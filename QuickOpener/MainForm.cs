using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

namespace QuickOpener
{
    public partial class MainForm : Form
    {
        private short _hotKeyId;
        private List<string> _history;
        private int _historyPointer = -1;

        private const int MOD_ALT = 0x0001;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;
        private const int MOD_NOREPEAT = 0x4000;

        public MainForm()
        {
            InitializeComponent();

            this.Location = new Point(Screen.GetWorkingArea(this).Width - Width, Screen.GetWorkingArea(this).Height - Height);

            _history = new List<string>();
        }

        [DllImport("user32", SetLastError=true)]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("kernel32", SetLastError = true)]
        private static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32", SetLastError = true)]
        private static extern short GlobalDeleteAtom(short nAtom);

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register the hot key information.
            string atomName = Guid.NewGuid().ToString();
            _hotKeyId = GlobalAddAtom(atomName);

            // Register CTRL+ALT+SPACE
            RegisterHotKey(Handle, _hotKeyId, MOD_CONTROL | MOD_ALT, (int)Keys.Space);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cleanup the hot key information.
            UnregisterHotKey(Handle, _hotKeyId);
            GlobalDeleteAtom(_hotKeyId);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x312)
            {
                // This handles when the hot key is pressed
                this.Show();
                this.Activate();
                txtCommand.Focus();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            // If enter was pressed...
            if (e.KeyValue == 13)
            {
                if (string.Compare("exit", txtCommand.Text.Trim(), true) == 0)
                {
                    this.Close();
                }
                else if (string.Compare("hide", txtCommand.Text.Trim(), true) == 0)
                {
                    this.Hide();

                    // Add the command to the history
                    _history.Add(txtCommand.Text);
                    _historyPointer = _history.Count;

                    txtCommand.Text = "";
                }
                else if (string.Compare("refresh", txtCommand.Text.Trim(), true) == 0)
                {
                    // trigger the application to re-read the config file
                    ConfigurationManager.RefreshSection("appSettings");

                    LogToScreen("config refreshed");

                    // Add the command to the history
                    _history.Add(txtCommand.Text);
                    _historyPointer = _history.Count;

                    txtCommand.Text = "";
                }
                else
                {
                    string path = "";
                    string args = "";
                    string command = txtCommand.Text.Trim();
                    string pathInfo = ConfigurationManager.AppSettings[command];


                    if (string.IsNullOrEmpty(pathInfo))
                    {
                        int indexOfPathEnd = command.IndexOf(' ');
                        if (indexOfPathEnd > 0)
                        {
                            path = command.Substring(0, indexOfPathEnd);
                            args = command.Substring(indexOfPathEnd + 1, command.Length - indexOfPathEnd - 1);
                        }
                        else
                        {
                            path = command;
                        }
                    }
                    else
                    {
                        string[] pathInfoArr = pathInfo.Split(',');
                        path = pathInfoArr[0];
                        if (pathInfoArr.Length > 1)
                        {
                            args = pathInfoArr[1];
                        }
                    }
                    Process p = new Process();
                    p.StartInfo.FileName = path;
                    if (!string.IsNullOrEmpty(args))
                    {
                        p.StartInfo.Arguments = args;
                    }

                    // Add the command to the history
                    _history.Add(command);
                    _historyPointer = _history.Count;

                    try
                    {
                        p.Start();
                        
                        LogToScreen(command);
                        txtCommand.Text = "";
                        this.Hide();
                    }
                    catch (Exception)
                    {
                        LogToScreen(string.Format("Error opening: {0}", command));
                        txtCommand.SelectAll();

                        _historyPointer--;
                    }

                    
                }
            }
            else if (e.KeyValue == (int)Keys.Escape)
            {
                // If Esc was pressed...
                this.Hide();
            }
            else if (e.KeyValue == (int)Keys.Up)
            {
                // If "Up" was pressed...
                if(_historyPointer > 0)
                {
                    txtCommand.Text = _history[--_historyPointer];
                    txtCommand.SelectAll();
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == (int)Keys.Down)
            {
                // If "Down" was pressed...
                if (_historyPointer < _history.Count - 1)
                {
                    txtCommand.Text = _history[++_historyPointer];
                    txtCommand.SelectAll();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void LogToScreen(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                lblOutput.Text += text + Environment.NewLine;
                pnlOutput.ScrollControlIntoView(lblScroller);
            }
        }

        private void pnlOutput_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this.Left + e.X + 5, this.Top + e.Y + 30);
            }
        }

        private void pnlOutput_DragDrop(object sender, DragEventArgs e)
        {
            // For now, only grab the first filename.  Basically I only want
            // to support adding one program/file at a time.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string fileName = files[0];

            AliasPrompt aliasPromptDialog = new AliasPrompt(fileName);
            aliasPromptDialog.ShowDialog();
        }

        private void pnlOutput_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                AliasPrompt aliasPromptDialog = new AliasPrompt(fileName);
                aliasPromptDialog.ShowDialog();
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
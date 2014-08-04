namespace QuickOpener
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.lblScroller = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlOutput.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.ForeColor = System.Drawing.Color.Cyan;
            this.txtCommand.Location = new System.Drawing.Point(0, 66);
            this.txtCommand.MaximumSize = new System.Drawing.Size(344, 20);
            this.txtCommand.MinimumSize = new System.Drawing.Size(344, 20);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(344, 20);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // pnlOutput
            // 
            this.pnlOutput.AllowDrop = true;
            this.pnlOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutput.AutoScroll = true;
            this.pnlOutput.Controls.Add(this.lblScroller);
            this.pnlOutput.Controls.Add(this.lblOutput);
            this.pnlOutput.Location = new System.Drawing.Point(0, 1);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(292, 69);
            this.pnlOutput.TabIndex = 1;
            this.pnlOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlOutput_DragDrop);
            this.pnlOutput.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlOutput_DragOver);
            this.pnlOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlOutput_MouseClick);
            // 
            // lblScroller
            // 
            this.lblScroller.AutoSize = true;
            this.lblScroller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblScroller.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScroller.Location = new System.Drawing.Point(0, 67);
            this.lblScroller.Name = "lblScroller";
            this.lblScroller.Size = new System.Drawing.Size(0, 2);
            this.lblScroller.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(4, 4);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 13);
            this.lblOutput.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addApplicationToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // addApplicationToolStripMenuItem
            // 
            this.addApplicationToolStripMenuItem.Name = "addApplicationToolStripMenuItem";
            this.addApplicationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addApplicationToolStripMenuItem.Text = "Add Application";
            this.addApplicationToolStripMenuItem.Click += new System.EventHandler(this.addApplicationToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(284, 86);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.txtCommand);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 125);
            this.MinimumSize = new System.Drawing.Size(300, 125);
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quick Opener";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblScroller;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    }
}


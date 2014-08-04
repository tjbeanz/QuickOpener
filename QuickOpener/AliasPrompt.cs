using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

namespace QuickOpener
{
    public partial class AliasPrompt : Form
    {
        string _fileName;
        public AliasPrompt(string fileName)
        {
            InitializeComponent();
            _fileName = fileName;
            lblFileName.Text = _fileName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()))
            {
                string aliasValue = ConfigurationManager.AppSettings[txtAlias.Text.Trim()];
                if (aliasValue != null)
                {
                    MessageBox.Show("The alias you entered already exists.  Please enter a unique alias.");
                }
                else
                {
                    // Save alias and file name to App.config.
                    
                    // Open the App.config of the executable
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);//Application.ExecutablePath);//ConfigurationUserLevel.None);

                    // Add an Application Setting
                    config.AppSettings.Settings.Add(txtAlias.Text.Trim(), _fileName);

                    // Save the chagnes in App.config
                    config.Save(ConfigurationSaveMode.Modified);

                    //Force a reload of the chagned section
                    ConfigurationManager.RefreshSection("appSettings");
                    
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You must enter an alias for the given file name.");
            }
        }

        private void AliasPrompt_Load(object sender, EventArgs e)
        {
            this.Activate();
            txtAlias.Focus();
        }

        private void txtAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
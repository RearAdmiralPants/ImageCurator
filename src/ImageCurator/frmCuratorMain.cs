namespace ImageCurator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using ImageCurator.Helpers;
    using ImageCurator.Resources;

    public partial class frmCuratorMain : Form
    {
        private OldUserSettingsProvider settingsProvider;

        public frmCuratorMain()
        {
            InitializeComponent();

            this.settingsProvider = new OldUserSettingsProvider();
            this.settingsProvider.SettingUpdated += this.SettingsProvider_SettingUpdated;
            
        }

        private void SettingsProvider_SettingUpdated(object sender, CustomEvents.SettingUpdatedEventArgs args)
        {
            switch (args.SettingName)
            {
                case Constants.Configuration.ROOT_IMAGE_PATH:
                    this.tsRootDirectoryLabel.Text = (string)args.SettingValue;
                    break;
                default:
                    break;
            }
        }

        private void Ui_UpdateRootDirectory()
        {
            this.tsRootDirectoryLabel.Text = this.settingsProvider.RootPath;
        }

        private void tsRootFolderButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.settingsProvider.RootPath = this.folderBrowser.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.settingsProvider.RootPath);
        }
    }
}

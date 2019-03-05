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

    public partial class frmCuratorMain : Form
    {
        private UserSettingsProvider settingsProvider;

        public frmCuratorMain()
        {
            InitializeComponent();

            this.settingsProvider = new UserSettingsProvider();
        }

        private void tsRootFolderButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.settingsProvider.RootPath = this.folderBrowser.SelectedPath;
            }
        }
    }
}

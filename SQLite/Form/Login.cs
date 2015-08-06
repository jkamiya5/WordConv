using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordConvertTool
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            string dataSourcePath = ConfigurationManager.AppSettings.Get("DataSource");
            string applicationBase = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            dataSourcePath = dataSourcePath.Replace("|DataDirectory|", applicationBase);
            dataSourcePath = dataSourcePath.Replace("Data Source=", "");
            this.dataSourcePath.Text = dataSourcePath;
            this.UserId.Text = ConfigurationManager.AppSettings.Get("UserId");
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(this.dataSourcePath.Text);
            ofd.FileName = Path.GetFileName(this.dataSourcePath.Text);

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.dataSourcePath.Text = ofd.FileName;
            }
        }
    }
}

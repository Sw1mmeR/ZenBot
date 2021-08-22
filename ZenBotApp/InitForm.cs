using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZenBotApp.ShellLink;

namespace ZenBotApp
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
        }
        private async void InitForm_Load(object sender, EventArgs e)
        {
            filecheckBar.Maximum = 5;
            FileManager.Delay = 100;
            FileManager.FileLabel = fileLabel;

            await FileManager.CheckDirAsync(@"\ZenBotApp", filecheckBar);
            await FileManager.CheckDirAsync(@"\ZenBotApp\Accounts", filecheckBar);
            await FileManager.CheckDirAsync(@"\ZenBotApp\assets", filecheckBar);
            await FileManager.CheckDirAsync(@"\ZenBotApp\Cookies");

            await FileManager.CheckFileAsync(@"\ZenBotApp\settings.txt");
            await FileManager.CheckFileAsync(@"\ZenBotApp\log.txt");

            //ShortCut.Create(FileManager.Path + @"\ZenBotApp\ZenBot\ZenBotApp.exe", FileManager.Path + @"\ZenBotApp\ZenBotApp.lnk", "", "ZenBotApp");

            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }
    }
}

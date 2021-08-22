using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.ZenBot;

namespace ZenBotApp
{
    public partial class MainForm : Form
    {
        public int time;
        public MainForm()
        {
            InitializeComponent();
            menuStrip1.Cursor = Cursors.Hand;
        }
        private UserSettings ThisUserSettings { get; set; }
        private List<FormManager> ListForms { get; set; } = new List<FormManager>();
        public static InsertParamsForm ParamsForm { get; set; }
        public static List<Task> TaskListInsertForm { get; private set; } = new List<Task>(10);
        private async void startBtn_Click(object sender, EventArgs e)
        {
            getDataTimer.Interval = 1000 * 60 * YandexHandler.ThisInsertSettings.TimerInterval;

            foreach (var form in ListForms)
                form.Dispose();
            if(getDataTimer.Enabled == true)
            {
                startBtn.Text = "Мониторить";
                StartMonitoring();
                return;
            }
            time = getDataTimer.Interval / 1000;
            startBtn.Text = "Стоп (" + time.ToString() + ")";

            usersContainer.Enabled = false;
            startBtn.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            if (YandexHandler.Handler != null)
            {
                YandexHandler.Handler = new List<Yandex.ZenBot.Yandex>();
            }
            var counter = FileManager.CountUsers();
            var allUsers = FileManager.GetListFiles();
            for (int i = 0; i < counter; ++i)
            {
                string userData = "";
                using (StreamReader reader = new StreamReader(allUsers[i]))
                {
                    userData = reader.ReadToEnd();
                }

                var json = JsonConvert.DeserializeObject<UserSettings>(userData);

                YandexHandler.Handler.Add(new Yandex.ZenBot.Yandex(json));
            }

            await YandexHandler.GetPublicationsStats();
            usersContainer.Enabled = true;
            startBtn.Enabled = true;

            StartMonitoring();
        }
        private void StartMonitoring()
        {
            if (getDataTimer.Enabled == true)
            {
                getDataTimer.Stop();
                tickTimer.Stop();
            }
            else
            {
                getDataTimer.Start();
                tickTimer.Start();
            }
        }
        private async void getDataTimer_Tick(object sender, EventArgs e)
        {
            await YandexHandler.GetPublicationsStats();

            bool isChange = false;
            if (YandexHandler.ThisInsertSettings.CheckChangeForm)
                isChange = true;
            if (YandexHandler.Handler.Count > 0)
            {
                int views = YandexHandler.ThisInsertSettings.Views;
                int likes = YandexHandler.ThisInsertSettings.Likes;
                if (!YandexHandler.ThisInsertSettings.CheckViews)
                    views = -1;
                if (!YandexHandler.ThisInsertSettings.CheckLikes)
                    likes = -1;
                foreach (var handle in YandexHandler.Handler)
                {
                    foreach (var element in handle.ListStats)
                    {
                        TaskListInsertForm.Add(handle.InsertForm(element.Id, handle.Form_id, views, likes));
                        if (!element.IsFormInserted || element.Status == "processing" || element.Likes <= likes || element.Views <= views)
                            isChange = false;
                    }
                    await Task.WhenAll(TaskListInsertForm);
                    TaskListInsertForm.Clear();

                    if (YandexHandler.ThisInsertSettings.CheckChangeForm && isChange)
                    {
                        if(await handle.ChangeForm(YandexHandler.ThisInsertSettings.Text, ""))
                            YandexHandler.ThisInsertSettings.CheckChangeForm = false;
                    }
                }
            }
        }
        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(FileManager.Path + @"\ZenBotApp\settings.txt"))
            {
                var str = reader.ReadToEnd();
                YandexHandler.ThisInsertSettings = JsonConvert.DeserializeObject<InsertSettings>(str);
            }
            if (usersContainer.Items.Count > 0)
                usersContainer.Items.Clear();

            var fileList = await FileManager.GetAllFiles(@"\ZenBotApp\Accounts");
            if (fileList.Count > 0)
            {
                foreach (var file in fileList)
                {
                    var splited = file.Split('\\');
                    var userFileName = splited[splited.Length - 1];
                    var username = userFileName.Substring(0, userFileName.IndexOf(".txt"));
                    usersContainer.Items.Add(username);
                }
            }
        }
        private void authBtn_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "" || passField.Text == "" || formIdBox.Text == "" || (YandexHandler.ThisInsertSettings.CheckChangeForm && linkBox.Text == ""))
            {
                MessageBox.Show("Заполнены не все поля!");
                return;
            }
            if(proxyLoginField.Text == "" || proxyPassField.Text == "" || proxyAddressField.Text == "")
            {
                DialogResult result = MessageBox.Show(
                    "Прокси не установлен! Продолжить?",
                    "Прокси",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                    return;
            }
            
            ThisUserSettings = new UserSettings(
                loginField.Text,
                passField.Text,
                formIdBox.Text,
                linkBox.Text,
                new UserProxy(proxyLoginField.Text, proxyPassField.Text, proxyAddressField.Text));

            var json = JsonConvert.SerializeObject(ThisUserSettings);

            FileManager.SaveUser(loginField.Text, json);
            loginField.Text = ""; passField.Text = ""; formIdBox.Text = "";
            proxyAddressField.Text = ""; proxyPassField.Text = ""; proxyLoginField.Text = "";
            linkBox.Text = "";
            MainForm_LoadAsync(sender, e);
        }
        //
        // UsersContainer
        //
        private void usersContainer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (usersContainer.SelectedItem == null) return;
            Rectangle itemRect = usersContainer.GetItemRectangle(usersContainer.SelectedIndex);
            if (itemRect.Contains(e.Location))
            {
                if (ListForms.Exists(x => x.Login == usersContainer.SelectedItem.ToString()))
                {
                    ListForms.Find(x => x.Login == usersContainer.SelectedItem.ToString()).Dispose();
                    ListForms.Find(x => x.Login == usersContainer.SelectedItem.ToString()).CreateStatsForm();
                }
                else
                {
                    ListForms.Add(new FormManager(usersContainer.SelectedItem.ToString()));
                    ListForms.Find(x => x.Login == usersContainer.SelectedItem.ToString()).CreateStatsForm();
                }
            }
        }
        private void usersContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = usersContainer.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    if (usersContainer.SelectedIndex == index)
                    {
                        usersContainer.ContextMenuStrip.Visible = true;
                    }
                    else
                    {
                        usersContainer.ContextMenuStrip.Visible = false;
                    }
                }
                else
                {
                    usersContainer.ContextMenuStrip.Visible = false;
                }
            }
            else
                return;
        }
        //
        //
        //
        private void showPassBox_CheckedChanged(object sender, EventArgs e)
        {
            passField.PasswordChar = showPassBox.Checked ? '\0' : '*';
        }
        private void showPassBtn_Click(object sender, EventArgs e)
        {
            if (showPassBox.Checked == true)
                showPassBox.Checked = false;
            else
                showPassBox.Checked = true;
        }
        //
        

        private void deleteUserMenuStrip_Click(object sender, EventArgs e)
        {
            string filePath = FileManager.Path + @"\ZenBotApp\Accounts\" + usersContainer.SelectedItem.ToString() + ".txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            usersContainer.Items.Remove(usersContainer.SelectedItem);
        }
        private void tickTimer_Tick(object sender, EventArgs e)
        {
            if(time == 0)
                time = getDataTimer.Interval / 1000;
            time = --time;
            startBtn.Text = "Стоп (" + (time).ToString() + ")";
        }
        private void insertParams_Click(object sender, EventArgs e)
        {
            if (ParamsForm == null)
                ParamsForm = new InsertParamsForm();
            else
                ParamsForm.Hide();
            if(ParamsForm.Visible == false)
                ParamsForm.Show();
        }
        private void openDirToolStrip_Click(object sender, EventArgs e)
        {
            Process.Start($"{FileManager.Path}\\ZenBotApp");
        }

        private void logFileToolStrip_Click(object sender, EventArgs e)
        {
            Process.Start($"{FileManager.Path}\\ZenBotApp\\log.txt");
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

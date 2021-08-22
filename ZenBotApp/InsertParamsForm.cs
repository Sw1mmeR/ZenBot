using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZenBotApp
{
    public partial class InsertParamsForm : Form
    {
        public InsertParamsForm()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int likes;
            int views;
            int interval;
            if(!Int32.TryParse(likesBox.Text, out likes) || !Int32.TryParse(viewsBox.Text, out views) || !Int32.TryParse(timerBox.Text, out interval))
            {
                MessageBox.Show("Неверный формат данных!");
                return;
            }
            if (interval == 0)
                interval = 1;
            using (StreamWriter writer = new StreamWriter(FileManager.Path + @"\ZenBotApp\settings.txt"))
            {
                var obj = new InsertSettings(
                    likes,
                    views,
                    formTextBox.Text,
                    likesCheckBox.Checked,
                    viewsCheckBox.Checked,
                    interval,
                    changeFormBox.Checked);
                writer.Write(JsonConvert.SerializeObject(obj));
                YandexHandler.ThisInsertSettings = obj;                
            }

            this.Hide();
        }

        private void InsertParamsForm_Load(object sender, EventArgs e)
        {
            likesBox.Text = YandexHandler.ThisInsertSettings.Likes.ToString();
            viewsBox.Text = YandexHandler.ThisInsertSettings.Views.ToString();
            formTextBox.Text = YandexHandler.ThisInsertSettings.Text;
            likesCheckBox.Checked = YandexHandler.ThisInsertSettings.CheckLikes;
            viewsCheckBox.Checked = YandexHandler.ThisInsertSettings.CheckViews;
            timerBox.Text = YandexHandler.ThisInsertSettings.TimerInterval.ToString();
            changeFormBox.Checked = YandexHandler.ThisInsertSettings.CheckChangeForm;
        }

        private void InsertParamsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.ParamsForm = null;
        }
    }
}

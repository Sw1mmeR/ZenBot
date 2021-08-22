using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZenBotApp
{
    public partial class UserTemplateForm : Form
    {
        public UserTemplateForm()
        {
            InitializeComponent();

        }

        private void UserTemplateForm_Load(object sender, EventArgs e)
        {
            foreach (var handle in YandexHandler.Handler)
            {
                if (handle.Login == this.Text)
                {
                    dataGridView1.DataSource = handle.ListStats;
                }
            }
            if (dataGridView1.Rows.Count == 0 || dataGridView1 == null)
            {
                MessageBox.Show($"Вероятнее всего возникла ошибка. Подробности: {FileManager.Path + @"\ZenBotApp\log.txt"}");
                this.Dispose();
            }
        }
    }
}

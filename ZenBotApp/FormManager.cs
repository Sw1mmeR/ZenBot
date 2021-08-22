using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZenBotApp
{
    public class FormManager
    {
        public ListBox UserContainer { get; private set; }
        public UserTemplateForm ThisForm { get; private set; }
        public string Login { get; private set; }
        public FormManager(string userContainer)
        {
            Login = userContainer;
        }        
        public void CreateStatsForm()
        {
            ThisForm = new UserTemplateForm
            {
                Text = Login,
                //Width = width,
                //Height = height                
            };

            //CreateDataGrid();

            ThisForm.Show();
        }
        public void Dispose()
        {
            ThisForm.Dispose();
        }
        ~FormManager()
        {
            ThisForm.Dispose();
        }
    }
}

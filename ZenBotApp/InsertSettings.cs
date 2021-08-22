using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBotApp
{
    public class InsertSettings
    {
        public int Likes { get; set; }
        public int Views{ get; set; }
        public string Text { get; set; }
        public bool CheckChangeForm { get; set; }
        public bool CheckLikes { get; set; }
        public bool CheckViews { get; set; }
        public int TimerInterval { get; set; }
        public InsertSettings(int likes, int views, string text, bool checkLikes, bool checkViews, int interval, bool checkChangeForm)
        {
            Likes = likes;
            Views = views;
            Text = text;
            CheckLikes = checkLikes;
            CheckViews = checkViews;
            TimerInterval = interval;
            CheckChangeForm = checkChangeForm;
        }
    }
}

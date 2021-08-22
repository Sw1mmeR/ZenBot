using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.ZenBot
{
    public class PasswordData
    {
        public string CSRF { get; set; }
        public string Track_id { get; set; }
        public PasswordData(string newCsrf, string track_id)
        {
            CSRF = newCsrf;
            Track_id = track_id;
        }
        public string Show()
        {
            return ($"csrf_token={CSRF}\ntrack_id={Track_id}");
        }
    }
}

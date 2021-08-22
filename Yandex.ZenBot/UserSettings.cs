using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.ZenBot
{
    public class UserSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Form_id { get; set; }
        public string Form_link { get; set; }
        public UserProxy Proxy { get; set; }
        public UserSettings(string username, string pass, string formId, string formLink, UserProxy proxy)
        {
            Username = username;
            Password = pass;
            Form_id = formId;
            Form_link = formLink;
            Proxy = proxy;
        }
    }
    public class UserProxy
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public UserProxy(string login, string pass, string address)
        {
            Login = login;
            Password = pass;
            Address = address;
        }
    }
}

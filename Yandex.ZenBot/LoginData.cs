using System.Net;

namespace Yandex.ZenBot
{
    public class LoginData
    {
        public Cookie Yandexuid { get; set; }
        public Cookie Uniqueid { get; set; }
        public string CSRF { get; set; }
        public string Process_Uuid { get; set; }
        public LoginData(Cookie uid, Cookie uniqueid, string csrf, string process_uuid)
        {
            Yandexuid = uid;
            Uniqueid = uniqueid;
            CSRF = csrf;
            Process_Uuid = process_uuid;
        }
        public string Show()
        {
            return ($"{Yandexuid}\n{Uniqueid}\nCSRF={CSRF}\nprocess_uuid={Process_Uuid}");
        }
    }
}

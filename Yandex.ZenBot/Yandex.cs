using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yandex.ZenBot
{
    public class Yandex
    {
        public static int YandexId { get; private set; } = 0;
        public HttpClientHandler Handler { get; private set; } = null;
        public HttpClient Client { get; private set; } = null;
        public WebProxy MyProxy { get; private set; } = null;
        public LoginData ThisLoginData { get; private set; }
        public Cookie Session_id { get; private set; }
        public PasswordData ThisPasswordData { get; private set; }
        public CookieContainer YandexCookieContainer = new CookieContainer();
        public bool CookieIsSet { get; private set; } = false;
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Channel_id { get; set; }
        public string Form_id { get; set; }
        public string Form_Link { get; set; }
        public bool IsFormInserted { get; private set; } = false;
        public bool TryInsert { get; private set; } = false;
        public bool IsFormResponseGetted { get; private set; } = false;
        public List<string> LogList { get; private set; } = new List<string>();
        public List<PublicationsStats> ListStats { get; private set; } = new List<PublicationsStats>();
        public bool IsFormChanged { get; private set; } = false;

        //public CookieCollection YandexCookieCollection = new CookieCollection();
        private static readonly string YandexBaseAddress = "https://passport.yandex.ru";
        private static readonly string LoginLink = @"https://passport.yandex.ru/registration-validations/auth/multi_step/start";
        private static readonly string PasswordLink = @"https://passport.yandex.ru/registration-validations/auth/multi_step/commit_password";

        public Yandex(string login, string password, string proxy_login = null, string proxy_pass = null, string address = null)
        {
            Login = login;
            Password = password;

            if (proxy_login != null)
                SetProxy(proxy_login, proxy_pass, address);
            Handler = SetHttpHandler();
            Client = SetHttpClient(YandexBaseAddress);

            ++YandexId;
        }
        public Yandex(UserSettings user)
        {
            Login = user.Username;
            Password = user.Password;
            Form_id = user.Form_id;
            Form_Link = user.Form_link;

            if (user.Proxy.Login != "")
                SetProxy(user.Proxy.Login, user.Proxy.Password, user.Proxy.Address);
            Handler = SetHttpHandler();
            Client = SetHttpClient(YandexBaseAddress);
        }
        public async Task StartAsync()
        {
            if (Session_id != null)
                return;
            try
            {
                await GetLoginDataAsync();

                await SendLoginDataAsync(LoginLink, CreateLoginBody());

                await SendPasswordDataAsync(PasswordLink, CreatePassBody());
            }
            catch (NullReferenceException ex)
            {
                LogList.Add($"Не удалось получить авторизационные данные /{ex.Message}");
            }
        }
        public bool WriteCookie(string file)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, YandexCookieContainer);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool ReadCookies(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    YandexCookieContainer = (CookieContainer)formatter.Deserialize(stream);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool SetProxy(string login, string pass, string address)
        {
            try
            {
                NetworkCredential Credentials = new NetworkCredential(login, pass);
                MyProxy =
                    new WebProxy(new Uri("http://" + address))
                    {
                        UseDefaultCredentials = false,
                        Credentials = Credentials
                    };
                return true;
            }
            catch (HttpRequestException ex)
            {
                LogList.Add($"Ошибка прокси!/{ex.Message}");
                return false;
            }
        }
        private HttpClientHandler SetHttpHandler()
        {
            var handler = new HttpClientHandler() { CookieContainer = YandexCookieContainer };

            if (MyProxy != null)
            {
                handler.Proxy = MyProxy;
                handler.PreAuthenticate = true;
                handler.UseDefaultCredentials = false;
            }
            return handler;
        }
        private HttpClient SetHttpClient(string url)
        {
            var client = new HttpClient(Handler)
            {
                BaseAddress = new Uri(url)

            };
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            return client;
        }
        private async Task SendLoginDataAsync(string url, FormUrlEncodedContent postData)
        {
            var response = await Client.PostAsync(url, postData);

            string data;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();

                JObject password_data = JObject.Parse(data);

                ThisPasswordData = new PasswordData((string)password_data["csrf_token"],
                    (string)password_data["track_id"]);
            }
            else
            {
                LogList.Add("Произошла ошибка при отправке запроса. Проверьте логин!");
            }
        }
        private async Task SendPasswordDataAsync(string url, FormUrlEncodedContent postData)
        {
            var response = await Client.PostAsync(url, postData);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                LogList.Add("Произошла ошибка при отправке запроса. Проверьте пароль!");
                return;
            }
            Session_id = YandexCookieContainer.GetCookies(
            new Uri(YandexBaseAddress)).Cast<Cookie>().FirstOrDefault(x => x.Name == "Session_id");

            //LogList.Add(Session_id);
        }
        private async Task GetLoginDataAsync(string url = "")
        {
            HttpResponseMessage response = null;
            try
            {
                response = await Client.GetAsync(url);
            }
            catch (WebException ex)
            {
                LogList.Add($"Произошла ошибка прокси!/{ex.Message}");
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                LogList.Add("Не удалось начать процесс авторизации. Проверьте прокси!");
                return;
            }
            var data = await response.Content.ReadAsStringAsync();

            var yandexuid = YandexCookieContainer.GetCookies(new Uri(YandexBaseAddress)).Cast<Cookie>().FirstOrDefault(x => x.Name == "yandexuid");
            var uniqueid = YandexCookieContainer.GetCookies(new Uri(YandexBaseAddress)).Cast<Cookie>().FirstOrDefault(x => x.Name == "uniqueuid");
            string csrf = "";
            string process_uuid = "";
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(data);
                csrf = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='csrf_token']").GetAttributeValue("value", null);
                var process_uuid_href = htmlDoc.DocumentNode.SelectSingleNode("//a[@data-t='button:pseudo']").GetAttributeValue("href", null);
                var process_uuid_href_splited = process_uuid_href.Split(';')[1];
                process_uuid = process_uuid_href_splited.Split('=')[1];
            }
            catch (NullReferenceException ex)
            {
                LogList.Add($"Не удалось получить csrf-token. multi_step/start error./{ex.Message}");
            }
            if (csrf == "" || process_uuid == "")
                return;
            ThisLoginData = new LoginData(yandexuid, uniqueid, csrf, process_uuid);
        }
        private FormUrlEncodedContent CreateLoginBody()
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", Login), // login field
                new KeyValuePair<string, string>("csrf_token", ThisLoginData .CSRF), // csrf-token field
                new KeyValuePair<string, string>("process_uuid", ThisLoginData .Process_Uuid), // process_uuid field
                new KeyValuePair<string, string>("retpath", @"https://zen.yandex.ru"),
                new KeyValuePair<string, string>("origin", "zen_header_entry")
            });
        }
        public FormUrlEncodedContent CreatePassBody()
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", Password), // login field
                new KeyValuePair<string, string>("csrf_token", ThisLoginData.CSRF), // csrf-token field
                new KeyValuePair<string, string>("track_id", ThisPasswordData.Track_id), // process_uuid field
                new KeyValuePair<string, string>("retpath", @"https://zen.yandex.ru"),
            });
        }
        //
        // Monitoring
        //
        public async Task GetStatsAsync(string publicationStatus = "published", int count = 500)
        {
            string[] preChannelId = null;
            try
            {
                var getChannelIdResponse = await Client.GetAsync("https://zen.yandex.ru/media/zen/new");
                var getChannelId = await getChannelIdResponse.Content.ReadAsStringAsync();
                var prepreChannelId = getChannelId.Substring(getChannelId.IndexOf("publisherId"));
                preChannelId = prepreChannelId.Substring(0, prepreChannelId.IndexOf(",")).Split('\"');
            }
            catch (Exception ex)
            {
                LogList.Add(ex.Message);
            }

            Channel_id = preChannelId[preChannelId.Length - 2];

            string csrf = "";
            try
            {
                var x_csrf_get_data = await Client.GetAsync($"https://zen.yandex.ru/profile/editor/id/{Channel_id}");
                var x_csrf_get_data_response = await x_csrf_get_data.Content.ReadAsStringAsync();
                var csrf_with_equals = x_csrf_get_data_response.Substring(x_csrf_get_data_response.IndexOf("csrfToken")).Split(';')[0];
                var pre_csrf = csrf_with_equals.Split(' ');
                csrf = pre_csrf[pre_csrf.Length - 1].Trim('"');
            }
            catch (ArgumentOutOfRangeException ex)
            {
                LogList.Add($"Не удалось спарсить X-Csrf-Token. Id канала: {Channel_id}/{ex.Message}");
            }

            Client.DefaultRequestHeaders.Add("X-Csrf-Token", csrf);
            var response = await Client.GetAsync($"https://zen.yandex.ru/editor-api/v2/get-publications-by-state?state={publicationStatus}&pageSize={count}&publisherId={Channel_id}");
            var json = await response.Content.ReadAsStringAsync();
            Client.DefaultRequestHeaders.Remove("X-Csrf-Token");
            JToken arr = null;
            try
            {
                JObject obj = JObject.Parse(json);
                arr = obj["publications"];
            }
            catch (JsonReaderException ex)
            {
                LogList.Add($"Не удалось получить параметры публикаций/{ex.Message}");
            }
            if (arr != null)
            {
                foreach (var element in arr)
                {
                    if (ListStats.Exists(x => x.Id == (string)element["id"]))
                    {
                        ListStats.Find(x => x.Id == (string)element["id"])
                            .ChangePublicationsStats(
                        (string)element["content"]["preview"]["title"],
                        (int)element["privateData"]["statistics"]["views"],
                        (int)element["privateData"]["statistics"]["likes"],
                        (string)element["privateData"]["status"],
                        (string)element["titleForUrl"]);
                    }
                    else
                    {
                        ListStats.Add(new PublicationsStats(
                        (string)element["id"], (string)element["content"]["preview"]["title"],
                        (int)element["privateData"]["statistics"]["views"],
                        (int)element["privateData"]["statistics"]["likes"],
                        (string)element["privateData"]["status"],
                        (string)element["titleForUrl"]));
                    }
                }
            }
            else
            {
                LogList.Add("Json объект null");
            }
        }
        public async Task InsertForm(string id, string formId, int maxViews = 0, int maxLikes = 0)
        {
            TryInsert = true;
            if (ListStats.Find(x => x.Id == id).IsFormInserted)
            {
                ListStats.Find(x => x.Id == id).Comment = "Inserted";
                return;
            }
            string link = "";
            HttpResponseMessage response;
            string data = "";
            foreach (var publication in ListStats)
            {
                if (publication.Id == id)
                {
                    if (publication.Views >= maxViews & publication.Likes >= maxLikes)
                    {
                        link = $"https://zen.yandex.ru/media/id/{Channel_id}/{publication.TitleForUrl}-{publication.Id}?from=editor";
                        try
                        {
                            response = await Client.GetAsync(link);
                            data = await response.Content.ReadAsStringAsync();

                            IsFormResponseGetted = true;
                        }
                        catch (WebException)
                        {
                            IsFormResponseGetted = false;

                            LogList.Add("Произошла ошибка при отправке запроса вставки формы.");
                        }
                    }
                    else
                    {
                        ListStats.Find(x => x.Id == id).Comment = "Low parameters";
                        return;
                    }
                }
            }
            if (data != "")
            {
                var csrf_with_equals = data.Substring(data.IndexOf("csrfToken")).Split(';')[0];
                var pre_csrf = csrf_with_equals.Split(' ');
                var csrf = pre_csrf[pre_csrf.Length - 1].Trim('"');

                var cut = data.Substring(data.IndexOf("contentState"));
                var cut2 = cut.Substring(0, cut.LastIndexOf("inlineStyleRanges"));

                cut2 = cut2.Substring(0, cut2.LastIndexOf("data"));

                var res = cut2.Trim(new char[] { ',', '{', '"' }) + "]}";
                res = res.Trim(new char[] { 'c', 'o', 'n', 't', 'e', 'n', 't', 'S', 't', 'a', 't', 'e', '"', ':', '"' });
                res = res.Remove(res.Length - 5, 3);

                var result = res.Replace("\\\\\\\"", "|||@@@").Replace("\\", String.Empty).Replace("|||@@@", "\\\"");
                
                Console.WriteLine(result);
                Console.WriteLine();
                
                JObject json = null;

                try
                {
                    json = JObject.Parse(result);
                }
                catch (Exception ex)
                {
                    LogList.Add($"{ex.Message}. {ex.Data}. {ex.StackTrace}");
                }

                if(json != null)
                {
                    if ((string)json["blocks"].Last["text"] != null)
                    {
                        if ((string)json["blocks"].Last["text"] != "")
                        {
                            ListStats.Find(x => x.Id == id).Comment = "Нет пустой строки!";
                        }
                        if ((string)json["blocks"].Last["data"]["embedData"]["type"] == "yandex-forms")
                        {
                            ListStats.Find(x => x.Id == id).Comment = "Inserted";
                        }
                    }

                    json["blocks"].Last["key"] = "";
                    json["blocks"].Last["type"] = "atomic:embed";
                    json["blocks"].Last["data"] = JObject.Parse("{\"embedData\":{\"type\": \"yandex-forms\",\"formId\": \"" + formId + "\"}}");

                    var serialized = JsonConvert.SerializeObject(json);
                    //serialized = serialized.Replace("\\", "\\\\");

                    JsonInsert jsonInsert = new JsonInsert(id, new ArticleContent(serialized));
                    var strToSend = JsonConvert.SerializeObject(jsonInsert);

                    string insertLink = $"https://zen.yandex.ru/editor-api/v2/update-publication-content-and-publish?publisherId={Channel_id}";
                    Client.DefaultRequestHeaders.Add("X-Csrf-Token", csrf);
                    Client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var content = new StringContent(strToSend, Encoding.UTF8, "application/json");
                    var insertResponse = await Client.PostAsync(insertLink, content);
                    var responseJson = JObject.Parse(await insertResponse.Content.ReadAsStringAsync());
                    
                    Client.DefaultRequestHeaders.Remove("X-Csrf-Token");
                    Client.DefaultRequestHeaders.Remove("Accept");

                    IsFormInserted = true;
                    ListStats.Find(x => x.Id == id).IsFormInserted = true;


                    if (responseJson["result"] != null)
                        ListStats.Find(x => x.Id == id).Comment = responseJson["result"].ToString();
                    if (responseJson["errors"] != null)
                        ListStats.Find(x => x.Id == id).Comment = responseJson["errors"][0]["type"].ToString();
                }
                else
                {
                    LogList.Add("Json is null");
                }
            }
            else
            {
                ListStats.Find(x => x.Id == id).Comment = "String data is null";
                return;
            }
        }
        public async Task<bool> CheckProxy()
        {
            var response = await Client.GetAsync("https://yandex.ru/internet/");
            var data = await response.Content.ReadAsStringAsync();
            using (StreamWriter writer = new StreamWriter("foo.html"))
            {
                writer.Write(data);
            }

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load("foo.html");

            var ip = doc.DocumentNode.SelectNodes("//li[@class='parameter-wrapper general-info__parameter']//div")[1];

            if (ip.InnerText == Convert.ToString(MyProxy.Address).Split(':')[1].Trim('/'))
                return true;
            else
                return false;
        }
        public async Task<bool> ChangeForm(string text, string url)
        {
            if (Form_Link != null)
                url = Form_Link;
            HttpResponseMessage response = null;
            string data = "";
            try
            {
                response = await Client.GetAsync(url);
                data = await response.Content.ReadAsStringAsync();
            }
            catch (WebException ex)
            {
                LogList.Add("Произошла ошибка отправки запроса. Изменение формы\n" + ex.Message);
                return false;
            }
            JObject json = null;
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(data);
                var pre_json = htmlDoc.DocumentNode.SelectSingleNode("//body").GetAttributeValue("data-bem", null);
                json = JObject.Parse(pre_json);
            }
            catch (Exception ex)
            {
                LogList.Add("Не удалось спарсить json.\n" + ex.Message);
                return false;
            }

            var secretKey = (string)json["i-global"]["secretkey"];
            string data_form = "{\"label\":\"" + text + "\",\"param_slug\":null,\"" +
               "param_help_text\":\"\",\"param_is_required\":false,\"param_is_hidden\":false," +
               "\"label_image\":null,\"param_is_section_header\":false}";

            var splited = url.Split('/');
            var index = splited[5].Split('=');

            var form_insert = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("data", data_form), // login field
                    new KeyValuePair<string, string>("method", "PATCH"), // csrf-token field
                    new KeyValuePair<string, string>("path[name]", "survey-question"), // process_uuid field
                    new KeyValuePair<string, string>("path[params][id]", index[index.Length - 1]),
                    new KeyValuePair<string, string>("query[survey]", splited[4])
                });

            Client.DefaultRequestHeaders.Add("csrf-token", secretKey);

            HttpResponseMessage result = null;
            try
            {
                result = await Client.PostAsync(@"https://forms.yandex.ru/admin/_api", form_insert);
            }
            catch (WebException ex)
            {
                LogList.Add("Произошла ошибка отправки запроса. Изменение формы.\n" + ex.Message);
                return false;
            }

            Client.DefaultRequestHeaders.Remove("csrf-token");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                IsFormChanged = true;
                return true;
            }
            else
            {
                LogList.Add("Произошла ошибка при отправке запроса на изменение формы");
            }
            return false;
        }
        public async Task WriteExceptions(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (var line in LogList)
                {
                    await Task.Run(() => writer.WriteLineAsync(line + " [" + DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + "]"));
                }
            }
        }
        ~Yandex()
        {
            Client.Dispose();
            Handler.Dispose();
        }
    }
}

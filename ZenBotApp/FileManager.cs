using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZenBotApp
{
    public static class FileManager
    {
        public static Label FileLabel { get; set; }
        public static int Delay { get; set; }
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static async Task<List<string>> GetAllFiles(string path)
        {
            path = Path + path;
            return await Task.Run(() => Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList());
        }
        public static string[] GetListFiles()
            => Directory.GetFiles(Path + @"\ZenBotApp\Accounts");
        public static void SaveUser(string login, string json)
        {
            var path = Path + @"\ZenBotApp\Accounts\" + login + ".txt";

            //using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))

            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(json);
            }
        }
        public static async Task<DirectoryInfo> CheckDirAsync(string path, ProgressBar bar = null)
        {
            path = Path + path;
            FileLabel.Text = path;
            if (bar != null) ++bar.Value;
            await Task.Delay(Delay);
            return await Task.Run(() => (!Directory.Exists(path) ? Directory.CreateDirectory(path) : null));
        }
        public static async Task<FileStream> CheckFileAsync(string path, ProgressBar bar = null)
        {
            path = Path + path;
            FileLabel.Text = path;
            if (bar != null) ++bar.Value;
            await Task.Delay(Delay);
            return await Task.Run(() => (!File.Exists(path) ? File.Create(path) : null));
        }
        public static int CountUsers()
            => new DirectoryInfo(Path + @"\ZenBotApp\Accounts").GetFiles().Length;
        /*
        public static async Task GetJson(string login)
        {
            var path = Path + @"\ZenBotApp\Accounts\" + login + ".txt";
            using (StreamReader reader = new StreamReader(Path))
            {

            }
        }
        */
    }
}

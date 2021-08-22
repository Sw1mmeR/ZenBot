using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.ZenBot;

namespace ZenBotApp
{
    public static class YandexHandler
    {
        public static List<Yandex.ZenBot.Yandex> Handler { get; set; } = new List<Yandex.ZenBot.Yandex>();
        public static InsertSettings ThisInsertSettings { get; set; }
        public static List<Task> TaskListStart { get; private set; } = new List<Task>();
        public static List<Task> TaskListGetStats { get; private set; } = new List<Task>();

        public static async Task GetPublicationsStats()
        {
            foreach (var handle in Handler)
                TaskListStart.Add(handle.StartAsync());
            await Task.WhenAll(TaskListStart);

            foreach (var handle in Handler)
                TaskListGetStats.Add(handle.GetStatsAsync());
            await Task.WhenAll(TaskListGetStats);
            foreach (var handle in Handler)
                await handle.WriteExceptions(FileManager.Path + "/ZenBotApp/log.txt");

            TaskListStart.Clear();
            TaskListGetStats.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.ZenBot
{
    public class PublicationsStats
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public int Views { get; private set; }
        public int Likes { get; private set; }
        public string Status { get; private set; }
        public string Comment { get; set; }
        public string TitleForUrl { get; private set; }
        public bool IsFormInserted { get; set; } = false;
        public PublicationsStats(string id, string title, int views, int likes, string status, string titleForUrl, string comment = null)
        {
            Id = id;
            Title = title;
            Views = views;
            Likes = likes;
            Status = status;
            Comment = comment;
            TitleForUrl = titleForUrl;
        }
        public void ChangePublicationsStats(string title, int views, int likes, string status, string titleForUrl, string comment = null)
        {
            Title = title;
            Views = views;
            Likes = likes;
            Status = status;
            Comment = comment;
            TitleForUrl = titleForUrl;
        }
    }
}

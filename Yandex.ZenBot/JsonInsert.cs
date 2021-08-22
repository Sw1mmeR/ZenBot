using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.ZenBot
{
    public class JsonInsert
    {
        //[JsonPropertyName("id")]
        public string id { get; set; }
        //[JsonPropertyName("articleContent")]
        public ArticleContent articleContent { get; set; }
        public JsonInsert(string thisId, ArticleContent content)
        {
            id = thisId;
            articleContent = content; 
        }
    }
    public class ArticleContent
    {
        public string contentState { get; set; }
        public ArticleContent(string state)
        {
            contentState = state;
        }
    }
}

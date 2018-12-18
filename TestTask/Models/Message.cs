using System.Collections.Generic;
using System.Net.Http;

namespace TestTask.Models
{
    public class Message
    {
        public string Token { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public FormUrlEncodedContent ToFormUrl()
        {
            return new FormUrlEncodedContent(
                new Dictionary<string, string> {
                    {"token", Token },
                    {"user", User },
                    {"message", Text }
                });
        }
    }
}

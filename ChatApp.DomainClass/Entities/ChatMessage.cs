using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.DomainClass.Entities
{
   public class ChatMessage
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }
}

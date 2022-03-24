using System;
using System.Collections.Generic;
using System.Text;

namespace AnswerAPP_MauricioG.Models
{
    public class PruebaChat
    {
        public int SenderId { get; set; }
        public string UserName { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string UserRole { get; set; }

    }
}

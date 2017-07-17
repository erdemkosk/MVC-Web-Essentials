using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSimplifier.LogHelpers.Models
{
    public class ServerLog
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public StackFootPrint StackFootPrint { get; set; }
        public string DateTime { get; set; }
        public ServerLog(string Type, string Message, StackFootPrint StackFootPrint, string DateTime)
        {
            this.Type = Type;
            this.Message = Message;
            this.StackFootPrint = StackFootPrint;
            this.DateTime = DateTime;
        }
    }
}

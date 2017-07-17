using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSimplifier.LogHelpers.Models;

namespace WebSimplifier.LogHelpers
{
    public static class JsonLogManager
    {
       
        public static string LogPathFile { get; set; }

       
       

        public static void LogError(Exception filterContext)
        {
            string path = LogPathFile;
            string readedText = "";
            List<ServerLog> serverLogs = new List<ServerLog>();
            //read
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    readedText = sr.ReadToEnd();
                }
                serverLogs = JsonConvert.DeserializeObject<List<ServerLog>>(readedText);
                File.WriteAllText(path, String.Empty);
            }

            ServerLog log = new ServerLog(filterContext.GetType().Name, filterContext.Message, GetAllFootprints(filterContext), DateTime.Now.ToString());
            serverLogs.Insert(0, log);
            string json = JsonConvert.SerializeObject(serverLogs, Formatting.Indented);

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.Write(json);
                writer.Flush();
            }
        }

        private static StackFootPrint GetAllFootprints(Exception x)
        {
            StackFootPrint stackPrint = new StackFootPrint();
            var st = new StackTrace(x, true);
            var frames = st.GetFrames();
            foreach (var frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                    continue;
                if (frame.GetFileName() != null || frame.GetFileName() != "")
                {
                 
                    string code = frame.GetFileName();
                    stackPrint.FileName = code;
                }
                else
                {
                    stackPrint.FileName = frame.GetFileName();
                }

                stackPrint.MethodName = frame.GetMethod().Name;
                stackPrint.LineNumber = frame.GetFileLineNumber();
            }

            return stackPrint;
        }
        private static StackFootPrint GetAllFootprintWithShortestFileName(Exception x, string SearchAndCropFromThis)
        {
            StackFootPrint stackPrint = new StackFootPrint();
            var st = new StackTrace(x, true);
            var frames = st.GetFrames();
            foreach (var frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                    continue;
                if (frame.GetFileName() != null || frame.GetFileName() != "")
                {
                    string toBeSearched = SearchAndCropFromThis;
                    string code = frame.GetFileName().Substring(frame.GetFileName().IndexOf(toBeSearched) + toBeSearched.Length);
                    stackPrint.FileName = code;
                }
                else
                {
                    stackPrint.FileName = frame.GetFileName();
                }

                stackPrint.MethodName = frame.GetMethod().Name;
                stackPrint.LineNumber = frame.GetFileLineNumber();
            }

            return stackPrint;
        }
    }
}

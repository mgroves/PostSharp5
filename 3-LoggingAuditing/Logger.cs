using System.Collections.Generic;

namespace LoggingAuditing
{
    public class Logger
    {
        static Logger()
        {
            Log = new List<string>();
        }
        public static IList<string> Log { get; set; }
        public static void Write(string entry)
        {
            Log.Add(entry);
        }
    }
}

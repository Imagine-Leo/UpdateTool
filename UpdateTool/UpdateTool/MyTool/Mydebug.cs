using System;
using System.IO;
using System.Text;

namespace UpdateTool
{
    internal class Mydebug
    {
        private static bool _startDebugFile = false;
        private static string _logFilePath = Directory.GetCurrentDirectory() + "/" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
        public static void MyDEBUG(string msg)
        {
            msg = DateTime.Now.ToString().Replace(" ", "_") + ">>>" + msg;
            if (!_startDebugFile)
            {
                _startDebugFile = true;
                if (!File.Exists(_logFilePath))
                {
                    FileStream fs1 = File.Create(_logFilePath);
                    fs1.Close();

                }
                StreamWriter fs = new StreamWriter(_logFilePath, true, Encoding.UTF8);
                fs.WriteLine("NewStartLog:" + DateTime.Now.ToString().Replace(" ", "_"));
                fs.WriteLine(msg);
                fs.Close();
            }
            else
            {
                StreamWriter fs = new StreamWriter(_logFilePath, true, Encoding.UTF8);
                fs.WriteLine(msg);
                fs.Close();
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;

namespace UpdateTool
{
    internal class KillExe
    {
        public static void KillExeByCMD(string exeName)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("TASKKILL /F /IM " + exeName);
            //p.WaitForExit();
            p.Close();
        }
        public static void StartExeByCMD(string exeName)
        {

            ThreadPool.QueueUserWorkItem(new WaitCallback((o)=> {
                Thread.Sleep(200);
                Process p = new Process();
                p.StartInfo.FileName = exeName;// "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                //p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                //p.WaitForExit();
                p.Close();
            }));
        }
    }


}

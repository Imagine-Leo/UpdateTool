using System;
using System.Windows.Forms;

namespace UpdateTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }

        ////http://blog.ihaiu.com/csharp-zip/#content
        //https://github.com/adamhathcock/sharpcompress/releases/tag/0.18
    }
}

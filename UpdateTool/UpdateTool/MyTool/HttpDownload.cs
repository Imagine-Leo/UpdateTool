using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace UpdateTool.MyTool
{
    public class HttpDownload
    {
        public delegate void DelegateSaveCompelete(bool suscess, string filePath);
        public event DelegateSaveCompelete EventCompelete;

        public delegate void ProgrecessDelegate(UItype type, int per);
        public event ProgrecessDelegate ProgrecessEvent;



        public string rootPath = "";
        private string _saveingPath = "";
        private string _savePath = "";
        private int _buflength = 1024 * 1024;
        private byte[] _buf;
        private Thread _downloadThread;

        public void DownloadFile(string url)
        {
            _downloadThread = new Thread(new ThreadStart(
               () =>
               {

                   if (_buf == null)
                   {
                       _buf = new byte[_buflength];
                   }
                   bool saveSucess = false;

                   try
                   {
                       HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                       httpWebRequest.Method = "GET";

                       HttpWebResponse _Response = (HttpWebResponse)httpWebRequest.GetResponse();
                       Stream stream = _Response.GetResponseStream();

                       Console.WriteLine("开始写入");

                       string[] str = url.Split('/');
                       string fileName = str[str.Length - 1];
                       _savePath = Path.Combine(rootPath, fileName);
                       if (File.Exists(_savePath))
                       {
                           File.Delete(_savePath);
                       }
                       _saveingPath = Path.Combine(rootPath, "loading" + Path.GetExtension(_savePath));
                       if (File.Exists(_saveingPath))
                           File.Delete(_saveingPath);
                       else if (Directory.Exists(_saveingPath))
                       {
                           Directory.Delete(_saveingPath);
                       }
                       float length0 = 0;
                       long length = _Response.ContentLength;
                       Console.WriteLine("接受总长度：" + length);//B
                       using (var fs = File.Open(_saveingPath, FileMode.OpenOrCreate))
                       {
                           int n = 0;
                           while ((n = stream.Read(_buf, 0, _buflength)) != 0)
                           {
                               Console.WriteLine("写入长度:" + n / 1024.0 + "KB");
                               length0 += n;
                               if (ProgrecessEvent != null)
                               {
                                   ProgrecessEvent(UItype.DownloadProgress, (int)(length0 / length * 100));
                               }
                               fs.Write(_buf, 0, n);
                           }
                           fs.Close();
                           fs.Dispose();
                           stream.Dispose();
                           _Response.Close();

                           FileInfo info = new FileInfo(_saveingPath);
                           info.MoveTo(_savePath);
                           Console.WriteLine("写入完毕");
                           saveSucess = true;
                       }
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine("写入失败");
                       if (EventCompelete != null)
                       {
                           EventCompelete(false, null);
                       }
                   }
                   if (saveSucess)
                   {
                       if (EventCompelete != null)
                       {
                           EventCompelete(true, _savePath);
                       }
                   }

               }
                ));
            _downloadThread.Start();
        }

        public void Clear()
        {
            if (_downloadThread != null)
            {
                if (_downloadThread.IsAlive)
                    _downloadThread.Abort();
            }
            _buf = new byte[_buflength];
            if (File.Exists(_saveingPath))
            {
                File.Delete(_saveingPath);
            }
        }
    }
}

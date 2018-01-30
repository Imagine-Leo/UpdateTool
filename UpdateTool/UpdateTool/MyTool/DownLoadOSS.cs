//using Aliyun.OSS;
//using System;
//using System.IO;

//namespace UpdateTool.MyTool
//{

//    public class DownLoadOSS
//    {
//        public delegate void ProgrecessDelegate(UItype type, int per);

//        public event ProgrecessDelegate ProgrecessEvent;

//        private const string DATE_TIME_FORMAT = "yyyy-MM-dd-HH:mm:ss:fff";


//        private OssClient _myOSSclient;
//        private const string _bucketName = "update-zip";
//        private const string _endpoint = "oss-cn-beijing.aliyuncs.com";
//        private const string _accesskeyId = "LTAIuxKtb1XmSjDw";
//        private const string _accesskeySecret = "JdUPCquZ3Lq6BcRA03d8MTyMB83oZ6";
//        private const int _bufLength = 1024*1024;
//        public string rootPath = "";
//        private string _saveingPath = "";
//        private string _savePath = "";
//        public delegate void DelegateSaveCompelete(bool suscess,string filePath);
//        public event DelegateSaveCompelete EventCompelete;


//        private void _Init()
//        {
//            _myOSSclient = new OssClient(_endpoint, _accesskeyId, _accesskeySecret);
//            Mydebug.MyDEBUG("oss初始化成功");
//            _buf = new byte[_bufLength];
//        }

//        private byte[] _buf;
//        public void DownloadZip(string fileName)
//        {
//            if (_myOSSclient == null)
//            {
//                _Init();
//            }
//            try
//            {
//                GetObjectRequest getobjRequest = new GetObjectRequest(_bucketName, fileName.Replace(" ", ""));
//                getobjRequest.StreamTransferProgress += _StreamProgressCallback;
//                OssObject data = _myOSSclient.GetObject(getobjRequest);
//                using (var requestStream = data.Content)
//                {
//                    Console.WriteLine("开始写入");

//                    string[] paths = fileName.Split('/');

//                    _savePath = Path.Combine(rootPath,paths[paths.Length - 1]);
//                    if (File.Exists(_savePath))
//                    {
//                        File.Delete(_savePath);
//                    }

//                    _saveingPath = Path.Combine(rootPath,"loading"+Path.GetExtension(fileName));
//                    if (File.Exists(_saveingPath))
//                        File.Delete(_saveingPath);
//                    else if (Directory.Exists(_saveingPath))
//                    {
//                        Directory.Delete(_saveingPath);
//                    }
//                    using (var fs = File.Open(_saveingPath, FileMode.OpenOrCreate))
//                    {
//                        int len = 0;
//                        while ((len = requestStream.Read(_buf, 0, _bufLength)) != 0)
//                        {
//                            Console.WriteLine("写入:" + len);

//                            fs.Write(_buf, 0, len);
//                        }
//                        fs.Close();
//                        fs.Dispose();
//                    }
//                    _DownLoadComPelete();
//                }

//            }
//            catch (Exception ex)
//            {
//                Mydebug.MyDEBUG("download error：" + ex.Message);
//                if (EventCompelete != null)
//                {
//                    EventCompelete(false,null);
//                }
//            }
//        }

//        public void DownloadZipAsny(string fileName, string savePath)
//        {
//            if (_myOSSclient == null)
//            {
//                _Init();
//            }
//            try
//            {
//                OssObject data = _myOSSclient.GetObject(_bucketName, fileName);
//                using (var requestStream = data.Content)
//                {
//                    using (var fs = File.Open(_saveingPath, FileMode.OpenOrCreate))
//                    {
//                        int len = 0;
//                        while ((len = requestStream.Read(_buf, 0, _bufLength)) != 0)
//                        {
//                            fs.Write(_buf, 0, len);
//                        }
//                        fs.Close();
//                        fs.Dispose();
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                Mydebug.MyDEBUG("download error：" + ex.Message);
//            }
//        }


//        private void _StreamProgressCallback(object sender, StreamTransferProgressArgs args)
//        {
//            int p =(int)(args.TransferredBytes / (float)args.TotalBytes * 100);
//            Console.WriteLine("ProgressCallback:{0} - TotalBytes:{1}, TransferredBytes:{2}",p.ToString("0.00") + "%"
//        , args.TotalBytes, args.TransferredBytes);
//            if (ProgrecessEvent!=null)
//            {
//                ProgrecessEvent(UItype.DownloadProgress,p);
//            }
//        }

//        private void _DownLoadComPelete()
//        {
//            Console.WriteLine("下载到本地完成");
//            Mydebug.MyDEBUG("下载到本地完成");
//            FileInfo info = new FileInfo(_saveingPath);
//            info.MoveTo(_savePath);
//            if (EventCompelete != null)
//            {
//                EventCompelete(true,_savePath);
//            }
//        }

//        public void Clear()
//        {
//            _buf = new byte[_bufLength];
//            if (File.Exists(_saveingPath))
//            {
//                File.Delete(_saveingPath);
//            }
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using UpdateTool.MyTool;

namespace UpdateTool
{
    //topmost 拖拽  windowstate donet4.0

    public enum UItype
    {
        DownloadProgress = 1,
        UzipProgress = 2,
        UpdateProgress = 3,
        Downloadtext = 4,
        Uziptext = 5,
        Updatetext = 6,
    }

    public partial class Form1 : Form
    {
        public delegate void UIperDelegate(UItype type, int per);
        public delegate void UItextDelegate(UItype type, string str);


        private string _myname = "updateTool";
        private string _ossPath;
        private string _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "updateAasfaSEDGwDGSDKLaGJJJBKJLSDNdKJASBA");
        private string _downloadPath;
        private string _uzipPath;
        private string _updatePath;
        private string _killExeName;
        private string _startExePath;

        private bool _startSucess = false;
        private bool _isOSS = false;
        //private DownLoadOSS _downLoadOSS;
        private HttpDownload _httpDownload;
        private bool _isdownloading = false;
        private bool _boolonlyOne = true;

        private ZipTest _zipTest;

        public Form1(string[] args)
        {
            Mydebug.MyDEBUG("=====================Init====================");
            FormClosing += _Quit_Form;
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("接收参数:" + args[i]);
                    Mydebug.MyDEBUG("接收参数:" + args[i]);

                    string[] arg = args[i].Split('=');
                    if (arg.Length == 2)
                    {
                        switch (arg[0].ToLower())
                        {
                            case "winname":
                                if (arg[1] != "")
                                    _myname = arg[1];
                                break;
                            case "downloadpath":
                                _ossPath = arg[1];
                                break;
                            case "updatepath":
                                _updatePath = arg[1];
                                break;
                            case "exename":
                                _killExeName = arg[1];
                                break;
                            default:
                                Console.WriteLine("！！！" + arg[0]);
                                break;
                        }
                    }
                }
                if (string.IsNullOrEmpty(_ossPath) || string.IsNullOrEmpty(_updatePath) || string.IsNullOrEmpty(_killExeName))
                {
                    string err = string.Format("接收参数有误:下载地址:{0} 更新地址:{1} 目标程序名字:{2}", _ossPath, _updatePath, _killExeName);
                    Mydebug.MyDEBUG(err);
                    return;
                }
                _downloadPath = _rootPath;
                _uzipPath = _rootPath;
                _startSucess = true;
                InitializeComponent();
                this.Text = _myname;
                Startbutton.Visible = true;
            }
            else
            {
                Mydebug.MyDEBUG("=====================Init====没有接收参数======Exit==========");
                Console.WriteLine("没有接收参数");
                System.Environment.Exit(0);
            }
        }



        private void _Quit_Form(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Quit");
        }

        private delegate void delegateQuit();
        private void Form1_Load(object sender, EventArgs e)
        {
            _UIInit();
            _Start();

            //pictureBox2.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            _Start();
        }

        private void _Start()
        {
            Process[] localByName = Process.GetProcessesByName(_killExeName);
            if (localByName.Length > 0)
            {
                _startExePath = localByName[0].MainModule.FileName;
                Console.WriteLine("杀掉进程的路径:" + _startExePath);
                Mydebug.MyDEBUG("杀掉进程的路径:" + _startExePath);

            }
            else
            {
                Console.WriteLine("未找到杀掉进程的路径:");
                Mydebug.MyDEBUG("杀掉进程的路径:" + _startExePath);
            }

            KillExe.KillExeByCMD(_killExeName + ".exe");
            //int pr = ScreenTool.GetCurrentWindowHandle();
            //ScreenTool.MaxScreen();
            //Console.WriteLine(pr);

            if (!_startSucess)
                return;

            if (!_isdownloading)
                _isdownloading = true;
            else
                return;
            _UIInit();


            if (Directory.Exists(_rootPath))
            {
                try
                {
                    Console.WriteLine("开始删除");
                    Mydebug.MyDEBUG("开始删除上次缓存");

                    FileSystemInfo[] fileinfo = new DirectoryInfo(_rootPath).GetFileSystemInfos();
                    foreach (FileSystemInfo i in fileinfo)
                    {
                        if (i is DirectoryInfo)
                        {
                            DirectoryInfo info = new DirectoryInfo(i.FullName);
                            info.Delete(true);
                        }
                        else
                        {
                            FileInfo info = new FileInfo(i.FullName);
                            if (info.IsReadOnly)
                            {
                                info.IsReadOnly = false;
                            }
                            File.Delete(i.FullName);
                        }
                    }
                    Mydebug.MyDEBUG("删除上次缓存完毕");
                }

                catch (Exception ex)
                {
                    KillExe.KillExeByCMD("explorer.exe");
                    Directory.Delete(_rootPath, true);
                    Directory.CreateDirectory(_rootPath);
                    KillExe.StartExeByCMD("explorer.exe");
                }
            }
            else
            {
                Directory.CreateDirectory(_rootPath);
            }


            if (_isOSS)
            {
                //if (_downLoadOSS == null)
                //{
                //    _downLoadOSS = new DownLoadOSS();
                //    _downLoadOSS.rootPath = _downloadPath;
                //    _downLoadOSS.ProgrecessEvent += _UpdateUIAsy;
                //}
                //_downLoadOSS.EventCompelete += _SaveComPelete;
                //_downLoadOSS.DownloadZip(_ossPath);
            }
            else
            {
                if (_httpDownload == null)
                {
                    _httpDownload = new HttpDownload();
                    _httpDownload.rootPath = _downloadPath;
                    _httpDownload.ProgrecessEvent += _UpdateUIAsy;
                }
                _httpDownload.EventCompelete += _SaveComPelete;
                _httpDownload.DownloadFile(_ossPath);
            }
        }

        private void _SaveComPelete(bool suscess, string filePath)
        {
            //if (_isOSS)
            //    _downLoadOSS.EventCompelete -= _SaveComPelete;
            //else
            //{

            //}
            _httpDownload.EventCompelete -= _SaveComPelete;

            if (suscess)
            {

                Console.WriteLine("开始解压:" + filePath);
                if (_zipTest == null)
                    _zipTest = new ZipTest();
                Console.WriteLine(Path.GetExtension(filePath));
                if (File.Exists(filePath) && Path.GetExtension(filePath).ToLower() == ".zip")
                {
                    _zipTest.UzipCompeleteEvent += _UzipCompelete;
                    _zipTest.Uzip(filePath, _uzipPath);
                }
                else
                {
                    Console.WriteLine("下载成功的文件非zip文件");
                    _SaveErr(true);
                    //_UpdateFile(filePath);
                }
            }
            else
            {
                _SaveErr(false);
            }
        }
        private void _SaveErr(bool sucess)
        {
            if (sucess)
            {
                Console.WriteLine("下载文件格式非法");
            }
            this.Invoke(new UIperDelegate(_UpdateUI), new object[] { UItype.Downloadtext, 0 });

            if (!string.IsNullOrEmpty(_startExePath))
            {
                KillExe.StartExeByCMD(_startExePath);
                ScreenTool.MinScreen();
                Mydebug.MyDEBUG("下载到本地失败，启动:" + _startExePath);
                Console.WriteLine("下载到本地失败，启动" + _startExePath);
            }
            else
            {
                Mydebug.MyDEBUG("下载到本地失败，未启动");
                Console.WriteLine("下载到本地失败，未启动");
            }

            if (_boolonlyOne)
            {
                Thread.Sleep(1500);
                Application.Exit();
                _httpDownload.Clear();
            }
            else
            {
                _isdownloading = false;
                _httpDownload.Clear();
            }
        }


        private void _UzipCompelete(bool suscess, string filePath)
        {
            _zipTest.UzipCompeleteEvent -= _UzipCompelete;
            if (suscess)
            {
                Mydebug.MyDEBUG("解压完毕");

                this.Invoke(new UIperDelegate(_UpdateUI), new object[] { UItype.UzipProgress, 100 });
                _UpdateFile(filePath);
            }
            else
            {
                Mydebug.MyDEBUG("解压失败");
                _UzipErr();
            }
        }
        private void _UzipErr()
        {
            this.Invoke(new UIperDelegate(_UpdateUI), new object[] { UItype.Uziptext, 0 });
            _zipTest.Clear();
            if (!string.IsNullOrEmpty(_startExePath))
            {
                KillExe.StartExeByCMD(_startExePath);
                ScreenTool.MinScreen();
                Mydebug.MyDEBUG("解压到本地失败，启动:" + _startExePath);
                Console.WriteLine("解压到本地失败，启动" + _startExePath);
            }
            else
            {
                Mydebug.MyDEBUG("解压到本地失败，未启动");
                Console.WriteLine("解压到本地失败，未启动");
            }

            if (_boolonlyOne)
            {
                Thread.Sleep(1500);
                Application.Exit();
                _httpDownload.Clear();
            }
            else
            {
                _isdownloading = false;
                _httpDownload.Clear();

            }


        }

        private void _UpdateFile(string filePath)
        {
            Console.WriteLine("准备更新：" + filePath);
            //开始替换更新包

            if (Directory.Exists(filePath))
            {
                Console.WriteLine("____________0_____________");
                if (Directory.Exists(_updatePath))
                {
                    Console.WriteLine("____________01_____________");

                    //DirectoryInfo inff = new DirectoryInfo(_updatePath);
                    //List<IntPtr> explorer = User32API.GetWindowHandleByName("explorer");
                    //Console.WriteLine("资源管理器长度:"+explorer.Count);

                    //if (explorer.Count > 0)
                    //{
                    //    Console.WriteLine("资源管理器[0]:" + explorer[0]);
                    //    //KillExe.KillExeByCMD("explorer.exe");
                    //    //KillExe.StartExeByCMD("explorer.exe");
                    //}

                    _OverwiteDirectory(filePath, _updatePath);
                    //try
                    //{
                    //    inff.Delete(true);
                    //}
                    //catch (Exception ex)
                    //{
                    //    KillExe.KillExeByCMD("explorer.exe");
                    //    inff.Delete(true);
                    //    KillExe.StartExeByCMD("explorer.exe");
                    //}
                }
                else
                {
                    Directory.CreateDirectory(_updatePath.Substring(0, _updatePath.LastIndexOf('\\')));
                    DirectoryInfo info = new DirectoryInfo(filePath);
                    try
                    {
                        info.MoveTo(_updatePath);
                    }
                    catch (Exception ex)
                    {
                        KillExe.KillExeByCMD("explorer.exe");
                        info.MoveTo(_updatePath);
                        KillExe.StartExeByCMD("explorer.exe");
                    }
                }
                Console.WriteLine("更新完成：" + _updatePath);
                _UpdateSucess();
            }
            else
            {
                Mydebug.MyDEBUG("!!!更新失败");
                this.Invoke(new UIperDelegate(_UpdateUI), new object[] { UItype.Updatetext, 0 });
                _zipTest.Clear();

                if (!string.IsNullOrEmpty(_startExePath))
                {
                    KillExe.StartExeByCMD(_startExePath);
                    ScreenTool.MinScreen();
                    Mydebug.MyDEBUG("更新指定位置失败，启动:" + _startExePath);
                    Console.WriteLine("更新指定位置失败，启动" + _startExePath);
                }
                else
                {
                    Mydebug.MyDEBUG("更新指定位置失败，未启动");
                    Console.WriteLine("更新指定位置失败，未启动");
                }
                if (_boolonlyOne)
                {
                    Thread.Sleep(1500);
                    Application.Exit();
                    _httpDownload.Clear();
                }
                else
                {
                    _isdownloading = false;
                    _httpDownload.Clear();

                }

            }

        }
        private void _UpdateUIAsy(UItype type, int per)
        {
            this.Invoke(new UIperDelegate(_UpdateUI), new object[] { type, per });
        }

        private void _UpdateUI(UItype type, int per)
        {
            if (per > 99)
                per = 100;
            switch (type)
            {
                case UItype.DownloadProgress:
                    progressBar_download.Value = Math.Min(per, 100);
                    break;
                case UItype.UzipProgress:
                    progressBar_uzip.Value = Math.Min(per, 100);
                    break;
                case UItype.UpdateProgress:
                    progressBar_update.Value = Math.Min(per, 100);
                    break;
                case UItype.Downloadtext:
                    lable_download.Text = "下载文件失败";
                    lable_download.BackColor = Color.Red;
                    break;
                case UItype.Uziptext:
                    label_uzip.Text = "解压失败";
                    label_uzip.BackColor = Color.Red;
                    break;
                case UItype.Updatetext:
                    label_update.Text = "更新失败";
                    label_update.BackColor = Color.Red;
                    break;
                default:
                    Console.WriteLine("!!!other");
                    break;
            }
        }

        private void _UIInit()
        {
            progressBar_download.Value = 0;
            progressBar_update.Value = 0;
            progressBar_uzip.Value = 0;
            label_update.Text = "更新进度";
            label_uzip.Text = "解压进度";
            lable_download.Text = "下载进度";
            label_update.BackColor = Color.Transparent;
            label_uzip.BackColor = Color.Transparent;
            lable_download.BackColor = Color.Transparent;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            //    delegateQuit s =new delegateQuit(
            //    Application.Exit
            //);
            //Invoke(s,new object[] { });
            //System.Environment.Exit(0);
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void _OverwiteDirectory(string ori, string despath)
        {
            //Console.WriteLine("___________更新地址_____________" + despath);

            List<string> files = new List<string>(Directory.GetFiles(ori));
            for (int i = 0; i < files.Count; i++)
            {
                Console.WriteLine("源文件名:" + files[i]);
                Console.WriteLine("文件名:" + Path.GetFileName(files[i]));


                string desfile = Path.Combine(despath, Path.GetFileName(files[i]));
                Console.WriteLine("目标文件名:" + files[i]);

                if (File.Exists(desfile))
                {
                    Console.WriteLine("存在删除：" + desfile);
                    File.Delete(desfile);
                }
                File.Move(files[i], desfile);
            }
            List<string> directories = new List<string>(Directory.GetDirectories(ori));
            for (int i = 0; i < directories.Count; i++)
            {
                //Console.WriteLine("根目录:"+ Path.GetFileName(directories[i]));

                string desDirectory = Path.Combine(despath, Path.GetFileName(directories[i]));

                if (Directory.Exists(desDirectory))
                {
                    _OverwiteDirectory(directories[i], desDirectory);
                }
                else
                {
                    Directory.Move(directories[i], desDirectory);
                }

            }
        }


        private void _UpdateSucess()
        {
            Mydebug.MyDEBUG("成功更新");
            this.Invoke(new UIperDelegate(_UpdateUI), new object[] { UItype.UpdateProgress, 100 });
            if (!string.IsNullOrEmpty(_startExePath))
            {
                KillExe.StartExeByCMD(_startExePath);
                ScreenTool.MinScreen();
                Mydebug.MyDEBUG("启动:"+_startExePath);
                Console.WriteLine("更新完成功启动"+_startExePath);
            }
            else
            {
                Mydebug.MyDEBUG("未启动:启动前exe未运行");
                Console.WriteLine("更新完成功未启动:启动前exe未运行");
            }
            _zipTest.Clear();
            if (_boolonlyOne)
            {
                Thread.Sleep(1500);
                Application.Exit();
                _httpDownload.Clear();
            }
            else
            {
                _isdownloading = false;
                _httpDownload.Clear();
            }
        }
    }
}

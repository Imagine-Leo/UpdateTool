using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace UpdateTool
{
    public delegate void UZipCompeleteDelegate(bool suscess, string fileName);

    public class ZipTest
    {
        public event UZipCompeleteDelegate UzipCompeleteEvent;
        public void Uzip(string ori, string des)
        {
            if (string.IsNullOrEmpty(ori)||string.IsNullOrEmpty(des))
            {
                Console.WriteLine("!!! zip file name IsNullOrEmpty");
                if (UzipCompeleteEvent != null)
                    UzipCompeleteEvent(false, null);
                return;
            }
            if (ZipArchive.IsZipFile(ori))
            {
                des = Path.Combine(des,Path.GetFileNameWithoutExtension(ori));
                Console.WriteLine("源地址：" + ori);
                Console.WriteLine("目标地址：" + des);
                try
                {
                    using (var archive = ZipArchive.Open(ori))
                    {
                        Console.WriteLine("Entries:" + archive.Entries);
                        foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                        {
                            //Console.WriteLine("Entry:" +Encoding.GetEncoding("gb2312").GetString(Encoding.Default.GetBytes(entry.Key)));

                            Console.WriteLine("解压中Entry:" + entry.Key);

                            entry.WriteToDirectory(des, new SharpCompress.Readers.ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            }
                            );
                        }
                        Console.WriteLine("解压完成:" + des);
                        if (UzipCompeleteEvent != null)
                            UzipCompeleteEvent(true, des);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.GetType().Name+":"+e.Message);
                }

            }
            else
            {
                Console.WriteLine("!!!not zip");
                if (UzipCompeleteEvent != null)
                    UzipCompeleteEvent(false, null);
            }

        }

        public void Zip(string ori = "", string des = "")
        {
            if (string.IsNullOrEmpty(ori))
            {
                ori = Directory.GetCurrentDirectory() + "\\";
            }
            if (string.IsNullOrEmpty(des))
            {
                des = Directory.GetCurrentDirectory() + "\\Web.zip";
            }
            Console.WriteLine("源地址：" + ori);
            Console.WriteLine("目标地址：" + des);

            if (Directory.Exists(ori))
            {
                using (var archive = ZipArchive.Create())
                {
                    archive.AddAllFromDirectory(ori);
                    archive.SaveTo(des, SharpCompress.Common.CompressionType.Deflate);

                }
            }
            else
            {
                Console.WriteLine("!!!not exsit zip directory");
            }

        }


        public string Decode(string sr)
        {
            return HttpUtility.UrlDecode(sr);
        }

        public void Clear()
        {

        }
    }
}

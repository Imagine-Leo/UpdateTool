using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UpdateTool
{
    public class ScreenTool
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        public static void MaxScreen()
        {
            ShowWindow(User32API.GetCurrentWindowHandle(), 3);
        }
        public static void MinScreen()
        {
            ShowWindow(User32API.GetCurrentWindowHandle(), 7);
        }
        public static int GetCurrentWindowHandle()
        {
            return (int)User32API.GetCurrentWindowHandle();
        }
    }
    public class User32API
    {
        private static Hashtable processWnd = null;
        public delegate bool WNDENUMPROC(IntPtr hwnd, uint lParam);
        static User32API()
        {
            if (processWnd == null)
            {
                processWnd = new Hashtable();
            }
        }
        #region
        [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        public static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, uint lParam);

        [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(uint dwErrCode);
        #endregion
        public static IntPtr GetCurrentWindowHandle()
        {
            IntPtr ptrWnd = IntPtr.Zero;
            uint uiPid = (uint)Process.GetCurrentProcess().Id;  // 当前进程 ID
            Console.WriteLine("当前进程id" + uiPid);
            object objWnd = processWnd[uiPid];
            if (objWnd != null)
            {
                Console.WriteLine("! null");
                ptrWnd = (IntPtr)objWnd;
                if (ptrWnd != IntPtr.Zero && IsWindow(ptrWnd))  // 从缓存中获取句柄
                {
                    return ptrWnd;
                }
                else
                {
                    Console.WriteLine("再次查询null");
                    ptrWnd = IntPtr.Zero;
                }
            }
            bool bResult = EnumWindows(new WNDENUMPROC(EnumWindowsProc), uiPid);
            // 枚举窗口返回 false 并且没有错误号时表明获取成功
            Console.WriteLine(bResult);
            if (!bResult && Marshal.GetLastWin32Error() == 0)
            {
                objWnd = processWnd[uiPid];
                if (objWnd != null)
                {
                    ptrWnd = (IntPtr)objWnd;
                }
                Mydebug.MyDEBUG("句柄suscess");
            }
            else
            {
                Mydebug.MyDEBUG("句柄error");
            }
            return ptrWnd;
        }
        public static List<IntPtr> GetWindowHandleByName(string Name)
        {
            IntPtr ptrWnd = IntPtr.Zero;
            List<IntPtr> intPtrArray = new List<IntPtr>();
            Process[] localByName = Process.GetProcessesByName(Name);
            uint uiPid = 0;//进程id
            if (localByName.Length > 0)
            {
                for (int i = 0; i < localByName.Length; i++)
                {
                    uiPid = (uint)localByName[i].Id;
                    Console.WriteLine("当前进程id" + uiPid);
                    object objWnd = processWnd[uiPid];

                    if (objWnd != null)
                    {
                        Console.WriteLine("! null");
                        ptrWnd = (IntPtr)objWnd;
                        if (ptrWnd != IntPtr.Zero && IsWindow(ptrWnd))  // 从缓存中获取句柄
                        {
                            intPtrArray.Add(ptrWnd);
                        }
                        else
                        {
                            Console.WriteLine("再次查询null");
                            ptrWnd = IntPtr.Zero;
                        }
                    }
                    bool bResult = EnumWindows(new WNDENUMPROC(EnumWindowsProc), uiPid);
                    // 枚举窗口返回 false 并且没有错误号时表明获取成功
                    Console.WriteLine(bResult);
                    if (!bResult && Marshal.GetLastWin32Error() == 0)
                    {
                        objWnd = processWnd[uiPid];
                        if (objWnd != null)
                        {
                            ptrWnd = (IntPtr)objWnd;
                            intPtrArray.Add(ptrWnd);
                            Mydebug.MyDEBUG("screenTool_suscess");
                        }
                    }
                    else
                    {
                        Mydebug.MyDEBUG("screenTool_error");
                    }


                }
            }
            return intPtrArray;
        }
        private static bool EnumWindowsProc(IntPtr hwnd, uint lParam)
        {
            uint uiPid = 0;
            if (GetParent(hwnd) == IntPtr.Zero)
            {
                GetWindowThreadProcessId(hwnd, out uiPid);
                if (uiPid == lParam)    // 找到进程对应的主窗口句柄
                {
                    processWnd[uiPid] = hwnd;   // 把句柄缓存起来
                    SetLastError(0);    // 设置无错误
                    //Console.WriteLine(":" + Process.GetCurrentProcess().MainWindowTitle);
                    return false;   // 返回 false 以终止枚举窗口
                }
            }
            return true;
        }
    }
}

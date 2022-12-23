using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveWindowControl {
  internal class WinAPI {

    [DllImport("user32.dll")]
    public extern static IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(SystemMetric smIndex);
    public enum SystemMetric : int {
      SM_CXSCREEN = 0,
      SM_CYSCREEN = 1,
      SM_CYVSCROLL = 2,
      SM_CXVSCROLL = 3,
      SM_CYCAPTION = 4,
      SM_CXBORDER = 5,
      SM_CYBORDER = 6,
      SM_CXDLGFRAME = 7,
      SM_CYDLGFRAME = 8,
      SM_CYVTHUMB = 9,
      SM_CXHTHUMB = 10,
      SM_CXICON = 11,
      SM_CYICON = 12,
      SM_CXCURSOR = 13,
      SM_CYCURSOR = 14,
      SM_CYMENU = 15,
      SM_CXFULLSCREEN = 16,
      SM_CYFULLSCREEN = 17,
      SM_CYKANJIWINDOW = 18,
      SM_MOUSEWHEELPRESENT = 75,
      SM_CYHSCROLL = 20,
      SM_CXHSCROLL = 21,
      SM_DEBUG = 22,
      SM_SWAPBUTTON = 23,
      SM_RESERVED1 = 24,
      SM_RESERVED2 = 25,
      SM_RESERVED3 = 26,
      SM_RESERVED4 = 27,
      SM_CXMIN = 28,
      SM_CYMIN = 29,
      SM_CXSIZE = 30,
      SM_CYSIZE = 31,
      SM_CXFRAME = 32,
      SM_CYFRAME = 33,
      SM_CXMINTRACK = 34,
      SM_CYMINTRACK = 35,
      SM_CXDOUBLECLK = 36,
      SM_CYDOUBLECLK = 37,
      SM_CXICONSPACING = 38,
      SM_CYICONSPACING = 39,
      SM_MENUDROPALIGNMENT = 40,
      SM_PENWINDOWS = 41,
      SM_DBCSENABLED = 42,
      SM_CMOUSEBUTTONS = 43,
      SM_CXFIXEDFRAME = SM_CXDLGFRAME,
      SM_CYFIXEDFRAME = SM_CYDLGFRAME,
      SM_CXSIZEFRAME = SM_CXFRAME,
      SM_CYSIZEFRAME = SM_CYFRAME,
      SM_SECURE = 44,
      SM_CXEDGE = 45,
      SM_CYEDGE = 46,
      SM_CXMINSPACING = 47,
      SM_CYMINSPACING = 48,
      SM_CXSMICON = 49,
      SM_CYSMICON = 50,
      SM_CYSMCAPTION = 51,
      SM_CXSMSIZE = 52,
      SM_CYSMSIZE = 53,
      SM_CXMENUSIZE = 54,
      SM_CYMENUSIZE = 55,
      SM_ARRANGE = 56,
      SM_CXMINIMIZED = 57,
      SM_CYMINIMIZED = 58,
      SM_CXMAXTRACK = 59,
      SM_CYMAXTRACK = 60,
      SM_CXMAXIMIZED = 61,
      SM_CYMAXIMIZED = 62,
      SM_NETWORK = 63,
      SM_CLEANBOOT = 67,
      SM_CXDRAG = 68,
      SM_CYDRAG = 69,
      SM_SHOWSOUNDS = 70,
      SM_CXMENUCHECK = 71,
      SM_CYMENUCHECK = 72,
      SM_SLOWMACHINE = 73,
      SM_MIDEASTENABLED = 74,
      SM_MOUSEPRESENT = 19,
      SM_XVIRTUALSCREEN = 76,
      SM_YVIRTUALSCREEN = 77,
      SM_CXVIRTUALSCREEN = 78,
      SM_CYVIRTUALSCREEN = 79,
      SM_CMONITORS = 80,
      SM_SAMEDISPLAYFORMAT = 81,
      SM_IMMENABLED = 82,
      SM_CXFOCUSBORDER = 83,
      SM_CYFOCUSBORDER = 84,
      SM_TABLETPC = 86,
      SM_MEDIACENTER = 87,
      SM_CMETRICS_OTHER = 76,
      SM_CMETRICS_2000 = 83,
      SM_CMETRICS_NT = 88,
      SM_REMOTESESSION = 0x1000,
      SM_SHUTTINGDOWN = 0x2000,
      SM_REMOTECONTROL = 0x2001,
    }

    [DllImport("user32.dll")]
    public static extern UInt32 SetWindowLong(IntPtr hWnd, GWL index, UInt32 unValue);
    const UInt32 WS_EX_NOACTIVATE = 0x8000000;
    public enum GWL : int {
      WINDPROC = -4,
      HINSTANCE = -6,
      HWNDPARENT = -8,
      ID = -12,
      STYLE = -16,
      EXSTYLE = -20,
      USERDATA = -21,
    }


    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint flags);

    public const int SWP_NOSIZE = 0x0001;
    public const int SWP_NOMOVE = 0x0002;
    public const int SWP_NOZORDER = 0x0004;
    public const int SWP_SHOWWINDOW = 0x0040;
    public const int SWP_ASYNCWINDOWPOS = 0x4000;
    public const int SWP_NOOWNERZORDER = 0x0200;
    public const int SWP_NOACTIVATE = 0x0010;
    public const int HWND_TOP = 0;
    public const int HWND_BOTTOM = 1;
    public const int HWND_TOPMOST = -1;
    public const int HWND_NOTOPMOST = -2;



    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int MoveWindow(IntPtr hwnd, int x, int y,
    int nWidth, int nHeight, int bRepaint);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowPlacement(
        IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

    public struct WINDOWPLACEMENT {
      public int length;
      public int flags;
      public int showCmd;
      public Point ptMinPosition;
      public Point ptMaxPosition;
      public Rectangle rcNormalPosition;
    }

    public static WINDOWPLACEMENT GetPlacement(IntPtr hwnd) {
      WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
      placement.length = Marshal.SizeOf(placement);
      GetWindowPlacement(hwnd, out placement);
      return placement;
    }

    public static string GetWindowState(IntPtr hwnd) {
      WINDOWPLACEMENT placement = GetPlacement(hwnd);

      if (placement.showCmd == SW_SHOWMINIMIZED)
        return "Minimized";

      if (placement.showCmd == SW_SHOWMAXIMIZED)
        return "Maximized";

      if (placement.showCmd == SW_HIDE)
        return "Hide";

      if (placement.showCmd == SW_SHOWNORMAL)
        return "Normal";

      return string.Empty;
    }

    public const int SW_HIDE = 0;
    public const int SW_SHOWNORMAL = 1;
    public const int SW_SHOWMINIMIZED = 2;
    public const int SW_SHOWMAXIMIZED = 3;
    public const int SW_SHOWNOACTIVATE = 4;
    public const int SW_SHOW = 5;
    public const int SW_MINIMIZE = 6;
    public const int SW_SHOWMINNOACTIVE = 7;
    public const int SW_SHOWNA = 8;
    public const int SW_RESTORE = 9;
    public const int SW_SHOWDEFAULT = 10;



    [DllImport("user32.dll")]
    public static extern int ShowWindow(IntPtr hWnd, uint Msg);


    //DWM（Desktop Window Manager）
    //見た目通りのRectを取得できる、引数のdwAttributeにDWMWA_EXTENDED_FRAME_BOUNDSを渡す
    //引数のcbAttributeにはRECTのサイズ、Marshal.SizeOf(typeof(RECT))これを渡す
    //戻り値が0なら成功、0以外ならエラー値
    [DllImport("dwmapi.dll")]
    public static extern long DwmGetWindowAttribute(IntPtr hWnd, DWMWINDOWATTRIBUTE dwAttribute, out RECT rect, int cbAttribute);

    //ウィンドウ属性
    //列挙値の開始は0だとずれていたので1からにした
    public enum DWMWINDOWATTRIBUTE {
      DWMWA_NCRENDERING_ENABLED = 1,
      DWMWA_NCRENDERING_POLICY,
      DWMWA_TRANSITIONS_FORCEDISABLED,
      DWMWA_ALLOW_NCPAINT,
      DWMWA_CAPTION_BUTTON_BOUNDS,
      DWMWA_NONCLIENT_RTL_LAYOUT,
      DWMWA_FORCE_ICONIC_REPRESENTATION,
      DWMWA_FLIP3D_POLICY,
      DWMWA_EXTENDED_FRAME_BOUNDS,//ウィンドウのRect
      DWMWA_HAS_ICONIC_BITMAP,
      DWMWA_DISALLOW_PEEK,
      DWMWA_EXCLUDED_FROM_PEEK,
      DWMWA_CLOAK,
      DWMWA_CLOAKED,
      DWMWA_FREEZE_REPRESENTATION,
      DWMWA_LAST
    };


    [DllImport("user32.dll")]
    public static extern bool SetWindowPlacement(
    IntPtr hWnd,
    [In] ref WINDOWPLACEMENT lpwndpl);

  }
}

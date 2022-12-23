using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveWindowControl {
  internal class Lib {

    public static int GetScreenIndexFromPoint(Point p, bool optionNotFoundPrimary = true) {
      var primaryScreenIndex = -1;
      for (int i = 0; i < Screen.AllScreens.Length; i += 1) {
        var s = Screen.AllScreens[i];
        if (s.Bounds.Contains(p)) {
          return i;
        }
        if (s.Primary) { primaryScreenIndex = i; }
      }
      if (optionNotFoundPrimary) {
        return primaryScreenIndex;
      } else {
        return -1;
      }
    }

    // 外部アプリケーションのウィンドウをアクティブにする - .NET Tips
    // https://dobon.net/vb/dotnet/process/appactivate.html#section4

    /// <summary>
    /// できるだけ確実に指定したウィンドウをフォアグラウンドにする
    /// </summary>
    /// <param name="hWnd">ウィンドウハンドル</param>
    public static void ActiveWindow(IntPtr hWnd) {
      if (hWnd == IntPtr.Zero) {
        return;
      }

      //ウィンドウが最小化されている場合は元に戻す
      if (IsIconic(hWnd)) {
        ShowWindowAsync(hWnd, SW_RESTORE);
      }

      //AttachThreadInputの準備
      //フォアグラウンドウィンドウのハンドルを取得
      IntPtr forehWnd = GetForegroundWindow();
      if (forehWnd == hWnd) {
        return;
      }
      //フォアグラウンドのスレッドIDを取得
      uint foreThread = GetWindowThreadProcessId(forehWnd, IntPtr.Zero);
      //自分のスレッドIDを収得
      uint thisThread = GetCurrentThreadId();

      uint timeout = 200000;
      if (foreThread != thisThread) {
        //ForegroundLockTimeoutの現在の設定を取得
        //Visual Studio 2010, 2012起動後は、レジストリと違う値を返す
        SystemParametersInfoGet(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, ref timeout, 0);
        //レジストリから取得する場合
        //timeout = (uint)Microsoft.Win32.Registry.GetValue(
        //    @"HKEY_CURRENT_USER\Control Panel\Desktop",
        //    "ForegroundLockTimeout", 200000);

        //ForegroundLockTimeoutの値を0にする
        //(SPIF_UPDATEINIFILE | SPIF_SENDCHANGE)を使いたいが、
        //  timeoutがレジストリと違う値だと戻せなくなるので使わない
        SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0);

        //入力処理機構にアタッチする
        AttachThreadInput(thisThread, foreThread, true);
      }

      //ウィンドウをフォアグラウンドにする処理
      SetForegroundWindow(hWnd);
      SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0,
          SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_ASYNCWINDOWPOS);
      BringWindowToTop(hWnd);
      ShowWindowAsync(hWnd, SW_SHOW);
      SetFocus(hWnd);

      if (foreThread != thisThread) {
        //ForegroundLockTimeoutの値を元に戻す
        //ここでも(SPIF_UPDATEINIFILE | SPIF_SENDCHANGE)は使わない
        SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0);

        //デタッチ
        AttachThreadInput(thisThread, foreThread, false);
      }
    }

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("user32.dll")]
    static extern IntPtr SetFocus(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetWindowPos(IntPtr hWnd,
        int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

    private const int SWP_NOSIZE = 0x0001;
    private const int SWP_NOMOVE = 0x0002;
    private const int SWP_NOZORDER = 0x0004;
    private const int SWP_SHOWWINDOW = 0x0040;
    private const int SWP_ASYNCWINDOWPOS = 0x4000;
    private const int HWND_TOP = 0;
    private const int HWND_BOTTOM = 1;
    private const int HWND_TOPMOST = -1;
    private const int HWND_NOTOPMOST = -2;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    private const int SW_SHOWNORMAL = 1;
    private const int SW_SHOW = 5;
    private const int SW_RESTORE = 9;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(
        IntPtr hWnd, IntPtr ProcessId);

    [DllImport("kernel32.dll")]
    private static extern uint GetCurrentThreadId();

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AttachThreadInput(
        uint idAttach, uint idAttachTo, bool fAttach);

    [DllImport("user32.dll", EntryPoint = "SystemParametersInfo",
        SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SystemParametersInfoGet(
        uint action, uint param, ref uint vparam, uint init);

    [DllImport("user32.dll", EntryPoint = "SystemParametersInfo",
        SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SystemParametersInfoSet(
        uint action, uint param, uint vparam, uint init);

    private const uint SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
    private const uint SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
    private const uint SPIF_UPDATEINIFILE = 0x01;
    private const uint SPIF_SENDCHANGE = 0x02;



    /// <summary>
    /// プライマリディスプレイの情報取得
    /// </summary>
    public static void GetPrimaryDisplayInformation() {
      try {
        System.Diagnostics.Debug.WriteLine("●プライマリディスプレイの情報取得");
        System.Diagnostics.Debug.WriteLine("デバイス名 : " + System.Windows.Forms.Screen.PrimaryScreen.DeviceName);
        System.Diagnostics.Debug.WriteLine("ディスプレイの位置 : X=" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.X + " - Y=" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y);
        System.Diagnostics.Debug.WriteLine("ディスプレイのサイズ : 幅=" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width + " - 高さ=" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
        System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域の位置 : X" + System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.X + " - Y=" + System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Y);
        System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域のサイズ : 幅" + System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width + " - 高さ=" + System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
      } catch {
      }
    }

    ///// <summary>
    ///// フォームがあるディスプレイの情報取得
    ///// </summary>
    //public void GetFormDisplayInformation() {
    //  try {
    //    System.Diagnostics.Debug.WriteLine("●フォームがあるディスプレイの情報取得");
    //    System.Diagnostics.Debug.WriteLine("デバイス名 : " + System.Windows.Forms.Screen.FromControl(this).DeviceName);
    //    System.Diagnostics.Debug.WriteLine("ディスプレイの位置 : X=" + System.Windows.Forms.Screen.FromControl(this).Bounds.X + " - Y=" + System.Windows.Forms.Screen.FromControl(this).Bounds.Y);
    //    System.Diagnostics.Debug.WriteLine("ディスプレイのサイズ : 幅=" + System.Windows.Forms.Screen.FromControl(this).Bounds.Width + " - 高さ=" + System.Windows.Forms.Screen.FromControl(this).Bounds.Height);
    //    System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域の位置 : X" + System.Windows.Forms.Screen.FromControl(this).WorkingArea.X + " - Y=" + System.Windows.Forms.Screen.FromControl(this).WorkingArea.Y);
    //    System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域のサイズ : 幅" + System.Windows.Forms.Screen.FromControl(this).WorkingArea.Width + " - 高さ=" + System.Windows.Forms.Screen.FromControl(this).WorkingArea.Height);
    //  } catch {
    //  }
    //}

    /// <summary>
    /// 全てのディスプレイの情報取得
    /// </summary>
    public static void GetAllDisplayInformation() {
      try {
        System.Diagnostics.Debug.WriteLine("●全てのディスプレイの情報取得");
        foreach (System.Windows.Forms.Screen screen_data in System.Windows.Forms.Screen.AllScreens) {
          System.Diagnostics.Debug.WriteLine("デバイス名 : " + screen_data.DeviceName);
          System.Diagnostics.Debug.WriteLine("ディスプレイの位置 : X=" + screen_data.Bounds.X + " - Y=" + screen_data.Bounds.Y);
          System.Diagnostics.Debug.WriteLine("ディスプレイのサイズ : 幅=" + screen_data.Bounds.Width + " - 高さ=" + screen_data.Bounds.Height);
          System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域の位置 : X" + screen_data.WorkingArea.X + " - Y=" + screen_data.WorkingArea.Y);
          System.Diagnostics.Debug.WriteLine("ディスプレイの作業領域のサイズ : 幅" + screen_data.WorkingArea.Width + " - 高さ=" + screen_data.WorkingArea.Height);
          System.Diagnostics.Debug.WriteLine("-----");
        }
      } catch {
      }
    }


  }
}

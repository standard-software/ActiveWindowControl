using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ActiveWindowControl {
  using static WinAPI;
  using static Lib;

  public partial class MainForm : Form {

    public MainForm() {
      InitializeComponent();
    }

    public IntPtr foregroundWinHandle;

    private void MainForm_Load(object sender, EventArgs e) {
      this.Top = 0;
      this.Left = 0;
      this.Height = 0;

      {
        leftSideMenuItem.Tag = 50;
        leftSideMenuItem.Click += leftSideMenuItem_Click;

        rightSideMenuItem.Tag = 50;
        rightSideMenuItem.Click += rightSideMenuItem_Click;

        size90CenterMenuItem.Tag = 90;
        size90CenterMenuItem.Click += centerMenuItem_Click;
        size75CenterMenuItem.Tag = 75;
        size75CenterMenuItem.Click += centerMenuItem_Click;
      }

      {
        splitScreenAreaMenuItem.Tag = 50;
        splitScreenAreaMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
        CreateLeftRightTopBottomMenuItem(splitScreenAreaMenuItem);
      }

      {
        resizeWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;

        ToolStripMenuItem menuItemSize;

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 90%";
        menuItemSize.Tag = 90;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 75%";
        menuItemSize.Tag = 75;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 50%";
        menuItemSize.Tag = 50;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 25%";
        menuItemSize.Tag = 25;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);
      }

      {
        toPrevMonitorMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
        toNextMonitorMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
      }

      {
        rootToPrevMonitorMenuItem.Click += samePositionPrevMonitorMenuItem_Click;
        rootToNextMonitorMenuItem.Click += samePositionNextMonitorMenuItem_Click;
      }

    }

    private void CreateLeftRightTopBottomMenuItem(ToolStripMenuItem rootMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Left Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += leftSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Right Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += rightSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      rootMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += topSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += bottomSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      rootMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "TopLeft Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += topLeftSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "TopRight Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += topRightSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "BottomLeft Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += bottomLeftSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "BottomRight Side";
      menuItem.Tag = rootMenuItem.Tag;
      menuItem.Click += bottomRightSideMenuItem_Click;
      rootMenuItem.DropDownItems.Add(menuItem);
    }

    private void CreateSizeMenuItem(ToolStripMenuItem sizeMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Center";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += centerMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      CreateLeftRightTopBottomMenuItem(sizeMenuItem);
    }

    private void aboutActiveWindowControlMenuItem_Click(object sender, EventArgs e) {
      timer1.Enabled = false;
      MessageBox.Show(
        "ActiveWindowControl\nVersion:0.2.0",
        "About",
        MessageBoxButtons.OK,
         MessageBoxIcon.Information
      );
      timer1.Enabled = true;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      this.Close();
    }

    private void notifyIcon1_Click(object sender, EventArgs e) {
      this.contextMenuStrip2.Show(
        Cursor.Position,
        ToolStripDropDownDirection.AboveRight
      );
    }

    private void tasktrayRestartMenuItem_Click(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      Application.Restart();
    }

    private void tasktrayExitMenuItem_Click(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      this.Close();
    }

    private void timer1_Tick(object sender, EventArgs e) {
      IntPtr _foregroundWinHandle = WinAPI.GetForegroundWindow();

      if (!IsThickFrame(_foregroundWinHandle)) { return; }

      if (foregroundWinHandle != _foregroundWinHandle) {
        //this.contextMenuStrip1.Tag = null;
        if (this.Handle == _foregroundWinHandle) {
          return;
        }
        foregroundWinHandle = _foregroundWinHandle;

        this.Visible = false;
        SetWindowLong(this.Handle, GWL.HWNDPARENT, (UInt32)foregroundWinHandle);
        this.Visible = true;
        ActiveWindow(foregroundWinHandle);
      }

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        rect.top = rect.top + GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) - 1;
        rect.bottom = rect.bottom + GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) - 1;
      }

      // Console.WriteLine("{0} {1} {2}", foregroundWinHandle, rect.top, rect.left);

      // this.Top = rect.top;
      // this.Left = rect.left;
      // this.Width = rect.right - rect.left;
      // this.Height = rect.bottom - rect.top;

      // this.Top = rect.top;
      // this.Left = rect.left;
      // this.Width =
      //   GetSystemMetrics(SystemMetric.SM_CXSIZE);
      // this.Height =
      //   GetSystemMetrics(SystemMetric.SM_CYSIZE) +
      //   GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME);

      {
        int width = GetSystemMetrics(SystemMetric.SM_CXSIZE) + 10;
        int right = rect.right;
        right -= 6;
        this.Top = rect.top + 1;
        this.Width = width;
        // this.Left = right - width * 2;
        // this.Left = right - width * 3;
        this.Left = right - width * 4;
        this.Height = (
          GetSystemMetrics(SystemMetric.SM_CYSIZE) +
          GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) * 2
        ) / 2;
      }

      if (this.Bounds.Contains(Cursor.Position)) {
        this.Opacity = 0.8;
      } else {
        this.Opacity = 0.3;
      }

    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      bool existsOtherMonitor = false;
      if (Screen.AllScreens.Length != 1) {
        existsOtherMonitor= true;
      }
      toPrevMonitorMenuItem.Visible = existsOtherMonitor;
      toNextMonitorMenuItem.Visible = existsOtherMonitor;
      rootToPrevMonitorMenuItem.Visible = existsOtherMonitor;
      rootToNextMonitorMenuItem.Visible = existsOtherMonitor;
      toOtherMonitorSeparator.Visible = existsOtherMonitor;

    }

    private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
      if (!this.Bounds.Contains(Cursor.Position)) {
        this.contextMenuStrip1.Tag = null;
      }
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e) {
      if (this.contextMenuStrip1.Tag == null) {
        this.contextMenuStrip1.Show(
          new Point(this.Left, this.Bottom)
        );
        this.contextMenuStrip1.Tag = "Show";
      } else {
        this.contextMenuStrip1.Tag = null;
      }
    }

    private int GetTargetScreenIndex(IntPtr hwnd) {
      if (GetWindowState(hwnd) == "Maximized") {
        ShowWindow(hwnd, SW_RESTORE);
      }

      var titlebarHeight = (
         GetSystemMetrics(SystemMetric.SM_CYSIZE) +
         GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) * 2
      );

      RECT rect;
      GetWindowRect(hwnd, out rect);

      int width = rect.right - rect.left;
      var p = new Point(rect.left + width / 2, rect.top + titlebarHeight);
      return GetScreenIndexFromPoint(p);
    }

    private Screen GetTargetScreen(IntPtr hwnd) {
      return Screen.AllScreens[GetTargetScreenIndex(hwnd)];
    }

    private void centerMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + (r.Width * (100 - size) / 100) / 2,
        r.Top + (r.Height * (100 - size) / 100) / 2,
        (r.Width * size / 100),
        (r.Height * size / 100),
        1
      );
      ActiveWindow(foregroundWinHandle);
    }
    private void leftSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        (r.Width * size / 100),
        r.Height,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void rightSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width * (100 - size) / 100,
        r.Top,
        r.Width * size / 100,
        r.Height,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void topSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        r.Width,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void bottomSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top + r.Height * (100 - size) / 100,
        r.Width,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void topLeftSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        r.Width * size / 100,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void topRightSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width * (100 - size) / 100,
        r.Top,
        r.Width * size / 100,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void bottomLeftSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top + r.Height * (100 - size) / 100,
        r.Width * size / 100,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void bottomRightSideMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width * (100 - size) / 100,
        r.Top + r.Height * (100 - size) / 100,
        r.Width * size / 100,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void samePositionPrevMonitorMenuItem_Click(object sender, EventArgs e) {
      var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);
      var prevScreenIndex = currentScreenIndex - 1;
      if (prevScreenIndex == -1) {
        prevScreenIndex = Screen.AllScreens.Length - 1;
      }
      var prevScreen = Screen.AllScreens[prevScreenIndex];

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      Screen currentScreen = Screen.AllScreens[currentScreenIndex];
      double percentLeft = (double)(rect.left - currentScreen.WorkingArea.Left)
        / (double)(currentScreen.WorkingArea.Width);

      double percentTop = (double)(rect.top - currentScreen.WorkingArea.Top)
        / (double)(currentScreen.WorkingArea.Height);
      double percentWidth = (double)(rect.right - rect.left)
        / (double)(currentScreen.WorkingArea.Width);
      double percentHeight = (double)(rect.bottom - rect.top)
        / (double)(currentScreen.WorkingArea.Height);

      var r = prevScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + (int)(r.Width * percentLeft),
        r.Top + (int)(r.Height * percentTop),
        (int)(r.Width * percentWidth),
        (int)(r.Height * percentHeight),
        1
      );
      MoveWindow(
        foregroundWinHandle,
        r.Left + (int)(r.Width * percentLeft),
        r.Top + (int)(r.Height * percentTop),
        (int)(r.Width * percentWidth),
        (int)(r.Height * percentHeight),
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void samePositionNextMonitorMenuItem_Click(object sender, EventArgs e) {
      var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);
      var nextScreenIndex = currentScreenIndex + 1;
      if (nextScreenIndex == Screen.AllScreens.Length) {
        nextScreenIndex = 0;
      }
      var nextScreen = Screen.AllScreens[nextScreenIndex];

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      Screen currentScreen = Screen.AllScreens[currentScreenIndex];
      double percentLeft = (double)(rect.left - currentScreen.WorkingArea.Left) / (double)(currentScreen.WorkingArea.Width);

      double percentTop = (double)(rect.top - currentScreen.WorkingArea.Top) / (double)(currentScreen.WorkingArea.Height);
      double percentWidth = (double)(rect.right - rect.left) / (double)(currentScreen.WorkingArea.Width);
      double percentHeight = (double)(rect.bottom - rect.top) / (double)(currentScreen.WorkingArea.Height);

      var r = nextScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + (int)(r.Width * percentLeft),
        r.Top + (int)(r.Height * percentTop),
        (int)(r.Width * percentWidth),
        (int)(r.Height * percentHeight),
        1
      );
      MoveWindow(
        foregroundWinHandle,
        r.Left + (int)(r.Width * percentLeft),
        r.Top + (int)(r.Height * percentTop),
        (int)(r.Width * percentWidth),
        (int)(r.Height * percentHeight),
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void maximizePrevMonitorMenuItem_Click(object sender, EventArgs e) {
      samePositionPrevMonitorMenuItem_Click(sender, e);
      ShowWindow(foregroundWinHandle, SW_SHOWMAXIMIZED);
    }

    private void maximizeNextMonitorMenuItem_Click(object sender, EventArgs e) {
      samePositionNextMonitorMenuItem_Click(sender, e);
      ShowWindow(foregroundWinHandle, SW_SHOWMAXIMIZED);
    }

    private void MainForm_MouseEnter(object sender, EventArgs e) {
      //this.Opacity = 100;
    }

    private void MainForm_MouseLeave(object sender, EventArgs e) {
      //this.Opacity = 50;
    }
  }
}

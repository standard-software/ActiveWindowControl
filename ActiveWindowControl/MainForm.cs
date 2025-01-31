using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

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

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      {
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Fit Left";
        menuItem.Click += fitLeftSideMenuItem_Click;
        contextMenuStrip1.Items.Insert(0, menuItem);
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Fit Right";
        menuItem.Click += fitRightSideMenuItem_Click;
        contextMenuStrip1.Items.Insert(1, menuItem);

      }
      {
        var fitWindowMenuItem = new ToolStripMenuItem();
        fitWindowMenuItem.Text = "Fit Window";
        contextMenuStrip1.Items.Insert(2, fitWindowMenuItem);
        fitWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
        CreateFitCornerMenuItem(fitWindowMenuItem);

        separator = new ToolStripSeparator();
        contextMenuStrip1.Items.Insert(3, separator);
      }

      {
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Snap Left";
        menuItem.Tag = 50;
        menuItem.Click += snapLeftSideMenuItem_Click;
        contextMenuStrip1.Items.Insert(4, menuItem);
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Snap Right";
        menuItem.Tag = 50;
        menuItem.Click += snapRightSideMenuItem_Click;
        contextMenuStrip1.Items.Insert(5, menuItem);
      }
      {
        var snapWindowMenuItem = new ToolStripMenuItem();
        snapWindowMenuItem.Text = "Snap Window";
        contextMenuStrip1.Items.Insert(6, snapWindowMenuItem);
        snapWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;

        {
          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 50%";
          menuItem.Tag = 50;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          separator = new ToolStripSeparator();
          snapWindowMenuItem.DropDownItems.Add(separator);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 90%";
          menuItem.Tag = 90;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 70%";
          menuItem.Tag = 70;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 30%";
          menuItem.Tag = 30;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          var separator2 = new ToolStripSeparator();
          snapWindowMenuItem.DropDownItems.Add(separator2);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 75%";
          menuItem.Tag = 75;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 25%";
          menuItem.Tag = 25;
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);
        }
      }

      {
        displayMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
      }

      {
        ToolStripProfessionalRenderer renderer = new VS2022MenuRenderer();
        renderer.RoundedEdges = false;
        ToolStripManager.Renderer = renderer;
        ToolStripManager.VisualStylesEnabled = true;
      }

    }

    private void CreateSnapSizeMenuItem(ToolStripMenuItem sizeMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapLeftSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapRightSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopLeftSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopRightSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomLeftSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomRightSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);
      
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Screen Center";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapCenterScreenMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Horizontal Center";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapCenterHorizontalMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Vertical Center";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapCenterVerticalMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

    }

    private void CreateFitCornerMenuItem(ToolStripMenuItem sizeMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top";
      menuItem.Click += fitTopSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom";
      menuItem.Click += fitBottomSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Left";
      menuItem.Click += fitTopLeftSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Right";
      menuItem.Click += fitTopRightSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Left";
      menuItem.Click += fitBottomLeftSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Right";
      menuItem.Click += fitBottomRightSideMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
    }

    private void aboutActiveWindowControlMenuItem_Click(object sender, EventArgs e) {
      timer1.Enabled = false;
      MessageBox.Show(
        "ActiveWindowControl\nVersion:0.15.1",
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

    private async void notifyIcon1_Click(object sender, EventArgs e) {
      //System.Console.WriteLine("notifyIcon1_Click " + this.contextMenuStrip2.Visible.ToString());
      if (this.contextMenuStrip2.Visible) {
        //System.Console.WriteLine("notifyIcon1_Click Hide");
        this.contextMenuStrip2.Hide();
      } else {
        //System.Console.WriteLine("notifyIcon1_Click Show");
        this.contextMenuStrip2.Show(
          Cursor.Position,
          ToolStripDropDownDirection.AboveRight
        );
        await Task.Delay(100);
        this.contextMenuStrip2.Show(
          Cursor.Position,
          ToolStripDropDownDirection.AboveRight
        );
      }
    }

    private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      Application.Restart();
    }

    private void tasktrayRestartMenuItem_Click(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      Application.Restart();
    }

    private void tasktrayExitMenuItem_Click(object sender, EventArgs e) {
      notifyIcon1.Visible = false;
      this.Close();
    }

    private DateTime insideMouseCursorTime = DateTime.MinValue;

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
        SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        ActiveWindow(foregroundWinHandle);
      }

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        var SM_CYSIZEFRAME = GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME);
        rect.top = rect.top + SM_CYSIZEFRAME - 1;
        rect.bottom = rect.bottom + SM_CYSIZEFRAME - 1;
        rect.right -= 2;
      }
      //System.Console.WriteLine(GetSystemMetrics(SystemMetric.SM_CXSIZEFRAME));
      //System.Console.WriteLine(GetSystemMetrics(SystemMetric.SM_CXSIZE));

      this.Top = rect.top + 1;

      // button width
      int width = GetSystemMetrics(SystemMetric.SM_CXSIZE) + 10;
      this.Width = width - 2;

      int right = rect.right - 5;

      // Above the maximize button
      this.Left = right - width * 2;

      // // Above the minimise button
      // this.Left = right - width * 3;

      // // Left of minimise button
      // this.Left = right - width * 4;

      this.Height = (
        GetSystemMetrics(SystemMetric.SM_CYSIZE) +
        GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) + 1
      ) / 2;
      

      if (this.Bounds.Contains(Cursor.Position)) {
        this.Opacity = 0.8;
        if (insideMouseCursorTime == DateTime.MinValue) {
          insideMouseCursorTime = DateTime.Now;
        } else {
          TimeSpan ts = DateTime.Now - insideMouseCursorTime;

          if (0.4 <= ts.TotalSeconds) {
            if (this.contextMenuStrip1.Tag == null) {
              this.Activate();

              // // BelowRight
              // this.contextMenuStrip1.Show(
              //   new Point(this.Left, this.Bottom)
              // );

              // BelowLeft
              this.contextMenuStrip1.Show(
                new Point(this.Right, this.Bottom),
                ToolStripDropDownDirection.BelowLeft
              );
        
              this.contextMenuStrip1.Tag = "Show";
            }
          }
        }
      } else {
        this.Opacity = 0.3;
      }

    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      var screens = GetAllScreens();
      displayMenuItem.DropDownItems.Clear();

      if (screens.Length == 1) {
        displayMenuItem.Visible = false;
      } else if (screens.Length >= 2) {
        displayMenuItem.Visible = true;

        var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);

        for (int i = 0; i < screens.Length; i++) {
          var screen = screens[i];
          string screenName = $"Screen";

          var centerX = screen.Bounds.Left + screen.Bounds.Width / 2;
          var centerY = screen.Bounds.Top + screen.Bounds.Height / 2;

          if (screen.Bounds.Top == 0 && screen.Bounds.Left == 0) {
            screenName += " Center";
          } else {
            if (centerY < 0) screenName += " Up";
            if (centerX < 0) screenName += " Left";
            if (centerY > screen.Bounds.Height) screenName += " Down";
            if (centerX > screen.Bounds.Width) screenName += " Right";
          }

          var screenItem = new ToolStripMenuItem(screenName.Trim());
          screenItem.DropDownDirection = ToolStripDropDownDirection.Left;
          var samePositionMenuItem = new ToolStripMenuItem("Same Position");
          samePositionMenuItem.Tag = i;
          samePositionMenuItem.Click += moveToScreenMenuItem_Click;
          screenItem.DropDownItems.Add(samePositionMenuItem);

          var separator = new ToolStripSeparator();
          screenItem.DropDownItems.Add(separator);

          if (i == currentScreenIndex) {
            screenItem.Text += " - Current Screen";
            screenItem.Enabled = false;
          }

          displayMenuItem.DropDownItems.Add(screenItem);
        }
      }
    }

    private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e) {
      if (this.contextMenuStrip1.Tag == null) {

        // // BelowRight
        // this.contextMenuStrip1.Show(
        //   new Point(this.Left, this.Bottom)
        // );

        // BelowLeft
        this.contextMenuStrip1.Show(
          new Point(this.Right, this.Bottom),
          ToolStripDropDownDirection.BelowLeft
        );

        this.contextMenuStrip1.Tag = "Show";
      } else {
        this.contextMenuStrip1.Tag = null;
        insideMouseCursorTime = DateTime.MinValue;
      }
    }

    private void MainForm_Deactivate(object sender, EventArgs e) {
      this.contextMenuStrip1.Tag = null;
      insideMouseCursorTime = DateTime.MinValue;
    }

    private void MainForm_Leave(object sender, EventArgs e) {
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
      var screens = GetAllScreens();
      return screens[GetTargetScreenIndex(hwnd)];
    }

    private void snapCenterScreenMenuItem_Click(object sender, EventArgs e) {
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

    private void snapCenterHorizontalMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left + (r.Width * (100 - size) / 100) / 2,
        r.Top,
        (r.Width * size / 100),
        r.Height,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void snapCenterVerticalMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
      int size = (int)menuitem.Tag;
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top + (r.Height * (100 - size) / 100) / 2,
        r.Width,
        r.Height * size / 100,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void snapLeftSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapRightSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapTopSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapBottomSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapTopLeftSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapTopRightSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapBottomLeftSideMenuItem_Click(object sender, EventArgs e) {
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

    private void snapBottomRightSideMenuItem_Click(object sender, EventArgs e) {
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

    private void fitLeftSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        winRect.right - winRect.left,
        r.Height,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void fitRightSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width - (winRect.right - winRect.left),
        r.Top,
        winRect.right - winRect.left,
        r.Height,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void fitTopSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        r.Width,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }
    private void fitBottomSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top + r.Height - (winRect.bottom - winRect.top),
        r.Width,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void fitTopLeftSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top,
        winRect.right - winRect.left,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }
    private void fitTopRightSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width - (winRect.right - winRect.left),
        r.Top,
        winRect.right - winRect.left,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void fitBottomLeftSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      var r = targetScreen.WorkingArea;
      MoveWindow(
        foregroundWinHandle,
        r.Left,
        r.Top + r.Height - (winRect.bottom - winRect.top),
        winRect.right - winRect.left,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }
    private void fitBottomRightSideMenuItem_Click(object sender, EventArgs e) {
      if (foregroundWinHandle == null) { return; }
      var targetScreen = GetTargetScreen(foregroundWinHandle);
      var r = targetScreen.WorkingArea;
      RECT winRect;
      GetWindowRect(foregroundWinHandle, out winRect);
      MoveWindow(
        foregroundWinHandle,
        r.Left + r.Width - (winRect.right - winRect.left),
        r.Top + r.Height - (winRect.bottom - winRect.top),
        winRect.right - winRect.left,
        winRect.bottom - winRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void moveToSamePositionDisplay(int screenIndex) {
            var screens = GetAllScreens();
      var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);
      var targetScreen = screens[screenIndex];

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      Screen currentScreen = screens[currentScreenIndex];
      double percentLeft = (double)(rect.left - currentScreen.WorkingArea.Left)
        / (double)(currentScreen.WorkingArea.Width);

      double percentTop = (double)(rect.top - currentScreen.WorkingArea.Top)
        / (double)(currentScreen.WorkingArea.Height);
      double percentWidth = (double)(rect.right - rect.left)
        / (double)(currentScreen.WorkingArea.Width);
      double percentHeight = (double)(rect.bottom - rect.top)
        / (double)(currentScreen.WorkingArea.Height);

      var r = targetScreen.WorkingArea;
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

    private void moveToScreenMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      int screenIndex = (int)menuItem.Tag;
      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        moveToSamePositionDisplay(screenIndex);
        SendMessage(foregroundWinHandle, WM_SYSCOMMAND, (IntPtr)SC_MAXIMIZE, IntPtr.Zero);
      } else {
        moveToSamePositionDisplay(screenIndex);
      }
    }

    private void contextMenuStrip2_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
      //System.Console.WriteLine("contextMenuStrip2_Closed");
      contextMenuStrip2.Visible = false;
    }

  }

  public class VS2022MenuColorTable : ProfessionalColorTable {

    public VS2022MenuColorTable() {
      this.UseSystemColors = false;
    }

    public override Color ImageMarginGradientBegin { get { return Color.FromArgb(46, 46, 46); } }
    public override Color ImageMarginGradientEnd { get { return Color.FromArgb(46, 46, 46); } }
    public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(46, 46, 46); } }
    public override Color MenuBorder { get { return Color.FromArgb(66, 66, 66); } }
    public override Color MenuItemBorder { get { return Color.FromArgb(112, 112, 112); } }
    public override Color MenuItemSelected { get { return Color.FromArgb(61, 61, 61); } }
    public override Color SeparatorDark { get { return Color.FromArgb(61, 61, 61); } }
    public override Color ToolStripDropDownBackground { get { return Color.FromArgb(46, 46, 46); } }

  }

  public class VS2022MenuRenderer : ToolStripProfessionalRenderer {

    public VS2022MenuRenderer()
        : base(new VS2022MenuColorTable()) {
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
      e.TextColor = Color.FromArgb(250, 250, 250);
      base.OnRenderItemText(e);
    }

    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
      e.ArrowColor = Color.FromArgb(214, 214, 214);
      base.OnRenderArrow(e);
    }

  }
}

using System;
using System.Collections.Generic;
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

    private List<ToolStripItem> initialContextMenuItems;

    private void MainForm_Load(object sender, EventArgs e) {
      this.Top = 0;
      this.Left = 0;
      this.Height = 0;

      initialContextMenuItems = new List<ToolStripItem>();
      foreach (ToolStripItem item in contextMenuStrip1.Items) {
        initialContextMenuItems.Add(item);
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
    
    private void CreateFitSnapMenuItem(ToolStripItemCollection menuItems, int screenIndex) {
      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;
      {
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Fit Left";
        menuItem.Tag = screenIndex;
        menuItem.Click += fitLeftMenuItem_Click;
        menuItems.Add(menuItem);
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Fit Right";
        menuItem.Tag = screenIndex;
        menuItem.Click += fitRightMenuItem_Click;
        menuItems.Add(menuItem);
      }
      {
        var fitWindowMenuItem = new ToolStripMenuItem();
        fitWindowMenuItem.Text = "Fit Window";
        fitWindowMenuItem.Tag = screenIndex;
        menuItems.Add(fitWindowMenuItem);
        fitWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;
        CreateFitWindowMenuItem(fitWindowMenuItem);

        separator = new ToolStripSeparator();
        menuItems.Add(separator);
      }

      {
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Snap Left";
        menuItem.Tag = (screenIndex, 50);
        menuItem.Click += snapLeftMenuItem_Click;
        menuItems.Add(menuItem);
        menuItem = new ToolStripMenuItem();
        menuItem.Text = "Snap Right";
        menuItem.Tag = (screenIndex, 50);
        menuItem.Click += snapRightMenuItem_Click;
        menuItems.Add(menuItem);
      }
      {
        var snapWindowMenuItem = new ToolStripMenuItem();
        snapWindowMenuItem.Text = "Snap Window";
        menuItems.Add(snapWindowMenuItem);
        snapWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;

        {
          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 50%";
          menuItem.Tag = (screenIndex, 50);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          separator = new ToolStripSeparator();
          snapWindowMenuItem.DropDownItems.Add(separator);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 90%";
          menuItem.Tag = (screenIndex, 90);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 70%";
          menuItem.Tag = (screenIndex, 70);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 30%";
          menuItem.Tag = (screenIndex, 30);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          var separator2 = new ToolStripSeparator();
          snapWindowMenuItem.DropDownItems.Add(separator2);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 75%";
          menuItem.Tag = (screenIndex, 75);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);

          menuItem = new ToolStripMenuItem();
          menuItem.Text = "Size 25%";
          menuItem.Tag = (screenIndex, 25);
          menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
          snapWindowMenuItem.DropDownItems.Add(menuItem);
          CreateSnapSizeMenuItem(menuItem);
        }
      }
    }

    private void CreateFitWindowMenuItem(ToolStripMenuItem fitMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitTopMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitBottomMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      fitMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Left";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitTopLeftMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Right";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitTopRightMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Left";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitBottomLeftMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Right";
      menuItem.Tag = fitMenuItem.Tag;
      menuItem.Click += fitBottomRightMenuItem_Click;
      fitMenuItem.DropDownItems.Add(menuItem);
    }

    private void CreateSnapSizeMenuItem(ToolStripMenuItem sizeMenuItem) {

      ToolStripMenuItem menuItem;
      ToolStripSeparator separator;

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapLeftMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapRightMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);

      separator = new ToolStripSeparator();
      sizeMenuItem.DropDownItems.Add(separator);

      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopLeftMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Top Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapTopRightMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Left";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomLeftMenuItem_Click;
      sizeMenuItem.DropDownItems.Add(menuItem);
      menuItem = new ToolStripMenuItem();
      menuItem.Text = "Bottom Right";
      menuItem.Tag = sizeMenuItem.Tag;
      menuItem.Click += snapBottomRightMenuItem_Click;
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
      // WriteLine("notifyIcon1_Click " + this.contextMenuStrip2.Visible.ToString());
      if (this.contextMenuStrip2.Visible) {
        // WriteLine("notifyIcon1_Click Hide");
        this.contextMenuStrip2.Hide();
      } else {
        // WriteLine("notifyIcon1_Click Show");
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
      // WriteLine($"foregroundWinHandle: {_foregroundWinHandle}, {foregroundWinHandle}");

      if (!IsThickFrame(_foregroundWinHandle)) { return; }

      if (foregroundWinHandle != _foregroundWinHandle) {
        if (this.Handle == _foregroundWinHandle) {
          return;
        }
        foregroundWinHandle = _foregroundWinHandle;
      }

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);
      // WriteLine($"foreground Window Rect: Left={rect.left}, Top={rect.top}, Right={rect.right}, Bottom={rect.bottom}");

      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        var SM_CYSIZEFRAME = GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME);
        rect.top = rect.top + SM_CYSIZEFRAME - 1;
        rect.bottom = rect.bottom + SM_CYSIZEFRAME - 1;
        rect.right -= 2;
      }
      // WriteLine($"{GetSystemMetrics(SystemMetric.SM_CXSIZEFRAME)} {GetSystemMetrics(SystemMetric.SM_CXSIZE)}" );

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
      
      // WriteLine($"this rect: Left={this.Left}, Top={this.Top}, Height={this.Height}, Width={this.Width}");
      // WriteLine($"this visible:{this.Visible} opacity:{this.Opacity} IsWindowVisible:{IsWindowVisible(foregroundWinHandle)}");


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

      contextMenuStrip1.Items.Clear();

      var screenIndex = -1;
      CreateFitSnapMenuItem(contextMenuStrip1.Items, screenIndex);

      foreach (var item in initialContextMenuItems) {
        contextMenuStrip1.Items.Add(item);
      }

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
          samePositionMenuItem.Click += samePositionMenuItem_Click;
          screenItem.DropDownItems.Add(samePositionMenuItem);

          var separator = new ToolStripSeparator();
          screenItem.DropDownItems.Add(separator);

          CreateFitSnapMenuItem(screenItem.DropDownItems, i);

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

    private void SnapWindow(int screenIndex, Action<Rectangle, RECT> moveWindowFn) {
      if (foregroundWinHandle == null) { return; }
      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        ShowWindow(foregroundWinHandle, SW_RESTORE);
      }
      var screens = GetAllScreens();
      Screen screen;
      RECT winRect;
      if (screenIndex == -1) {
        screen = screens[GetTargetScreenIndex(foregroundWinHandle)];
        GetWindowRect(foregroundWinHandle, out winRect);
      } else {
        screen = screens[screenIndex];
        winRect = getRectSamePositionToDisplay(screenIndex);
        MoveWindow(
          foregroundWinHandle,
          winRect.left, winRect.top,
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      }
      var screenRectangle = screen.WorkingArea;
      moveWindowFn(screenRectangle, winRect);
      ActiveWindow(foregroundWinHandle);
    }

    private void snapLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          (screenRectangle.Width * size / 100),
          screenRectangle.Height,
          1
        );
      });
    }

    private void snapRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width * (100 - size) / 100,
          screenRectangle.Top,
          screenRectangle.Width * size / 100,
          screenRectangle.Height,
          1
        );
      });
    }

    private void snapTopMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          screenRectangle.Width,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapBottomMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top + screenRectangle.Height * (100 - size) / 100,
          screenRectangle.Width,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapTopLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          screenRectangle.Width * size / 100,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapTopRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width * (100 - size) / 100,
          screenRectangle.Top,
          screenRectangle.Width * size / 100,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapBottomLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top + screenRectangle.Height * (100 - size) / 100,
          screenRectangle.Width * size / 100,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapBottomRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width * (100 - size) / 100,
          screenRectangle.Top + screenRectangle.Height * (100 - size) / 100,
          screenRectangle.Width * size / 100,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void snapCenterScreenMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + (screenRectangle.Width * (100 - size) / 100) / 2,
          screenRectangle.Top + (screenRectangle.Height * (100 - size) / 100) / 2,
          (screenRectangle.Width * size / 100),
          (screenRectangle.Height * size / 100),
          1
        );
      });
    }

    private void snapCenterHorizontalMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + (screenRectangle.Width * (100 - size) / 100) / 2,
          screenRectangle.Top,
          (screenRectangle.Width * size / 100),
          screenRectangle.Height,
          1
        );
      });
    }

    private void snapCenterVerticalMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var (screenIndex, size) = ((int, int))menuItem.Tag;
      SnapWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top + (screenRectangle.Height * (100 - size) / 100) / 2,
          screenRectangle.Width,
          screenRectangle.Height * size / 100,
          1
        );
      });
    }

    private void FitWindow(int screenIndex, Action<Rectangle, RECT> moveWindowFn) {
      if (foregroundWinHandle == null) { return; }
      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        ShowWindow(foregroundWinHandle, SW_RESTORE);
      }
      var screens = GetAllScreens();
      Screen screen;
      RECT winRect;
      if (screenIndex == -1) {
        screen = screens[GetTargetScreenIndex(foregroundWinHandle)];
        GetWindowRect(foregroundWinHandle, out winRect);
      } else {
        screen = screens[screenIndex];
        winRect = getRectSamePositionToDisplay(screenIndex);
        MoveWindow(
          foregroundWinHandle,
          winRect.left, winRect.top,
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      }
      var screenRectangle = screen.WorkingArea;
      moveWindowFn(screenRectangle, winRect);
      ActiveWindow(foregroundWinHandle);
    }

    private void fitLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          winRect.right - winRect.left,
          screenRectangle.Height,
          1
        );
      });
    }

    private void fitRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width - (winRect.right - winRect.left),
          screenRectangle.Top,
          winRect.right - winRect.left,
          screenRectangle.Height,
          1
        );
      });
    }

    private void fitTopMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          screenRectangle.Width,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private void fitBottomMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top + screenRectangle.Height - (winRect.bottom - winRect.top),
          screenRectangle.Width,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private void fitTopLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top,
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private void fitTopRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width - (winRect.right - winRect.left),
          screenRectangle.Top,
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private void fitBottomLeftMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left,
          screenRectangle.Top + screenRectangle.Height - (winRect.bottom - winRect.top),
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private void fitBottomRightMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      var screenIndex = (int)menuItem.Tag;
      FitWindow(screenIndex, (screenRectangle, winRect) => {
        MoveWindow(
          foregroundWinHandle,
          screenRectangle.Left + screenRectangle.Width - (winRect.right - winRect.left),
          screenRectangle.Top + screenRectangle.Height - (winRect.bottom - winRect.top),
          winRect.right - winRect.left,
          winRect.bottom - winRect.top,
          1
        );
      });
    }

    private RECT getRectSamePositionToDisplay(int screenIndex) {
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
      RECT newRect;
      newRect.left = r.Left + (int)(r.Width * percentLeft);
      newRect.top = r.Top + (int)(r.Height * percentTop);
      newRect.right = newRect.left + (int)(r.Width * percentWidth);
      newRect.bottom = newRect.top + (int)(r.Height * percentHeight);
      return newRect;
    }

    private void moveToSamePositionDisplay(int screenIndex) {
      var newRect = getRectSamePositionToDisplay(screenIndex);
      MoveWindow(
        foregroundWinHandle,
        newRect.left,
        newRect.top,
        newRect.right - newRect.left,
        newRect.bottom - newRect.top,
        1
      );
      MoveWindow(
        foregroundWinHandle,
        newRect.left,
        newRect.top,
        newRect.right - newRect.left,
        newRect.bottom - newRect.top,
        1
      );
      ActiveWindow(foregroundWinHandle);
    }

    private void samePositionMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      int screenIndex = (int)menuItem.Tag;
      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        ShowWindow(foregroundWinHandle, SW_RESTORE);
        moveToSamePositionDisplay(screenIndex);
        SendMessage(foregroundWinHandle, WM_SYSCOMMAND, (IntPtr)SC_MAXIMIZE, IntPtr.Zero);
      } else {
        moveToSamePositionDisplay(screenIndex);
      }
    }

    private void contextMenuStrip2_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
      // WriteLine("contextMenuStrip2_Closed");
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

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
        // Resize Window
        resizeWindowMenuItem.DropDownDirection = ToolStripDropDownDirection.Left;

        ToolStripMenuItem menuItemSize;

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 50%";
        menuItemSize.Tag = 50;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        var separator1 = new ToolStripSeparator();
        resizeWindowMenuItem.DropDownItems.Add(separator1);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 90%";
        menuItemSize.Tag = 90;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 70%";
        menuItemSize.Tag = 70;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 30%";
        menuItemSize.Tag = 30;
        menuItemSize.DropDownDirection = ToolStripDropDownDirection.Left;
        resizeWindowMenuItem.DropDownItems.Add(menuItemSize);
        CreateSizeMenuItem(menuItemSize);

        var separator2 = new ToolStripSeparator();
        resizeWindowMenuItem.DropDownItems.Add(separator2);

        menuItemSize = new ToolStripMenuItem();
        menuItemSize.Text = "Size 75%";
        menuItemSize.Tag = 75;
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
        ToolStripProfessionalRenderer renderer = new VS2022MenuRenderer();
        renderer.RoundedEdges = false;
        ToolStripManager.Renderer = renderer;
        ToolStripManager.VisualStylesEnabled = true;
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
        "ActiveWindowControl\nVersion:0.7.0",
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
      if (this.contextMenuStrip2.Visible) {
        this.contextMenuStrip2.Hide();
      } else {
      this.contextMenuStrip2.Show(
        Cursor.Position,
        ToolStripDropDownDirection.AboveRight
      );
      }
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
        ActiveWindow(foregroundWinHandle);
      }

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      if (GetWindowState(foregroundWinHandle) == "Maximized") {
        rect.top = rect.top + GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) - 1;
        rect.bottom = rect.bottom + GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME) - 1;
      }

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
        if (insideMouseCursorTime == DateTime.MinValue) {
          insideMouseCursorTime = DateTime.Now;
        } else {
          TimeSpan ts = DateTime.Now - insideMouseCursorTime;

          if (0.4 <= ts.TotalSeconds) {
            if (this.contextMenuStrip1.Tag == null) {
              this.Activate();
              this.contextMenuStrip1.Show(
                new Point(this.Left, this.Bottom)
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

      if (Screen.AllScreens.Length == 1) {
        toPrevMonitorMenuItem.Visible = false;
        toNextMonitorMenuItem.Visible = false;
        toOtherMonitorSeparator.Visible = false;
      } else if (Screen.AllScreens.Length == 2) {
        toPrevMonitorMenuItem.Visible = false;
        toNextMonitorMenuItem.Visible = true;
        toOtherMonitorSeparator.Visible = true;
      } else if (3 <= Screen.AllScreens.Length) {
        toPrevMonitorMenuItem.Visible = true;
        toNextMonitorMenuItem.Visible = true;
        toOtherMonitorSeparator.Visible = true;
      }

    }

    private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e) {
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e) {
      if (this.contextMenuStrip1.Tag == null) {
        this.contextMenuStrip1.Show(
          new Point(this.Left, this.Bottom)
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
      var screens = GetAllScreens();
      var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);
      var prevScreenIndex = currentScreenIndex - 1;
      if (prevScreenIndex == -1) {
        prevScreenIndex = screens.Length - 1;
      }
      var prevScreen = screens[prevScreenIndex];

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
      var screens = GetAllScreens();
      var currentScreenIndex = GetTargetScreenIndex(foregroundWinHandle);
      var nextScreenIndex = currentScreenIndex + 1;
      if (nextScreenIndex == screens.Length) {
        nextScreenIndex = 0;
      }
      var nextScreen = screens[nextScreenIndex];

      RECT rect;
      GetWindowRect(foregroundWinHandle, out rect);

      Screen currentScreen = screens[currentScreenIndex];
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

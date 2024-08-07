namespace ActiveWindowControl {
  partial class MainForm {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rightSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.topSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bottomSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.topLeftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.splitPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tasktrayAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.tasktrayRestartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tasktrayExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resizeWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toOtherMonitorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.toPrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.samePositionPrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.maximizePrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.samePositionNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.maximizeNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.contextMenuStrip2.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // leftSideToolStripMenuItem
      // 
      this.leftSideToolStripMenuItem.Name = "leftSideToolStripMenuItem";
      this.leftSideToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
      // 
      // rightSideToolStripMenuItem
      // 
      this.rightSideToolStripMenuItem.Name = "rightSideToolStripMenuItem";
      this.rightSideToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
      // 
      // topSideToolStripMenuItem
      // 
      this.topSideToolStripMenuItem.Name = "topSideToolStripMenuItem";
      this.topSideToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // bottomSideToolStripMenuItem
      // 
      this.bottomSideToolStripMenuItem.Name = "bottomSideToolStripMenuItem";
      this.bottomSideToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
      // 
      // topLeftSideToolStripMenuItem
      // 
      this.topLeftSideToolStripMenuItem.Name = "topLeftSideToolStripMenuItem";
      this.topLeftSideToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
      this.topLeftSideToolStripMenuItem.Text = "TopLeft Side";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
      // 
      // splitPositionToolStripMenuItem
      // 
      this.splitPositionToolStripMenuItem.Name = "splitPositionToolStripMenuItem";
      this.splitPositionToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "ActiveWindowControl";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
      // 
      // contextMenuStrip2
      // 
      this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(28, 28);
      this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tasktrayAboutMenuItem,
            this.toolStripMenuItem3,
            this.tasktrayRestartMenuItem,
            this.tasktrayExitMenuItem});
      this.contextMenuStrip2.Name = "contextMenuStrip2";
      this.contextMenuStrip2.Size = new System.Drawing.Size(136, 88);
      this.contextMenuStrip2.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip2_Closed);
      // 
      // tasktrayAboutMenuItem
      // 
      this.tasktrayAboutMenuItem.Name = "tasktrayAboutMenuItem";
      this.tasktrayAboutMenuItem.Size = new System.Drawing.Size(135, 26);
      this.tasktrayAboutMenuItem.Text = "About";
      this.tasktrayAboutMenuItem.Click += new System.EventHandler(this.aboutActiveWindowControlMenuItem_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(132, 6);
      // 
      // tasktrayRestartMenuItem
      // 
      this.tasktrayRestartMenuItem.Name = "tasktrayRestartMenuItem";
      this.tasktrayRestartMenuItem.Size = new System.Drawing.Size(135, 26);
      this.tasktrayRestartMenuItem.Text = "Restart";
      this.tasktrayRestartMenuItem.Click += new System.EventHandler(this.tasktrayRestartMenuItem_Click);
      // 
      // tasktrayExitMenuItem
      // 
      this.tasktrayExitMenuItem.Name = "tasktrayExitMenuItem";
      this.tasktrayExitMenuItem.Size = new System.Drawing.Size(135, 26);
      this.tasktrayExitMenuItem.Text = "Exit";
      this.tasktrayExitMenuItem.Click += new System.EventHandler(this.tasktrayExitMenuItem_Click);
      // 
      // resizeWindowMenuItem
      // 
      this.resizeWindowMenuItem.Name = "resizeWindowMenuItem";
      this.resizeWindowMenuItem.Size = new System.Drawing.Size(246, 26);
      this.resizeWindowMenuItem.Text = "Resize Window";
      // 
      // toOtherMonitorSeparator
      // 
      this.toOtherMonitorSeparator.Name = "toOtherMonitorSeparator";
      this.toOtherMonitorSeparator.Size = new System.Drawing.Size(243, 6);
      // 
      // toPrevMonitorMenuItem
      // 
      this.toPrevMonitorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samePositionPrevMonitorMenuItem,
            this.maximizePrevMonitorMenuItem});
      this.toPrevMonitorMenuItem.Name = "toPrevMonitorMenuItem";
      this.toPrevMonitorMenuItem.Size = new System.Drawing.Size(246, 26);
      this.toPrevMonitorMenuItem.Text = "Move To Prev Monitor";
      // 
      // samePositionPrevMonitorMenuItem
      // 
      this.samePositionPrevMonitorMenuItem.Name = "samePositionPrevMonitorMenuItem";
      this.samePositionPrevMonitorMenuItem.Size = new System.Drawing.Size(187, 26);
      this.samePositionPrevMonitorMenuItem.Text = "Same Position";
      this.samePositionPrevMonitorMenuItem.Click += new System.EventHandler(this.samePositionPrevMonitorMenuItem_Click);
      // 
      // maximizePrevMonitorMenuItem
      // 
      this.maximizePrevMonitorMenuItem.Name = "maximizePrevMonitorMenuItem";
      this.maximizePrevMonitorMenuItem.Size = new System.Drawing.Size(187, 26);
      this.maximizePrevMonitorMenuItem.Text = "Maximize";
      this.maximizePrevMonitorMenuItem.Click += new System.EventHandler(this.maximizePrevMonitorMenuItem_Click);
      // 
      // toNextMonitorMenuItem
      // 
      this.toNextMonitorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samePositionNextMonitorMenuItem,
            this.maximizeNextMonitorMenuItem});
      this.toNextMonitorMenuItem.Name = "toNextMonitorMenuItem";
      this.toNextMonitorMenuItem.Size = new System.Drawing.Size(246, 26);
      this.toNextMonitorMenuItem.Text = "Move To Next Monitor";
      // 
      // samePositionNextMonitorMenuItem
      // 
      this.samePositionNextMonitorMenuItem.Name = "samePositionNextMonitorMenuItem";
      this.samePositionNextMonitorMenuItem.Size = new System.Drawing.Size(187, 26);
      this.samePositionNextMonitorMenuItem.Text = "Same Position";
      this.samePositionNextMonitorMenuItem.Click += new System.EventHandler(this.samePositionNextMonitorMenuItem_Click);
      // 
      // maximizeNextMonitorMenuItem
      // 
      this.maximizeNextMonitorMenuItem.Name = "maximizeNextMonitorMenuItem";
      this.maximizeNextMonitorMenuItem.Size = new System.Drawing.Size(187, 26);
      this.maximizeNextMonitorMenuItem.Text = "Maximize";
      this.maximizeNextMonitorMenuItem.Click += new System.EventHandler(this.maximizeNextMonitorMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
      // 
      // aboutMenuItem
      // 
      this.aboutMenuItem.Name = "aboutMenuItem";
      this.aboutMenuItem.Size = new System.Drawing.Size(246, 26);
      this.aboutMenuItem.Text = "About";
      this.aboutMenuItem.Click += new System.EventHandler(this.aboutActiveWindowControlMenuItem_Click);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeWindowMenuItem,
            this.toOtherMonitorSeparator,
            this.toPrevMonitorMenuItem,
            this.toNextMonitorMenuItem,
            this.toolStripSeparator3,
            this.aboutMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(247, 142);
      this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.ClientSize = new System.Drawing.Size(77, 62);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MainForm";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Form1";
      this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Leave += new System.EventHandler(this.MainForm_Leave);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
      this.contextMenuStrip2.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.ToolStripMenuItem leftSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rightSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem topSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bottomSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem topLeftSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem splitPositionToolStripMenuItem;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    private System.Windows.Forms.ToolStripMenuItem tasktrayAboutMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tasktrayExitMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tasktrayRestartMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem resizeWindowMenuItem;
    private System.Windows.Forms.ToolStripSeparator toOtherMonitorSeparator;
    private System.Windows.Forms.ToolStripMenuItem toPrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem samePositionPrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem maximizePrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem samePositionNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem maximizeNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
  }
}


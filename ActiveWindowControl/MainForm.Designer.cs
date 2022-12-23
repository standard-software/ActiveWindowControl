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
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.leftSideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rightSideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.size75CenterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rootToPrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rootToNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.splitScreenAreaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resizeWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toOtherMonitorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.toPrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.samePositionPrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.maximizePrevMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.samePositionNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.maximizeNextMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutActiveWindowControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rightSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.topSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bottomSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.topLeftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.splitPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftSideMenuItem,
            this.rightSideMenuItem,
            this.size75CenterMenuItem,
            this.rootToPrevMonitorMenuItem,
            this.rootToNextMonitorMenuItem,
            this.toolStripSeparator4,
            this.splitScreenAreaMenuItem,
            this.resizeWindowMenuItem,
            this.toOtherMonitorSeparator,
            this.toPrevMonitorMenuItem,
            this.toNextMonitorMenuItem,
            this.toolStripSeparator3,
            this.aboutActiveWindowControlToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(223, 286);
      this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
      // 
      // leftSideMenuItem
      // 
      this.leftSideMenuItem.Name = "leftSideMenuItem";
      this.leftSideMenuItem.Size = new System.Drawing.Size(222, 22);
      this.leftSideMenuItem.Text = "Left Side";
      // 
      // rightSideMenuItem
      // 
      this.rightSideMenuItem.Name = "rightSideMenuItem";
      this.rightSideMenuItem.Size = new System.Drawing.Size(222, 22);
      this.rightSideMenuItem.Text = "Right Side";
      // 
      // size75CenterMenuItem
      // 
      this.size75CenterMenuItem.Name = "size75CenterMenuItem";
      this.size75CenterMenuItem.Size = new System.Drawing.Size(222, 22);
      this.size75CenterMenuItem.Text = "Center Size75%";
      // 
      // rootToPrevMonitorMenuItem
      // 
      this.rootToPrevMonitorMenuItem.Name = "rootToPrevMonitorMenuItem";
      this.rootToPrevMonitorMenuItem.Size = new System.Drawing.Size(222, 22);
      this.rootToPrevMonitorMenuItem.Text = "Prev Monitor Same Position";
      // 
      // rootToNextMonitorMenuItem
      // 
      this.rootToNextMonitorMenuItem.Name = "rootToNextMonitorMenuItem";
      this.rootToNextMonitorMenuItem.Size = new System.Drawing.Size(222, 22);
      this.rootToNextMonitorMenuItem.Text = "Next Monitor Same Position";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(219, 6);
      // 
      // splitScreenAreaMenuItem
      // 
      this.splitScreenAreaMenuItem.Name = "splitScreenAreaMenuItem";
      this.splitScreenAreaMenuItem.Size = new System.Drawing.Size(222, 22);
      this.splitScreenAreaMenuItem.Text = "Split Screen Area";
      // 
      // resizeWindowMenuItem
      // 
      this.resizeWindowMenuItem.Name = "resizeWindowMenuItem";
      this.resizeWindowMenuItem.Size = new System.Drawing.Size(222, 22);
      this.resizeWindowMenuItem.Text = "Resize Window";
      // 
      // toOtherMonitorSeparator
      // 
      this.toOtherMonitorSeparator.Name = "toOtherMonitorSeparator";
      this.toOtherMonitorSeparator.Size = new System.Drawing.Size(219, 6);
      // 
      // toPrevMonitorMenuItem
      // 
      this.toPrevMonitorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samePositionPrevMonitorMenuItem,
            this.maximizePrevMonitorMenuItem});
      this.toPrevMonitorMenuItem.Name = "toPrevMonitorMenuItem";
      this.toPrevMonitorMenuItem.Size = new System.Drawing.Size(222, 22);
      this.toPrevMonitorMenuItem.Text = "Move To Prev Monitor";
      // 
      // samePositionPrevMonitorMenuItem
      // 
      this.samePositionPrevMonitorMenuItem.Name = "samePositionPrevMonitorMenuItem";
      this.samePositionPrevMonitorMenuItem.Size = new System.Drawing.Size(148, 22);
      this.samePositionPrevMonitorMenuItem.Text = "Same Position";
      this.samePositionPrevMonitorMenuItem.Click += new System.EventHandler(this.samePositionPrevMonitorMenuItem_Click);
      // 
      // maximizePrevMonitorMenuItem
      // 
      this.maximizePrevMonitorMenuItem.Name = "maximizePrevMonitorMenuItem";
      this.maximizePrevMonitorMenuItem.Size = new System.Drawing.Size(148, 22);
      this.maximizePrevMonitorMenuItem.Text = "Maximize";
      this.maximizePrevMonitorMenuItem.Click += new System.EventHandler(this.maximizePrevMonitorMenuItem_Click);
      // 
      // toNextMonitorMenuItem
      // 
      this.toNextMonitorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samePositionNextMonitorMenuItem,
            this.maximizeNextMonitorMenuItem});
      this.toNextMonitorMenuItem.Name = "toNextMonitorMenuItem";
      this.toNextMonitorMenuItem.Size = new System.Drawing.Size(222, 22);
      this.toNextMonitorMenuItem.Text = "Move To Next Monitor";
      // 
      // samePositionNextMonitorMenuItem
      // 
      this.samePositionNextMonitorMenuItem.Name = "samePositionNextMonitorMenuItem";
      this.samePositionNextMonitorMenuItem.Size = new System.Drawing.Size(148, 22);
      this.samePositionNextMonitorMenuItem.Text = "Same Position";
      this.samePositionNextMonitorMenuItem.Click += new System.EventHandler(this.samePositionNextMonitorMenuItem_Click);
      // 
      // maximizeNextMonitorMenuItem
      // 
      this.maximizeNextMonitorMenuItem.Name = "maximizeNextMonitorMenuItem";
      this.maximizeNextMonitorMenuItem.Size = new System.Drawing.Size(148, 22);
      this.maximizeNextMonitorMenuItem.Text = "Maximize";
      this.maximizeNextMonitorMenuItem.Click += new System.EventHandler(this.maximizeNextMonitorMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
      // 
      // aboutActiveWindowControlToolStripMenuItem
      // 
      this.aboutActiveWindowControlToolStripMenuItem.Name = "aboutActiveWindowControlToolStripMenuItem";
      this.aboutActiveWindowControlToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
      this.aboutActiveWindowControlToolStripMenuItem.Text = "About";
      this.aboutActiveWindowControlToolStripMenuItem.Click += new System.EventHandler(this.aboutActiveWindowControlToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(77, 62);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MainForm";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

    private System.Windows.Forms.ToolStripMenuItem leftSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rightSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem topSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bottomSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem topLeftSideToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem splitPositionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem resizeWindowMenuItem;
    private System.Windows.Forms.ToolStripMenuItem splitScreenAreaMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutActiveWindowControlToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toOtherMonitorSeparator;
    private System.Windows.Forms.ToolStripMenuItem toPrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem samePositionPrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem maximizePrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem samePositionNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem maximizeNextMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem leftSideMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rightSideMenuItem;
    private System.Windows.Forms.ToolStripMenuItem size75CenterMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem rootToPrevMonitorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rootToNextMonitorMenuItem;
  }
}


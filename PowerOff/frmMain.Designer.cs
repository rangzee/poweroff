namespace PowerOff
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbxAction = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tspbRemain = new System.Windows.Forms.ToolStripProgressBar();
            this.tslblRemain = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbxTimeMode = new System.Windows.Forms.ComboBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.nicoMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmMain = new System.Windows.Forms.Timer(this.components);
            this.stsMain.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxAction
            // 
            this.cbxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAction.FormattingEnabled = true;
            this.cbxAction.Items.AddRange(new object[] {
            "休眠",
            "关机",
            "注销",
            "重启"});
            this.cbxAction.Location = new System.Drawing.Point(275, 34);
            this.cbxAction.Name = "cbxAction";
            this.cbxAction.Size = new System.Drawing.Size(50, 21);
            this.cbxAction.TabIndex = 3;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(126, 34);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(143, 20);
            this.dtpTime.TabIndex = 0;
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbRemain,
            this.tslblRemain});
            this.stsMain.Location = new System.Drawing.Point(0, 181);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(394, 23);
            this.stsMain.SizingGrip = false;
            this.stsMain.TabIndex = 4;
            this.stsMain.Text = "statusStrip1";
            // 
            // tspbRemain
            // 
            this.tspbRemain.AutoSize = false;
            this.tspbRemain.Name = "tspbRemain";
            this.tspbRemain.Size = new System.Drawing.Size(388, 17);
            this.tspbRemain.Step = 1;
            this.tspbRemain.ToolTipText = "00.00";
            // 
            // tslblRemain
            // 
            this.tslblRemain.AutoSize = false;
            this.tslblRemain.Name = "tslblRemain";
            this.tslblRemain.Size = new System.Drawing.Size(137, 18);
            this.tslblRemain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTimeMode
            // 
            this.cbxTimeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTimeMode.FormattingEnabled = true;
            this.cbxTimeMode.Items.AddRange(new object[] {
            "就在",
            "再等"});
            this.cbxTimeMode.Location = new System.Drawing.Point(70, 34);
            this.cbxTimeMode.Name = "cbxTimeMode";
            this.cbxTimeMode.Size = new System.Drawing.Size(50, 21);
            this.cbxTimeMode.TabIndex = 5;
            this.cbxTimeMode.SelectedIndexChanged += new System.EventHandler(this.cbxTimeMode_SelectedIndexChanged);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(136, 100);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(123, 39);
            this.btnAction.TabIndex = 6;
            this.btnAction.Text = "确定";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // nicoMain
            // 
            this.nicoMain.ContextMenuStrip = this.cmsMain;
            this.nicoMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nicoMain.Icon")));
            this.nicoMain.Visible = true;
            this.nicoMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nicoMain_MouseDoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHide,
            this.tsmiExit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(127, 48);
            // 
            // tsmiHide
            // 
            this.tsmiHide.Name = "tsmiHide";
            this.tsmiHide.Size = new System.Drawing.Size(126, 22);
            this.tsmiHide.Tag = "";
            this.tsmiHide.Text = "显示/隐藏";
            this.tsmiHide.Click += new System.EventHandler(this.tsmiHide_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(126, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tmMain
            // 
            this.tmMain.Interval = 1000;
            this.tmMain.Tick += new System.EventHandler(this.tmMain_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 204);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.cbxTimeMode);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.cbxAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "定时关机小程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAction;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripProgressBar tspbRemain;
        private System.Windows.Forms.ComboBox cbxTimeMode;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.NotifyIcon nicoMain;
        private System.Windows.Forms.Timer tmMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiHide;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripStatusLabel tslblRemain;
    }
}


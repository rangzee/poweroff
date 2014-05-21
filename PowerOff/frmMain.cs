using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PowerOff
{
    public partial class frmMain : Form
    {
        private DateTime _startTime;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbxAction.SelectedIndex = 0;
            cbxTimeMode.SelectedIndex = 1;

            tspbRemain.Width = stsMain.Width - 5;
        }

        private void cbxTimeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTimeMode.SelectedIndex == 0)
            {
                dtpTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtpTime.Value = DateTime.Now.AddHours(1);
            }
            else
            {
                dtpTime.CustomFormat = "HH:mm:ss";
                dtpTime.Value = DateTime.Today.AddHours(3);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();

            Application.Exit();
        }

        private void tsmiHide_Click(object sender, EventArgs e)
        {
            if (this.ShowInTaskbar)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
            else
            {
                this.Show();
                this.ShowInTaskbar = true;
            }
        }

        private void nicoMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsmiHide_Click(sender, e);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tsmiHide_Click(sender, e);

            if (btnAction.Text == "取消")
            {
                nicoMain.BalloonTipText = "计时器仍在运行。";
                nicoMain.BalloonTipIcon = ToolTipIcon.Info;
                nicoMain.BalloonTipTitle = "注意！";
                nicoMain.ShowBalloonTip(3000);
            }

            e.Cancel = true;
        }

        private void tmMain_Tick(object sender, EventArgs e)
        {
            var action = (ActionType) cbxAction.SelectedIndex;
            var timeMode = (TimeMode) cbxTimeMode.SelectedIndex;
            var time = dtpTime.Value;

            var totalSeconds =
                timeMode == TimeMode.Wait
                    ? time.TimeOfDay.TotalSeconds
                    : (time - _startTime).TotalSeconds;
            TimeSpan tsRemain =
                timeMode == TimeMode.Wait
                    ? _startTime.Add(time.TimeOfDay) - DateTime.Now
                    : time - DateTime.Now;
            var expired =
                timeMode == TimeMode.Wait
                    ? DateTime.Now >= (_startTime.Add(time.TimeOfDay))
                    : DateTime.Now >= time;

            tslblRemain.Text = string.Format(
                "剩余{0}天{1}小{2}分{3}秒",
                tsRemain.Days, tsRemain.Hours, tsRemain.Minutes, tsRemain.Seconds);

            var progress = (int) ((tsRemain.TotalSeconds/totalSeconds)*100.0);
            tspbRemain.Value = progress < 0 ? 0 : progress;

            if (expired)
            {
                ProcessStartInfo psi = new ProcessStartInfo("shutdown.exe", action.Argment());
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);

                Application.ExitThread();
                Application.Exit();
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "确定")
            {
                btnAction.Text = "取消";

                tmMain.Enabled = true;
                cbxAction.Enabled = false;
                cbxTimeMode.Enabled = false;
                dtpTime.Enabled = false;

                _startTime = DateTime.Now;

                tspbRemain.Value = 100;

                var time = dtpTime.Value;
                var timeMode = (TimeMode)cbxTimeMode.SelectedIndex;

                TimeSpan tsRemain =
                    timeMode == TimeMode.Wait
                        ? _startTime.Add(time.TimeOfDay) - DateTime.Now.AddSeconds(1)
                        : time - DateTime.Now.AddSeconds(1);

                tspbRemain.Width = stsMain.Width - 185;
                tslblRemain.Text = string.Format(
                    "剩余{0}天{1}小{2}分{3}秒",
                    tsRemain.Days, tsRemain.Hours, tsRemain.Minutes, tsRemain.Seconds);
            }
            else
            {
                btnAction.Text = "确定";

                tmMain.Enabled = false;
                cbxAction.Enabled = true;
                cbxTimeMode.Enabled = true;
                dtpTime.Enabled = true;

                tspbRemain.Value = 0;
                tspbRemain.Width = stsMain.Width - 5;
                tslblRemain.Text = "";
            }
        }
    }

    public enum TimeMode
    {
        At, Wait
    }

    public enum ActionType
    {
        Hibernat, Shutdown, Logoff, Restart
    }

    public static class Extenstions
    {
        public static string Argment(this ActionType action)
        {
            switch (action)
            {
                case ActionType.Hibernat:
                    return "-h";
                case ActionType.Logoff:
                    return "-l";
                case ActionType.Restart:
                    return "-r -f -t 0";
                case ActionType.Shutdown:
                    return "-s -f -t 0";
            }
            return "";
        }
    }
}

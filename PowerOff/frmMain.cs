using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

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
            var mode = GetConfig("Mode");
            var action = GetConfig("Action");
            var minimize = GetConfig("Minimize");
            var autostart = GetConfig("Autostart");
            var time = GetConfig("Time");

            cbxAction.SelectedIndex = string.IsNullOrEmpty(action.Trim()) ? 0 : int.Parse(action);
            cbxTimeMode.SelectedIndex = string.IsNullOrEmpty(mode.Trim()) ? 0 : int.Parse(mode);
            this.cbxMinimize.Checked = minimize.ToLower() == "true";
            this.cbxAutostart.Checked = autostart.ToLower() == "true";
            dtpTime.Text = time;

            tspbRemain.Width = stsMain.Width - 5;

            if (this.cbxAutostart.Checked)
            {
                btnAction_Click(sender, e);
            }

            if (this.cbxMinimize.Checked)
            {
                tsmiHide_Click(sender, e);
            }
        }

        private void cbxTimeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTimeMode.SelectedIndex == 0)
            {
                dtpTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtpTime.Value = DateTime.Now.AddMinutes(30);
            }
            else
            {
                dtpTime.CustomFormat = "HH:mm:ss";
                dtpTime.Value = DateTime.Today.AddMinutes(30);
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

            SetConfig("Mode", cbxTimeMode.SelectedIndex.ToString());
            SetConfig("Action", cbxAction.SelectedIndex.ToString());
            SetConfig("Minimize", cbxMinimize.Checked.ToString());
            SetConfig("Autostart", cbxAutostart.Checked.ToString());
            SetConfig("Time", dtpTime.Text);

            e.Cancel = true;
        }

        private void tmMain_Tick(object sender, EventArgs e)
        {
            var action = (ActionType)cbxAction.SelectedIndex;
            var timeMode = (TimeMode)cbxTimeMode.SelectedIndex;
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

            var progress = (int)((tsRemain.TotalSeconds / totalSeconds) * 100.0);
            tspbRemain.Value = progress < 0 ? 0 : progress;

            if (expired)
            {
                var process = action == ActionType.Sleep ? "rundll32.exe" : "shutdown.exe";

                ProcessStartInfo psi = new ProcessStartInfo(process, action.Argment());
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);

                tmMain.Stop();

                Application.ExitThread();
                Application.Exit();
            }
        }

        #region 读写配置文件
        /// <summary>
        /// 修改配置文件中某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <param name="value">appSettings的Value</param>
        public static void SetConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 读取配置文件某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <returns>appSettings的Value</returns>
        public static string GetConfig(string key)
        {
            string _value = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                _value = config.AppSettings.Settings[key].Value;
            }
            return _value;
        }
        #endregion

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
        Sleep, Shutdown, Logoff, Restart
    }

    public static class Extenstions
    {
        public static string Argment(this ActionType action)
        {
            switch (action)
            {
                case ActionType.Sleep:
                    return "powrprof.dll, SetSuspendState";
                case ActionType.Logoff:
                    return "-l -t 120";
                case ActionType.Restart:
                    return "-r -t 120";
                case ActionType.Shutdown:
                    return "-s -t 120";
            }
            return "";
        }
    }
}

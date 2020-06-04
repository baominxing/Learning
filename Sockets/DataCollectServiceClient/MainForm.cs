using MDCDataService;
using Net4Logger;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using MDCSingleDLL.Process;

namespace MDCDataCollectService_Winform
{
    public partial class MainForm : Form
    {
        private delegate void UpdateMessageDel(string message);
        private IProcess _process;
        private readonly ILogManager _logManager;
        private static readonly string Address = System.Configuration.ConfigurationManager.AppSettings["ListenAddress"];
        private static readonly int Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ListenPort"]);
        private const int LogMaxNumberCount = 30000;
        private static int _logNumberCount;
        private static string _filterString;

        public MainForm()
        {
            InitializeComponent();
            _logManager = CustomLogManager.GetInstance();
            ((CustomLogManager)_logManager).LogChangedEvent += MainForm_LogChangedEvent;
            StartCollectService();
        }

        private void StartCollectService()
        {
            if (_process != null)
            {
                MessageBox.Show("服务已启动");
            }
            else
            {
                _process = new ActiveProccess(CustomLogManager.GetInstance());
                _process.Run(Address, Port);
            }
        }

        private void MainForm_LogChangedEvent(string message)
        {
            try
            {
                if (rtb_LogMessage.IsDisposed) return;

                if (rtb_LogMessage.InvokeRequired)
                {
                    Invoke(new UpdateMessageDel(MainForm_LogChangedEvent), message);
                }
                else
                {
                    _logNumberCount++;

                    //记录Log到文件
                    var log = _logNumberCount.ToString().PadRight(6) + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + message + "\r\n";

                    ((CustomLogManager)_logManager).WriteLogToFile(log);

                    if (_logNumberCount >= LogMaxNumberCount)
                    {
                        _logNumberCount = 0;

                        rtb_LogMessage.Clear();
                    }
                    if (!string.IsNullOrEmpty(_filterString) && !log.Contains(_filterString)) return;

                    rtb_LogMessage.AppendText(log);

                    rtb_LogMessage.Focus();
                }
            }
            catch (Exception)
            {

            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState != FormWindowState.Minimized) return;

            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_process != null)
            {
                CloseService();
            }
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = false;
            this.Dispose();
            this.Close();
        }

        private void tsm_Exit_Click(object sender, EventArgs e)
        {
            if (_process != null)
            {
                CloseService();
            }
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = false;
            this.Dispose();
            this.Close();
        }

        private void tsm_Show_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void CloseService()
        {
            _process.End();
            _process = null;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            _filterString = tb_FilterText.Text;
        }
    }
}

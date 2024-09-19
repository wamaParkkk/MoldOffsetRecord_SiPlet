using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MoldOffsetRecord_SiPlet
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private FtpDownloader _ftpDownloader;                
        private Timer _timer;        

        MaintnanceForm m_maintnanceForm;
        ConfigureForm m_configureForm;        

        public MainForm()
        {
            InitializeComponent();            

            SubFormCreate();

            _F_USER_INIT();
            _PARAMETER_LOAD();

            _ftpDownloader = new FtpDownloader();            

            // 프로그램 시작 시 파일 다운로드, excel file에 write
            if (Define.strUserMode == "Master")
                _ftpDownloader.CheckAndDownloadFile(null, null);

            // 설정 시간 마다 실행 (분 단위)
            int iTime = Define.iTimeInterval * 60000;
            _timer = new Timer(iTime);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true; // 타이머 반복 실행
            _timer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Width = 1680;
            Height = 1050;
            Top = 0;
            Left = 0;

            MyNativeWindows myNativeWindows = new MyNativeWindows();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                MdiClient mdiClient = this.Controls[i] as MdiClient;
                if (mdiClient != null)
                {
                    myNativeWindows.ReleaseHandle();
                    myNativeWindows.AssignHandle(mdiClient.Handle);
                }
            }
            
            timerDisplay.Enabled = true;            

            SubFormShow((byte)Page.MaintnancePage);            
        }

        public class MyNativeWindows : NativeWindow
        {
            public MyNativeWindows()
            {
            }

            private const int WM_NCCALCSIZE = 0x0083;
            private const int SB_BOTH = 3;

            [DllImport("user32.dll")]
            private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_NCCALCSIZE:
                        ShowScrollBar(m.HWnd, SB_BOTH, 0);
                        break;
                }
                base.WndProc(ref m);
            }
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerDisplay.Enabled = false;
            
            Dispose();
        }

        private void SubFormCreate()
        {
            m_maintnanceForm = new MaintnanceForm();
            m_maintnanceForm.MdiParent = this;
            m_maintnanceForm.Dock = DockStyle.Fill;
            m_maintnanceForm.Show();

            m_configureForm = new ConfigureForm();
            m_configureForm.MdiParent = this;
            m_configureForm.Dock = DockStyle.Fill;
            m_configureForm.Show();
        }

        private void _F_USER_INIT()
        {
            try
            {
                // User Ini file read
                StringBuilder sbUserMode = new StringBuilder();
                GetPrivateProfileString("UserInfo", "User", "", sbUserMode, sbUserMode.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "User.ini"));
                Define.strUserMode = sbUserMode.ToString().Trim();                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 설정 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PARAMETER_LOAD()
        {
            try
            {
                // Ini file read
                StringBuilder sbTimeInterval = new StringBuilder();
                GetPrivateProfileString("Time", "Interval", "", sbTimeInterval, sbTimeInterval.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Setting.ini"));
                if (int.TryParse(sbTimeInterval.ToString().Trim(), out int iTime))
                    Define.iTimeInterval = iTime;

                m_configureForm.txtBoxTimeInterval.Text = iTime.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파라미터 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SubFormShow(byte PageNum)
        {
            try
            {
                Define.currentPage = PageNum;                
                switch (PageNum)
                {                    
                    case (byte)Page.MaintnancePage:
                        {
                            m_maintnanceForm.Activate();
                            m_maintnanceForm.BringToFront();                            
                        }
                        break;
                        
                    case (byte)Page.ConfigurePage:
                        {
                            m_configureForm.Activate();
                            m_configureForm.BringToFront();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void btnMain_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.MaintnancePage);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.ConfigurePage);
        }

        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            laDate.Text = DateTime.Today.ToShortDateString();
            laTime.Text = DateTime.Now.ToLocalTime().ToString("HH:mm:ss");            
        }
        
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Define.strUserMode == "Master")
                _ftpDownloader.CheckAndDownloadFile(sender, e);            
        }        
    }
}

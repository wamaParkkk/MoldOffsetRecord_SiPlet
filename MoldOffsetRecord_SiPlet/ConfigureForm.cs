using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MoldOffsetRecord_SiPlet
{
    public partial class ConfigureForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private FtpDownloader _ftpDownloader;

        public ConfigureForm()
        {
            InitializeComponent();

            _ftpDownloader = new FtpDownloader();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            Width = 1544;
            Height = 1011;
            Top = 0;
            Left = 0;

            if (Define.strUserMode == "Master")
                groupBox_Manual.Visible = true;
            else
                groupBox_Manual.Visible = false;
        }

        private void ConfigureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Define.strUserMode != "Master")
                {
                    MessageBox.Show($"접근 권한이 없습니다 : {Define.strUserMode}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _PARAMETER_LOAD();                    
                    return;
                }

                if (int.TryParse(txtBoxTimeInterval.Text.ToString().Trim(), out int iTime))
                {
                    WritePrivateProfileString("Time", "Interval", iTime.ToString(), string.Format("{0}{1}", Global.ConfigurePath, "Setting.ini"));
                    
                    MessageBox.Show("설정 파라미터 저장 완료", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                _PARAMETER_LOAD();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파라미터 저장 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtBoxTimeInterval.Text = iTime.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파라미터 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManualExec_Click(object sender, EventArgs e)
        {
            try
            {
                int iCnt = 0;
                progressBar.Value = iCnt;

                DateTime selectedDate = _monthCalendar_Manual.SelectionStart;
                string formattedDate = selectedDate.ToString("yyyyMMdd");

                string[] files = _ftpDownloader.GetFileList();
                progressBar.Maximum = files.Length;
                foreach (string file in files)
                {
                    if (file.Contains(formattedDate) && file.EndsWith(".csv"))
                    {
                        string localFilePath = Path.Combine(Global.localLogFilePath, file);
                        _ftpDownloader.DownloadFile(file, localFilePath);
                        _ftpDownloader.WriteCsvToExcel(localFilePath, Path.Combine(Global.localLogFilePath, "SiPlet Offset.xlsx"));
                    }

                    iCnt++;
                    progressBar.Value = iCnt;
                }

                MessageBox.Show($"[수동] CSV 데이터를 Excel에 기록 완료 : {formattedDate}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[수동] CSV 데이터를 Excel에 기록 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}

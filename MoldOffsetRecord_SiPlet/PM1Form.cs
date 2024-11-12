using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoldOffsetRecord_SiPlet
{
    public partial class PM1Form : UserControl
    {
        private FtpDownloader _ftpDownloader;
        private MaintnanceForm m_Parent;        

        public PM1Form(MaintnanceForm parent)
        {                 
            InitializeComponent();

            m_Parent = parent;

            _ftpDownloader = new FtpDownloader();

            _deviceComboBox.Items.AddRange(new string[] { "All" });
        }

        private void PM1Form_Load(object sender, EventArgs e)
        {
            Width = 1544;
            Height = 1011;
            Top = 0;
            Left = 0;

            _pointChart_Init();
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        private void _pointChart_Init()
        {            
            _pointChart.ChartAreas[0].AxisX.Interval = 1;
            _pointChart.ChartAreas[0].AxisX.Minimum = 0;
            _pointChart.ChartAreas[0].AxisX.Maximum = 17;

            _pointChart.ChartAreas[0].AxisY.Interval = 0.02;
            _pointChart.ChartAreas[0].AxisY.Minimum = -0.3;
            _pointChart.ChartAreas[0].AxisY.Maximum = 0.3;

            _pointChart.Series["X"].BorderWidth = 3;
            _pointChart.Series["X"].Color = Color.Red;

            _pointChart.Series["Y"].BorderWidth = 3;
            _pointChart.Series["Y"].Color = Color.Blue;


            // 기준선 Legend
            //_pointChart.Series["Marlin"].BorderWidth = 3;
            //_pointChart.Series["Marlin"].Color = Color.DarkOrange;

            //_pointChart.Series["Monaco"].BorderWidth = 3;
            //_pointChart.Series["Monaco"].Color = Color.Fuchsia;
        }

        public void Display()
        {
            SetDoubleBuffered(_listBox);
            SetDoubleBuffered(_dataGridView);
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            if (_deviceComboBox.SelectedItem == null)
            {                
                MessageBox.Show("Device를 선택하세요", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            

            DateTime selectedDate = _monthCalendar.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyyMMdd");            
            LoadCsvFilesFromFtp(formattedDate);

            _filterTextBox.Text = string.Empty;
            _filterTextBox.Focus();
        }
        
        private void LoadCsvFilesFromFtp(string date)
        {
            try
            {
                string ftpFolderPath = $"{_ftpDownloader._ftpAddress}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFolderPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {                    
                    var fileList = new List<string>();
                    string line;
                    bool fileFound = false;     // 파일이 발견되었는지 여부를 추적
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 날짜를 포함하는 경우에만 추가                        
                        if (line.Contains(date) && line.EndsWith(".csv"))
                        {
                            fileList.Add(line);
                            fileFound = true;   // 파일을 발견했음을 표시
                        }
                    }

                    // 파일명을 시간순으로 정렬
                    var sortedFiles = fileList.OrderBy(f => ExtractTimestamp(f)).ToList();
                    _listBox.Items.Clear();
                    foreach (var file in sortedFiles)
                    {
                        _listBox.Items.Add(file);
                    }

                    labelStripCount.Text = $"Strip : {_listBox.Items.Count.ToString()}개";

                    // 조건에 맞는 파일이 없으면 메시지 박스 표시
                    if (!fileFound)
                    {
                        labelStripCount.Text = "Strip : 0개";

                        MessageBox.Show("조건에 맞는 파일이 없습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FTP서버 파일 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime ExtractTimestamp(string fileName)
        {
            string[] parts = fileName.Split('_');
            if (parts.Length >= 2)
            {
                string timestamp = parts[1].Replace(".csv", "");
                if (DateTime.TryParseExact(timestamp, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out DateTime fileTime))
                {
                    return fileTime;
                }
            }

            return DateTime.MinValue;   // 실패 시 최소 날짜 반환
        }

        private void _clearButton_Click(object sender, EventArgs e)
        {
            if (_listBox.Items == null)
                return;

            _listBox.Items.Clear();
            labelStripCount.Text = "Strip : 0개";
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = _filterTextBox.Text.ToUpper();
            for (int i = 0; i < _listBox.Items.Count; i++)
            {
                string itemText = _listBox.Items[i].ToString().ToUpper();
                if (!itemText.Contains(filterText))
                {
                    _listBox.Items.RemoveAt(i);
                    i--; // RemoveAt으로 아이템이 제거되면 인덱스 조정 필요
                }
            }
        }

        private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listBox.SelectedItem == null) 
                return;

            string selectedFile = _listBox.SelectedItem.ToString();
            string localFilePath = Path.Combine(Global.searchFileDirectory, selectedFile);

            // 파일 이름에 "NULL"이 포함된 경우 스킵
            if (selectedFile.Contains("NULL"))
            {
                MessageBox.Show($"지원하지 않는 파일 형식입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // FTP 서버에서 로컬 디렉토리로 CSV 파일 다운로드
            DownloadCsvFileFromFtp(selectedFile, localFilePath);
            
            // CSV 파일 내용을 DataGridView에 로드
            LoadCsvDataToGrid(localFilePath);

            // Chart 그리기
            PlotChart(localFilePath);
        }

        private void DownloadCsvFileFromFtp(string fileName, string localFilePath)
        {
            try
            {
                string ftpFilePath = $"{_ftpDownloader._ftpAddress}/{fileName}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 파일 다운로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCsvDataToGrid(string filePath)
        {
            try
            {
                var dataTable = new DataTable();                
                // 열 제목 추가
                dataTable.Columns.Add("Column1", typeof(string));
                for (int i = 2; i <= 17; i++)
                {
                    dataTable.Columns.Add($"Column{i}", typeof(string));
                }

                // 첫 번째 행 : 제목
                var row1 = dataTable.NewRow();
                row1["Column1"] = "Lot#";
                row1["Column2"] = "Strip ID";
                row1["Column3"] = "Time";
                row1["Column4"] = "L/R";
                dataTable.Rows.Add(row1);
                
                // CSV 파일 내용 읽기
                string[] lines = File.ReadAllLines(filePath);                
                // 두 번째 행 : CSV 파일에서 해당 값 가져오기
                var row2 = dataTable.NewRow();
                row2["Column1"] = lines.First(l => l.StartsWith("LOT#")).Split(',')[1];
                row2["Column2"] = lines.First(l => l.StartsWith("STRIP ID")).Split(',')[1];
                row2["Column3"] = Path.GetFileNameWithoutExtension(filePath).Split('_')[1];
                row2["Column4"] = lines.First(l => l.StartsWith("Left/Right")).Split(',')[1];
                dataTable.Rows.Add(row2);
                
                // 세 번째 행 : 제목 (Point, L-1~8, R-1~8)
                var row3 = dataTable.NewRow();
                row3["Column1"] = "Point";
                for (int i = 2; i <= 9; i++)
                {
                    row3[$"Column{i}"] = "L-" + (i - 1).ToString();                    
                }

                for (int i = 10; i <= 17; i++)
                {
                    row3[$"Column{i}"] = "R-" + (i - 9).ToString();
                }

                dataTable.Rows.Add(row3);

                // 네 번째 행 : "X" 제목
                var row4 = dataTable.NewRow();
                row4["Column1"] = "X";
                dataTable.Rows.Add(row4);
                
                // 다섯 번째 행 : "Y" 제목
                var row5 = dataTable.NewRow();
                row5["Column1"] = "Y";
                dataTable.Rows.Add(row5);
                
                // CSV 파일에서 Distance X, Y값을 가져와서 추가                                
                for (int i = 7; i < lines.Length; i++)
                {
                    string[] strValue = lines[i].Split(',');                                                    
                    if ((strValue[0] == "A") || (strValue[0] == "B"))
                    {
                        //
                    }
                    else
                    {
                        //row4[$"Column{int.Parse(strValue[0]) + 1}"] = strValue[1];  // X값
                        //row5[$"Column{int.Parse(strValue[0]) + 1}"] = strValue[2];  // Y값        
                        row4[$"Column{(i - 6) + 1}"] = strValue[1];  // X값
                        row5[$"Column{(i - 6) + 1}"] = strValue[2];  // Y값        
                    }
                }

                _dataGridView.DataSource = dataTable;

                // DataGridView 열 정렬 비활성화
                foreach (DataGridViewColumn column in _dataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Width = 85;
                }
                
                // 제목 행의 배경색
                _dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                _dataGridView.Rows[2].DefaultCellStyle.BackColor = Color.Cornsilk;                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 파일 로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlotChart(string filePath)
        {
            try
            {
                // Chart clear
                _pointChart.Series["X"].Points.Clear();
                _pointChart.Series["Y"].Points.Clear();                

                string[] lines = File.ReadAllLines(filePath);
                List<(int xKey, double xValue, double yValue)> dataPoints = new List<(int, double, double)>();
                for (int i = 7; i < lines.Length; i++)
                {                    
                    string[] strValue = lines[i].Split(',');                    
                    if (strValue[0] != "A" && strValue[0] != "B")
                    {
                        int.TryParse(strValue[0], out int xKey);
                        double.TryParse(strValue[1], out double xValue);
                        double.TryParse(strValue[2], out double yValue);

                        dataPoints.Add((xKey, xValue, yValue));
                    }                                            
                }

                if (dataPoints.Count == 0)                    
                    return;

                // xKey 값을 기준으로 정렬
                var sortedDataPoints = dataPoints.OrderBy(dp => dp.xKey);
                // 정렬된 데이터 포인트를 Chart에 추가
                foreach (var dp in sortedDataPoints)
                {
                    // Chart에 X값 데이터 포인트 추가
                    DataPoint xDataPoint = new DataPoint(dp.xKey, dp.xValue)
                    {
                        Label = dp.xValue.ToString()    // X값 라벨 설정
                    };
                    _pointChart.Series["X"].Points.Add(xDataPoint);

                    // Chart에 Y값 데이터 포인트 추가
                    DataPoint yDataPoint = new DataPoint(dp.xKey, dp.yValue)
                    {
                        Label = dp.yValue.ToString()    // Y값 라벨 설정
                    };
                    _pointChart.Series["Y"].Points.Add(yDataPoint);
                }

                // 기준선 그리기
                //AddMultipleReferenceLinesToChart_Marlin();
                //AddMultipleReferenceLinesToChart_Monaco();

                // Chart를 새로 고침해서 그리기
                _pointChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chart 데이터를 그리는 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMultipleReferenceLinesToChart_Marlin()
        {
            // 차트 영역의 위치 및 크기를 가져옵니다.
            var chartArea = _pointChart.ChartAreas[0];
            var chartPosition = _pointChart.ClientRectangle;
            // y값과 라벨 텍스트 정의
            double[] yValues = { 0.2, -0.2, 0.1, -0.1 };
            string[] labels = { "0.2", "-0.2", "0.1", "-0.1" };
            for (int i = 0; i < yValues.Length; i++)
            {
                // StripLine 객체 생성
                StripLine stripLine = new StripLine
                {
                    IntervalOffset = yValues[i],                // y값에 선 추가                                        
                    BorderColor = Color.DarkOrange,             // 선 색상
                    BorderWidth = 2,                            // 선 두께
                    BorderDashStyle = ChartDashStyle.Solid,     // 선 스타일
                    Text = labels[i],                           // 라벨 텍스트 설정
                    TextLineAlignment = StringAlignment.Center  // 라벨 정렬 설정
                };
                // 차트 영역에 StripLine 추가
                chartArea.AxisY.StripLines.Add(stripLine);                
            }            
        }

        private void AddMultipleReferenceLinesToChart_Monaco()
        {
            // 차트 영역의 위치 및 크기를 가져옵니다.
            var chartArea = _pointChart.ChartAreas[0];
            var chartPosition = _pointChart.ClientRectangle;
            // y값과 라벨 텍스트 정의
            double[] yValues = { 0.125, 0.09, -0.125, -0.09 };
            string[] labels = { "0.125", "0.09", "-0.125", "-0.09" };
            for (int i = 0; i < yValues.Length; i++)
            {
                // StripLine 객체 생성
                StripLine stripLine = new StripLine
                {
                    IntervalOffset = yValues[i],                // y값에 선 추가                                        
                    BorderColor = Color.Fuchsia,                // 선 색상
                    BorderWidth = 2,                            // 선 두께
                    BorderDashStyle = ChartDashStyle.Solid,     // 선 스타일
                    Text = labels[i],                           // 라벨 텍스트 설정
                    TextLineAlignment = StringAlignment.Center  // 라벨 정렬 설정
                };
                // 차트 영역에 StripLine 추가
                chartArea.AxisY.StripLines.Add(stripLine);                
            }
        }

        private void _excelDownloadButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "저장할 위치를 선택하세요";
                saveFileDialog.FileName = "SiPlet Offset";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    string remoteFileName = Path.GetFileName(saveFileDialog.FileName);                                                                     
                    string remoteFilePath = $"{_ftpDownloader._ftpIP}{_ftpDownloader._ftpExcelFileFolder}/{remoteFileName}";
                    DownloadFile(remoteFilePath, saveFileDialog.FileName);                    
                }
            }
        }

        private void DownloadFile(string remoteFileName, string localFilePath)
        {
            try
            {                
                string ftpFilePath = $"{remoteFileName}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_ftpDownloader._ftpUser, _ftpDownloader._ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel파일 다운로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}

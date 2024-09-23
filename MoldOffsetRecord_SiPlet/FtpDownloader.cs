using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace MoldOffsetRecord_SiPlet
{
    internal class FtpDownloader
    {
        public string _ftpIP = "ftp://10.141.12.165/";
        public string _ftpAddress = "ftp://10.141.12.165/Pemtron_Mold_MES_SiPlet/";
        public string _ftpUser = "insp_pemtron";
        public string _ftpPassword = "n63Tpy9f";
        public string _ftpExcelFileFolder = "Data_Collection";
        public string _localDirectory = Global.localLogFilePath;        

        public FtpDownloader()
        {            
            //
        }

        public void CheckAndDownloadFile(object sender, EventArgs e)
        {
            try
            {
                string[] files = GetFileList();
                foreach (string file in files)
                {
                    if (ShouldDownloadFile(file))
                    {
                        string localFilePath = Path.Combine(_localDirectory, file);
                        DownloadFile(file, localFilePath);
                        WriteCsvToExcel(localFilePath, Path.Combine(_localDirectory, "SiPlet Offset.xlsx"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 확인 및 다운로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string[] GetFileList()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(_ftpUser, _ftpPassword);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string fileList = reader.ReadToEnd();
                    return fileList.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"FTP 파일 목록을 가져오는 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { };
            }
        }

        public bool ShouldDownloadFile(string fileName)
        {            
            try
            {
                // "_"로 파일명을 분리하여 날짜와 시간 부분을 추출
                string[] parts = fileName.Split('_');
                if (parts.Length < 2)
                    return false;

                string timestamp = parts[1].Replace(".csv", "");
                DateTime fileTime;
                if (DateTime.TryParseExact(timestamp, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out fileTime))
                {
                    return fileTime >= DateTime.Now.AddMinutes(-Define.iTimeInterval);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"파일 확인 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void DownloadFile(string remoteFileName, string localFilePath)
        {            
            try
            {
                // 파일이 이미 존재하면 다운로드를 건너 뜀
                if (File.Exists(localFilePath))
                {                    
                    return;
                }

                string ftpFilePath = $"{_ftpAddress}/{remoteFileName}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(_ftpUser, _ftpPassword);
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

        public void WriteCsvToExcel(string csvFilePath, string excelFilePath)
        {
            try
            {
                var csvLines = File.ReadAllLines(csvFilePath);
                // 엑셀 파일 열기
                IWorkbook workbook;
                using (FileStream file = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                // 엑셀 파일에서 마지막으로 사용된 행을 찾음
                int lastRow = sheet.LastRowNum;
                // 복사할 범위 (A1:Q6)
                int startRow = 0;   // Row 1
                int endRow = 5;     // Row 6
                int startCol = 0;   // Column A
                int endCol = 16;    // Column O
                int targetStartRow = lastRow + 1;   // 다음 빈 행부터 기록
                for (int i = startRow; i <= endRow; i++)
                {
                    IRow sourceRow = sheet.GetRow(i) ?? sheet.CreateRow(i); // 행이 없으면 새로 생성
                    IRow targetRow = sheet.CreateRow(targetStartRow + (i - startRow));
                    for (int j = startCol; j <= endCol; j++)
                    {
                        ICell sourceCell = sourceRow.GetCell(j);
                        ICell targetCell = targetRow.CreateCell(j);
                        if (sourceCell != null)
                        {
                            targetCell.SetCellValue(sourceCell.ToString());
                            // 셀 스타일 복사
                            ICellStyle newCellStyle = workbook.CreateCellStyle();
                            newCellStyle.CloneStyleFrom(sourceCell.CellStyle);
                            targetCell.CellStyle = newCellStyle;
                        }
                    }
                }

                // 추가된 위치에 데이터 기록
                IRow dataRow = sheet.GetRow(targetStartRow + 2);    // 실제 데이터는 3번째 행부터 기록

                dataRow.GetCell(0).SetCellValue(csvLines[5].Split(',')[1]); // LOT# -> A

                dataRow.GetCell(1).SetCellValue(csvLines[2].Split(',')[1]); // STRIP ID -> B

                string timeStamp = Path.GetFileNameWithoutExtension(csvFilePath).Split('_')[1];
                dataRow.GetCell(2).SetCellValue(timeStamp);                 // Time -> C

                dataRow.GetCell(3).SetCellValue(csvLines[4].Split(',')[1]); // Left/Right -> D

                IRow distanceXRow = sheet.GetRow(targetStartRow + 4);       // Distance X 기록
                IRow distanceYRow = sheet.GetRow(targetStartRow + 5);       // Distance Y 기록

                for (int i = 7; i < csvLines.Length; i++)
                {
                    string[] strValue = csvLines[i].Split(',');                    
                    if ((strValue[0] == "A") || (strValue[0] == "B"))
                    {
                        //
                    }
                    else
                    {
                        //distanceXRow.GetCell(int.Parse(strValue[0])).SetCellValue(strValue[1]);  // Distance X
                        //distanceYRow.GetCell(int.Parse(strValue[0])).SetCellValue(strValue[2]);  // Distance Y
                        distanceXRow.GetCell(i - 6).SetCellValue(strValue[1]);  // Distance X
                        distanceYRow.GetCell(i - 6).SetCellValue(strValue[2]);  // Distance Y
                    }
                }

                // 엑셀 파일 저장
                using (FileStream fileOut = new FileStream(excelFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileOut);
                }

                // 엑셀 파일을 FTP서버의 Data_Collection 폴더로 업로드
                UploadFileToFtp(excelFilePath, _ftpExcelFileFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV 데이터를 Excel에 기록 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        public void UploadFileToFtp(string localFilePath, string ftpFolder)
        {
            try
            {
                string ftpFilePath = $"{_ftpIP}{ftpFolder}/{Path.GetFileName(localFilePath)}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_ftpUser, _ftpPassword);
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FTP 서버로 파일 업로드 중 오류 발생 : {ex.Message}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

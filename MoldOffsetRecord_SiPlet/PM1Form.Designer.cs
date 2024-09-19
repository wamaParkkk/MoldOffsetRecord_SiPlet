
namespace MoldOffsetRecord_SiPlet
{
    partial class PM1Form
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series45 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series46 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series47 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series48 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._monthCalendar = new System.Windows.Forms.MonthCalendar();
            this._deviceComboBox = new System.Windows.Forms.ComboBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._clearButton = new System.Windows.Forms.Button();
            this.labelStripCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._filterTextBox = new System.Windows.Forms.TextBox();
            this._excelDownloadButton = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._pointChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pointChart)).BeginInit();
            this.SuspendLayout();
            // 
            // _monthCalendar
            // 
            this._monthCalendar.Location = new System.Drawing.Point(10, 35);
            this._monthCalendar.Name = "_monthCalendar";
            this._monthCalendar.TabIndex = 0;
            // 
            // _deviceComboBox
            // 
            this._deviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._deviceComboBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._deviceComboBox.FormattingEnabled = true;
            this._deviceComboBox.Location = new System.Drawing.Point(234, 36);
            this._deviceComboBox.Name = "_deviceComboBox";
            this._deviceComboBox.Size = new System.Drawing.Size(218, 24);
            this._deviceComboBox.TabIndex = 1;
            // 
            // _searchButton
            // 
            this._searchButton.BackColor = System.Drawing.Color.PaleGreen;
            this._searchButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._searchButton.Location = new System.Drawing.Point(242, 137);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(100, 60);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "검색";
            this._searchButton.UseVisualStyleBackColor = false;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // _listBox
            // 
            this._listBox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._listBox.FormattingEnabled = true;
            this._listBox.ItemHeight = 16;
            this._listBox.Location = new System.Drawing.Point(10, 225);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(442, 708);
            this._listBox.TabIndex = 3;
            this._listBox.SelectedIndexChanged += new System.EventHandler(this._listBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Plum;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "날짜 선택";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(234, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Device 선택";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this._clearButton);
            this.panel1.Controls.Add(this.labelStripCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._filterTextBox);
            this.panel1.Controls.Add(this._excelDownloadButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._monthCalendar);
            this.panel1.Controls.Add(this._deviceComboBox);
            this.panel1.Controls.Add(this._listBox);
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 1005);
            this.panel1.TabIndex = 7;
            // 
            // _clearButton
            // 
            this._clearButton.BackColor = System.Drawing.Color.MistyRose;
            this._clearButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clearButton.Location = new System.Drawing.Point(352, 137);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(100, 60);
            this._clearButton.TabIndex = 11;
            this._clearButton.Text = "리스트\r\nClear";
            this._clearButton.UseVisualStyleBackColor = false;
            this._clearButton.Click += new System.EventHandler(this._clearButton_Click);
            // 
            // labelStripCount
            // 
            this.labelStripCount.AutoSize = true;
            this.labelStripCount.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStripCount.ForeColor = System.Drawing.Color.Blue;
            this.labelStripCount.Location = new System.Drawing.Point(10, 205);
            this.labelStripCount.Name = "labelStripCount";
            this.labelStripCount.Size = new System.Drawing.Size(69, 17);
            this.labelStripCount.TabIndex = 10;
            this.labelStripCount.Text = "Strip : 0개";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 980);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "(필터링 후 다른 파일을 보려면 재검색)";
            // 
            // _filterTextBox
            // 
            this._filterTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this._filterTextBox.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._filterTextBox.Location = new System.Drawing.Point(10, 939);
            this._filterTextBox.Name = "_filterTextBox";
            this._filterTextBox.Size = new System.Drawing.Size(306, 33);
            this._filterTextBox.TabIndex = 8;
            this._filterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._filterTextBox.TextChanged += new System.EventHandler(this._filterTextBox_TextChanged);
            // 
            // _excelDownloadButton
            // 
            this._excelDownloadButton.BackColor = System.Drawing.Color.Aquamarine;
            this._excelDownloadButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._excelDownloadButton.Location = new System.Drawing.Point(322, 937);
            this._excelDownloadButton.Name = "_excelDownloadButton";
            this._excelDownloadButton.Size = new System.Drawing.Size(130, 60);
            this._excelDownloadButton.TabIndex = 7;
            this._excelDownloadButton.Text = "Excel 파일\r\n다운로드";
            this._excelDownloadButton.UseVisualStyleBackColor = false;
            this._excelDownloadButton.Click += new System.EventHandler(this._excelDownloadButton_Click);
            // 
            // _dataGridView
            // 
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.White;
            this._dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
            this._dataGridView.BackgroundColor = System.Drawing.Color.White;
            this._dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridView.DefaultCellStyle = dataGridViewCellStyle36;
            this._dataGridView.Location = new System.Drawing.Point(473, 3);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersWidth = 30;
            this._dataGridView.RowTemplate.Height = 23;
            this._dataGridView.Size = new System.Drawing.Size(1068, 400);
            this._dataGridView.TabIndex = 8;
            // 
            // _pointChart
            // 
            this._pointChart.BackColor = System.Drawing.Color.Cornsilk;
            chartArea12.Name = "ChartArea1";
            this._pointChart.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this._pointChart.Legends.Add(legend12);
            this._pointChart.Location = new System.Drawing.Point(473, 409);
            this._pointChart.Name = "_pointChart";
            series45.ChartArea = "ChartArea1";
            series45.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series45.Legend = "Legend1";
            series45.Name = "X";
            series46.ChartArea = "ChartArea1";
            series46.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series46.Legend = "Legend1";
            series46.Name = "Y";
            series47.ChartArea = "ChartArea1";
            series47.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series47.Legend = "Legend1";
            series47.Name = "Marlin";
            series48.ChartArea = "ChartArea1";
            series48.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series48.Legend = "Legend1";
            series48.Name = "Monaco";
            this._pointChart.Series.Add(series45);
            this._pointChart.Series.Add(series46);
            this._pointChart.Series.Add(series47);
            this._pointChart.Series.Add(series48);
            this._pointChart.Size = new System.Drawing.Size(1068, 591);
            this._pointChart.TabIndex = 9;
            this._pointChart.Text = "Point Chart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Cornsilk;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(1384, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "[Marlin] X-USL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Cornsilk;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(1384, 856);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "[Marlin] X-LSL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Cornsilk;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(1384, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "[Marlin] Y-USL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Cornsilk;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(1384, 774);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "[Marlin] Y-LSL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Cornsilk;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Fuchsia;
            this.label8.Location = new System.Drawing.Point(1384, 578);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "[Monaco] X-USL(MCO)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Cornsilk;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(1384, 610);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "[Monaco] X-USL(Pemtron)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Cornsilk;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Fuchsia;
            this.label10.Location = new System.Drawing.Point(1384, 792);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "[Monaco] X-LSL(MCO)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Cornsilk;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Fuchsia;
            this.label11.Location = new System.Drawing.Point(1384, 761);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "[Monaco] X-LSL(Pemtron)";
            // 
            // PM1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._pointChart);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "PM1Form";
            this.Size = new System.Drawing.Size(1544, 1011);
            this.Load += new System.EventHandler(this.PM1Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pointChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar _monthCalendar;
        private System.Windows.Forms.ComboBox _deviceComboBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart _pointChart;
        private System.Windows.Forms.Button _excelDownloadButton;
        private System.Windows.Forms.TextBox _filterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStripCount;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

namespace MoldOffsetRecord_SiPlet
{
    partial class ConfigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureForm));
            this.groupBox_Auto = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBoxTimeInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnManualExec = new System.Windows.Forms.Button();
            this.groupBox_Manual = new System.Windows.Forms.GroupBox();
            this._monthCalendar_Manual = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox_Auto.SuspendLayout();
            this.groupBox_Manual.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Auto
            // 
            this.groupBox_Auto.Controls.Add(this.label1);
            this.groupBox_Auto.Controls.Add(this.btnSave);
            this.groupBox_Auto.Controls.Add(this.txtBoxTimeInterval);
            this.groupBox_Auto.Controls.Add(this.label3);
            this.groupBox_Auto.Controls.Add(this.label5);
            this.groupBox_Auto.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Auto.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_Auto.Location = new System.Drawing.Point(585, 250);
            this.groupBox_Auto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Auto.Name = "groupBox_Auto";
            this.groupBox_Auto.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Auto.Size = new System.Drawing.Size(388, 168);
            this.groupBox_Auto.TabIndex = 13;
            this.groupBox_Auto.TabStop = false;
            this.groupBox_Auto.Text = "[ 자동 MES 파일 취합 > Excel ]";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(246, 105);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 51);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "   저장";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.png");
            this.imageList1.Images.SetKeyName(1, "Excel.png");
            // 
            // txtBoxTimeInterval
            // 
            this.txtBoxTimeInterval.BackColor = System.Drawing.Color.White;
            this.txtBoxTimeInterval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBoxTimeInterval.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTimeInterval.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxTimeInterval.Location = new System.Drawing.Point(130, 48);
            this.txtBoxTimeInterval.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBoxTimeInterval.Name = "txtBoxTimeInterval";
            this.txtBoxTimeInterval.Size = new System.Drawing.Size(186, 30);
            this.txtBoxTimeInterval.TabIndex = 30;
            this.txtBoxTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(27, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "시간 간격";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(326, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "min";
            // 
            // btnManualExec
            // 
            this.btnManualExec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManualExec.ImageIndex = 1;
            this.btnManualExec.ImageList = this.imageList1;
            this.btnManualExec.Location = new System.Drawing.Point(246, 152);
            this.btnManualExec.Name = "btnManualExec";
            this.btnManualExec.Size = new System.Drawing.Size(126, 51);
            this.btnManualExec.TabIndex = 14;
            this.btnManualExec.Text = "   실행";
            this.btnManualExec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManualExec.UseVisualStyleBackColor = true;
            this.btnManualExec.Click += new System.EventHandler(this.btnManualExec_Click);
            // 
            // groupBox_Manual
            // 
            this.groupBox_Manual.Controls.Add(this.progressBar);
            this.groupBox_Manual.Controls.Add(this._monthCalendar_Manual);
            this.groupBox_Manual.Controls.Add(this.btnManualExec);
            this.groupBox_Manual.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Manual.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_Manual.Location = new System.Drawing.Point(585, 430);
            this.groupBox_Manual.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Manual.Name = "groupBox_Manual";
            this.groupBox_Manual.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Manual.Size = new System.Drawing.Size(388, 220);
            this.groupBox_Manual.TabIndex = 15;
            this.groupBox_Manual.TabStop = false;
            this.groupBox_Manual.Text = "[ 수동 MES 파일 취합 > Excel ]";
            // 
            // _monthCalendar_Manual
            // 
            this._monthCalendar_Manual.Location = new System.Drawing.Point(14, 41);
            this._monthCalendar_Manual.Name = "_monthCalendar_Manual";
            this._monthCalendar_Manual.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "(저장 후 프로그램 재 실행 필요)";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(246, 123);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(126, 23);
            this.progressBar.TabIndex = 16;
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1528, 972);
            this.Controls.Add(this.groupBox_Manual);
            this.Controls.Add(this.groupBox_Auto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigureForm";
            this.Text = "ConfigureForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigureForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigureForm_Load);
            this.groupBox_Auto.ResumeLayout(false);
            this.groupBox_Auto.PerformLayout();
            this.groupBox_Manual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Auto;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TextBox txtBoxTimeInterval;
        private System.Windows.Forms.Button btnManualExec;
        private System.Windows.Forms.GroupBox groupBox_Manual;
        private System.Windows.Forms.MonthCalendar _monthCalendar_Manual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
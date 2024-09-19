namespace MoldOffsetRecord_SiPlet
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnMain = new System.Windows.Forms.Button();
            this.laTime = new System.Windows.Forms.Label();
            this.laDate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDisplay
            // 
            this.timerDisplay.Interval = 500;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnMain);
            this.panel1.Controls.Add(this.laTime);
            this.panel1.Controls.Add(this.laDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1544, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 1011);
            this.panel1.TabIndex = 3;
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.Navy;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.ImageIndex = 1;
            this.btnConfig.ImageList = this.imageList1;
            this.btnConfig.Location = new System.Drawing.Point(8, 131);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(103, 50);
            this.btnConfig.TabIndex = 152;
            this.btnConfig.Text = "   설정";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MainButton.png");
            this.imageList1.Images.SetKeyName(1, "Settings.png");
            // 
            // btnMain
            // 
            this.btnMain.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.Color.Navy;
            this.btnMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMain.ImageIndex = 0;
            this.btnMain.ImageList = this.imageList1;
            this.btnMain.Location = new System.Drawing.Point(8, 75);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(103, 50);
            this.btnMain.TabIndex = 151;
            this.btnMain.Text = "    Main";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // laTime
            // 
            this.laTime.AutoSize = true;
            this.laTime.BackColor = System.Drawing.Color.Transparent;
            this.laTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTime.ForeColor = System.Drawing.Color.Black;
            this.laTime.Location = new System.Drawing.Point(20, 29);
            this.laTime.Name = "laTime";
            this.laTime.Size = new System.Drawing.Size(63, 14);
            this.laTime.TabIndex = 150;
            this.laTime.Text = "00:00:00";
            // 
            // laDate
            // 
            this.laDate.AutoSize = true;
            this.laDate.BackColor = System.Drawing.Color.Transparent;
            this.laDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDate.ForeColor = System.Drawing.Color.Black;
            this.laDate.Location = new System.Drawing.Point(20, 9);
            this.laDate.Name = "laDate";
            this.laDate.Size = new System.Drawing.Size(79, 14);
            this.laDate.TabIndex = 149;
            this.laDate.Text = "0000.00.00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1011);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Mold Offset Record (SiPlet)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label laTime;
        private System.Windows.Forms.Label laDate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnConfig;
    }
}


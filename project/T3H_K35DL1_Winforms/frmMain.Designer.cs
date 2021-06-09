
namespace T3H_K35DL1_Winforms
{
    partial class frmMain
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
            this.test = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnCN = new System.Windows.Forms.Button();
            this.btnShowPage = new System.Windows.Forms.Button();
            this.btnShowPanel = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.btnBM = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.test.SuspendLayout();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Controls.Add(this.btnSinhVien);
            this.test.Controls.Add(this.btnGiangVien);
            this.test.Controls.Add(this.btnKhoa);
            this.test.Controls.Add(this.btnCN);
            this.test.Controls.Add(this.btnBM);
            this.test.Controls.Add(this.btnLop);
            this.test.Controls.Add(this.btnShowPage);
            this.test.Controls.Add(this.btnShowPanel);
            this.test.Dock = System.Windows.Forms.DockStyle.Left;
            this.test.Location = new System.Drawing.Point(0, 0);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(200, 542);
            this.test.TabIndex = 0;
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.AutoSize = true;
            this.btnSinhVien.Location = new System.Drawing.Point(3, 3);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(160, 27);
            this.btnSinhVien.TabIndex = 0;
            this.btnSinhVien.Text = "Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.AutoSize = true;
            this.btnGiangVien.Location = new System.Drawing.Point(3, 36);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Size = new System.Drawing.Size(160, 27);
            this.btnGiangVien.TabIndex = 3;
            this.btnGiangVien.Text = "Giảng viên";
            this.btnGiangVien.UseVisualStyleBackColor = true;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.AutoSize = true;
            this.btnKhoa.Location = new System.Drawing.Point(3, 69);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(160, 27);
            this.btnKhoa.TabIndex = 4;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // btnCN
            // 
            this.btnCN.AutoSize = true;
            this.btnCN.Location = new System.Drawing.Point(3, 102);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(160, 27);
            this.btnCN.TabIndex = 5;
            this.btnCN.Text = "Chuyên ngành";
            this.btnCN.UseVisualStyleBackColor = true;
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // btnShowPage
            // 
            this.btnShowPage.AutoSize = true;
            this.btnShowPage.Location = new System.Drawing.Point(3, 201);
            this.btnShowPage.Name = "btnShowPage";
            this.btnShowPage.Size = new System.Drawing.Size(160, 27);
            this.btnShowPage.TabIndex = 2;
            this.btnShowPage.Text = "Show UcPage";
            this.btnShowPage.UseVisualStyleBackColor = true;
            this.btnShowPage.Click += new System.EventHandler(this.btnShowPage_Click);
            // 
            // btnShowPanel
            // 
            this.btnShowPanel.AutoSize = true;
            this.btnShowPanel.Location = new System.Drawing.Point(3, 234);
            this.btnShowPanel.Name = "btnShowPanel";
            this.btnShowPanel.Size = new System.Drawing.Size(160, 27);
            this.btnShowPanel.TabIndex = 1;
            this.btnShowPanel.Text = "Show UserControl";
            this.btnShowPanel.UseVisualStyleBackColor = true;
            this.btnShowPanel.Click += new System.EventHandler(this.btnShowPanel_Click);
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(980, 542);
            this.pnMain.TabIndex = 1;
            // 
            // btnBM
            // 
            this.btnBM.AutoSize = true;
            this.btnBM.Location = new System.Drawing.Point(3, 135);
            this.btnBM.Name = "btnBM";
            this.btnBM.Size = new System.Drawing.Size(160, 27);
            this.btnBM.TabIndex = 6;
            this.btnBM.Text = "Bộ môn";
            this.btnBM.UseVisualStyleBackColor = true;
            this.btnBM.Click += new System.EventHandler(this.btnBM_Click);
            // 
            // btnLop
            // 
            this.btnLop.AutoSize = true;
            this.btnLop.Location = new System.Drawing.Point(3, 168);
            this.btnLop.Name = "btnLop";
            this.btnLop.Size = new System.Drawing.Size(160, 27);
            this.btnLop.TabIndex = 7;
            this.btnLop.Text = "Lớp";
            this.btnLop.UseVisualStyleBackColor = true;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 542);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.test);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.test.ResumeLayout(false);
            this.test.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel test;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnShowPanel;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnShowPage;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnCN;
        private System.Windows.Forms.Button btnBM;
        private System.Windows.Forms.Button btnLop;
    }
}


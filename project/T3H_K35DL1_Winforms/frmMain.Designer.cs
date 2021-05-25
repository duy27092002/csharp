
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
            this.btnShowPanel = new System.Windows.Forms.Button();
            this.btnShowPage = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.test.SuspendLayout();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Controls.Add(this.btnSinhVien);
            this.test.Controls.Add(this.btnShowPanel);
            this.test.Controls.Add(this.btnShowPage);
            this.test.Dock = System.Windows.Forms.DockStyle.Left;
            this.test.Location = new System.Drawing.Point(0, 0);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(200, 542);
            this.test.TabIndex = 0;
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Location = new System.Drawing.Point(3, 3);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(160, 23);
            this.btnSinhVien.TabIndex = 0;
            this.btnSinhVien.Text = "Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // btnShowPanel
            // 
            this.btnShowPanel.Location = new System.Drawing.Point(3, 32);
            this.btnShowPanel.Name = "btnShowPanel";
            this.btnShowPanel.Size = new System.Drawing.Size(160, 23);
            this.btnShowPanel.TabIndex = 1;
            this.btnShowPanel.Text = "Show UserControl";
            this.btnShowPanel.UseVisualStyleBackColor = true;
            this.btnShowPanel.Click += new System.EventHandler(this.btnShowPanel_Click);
            // 
            // btnShowPage
            // 
            this.btnShowPage.Location = new System.Drawing.Point(3, 61);
            this.btnShowPage.Name = "btnShowPage";
            this.btnShowPage.Size = new System.Drawing.Size(160, 23);
            this.btnShowPage.TabIndex = 2;
            this.btnShowPage.Text = "Show UcPage";
            this.btnShowPage.UseVisualStyleBackColor = true;
            this.btnShowPage.Click += new System.EventHandler(this.btnShowPage_Click);
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(980, 542);
            this.pnMain.TabIndex = 1;
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
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.test.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel test;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnShowPanel;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnShowPage;
    }
}


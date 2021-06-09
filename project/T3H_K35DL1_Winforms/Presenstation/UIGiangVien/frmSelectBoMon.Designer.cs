
namespace T3H_K35DL1_Winforms.Presenstation.UIGiangVien
{
    partial class frmSelectBoMon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonBM = new System.Windows.Forms.Button();
            this.cbbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvBoMon = new System.Windows.Forms.DataGridView();
            this.MaBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiangViens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoMon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChonBM);
            this.panel1.Controls.Add(this.cbbChuyenNganh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbKhoa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 72);
            this.panel1.TabIndex = 0;
            // 
            // btnChonBM
            // 
            this.btnChonBM.Location = new System.Drawing.Point(1042, 13);
            this.btnChonBM.Name = "btnChonBM";
            this.btnChonBM.Size = new System.Drawing.Size(75, 44);
            this.btnChonBM.TabIndex = 1;
            this.btnChonBM.Text = "Chọn Bộ Môn";
            this.btnChonBM.UseVisualStyleBackColor = true;
            this.btnChonBM.Click += new System.EventHandler(this.btnChonBM_Click);
            // 
            // cbbChuyenNganh
            // 
            this.cbbChuyenNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChuyenNganh.FormattingEnabled = true;
            this.cbbChuyenNganh.Location = new System.Drawing.Point(673, 24);
            this.cbbChuyenNganh.Name = "cbbChuyenNganh";
            this.cbbChuyenNganh.Size = new System.Drawing.Size(291, 24);
            this.cbbChuyenNganh.TabIndex = 3;
            this.cbbChuyenNganh.SelectedIndexChanged += new System.EventHandler(this.cbbChuyenNganh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lựa chọn chuyên ngành:";
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.FormattingEnabled = true;
            this.cbbKhoa.Location = new System.Drawing.Point(142, 24);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(291, 24);
            this.cbbKhoa.TabIndex = 1;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbbKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lựa chọn khoa:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBoMon);
            this.groupBox1.Location = new System.Drawing.Point(13, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 410);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các bộ môn";
            // 
            // dgvBoMon
            // 
            this.dgvBoMon.AllowUserToAddRows = false;
            this.dgvBoMon.AllowUserToDeleteRows = false;
            this.dgvBoMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBM,
            this.TenBM,
            this.Khoa,
            this.GiangViens});
            this.dgvBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoMon.Location = new System.Drawing.Point(3, 18);
            this.dgvBoMon.Name = "dgvBoMon";
            this.dgvBoMon.ReadOnly = true;
            this.dgvBoMon.RowHeadersWidth = 51;
            this.dgvBoMon.RowTemplate.Height = 24;
            this.dgvBoMon.Size = new System.Drawing.Size(1138, 389);
            this.dgvBoMon.TabIndex = 0;
            // 
            // MaBM
            // 
            this.MaBM.DataPropertyName = "MaBM";
            this.MaBM.HeaderText = "Mã Bộ Môn";
            this.MaBM.MinimumWidth = 6;
            this.MaBM.Name = "MaBM";
            this.MaBM.ReadOnly = true;
            // 
            // TenBM
            // 
            this.TenBM.DataPropertyName = "TenBM";
            this.TenBM.HeaderText = "Tên Bộ Môn";
            this.TenBM.MinimumWidth = 6;
            this.TenBM.Name = "TenBM";
            this.TenBM.ReadOnly = true;
            // 
            // Khoa
            // 
            this.Khoa.DataPropertyName = "Khoa";
            this.Khoa.HeaderText = "Khoa";
            this.Khoa.MinimumWidth = 6;
            this.Khoa.Name = "Khoa";
            this.Khoa.ReadOnly = true;
            this.Khoa.Visible = false;
            // 
            // GiangViens
            // 
            this.GiangViens.DataPropertyName = "GiangViens";
            this.GiangViens.HeaderText = "Giảng viên";
            this.GiangViens.MinimumWidth = 6;
            this.GiangViens.Name = "GiangViens";
            this.GiangViens.ReadOnly = true;
            this.GiangViens.Visible = false;
            // 
            // frmSelectBoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectBoMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Bộ Môn";
            this.Load += new System.EventHandler(this.frmSelectBoMon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBoMon;
        private System.Windows.Forms.ComboBox cbbChuyenNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbKhoa;
        private System.Windows.Forms.Button btnChonBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiangViens;
    }
}
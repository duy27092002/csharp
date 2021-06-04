
namespace T3H_K35DL1_Winforms.Presenstation.UISinhVien
{
    partial class frmSelectMaLop
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChosseClass = new System.Windows.Forms.Button();
            this.cbbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnChosseClass);
            this.panel1.Controls.Add(this.cbbChuyenNganh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbKhoa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 101);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1009, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1, 1);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnChosseClass
            // 
            this.btnChosseClass.Location = new System.Drawing.Point(552, 15);
            this.btnChosseClass.Name = "btnChosseClass";
            this.btnChosseClass.Size = new System.Drawing.Size(75, 63);
            this.btnChosseClass.TabIndex = 4;
            this.btnChosseClass.Text = "Chọn lớp";
            this.btnChosseClass.UseVisualStyleBackColor = true;
            this.btnChosseClass.Click += new System.EventHandler(this.btnChosseClass_Click);
            // 
            // cbbChuyenNganh
            // 
            this.cbbChuyenNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChuyenNganh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbChuyenNganh.FormattingEnabled = true;
            this.cbbChuyenNganh.Location = new System.Drawing.Point(215, 54);
            this.cbbChuyenNganh.Name = "cbbChuyenNganh";
            this.cbbChuyenNganh.Size = new System.Drawing.Size(284, 24);
            this.cbbChuyenNganh.TabIndex = 3;
            this.cbbChuyenNganh.SelectedIndexChanged += new System.EventHandler(this.cbbChuyenNganh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lựa chọn chuyên ngành:";
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbKhoa.FormattingEnabled = true;
            this.cbbKhoa.Location = new System.Drawing.Point(215, 15);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(284, 24);
            this.cbbKhoa.TabIndex = 1;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbbKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lựa chọn khoa:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLop);
            this.groupBox1.Location = new System.Drawing.Point(13, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1112, 362);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các lớp trong chuyên nghành";
            // 
            // dgvLop
            // 
            this.dgvLop.AllowUserToAddRows = false;
            this.dgvLop.AllowUserToDeleteRows = false;
            this.dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.TenLop});
            this.dgvLop.Location = new System.Drawing.Point(7, 22);
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.ReadOnly = true;
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.RowTemplate.Height = 24;
            this.dgvLop.Size = new System.Drawing.Size(1099, 334);
            this.dgvLop.TabIndex = 0;
            // 
            // btnClose1
            // 
            this.btnClose1.Location = new System.Drawing.Point(1009, 15);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(1, 1);
            this.btnClose1.TabIndex = 6;
            this.btnClose1.Text = "Thoát";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.ReadOnly = true;
            // 
            // TenLop
            // 
            this.TenLop.DataPropertyName = "TenLop";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.ReadOnly = true;
            // 
            // frmSelectMaLop
            // 
            this.AcceptButton = this.btnChosseClass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectMaLop";
            this.Text = "frmSelectMaLop";
            this.Load += new System.EventHandler(this.frmSelectMaLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChosseClass;
        private System.Windows.Forms.ComboBox cbbChuyenNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
    }
}
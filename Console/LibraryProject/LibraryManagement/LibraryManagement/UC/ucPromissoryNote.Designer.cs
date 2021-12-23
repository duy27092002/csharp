
namespace LibraryManagement.UC
{
    partial class ucPromissoryNote
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCreate = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPromissoryNote = new System.Windows.Forms.DataGridView();
            this.PNId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUId = new System.Windows.Forms.TextBox();
            this.txtPNId = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnLastPagePN = new System.Windows.Forms.Button();
            this.btnFirstPagePN = new System.Windows.Forms.Button();
            this.btnNextPagePN = new System.Windows.Forms.Button();
            this.btnPreviousPagePN = new System.Windows.Forms.Button();
            this.btnDeletePN = new System.Windows.Forms.Button();
            this.btnSavePN = new System.Windows.Forms.Button();
            this.btnAddPN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbRId = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPNDetails = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpBorrowedDate = new System.Windows.Forms.DateTimePicker();
            this.cbbBId = new System.Windows.Forms.ComboBox();
            this.cbbPNId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLastPagePNDetails = new System.Windows.Forms.Button();
            this.btnFirstPagePNDetails = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNextPagePNDetails = new System.Windows.Forms.Button();
            this.btnPreviousPagePNDetails = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDeletePNDetails = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSavePNDetails = new System.Windows.Forms.Button();
            this.btnAddPNDetails = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.pndid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpCreate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromissoryNote)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tbDetails.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPNDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 61);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ MƯỢN-TRẢ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 633);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCreate);
            this.tabControl1.Controls.Add(this.tbDetails);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 633);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCreate
            // 
            this.tpCreate.Controls.Add(this.groupBox2);
            this.tpCreate.Controls.Add(this.groupBox1);
            this.tpCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCreate.Location = new System.Drawing.Point(4, 25);
            this.tpCreate.Name = "tpCreate";
            this.tpCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreate.Size = new System.Drawing.Size(1023, 604);
            this.tpCreate.TabIndex = 0;
            this.tpCreate.Text = "Tạo phiếu mới";
            this.tpCreate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPromissoryNote);
            this.groupBox2.Location = new System.Drawing.Point(6, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1011, 387);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvPromissoryNote
            // 
            this.dgvPromissoryNote.AllowUserToAddRows = false;
            this.dgvPromissoryNote.AllowUserToDeleteRows = false;
            this.dgvPromissoryNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPromissoryNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromissoryNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromissoryNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PNId,
            this.RId,
            this.UId});
            this.dgvPromissoryNote.Location = new System.Drawing.Point(22, 26);
            this.dgvPromissoryNote.Name = "dgvPromissoryNote";
            this.dgvPromissoryNote.ReadOnly = true;
            this.dgvPromissoryNote.RowHeadersWidth = 51;
            this.dgvPromissoryNote.RowTemplate.Height = 24;
            this.dgvPromissoryNote.Size = new System.Drawing.Size(974, 268);
            this.dgvPromissoryNote.TabIndex = 0;
            this.dgvPromissoryNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromissoryNote_CellClick);
            // 
            // PNId
            // 
            this.PNId.DataPropertyName = "PNId";
            this.PNId.HeaderText = "Mã phiếu";
            this.PNId.MinimumWidth = 6;
            this.PNId.Name = "PNId";
            this.PNId.ReadOnly = true;
            // 
            // RId
            // 
            this.RId.DataPropertyName = "RId";
            this.RId.HeaderText = "Mã đọc giả";
            this.RId.MinimumWidth = 6;
            this.RId.Name = "RId";
            this.RId.ReadOnly = true;
            // 
            // UId
            // 
            this.UId.DataPropertyName = "UId";
            this.UId.HeaderText = "Mã nhân viên";
            this.UId.MinimumWidth = 6;
            this.UId.Name = "UId";
            this.UId.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUId);
            this.groupBox1.Controls.Add(this.txtPNId);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnLastPagePN);
            this.groupBox1.Controls.Add(this.btnFirstPagePN);
            this.groupBox1.Controls.Add(this.btnNextPagePN);
            this.groupBox1.Controls.Add(this.btnPreviousPagePN);
            this.groupBox1.Controls.Add(this.btnDeletePN);
            this.groupBox1.Controls.Add(this.btnSavePN);
            this.groupBox1.Controls.Add(this.btnAddPN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbRId);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1011, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu mới";
            // 
            // txtUId
            // 
            this.txtUId.Enabled = false;
            this.txtUId.Location = new System.Drawing.Point(360, 73);
            this.txtUId.Name = "txtUId";
            this.txtUId.Size = new System.Drawing.Size(277, 26);
            this.txtUId.TabIndex = 78;
            // 
            // txtPNId
            // 
            this.txtPNId.Enabled = false;
            this.txtPNId.Location = new System.Drawing.Point(709, 73);
            this.txtPNId.Name = "txtPNId";
            this.txtPNId.Size = new System.Drawing.Size(277, 26);
            this.txtPNId.TabIndex = 77;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(705, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 20);
            this.label17.TabIndex = 75;
            this.label17.Text = "Mã phiếu:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(833, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 20);
            this.label18.TabIndex = 76;
            this.label18.Text = "(*)";
            // 
            // btnLastPagePN
            // 
            this.btnLastPagePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPagePN.Location = new System.Drawing.Point(908, 124);
            this.btnLastPagePN.Name = "btnLastPagePN";
            this.btnLastPagePN.Size = new System.Drawing.Size(75, 43);
            this.btnLastPagePN.TabIndex = 74;
            this.btnLastPagePN.Text = ">>";
            this.btnLastPagePN.UseVisualStyleBackColor = true;
            this.btnLastPagePN.Click += new System.EventHandler(this.btnLastPagePN_Click);
            // 
            // btnFirstPagePN
            // 
            this.btnFirstPagePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPagePN.Location = new System.Drawing.Point(665, 124);
            this.btnFirstPagePN.Name = "btnFirstPagePN";
            this.btnFirstPagePN.Size = new System.Drawing.Size(75, 43);
            this.btnFirstPagePN.TabIndex = 73;
            this.btnFirstPagePN.Text = "<<";
            this.btnFirstPagePN.UseVisualStyleBackColor = true;
            this.btnFirstPagePN.Click += new System.EventHandler(this.btnFirstPagePN_Click);
            // 
            // btnNextPagePN
            // 
            this.btnNextPagePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPagePN.Location = new System.Drawing.Point(827, 124);
            this.btnNextPagePN.Name = "btnNextPagePN";
            this.btnNextPagePN.Size = new System.Drawing.Size(75, 43);
            this.btnNextPagePN.TabIndex = 72;
            this.btnNextPagePN.Text = ">";
            this.btnNextPagePN.UseVisualStyleBackColor = true;
            this.btnNextPagePN.Click += new System.EventHandler(this.btnNextPagePN_Click);
            // 
            // btnPreviousPagePN
            // 
            this.btnPreviousPagePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPagePN.Location = new System.Drawing.Point(746, 124);
            this.btnPreviousPagePN.Name = "btnPreviousPagePN";
            this.btnPreviousPagePN.Size = new System.Drawing.Size(75, 43);
            this.btnPreviousPagePN.TabIndex = 71;
            this.btnPreviousPagePN.Text = "<";
            this.btnPreviousPagePN.UseVisualStyleBackColor = true;
            this.btnPreviousPagePN.Click += new System.EventHandler(this.btnPreviousPagePN_Click);
            // 
            // btnDeletePN
            // 
            this.btnDeletePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePN.Location = new System.Drawing.Point(224, 124);
            this.btnDeletePN.Name = "btnDeletePN";
            this.btnDeletePN.Size = new System.Drawing.Size(75, 43);
            this.btnDeletePN.TabIndex = 70;
            this.btnDeletePN.Text = "Xóa";
            this.btnDeletePN.UseVisualStyleBackColor = true;
            this.btnDeletePN.Click += new System.EventHandler(this.btnDeletePN_Click);
            // 
            // btnSavePN
            // 
            this.btnSavePN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePN.Location = new System.Drawing.Point(125, 124);
            this.btnSavePN.Name = "btnSavePN";
            this.btnSavePN.Size = new System.Drawing.Size(75, 43);
            this.btnSavePN.TabIndex = 69;
            this.btnSavePN.Text = "Sửa";
            this.btnSavePN.UseVisualStyleBackColor = true;
            this.btnSavePN.Click += new System.EventHandler(this.btnSavePN_Click);
            // 
            // btnAddPN
            // 
            this.btnAddPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPN.Location = new System.Drawing.Point(22, 124);
            this.btnAddPN.Name = "btnAddPN";
            this.btnAddPN.Size = new System.Drawing.Size(75, 43);
            this.btnAddPN.TabIndex = 68;
            this.btnAddPN.Text = "Thêm";
            this.btnAddPN.UseVisualStyleBackColor = true;
            this.btnAddPN.Click += new System.EventHandler(this.btnAddPN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Mã nhân viên tạo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(541, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "(*)";
            // 
            // cbbRId
            // 
            this.cbbRId.FormattingEnabled = true;
            this.cbbRId.Items.AddRange(new object[] {
            "Đang làm việc",
            "Đã nghỉ việc"});
            this.cbbRId.Location = new System.Drawing.Point(22, 73);
            this.cbbRId.Name = "cbbRId";
            this.cbbRId.Size = new System.Drawing.Size(277, 28);
            this.cbbRId.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "Mã đọc giả:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(146, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = "(*)";
            // 
            // tbDetails
            // 
            this.tbDetails.Controls.Add(this.groupBox4);
            this.tbDetails.Controls.Add(this.groupBox3);
            this.tbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetails.Location = new System.Drawing.Point(4, 25);
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tbDetails.Size = new System.Drawing.Size(1023, 604);
            this.tbDetails.TabIndex = 1;
            this.tbDetails.Text = "Chi tiết phiếu";
            this.tbDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvPNDetails);
            this.groupBox4.Location = new System.Drawing.Point(7, 251);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1010, 335);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách";
            // 
            // dgvPNDetails
            // 
            this.dgvPNDetails.AllowUserToAddRows = false;
            this.dgvPNDetails.AllowUserToDeleteRows = false;
            this.dgvPNDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPNDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPNDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPNDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pndid,
            this.BId,
            this.BorrowedDate,
            this.PayDate,
            this.Cost,
            this.Status});
            this.dgvPNDetails.Location = new System.Drawing.Point(17, 26);
            this.dgvPNDetails.Name = "dgvPNDetails";
            this.dgvPNDetails.ReadOnly = true;
            this.dgvPNDetails.RowHeadersWidth = 51;
            this.dgvPNDetails.RowTemplate.Height = 24;
            this.dgvPNDetails.Size = new System.Drawing.Size(974, 268);
            this.dgvPNDetails.TabIndex = 0;
            this.dgvPNDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPNDetails_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpPayDate);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.dtpBorrowedDate);
            this.groupBox3.Controls.Add(this.cbbBId);
            this.groupBox3.Controls.Add(this.cbbPNId);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnLastPagePNDetails);
            this.groupBox3.Controls.Add(this.btnFirstPagePNDetails);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnNextPagePNDetails);
            this.groupBox3.Controls.Add(this.btnPreviousPagePNDetails);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbbStatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnDeletePNDetails);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btnSavePNDetails);
            this.groupBox3.Controls.Add(this.btnAddPNDetails);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtCost);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1010, 238);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết";
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPayDate.Location = new System.Drawing.Point(361, 142);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(277, 26);
            this.dtpPayDate.TabIndex = 94;
            this.dtpPayDate.ValueChanged += new System.EventHandler(this.dtpPayDate_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(502, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 20);
            this.label15.TabIndex = 93;
            this.label15.Text = "(*)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(357, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.TabIndex = 92;
            this.label16.Text = "Ngày trả:";
            // 
            // dtpBorrowedDate
            // 
            this.dtpBorrowedDate.Enabled = false;
            this.dtpBorrowedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowedDate.Location = new System.Drawing.Point(17, 142);
            this.dtpBorrowedDate.Name = "dtpBorrowedDate";
            this.dtpBorrowedDate.Size = new System.Drawing.Size(277, 26);
            this.dtpBorrowedDate.TabIndex = 91;
            // 
            // cbbBId
            // 
            this.cbbBId.FormattingEnabled = true;
            this.cbbBId.Items.AddRange(new object[] {
            "Đang làm việc",
            "Đã nghỉ việc"});
            this.cbbBId.Location = new System.Drawing.Point(361, 63);
            this.cbbBId.Name = "cbbBId";
            this.cbbBId.Size = new System.Drawing.Size(277, 28);
            this.cbbBId.TabIndex = 90;
            // 
            // cbbPNId
            // 
            this.cbbPNId.FormattingEnabled = true;
            this.cbbPNId.Items.AddRange(new object[] {
            "Đang làm việc",
            "Đã nghỉ việc"});
            this.cbbPNId.Location = new System.Drawing.Point(17, 63);
            this.cbbPNId.Name = "cbbPNId";
            this.cbbPNId.Size = new System.Drawing.Size(277, 28);
            this.cbbPNId.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "Mã phiếu:";
            // 
            // btnLastPagePNDetails
            // 
            this.btnLastPagePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPagePNDetails.Location = new System.Drawing.Point(923, 192);
            this.btnLastPagePNDetails.Name = "btnLastPagePNDetails";
            this.btnLastPagePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnLastPagePNDetails.TabIndex = 88;
            this.btnLastPagePNDetails.Text = ">>";
            this.btnLastPagePNDetails.UseVisualStyleBackColor = true;
            this.btnLastPagePNDetails.Click += new System.EventHandler(this.btnLastPagePNDetails_Click);
            // 
            // btnFirstPagePNDetails
            // 
            this.btnFirstPagePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPagePNDetails.Location = new System.Drawing.Point(680, 192);
            this.btnFirstPagePNDetails.Name = "btnFirstPagePNDetails";
            this.btnFirstPagePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnFirstPagePNDetails.TabIndex = 87;
            this.btnFirstPagePNDetails.Text = "<<";
            this.btnFirstPagePNDetails.UseVisualStyleBackColor = true;
            this.btnFirstPagePNDetails.Click += new System.EventHandler(this.btnFirstPagePNDetails_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(119, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 20);
            this.label8.TabIndex = 70;
            this.label8.Text = "(*)";
            // 
            // btnNextPagePNDetails
            // 
            this.btnNextPagePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPagePNDetails.Location = new System.Drawing.Point(842, 192);
            this.btnNextPagePNDetails.Name = "btnNextPagePNDetails";
            this.btnNextPagePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnNextPagePNDetails.TabIndex = 86;
            this.btnNextPagePNDetails.Text = ">";
            this.btnNextPagePNDetails.UseVisualStyleBackColor = true;
            this.btnNextPagePNDetails.Click += new System.EventHandler(this.btnNextPagePNDetails_Click);
            // 
            // btnPreviousPagePNDetails
            // 
            this.btnPreviousPagePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPagePNDetails.Location = new System.Drawing.Point(761, 192);
            this.btnPreviousPagePNDetails.Name = "btnPreviousPagePNDetails";
            this.btnPreviousPagePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnPreviousPagePNDetails.TabIndex = 85;
            this.btnPreviousPagePNDetails.Text = "<";
            this.btnPreviousPagePNDetails.UseVisualStyleBackColor = true;
            this.btnPreviousPagePNDetails.Click += new System.EventHandler(this.btnPreviousPagePNDetails_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(498, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "(*)";
            // 
            // cbbStatus
            // 
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Items.AddRange(new object[] {
            "Đang mượn",
            "Đã trả",
            "Trễ hạn"});
            this.cbbStatus.Location = new System.Drawing.Point(714, 140);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(277, 28);
            this.cbbStatus.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(357, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 71;
            this.label6.Text = "Mã sách:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(710, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "Trạng thái:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(827, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 83;
            this.label9.Text = "(*)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(166, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 20);
            this.label10.TabIndex = 76;
            this.label10.Text = "(*)";
            // 
            // btnDeletePNDetails
            // 
            this.btnDeletePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePNDetails.Location = new System.Drawing.Point(219, 192);
            this.btnDeletePNDetails.Name = "btnDeletePNDetails";
            this.btnDeletePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnDeletePNDetails.TabIndex = 81;
            this.btnDeletePNDetails.Text = "Xóa";
            this.btnDeletePNDetails.UseVisualStyleBackColor = true;
            this.btnDeletePNDetails.Click += new System.EventHandler(this.btnDeletePNDetails_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 20);
            this.label13.TabIndex = 74;
            this.label13.Text = "Ngày mượn:";
            // 
            // btnSavePNDetails
            // 
            this.btnSavePNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePNDetails.Location = new System.Drawing.Point(120, 192);
            this.btnSavePNDetails.Name = "btnSavePNDetails";
            this.btnSavePNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnSavePNDetails.TabIndex = 80;
            this.btnSavePNDetails.Text = "Sửa";
            this.btnSavePNDetails.UseVisualStyleBackColor = true;
            this.btnSavePNDetails.Click += new System.EventHandler(this.btnSavePNDetails_Click);
            // 
            // btnAddPNDetails
            // 
            this.btnAddPNDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPNDetails.Location = new System.Drawing.Point(17, 192);
            this.btnAddPNDetails.Name = "btnAddPNDetails";
            this.btnAddPNDetails.Size = new System.Drawing.Size(75, 43);
            this.btnAddPNDetails.TabIndex = 79;
            this.btnAddPNDetails.Text = "Thêm";
            this.btnAddPNDetails.UseVisualStyleBackColor = true;
            this.btnAddPNDetails.Click += new System.EventHandler(this.btnAddPNDetails_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(710, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 77;
            this.label14.Text = "Chi phí:";
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(714, 63);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(277, 26);
            this.txtCost.TabIndex = 78;
            // 
            // pndid
            // 
            this.pndid.DataPropertyName = "pndid";
            this.pndid.HeaderText = "Mã phiếu";
            this.pndid.MinimumWidth = 6;
            this.pndid.Name = "pndid";
            this.pndid.ReadOnly = true;
            // 
            // BId
            // 
            this.BId.DataPropertyName = "BId";
            this.BId.HeaderText = "Mã sách";
            this.BId.MinimumWidth = 6;
            this.BId.Name = "BId";
            this.BId.ReadOnly = true;
            // 
            // BorrowedDate
            // 
            this.BorrowedDate.DataPropertyName = "BorrowedDate";
            this.BorrowedDate.HeaderText = "Ngày mượn";
            this.BorrowedDate.MinimumWidth = 6;
            this.BorrowedDate.Name = "BorrowedDate";
            this.BorrowedDate.ReadOnly = true;
            // 
            // PayDate
            // 
            this.PayDate.DataPropertyName = "PayDate";
            this.PayDate.HeaderText = "Ngày trả";
            this.PayDate.MinimumWidth = 6;
            this.PayDate.Name = "PayDate";
            this.PayDate.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Chi phí";
            this.Cost.MinimumWidth = 6;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng thái";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // ucPromissoryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPromissoryNote";
            this.Size = new System.Drawing.Size(1031, 694);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpCreate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromissoryNote)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbDetails.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPNDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tbDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbRId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLastPagePN;
        private System.Windows.Forms.Button btnFirstPagePN;
        private System.Windows.Forms.Button btnNextPagePN;
        private System.Windows.Forms.Button btnPreviousPagePN;
        private System.Windows.Forms.Button btnDeletePN;
        private System.Windows.Forms.Button btnSavePN;
        private System.Windows.Forms.Button btnAddPN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPromissoryNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn PNId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLastPagePNDetails;
        private System.Windows.Forms.Button btnFirstPagePNDetails;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNextPagePNDetails;
        private System.Windows.Forms.Button btnPreviousPagePNDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDeletePNDetails;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSavePNDetails;
        private System.Windows.Forms.Button btnAddPNDetails;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.ComboBox cbbPNId;
        private System.Windows.Forms.ComboBox cbbBId;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpBorrowedDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvPNDetails;
        private System.Windows.Forms.TextBox txtUId;
        private System.Windows.Forms.TextBox txtPNId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn pndid;
        private System.Windows.Forms.DataGridViewTextBoxColumn BId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

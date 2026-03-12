namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class QuanLySinhVienForm
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

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox();
            cboLop = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            txtQueQuan = new TextBox();
            rdNu = new RadioButton();
            rdNam = new RadioButton();
            txtTenSinhVien = new TextBox();
            txtMaSinhVien = new TextBox();
            lblLop = new Label();
            lblQueQuan = new Label();
            lblGioiTinh = new Label();
            lblNgaySinh = new Label();
            lblTenSinhVien = new Label();
            lblMaSinhVien = new Label();
            grpChucNang = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            grpDanhSach = new GroupBox();
            dgvSinhVien = new DataGridView();
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(cboLop);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(txtQueQuan);
            grpThongTin.Controls.Add(rdNu);
            grpThongTin.Controls.Add(rdNam);
            grpThongTin.Controls.Add(txtTenSinhVien);
            grpThongTin.Controls.Add(txtMaSinhVien);
            grpThongTin.Controls.Add(lblLop);
            grpThongTin.Controls.Add(lblQueQuan);
            grpThongTin.Controls.Add(lblGioiTinh);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(lblTenSinhVien);
            grpThongTin.Controls.Add(lblMaSinhVien);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1160, 250);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sinh viên";
            // 
            // cboLop
            // 
            cboLop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(150, 205);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(980, 33);
            cboLop.TabIndex = 12;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(150, 100);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(980, 31);
            dtpNgaySinh.TabIndex = 11;
            // 
            // txtQueQuan
            // 
            txtQueQuan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQueQuan.Location = new Point(150, 170);
            txtQueQuan.MaxLength = 50;
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(980, 31);
            txtQueQuan.TabIndex = 10;
            // 
            // rdNu
            // 
            rdNu.AutoSize = true;
            rdNu.Location = new Point(250, 137);
            rdNu.Name = "rdNu";
            rdNu.Size = new Size(61, 29);
            rdNu.TabIndex = 9;
            rdNu.Text = "Nữ";
            rdNu.UseVisualStyleBackColor = true;
            // 
            // rdNam
            // 
            rdNam.AutoSize = true;
            rdNam.Checked = true;
            rdNam.Location = new Point(150, 137);
            rdNam.Name = "rdNam";
            rdNam.Size = new Size(75, 29);
            rdNam.TabIndex = 8;
            rdNam.TabStop = true;
            rdNam.Text = "Nam";
            rdNam.UseVisualStyleBackColor = true;
            // 
            // txtTenSinhVien
            // 
            txtTenSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenSinhVien.Location = new Point(150, 67);
            txtTenSinhVien.MaxLength = 50;
            txtTenSinhVien.Name = "txtTenSinhVien";
            txtTenSinhVien.Size = new Size(980, 31);
            txtTenSinhVien.TabIndex = 7;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaSinhVien.Location = new Point(150, 34);
            txtMaSinhVien.MaxLength = 10;
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(980, 31);
            txtMaSinhVien.TabIndex = 6;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(20, 208);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(45, 25);
            lblLop.TabIndex = 5;
            lblLop.Text = "Lớp:";
            // 
            // lblQueQuan
            // 
            lblQueQuan.AutoSize = true;
            lblQueQuan.Location = new Point(20, 173);
            lblQueQuan.Name = "lblQueQuan";
            lblQueQuan.Size = new Size(93, 25);
            lblQueQuan.TabIndex = 4;
            lblQueQuan.Text = "Quê quán:";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(20, 139);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(82, 25);
            lblGioiTinh.TabIndex = 3;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 105);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(91, 25);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblTenSinhVien
            // 
            lblTenSinhVien.AutoSize = true;
            lblTenSinhVien.Location = new Point(20, 70);
            lblTenSinhVien.Name = "lblTenSinhVien";
            lblTenSinhVien.Size = new Size(118, 25);
            lblTenSinhVien.TabIndex = 1;
            lblTenSinhVien.Text = "Tên sinh viên:";
            // 
            // lblMaSinhVien
            // 
            lblMaSinhVien.AutoSize = true;
            lblMaSinhVien.Location = new Point(20, 37);
            lblMaSinhVien.Name = "lblMaSinhVien";
            lblMaSinhVien.Size = new Size(116, 25);
            lblMaSinhVien.TabIndex = 0;
            lblMaSinhVien.Text = "Mã sinh viên:";
            // 
            // grpChucNang
            // 
            grpChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChucNang.Controls.Add(btnLamMoi);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Location = new Point(12, 268);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(1160, 80);
            grpChucNang.TabIndex = 1;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(620, 30);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(180, 40);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(420, 30);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(180, 40);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(220, 30);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(180, 40);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(20, 30);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(180, 40);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSach.Controls.Add(dgvSinhVien);
            grpDanhSach.Location = new Point(12, 354);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(1160, 320);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sinh viên";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.Location = new Point(3, 27);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 62;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1154, 290);
            dgvSinhVien.TabIndex = 0;
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;
            // 
            // QuanLySinhVienForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 686);
            Controls.Add(grpDanhSach);
            Controls.Add(grpChucNang);
            Controls.Add(grpThongTin);
            Name = "QuanLySinhVienForm";
            Text = "Quản lý sinh viên";
            Load += QuanLySinhVienForm_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaSinhVien;
        private Label lblTenSinhVien;
        private Label lblNgaySinh;
        private Label lblGioiTinh;
        private Label lblQueQuan;
        private Label lblLop;
        private TextBox txtMaSinhVien;
        private TextBox txtTenSinhVien;
        private RadioButton rdNam;
        private RadioButton rdNu;
        private TextBox txtQueQuan;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboLop;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvSinhVien;
    }
}

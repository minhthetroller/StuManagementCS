namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class QuanLyLopForm
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
            txtKhoaHoc = new NumericUpDown();
            txtTenLop = new TextBox();
            txtMaLop = new TextBox();
            lblKhoaHoc = new Label();
            lblTenLop = new Label();
            lblMaLop = new Label();
            grpChucNang = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            grpDanhSach = new GroupBox();
            dgvLop = new DataGridView();
            pnlPagination = new Panel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnLast = new Button();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKhoaHoc).BeginInit();
            grpChucNang.SuspendLayout();
            grpDanhSach.SuspendLayout();
            pnlPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(txtKhoaHoc);
            grpThongTin.Controls.Add(txtTenLop);
            grpThongTin.Controls.Add(txtMaLop);
            grpThongTin.Controls.Add(lblKhoaHoc);
            grpThongTin.Controls.Add(lblTenLop);
            grpThongTin.Controls.Add(lblMaLop);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1160, 150);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin lớp";
            // 
            // txtKhoaHoc
            // 
            txtKhoaHoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKhoaHoc.Location = new Point(150, 100);
            txtKhoaHoc.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            txtKhoaHoc.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            txtKhoaHoc.Name = "txtKhoaHoc";
            txtKhoaHoc.Size = new Size(980, 31);
            txtKhoaHoc.TabIndex = 5;
            txtKhoaHoc.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // txtTenLop
            // 
            txtTenLop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenLop.Location = new Point(150, 67);
            txtTenLop.MaxLength = 50;
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(980, 31);
            txtTenLop.TabIndex = 4;
            // 
            // txtMaLop
            // 
            txtMaLop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaLop.Location = new Point(150, 34);
            txtMaLop.MaxLength = 10;
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(980, 31);
            txtMaLop.TabIndex = 3;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 102);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(89, 25);
            lblKhoaHoc.TabIndex = 2;
            lblKhoaHoc.Text = "Khóa học:";
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(20, 70);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new Size(75, 25);
            lblTenLop.TabIndex = 1;
            lblTenLop.Text = "Tên lớp:";
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(20, 37);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new Size(73, 25);
            lblMaLop.TabIndex = 0;
            lblMaLop.Text = "Mã lớp:";
            // 
            // grpChucNang
            // 
            grpChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChucNang.Controls.Add(btnLamMoi);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Location = new Point(12, 168);
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
            grpDanhSach.Controls.Add(pnlPagination);
            grpDanhSach.Controls.Add(dgvLop);
            grpDanhSach.Location = new Point(12, 254);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(1160, 420);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách lớp";
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Dock = DockStyle.Fill;
            dgvLop.Location = new Point(3, 27);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersWidth = 62;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new Size(1154, 390);
            dgvLop.TabIndex = 0;
            dgvLop.SelectionChanged += dgvLop_SelectionChanged;
            // 
            // pnlPagination
            // 
            pnlPagination.Controls.Add(btnLast);
            pnlPagination.Controls.Add(btnNext);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnPrev);
            pnlPagination.Controls.Add(btnFirst);
            pnlPagination.Dock = DockStyle.Bottom;
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1154, 45);
            pnlPagination.TabIndex = 1;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(5, 7);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(40, 30);
            btnFirst.TabIndex = 0;
            btnFirst.Text = "\u00ab";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(50, 7);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(40, 30);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "\u2039";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPageInfo.Location = new Point(95, 12);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(964, 20);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Trang 1 / 1 | T\u1ed5ng: 0";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(1064, 7);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(40, 30);
            btnNext.TabIndex = 3;
            btnNext.Text = "\u203a";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.Location = new Point(1109, 7);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(40, 30);
            btnLast.TabIndex = 4;
            btnLast.Text = "\u00bb";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // QuanLyLopForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 686);
            Controls.Add(grpDanhSach);
            Controls.Add(grpChucNang);
            Controls.Add(grpThongTin);
            Name = "QuanLyLopForm";
            Text = "Qu\u1ea3n l\u00fd l\u1edbp";
            Load += QuanLyLopForm_Load;
            SizeChanged += QuanLyLopForm_SizeChanged;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKhoaHoc).EndInit();
            grpChucNang.ResumeLayout(false);
            pnlPagination.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaLop;
        private Label lblTenLop;
        private Label lblKhoaHoc;
        private TextBox txtMaLop;
        private TextBox txtTenLop;
        private NumericUpDown txtKhoaHoc;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvLop;
        private Panel pnlPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Label lblPageInfo;
        private Button btnNext;
        private Button btnLast;
    }
}

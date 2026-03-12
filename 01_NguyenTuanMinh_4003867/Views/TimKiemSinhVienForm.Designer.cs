namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class TimKiemSinhVienForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpTimKiem = new GroupBox();
            cboLop = new ComboBox();
            lblLop = new Label();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            grpKetQua = new GroupBox();
            dgvKetQua = new DataGridView();
            grpTimKiem.SuspendLayout();
            grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();
            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Controls.Add(cboLop);
            grpTimKiem.Controls.Add(lblLop);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(lblTimKiem);
            grpTimKiem.Location = new Point(12, 12);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(1160, 140);
            grpTimKiem.TabIndex = 0;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm sinh viên";
            // 
            // cboLop
            // 
            cboLop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(150, 73);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(980, 33);
            cboLop.TabIndex = 4;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(20, 76);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(74, 25);
            lblLop.TabIndex = 3;
            lblLop.Text = "Lọc lớp:";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Location = new Point(980, 30);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(150, 40);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(150, 36);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã sinh viên, tên sinh viên hoặc quê quán...";
            txtTimKiem.Size = new Size(810, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.KeyPress += txtTimKiem_KeyPress;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(20, 39);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(82, 25);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Từ khóa:";
            // 
            // grpKetQua
            // 
            grpKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpKetQua.Controls.Add(dgvKetQua);
            grpKetQua.Location = new Point(12, 158);
            grpKetQua.Name = "grpKetQua";
            grpKetQua.Size = new Size(1160, 516);
            grpKetQua.TabIndex = 1;
            grpKetQua.TabStop = false;
            grpKetQua.Text = "Kết quả tìm kiếm";
            // 
            // dgvKetQua
            // 
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Dock = DockStyle.Fill;
            dgvKetQua.Location = new Point(3, 27);
            dgvKetQua.MultiSelect = false;
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.ReadOnly = true;
            dgvKetQua.RowHeadersWidth = 62;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.Size = new Size(1154, 486);
            dgvKetQua.TabIndex = 0;
            // 
            // TimKiemSinhVienForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 686);
            Controls.Add(grpKetQua);
            Controls.Add(grpTimKiem);
            Name = "TimKiemSinhVienForm";
            Text = "Tìm kiếm sinh viên";
            Load += TimKiemSinhVienForm_Load;
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            grpKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpTimKiem;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblLop;
        private ComboBox cboLop;
        private GroupBox grpKetQua;
        private DataGridView dgvKetQua;
    }
}

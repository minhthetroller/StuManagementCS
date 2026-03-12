namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class TimKiemLopForm
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
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Controls.Add(txtTimKiem);
            grpTimKiem.Controls.Add(lblTimKiem);
            grpTimKiem.Location = new Point(12, 12);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(1160, 100);
            grpTimKiem.TabIndex = 0;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "Tìm kiếm lớp";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Location = new Point(980, 34);
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
            txtTimKiem.Location = new Point(150, 40);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã lớp, tên lớp hoặc khóa học...";
            txtTimKiem.Size = new Size(810, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.KeyPress += txtTimKiem_KeyPress;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(20, 43);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(82, 25);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Từ khóa:";
            // 
            // grpKetQua
            // 
            grpKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpKetQua.Controls.Add(dgvKetQua);
            grpKetQua.Location = new Point(12, 118);
            grpKetQua.Name = "grpKetQua";
            grpKetQua.Size = new Size(1160, 556);
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
            dgvKetQua.Size = new Size(1154, 526);
            dgvKetQua.TabIndex = 0;
            // 
            // TimKiemLopForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 686);
            Controls.Add(grpKetQua);
            Controls.Add(grpTimKiem);
            Name = "TimKiemLopForm";
            Text = "Tìm kiếm lớp";
            Load += TimKiemLopForm_Load;
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
        private GroupBox grpKetQua;
        private DataGridView dgvKetQua;
    }
}

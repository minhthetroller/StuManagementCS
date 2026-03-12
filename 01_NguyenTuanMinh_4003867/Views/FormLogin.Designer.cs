namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class FormLogin
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
            panelMain = new Panel();
            grpInfo = new GroupBox();
            lblInfoDetail = new Label();
            lblInfoTitle = new Label();
            grpLogin = new GroupBox();
            btnThoat = new Button();
            btnDangNhap = new Button();
            chkHienMatKhau = new CheckBox();
            txtMatKhau = new TextBox();
            txtTaiKhoan = new TextBox();
            lblMatKhau = new Label();
            lblTaiKhoan = new Label();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            grpInfo.SuspendLayout();
            grpLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(grpInfo);
            panelMain.Controls.Add(grpLogin);
            panelMain.Controls.Add(lblTitle);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(700, 550);
            panelMain.TabIndex = 0;
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.None;
            grpInfo.BackColor = Color.FromArgb(240, 248, 255);
            grpInfo.Controls.Add(lblInfoDetail);
            grpInfo.Controls.Add(lblInfoTitle);
            grpInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpInfo.ForeColor = Color.FromArgb(0, 122, 204);
            grpInfo.Location = new Point(100, 400);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(500, 120);
            grpInfo.TabIndex = 2;
            grpInfo.TabStop = false;
            grpInfo.Text = "THÔNG TIN TÀI KHOẢN MẪU";
            // 
            // lblInfoDetail
            // 
            lblInfoDetail.BackColor = Color.White;
            lblInfoDetail.BorderStyle = BorderStyle.FixedSingle;
            lblInfoDetail.Dock = DockStyle.Fill;
            lblInfoDetail.Font = new Font("Consolas", 10F);
            lblInfoDetail.ForeColor = Color.Black;
            lblInfoDetail.Location = new Point(3, 46);
            lblInfoDetail.Name = "lblInfoDetail";
            lblInfoDetail.Padding = new Padding(10);
            lblInfoDetail.Size = new Size(494, 71);
            lblInfoDetail.TabIndex = 1;
            lblInfoDetail.Text = "Admin     : admin / 123456\r\nEmployee  : employee / 123456\r\nUser      : user / 123456";
            lblInfoDetail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.Dock = DockStyle.Top;
            lblInfoTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.DarkRed;
            lblInfoTitle.Location = new Point(3, 23);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(494, 23);
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "Sử dụng tài khoản sau để đăng nhập:";
            lblInfoTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpLogin
            // 
            grpLogin.Anchor = AnchorStyles.None;
            grpLogin.Controls.Add(btnThoat);
            grpLogin.Controls.Add(btnDangNhap);
            grpLogin.Controls.Add(chkHienMatKhau);
            grpLogin.Controls.Add(txtMatKhau);
            grpLogin.Controls.Add(txtTaiKhoan);
            grpLogin.Controls.Add(lblMatKhau);
            grpLogin.Controls.Add(lblTaiKhoan);
            grpLogin.Location = new Point(100, 120);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(500, 250);
            grpLogin.TabIndex = 1;
            grpLogin.TabStop = false;
            grpLogin.Text = "Thông tin đăng nhập";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(270, 190);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(200, 45);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(30, 190);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(200, 45);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(150, 150);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(147, 29);
            chkHienMatKhau.TabIndex = 4;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 11F);
            txtMatKhau.Location = new Point(150, 105);
            txtMatKhau.MaxLength = 30;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(320, 32);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.KeyPress += txtMatKhau_KeyPress;
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new Font("Segoe UI", 11F);
            txtTaiKhoan.Location = new Point(150, 55);
            txtTaiKhoan.MaxLength = 30;
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(320, 32);
            txtTaiKhoan.TabIndex = 2;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F);
            lblMatKhau.Location = new Point(30, 110);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(86, 23);
            lblMatKhau.TabIndex = 1;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new Font("Segoe UI", 10F);
            lblTaiKhoan.Location = new Point(30, 60);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(87, 23);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(0, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(700, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 550);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            panelMain.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpLogin.ResumeLayout(false);
            grpLogin.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblTitle;
        private GroupBox grpLogin;
        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private GroupBox grpInfo;
        private Label lblInfoTitle;
        private Label lblInfoDetail;
    }
}

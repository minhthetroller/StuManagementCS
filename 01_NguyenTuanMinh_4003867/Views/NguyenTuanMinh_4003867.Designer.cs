namespace _01_NguyenTuanMinh_4003867.Views
{
    partial class NguyenTuanMinh_4003867
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
            menuStrip1 = new MenuStrip();
            mnuQuanLyDuLieu = new ToolStripMenuItem();
            mnuQuanLyLop = new ToolStripMenuItem();
            mnuQuanLySinhVien = new ToolStripMenuItem();
            mnuTimKiem = new ToolStripMenuItem();
            mnuTimKiemLop = new ToolStripMenuItem();
            mnuTimKiemSinhVien = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblUser = new ToolStripStatusLabel();
            panelMain = new Panel();
            lblWelcome = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuQuanLyDuLieu, mnuTimKiem, mnuDangXuat, mnuThoat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1200, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuQuanLyDuLieu
            // 
            mnuQuanLyDuLieu.DropDownItems.AddRange(new ToolStripItem[] { mnuQuanLyLop, mnuQuanLySinhVien });
            mnuQuanLyDuLieu.Name = "mnuQuanLyDuLieu";
            mnuQuanLyDuLieu.Size = new Size(151, 29);
            mnuQuanLyDuLieu.Text = "Quản lý dữ liệu";
            // 
            // mnuQuanLyLop
            // 
            mnuQuanLyLop.Name = "mnuQuanLyLop";
            mnuQuanLyLop.Size = new Size(242, 34);
            mnuQuanLyLop.Text = "Quản lý lớp";
            mnuQuanLyLop.Click += mnuQuanLyLop_Click;
            // 
            // mnuQuanLySinhVien
            // 
            mnuQuanLySinhVien.Name = "mnuQuanLySinhVien";
            mnuQuanLySinhVien.Size = new Size(242, 34);
            mnuQuanLySinhVien.Text = "Quản lý sinh viên";
            mnuQuanLySinhVien.Click += mnuQuanLySinhVien_Click;
            // 
            // mnuTimKiem
            // 
            mnuTimKiem.DropDownItems.AddRange(new ToolStripItem[] { mnuTimKiemLop, mnuTimKiemSinhVien });
            mnuTimKiem.Name = "mnuTimKiem";
            mnuTimKiem.Size = new Size(101, 29);
            mnuTimKiem.Text = "Tìm kiếm";
            // 
            // mnuTimKiemLop
            // 
            mnuTimKiemLop.Name = "mnuTimKiemLop";
            mnuTimKiemLop.Size = new Size(242, 34);
            mnuTimKiemLop.Text = "Tìm kiếm lớp";
            mnuTimKiemLop.Click += mnuTimKiemLop_Click;
            // 
            // mnuTimKiemSinhVien
            // 
            mnuTimKiemSinhVien.Name = "mnuTimKiemSinhVien";
            mnuTimKiemSinhVien.Size = new Size(242, 34);
            mnuTimKiemSinhVien.Text = "Tìm kiếm sinh viên";
            mnuTimKiemSinhVien.Click += mnuTimKiemSinhVien_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(103, 29);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(71, 29);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblUser });
            statusStrip1.Location = new Point(0, 718);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1200, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(993, 25);
            lblStatus.Spring = true;
            lblStatus.Text = "Sẵn sàng";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(192, 25);
            lblUser.Text = "Người dùng: Chưa đăng nhập";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(lblWelcome);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 33);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 685);
            panelMain.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(0, 122, 204);
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1200, 685);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NguyenTuanMinh_4003867
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            Controls.Add(panelMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "NguyenTuanMinh_4003867";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý sinh viên - NguyenTuanMinh_4003867";
            FormClosing += NguyenTuanMinh_4003867_FormClosing;
            Load += NguyenTuanMinh_4003867_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuQuanLyDuLieu;
        private ToolStripMenuItem mnuQuanLyLop;
        private ToolStripMenuItem mnuQuanLySinhVien;
        private ToolStripMenuItem mnuTimKiem;
        private ToolStripMenuItem mnuTimKiemLop;
        private ToolStripMenuItem mnuTimKiemSinhVien;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuThoat;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblUser;
        private Panel panelMain;
        private Label lblWelcome;
    }
}

using _01_NguyenTuanMinh_4003867.Controllers;
using _01_NguyenTuanMinh_4003867.Data;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class NguyenTuanMinh_4003867 : Form
    {
        public NguyenTuanMinh_4003867()
        {
            InitializeComponent();
        }

        private void NguyenTuanMinh_4003867_Load(object sender, EventArgs e)
        {
            // Check if user is authenticated
            if (!AuthenticationController.IsAuthenticated())
            {
                // Show login form
                ShowLoginForm();
            }
            else
            {
                UpdateUserInterface();
            }
        }

        private void ShowLoginForm()
        {
            using var loginForm = new FormLogin();
            var result = loginForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // User logged in successfully
                UpdateUserInterface();
            }
            else
            {
                // User cancelled login - close the main form and exit
                this.Close();
                Application.Exit();
            }
        }

        private void UpdateUserInterface()
        {
            string username = AuthenticationController.GetCurrentUsername();
            string roleName = AuthenticationController.GetCurrentUserRoleName();

            lblUser.Text = $"Người dùng: {username} ({roleName})";
            lblStatus.Text = "Kết nối cơ sở dữ liệu thành công";
            lblWelcome.Text = $"CHÀO MỪNG {username.ToUpper()}\n\nHỆ THỐNG QUẢN LÝ SINH VIÊN";
        }

        private void mnuQuanLyLop_Click(object sender, EventArgs e)
        {
            if (!CheckAuthentication()) return;
            ShowForm(new QuanLyLopForm());
        }

        private void mnuQuanLySinhVien_Click(object sender, EventArgs e)
        {
            if (!CheckAuthentication()) return;
            ShowForm(new QuanLySinhVienForm());
        }

        private void mnuTimKiemLop_Click(object sender, EventArgs e)
        {
            if (!CheckAuthentication()) return;
            ShowForm(new TimKiemLopForm());
        }

        private void mnuTimKiemSinhVien_Click(object sender, EventArgs e)
        {
            if (!CheckAuthentication()) return;
            ShowForm(new TimKiemSinhVienForm());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất khỏi hệ thống?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Logout and show login form again
                var authController = new AuthenticationController();
                authController.Logout();
                
                // Clear the main panel
                panelMain.Controls.Clear();
                panelMain.Controls.Add(lblWelcome);
                lblWelcome.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
                lblWelcome.Dock = DockStyle.Fill;
                
                // Update status bar
                lblUser.Text = "Người dùng: Chưa đăng nhập";
                lblStatus.Text = "Vui lòng đăng nhập";
                
                // Hide the main form temporarily
                this.Hide();
                
                // Show login form
                using var loginForm = new FormLogin();
                var loginResult = loginForm.ShowDialog();

                if (loginResult == DialogResult.OK)
                {
                    // User logged in successfully - show main form again
                    this.Show();
                    UpdateUserInterface();
                }
                else
                {
                    // User cancelled login - close main form and exit
                    this.Close();
                    Application.Exit();
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void NguyenTuanMinh_4003867_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Don't show confirmation if already exiting
            if (Application.OpenForms.Count <= 1)
            {
                return;
            }

            var result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private bool CheckAuthentication()
        {
            if (!AuthenticationController.IsAuthenticated())
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowLoginForm();
                return false;
            }
            return true;
        }

        private void ShowForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
            lblStatus.Text = form.Text;
        }
    }
}

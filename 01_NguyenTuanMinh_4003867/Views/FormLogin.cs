using _01_NguyenTuanMinh_4003867.Controllers;
using _01_NguyenTuanMinh_4003867.Data;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class FormLogin : Form
    {
        private readonly AuthenticationController _authController;

        public FormLogin()
        {
            InitializeComponent();
            _authController = new AuthenticationController();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                DatabaseHelper.Initialize();
                DatabaseHelper.InsertSampleData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi tạo cơ sở dữ liệu: {ex.Message}\n\n" +
                    $"Đường dẫn: {DatabaseHelper.GetDatabasePath()}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            var result = _authController.Login(username, password);

            if (result.success)
            {
                // Close login form and show main form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Clear();
                txtTaiKhoan.Focus();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using _01_NguyenTuanMinh_4003867.Controllers;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class QuanLyLopForm : Form
    {
        private readonly LopQuanLyController _controller;
        private bool _isEditMode = false;

        public QuanLyLopForm()
        {
            InitializeComponent();
            _controller = new LopQuanLyController();
            txtMaLop.ReadOnly = true;
            txtTenLop.TextChanged += txtTenLop_TextChanged;
        }

        private void QuanLyLopForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetupDataGridView();
            dgvLop.ClearSelection();
            ClearInputs();
        }

        private void SetupDataGridView()
        {
            dgvLop.AutoGenerateColumns = false;
            dgvLop.Columns.Clear();

            dgvLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqLma",
                HeaderText = "Mã lớp",
                Name = "colMaLop",
                Width = 150
            });

            dgvLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqTen",
                HeaderText = "Tên lớp",
                Name = "colTenLop",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqKhoaHoc",
                HeaderText = "Khóa học",
                Name = "colKhoaHoc",
                Width = 150
            });
            
            // Add mouse click event to handle deselection
            dgvLop.MouseClick += dgvLop_MouseClick;
        }

        private void dgvLop_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the hit test information
            var hitTest = dgvLop.HitTest(e.X, e.Y);
            
            // If clicked on empty area (not on a row), clear selection
            if (hitTest.Type == DataGridViewHitTestType.None)
            {
                dgvLop.ClearSelection();
                ClearInputs();
            }
        }

        private void LoadData()
        {
            try
            {
                var lopQuanLys = _controller.GetAllLopQuanLys();
                dgvLop.DataSource = lopQuanLys;
                dgvLop.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                var lop = dgvLop.SelectedRows[0].DataBoundItem as LopQuanLy;
                if (lop != null)
                {
                    _isEditMode = true;
                    txtMaLop.Text = lop.LqLma;
                    txtTenLop.Text = lop.LqTen;
                    txtKhoaHoc.Value = lop.LqKhoaHoc;
                }
            }
            else
            {
                ClearInputs();
            }
        }

        private void txtTenLop_TextChanged(object? sender, EventArgs e)
        {
            if (_isEditMode)
            {
                return;
            }

            txtMaLop.Text = _controller.GenerateClassId(txtTenLop.Text.Trim());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var lop = new LopQuanLy
            {
                LqLma = txtMaLop.Text.Trim(),
                LqTen = txtTenLop.Text.Trim(),
                LqKhoaHoc = (int)txtKhoaHoc.Value
            };

            var result = _controller.AddLopQuanLy(lop);

            if (result.success)
            {
                MessageBox.Show(result.message, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show(result.message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var lop = new LopQuanLy
            {
                LqLma = txtMaLop.Text.Trim(),
                LqTen = txtTenLop.Text.Trim(),
                LqKhoaHoc = (int)txtKhoaHoc.Value
            };

            var result = _controller.UpdateLopQuanLy(lop);

            if (result.success)
            {
                MessageBox.Show(result.message, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show(result.message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lớp này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = _controller.DeleteLopQuanLy(txtMaLop.Text.Trim());

                if (result.success)
                {
                    MessageBox.Show(result.message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(result.message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvLop.ClearSelection();
            ClearInputs();
            LoadData();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Không thể tạo mã lớp tự động từ tên lớp. Vui lòng nhập tên lớp hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtKhoaHoc.Value = DateTime.Now.Year;
            _isEditMode = false;
            txtTenLop.Focus();
        }
    }
}

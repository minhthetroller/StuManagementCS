using _01_NguyenTuanMinh_4003867.Controllers;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class QuanLySinhVienForm : Form
    {
        private readonly SinhVienController _controller;
        private readonly LopQuanLyController _lopController;
        private bool _isEditMode = false;
        private string? _lastSelectedStudentId = null;

        public QuanLySinhVienForm()
        {
            InitializeComponent();
            _controller = new SinhVienController();
            _lopController = new LopQuanLyController();
            txtMaSinhVien.ReadOnly = true;
        }

        private void QuanLySinhVienForm_Load(object sender, EventArgs e)
        {
            LoadClasses();
            SetupDataGridView();
            LoadData();
            
            // Don't auto-select any student - leave fields empty
            dgvSinhVien.ClearSelection();
            ClearInputs();
        }

        private void LoadClasses()
        {
            try
            {
                var classes = _lopController.GetAllLopQuanLys();
                cboLop.DataSource = classes;
                cboLop.DisplayMember = "LqTen";
                cboLop.ValueMember = "LqLma";
                cboLop.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvMa",
                HeaderText = "Mã SV",
                Name = "colMaSinhVien",
                Width = 100
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvTen",
                HeaderText = "Tên sinh viên",
                Name = "colTenSinhVien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvNgaySinh",
                HeaderText = "Ngày sinh",
                Name = "colNgaySinh",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvGioiTinh",
                HeaderText = "Giới tính",
                Name = "colGioiTinh",
                Width = 100
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvQueQuan",
                HeaderText = "Quê quán",
                Name = "colQueQuan",
                Width = 150
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqLma",
                HeaderText = "Mã lớp",
                Name = "colMaLop",
                Width = 100
            });
            
            // Add mouse click event to handle deselection and re-selection
            dgvSinhVien.MouseClick += dgvSinhVien_MouseClick;
        }

        private void dgvSinhVien_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the hit test information
            var hitTest = dgvSinhVien.HitTest(e.X, e.Y);
            
            // If clicked on empty area (not on a row), clear selection
            if (hitTest.Type == DataGridViewHitTestType.None)
            {
                dgvSinhVien.ClearSelection();
                _lastSelectedStudentId = null;
                ClearInputs();
                return;
            }

            // If clicked on a row
            if (hitTest.Type == DataGridViewHitTestType.Cell && hitTest.RowIndex >= 0)
            {
                var row = dgvSinhVien.Rows[hitTest.RowIndex];
                var originalData = row.DataBoundItem?.GetType().GetProperty("OriginalData")?.GetValue(row.DataBoundItem, null) as SinhVien;
                
                if (originalData != null)
                {
                    if (_lastSelectedStudentId == originalData.SvMa)
                    {
                        dgvSinhVien.ClearSelection();
                        _lastSelectedStudentId = null;
                        ClearInputs();
                    }
                    else
                    {
                        // New student selected
                        _lastSelectedStudentId = originalData.SvMa;
                    }
                }
            }
        }

        private void LoadData()
        {
            try
            {
                var sinhViens = _controller.GetAllSinhViens();
                
                // Format gender display
                var displayList = sinhViens.Select(sv => new
                {
                    sv.SvMa,
                    sv.SvTen,
                    sv.SvNgaySinh,
                    SvGioiTinh = sv.SvGioiTinh.HasValue ? (sv.SvGioiTinh.Value ? "Nam" : "Nữ") : "",
                    sv.SvQueQuan,
                    sv.LqLma,
                    OriginalData = sv
                }).ToList();

                dgvSinhVien.DataSource = displayList;
                dgvSinhVien.ClearSelection();
                _lastSelectedStudentId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                var row = dgvSinhVien.SelectedRows[0];
                var originalData = row.DataBoundItem?.GetType().GetProperty("OriginalData")?.GetValue(row.DataBoundItem, null) as SinhVien;
                
                if (originalData != null)
                {
                    txtMaSinhVien.Text = originalData.SvMa;
                    txtTenSinhVien.Text = originalData.SvTen;
                    
                    if (originalData.SvNgaySinh.HasValue)
                    {
                        dtpNgaySinh.Value = originalData.SvNgaySinh.Value;
                    }
                    else
                    {
                        dtpNgaySinh.Value = DateTime.Now;
                    }

                    if (originalData.SvGioiTinh.HasValue)
                    {
                        rdNam.Checked = originalData.SvGioiTinh.Value;
                        rdNu.Checked = !originalData.SvGioiTinh.Value;
                    }
                    else
                    {
                        rdNam.Checked = true;
                    }

                    txtQueQuan.Text = originalData.SvQueQuan ?? "";
                    cboLop.SelectedValue = originalData.LqLma;

                    _lastSelectedStudentId = originalData.SvMa;
                    _isEditMode = true;
                }
            }
            else
            {
                ClearInputs();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var sinhVien = new SinhVien
            {
                SvMa = txtMaSinhVien.Text.Trim(),
                SvTen = txtTenSinhVien.Text.Trim(),
                SvNgaySinh = dtpNgaySinh.Value,
                SvGioiTinh = rdNam.Checked,
                SvQueQuan = string.IsNullOrWhiteSpace(txtQueQuan.Text) ? null : txtQueQuan.Text.Trim(),
                LqLma = cboLop.SelectedValue?.ToString() ?? ""
            };

            var result = _controller.AddSinhVien(sinhVien);

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
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var sinhVien = new SinhVien
            {
                SvMa = txtMaSinhVien.Text.Trim(),
                SvTen = txtTenSinhVien.Text.Trim(),
                SvNgaySinh = dtpNgaySinh.Value,
                SvGioiTinh = rdNam.Checked,
                SvQueQuan = string.IsNullOrWhiteSpace(txtQueQuan.Text) ? null : txtQueQuan.Text.Trim(),
                LqLma = cboLop.SelectedValue?.ToString() ?? ""
            };

            var result = _controller.UpdateSinhVien(sinhVien);

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
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var result = _controller.DeleteSinhVien(txtMaSinhVien.Text.Trim());

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
            dgvSinhVien.ClearSelection();
            _lastSelectedStudentId = null;
            ClearInputs();
            LoadData();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenSinhVien.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSinhVien.Focus();
                return false;
            }

            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtMaSinhVien.Text = _controller.GenerateNextStudentId();
            txtTenSinhVien.Clear();
            txtQueQuan.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            cboLop.SelectedIndex = -1;
            _isEditMode = false;
            _lastSelectedStudentId = null;
            txtTenSinhVien.Focus();
        }
    }
}

using _01_NguyenTuanMinh_4003867.Controllers;
using _01_NguyenTuanMinh_4003867.Models;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class QuanLyLopForm : Form
    {
        private readonly LopQuanLyController _controller;
        private bool _isEditMode = false;
        private int _currentPage = 0;
        private int _pageSize = 15;
        private int _totalCount = 0;
        private readonly System.Windows.Forms.Timer _resizeTimer;

        public QuanLyLopForm()
        {
            _resizeTimer = new System.Windows.Forms.Timer { Interval = 250 };
            _resizeTimer.Tick += ResizeTimer_Tick;
            InitializeComponent();
            _controller = new LopQuanLyController();
            txtMaLop.ReadOnly = true;
            txtTenLop.TextChanged += txtTenLop_TextChanged;
        }

        private void QuanLyLopForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            _pageSize = CalculatePageSize();
            LoadPagedData();
            dgvLop.ClearSelection();
            ClearInputs();
        }

        private void SetupDataGridView()
        {
            dgvLop.AutoGenerateColumns = false;
            dgvLop.ScrollBars = ScrollBars.None;
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

        private void LoadPagedData()
        {
            try
            {
                var (items, total) = _controller.GetLopQuanLyPage(_currentPage, _pageSize);
                _totalCount = total;
                dgvLop.DataSource = items;
                dgvLop.ClearSelection();
                UpdatePaginationControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationControls()
        {
            int totalPages = _pageSize > 0 ? (int)Math.Ceiling((double)_totalCount / _pageSize) : 1;
            if (totalPages < 1) totalPages = 1;
            lblPageInfo.Text = $"Trang {_currentPage + 1} / {totalPages} | Tổng: {_totalCount} lớp";
            btnFirst.Enabled = _currentPage > 0;
            btnPrev.Enabled = _currentPage > 0;
            btnNext.Enabled = _currentPage < totalPages - 1;
            btnLast.Enabled = _currentPage < totalPages - 1;
        }

        private int CalculatePageSize()
        {
            int rowHeight = Math.Max(1, dgvLop.RowTemplate.Height);
            int headerHeight = dgvLop.ColumnHeadersHeight > 0 ? dgvLop.ColumnHeadersHeight : rowHeight;
            int available = dgvLop.ClientSize.Height - headerHeight;
            return Math.Max(1, available / rowHeight);
        }

        private void ResizeTimer_Tick(object? sender, EventArgs e)
        {
            _resizeTimer.Stop();
            int newSize = CalculatePageSize();
            if (newSize != _pageSize)
            {
                _pageSize = newSize;
                _currentPage = 0;
                LoadPagedData();
            }
        }

        private void QuanLyLopForm_SizeChanged(object sender, EventArgs e)
        {
            _resizeTimer.Stop();
            _resizeTimer.Start();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _currentPage = 0;
            LoadPagedData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                LoadPagedData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalCount / _pageSize);
            if (_currentPage < totalPages - 1)
            {
                _currentPage++;
                LoadPagedData();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalCount / _pageSize);
            _currentPage = Math.Max(0, totalPages - 1);
            LoadPagedData();
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
                _currentPage = 0;
                LoadPagedData();
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
                LoadPagedData();
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
                    _currentPage = 0;
                    LoadPagedData();
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
            _currentPage = 0;
            LoadPagedData();
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

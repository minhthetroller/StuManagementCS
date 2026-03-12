using _01_NguyenTuanMinh_4003867.Controllers;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class TimKiemSinhVienForm : Form
    {
        private readonly SinhVienController _controller;
        private readonly LopQuanLyController _lopController;

        public TimKiemSinhVienForm()
        {
            InitializeComponent();
            _controller = new SinhVienController();
            _lopController = new LopQuanLyController();
        }

        private void TimKiemSinhVienForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadClasses();
            LoadAllData();
            txtTimKiem.PlaceholderText = "Nhập tên sinh viên (tìm kiếm gần đúng)...";
        }

        private void LoadClasses()
        {
            try
            {
                var classes = _lopController.GetAllLopQuanLys();
                
                // Add "All" option
                var allClasses = new List<Models.LopQuanLy>
                {
                    new Models.LopQuanLy { LqLma = "", LqTen = "-- Tất cả lớp --", LqKhoaHoc = 0 }
                };
                allClasses.AddRange(classes);

                cboLop.DataSource = allClasses;
                cboLop.DisplayMember = "LqTen";
                cboLop.ValueMember = "LqLma";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvMa",
                HeaderText = "Mã SV",
                Name = "colMaSinhVien",
                Width = 100
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvTen",
                HeaderText = "Tên sinh viên",
                Name = "colTenSinhVien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvNgaySinh",
                HeaderText = "Ngày sinh",
                Name = "colNgaySinh",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvGioiTinh",
                HeaderText = "Giới tính",
                Name = "colGioiTinh",
                Width = 100
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SvQueQuan",
                HeaderText = "Quê quán",
                Name = "colQueQuan",
                Width = 150
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqLma",
                HeaderText = "Mã lớp",
                Name = "colMaLop",
                Width = 100
            });
        }

        private void LoadAllData()
        {
            try
            {
                var sinhViens = _controller.GetAllSinhViens();
                DisplayResults(sinhViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string? selectedClass = cboLop.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(selectedClass))
                    selectedClass = null;

                List<Models.SinhVien> results;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // If no keyword, get all or filter by class
                    if (string.IsNullOrEmpty(selectedClass))
                    {
                        results = _controller.GetAllSinhViens();
                    }
                    else
                    {
                        results = _controller.SearchSinhViens("", selectedClass);
                    }
                }
                else
                {
                    // Approximate search by student name (svten)
                    results = _controller.SearchSinhViens(keyword, selectedClass);
                }

                DisplayResults(results);

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(List<Models.SinhVien> results)
        {
            var displayList = results.Select(sv => new
            {
                sv.SvMa,
                sv.SvTen,
                sv.SvNgaySinh,
                SvGioiTinh = sv.SvGioiTinh.HasValue ? (sv.SvGioiTinh.Value ? "Nam" : "Nữ") : "",
                sv.SvQueQuan,
                sv.LqLma
            }).ToList();

            dgvKetQua.DataSource = displayList;

            grpKetQua.Text = $"Kết quả tìm kiếm ({results.Count} sinh viên)";
        }
    }
}

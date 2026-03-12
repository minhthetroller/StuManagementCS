using _01_NguyenTuanMinh_4003867.Controllers;

namespace _01_NguyenTuanMinh_4003867.Views
{
    public partial class TimKiemLopForm : Form
    {
        private readonly LopQuanLyController _controller;

        public TimKiemLopForm()
        {
            InitializeComponent();
            _controller = new LopQuanLyController();
        }

        private void TimKiemLopForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAllData();
            txtTimKiem.PlaceholderText = "Nhập mã lớp (tìm kiếm chính xác)...";
        }

        private void SetupDataGridView()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqLma",
                HeaderText = "Mã lớp",
                Name = "colMaLop",
                Width = 150
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqTen",
                HeaderText = "Tên lớp",
                Name = "colTenLop",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LqKhoaHoc",
                HeaderText = "Khóa học",
                Name = "colKhoaHoc",
                Width = 150
            });

            // Add student count column
            var countColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số sinh viên",
                Name = "colSoSinhVien",
                Width = 150
            };
            dgvKetQua.Columns.Add(countColumn);
        }

        private void LoadAllData()
        {
            try
            {
                var lopQuanLys = _controller.GetAllLopQuanLys();
                DisplayResults(lopQuanLys);
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

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    LoadAllData();
                    return;
                }

                // Exact search by class code (lqlma)
                var exactResult = _controller.GetLopQuanLyById(keyword);
                
                List<Models.LopQuanLy> results = new List<Models.LopQuanLy>();
                
                if (exactResult != null)
                {
                    results.Add(exactResult);
                }

                DisplayResults(results);

                if (results.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy lớp có mã '{keyword}'!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(List<Models.LopQuanLy> results)
        {
            var displayList = results.Select(lop => new
            {
                lop.LqLma,
                lop.LqTen,
                lop.LqKhoaHoc,
                SoSinhVien = _controller.GetStudentCount(lop.LqLma)
            }).ToList();

            dgvKetQua.DataSource = displayList;

            grpKetQua.Text = $"Kết quả tìm kiếm ({results.Count} lớp)";
        }
    }
}

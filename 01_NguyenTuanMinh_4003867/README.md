# Hệ Thống Quản Lý Sinh Viên

**Student Management System — NguyenTuanMinh_4003867**

## Mô tả dự án

Ứng dụng quản lý sinh viên được xây dựng bằng C# Windows Forms với .NET 10, sử dụng SQL Server làm cơ sở dữ liệu và Entity Framework Core 10 làm ORM.

## Kiến trúc

Ứng dụng được thiết kế theo mô hình MVC (Model-View-Controller):

### Cấu trúc thư mục

```
01_NguyenTuanMinh_4003867/
├── Models/                          # Lớp mô hình dữ liệu
│   ├── SinhVien.cs                  # Model sinh viên
│   ├── LopQuanLy.cs                 # Model lớp học
│   ├── NhomQuyen.cs                 # Model nhóm quyền
│   └── TaiKhoan.cs                  # Model tài khoản
├── Data/                            # Lớp truy xuất dữ liệu
│   ├── StudentManagementDb.cs       # EF Core DbContext
│   ├── DatabaseHelper.cs            # Khởi tạo và quản lý database
│   ├── SinhVienRepository.cs        # Repository cho sinh viên
│   ├── LopQuanLyRepository.cs       # Repository cho lớp học
│   └── TaiKhoanRepository.cs        # Repository cho tài khoản
├── Controllers/                     # Lớp xử lý logic nghiệp vụ
│   ├── SinhVienController.cs        # Controller sinh viên
│   ├── LopQuanLyController.cs       # Controller lớp học
│   └── AuthenticationController.cs  # Controller xác thực
├── Views/                           # Giao diện người dùng
│   ├── FormLogin.cs                 # Form đăng nhập
│   ├── NguyenTuanMinh_4003867.cs    # Form chính
│   ├── QuanLyLopForm.cs             # Form quản lý lớp
│   ├── QuanLySinhVienForm.cs        # Form quản lý sinh viên
│   ├── TimKiemLopForm.cs            # Form tìm kiếm lớp
│   └── TimKiemSinhVienForm.cs       # Form tìm kiếm sinh viên
└── dbsettings.json                  # Cấu hình kết nối SQL Server
```

## Cấu hình kết nối

Kết nối SQL Server được cấu hình qua file `dbsettings.json`:

```json
{
  "ServerAddress": "localhost",
  "Username": "sa",
  "Password": "your_password",
  "DatabaseName": "StudentManagement"
}
```

> Sao chép `dbsettings.example.json` thành `dbsettings.json` và điền thông tin kết nối của bạn.

## Cơ sở dữ liệu

Schema được quản lý hoàn toàn bởi Entity Framework Core thông qua `EnsureCreated()` — không cần file SQL script.

### Bảng tbl_nhomquyen (Nhóm quyền)
| Cột | Kiểu | Ghi chú |
|-----|------|---------|
| `nqma` | `INT IDENTITY` | Khóa chính, tự tăng |
| `nqten` | `NVARCHAR(50)` | Tên nhóm quyền |
| `nqmota` | `NVARCHAR(MAX)` | Mô tả |

### Bảng tbl_taikhoan (Tài khoản)
| Cột | Kiểu | Ghi chú |
|-----|------|---------|
| `tktaikhoan` | `NVARCHAR(30)` | Khóa chính |
| `tkmatkhau` | `NVARCHAR(30)` | Mật khẩu |
| `nqma` | `INT` | Khóa ngoại → tbl_nhomquyen |

### Bảng tbl_lopquanly (Lớp quản lý)
| Cột | Kiểu | Ghi chú |
|-----|------|---------|
| `lqlma` | `NCHAR(10)` | Khóa chính |
| `lqten` | `NVARCHAR(50)` | Tên lớp |
| `lqkhoahoc` | `INT` | Khóa học |

### Bảng tbl_sinhvien (Sinh viên)
| Cột | Kiểu | Ghi chú |
|-----|------|---------|
| `svma` | `NCHAR(10)` | Khóa chính |
| `svten` | `NVARCHAR(50)` | Tên sinh viên |
| `svngaysinh` | `DATE` | Ngày sinh |
| `svgioitinh` | `TINYINT` | Giới tính (1=Nam, 0=Nữ) |
| `svquequan` | `NVARCHAR(50)` | Quê quán |
| `lqlma` | `NCHAR(10)` | Khóa ngoại → tbl_lopquanly |

## Tính năng chính

### 0. Xác thực người dùng
- ✅ Form đăng nhập với validation
- ✅ Hiển thị rõ ràng thông tin tài khoản mẫu
- ✅ Quản lý phiên đăng nhập
- ✅ 3 loại người dùng: Admin, Employee, User
- ✅ Đăng xuất và đăng nhập lại
- ✅ Kiểm tra xác thực trước khi truy cập chức năng
- ✅ Hiển thị thông tin người dùng trên thanh trạng thái

### 1. Quản lý dữ liệu
#### Quản lý lớp học
- ✅ Thêm lớp học mới
- ✅ Sửa thông tin lớp học
- ✅ Xóa lớp học (kiểm tra ràng buộc sinh viên)
- ✅ Xem danh sách tất cả lớp học

#### Quản lý sinh viên
- ✅ Thêm sinh viên mới
- ✅ Sửa thông tin sinh viên
- ✅ Xóa sinh viên
- ✅ Xem danh sách tất cả sinh viên
- ✅ Lọc theo lớp quản lý qua ComboBox

### 2. Tìm kiếm
#### Tìm kiếm lớp (Chính xác)
- ✅ Tìm kiếm theo mã lớp (lqlma)
- ✅ Hiển thị số lượng sinh viên trong lớp

#### Tìm kiếm sinh viên (Gần đúng)
- ✅ Tìm kiếm theo tên sinh viên (svten)
- ✅ Lọc theo lớp qua ComboBox
- ✅ Hỗ trợ tìm kiếm một phần tên

## Validation (Kiểm tra dữ liệu)

### Đăng nhập
- Tên đăng nhập: Không được trống
- Mật khẩu: Không được trống

### Lớp học
- Mã lớp: Không được trống, tối đa 10 ký tự
- Tên lớp: Không được trống, tối đa 50 ký tự
- Khóa học: Phải trong khoảng 2000 đến năm hiện tại + 1
- Không cho phép xóa lớp còn sinh viên

### Sinh viên
- Mã sinh viên: Không được trống, tối đa 10 ký tự
- Tên sinh viên: Không được trống, tối đa 50 ký tự
- Ngày sinh: Không được lớn hơn ngày hiện tại
- Tuổi: Phải trong khoảng 15–100 tuổi
- Quê quán: Tối đa 50 ký tự
- Mã lớp: Phải tồn tại trong hệ thống

## Công nghệ sử dụng

| Thành phần | Công nghệ |
|------------|-----------|
| Framework | .NET 10 |
| UI | Windows Forms |
| Database | SQL Server (2019+) |
| ORM | Entity Framework Core 10.0.4 |
| EF Provider | Microsoft.EntityFrameworkCore.SqlServer |
| Design Pattern | MVC (Model-View-Controller) |

## Cách chạy ứng dụng

1. Mở solution trong Visual Studio
2. Sao chép `dbsettings.example.json` thành `dbsettings.json` và điền thông tin SQL Server
3. Khôi phục NuGet packages (tự động khi build)
4. Build solution (`Ctrl + Shift + B`)
5. Chạy ứng dụng (`F5`)

Database và schema sẽ được tạo tự động bởi EF Core khi khởi chạy lần đầu.

## Dữ liệu mẫu

### Tài khoản
| Username | Password | Role | Mô tả |
|----------|----------|------|-------|
| `admin` | `123456` | Admin | Quản trị viên — Toàn quyền hệ thống |
| `employee` | `123456` | Employee | Nhân viên — Quản lý sinh viên và lớp học |
| `user` | `123456` | User | Người dùng — Chỉ xem thông tin |

### Lớp học (8 lớp)
| Mã lớp | Tên lớp | Khóa học |
|--------|---------|----------|
| CNTT2023A | Công nghệ thông tin 2023A | 2023 |
| CNTT2023B | Công nghệ thông tin 2023B | 2023 |
| CNTT2024A | Công nghệ thông tin 2024A | 2024 |
| KTPM2023A | Kỹ thuật phần mềm 2023A | 2023 |
| KTPM2024A | Kỹ thuật phần mềm 2024A | 2024 |
| KHMT2023A | Khoa học máy tính 2023A | 2023 |
| KHMT2024A | Khoa học máy tính 2024A | 2024 |
| HTTT2023A | Hệ thống thông tin 2023A | 2023 |

### Sinh viên (20 sinh viên)
| Mã SV | Tên sinh viên | Ngày sinh | Giới tính | Quê quán | Lớp |
|-------|---------------|-----------|-----------|----------|-----|
| SV2023001 | Nguyễn Văn Anh | 2005-03-15 | Nam | Hà Nội | CNTT2023A |
| SV2023002 | Trần Thị Bảo | 2005-07-22 | Nữ | Hồ Chí Minh | CNTT2023A |
| SV2023003 | Lê Minh Châu | 2005-01-10 | Nữ | Đà Nẵng | CNTT2023A |
| SV2023004 | Phạm Quốc Dũng | 2005-11-05 | Nam | Hải Phòng | CNTT2023B |
| SV2023005 | Hoàng Thị Em | 2005-09-18 | Nữ | Cần Thơ | CNTT2023B |
| SV2023006 | Võ Văn Phúc | 2005-04-25 | Nam | Huế | CNTT2023B |
| SV2024001 | Đặng Thị Giang | 2006-02-14 | Nữ | Nghệ An | CNTT2024A |
| SV2024002 | Bùi Văn Hùng | 2006-06-30 | Nam | Thanh Hóa | CNTT2024A |
| SV2024003 | Ngô Thị Lan | 2006-08-12 | Nữ | Bình Dương | CNTT2024A |
| SV2023007 | Lý Văn Kiên | 2005-12-20 | Nam | Quảng Ninh | KTPM2023A |
| SV2023008 | Mai Thị Linh | 2005-05-17 | Nữ | Nam Định | KTPM2023A |
| SV2023009 | Đỗ Văn Mạnh | 2005-10-08 | Nam | Hà Tĩnh | KTPM2023A |
| SV2024004 | Trương Thị Nga | 2006-03-22 | Nữ | Vĩnh Phúc | KTPM2024A |
| SV2024005 | Phan Văn Ổn | 2006-07-15 | Nam | Bắc Ninh | KTPM2024A |
| SV2023010 | Dương Thị Phương | 2005-04-11 | Nữ | Thái Bình | KHMT2023A |
| SV2023011 | Tạ Văn Quang | 2005-09-28 | Nam | Ninh Bình | KHMT2023A |
| SV2024006 | Hồ Thị Rạng | 2006-01-19 | Nữ | Lào Cai | KHMT2024A |
| SV2024007 | Trịnh Văn Sơn | 2006-11-25 | Nam | Điện Biên | KHMT2024A |
| SV2023012 | Lương Thị Tâm | 2005-06-07 | Nữ | Quảng Bình | HTTT2023A |
| SV2023013 | Vương Văn Uy | 2005-08-14 | Nam | Quảng Trị | HTTT2023A |

## Luồng hoạt động

1. Khởi động ứng dụng → Form Login
2. Nhập tài khoản/mật khẩu → Xác thực
3. Đăng nhập thành công → Form Main
4. Đăng nhập thất bại → Hiển thị thông báo lỗi
5. Trên Form Main: luôn kiểm tra phiên đăng nhập
6. Chưa đăng nhập hoặc đã đăng xuất → Redirect to Login
7. Các chức năng quản lý và tìm kiếm chỉ khả dụng khi đã đăng nhập

## Ghi chú kỹ thuật

- Schema được tạo tự động bởi EF Core `EnsureCreated()` — không cần chạy SQL script thủ công
- Dữ liệu mẫu được seeded tự động khi khởi chạy lần đầu (nếu database trống)
- Session management với static variables
- Tìm kiếm lớp: so sánh trực tiếp với mã lớp (lqlma)
- Tìm kiếm sinh viên: sử dụng `Contains()` được EF Core dịch sang SQL `LIKE`
- Form embedding: sử dụng Panel để hiển thị các form con
- Validation đầy đủ ở cả controller layer
- Transaction support cho data integrity (`db.Database.BeginTransaction()`)

## Tác giả

**Nguyen Tuan Minh** — 4003867

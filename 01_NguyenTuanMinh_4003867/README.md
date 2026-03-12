# H? TH?NG QU?N LÝ SINH VIÊN
**Student Management System - NguyenTuanMinh_4003867**

## Mô t? d? án
?ng d?ng qu?n lý sinh viên ???c xây d?ng b?ng C# Windows Forms v?i .NET 10, s? d?ng SQLite làm c? s? d? li?u.

## ?? Kh?c ph?c v?n ?? ký t? ti?ng Vi?t
?ng d?ng ?ã ???c c?p nh?t ?? x? lý ?úng ký t? ti?ng Vi?t:
- ? S? d?ng UTF-8 encoding trong SQLite
- ? S? d?ng TEXT type cho các tr??ng v?n b?n (SQLite native)
- ? S? d?ng INTEGER cho gi?i tính
- ? Thêm PRAGMA encoding UTF-8
- ? S? d?ng parameterized queries ?? tránh l?i encoding

**N?u g?p v?n ?? v?i d? li?u c?:**
1. Xóa file `StudentManagement.db` trong th? m?c `bin\Debug\net10.0-windows`
2. Ch?y l?i ?ng d?ng ?? t?o database m?i v?i encoding ?úng

## Ki?n trúc
?ng d?ng ???c thi?t k? theo mô hình MVC (Model-View-Controller):

### ?? C?u trúc th? m?c
```
01_NguyenTuanMinh_4003867/
??? Models/                     # L?p mô hình d? li?u
?   ??? SinhVien.cs            # Model sinh viên
?   ??? LopQuanLy.cs           # Model l?p h?c
?   ??? NhomQuyen.cs           # Model nhóm quy?n
?   ??? TaiKhoan.cs            # Model tài kho?n
??? Data/                       # L?p truy xu?t d? li?u
?   ??? DatabaseHelper.cs      # Kh?i t?o và qu?n lý database
?   ??? InitializeDatabase.sql # SQL script cho database schema
?   ??? SinhVienRepository.cs  # Repository cho sinh viên
?   ??? LopQuanLyRepository.cs # Repository cho l?p h?c
?   ??? TaiKhoanRepository.cs  # Repository cho tài kho?n
??? Controllers/                # L?p x? lý logic nghi?p v?
?   ??? SinhVienController.cs  # Controller sinh viên
?   ??? LopQuanLyController.cs # Controller l?p h?c
?   ??? AuthenticationController.cs # Controller xác th?c
??? Views/                      # Giao di?n ng??i dùng
    ??? FormLogin.cs                  # Form ??ng nh?p
    ??? NguyenTuanMinh_4003867.cs     # Form chính
    ??? QuanLyLopForm.cs              # Form qu?n lý l?p
    ??? QuanLySinhVienForm.cs         # Form qu?n lý sinh viên
    ??? TimKiemLopForm.cs             # Form tìm ki?m l?p
    ??? TimKiemSinhVienForm.cs        # Form tìm ki?m sinh viên
```

## C? s? d? li?u

### Qu?n lý Schema
Database schema ???c qu?n lý thông qua file SQL riêng bi?t:
- File: `Data/InitializeDatabase.sql`
- T? ??ng ???c ??c và th?c thi khi kh?i t?o database
- Có fallback n?u file không tìm th?y
- S? d?ng SQLite native types (TEXT, INTEGER)

### B?ng tbl_nhomquyen (Nhóm quy?n)
- `nqma` (INTEGER, PRIMARY KEY AUTOINCREMENT): Mã nhóm quy?n
- `nqten` (TEXT): Tên nhóm quy?n
- `nqmota` (TEXT): Mô t?

### B?ng tbl_taikhoan (Tài kho?n)
- `tktaikhoan` (TEXT, PRIMARY KEY): Tên tài kho?n
- `tkmatkhau` (TEXT): M?t kh?u
- `nqma` (INTEGER, FOREIGN KEY): Mã nhóm quy?n

### B?ng tbl_lopquanly (L?p qu?n lý)
- `lqlma` (TEXT, PRIMARY KEY): Mã l?p
- `lqten` (TEXT): Tên l?p
- `lqkhoahoc` (INTEGER): Khóa h?c

### B?ng tbl_sinhvien (Sinh viên)
- `svma` (TEXT, PRIMARY KEY): Mã sinh viên
- `svten` (TEXT): Tên sinh viên
- `svngaysinh` (TEXT): Ngày sinh (??nh d?ng YYYY-MM-DD)
- `svgioitinh` (INTEGER): Gi?i tính (1=Nam, 0=N?)
- `svquequan` (TEXT): Quê quán
- `lqlma` (TEXT, FOREIGN KEY): Mã l?p

## Tính n?ng chính

### 0. Xác th?c ng??i dùng
- ? Form ??ng nh?p v?i validation
- ? **Hi?n th? rõ ràng thông tin tài kho?n m?u**
- ? Giao di?n ??p v?i màu s?c n?i b?t
- ? Qu?n lý phiên ??ng nh?p
- ? 3 lo?i ng??i dùng: Admin, Employee, User
- ? ??ng xu?t và ??ng nh?p l?i
- ? Ki?m tra xác th?c tr??c khi truy c?p ch?c n?ng
- ? Hi?n th? thông tin ng??i dùng trên thanh tr?ng thái

### 1. Qu?n lý d? li?u
#### Qu?n lý l?p h?c
- ? Thêm l?p h?c m?i
- ? S?a thông tin l?p h?c
- ? Xóa l?p h?c (ki?m tra ràng bu?c sinh viên)
- ? Xem danh sách t?t c? l?p h?c
- ? Click vào kho?ng tr?ng ?? b? ch?n và thêm m?i

#### Qu?n lý sinh viên
- ? Thêm sinh viên m?i
- ? S?a thông tin sinh viên
- ? Xóa sinh viên
- ? Xem danh sách t?t c? sinh viên
- ? L?c l?p qu?n lý qua ComboBox
- ? **Không t? ??ng ch?n sinh viên khi vào form**
- ? **Click vào sinh viên ?? ch?n, click l?i ?? b? ch?n**
- ? **Click vào kho?ng tr?ng ?? b? ch?n**
- ? **Các tr??ng không b? ch?ng l?n (Gi?i tính và Quê quán)**

### 2. Tìm ki?m
#### Tìm ki?m l?p (Chính xác)
- ? Tìm ki?m CHÍNH XÁC theo mã l?p (lqlma)
- ? Hi?n th? s? l??ng sinh viên trong l?p

#### Tìm ki?m sinh viên (G?n ?úng)
- ? Tìm ki?m G?N ?ÚNG theo tên sinh viên (svten)
- ? L?c theo l?p qua ComboBox
- ? H? tr? tìm ki?m m?t ph?n tên

## Validation (Ki?m tra d? li?u)

### ??ng nh?p
- Tên ??ng nh?p: Không ???c tr?ng
- M?t kh?u: Không ???c tr?ng
- Thông báo l?i: "??ng nh?p th?t b?i" n?u sai thông tin

### L?p h?c
- Mã l?p: Không ???c tr?ng, t?i ?a 10 ký t?
- Tên l?p: Không ???c tr?ng, t?i ?a 50 ký t?
- Khóa h?c: Ph?i trong kho?ng 2000 ??n n?m hi?n t?i + 1
- Không cho phép xóa l?p còn sinh viên

### Sinh viên
- Mã sinh viên: Không ???c tr?ng, t?i ?a 10 ký t?
- Tên sinh viên: Không ???c tr?ng, t?i ?a 50 ký t?
- Ngày sinh: Không ???c l?n h?n ngày hi?n t?i
- Tu?i: Ph?i trong kho?ng 15-100 tu?i
- Quê quán: T?i ?a 50 ký t?
- Mã l?p: Ph?i t?n t?i trong h? th?ng

## Giao di?n
- ? T?t c? label và field ??u b?ng ti?ng Vi?t
- ? Giao di?n t? ??ng ?i?u ch?nh theo kích th??c c?a s? (Anchor & Dock)
- ? DataGridView v?i AutoSizeColumnsMode ?? t? ??ng ?i?u ch?nh c?t
- ? Responsive layout v?i GroupBox và Panel
- ? **Form ??ng nh?p ???c c?i ti?n:**
  - ? Kích th??c l?n h?n (700x550)
  - ? Hi?n th? rõ ràng thông tin tài kho?n demo
  - ? Nút ??ng nh?p có màu n?i b?t
  - ? S? d?ng font Consolas cho thông tin tài kho?n
  - ? Checkbox hi?n th? m?t kh?u
- ? **Form qu?n lý sinh viên:**
  - ? Các tr??ng ???c phân cách rõ ràng
  - ? Không t? ??ng ch?n sinh viên khi m?
  - ? Click l?i sinh viên ?ã ch?n ?? b? ch?n
- ? Thanh tr?ng thái hi?n th? thông tin ng??i dùng

## Công ngh? s? d?ng
- **Framework**: .NET 10
- **UI**: Windows Forms
- **Database**: SQLite (v?i UTF-8 encoding)
- **Database Schema**: SQL script file (InitializeDatabase.sql)
- **ORM**: Microsoft.Data.Sqlite 10.0.0
- **Design Pattern**: MVC (Model-View-Controller)

## Cách ch?y ?ng d?ng
1. M? solution trong Visual Studio
2. Khôi ph?c NuGet packages (t? ??ng)
3. Build solution (Ctrl + Shift + B)
4. Run application (F5)

Database s? ???c t?o t? ??ng trong th? m?c bin khi kh?i ch?y l?n ??u v?i tên `StudentManagement.db`

## D? li?u m?u

### ?? Tài kho?n (Hi?n th? rõ ràng trên Form Login)
| Username | Password | Role | Mô t? |
|----------|----------|------|-------|
| **admin** | **123456** | Admin | Qu?n tr? viên - Toàn quy?n h? th?ng |
| **employee** | **123456** | Employee | Nhân viên - Qu?n lý sinh viên và l?p h?c |
| **user** | **123456** | User | Ng??i dùng - Ch? xem thông tin |

### L?p h?c (8 l?p)
| Mã l?p | Tên l?p | Khóa h?c |
|--------|---------|----------|
| CNTT2023A | Công ngh? thông tin 2023A | 2023 |
| CNTT2023B | Công ngh? thông tin 2023B | 2023 |
| CNTT2024A | Công ngh? thông tin 2024A | 2024 |
| KTPM2023A | K? thu?t ph?n m?m 2023A | 2023 |
| KTPM2024A | K? thu?t ph?n m?m 2024A | 2024 |
| KHMT2023A | Khoa h?c máy tính 2023A | 2023 |
| KHMT2024A | Khoa h?c máy tính 2024A | 2024 |
| HTTT2023A | H? th?ng thông tin 2023A | 2023 |

### Sinh viên (20 sinh viên)
| Mã SV | Tên sinh viên | Ngày sinh | Gi?i tính | Quê quán | L?p |
|-------|---------------|-----------|-----------|----------|-----|
| SV2023001 | Nguy?n V?n Anh | 2005-03-15 | Nam | Hà N?i | CNTT2023A |
| SV2023002 | Tr?n Th? B?o | 2005-07-22 | N? | H? Chí Minh | CNTT2023A |
| SV2023003 | Lê Minh Châu | 2005-01-10 | N? | ?à N?ng | CNTT2023A |
| SV2023004 | Ph?m Qu?c D?ng | 2005-11-05 | Nam | H?i Phòng | CNTT2023B |
| SV2023005 | Hoàng Th? Em | 2005-09-18 | N? | C?n Th? | CNTT2023B |
| SV2023006 | Võ V?n Phúc | 2005-04-25 | Nam | Hu? | CNTT2023B |
| SV2024001 | ??ng Th? Giang | 2006-02-14 | N? | Ngh? An | CNTT2024A |
| SV2024002 | Bùi V?n Hùng | 2006-06-30 | Nam | Thanh Hóa | CNTT2024A |
| SV2024003 | Ngô Th? Lan | 2006-08-12 | N? | Bình D??ng | CNTT2024A |
| SV2023007 | Lý V?n Kiên | 2005-12-20 | Nam | Qu?ng Ninh | KTPM2023A |
| SV2023008 | Mai Th? Linh | 2005-05-17 | N? | Nam ??nh | KTPM2023A |
| SV2023009 | ?? V?n M?nh | 2005-10-08 | Nam | Hà T?nh | KTPM2023A |
| SV2024004 | Tr??ng Th? Nga | 2006-03-22 | N? | V?nh Phúc | KTPM2024A |
| SV2024005 | Phan V?n ?n | 2006-07-15 | Nam | B?c Ninh | KTPM2024A |
| SV2023010 | D??ng Th? Ph??ng | 2005-04-11 | N? | Thái Bình | KHMT2023A |
| SV2023011 | T? V?n Quang | 2005-09-28 | Nam | Ninh Bình | KHMT2023A |
| SV2024006 | H? Th? R?ng | 2006-01-19 | N? | Lào Cai | KHMT2024A |
| SV2024007 | Tr?nh V?n S?n | 2006-11-25 | Nam | ?i?n Biên | KHMT2024A |
| SV2023012 | L??ng Th? Tâm | 2005-06-07 | N? | Qu?ng Bình | HTTT2023A |
| SV2023013 | V??ng V?n Uy | 2005-08-14 | Nam | Qu?ng Tr? | HTTT2023A |

## Lu?ng ho?t ??ng
1. Kh?i ??ng ?ng d?ng ? Form Login (hi?n th? rõ thông tin tài kho?n)
2. Nh?p tài kho?n/m?t kh?u ? Xác th?c
3. N?u ??ng nh?p thành công ? Form Main
4. N?u th?t b?i ? Hi?n th? "??ng nh?p th?t b?i"
5. Trên Form Main: Luôn ki?m tra phiên ??ng nh?p
6. N?u ch?a ??ng nh?p ho?c ?ã ??ng xu?t ? Redirect to Login
7. Các ch?c n?ng qu?n lý và tìm ki?m ch? kh? d?ng khi ?ã ??ng nh?p

## ?? C?i ti?n Form Qu?n lý Sinh viên
- **Không t? ??ng ch?n**: Khi m? form, không có sinh viên nào ???c ch?n
- **Click ?? ch?n**: Click vào sinh viên trong danh sách ?? ch?n
- **Click l?i ?? b? ch?n**: Click vào sinh viên ?ã ch?n ?? b? ch?n và xóa thông tin
- **Click kho?ng tr?ng**: Click vào vùng tr?ng trong DataGridView ?? b? ch?n
- **Các tr??ng rõ ràng**: Gi?i tính và Quê quán ???c phân cách ?úng, không b? ch?ng l?n

## ?? Kh?c ph?c s? c?

### V?n ??: Ký t? ti?ng Vi?t hi?n th? d?u ?
**Gi?i pháp:**
1. Xóa file database c?: `bin\Debug\net10.0-windows\StudentManagement.db`
2. Ch?y l?i ?ng d?ng
3. Database m?i s? ???c t?o t? file SQL script v?i encoding ?úng

### V?n ??: SQL syntax errors
**?ã kh?c ph?c:**
- S? d?ng SQLite native types (TEXT, INTEGER) thay vì NVARCHAR, NCHAR
- B? NOT NULL không c?n thi?t
- S? d?ng TEXT cho ngày tháng (SQLite không có DATE type riêng)

## Tác gi?
**Nguyen Tuan Minh** - 4003867

## Ghi chú k? thu?t
- Database ???c l?u trong th? m?c bin c?a ?ng d?ng
- **Database schema ???c qu?n lý qua file SQL riêng (InitializeDatabase.sql)**
- **UTF-8 encoding ???c c?u hình ?úng cho ký t? ti?ng Vi?t**
- **S? d?ng TEXT type cho text fields (SQLite native)**
- **S? d?ng INTEGER cho boolean (gi?i tính)**
- **S? d?ng TEXT cho date fields (??nh d?ng YYYY-MM-DD)**
- Session management v?i static variables
- Tìm ki?m chính xác: So sánh tr?c ti?p v?i mã l?p (lqlma)
- Tìm ki?m g?n ?úng: S? d?ng LIKE v?i wildcard (%) cho tên sinh viên (svten)
- Form embedding: S? d?ng Panel ?? hi?n th? các form con
- Validation ??y ?? ? c? client và controller layer
- Transaction support cho data integrity
- **Improved selection behavior**: Re-clicking selected item deselects it
- **20 sinh viên m?u v?i tên ti?ng Vi?t ?a d?ng t? các t?nh thành khác nhau**

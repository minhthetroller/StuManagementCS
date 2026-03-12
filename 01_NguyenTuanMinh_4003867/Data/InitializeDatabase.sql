-- Bảng Nhóm quyền
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_nhomquyen')
BEGIN
    CREATE TABLE tbl_nhomquyen (
        nqma INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
        nqten NVARCHAR(50) NOT NULL,
        nqmota TEXT NULL
    );
END
GO

-- Bảng Tài khoản
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_taikhoan')
BEGIN
    CREATE TABLE tbl_taikhoan (
        tktaikhoan NVARCHAR(30) PRIMARY KEY NOT NULL,
        tkmatkhau NVARCHAR(30) NOT NULL,
        nqma INT NOT NULL,
        CONSTRAINT FK_taikhoan_nhomquyen FOREIGN KEY (nqma) REFERENCES tbl_nhomquyen(nqma)
    );
END
GO

-- Bảng Lớp quản lý
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_lopquanly')
BEGIN
    CREATE TABLE tbl_lopquanly (
        lqlma NCHAR(10) PRIMARY KEY NOT NULL,
        lqten NVARCHAR(50) NOT NULL,
        lqkhoahoc INT NOT NULL
    );
END
GO

-- Bảng Sinh viên
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_sinhvien')
BEGIN
    CREATE TABLE tbl_sinhvien (
        svma NCHAR(10) PRIMARY KEY NOT NULL,
        svten NVARCHAR(50) NOT NULL,
        svngaysinh DATE NULL,
        svgioitinh TINYINT NULL,
        svquequan NVARCHAR(50) NULL,
        lqlma NCHAR(10) NOT NULL,
        CONSTRAINT FK_sinhvien_lopquanly FOREIGN KEY (lqlma) REFERENCES tbl_lopquanly(lqlma)
    );
END
GO

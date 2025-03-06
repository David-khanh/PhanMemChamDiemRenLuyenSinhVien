CREATE DATABASE QL_DiemRL
go

USE QL_DiemRL
go

CREATE TABLE Luong
(
    IdLuong INT PRIMARY KEY IDENTITY(1,1),
    TenLuong NVARCHAR(255) 
);


CREATE TABLE Taikhoan
(
    Idtaikhoan INT PRIMARY KEY IDENTITY(1,1),
    taikhoan NVARCHAR(255) NOT NULL,
    matkhau NVARCHAR(255) NOT NULL,
    IdLuong INT FOREIGN KEY REFERENCES Luong(IdLuong)
);



CREATE TABLE Khoa (
    maKhoa INT IDENTITY(1,1) PRIMARY KEY,
    tenKhoa NVARCHAR(255) NOT NULL
);


CREATE TABLE Lop (
    maLop INT IDENTITY(1,1) PRIMARY KEY,
    tenLop NVARCHAR(255) NOT NULL,
    maKhoa INT FOREIGN KEY REFERENCES Khoa(maKhoa)
);


CREATE TABLE SinhVien (
    maSV int PRIMARY KEY,
    hoTen NVARCHAR(255) NOT NULL,
    ngaySinh DATE NOT NULL,
    diaChi NVARCHAR(255) NOT NULL,
    soDienThoai NVARCHAR(20) NOT NULL,
    matKhau NVARCHAR(255) NOT NULL,
    maLop INT FOREIGN KEY REFERENCES Lop(maLop)
);


-- Bảng TieuChi
CREATE TABLE TieuChi (
    maTieuChi INT IDENTITY(1,1) PRIMARY KEY,
    tenTieuChi NVARCHAR(max),
    diemToiDa INT
);

-- Bảng NoiDung 
CREATE TABLE NoiDung (
    maNoiDung INT IDENTITY(1,1) PRIMARY KEY,
    tenNoiDung NVARCHAR(max),
    diemToiDa INT,
    maTieuChi INT FOREIGN KEY REFERENCES TieuChi(maTieuChi)
);

-- Bảng PhieuCham
CREATE TABLE PhieuCham (
    maPhieuCham INT IDENTITY(1,1) PRIMARY KEY,
    ngayLap DATE,
    nienKhoa NVARCHAR(10),
    hocKi NVARCHAR(10)
);

-- Bảng ChiTieuPhieuCham
CREATE TABLE ChiTieuPhieuCham (
    maPhieuCham INT ,
    maTieuChi INT ,
    maNoiDung INT ,
    diemRL1 INT,
    diemL2 INT,
    diemL3 INT,
    PRIMARY KEY (maPhieuCham, maTieuChi, maNoiDung) ,
    FOREIGN KEY (maPhieuCham) REFERENCES PhieuCham(maPhieuCham) ,
    FOREIGN KEY (maTieuChi) REFERENCES TieuChi(maTieuChi),
    FOREIGN KEY (maNoiDung) REFERENCES NoiDung(maNoiDung)
);

-- Bảng ChamDiemRL
CREATE TABLE ChamDiemRL (
    maSV INT,
    maPhieuCham INT,
    diemRL INT,
    PRIMARY KEY (maSV, maPhieuCham),
    FOREIGN KEY (maPhieuCham) REFERENCES PhieuCham(maPhieuCham),
	FOREIGN KEY (maSV) REFERENCES SinhVien(maSV)
);

-- Thêm dữ liệu vào bảng Roles
INSERT INTO Luong (TenLuong) VALUES
('Admin'),
(N'Giảng Viên')


delete from Taikhoan
-- Thêm dữ liệu vào bảng Users
INSERT INTO Taikhoan(taikhoan, matkhau, IdLuong) VALUES
('giangvien', '123', 2),
('admin', '123', 1)

-- Thêm dữ liệu vào bảng Khoa
INSERT INTO Khoa (tenKhoa) VALUES
(N'Công Nghệ Thông Tin'),
(N'Kinh Tế'),
(N'Luật'),
(N'Xây Dựng'),
(N'Ngoại Ngữ');

-- Thêm dữ liệu vào bảng Lop
INSERT INTO Lop (tenLop, maKhoa) VALUES
('DH21TIN02', 1),
('DH21KTO01', 2),
('DH21LUA01', 3),
('DH21LXD01', 4),
('DH21NNA01', 5);

-- Thêm dữ liệu vào bảng SinhVien
INSERT INTO SinhVien (maSV, hoTen, ngaySinh, diaChi, soDienThoai, matKhau, maLop) VALUES
('211095', N'Lê Trần Tuấn Khanh', '2003-09-09', N'Giổng riềng, Kiên Giang', '0987654321', '211095', 1),
('211124', N'Trần Trung Kiên', '2003-02-02', N'Ngã năm, Sóc Trăng', '0123456789', '211124', 1),
('003', N'Trần Văn C', '2002-03-03', N'789 Đường GHI, Thành phố RST', '0987123456', '789', 1),
('004', N'Phạm Thị D', '2003-04-04', N'159 Đường JKL, Thành phố MNO', '0123789456', 'passwordabc', 2),
('005', N'Hoàng Văn E', '2004-05-05', N'357 Đường PQR, Thành phố STU', '0987456123', 'passworddef', 2);



insert into TieuChi(tenTieuChi,diemToiDa) VALUES
(N'Ý thức và kết quả học tập',20),
(N'Ý thức và kết quả chấp hành nội quy, quy chế trong cơ sở giáo dục đại học',25),
(N'Ý thức và kết quả tham gia các hoạt động chính trị, xã hội, văn hóa, văn nghệ, thể thao, phòng chống tội phạm và các tệ nạn xã hội',20),
(N'Phẩm chất công dân và quan hệ cộng đồng',25),
(N'Ý thức và kết quả tham gia phụ trách lớp',10);

insert into NoiDung(tenNoiDung,maTieuChi,diemToiDa) Values
(N'Kết quả học tập (Xuất sắc: +15đ, Giỏi: +12đ, Khá: +10đ, TB Khá: +8đ, Trung bình: +5đ)',1,15),
(N' Xếp loại học tập tăng ….bậc, từ…….lên…....(+3đ, +5đ)',1,5),
(N'Có tham gia nghiên cứu khoa học (+5đ)',1,5),
(N'Có tham gia các câu lạc bộ học thuật (Anh văn, Tin học…) (+4đ)',1,4),
(N'Không vi phạm quy chế thi (+5đ)',1,5),
(N'Nghỉ học không phép (– 01điểm/01 buổi)',1,-5),
(N'Nghỉ học có phép (– 01điểm/05 buổi)',1,-2),
(N'Có thái độ học tập chưa tốt (Giảng viên mời ra khỏi lớp, ……..) mỗi lần vi phạm (- 5đ/lần)',1,-10),




(N'Ý thức chấp hành các văn bản của ngành, cơ quan chỉ đạo cấp trên (Đăng ký nội trú, ngoại trú, khám sức khỏe, Phiếu QLSV, hồ sơ nhập học, đóng học phí, tham gia BHYT) (+10đ)  ',2,10),
(N'Tham gia các buổi sinh hoạt của Lớp (mỗi lần được +0.5đ/lần sinh hoạt)
(Mỗi học kỳ cộng không quá 5đ)',2,5),
(N'Tham gia các buổi sinh hoạt của Lớp (mỗi lần được +0.5đ/lần sinh hoạt)
(Mỗi học kỳ cộng không quá 5đ)',2,5),
(N'Đánh giá giảng dạy của giảng viên +(1đ - 5đ)',2,5),
(N'Đánh giá giáo viên chủ nhiệm (+3đ)',2,3),
(N'Sinh viên nghiên cứu và học tập tại Thư viện (+0.5 đ/lần) (Mỗi học kỳ cộng không quá 5đ)',2,5),
(N'Vi phạm các nội quy, quy chế của trường, của Ký túc xá, vi phạm quy chế thi:
Vi phạm bị lập biên bản: (- 5đ/lần)',2,-10),


(N'Là thành viên CLB (ngoại trừ CLB học thuật) (+4đ) (Có xác nhận của lãnh đạo Câu lạc bộ)',3,4),
(N'Tham gia các hoạt động rèn luyện, chính trị, tư tưởng:
-Tham gia các hội thi do Bộ GDĐT, Đoàn, Hội tổ chức (+5đ/lần)
Tham dự chuyên đề do nhà Trường tổ chức (đối thoại, ngày hội việc làm…) (+5đ/lần)',3,10),
(N'Được chọn tham gia đội tuyển của trường đi dự thi (+3đ)',3,3),
(N'Có tham dự (mít tinh, các ngày lễ, ngày hội, tuần hành, cổ động…) do nhà trường, Đoàn, Hội cử đi (+3đ/lần) ',3,9),
(N'Tham gia các hội thi: văn hoá, văn nghệ, thể dục, thể thao do trường tổ chức:
-Tham gia cổ vũ, hỗ trợ (+1đ/lần)
-Tham gia dự thi, là thành viên trong Ban tổ chức (+3đ/lần tổ chức)
-Tham gia đạt giải (Khuyến khích:+2đ, Ba:+3đ, Nhì:+4đ, Nhất:+5đ)
(Có minh chứng kèm theo)
 Đăng ký mà không dự, không có lý do chính đáng (-5đ/lần)',3,20),
(N'Sinh viên tham gia nghiên cứu khoa học đạt giải: (Nhất:+10đ, Nhì:+8đ, Ba:+6đ)',3,10),
(N'Tham gia tuyên truyền và không vi phạm tệ nạn xã hội trong và ngoài trường (+6đ)',3,6),






(N'Trực tiếp tham gia các hoạt động tình nguyện:
-Tham gia hiến máu nhân đạo (+10đ) (Có minh chứng kèm theo)
Tham gia chiến dịch mùa hè xanh, các chiến dịch khác (+10đ) (Có minh chứng kèm theo)',4,20),
(N'Tham gia công ích, công tác xã hội cấp Lớp, cấp trường:
-Tham gia vệ sinh công ích (+3đ/lần)
-Tham gia các hoạt động xã hội (Tổ chức trung thu, thăm trẻ mồ côi và người già neo đơn, quyên góp giúp đỡ những hoàn cảnh khó khăn…..) (+5đ/lần)
 (Có minh chứng kèm theo)
 Đăng ký mà không dự, không có lý do chính đáng (-5đ/lần)',4,20),
(N' Không vi phạm quyền và nghĩa vụ của sinh viên theo quy định của Bộ GD&ĐT (+5đ)',4,5),
(N'Tham gia các hoạt động xã hội ở địa phương (Có giấy xác nhận) (+5đ)',4,5),
(N'Ý thức tham gia các hoạt động xã hội, hoạt động học tập của trường, của địa phương được biểu dương, khen thưởng (Có giấy khen) (+10đ)',4,10),



(N'Hoạt động của Lớp trưởng, Bí thư chi đoàn, BCH đoàn trường, BCH HSV, Đội tự quản 
(XS: +10đ, Tốt: +8đ, Hoàn thành nhiệm vụ (HTNV): +6đ)',5,6),
(N'Hoạt động của Lớp phó, Thủ Quỹ, BCH chi đoàn, BCH Đoàn Khoa, BCH liên chi hội SV (XS: +7đ, Tốt: +6đ, HTNV: +5đ)',5,7),
(N'Hoạt động của Tổ trưởng, tổ phó và các chức danh khác do lớp đặt ra (XS: +6đ, Tốt: +5đ, HTNV: +4đ)',5,6),
(N'Sinh viên đạt danh hiệu sinh viên 5 tốt cấp:Trường(+4đ), Thành phố(+5đ), Trung ương(+6đ)',5,6),
(N'Hoàn thành công việc của Thanh niên tình nguyện, CTV tại các Phòng, Ban, Trung Tâm +(4đ) (Phòng, Ban, TT đánh giá)',5,4),
(N'Đề tài nghiên cứu khoa học được hội đồng Khoa học cấp trường công nhận (+8đ)',5,8);
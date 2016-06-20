CREATE DATABASE Exercise1
GO
USE Exercise1

--Q1
CREATE TABLE San_Pham(
 Ma_SP int PRIMARY KEY ,
 Ten_SP nvarchar(200),
 Don_Gia money,
 Ma_KH int
)

CREATE TABLE Khach_Hang(
 Ma_KH int PRIMARY KEY,
 Ten_KH nvarchar(200),
 Phone_No varchar(12),
 Ghi_Chu ntext
)

CREATE TABLE Don_Hang(
 Ma_DH int PRIMARY KEY,
 Ngay_DH datetime,
 Ma_SP int,
 So_Luong int
)

ALTER TABLE San_Pham ADD CONSTRAINT FK_Ma_KH FOREIGN KEY (Ma_KH) REFERENCES Khach_Hang(Ma_KH)
ALTER TABLE Don_Hang ADD CONSTRAINT FK_Ma_SP FOREIGN KEY (Ma_SP) REFERENCES San_Pham(Ma_SP)

INSERT INTO Khach_Hang VALUES('1' , 'Nguyen Van Trong' ,'0123456789','Không')
INSERT INTO Khach_Hang VALUES('2','Tran Trung Tuyen' , '0987654321','Không')
INSERT INTO Khach_Hang VALUES('3', 'Mai Anh' , '0912345678','Không')

INSERT INTO San_Pham VALUES ('1','Ao','20000','1')
INSERT INTO San_Pham VALUES ('2','Mu','30000','2')
INSERT INTO San_Pham VALUES ('3','Giay','10000','3')

INSERT INTO Don_Hang VALUES('1','2014-2-28','1','2')
INSERT INTO Don_Hang VALUES('2','2014-3-30','2','3')
INSERT INTO Don_Hang VALUES('3','2014-4-27','3','4')

--Q2
GO
CREATE VIEW KhachHangMuaHang AS
SELECT Ten_KH, Ngay_DH, Ten_SP, So_Luong, (Don_Gia * So_Luong) AS Thanh_Tien 
FROM (Don_Hang LEFT JOIN San_Pham ON Don_Hang.Ma_SP = San_Pham.Ma_SP ) LEFT JOIN Khach_Hang ON San_Pham.Ma_KH = Khach_Hang.Ma_KH

GO
SELECT * FROM KhachHangMuaHang


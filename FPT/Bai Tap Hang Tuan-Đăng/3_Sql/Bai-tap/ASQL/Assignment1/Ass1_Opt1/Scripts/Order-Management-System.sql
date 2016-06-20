--1--
CREATE TABLE Khach_Hang
(
	Ma_KH int Identity(1,1) NOT NULL PRIMARY KEY,
	Ten_KH nvarchar(50) NOT NULL,
	Phone_No varchar(15) NOT NULL CHECK(Phone_No NOT LIKE '%[^0-9]%'),
	Ghi_Chu nvarchar(100)
)

CREATE TABLE San_Pham
(
	Ma_SP int Identity(1,1) NOT NULL PRIMARY KEY,
	Ten_SP nvarchar(50) NOT NULL,
	Don_Gia money NOT NULL,
	Ma_KH int NOT NULL REFERENCES Khach_Hang(Ma_KH)
)

CREATE TABLE Don_Hang
(
	Ma_DH int Identity(1,1) NOT NULL PRIMARY KEY,
	Ngay_DH date NOT NULL,
	Ma_SP int NOT NULL REFERENCES San_Pham(Ma_SP),
	So_Luong int NOT NULL
)

GO

INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Nguyễn Hải Đăng', '01627927829', N'Vip')
INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Phạm Thanh Hiền', '0123456789', N'Normal')
INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Lê Quang Vinh', '01655450125', N'Normal')

INSERT INTO San_Pham(Ten_SP, Don_Gia, Ma_KH) VALUES(N'Lumia 435', 1700000, 2)
INSERT INTO San_Pham(Ten_SP, Don_Gia, Ma_KH) VALUES(N'Laptop Dell 5420', 13000000, 1)
INSERT INTO San_Pham(Ten_SP, Don_Gia, Ma_KH) VALUES(N'Nokia 1202', 300000, 3)

SET DATEFORMAT DMY;
INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong) VALUES('22/07/2015', 1, 1)
INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong) VALUES('20/07/2015', 2, 2)
INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong) VALUES('15/07/2015', 3, 3)

GO


--2--
CREATE VIEW dbo.view_Don_Hang
AS
SELECT Don_Hang.Ma_DH
	, Don_Hang.Ngay_DH
	, San_Pham.Ten_SP
	, Don_Hang.So_Luong
	, (San_Pham.Don_Gia * Don_Hang.So_Luong) AS Thanh_Tien
FROM Don_Hang, Khach_Hang, San_Pham
WHERE Don_Hang.Ma_SP = San_Pham.Ma_SP
	AND San_Pham.Ma_KH = Khach_Hang.Ma_KH


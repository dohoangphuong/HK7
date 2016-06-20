CREATE DATABASE FSOFT_ASS2
USE  FSOFT_ASS2
GO
CREATE TABLE EMPLOYEE
(
	EmpNo int primary key,
	EmpName nvarchar(50),
	BirthDay datetime,
	DeptNo int,
	MgrNo int not null,
	StartDate datetime ,
	Salary money,
	Level int ,				
	Status int,				
	Note  nvarchar(100)
)
GO 
CREATE TABLE SKILL
(
	SkillNo int primary key,
	SkillName nvarchar(50),
	Note nvarchar(100)
)

GO
CREATE TABLE DEPARTMENT 
(
	DeptNo int primary key,
	DeptName nvarchar(50),
	Note nvarchar(100)
)

GO
CREATE TABLE EMP_SKILL
(
	SkillNo int foreign key (SkillNo) references SKILL(SkillNo) not null,
	EmpNo  int foreign key (EmpNo) references EMPLOYEE(EmpNo) not null,
	SkillLevel int ,
	RegDate Datetime,
	Description nvarchar(100),
	constraint PK_ES primary key (SkillNo,EmpNo)
)

GO
-----Question 2:
ALTER TABLE EMPLOYEE ADD  Email nvarchar(50)
ALTER TABLE EMPLOYEE ADD CONSTRAINT uniqe_abc UNIQUE(Email)
ALTER TABLE EMPLOYEE ADD CONSTRAINT def_abc DEFAULT 0 FOR MgrNo

----Question 3: 
ALTER TABLE EMPLOYEE ADD CONSTRAINT FK_Dep FOREIGN KEY (DeptNo) REFERENCES DEPARTMENT(DeptNo)
ALTER TABLE EMP_SKILL DROP COLUMN Description

----Question 4:
INSERT INTO DEPARTMENT VALUES (12, N'Marketing',N'PR, Marketting')
INSERT INTO DEPARTMENT VALUES (13, N'Tài chính',N'Quản lý tài chính')
INSERT INTO DEPARTMENT VALUES (11, N'Nhân sự',N'Quản lý nhân sự')
INSERT INTO DEPARTMENT VALUES (15, N'Software Develop',N'phát triển phần mềm')
INSERT INTO DEPARTMENT VALUES (14, N'Kế toán', N'kế toán')
INSERT INTO DEPARTMENT VALUES (16, N'Game Develop',N'Phát triển game')
----------

INSERT INTO EMPLOYEE VALUES (11, N'Nguyễn Hoàng Long', 10/04/1991,1, 2, 25/06/2012, 8000000, 4, 0, N'Nhân viên',N'long@gmail.com')
INSERT INTO EMPLOYEE VALUES (12, N'Bùi Anh Tuấn', 16/05/1991,1, 2, 25/06/2012, 9000000, 4, 0, N'Trưởng phòng',N'tuan@gmail.com')
INSERT INTO EMPLOYEE VALUES (13, N'Nguyễn Trung Lâm', 06/04/1992,1, 2, 25/06/2014, 7000000, 4, 0,N'ok', N'lam@gmail.com')
INSERT INTO EMPLOYEE VALUES (14, N'Trần Cẩm Quốc', 01/12/1991,1, 2, 25/06/2012, 9000000, 4, 0, N'intelligent',N'quoc@yahoo.com')
INSERT INTO EMPLOYEE VALUES (15, N'Lâm Lý Bằng', 29/04/1993,1, 2, 25/06/2012, 9000000, 4, 0, N'good',N'bang@gmail.com')
---------
INSERT INTO SKILL VALUES( 11,N'Lập Trình',N'Thành thạo')
INSERT INTO SKILL VALUES( 11,N'Thuyết trình',N'bắt buộc')
INSERT INTO SKILL VALUES( 12,N'Đàm phán',N'Quản lý')
INSERT INTO SKILL VALUES( 13,N'Lập trình',N'Developer')
INSERT INTO SKILL VALUES( 14,N'Test',N'Tester')
INSERT INTO SKILL VALUES( 15,N'Design',N'Developer,Manager,Designer')
-----------
INSERT INTO EMP_SKILL VALUES (11,12,2,21/3/2008)
INSERT INTO EMP_SKILL VALUES (12,13,2,11/4/2009)
INSERT INTO EMP_SKILL VALUES (13,15,2,8/4/2006)
INSERT INTO EMP_SKILL VALUES (14,15,2,3/4/2007)
INSERT INTO EMP_SKILL VALUES (15,13,2,4/2/2008)

------

SELECT			EmpNo, EmpName, Level
FROM			EMPLOYEE
WHERE			Level >=3 and Level <=5

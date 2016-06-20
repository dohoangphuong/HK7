CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NOT NULL,
	[EmpName] [nchar](30) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[DeptNo] [int] NOT NULL, 
	[MgrNo] [nchar](10) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Salary] [money] NOT NULL,
	[Status] [int] NOT NULL,
	[Note] [nchar](100) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NULL,
	[Level] [int] NOT NULL

) ON [PRIMARY]
GO

ALTER TABLE Employee 
ADD CONSTRAINT PK_Emp PRIMARY KEY (EmpNo)
GO

ALTER TABLE [dbo].[Employee]  ADD  CONSTRAINT [chk_Level] CHECK  (([Level]=(7) OR [Level]=(6) OR [Level]=(5) OR [Level]=(4) OR [Level]=(3) OR [Level]=(2) OR [Level]=(1)))
GO
ALTER TABLE [dbo].[Employee]  ADD  CONSTRAINT [chk_Status] CHECK  (([Status]=(2) OR [Status]=(1) OR [Status]=(0)))
GO

ALTER TABLE [dbo].[Employee]
ADD Email NCHAR(30) 
GO

ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT chk_Email CHECK (Email IS NOT NULL)
GO

ALTER TABLE [dbo].[Employee] ADD CONSTRAINT chk_Email1 UNIQUE(Email)
GO
ALTER TABLE Employee
ADD CONSTRAINT DF_EmpNo DEFAULT 0 FOR EmpNo
GO

ALTER TABLE Employee
ADD CONSTRAINT DF_Status DEFAULT 0 FOR Status
GO

CREATE TABLE [dbo].[Skill](
	[SkillNo] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nchar](30) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Note] [nchar](100) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

ALTER TABLE Skill
ADD CONSTRAINT PK_Skill PRIMARY KEY (SkillNo)
GO

CREATE TABLE [dbo].[Department](
	[DeptNo] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nchar](30) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Note] [nchar](100) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

ALTER TABLE Department
ADD CONSTRAINT PK_Dept PRIMARY KEY (DeptNo)
GO

CREATE TABLE [dbo].[Emp_Skill](
	[SkillNo] [int] NOT NULL,
	[EmpNo] [int] NOT NULL,
	[SkillLevel] [int] NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[Description] [nchar](100) COLLATE 
	SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

ALTER TABLE Emp_Skill
ADD CONSTRAINT PK_Emp_Skill PRIMARY KEY (SkillNo, EmpNo)
GO

ALTER TABLE Employee  ADD  CONSTRAINT [FK_1] FOREIGN KEY([DeptNo])
REFERENCES Department (DeptNo)
GO

--a--
INSERT INTO dbo.Department(DeptName, Note) VALUES('Software Engineering', 'SE')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Network and Telecommunication', 'NT')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Information System', 'IS')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Computer Engineering', 'CE')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Computer Science', 'CS')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Infomation Scecurity', 'IS')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Infomation Engineering', 'IE')
INSERT INTO dbo.Department(DeptName, Note) VALUES('E-Commerce', 'E-Com')

SET DATEFORMAT DMY;
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(1, N'Nguyễn Hải Đăng', '24/08/1994', 1, '12520554', '06/01/2015', 0, 0, 'submit assignment late', 4, N'nguyenhaidang@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(2, N'Lê Quang Vinh', '26/08/1993', 3, '12520510', '06/01/2015', 0, 2, 'take off', 3, N'lequangvinh@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(3, N'Phạm Nam Trường', '13/04/1994', 1, '12520472', '06/07/2015', 0, 0, 'have good ideas', 5, N'phamnamtruong@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(4, N'Hoàng Xuân Thiên', '17/08/1992', 1, '12520411', '06/01/2015', 0, 0, 'good skills', 6, N'hoangxuanthien@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(5, N'Dư Phát Tài', '21/09/1994', 3, '12520367', '06/07/2015', 0, 0, 'good skills', 6, N'duphattai@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(6, N'Đỗ Hoàng Phương', '21/09/1994', 4, '12520324', '06/07/2015', 0, 0, 'good knowledge', 5, N'dohoangphuong@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(7, N'Lê Quang Nhật', '21/09/1994', 4, '12520305', '06/07/2015', 0, 0, 'basic knowledge', 4, N'lequangnhat@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(8, N'Nguyễn Trung Lâm', '21/09/1994', 7, '12520218', '06/07/2015', 0, 0, 'well-done', 5, N'nguyentrunglam@gmail.com')

INSERT INTO SKILL(SkillName, Note) VALUES(N'C++', N'C++ Develop')
INSERT INTO SKILL(SkillName, Note) VALUES(N'JAVA', N'JAVA Develop')
INSERT INTO SKILL(SkillName, Note) VALUES(N'.NET', N'.NET Develop')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Embedded', N'Embedded Develop')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Tester', N'Software Testing')
INSERT INTO SKILL(SkillName, Note) VALUES(N'PHP', N'PHP Develop')
INSERT INTO SKILL(SkillName, Note) VALUES(N'QA', N'Quality Assurance')
INSERT INTO SKILL(SkillName, Note) VALUES(N'IS', N'Information Security')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(1, 1, 2, '06/07/2015', N'Desc11')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 1, 1, '13/07/2015', N'Desc12')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 1, 2, '13/07/2015', N'Desc13')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 2, 2, '06/07/2015', N'Desc21')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 2, 2, '06/07/2015', N'Desc22')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 3, 2, '06/07/2015', N'Desc31')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 3, 2, '06/07/2015', N'Desc32')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 4, 1, '20/07/2015', N'Desc41')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 4, 2, '20/07/2015', N'Desc42')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(1, 5, 3, '06/07/2015', N'Desc51')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 5, 1, '13/07/2015', N'Desc52')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 5, 2, '13/07/2015', N'Desc53')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(1, 6, 2, '06/07/2015', N'Desc61')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 6, 1, '13/07/2015', N'Desc62')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 6, 2, '13/07/2015', N'Desc63')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(1, 7, 2, '06/07/2015', N'Desc71')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 7, 1, '13/07/2015', N'Desc72')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 7, 2, '13/07/2015', N'Desc73')

INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(1, 8, 2, '06/07/2015', N'Desc81')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(2, 8, 1, '13/07/2015', N'Desc82')
INSERT INTO EMP_SKILL([SkillNo], [EmpNo], [SkillLevel], [RegDate], [Description]) VALUES(3, 8, 2, '13/07/2015', N'Desc83')

--b--
SELECT dbo.Employee.EmpName, dbo.Employee.Email, dbo.Department.DeptName
FROM dbo.Employee
	INNER JOIN dbo.Department ON (dbo.Employee.DeptNo = dbo.Department.DeptNo)
WHERE DATEDIFF(month, dbo.Employee.StartDate, GETDATE()) >= 6

--c--
SELECT emp1.EmpName
FROM dbo.Employee emp1
	INNER JOIN dbo.Emp_Skill emp_sk1 ON (emp_sk1.EmpNo = emp1.EmpNo)
	INNER JOIN dbo.Skill sk1 ON (emp_sk1.SkillNo = sk1.SkillNo)
WHERE sk1.SkillName = 'C++'
	AND emp1.EmpNo
		IN
		(
			SELECT emp2.EmpNo
			FROM dbo.Employee emp2
			INNER JOIN dbo.Emp_Skill emp_sk2 ON (emp_sk2.EmpNo = emp2.EmpNo)
			INNER JOIN dbo.Skill sk2 ON (emp_sk2.SkillNo = sk2.SkillNo)
			WHERE sk2.SkillName = '.NET'
		)


--d--
SELECT dbo.Employee.EmpName, dbo.Employee.MgrNo AS Manage_Name, dbo.Employee.Email
FROM dbo.Employee


--e--
SELECT dpm1.DeptName, emp1.EmpName
FROM dbo.Department dpm1
	INNER JOIN Employee emp1
	ON (emp1.DeptNo = dpm1.DeptNo)
WHERE dpm1.DeptNo
	IN
	(
		SELECT dpm2.DeptNo
		FROM Department dpm2
			INNER JOIN Employee emp2
			ON (emp2.DeptNo = dpm2.DeptNo)
		GROUP BY dpm2.DeptNo
		HAVING (COUNT(emp2.EmpNo) >= 2)
	)
ORDER BY (dpm1.DeptNo)


--f--
SELECT dbo.Employee.EmpName, dbo.Emp_Skill.SkillNo
FROM dbo.Employee
	INNER JOIN dbo.Emp_Skill ON (dbo.Emp_Skill.EmpNo = dbo.Employee.EmpNo)
ORDER BY dbo.Employee.EmpName ASC

--g--
SELECT emp1.EmpName, emp1.Email, emp1.BirthDay
FROM dbo.Employee emp1
WHERE emp1.EmpNo IN
	(
		SELECT emp2.EmpNo
		FROM dbo.Employee emp2
			INNER JOIN dbo.Emp_Skill emp_sk ON (emp_sk.EmpNo = emp2.EmpNo)
		WHERE emp2.Status = 0
		GROUP BY (emp2.EmpNo)
	)

GO

--h--
CREATE VIEW dbo.view_EMP_SK_DEPT
AS
SELECT emp.EmpName, sk.SkillName, dept.DeptName
FROM dbo.Employee emp
	INNER JOIN dbo.Emp_Skill emp_sk ON (emp_sk.EmpNo = emp.EmpNo)
	INNER JOIN dbo.Skill sk ON (emp_sk.SkillNo = sk.SkillNo)
	INNER JOIN dbo.Department dept ON (emp.DeptNo = dept.DeptNo)
WHERE emp.Status = 0
CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NOT NULL,
[EmpName] [nchar](30) COLLATE 
SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[DeptNo] [int] NOT NULL, 
	[MgrNo] [int] NOT NULL, 
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
	VALUES(1, N'Nguyễn Hải Đăng', '24/08/1994', 1, '12520554', '06/01/2012', 0, 0, 'submit assignment late', 1, N'nguyenhaidang@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(2, N'Lê Quang Vinh', '26/08/1993', 3, '12520510', '06/01/2015', 0, 2, 'take off', 3, N'lequangvinh@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(3, N'Phạm Nam Trường', '13/04/1994', 1, '12520472', '06/07/2015', 0, 0, 'have good ideas', 5, N'phamnamtruong@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(4, N'Hoàng Xuân Thiên', '17/08/1992', 1, '12520411', '06/01/2012', 0, 0, 'good skills', 1, N'hoangxuanthien@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(5, N'Dư Phát Tài', '21/09/1994', 3, '12520367', '06/07/2015', 0, 0, 'good skills', 6, N'duphattai@gmail.com')
INSERT INTO dbo.Employee([EmpNo], [EmpName], [BirthDay], [DeptNo], [MgrNo], [StartDate], [Salary], [Status], [Note], [Level], [Email])
	VALUES(6, N'Đỗ Hoàng Phương', '21/09/1994', 4, '12520324', '06/07/2012', 0, 0, 'good knowledge', 2, N'dohoangphuong@gmail.com')
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

GO

--b--
CREATE PROC dbo.usp_UPDATE_EMPLOYEE_LEVEL
AS
BEGIN
	UPDATE dbo.Employee
	SET dbo.Employee.Level = 2
	WHERE DATEDIFF(year, dbo.Employee.StartDate, GETDATE()) >= 3
		AND dbo.Employee.Level = 1
END

GO

--c--
CREATE PROC dbo.usp_SELECT_EMPLOYEE
	@EmpNo int = NULL
AS
BEGIN
	SELECT emp.EmpName, emp.Email, dept.DeptName
	FROM dbo.Employee emp
		INNER JOIN dbo.Department dept
			ON emp.DeptNo = dept.DeptNo
	WHERE emp.EmpNo = @EmpNo
END

exec dbo.usp_SELECT_EMPLOYEE 1

GO

--d--
CREATE FUNCTION dbo.ufn_EmpTracking
	(@EmpNo int = NULL)
RETURNS TABLE
AS
	RETURN
		(SELECT emp.EmpName, emp.Salary 
		FROM dbo.Employee emp
		WHERE emp.EmpNo = @EmpNo)

GO

--e--
CREATE TRIGGER dbo.trg_LIMIT_SALARY ON [dbo].[Employee] 
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS
		(
			SELECT 1
			FROM Inserted i
			WHERE i.Level = 1 AND i.Salary > 10000000
		)
		ROLLBACK TRANSACTION		
END
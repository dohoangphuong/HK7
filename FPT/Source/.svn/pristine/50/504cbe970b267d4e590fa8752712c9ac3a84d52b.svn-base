
Create database [ASQL_ASS1_2]
GO
Use [ASQL_ASS1_2]
GO

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


-------------------------------------------------------------------------
--Cau 1
GO
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Nhân Sự','Phòng nhân sự')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Khách Hàng',N'Phòng chăm sóc khách hàng')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Kế Toán',N'Phòng kế toán')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Marketing',N'Phòng marketing')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Phát Triển Phần Mềm',N'Bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Kiểm Thử Phần Mềm',N'Bộ phận Kiểm thử phần mềm')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Bảo Trì Phần Mềm',N'Bộ phận Bảo trì phần mềm')
INSERT INTO [dbo].[Department]([DeptName],[Note])
	VALUES(N'Cài đặt Phần Mềm',N'Bộ phận Cài đặt phần mềm')

GO
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(1,N'Nguyễn Văn A','02/19/1993',1,0,'08/19/2014',10000000,2,0,N'Nhân vật hư cấu','anv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(2,N'Nguyễn Văn B','08/19/1991',4,1,'08/19/2013',11000000,1,0,null,'bnv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(3,N'Nguyễn Văn C','06/19/1993',3,1,'08/19/2014',25000000,5,0,N'Nhân viên xuất sắc','cnv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(4,N'Nguyễn Văn D','07/19/1992',1,1,'08/19/2015',8000000,3,0,N'Sắp bị đuổi','dnv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(5,N'Nguyễn Văn E','08/19/1993',2,1,'08/19/2014',14000000,5,0,N'Chuẩn bị nghỉ hưu','env@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(6,N'Nguyễn Văn F','08/19/1993',4,1,'08/19/2014',14000000,4,0,N'Chuẩn bị nghỉ hưu','fnv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(7,N'Nguyễn Văn G','02/19/1992',2,1,'08/19/2014',14000000,6,0,N'Nhân viên xuất sắc','gnv@gmail.com')
INSERT INTO [dbo].[Employee]([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate],[Salary],[Level],[Status],[Note],[Email])
     VALUES(8,N'Nguyễn Văn H','08/19/1993',2,1,'08/19/2014',14000000,3,0,null,'hnv@gmail.com')

GO
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'Đàm Phán',N'Thường ở bộ phận chăm sóc khách hàng')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'C++',N'Thường ở bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'.Net',N'Thường ở bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'Java',N'Thường ở bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'Marketing',N'Thường ở bộ phận Marketing')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'PHP',N'Thường ở bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'HTML, CSS',N'Thường ở bộ phận Phát triển phần mềm')
INSERT INTO [dbo].[Skill]([SkillName],[Note])
     VALUES(N'Database',N'Thường ở bộ phận Phát triển phần mềm')

GO
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(1,1,1,'08/19/2015','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(4,2,2,'08/19/2014','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(3,3,3,'08/19/2015','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(5,4,3,'08/19/2014','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(2,3,3,'08/19/2014','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(2,2,3,'08/19/2013','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(2,4,1,'08/19/2014','note')
INSERT INTO [dbo].[Emp_Skill]([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description])
     VALUES(4,3,1,'08/19/2014','note')
GO

--------------------------------------------------------------
--cau b
SELECT e.[EmpName], e.[Email], d.[DeptName]
FROM [dbo].[Employee] as e, [dbo].[Department] as d
WHERE DateDiff( MONTH, e.[StartDate] , GetDate()) >= 6  AND e.[DeptNo] = d.[DeptNo] 


--------------------------------------------------------------
--cau c
SELECT DISTINCT e.[EmpName]
FROM [dbo].[Employee] as e, [dbo].[Emp_Skill] as esk, [dbo].[Skill] as sk
WHERE  sk.SkillNo = esk.SkillNo AND e.EmpNo = esk.EmpNo AND (sk.SkillName like '%C++%' OR sk.SkillName like '%.Net%')


--------------------------------------------------------------
--cau d
SELECT DISTINCT e.[EmpName] as [Employee Name], ISNULL(e2.[EmpName],N'Quản Lý Cao Nhất') as [Manager Name],
	 ISNULL(e2.[Email],e.Email) as [Manager Email]
FROM [dbo].[Employee] as e
LEFT JOIN [dbo].[Employee] as e2
ON e.MgrNo = e2.EmpNo

--------------------------------------------------------------
--cau e
GO
SELECT DISTINCT d.[DeptNo] as [Department ID], d.[DeptName] as [Department Name],
	COUNT(e.[EmpNo]) as [Number Employee],
		STUFF((SELECT ', '+ CAST(e1.[EmpNo] as nchar(10))
         FROM [dbo].[Employee] as e1 
         WHERE e1.[DeptNo] = d.[DeptNo]
		 FOR XML PATH('')),1,2,'') as [List Employee ID]
FROM [dbo].[Department] d, [dbo].[Employee] as e
WHERE d.[DeptNo] = e.[DeptNo] AND (SELECT COUNT(e2.[EmpNo]) FROM [dbo].[Employee] as e2 WHERE e2.[DeptNo] = d.[DeptNo]) >= 2
GROUP BY d.[DeptNo], d.[DeptName]

--------------------------------------------------------------
--cau f
SELECT e.[EmpName] as [Employee Name], e.[Email] as [Employee Email], COUNT(esk.[EmpNo]) as [Skill Number]
FROM [dbo].[Employee] as e
LEFT JOIN [dbo].[Emp_Skill] esk
ON e.[EmpNo] = esk.[EmpNo]
GROUP BY e.[EmpName], e.[Email]
ORDER BY e.[EmpName] ASC

--cau g
SELECT e.[EmpName] as [Employee Name], e.[Email] as [Employee Email], e.[BirthDay] as [Employee Birthday]
FROM [dbo].[Employee] as e
WHERE (SELECT COUNT(esk2.[EmpNo]) FROM [dbo].[Emp_Skill] esk2 WHERE esk2.[EmpNo] = e.EmpNo GROUP BY esk2.[EmpNo]) > 1
		AND e.[Status] = 0
ORDER BY e.[EmpName] ASC

--cau h
GO
CREATE VIEW Employee_Working
AS
SELECT e.[EmpName] as [Employee Name], 
		STUFF((SELECT ', '+sk.[SkillName]
         FROM [dbo].[Skill] sk, [dbo].[Emp_Skill] esk
         WHERE sk.[SkillNo] = esk.[SkillNo] AND  esk.EmpNo = e.EmpNo
		 FOR XML PATH('')),1,2,'') as [Employee Skill], d.[DeptName] as [Employee Department]
FROM [dbo].[Employee] as e, [dbo].[Department] d
WHERE e.[Status] = 0  AND d.[DeptNo] = e.[DeptNo]
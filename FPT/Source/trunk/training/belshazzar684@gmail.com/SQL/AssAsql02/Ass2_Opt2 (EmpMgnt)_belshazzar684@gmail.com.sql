CREATE DATABASE EMS
GO
USE EMS

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

--a)Add at least 8 records into each created tables.
--Department
INSERT INTO dbo.Department(DeptName, Note) VALUES('Customer Service', 'Support customers')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Human Resources ', 'hiring, benefits,...')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Marketing', 'PR')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Sales', 'Manage sale')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Research & Development', 'Research & Development')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Quality Esurance', 'Ensure quality of products')
INSERT INTO dbo.Department(DeptName, Note) VALUES('Finance', 'Manage company finances')
INSERT INTO dbo.Department(DeptName, Note) VALUES('IT', 'Support about IT')

--Employee
INSERT INTO dbo.Employee VALUES (1,'Mike Ambinder', '8/21/1984', 1, '', '2/10/2008', 1500, 1, 'Note1', 4, '1@gmail.com')
INSERT INTO dbo.Employee VALUES (2,'Jeep Barnett', '7/15/1982', 2, '1', '4/24/2010', 1000, 0, 'Note2', 1, '2@gmail.com')
INSERT INTO dbo.Employee VALUES (3,'Kaci Aitchison', '2/21/1987', 3, '1', '1/5/2015', 1750, 2, 'Note3', 2, '3@gmail.com')
INSERT INTO dbo.Employee VALUES (4,'Andrea Wendel', '7/15/1988', 5, '1', '4/6/2012', 800, 2, 'Note4', 7, '4@gmail.com')
INSERT INTO dbo.Employee VALUES (5,'Greg Coomer', '3/21/1978', 2, '2', '7/1/2015', 900, 1, 'Note5', 6, '5@gmail.com')
INSERT INTO dbo.Employee VALUES (6,'Mike Dunkle', '1/25/1982', 6, '2', '3/9/2008', 1500, 0, 'Note6', 6, '6@gmail.com')
INSERT INTO dbo.Employee VALUES (7,'Emilia Clarke', '2/21/1990', 3, '3', '2/4/2015', 1200, 0, 'Note7', 5, '7@gmail.com')
INSERT INTO dbo.Employee VALUES (8,'Dave Feise', '4/15/1984', 4, '1', '2/6/2008', 1300, 1, 'Note8', 3, '8@gmail.com')

--Skill
INSERT INTO dbo.Skill(SkillName, Note) VALUES('C++', 'Note 1')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('.NET', 'Note 2')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('Java', 'Note 3')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('Python', 'Note 4')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('Ruby', 'Note 5')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('Design', 'Note 6')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('PR', 'Note 7')
INSERT INTO dbo.Skill(SkillName, Note) VALUES('Negotiation', 'Note 8')

--Emp_Skill
INSERT INTO dbo.Emp_Skill VALUES (1, 1, 3, '2/6/2008','Description 1')
INSERT INTO dbo.Emp_Skill VALUES (2, 1, 2, '2/6/2008', NULL)
INSERT INTO dbo.Emp_Skill VALUES (3, 1, 4, '2/6/2008', NULL)
INSERT INTO dbo.Emp_Skill VALUES (2, 2, 3, '2/6/2008','Description 2')
INSERT INTO dbo.Emp_Skill VALUES (3, 3, 3, '2/6/2008','Description 3')
INSERT INTO dbo.Emp_Skill VALUES (5, 4, 3, '2/6/2008','Description 4')
INSERT INTO dbo.Emp_Skill VALUES (1, 5, 3, '2/6/2008','Description 5')
INSERT INTO dbo.Emp_Skill VALUES (7, 5, 3, '2/6/2008','Description 6')
INSERT INTO dbo.Emp_Skill VALUES (6, 6, 3, '2/6/2008','Description 7')
INSERT INTO dbo.Emp_Skill VALUES (7, 7, 3, '2/6/2008','Description 8')
INSERT INTO dbo.Emp_Skill VALUES (4, 8, 3, '2/6/2008','Description 9')
GO

--b)Write a stored procedure (without parameter) to update employee level to 2 of the employees that has employee level = 1 and has been working
-- at least three year ago (from starting date). Print out the number updated records.
CREATE PROCEDURE [dbo].[usp_UpdateEmployeeLevel]
AS

SET NOCOUNT ON

UPDATE [dbo].[Employee] SET
	[Level] = 2
WHERE
	DATEDIFF(YEAR, [StartDate], GETDATE()) >= 3
	AND [Level] = 1
	AND [Status] = 1
GO


--c)Write a stored procedure (with EmpNo parameter) to print out employee’s name, employee’s email address and department’s name of employee that
-- has been out.
CREATE PROCEDURE [dbo].[usp_SelectOutEmployee]
	@EmpNo int
AS

SET NOCOUNT ON
SELECT [EmpName], [EMail], [DeptName]
FROM
	[dbo].[Employee], [dbo].[Department] 
WHERE
	[dbo].[Employee].[DeptNo] = [dbo].[Department].[DeptNo]
	AND [EmpNo] = @EmpNo
	AND [Status] = 0

GO

--d)Write a user function named Emp_Tracking (with EmpNo parameter) that return the salary of the employee has been working.
CREATE FUNCTION Emp_Tracking (@EmpNo int)
RETURNS money
AS	
BEGIN
	DECLARE @ret money;
	SELECT @ret = [Salary]
	FROM [dbo].[Employee]
	WHERE [EmpNo] = @EmpNo
		AND [Status] = 2
	RETURN @ret
END
GO

--e)Write the trigger(s) to prevent the case that the end user to input invalid employees information (level = 1 and salary >10.000.000).
CREATE TRIGGER Trigger_ValidateInput ON Employee
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT [EmpNo]
				FROM Inserted
				WHERE [Level] = 1
					AND [Salary] > 10000000
		)
		ROLLBACK TRANSACTION
END
GO
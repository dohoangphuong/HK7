--Question1--
CREATE TABLE DEPARTMENT
(
	DeptNo		tinyint Identity(1,1) NOT NULL PRIMARY KEY,
	DeptName	nvarchar(50) NOT NULL,
	Note		nvarchar(100)
)

CREATE TABLE EMPLOYEE
(
	EmpNo		int NOT NULL PRIMARY KEY,
	EmpName		nvarchar(50) NOT NULL,
	BirthDay	date NOT NULL,
	DeptNo		tinyint NOT NULL,
	MgrNo		int NOT NULL,
	StartDate	date NOT NULL,
	Salary		money NOT NULL,
	Emp_Level	tinyint NOT NULL CHECK(Emp_Level >= 1 AND Emp_Level <= 7),
	Emp_Status	tinyint NOT NULL CHECK(Emp_Status >= 0 AND Emp_Status <= 2),
	Note		nvarchar(100)
)

CREATE TABLE SKILL
(
	SkillNo		tinyint Identity(1,1) NOT NULL PRIMARY KEY,
	SkillName	nvarchar(50) NOT NULL,
	Note		nvarchar(100)
)

CREATE TABLE EMP_SKILL
(
	SkillNo		tinyint NOT NULL FOREIGN KEY REFERENCES SKILL(SkillNo),
	EmpNo		int NOT NULL FOREIGN KEY REFERENCES EMPLOYEE(EmpNo),
	SkillLevel	tinyint NOT NULL CHECK(SkillLevel >= 1 AND SkillLevel <= 3),
	RegDate		date NOT NULL,
	Descriptions nvarchar(100)
	CONSTRAINT [PK_EMP_SKILL] PRIMARY KEY(SkillNo, EmpNo)
)

--Question2--
ALTER TABLE dbo.EMPLOYEE ADD Email varchar(50) NOT NULL UNIQUE

ALTER TABLE dbo.EMPLOYEE ADD CONSTRAINT DF_EMPLOYEE_MgrNo DEFAULT 0 FOR MgrNo
ALTER TABLE dbo.EMPLOYEE ADD CONSTRAINT DF_EMPLOYEE_Emp_Status DEFAULT 0 FOR Emp_Status

--Question3--
ALTER TABLE EMPLOYEE ADD CONSTRAINT FK_EMPLOYEE_DEPARTMENT FOREIGN KEY(DeptNo) REFERENCES DEPARTMENT(DeptNo)

ALTER TABLE EMP_SKILL DROP COLUMN Descriptions

--Question4--
INSERT INTO DEPARTMENT(DeptName, Note) VALUES(N'Software Engineering', N'SE')
INSERT INTO DEPARTMENT(DeptName, Note) VALUES(N'Network and Telecommunication', N'NT')
INSERT INTO DEPARTMENT(DeptName, Note) VALUES(N'Information System', N'IS')
INSERT INTO DEPARTMENT(DeptName, Note) VALUES(N'Computer Engineering', N'CE')
INSERT INTO DEPARTMENT(DeptName, Note) VALUES(N'Computer Science', N'CS')

SET DATEFORMAT DMY;
INSERT INTO EMPLOYEE(EmpNo, EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, Emp_Level, Emp_Status, Note, Email)
	VALUES(1, N'Nguyễn Hải Đăng', '24/08/1994', 1, 12520554, '06/07/2015', 0, 4, 0, N'submit assignment late', 'nguyenhaidang@gmail.com')
INSERT INTO EMPLOYEE(EmpNo, EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, Emp_Level, Emp_Status, Note, Email)
	VALUES(2, N'Lê Quang Vinh', '26/08/1993', 3, 12520510, '06/07/2015', 0, 3, 2, N'take off', 'lequangvinh@gmail.com')
INSERT INTO EMPLOYEE(EmpNo, EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, Emp_Level, Emp_Status, Note, Email)
	VALUES(3, N'Phạm Nam Trường', '13/04/1994', 1, 12520472, '06/07/2015', 0, 5, 0, N'have good ideas', 'phamnamtruong@gmail.com')
INSERT INTO EMPLOYEE(EmpNo, EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, Emp_Level, Emp_Status, Note, Email)
	VALUES(4, N'Hoàng Xuân Thiên', '17/08/1992', 1, 12520411, '06/07/2015', 0, 6, 0, N'good skills', 'hoangxuanthien@gmail.com')
INSERT INTO EMPLOYEE(EmpNo, EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, Emp_Level, Emp_Status, Note, Email)
	VALUES(5, N'Dư Phát Tài', '21/09/1994', 5, 12520367, '06/07/2015', 0, 6, 0, N'good skills', 'duphattai@gmail.com')

INSERT INTO SKILL(SkillName, Note) VALUES(N'Requirement and design', N'RnD')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Coding and Unit test', N'CnU')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Bacsic SQL', N'BSQL')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Advanced SQL', N'ASQL')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Basic .NET', N'BTNB')
INSERT INTO SKILL(SkillName, Note) VALUES(N'Advanced .NET', N'ATNB')

INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(1, 3, 1, '06/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(1, 4, 2, '13/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(2, 1, 2, '06/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(3, 2, 2, '06/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(4, 3, 2, '06/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(4, 5, 1, '20/07/2015')
INSERT INTO EMP_SKILL(SkillNo, EmpNo, SkillLevel, RegDate) VALUES(5, 5, 2, '20/07/2015')

GO

CREATE VIEW dbo.view_EMPLOYEE_TRACKING
AS
SELECT EMPLOYEE.EmpNo, EMPLOYEE.EmpName, EMPLOYEE.Emp_Level
FROM EMPLOYEE
WHERE EMPLOYEE.Emp_Level >= 3 AND EMPLOYEE.Emp_Level <= 5
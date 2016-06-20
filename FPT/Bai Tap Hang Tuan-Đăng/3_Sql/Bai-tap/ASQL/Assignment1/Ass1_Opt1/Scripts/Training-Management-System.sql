--1--
CREATE TABLE Department
(
	Department_Number tinyint Identity(1,1) NOT NULL PRIMARY KEY,
	Department_Name nvarchar(50) NOT NULL
)

CREATE TABLE Employee_Table
(
	Employee_Number int Identity(1,1) NOT NULL PRIMARY KEY,
	Employee_Name nvarchar(50) NOT NULL,
	Department_Number tinyint NOT NULL FOREIGN KEY REFERENCES Department(Department_Number)
)

CREATE TABLE Employee_Skill_Table
(
	Employee_Number int NOT NULL FOREIGN KEY REFERENCES Employee_Table(Employee_Number),
	Skill_Code varchar(10) NOT NULL,
	Date_Registered date NOT NULL
	CONSTRAINT PK_Employee_Skill_Table PRIMARY KEY(Employee_Number, Skill_Code)
)

GO

INSERT INTO Department(Department_Name) VALUES(N'Software Engineering')
INSERT INTO Department(Department_Name) VALUES(N'Network and Telecommunication')
INSERT INTO Department(Department_Name) VALUES(N'Information System')
INSERT INTO Department(Department_Name) VALUES(N'Computer Engineering')
INSERT INTO Department(Department_Name) VALUES(N'Computer Science')

INSERT INTO Employee_Table(Employee_Name, Department_Number) VALUES(N'Nguyễn Hải Đăng', 1)
INSERT INTO Employee_Table(Employee_Name, Department_Number) VALUES(N'Phạm Thanh Hiền', 4)
INSERT INTO Employee_Table(Employee_Name, Department_Number) VALUES(N'Đỗ Hoàng Phương', 1)
INSERT INTO Employee_Table(Employee_Name, Department_Number) VALUES(N'Lê Quang Nhật', 1)

SET DATEFORMAT DMY;
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(1, '.NET', '06/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(1, 'JAVA', '13/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(3, '.NET', '06/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(3, 'JAVA', '13/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(2, 'JAVA', '13/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(4, '.NET', '06/07/2015')
INSERT INTO Employee_Skill_Table(Employee_Number, Skill_Code, Date_Registered) VALUES(4, 'JAVA', '13/07/2015')

GO

--2--
SELECT Employee_Table.Employee_Number, Employee_Table.Employee_Name 
FROM Employee_Table
WHERE Employee_Table.Employee_Number
	IN
	(
		SELECT Employee_Skill_Table.Employee_Number
		FROM Employee_Skill_Table
		WHERE Employee_Skill_Table.Skill_Code = 'JAVA'
	)

SELECT Employee_Table.Employee_Number, Employee_Table.Employee_Name 
FROM Employee_Table
	INNER JOIN Employee_Skill_Table
	ON (Employee_Table.Employee_Number = Employee_Skill_Table.Employee_Number)
WHERE Employee_Skill_Table.Skill_Code = 'JAVA'

--3--
SELECT dpm1.Department_Name, emp1.Employee_Name
FROM Department dpm1
	INNER JOIN Employee_Table emp1
	ON (emp1.Department_Number = dpm1.Department_Number)
WHERE dpm1.Department_Number
	IN
	(
		SELECT dpm2.Department_Number
		FROM Department dpm2
			INNER JOIN Employee_Table emp2
			ON (emp2.Department_Number = dpm2.Department_Number)
		GROUP BY dpm2.Department_Number
		HAVING (COUNT(emp2.Employee_Number) >= 3)
	)

--4--
SELECT emp1.Employee_Number, emp1.Employee_Name
FROM Employee_Table emp1
WHERE emp1.Employee_Number IN
		(
			SELECT emp2.Employee_Number
			FROM Employee_Table emp2, Employee_Skill_Table emp_skill
			WHERE emp_skill.Employee_Number = emp2.Employee_Number
			GROUP BY (emp2.Employee_Number)
			HAVING COUNT(emp_skill.Skill_Code) > 1
		)

GO

---5--
CREATE VIEW dbo._view_MULTISKILLS_EMPLOYEE
AS
SELECT emp1.Employee_Number, emp1.Employee_Name, dpm.Department_Name
FROM Employee_Table emp1
	INNER JOIN Department dpm
	ON (emp1.Department_Number = dpm.Department_Number)
WHERE emp1.Employee_Number
	IN
	(
		SELECT emp2.Employee_Number
		FROM Employee_Table emp2
			INNER JOIN Employee_Skill_Table emp_skill
			ON (emp_skill.Employee_Number = emp2.Employee_Number)
		GROUP BY (emp2.Employee_Number)
		HAVING COUNT(emp_skill.Skill_Code) > 1
	)

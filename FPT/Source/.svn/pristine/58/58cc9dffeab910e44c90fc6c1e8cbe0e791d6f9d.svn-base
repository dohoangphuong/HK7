/*
1.	Create the tables (with the most appropriate field/column constraints & types) 
and add at least 3 records into each created table.
*/
CREATE DATABASE Exercise2
GO
USE Exercise2
GO

CREATE TABLE Employee_Table
(
Employee_Number int NOT NULL PRIMARY KEY,
Employee_Name varchar(35) NOT NULL,
Department_Number int
)

CREATE TABLE Employee_Skill_Table
(
Employee_Number int NOT NULL,
Skill_Code varchar(50) NOT NULL,
Date_Registered datetime,
)
ALTER TABLE Employee_Skill_Table ADD CONSTRAINT PK_Employee_Skill_Table PRIMARY KEY(Employee_Number, Skill_Code)

CREATE TABLE Department
(
Department_Number int NOT NULL PRIMARY KEY,
Department_Name nvarchar(100) NOT NULL
)

ALTER TABLE Employee_Table ADD CONSTRAINT FK_Employee_Table_Department FOREIGN KEY(Department_Number) REFERENCES Department(Department_Number)
ALTER TABLE Employee_Skill_Table ADD CONSTRAINT FK_Employee_Skill_Table_Employee_Table FOREIGN KEY(Employee_Number) REFERENCES Employee_Table(Employee_Number)

INSERT INTO Department(Department_Number,Department_Name) VALUES (1,'Department Name 1')
INSERT INTO Department(Department_Number,Department_Name) VALUES (2,'Department Name 2')
INSERT INTO Department(Department_Number,Department_Name) VALUES (3,'Department Name 3')

INSERT INTO Employee_Table(Employee_Number,Employee_Name,Department_Number) VALUES (1,'Employee Name 1',1)
INSERT INTO Employee_Table(Employee_Number,Employee_Name,Department_Number) VALUES (2,'Employee Name 2',1)
INSERT INTO Employee_Table(Employee_Number,Employee_Name,Department_Number) VALUES (3,'Employee Name 3',2)
INSERT INTO Employee_Table(Employee_Number,Employee_Name,Department_Number) VALUES (4,'Employee Name 4',NULL)
INSERT INTO Employee_Table(Employee_Number,Employee_Name,Department_Number) VALUES (5,'Employee Name 5',1)

INSERT INTO Employee_Skill_Table(Employee_Number,Skill_Code,Date_Registered) VALUES (1,'Java','2009-1-12')
INSERT INTO Employee_Skill_Table(Employee_Number,Skill_Code,Date_Registered) VALUES (1,'C++','2010-3-21')
INSERT INTO Employee_Skill_Table(Employee_Number,Skill_Code,Date_Registered) VALUES (2,'Java','2011-4-15')
INSERT INTO Employee_Skill_Table(Employee_Number,Skill_Code,Date_Registered) VALUES (3,'Java','2009-6-11')
INSERT INTO Employee_Skill_Table(Employee_Number,Skill_Code,Date_Registered) VALUES (4,'C++','2010-6-17')

/*
2.	Specify the names of the employees whore have skill of ‘Java’ – give >=2 solutions: 
a.	Use JOIN selection, 
b.	Use sub query.
*/
--a. Use JOIN selection, --
SELECT Employee_Name
FROM dbo.[Employee_Table] A LEFT JOIN dbo.[Employee_Skill_Table] B
ON A.Employee_Number = B.Employee_Number
WHERE  B.Skill_Code = 'Java'
--b.	Use sub query.--
SELECT Employee_Name
FROM dbo.[Employee_Table]
WHERE Employee_Number IN ( SELECT Employee_Number
						   FROM dbo.[Employee_Skill_Table]
						   WHERE Skill_Code = 'Java'
						   )
/*
3.	Specify the departments which have >=3 employees, 
print out the list of departments’ employees right after each department.
*/
SELECT B.Department_Name,A.Employee_Name
FROM dbo.[Employee_Table] A LEFT JOIN dbo.[Department] B
ON A.Department_Number = B.Department_Number
WHERE B.Department_Number IN (
						SELECT Department_Number 
						FROM Employee_Table
						GROUP BY Department_Number
						HAVING COUNT(Employee_Number) >=3
					)
/*
4.	Use SUB-QUERY technique to list out the different employees 
(include employee number and employee names) who have multiple skills.
*/
SELECT Employee_Number, Employee_Name
FROM dbo.[Employee_Table] 
WHERE Employee_Number IN ( 
						SELECT Employee_Number
						FROM Employee_Skill_Table
						GROUP BY Employee_Number
						HAVING COUNT(Skill_Code) > 1
						)
/*
5.	Create a view to show different employees 
(with following information: employee number and employee name, department name) who have multiple skills
*/
GO
CREATE VIEW Employee_Multipleskill AS 
SELECT A.Employee_Number, A.Employee_Name, B.Department_Name
FROM dbo.[Employee_Table] A LEFT JOIN dbo.[Department] B
ON A.Department_Number = B.Department_Number
WHERE Employee_Number IN ( 
						SELECT Employee_Number
						FROM Employee_Skill_Table
						GROUP BY Employee_Number
						HAVING COUNT(Skill_Code) > 1
						)
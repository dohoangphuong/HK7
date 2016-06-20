/*•	Employee_Table (Employee_Number, Employee_Name, Department_Number)
•	Employee_Skill_Table (Employee_Number, Skill_Code, Date Registered)
•	Department (Department_Number, Department_Name)
*/

CREATE DATABASE ASQL_EMPLOYEE
GO
USE ASQL_EMPLOYEE

CREATE TABLE EMPLOYEE
(
	Employee_Number int primary key,
	Employee_Name nvarchar(50),
	Department_Number int foreign key (Department_Number) references DEPARTMENT(Department_Number)
)
GO
CREATE TABLE EMP_SKILL
(
	Employee_Number int foreign key (Employee_Number) references EMPLOYEE(Employee_Number),
	Skill_Code char(4),
	Regis_Date datetime,
	constraint PK_ES primary key (Employee_number, Skill_Code)
)
GO
CREATE TABLE DEPARTMENT
(
	Department_number int primary key,
	Department_Name nvarchar(50)
)
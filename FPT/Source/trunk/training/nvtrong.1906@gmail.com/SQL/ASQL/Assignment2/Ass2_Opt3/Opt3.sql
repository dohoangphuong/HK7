/*
a)	Create the tables (with the most appropriate field/column constraints & types)
and add at least 3 records into each created table.
*/
GO
CREATE DATABASE Exercise1
GO
USE Exercise1
GO

CREATE TABLE dbo.[Employee](
 EmployeeID int IDENTITY(1,1) PRIMARY KEY,
 EmployeeLastName nvarchar(100),
 EmployeeFirstName nvarchar(100),
 EmployeeHireDate datetime,
 EmployeeStatus int,
 SupervisorID int,
 SocialSecurityNumber nvarchar(12) 
)

CREATE TABLE dbo.[Projects](
 ProjectID int IDENTITY(1,1) PRIMARY KEY,
 EmployeeID int,
 ProjectName nvarchar(100),
 ProjectStartDate datetime,
 ProjectDescription ntext,
 ProjectDetail ntext,
 ProjectCompletedOn datetime
)

CREATE TABLE dbo.[Project_Modules](
 ModuleID int IDENTITY(1,1) PRIMARY KEY,
 ProjectID int,
 EmployeeID int,
 ProjectModulesDate datetime,
 ProjectModulesCompledOn datetime,
 ProjectModulesDescription ntext
)

CREATE TABLE dbo.[Work_Done](
 WorkDoneID int IDENTITY(1,1) PRIMARY KEY,
 EmployeeID int,
 ModuleID int , 
 WorkDoneDate datetime,
 WorkDoneDescription ntext,
 WorkDoneStatus int
)

ALTER TABLE dbo.[Employee] ADD CONSTRAINT CHK_EmployeeStatus CHECK(EmployeeStatus IN('0','1','2'))
ALTER TABLE dbo.[Work_Done] ADD CONSTRAINT CHK_WorkDoneStatus CHECK(WorkDoneStatus IN('0','1','2'))

ALTER TABLE dbo.[Employee] ADD CONSTRAINT FK_SupervisorID FOREIGN KEY (SupervisorID) REFERENCES Employee(EmployeeID)
ALTER TABLE dbo.[Projects] ADD CONSTRAINT FK_EmployeeIDProjects FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
ALTER TABLE dbo.[Project_Modules] ADD CONSTRAINT FK_EmployeeIDProject_Modules FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
ALTER TABLE dbo.[Work_Done]	ADD CONSTRAINT FK_EmployeeIDWork_Done FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
ALTER TABLE dbo.[Project_Modules] ADD CONSTRAINT FK_ProjectID FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
ALTER TABLE dbo.[Work_Done] ADD CONSTRAINT FK_ModuleID FOREIGN KEY (ModuleID) REFERENCES Project_Modules(ModuleID)

INSERT INTO dbo.[Employee]( EmployeeLastName,EmployeeFirstName ,EmployeeHireDate,EmployeeStatus,SupervisorID,SocialSecurityNumber)
VALUES('Last 1' ,'First 1 ' ,'2013-02-28','1',NULL,'123456789')
INSERT INTO dbo.[Employee]( EmployeeLastName,EmployeeFirstName ,EmployeeHireDate,EmployeeStatus,SupervisorID,SocialSecurityNumber)
VALUES('Last 2' ,'First 2 ' ,'2012-06-15','1','1','987654321')
INSERT INTO dbo.[Employee]( EmployeeLastName,EmployeeFirstName ,EmployeeHireDate,EmployeeStatus,SupervisorID,SocialSecurityNumber)
VALUES('Last 3' ,'First 3 ' ,'2011-01-31','1','1','123456788')

INSERT INTO dbo.[Projects]( EmployeeID,ProjectName,ProjectStartDate,ProjectDescription,ProjectDetail,ProjectCompletedOn)
VALUES('1','Project 1' , '2014-04-01','Description 1' , ' Detail 1 ' , '2014-06-01')
INSERT INTO dbo.[Projects]( EmployeeID,ProjectName,ProjectStartDate,ProjectDescription,ProjectDetail,ProjectCompletedOn)
VALUES('2','Project 2' , '2014-05-10','Description 2' , ' Detail 2 ' , '2014-09-20')
INSERT INTO dbo.[Projects]( EmployeeID,ProjectName,ProjectStartDate,ProjectDescription,ProjectDetail,ProjectCompletedOn)
VALUES('3','Project 3' , '2014-07-11','Description 3' , ' Detail 3 ' , '2014-08-11')

INSERT INTO dbo.[Project_Modules]( ProjectID,EmployeeID,ProjectModulesDate,ProjectModulesCompledOn,ProjectModulesDescription)
VALUES('1' ,'1' ,'2014-04-02','2014-06-01','Description Modules 1')
INSERT INTO dbo.[Project_Modules]( ProjectID,EmployeeID,ProjectModulesDate,ProjectModulesCompledOn,ProjectModulesDescription)
VALUES('2' ,'2' ,'2014-05-11','2014-07-11','Description Modules 2')
INSERT INTO dbo.[Project_Modules]( ProjectID,EmployeeID,ProjectModulesDate,ProjectModulesCompledOn,ProjectModulesDescription)
VALUES('3' ,'3' ,'2014-07-12','2014-07-19','Description Modules 3')

INSERT INTO dbo.Work_Done(EmployeeID,ModuleID, WorkDoneDate,WorkDoneDescription,WorkDoneStatus)
VALUES('1','1','2014-05-31','Description Work 1','0')
INSERT INTO dbo.Work_Done(EmployeeID,ModuleID, WorkDoneDate,WorkDoneDescription,WorkDoneStatus)
VALUES('2','2','2014-07-12','Description Work 2','1')
INSERT INTO dbo.Work_Done(EmployeeID,ModuleID, WorkDoneDate,WorkDoneDescription,WorkDoneStatus)
VALUES('3','3',NULL,'Description Work 3','0')

/*
b)	Write a stored procedure (without parameter) to remove the project information 
after three months of project completion, since the current date. 
Print out the number of records which are removed from each related table during the removals.
*/
GO
CREATE PROC Delete_Project
AS
BEGIN
	DECLARE @RowDeleteWorkDone int
	DECLARE @RowDeleteProject_Modules int
	DECLARE @RowDeleteProjects int

	--Work_Done
	DELETE 
	FROM dbo.[Work_Done]
	WHERE ModuleID IN	(
						SELECT ModuleID 
						FROM dbo.[Project_Modules]
						WHERE ProjectID IN	(
											SELECT ProjectID
											FROM dbo.[Projects]
											WHERE DATEDIFF(month,ProjectCompletedOn,GETDATE())>=3
											)
						)
	SELECT @RowDeleteWorkDone = @@ROWCOUNT
	
	--Project_Modules
	DELETE
	FROM dbo.[Project_Modules]
	WHERE ProjectID IN	(
						SELECT ProjectID
						FROM dbo.[Projects]
						WHERE DATEDIFF(month,ProjectCompletedOn,GETDATE())>=3
						)
	SELECT @RowDeleteProject_Modules = @@ROWCOUNT						
	
	--Projects
	DELETE
	FROM dbo.[Projects]
	WHERE DATEDIFF(month,ProjectCompletedOn,GETDATE())>=3 
	SELECT @RowDeleteProjects = @@ROWCOUNT

	--Print out number delete
	SELECT 'Projects' AS NameProject , @RowDeleteProjects AS TheCount
	UNION
	SELECT 'Project_Modules' , @RowDeleteProject_Modules 
	UNION
	SELECT 'Work_Done' , @RowDeleteWorkDone
END

/*
c)	Write a stored procedure (with parameter) to print out the modules that a specific employee has been working on.
*/


/*
d)	Write a user function (with parameter) that return the Works information that a 
specific employee has been involving though those were not assigned to him/her.
*/


/*
e)	Write the trigger(s) to prevent the case that the end user to input invalid Project Modules information 
(Project_Modules.ProjectModulesDate < Projects.ProjectStartDate, 
Project_Modules.ProjectModulesCompletedOn > Projects.ProjectCompletedOn)
*/


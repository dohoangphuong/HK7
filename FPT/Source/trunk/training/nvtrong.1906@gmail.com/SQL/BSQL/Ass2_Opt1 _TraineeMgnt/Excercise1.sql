CREATE DATABASE Assignment2
USE Assignment2
GO

/*Q1:Create the tables (with the most appropriate/economic field/column constraints & types).*/
CREATE TABLE dbo.[Trainee]
(
	TraineeID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Full_Name nvarchar(30),
	Birth_Date datetime,
	Gender varchar(7),
	ET_IQ int,
	ET_Gmath int,
	ET_English int,
	Trainning_Class varchar(10),
	Evaluation_Notes ntext
)

ALTER TABLE dbo.[Trainee] ADD CONSTRAINT CHK_GENDER CHECK(Gender IN ('male','female','unknown'))
ALTER TABLE dbo.[Trainee] ADD CONSTRAINT CHK_ET_IQ CHECK(ET_IQ >= 0 AND ET_IQ <= 20)
ALTER TABLE dbo.[Trainee] ADD CONSTRAINT ET_GMATH CHECK(ET_Gmath >= 0 AND ET_Gmath <= 20)
ALTER TABLE dbo.[Trainee] ADD CONSTRAINT ET_ENGLISH CHECK(ET_English >= 0 AND ET_English <= 50)

/*Q2:Change the table TRAINEE to add one more field named Fsoft_Account which is a not-null &unique field*/
ALTER TABLE dbo.[Trainee] ADD Fsoft_Account varchar(60) NOT NULL
ALTER TABLE dbo.[Trainee] ADD UNIQUE(Fsoft_Account)

/*Q3:Create a VIEW which includes all the ET-passed trainees. One trainee is considered as ET-passed when he/she has the entry test points satisfied below criteria:
•	ET_IQ + ET_Gmath>=20
•	ET_IQ>=8
•	ET_Gmath>=8
•	ET_English>=18
*/
GO
CREATE VIEW [ET-passed] 
AS 
SELECT * FROM dbo.[Trainee] 
WHERE (ET_IQ + ET_Gmath >=20) AND (ET_IQ >=8) AND (ET_Gmath >= 8 ) AND (ET_English >=18)
GO

/*Q5:Query the trainee who has the longest name, showing his/her age along with his/her basic information (as defined in the table)*/
SELECT TraineeID, Full_Name , Birth_Date, Gender , DATEDIFF(YEAR, Birth_Date , GETDATE()) AS [Age] FROM dbo.[Trainee] WHERE LEN(Full_Name) = (SELECT MAX(LEN(Full_Name)) FROM dbo.[Trainee])

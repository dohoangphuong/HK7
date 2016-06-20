CREATE DATABASE FMT
GO
USE FMT

--Q1: Create the tables (with the most appropriate/economic field/column constraints & types) and add at least 10 records into each created table.
CREATE TABLE Trainee
(
	TraineeID int IDENTITY(1,1) primary key ,
	Full_Name nvarchar(50),
	Birth_Date datetime,
	Gender bit,
	ET_IQ int,
	ET_Gmath int,
	ET_English int,
	Training_Class nvarchar(10),
	Evaluation_Notes nvarchar(100),
	CONSTRAINT chk_ETIQ CHECK (ET_IQ >= 0 AND ET_IQ <= 20),
	CONSTRAINT chk_ETGmath CHECK (ET_IQ >= 0 AND ET_IQ <= 20),
	CONSTRAINT chk_ETEnglish CHECK (ET_IQ >= 0 AND ET_IQ <= 50)
)

INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Mike Ambinder', '8/21/1984', 0, 15, 10, 41, 'C112', 'Lazy')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Jeep Barnett', '7/15/1982', 0, 17, 6, 35, 'C121', 'Excelent')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Kaci Aitchison', '2/21/1987', 1, 7, 15, 44, 'C142', 'Good')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Andrea Wendel', '7/15/1988', 1, 7, 18, 35, 'C212', 'Okay')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Greg Coomer', '3/21/1978', 0, 15, 17, 32, 'C152', 'Employer of the month')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Mike Dunkle', '1/25/1982', 0, 17, 8, 17, 'C147', 'Good')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Emilia Clarke', '2/21/1990', 1, 13, 15, 35, 'C169', 'Okay')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Dave Feise', '4/15/1984', 0, 17, 18, 18, 'C192', 'Excelent')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('Alicia Vikander', '11/25/1987', 1, 13, 15, 24, 'C319', 'Good')
INSERT INTO Trainee(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes) VALUES ('John Guthrie', '4/15/1984', 0, 17, 18, 18, 'C141', 'Good')

--Q2: Change the table TRAINEE to add one more field named Fsoft_Account which is a not-null & unique field.
ALTER TABLE dbo.Trainee
ADD Fsoft_Account varchar(50) NOT NULL DEFAULT ('new account')
GO

UPDATE Trainee SET [Fsoft_Account] = [Fsoft_Account] + CONVERT(nvarchar(10),[TraineeID])
GO

ALTER TABLE Trainee 
	ADD UNIQUE (Fsoft_Account)
GO

--Q3: Create a VIEW which includes all the ET-passed trainees. One trainee is considered as ET-passed when he/she has the entry test points satisfied below criteria:
--•	ET_IQ + ET_Gmath >=20
--•	ET_IQ>=8
--•	ET_Gmath>=8
--•	ET_English>=18
CREATE VIEW PassedTrainee AS
SELECT * 
FROM dbo.Trainee
WHERE ([ET_IQ] + [ET_Gmath]) >= 20 AND
	[ET_IQ] >= 8 AND
	[ET_Gmath] >=8 AND
	[ET_English] >= 18
GO

--Q4: Query all the trainees who is passed the entry test, group them into different birth months.
SELECT * 
FROM dbo.PassedTrainee
ORDER BY Month([Birth_Date])

--Q5: Query the trainee who has the longest name, showing his/her age along with his/her basic information (as defined in the table)
SELECT TOP 1 *
FROM dbo.Trainee
ORDER BY Len([Full_Name]) DESC


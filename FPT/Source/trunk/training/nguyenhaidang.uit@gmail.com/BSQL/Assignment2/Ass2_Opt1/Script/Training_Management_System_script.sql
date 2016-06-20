--Question 1--
CREATE TABLE TRAINEE(
	TraineeID		int IDENTITY(1,1) PRIMARY KEY,
	Full_Name		nvarchar(50),
	Birth_Date		date,
	Gender			bit,
	ET_IQ			tinyint DEFAULT 0 CHECK (ET_IQ >= 0 AND ET_IQ <= 20),
	ET_GMath		tinyint DEFAULT 0 CHECK (ET_GMath >= 0 AND ET_GMath <= 20),
	ET_English		tinyint DEFAULT 0 CHECK (ET_English >= 0 AND ET_English <= 50),
	Training_Class	varchar(30),
	Evaluation_Notes nvarchar(200)
)

GO

SET DATEFORMAT dmy;
INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Nguyễn Hải Đăng', '24/08/1994', 1, 19, 19, 49, '.NET', N'good skills')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Lê Quang Vinh', '26/08/1993', 1, 7, 6, 23, '.NET', N'take off')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Phạm Nam Trường', '13/04/1994', 1, 15, 16, 33, 'JAVA', N'enthusiasm')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Hoàng Xuân Thiên', '17/05/1992', 1, 16, 15, 19, '.NET', N'submit assignment late')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Dư Phát Tài', '21/09/1994', 1, 15, 7, 27, 'JAVA', N'have good ideas')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Trần Cẩm Quốc', '19/02/1993', 1, 19, 13, 35, 'JAVA', N'monitor')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Đỗ Hoàng Phương', '05/03/1994', 1, 17, 16, 38, '.NET', N'good at resolving problem')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Lê Quang Nhật', '29/01/1992', 1, 17, 18, 40, 'JAVA', N'boss')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Nguyễn Khoa Minh Nhân', '01/12/1993', 1, 6, 17, 17, '.NET', N'nothing')

INSERT INTO TRAINEE(Full_Name, Birth_Date, Gender, ET_IQ, ET_GMath, ET_English, Training_Class, Evaluation_Notes)
	VALUES(N'Nguyễn Thị Phương Mai', '10/11/1994', 0, 8, 19, 36, 'JAVA', N'only girl in the class')

GO

--Question 2--
ALTER TABLE TRAINEE ADD Fsoft_Account varchar(30)

UPDATE TRAINEE SET Fsoft_Account = 'nguyenhaidang@gmail.com' WHERE TraineeID = 1
UPDATE TRAINEE SET Fsoft_Account = 'lequangvinh@gmail.com' WHERE TraineeID = 2
UPDATE TRAINEE SET Fsoft_Account = 'phamnamtruong@gmail.com' WHERE TraineeID = 3
UPDATE TRAINEE SET Fsoft_Account = 'hoangxuanthien@gmail.com' WHERE TraineeID = 4
UPDATE TRAINEE SET Fsoft_Account = 'duphattai@gmail.com' WHERE TraineeID = 5
UPDATE TRAINEE SET Fsoft_Account = 'trancamquoc@gmail.com' WHERE TraineeID = 6
UPDATE TRAINEE SET Fsoft_Account = 'dohoangphuong@gmail.com' WHERE TraineeID = 7
UPDATE TRAINEE SET Fsoft_Account = 'lequangnhat@gmail.com' WHERE TraineeID = 8
UPDATE TRAINEE SET Fsoft_Account = 'nguyenhkhoaminhnhan@gmail.com' WHERE TraineeID = 9
UPDATE TRAINEE SET Fsoft_Account = 'nguyenthiphuongmai@gmail.com' WHERE TraineeID = 10

ALTER TABLE TRAINEE ALTER COLUMN Fsoft_Account varchar(30) NOT NULL
ALTER TABLE TRAINEE ADD CONSTRAINT UNI_Fsoft_Account UNIQUE(Fsoft_Account)

GO

--Question 3--
CREATE VIEW dbo.view_PassEntryTest
AS
SELECT	TraineeID,
		Full_Name,
		Birth_Date,
		Gender,
		ET_IQ,
		ET_GMath,
		ET_English,
		Training_Class,
		Evaluation_Notes,
		Fsoft_Account

FROM TRAINEE
WHERE ET_IQ + ET_GMath >= 20
	AND ET_IQ >= 8
	AND ET_GMath >= 8
	AND ET_English >= 18

GO

--Question 4--
SELECT * FROM dbo.view_PassEntryTest
ORDER BY MONTH(Birth_Date)

GO

--Question 5--
SELECT	trainee1.TraineeID,
		trainee1.Full_Name,
		trainee1.Birth_Date,
		trainee1.Gender,
		trainee1.ET_IQ, ET_GMath,
		trainee1.ET_English,
		trainee1.Training_Class,
		trainee1.Evaluation_Notes,
		trainee1.Fsoft_Account,
		LEN(trainee1.Full_Name) AS Length_Of_Name

FROM TRAINEE trainee1
WHERE NOT EXISTS
		(
			SELECT 1
			FROM TRAINEE trainee2
			WHERE LEN(trainee2.Full_Name) > LEN(trainee1.Full_Name)
		)
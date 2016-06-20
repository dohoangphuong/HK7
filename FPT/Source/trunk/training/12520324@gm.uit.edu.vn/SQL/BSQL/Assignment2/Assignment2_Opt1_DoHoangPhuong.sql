-------------------TÊN: Đỗ Hoàng Phương----------------------
---------------------MSSV: 12520324-----------------------

create database Fsoft
GO
USE Fsoft
GO
CREATE TABLE TRAINEE
(
	ID CHAR(7) PRIMARY KEY,
	FULL_NAME varchar(40) NULL, 
	BIRTH_DATE SMALLDATETIME NULL,
	GENDER VARCHAR(20) NULL,
	ET_IQ INT NULL,
	ET_GMATH INT NULL,
	ET_ENGLISH INT NULL,
	TRAINING_CLASS CHAR(7),
	EVALUATION_NOTES varchar(100) NULL,
)

ALTER TABLE TRAINEE ADD CONSTRAINT CHECK_G CHECK(GENDER = 'Nam' Or GENDER = 'Nu')
ALTER TABLE TRAINEE ADD CONSTRAINT CHECK_IQ CHECK(ET_IQ >= 0 Or ET_IQ <= 20)
ALTER TABLE TRAINEE ADD CONSTRAINT CHECK_GMATH CHECK(ET_GMATH >= 0 Or ET_GMATH <= 20)
ALTER TABLE TRAINEE ADD CONSTRAINT CHECK_ENG CHECK(ET_ENGLISH >= 0 Or ET_ENGLISH <= 50)

insert into TRAINEE values ('1','Nguyen Van A','1960/10/22','Nam',10,16,20, '01','')
insert into TRAINEE values ('2','Nguyen Van B','1990/10/22','Nu',20,20,50, '02','')
insert into TRAINEE values ('3','Nguyen Van C','1980/10/22','Nam',10,16,20, '03','')
insert into TRAINEE values ('4','Nguyen Van D','1983/10/22','Nam',10,10,20, '04','')
insert into TRAINEE values ('5','Nguyen Van E','1985/10/22','Nam',20,20,30, '05','')
insert into TRAINEE values ('6','Nguyen Van F','1963/10/22','Nu',10,4,20, '06','')
insert into TRAINEE values ('7','Nguyen Van G','1980/10/22','Nam',10,16,20, '07','')
insert into TRAINEE values ('8','Nguyen Van H','1990/10/22','Nam',5,6,20, '01','')
insert into TRAINEE values ('9','Nguyen Van I','1984/10/22','Nu',10,16,30, '04','')
insert into TRAINEE values ('10','Nguyen Van J','1980/10/22','Nam',20,16,20, '08','')

-------------------------------------------------
ALTER TABLE TRAINEE ADD Fsoft_Account CHAR(12)
ALTER table TRAINEE alter column Fsoft_Account nchar(50) not null
ALTER TABLE TRAINEE ADD CONSTRAINT PK_f UNIQUE(Fsoft_Account)
-------------------QD3-----------------------------

GO
SELECT ID, FULL_NAME, ET_IQ,ET_GMATH,ET_ENGLISH
FROM TRAINEE
WHERE TRAINEE.ET_IQ + TRAINEE.ET_GMATH >=20 AND
		TRAINEE.ET_IQ >=8 AND TRAINEE.ET_GMATH >= 8 AND
		TRAINEE.ET_ENGLISH >=18

--------------------QD4------------------
GO
SELECT  MONTH(BIRTH_DATE) [THÁNG]
FROM TRAINEE
WHERE TRAINEE.ET_IQ + TRAINEE.ET_GMATH >=20 AND
		TRAINEE.ET_IQ >=8 AND TRAINEE.ET_GMATH >= 8 AND
		TRAINEE.ET_ENGLISH >=18
GROUP BY MONTH(BIRTH_DATE)

-------------------------QD5-----------------------
GO
SELECT  LEN(FULL_NAME),ID ,FULL_NAME, BIRTH_DATE,GENDER,ET_IQ ,ET_GMATH ,ET_ENGLISH ,TRAINING_CLASS, DateDiff( YEAR, BIRTH_DATE , GetDate())[AGE]
FROM TRAINEE
GROUP BY  LEN(FULL_NAME),ID ,FULL_NAME, BIRTH_DATE,GENDER,ET_IQ ,ET_GMATH ,ET_ENGLISH ,TRAINING_CLASS
HAVING LEN(TRAINEE.FULL_NAME) = 
(
		SELECT TOP 1 LEN(TRAINEE.FULL_NAME) 
		FROM TRAINEE
		ORDER BY LEN(TRAINEE.FULL_NAME) DESC
			)
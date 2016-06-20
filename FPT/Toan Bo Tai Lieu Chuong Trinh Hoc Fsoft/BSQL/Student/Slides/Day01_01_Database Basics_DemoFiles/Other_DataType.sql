-- TimeStamp
CREATE TABLE MyTest (myKey int PRIMARY KEY
    ,myValue int, RV rowversion);
GO 
INSERT INTO MyTest (myKey, myValue) VALUES (3, 0);
GO 
INSERT INTO MyTest (myKey, myValue) VALUES (4, 0);
GO


select * from MyTest

-- SQL_VARIANT
declare @t SQL_VARIANT
SET @t = '2012-12-12'
SELECT @t
SET @t = 1
SELECT @t


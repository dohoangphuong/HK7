Use Master
GO
CREATE DATABASE AdventureWorks2008 
ON (FILENAME = 'D:\HK6\FPT\Tuan03\AdventureWorks2008_Database\AdventureWorks2008_Data.mdf'), -- Data file path
(FILENAME = 'D:\HK6\FPT\Tuan03\AdventureWorks2008_Database\AdventureWorks2008_Log.ldf') -- Log file path
FOR ATTACH;


USE AdventureWorks2008 
GO
-------------------------------------------------------------------------------------------------------------
---------------------------------------------Exercise 2------------------------------------------------------
-------------------------------------------------------------------------------------------------------------
---------------------QUERY 1----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
---------------------QUERY 2----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.ListPrice <> 0
---------------------QUERY 3----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR IS NULL
---------------------QUERY 4----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR IS NOT NULL
---------------------QUERY 5----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR IS NOT NULL AND ListPrice > 0
---------------------QUERY 6----------------------
SELECT A.NAME, A.COLOR
FROM PRODUCTION.PRODUCT A 
WHERE A.COLOR IS NOT NULL
---------------------QUERY 7----------------------
SELECT 'NAME: ', A.NAME,' -- ','COLOR:', A.COLOR
FROM PRODUCTION.PRODUCT A 
WHERE A.COLOR IS NOT NULL
---------------------QUERY 8----------------------
SELECT A.PRODUCTID,A.NAME
FROM PRODUCTION.PRODUCT A 
WHERE A.PRODUCTID BETWEEN 400 AND 500
---------------------QUERY 9----------------------
SELECT A.PRODUCTID, A.NAME, A.COLOR
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR= 'BLUE'  OR A.COLOR= 'BLACK'
---------------------QUERY 10----------------------
SELECT A.NAME,A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.NAME LIKE 'S%' 
ORDER BY A.NAME ASC
---------------------QUERY 11----------------------
SELECT A.NAME, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.NAME LIKE 'A%' OR A.NAME LIKE 'S%'
ORDER BY A.NAME ASC
---------------------QUERY 12----------------------
SELECT A.NAME 
FROM PRODUCTION.PRODUCT A
WHERE A.NAME LIKE 'SPO%' AND A.NAME NOT IN 
			(	
			SELECT A.NAME 
			FROM PRODUCTION.PRODUCT A
			WHERE A.NAME LIKE 'SPOK%'
			) 
---------------------QUERY 13----------------------
SELECT  A.COLOR
FROM PRODUCTION.PRODUCT A
GROUP BY COLOR
---------------------QUERY 14----------------------
SELECT DISTINCT A.PRODUCTSUBCATEGORYID, A.COLOR
FROM PRODUCTION.PRODUCT A
WHERE (A.PRODUCTSUBCATEGORYID IS NOT NULL) AND (A.COLOR IS NOT NULL) 
---------------------QUERY 15----------------------
--QUERY 15
SELECT PRODUCTSUBCATEGORYID, LEFT([NAME],35) AS [NAME], COLOR, LISTPRICE
FROM PRODUCTION.PRODUCT
WHERE (COLOR IN ('RED','BLACK')
       AND PRODUCTSUBCATEGORYID = 1)
      OR LISTPRICE BETWEEN 1000 AND 2000
ORDER BY PRODUCTID
---------------------QUERY 16----------------------
SELECT A.NAME, 'UNKNOWN'[COLOR], A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR IS NULL
SELECT A.NAME, COLOR, A.LISTPRICE
FROM PRODUCTION.PRODUCT A
WHERE A.COLOR IS NOT NULL

-------------------------------------------------------------------------------------------------------------
---------------------------------------------Exercise 3------------------------------------------------------
-------------------------------------------------------------------------------------------------------------

---------------------QUERY 1----------------------
SELECT COUNT (A.PRODUCTID)
FROM PRODUCTION.PRODUCT A
---------------------QUERY 2----------------------
SELECT COUNT (A.PRODUCTID)[HasSubCategoryID]
FROM PRODUCTION.PRODUCT A
WHERE ProductSubcategoryID IS NULL
---------------------QUERY 3----------------------
SELECT [ProductSubcategoryID], COUNT (ProductSubcategoryID)[CountedProducts]
FROM PRODUCTION.PRODUCT A
GROUP BY ProductSubcategoryID
---------------------QUERY 4----------------------
SELECT COUNT(ProductID)
FROM PRODUCTION.PRODUCT A
GROUP BY ProductSubcategoryID
HAVING ProductSubcategoryID IS NULL

---------------------QUERY 5----------------------
SELECT ProductID, COUNT(Production)
FROM PRODUCTION.PRODUCT A
GROUP BY ProductSubcategoryID
---------------------QUERY 1----------------------
---------------------QUERY 1----------------------
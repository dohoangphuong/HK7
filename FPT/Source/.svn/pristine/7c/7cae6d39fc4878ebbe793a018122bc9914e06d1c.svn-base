USE AdventureWorks2008
GO

--Exercise1: Working with Subqueries 
--Query 1
SELECT A.Name
FROM Production.Product A
WHERE A.ProductSubcategoryID In  
	(SELECT B.ProductSubcategoryID
	 FROM Production.ProductSubcategory B
	 WHERE B.Name = 'Saddles')

--Query 2
SELECT A.Name
FROM Production.Product A
WHERE A.ProductSubcategoryID In  
	(SELECT B.ProductSubcategoryID
	 FROM Production.ProductSubcategory B
	 WHERE B.Name LIKE 'Bo%')

--Query 3
SELECT A.Name
FROM Production.Product A
WHERE A.ListPrice  IN 
	(SELECT MIN(Product.ListPrice) as [Min]
	 FROM Production.Product
	 WHERE Product.ProductSubcategoryID = 3)

--Query 4
--Part 1
SELECT A.Name
FROM Person.CountryRegion A
WHERE A.CountryRegionCode IN 
	(SELECT B.CountryRegionCode
	 FROM Person.StateProvince B
	 GROUP BY B.CountryRegionCode
	 HAVING COUNT(B.CountryRegionCode) < 10)

--Part 2
SELECT A.Name
FROM Person.CountryRegion A 
INNER JOIN Person.StateProvince B 
ON A.CountryRegionCode = B.CountryRegionCode
GROUP BY A.Name
HAVING COUNT(A.Name) < 10


--Query 5
SELECT A.SalesPersonID, AVG(A.SubTotal) - (SELECT AVG(A.SubTotal) AS [AvgSubTotal] FROM Sales.SalesOrderHeader A) AS SalesDiff
FROM Sales.SalesOrderHeader A
GROUP BY A.SalesPersonID
HAVING A.SalesPersonID IS NOT NULL

--Query 6
--Step 1
SELECT AVG(A.ListPrice)
FROM Production.Product A
WHERE A.ProductSubcategoryID IN (1, 2, 3)

--Query 7
--Part 1
SELECT C.FirstName + ' ' + C.LastName
FROM Sales.SalesPerson A 
JOIN HumanResources.Employee B 
ON B.BusinessEntityID  = A.BusinessEntityID
JOIN Person.Person C  
ON B.BusinessEntityID = C.BusinessEntityID
WHERE Bonus > 5000

--Exercise 2: Joining Data from multiple tables
--Query 1
SELECT 'Country' = A.Name, 'Province' = B.Name
FROM Person.CountryRegion A
JOIN Person.StateProvince B 
ON A.CountryRegionCode = B.CountryRegionCode

--Query 2
SELECT 'Country' = A.Name, 'Province' = B.Name
FROM Person.CountryRegion A
JOIN Person.StateProvince B 
ON A.CountryRegionCode = B.CountryRegionCode
WHERE A.Name = 'Canada' OR A.Name = 'Germany'
ORDER BY A.Name, B.Name

--Query 3
SELECT DISTINCT
	A.SalesOrderID
,	A.OrderDate
,	A.SalesPersonID
,	B.BusinessEntityID
,	B.Bonus
,	B.SalesYTD
FROM Sales.SalesOrderHeader A
JOIN Sales.SalesPerson B 
ON A.SalesPersonID = B.BusinessEntityID
WHERE A.SalesPersonID IS NOT NULL

--Query 4
SELECT DISTINCT
	A.SalesOrderID
,	A.OrderDate
,	C.JobTitle
,	B.Bonus
,	B.SalesYTD
FROM Sales.SalesOrderHeader A
JOIN HumanResources.Employee C
ON A.SalesPersonID = C.BusinessEntityID
JOIN Sales.SalesPerson B 
ON A.SalesPersonID = B.BusinessEntityID
WHERE A.SalesPersonID IS NOT NULL

--Query 5
SELECT DISTINCT
	A.SalesOrderID
,	A.OrderDate
,	C.FirstName
,	C.LastName
,	B.Bonus
,	B.SalesYTD
FROM Sales.SalesOrderHeader A
JOIN Person.Person C
ON A.SalesPersonID = C.BusinessEntityID
JOIN Sales.SalesPerson B 
ON A.SalesPersonID = B.BusinessEntityID
WHERE A.SalesPersonID IS NOT NULL

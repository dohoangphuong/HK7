--Quyery1
SELECT [Name]
FROM Production.Product
WHERE ProductSubcategoryID IN 
    (
		SELECT ProductSubcategoryID
		FROM Production.ProductSubcategory
		WHERE [Name] = 'Saddles'
	)

--Quyery2
SELECT [Name]
FROM Production.Product
WHERE ProductSubcategoryID IN 
    (
		SELECT ProductSubcategoryID
		FROM Production.ProductSubcategory
		WHERE [Name] Like 'Bo%'
	)

--Quyery3
SELECT Name
FROM Production.Product
WHERE ListPrice IN
	(
		SELECT MIN(ListPrice)
		FROM Production.Product
		WHERE ProductSubcategoryID = 3
	)

--Quyery4
--Part 1:
SELECT [Name] 
FROM Person.CountryRegion
WHERE CountryRegionCode IN 
    (
		SELECT CountryRegionCode
		FROM Person.StateProvince
		GROUP BY CountryRegionCode
		HAVING COUNT(*) < 10
	)

--Part 2:
SELECT cr.[Name]
FROM Person.CountryRegion cr
	INNER JOIN Person.StateProvince sp
	ON cr.CountryRegionCode = sp.CountryRegionCode
GROUP BY cr.[Name]
HAVING COUNT(*) < 10

--Quyery5
SELECT soh.SalesPersonID 
	, (SELECT AVG(sod.SubTotal) 
		FROM Sales.SalesOrderHeader AS sod
		WHERE sod.SalesPersonID IS NOT NULL)
	- AVG(SubTotal) AS SalesDiff
FROM Sales.SalesOrderHeader soh
WHERE soh.SalesPersonID IS NOT NULL
GROUP BY soh.SalesPersonID


--Quyery6
--Step 1:
SELECT AVG(ListPrice) 
FROM Production.Product
WHERE ProductSubcategoryID IN (1,2,3)

--Step 2:
SELECT p2.Name
	 , p2.ListPrice - 
	  (SELECT AVG(p1.ListPrice) 
		FROM Production.Product p1
		WHERE p1.ProductSubcategoryID IN (1,2,3)) 
	   AS Diff
FROM Production.Product p2
WHERE p2.ProductSubcategoryID IN (1,2,3) 


--Step 3:
--using derived table
SELECT * 
FROM (
		SELECT 
			p2.Name
			, p2.ListPrice -(SELECT AVG(p1.ListPrice) 
			FROM Production.Product p1
			WHERE p1.ProductSubcategoryID IN (1,2,3)) 
			AS Diff
		FROM Production.Product p2
		WHERE p2.ProductSubcategoryID IN (1,2,3)
	 )	AS temp
WHERE temp.Diff BETWEEN -800 and -400

--using CTE
WITH temp AS
(
	SELECT 
		p2.Name
		, p2.ListPrice - 
			(SELECT AVG(p1.ListPrice) 
			FROM Production.Product p1
			WHERE p1.ProductSubcategoryID IN (1,2,3)) 
			AS Diff
	FROM Production.Product p2
	WHERE p2.ProductSubcategoryID IN (1,2,3)
)
SELECT * 
FROM temp
WHERE temp.Diff BETWEEN -800 and -400


--Query7
--Part 1:
SELECT P.FirstName + ' ' + P.LastName
FROM Sales.SalesPerson SP 
JOIN HumanResources.Employee E 
    ON E.BusinessEntityID  = SP.BusinessEntityID
JOIN Person.Person AS P  
    ON E.BusinessEntityID = P.BusinessEntityID
WHERE Bonus > 5000


--Part 2:
SELECT ps.FirstName + ' ' + ps.LastName
FROM Person.Person ps 
  INNER JOIN HumanResources.Employee emp
    ON (emp.BusinessEntityID = ps.BusinessEntityID)
WHERE 5000 <
    (
		SELECT Bonus
		FROM Sales.SalesPerson sps
		WHERE emp.BusinessEntityID = sps.BusinessEntityID
	 )

--Part 3:
--Nothing, SQL Server optimizer evaluates to the same plan.


--Query8
--Part 1:
SELECT sps.BusinessEntityID 
FROM  Sales.SalesPerson sps
WHERE NOT EXISTS 
    (
		SELECT st.SalesPersonID
		FROM Sales.Store st
		WHERE st.SalesPersonID = sps.BusinessEntityID
	 )

--Part 2:
SELECT sps.BusinessEntityID 
FROM Sales.SalesPerson sps
	LEFT JOIN Sales.Store st
    ON (st.SalesPersonID = sps.BusinessEntityID)
WHERE st.name IS NULL


--Query9
--Part 1:
SELECT ProductSubcategoryID, COUNT(ProductID) 
FROM Production.Product
GROUP BY ProductSubcategoryID

GO

--Part 2:
WITH TempSet (ProdSubID, CountedProds) AS
(
	SELECT ProductSubcategoryID, COUNT(ProductID) 
	FROM Production.Product
	GROUP BY ProductSubcategoryID
)
SELECT * FROM TempSet

GO

-- The final
WITH TempSet (ProdSubID, CountedProds) AS
(
	SELECT ProductSubcategoryID, COUNT(ProductID) 
	FROM Production.Product
	GROUP BY ProductSubcategoryID
)
SELECT ProductCategoryID
	, COUNT(ProductSubcategoryID) AS SubCat
    , SUM(CountedProds) as SumProds
FROM Production.ProductSubcategory PS
	RIGHT JOIN TempSet T 
    ON (T.ProdSubID = PS.ProductSubcategoryID)
GROUP BY ProductCategoryID


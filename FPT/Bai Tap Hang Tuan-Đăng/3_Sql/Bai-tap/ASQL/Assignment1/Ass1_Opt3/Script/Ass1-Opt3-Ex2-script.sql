--Query1
SELECT CR.[Name] AS Country, SP.[Name] AS Province
FROM Person.CountryRegion cr
    JOIN Person.StateProvince sp
	ON (cr.CountryRegionCode = sp.CountryRegionCode)


--Query2
SELECT cr.[Name] AS Country, sp.[Name] AS Province
FROM Person.CountryRegion cr
    JOIN Person.StateProvince sp
    ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE CR.[Name] IN ('Germany','Canada')
ORDER BY Country ASC, Province ASC  


--Query3
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, soh.SalesPersonID
		, sps.BusinessEntityID
		, sps.Bonus
		, sps.SalesYTD
FROM Sales.SalesOrderHeader soh
	INNER JOIN Sales.SalesPerson sps 
	ON soh.SalesPersonID = sps.BusinessEntityID


--Query4
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, e.JobTitle
		, p.Bonus
		, p.SalesYTD
FROM Sales.SalesOrderHeader soh
	INNER JOIN Sales.SalesPerson p 
		ON soh.SalesPersonID = p.BusinessEntityID
	INNER JOIN HumanResources.Employee e 
		ON p.BusinessEntityID = e.BusinessEntityID


--Query5
SELECT	soh.SalesOrderID
	, soh.OrderDate
	, prs.FirstName
	, prs.LastName
	, p.Bonus
FROM Sales.SalesOrderHeader soh
	INNER JOIN Sales.SalesPerson p 
		ON soh.SalesPersonID = p.BusinessEntityID
	INNER JOIN HumanResources.Employee e 
		ON p.BusinessEntityID = e.BusinessEntityID
	INNER JOIN Person.Person prs 
		ON e.BusinessEntityID = prs.BusinessEntityID


--Query6
SELECT	soh.SalesOrderID
	, soh.OrderDate
	, prs.FirstName
	, prs.LastName
	, p.Bonus
FROM Sales.SalesOrderHeader soh
	INNER JOIN Sales.SalesPerson p 
		ON soh.SalesPersonID = p.BusinessEntityID
	INNER JOIN Person.Person prs 
		ON p.BusinessEntityID = prs.BusinessEntityID


--Query7
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, prs.FirstName
		, prs.LastName
FROM Sales.SalesOrderHeader soh
	INNER JOIN Person.Person prs 
		ON soh.SalesPersonID = prs.BusinessEntityID

--Query8
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, prs.FirstName + ' ' + prs.LastName AS SalesPerson
		, sod.ProductID
		, sod.OrderQty
FROM Sales.SalesOrderHeader soh
	INNER JOIN Person.Person prs
		ON soh.SalesPersonID = prs.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail sod
		ON soh.SalesOrderID = sod.SalesOrderID
ORDER BY OrderDate, SalesOrderID


--Query9
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, prs.FirstName + ' ' + prs.LastName AS SalesPerson
		, p.Name AS ProductName
		, sod.OrderQty
FROM Sales.SalesOrderHeader soh
	INNER JOIN Person.Person prs
		ON soh.SalesPersonID = prs.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail sod
		ON soh.SalesOrderID = sod.SalesOrderID
	INNER JOIN Production.Product p 
	    ON p.ProductID = sod.ProductID
ORDER BY OrderDate, SalesOrderID


--Query10
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, prs.FirstName + ' ' + prs.LastName AS SalesPerson
		, p.Name AS ProductName
		, sod.OrderQty
FROM Sales.SalesOrderHeader soh
	INNER JOIN Person.Person prs
		ON soh.SalesPersonID = prs.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail sod
		ON soh.SalesOrderID = sod.SalesOrderID
	INNER JOIN Production.Product p 
		ON p.ProductID = sod.ProductID
WHERE soh.SubTotal > 100000	AND YEAR(soh.OrderDate) = 2004
ORDER BY OrderDate, SalesOrderID
------
SELECT	soh.SalesOrderID
		, soh.OrderDate
		, prs.FirstName + ' ' + prs.LastName AS SalesPerson
		, p.Name AS ProductName
		, sod.OrderQty
FROM Sales.SalesOrderHeader soh
	INNER JOIN Person.Person prs
		ON soh.SalesPersonID = prs.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail sod
		ON soh.SalesOrderID = sod.SalesOrderID
	INNER JOIN Production.Product p 
		ON p.ProductID = sod.ProductID
WHERE soh.SubTotal > 100000
	AND soh.OrderDate >= '20040101'
	AND soh.OrderDate < '20050101'
ORDER BY OrderDate, SalesOrderID


--Query11
SELECT	cr.Name AS CountryName
		, ps.Name AS ProvinceName
FROM Person.CountryRegion cr
	LEFT OUTER JOIN Person.StateProvince AS ps
		ON cr.CountryRegionCode = ps.CountryRegionCode
ORDER BY CountryName, ProvinceName


--Query12
SELECT c.CustomerID, soh.SalesOrderID 
FROM Sales.Customer c
     LEFT OUTER JOIN Sales.SalesOrderHeader soh 
        ON c.CustomerID = soh.CustomerID
WHERE soh.SalesOrderID IS NULL
ORDER BY CustomerID


--Query13
SELECT	p.[Name] AS ProductName
		, pm.[Name] AS ProductModelName
FROM Production.Product p
	FULL OUTER JOIN Production.ProductModel AS pm
		ON p.ProductModelID = pm.ProductModelID
WHERE p.[Name] IS NULL OR pm.[Name] IS NULL

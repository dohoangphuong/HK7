--Query1--
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product

--Query2--
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice <> 0

--Query3--
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NULL

--Query4--
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL

--Query5--
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Query6--
SELECT (Name + ': ' + Color) AS 'Name And Color'
FROM Production.Product
WHERE Color IS NOT NULL

--Query7--
SELECT ('NAME: ' + Name + ' -- COLOR: ' + Color) AS 'Name And Color'
FROM Production.Product
WHERE Color IS NOT NULL

--Query8--
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID >= 400 AND ProductID <= 500

--Query9--
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color LIKE N'Black' OR Color LIKE N'Blue'

--Query10--
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'
ORDER BY Name

--Query11--
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%' OR Name LIKE 'A%'
ORDER BY Name

--Query12--
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'SPO[^K]%'
ORDER BY Name

--Query13--
SELECT DISTINCT Color
FROM Production.Product

--Query14--
SELECT DISTINCT ProductSubcategoryID, Color
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL AND Color IS NOT NULL
ORDER BY ProductSubcategoryID ASC, Color DESC

--Query15--
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice
FROM Production.Product
WHERE Color IN ('Red','Black') 
	  AND ProductSubCategoryID = 1	
      OR ListPrice BETWEEN 1000 AND 2000    
ORDER BY ProductID

--Quyery16--
SELECT Name, ISNULL(Color, 'Unknown') AS Color, ListPrice
FROM Production.Product

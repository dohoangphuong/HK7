--Query1--
SELECT COUNT(*)
FROM Production.Product


--Query2--
SELECT COUNT(ProductSubcategoryID) AS HasSubCategoryID 
FROM Production.Product


--Query3--
SELECT ProductSubcategoryID, COUNT(Name) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID


--Query4--
SELECT COUNT(*) - COUNT(ProductSubcategoryID) 
FROM Production.Product

SELECT COUNT(*) AS NoSubCat
FROM Production.Product
WHERE ProductSubcategoryID IS NULL


--Query5--
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
GROUP BY ProductID


--Query6--
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100


--Query7--
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID, Shelf
HAVING SUM(Quantity) < 100


--Query8--
SELECT AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
Where LocationID = 10


--Query9--
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10 AND Shelf <> 'N/A'
GROUP BY ROLLUP (Shelf, ProductID) 
ORDER BY Shelf


--Query10--
SELECT Color ,Class ,COUNT(*) AS TheCount ,AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Class IS NOT NULL AND Color IS NOT NULL
GROUP BY GROUPING SETS (Color, Class)


--Query11--
SELECT ProductSubcategoryID, COUNT(Name) as Counted, GROUPING(ProductSubcategoryID) AS IsGrandTotal
FROM Production.Product
GROUP BY ROLLUP (ProductSubcategoryID)
ORDER BY ProductSubcategoryID

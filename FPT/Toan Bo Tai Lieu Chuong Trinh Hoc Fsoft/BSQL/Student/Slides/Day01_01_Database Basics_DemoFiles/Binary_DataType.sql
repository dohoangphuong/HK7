DECLARE @BinaryVariable2 BINARY(2);

SET @BinaryVariable2 = 123456;
SET @BinaryVariable2 = @BinaryVariable2 + 1;

select @BinaryVariable2

SELECT CAST( @BinaryVariable2 AS INT);
GO
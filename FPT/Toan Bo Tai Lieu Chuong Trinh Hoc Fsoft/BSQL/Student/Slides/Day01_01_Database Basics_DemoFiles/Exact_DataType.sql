declare @t decimal(5,3) -- up to 38. -- equality numeric

set @t = 1

select @t

-- money 8 bytes, smallmoney 4bytes
DECLARE
@mon1 MONEY,
@mon2 MONEY,
@mon3 MONEY,
@mon4 MONEY,
@num1 DECIMAL(19,4),
@num2 DECIMAL(19,4),
@num3 DECIMAL(19,4),
@num4 DECIMAL(19,4)

SELECT
@mon1 = 100, @mon2 = 339, @mon3 = 10000,
@num1 = 100, @num2 = 339, @num3 = 10000

SET @mon4 = @mon1/@mon2*@mon3
SET @num4 = @num1/@num2*@num3

SELECT @mon4 AS moneyresult,
@num4 AS numericresult
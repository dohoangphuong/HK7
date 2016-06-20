-- Date and Time
select getdate()
declare @d date
set @d = getdate()
select @d


declare @t time
set @t = getdate()
select @t

-- DateTime and DateTime2
declare @d1 datetime   = '2/25/2013 11:59:59.997'
declare @d2 datetime2  = '2/25/2013 11:59:59.999'
select @d1 as 'DateTime', @d2 'DateTime2'

-- DateTimeOffset
select cast(getdate() as DateTimeOffset)

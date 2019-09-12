  
DECLARE @ypro int
DECLARE @npro int
DECLARE @kpro int

DECLARE rowcursor INSENSITIVE CURSOR FOR
select ypro, npro, kpro from proceeds where
not exists (select  * from proceeds_bank where proceeds_bank.kpro = proceeds.kpro)
and ypro = 2013

ORDER BY adate asc
FOR READ ONLY
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @ypro, @npro, @kpro
WHILE @@FETCH_STATUS = 0
BEGIN 

	PRINT   @ypro
	print   @kpro
	
	exec compute_proceeds_bank @kpro
 

	FETCH NEXT FROM rowcursor
	INTO @ypro, @npro, @kpro
END 
DEALLOCATE rowcursor
 
GO


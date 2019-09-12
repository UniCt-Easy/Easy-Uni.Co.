  
DECLARE @ypay int
DECLARE @npay int
DECLARE @kpay int

DECLARE rowcursor INSENSITIVE CURSOR FOR
select ypay, npay, kpay from payment where
not exists (select  * from payment_bank where payment_bank.kpay = payment.kpay)
and ypay = 2013

ORDER BY adate asc
FOR READ ONLY
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @ypay, @npay, @kpay
WHILE @@FETCH_STATUS = 0
BEGIN 

	PRINT   @ypay
	print   @kpay
	
	exec compute_payment_bank @kpay
 

	FETCH NEXT FROM rowcursor
	INTO @ypay, @npay, @kpay
END 
DEALLOCATE rowcursor
 
GO
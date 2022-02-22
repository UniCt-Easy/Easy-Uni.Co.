
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


  
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

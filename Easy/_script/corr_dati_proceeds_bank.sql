
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


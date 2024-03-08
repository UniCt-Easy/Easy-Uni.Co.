
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[calc_bookingcode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [calc_bookingcode]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE [calc_bookingcode]	
	@idbooking  int 
AS
BEGIN
declare @numstr varchar(20)
declare @num int
declare @mychk varchar(20)
declare @chkstr varchar(20)
declare @chk int
declare @dipstr varchar(20)
declare @numdip int

declare @lunghezzatotale int
declare @lunghezzacheck int
declare @lunghezzanumero int
declare @lunghezzadipcode int

select @numdip= iddep from dbdepartment where iddbdepartment= user
set @numdip = isnull(@numdip,0)

set @lunghezzatotale   =15
set @lunghezzacheck    =3
set @lunghezzadipcode  = 3
set @lunghezzanumero = @lunghezzatotale - @lunghezzacheck - @lunghezzadipcode

set @numstr= convert(varchar, @idbooking)

if  DATALENGTH(ISNULL(@numstr,'')) <= @lunghezzanumero	
BEGIN
	SET @numstr =  SUBSTRING(REPLICATE('0',@lunghezzanumero),1,@lunghezzanumero - DATALENGTH(@numstr)) + @numstr
END
print @numstr


set @dipstr= convert(varchar, @numdip)

if  DATALENGTH(ISNULL(@dipstr,'')) <= @lunghezzadipcode	
BEGIN
	SET @dipstr =  SUBSTRING(REPLICATE('0',@lunghezzadipcode),1,@lunghezzadipcode - DATALENGTH(@dipstr)) + @dipstr
END
--print @dipstr


declare @n int
set @n= @idbooking

declare @alfa varchar(21)
set @alfa='NHRSWDXYCIQOEJKTUGVPFZABLM'

declare @c1 int
declare @c2 int
declare @c3 int
declare @c4 int


set @c1 = @n % 21
set @n= @n-@c1

set @n = @n /21
set @c2 = @n % 21
set @n= @n-@c2

set @n = @n /21
set @c3 = @n % 21
set @n= @n-@c3


set @c3 =( @c3 + (@numdip / 100)) % 21
set @c2 = (@c2 + ( (@numdip /10) % 10)) % 21
set @c1 = (@c1 + ( @numdip % 10) ) % 21
print '----'
print @c1
print @c2
print @c3

set @mychk= substring(@alfa,@c3+1,1)+substring(@alfa,@c2+1,1)+substring(@alfa,@c1+1,1)
print @mychk
print @numdip

select @numstr+@dipstr+ @mychk as bookingcode
 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

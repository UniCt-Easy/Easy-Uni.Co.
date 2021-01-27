
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


if exists (select * from dbo.sysobjects where id = object_id(N'[calc_bookingid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [calc_bookingid]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [calc_bookingid]
	@codebooking  varchar(15) 
AS
BEGIN
declare @numstr varchar(20)
declare @num int
declare @mychk varchar(20)
declare @chkstr varchar(20)
declare @chk int
declare @dipstr varchar(20)
declare @numdip int
-- NUMERO(9)  DIPCODE(3) CHECK(3)

declare @lunghezzatotale int
declare @lunghezzacheck int
declare @lunghezzadipcode int

set @lunghezzatotale   =  15
set @lunghezzacheck    =  3
set @lunghezzadipcode  =  3

set @codebooking= isnull(@codebooking,'')

if  DATALENGTH(ISNULL(@codebooking,'')) <= @lunghezzatotale	
BEGIN
	SET @codebooking =  SUBSTRING(REPLICATE('0',@lunghezzatotale),1,@lunghezzatotale - DATALENGTH(@codebooking)) + @codebooking
END

set    @numstr= substring(@codebooking,1,@lunghezzatotale-@lunghezzacheck-@lunghezzadipcode)
set    @chkstr= substring(@codebooking,@lunghezzatotale-@lunghezzadipcode+1,@lunghezzacheck)
set    @dipstr= substring(@codebooking,@lunghezzatotale-@lunghezzacheck-@lunghezzadipcode+1,@lunghezzadipcode)

print '@codebooking'
print @codebooking
print '@numstr'
print @numstr
print '@dipstr'
print @dipstr
print '@chkstr'
print @chkstr

print '----'
set @num = convert(int,@numstr)
set @numdip = convert(int,@dipstr)

declare @n int
set @n= @num

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



set @mychk= substring(@alfa,@c3+1,1)+substring(@alfa,@c2+1,1)+substring(@alfa,@c1+1,1)
print '@mychk'
print @mychk
print '@chkstr'
print @chkstr

if (@mychk <> @chkstr) 
	select null as idbooking , null as iddep
else
	select @num as idbooking , @numdip as iddep
 

print @num


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

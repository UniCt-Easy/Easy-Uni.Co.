
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_reopenayear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_reopenayear]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [closeyear_reopenayear]
(
	@ayear int,
	@kind char(1)
)
AS BEGIN
IF @kind = 'F'
BEGIN
	--azzero i bit da 0 a 3 e poi imposto il valore 5 su questi flag
	UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
	UPDATE accountingyear SET flag = flag|0x05 WHERE ayear = @ayear
END
IF @kind = 'P'
BEGIN
	--azzero il bit 4
	UPDATE accountingyear SET flag = flag&0xEF WHERE ayear = @ayear
END
IF @kind = 'E'
BEGIN
	--azzero il bit 5
	UPDATE accountingyear SET flag = flag&0xDF WHERE ayear = @ayear
END
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




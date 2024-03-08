
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_iddb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_iddb]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE compute_iddb(
	@iddb varchar(5)
)
AS BEGIN

-- exec compute_iddb 1429

CREATE TABLE #AllLicense(
	departmentname	varchar(150)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @dip_nome varchar(300)
declare @query nvarchar(4000)

DECLARE crsdepartment INSENSITIVE CURSOR FOR
	SELECT iddbdepartment FROM dbdepartment
	OPEN crsdepartment 
FETCH NEXT FROM crsdepartment INTO @iddbdepartment

        WHILE @@fetch_status=0 begin
        	SET @dip_nome = @iddbdepartment + '.license'
			
                SET  @query = ' INSERT INTO #AllLicense(departmentname)'
							+ ' SELECT departmentname '       
                            + ' FROM '+@dip_nome
                            + ' WHERE iddb =  '+ convert(varchar(5), @iddb)
               EXEC sp_executesql @query
PRINT @query

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

deallocate crsdepartment


SELECT departmentname
FROM #AllLicense
WHERE departmentname IS NOT NULL


END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


exec compute_iddb 1429

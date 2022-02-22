
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_serviceregistryunified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_serviceregistryunified]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE check_serviceregistryunified(
	@ayear	smallint ,
	@unified char(1)
)
AS BEGIN


--- exec check_serviceregistryunified 2011, 'N'

CREATE TABLE #error (departmentname varchar(500), message varchar(400))

IF (@unified <> 'S')
BEGIN
        EXEC check_serviceregistrysingle @ayear
        RETURN
END 


DECLARE @iddbdepartment varchar(50)

DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment
WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
 FOR READ ONLY
OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.check_serviceregistrysingle'

		INSERT INTO #error (
                     departmentname, message
		)
		EXEC @dip_nomesp @ayear
	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

DEALLOCATE crsdepartment



IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT departmentname as Dipartimento, message FROM #error
	RETURN
END

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



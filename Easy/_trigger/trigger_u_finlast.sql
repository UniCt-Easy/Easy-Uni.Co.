
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finlast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finlast]
GO

CREATE   TRIGGER [trigger_u_finlast] ON [finlast] FOR UPDATE
AS BEGIN

DECLARE	@lu varchar(64)
SELECT	@lu = lu FROM inserted
if (user<>'amministrazione' OR @lu = 'trigger_finlast_upd') return;

CREATE TABLE #finlast
(
	idfin int,
	expiration smalldatetime,
	lt datetime, lu varchar(64)
)

INSERT INTO #finlast
(
	idfin,
	expiration,
	lt, lu
)
SELECT
	inserted.idfin,
	inserted.expiration,
	inserted.lt, 'trigger_finlast_upd'
FROM inserted
JOIN deleted
	ON deleted.idfin = inserted.idfin
JOIN fin
	ON fin.idfin = inserted.idfin
WHERE fin.nlevel <= (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = fin.ayear)
AND ISNULL(inserted.expiration, {D '1900-01-01'}) <> ISNULL(deleted.expiration, {D '1900-01-01'})
AND inserted.lu <>'trigger_finlast_upd'

IF (SELECT COUNT(*) FROM #finlast) = 0 RETURN
-- Parte di propagazione delle modifiche a tutti i dipartimenti


        DECLARE @currdep varchar(50)
        SET @currdep = user
        
        DECLARE @iddbdepartment varchar(50)
        
        DECLARE @cursore cursor
        SET @cursore = CURSOR FOR
        SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
        OPEN @cursore
        FETCH NEXT FROM @cursore INTO @iddbdepartment
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
        	DECLARE @sql nvarchar(4000)
        
        	SET @sql = N'UPDATE [' + @iddbdepartment + '].finlast' +
        	' SET [' + @iddbdepartment + '].finlast.expiration = f.expiration, ' +
        	' [' + @iddbdepartment + '].finlast.lt = f.lt, ' +
        	' [' + @iddbdepartment + '].finlast.lu = ''trigger_finlast_upd'' ' +
        	' FROM #finlast f ' +
        	' join fin f1 on f.idfin=f1.idfin '+
        	' join [' + @iddbdepartment + '].fin f2 on f2.codefin=f1.codefin and f1.ayear=f2.ayear and (f1.flag & 1)=(f2.flag & 1) '+
        	' WHERE [' + @iddbdepartment + '].finlast.idfin = f2.idfin ' +
        	' AND ([' + @iddbdepartment + '].finlast.lt <> f.lt OR [' +@iddbdepartment + '].finlast.lu <> f.lu)'
        
        	EXEC SP_EXECUTESQL @sql	
        	FETCH NEXT FROM @cursore INTO @iddbdepartment
        END
        
        CLOSE  @cursore
        DEALLOCATE  @cursore
        


DROP TABLE #finlast

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


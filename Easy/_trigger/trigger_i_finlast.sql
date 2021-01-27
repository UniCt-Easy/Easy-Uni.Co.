
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_finlast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_finlast]
GO

CREATE    TRIGGER [trigger_i_finlast] ON [finlast] FOR INSERT
AS BEGIN

IF (@@ROWCOUNT = 0) RETURN
DECLARE @idfin int
DECLARE @expiration datetime
DECLARE @idman int
DECLARE	@cupcode varchar(15)
DECLARE	@cu varchar(64)
DECLARE	@ct datetime
DECLARE	@lu varchar(64)
DECLARE	@lt datetime

SELECT	@idfin = idfin, @expiration = expiration, @idman = idman, @cupcode = cupcode, 
	@cu = cu, @ct = ct, @lu = lu, @lt = lt
FROM inserted

DECLARE @ayear  int
DECLARE @nlevel tinyint
SELECT  @ayear = ayear, @nlevel = nlevel FROM fin WHERE idfin = @idfin

DECLARE @unifiedfinlevel smallint
SET @unifiedfinlevel = (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = @ayear) 

IF EXISTS (SELECT * FROM accountingyear WHERE ayear = @ayear AND ((flag&0x0F)>= 2))
OR
(EXISTS (SELECT * FROM mainaccountingyear WHERE completed = 'S' AND ayear = @ayear) 
	AND @nlevel <= @unifiedfinlevel)
	BEGIN
	DECLARE @newidfin int

	SELECT  @newidfin = newidfin FROM finlookup WHERE oldidfin = @idfin

	DECLARE @newparidfin int
	SELECT  @newparidfin = paridfin FROM fin WHERE idfin = @newidfin
		
	IF (@newidfin IS NOT NULL) AND NOT EXISTS(SELECT * FROM finlast WHERE idfin = @newidfin)
	BEGIN
		-- Il finlast del padre nell'anno successivo deve essere cancellato in quanto finlast è associato solo alle voci foglia
		IF (@newparidfin IS NOT NULL)
		BEGIN
			DELETE FROM finlast WHERE idfin = @newparidfin
		END
		-- Viene creata finlast solo se la voce di bilancio nell'anno successivo non ha figli
		IF (SELECT COUNT(*) FROM fin WHERE paridfin = @newidfin) = 0
		BEGIN
			INSERT INTO finlast (idfin, idman, cupcode, expiration, ct, cu, lt, lu)
			VALUES (@newidfin, @idman, @cupcode, @expiration, GETDATE(), 'TRIGGER', GETDATE(), '''TRIGGER''')
		END
	END
END

-- Parte di propagazione delle modifiche a tutti i dipartimenti
IF (user<>'amministrazione' OR @cu ='trigger_finlast_copy') RETURN

        CREATE TABLE #finlast
        (
        	idfin int,
        	codefin varchar(100),
        	flag int,
        	ayear smallint,
        	expiration datetime,
        	ct datetime, cu varchar(64), lt datetime, lu varchar(64)
        )
        
        INSERT INTO #finlast
        (
        	idfin, codefin, flag, ayear, expiration, 
        	ct, cu, lt, lu
        )
        SELECT 
        	inserted.idfin, fin.codefin, fin.flag, fin.ayear, inserted.expiration, 
        	inserted.ct, 'trigger_finlast_copy', inserted.lt, inserted.lu
        FROM inserted
        JOIN fin
        	ON fin.idfin = inserted.idfin
        WHERE fin.nlevel <= @unifiedfinlevel
        AND inserted.cu <> 'trigger_finlast_copy'
        
        IF( (SELECT COUNT(*) FROM #finlast ) > 0)
        BEGIN
                DECLARE @currdep varchar(50)
                SET @currdep = user
                
                DECLARE @iddbdepartment varchar(50)
                
                DECLARE @cursore cursor
                SET @cursore = CURSOR FOR
                SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
                OPEN @cursorE
                FETCH NEXT FROM @cursore INTO @iddbdepartment
                WHILE (@@FETCH_STATUS = 0)
                BEGIN
                	DECLARE @sql nvarchar(2000)
                	
                	SET @sql = N'INSERT INTO [' + @iddbdepartment + '].finlast' +
                	' (idfin, expiration,ct, cu, lt, lu)' +
                	' SELECT FF.idfin, #finlast.expiration, #finlast.ct, #finlast.cu, #finlast.lt, #finlast.lu ' +
                	' FROM #finlast '+
                	 'join [' + @iddbdepartment + '].fin FF '+
                		' on FF.ayear=#finlast.ayear and FF.codefin=#finlast.codefin and (FF.flag&1) = (#finlast.flag&1) '+
                	' WHERE NOT EXISTS(SELECT * FROM [' + @iddbdepartment + '].finlast fd join [' + @iddbdepartment + '].fin ffd on ffd.idfin=fd.idfin '+
                				' WHERE FFD.ayear=#finlast.ayear and FFD.codefin=#finlast.codefin and (FFD.flag&1) = (#finlast.flag&1)'+
                			 ')'
                
                	--PRINT @sql
                	EXEC SP_EXECUTESQL @sql
                	
                	FETCH NEXT FROM @cursore INTO @iddbdepartment
                END
                
                CLOSE @cursore
                DEALLOCATE  @cursore
        END
        
   DROP TABLE #finlast

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


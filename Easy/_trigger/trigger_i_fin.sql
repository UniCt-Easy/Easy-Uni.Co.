
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_fin]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_fin]
GO

CREATE       TRIGGER [trigger_i_fin] ON [fin] FOR INSERT
AS BEGIN

IF (@@ROWCOUNT = 0) RETURN
DECLARE @oldidfin int
DECLARE @ayear smallint
DECLARE @fincode varchar(50)
DECLARE	@paridfin int
DECLARE	@nlevel tinyint
DECLARE	@printingorder varchar(50)
DECLARE	@title varchar(150)
DECLARE	@prevision decimal(19, 2)
DECLARE	@flag tinyint
DECLARE	@cu varchar(64)
DECLARE	@ct datetime
DECLARE	@lu varchar(64)
DECLARE	@lt datetime

SELECT	@oldidfin = idfin, @ayear = ayear, @flag = flag, 
	@fincode = codefin, @paridfin = paridfin,
	@nlevel = nlevel,
	@printingorder = printingorder,
	@title = title, 
	@cu = cu, @ct = ct, @lu = lu, @lt = lt
FROM inserted


DECLARE @nrowinserted int
SET     @nrowinserted = ISNULL((SELECT COUNT(*) FROM inserted),0)

IF (@nrowinserted > 1)
BEGIN
	CREATE TABLE #fin2 (idfin int, nlevel tinyint)
	
	INSERT INTO #fin2 (idfin, nlevel)
	SELECT idfin, nlevel FROM inserted
	
	INSERT INTO finlink (idchild, nlevel, idparent)
	SELECT idfin, nlevel, idfin
	FROM #fin2
	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO finlink (idchild, nlevel, idparent)
		SELECT IL.idchild, (IL.nlevel - 1), I.paridfin
		FROM finlink IL
		JOIN fin I
		ON IL.idparent = I.idfin
		WHERE IL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM finlink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
		AND EXISTS(SELECT * FROM #fin2 WHERE #fin2.idfin = IL.idchild)
	END
END
ELSE
BEGIN

	INSERT INTO finlink (idchild, nlevel, idparent)
	VALUES(@oldidfin, @nlevel, @oldidfin)
	
	DECLARE @currlev  tinyint
	SET @currlev = @nlevel - 1

	DECLARE @currpar int
	SET @currpar = @paridfin
	
	WHILE (@currlev >= 1)
	BEGIN
		INSERT INTO finlink (idchild, nlevel, idparent)
		VALUES(@oldidfin, @currlev, @currpar)
		
		SET @currpar = (SELECT paridfin FROM fin WHERE idfin = @currpar)
		SET @currlev = @currlev - 1
	END
END

DECLARE @unifiedfinlevel smallint
SET @unifiedfinlevel = (SELECT unifiedfinlevel FROM commonconfig WHERE ayear = @ayear )


IF EXISTS (SELECT * FROM accountingyear WHERE ayear = @ayear AND ((flag&0x0F)>= 2))
OR
(EXISTS (SELECT * FROM mainaccountingyear WHERE completed = 'S' AND ayear = @ayear) 
	AND @nlevel <= @unifiedfinlevel)
BEGIN

	DECLARE @newidfin int

	-- Quando viene ribaltata una voce di bilancio nell'esercizio successivo bisogna controllare innanzitutto che non ce ne sia già una esistente
	-- quindi si deve verificare che la terna ayear, codefin, flag non sia già presente nell'esercizio successivo, in tal caso si collega in finlookup
	-- questa voce
	
	SELECT @newidfin = idfin
	FROM fin
	WHERE (ayear = @ayear + 1)
		AND (codefin = @fincode)
		AND ((flag & 1) = (@flag & 1))
	
	DECLARE @existsfin char(1)

	IF (@newidfin IS NOT NULL)
	BEGIN
		SET @existsfin = 'S'
	END
	ELSE
	BEGIN
		SET @existsfin = 'N'
	END
	
	-- Se esiste la voce di bilancio riempio solamente finlookup nel caso in cui non ci sia un lookup sulla voce che sto inserendo
	IF (@existsfin = 'S')
	BEGIN
	
		INSERT INTO finlookup (oldidfin, newidfin, ct, cu, lt, lu)
		VALUES(@oldidfin, @newidfin, GETDATE(), 'trigger_fin_copy', GETDATE(), '''trigger_fin_copy''')
	END
	ELSE
	-- Se la voce non esiste mi comporto come prima
	BEGIN

		SET @newidfin = 1 + ISNULL((SELECT MAX(idfin) FROM fin),0)

		DECLARE @err_condition char(1)
		SET @err_condition = 'N'
	
		DECLARE @newparidfin int
		IF (@paridfin IS NOT NULL)
		BEGIN
			SELECT @newparidfin = newidfin FROM finlookup WHERE oldidfin = @paridfin
			
			IF ((@newparidfin IS NULL) OR (ISNULL((SELECT COUNT(*) FROM fin WHERE idfin = @newparidfin),0) = 0))
			BEGIN
				SET @err_condition = 'S'
			END
		END

		IF (@err_condition = 'N')
		  BEGIN
		   INSERT INTO fin
		   (
		    idfin, ayear, codefin, paridfin,
		    nlevel, printingorder, title, flag,
		    cu, ct, lu, lt
		   )
		   VALUES
		   (
		    @newidfin, @ayear + 1, @fincode, @newparidfin,
		    @nlevel, @printingorder, @title, @flag, 
		    'trigger_fin_copy', GETDATE(), '''trigger_fin_copy''', GETDATE()
		   )
		  END
		
		--- Fare una INSERT in FINLOOKUP nel caso in cui non esista già la riga
		IF (@err_condition = 'N')
		BEGIN
			INSERT INTO finlookup (oldidfin, newidfin, ct, cu, lt, lu)
			VALUES(@oldidfin, @newidfin, GETDATE(), 'trigger_fin_copy', GETDATE(), '''trigger_fin_copy''')
		END
	END
END



-- Parte di propagazione delle modifiche a tutti i dipartimenti
IF (user<>'amministrazione' OR @cu='trigger_fin_copy') return
IF (( 
SELECT TRIGGER_NESTLEVEL ()) > 1 ) 
RETURN

CREATE TABLE #fin
(
	idfin int,
	ayear smallint,
	codefin varchar(50),
	flag tinyint,
	ct datetime, cu varchar(64), lt datetime, lu varchar(64),
	nlevel char(1),
	paridfin int,
	printingorder varchar(50),
	title varchar(150)
)

INSERT INTO #fin
(
	idfin, ayear, codefin, flag,
	nlevel, paridfin, printingorder,
	title,
	ct, cu, lt, lu
)
SELECT 
	idfin, ayear, codefin, flag,
	nlevel, paridfin, printingorder,
	title,
	ct, 'trigger_fin_copy', lt, lu
FROM inserted
WHERE nlevel <= @unifiedfinlevel
and cu <> 'trigger_fin_copy'

DECLARE @currdep varchar(50)
SET @currdep = user

DECLARE @iddbdepartment varchar(50)

declare @cursfin cursor


declare @new_ayear smallint
declare @new_codefin varchar(100) 
declare @new_parcodefin varchar(100)
declare @new_printingorder varchar(100) 
declare @new_flagfin tinyint
declare @new_parflagfin tinyint
declare @new_nlevel tinyint
declare @new_title varchar(300)


DECLARE @cursore cursor

SET @cursore = CURSOR FOR
SELECT  iddbdepartment FROM dbdepartment WHERE iddbdepartment <> @currdep
OPEN @cursore
FETCH NEXT FROM @cursore INTO @iddbdepartment
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SET @cursfin = CURSOR FOR
	SELECT  #fin.ayear, #fin.codefin, #fin.flag, #fin.nlevel,PAR.codefin,#fin.printingorder,#fin.title FROM #fin 
		left outer join fin PAR on PAR.idfin=#fin.paridfin
		ORDER BY #fin.nlevel
		
	OPEN @cursfin
	FETCH NEXT FROM @cursfin INTO @new_ayear,@new_codefin,@new_flagfin,
			@new_nlevel,@new_parcodefin,@new_printingorder, @new_title
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--print 'entra'
		set @new_codefin=''''+replace(@new_codefin,'''','''''') + ''''
		set @new_parcodefin=''''+replace(@new_parcodefin,'''','''''') + ''''
		set @new_printingorder=''''+replace(@new_printingorder,'''','''''') + ''''
		set @new_title=''''+replace(@new_title,'''','''''') + ''''
		set @new_parflagfin= @new_flagfin & 1
		
		print @iddbdepartment
		print @new_codefin
		print @new_parcodefin
		print @new_printingorder
		print @new_parflagfin
		DECLARE @sql nvarchar(2000)

		SET @sql = N'
		if not exists(select * from [' + @iddbdepartment + '].fin where codefin = ' +  
		@new_codefin + ' and ayear = '+
		convert(varchar(5),@new_ayear)+' and (flag&1)= '+isnull(convert(varchar(5),@new_parflagfin),'null')+') '+						
		'INSERT INTO [' + @iddbdepartment + '].fin' +
		' (idfin, ayear, codefin, flag, nlevel, paridfin, printingorder, title, ct, cu, lt, lu)' +
		' SELECT '+
		' ISNULL((SELECT MAX(idfin) from [' + @iddbdepartment + '].fin),0)+1, '+
		convert(varchar(5),@new_ayear)+', '+
		@new_codefin+', '+
		convert(varchar(20),@new_flagfin)+', '+
		convert(varchar(5),@new_nlevel)+', '+
			'(SELECT idfin from ['+@iddbdepartment+'].fin where codefin='+isnull(@new_parcodefin, 'null')+
				'  and ayear='+convert(varchar(5),@new_ayear)+
				'  and (flag & 1)='+isnull(convert(varchar(5),@new_parflagfin),'null')+'), ' +
		@new_printingorder+', '+
		@new_title+', '+
		'getdate(),''trigger_fin_copy'',getdate(),''trigger_i_fin'' '
		--PRINT @sql
		EXEC SP_EXECUTESQL @sql
		
		
		FETCH NEXT FROM @cursfin INTO @new_ayear,@new_codefin,@new_flagfin,
		@new_nlevel,@new_parcodefin,@new_printingorder, @new_title
	END --WHILE

	CLOSE @cursfin
	DEALLOCATE @cursfin

	FETCH NEXT FROM @cursore INTO @iddbdepartment
END --WHILE

CLOSE @cursore
DEALLOCATE @cursore

DROP TABLE #fin


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


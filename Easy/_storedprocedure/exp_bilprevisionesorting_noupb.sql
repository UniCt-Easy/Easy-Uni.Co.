
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilprevisionesorting_noupb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilprevisionesorting_noupb]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_bilprevisionesorting_noupb]
(
	@ayear int,--> anno del bilancio di previsione
	@finpart char(1),
	@idsorkindfin int
)
AS BEGIN


--  exec exp_bilprevisionesorting_noupb 2012,'S', 23

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

-- @fin_kind = 1-comp, 2-cassa, 3 comp. e cassa

DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind
FROM config
WHERE ayear = @ayear


CREATE TABLE #data
(
	codefin varchar(50),
	fin varchar(200),
	
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	currentarrears decimal(19,2)
)

insert into #data (
	codefin,
	fin,
	
	initialprevision,
	previousprevision,
	secondaryprevision,
	currentarrears)
SELECT 
	S_ALL.sortcode,	
	S_ALL.description, 
	ISNULL(SUM(isnull(FS.quota,1)*finyear.prevision),0),
	ISNULL(SUM(isnull(FS.quota,1)*finyear.previousprevision),0), 
	ISNULL(SUM(isnull(FS.quota,1)*finyear.secondaryprev),0) ,
	ISNULL(SUM(isnull(FS.quota,1)*finyear.currentarrears),0)
FROM sorting S_ALL
	join sortinglink SL on SL.idparent= S_ALL.idsor
	JOIN sorting sorFin	on SL.idchild = sorFin.idsor
	left outer JOIN finsorting FS ON sorFin.idsor = FS.idsor	
	left outer JOIN fin	ON FS.idfin = fin.idfin	 AND fin.ayear = @ayear AND ((fin.flag & 1)= @finpart_bit) 	
	LEFT OUTER JOIN finlast	 ON fin.idfin = finlast.idfin
	left outer join  finyear ON finyear.idfin = fin.idfin
	WHERE 			
		S_ALL.idsorkind= @idsorkindfin
group by  S_ALL.sortcode, S_ALL.description


DECLARE @SQL_string nvarchar(4000) --> Variabile che immagazzina la stringa di comando SQL


DECLARE @Col_codefin varchar(50)
DECLARE @Col_fin varchar(100)
IF (@idsorkindfin is null) 
Begin
	SET @Col_codefin = 'Cod.Bilancio'
	SET @Col_fin = 'Bilancio'
End
ELSE
Begin
	SELECT  @Col_codefin = 'Class.'+codesorkind FROM sortingkind WHERE idsorkind = @idsorkindfin
	SELECT @Col_fin =  'Descr.Class.'+codesorkind FROM sortingkind WHERE idsorkind = @idsorkindfin
End

SET @Col_codefin = quotename(@Col_codefin,'''')
SET @Col_fin = quotename(@Col_fin,'''')

declare @ayearChar varchar(4)
set @ayearChar = convert(varchar(10),@ayear)

declare @ayearPrecChar varchar(4)
set @ayearPrecChar = convert(varchar(4),@ayear-1)

				
IF( @fin_kind = 3)
Begin
	SET @SQL_string = N'SELECT '+
				''''+@finpart + ''' as ''E/S'','+
				' codefin as '+ @Col_codefin + ','+
				' fin as '+@Col_fin + ','+
				' ISNULL(SUM(currentarrears),0) AS ''Residui presunti dell''''anno '+ @ayearPrecChar+''',
				ISNULL(SUM(previousprevision),0) AS ''Prev. definitive Competenza '+ @ayearPrecChar+''',
				 case 
					when isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )>0
					then isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )
					else 0
				End as ''Var. Aumento''	,
				case 
					when isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )<0
					then ISNULL(SUM(previousprevision),0) - isnull(SUM(initialprevision),0)
					else 0
				End as ''Var. Diminuzione''	,
				isnull(SUM(initialprevision),0) as ''Totale Prev.Competenza '+@ayearChar+''',
				ISNULL(SUM(secondaryprevision),0) AS ''Previsioni di cassa per l''''anno '+@ayearChar+'''
				FROM #data
				GROUP BY codefin, fin
				ORDER BY codefin
				'
End
ELSE
Begin
	SET @SQL_string = N'SELECT '+
				''''+@finpart + ''' as ''E/S'','+
				' codefin as '+ @Col_codefin + ','+
				' fin as Descrizione ,'+
				' ISNULL(SUM(previousprevision),0) AS ''Prev. definitive '+ @ayearPrecChar+''',
				 case 
					when isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )>0
					then isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )
					else 0
				End as ''Var. Aumento''	,
				case 
					when isnull(SUM(initialprevision),0) - (ISNULL(SUM(previousprevision),0) )<0
					then ISNULL(SUM(previousprevision),0) - isnull(SUM(initialprevision),0)
					else 0
				End as ''Var. Diminuzione''	,
				isnull(SUM(initialprevision),0) as ''Totali '+@ayearChar+'''
				FROM #data
				GROUP BY codefin, fin
				ORDER BY codefin
				'
End
print @SQL_string
EXEC sp_executesql @SQL_string



				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilprevisionesorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilprevisionesorting]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_bilprevisionesorting]
(
	@ayear int,--> anno del bilancio di previsione
	@finpart char(1),
	@idsorkindfin int,
    @idsorkindupb int

)
AS BEGIN


--  exec exp_bilprevisionesorting 2012,'S', 23, 6

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
	codeupb varchar(50),
	upb varchar(200),

	codefin varchar(50),
	fin varchar(200),
	
	initialprevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	currentarrears decimal(19,2)
)

insert into #data (
	codeupb,
	upb,
	codefin,
	fin,
	
	initialprevision,
	previousprevision,
	secondaryprevision,
	currentarrears)
SELECT 
	isnull(sorUpb.sortcode,	upb.codeupb),
	isnull(sorUpb.description,	upb.title),
	isnull(sorFin.sortcode,	fin.codefin),
	isnull(sorFin.description, fin.title),
	ISNULL(SUM(isnull(US.quota,1)*isnull(FS.quota,1)*finyear.prevision),0),
	ISNULL(SUM(isnull(US.quota,1)*isnull(FS.quota,1)*finyear.previousprevision),0), 
	ISNULL(SUM(isnull(US.quota,1)*isnull(FS.quota,1)*finyear.secondaryprev),0) ,
	ISNULL(SUM(isnull(US.quota,1)*isnull(FS.quota,1)*finyear.currentarrears),0)
FROM finyear 
JOIN fin  
	ON finyear.idfin = fin.idfin
JOIN upb 
	ON finyear.idupb = upb.idupb
JOIN finlast 
	ON fin.idfin = finlast.idfin
LEFT OUTER JOIN finsorting FS
	ON FS.idfin = fin.idfin	 AND FS.idsor in (select idsor from sorting where idsorkind = @idsorkindfin)
LEFT OUTER JOIN sorting sorFin
	ON sorFin.idsor = FS.idsor				
LEFT OUTER JOIN upbsorting US 
	ON US.idupb = upb.idupb	AND US.idsor in (select idsor from sorting where idsorkind = @idsorkindupb)
LEFT OUTER JOIN sorting sorUpb
	ON sorUpb.idsor = US.idsor				
WHERE fin.ayear = @ayear
		AND ((fin.flag & 1)= @finpart_bit) 
		AND ( sorFin.idsorkind = @idsorkindfin	OR @idsorkindfin is null)
		AND ( sorUpb.idsorkind = @idsorkindupb	OR @idsorkindupb is null)
group by  isnull(sorUpb.sortcode,	upb.codeupb), isnull(sorUpb.description,	upb.title),
	isnull(sorFin.sortcode,	fin.codefin), isnull(sorFin.description, fin.title)


DECLARE @SQL_string nvarchar(4000) --> Variabile che immagazzina la stringa di comando SQL

DECLARE @Col_upb varchar(100)
DECLARE @Col_codeupb varchar(50)
IF(@idsorkindupb is null) 
Begin
	SET @Col_codeupb = 'Cod.UPB'
	SET @Col_upb = 'UPB'
End
ELSE
Begin
	SELECT @Col_codeupb = 'Class.'+codesorkind from sortingkind where idsorkind = @idsorkindupb
	SELECT @Col_upb = 'Descr.Class.'+codesorkind from sortingkind where idsorkind = @idsorkindupb
End

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

SET @Col_codeupb=quotename(@Col_codeupb,'''')
SET @Col_upb=quotename(@Col_upb,'''')
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
				' codeupb as '+ @Col_codeupb + ','+
				' upb as '+ @Col_upb + ','+
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
				GROUP BY codeupb, upb, codefin, fin'
End
ELSE
Begin
	SET @SQL_string = N'SELECT '+
				''''+@finpart + ''' as ''E/S'','+
				' codeupb as '+ @Col_codeupb + ','+
				' upb as Descrizione ,'+
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
				GROUP BY codeupb, upb, codefin, fin'
End
print @SQL_string
EXEC sp_executesql @SQL_string



				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



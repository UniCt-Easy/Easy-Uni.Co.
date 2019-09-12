if exists (select * from dbo.sysobjects where id = object_id(N'[exp_lcardvar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_lcardvar]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE   PROCEDURE exp_lcardvar
	@idlcard     int, --numero card di riferimento
	@ayear       int  -- esercizio di riferimento
	AS
	BEGIN
	
DECLARE @idfin_store int
DECLARE @finpart_store char(1)

DECLARE @codefin_store varchar(50)
DECLARE @fin_store varchar(150)

SELECT @idfin_store = idfin_store FROM config
WHERE ayear = @ayear

--select @idfin_store, @codefin_store, @finpart_store, @fin_store

SELECT	@codefin_store = fin.codefin,
		@finpart_store = CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End ,
		@fin_store = fin.title 
FROM    fin 
WHERE	fin.idfin = @idfin_store

	SELECT   
		lcardview.idlcard as '# Card',
		lcardview.title as 'Descrizione',
		lcardview.extcode as 'Cod. esterno',
		lcardview.manager as 'Titolare',
		lcardview.store as 'Magazzino',
		'n° ' + convert (varchar(4),lcardvar.nlvar) +  '/' + convert (varchar(10),lcardvar.ylvar) + 'del ' +
		convert(varchar(10), lcardvar.adate,105 )  as 'Richiesta Ricarica',
		--lcardvar.adate as 'Data Rich.',
		lcardvar.amount as 'Importo Rich.',
		'n° ' +convert (varchar(10),finvar.nvar) +  '/' + convert (varchar(4),finvar.yvar) + 'del ' + 
		convert(varchar(10), finvar.adate,105)  as 'Var. bilancio',
		finvar.nofficial as 'Num. ufficiale',
		'n° ' + convert (varchar(10),enactment.nenactment) + '/' + convert (varchar(4),enactment.yenactment) as 'Atto Amministrativo',  
		finvar.description as 'Descr. Var',
		abs(f1.amount) as 'Importo. dett.',
		CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End  + '-' +
		fin.codefin + ' ' +
		fin.title as 'Bilancio Ricarica',
		@finpart_store + '-' +  @codefin_store + ' ' + @fin_store as 'Bilancio Storno',
		upb.codeupb as 'Cod. UPB',
		upb.title as 'UPB' --,
	FROM  lcardvar
	JOIN lcardview
		ON lcardvar.idlcard = lcardview.idlcard
	JOIN finvar
		ON 	finvar.yvar = lcardvar.yvar
		AND finvar.nvar = lcardvar.nvar
	JOIN finvardetail F1
		ON F1.yvar = finvar.yvar
		AND F1.nvar = finvar.nvar
	JOIN fin
		ON fin.idfin = F1.idfin
	JOIN upb
		ON upb.idupb = F1.idupb
	LEFT OUTER  JOIN enactment
		ON enactment.idenactment = finvar.idenactment
	WHERE lcardview.idlcard = @idlcard
	AND	  lcardvar.ylvar = @ayear
	AND	  F1.idfin = lcardvar.idfin
	AND   F1.idupb = lcardvar.idupb
	ORDER BY lcardvar.ylvar,
			 lcardvar.nlvar
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--[exp_lcardvar] 9, 2011
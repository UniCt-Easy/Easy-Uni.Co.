
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_generale_sub_variazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_generale_sub_variazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE                    PROCEDURE rpt_partitario_generale_sub_variazioni
	@ayear int,			
	@idupb	varchar(36),	
	@nlevel tinyint ,	-- livello di bilancio:lo prende dal report principale
	@stop datetime,
	@variationtype char(1),		-- P : prev. Principale, S : prev. Secondaria, I : Crediti E Incassi
	@idfin int
AS
BEGIN

DECLARE @firstday datetime
SET @firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

DECLARE @MostraVarBilancio varchar(50)
DECLARE @MostraVarDotazione varchar(50)
SELECT @MostraVarBilancio = isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname='MostraVarBilancio'

SELECT @MostraVarDotazione = isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname='MostraVarDotazione'

IF ( @variationtype = 'P' and @MostraVarBilancio='S')
BEGIN
	SELECT 										
		finvardetail.idfin,
		finvardetail.idupb,
		upb.codeupb,
		finvar.adate,
		finvar.yvar,
		finvar.nvar,
		finvar.official as flagnofficial,
		finvar.description,
		finvardetail.amount,
		'Prev. Principale' as flagvariation,
		finvar.nofficial,
		finvar.variationkind,
		finvar.enactment
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb 
		ON upb.idupb=finvardetail.idupb 
	WHERE finvar.flagprevision = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @firstday AND @stop
		AND (finvardetail.idfin  = @idfin)
		AND (finvardetail.idupb = @idupb)
	ORDER BY finvar.adate,finvar.yvar,finvar.nvar
	RETURN
END

IF  (@variationtype = 'S' and @MostraVarBilancio='S')
BEGIN
	SELECT 										
		finvardetail.idfin,
		finvardetail.idupb,
		upb.codeupb,
		finvar.adate,
		finvar.yvar,
		finvar.nvar,
		finvar.official as flagnofficial,
		finvar.description,
		finvardetail.amount,
		'Prev. Secondaria' as flagvariation,
		finvar.nofficial,
		finvar.variationkind,
		finvar.enactment
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb 
		ON upb.idupb=finvardetail.idupb 
	WHERE finvar.flagsecondaryprev = 'S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate BETWEEN @firstday AND @stop
		AND (finvardetail.idupb = @idupb)
		AND (finvardetail.idfin = @idfin)
	ORDER BY finvar.adate,finvar.yvar,finvar.nvar
	RETURN
END

IF ( @variationtype='I' and @MostraVarDotazione ='S')
BEGIN
	SELECT 										
		finvardetail.idfin,
		finvardetail.idupb,
		upb.codeupb,
		finvar.adate,
		finvar.yvar,
		finvar.nvar,
		finvar.official as flagnofficial,
		finvar.description,
		finvardetail.amount,
		CASE	WHEN  ( finvar.flagcredit = 'S' AND finvar.flagproceeds = 'S' )THEN 'Dot.Crediti e Dot. Cassa'
			WHEN  finvar.flagcredit = 'S'	THEN 'Dot.Crediti             '
			WHEN  finvar.flagproceeds = 'S'	THEN 'Dot.Cassa               '	
		END AS  flagvariation,
		finvar.nofficial,
		finvar.variationkind,
		finvar.enactment
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN upb 
		ON upb.idupb=finvardetail.idupb 
	WHERE ( finvar.flagcredit = 'S'	OR finvar.flagproceeds = 'S') 
		AND finvar.idfinvarstatus = 5
		AND finvar.adate <= @stop
		AND finvar.yvar = @ayear
		AND (finvardetail.idupb = @idupb)
		AND (finvardetail.idfin  = @idfin)
	ORDER BY finvar.adate,finvar.yvar,finvar.nvar
	RETURN
END

SELECT 										
	NULL AS idfin,
	NULL AS idupb,
	NULL AS codeupb,
	NULL AS adate,
	NULL AS yvar,
	NULL AS nvar,
	NULL AS flagnofficial,
	NULL AS description,
	NULL AS amount,
	NULL AS flagvariation,
	NULL AS nofficial,
	NULL AS variationkind,
	NULL AS enactment

END






















GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


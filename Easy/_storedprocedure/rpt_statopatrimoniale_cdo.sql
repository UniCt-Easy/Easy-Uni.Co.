
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_cdo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_cdo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
CREATE  PROCEDURE [rpt_statopatrimoniale_cdo]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@apertura   varchar(1)
)
AS BEGIN
-- exec rpt_statopatrimoniale_cdo 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'}, '0001','S','N'
-- exec rpt_statopatrimoniale_cdo 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '0001','S','N'
-- Stato Patrimoniale Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)


DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)


-- Stato Patrimoniale Anno Corrente
DECLARE @sk char(2)
SET @sk = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

CREATE TABLE #conti_d_ordine
	(
		idacc 		varchar(38), 
		code	varchar(50), 
		title		varchar(150), 
		printingordacc varchar(50), 
		py_totaledare decimal(19,2),
		py_totaleavere decimal(19,2),
		p_totaledare decimal(19,2),
		p_totaleavere decimal(19,2)
	)
		

INSERT INTO #conti_d_ordine
(
		idacc, 
		code, 
		title, 
		printingordacc
)
SELECT
	idacc,
	codeacc,
	title,
	printingorder
FROM 
	account
WHERE ((account.flag&4)<> 0)
AND account.ayear = @ayear 


--SELECT * FROM #conti_d_ordine


--select oldidacc,newidacc FROM accountlookup join #conti_d_ordine on  newidacc =  #conti_d_ordine.idacc
UPDATE #conti_d_ordine
SET   p_totaledare = -isnull((SELECT SUM(amount) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
			     WHERE  amount < 0 AND
				(entrydetail.idupb like @idupb  OR @idupb is null) AND
			     entrydetail.idacc = #conti_d_ordine.idacc and
		         entry.adate between @start and @stop
				 AND (@apertura ='N' or entry.identrykind=7)
			     ),0)


UPDATE #conti_d_ordine
SET   p_totaleavere =  isnull((SELECT SUM(amount) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
			     WHERE  amount > 0 
			     AND entrydetail.idacc = #conti_d_ordine.idacc 
			     AND  (entrydetail.idupb like @idupb  OR @idupb is null)
			     AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		         AND entry.adate between @start and @stop
				 AND (@apertura ='N' or entry.identrykind=7)
			     ),0)

			     
UPDATE #conti_d_ordine
SET   py_totaledare = -isnull((SELECT SUM(amount) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
				 join accountlookup ON #conti_d_ordine.idacc = accountlookup.newidacc
			     WHERE  amount < 0 
				 AND  entrydetail.idacc = accountlookup.oldidacc
			     AND  (entrydetail.idupb like @idupb  OR @idupb is null)
			     AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		         AND entry.adate between @firstdayPY and @lastdayPY
			     ),0)


UPDATE #conti_d_ordine
SET   py_totaleavere = isnull((SELECT SUM(amount) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
				 join accountlookup ON #conti_d_ordine.idacc = accountlookup.newidacc
			     WHERE  amount > 0 
				 AND  entrydetail.idacc = accountlookup.oldidacc
			     AND  (entrydetail.idupb like @idupb  OR @idupb is null)
			     AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
				 AND entry.adate between  @firstdayPY and @lastdayPY
			     ),0)
			     
			     

 
 

SELECT * FROM


#conti_d_ordine



END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



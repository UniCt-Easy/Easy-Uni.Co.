/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_performed]
GO
--setuser 'amministrazione'
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_proceeds_performed 2024, {d '2024-12-15'}, {d '2024-12-31'}, null, 'S'
CREATE    PROCEDURE [exp_proceeds_performed]
	@ayear 		int,
	@start 		datetime,
	@stop 		datetime,
	@idtreasurer int,
	@documentiesitati char(1) --Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio

AS BEGIN

DECLARE @cashvaliditykind tinyint
SELECT	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

DECLARE @31dicCurr datetime
SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

CREATE TABLE #journal
(
	ymov int,
	nmov int,
	adate datetime,
	amount decimal(19,2),
	amount_var decimal(19, 2),
	flagarrear char(1),
	ypro int,
	npro int,		
	proceeds_adate datetime,
	competencydate datetime		
)

INSERT INTO #journal
(
	ymov,
	nmov,
	adate,
	amount,
	amount_var,
	flagarrear,
	ypro,
	npro,		
	proceeds_adate,
	competencydate	
)
SELECT
	hpv.ymov,
	hpv.nmov,
	hpv.adate,
	sum(hpv.amount),
	isnull(
		(select sum(IV.amount)
		FROM   incomevar IV
		JOIN historyproceedsview HPV2 on HPV2.idinc = IV.idinc
		where IV.idinc = hpv.idinc
		and	IV.yvar = @ayear
		and HPV2.ymov = @ayear
		AND (HPV2.idtreasurer = @idtreasurer		 or @idtreasurer is null)
		AND (
		(HPV2.competencydate between @start and @stop
  			AND ( 
				((IV.autokind <> 11) AND(IV.autokind <> 10)) 
				OR IV.autokind is null
          						)
		)
		OR
		(IV.adate between @start and @stop
			AND ((IV.autokind = 11)OR(IV.autokind = 10 )) 
		) 
		)
		)
	,0),
	hpv.flagarrear,
	hpv.ypro,
	hpv.npro,
	p.adate,
	hpv.competencydate
FROM historyproceedsview hpv
join proceeds p on p.kpro = hpv.kpro 
WHERE hpv.competencydate between @start and @stop
and hpv.ymov = @ayear
and (hpv.idtreasurer = @idtreasurer or @idtreasurer is null)
GROUP BY hpv.ymov, hpv.nmov, hpv.adate, hpv.idinc, hpv.flagarrear, hpv.ypro, hpv.npro, p.adate, hpv.competencydate

if ( @cashvaliditykind = 4 and @documentiesitati='S')
Begin
	WITH
	banktr (idinc, amount, transactiondate)  
	AS  
	(  
		SELECT idinc, SUM(amount)AS amount,  max(transactiondate) AS transactiondate  
		FROM banktransaction where idinc is not null
		GROUP BY idinc  
	)
	INSERT INTO #journal
	(
		ymov,
		nmov,
		adate,
		amount,
		amount_var,
		flagarrear,
		ypro,
		npro,		
		proceeds_adate,
		competencydate	
	)
	SELECT
		IL.ymov,
		IL.nmov,
		IL.adate,
		sum(IL.amount),
		0,
		IL.flagarrear,
		p.ypro,
		p.npro,
		p.adate,
		banktr.transactiondate
	FROM incomelastview IL  
	JOIN proceeds p on p.kpro = IL.kpro
	JOIN  banktr on banktr.idinc = IL.idinc and year(banktr.transactiondate) = @ayear + 1
	WHERE IL.ymov 	= @ayear AND @stop >= @31dicCurr
		AND (p.idtreasurer = @idtreasurer	 or @idtreasurer is null)
	GROUP BY IL.ymov, IL.nmov, IL.adate, IL.flagarrear, p.ypro, p.npro, p.adate, banktr.transactiondate
end

IF @cashvaliditykind <> 4
BEGIN
	INSERT INTO #journal
	(
		ymov,
		nmov,
		adate,
		amount,
		amount_var,
		flagarrear,
		ypro,
		npro,		
		proceeds_adate,
		competencydate
	)
	SELECT
		HPV.ymov,
		HPV.nmov,
		IV.adate,
		0,
		sum(IV.amount),
		HPV.flagarrear,
		HPV.ypro,
		HPV.npro,
		p.adate,
		HPV.competencydate
	FROM incomevar IV
		JOIN historyproceedsview HPV ON HPV.idinc = IV.idinc AND HPV.ymov = @ayear
		JOIN proceeds p on p.kpro = HPV.kpro
	WHERE IV.yvar = @ayear
		AND isnull(IV.autokind,'') <>'22' 
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
		AND (
		(HPV.competencydate BETWEEN @start AND @stop
				AND ( 
				((IV.autokind <> 11) AND(IV.autokind <> 10)) 
				OR IV.autokind IS NULL)
		)
		OR
		(IV.adate  BETWEEN @start AND @stop
			AND ((IV.autokind = 11) OR (IV.autokind = 10)) 
		))
	GROUP BY HPV.ymov, HPV.nmov, IV.adate, HPV.flagarrear, HPV.ypro, HPV.npro, p.adate, HPV.competencydate
END



SELECT 
	ymov as 'Esercizio Movimento',
	nmov as 'Numero Movimento',
	adate as 'Data Movimento',
	sum(amount) as 'Importo',
	sum(amount_var) as 'Variazioni',
	flagarrear as 'Tipo Movimento',
	ypro as 'Esercizio Reversale',
	npro as 'Numero Reversale',		
	proceeds_adate as 'Data Reversale',
	competencydate as 'Data Esitazione'
FROM #journal
GROUP BY ymov, nmov, adate, flagarrear, ypro, npro, proceeds_adate, competencydate
ORDER BY competencydate, npro

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
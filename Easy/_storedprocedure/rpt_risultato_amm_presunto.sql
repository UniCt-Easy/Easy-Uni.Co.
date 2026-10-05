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

-- setuser setuser 'amministrazione'
-- CREAZIONE PROCEDURE [rpt_risultato_amm_presunto]
IF EXISTS (select * from sysobjects where id = object_id(N'[rpt_risultato_amm_presunto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [rpt_risultato_amm_presunto]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_risultato_amm_presunto '2025'
CREATE PROCEDURE [rpt_risultato_amm_presunto]
	@ayear smallint
AS
BEGIN

	declare @ayear_prev smallint
	set @ayear_prev = @ayear - 1

	declare @ayear_prev2 smallint
	set @ayear_prev2 = @ayear - 2

	DECLARE @date date
	SET @date = CONVERT(date,'31-12-' + CONVERT(varchar(4),@ayear_prev),105)

	DECLARE @finphase_entrate tinyint
	DECLARE @finphase_uscite tinyint

	SELECT @finphase_entrate = assessmentphasecode
	FROM config
	WHERE ayear = @ayear_prev
	IF @finphase_entrate IS NULL
	BEGIN
		SELECT @finphase_entrate = incomefinphase FROM uniconfig
	END

	SELECT @finphase_uscite = appropriationphasecode
	FROM config
	WHERE ayear = @ayear_prev
	IF @finphase_uscite IS NULL
	BEGIN
		SELECT @finphase_uscite = expensefinphase FROM uniconfig
	END

	DECLARE @idsorkind int
	DECLARE @idsorVincolate int
	DECLARE @idsorNon_Vincolate int

	--- per calcolare la classificazione
	SELECT @idsorkind = idsorkind from sortingkind where codesorkind = 'Voci_Fin_Vincolate'

	--- per calcolare la idsor delle voci di Bil. Vincolate
	SELECT @idsorVincolate = idsor from sorting where idsorkind= @idsorkind and sortcode = 'Vincolate'

	--- per calcolare la idsor delle voci di Bil. NON Vincolate
	SELECT @idsorNon_Vincolate = idsor from sorting where idsorkind= @idsorkind and sortcode = 'NonVincolate'
		
	CREATE TABLE #data
	(
		recordtype int,
		ordercode varchar(50),
		title varchar(max),
		import decimal(19,2)
	)

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0001',
		'FONDO CASSA INIZIALE',
		isnull(max((isnull(startfloatfund, 0) + isnull(competencyproceeds, 0) + isnull(residualproceeds, 0)) - (isnull(competencypayments,0) + isnull(residualpayments,0))), 0)
	from surplus
	where ayear = @ayear_prev2

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0002',
		'+ RESIDUI ATTIVI INIZIALI',
		isnull(max(isnull(previousrevenue, 0) + isnull(currentrevenue, 0)), 0)
	from surplus
	where ayear = @ayear_prev2

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0003',
		'- RESIDUI PASSIVI INIZIALI',
		isnull(max(isnull(previousexpenditure, 0) + isnull(currentexpenditure, 0)), 0)
	from surplus
	where ayear = @ayear_prev2

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0004',
		'= AVANZO/DISAVANZO DI AMMINISTRAZIONE INIZIALE',
		isnull(max(((isnull(startfloatfund, 0) + isnull(competencyproceeds, 0) + isnull(residualproceeds, 0)) - (isnull(competencypayments, 0) + isnull(residualpayments, 0))) +
		(isnull(previousrevenue, 0) + isnull(currentrevenue, 0)) -
		(isnull(previousexpenditure, 0) + isnull(currentexpenditure, 0))), 0)
	from surplus
	where ayear = @ayear_prev2

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0005',
		'+ ENTRATE GIA'' ACCERTATE NELL''ESERCIZIO',
		isnull(sum(isnull(totale.somma, 0)), 0)
	FROM 
	(
		select
			isnull(SUM(isnull(IY.amount, 0)), 0) as somma
		from income I
		JOIN incomeyear IY			ON IY.idinc = I.idinc
		JOIN upb U					ON IY.idupb = U.idupb
		JOIN incometotal IT			ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK		ON FLK.idchild = IY.idfin AND FLK.nlevel = 1
		WHERE I.adate <= @date
			AND IY.ayear = @ayear_prev
			AND ( (IT.flag & 1) =0)-- Competenza
			AND I.nphase = @finphase_entrate
		
		UNION ALL
	
		SELECT 
			isnull(SUM(isnull(IV.amount, 0)), 0) as somma
		FROM incomevar IV
		JOIN income I			ON IV.idinc = I.idinc
		JOIN incomeyear IY		ON IY.idinc = IV.idinc
		JOIN upb U				ON IY.idupb = U.idupb
		JOIN incometotal IT		ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK		ON FLK.idchild = IY.idfin AND FLK.nlevel = 1
		WHERE IV.yvar = @ayear_prev
			AND IY.ayear = @ayear_prev
			AND ( (IT.flag & 1) =0)-- Competenza
			AND I.nphase = @finphase_entrate
			AND IV.adate <= @date 
	) as totale

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0006',
		'- USCITE GIA'' IMPEGNATE NELL''ESERCIZIO',
		isnull(sum(isnull(totale.somma, 0)), 0)
	FROM 
	(
		SELECT
			isnull(SUM(isnull(EY.amount, 0)), 0) as somma
		FROM expense E
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = 1
		WHERE E.adate <= @date
			AND EY.ayear = @ayear_prev
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND E.nphase = @finphase_uscite
		
		UNION ALL
	
		SELECT
			isnull(SUM(isnull(EV.amount, 0)), 0) as somma
		FROM expensevar EV
		JOIN expense E
			ON EV.idexp = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = 1
		WHERE EV.yvar = @ayear_prev
			AND EV.adate <= @date 
			AND EY.ayear = @ayear_prev
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND E.nphase = @finphase_uscite
	) as totale

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0007',
		'+/- VARIAZIONE DEI RESIDUI ATTIVI GIA'' VERIFICATESI NELL''ESERCIZIO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0008',
		'+/- VARIAZIONE DEI RESIDUI PASSIVI GIA'' VERIFICATESI NELL''ESERCIZIO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0009',
		'= AVANZO/DISAVANZO DI AMMINISTRAZIONE ALLA DATA DELLA REDAZIONE DEL BILANCIO',
		isnull(max(((isnull(startfloatfund, 0) + isnull(competencyproceeds, 0) + isnull(residualproceeds, 0)) - (isnull(competencypayments, 0) + isnull(residualpayments, 0))) +
		(isnull(previousrevenue, 0) + isnull(currentrevenue, 0)) -
		(isnull(previousexpenditure, 0) + isnull(currentexpenditure, 0))), 0)
	from surplus
	where ayear = @ayear_prev

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0010',
		'+ ENTRATE PRESUNTE PER IL RESTANTE PERIODO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0011',
		'- USCITE PRESUNTE PER IL RESTANTE PERIODO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0012',
		'+/- VARIAZIONE DEI RESIDUI ATTIVI, PRESUNTE PER IL RESTANTE PERIODO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0013',
		'+/- VARIAZIONE DEI RESIDUI PASSIVI, PRESUNTE PER IL RESTANTE PERIODO',
		0

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		0,
		'0014',
		'= AVANZO/DISAVANZO DI AMMINISTRAZIONE PRESUNTO AL ' + CONVERT(VARCHAR, @date, 103) + ' DA APPLICARE AL BILANCIO ' + CONVERT(VARCHAR, @ayear),
		SUM(CASE 
			WHEN ordercode IN ('0009', '0010', '0013') THEN isnull(import, 0)
			WHEN ordercode IN ('0011', '0012') THEN -isnull(import, 0)
		END) AS risultato
	from #data
	where ordercode in ('0009', '0010', '0011', '0012', '0013')

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		1,
		f.printingorder,
		f.title, 
		isnull(sum(isnull(fy.prevision,0)), 0)
	from fin f
	join finyear fy on fy.idfin = f.idfin
	join finsorting fs on f.idfin = fs.idfin 
	where idsor = @idsorVincolate
	and f.ayear = @ayear
	group by f.idfin, f.printingorder, f.title

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		2,
		'0001',
		'TOTALE PARTE VINCOLATA',
		isnull(SUM(isnull(import, 0)), 0)
	from #data
	where recordtype = 1

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		3,
		f.printingorder,
		f.title, 
		isnull(sum(isnull(fy.prevision, 0)), 0)
	from fin f
	join finyear fy on fy.idfin = f.idfin
	join finsorting fs on f.idfin = fs.idfin 
	where idsor = @idsorNon_Vincolate
	and f.ayear = @ayear
	group by f.idfin, f.printingorder, f.title

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		4,
		'0001',
		'TOTALE PARTE DISPONIBILE',
		isnull(SUM(isnull(import, 0)), 0)
	from #data
	where recordtype = 3

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		5,
		'0001',
		'Avanzo utilizzato',
		isnull(SUM(isnull(import, 0)), 0)
	from #data
	where recordtype in (2, 4)

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		7,
		'0001',
		'TOTALE RISULTATO DI AMMINISTRAZIONE PRESUNTO',
		isnull(SUM(isnull(import, 0)), 0)
	from #data
	where recordtype = 0 and ordercode = '0014'

	insert into #data
	(
		recordtype,
		ordercode,
		title,
		import
	)
	select
		6,
		'0001',
		'PARTE DI CUI NON SI PREVEDE L''UTILIZZAZIONE NELL''ESERCIZIO ' + CONVERT(VARCHAR, @ayear),
		MAX(CASE WHEN recordtype = 7 THEN isnull(import, 0) END) -
		MAX(CASE WHEN recordtype = 5 THEN isnull(import, 0) END) 
	from #data
	where recordtype in (5, 7)

	SELECT
		recordtype,
		ordercode,
		title,
		import
	from #data
	order by recordtype, ordercode

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
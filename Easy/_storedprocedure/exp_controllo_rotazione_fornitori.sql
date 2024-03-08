
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


--SETUSER'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_controllo_rotazione_fornitori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_controllo_rotazione_fornitori]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--  exec exp_controllo_rotazione_fornitori  4875
CREATE  procedure exp_controllo_rotazione_fornitori
AS BEGIN
-- 1. Impegno Provvisorio
-- 2. Impegno di Aggiudicazione
-- 3. Impegno d'Ordine - contratto passivo 
-- 4. Liquidazione
declare @ayear int
set @ayear = year(getdate())

declare @idsorkind_Obiettivi int 
set @idsorkind_Obiettivi = (select idsorkind from sortingkind where codesorkind='Obiettivi')/*1. Impegno Provvisorio*/

declare @idsorkind_CPV int 
set @idsorkind_CPV = (select idsorkind from sortingkind where codesorkind='CPV')/*3. Impegno d'Ordine*/

declare @idsorkind_COAN_U int 
set @idsorkind_COAN_U = (select idsorkind from sortingkind where codesorkind='COAN_U') /*1. Impegno Provvisorio*/
-- Impegni classificati E CON CONTABILIZZAZIONE TOTALE O SOLO IMPONIBILE
	SELECT  M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', ISNULL(R.cf,R.foreigncf) 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		SortObiettivi.sortcode as 'Class.Obiettivo(cod.)', SortObiettivi.description as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		--SUM(ImpOrdTot.curramount) as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		S02.description as 'Struttura Provedditorali AC',
		S03.description as 'Responsabile che ha emesso l''Ordinativo',
		SortCoAn.description as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_taxable
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpOrd.idexp)
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpAgg.idexp)

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpProvv.idexp)
	join expensesorted SortObiettiviExp on ImpProvv.idexp = SortObiettiviExp.idexp 
	join sorting SortObiettivi on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
	
	join expensesorted SortCoAnExp on ImpProvv.idexp = SortCoAnExp.idexp 
	join sorting SortCoAn on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
	
	--left outer join expense Liq on Liq.parentidexp = ImpOrd.idexp
	--left outer join expenselast EL on Liq.idexp = EL.idexp
	--left outer join payment P on EL.kpay = P.kpay
	--left outer join treasurer T on T.idtreasurer = P.idtreasurer
	left outer join sorting S01 ON M.idsor01 = S01.idsor
	left outer join sorting S02 on M.idsor02 = S02.idsor
	left outer join sorting S03 on M.idsor03 = S03.idsor

	left outer join expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	left outer join sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	left outer join mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	left outer join avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
 AND (R.p_iva IS NOT NULL OR R.foreigncf is not NULL)
	AND M.taxable_euro > 0
	and isnull(ImpProvv.autokind,0) = 131
	and (MD.idexp_taxable = MD.idexp_iva  /*totale*/
		or
		(MD.idexp_taxable IS NOT NULL AND  (MD.idexp_iva IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imponibile*/
	)
	GROUP BY  M.registry ,M.adate, taxable_euro, iva_euro , 
		R.p_iva, ISNULL(R.cf,R.foreigncf) , M.cigcode ,
		M.description, AC.description ,
		SortObiettivi.sortcode , SortObiettivi.description ,
		SortCpv.sortcode, SortCpv.description,
		S01.description,
		S02.description ,
		S03.description ,
		SortCoAn.description,
		ISNULL(ImpOrd.cupcode,MD.cupcode)
UNION
-- Impegni SENZA classificazione Obiettivo o Co.An E CON CONTABILIZZAZIONE TOTALE O SOLO IMPONIBILE
	SELECT  M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', ISNULL(R.cf,R.foreigncf) 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		NULL as 'Class.Obiettivo(cod.)', NULL as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		--SUM(ImpOrdTot.curramount) as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		S02.description as 'Struttura Provedditorali AC',
		S03.description as 'Responsabile che ha emesso l''Ordinativo',
		NULL as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_taxable
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpOrd.idexp)
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear =  (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpAgg.idexp)

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpProvv.idexp)
	
	
	--left outer join expense Liq on Liq.parentidexp = ImpOrd.idexp
	--left outer join expenselast EL on Liq.idexp = EL.idexp
	--left outer join payment P on EL.kpay = P.kpay
	--left outer join treasurer T on T.idtreasurer = P.idtreasurer
	left outer join sorting S01 ON M.idsor01 = S01.idsor
	left outer join sorting S02 on M.idsor02 = S02.idsor
	left outer join sorting S03 on M.idsor03 = S03.idsor

	left outer join expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	left outer join sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	left outer join mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	left outer join avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
 AND (R.p_iva IS NOT NULL OR R.foreigncf is not NULL)
	AND M.taxable_euro > 0
	and (MD.idexp_taxable = MD.idexp_iva  /*totale*/
		or
		(MD.idexp_taxable IS NOT NULL AND  (MD.idexp_iva IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imponibile*/
	)
	AND ( NOT EXISTS (SELECT * FROM expensesorted SortObiettiviExp join sorting SortObiettivi 
											on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
					WHERE ImpProvv.idexp = SortObiettiviExp.idexp) 
		OR
		NOT EXISTS (SELECT * FROM expensesorted SortCoAnExp  join sorting SortCoAn 
											on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
					WHERE  ImpProvv.idexp = SortCoAnExp.idexp )
		)
	GROUP BY  M.registry ,M.adate, taxable_euro, iva_euro , 
		R.p_iva, ISNULL(R.cf,R.foreigncf) , M.cigcode ,
		M.description, AC.description ,
		SortCpv.sortcode, SortCpv.description,
		S01.description,
		S02.description ,
		S03.description ,
		ISNULL(ImpOrd.cupcode,MD.cupcode)
UNION 
-- Impegni classificati E CON CONTABILIZZAZIONE SOLO IMPOSTA
	SELECT  M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', ISNULL(R.cf,R.foreigncf) 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		SortObiettivi.sortcode as 'Class.Obiettivo(cod.)', SortObiettivi.description as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		--SUM(ImpOrdTot.curramount) as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		S02.description as 'Struttura Provedditorali AC',
		S03.description as 'Responsabile che ha emesso l''Ordinativo',
		SortCoAn.description as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_iva
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpOrd.idexp)
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpAgg.idexp)

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpProvv.idexp)
	join expensesorted SortObiettiviExp on ImpProvv.idexp = SortObiettiviExp.idexp 
	join sorting SortObiettivi on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
	
	join expensesorted SortCoAnExp on ImpProvv.idexp = SortCoAnExp.idexp 
	join sorting SortCoAn on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
	
	--left outer join expense Liq on Liq.parentidexp = ImpOrd.idexp
	--left outer join expenselast EL on Liq.idexp = EL.idexp
	--left outer join payment P on EL.kpay = P.kpay
	--left outer join treasurer T on T.idtreasurer = P.idtreasurer
	left outer join sorting S01 ON M.idsor01 = S01.idsor
	left outer join sorting S02 on M.idsor02 = S02.idsor
	left outer join sorting S03 on M.idsor03 = S03.idsor

	left outer join expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	left outer join sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	left outer join mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	left outer join avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
 AND (R.p_iva IS NOT NULL OR R.foreigncf is not NULL)
	and isnull(ImpProvv.autokind,0) = 131
	AND M.iva_euro > 0
	and (MD.idexp_iva IS NOT NULL AND  (MD.idexp_taxable IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imposta*/
	GROUP BY  M.registry ,M.adate, taxable_euro, iva_euro , 
		R.p_iva, ISNULL(R.cf,R.foreigncf) , M.cigcode ,
		M.description, AC.description ,
		SortObiettivi.sortcode , SortObiettivi.description ,
		SortCpv.sortcode, SortCpv.description,
		S01.description,
		S02.description ,
		S03.description ,
		SortCoAn.description,
		ISNULL(ImpOrd.cupcode,MD.cupcode)
UNION
-- Impegni SENZA classificazione Obiettivo o Co.An E CON CONTABILIZZAZIONE SOLO IMPOSTA
	SELECT  M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', ISNULL(R.cf,R.foreigncf) 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		NULL as 'Class.Obiettivo(cod.)', NULL as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		--SUM(ImpOrdTot.curramount) as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		S02.description as 'Struttura Provedditorali AC',
		S03.description as 'Responsabile che ha emesso l''Ordinativo',
		NULL as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_iva
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpOrd.idexp)
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpAgg.idexp)

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = (SELECT MAX(ayear) FROM expenseyear WHERE idexp =  ImpProvv.idexp)
	
	
	--left outer join expense Liq on Liq.parentidexp = ImpOrd.idexp
	--left outer join expenselast EL on Liq.idexp = EL.idexp
	--left outer join payment P on EL.kpay = P.kpay
	--left outer join treasurer T on T.idtreasurer = P.idtreasurer
	left outer join sorting S01 ON M.idsor01 = S01.idsor
	left outer join sorting S02 on M.idsor02 = S02.idsor
	left outer join sorting S03 on M.idsor03 = S03.idsor

	left outer join expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	left outer join sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	left outer join mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	left outer join avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
 AND (R.p_iva IS NOT NULL OR R.foreigncf is not NULL)
	and isnull(ImpProvv.autokind,0) = 131
	AND M.iva_euro > 0
	and (MD.idexp_iva IS NOT NULL AND  (MD.idexp_taxable IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imposta*/
	AND ( NOT EXISTS (SELECT * FROM expensesorted SortObiettiviExp join sorting SortObiettivi 
											on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
					WHERE ImpProvv.idexp = SortObiettiviExp.idexp) 
		OR
		NOT EXISTS (SELECT * FROM expensesorted SortCoAnExp  join sorting SortCoAn 
											on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
					WHERE  ImpProvv.idexp = SortCoAnExp.idexp )
		)
	GROUP BY  M.registry ,M.adate, taxable_euro, iva_euro , 
		R.p_iva, ISNULL(R.cf,R.foreigncf) , M.cigcode ,
		M.description, AC.description ,

		SortCpv.sortcode, SortCpv.description,
		S01.description,
		S02.description ,
		S03.description ,

		ISNULL(ImpOrd.cupcode,MD.cupcode)
Order by registry,taxable_euro
END
GO

-- exec exp_controllo_rotazione_fornitori  

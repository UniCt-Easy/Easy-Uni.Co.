
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_controllo_rotazione_fornitori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_controllo_rotazione_fornitori]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
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

	SELECT distinct M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', R.cf 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		SortObiettivi.sortcode as 'Class.Obiettivo(cod.)', SortObiettivi.description as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		ImpOrdTot.curramount as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		SortCoAn.description as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_taxable
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = @ayear
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear = @ayear

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = @ayear
	join expensesorted SortObiettiviExp on ImpProvv.idexp = SortObiettiviExp.idexp 
	join sorting SortObiettivi on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
	
	join expensesorted SortCoAnExp on ImpProvv.idexp = SortCoAnExp.idexp 
	join sorting SortCoAn on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
	
	join expense Liq on Liq.parentidexp = ImpOrd.idexp
	join expenselast EL on Liq.idexp = EL.idexp
	join payment P on EL.kpay = P.kpay
	join treasurer T on T.idtreasurer = P.idtreasurer
	JOIN sorting S01 ON T.idsor01 = S01.idsor

	JOIN expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	LEFT OUTER JOIN sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	LEFT JOIN mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	LEFT JOIN avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
	AND	R.p_iva IS NOT NULL
	AND taxable_euro > 0
	and isnull(ImpProvv.autokind,0) = 131
	and (MD.idexp_taxable = MD.idexp_iva  /*totale*/
		or
		(MD.idexp_taxable IS NOT NULL AND  (MD.idexp_iva IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imponibile*/
	)
UNION
	SELECT distinct  M.registry 'Fornitore',  
		M.adate 'Data creazione Contratto', taxable_euro 'Imponibile', iva_euro 'Iva' , 
		R.p_iva 'P.Iva', R.cf 'Codice Fiscale', M.cigcode 'Cig',
		M.description 'Descrizione Contratto', AC.description 'Procedura di scelta del contraente',
		SortObiettivi.sortcode as 'Class.Obiettivo(cod.)', SortObiettivi.description as 'Class.Obiettivo',
		SortCpv.sortcode as 'Class.CPV(cod.)', SortCpv.description as 'Class.CPV',
		ImpOrdTot.curramount as 'Importo d''Ordine',
		S01.description as 'Struttura che ha emesso l''Ordinativo',
		SortCoAn.description as 'Co.An',
		ISNULL(ImpOrd.cupcode,MD.cupcode) as 'CUP'
	from mandateview M
	join mandatedetail MD
		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	JOIN registry R ON R.idreg = M.idreg
	join expense ImpOrd on ImpOrd.idexp = MD.idexp_iva
	join expenseyear ImpOrdEY on ImpOrd.idexp = ImpOrdEY.idexp and ImpOrdEY.ayear = @ayear
	JOIN expensetotal ImpOrdTot	ON ImpOrdTot.idexp = ImpOrd.idexp AND ImpOrdTot.ayear = ImpOrdEY.ayear

	join expense ImpAgg on ImpAgg.idexp = ImpOrd.parentidexp  
	join expenseyear ImpAggEY on ImpAgg.idexp = ImpAggEY.idexp and ImpAggEY.ayear = @ayear

	join expense ImpProvv on ImpProvv.idexp = ImpAgg.parentidexp
	join expenseyear ImpProvvEY on ImpProvv.idexp = ImpProvvEY.idexp and ImpProvvEY.ayear = @ayear
	join expensesorted SortObiettiviExp on ImpProvv.idexp = SortObiettiviExp.idexp 
	join sorting SortObiettivi on SortObiettiviExp.idsor = SortObiettivi.idsor and SortObiettivi.idsorkind = @idsorkind_Obiettivi
	
	join expensesorted SortCoAnExp on ImpProvv.idexp = SortCoAnExp.idexp 
	join sorting SortCoAn on SortCoAnExp.idsor = SortCoAn.idsor and SortCoAn.idsorkind = @idsorkind_COAN_U
	
	join expense Liq on Liq.parentidexp = ImpOrd.idexp
	join expenselast EL on Liq.idexp = EL.idexp
	join payment P on EL.kpay = P.kpay
	join treasurer T on T.idtreasurer = P.idtreasurer
	JOIN sorting S01 ON T.idsor01 = S01.idsor

	JOIN expensesorted SortCpvExp on ImpOrd.idexp = SortCpvExp.idexp
	LEFT OUTER JOIN sorting SortCpv on SortCpvExp.idsor = SortCpv.idsor and SortCpv.idsorkind = @idsorkind_CPV
	
	LEFT JOIN mandatecig MC ON M.idmankind = MC.idmankind AND M.yman = MC.yman AND M.nman = MC.nman
	LEFT JOIN avcpchoice AC ON MC.idavcp_choice = AC.idavcp_choice

	WHERE
	getdate() - 365 < M.adate 
	AND	R.p_iva IS NOT NULL
	and isnull(ImpProvv.autokind,0) = 131
	AND iva_euro > 0
	and (MD.idexp_iva IS NOT NULL AND  (MD.idexp_taxable IS NULL OR MD.idexp_taxable<>MD.idexp_iva))  /* SOLO imposta*/
	Order by registry,taxable_euro


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 -- exec exp_controllo_rotazione_fornitori

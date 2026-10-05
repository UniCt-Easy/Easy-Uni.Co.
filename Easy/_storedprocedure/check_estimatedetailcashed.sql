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

if exists (select * from dbo.sysobjects where id = object_id(N'[check_estimatedetailcashed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_estimatedetailcashed]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- --
--SETUSER 'amministrazione'
-- exec [check_estimatedetailcashed] 2024
CREATE    PROCEDURE [check_estimatedetailcashed]
	@ayear	int
AS BEGIN
   	DECLARE @nfinphase tinyint
	SELECT  @nfinphase = incomeregphase FROM uniconfig
	
	DECLARE @maxincomephase tinyint
	SELECT  @maxincomephase = MAX(nphase) FROM   incomephase 
	CREATE TABLE #estimatedetail
	(
		idestimkind varchar(20),
		estimatekind varchar(150), 
		yestim int, 
		nestim int, 
		rownum int,
		idinc_taxable int,
		taxable_row decimal(19,2), 
		cashed_amount decimal(19,2),
		cashed_registered decimal(19,2)
	)

	CREATE TABLE #estimatedetail_cashed
	(
		idestimkind varchar(20),
		estimatekind varchar(150), 
		yestim int, 
		nestim int, 
		rownum int,
		taxable_row decimal(19,2), 
		cashed_amount decimal(19,2),
		cashed_registered decimal(19,2)
	)

	CREATE TABLE #estimatedetail_registered
	(
		idestimkind varchar(20),
		estimatekind varchar(150), 
		yestim int, 
		nestim int, 
		rownum int,
		cashed_registered decimal(19,2)
	)
	INSERT INTO #estimatedetail
	(	
		idestimkind,
		estimatekind, 
		yestim, 
		nestim, 
		rownum,
		idinc_taxable,
		taxable_row, 
		cashed_amount,
		cashed_registered
	)
	SELECT	
			dett.idestimkind,
			k.description as TipoContrattoAttivo, 
			E.yestim as Eserc , 
			E.nestim as Num , 
			dett.rownum as Dettaglio,
			dett.idinc_taxable,
			ROUND(dett.taxable * dett.number * 
		    CONVERT(decimal(19,6),e.exchangerate) * 
		    (1 - CONVERT(decimal(19,6),ISNULL(dett.discount, 0.0))),2) as 'Imponibile riga',
			null,
			null 
		FROM estimatedetail dett 
		join estimate e on dett.idestimkind =	e.idestimkind and			dett.yestim	=	e.yestim and			dett.nestim	=	e.nestim 
		join estimatekind k	on dett.idestimkind = k.idestimkind
	WHERE
			k.linktoinvoice = 'N' -- CA non collegati a fattura
		and dett.idinc_taxable is not null	-- dettagli CA  contabilizzati
		and dett.stop is null
		and dett.yestim =@ayear				
	-- Esiste l'incasso
	and exists ( select * from  incomelink EL 
				join incomelast ELA on EL.idchild=ELA.idinc
				where  EL.idparent=dett.idinc_taxable)

AND
dett.yestim =@ayear

--SELECT * FROM #estimatedetail

INSERT INTO #estimatedetail_cashed
	(	
		idestimkind,
		estimatekind, 
		yestim, 
		nestim, 
		rownum,
		taxable_row, 
		cashed_amount 
	)
SELECT	
		dett.idestimkind,
		dett.estimatekind, 
		dett.yestim as Eserc , 
		dett.nestim as Num , 
		dett.rownum as Dettaglio,
		dett.taxable_row as imponibile, 
		ISNULL((select  sum(incometotal.curramount )
		FROM incomeyear
		JOIN income
			ON incomeyear.idinc = income.idinc 
		JOIN incometotal
			ON  incomeyear.idinc = incometotal.idinc
			AND incomeyear.ayear = incometotal.ayear		
		JOIN incomelink EL2
			ON EL2.idchild = income.idinc  AND EL2.nlevel = @nfinphase
		where income.ymov = @ayear
		and EL2.idparent = dett.idinc_taxable
		and income.nphase = @maxincomephase
		),0)AS  'Importo Incasso' 
		from #estimatedetail dett

--SELECT * FROM #estimatedetail_cashed
INSERT INTO #estimatedetail_registered
	(	
		idestimkind,
		estimatekind, 
		yestim, 
		nestim, 
		rownum,
		cashed_registered
	)
SELECT 
		dett.idestimkind,
		dett.estimatekind, 
		dett.yestim as Eserc , 
		dett.nestim as Num , 
		dett.rownum as Dettaglio,
		ISNULL((select  sum(incomelastestimatedetail.amount )
			FROM income
			JOIN incomelastestimatedetail
				ON  income.idinc = incomelastestimatedetail.idinc
			JOIN incomelink EL2
				ON EL2.idchild = income.idinc  AND EL2.nlevel = @nfinphase
			where income.ymov = @ayear
			and EL2.idparent = dett.idinc_taxable
			and income.nphase = @maxincomephase
			),0) as 'Incassato risultante (in incomelastestimatedetail)'
		from #estimatedetail dett
 	--SELECT * FROM #estimatedetail_registered
	SELECT 	
		--registered.idmankind,
		registered.estimatekind as 'Tipo contratto attivo', 
		registered.yestim  as Eserc, 
		registered.nestim as Num, 
		registered.rownum as Dettaglio,
		cashed.taxable_row as 'Imponibile riga',
		cashed.cashed_amount  AS  'Importo Incassato',
		registered.cashed_registered as 'Incassato risultante(in expenselastmandatedetail)' 
		from 
#estimatedetail_registered registered
JOIN #estimatedetail_cashed  cashed  on 
	cashed.idestimkind = registered.idestimkind and
	cashed.yestim = registered.yestim and
	cashed.nestim = registered.nestim and
	cashed.rownum = registered.rownum  
where  registered.cashed_registered  <> cashed.cashed_amount
-- Importo incasso diverso da expenselastMANDATEdetail


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
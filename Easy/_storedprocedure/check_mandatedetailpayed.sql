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

if exists (select * from dbo.sysobjects where id = object_id(N'[check_mandatedetailpayed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_mandatedetailpayed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- --
--SETUSER 'amministrazione'
-- exec [check_mandatedetailpayed] 2024
CREATE    PROCEDURE [check_mandatedetailpayed]
	@ayear	int
AS BEGIN

   	DECLARE @nfinphase tinyint
	SELECT @nfinphase = expenseregphase FROM uniconfig
	
	DECLARE @maxexpensephase tinyint
	SELECT  @maxexpensephase = MAX(nphase) FROM   expensephase 
	
	--sp_help mandatekind
	CREATE TABLE #mandatedetail
	(
		idmankind varchar(20),
		mandatekind varchar(150), 
		yman int, 
		nman int, 
		rownum int,
		idexp_taxable int,
		taxable_row decimal(19,2), 
		payed_amount decimal(19,2),
		payed_registered decimal(19,2)
	)

	CREATE TABLE #mandatedetail_payed
	(
		idmankind varchar(20),
		mandatekind varchar(150), 
		yman int, 
		nman int, 
		rownum int,
		taxable_row decimal(19,2),
		payed_amount decimal(19,2),
		payed_registered decimal(19,2)
	)

	CREATE TABLE #mandatedetail_registered
	(
		idmankind varchar(20),
		mandatekind varchar(150), 
		yman int, 
		nman int, 
		rownum int,
		payed_registered decimal(19,2)
	)

	INSERT INTO #mandatedetail
	(	
		idmankind,
		mandatekind, 
		yman, 
		nman, 
		rownum,
		idexp_taxable,
		taxable_row, 
		payed_amount,
		payed_registered
	)
	SELECT	
					dett.idmankind,
					k.description as TipoContrattoPassivo, 
					dett.yman as Eserc , 
					dett.nman as Num , 
					dett.rownum as Dettaglio,
					dett.idexp_taxable,
					ROUND(dett.taxable * dett.number * 
		     		CONVERT(decimal(19,6),e.exchangerate) * 
		     		(1 - CONVERT(decimal(19,6),ISNULL(dett.discount, 0.0))),2) as 'Imponibile riga',
					null,  
					null  
			 FROM MANDATEdetail dett 
			 join MANDATE e on dett.idmankind =	e.idmankind and			
			 dett.yman	=	e.yman and			dett.nman	=	e.nman 
			 join MANDATEkind k	on dett.idmankind = k.idmankind
			WHERE
					k.linktoinvoice = 'N' -- CP non collegati a fattura
				and dett.idexp_taxable is not null	-- dettagli CP  contabilizzati
				and dett.stop is null
				and dett.yman =@ayear				
			-- Esiste il pagamento
			and exists ( select * from  expenselink EL 
						join expenselast ELA on EL.idchild=ELA.idexp
						where  EL.idparent=dett.idexp_taxable)
and dett.yman =@ayear
--SELECT * FROM #mandatedetail

INSERT INTO #mandatedetail_payed
	(	
		idmankind,
		mandatekind, 
		yman, 
		nman, 
		rownum,
		taxable_row, 
		payed_amount 
	)
	SELECT	
					dett.idmankind,
					dett.mandatekind, 
					dett.yman as Eserc , 
					dett.nman as Num , 
					dett.rownum as Dettaglio,
					dett.taxable_row as imponibile, 
					ISNULL((select  sum(expensetotal.curramount )
					FROM expenseyear
					JOIN expense
						ON expenseyear.idexp = expense.idexp 
					JOIN expensetotal
						ON  expenseyear.idexp = expensetotal.idexp
						AND expenseyear.ayear = expensetotal.ayear		
					JOIN expenselink EL2
						ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
					where expense.ymov = @ayear
					and EL2.idparent = dett.idexp_taxable
					and expense.nphase = @maxexpensephase
					),0)AS  'Importo Pagamento'
	from #mandatedetail dett
--select * from #mandatedetail_payed


INSERT INTO #mandatedetail_registered
	(	
		idmankind,
		mandatekind, 
		yman, 
		nman, 
		rownum,
		payed_registered 
	)
	SELECT	
					dett.idmankind,
					dett.mandatekind, 
					dett.yman as Eserc , 
					dett.nman as Num , 
					dett.rownum as Dettaglio,
					ISNULL((select  sum(expenselastMANDATEdetail .amount )
					FROM expense
					JOIN expenselastMANDATEdetail 
						ON  expense.idexp = expenselastMANDATEdetail .idexp
					JOIN expenselink EL2
						ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
					where expense.ymov = @ayear
					and EL2.idparent = dett.idexp_taxable
					and expense.nphase = @maxexpensephase
					),0) as 'Pagato risultante(in expenselastmandatedetail)'
	from #mandatedetail dett
 
--select * from #mandatedetail_registered

select 	
		--registered.idmankind,
		registered.mandatekind as 'Tipo contratto passivo', 
		registered.yman as Eserc, 
		registered.nman as Num, 
		registered.rownum as Dettaglio,
		payed.taxable_row as 'Imponibile riga',
		payed.payed_amount  AS  'Importo Pagamento',
		registered.payed_registered as 'Pagato risultante(in expenselastmandatedetail)' 
		from 
#mandatedetail_registered registered
JOIN #mandatedetail_payed  payed  on 
	payed.idmankind = registered.idmankind and
	payed.yman = registered.yman and
	payed.nman = registered.nman and
	payed.rownum = registered.rownum  
where  registered.payed_registered  <> payed.payed_amount
-- Importo incasso diverso da expenselastMANDATEdetail

	END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO				

					
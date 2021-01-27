
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[gerarchia_accantonamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [gerarchia_accantonamenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



--	select user
--	setuser 'amministrazione'

--left outer join expenseview sub on sub.parentidexp = acc.idexp and sub.ayear = @ayear
--left outer join expenseview imp on imp.parentidexp = sub.idexp and imp.ayear = @ayear
--left outer join expenseview pag on pag.parentidexp = imp.idexp and pag.ayear = @ayear
--left outer join	invoicedetail dfat on dfat.idexp_taxable =  pag.idexp  -- Fattura
--left outer join	mandatedetail dman on dman.idexp_taxable =  imp.idexp  -- Fattura
--left outer join	expensecasualcontractview con	on con.idexp = imp.idexp
--left outer join	expenseitinerationview mis		on mis.idexp = imp.idexp
--left outer join	expenseprofserviceview prof		on prof.idexp = imp.idexp
--left outer join	expensewageadditionview alt		on alt.idexp = imp.idexp

CREATE  procedure [gerarchia_accantonamenti]
(
	@ayear int, --Esercizio del quale visualizzare la situazione
	@acc int    --Esercizio massimo dell'accantonamento 
)


as
begin

select distinct
-- Accantonamento
acc.phase [Accantonamento], acc.ymov [Eser. Acc.], acc.nmov [Num. Acc.], acc.codefin [Bilancio],acc.codeupb [UPB], acc.ayearstartamount [Importo Esercizio Acc.], acc.curramount [Corrente Acc.], acc.available [Disponibile Acc.],
--SubAccantonamento
sub.phase [SubAccantonamento], sub.ymov [Eser. Sub.], sub.nmov [Num. Sub.],sub.ayearstartamount [Importo Esercizio Sub.], sub.curramount [Corrente Sub.], sub.available [Disponibile Sub.],
-- Impegno
imp.phase [Impegno], imp.ymov [Eser. Imp.], imp.nmov [Num. Imp], imp.registry [Anagrafica], imp.curramount [Corrente Imp.], imp.available [Disponibile Imp.],
-- Pagamento
pag.phase [Pagamento], pag.ymov [Eser. Pag.], pag.nmov [Num. Pag.], pag.curramount [Corrente Pag.], pag.npay [Num. Mandato],  pag.npaymenttransmission [Num. Trasmissione],
-- Documento Impegno
COALESCE(dman.yman, con.ycon, mis.yitineration, prof.ycon, alt.ycon ) AS [Eser. Doc.] ,
COALESCE(dman.nman, con.ncon, mis.nitineration, prof.ncon, alt.ncon ) AS [Num. Doc.],   
COALESCE(dcon.datecompleted, dite.datecompleted ) as [Data Acquisizione Definitiva],
--COALESCE(dman.nman, con.ncon, mis.nitineration, prof.ncon, alt.ncon ) AS [Tipo Doc.], -- mi devo far venire qualche idea  per la valorizzazione
CASE
     WHEN dman.nman is not null THEN dman.mankind 
	 WHEN con.ncon is not null THEN 'Occasionale' 
	 WHEN mis.nitineration is not null THEN 'Missioni' 
	 WHEN prof.ncon is not null THEN 'Professionale' 
	 WHEN alt.ncon is not null THEN 'Altri premi' 
END AS [Tipo Doc.],
isnull(dman.nman, 0) as [Dett. Con. Passivo],

-- Fattura 
 -- dfat_IMPON.invoicekind [Tipo. Fatt.], dfat_IMPON.yinv [Eserc. Fatt.], dfat_IMPON.ninv [Num. Fatt.], dfat_IMPON.rownum [Dett. Fattura]
case when (dfat_IMPON.idexp_taxable =  dfat_IVA.idexp_iva ) /*Contab. Totale*/ OR  ( dfat_IMPON.idexp_taxable is NOT null and  dfat_IVA.idexp_iva is null ) /*Contab. Solo Impon*/
		then dfat_IMPON.invoicekind 
	when dfat_IMPON.idexp_taxable is null and  dfat_IVA.idexp_iva is NOT null /*Contab. Solo IVA*/
		then dfat_IVA.invoicekind 
	end as [Tipo. Fatt.] ,
case when (dfat_IMPON.idexp_taxable =  dfat_IVA.idexp_iva ) /*Contab. Totale*/ OR  ( dfat_IMPON.idexp_taxable is NOT null and  dfat_IVA.idexp_iva is null ) /*Contab. Solo Impon*/
		then dfat_IMPON.yinv 
	when dfat_IMPON.idexp_taxable is null and  dfat_IVA.idexp_iva is NOT null /*Contab. Solo IVA*/
		then dfat_IVA.yinv 
	end as [Eserc. Fatt.] ,
case when (dfat_IMPON.idexp_taxable =  dfat_IVA.idexp_iva ) /*Contab. Totale*/ OR  ( dfat_IMPON.idexp_taxable is NOT null and  dfat_IVA.idexp_iva is null ) /*Contab. Solo Impon*/
		then dfat_IMPON.ninv 
	when dfat_IMPON.idexp_taxable is null and  dfat_IVA.idexp_iva is NOT null /*Contab. Solo IVA*/
		then dfat_IVA.ninv 
	end as [Num. Fatt.] ,
case when (dfat_IMPON.idexp_taxable =  dfat_IVA.idexp_iva ) /*Contab. Totale*/ OR  ( dfat_IMPON.idexp_taxable is NOT null and  dfat_IVA.idexp_iva is null ) /*Contab. Solo Impon*/
		then dfat_IMPON.rownum 
	when dfat_IMPON.idexp_taxable is null and  dfat_IVA.idexp_iva is NOT null /*Contab. Solo IVA*/
		then dfat_IVA.rownum 
	end as [Dett. Fatt.]
from
(select * from expenseview where ayear = @ayear and
(ayear = @ayear and nphase =1  and ymov <= @acc) ) acc
left outer join expenseview sub on sub.parentidexp = acc.idexp and sub.ayear = @ayear
left outer join expenseview imp on imp.parentidexp = sub.idexp and imp.ayear = @ayear
left outer join expenseview pag on pag.parentidexp = imp.idexp and pag.ayear = @ayear
left outer join	invoicedetailview dfat_IMPON on dfat_IMPON.idexp_taxable =  pag.idexp  -- Fattura contabilizzata imponibile
left outer join	invoicedetailview dfat_IVA on dfat_IVA.idexp_iva =  pag.idexp  -- Fattura contabilizzata imposta
left outer join	mandatedetailview dman on dman.idexp_taxable =  imp.idexp  -- Fattura
left outer join	expensecasualcontractview con	on con.idexp = imp.idexp
left outer join	expenseitinerationview mis		on mis.idexp = imp.idexp
left outer join	expenseprofserviceview prof		on prof.idexp = imp.idexp
left outer join	expensewageadditionview alt		on alt.idexp = imp.idexp
left outer join	casualcontract dcon	on dcon.ycon = con.ycon and dcon.ncon = con.ncon
left outer join	itineration dite on dite.iditineration = mis.iditineration
--left outer join	pettycashexpense
order by 1,2,3

end

--select distinct name from sysobjects where type = 'u' and name like '%expense%'
--select * from expensecasualcontractview


GO 

-- exec gerarchia_accantonamenti 2016,2015

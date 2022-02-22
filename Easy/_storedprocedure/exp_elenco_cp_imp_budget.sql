
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


/****** Object:  StoredProcedure [Amministrazione].[exp_elenco_cp_imp_budget]    Script Date: 18/03/2016 09:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 --setuser 'amm'
-- exp_elenco_cp_imp_budget 2015
ALTER  PROCEDURE [exp_elenco_cp_imp_budget](
	@ayear 			int  --,
	--@data_pagamento	datetime, -- Per le fatture pagate con fondo economale Ã¨ la data di registrazione dell'operazione
	--@data_scadenza	datetime,
	--@data_emissione_start	datetime,
	--@data_emissione_stop	datetime,
	--@flag_nascondi_pagate	varchar,	
	--@flag_nascondi_noliq	varchar,	
	--@idsor01 int,
	--@idsor02 int,
	--@idsor03 int,
	--@idsor04 int,
	--@idsor05 int
) 
AS BEGIN


select
mk.description					[Contratto], 
m.yman							[Esercizio], 
m.nman							[Numero], 
m.description					[Descr. Contratto],
md.rownum						[Numero riga],
ROUND(md.taxable * ISNULL(md.npackage,md.number) * 
		  CONVERT(DECIMAL(19,6),m.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(md.discount, 0.0))),2
		)					[Totale riga],  
md.unabatable				[Iva indetraibile],
e.ymov						[Eserc. Impegno fin.],
e.nmov						[Num. Impegno fin. ],
et.curramount				[Importo corrente],
et.available				[Disponibile per liquidazione],
epx.yepexp					[Eserc. Impegno Budget],
epx.nepexp					[Num. Impegno Budget],
epx.curramount				[Importo eserc. corrente],
epx.costavailable+epx.curramount-epx.totcurramount			[Disp. per costi eserc. corrente],
epx.costavailable			[Disponile per costi pluriennale],
epx.totcurramount			[Totale pluriennale],
accmotive.codemotive		[codice causale ep],
accmotive.title				[causale ep],
upb.codeupb				[codice upb ],
upb.title				[upb ],
case when md.epkind='R' then 'genera rateo' 
	 when md.epkind='F' then 'fattura da ric' 
	 when md.epkind='N' then 'non generare' 
	 else null end as 'tipo EP',
convert(date,md.competencystart)		[inizio competenza EP],
convert(date,md.competencystop)		[fine competenza EP],
(select sum(id.taxable_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum )
				as 'imponibile in fatture',
(select sum(id.taxable_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum 
			and id.ymov_taxable is not null)
				as 'imponibile in fatture pagate',
(select sum(id.taxable_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum 
			and id.ymov_taxable =@ayear)
				as 'imponibile in fatture pagate nell''anno',
(select sum(id.iva_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum  )
				as 'iva in fatture',
(select sum(id.iva_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum 
			and id.ymov_iva is not null)
				as 'iva in fatture pagate',
(select sum(id.iva_euro) from invoicedetailview id where 
			id.idmankind=md.idmankind and id.yman=md.yman and id.nman=md.nman and id.manrownum=md.rownum 
			and id.ymov_iva =@ayear)
				as 'iva in fatture pagate nell''anno'

	
from expenseyear ey 
join expensemandate em		on ey.idexp = em.idexp 
join mandatedetail md		on ey.idexp= md.idexp_taxable
join mandate m				on m.idmankind = md.idmankind and m.yman = md.yman and m.nman = md.nman
join mandatekind mk			on m.idmankind = mk.idmankind 
join expensetotal et		on ey.idexp=et.idexp	and ey.ayear= et.ayear
join expense e				on ey.idexp=e.idexp
left outer join epexpview  epx	on	epx.idepexp=md.idepexp and epx.ayear = @ayear
left outer join accmotive on accmotive.idaccmotive = md.idaccmotive
left outer join upb  on upb.idupb = md.idupb


where ey.ayear=@ayear	
				and m.active='S'
				and md.stop is null
				and e.nphase='2'
order by 1,2,3


END


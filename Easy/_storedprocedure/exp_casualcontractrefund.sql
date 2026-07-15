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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_casualcontractrefund]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_casualcontractrefund]
GO
 
CREATE  PROCEDURE [exp_casualcontractrefund]
(
	@esercizio		int,
	@annopagamento	int
)
AS BEGIN

SELECT  
	p.ycon 'Esercizio contratto',
	p.ncon 'Numero contratto',
	r.title 'Percipiente',
	r.cf 'Codice Fiscale',
	r.p_iva 'Partita IVA',
	r.foreigncf 'CF Estero',
	p.description 'Descrizione Contratto',	
	s.codeser 'Codice Tipo Prestazione',
	s.description 'Descrizione Tipo Prestazione',
	p.feegross 'Importo prestazione',
	p.total 'Costo totale',
	pst.employtax 'Ritenute',	
	pa.npay 'Numero pagamento',
	pa.adate 'Data pagamento',
	pt.npaymenttransmission 'Numero distinta di trasmissione',
	pt.ypaymenttransmission 'Data distinta di trasmissione',
	pr.amount 'Spese prestazione',
	pf.idlinkedrefund 'Tipo Spesa',
	pf.description 'Descrizione Tipo Spesa',
	case when pf.deduction='F' then 'S'	else 'N' end as 'Ai fini fiscali',
	case when pf.deduction='P' then 'S'	else 'N' end as 'Ai fini previdenziali'
FROM expense
	join expenselast elast				on expense.idexp = elast.idexp
	join expenselink el				on el.idchild = expense.idexp 
	join expensecasualcontract ep		on el.idparent = ep.idexp
	join casualcontractview p				on p.ycon = ep.ycon and p.ncon = ep.ncon
	left join casualcontracttax pst	on p.ycon = pst.ycon and p.ncon = pst.ncon
	LEFT JOIN service s				ON s.idser = p.idser
	left join payment pa			on pa.kpay = elast.kpay
	left join paymenttransmission pt on pt.kpaymenttransmission = pa.kpaymenttransmission
	left join  casualcontractrefund pr	on pr.ycon = p.ycon AND  pr.ncon = p.ncon
	LEFT JOIN casualrefund pf			on pr.idlinkedrefund = pf.idlinkedrefund
	left join registry r			on r.idreg = p.idreg
where pr.ncon is not null
	and (YEAR(pt.transmissiondate) = @annopagamento or @annopagamento is null) 
	and (p.ycon = @esercizio or @esercizio is null) 
order by r.cf

END


GO

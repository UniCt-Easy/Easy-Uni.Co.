
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


-- CREAZIONE VISTA expenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[expense_epview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expense_epview]
GO

--setuser'amministrazione'
--setuser 'amm'
--select (case when exists(select * from expense_epview2 where ymov=2019) then 1 else 0 end) as 'exist'
--select count(*) from expense_epview2 where ymov=2019  --su test 26948 righe 5:16 
--select  count(*) from expense_epview2    where ymov=2019   --su test 26948 righe 5:16 
--select top 1000 * from expense_epview where ymov=2019  --su test 26948 righe 2:49  2:08


--select convert(int, replace(replace(idrelated,'expense§',''),'§debit','')), idrelated from entrydetail where idrelated like 'expense§%'
--update entrydetail set idexp=convert(int, replace(replace(idrelated,'expense§',''),'§debit','')) where idrelated like 'expense§%' and not idrelated like like '%§debit'
--update entrydetail set idexp=null where idrelated like '%§debit'
--update entrydetail set idinc=null where idrelated like '%§credit'
--update entrydetail set idinc=convert(int, replace(replace(idrelated,'income§',''),'§credit','')) where idrelated like 'income§%' and not idrelated like '%§credit'

--clear_table_info 'expense_epview'
CREATE      VIEW expense_epview
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	idformerexpense,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idreg,
	registry,
	idman,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	curramount,
	available,
	extracode,
	ivaamount,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	nbill,
	npaymenttransmission,
	transmissiondate,
	idaccdebit, 
	codeaccdebit,
	accountdebit,
	cigcode,	
	cupcode,
	txt,
	cu,
	ct,
	lu,
	lt,
	external_reference,
	--automatismo,
	n_mandato,
	n_elenco,
	scrittura_chiusura_debito,
	debito_chiuso,
	importo_da_esitare,
	importo_contributi,
	pagamenti_contributi
	--,	chiusura_debito_contributi,	contributi_da_esitare
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	expense.idformerexpense,
	expense.ymov,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expense.idreg,
	registry.title,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	extracode,
	expenselast.ivaamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	expenselast.nbill,
	paymenttransmission.npaymenttransmission,
	paymenttransmission.transmissiondate,
	expenselast.idaccdebit,
	account.codeacc,
	account.title,
	expense.cigcode,	
	expense.cupcode,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expense.external_reference,	
	--aa.title,
	p.npay ,--as 'n.mandato', 
	paymenttransmission.npaymenttransmission ,--as 'n.elenco',	

	concat(ed.yentry,'/',ed.nentry),  --scrittura_chiusura_debito
		ed.amount ,--as 'debito chiuso',+			
		isnull((select sum(ed2.amount) from entrydetail ed2 with(nolock) where  ed2.idexp=expenselast.idexp),0) ,--as 'importo da esitare',
		(select sum(etax.admintax) from expensetax etax with(nolock) where etax.idexp=expense.idexp), --as 'importo contributi',
	isnull( (select sum(et2.curramount) from expense e2 with(nolock) join expenselast el2 with(nolock) on el2.idexp=e2.idexp join expensetotal et2 with(nolock) on et2.idexp=e2.idexp
						where e2.idpayment= expense.idexp),0) --as 'pagamenti contributi',
	--isnull( (select -sum(ed2.amount) from expense e2 with(nolock) join expenselast el2 with(nolock) on el2.idexp=e2.idexp join expensetotal et2 with(nolock) on et2.idexp=e2.idexp
	--				join entrydetail ed2 on ed2.idrelated= 'expense§'+convert(varchar(15),el2.idexp)+'§debit'	where e2.idpayment= expense.idexp
	--						),0),-- as 'chiusura debito contributi',
	--isnull( (select -sum(ed2.amount) from expense e2 with(nolock) join expenselast el2 with(nolock) on el2.idexp=e2.idexp join expensetotal et2 with(nolock) on et2.idexp=e2.idexp
	--				join entrydetail ed2 with(nolock) on ed2.idrelated= 'expense§'+convert(varchar(15),el2.idexp)
	--						where e2.idpayment= e2.idexp
	--						),0)-- as 'contributi da esitare'
FROM expenselast  with(nolock)
--JOIN expensephase with(nolock)		ON expensephase.nphase = expense.nphase
JOIN expense	with(nolock)	ON expenselast.idexp = expense.idexp
JOIN expenseyear with(nolock)		ON expenseyear.idexp = expense.idexp	AND expenseyear.ayear = expense.ymov
JOIN expensetotal with(nolock)		ON expensetotal.idexp = expense.idexp 				AND expensetotal.ayear =  expense.ymov
--LEFT OUTER JOIN expense parentexpense with(nolock)	ON parentexpense.idexp = expense.parentidexp
--LEFT OUTER JOIN expense former	with(nolock)	ON expense.idformerexpense = former.idexp
left outer join payment p on expenselast.kpay=p.kpay
LEFT OUTER JOIN fin	with(nolock)	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb	with(nolock)	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry	with(nolock)	ON registry.idreg = expense.idreg
--LEFT OUTER JOIN manager	with(nolock)		ON manager.idman = expense.idman
--LEFT OUTER JOIN service	with(nolock)	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment with(nolock)	ON payment.kpay = expenselast.kpay
--LEFT OUTER JOIN registry deputy with(nolock)	ON deputy.idreg = expenselast.iddeputy
--LEFT OUTER JOIN clawback with(nolock)	ON clawback.idclawback = expense.idclawback
--LEFT OUTER JOIN expensetotal expensetotal_firstyear with(nolock)  	ON expensetotal_firstyear.idexp = expense.idexp and (expensetotal_firstyear.ayear=expense.ymov)
--LEFT OUTER JOIN expenseyear  expenseyear_starting with(nolock) 	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp								AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN paymenttransmission with(nolock) 	ON paymenttransmission.kpaymenttransmission = p.kpaymenttransmission
LEFT OUTER JOIN  account	with(nolock)		ON account.idacc =  expenselast.idaccdebit
left outer join  entrydetail ed with(nolock) on ed.idexp= expenselast.idexp
--left outer join autokind aa with(nolock) on aa.idautokind=expense.autokind
where (  ed.yentry is null or 
			isnull((select sum(ed2.amount) from entrydetail  ed2 with(nolock) where  ed2.idexp= expenselast.idexp),0)<>0 --debito non chiuso bene
		)
			and not exists (select * from taxpayexpense tp  where tp.idexp=expense.parentidexp)
			and expensetotal.curramount<>0
			--and nmov=29496
GO

--select * from entrydetail where	((idrelated='expense§1209229§debit')OR(idrelated='expense§1209229')) AND(yentry=2019)
--select * from expense where idexp=1209229
--1209229
 

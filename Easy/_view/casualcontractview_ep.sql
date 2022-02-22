
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



-- CREAZIONE VISTA casualcontractview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractview_ep]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractview_ep]
GO
 
-- setuser 'amm'
--  clear_table_info'casualcontractview_ep'
-- select * from casualcontractview_ep
CREATE VIEW [casualcontractview_ep]
(
	ayear,
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	iddaliaposition,
	codedaliaposition,
	daliaposition,
	idupb,
	codeupb,
	upb,
	feegross,
	total,
	taxableotheragency,
	idser,
	service,
	codeser,
	description,
	ndays,
	activitycode,
	activity,
	idotherinsurance,
	otherinsurance,
	idemenscontractkind,
	emenscontractkind,
	flaghigherrate,
	completed,
	idaccmotive,
	codemotive,
	accmotive,
	idaccmotivedebit,
	codemotivedebit,
	accmotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	accmotive_crg,
	idaccmotivedebit_datacrg,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	arrivalprotocolnum,
	arrivaldate,
	annotations,
	expiration,
	cupcode,
	cigcode,
	iduniqueregister,
	resendingpcc,
	ipa_fe,
	expensekind,
	cu,
	ct,
	lu,
	lt,
	txt,
	expensekinddescription,
	idrelated,
	datecompleted,
	idsor_siope,
	requested_doc,
	impegno, pagamento,
	mandato,elenco_trasm,importo_impegno,importo_pagamento,chiusura_debito,contributi_pagati,
	scrittura_elenco,scrittura_esito,chiusura_debito_contributi,contributi_da_esitare,importo_da_esitare, 
	residuo
)
AS SELECT 
	ICOP.ayear,
	COP.ycon,
	COP.ncon,
	COP.start,
	COP.stop,
	COP.adate,
	COP.idreg,
	registry.title,
	DP.iddaliaposition,
	DP.codedaliaposition,
	DP.description,
	COP.idupb,
	UPB.codeupb,
	UPB.title,
	COP.feegross,
	COP.feegross + isnull((select sum(CTAX.admintax)
		from casualcontracttax CTAX
		where  COP.ycon = CTAX.ycon AND COP.ncon = CTAX.ncon),0)
	,
	ICOP.taxableotheragency,
	COP.idser,
	service.description,
	service.codeser,
	COP.description,
	COP.ndays,
	ICOP.activitycode,
	API.description,
	ICOP.idotherinsurance,
	AFA.description,
	ICOP.idemenscontractkind,
	ETR.description,
	ICOP.flaghigherrate,
	COP.completed,
	COP.idaccmotive,
	AM.codemotive,
	AM.title,
	COP.idaccmotivedebit,
	DB.codemotive,
	DB.title,
	COP.idaccmotivedebit_crg,
	CRG.codemotive,
	CRG.title,
	COP.idaccmotivedebit_datacrg,
	COP.idsor1,
	COP.idsor2,
	COP.idsor3,
	isnull(COP.idsor01,UPB.idsor01),
	isnull(COP.idsor02,UPB.idsor02),
	isnull(COP.idsor03,UPB.idsor03),
	isnull(COP.idsor04,UPB.idsor04),
	isnull(COP.idsor05,UPB.idsor05),
	COP.authneeded,
	COP.authdoc,
	COP.authdocdate,
	COP.noauthreason,
	COP.arrivalprotocolnum,
	COP.arrivaldate,
	COP.annotations,
	COP.expiration,
	COP.cupcode,
	COP.cigcode,
	uniqueregister.iduniqueregister,
	COP.resendingpcc,
	COP.ipa_fe,
	COP.expensekind,
	COP.cu,
	COP.ct,
	COP.lu,
	COP.lt,
	COP.txt,
	case 
		when COP.expensekind='CO' then 'Spesa corrente'
		when COP.expensekind='CA' then 'Conto capitale'
		else null
	end,
	'cascon§'+ convert(varchar(10),COP.ycon) + '§'+ convert(varchar(10),COP.ncon),
	COP.datecompleted,
	COP.idsor_siope,
	COP.requested_doc,

	convert(varchar(20),imp.nmov)+'/'+convert(varchar(4),imp.ymov), --impegno
	convert(varchar(20),e.nmov)+'/'+convert(varchar(4),e.ymov) ,--pagamento
	convert(varchar(20),p.npay) , --mandato
	convert(varchar(20),pt.npaymenttransmission) , --elenco_trasm
		et_imp.curramount,		--importo_impegno
		et.curramount ,		--importo_pagamento
		ed.amount ,	--chiusura_debito
		isnull( (select sum(et2.curramount) from expense e2 join expenselast el2 on el2.idexp=e2.idexp join expensetotal et2 on et2.idexp=e2.idexp
						where e2.idpayment= e.idexp),0) , --contributi_pagati
		convert(varchar(20),entry.nentry)+'/'+convert(varchar(4),entry.yentry)	,		--scrittura_elenco
		(select max(ed2.nentry) from entrydetail ed2 	where ed2.idrelated = 'expense§'+convert(varchar(15),ela.idexp)	and ed2.amount<0 )	 , --scrittura_esito
		isnull( (select -sum(ed2.amount) from expense e2 join expenselast el2 on el2.idexp=e2.idexp join expensetotal et2 on et2.idexp=e2.idexp
					join entrydetail ed2 on ed2.idrelated= 'expense§'+convert(varchar(15),el2.idexp)+'§debit'
							where e2.idpayment= e.idexp
							),0) , --chiusura_debito_contributi
	isnull( (select -sum(ed2.amount) from expense e2 join expenselast el2 on el2.idexp=e2.idexp join expensetotal et2 on et2.idexp=e2.idexp
					join entrydetail ed2 on ed2.idrelated= 'expense§'+convert(varchar(15),el2.idexp)
							where e2.idpayment= e2.idexp
							),0), --as 'contributi da esitare',
		isnull((select sum(amount) from entrydetail ed2 where  ed2.idrelated= 'expense§'+convert(varchar(15),ela.idexp)),0), -- as 'importo da esitare',
		CONVERT(decimal(23,6),
		COP.feegross -
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expensecasualcontract mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = COP.ycon
			AND mov.ncon = COP.ncon
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.ycon = COP.ycon 
			AND mov.ncon = COP.ncon
			AND (ISNULL(v.autokind,0)<> 4)
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = COP.ycon
			AND mov.ncon = COP.ncon)
		,0)
		) 
	)
FROM casualcontract COP (nolock)
JOIN casualcontractyear ICOP (nolock) 	ON COP.ycon = ICOP.ycon	AND COP.ncon = ICOP.ncon
JOIN registry (nolock)					ON registry.idreg = COP.idreg
LEFT OUTER JOIN UPB (nolock)			ON UPB.idupb=COP.idupb
JOIN service (nolock)					ON service.idser = COP.idser
LEFT OUTER JOIN otherinsurance AFA (nolock)		ON AFA.idotherinsurance = ICOP.idotherinsurance	AND AFA.ayear = ICOP.ayear 
LEFT OUTER JOIN inpsactivity API (nolock)	ON API.activitycode = ICOP.activitycode	AND API.ayear = ICOP.ayear
LEFT OUTER JOIN emenscontractkind ETR (nolock)	ON ETR.idemenscontractkind = ICOP.idemenscontractkind	AND ETR.ayear = ICOP.ayear
LEFT OUTER JOIN accmotive AM (nolock)		ON AM.idaccmotive = COP.idaccmotive
LEFT OUTER JOIN accmotive DB (nolock)		ON DB.idaccmotive =  COP.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG (nolock)		ON CRG.idaccmotive = COP.idaccmotivedebit_crg
LEFT OUTER JOIN uniqueregister		ON uniqueregister.ncon = COP.ncon	AND uniqueregister.ycon = COP.ycon
LEFT OUTER JOIN dalia_position DP	ON DP.iddaliaposition = COP.iddaliaposition


left outer join expensecasualcontract ce on COP.ycon=ce.ycon and COP.ncon=ce.ncon
		left outer join expense imp on ce.idexp=imp.idexp
		left outer join expensetotal et_imp on et_imp.idexp=imp.idexp and et_imp.ayear=imp.ymov
		left outer join expenselink eli on eli.idparent=ce.idexp  and eli.idchild in (select idexp from expenselast)
		left outer join expenselast ela on ela.idexp=eli.idchild
		left outer join payment p on ela.kpay=p.kpay
		left outer join paymenttransmission pt on pt.kpaymenttransmission=p.kpaymenttransmission
		left outer join expense e on ela.idexp=e.idexp
		left outer join expensetotal et on et.idexp=e.idexp
		left outer join entrydetail ed on ed.idrelated= 'expense§'+convert(varchar(15),ela.idexp) and ed.amount>0 --la chiusura del debito è in avere, 
		left outer join entry on entry.yentry=ed.yentry and entry.nentry=ed.nentry




GO
 

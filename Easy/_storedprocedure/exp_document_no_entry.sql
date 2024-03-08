
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


-- setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_document_no_entry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_document_no_entry]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE PROCEDURE [exp_document_no_entry]
(
	@ayear int,
	@kind char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS 
BEGIN
-- setuser'amministrazione'
-- setuser'amm'
-- exec [exp_document_no_entry] 2021, 'I'
 
/*
A) Compensi (Missioni, Contratti occasionali, Cedolini, Compensi a dipendenti, Import da stipendi CSA, Liquidazione imposte) -- >C
B) Contratti Attivi e Passivi, Fatture e liquidazione IVA -->I
C) Magazzino (Scarichi) -->M
D) Elenchi di Trasmissione Mandati e Reversali -->T
E) Patrimonio(Buoni di Carico e Scarico) -->P
F) Fondo economale (Operazioni) -->F
G) Tutti i Documenti -->A

Ultima modifica 23/10/2014 Gianni
aumentata la dimensione dei campi di #document a 250 per risolvere un errore di troncamento



-- Essendo cambiata la logica di generazione delle scritture sui Compensi occasionali e cioè 
-- poichè le scritture EP adesso vengono generate solo se c'è la Data acquisizione documentazione definitiva, 
-- si chiede di escludere dall'esportazione tutti i compensi occasionali che non hanno scrittura,  
-- ma non hanno neanche la Data acquisizione documentazione definitiva valorizzata

 
-- Sempre per gli occasionali, se non esiste una scrittura e se la Data acquisizione documentazione 
-- definitiva ha esercizio diverso da quello in cui si lancia l'esportazione, deve essere visualizzata 
-- la Nota "Scrittura non generata perchè costo non di competenza dell'esercizio"
*/

declare @usapresentazionedocumenti char(1)
set @usapresentazionedocumenti='N'
if (select idacc_bankpaydoc from config where ayear=@ayear) is not null set @usapresentazionedocumenti='S'

CREATE TABLE #document
	(
		desckind varchar(250),
		dockind varchar(250),
		y int,
		n int,
		fiscalyear int,
		ndetail int,
		description varchar(250),
		adate smalldatetime,
		registry varchar(250),
		service varchar(250),
		manager varchar(250), 
		start datetime, 
		stop datetime,
		docamount decimal(19,2),
		note varchar(400),
		datecompleted datetime,
		sortcode varchar(30), --task 10695
		descriptions varchar(250),
		rownum int
	)


INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager, start, stop,docamount,datecompleted, note, sortcode, descriptions
	)
SELECT 
		'Contratto occasionale',null,ycon,ncon,null,null,casualcontractview.description,
		adate,registry,service,null, casualcontractview.start, casualcontractview.stop,total, datecompleted, 
		case 
			when year(datecompleted)<>@ayear 
				then 'Scrittura non generata perchè costo non di competenza dell''esercizio'
			when ( year(casualcontractview.stop) = @ayear and ISNULL(completed,'N') = 'N')
				THEN 'Scrittura non generata perchè prestazione non eseguita (flag "Considera eseguito e quindi pagabile" non valorizzato)'
			else null
		end, sorting.sortcode, sorting.description
from casualcontractview 
left join sorting on casualcontractview.idsor01 = sorting.idsor
where not exists
(select * from entry 
		 where idrelated = 'cascon' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(14),ncon)
)
AND ycon = @ayear and casualcontractview.datecompleted is not null
AND @kind in ('C','A') --AND ISNULL(completed,'N') = 'S'
	AND (@idsor01 IS NULL OR casualcontractview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR casualcontractview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR casualcontractview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR casualcontractview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR casualcontractview.idsor05 = @idsor05)

ORDER BY ycon, ncon

 
INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,wageadditionview.description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 
		'Compenso a dipendente',null,ycon,ncon,null,null,wageadditionview.description,
		adate,registry,service,null, feegross,sorting.sortcode, sorting.description
from wageadditionview
left join sorting on wageadditionview.idsor01 = sorting.idsor where not  exists
(select * from entry 
		 where idrelated = 'wageadd' + '§' + convert(varchar(4),ycon) + '§'  + 
		 convert(varchar(14),ncon)
)
AND ycon = @ayear
AND @kind in ('C','A')
	AND (@idsor01 IS NULL OR wageadditionview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR wageadditionview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR wageadditionview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR wageadditionview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR wageadditionview.idsor05 = @idsor05)
ORDER BY ycon, ncon
-- Per le Missioni, essendo cambiata la logica di generazione delle scritture su
-- Missioni e cioè poichè le scritture EP adesso vengono generate solo se c'è la Data acquisizione documentazione definitiva, 
-- si chiede di escludere dall'esportazione tutte le Missioni che non hanno scrittura, ma non hanno neanche la Data acquisizione documentazione definitiva valorizzata
-- Anche per le Missioni, se non esiste una scrittura e se la Data acquisizione documentazione definitiva 
-- ha esercizio diverso da quello in cui si lancia l'esportazione, deve essere visualizzata la Nota 
-- "Scrittura non generata perchè costo non di competenza dell'esercizio"
INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager, start, stop,docamount, datecompleted, note,sortcode, descriptions
	)
SELECT 
		'Missione',null, yitineration, nitineration, null, null, itinerationview.description,
		adate, registry, service,null, itinerationview.start, itinerationview.stop,totalgross,datecompleted, 
		case 
			when year(datecompleted)<>@ayear 
				then 'Scrittura non generata perchè costo non di competenza dell''esercizio'
			when ( year(itinerationview.stop) = @ayear and ISNULL(completed,'N') = 'N')
				then 'Scrittura non generata perchè prestazione non eseguita (flag "Considera eseguito e quindi pagabile" non valorizzato)'
		else null
		end,sorting.sortcode, sorting.description
from itinerationview 
left join sorting on itinerationview.idsor01 = sorting.idsor
where  not exists
(select * from entry where idrelated = 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 
	convert(varchar(14),nitineration)
)
AND yitineration = @ayear and itinerationview.datecompleted is not null
	AND (@idsor01 IS NULL OR itinerationview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR itinerationview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR itinerationview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR itinerationview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR itinerationview.idsor05 = @idsor05)
AND @kind in ('C','A')
ORDER BY yitineration, nitineration


INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount
	)
SELECT 
		'Liquidazione IVA', null, yivapay, nivapay,null,null, null, 
		dateivapay,null, null, null,paymentamount
FROM ivapay  WHERE not  exists
(SELECT * FROM entry 
		 WHERE idrelated = 'ivapay' + '§' + convert(varchar(4),yivapay) + '§'  + convert(varchar(14),nivapay)
)
AND yivapay = @ayear
AND @kind in ('I','A')

ORDER BY yivapay, nivapay

if (@usapresentazionedocumenti='S')
begin

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount
	)
	
SELECT 
		'Liquidazione Imposte', null, ytaxpay, ntaxpay,null,null, null, 
		adate,null, null, null,amount
FROM taxpay  WHERE not  exists
(SELECT * FROM entry 
		 WHERE idrelated like 'taxpay' + '§' + convert(varchar(4),ytaxpay) + '§'  + convert(varchar(14),ntaxpay)+ '§%'
)
AND ytaxpay = @ayear
AND @kind in ('C','A')
ORDER BY ytaxpay, ntaxpay
END


INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount
	)
SELECT 
		'Liquidazione Iva consolidata', null, ymainivapay, nmainivapay,null, null, null,
		datemainivapay, null, null, null,paymentamount
FROM mainivapay  WHERE  not exists
(SELECT * FROM entry WHERE idrelated = 'mainivapay' + '§' + convert(varchar(4),ymainivapay) + '§'  + 
	convert(varchar(14),nmainivapay)
)
AND ymainivapay = @ayear
AND @kind in ('I','A')
ORDER BY ymainivapay, nmainivapay

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 
		'Elenco di trasmissione Mandati',null, ypaymenttransmission, npaymenttransmission, null,null, null,
		transmissiondate, null, null,manager,total,sorting.sortcode, sorting.description
FROM paymenttransmissionview
left join sorting on paymenttransmissionview.idsor01 = sorting.idsor WHERE not exists
(SELECT * FROM entry WHERE idrelated = 'paytrans' + '§' + convert(varchar(4),ypaymenttransmission) + '§'  + 
	convert(varchar(14),npaymenttransmission)
)
AND transmissionkind<>'V'
AND EXISTS (SELECT * from expenseview where kpaymenttransmission = paymenttransmissionview.kpaymenttransmission and 
	 isnull(autokind,0) not in (2,12,17,23,20,21,22))
AND ypaymenttransmission = @ayear
--and isnull(noep,'N') ='N'
AND @kind in ('T','A')
	AND (@idsor01 IS NULL OR paymenttransmissionview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR paymenttransmissionview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR paymenttransmissionview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR paymenttransmissionview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR paymenttransmissionview.idsor05 = @idsor05)
ORDER BY ypaymenttransmission, npaymenttransmission

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 'Elenco di trasmissione Reversali',null, yproceedstransmission, nproceedstransmission, null, null, null,
		transmissiondate, null, null,manager,total,sorting.sortcode, sorting.description
from proceedstransmissionview 
left join sorting on proceedstransmissionview.idsor01 = sorting.idsor where not exists
(select * from entry where idrelated = 'protrans' + '§' + convert(varchar(4),yproceedstransmission) + '§'  + 
	convert(varchar(14),nproceedstransmission)
)
AND transmissionkind<>'V'
AND EXISTS (SELECT * from incomeview where kproceedstransmission = proceedstransmissionview.kproceedstransmission and 
	 isnull(autokind,0) not in (12,20,21,22))
AND yproceedstransmission = @ayear
--and isnull(noep,'N') ='N'
AND @kind in ('T','A')
	AND (@idsor01 IS NULL OR proceedstransmissionview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR proceedstransmissionview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR proceedstransmissionview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR proceedstransmissionview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR proceedstransmissionview.idsor05 = @idsor05)
ORDER BY yproceedstransmission, nproceedstransmission

 
INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 'Importazione Esiti Bancari','ABI: ' + idbank, ayear, idbankimport, null, null, 'Tot Mandati:' + Convert(varchar(20), totalpayment) +  ' Tot Reversali:' + Convert(varchar(20), totalproceeds) ,
		adate, null, null,null,null,null, null
from bankimport where not exists
(select * from entry where idrelated = 'bankimport' + '§' + convert(varchar(4),idbankimport)  
)
and exists (select * from banktransaction where idbankimport = bankimport.idbankimport)
and @kind in ('T','A') AND ayear = @ayear
ORDER BY idbankimport



INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 
		 'Fattura', invoicekind ,yinv, ninv,null,null,invoiceview.description,
		 adate, registry, null, null,total,sorting.sortcode, sorting.description
from invoiceview 
 
left join sorting on invoiceview.idsor01 = sorting.idsor where not exists
(select * from entry where idrelated = 'inv' + '§' + convert(varchar(4),idinvkind) + '§'  + 
		convert(varchar(4),yinv) + '§'  + convert(varchar(14),ninv))
AND yinv = @ayear
AND @kind in ('I','A')
	AND (@idsor01 IS NULL OR invoiceview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR invoiceview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR invoiceview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR invoiceview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR invoiceview.idsor05 = @idsor05)
ORDER BY invoicekind ,yinv, ninv

-- Escludere i contratti attivi e passivi non collegabili a fattura per i quali non vi è la spunta su “Utilizzabile per la contabilizzazione”.
INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT 
		'Contratto Passivo', mankind, yman, nman, null, null, mandateview.description,
		adate,  registry,null, manager,total,sorting.sortcode, sorting.description
from mandateview 
join mandatekind ON mandateview.idmankind = mandatekind.idmankind
left join sorting on mandateview.idsor01 = sorting.idsor
where not exists
(select * from entry where idrelated = 'man' + '§' + mandateview.idmankind + '§'  + 
		convert(varchar(4),yman) + '§'  + convert(varchar(14),nman))
--and not exists (select * from invoicedetail 
--				where invoicedetail.idmankind = mandateview.idmankind and 
--				      invoicedetail.yman = mandateview.yman and 
--				      invoicedetail.nman = mandateview.nman )
AND isnull(mandatekind.linktoinvoice,'N') ='N' AND isnull(mandateview.active,'N') = 'S'
	AND (@idsor01 IS NULL OR mandateview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR mandateview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR mandateview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR mandateview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR mandateview.idsor05 = @idsor05)
AND yman = @ayear
AND @kind in ('I','A') AND isnull(mandatekind.isrequest,'N') = 'N'
ORDER BY mankind, yman, nman

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions, rownum
	)
SELECT  'Contratto Attivo', estimatekind.description, estimate.yestim, estimate.nestim, null, null, estimatedetail.detaildescription,
		estimate.adate, registry.title, null, manager.title,
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		)+
	  ROUND(isnull(estimatedetail.tax,0) ,2),  sorting.sortcode, sorting.description, estimatedetail.rownum
from estimate 
join estimatedetail
	on estimatedetail.idestimkind = estimate.idestimkind and 
	   estimatedetail.yestim = estimate.yestim and 
	   estimatedetail.nestim = estimate.nestim 
join estimatekind ON estimate.idestimkind = estimatekind.idestimkind
join registry ON registry.idreg = estimatedetail.idreg
left outer join manager ON manager.idman = estimate.idman
left join sorting on estimate.idsor01 = sorting.idsor
where  (

	--task 17744: RIEPILOGO COSA DEVE MOSTRARE L'ESPORTAZIONE PER I CA:
--CASO  1) CA  SENZA flag accertamento differiti -> la diagnostica deve mostrare nell'esercizio in cui viene lanciata deve mostrare i CA dell'anno che hanno dettagli con
--o senza data inizio validità nell'anno e che non hanno scrittura, e quelli di esercizi precedenti con dettagli con data inizio validità dell'anno dell'esportazione

--CASO 2) CA  CON flag accertamento differiti  -->  nell'esercizio in cui viene lanciata deve mostrare CA dell'anno che hanno dettagli CON data inizio validità nell'anno
--e che non hanno scrittura. Nonchè deve mostrare i CA  di anni precedenti che hanno dettagli CON data inizio validità nell'anno di lancio diagnostica che non hanno scrittura.
--Nel caso 2 Non devono mai essere mostrati quella senza data inizio validità.

			-- 1) --  Scritture non differite alla fase di generazione incassi
			(isnull(estimatedetail.flag,0) & 1 = 0  -- Prendo contratti dell'anno con o senza data inizio validità nell'anno (non esercizi futuri) 
			and ((estimate.yestim = @ayear and isnull(year(estimatedetail.start), estimate.yestim) = @ayear) 
			 or (estimate.yestim <@ayear and  year(estimatedetail.start) = @ayear)
			)
			-- 2)--  Scritture differite alla fase di generazione incassi
			OR 
			-- Non devono mai essere mostrati quella senza data inizio validità, ma sono quelli aventi inizio validità nell'anno, sia di contratti dell'anno che di contratti di anni precedenti. 
			(isnull(estimatedetail.flag,0) & 1 <> 0 and (year(estimatedetail.start) = @ayear)) -- Contratti di esercizi precedenti e dettagli con data inizio validità in esercizio corrente
		)
		)

 and not exists
 (select * from entry e
 join entrydetail ed on e.nentry = ed.nentry 
	and e.yentry = ed.yentry
 where ed.idrelated = 'estim' + '§' + estimatedetail.idestimkind 
		+ '§'  + convert(varchar(4), estimatedetail.yestim) 
		+ '§'  + convert(varchar(14), estimatedetail.nestim) 
		+ '§'  + convert(varchar(14), estimatedetail.rownum)
		and ed.yentry = @ayear -- cerchiamo una scrittura in esercizio corrente
		and e.idrelated like '%estim§%')

AND isnull(estimatekind.linktoinvoice,'N') ='N' AND isnull(estimate.active,'N') = 'S'
	AND (@idsor01 IS NULL OR estimate.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR estimate.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR estimate.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR estimate.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR estimate.idsor05 = @idsor05)
AND @kind in ('I','A')
ORDER BY estimatekind.description, estimate.yestim, estimate.nestim 
--select * from #document where desckind = 'Contratto Attivo'

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,start,stop,docamount,
		note,sortcode, descriptions
	)
SELECT 
		'Cedolino parasubordinati',null, C.ycon, C.ncon, C.fiscalyear, C.npayroll,null, 
		C.disbursementdate, C.registry, C.service,null,C.start, C.stop, feegross,
		case 
			when  (ISNULL(flagcomputed,'N') = 'N'  and year(C.stop)=@ayear )
				then 'Scrittura non generata perchè cedolino non calcolato' 
			when year(C.stop)<>@ayear 
				then 'Scrittura non generata perchè costo non di competenza dell''esercizio'
		else null
		end,sorting.sortcode, sorting.description
from payrollview C
left join sorting on C.idsor01 = sorting.idsor
where not  exists
(select * from entry where idrelated = 'payroll' + '§' + convert(varchar(10),C.idpayroll) + '§'  + 
		convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll))
AND fiscalyear = @ayear
	AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
AND @kind in ('C','A') 
AND C.flagbalance<>'S'
ORDER BY C.ycon, C.ncon, C.fiscalyear, C.npayroll
 
INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager ,sortcode, descriptions
	)
SELECT 
	'Buono di scarico', assetunloadkind,yassetunload, nassetunload,null,null,assetunloadview.description,
	adate, registry,null, null,sorting.sortcode, sorting.description
	from assetunloadview 
	left join sorting on assetunloadview.idsor01 = sorting.idsor where not exists
(select * from entry where idrelated = 'assetunload' + '§' + convert(varchar(10),idassetunload))
and not exists(select * from assetunloadmotive where assetunloadmotive.idmot = assetunloadview.idmot and (assetunloadmotive.flag&1) <> 0)
	AND yassetunload = @ayear
	--and totalassetunload <> 0
	AND (@idsor01 IS NULL OR assetunloadview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR assetunloadview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR assetunloadview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR assetunloadview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR assetunloadview.idsor05 = @idsor05)
AND @kind in ('P','A')
ORDER BY assetunloadkind,yassetunload, nassetunload

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,sortcode, descriptions
	)
SELECT 
		'Buono di carico', assetloadkind,yassetload, nassetload,null, null,assetloadview.description,
		adate,registry,null,null,sorting.sortcode, sorting.description
from assetloadview 
left join sorting on assetloadview.idsor01 = sorting.idsor where  not exists
(select * from entry where idrelated = 'assetload' + '§' + convert(varchar(10),idassetload))
AND yassetload = @ayear AND assetloadmotive = 'DONAZIONE'
AND @kind in ('P','A')
and totalassetload <> 0
	AND (@idsor01 IS NULL OR assetloadview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR assetloadview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR assetloadview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR assetloadview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR assetloadview.idsor05 = @idsor05)
ORDER BY assetloadkind,yassetload, nassetload

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,sortcode, descriptions
	)
SELECT 
		'Scarico magazzino', store,ystoreunload, nstoreunload,null,idstoreunloaddetail,null,
		adate, null, null, null,sorting.sortcode, sorting.description
from storeunloaddetailview 
left join sorting on storeunloaddetailview.idsor01 = sorting.idsor where not  exists
(select * from entry where idrelated = 'storeunloaddetail' + '§' + convert(varchar(14),idstoreunload) + '§'  + 
		convert(varchar(4),idstoreunloaddetail))
AND ystoreunload = @ayear
AND @kind in ('M','A')
	AND (@idsor01 IS NULL OR storeunloaddetailview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR storeunloaddetailview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR storeunloaddetailview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR storeunloaddetailview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR storeunloaddetailview.idsor05 = @idsor05)
ORDER BY ystoreunload, nstoreunload,idstoreunloaddetail


INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager
	)
SELECT 'Import Stipendi da CSA', null, yimport, nimport,null, null,description,
		null,null,null,null
from csa_import  where not exists
(select * from entry where idrelated = 'csa_import' + '§' + convert(varchar(4),yimport) + '§'  + 
	convert(varchar(14),nimport)
)
AND yimport = @ayear
AND @kind in ('C','A')
ORDER BY yimport, nimport

INSERT INTO #document
	(
		desckind, dockind,y,n,fiscalyear,ndetail,description,
		adate,registry,service,manager,docamount,sortcode, descriptions
	)
SELECT
'Operazione Fondo Economale', pettycash,yoperation, noperation,null, null,pettycashoperationview.description,
adate, null, null, manager,amount,sorting.sortcode, sorting.description
from pettycashoperationview 
left join sorting on pettycashoperationview.idsor01 = sorting.idsor where  not exists
(select * from entry where idrelated = 'pettycashoperation' + '§' + convert(varchar(4),idpettycash) + '§'  + 
		convert(varchar(4),yoperation) + '§'  + convert(varchar(14),noperation))
AND yoperation = @ayear
	AND (@idsor01 IS NULL OR pettycashoperationview.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR pettycashoperationview.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR pettycashoperationview.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR pettycashoperationview.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR pettycashoperationview.idsor05 = @idsor05)
AND @kind in ('F','A') AND pettycashoperationview.kind NOT IN ('A','R','C')
ORDER BY pettycash,yoperation, noperation

/*
select 'Contratto occasionale',ycon, ncon,adate,description, registry,service,
'cascon' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(4),ncon)
from casualcontractview where not exists
(select * from entry where idrelated = 'cascon' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(4),ncon)
)

select 'Compenso a dipendente',ycon, ncon,adate,description,registry,service,
'wageadd' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(4),ncon)
from wageadditionview where not  exists
(select * from entry where idrelated = 'wageadd' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(4),ncon)
)

select 'Missione',yitineration, nitineration,adate,description,registry,service,
'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + convert(varchar(4),nitineration)
from itinerationview where  not exists
(select * from entry where idrelated = 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 
	convert(varchar(4),nitineration)
)

select 'Liquidazione IVA', yivapay, nivapay, dateivapay,
'ivapay' + '§' + convert(varchar(4),yivapay) + '§'  + convert(varchar(4),nivapay)
from ivapay where not  exists
(select * from entry where idrelated = 'ivapay' + '§' + convert(varchar(4),yivapay) + '§'  + 
	convert(varchar(4),nivapay)
)

select 'Liquidazione Iva consolidata', ymainivapay, nmainivapay,datemainivapay,
'mainivapay' + '§' + convert(varchar(4),ymainivapay) + '§'  + convert(varchar(4),nmainivapay)
from mainivapay where  not exists
(select * from entry where idrelated = 'mainivapay' + '§' + convert(varchar(4),ymainivapay) + '§'  + 
	convert(varchar(4),nmainivapay)
)

select 'Elenco di trasmissione Mandati',ypaymenttransmission, npaymenttransmission, transmissiondate, manager,
'paytrans' + '§' + convert(varchar(4),ypaymenttransmission) + '§'  + convert(varchar(4),npaymenttransmission)
from paymenttransmissionview where not exists
(select * from entry where idrelated = 'paytrans' + '§' + convert(varchar(4),ypaymenttransmission) + '§'  + 
	convert(varchar(4),npaymenttransmission)
)

select 'Elenco di trasmissione Reversali',yproceedstransmission, nproceedstransmission, transmissiondate, manager,
'protrans' + '§' + convert(varchar(4),yproceedstransmission) + '§'  + convert(varchar(4),nproceedstransmission)
from proceedstransmissionview where not exists
(select * from entry where idrelated = 'protrans' + '§' + convert(varchar(4),yproceedstransmission) + '§'  + 
	convert(varchar(4),nproceedstransmission)
)

select 'Fattura', invoicekind ,yinv, ninv,adate, registry, description,
'inv' + '§' + convert(varchar(4),idinvkind) + '§'  + 
		convert(varchar(4),yinv) + '§'  + convert(varchar(4),ninv)
from invoiceview where not exists
(select * from entry where idrelated = 'inv' + '§' + convert(varchar(4),idinvkind) + '§'  + 
		convert(varchar(4),yinv) + '§'  + convert(varchar(4),ninv))

select 'Contratto Passivo', mankind, yman, nman, registry, description,
'man' + '§' + idmankind + '§'  + 
		convert(varchar(4),yman) + '§'  + convert(varchar(4),nman)
from mandateview where not exists
(select * from entry where idrelated = 'man' + '§' + idmankind + '§'  + 
		convert(varchar(4),yman) + '§'  + convert(varchar(4),nman))

select 'Contratto Attivo', estimkind, yestim, nestim, registry, description,
'estim' + '§' + idestimkind + '§'  + 
		convert(varchar(4),yestim) + '§'  + convert(varchar(4),nestim)
from estimateview where  not exists
(select * from entry where idrelated = 'estim' + '§' + idestimkind + '§'  + 
		convert(varchar(4),yestim) + '§'  + convert(varchar(4),nestim))

select 'Cedolino',fiscalyear, npayroll,registry, service,
'payroll' + '§' + convert(varchar(4),idpayroll) + '§'  + 
		convert(varchar(4),fiscalyear) + '§'  + convert(varchar(4),npayroll)
from payrollview where not  exists
(select * from entry where idrelated = 'payroll' + '§' + convert(varchar(4),idpayroll) + '§'  + 
		convert(varchar(4),fiscalyear) + '§'  + convert(varchar(4),npayroll))

select 'Buono di scarico', assetunloadkind,yassetunload, nassetunload,adate,description,
'assetunload' + '§' + convert(varchar(4),idassetunloadkind) + '§'  + 
		convert(varchar(4),yassetunload) + '§'  + convert(varchar(4),nassetunload)
from assetunloadview where not exists
(select * from entry where idrelated = 'assetunload' + '§' + convert(varchar(4),idassetunloadkind) + '§'  + 
		convert(varchar(4),yassetunload) + '§'  + convert(varchar(4),nassetunload))

select 'Buono di carico', assetloadkind,yassetload, nassetload,adate,description,
'assetload' + '§' + convert(varchar(4),idassetloadkind) + '§'  + 
		convert(varchar(4),yassetload) + '§'  + convert(varchar(4),nassetload)
from assetloadview where  not exists
(select * from entry where idrelated = 'assetload' + '§' + convert(varchar(4),idassetloadkind) + '§'  + 
		convert(varchar(4),yassetload) + '§'  + convert(varchar(4),nassetload))

select 'Scarico magazzino', store,ystoreunload, nstoreunload,idstoreunloaddetail,
'storeunloaddetail' + '§' + convert(varchar(4),idstoreunload) + '§'  + 
		convert(varchar(4),idstoreunloaddetail) 
from storeunloaddetailview where not  exists
(select * from entry where idrelated = 'storeunloaddetail' + '§' + convert(varchar(4),idstoreunload) + '§'  + 
		convert(varchar(4),idstoreunloaddetail))

select 'Operazione Fondo Economale', pettycash,yoperation, noperation,adate,description,manager,
'pettycashoperation' + '§' + convert(varchar(4),idpettycash) + '§'  + 
		convert(varchar(4),yoperation) + '§'  + convert(varchar(4),noperation)
from pettycashoperationview where  not exists
(select * from entry where idrelated = 'pettycashoperation' + '§' + convert(varchar(4),idpettycash) + '§'  + 
		convert(varchar(4),yoperation) + '§'  + convert(varchar(4),noperation))

select * from pettycashoperationview 


case "pettycashoperation":
					return ComposeObjects(
						new object[] { "pettycashoperation",
										 R["idpettycash", toConsider],
										 R["yoperation", toConsider],
										 R["noperation", toConsider]
									 });
           
select 'Import Stipendi da CSA', yimport, nimport,adate,description,
'csa_import' + '§' + convert(varchar(4),yimport) + '§'  + convert(varchar(4),nimport)
from csa_import where not exists
(select * from entry where idrelated = 'csa_import' + '§' + convert(varchar(4),yimport) + '§'  + 
	convert(varchar(4),nimport)
)
*/
SELECT 
	desckind  as 'Documento',
	dockind as 'Tipo',
	y as 'Eserc. Doc.',
	case when rownum is  null then convert(varchar(10), n) 
		else convert(varchar(10), n)  + ' (Dettaglio: ' + convert(varchar(10),rownum) + ')'
		end
	as 'Num. Doc.',
	-- n as 'Num. Doc.',
	start as 'Dal',
	stop as 'Al',
	datecompleted as 'Data Acquisizione Documentazione definitiva',
	fiscalyear as 'Eserc. Fiscale',
	ndetail as '#',
	description as 'Descrizione',
	adate as 'Data',
	registry as 'Anagrafica',
	service as 'Prestazione',
	manager as 'Respons.'  ,
	docamount as 'Importo doc.',
	note as 'Note',
	sortcode as 'Codice Attributo',
	descriptions as 'Descrizione Attributo'
FROM #document
END 

 

GO

SET QUOTED_IDENTIFIER OFF 
GO

SET ANSI_NULLS ON 
GO




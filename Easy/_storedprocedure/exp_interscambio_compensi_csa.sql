
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_compensi_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_compensi_csa]
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
 
--setuser 'amministrazione'
CREATE PROCEDURE [exp_interscambio_compensi_csa]
(
@datagenerazione datetime,
@ayear int,
@start datetime,
@stop datetime,

@extmatricula varchar(40),
@mask int
)
--[exp_interscambio_compensi_csa] {d '2023-12-31'}, '2023', {d '2023-01-01'}, {d '2023-12-31'}, '001201', '2'
-- exp_interscambio_csa_record08 {d '2023-12-31'}, '2023', '70049', 'U00007', {d '2023-01-01'}, {d '2023-12-31'}, '001201', '2'
 
AS
-- exec exp_interscambio_compensi_csa {ts '2017-02-01 01:02:03'} ,2017,{ts '2017-02-01 01:02:03'} ,{ts '2017-02-28 01:02:03'}, '001383', 1
BEGIN
IF @mask IS NULL RETURN
DECLARE @annoredditi int
SET @annoredditi = @ayear
declare @expensephase int
select @expensephase = expensephase from config where ayear = @annoredditi
CREATE TABLE #pagamenti(
idexp int, kind char(1),voce8000 varchar(4),voce8000refund_i varchar(4),voce8000refund_e varchar(4),
voce8000exemptionquota varchar(4),capitolo varchar(20),importo decimal(19,2),exemptionquota decimal(19,2),idreg int,
idregistrylegalstatus int,csa_compartment char(1),csa_role varchar(4),extmatricula varchar(40),
ymov int,nmov int,transmissiondate datetime,codeser varchar(20),service varchar(50),module varchar(15),itinerationvisible char(1)
)

INSERT INTO #pagamenti(
idexp,kind,voce8000,capitolo,importo,idreg,extmatricula,ymov,nmov, transmissiondate,codeser,service,module,itinerationvisible
)
SELECT EL.idexp,'I',V.voceimponibile,ISNULL(V.capitoloimponibile,V8.capitolo),MAX(ETO.taxablegross),E.idreg,R.extmatricula,
E.ymov,E.nmov,PT.transmissiondate,S.codeser,S.description,S.module, S.itinerationvisible
FROM expense E 
	JOIN expenselast EL ON E.idexp = EL.idexp
	JOIN expensetaxofficial ETO ON ETO.idexp = EL.idexp
	JOIN tax T ON ETO.taxcode = T.taxcode
	JOIN voce8000lookup V ON V.taxcode = T.taxcode
	JOIN voce8000 V8 ON V.voceimponibile = V8.voce
	join payment P on P.kpay = EL.kpay
	join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN service S ON S.idser = EL.idser
	JOIN registry R ON R.idreg = E.idreg
WHERE P.ypay = @ayear
	AND (( S.flagcsausability & @mask) <>0 )
	AND P.kpaymenttransmission IS NOT NULL
	AND PT.transmissiondate between @start and @stop
	AND ETO.stop is null
	AND R.extmatricula is not null
	AND (( V.flagcsausability & @mask) <>0 )
--AND ISNULL(S.itinerationvisible,'N')= 'N'
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
GROUP BY S.flagcsausability ,E.idreg, R.extmatricula, EL.idexp,PT.transmissiondate,	E.ymov,E.nmov,	S.codeser,
		S.description, S.module, S.itinerationvisible ,	V.voceimponibile,ISNULL(V.capitoloimponibile,V8.capitolo),V.flagcsausability



INSERT INTO #pagamenti(
idexp,kind,voce8000,capitolo,importo,idreg,extmatricula,ymov,nmov, transmissiondate,codeser,service,module,itinerationvisible
)
 
SELECT
EL.idexp, 'I', V.vocequotaesente, ISNULL(V.capitoloquotaesente,V8.capitolo),
(SELECT importo FROM #pagamenti P1 where P1.idexp = EL.idexp 
AND P1.voce8000 = '8047') - MAX(ETO.taxablegross), E.idreg,R.extmatricula,
E.ymov, E.nmov, PT.transmissiondate, S.codeser, S.description, S.module, S.itinerationvisible
FROM expense E
JOIN expenselast EL ON E.idexp = EL.idexp
JOIN expensetaxofficial ETO ON ETO.idexp = EL.idexp
JOIN tax T ON ETO.taxcode = T.taxcode
JOIN voce8000lookup V ON V.taxcode = T.taxcode
JOIN voce8000 V8 ON V.vocequotaesente= V8.voce
JOIN payment P ON P.kpay = EL.kpay
JOIN paymenttransmission PT	 on P.kpaymenttransmission = PT.kpaymenttransmission
JOIN service S ON S.idser = EL.idser
JOIN registry R ON R.idreg = E.idreg
WHERE P.ypay = @ayear
AND (( S.flagcsausability & @mask) <>0 )
AND P.kpaymenttransmission IS NOT NULL
AND PT.transmissiondate between @start and @stop
AND ETO.stop is null
AND R.extmatricula is not null
AND (( V.flagcsausability & @mask) <>0 )
AND  V.voceimponibile =  '8047'
AND  V.vocequotaesente IS NOT NULL
AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
GROUP BY S.flagcsausability ,E.idreg, R.extmatricula, EL.idexp,PT.transmissiondate,
E.ymov,E.nmov,	S.codeser,S.description, S.module, S.itinerationvisible ,	V.vocequotaesente,  
ISNULL(V.capitoloquotaesente,V8.capitolo),V.flagcsausability

-- Inserisce le ritenute c/Amm
INSERT INTO #pagamenti( idexp, kind,voce8000,capitolo,importo,idreg,extmatricula,ymov,nmov,transmissiondate,codeser,
service, module, itinerationvisible
)
SELECT EL.idexp, 'R',V.voce,ISNULL(V.capitolovoce,V8.capitolo),SUM(ETO.admintax),E.idreg,R.extmatricula,E.ymov,E.nmov,PT.transmissiondate,S.codeser,
S.description,S.module,S.itinerationvisible
FROM expense E
	JOIN expenselast EL ON E.idexp = EL.idexp
	JOIN expensetaxofficial ETO ON ETO.idexp = EL.idexp
	JOIN voce8000lookup V ON V.taxcode = ETO.taxcode
	JOIN voce8000 V8 ON V.voce = V8.voce
	join payment P on P.kpay = EL.kpay
	join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN service S ON S.idser = EL.idser
	JOIN registry R ON R.idreg = E.idreg
	WHERE P.ypay = @ayear
		AND (( S.flagcsausability & @mask) <>0 )
		AND V.conto = 'A'
		AND isnull(ETO.admintax,0) >= 0
		AND P.kpaymenttransmission IS NOT NULL
		AND PT.transmissiondate between @start and @stop
		AND ETO.stop is null
		AND R.extmatricula is not null
		AND (( V.flagcsausability & @mask) <>0 )
--AND ISNULL(S.itinerationvisible,'N')= 'N'
		AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
GROUP BY S.flagcsausability , EL.idexp, V.voce,	E.idreg, R.extmatricula,PT.transmissiondate,
		E.ymov,E.nmov,S.codeser,S.description, S.module, S.itinerationvisible , ISNULL(V.capitolovoce,V8.capitolo),V.flagcsausability


-- la Group By la faccio per la presenza di eventuali scaglioni
-- Inserisce le ritenute c/Dip
INSERT INTO #pagamenti( idexp,kind,voce8000,capitolo,importo,idreg,extmatricula,ymov,nmov,transmissiondate,codeser,service,module,itinerationvisible
)
SELECT EL.idexp,'R',V.voce,ISNULL(V.capitolovoce,V8.capitolo),SUM(ETO.employtax),E.idreg,R.extmatricula,E.ymov,E.nmov,
PT.transmissiondate,S.codeser,S.description,S.module,S.itinerationvisible
FROM expense E 
	JOIN expenselast EL ON E.idexp = EL.idexp
	JOIN expensetaxofficial ETO ON ETO.idexp = EL.idexp
	JOIN voce8000lookup V ON V.taxcode = ETO.taxcode
	JOIN voce8000 V8 ON V.voce = V8.voce
	join payment P on P.kpay = EL.kpay
	join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN service S		ON S.idser = EL.idser
	JOIN registry R		ON R.idreg = E.idreg
WHERE P.ypay = @ayear
	AND (( S.flagcsausability & @mask) <>0 )
	AND V.conto = 'D'
	AND isnull(ETO.employtax,0) >= 0

	AND P.kpaymenttransmission IS NOT NULL
	AND PT.transmissiondate between @start and @stop
	AND ETO.stop is null
	AND R.extmatricula is not null
	AND (( V.flagcsausability & @mask) <>0 )
--AND ISNULL(S.itinerationvisible,'N')= 'N'
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
GROUP BY S.flagcsausability ,EL.idexp, V.voce,ISNULL(V.capitolovoce,V8.capitolo),	E.idreg, R.extmatricula, PT.transmissiondate,
E.ymov,E.nmov,S.codeser,S.description, S.module, S.itinerationvisible , V.flagcsausability

CREATE TABLE #Missione( iditineration int,idreg int,extmatricula varchar(40),idexp int,movkind int,curramount decimal(19,2),
voce8000refund_i varchar(4), voce8000refund_e varchar(4),capitolo_i varchar(20),capitolo_e varchar(20), ymov int,
nmov int,  transmissiondate datetime, codeser varchar(20), service varchar(50), module varchar(15), 
itinerationvisible char(1), idregistrylegalstatus int
)

;with PagamentoAnticipoMissione(iditineration, amount)
as (
SELECT EI.iditineration, EL.curramount
FROM expense E
	JOIN expenselastview EL ON E.idexp = EL.idexp
	JOIN registry R ON R.idreg = E.idreg
	JOIN expenselink ELL on ELL.idchild = EL.idexp AND ELL.nlevel = @expensephase
	JOIN expenseitineration EI on ELL.idparent = EI.idexp
WHERE R.extmatricula is not null
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
	AND EI.movkind = 6 -- Anticipo della missione su capitolo di spesa
)

INSERT INTO #Missione (iditineration,idreg,extmatricula,idexp,movkind,curramount,voce8000refund_i,voce8000refund_e,capitolo_i,
capitolo_e,ymov,nmov,transmissiondate,codeser,service,module,itinerationvisible,idregistrylegalstatus)
SELECT I.iditineration,I.idreg,R.extmatricula,EL.idexp,E.movkind,EL.curramount + isnull(PagamentoAnticipoMissione.amount,0),S.voce8000refund_i,S.voce8000refund_e,V8_i.capitolo,
V8_e.capitolo,EL.ymov,EL.nmov,PT.transmissiondate,S.codeser,S.description,S.module, S.itinerationvisible, I.idregistrylegalstatus
FROM itineration I 
	JOIN expenseitineration E  ON E.iditineration = I.iditineration
	join expenselink ELK ON ELK.idparent = E.idexp
	join expense EXPE ON ELK.idparent = EXPE.idexp
	join expenselastview EL  on EL.idexp = ELK.idchild
	join payment P on P.kpay = EL.kpay
	join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN service S ON S.idser = I.idser
	LEFT OUTER JOIN voce8000 V8_i ON S.voce8000refund_i = V8_i.voce
	LEFT OUTER JOIN voce8000 V8_e ON S.voce8000refund_e = V8_e.voce
	JOIN registry R ON R.idreg = I.idreg
	LEFT OUTER JOIN PagamentoAnticipoMissione
		on PagamentoAnticipoMissione.iditineration = I.iditineration
WHERE (( S.flagcsausability & @mask) <>0 ) --> Solo le missioni da comunicare nel Record 8000
	AND P.ypay = @ayear
	AND PT.transmissiondate between @start and @stop
	AND R.extmatricula is not null
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
	AND E.movkind not in (5,6)	--> 5 - Anticipo della missione su partita di giro, 6 - Anticipo della missione sul capitolo di spesa

declare @idtipo_rimborso_forfettario int
select @idtipo_rimborso_forfettario = iditinerationrefundkind from itinerationrefundkind where codeitinerationrefundkind = '07_FORFETTARIO'
CREATE TABLE #SpeseMissione(
iditineration int,
flagadvancebalance char(1),
flag_geo char(1),
amount decimal(19,2),
voce8000refund_i varchar(4),
voce8000refund_e varchar(4)
)
INSERT INTO #SpeseMissione(iditineration, flagadvancebalance, flag_geo, amount, voce8000refund_i,voce8000refund_e)
SELECT
S.iditineration,
S.flagadvancebalance,
S.flag_geo,
SUM(S.amount),
	CASE  WHEN (S.flag_geo = 'I' AND M.voce8000refund_i IS NOT NULL) THEN M.voce8000refund_i ELSE NULL END ,
	CASE  WHEN (S.flag_geo <> 'I' AND M.voce8000refund_e IS NOT NULL) THEN M.voce8000refund_e ELSE NULL END
	FROM itinerationrefund	S
JOIN #Missione M ON S.iditineration = M.iditineration
WHERE (
		(S.flag_geo = 'I' AND M.voce8000refund_i IS NOT NULL)
		OR
		(S.flag_geo <> 'I' AND M.voce8000refund_e IS NOT NULL)
	  )
AND S.flagadvancebalance = 'S' -- Attenzione dobbiamo considerare solo le spese a saldo
AND S.iditinerationrefundkind <> @idtipo_rimborso_forfettario
GROUP BY  S.iditineration, S.flagadvancebalance, S.flag_geo, M.voce8000refund_i, M.voce8000refund_e
HAVING SUM(S.amount) <> 0

-- Consideriamo l'indennità kilometrica, calcolata come:  kmProprio * ImpProprio + KmAmm * ImpAmm + KmPiedi * ImpPiedi
INSERT INTO #SpeseMissione(iditineration, flagadvancebalance, flag_geo, amount, voce8000refund_i,voce8000refund_e)
SELECT
	S.iditineration,
	'S',
	'I', -- flag_geo,
	round( convert(decimal(19,2), isnull(S.owncarkm,0)) * isnull(S.owncarkmcost,0) + convert(decimal(19,2), isnull(S.admincarkm,0)) *  isnull(S.admincarkmcost,0) + convert(decimal(19,2), isnull(S.footkm,0)) * isnull(S.footkmcost,0),2),
	M.voce8000refund_i, --M.voce8000refund_e
	null
FROM itineration S
JOIN #Missione M 
	ON S.iditineration = M.iditineration
where (select count(*) from itinerationrefund where  itinerationrefund.iditineration = S.iditineration)=0
and 	round( convert(decimal(19,2), isnull(S.owncarkm,0)) * isnull(S.owncarkmcost,0) + convert(decimal(19,2), isnull(S.admincarkm,0)) *  isnull(S.admincarkmcost,0) + convert(decimal(19,2), isnull(S.footkm,0)) * isnull(S.footkmcost,0),2) <> 0


-- Assumiamo per diaria il particolare tipo rimborso forfettario O7_FORFETTARIO
CREATE TABLE #DiariaMissione( iditineration int, flagadvancebalance char(1), amount decimal(19,2),exemptionquota decimal(19,2),taxableprev decimal(19,2) )
INSERT INTO #DiariaMissione(iditineration, flagadvancebalance, amount )
SELECT S.iditineration, S.flagadvancebalance, SUM(S.amount) 
FROM itinerationrefund	S
	JOIN #Missione M ON S.iditineration = M.iditineration
WHERE S.flagadvancebalance = 'S' -- Attenzione dobbiamo considerare solo le spese a saldo
	AND S.iditinerationrefundkind = @idtipo_rimborso_forfettario
GROUP BY S.iditineration, S.flagadvancebalance

UPDATE #DiariaMissione SET taxableprev =
	(SELECT TOP 1 taxable FROM itinerationtax join tax on itinerationtax.taxcode = tax.taxcode
		WHERE #DiariaMissione.iditineration = itinerationtax.iditineration
		AND taxkind = 3 --'prendo l'imponibile della ritenuta previdenziale'
	)
UPDATE #DiariaMissione SET exemptionquota = ISNULL(amount,0) - ISNULL(taxableprev,0)

--rimborso_totale_forfettario : quota_esente_totale_forfettaria = imponibile_parziale : quota_esente_parziale
--quota_esente_parziale = quota_esente_totale_forfettaria * imponibile_parziale / rimborso_totale_forfettario
;with PagamentoAnticipo(iditineration, amount)
as (
SELECT EI.iditineration, EL.curramount
FROM expense E
	JOIN expenselastview EL ON E.idexp = EL.idexp
	JOIN registry R ON R.idreg = E.idreg
	JOIN expenselink ELL on ELL.idchild = EL.idexp AND ELL.nlevel = @expensephase
	JOIN expenseitineration EI on ELL.idparent = EI.idexp
WHERE R.extmatricula is not null
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
	AND EI.movkind = 6 -- Anticipo della missione su capitolo di spesa
)

INSERT INTO #pagamenti(
	idexp,	kind,	voce8000,	capitolo,	importo,	idreg,	extmatricula,	ymov,
	nmov,	transmissiondate,	codeser,	service,	module,	itinerationvisible
)

SELECT
	EL.idexp, 	'I',  	V.vocequotaesente,	ISNULL(V.capitoloquotaesente,V8.capitolo),
		--quota_esente_parziale = quota_esente_totale_forfettaria * imponibile_parziale / imponibile_totale
	Round(#DiariaMissione.exemptionquota * (EL.curramount + isnull(PagamentoAnticipo.amount,0)) / I.totalgross,2),
	E.idreg, 	R.extmatricula,	E.ymov,	E.nmov, 	PT.transmissiondate,	S.codeser,
	S.description,	S.module,	S.itinerationvisible
FROM expense E
	JOIN expenselastview EL ON E.idexp = EL.idexp
	JOIN expensetaxofficial ETO	ON ETO.idexp = EL.idexp
	JOIN tax T ON ETO.taxcode = T.taxcode
	JOIN voce8000lookup V ON V.taxcode = T.taxcode
	JOIN voce8000 V8 ON V.vocequotaesente = V8.voce
	join payment P on P.kpay = EL.kpay
	join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN service S ON S.idser = EL.idser
	JOIN registry R ON R.idreg = E.idreg
	JOIN expenselink ELL on ELL.idchild = EL.idexp AND ELL.nlevel = @expensephase
	JOIN expenseitineration EI on ELL.idparent = EI.idexp
	JOIN itineration I on I.iditineration = EI.iditineration
	JOIN #DiariaMissione  on #DiariaMissione.iditineration = I.iditineration
	LEFT OUTER JOIN PagamentoAnticipo
		ON PagamentoAnticipo.iditineration = I.iditineration
WHERE P.ypay = @ayear AND EL.ayear = @ayear
	AND (( S.flagcsausability & @mask) <>0 )
	AND P.kpaymenttransmission IS NOT NULL
	AND PT.transmissiondate between @start and @stop
	AND ETO.stop is null
	AND R.extmatricula is not null
	AND  (LTRIM(RTRIM(R.extmatricula)) = LTRIM(RTRIM(@extmatricula)) OR @extmatricula IS NULL)
	AND (( V.flagcsausability & @mask) <>0 )
	AND EI.movkind not in (5,6)	--> 5 - Anticipo della missione su partita di giro, 6 - Anticipo della missione sul capitolo di spesa
GROUP BY S.flagcsausability ,E.idreg, R.extmatricula, EL.idexp,PT.transmissiondate,
	E.ymov,E.nmov,	S.codeser,S.description, S.module,	V.vocequotaesente,	S.itinerationvisible,
	ISNULL(V.capitoloquotaesente,V8.capitolo),V.flagcsausability,#DiariaMissione.exemptionquota,EL.curramount, I.totalgross, PagamentoAnticipo.amount


---- Valorizzo idregistrylegalstatus prendendolo dall'eventuale compenso a Dipendenti
UPDATE #pagamenti SET idregistrylegalstatus =
(	SELECT W.idregistrylegalstatus 
	FROM expenselast EL 
		LEFT OUTER JOIN service S on EL.idser = S.idser
		LEFT OUTER JOIN expenselink ELL on ELL.idchild = EL.idexp and ELL.nlevel = @expensephase
		LEFT OUTER JOIN expensewageaddition EW on ELL.idparent = EW.idexp
		LEFT OUTER JOIN wageaddition W on W.ycon = EW.ycon and W.ncon = EW.ncon
	WHERE W.ycon IS NOT NULL
		AND #pagamenti.idexp = EL.idexp
)
where 	idregistrylegalstatus is null

---- Valorizzo idregistrylegalstatus prendendolo dall'eventuale cococo
UPDATE #pagamenti SET idregistrylegalstatus =
(select P.idregistrylegalstatus 
	from expenselast EL
	LEFT OUTER JOIN service S on EL.idser = S.idser
	LEFT OUTER JOIN expenselink ELL on ELL.idchild = EL.idexp AND ELL.nlevel = @expensephase
	LEFT OUTER JOIN expensepayroll EW on ELL.idparent = EW.idexp
	LEFT OUTER JOIN payroll PY on PY.idpayroll = EW.idpayroll
	LEFT OUTER JOIN parasubcontract P on PY.idcon = P.idcon
WHERE P.idcon IS NOT NULL
	AND #pagamenti.idexp = EL.idexp
)
where 	idregistrylegalstatus is null


---- Valorizzo idregistrylegalstatus prendendolo dall'eventuale missione
UPDATE #pagamenti SET idregistrylegalstatus =
(
select I.idregistrylegalstatus from expenselast EL
	LEFT OUTER JOIN service S  on EL.idser = S.idser
	LEFT OUTER JOIN expenselink ELL on ELL.idchild = EL.idexp AND ELL.nlevel = @expensephase
	LEFT OUTER JOIN expenseitineration EI on ELL.idparent = EI.idexp
	LEFT OUTER JOIN itineration I on I.iditineration = EI.iditineration
WHERE I.iditineration IS NOT NULL
	AND #pagamenti.idexp = EL.idexp
)
where 	idregistrylegalstatus is null

--select '#Missione',* from #Missione 

--select '#Missione',* from #Missione-- where flag_geo <> 'I'
--select '#SpeseMissione',* from #SpeseMissione where flag_geo = 'I'
--select '#SpeseMissione',* from #SpeseMissione where flag_geo <> 'I'
--SELECT
--#Italia.*
--FROM #Missione
--	JOIN #SpeseMissione #Italia		ON #Missione.iditineration = #Italia.iditineration AND #Italia.flag_geo = 'I'
	
--SELECT
--#Estero.*
--FROM #Missione
--JOIN #SpeseMissione #Estero ON #Missione.iditineration = #Estero.iditineration AND #Estero.flag_geo <> 'I'

INSERT INTO #pagamenti(idexp,kind,voce8000refund_i,capitolo,importo,idreg,extmatricula,ymov,
nmov,transmissiondate,codeser,service, module,itinerationvisible,idregistrylegalstatus
)
SELECT
#Missione.idexp,'S',#Italia.voce8000refund_i,#Missione.capitolo_i,
Round((#Missione.curramount*#Italia.amount)/ ISNULL((SELECT SUM(#SpeseMissione.amount) FROM #SpeseMissione
 WHERE #SpeseMissione.iditineration = #Missione.iditineration),0),2),
#Missione.idreg,#Missione.extmatricula,#Missione.ymov,#Missione.nmov,#Missione.transmissiondate,
#Missione.codeser,#Missione.service,#Missione.module,#Missione.itinerationvisible,#Missione.idregistrylegalstatus
FROM #Missione
	JOIN #SpeseMissione #Italia		ON #Missione.iditineration = #Italia.iditineration AND #Italia.flag_geo = 'I'
		 
 --SELECT * from #pagamenti
INSERT INTO #pagamenti( idexp,kind,voce8000refund_e,capitolo,importo,idreg,extmatricula,ymov,nmov,
transmissiondate,codeser,service,module,itinerationvisible,idregistrylegalstatus)
SELECT
#Missione.idexp,'S',#Estero.voce8000refund_e,#Missione.capitolo_e,
Round((#Missione.curramount*#Estero.amount)/ ISNULL((SELECT SUM(#SpeseMissione.amount) FROM #SpeseMissione
 WHERE #SpeseMissione.iditineration = #Missione.iditineration),0),2),
#Missione.idreg,#Missione.extmatricula,#Missione.ymov,#Missione.nmov,#Missione.transmissiondate,#Missione.codeser,
#Missione.service,#Missione.module,#Missione.itinerationvisible,#Missione.idregistrylegalstatus
FROM #Missione
	JOIN #SpeseMissione #Estero ON #Missione.iditineration = #Estero.iditineration AND #Estero.flag_geo <> 'I'
 

UPDATE #Pagamenti SET idregistrylegalstatus =
(select TOP 1 R1.idregistrylegalstatus
from registrylegalstatus R1
where R1.idreg = #Pagamenti.idreg
	and R1.csa_compartment is not null
	and R1.csa_role is not null
	and #Pagamenti.transmissiondate BETWEEN R1.start AND ISNULL(R1.stop,#Pagamenti.transmissiondate)
)
WHERE #Pagamenti.idregistrylegalstatus IS NULL
 

UPDATE #Pagamenti SET csa_role = RLS.csa_role, csa_compartment = RLS.csa_compartment
from registrylegalstatus RLS
WHERE RLS.idreg = #Pagamenti.idreg
	AND RLS.idregistrylegalstatus= #Pagamenti.idregistrylegalstatus
 


DECLARE @departmentname varchar(500)
SET @departmentname = ISNULL( (SELECT paramvalue from
generalreportparameter where idparam='DenominazioneDipartimento'
and (start is null or year(start) <= @ayear)
and (stop is null or year(stop) >= @ayear)
),'Manca Cfg. Parametri Tutte le stampe')
-- In Out forniamo anche idexp perch il file deve comunicare un record per pagamento
-- Ma l'idexp non basta, perch univoco nel dipartimento non nel DB, quindi vi concateniamo anche lo user per avere una chiave
-- univoca del mov. di spesa all'interno del DB consolidato
SELECT P.idreg,P.csa_role,P.csa_compartment,P.extmatricula,@departmentname as departmentname,convert(varchar(10),P.idexp) as reference,
P.voce8000,P.voce8000refund_i,P.voce8000refund_e,P.capitolo,P.importo,P.ymov,P.nmov,P.transmissiondate,P.codeser,P.service,
P.itinerationvisible 
FROM #pagamenti P
	JOIN csa_rolekind RL ON  LTRIM(RTRIM(ISNULL(RL.csa_role,'')))  = LTRIM(RTRIM(ISNULL(P.csa_role,'')))
						AND (( RL.flagcsausability & @mask) <>0 ) -- infine filtro anche i ruoli compatibili con la maschera selezionata
ORDER BY P.idreg, P.idexp, P.kind, P.voce8000
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


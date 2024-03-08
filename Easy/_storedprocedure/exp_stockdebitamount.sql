
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_stockdebitamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_stockdebitamount]
GO

CREATE  PROCEDURE [exp_stockdebitamount](
	@year 			int,
	@idivaregisterkind 	int,
	@idinvkind int, 	  
	--@start datetime,
	@stop datetime,	
	@stoppay datetime,	
	@unified  char(1),
	@kind char(1), --- Tipo vista D: dettagliata C: consolidata su codice fiscale fornitore
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@excludefattest char(1) --- S: filtra, N: non filtra
)  
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_stockdebitamount 2022,null,null, '2022-12-31', '2023-02-20','S','D',null,null,null,null,null,'N'
 
 

AS BEGIN
	--- parametro gestisci recupero split payment in config
	 declare @recuperosplit char(1)
	 set @recuperosplit='N'
	 if (select (flag & 1) from config where ayear=@year)<>0 set @recuperosplit='S'

	--- MEMORIZZA I TIPI DOCUMENTO IVA INDICANDO IN PARTICOLARE SE SONO NOTE DI CREDITO DA INCASSARE
	CREATE TABLE #invoicekind (idinvkind int,flagbuysell char(1),creditnotetocashin char(1))
	INSERT INTO #invoicekind (idinvkind,flagbuysell,creditnotetocashin)

	SELECT idinvkind,
	CASE
		WHEN (IK.flag&1<>0) THEN 'V'
		ELSE 'A'
	END,
	CASE 
		WHEN (IK.flag&1<>0)  AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IK.idinvkind
					and RK.registerclass = 'A'
				) >= 1  THEN 'S'
		ELSE 'N'
	END
	from invoicekind IK 
 --SELECT * FROM #invoicekind

	CREATE TABLE #invoicedebitamount
	(	
		idinvkind int,
		yinv int,
		ninv int,
		ycon int,
		ncon int,
		adate datetime, 
		protocoldate datetime,
		docdate datetime,
		transmissiondate datetime,
		taxable_euro  decimal(19,2), 
		iva_euro  decimal(19,2),
		iva_euro_split_payment decimal(19,2),
		curr_amount  decimal(19,2), 
		pettycash_amount decimal(19,2), 
		profservice_amount decimal(19,2),
		iva_split_amount decimal(19,2),
		NOLIQ_amount decimal(19,2),
		totaldebit_amount decimal(19,2),
		expiring datetime,
		dateconsidered datetime,
		paymentfromexpiring  int,
		kind int,
		idreg int,
		flagvariation char(1), 
		creditnotetocashin char(1)  -- nota di credito da incassare
	)
 	-- insert dei movimenti finanziari che contabilizzano le fatture

-- insert se fattura di acquisto
	INSERT INTO #invoicedebitamount 
	(
		idinvkind,		yinv,		ninv,	flagvariation,
		adate,		protocoldate, docdate, expiring, dateconsidered,
		taxable_euro, iva_euro,iva_euro_split_payment,
		curr_amount, pettycash_amount, profservice_amount, iva_split_amount,NOLIQ_amount,/*gli importi delle contabilizzazioni sono valorizzati a zero in questa fase*/ kind /*vale 1 in questa fase*/, idreg 
	 )
	SELECT 
		I.idinvkind,		I.yinv,		I.ninv,		I.flagvariation,
		I.adate,	I.protocoldate,	I.docdate, I.paymentexpiring,	
		coalesce(I.expiring,I.protocoldate,I.adate),
		--escludo iva split dal calcolo secondo task 8647
		case when ((IK.flag&4)<>0)  OR (IK1.creditnotetocashin = 'S') /*le note di variazione vanno equiparate alle note di credito da incassare*/
			then - isnull((select sum(taxable_euro) 
							from invoicedetailview ID 
							where  I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
							and isnull(ID.idpccdebitmotive,'') <>'CONT' 
							--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
							and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
							),0) /*task 15343*/
			else isnull((select sum(taxable_euro) 
						from invoicedetailview ID 
						where  I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
						and isnull(ID.idpccdebitmotive,'') <>'CONT' 
						--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
						and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
						),0) /*task 15343*/
		end,
		-- IVA, rientra nell'ammontare del debito solo se la Fattura non è INTRA -EXTRA UE. In questi casi, la cosiddetta iva di integrazione non rientra
		-- nell'ammontare del debito
		case when ((IK.flag&4)<>0) OR (IK1.creditnotetocashin = 'S') /*le note di variazione vanno equiparate alle note di credito da incassare*/
			then - isnull((select sum(iva_euro) 
							from invoicedetailview ID 
							where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
							and isnull(ID.idpccdebitmotive,'') <>'CONT' 
							--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
							and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
							),0)  /*per le  NC */			
			else isnull((select sum(iva_euro) 
							from invoicedetailview ID 
							where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
							and isnull(ID.idpccdebitmotive,'') <>'CONT' 
							--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
							and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
							),0) /*per le fatture */						
		end,
		--- IVA SPLIT, rientra nell'ammontare del debito
		case when (I.flag_enable_split_payment='S'  OR (@recuperosplit='S' AND I.flagintracom<>'N')) and (((IK.flag&4)<>0) OR  (IK1.creditnotetocashin = 'S') )
		 /*le note di variazione vanno equiparate alle note di credito da incassare*/
				then - isnull((select sum(iva_euro) 
						from invoicedetailview ID 
						where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
						and isnull(ID.idpccdebitmotive,'') <>'CONT' 
						--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
						and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
						),0)
			 when (I.flag_enable_split_payment='S' OR (@recuperosplit='S' AND I.flagintracom<>'N')) and ((IK.flag&4)=0) 
				then isnull((select sum(iva_euro) 
							from invoicedetailview ID 
							where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv 
							and isnull(ID.idpccdebitmotive,'') <>'CONT' 
							--Aggiungo i nuovi stati ma lascio le condizioni esistenti per esportare fatture pregresse
							and isnull(ID.idpccdebitstatus,'') not in ('SOSP','NLdaLIQ','NLdaSOSP','NOLIQ','SospCnst','SospContz','SOSPdaLIQ','SOSPdaNL','SospEsReg')
							),0)			 
			 else 0
		end,
		0,0,0,0,0, 1,I.idreg 
	FROM invoiceview I 			 
	JOIN invoicekind  IK  ON I.idinvkind = IK.idinvkind	 
	JOIN #invoicekind  IK1  ON IK1.idinvkind = IK.idinvkind	 
   WHERE 
	coalesce(I.expiring,I.protocoldate,I.adate)  <= @stop
		AND (IK.idinvkind = @idinvkind OR @idinvkind is null)
		AND ((EXISTS (SELECT * FROM ivaregister IRG 
			      WHERE IRG.idinvkind = I.idinvkind
				AND IRG.yinv = I.yinv
				AND IRG.ninv = I.ninv 
				AND IRG.idivaregisterkind = @idivaregisterkind
				AND @idivaregisterkind IS NOT NULL))  
		     OR (@idivaregisterkind is null))
		AND ISNULL(I.toincludeinpaymentindicator,'S') <> 'N'		
		AND (ISNULL(I.idsor01,IK.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (ISNULL(I.idsor02,IK.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (ISNULL(I.idsor03,IK.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (ISNULL(I.idsor04,IK.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (ISNULL(I.idsor05,IK.idsor05) = @idsor05 OR @idsor05 IS NULL)
		AND (
			(IK.flag&1=0)  --- prende le fatture di acquisto
			OR  --- prende le NOTE DI CREDITO  SU acquisti DA INCASSARE
			IK1.creditnotetocashin = 'S'  
		)
		AND (I.flagbit & 1 =0 ) -- Esclude le bollette doganali
		AND ( (@excludefattest = 'S' and I.flagintracom ='N') OR (@excludefattest = 'N'))
		AND (I.idsdi_acquisto IS NOT NULL  OR I.idsdi_acquistoestere  IS NOT NULL)  -- Escludo le fatture cartacee

  
  		
-- Contab. Fatture: considera l'importo del mov. principale, senza variazioni (le prenderà dopo)
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		flagvariation,
		curr_amount, pettycash_amount, profservice_amount, iva_split_amount,NOLIQ_amount, idreg,kind
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.flagvariation,
	sum( EY.amount), 0,0, 
	-- scorporo dal pagamento l'iva contabilizzata per le sole fatture split payment, in cui l'iva rientra nell'ammontare del debito task 17616
	CASE
		WHEN (#invoicedebitamount.iva_euro_split_payment <> 0) THEN 
		 ((SELECT ISNULL(SUM(tax),0) FROM invoicedetail ED							
									WHERE ED.idinvkind= #invoicedebitamount.idinvkind		
										AND ED.yinv = #invoicedebitamount.yinv
										AND ED.ninv = #invoicedebitamount.ninv
										AND ED.idexp_iva = EI.idexp ))
		ELSE 0
	END, 0,
	#invoicedebitamount.idreg,21
	FROM expenseinvoice EI
	JOIN expenselast ELAST on ELAST.idexp= EI.idexp
	JOIN expenseyear EY on ELAST.idexp=EY.idexp
	JOIN payment P	ON	P.kpay = ELAST.kpay
	JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN #invoicedebitamount 	ON EI.idinvkind=#invoicedebitamount.idinvkind 	AND EI.yinv=#invoicedebitamount.yinv AND EI.ninv=#invoicedebitamount.ninv
	WHERE  PT.transmissiondate <= @stoppay and isnull(#invoicedebitamount.kind,0) = 1 AND #invoicedebitamount.flagvariation = 'N'
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg,#invoicedebitamount.iva_euro_split_payment,EI.idexp,
	#invoicedebitamount.flagvariation 



-- Contab. Fatture: considera le var. del movimento. Prendere solo le var. del movimento, non le contabilizzazioni delle NC.
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		flagvariation,
		curr_amount, pettycash_amount, profservice_amount, iva_split_amount, NOLIQ_amount, idreg,kind
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.flagvariation ,
	sum(EV.amount), 0,0,0,0, #invoicedebitamount.idreg,23
	FROM expensevar EV
	join expenseinvoice EI on EV.idexp= EI.idexp
	JOIN expenselast ELAST on ELAST.idexp= EI.idexp
	JOIN expenseyear EY on ELAST.idexp=EY.idexp
	JOIN payment P	ON	P.kpay = ELAST.kpay
	JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN #invoicedebitamount 
		ON EI.idinvkind=#invoicedebitamount.idinvkind 
		AND EI.yinv=#invoicedebitamount.yinv 
		AND EI.ninv=#invoicedebitamount.ninv
	WHERE  PT.transmissiondate <=@stoppay and isnull(#invoicedebitamount.kind,0) = 1
		AND EV.idinvkind IS NULL -- deve prendere solo le var. del movimento, NON le contabilizzazioni delle NC
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg,
	#invoicedebitamount.flagvariation 


-- Contab. note di variazione : considera le var. del movimenti che contabilizzano NC
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		flagvariation,
		curr_amount, pettycash_amount, profservice_amount, iva_split_amount,NOLIQ_amount, idreg,kind
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.flagvariation ,
	sum(EI.amount), 0,0,0,0,  #invoicedebitamount.idreg,24
	FROM expensevar EI
	JOIN expenselast ELAST on ELAST.idexp= EI.idexp
	JOIN expenseyear EY on ELAST.idexp=EY.idexp
	JOIN payment P	ON	P.kpay = ELAST.kpay -- Mandato del pagamento principale
	JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN #invoicedebitamount 
		ON EI.idinvkind=#invoicedebitamount.idinvkind 
		AND EI.yinv=#invoicedebitamount.yinv 
		AND EI.ninv=#invoicedebitamount.ninv
	WHERE  PT.transmissiondate <= @stoppay and isnull(#invoicedebitamount.kind,0) = 1
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg,
	#invoicedebitamount.flagvariation 


--- Non Sottraggo eventuali recuperi dell'iva split 
--- Per le Fatture Split Payment non dobbiamo sottrarre più il recupero split payment perchè con la contabilizzazione 
--  al lordo del recupero si deve considerare estinto anche il debito relativo all'iva split payment 
--  (teoricamente si apre però il debito con l'Erario)
 

-- Considero eventuali contabilizzazioni effettuate mediante fondo economale

INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		flagvariation,
		curr_amount, pettycash_amount, profservice_amount, iva_split_amount, NOLIQ_amount,idreg,kind
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.flagvariation ,
	0, sum(amount),0,
	-- scorporo dal pagamento l'iva contabilizzata per le sole fatture split payment, in cui l'iva rientra nell'ammontare del debito task 17616
	CASE
		WHEN (#invoicedebitamount.iva_euro_split_payment <> 0) THEN 
		 ((SELECT ISNULL(SUM(tax),0) FROM invoicedetail ED							
									WHERE ED.idinvkind = #invoicedebitamount.idinvkind		
										AND ED.yinv = #invoicedebitamount.yinv
										AND ED.ninv = #invoicedebitamount.ninv))
		ELSE 0
	END, 0,
	#invoicedebitamount.idreg,25
	FROM pettycashoperationinvoice PCOP 
	JOIN pettycashoperation PCO 
		ON PCOP.idpettycash=PCO.idpettycash 
		AND PCOP.yoperation = PCO.yoperation 
		AND PCO.noperation=PCOP.noperation
	JOIN #invoicedebitamount ON PCOP.idinvkind=#invoicedebitamount.idinvkind 
		AND PCOP.yinv=#invoicedebitamount.yinv 
		AND PCOP.ninv=#invoicedebitamount.ninv
	WHERE   PCO.adate <= @stoppay and isnull(#invoicedebitamount.kind,0) = 1	
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv,
	#invoicedebitamount.idreg,#invoicedebitamount.iva_euro_split_payment,#invoicedebitamount.flagvariation 


INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		flagvariation,
		curr_amount, pettycash_amount, profservice_amount,iva_split_amount,NOLIQ_amount,idreg,kind
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.flagvariation ,
	0, 0, sum(ET.curramount) ,
	-- scorporo dal pagamento l'iva contabilizzata per le sole fatture split payment, in cui l'iva rientra nell'ammontare del debito task 17616
	CASE
		WHEN (#invoicedebitamount.iva_euro_split_payment <> 0) THEN 
		 ((SELECT ISNULL(SUM(tax),0) FROM #invoicedebitamount ED							
									WHERE ED.idinvkind = #invoicedebitamount.idinvkind		
									AND ED.yinv = #invoicedebitamount.yinv
										AND ED.ninv = #invoicedebitamount.ninv))
		ELSE 0
	END, 0,
	#invoicedebitamount.idreg,26
FROM expenseprofservice EP
join profservice PS ON	EP.ycon = PS.ycon	 AND	EP.ncon = PS.ncon	 
JOIN 	invoiceview I 			ON	PS.idinvkind = I.idinvkind	 AND	PS.ninv = I.ninv	 	 AND	PS.yinv = I.yinv	
JOIN #invoicedebitamount 	ON PS.idinvkind=#invoicedebitamount.idinvkind 	AND PS.yinv=#invoicedebitamount.yinv 	AND PS.ninv=#invoicedebitamount.ninv
JOIN expenselink EL on EL.idparent  = EP.idexp 
JOIN expenselast ELAST on ELAST.idexp= EL.idchild
JOIN expenseyear EY on ELAST.idexp=EY.idexp
JOIN expensetotal ET on EY.idexp=ET.idexp
JOIN payment P	ON	P.kpay = ELAST.kpay
JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
WHERE   PT.transmissiondate  <= @stoppay and isnull(#invoicedebitamount.kind,0) = 1
and I.docdate < {ts '2017-07-01 00:00:00'} 
and not exists(select * from #invoicedebitamount Q where Q.idinvkind = I.idinvkind	 AND	Q.ninv = I.ninv	 	 AND	Q.yinv = I.yinv	 and Q.kind>1)
GROUP BY #invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg,#invoicedebitamount.iva_euro_split_payment,
#invoicedebitamount.flagvariation 
UPDATE #invoicedebitamount SET creditnotetocashin  = IK.creditnotetocashin
from #invoicekind IK 
where IK.idinvkind = #invoicedebitamount.idinvkind
 
IF (
	  @kind = 'D'  -- Vista Dettagliata
    )
	SELECT 	 --  filtra  sugli attributi
	@stop as 'Fine Scadenza',
	SDI.identificativo_sdi as 'Indentificativo SDI',
	I.invoicekind AS 'Tipo', 
	I.yinv AS 'Esercizio', 
	I.ninv AS 'Numero', 	
	I.ycon AS 'Anno parcella',
	I.ncon AS 'N.parcella',
	I.doc AS  'Num. Doc. Coll.',
	convert(varchar,I.docdate,105) AS  'Data Doc. Coll.',
	I.cf as 'Codice Fiscale Cliente/Fornitore',
	I.p_iva as 'P. Iva Cliente/Fornitore',
	I.registry AS 'Cliente/Fornitore',
	I.description AS 'Descrizione',
	convert(varchar,I.adate,105) AS 'Data Registrazione',
	convert(varchar,I.protocoldate,105) AS 'Data Protocollo',
	convert(varchar,I.expiring,105) as 'Data Scadenza', 	
	I.iduniqueregister as 'Cod. Progr. Registro Unico', 
	I.flag_enable_split_payment as 'Split Payment',
	CASE I.flagintracom 
		 WHEN 'N' THEN 'Italia'
		 WHEN 'S' THEN 'Intracomunitaria'
		 WHEN 'X' THEN 'Extra-UE'
	END as 'Tipo',
	SUM(CASE 
		WHEN IC.kind = 1 /*and I.flagvariation = 'N' AND creditnotetocashin = 'N'*/  THEN I.total 
		/*WHEN IC.kind = 1 and (I.flagvariation = 'S' OR creditnotetocashin = 'S') THEN - I.total*/ 
		ELSE 0 END) AS 'Tot. fattura',
	SUM(CASE WHEN IC.kind = 1 THEN IC.taxable_euro * (CASE WHEN (I.flagvariation = 'S' OR creditnotetocashin = 'S') THEN -1 ELSE 1 END) ELSE 0 END) AS 'Imponibile',
	SUM(CASE WHEN IC.kind = 1 THEN IC.iva_euro * (CASE WHEN (I.flagvariation = 'S' OR creditnotetocashin = 'S') THEN -1 ELSE 1 END) ELSE 0 END) AS 'IVA',
	CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom = 'N')   THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ - 
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  - ISNULL(IC.iva_split_amount,0) +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
				)  - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - ISNULL(IC.iva_split_amount,0) - -- VERIFICARE
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
				)  - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='S') THEN  
			SUM(ISNULL(IC.taxable_euro,0)   - ISNULL(IC.iva_split_amount,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ - 
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0) ) 
				 ELSE 0
				END
				)  - SUM(ISNULL(IC.NOLIQ_amount,0))

		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
			)  - SUM(ISNULL(IC.NOLIQ_amount,0))
	END  AS 'Totale debito' 
	FROM invoiceview I 		
		JOIN #invoicedebitamount IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  
		LEFT OUTER JOIN sdi_acquisto SDI on I.idsdi_acquisto=SDI.idsdi_acquisto
	group by I.idsdi_acquisto,SDI.identificativo_sdi, I.invoicekind, I.idinvkind, I.yinv, I.ninv,
	I.ycon,I.ncon,I.doc,convert(varchar,I.docdate,105),I.cf,I.p_iva, I.registry,
	I.description,convert(varchar,I.adate,105), convert(varchar,I.protocoldate,105),convert(varchar,I.expiring,105),
	I.iduniqueregister, I.flag_enable_split_payment,  I.flagintracom
		having CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N')   THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0) */- 
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0)  ) 
				 ELSE 0
				END
				)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - 
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
				
				)   - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='S') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ - 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0) ) 
				 ELSE 0
				END
				
				)   - SUM(ISNULL(IC.NOLIQ_amount,0))

		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
				CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
			
			)   - SUM(ISNULL(IC.NOLIQ_amount,0))
	END   <> 0
 	AND SUM(ISNULL(IC.curr_amount,0)) >= 0 
	order by I.idinvkind, I.yinv, I.ninv
ELSE
BEGIN
;
WITH to_sum (idinvkind, yinv, ninv, flag_enable_split_payment, total, taxable_euro, iva_euro, invoicedebitamount) as
(
	SELECT 
		I.idinvkind, 
		I.yinv, 
		I.ninv, 	
		I.flag_enable_split_payment ,
		SUM(CASE 
		WHEN IC.kind = 1 and I.flagvariation = 'N' AND creditnotetocashin = 'N' THEN I.total 
		WHEN IC.kind = 1 and (I.flagvariation = 'S' OR creditnotetocashin = 'S') THEN - I.total 
		ELSE 0 END)  ,

		SUM(CASE WHEN IC.kind = 1 THEN IC.taxable_euro ELSE 0 END)  ,
		SUM(CASE WHEN IC.kind = 1 THEN IC.iva_euro ELSE 0 END)  ,
		CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0) /* + ISNULL(IC.iva_euro_split_payment,0) */- 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0) +ISNULL(IC.NOLIQ_amount,0)  ) 
				 ELSE 0
				END
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='N')THEN  
			SUM(ISNULL(IC.taxable_euro,0)  -
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0)  +ISNULL(IC.NOLIQ_amount,0)  ) 
				 ELSE 0
				END
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='S') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ -
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0)  + ISNULL(IC.NOLIQ_amount,0)  ) 
				 ELSE 0
				END
			) 
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) +ISNULL(IC.NOLIQ_amount,0)  ) 
				 ELSE 0
				END
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		END 
	FROM invoiceview  I 		
		JOIN #invoicedebitamount IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  	
	group by I.idinvkind, I.yinv, I.ninv, I.flag_enable_split_payment, I.flagintracom
	having 	CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ - 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0)  ) 
				 ELSE 0
				END
			
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='N')THEN  
			SUM(ISNULL(IC.taxable_euro,0)  -
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		WHEN (I.flagintracom <> 'N') AND  (@recuperosplit='S') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  /*+ ISNULL(IC.iva_euro_split_payment,0)*/ -
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) - ISNULL(IC.iva_split_amount,0)  ) 
				 ELSE 0
				END
			)    - SUM(ISNULL(IC.NOLIQ_amount,0))
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			CASE WHEN I.flagvariation = 'N' AND creditnotetocashin = 'N'
				 THEN (ISNULL(IC.curr_amount,0)  +  ISNULL(IC.pettycash_amount,0)   + ISNULL(IC.profservice_amount,0) ) 
				 ELSE 0
				END
			)   - SUM(ISNULL(IC.NOLIQ_amount,0))
		END   <> 0
		AND SUM(ISNULL(IC.curr_amount,0)) >= 0 
	)

	SELECT  --  filtra  sugli attributi
	@stop as 'Fine Scadenza',
	I.cf as 'Codice Fiscale Cliente/Fornitore',
	I.p_iva as 'P. Iva Cliente/Fornitore',
	I.registry AS 'Cliente/Fornitore',
	I.flag_enable_split_payment as 'Split Payment',
	CASE I.flagintracom 
		 WHEN 'N' THEN 'Italia'
		 WHEN 'S' THEN 'Intracomunitaria'
		 WHEN 'X' THEN 'Extra-UE'
	END AS 'Tipo',
	SUM(IC.total) AS 'Tot. fattura',
	SUM(IC.taxable_euro) AS 'Imponibile',
	SUM(IC.iva_euro) AS 'IVA',
	SUM(IC.invoicedebitamount) AS 'Totale debito' 
	FROM invoiceview I 
		JOIN TO_SUM IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  		
	group by I.idreg, I.registry,I.cf ,I.p_iva, 
	I.flag_enable_split_payment  ,I.flagintracom
	HAVING SUM(IC.invoicedebitamount) <> 0
	order by I.registry, I.cf,I.p_iva	
	END
END



GO 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec exp_stockdebitamount 2021,null,null, '2021-12-31','S','D',null,null,null,null,null,'S'
--exec exp_stockdebitamount3 2021,null,null, '2021-01-01','2021-12-31','S','D',null,null,null,null,null,'S'
--exec exp_invoicedebitamount 2021,null,null, '2021-01-01','2021-12-31','S','D',null,null,null,null,null,'S'


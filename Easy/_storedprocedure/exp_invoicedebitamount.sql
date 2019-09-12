if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicedebitamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicedebitamount]
GO

CREATE  PROCEDURE [exp_invoicedebitamount](
	@year 			int,
	@idivaregisterkind 	int,
	@idinvkind int, 	  
	@start datetime,
	@stop datetime,	
	@unified  char(1),
	@kind char(1), --- Tipo vista D: dettagliata C: consolidata su codice fiscale fornitore
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)  
-- setuser 'amm'
-- exec exp_invoicedebitamount 2018,null,null, '2018-01-01','2018-14-03','S','D',null,null,null,null,null

/*
*/

AS BEGIN
	 
	CREATE TABLE #invoicedebitamount
	(	
		idinvkind int,
		yinv int,
		ninv int,
		ycon int,
		ncon int,
		adate datetime, 
		protocoldate datetime,
		transmissiondate datetime,
		taxable_euro  decimal(19,2), 
		iva_euro  decimal(19,2),
		iva_euro_split_payment decimal(19,2),
		curr_amount  decimal(19,2), 
		pettycash_amount decimal(19,2), 
		profservice_amount decimal(19,2),
		totaldebit_amount decimal(19,2),
		expiring datetime,
		dateconsidered datetime,
		paymentfromexpiring  int,
		kind int,
		idreg int
	)
 	-- insert dei movimenti finanziari che contabilizzano le fatture
  
-- insert se fattura di acquisto
	INSERT INTO #invoicedebitamount
	(
		idinvkind,		yinv,		ninv,		
		adate,		protocoldate, expiring, dateconsidered,
		taxable_euro, iva_euro,iva_euro_split_payment,
		curr_amount, pettycash_amount, profservice_amount, kind, idreg
	 )
	SELECT 
		I.idinvkind,		I.yinv,		I.ninv,		
		I.adate,	I.protocoldate,	I.paymentexpiring,	
		coalesce(I.expiring,I.protocoldate,I.adate),
		--escludo iva split dal calcolo secondo task 8647
		case when ((IK.flag&4)<>0)
			then - isnull((select sum(taxable_euro) from invoicedetailview ID where  I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
			else isnull((select sum(taxable_euro) from invoicedetailview ID where  I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
		end,
		-- IVA, rientra nell'ammontare del debito solo se la Fattura non � INTRA -EXTRA UE. In questi casi, la cosiddetta iva di integrazione non rientra
		-- nell'ammontare del debito
		case when ((IK.flag&4)<>0) 
			then - isnull((select sum(iva_euro) from invoicedetailview ID where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
			else isnull((select sum(iva_euro) from invoicedetailview ID where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
		end,
		--- IVA SPLIT, rientra nell'ammontare del debito
		case when I.flag_enable_split_payment='S' and ((IK.flag&4)<>0) 
				then - isnull((select sum(iva_euro) from invoicedetailview ID where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
			 when I.flag_enable_split_payment='S' and ((IK.flag&4)=0) 
				then isnull((select sum(iva_euro) from invoicedetailview ID where I.idinvkind = ID.idinvkind AND I.yinv = ID.yinv  AND I.ninv = ID.ninv),0)
			 else 0
		end,
		0,0,0, 1,I.idreg
	FROM invoiceview I 			 
	JOIN invoicekind  IK  ON I.idinvkind = IK.idinvkind	 
   WHERE 
	coalesce(I.expiring,I.protocoldate,I.adate)   between @start and @stop
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
		AND (IK.flag&1=0)
		AND (I.flagbit & 1 =0 ) -- Esclude le bollette doganali
		
-- Contab. Fatture: considera l'importo del mov. principale, senza variazioni (le prender� dopo)
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		
		curr_amount, pettycash_amount, profservice_amount, idreg
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, 
	sum(EY.amount), 0,0, #invoicedebitamount.idreg
	FROM expenseinvoice EI
	JOIN expenselast ELAST on ELAST.idexp= EI.idexp
	JOIN expenseyear EY on ELAST.idexp=EY.idexp
	JOIN payment P	ON	P.kpay = ELAST.kpay
	JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN #invoicedebitamount 
		ON EI.idinvkind=#invoicedebitamount.idinvkind 
		AND EI.yinv=#invoicedebitamount.yinv 
		AND EI.ninv=#invoicedebitamount.ninv
	WHERE  PT.transmissiondate between @start and @stop and isnull(#invoicedebitamount.kind,0) = 1
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg
	
-- Contab. Fatture: considera le var. del movimento. Prendere solo le var. del movimento, non le contabilizzazioni delle NC.
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		
		curr_amount, pettycash_amount, profservice_amount, idreg
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, 
	sum(EV.amount), 0,0, #invoicedebitamount.idreg
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
	WHERE  PT.transmissiondate between @start and @stop and isnull(#invoicedebitamount.kind,0) = 1
		AND EV.idinvkind IS NULL -- deve prendere solo le var. del movimento, NON le contabilizzazioni delle NC
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg

-- Contab. note di variazione : considera le var. del movimenti che contabilizzano NC
INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		
		curr_amount, pettycash_amount, profservice_amount, idreg
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, 
	sum(EI.amount), 0,0, #invoicedebitamount.idreg
	FROM expensevar EI
	JOIN expenselast ELAST on ELAST.idexp= EI.idexp
	JOIN expenseyear EY on ELAST.idexp=EY.idexp
	JOIN payment P	ON	P.kpay = ELAST.kpay -- Mandato del pagamento principale
	JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
	JOIN #invoicedebitamount 
		ON EI.idinvkind=#invoicedebitamount.idinvkind 
		AND EI.yinv=#invoicedebitamount.yinv 
		AND EI.ninv=#invoicedebitamount.ninv
	WHERE  PT.transmissiondate between @start and @stop and isnull(#invoicedebitamount.kind,0) = 1
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg

	
--- Non Sottraggo eventuali recuperi dell'iva split 
--- Per le Fatture Split Payment non dobbiamo sottrarre pi� il recupero split payment perch� con la contabilizzazione 
--  al lordo del recupero si deve considerare estinto anche il debito relativo all'iva split payment 
--  (teoricamente si apre per� il debito con l'Erario)
 

-- Considero eventuali contabilizzazioni effettuate mediante fondo economale

INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		
		curr_amount, pettycash_amount, profservice_amount,idreg
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, 
	0, sum(amount),0,#invoicedebitamount.idreg
	FROM pettycashoperationinvoice PCOP 
	JOIN pettycashoperation PCO 
		ON PCOP.idpettycash=PCO.idpettycash 
		AND PCOP.yoperation = PCO.yoperation 
		AND PCO.noperation=PCOP.noperation
	JOIN #invoicedebitamount ON PCOP.idinvkind=#invoicedebitamount.idinvkind 
		AND PCOP.yinv=#invoicedebitamount.yinv 
		AND PCOP.ninv=#invoicedebitamount.ninv
	WHERE   PCO.adate between @start and @stop and isnull(#invoicedebitamount.kind,0) = 1
	group by 	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv,#invoicedebitamount.idreg


INSERT INTO #invoicedebitamount
(idinvkind,		yinv,		ninv,		
		curr_amount, pettycash_amount, profservice_amount,idreg
)
SELECT 
	#invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, 
	0, 0, sum(ET.curramount) , #invoicedebitamount.idreg 
FROM expenseprofservice EP
JOIN profservice 
	ON profservice.ycon =EP.ycon and profservice.ncon=EP.ncon 
JOIN #invoicedebitamount 
	ON profservice.idinvkind=#invoicedebitamount.idinvkind 
	AND profservice.yinv=#invoicedebitamount.yinv 
	AND profservice.ninv=#invoicedebitamount.ninv
JOIN expenselink EL on EL.idparent  = EP.idexp 
JOIN expenselast ELAST on ELAST.idexp= EL.idchild
JOIN expenseyear EY on elast.idexp=EY.idexp
JOIN expensetotal ET on EY.idexp=ET.idexp
JOIN payment P	ON	P.kpay = ELAST.kpay
JOIN paymenttransmission PT ON	P.kpaymenttransmission = PT.kpaymenttransmission
WHERE   PT.transmissiondate between @start and @stop and isnull(#invoicedebitamount.kind,0) = 1
and (select count(*) from invoicedetail  D 
	where  D.idinvkind=#invoicedebitamount.idinvkind 
	AND D.yinv=#invoicedebitamount.yinv 
	AND D.ninv=#invoicedebitamount.ninv
	AND D.ycon is not null) = 0--> i dettagli fattura non devono essere associati alla parcella. Sta prendendo le parcelle associate a fattura. Le fatture con l'associazione alla parcella nel dettalglio, le ha prese sopra.
GROUP BY #invoicedebitamount.idinvkind ,#invoicedebitamount.yinv, #invoicedebitamount.ninv, #invoicedebitamount.idreg


IF (
	  @kind = 'D'  -- Vista Dettagliata
    )
	SELECT 	 --  filtra  sugli attributi
	@start as 'Inizio Scadenza',
	@stop as 'Fine Scadenza',
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
		WHEN IC.kind = 1 and I.flagvariation = 'N' THEN I.total 
		WHEN IC.kind = 1 and I.flagvariation = 'S' THEN - I.total 
		ELSE 0 END) AS 'Tot. fattura',
	SUM(CASE WHEN IC.kind = 1 THEN IC.taxable_euro ELSE 0 END) AS 'Imponibile',
	SUM(CASE WHEN IC.kind = 1 THEN IC.iva_euro ELSE 0 END) AS 'IVA',
	CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N')  THEN  
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro_split_payment,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		WHEN (I.flagintracom <> 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
	END  AS 'Totale debito' 
	FROM invoiceview I 		
		JOIN #invoicedebitamount IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  	
	--where   IC.idreg = 12063
	group by I.invoicekind, I.idinvkind, I.yinv, I.ninv,I.ycon,I.ncon,I.doc,convert(varchar,I.docdate,105),I.cf,I.p_iva, I.registry,
	I.description,convert(varchar,I.adate,105), convert(varchar,I.protocoldate,105),convert(varchar,I.expiring,105),
	I.iduniqueregister, I.flag_enable_split_payment,  I.flagintracom
		having 	CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N')  THEN  
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro_split_payment,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		WHEN (I.flagintracom <> 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		END  <> 0
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
		SUM(CASE WHEN IC.kind = 1 THEN I.total ELSE 0 END)  ,
		SUM(CASE WHEN IC.kind = 1 THEN IC.taxable_euro ELSE 0 END)  ,
		SUM(CASE WHEN IC.kind = 1 THEN IC.iva_euro ELSE 0 END)  ,
		CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro_split_payment,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		WHEN (I.flagintracom <> 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		END 
	FROM invoiceview  I 		
		JOIN #invoicedebitamount IC ON IC.idinvkind = I.idinvkind	 AND	IC.yinv = I.yinv	 AND	IC.ninv = I.ninv  	
	group by I.idinvkind, I.yinv, I.ninv, I.flag_enable_split_payment, I.flagintracom
	having 	CASE
		WHEN (I.flag_enable_split_payment= 'S') AND (I.flagintracom <= 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro_split_payment,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		WHEN (I.flagintracom <> 'N') THEN  
			SUM(ISNULL(IC.taxable_euro,0)  - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
		ELSE 
			SUM(ISNULL(IC.taxable_euro,0)  + ISNULL(IC.iva_euro,0) - 
			(ISNULL(IC.curr_amount,0)  + 
			 ISNULL(IC.pettycash_amount,0)   + 
			 ISNULL(IC.profservice_amount,0) ) ) 
	END  <> 0
	)

	SELECT  --  filtra  sugli attributi
	@start as 'Inizio Scadenza',
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
		--where IC.idreg = 12063
	group by I.idreg, I.registry,I.cf ,I.p_iva, 
	I.flag_enable_split_payment  ,I.flagintracom
	order by I.registry, I.cf,I.p_iva	
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



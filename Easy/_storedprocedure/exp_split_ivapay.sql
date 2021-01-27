
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_split_ivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_split_ivapay]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--[exp_split_ivapay] '2017/01/01','2017/31/12',null, 'N'

CREATE  PROCEDURE [exp_split_ivapay]
	@datebegin datetime,
	@dateend datetime,
	@flagactivity int,
	@kind  char(1) -- A (Tutti), (N No Recupero), (R Reversali Trasmesse in Range differente) (M Mandati Trasmessi in Range differente)
AS BEGIN
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoice
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagintracom char(1),
		flagsplit char(1),
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		currivagrosspayed decimal(19,2),  
		currivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		idreg int,
		idivaregisterkind int,
		taxable decimal(19,2),
		idexp_taxable int,
		idexp_iva int,
		idinc_iva int,
		curramount decimal(19,2), 
		ymov_iva_split int,
		nmov_iva_split int,
		phase_taxable varchar(30),
		ymov_taxable int, 
		nmov_taxable int  ,
		phase_iva  varchar(30),
		ymov_iva   int,
		nmov_iva   int,
		kpay_taxable int,
		kpay_iva int, 
		kpro_iva int, 
		kpaymenttransmission_taxable int,
		kpaymenttransmission_iva int,
		ypay_taxable int,
		ypay_iva int,
		npay_taxable int,
		npay_iva int,
		ypro_iva int,
		npro_iva int,
		paymentadate_taxable datetime,
		paymentadate_iva datetime,
		ypaytransmission_taxable int,
		ypaytransmission_iva int,
		npaytransmission_taxable int,
		npaytransmission_iva int,
		transmissiondate_taxable  datetime,
	    transmissiondate_iva  datetime,
	    kproceedstransmission_iva_split int,
		yproceedstransmission_iva_split  int,
		nproceedstransmission_iva_split int,
		transmissiondate_iva_split	datetime,
		no_clawback char(1),
		doc varchar(35),
		docdate smalldatetime
	)
	
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita
	
	-- Sezione 1. Calcolo dell'IVA IMMEDIATA a Debito e a Credito
	-- Si prendono tutte le fatture con IVA immediata 
	-- 	la cui data di registrazione ricade nel range di date comunicato in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagintracom,flagsplit,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable,
		idexp_taxable, idexp_iva, doc,docdate 
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum,  'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --kind		--tipo fattura (A/V)
		I.flagintracom,I.flag_enable_split_payment,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --flagvariation
		ISNULL(IDET.tax,0) ,--cambiare segno
		ISNULL(IDET.unabatable,0)  , --cambiare segno		
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), --taxabletotal
		IDET.idexp_taxable, IDET.idexp_iva, I.doc,I.docdate
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN invoicekind IK
		ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	I.adate BETWEEN @datebegin AND @dateend
		AND I.flagdeferred = 'N'
		AND idinvkind_real is null
		AND IRK.registerclass<>'P'
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND ((IK.flag & 1)=0 --task 6664  --- acquisto 
			OR  --- vendita
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <> 0
		)

	)
	  
	-- Sezione 2.1 IVA Differita a DEBITO (fatt.vendita) - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  (incluse note di variazione)
	-- 	la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,
		idexp_taxable, idexp_iva , doc, docdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --kind	
		I.flagintracom,I.flag_enable_split_payment,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --flagvariation
		ISNULL(IDET.tax,0),					
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), --taxabletotal
		IDET.idexp_taxable, IDET.idexp_iva , I.doc, I.docdate
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_iva 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 		I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND PE1.competencydate BETWEEN @datebegin AND @dateend
		AND IRK.registerclass<>'P'
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'
	 
		AND ((IK.flag & 1)=0 --task 6664
			OR
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <>0
		)

	)

	-- Sezione 2.2 IVA Differita  - DATA MANDATO
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 
		kind,flagintracom,flagsplit,
		flagvariation,
		flagmixed,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable,
		idexp_taxable, idexp_iva , doc,docdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo		
		I.flagintracom,I.flag_enable_split_payment,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), --taxabletotal
		IDET.idexp_taxable, IDET.idexp_iva , I.doc, I.docdate
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1		ON PC1.idexp = IDET.idexp_iva 		
	JOIN invoicekind IK 		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind 		AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND PC1.competencydate BETWEEN @datebegin AND @dateend
		AND IRK.registerclass<>'P'		
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'		
		AND ((IK.flag & 1)=0 --task 6664
			OR
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <> 0
		)


	)

	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit, flagvariation,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable,
		idexp_taxable, idexp_iva , doc, docdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo	
		I.flagintracom,I.flag_enable_split_payment,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), --taxabletotal
		IDET.idexp_taxable, IDET.idexp_iva , I.doc, I.docdate
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S'
		AND IDET.paymentcompetency BETWEEN @datebegin AND @dateend		
		AND IRK.registerclass<>'P'		
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'
		AND ((IK.flag & 1)=0 --task 6664
			OR
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <>0
		)

	)
	
	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,flagsplit, flagvariation,
		flagmixed,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable,
		idexp_taxable, idexp_iva , doc, docdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv, IDET.rownum, 'S', 		
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo		
		I.flagintracom,I.flag_enable_split_payment,
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ISNULL(IDET.tax,0) ,
		ISNULL(IDET.unabatable,0),
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), --taxabletotal
		IDET.idexp_taxable, IDET.idexp_iva , I.doc, I.docdate
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind 		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND IRK.registerclass<>'P'
		AND exists (SELECT * FROM pettycashoperationinvoice PCOI
					JOIN pettycashoperation PCO			ON PCO.idpettycash = PCOI.idpettycash	AND PCO.yoperation = PCOI.yoperation	AND PCO.noperation = PCOI.noperation 
					WHERE PCOI.idinvkind = I.idinvkind
							AND PCOI.yinv = I.yinv
							AND PCOI.ninv = I.ninv
							AND PCO.adate BETWEEN @datebegin AND @dateend)
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'
		AND ((IK.flag & 1)=0 --task 6664
			OR
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <> 0
		)

	)

/*
	-- cancella le righe su registro di vendita di fatture in acquisto che presentano la riga anche in acquisto ma non sono intracomunitarie	
	delete  from #invoice where 
		#invoice.registerclass='V' and
		#invoice.flagintracom='N' and
		exists (select * from #invoice I2 where
				I2.idinvkind=#invoice.idinvkind and
				I2.yinv=#invoice.yinv and
				I2.ninv=#invoice.ninv and
				I2.registerclass='A') 
*/
	
	--integra le fatture considerate con quelle collegate (e registri collegati)
	insert into #invoice(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagintracom,flagsplit,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable , doc, docdate
	)
	(
	   select 
		I.idinvkind,I.yinv,I.ninv, II.rownum, II.flagdeferred, II.flagmixed,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END, --Tipo
		II.flagintracom,II.flagsplit,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END,  -- flagvariation
		II.currivagrosspayed,II.currivaunabatable,II.idreg,
		IRK.idivaregisterkind,II.taxable , II.doc, II.docdate
	   from #invoice II
				join invoice I on I.idinvkind_real= II.idinvkind		and I.yinv_real= II.yinv	and I.ninv= II.ninv
				JOIN invoicekind IK		ON I.idinvkind = IK.idinvkind	
				JOIN ivaregister IR		ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
				JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind	
		AND ISNULL(I.flag_enable_split_payment,'N' ) = 'S'	
		AND ((IK.flag & 1)=0 --task 6664
			OR
			((IK.flag & 1)<>0) AND  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass = 'A'
				) <> 0
		)
	
	)

	
	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	update #invoice set kind = registerclass,
						currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass<>'P'
			) = 1

		--AND flagintracom = 'N'
	
	UPDATE #invoice set currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
    WHERE flagvariation='S'			--serve solo per le intrastat istituz. acquisti
	
	--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoice set kind = 'A',
						currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass = 'A'
				) <> 0
			and kind<>'A'

	UPDATE #invoice SET 
		kpay_taxable = expenselastview.kpay,
		ypay_taxable = expenselastview.ypay,
		npay_taxable = expenselastview.npay,
		paymentadate_taxable = paymentview.adate,
		phase_taxable = expenselastview.phase,
		ymov_taxable  = expenselastview.ymov,
		nmov_taxable  = expenselastview.nmov,
		kpaymenttransmission_taxable = paymentview.kpaymenttransmission,
		ypaytransmission_taxable = paymentview.ypaymenttransmission,
		npaytransmission_taxable = paymentview.npaymenttransmission,
		transmissiondate_taxable = paymentview.transmissiondate
	FROM expenselastview 
	JOIN paymentview ON expenselastview.kpay = paymentview.kpay
	WHERE expenselastview.idexp = idexp_taxable
	
	UPDATE #invoice SET 
		kpay_iva = expenselastview.kpay,
		ypay_iva = expenselastview.ypay,
		npay_iva = expenselastview.npay,
		paymentadate_iva = paymentview.adate,
		phase_iva = expenselastview.phase,
		ymov_iva  = expenselastview.ymov,
		nmov_iva  = expenselastview.nmov,
		kpaymenttransmission_iva = paymentview.kpaymenttransmission,
		ypaytransmission_iva = paymentview.ypaymenttransmission,
		npaytransmission_iva = paymentview.npaymenttransmission,
		transmissiondate_iva = paymentview.transmissiondate
	FROM expenselastview 
	JOIN paymentview ON expenselastview.kpay = paymentview.kpay
	WHERE expenselastview.idexp = idexp_iva AND isnull(#invoice.idexp_taxable,0) <> isnull(#invoice.idexp_iva,0)
 
 	UPDATE #invoice SET 
		idinc_iva        = incomelastview.idinc,
		curramount       = incomelastview.curramount,
		kpro_iva         = incomelastview.kpro,
		ypro_iva         = incomelastview.ypro,
		npro_iva         = incomelastview.npro,
		phase_iva		 = incomelastview.phase,
		ymov_iva_split   = incomelastview.ymov,
		nmov_iva_split   = incomelastview.nmov,
		kproceedstransmission_iva_split  = proceedstransmission.kproceedstransmission,
		yproceedstransmission_iva_split  = proceedstransmission.yproceedstransmission,
		nproceedstransmission_iva_split  = proceedstransmission.nproceedstransmission,
		transmissiondate_iva_split		 = proceedstransmission.transmissiondate
	FROM  incomelastview 
	LEFT OUTER JOIN proceeds ON incomelastview.kpro = proceeds.kpro
	LEFT OUTER JOIN proceedstransmission ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 
	JOIN  #invoice ON incomelastview.idpayment = #invoice.idexp_taxable
	WHERE incomelastview.autokind = 6 
	-- select * from #invoice where kproceedstransmission_iva_split is not null and idexp_taxable <> idexp_iva
	UPDATE #invoice SET 
		idinc_iva		= incomelastview.idinc,
		curramount		= incomelastview.curramount,
		kpro_iva		= incomelastview.kpro,
		ypro_iva		= incomelastview.ypro,
		npro_iva		= incomelastview.npro,
		phase_iva		= incomelastview.phase,
		ymov_iva_split  = incomelastview.ymov,
		nmov_iva_split  = incomelastview.nmov,
		kproceedstransmission_iva_split  = proceedstransmission.kproceedstransmission,
		yproceedstransmission_iva_split  = proceedstransmission.yproceedstransmission,
		nproceedstransmission_iva_split  = proceedstransmission.nproceedstransmission,
		transmissiondate_iva_split		 = proceedstransmission.transmissiondate
	FROM  incomelastview 
	LEFT OUTER JOIN proceeds
		ON incomelastview.kpro = proceeds.kpro
	LEFT OUTER JOIN proceedstransmission 
		ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 
	JOIN  #invoice ON incomelastview.idpayment = #invoice.idexp_iva
	WHERE incomelastview.autokind = 6 AND idinc_iva is null
	
	
	UPDATE #invoice set no_clawback = 'S' 
	FROM #invoice 
	WHERE EXISTS 
	(
		SELECT I.idinvkind, I.yinv, I.ninv, I.idexp_taxable, I.idinc_iva, 
		SUM(I.currivagrosspayed),SUM(I.curramount) FROM #invoice  I
		WHERE I.idexp_taxable IS NOT NULL AND I.idexp_iva IS NULL AND I.idinc_iva IS NOT NULL 
			AND #invoice.idinvkind = I.idinvkind  
			AND #invoice.yinv = I.yinv  
			AND #invoice.ninv = I.ninv  
			AND #invoice.idexp_taxable = I.idexp_taxable
			AND #invoice.idinc_iva = I.idinc_iva
		GROUP BY I.idinvkind, I.yinv, I.ninv, I.idexp_taxable, I.idinc_iva
		HAVING ISNULL(SUM(I.currivagrosspayed),0) <> ISNULL(SUM(I.curramount),0) 
	)
 
	UPDATE #invoice set no_clawback = 'S' 
	FROM #invoice  
	WHERE EXISTS
	(
		SELECT I.idinvkind, I.yinv, I.ninv, I.idexp_iva, I.idinc_iva, 
		SUM(I.currivagrosspayed),SUM(I.curramount) FROM #invoice  I
		WHERE I.idexp_iva IS NOT NULL  AND I.idinc_iva IS NOT NULL 
			AND #invoice.idinvkind = I.idinvkind  
			AND #invoice.yinv = I.yinv  
			AND #invoice.ninv = I.ninv  
			AND #invoice.idexp_iva = I.idexp_iva
			AND #invoice.idinc_iva = I.idinc_iva
		GROUP BY I.idinvkind, I.yinv, I.ninv, I.idexp_iva, I.idinc_iva
		HAVING ISNULL(SUM(I.currivagrosspayed),0) <> ISNULL(SUM(I.curramount),0) 
	)
	
--	SELECT * FROM #invoice WHERE no_clawback = 'S'  OR idinc_iva IS NULL
	--SELECT idinvkind, yinv, ninv, idexp_taxable, idinc_iva, 
	--SUM(currivagrosspayed),SUM(curramount) FROM #invoice 
	--WHERE idexp_taxable IS NOT NULL AND idexp_iva IS NULL AND idinc_iva IS NOT NULL 
	--GROUP BY idinvkind, yinv, ninv, idexp_taxable, idinc_iva
	--HAVING ISNULL(SUM(currivagrosspayed),0) <> ISNULL(SUM(curramount),0) 
	
	--SELECT idinvkind, yinv, ninv, idexp_taxable, idinc_iva, 
	--SUM(currivagrosspayed),SUM(curramount) FROM #invoice 
	--WHERE idexp_iva IS NOT NULL AND idinc_iva IS NOT NULL 
	--GROUP BY idinvkind, yinv, ninv, idexp_taxable, idinc_iva
	--HAVING ISNULL(SUM(currivagrosspayed),0) <> ISNULL(SUM(curramount),0) 
 
	--select * from #invoice where kproceedstransmission_iva_split is not null and idexp_taxable <> idexp_iva
	--select 11, * from #invoice  where ninv = 28
	-- La select inale visualizza tutte le fatture che hanno IVA lorda diversa da zero
	-- oppure IVA netta diversa da zero ma immediata.	
	SELECT ivaregisterkind.description as 'Tipo Registro',
		   CASE ivaregisterkind.flagactivity
				WHEN 1 THEN 'Istituzionale'
				WHEN 2 THEN 'Commerciale'
				WHEN 1 THEN 'Promiscua'
				WHEN 1 THEN 'Altro'
		   END as 'Tipo attività',
		   ivaregisterkind.registerclass as 'Classe registro',
		   invoicekind.description  + ' n°' + CONVERT(varchar(10), #invoice.ninv) +'/' + CONVERT( varchar(4),#invoice.yinv)  as 'Fattura',
		   #invoice.doc as 'Doc.',
		   #invoice.docdate as 'Data Doc.',
		   CASE #invoice.flagintracom
				WHEN 'S' THEN 'Intra - UE'
				WHEN 'N' THEN 'Italia'
				WHEN 'X' THEN 'Extra - UE'
		   END as 'Resid. Fornitore' ,
		   #invoice.flagsplit as 'Soggetta a Split' ,
		   #invoice.flagdeferred as 'Differita',#invoice.flagvariation as 'Nota di Credito',
		   #invoice.taxable as 'Imponibile', #invoice.currivagrosspayed as 'IVA', #invoice.currivaunabatable as 'Iva indetraibile',  
		   registry.title as 'Fornitore', registry.cf as 'CF', registry.p_iva as 'P.IVA',registry.birthdate as 'Nato il',
		   phase_taxable + ' ' + CONVERT(varchar(4),ymov_taxable) + '/' + CONVERT(varchar(10),nmov_taxable)  as 'Contabilizzazione', 
		   ypay_taxable as 'Eserc. Mandato',
		   npay_taxable as 'Num. Mandato',
		   paymentadate_taxable as  'Emesso il ', 
		   ypaytransmission_taxable as 'Elenco Trasm. Eserc.',
		   npaytransmission_taxable as 'Elenco Trasm. n°', 
		   transmissiondate_taxable as 'Trasmissione del ',
		   phase_iva  + ' ' + CONVERT(varchar(4),ymov_iva) + '/' + CONVERT(varchar(10),nmov_iva)  as 'Contabilizzazione IVA', 
		   ypay_iva as 'Eserc. Mandato',
		   npay_iva as 'Num. Mandato',
		   paymentadate_iva as  'Emesso il ', 
		   ypaytransmission_iva as 'Elenco Trasm. Eserc.',
		   npaytransmission_iva as 'Elenco Trasm. n°', 
		   transmissiondate_iva as 'Trasmissione del',
		   curramount as 'Importo Iva Split Payment',
	       phase_iva  as 'Fase',
		   ymov_iva_split as 'Esercizio Mov. Split',
		   nmov_iva_split as 'Numero Mov. Split' ,
		   ypro_iva   as 'Eserc. Reversale Split',
		   npro_iva   as 'Num. Reversale Split',
		   yproceedstransmission_iva_split as 'Elenco Trasm. Split Eserc.',
		   nproceedstransmission_iva_split as 'Elenco Trasm. N° Split', 
		   transmissiondate_iva_split as 'Trasmissione Split del'
	 FROM #invoice
		JOIN invoicekind
			ON invoicekind.idinvkind = #invoice.idinvkind
		JOIN ivaregisterkind
			ON ivaregisterkind.idivaregisterkind = #invoice.idivaregisterkind
		JOIN registry
			ON registry.idreg = #invoice.idreg
	WHERE currivagrosspayed <> 0 AND kind = 'A' 
	AND (ivaregisterkind.flagactivity = @flagactivity OR @flagactivity IS NULL)
	-- @kind  char(1) -- A (Tutti), (N No Recupero), (R Reversali Trasmesse in Range differente) (M Mandati Trasmessi in Range differente)
	AND (((ISNULL(no_clawback,'N') = 'S' OR (idinc_iva IS NULL)) AND @kind = 'N') 
	OR ((transmissiondate_taxable IS NOT NULL AND transmissiondate_iva IS NULL) AND (transmissiondate_iva_split IS NOT NULL) AND 
	     (transmissiondate_taxable BETWEEN @datebegin AND @dateend) AND 
	     NOT(transmissiondate_iva_split  BETWEEN @datebegin AND @dateend) AND @kind = 'R') 
	OR ((transmissiondate_iva IS NOT NULL) AND (transmissiondate_iva_split IS NOT NULL) AND 
	     (transmissiondate_iva BETWEEN @datebegin AND @dateend) AND 
	     NOT(transmissiondate_iva_split  BETWEEN @datebegin AND @dateend) AND @kind = 'R') 
	OR ((transmissiondate_taxable IS NOT NULL  AND transmissiondate_iva IS NULL) AND (transmissiondate_iva_split) IS NOT NULL AND 
		 NOT(transmissiondate_taxable  BETWEEN @datebegin AND @dateend) AND 
		 (transmissiondate_iva_split  BETWEEN @datebegin AND @dateend)  AND @kind = 'M') 
	OR ((transmissiondate_iva IS NOT NULL) AND (transmissiondate_iva_split) IS NOT NULL AND 
		 NOT(transmissiondate_iva BETWEEN @datebegin AND @dateend) AND 
		 (transmissiondate_iva_split  BETWEEN @datebegin AND @dateend)  AND @kind = 'M') 
	OR (@kind = 'A'))
	ORDER BY #invoice.idinvkind,yinv,ninv,rownum,flagdeferred
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




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


--setuser 'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva_riep_ivakind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_liquidazioneiva_riep_ivakind]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
--exec [rpt_liquidazioneiva_riep_ivakind] 2016, 17
--go
--select * from invoicedetaildeferred where yivapay = 2016 and nivapay = 17
--exec rpt_liquidazioneiva 2016,17, 'S'
--go
--exec rpt_liquidazioneiva_riep_ivakind 2016,17
CREATE PROCEDURE [rpt_liquidazioneiva_riep_ivakind]
	@ayear int,
	@number int 
AS 
BEGIN

DECLARE @datebegin datetime
DECLARE @dateend   datetime
SELECT  @datebegin = start,
	    @dateend = stop 
FROM	ivapay
WHERE	yivapay = @ayear
AND		nivapay = @number
	
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione iva
	CREATE TABLE #invoicedet
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		taxabletotal decimal(19,2),
		ivagross decimal(19,2),
		ivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		ivaabatable decimal(19,2),   -- calcolato qui
		idivaregisterkind int, 
		idivakind int,
		idivataxablekind int,
		flagintracom char(1),
		flag_enable_split_payment char(1)		
	)
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita


	-- Sezione 1.  Calcolo dell'IVA IMMEDIATA a Debito e a Credito
	--    Si prendono tutte le fatture con IVA immediata 
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,idivaregisterkind,idivataxablekind,
		flagintracom,adate,flag_enable_split_payment
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum,
		case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 		--tipo fattura (A/V)
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, 	
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0), 
		ISNULL(IDET.unabatable,0)  , --cambiare segno				
		IDET.idivakind,IRK.idivaregisterkind,IVK.idivataxablekind,
		I.flagintracom,I.adate,I.flag_enable_split_payment
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
	JOIN ivakind IVK
		ON IVK.idivakind = IDET.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN invoicedetaildeferred IDF 
		ON IDF.idinvkind = IDET.idinvkind and
			IDF.yinv = IDET.yinv and
			IDF.ninv = IDET.ninv and
			IDF.rownum = IDET.rownum 
	WHERE
	    I.flagdeferred = 'N'
		AND I.idinvkind_real is null
		AND IRK.registerclass<>'P'
		AND I.adate BETWEEN @datebegin AND @dateend   -- leggere le date del periodo di riferimento
		AND ISNULL(IDET.rounding,'N') <>'S'			  -- salta i dettagli di arrotondamento 
		AND (isnull(IDET.flagbit,0) & 4) = 0
		AND IDF.yivapay = @ayear AND IDF.nivapay = @number
	)

	-- Sezione 2.1 IVA Differita a DEBITO (fatt.vendita) - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  (incluse note di variazione)
	-- la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	-- aventi data competenza del dettaglio NULL
	
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,idivataxablekind,
		adate,flagintracom,flag_enable_split_payment
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),				
		IRK.idivaregisterkind,IDET.idivakind,IVK.idivataxablekind,
		PE1.competencydate,
		I.flagintracom, I.flag_enable_split_payment
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_iva  
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivakind IVK
		ON IVK.idivakind = IDET.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN invoicedetaildeferred IDF 
		ON IDF.idinvkind = IDET.idinvkind and
			IDF.yinv = IDET.yinv and
			IDF.ninv = IDET.ninv and
			IDF.rownum = IDET.rownum 
	WHERE 
		I.flagdeferred = 'S'
		AND IRK.registerclass<>'P'
		AND IDET.paymentcompetency IS NULL
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento 
		AND (isnull(IDET.flagbit,0) & 4) = 0
		AND PE1.competencydate BETWEEN @datebegin AND @dateend   --- leggere le date del periodo di riferimento della liquidazione iva
		AND IDF.yivapay = @ayear AND IDF.nivapay = @number
	)

 
	-- Sezione 2.2 IVA Differita  - DATA MANDATO
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date  
	

	-- Sezione 2.2 IVA Differita  - DATA MANDATO
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind,idivakind,idivataxablekind,
		adate,flag_enable_split_payment
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),	 				
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IDET.idivakind,IVK.idivataxablekind,
		PC1.competencydate,I.flag_enable_split_payment
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_iva  
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind 
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivakind IVK
		ON IVK.idivakind = IDET.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN invoicedetaildeferred IDF 
		ON IDF.idinvkind = IDET.idinvkind and
			IDF.yinv = IDET.yinv and
			IDF.ninv = IDET.ninv and
			IDF.rownum = IDET.rownum 
	WHERE 
		I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND IRK.registerclass<>'P'	
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento
		AND (isnull(IDET.flagbit,0) & 4) = 0
		AND IDF.yivapay = @ayear AND IDF.nivapay = @number
	)

	
	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP

	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind,idivakind,idivataxablekind,
		adate,flag_enable_split_payment
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,
		case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, 
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		 IRK.idivaregisterkind,IDET.idivakind,IVK.idivataxablekind,
		 IDET.paymentcompetency,I.flag_enable_split_payment
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivakind IVK
		ON IVK.idivakind = IDET.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN invoicedetaildeferred IDF 
		ON IDF.idinvkind = IDET.idinvkind and
			IDF.yinv = IDET.yinv and
			IDF.ninv = IDET.ninv and
			IDF.rownum = IDET.rownum 
	WHERE  
		I.flagdeferred = 'S'
		AND IDET.paymentcompetency BETWEEN @datebegin AND @dateend		
		AND IRK.registerclass<>'P'		
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
		AND IDF.yivapay = @ayear AND IDF.nivapay = @number
	)


 
	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,flagvariation,	flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind,idivakind,idivataxablekind,
		adate,flag_enable_split_payment
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv, IDET.rownum,
		case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura è soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 	
		ISNULL(IDET.tax,0) ,
		ISNULL(IDET.unabatable,0),
		IRK.idivaregisterkind,IDET.idivakind,IVK.idivataxablekind,
		NULL,	--PCO.adate ---> La data non la usa mai!
		I.flag_enable_split_payment
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind 
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivakind IVK
		ON IVK.idivakind = IDET.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN invoicedetaildeferred IDF 
		ON IDF.idinvkind = IDET.idinvkind and
			IDF.yinv = IDET.yinv and
			IDF.ninv = IDET.ninv and
			IDF.rownum = IDET.rownum 
	WHERE 	I.flagdeferred = 'S'
 		AND IDET.paymentcompetency IS NULL
		AND EXISTS (SELECT * FROM pettycashoperationinvoice PCOI
				JOIN pettycashoperation PCO
							ON PCO.idpettycash = PCOI.idpettycash
							AND PCO.yoperation = PCOI.yoperation
							AND PCO.noperation = PCOI.noperation 
				WHERE PCOI.idinvkind = I.idinvkind
						AND PCOI.yinv = I.yinv
						AND PCOI.ninv = I.ninv
						AND PCO.adate BETWEEN @datebegin AND @dateend)	
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento
		AND (isnull(IDET.flagbit,0) & 4) = 0
		AND IDF.yivapay = @ayear AND IDF.nivapay = @number
	)


--12)
-- Integra le fatture considerate con le autofatture senza dettagli ad esse associate:

	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind,idivakind,idivataxablekind,
		adate,flag_enable_split_payment
	)
	(SELECT 
		I.idinvkind,I.yinv,I.ninv, M.rownum, M.flagdeferred, M.flagmixed,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0
			 THEN 'A'   
			 ELSE 'V'	
		END, --Tipo
		M.flagintracom, 
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END,  -- flagvariation
		M.taxabletotal, M.ivagross, M.ivaunabatable,
		IRK.idivaregisterkind, M.idivakind, IVK.idivataxablekind,
		M.adate, I.flag_enable_split_payment
	FROM #invoicedet M
	join invoice I on I.idinvkind_real= M.idinvkind
		and I.yinv_real= M.yinv
		and I.ninv= M.ninv
	JOIN invoicekind IK
		ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivakind IVK
		ON IVK.idivakind = M.idivakind
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind				
	)
	
	DECLARE @proratarate decimal(19,6)
	SELECT @proratarate = prorata 	FROM iva_prorata WHERE ayear = @ayear
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed FROM iva_mixed WHERE ayear = @ayear
	set @mixedrate= isnull(@mixedrate,1)
	

	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @ayear

	--Per chi scegli di applicare il calcolo sul totale, anche il promiscuo sarà applicato sul totale.
	if (@flagivapaybyrow='N') 
	Begin
		SET @proratarate=1 --non applica il prorata in questo caso
		SET @mixedrate = 1
	End

	update #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate*@mixedrate )
		where registerclass='A' and flagmixed='S'

	update #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate )
		where registerclass='A' and flagmixed='N'


	update #invoicedet set ivaabatable= ivagross	
		where registerclass='V'


	UPDATE #invoicedet SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)

	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	
	update #invoicedet set kind= registerclass, taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
			) = 1
		
	update #invoicedet set taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where flagvariation='S'

	--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoicedet set kind = 'A',
				taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'



	

-- Tabella finale, dove sono presenti i vari tipi IVA con gli importi calcolati
	CREATE TABLE #ivakind
	(	
		idivakind					int,
		kind						char(1),
		taxabletotal_period			decimal(19,2),
		nottaxabletotal_period		decimal(19,2),
		ivatotal_period				decimal(19,2),
		ivaunabatable_period		decimal(19,2),
		ivaabatable_period			decimal(19,2),
		taxabletotal_dif			decimal(19,2),
		nottaxabletotal_dif			decimal(19,2),
		ivatotal_dif				decimal(19,2),
		ivaunabatable_dif			decimal(19,2),
		ivaabatable_dif				decimal(19,2),
		taxabletotal_totdif			decimal(19,2),
		nottaxabletotal_totdif		decimal(19,2),
		ivatotal_totdif				decimal(19,2),
		ivaunabatable_totdif		decimal(19,2),
		ivaabatable_totdif			decimal(19,2),
		flag_enable_split_payment	char(1)
	)


	INSERT INTO #ivakind
	(
		idivakind,kind,
		taxabletotal_period,
		nottaxabletotal_period,
		ivatotal_period,
		ivaunabatable_period,
		ivaabatable_period,
		flag_enable_split_payment		
	)
	SELECT idivakind,kind,
		SUM(
			CASE
				WHEN idivataxablekind = 1 THEN taxabletotal ELSE 0
			END
		),
		SUM(
			CASE
				WHEN idivataxablekind <> 1 THEN taxabletotal ELSE 0
			END
		),
		SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable),flag_enable_split_payment
	FROM #invoicedet WHERE flagdeferred = 'N' 
	GROUP BY idivakind,kind,flag_enable_split_payment

	
	INSERT INTO #ivakind
	(
		idivakind,kind,
		taxabletotal_dif,
		nottaxabletotal_dif,
		ivatotal_dif,
		ivaunabatable_dif,
		ivaabatable_dif,
		flag_enable_split_payment	
	)
	SELECT idivakind,kind,
		SUM(
			CASE
				WHEN idivataxablekind = 1 THEN taxabletotal ELSE 0
			END
		),
		SUM(
			CASE
				WHEN idivataxablekind <> 1 THEN taxabletotal ELSE 0
			END
		),
		SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable),flag_enable_split_payment
	FROM #invoicedet WHERE flagdeferred = 'S' 
	GROUP BY idivakind,kind, flag_enable_split_payment


	 

IF ((select count(*) from #ivakind)=0)
 
BEGIN
    SELECT
		null  AS idivakind, 
		null  AS ivakinddescr,
		0     AS rate,
		null  AS flag_enable_split_payment,
		null  AS kind,
 		0     AS taxabletotal, 
		0     AS nottaxabletotal, 
		0     AS ivaunabatable, 
		0     AS ivaabatable,
		0     AS ivatotal
 
END
ELSE
BEGIN
SELECT

	ivakind.codeivakind as idivakind, 
	ivakind.description AS ivakinddescr,
	ivakind.rate,
	#ivakind.flag_enable_split_payment,
	#ivakind.kind AS kind,
 
    -- Imponibile (dei documenti immediati)        >>>>>>
    -- Imponibile (dei documenti differiti)        <<<<<<<<<
 	SUM(ISNULL(taxabletotal_period,0)) + 	SUM(ISNULL(taxabletotal_dif,0))   AS taxabletotal, 

    -- Imponibile (dei documenti immediati)        >>>>>>
    -- Imponibile (dei documenti differiti)        <<<<<<<<<
    SUM(ISNULL(nottaxabletotal_period,0)) +	SUM(ISNULL(nottaxabletotal_dif,0))  AS nottaxabletotal, 

	-- IVA Indetraibile (dei documenti immediati)
	-- IVA Indetraibile (dei documenti differiti divenuti immediati)
	-- IVA Indetraibile (dei documenti differiti)
	SUM(ISNULL(ivaunabatable_period,0)) + 	SUM(ISNULL(ivaunabatable_dif,0))    AS ivaunabatable, 

	-- IVA Detraibile (dei documenti immediati)
	-- IVA Detraibile (dei documenti differiti)
	SUM(ISNULL(ivaabatable_period,0)) +  	SUM(ISNULL(ivaabatable_dif,0))   AS ivaabatable,

	-- Somma di Iva Detraibile + Iva indetraibile 
	-- (dei documenti immediati)
	-- (dei documenti differiti)
	SUM(ISNULL(ivaunabatable_period,0)) + 	SUM(ISNULL(ivaunabatable_dif,0)) +  
		SUM(ISNULL(ivaabatable_period,0)) +  	SUM(ISNULL(ivaabatable_dif,0))   AS ivatotal
 
	FROM #ivakind
	JOIN ivakind
		ON ivakind.idivakind = #ivakind.idivakind
	GROUP BY  #ivakind.kind, ivakind.codeivakind,ivakind.description,ivakind.rate ,
		#ivakind.flag_enable_split_payment
	ORDER BY #ivakind.kind, ivakind.codeivakind
END


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

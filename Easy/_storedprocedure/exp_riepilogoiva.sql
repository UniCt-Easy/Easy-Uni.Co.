
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogoiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogoiva]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amm'

CREATE PROCEDURE [exp_riepilogoiva]
	@idivaregisterkind int,
	@codeinvkind varchar(20),
	@year int,
	@startmonth int,
	@stopmonth int,
    @unified  char(1),
    @codeivaregisterkind  varchar(20)      
AS  BEGIN

	CREATE TABLE #ivaregisterkind (
	idivaregisterkind int,
	flagactivity int,
	registerclass char(1),
	description varchar(50)
	)
	
	if( @idivaregisterkind is null and @codeivaregisterkind is null)	--> Vuol dire che non si è specificato il Registro, e si desidera vederli tutti.
	Begin
			insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description)
			select idivaregisterkind, flagactivity, registerclass,description from ivaregisterkind
	End
	Else
	Begin
			IF (@unified ='S')  --Aggiunta Unified
			Begin
				--se uno non usa i codici di consolidamento, allora deve prendere quello con pari codice
				-- se uno usa i codici, deve prendere TUTTI quelli aventi pari codice  (attualmente ne prende uno solo)
				insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description)
					select idivaregisterkind, flagactivity, registerclass,description from ivaregisterkind
							where idivaregisterkindunified=@idivaregisterkind OR 
									(idivaregisterkindunified is null and codeivaregisterkind = @codeivaregisterkind)
			End
			ELSE
			BEGIN
				insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description)
					select idivaregisterkind, flagactivity, registerclass,description from ivaregisterkind
							where idivaregisterkind=@idivaregisterkind 
			END
	End
	
	IF @startmonth IS NULL OR @startmonth < 1
	BEGIN
		SET @startmonth = 1
	END
	IF @startmonth > 12
	BEGIN
		SET @startmonth = 12
	END

	IF @stopmonth IS NULL OR @stopmonth < 1
	BEGIN
		SET @stopmonth = 1
	END
	IF @stopmonth > 12
	BEGIN
		SET @stopmonth = 12
	END

	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(
		label varchar(50),
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		competencydate datetime, 
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
		registername varchar(50),
		idivakind int,
		ivakind varchar(50),
		flagintracom char(1),
		reverse_charge char(1),
		doc varchar(35),
		docdate smalldatetime,	
		registry varchar(100),
		description varchar(150),
		va3type char(1),
		intrastatoperationkind  char(1),  -- codice operazione intrastat
		idintrastatservice int,
		idintrastatpaymethod int, -- dalla fattura
		idintrastatsupplymethod int,
		iso_payment char(2),
		idintrastatkind int,
		idintrastatmeasure int,
		idintrastatcode int,
		iso_destination char(2),
		iso_origin char(2),
		iso_provenance char(2),
		idcountry_destination int,
		idcountry_origin int,
		idintra12operationkind int,
		exception12 char(1),
		intra12operationkind char(1),
		move12 char(1),
		idaccmotive varchar(36),
		idaccmotivedett varchar(36),
		flag_enable_split_payment char(1),
		idsdi_acquisto int,ipa_acq varchar(6),
		idsdi_vendita int, ipa_ven_cliente varchar(6),
		idsor01 int
	)
	
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita

	INSERT INTO #invoicedet
	(
		idinvkind, invoicekind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,ivakind, idivaregisterkind, registername,	flagintracom,reverse_charge,
		adate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		I.idinvkind,IK.description, I.yinv,I.ninv, IDET.rownum, I.flagdeferred,
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
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0), 
		ISNULL(IDET.unabatable,0)  , --cambiare segno				
		IDET.idivakind, ivakind.description, IRK.idivaregisterkind,IRK.description,
		I.flagintracom,
		'N', 
		I.adate,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatcode,
		IDET.idintrastatmeasure,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01
	FROM invoice I
	JOIN invoicedetail IDET
		 ON IDET.idinvkind=I.idinvkind
		 AND IDET.yinv=I.yinv
		 AND IDET.ninv=I.ninv
	JOIN invoicekind IK
		 ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR
		 ON IR.idinvkind = I.idinvkind
		 AND IR.yinv = I.yinv
		 AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		 ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE 	
		 YEAR(I.adate) = @year 
		 AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		 and (isnull(IDET.flagbit,0) & 4) = 0
		 AND MONTH(I.adate) BETWEEN @startmonth AND @stopmonth
		 AND (IRK.idivaregisterkind = @idivaregisterkind or @idivaregisterkind is null)
		 AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- chiamiamo 'T' le fatture differite, a prescindere da quando vengono pagate
	UPDATE #invoicedet set flagdeferred='T' where flagdeferred='S' 
	UPDATE #invoicedet set label = 'Immediata' where flagdeferred='N'

	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	-- e aventi data competenza del dettaglio NULL
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind, registername, idivakind,ivakind, adate,competencydate,flagintracom,reverse_charge,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment, idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		
		null, I.idinvkind,IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
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
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),				
		IRK.idivaregisterkind, IRK.description, IDET.idivakind,ivakind.description, 
		I.adate,
		PE1.competencydate,
		I.flagintracom,
		'N', 
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
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
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE 
		I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND(  IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
	    AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	-- e aventi data competenza del dettaglio NULL
	-- Stessa insert di prima, ma per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,registername, idivakind,ivakind, adate, competencydate,flagintracom,reverse_charge,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null,I.idinvkind,IK.description,I.yinv, I.ninv,IDET.rownum, 'S', 
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
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),					
		IRK.idivaregisterkind,IRK.description,IDET.idivakind,ivakind.description, 
		I.adate,
		PE1.competencydate,
		I.flagintracom,
		'N', 
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_taxable 
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE 
		I.flagintracom='S' 
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND ( IRK.idivaregisterkind = @idivaregisterkind   or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)


	-- variazioni su entrata
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,registername, idivakind,ivakind,
		adate,competencydate,flagintracom,reverse_charge,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description , I.yinv, I.ninv,IDET.rownum, 'S', 
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
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),	 			
		IRK.idivaregisterkind, IRK.description,IDET.idivakind, ivakind.description, 
		I.adate,
		PE1.competencydate,
		I.flagintracom,
		'N',
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_iva  
	join incomevar VARMOV on
		VARMOV.idinc=PE1.idinc 
		AND VARMOV.idinvkind = I.idinvkind
		AND VARMOV.yinv  = I.yinv
		AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- variazioni su entrata
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,registername, idivakind,ivakind, adate, competencydate, flagintracom,reverse_charge,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
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
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),				
		IRK.idivaregisterkind, IRK.description, IDET.idivakind, ivakind.description, 
		I.adate,
		PE1.competencydate,
		I.flagintracom,
		'N',
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_taxable 
	join incomevar VARMOV on
		VARMOV.idinc=PE1.idinc 
		AND VARMOV.idinvkind = I.idinvkind
		AND VARMOV.yinv  = I.yinv
		AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE I.flagintracom='S' 
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND ( IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, reverse_charge,flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername, idivakind,ivakind, adate,competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),	 				
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind, IRK.description, IDET.idivakind, ivakind.description, 
		I.adate, PC1.competencydate,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente,I.idsor01 
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
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND ( IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom,reverse_charge, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername,idivakind,ivakind, adate,competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),	 				
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IRK.description, IDET.idivakind, ivakind.description, 
		I.adate, PC1.competencydate,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_taxable  
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind 
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE I.flagintracom='S' 
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND ( IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)


	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture non intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, reverse_charge, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername, idivakind,ivakind, adate, competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		'S',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),				
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IRK.description, IDET.idivakind,ivakind.description, 
		I.adate,
		PC1.competencydate,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_iva 
	join expensevar VARMOV on
		VARMOV.idexp=PC1.idexp 
		AND VARMOV.idinvkind = I.idinvkind
		AND VARMOV.yinv  = I.yinv
		AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind 
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND I.flagintracom='N'				
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND ( IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)


	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom,reverse_charge, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername, idivakind,ivakind, adate,competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		'S',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),					
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind, IRK.description,IDET.idivakind, ivakind.description, 
		I.adate,
		PC1.competencydate,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_taxable 
	join expensevar VARMOV on
		VARMOV.idexp=PC1.idexp 
		AND VARMOV.idinvkind = I.idinvkind
		AND VARMOV.yinv  = I.yinv
		AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK
		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind 
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE 
		I.flagintracom='S' 
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND I.flagintracom='N'				
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind,yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom, reverse_charge,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername, idivakind,ivakind, adate,competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null,
		I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 
		I.flagintracom,
		'N',
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, 
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind, IRK.description, IDET.idivakind, ivakind.description, 
		I.adate, IDET.paymentcompetency,
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
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
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE  
		I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND month(IDET.paymentcompetency)  BETWEEN @startmonth and 	@stopmonth
		AND Year(IDET.paymentcompetency) = @year -- BETWEEN @datebegin AND @dateend
		AND (IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,reverse_charge, flagvariation,	flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, registername, idivakind,ivakind, adate,competencydate,
		doc,docdate, registry, description,va3type,
		intrastatoperationkind,  -- codice operazione intrastat
		idintrastatservice,
		idintrastatpaymethod, -- dalla fattura
		idintrastatsupplymethod,
		iso_payment,
		idintrastatkind,
		idintrastatmeasure,
		idintrastatcode,
		iso_destination,
		iso_origin,
		iso_provenance,
		idcountry_destination,
		idcountry_origin,
		exception12,
		intra12operationkind,
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01
	)
	(SELECT
		null,
		I.idinvkind, IK.description, I.yinv, I.ninv, IDET.rownum, 'S', 		
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'N',
		'N',
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		ROUND(IDET.taxable * IDET.number * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 	
		ISNULL(IDET.tax,0) ,
		ISNULL(IDET.unabatable,0),
		IRK.idivaregisterkind, IRK.description,IDET.idivakind, ivakind.description, 
		I.adate, NULL,	--PCO.adate ---> La data non la usa mai!
		I.doc,I.docdate, registry.title, I.description,IDET.va3type,
		IDET.intrastatoperationkind,  -- codice operazione intrastat
		IDET.idintrastatservice,
		I.idintrastatpaymethod, -- dalla fattura
		IDET.idintrastatsupplymethod,
		I.iso_payment,
		I.idintrastatkind,
		IDET.idintrastatmeasure,
		IDET.idintrastatcode,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,
		I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, I.ipa_ven_cliente, I.idsor01 
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
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry 
		ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	WHERE 	I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND ( IRK.idivaregisterkind = @idivaregisterkind  or @idivaregisterkind is null)
		AND EXISTS (SELECT * FROM pettycashoperationinvoice PCOI
				JOIN pettycashoperation PCO
							ON PCO.idpettycash = PCOI.idpettycash
							AND PCO.yoperation = PCOI.yoperation
							AND PCO.noperation = PCOI.noperation 
				WHERE PCOI.idinvkind = I.idinvkind
						AND PCOI.yinv = I.yinv
						AND PCOI.ninv = I.ninv
						AND month(PCO.adate) BETWEEN @startmonth and 	@stopmonth
						and Year(PCO.adate) = @year -- BETWEEN @datebegin AND @dateend
				)
		 AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
	)

	DECLARE @monthname varchar(50)
	SELECT @monthname = title
	FROM monthname
	WHERE code = @startmonth
	IF (@startmonth <> @stopmonth)
	BEGIN
		SET @monthname = @monthname + ' - ' +
		(SELECT title FROM monthname WHERE code = @stopmonth)
	END

	DECLARE @proratarate decimal(19,6)
	SELECT  @proratarate = prorata 	FROM iva_prorata WHERE ayear = @year
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT  @mixedrate = mixed FROM iva_mixed WHERE ayear = @year
	set @mixedrate= isnull(@mixedrate,1)
	

	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @year

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


	UPDATE #invoicedet set reverse_charge = 'S'
	WHERE (#invoicedet.flagintracom =  'S' OR  #invoicedet.flagintracom =  'X')
	AND    #invoicedet.registerclass = 'V'
	AND EXISTS (SELECT * FROM ivaregister RA 
				JOIN ivaregisterkind RAK
					  ON  RAK.idivaregisterkind = RA.idivaregisterkind
					  AND RAK.registerclass = 'A'
					 WHERE
					 	RA.idinvkind = #invoicedet.idinvkind
						AND RA.yinv = #invoicedet.yinv
						AND RA.ninv = #invoicedet.ninv) 
	
	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation

	--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione, caso doppia registrazione
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
			and kind<>'A' 			AND taxabletotal > 0

	-- caso singola registrazione, su classe registro diversa da tipo contabilizzazione
	update #invoicedet set kind = registerclass,
					taxabletotal=-taxabletotal ,
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

update #invoicedet SET label = 'Acquisto anni prec. diven. detraibili'  WHERE flagdeferred = 'S' AND kind = 'A' and yinv < @year
update #invoicedet SET label = 'Vendita  anni prec. diven. esigibili'	WHERE flagdeferred = 'S' AND kind = 'V' and yinv < @year
update #invoicedet SET label = 'Acquisto anno corr. diven. detraibili'  WHERE flagdeferred = 'S' AND kind = 'A' and yinv = @year
update #invoicedet SET label = 'Vendita anno corr. diven. esigibili'	WHERE flagdeferred = 'S' AND kind = 'V' and yinv = @year

delete from #invoicedet WHERE flagdeferred = 'T'
and exists (select  * from #invoicedet I1 
			 where	#invoicedet.idinvkind = I1.idinvkind 
			 and    #invoicedet.yinv = I1.yinv 
			 and    #invoicedet.ninv = I1.ninv
			 and    I1.flagdeferred = 'S' )

update #invoicedet SET label = 'Acquisto anno corr. non ancora detraibili', flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'A' and yinv = @year
update #invoicedet SET label = 'Vendita  anno corr. non ancora esigibili' ,flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'V' and yinv = @year

DECLARE @departmentname varchar(500)
				
SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @year) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @year)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


SELECT 
		registername as 'Registro', 
		--@departmentname as 'Dipartimento', 
		sor01.description as 'Attributo1',
		label as 'Esigibilità/Detraibilità', 
		invoicekind as 'Tipo Fattura', 
		#invoicedet.yinv as 'Eserc. Fattura', 
		#invoicedet.ninv as 'Num. Fattura', 
		rownum as '# Dett', 
		adate as 'Data Registr.',
		accmotive.codemotive as 'Cod.Causale credito/debito', accmotive.title as 'Causale credito/debito',	account.codeacc as 'Cod.Conto credito/debito', account.title as 'Conto credito/debito',
		accmotiveDett.codemotive as 'Cod.Causale costo/ricavo', accmotiveDett.title as 'Causale costo/ricavo',accountDett.codeacc as 'Cod.Conto costo/ricavo', accountDett.title as 'Conto costo/ricavo',
		flagmixed as 'Promiscua',
		flagdeferred as 'IVA Differita', 
	    taxabletotal as 'Impon. Tot.', 
		ivagross as 'IVA Tot.',
		ivaunabatable as 'IVA Indetr.',
		ivaabatable as 'IVA Detr.',
	    ivakind as 'Tipo IVA',
		doc as 'Doc. colleg.',
		docdate as 'Data Doc.', 
		registry as 'Fornitore/Cliente', 
		#invoicedet.description  as 'Descrizione',
		CASE #invoicedet.flagintracom 
			WHEN 'S' THEN 'Intra-UE'
			WHEN 'N' THEN 'Italia'
			WHEN 'X' THEN 'Extra-UE' 
			END as 'Operazione UE',
		#invoicedet.reverse_charge as 'Reverse Charge', 
		CASE #invoicedet.intrastatoperationkind
			WHEN 'S' THEN 'Servizi'
			WHEN 'B' THEN 'Beni'
		END as 'Tipo oper. Intrastat',		
		S.description as 'Servizio',		
		CASE #invoicedet.intrastatoperationkind
			WHEN 'S' THEN P.description
			ELSE NULL 
		END as 'Modalità pagamento/incasso',		
		E.description as 'Modalità erogazione',		
		CASE #invoicedet.intrastatoperationkind
			WHEN 'S' THEN Pag.description 
		ELSE NULL 
		END as 'Paese pagam.',
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN 	K.description
			ELSE NULL 
		END as 'Nat. Transazione',	
		M.code as 'Un. misura suppl.',	
		C.code as 'Cod. Nomencl. combinata',	
		C.description as 'Nomencl. combinata',	
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN Dest.description 
			ELSE NULL 
		END as 'Paese. destin.',	
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN Orig.description
			ELSE NULL 
		END  as 'Paese. orig.',	
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN Prov.description 
			ELSE NULL 
		END as 'Paese. proven.',	
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN geo_country_destination.province 
			ELSE NULL 
		END as 'Prov. destin.', 
		CASE #invoicedet.intrastatoperationkind
			WHEN 'B' THEN geo_country_origin.province 
		ELSE NULL 
		END as 'Prov. orig.', 
		CASE 
			#invoicedet.intra12operationkind
			WHEN 'S' THEN 'Servizi'
			WHEN 'B' THEN 'Beni'
		END as 'INTRA12 - Tipo oper.',
		CASE 
			WHEN #invoicedet.intra12operationkind IS NOT NULL THEN #invoicedet.move12 
		ELSE NULL 
		END as 'INTRA12 - Fornitore non resid. UE',
		CASE 
			WHEN #invoicedet.intra12operationkind IS NOT NULL THEN #invoicedet.exception12 
			ELSE NULL 
		END as 'INTRA12 - art.7-Ter DPR. n.633/72',
		CASE  #invoicedet.va3type 
			WHEN 'S' THEN 'Beni Ammortizzabili'
			WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
			WHEN 'R' THEN 'Beni destinati alla rivendita'
			WHEN 'A' THEN 'Altri acquisti e importazioni'
			ELSE 'Non specificato'
		END as 'Tipologia VF24',
		flag_enable_split_payment as 'Split Payment',
		idsdi_acquisto as 'N.File(SdI Acquisto)' ,	ipa_acq as 'IPA acqisto',
		idsdi_vendita  as 'N.File(SdI Vendita)', ipa_ven_cliente as 'IPA cliente', 
		uniqueregister.iduniqueregister as 'N.Registro Unico'
FROM  #invoicedet
LEFT OUTER JOIN intrastatservice as S 
	ON S.idintrastatservice = #invoicedet.idintrastatservice
LEFT OUTER JOIN intrastatpaymethod as P 
	ON P.idintrastatpaymethod = #invoicedet.idintrastatpaymethod
LEFT OUTER JOIN intrastatsupplymethod E 
	ON E.idintrastatsupplymethod = #invoicedet.idintrastatsupplymethod
LEFT OUTER JOIN intrastatnation as Pag	
	ON #invoicedet.iso_payment = Pag.idintrastatnation
LEFT OUTER JOIN intrastatkind as K
	ON #invoicedet.idintrastatkind = K.idintrastatkind
LEFT OUTER JOIN intrastatmeasure as M
	ON #invoicedet.idintrastatmeasure= M.idintrastatmeasure
LEFT OUTER JOIN intrastatcode as C 
	ON C.idintrastatcode = #invoicedet.idintrastatcode
LEFT OUTER JOIN intrastatnation as Dest
	ON #invoicedet.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig	
	ON #invoicedet.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov
	ON #invoicedet.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination
	ON #invoicedet.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin
	ON #invoicedet.idcountry_origin = geo_country_origin.idcountry

LEFT OUTER JOIN accmotive  
	ON accmotive.idaccmotive = #invoicedet.idaccmotive
LEFT OUTER JOIN accmotivedetail
	on accmotive.idaccmotive = accmotivedetail.idaccmotive and accmotivedetail.ayear = #invoicedet.yinv
LEFT OUTER JOIN account  
	on account.idacc= accmotivedetail.idacc and account.ayear= accmotivedetail.ayear

LEFT OUTER JOIN accmotive accmotiveDett 
	ON accmotiveDett.idaccmotive = #invoicedet.idaccmotivedett
LEFT OUTER JOIN accmotivedetail accmotivedetailDett
	on accmotiveDett.idaccmotive = accmotivedetailDett.idaccmotive and accmotivedetailDett.ayear = #invoicedet.yinv
LEFT OUTER JOIN account accountDett
	on accountDett.idacc= accmotivedetailDett.idacc and accountDett.ayear= accmotivedetailDett.ayear
	
LEFT OUTER JOIN uniqueregister
	ON uniqueregister.idinvkind = #invoicedet.idinvkind
	AND uniqueregister.ninv = #invoicedet.ninv
	AND uniqueregister.yinv = #invoicedet.yinv	
LEFT OUTER JOIN sorting sor01
	on #invoicedet.idsor01 = sor01.idsor
ORDER BY invoicekind,  #invoicedet.yinv,  #invoicedet.ninv,  #invoicedet.adate, rownum

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogoiva_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogoiva_dett]
GO
--exp_riepilogoiva_dett null,null,2017,1,12,'N','N',4,'N','null','A'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
	-- setuser 'amministrazione'
 	-- exp_unified_riepilogoiva_dett null,null,2017,1,12,'S','N',2,'N','V'
	-- exp_unified_riepilogoiva_dett null,null,2017,1,12,'N','S',2,'N','V'
CREATE PROCEDURE [exp_riepilogoiva_dett]
	@idivaregisterkind int,
	@codeinvkind varchar(20),
	@year int,
	@startmonth int,
	@stopmonth int,
	@groupiva char(1),
	@groupinvkind char(1),
	@flagactivity smallint,
	@unified  char(1),
	@codeivaregisterkind  varchar(20) ,
	@av char(1)   

AS  BEGIN

	IF  @flagactivity = 4 SET @flagactivity = NULL 

	CREATE TABLE #ivaregisterkind (
		idivaregisterkind int,
		flagactivity int,
		registerclass char(1),
		description varchar(50),
		idivaregisterkindunified int
	)

	if( @idivaregisterkind is null and @codeivaregisterkind is null)	--> Vuol dire che non si è specificato il Registro, e si desidera vederli tutti.
	Begin
			insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified)
			select idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified from ivaregisterkind
	End
	Else
	Begin
			IF (@unified ='S')  --Aggiunta Unified
			Begin
				--se uno non usa i codici di consolidamento, allora deve prendere quello con pari codice
				-- se uno usa i codici, deve prendere TUTTI quelli aventi pari codice  (attualmente ne prende uno solo)

				insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified)
					select idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified from ivaregisterkind
							where 	idivaregisterkindunified=@idivaregisterkind OR 
										(idivaregisterkindunified is null and codeivaregisterkind = @codeivaregisterkind)
								
			End
			ELSE
			BEGIN
				insert into #ivaregisterkind (idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified)
					select idivaregisterkind, flagactivity, registerclass,description,idivaregisterkindunified from ivaregisterkind
							where idivaregisterkind=@idivaregisterkind 
			END
	END	
 
	--exec exp_riepilogoiva_dett 1, null, 2011, 1, 12, 'N','N',2,'N',null
	--exec [exp_unified_riepilogoiva_DETT] 1, null, 2011, 1, 12,'S' 

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
		flagactivity smallint,
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
		idsdi_acquisto int,ipa_acq varchar(7),
		idsdi_vendita int, ipa_ven_cliente varchar(7),
		idsor01 int,
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		idupb_iva varchar(36),
		codeupb_iva varchar(50),
		upb_iva varchar(150) 
		,kpaymenttransmission int              -- Modifiche task 10269
		,kproceedstransmission int             -- Modifiche task 10269
		,kpro int
		,cf	varchar(16)                        -- Modifiche task 10659
		,p_iva varchar(15)
		,foreigncf varchar(40)		
		
	)
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita


	INSERT INTO #invoicedet
	(
		idinvkind, invoicekind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,flagactivity,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,ivakind, idivaregisterkind, flagintracom,reverse_charge, adate,
		doc,docdate, registry, description, va3type,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01,
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, cf, p_iva, foreigncf       -- Modifiche per task 10659
	)
	(SELECT
		I.idinvkind,IK.description, I.yinv,I.ninv, IDET.rownum, I.flagdeferred,
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
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
		IDET.idivakind, ivakind.description, IRK.idivaregisterkind,
		I.flagintracom,
		'N',
		I.adate,
		I.doc,I.docdate, registry.title, I.description, IDET.va3type,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		,  registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659

	FROM invoice I
	JOIN invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind	 AND IDET.yinv=I.yinv	 AND IDET.ninv=I.ninv
	JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	 AND IR.yinv = I.yinv	 AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE 	
		 YEAR(I.adate) = @year 
		 and (	(@av = 'A' and  ---- incluse note in credito su acquisti in entrata
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				 ---- ecluse note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)

		 AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		 and (isnull(IDET.flagbit,0) & 4) = 0
		 AND MONTH(I.adate) BETWEEN @startmonth AND @stopmonth
		 AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		 AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
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
		registerclass,flagactivity, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,ivakind, adate,competencydate,flagintracom,reverse_charge,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01, 
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpro                   --Modifiche task 10269	
		, cf, p_iva, foreigncf   -- Modifiche  task 10659		
	)
	(SELECT
		
		null, I.idinvkind,IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
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
		IRK.idivaregisterkind,
		IDET.idivakind,ivakind.description, 
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
		IDET.idintrastatcode,
		IDET.idintrastatmeasure,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PE1.kpro                                          -- Modifiche task 10269
		,  registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	join invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_iva  
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE 
		I.flagintracom='N'
		and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	  ---- incluse note in credito su acquisti in entrata
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 ))  
				 ---- escluse note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
	    AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	-- e aventi data competenza del dettaglio NULL
	-- Stessa insert di prima, ma per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass,flagactivity, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,ivakind, adate, competencydate,flagintracom,reverse_charge,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01,
				idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpro                   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null,I.idinvkind,IK.description,I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind,ivakind.description, 
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
		IDET.idintrastatcode,
		IDET.idintrastatmeasure,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title	
		, PE1.kpro                                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	join invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_taxable 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
		LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE 
		I.flagintracom='S' 
	 and (	(@av = 'A' and   ---- incluse note in credito su acquisti in entrata
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 ))   ---- escluse note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)


	-- variazioni su entrata
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass,flagactivity, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,ivakind,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01 ,
			idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva	
		, kpro                   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null, I.idinvkind, IK.description , I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind, ivakind.description, 
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
		IDET.idintrastatcode,
		IDET.idintrastatmeasure,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PE1.kpro                                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	join invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_iva  
	join incomevar VARMOV			on VARMOV.idinc=PE1.idinc 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv	AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE I.flagintracom='N'
	 and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	   ---- incluse note in credito su acquisti in entrata
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 ))   ---- escluse note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- variazioni su entrata
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass,flagactivity, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,ivakind, adate, competencydate, flagintracom,reverse_charge,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01, 
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpro                   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
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
		IRK.idivaregisterkind, IDET.idivakind, ivakind.description, 
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
		IDET.idintrastatcode,
		IDET.idintrastatmeasure,
		I.iso_destination,
		I.iso_origin,
		I.iso_provenance,
		I.idcountry_destination,
		I.idcountry_origin,
		IDET.exception12,
		IDET.intra12operationkind,
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PE1.kpro                                         -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	join invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_taxable 
	join incomevar VARMOV			on	VARMOV.idinc=PE1.idinc 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE I.flagintracom='S' 
		AND I.flagdeferred = 'S'
	 and (	(@av = 'A' and  ---- incluse note in credito su acquisti in entrata 
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 ))  ---- escluse note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass,flagactivity, 	kind,flagintracom, reverse_charge, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate,competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01, 
			idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva	
		, kpaymenttransmission   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind, ivakind.description, 
		I.adate, PC1.competencydate,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PC1.kpaymenttransmission                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1	ON PC1.idexp = IDET.idexp_iva  
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind	
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind 	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry				ON registry.idreg = I.idreg
	JOIN ivakind				ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE I.flagintracom='N'
	and (	(@av = 'A' and   ---- incluse note in credito su acquisti in entrata
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) --escluse  note in credito su acquisti in entrata
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass,flagactivity, 	kind,flagintracom,reverse_charge,  flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate,competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01 ,
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpaymenttransmission   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind, ivakind.description, 
		I.adate, PC1.competencydate,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PC1.kpaymenttransmission                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	JOIN invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1	ON PC1.idexp = IDET.idexp_taxable  
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind 	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE I.flagintracom='S' 
	and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)


	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture non intracom
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass,flagactivity, 	kind,flagintracom, reverse_charge,flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate, competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01,
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpaymenttransmission   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind,ivakind.description, 
		I.adate,
		PC1.competencydate,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PC1.kpaymenttransmission                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	JOIN invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1	ON PC1.idexp = IDET.idexp_iva 
	join expensevar VARMOV			on	VARMOV.idexp=PC1.idexp 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv	AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
		LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE I.flagintracom='N'
 and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND I.flagintracom='N'				
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)


	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv,rownum, flagdeferred, 
		registerclass, flagactivity, 	kind,flagintracom, reverse_charge, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate,competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01, 
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, kpaymenttransmission   -- Modifiche task 10269
		, cf, p_iva, foreigncf   -- Modifiche task 10659
		
	)
	(SELECT
		null, I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind, ivakind.description, 
		I.adate,
		PC1.competencydate,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, PC1.kpaymenttransmission                          -- Modifiche task 10269
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659
		
	FROM invoice I
	JOIN invoicedetail IDET			ON IDET.idinvkind=I.idinvkind AND IDET.yinv=I.yinv AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1	ON PC1.idexp = IDET.idexp_taxable 
	join expensevar VARMOV			on VARMOV.idexp=PC1.idexp AND VARMOV.idinvkind = I.idinvkind AND VARMOV.yinv  = I.yinv AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE 
		I.flagintracom='S' 
	 and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND I.flagdeferred = 'S'
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND I.flagintracom='N'				
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		label, idinvkind,invoicekind,yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass,flagactivity, kind,flagintracom, reverse_charge, flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate,competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01 ,
				idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, cf, p_iva, foreigncf   -- Modifiche task 10659
	)
	(SELECT
		null,
		I.idinvkind, IK.description, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		IRK.flagactivity,
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 
		I.flagintracom,
		CASE
			WHEN (I.flagintracom <> 'N') AND (IRK.registerclass = 'V') AND ( RAK.registerclass IS NOT NULL) THEN 'S'
			ELSE 'N'
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
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind, IDET.idivakind, ivakind.description, 
		I.adate, IDET.paymentcompetency,
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
	    , registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659

	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry				ON registry.idreg = I.idreg
	JOIN ivakind				ON IDET.idivakind = ivakind.idivakind
	--JOIN ivaregister RA 	ON  RA.idinvkind = I.idinvkind	AND RA.yinv = I.yinv	AND RA.ninv = I.ninv
	LEFT JOIN ivaregisterkind RAK	ON RAK.idivaregisterkind = IRK.idivaregisterkind	AND RAK.registerclass = 'A'
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE  
		I.flagdeferred = 'S'
		and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND month(IDET.paymentcompetency)  BETWEEN @startmonth and 	@stopmonth
		AND Year(IDET.paymentcompetency) = @year -- BETWEEN @datebegin AND @dateend
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		AND (IK.codeinvkind = @codeinvkind OR @codeinvkind is null)
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	)

	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		label, idinvkind, invoicekind, yinv, ninv, rownum,flagdeferred, 
		registerclass,flagactivity, kind,flagintracom,reverse_charge, flagvariation,	flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,ivakind, adate,competencydate,
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
		move12,idaccmotive,idaccmotivedett,flag_enable_split_payment,idsdi_acquisto,ipa_acq,idsdi_vendita, ipa_ven_cliente, idsor01, 
		idupb, codeupb, upb,idupb_iva,codeupb_iva, upb_iva
		, cf, p_iva, foreigncf   -- Modifiche task 10659
	)
	(SELECT
		null,
		I.idinvkind, IK.description, I.yinv, I.ninv, IDET.rownum, 'S', 		
		IRK.registerclass, 
		IRK.flagactivity,
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
		IRK.idivaregisterkind,IDET.idivakind, ivakind.description, 
		I.adate, NULL,	--PCO.adate ---> La data non la usa mai!
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
		IDET.move12,I.idaccmotivedebit, IDET.idaccmotive, I.flag_enable_split_payment, I.idsdi_acquisto, I.ipa_acq, I.idsdi_vendita, ipa_ven_cliente, I.idsor01
		,
		IDET.idupb,   upb.codeupb, upb.title,  IDET.idupb_iva,upb_iva.codeupb, upb_iva.title
		, registry.cf, registry.p_iva, registry.foreigncf	-- Modifiche task 10659

	FROM invoice I
	JOIN invoicedetail IDET			ON IDET.idinvkind=I.idinvkind AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN #ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN registry					ON registry.idreg = I.idreg
	JOIN ivakind					ON IDET.idivakind = ivakind.idivakind
	LEFT OUTER JOIN upb				ON upb.idupb = IDET.idupb
	LEFT OUTER JOIN upb upb_iva		ON upb_iva.idupb = IDET.idupb_iva
	WHERE 	I.flagdeferred = 'S'
	and (	(@av = 'A' and  
				((IK.flag & 1)=0   OR 	 
			    (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 2 )) 
				OR (@av = 'V' and  (IK.flag & 1)<>0   and  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = IDET.idinvkind
					and RK.registerclass<>'P'
				) = 1 ) 
				
				)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND IDET.paymentcompetency IS NULL
		AND (IRK.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
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
		AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
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

	DECLARE @registerclass char(1)
	SELECT  @registerclass = registerclass	FROM ivaregisterkind	WHERE idivaregisterkind = @idivaregisterkind
	
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
			
				JOIN ivaregisterkind RAK	 ON  RAK.idivaregisterkind = RA.idivaregisterkind  AND RAK.registerclass = 'A'
					 WHERE
					 	RA.idinvkind = #invoicedet.idinvkind
						AND RA.yinv = #invoicedet.yinv
						AND RA.ninv = #invoicedet.ninv) 
						
	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
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

update #invoicedet SET label = 'Acquisto anni prec. diven. detraibili'  WHERE flagdeferred = 'S' AND kind = 'A' and yinv < @year
update #invoicedet SET label = 'Vendita  anni prec. diven. esigibili'	WHERE flagdeferred = 'S' AND kind = 'V' and yinv < @year
update #invoicedet SET label = 'Acquisto anno corr. diven. detraibili'  WHERE flagdeferred = 'S' AND kind = 'A' and yinv = @year
update #invoicedet SET label = 'Vendita anno corr. diven. esigibili'	WHERE flagdeferred = 'S' AND kind = 'V' and yinv = @year

delete from #invoicedet WHERE flagdeferred = 'T'
and exists (select  * from #invoicedet I1 
			 where	#invoicedet.idinvkind = I1.idinvkind 
			 and    #invoicedet.yinv = I1.yinv 
			 and    #invoicedet.ninv = I1.ninv
			 and    #invoicedet.rownum = I1.rownum
			 and    I1.flagdeferred = 'S' )

update #invoicedet SET label = 'Acquisto anno corr. non ancora detraibili', flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'A' and yinv = @year
update #invoicedet SET label = 'Vendita  anno corr. non ancora esigibili' ,flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'V' and yinv = @year
update #invoicedet SET label = 'Acquisto anno prec. non ancora detraibili', flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'A' and yinv < @year
update #invoicedet SET label = 'Vendita  anno prec. non ancora esigibili' ,flagdeferred = 'S' WHERE flagdeferred = 'T' AND kind = 'V' and yinv < @year

DECLARE @departmentname varchar(500)

SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @year) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @year)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


--IF @flagactivity is not null
--BEGIN

	IF @groupiva = 'N' and @groupinvkind = 'N' 
	BEGIN
		SELECT
			#ivaregisterkind.description as 'Registro', 
			#ivaregisterkind.idivaregisterkindunified as '#Cod. consolidamento',
			--@departmentname as 'Dipartimento', 
			sor01.description as 'Attributo1',
			#invoicedet.label as 'Esigibilità/Detraibilità', 
			#invoicedet.invoicekind as 'Tipo Fattura', 
			#invoicedet.yinv as 'Eserc. Fattura', 
			#invoicedet.ninv as 'Num. Fattura', 
			#invoicedet.rownum as '# Dett', 
			#invoicedet.adate as 'Data Registr.',
			accmotive.codemotive as 'Cod.Causale credito/debito', accmotive.title as 'Causale credito/debito',	account.codeacc as 'Cod.Conto credito/debito', account.title as 'Conto credito/debito',
			#invoicedet.cf as 'Codice Fiscale', #invoicedet.p_iva as 'Partita IVA', #invoicedet.foreigncf as 'CF Estero/Passaporto',   -- Modifiche task 10659
			accmotiveDett.codemotive as 'Cod.Causale costo/ricavo', accmotiveDett.title as 'Causale costo/ricavo',accountDett.codeacc as 'Cod.Conto costo/ricavo', accountDett.title as 'Conto costo/ricavo',
			#invoicedet.flagmixed as 'Promiscua',
			#invoicedet.flagdeferred as 'IVA Differita', 
			#invoicedet.taxabletotal as 'Impon. Tot.', 
			#invoicedet.ivagross as 'IVA Tot.',
			#invoicedet.ivaunabatable as 'IVA Indetr.',
			#invoicedet.ivaabatable as 'IVA Detr.',
			#invoicedet.ivakind as 'Tipo IVA',
			#invoicedet.doc as 'Doc. colleg.',
			#invoicedet.docdate as 'Data Doc.', 
			#invoicedet.registry as 'Fornitore/Cliente', 
			#invoicedet.description  as 'Descrizione',
			CASE #invoicedet.flagactivity 
				WHEN 1 THEN 'Istituzionale'
				WHEN 2 THEN 'Commerciale'
				WHEN 3 THEN 'Promiscua'
			END as 'Attività',
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
		uniqueregister.iduniqueregister as 'N.Registro Unico',
		#invoicedet.idupb, 
		#invoicedet.codeupb,
		#invoicedet.upb,
		#invoicedet.idupb_iva,
		#invoicedet.codeupb_iva,
		#invoicedet.upb_iva
		--Modifiche task 10269
		,pt.transmissiondate  as 'Data di trasmissione della distinta pagamenti',
		prt.transmissiondate  as 'Data di trasmissione della distinta incassi',

		CASE 
			WHEN pt.transmissiondate IS NULL
			AND prt.transmissiondate IS NULL THEN NULL
			ELSE ID.tax
		END as 'IVA pagata/Incassata',
		
		CASE 
			WHEN pt.transmissiondate IS NULL 
			AND prt.transmissiondate IS NULL THEN NULL
			ELSE ID.taxable
		END as 'Imponibile Pagato/Incassato',
		--Fine modifiche task 10269

		--task 12716
		IDD.yivapay as 'Eserc.Liquidazione iva',
		IDD.nivapay as 'N.Liquidazione iva'
				
		
		FROM    #invoicedet
		LEFT OUTER JOIN  #ivaregisterkind					ON #invoicedet.idivaregisterkind = #ivaregisterkind.idivaregisterkind
		LEFT OUTER JOIN intrastatservice as S				ON S.idintrastatservice = #invoicedet.idintrastatservice
		LEFT OUTER JOIN intrastatpaymethod as P				ON P.idintrastatpaymethod = #invoicedet.idintrastatpaymethod
		LEFT OUTER JOIN intrastatsupplymethod E				ON E.idintrastatsupplymethod = #invoicedet.idintrastatsupplymethod
		LEFT OUTER JOIN intrastatnation as Pag				ON #invoicedet.iso_payment = Pag.idintrastatnation
		LEFT OUTER JOIN intrastatkind as K					ON #invoicedet.idintrastatkind = K.idintrastatkind
		LEFT OUTER JOIN intrastatmeasure as M				ON #invoicedet.idintrastatmeasure= M.idintrastatmeasure
		LEFT OUTER JOIN intrastatcode as C					ON C.idintrastatcode = #invoicedet.idintrastatcode
		LEFT OUTER JOIN intrastatnation as Dest				ON #invoicedet.iso_destination = Dest.idintrastatnation
		LEFT OUTER JOIN intrastatnation as Orig				ON #invoicedet.iso_origin = Orig.idintrastatnation
		LEFT OUTER JOIN intrastatnation as Prov				ON #invoicedet.iso_provenance = Prov.idintrastatnation
		LEFT OUTER JOIN geo_country as geo_country_destination			ON #invoicedet.idcountry_destination = geo_country_destination.idcountry
		LEFT OUTER JOIN geo_country as geo_country_origin				ON #invoicedet.idcountry_origin = geo_country_origin.idcountry
		LEFT OUTER JOIN accmotive							ON accmotive.idaccmotive = #invoicedet.idaccmotive
		LEFT OUTER JOIN accmotivedetail						on accmotive.idaccmotive = accmotivedetail.idaccmotive and accmotivedetail.ayear = #invoicedet.yinv
		LEFT OUTER JOIN account								on account.idacc= accmotivedetail.idacc and account.ayear= accmotivedetail.ayear
		LEFT OUTER JOIN accmotive accmotiveDett				ON accmotiveDett.idaccmotive = #invoicedet.idaccmotivedett
		LEFT OUTER JOIN accmotivedetail accmotivedetailDett	on accmotiveDett.idaccmotive = accmotivedetailDett.idaccmotive and accmotivedetailDett.ayear = #invoicedet.yinv
		LEFT OUTER JOIN account accountDett					on accountDett.idacc= accmotivedetailDett.idacc and accountDett.ayear= accmotivedetailDett.ayear	
		LEFT OUTER JOIN uniqueregister						ON uniqueregister.idinvkind = #invoicedet.idinvkind	AND uniqueregister.ninv = #invoicedet.ninv
																	AND uniqueregister.yinv = #invoicedet.yinv	
		LEFT OUTER JOIN sorting sor01						on #invoicedet.idsor01 = sor01.idsor
		
		--Modifiche task 10269
		LEFT OUTER JOIN invoicedetail ID					ON #invoicedet.idinvkind = ID.idinvkind		AND #invoicedet.yinv = ID.yinv		AND #invoicedet.ninv = ID.ninv	AND #invoicedet.rownum = ID.rownum
		LEFT OUTER JOIN paymenttransmission pt				on #invoicedet.kpaymenttransmission = pt.kpaymenttransmission
		LEFT OUTER JOIN proceeds                            on #invoicedet.kpro = proceeds.kpro
		LEFT OUTER JOIN proceedstransmission prt			on proceeds.kproceedstransmission = prt.kproceedstransmission
		LEFT OUTER JOIN profservice							ON #invoicedet.idinvkind = profservice.idinvkind		AND #invoicedet.yinv = profservice.yinv		AND #invoicedet.ninv = profservice.ninv
		LEFT OUTER JOIN profserviceresidual					ON profservice.ycon = profserviceresidual.ycon		AND profservice.ncon = profserviceresidual.ncon
		--Fine modifiche task 10269
		
		--task 12716
		LEFT OUTER JOIN invoicedetaildeferred IDD			ON IDD.idinvkind=ID.idinvkind AND IDD.yinv=ID.yinv AND IDD.ninv=ID.ninv AND IDD.rownum=ID.rownum
																	AND IDD.idivaregisterkind=	#invoicedet.idivaregisterkind

		--WHERE (#ivaregisterkind.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		ORDER BY #invoicedet.invoicekind, #invoicedet.yinv, #invoicedet.ninv, #invoicedet.adate,#invoicedet.rownum
	END
	
	
	IF @groupiva = 'S' and @groupinvkind = 'N' 
	BEGIN
		SELECT 
			#ivaregisterkind.description as 'Registro', 
			#ivaregisterkind.idivaregisterkindunified as '#Cod. consolidamento',
			@departmentname as 'Dipartimento', 
			#invoicedet.label as 'Esigibilità/Detraibilità', 
			NULL as 'Tipo Fattura', --invoicekind as 'Tipo Fattura', 
			#invoicedet.yinv as 'Eserc. Fattura', 
			NULL as 'Num. Fattura',--ninv as 'Num. Fattura', 
			NULL as '# Dett',--rownum as '# Dett', 
			NULL as 'Data Registr.',--adate as 'Data Registr.',
			--accmotive.codemotive as 'Cod.Causale credito/debito', accmotive.title as 'Causale credito/debito',	account.codeacc as 'Cod.Conto', account.title as 'Conto',
			#invoicedet.cf as 'Codice Fiscale', #invoicedet.p_iva as 'Partita IVA', #invoicedet.foreigncf as 'CF Estero/Passaporto',   -- Modifiche task 10659
			#invoicedet.flagmixed as 'Promiscua',
			#invoicedet.flagdeferred as 'IVA Differita', 
			SUM(#invoicedet.taxabletotal) as 'Impon. Tot.', 
			SUM(#invoicedet.ivagross) as 'IVA Tot.',
			SUM(#invoicedet.ivaunabatable) as 'IVA Indetr.',
			SUM(#invoicedet.ivaabatable) as 'IVA Detr.',
			#invoicedet.ivakind as 'Tipo IVA',
			NULL as 'Doc. colleg.',--doc as 'Doc. colleg.',
			NULL as 'Data Doc.',--docdate as 'Data Doc.', 
			NULL as 'Fornitore/Cliente',--registry as 'Fornitore/Cliente'
			NULL as 'Descrizione',--description  as 'Descrizione'
			CASE #invoicedet.flagactivity WHEN 1 THEN 'Istituzionale'
										  WHEN 2 THEN 'Commerciale'
										  WHEN 3 THEN 'Promiscua'
			END as 'Attivita'/*,
			flag_enable_split_payment as 'Split Payment',
			idsdi_acquisto as 'N.File(SdI Acquisto)' ,	ipa_acq as 'IPA acqisto',
			idsdi_vendita  as 'N.File(SdI Vendita)', ipa_ven_cliente as 'IPA cliente', 
			uniqueregister.iduniqueregister as 'N.Registro Unico'*/
			,#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva
		FROM    #invoicedet
		LEFT OUTER JOIN  #ivaregisterkind				ON #invoicedet.idivaregisterkind = #ivaregisterkind.idivaregisterkind
		/*LEFT OUTER JOIN accmotive  			ON accmotive.idaccmotive = #invoicedet.idaccmotive
		LEFT OUTER JOIN accmotivedetail			on accmotive.idaccmotive = accmotivedetail.idaccmotive and accmotivedetail.ayear = #invoicedet.yinv
		LEFT OUTER JOIN account					on account.idacc= accmotivedetail.idacc and account.ayear= accmotivedetail.ayear
		LEFT OUTER JOIN uniqueregister			ON uniqueregister.idinvkind = #invoicedet.idinvkind
										AND uniqueregister.ninv = #invoicedet.ninv			AND uniqueregister.yinv = #invoicedet.yinv*/
		--WHERE (#ivaregisterkind.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		GROUP BY #invoicedet.ivakind,#invoicedet.label,#invoicedet.yinv,#invoicedet.flagmixed,#invoicedet.flagdeferred,#ivaregisterkind.idivaregisterkindunified  , 
				#ivaregisterkind.description,#invoicedet.flagactivity,
				#invoicedet.cf, #invoicedet.p_iva, #invoicedet.foreigncf ,	#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva
				/*,
				accmotive.codemotive, accmotive.title,	account.codeacc, account.title,
				flag_enable_split_payment,
				idsdi_acquisto,	ipa_acq,idsdi_vendita, ipa_ven_cliente, uniqueregister.iduniqueregister*/
		ORDER BY #invoicedet.yinv,#invoicedet.ivakind
	END
	
	
	IF @groupiva = 'N' and @groupinvkind = 'S' 
	BEGIN
		SELECT 
			#ivaregisterkind.description as 'Registro', 
			#ivaregisterkind.idivaregisterkindunified as '#Cod. consolidamento',
			@departmentname as 'Dipartimento', 
			#invoicedet.label as 'Esigibilità/Detraibilità',
			#invoicedet.invoicekind as 'Tipo Fattura',
			#invoicedet.yinv as 'Eserc. Fattura', 
			NULL as 'Num. Fattura',--ninv as 'Num. Fattura', 
			NULL as '# Dett',--rownum as '# Dett', 
			NULL as 'Data Registr.',--adate as 'Data Registr.',
			#invoicedet.cf as 'Codice Fiscale', #invoicedet.p_iva as 'Partita IVA', #invoicedet.foreigncf as 'CF Estero/Passaporto',   -- Modifiche task 10659
			#invoicedet.flagmixed as 'Promiscua',
			#invoicedet.flagdeferred as 'IVA Differita', 
			SUM(#invoicedet.taxabletotal) as 'Impon. Tot.', 
			SUM(#invoicedet.ivagross) as 'IVA Tot.',
			SUM(#invoicedet.ivaunabatable) as 'IVA Indetr.',
			SUM(#invoicedet.ivaabatable) as 'IVA Detr.',
			NULL as 'Tipo IVA',
			NULL as 'Doc. colleg.',--doc as 'Doc. colleg.',
			NULL as 'Data Doc.',--docdate as 'Data Doc.', 
			NULL as 'Fornitore/Cliente',--registry as 'Fornitore/Cliente'
			NULL as 'Descrizione',--description  as 'Descrizione'
			CASE #invoicedet.flagactivity WHEN 1 THEN 'Istituzionale'
										  WHEN 2 THEN 'Commerciale'
										  WHEN 3 THEN 'Promiscua'
			END as 'Attivita',
			#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva
		FROM    #invoicedet
		LEFT OUTER JOIN  #ivaregisterkind				ON #invoicedet.idivaregisterkind = #ivaregisterkind.idivaregisterkind
		
		--WHERE (#ivaregisterkind.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		GROUP BY #invoicedet.invoicekind,#invoicedet.label,#invoicedet.yinv,#invoicedet.flagmixed,#invoicedet.flagdeferred, 
				 #ivaregisterkind.description,#invoicedet.flagactivity,#ivaregisterkind.idivaregisterkindunified,
				 #invoicedet.cf, #invoicedet.p_iva, #invoicedet.foreigncf ,	#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva
		ORDER BY #invoicedet.yinv,#invoicedet.invoicekind
	END
	
	IF @groupiva = 'S' and @groupinvkind = 'S' 
	BEGIN
		SELECT 
			#ivaregisterkind.description as 'Registro', 
			#ivaregisterkind.idivaregisterkindunified as '#Cod. consolidamento',
			@departmentname as 'Dipartimento', 
			#invoicedet.label as 'Esigibilità/Detraibilità', 
			#invoicedet.invoicekind as 'Tipo Fattura', 
			#invoicedet.yinv as 'Eserc. Fattura', 
			NULL as 'Num. Fattura',--ninv as 'Num. Fattura', 
			NULL as '# Dett',--rownum as '# Dett', 
			NULL as 'Data Registr.',--adate as 'Data Registr.',
			#invoicedet.cf as 'Codice Fiscale', #invoicedet.p_iva as 'Partita IVA', #invoicedet.foreigncf as 'CF Estero/Passaporto',   -- Modifiche task 10659
			#invoicedet.flagmixed as 'Promiscua',
			#invoicedet.flagdeferred as 'IVA Differita', 
			SUM(#invoicedet.taxabletotal) as 'Impon. Tot.', 
			SUM(#invoicedet.ivagross )as 'IVA Tot.',
			SUM(#invoicedet.ivaunabatable) as 'IVA Indetr.',
			SUM(#invoicedet.ivaabatable) as 'IVA Detr.',
			#invoicedet.ivakind as 'Tipo IVA',
			NULL as 'Doc. colleg',--doc as 'Doc. colleg.',
			NULL as 'Data Doc.',--docdate as 'Data Doc.', 
			NULL as 'Fornitore/Cliente',--registry as 'Fornitore/Cliente', 
			NULL as 'Descrizione',--description  as 'Descrizione'
			CASE #invoicedet.flagactivity WHEN 1 THEN 'Istituzionale'
										  WHEN 2 THEN 'Commerciale'
										  WHEN 3 THEN 'Promiscua'
			END as 'Attivita',
				#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva
		
		FROM    #invoicedet
		LEFT OUTER JOIN  #ivaregisterkind				ON #invoicedet.idivaregisterkind = #ivaregisterkind.idivaregisterkind
		
		--WHERE (#ivaregisterkind.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
		GROUP BY #invoicedet.invoicekind, #invoicedet.ivakind, #invoicedet.label, #invoicedet.flagmixed, 
				 #invoicedet.flagdeferred, #invoicedet.yinv, #ivaregisterkind.description, #invoicedet.flagactivity,
				 #ivaregisterkind.idivaregisterkindunified,
				 #invoicedet.cf, #invoicedet.p_iva, #invoicedet.foreigncf ,	#invoicedet.idupb, 
			#invoicedet.codeupb,
			#invoicedet.upb,
			#invoicedet.idupb_iva,
			#invoicedet.codeupb_iva,
			#invoicedet.upb_iva 
		ORDER BY #invoicedet.invoicekind, #invoicedet.ivakind, #invoicedet.yinv
	END
--END
--ELSE
--		SELECT 
--			#ivaregisterkind.description as 'Registro', 
--			#ivaregisterkind.idivaregisterkindunified as '#Cod. consolidamento',
--			@departmentname as 'Dipartimento', 
--			#invoicedet.label as 'Esigibilità/Detraibilità', 
--			NULL as 'Tipo Fattura',--#invoicedet.invoicekind as 'Tipo Fattura', 
--			#invoicedet.yinv as 'Eserc. Fattura', 
--			NULL as 'Num. Fattura',--ninv as 'Num. Fattura', 
--			NULL as '# Dett',--rownum as '# Dett', 
--			NULL as 'Data Registr.',--adate as 'Data Registr.',
--			#invoicedet.flagmixed as 'Promiscua',
--			#invoicedet.flagdeferred as 'IVA Differita', 
--			SUM(#invoicedet.taxabletotal) as 'Impon. Tot.', 
--			SUM(#invoicedet.ivagross )as 'IVA Tot.',
--			SUM(#invoicedet.ivaunabatable) as 'IVA Indetr.',
--			SUM(#invoicedet.ivaabatable) as 'IVA Detr.',
--			#invoicedet.ivakind as 'Tipo IVA',
--			NULL as 'Doc. colleg',--doc as 'Doc. colleg.',
--			NULL as 'Data Doc.',--docdate as 'Data Doc.', 
--			NULL as 'Fornitore/Cliente',--registry as 'Fornitore/Cliente', 
--			NULL as 'Descrizione',--description  as 'Descrizione'
--			CASE #invoicedet.flagactivity WHEN 1 THEN 'Istituzionale'
--										  WHEN 2 THEN 'Commerciale'
--										  WHEN 3 THEN 'Promiscua'
--			END as 'Attivita'
--		FROM    #invoicedet
--		LEFT OUTER JOIN  #ivaregisterkind
--			ON #invoicedet.idivaregisterkind = #ivaregisterkind.idivaregisterkind
--		--WHERE (#ivaregisterkind.idivaregisterkind = @idivaregisterkind OR @idivaregisterkind IS NULL)
--		GROUP BY #invoicedet.ivakind, #invoicedet.label, #invoicedet.flagmixed, 
--				 #invoicedet.flagdeferred, #invoicedet.yinv, 
--				#ivaregisterkind.description, #invoicedet.flagactivity,	#ivaregisterkind.idivaregisterkindunified 
--		ORDER BY  #invoicedet.ivakind, #invoicedet.yinv
	
	END
	

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

 
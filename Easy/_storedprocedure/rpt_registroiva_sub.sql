
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registroiva_sub]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registroiva_sub]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- rpt_registroiva_sub 1, 2017, 1, 12
CREATE           PROCEDURE [rpt_registroiva_sub]
	@idivaregisterkind int,
	@year int,
	@month_start int,
	@month_stop int,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS BEGIN
	

	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagintracom char(1),
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		ivagross decimal(19,2),
		ivaabatable decimal(19,2),
		ivaunabatable decimal(19,2),
		taxable decimal(19,2),
		idivaregisterkind int,
		idivakind int,		
		movdescription varchar(500),
		paymentproceeds varchar(500),
		movdate datetime,
		ispettycash int
	)
CREATE TABLE #invoicePettycash (
		description varchar(50),
		pettycash varchar(50),	
		idinvkind int,
		yinv int,
		ninv int,
		movdate datetime
		)

declare @DenominazioneUniversita varchar(50)
select @DenominazioneUniversita = paramvalue from generalreportparameter where idparam='DenominazioneUniversita'

	IF @month_start IS NULL OR @month_start < 1
	BEGIN
		SET @month_start = 1
	END
	IF @month_start > 12
	BEGIN
		SET @month_start = 12
	END

	IF @month_stop IS NULL OR @month_stop < 1
	BEGIN
		SET @month_stop = 1
	END
	IF @month_stop > 12
	BEGIN
		SET @month_stop = 12
	END
	
	DECLARE @monthname_start varchar(20)
	SELECT @monthname_start = title
	FROM monthname
	WHERE code = @month_start

	DECLARE @monthname_stop varchar(20)
	SELECT @monthname_stop = title
	FROM monthname
	WHERE code = @month_stop



	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- 	la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxable,ivagross,	
		idivaregisterkind,idivakind,movdescription, paymentproceeds, movdate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE 	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END, --flagmixed
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1) = 0 THEN 'A'  ELSE 'V'		END, --Tipologia	
		CASE WHEN (IK.flag & 4) = 0 THEN 'N'  ELSE 'S'		END, --Tipo della variazione
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *	  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2		 ), 
		ISNULL(IDET.tax,0),					
		IRK.idivaregisterkind,IDET.idivakind,
		'Mov. n. ' + CONVERT(varchar(6),PE1.nmov) + '/' + CONVERT(varchar(4),PE1.ymov),
		'Reversale n. '+ convert(varchar(6),PE1.npro),
		PE1.competencydate,
		I.flagintracom
	FROM invoice I
	join invoicedetail IDET				ON IDET.idinvkind=I.idinvkind AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1			ON PE1.idinc = IDET.idinc_iva  
	JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv 	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		AND I.flagintracom='N'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate)  between @month_start and @month_stop	and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		--AND I.flagintracom='N'		
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)





	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxable,ivagross,	
		idivaregisterkind,idivakind,movdescription,paymentproceeds, movdate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END, --flagmixed
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'		ELSE 'V'	END, 	
		CASE WHEN (IK.flag & 4) = 0 THEN 'N'	ELSE 'S'	END, 
		ROUND(IDET.taxable * IDET.npackage * 	 CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ),
		ISNULL(IDET.tax,0),				
		IRK.idivaregisterkind,IDET.idivakind,
		'Mov. n. ' + CONVERT(varchar(6),PE1.nmov) + '/' + CONVERT(varchar(4),PE1.ymov),
		'Reversale n. '+ convert(varchar(6),PE1.npro),
		PE1.competencydate,
		I.flagintracom
	FROM invoice I		
	join invoicedetail IDET				ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1			ON PE1.idinc = IDET.idinc_taxable 
	JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv 	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		AND I.flagintracom <>'N'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate)  between @month_start and @month_stop	and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

	--variazioni su entrata
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxable,ivagross,	
		idivaregisterkind,idivakind,movdescription,paymentproceeds, movdate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END, --flagmixed
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'		END, 
		CASEWHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END, 
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		ISNULL(IDET.tax,0),	 			
		IRK.idivaregisterkind,IDET.idivakind,
		'Var. n. ' + CONVERT(varchar(6),VARMOV.nvar) + '/' + CONVERT(varchar(4),VARMOV.yvar),
		'Reversale n. '+ convert(varchar(6),PE1.npro),
		PE1.competencydate,
		I.flagintracom
	FROM invoice I
	join invoicedetail IDET				ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1			ON PE1.idinc = IDET.idinc_iva  
	join incomevar VARMOV				on	VARMOV.idinc=PE1.idinc 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv	AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S' AND I.flagintracom='N'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		AND IDET.paymentcompetency IS NULL
		--AND PE1.competencydate BETWEEN @datebegin AND @dateend
		AND month(PE1.competencydate)  between @month_start and @month_stop	and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend

		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxable,ivagross,	
		idivaregisterkind,idivakind,movdescription,paymentproceeds, movdate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'		END, 
		CASE WHEN (IK.flag & 4) = 0 THEN 'N'   ELSE 'S'		END, 
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2	 ), 
		ISNULL(IDET.tax,0),	 			
		IRK.idivaregisterkind,IDET.idivakind,
		'Var. n. ' + CONVERT(varchar(6),VARMOV.nvar) + '/' + CONVERT(varchar(4),VARMOV.yvar),
	'Reversale n. '+ convert(varchar(6),PE1.npro),
		PE1.competencydate,
		I.flagintracom
	FROM invoice I
	join invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_taxable  
	join incomevar VARMOV			on	VARMOV.idinc=PE1.idinc 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv	AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S' 
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		AND I.flagintracom <>'N'
		AND IDET.paymentcompetency IS NULL
		--AND PE1.competencydate BETWEEN @datebegin AND @dateend
		AND month(PE1.competencydate)  between @month_start and @month_stop	and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend

		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)


	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,movdescription, paymentproceeds, movdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'	END, 	
		I.flagintracom,	'N',
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END, --flagmixed
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2	 ), 
		ISNULL(IDET.tax,0),				
		ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IDET.idivakind,
		'Mov. n. ' + CONVERT(varchar(6),PC1.nmov) + '/' + CONVERT(varchar(4),PC1.ymov),
		'Mandato n. '+ convert(varchar(6),PC1.npay),
		PC1.competencydate
	FROM invoice I
	JOIN invoicedetail IDET				ON IDET.idinvkind=I.idinvkind  AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1		ON PC1.idexp = IDET.idexp_iva 
	JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind 	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S' AND I.flagintracom='N' 
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) between @month_start and @month_stop	and Year(PC1.competencydate) = @year -- BETWEEN @datebegin AND @dateend

		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)



	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,movdescription,paymentproceeds, movdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,	
		I.flagintracom,		'N',
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *	  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2	 ), 
		ISNULL(IDET.tax,0),					ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IDET.idivakind,
		'Mov. n. ' + CONVERT(varchar(6),PC1.nmov) + '/' + CONVERT(varchar(4),PC1.ymov),
		'Mandato n. '+ convert(varchar(6),PC1.npay),
		PC1.competencydate
	FROM invoice I
	JOIN invoicedetail IDET					ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1			ON PC1.idexp = IDET.idexp_taxable 
	JOIN invoicekind IK						ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR						ON IR.idinvkind = I.idinvkind 	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK				ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S' AND I.flagintracom <>'N'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate)  between @month_start and @month_stop	and Year(PC1.competencydate) = @year -- BETWEEN @datebegin AND @dateend

		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)



	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,movdescription,paymentproceeds, movdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'	END, 	
		I.flagintracom,		'S',
		CASE	WHEN IRK.flagactivity = 3  THEN 'S' 	ELSE 'N' END,
		ROUND(IDET.taxable * IDET.npackage * 	 CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ), 
		ISNULL(IDET.tax,0),					ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IDET.idivakind,
		'Var. n. ' + CONVERT(varchar(6),VARMOV.nvar) + '/' + CONVERT(varchar(4),VARMOV.yvar),
		'Mandato n. '+ convert(varchar(6),PC1.npay),
		PC1.competencydate
	FROM invoice I
	JOIN invoicedetail IDET				ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1		ON PC1.idexp = IDET.idexp_iva 
	join expensevar VARMOV				on	VARMOV.idexp=PC1.idexp 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK					ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinvAND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S' AND I.flagintracom='N'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		--AND PC1.competencydate BETWEEN @datebegin AND @dateend
		AND month(PC1.competencydate) between @month_start and @month_stop	and Year(PC1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)


	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,movdescription,paymentproceeds, movdate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'	END, 		
		I.flagintracom,		'S',
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,
		ROUND(IDET.taxable * IDET.npackage * 	 CONVERT(decimal(19,6),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2	 ), 
		ISNULL(IDET.tax,0),						ISNULL(IDET.unabatable,0),	
		IRK.idivaregisterkind,IDET.idivakind,
		'Var. n. ' + CONVERT(varchar(6),VARMOV.nvar) + '/' + CONVERT(varchar(4),VARMOV.yvar),
		'Mandato n. '+ convert(varchar(6),PC1.npay),
		PC1.competencydate
	FROM invoice I
	JOIN invoicedetail IDET			ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1	ON PC1.idexp = IDET.idexp_taxable 
	join expensevar VARMOV			on	VARMOV.idexp=PC1.idexp 	AND VARMOV.idinvkind = I.idinvkind	AND VARMOV.yinv  = I.yinv	AND VARMOV.ninv  = I.ninv
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE   
		I.flagdeferred = 'S' AND I.flagintracom <> 'N'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		--AND PC1.competencydate BETWEEN @datebegin AND @dateend
		AND month(PC1.competencydate)  between @month_start and @month_stop	and Year(PC1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1) = 0 THEN 'A'     ELSE 'V'		END, 	
		I.flagintracom,
		CASE	WHEN (IK.flag & 4) = 0 THEN 'N'	ELSE 'S'	END,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ), 
		ISNULL(IDET.tax,0),			ISNULL(IDET.unabatable,0),	
		 IRK.idivaregisterkind, IDET.idivakind
	FROM invoice I
	JOIN invoicedetail IDET					ON IDET.idinvkind=I.idinvkind	AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN invoicekind IK						ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR						ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK				ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE  
		I.flagdeferred = 'S'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		--AND IDET.paymentcompetency BETWEEN @datebegin AND @dateend				
		AND month(IDET.paymentcompetency)  between @month_start and @month_stop	and Year(IDET.paymentcompetency) = @year -- BETWEEN @datebegin AND @dateend
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,flagvariation,	flagmixed,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind, movdescription, movdate, ispettycash
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv, IDET.rownum, 'S', 		
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'     ELSE 'V'	END, 	
		I.flagintracom,		'N',
		CASE	WHEN IRK.flagactivity = 3  THEN 'S'	ELSE 'N'	END,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2 ), 		
		ISNULL(IDET.tax,0) ,		ISNULL(IDET.unabatable,0),
		IRK.idivaregisterkind,IDET.idivakind,
		NULL,-- movdescription
		NULL,-- PCO.adate
		1
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind AND IDET.yinv=I.yinv AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind 	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	I.flagdeferred = 'S'
		-- Fatture di acquisto oppure di vendita ma non soggette a split payment
		and ((IK.flag & 1)=0 OR  (IK.flag & 1)<>0	and	isnull(I.flag_enable_split_payment,'N')='N')
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		--AND PCO.adate BETWEEN @datebegin AND @dateend
		AND IRK.idivaregisterkind = @idivaregisterkind
		AND EXISTS (SELECT * FROM pettycashoperationinvoice PCOI
		JOIN pettycashoperation PCO
					ON PCO.idpettycash = PCOI.idpettycash
					AND PCO.yoperation = PCOI.yoperation
					AND PCO.noperation = PCOI.noperation 
		WHERE 	PCOI.idinvkind = I.idinvkind
					AND PCOI.yinv = I.yinv
					AND PCOI.ninv = I.ninv
					AND month(PCO.adate)  between @month_start and @month_stop	and Year(PCO.adate) = @year -- BETWEEN @datebegin AND @dateend
		)
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	)

INSERT INTO #invoicePettycash (description, pettycash, idinvkind, yinv, ninv, movdate)
SELECT 	'Op. n. ' + CONVERT(varchar(6),PCO.noperation) + '/' + CONVERT(varchar(4),PCO.yoperation),
		P.description ,
		I.idinvkind, 
		I.yinv, 
		I.ninv,
		PCO.adate
FROM #invoicedet I
JOIN pettycashoperationinvoice PCOI		ON PCOI.idinvkind = I.idinvkind	AND PCOI.yinv = I.yinv	AND PCOI.ninv = I.ninv
JOIN pettycashoperation PCO				ON PCO.idpettycash = PCOI.idpettycash	AND PCO.yoperation = PCOI.yoperation	AND PCO.noperation = PCOI.noperation 
JOIN pettycash P						ON P.idpettycash = PCO.idpettycash
GROUP BY I.idinvkind, I.yinv, I.ninv, PCO.noperation, PCO.yoperation, P.description ,PCO.adate

UPDATE #invoicedet	SET movdescription = #invoicePettycash.pettycash,
						movdate = #invoicePettycash.movdate
					FROM #invoicePettycash
					WHERE isnull(ispettycash,0)=1 
						AND #invoicedet.idinvkind = #invoicePettycash.idinvkind 
						AND #invoicedet.yinv = #invoicePettycash.yinv 
						AND #invoicedet.ninv = #invoicePettycash.ninv

-- Elenca tutte le operazioni del fondo p.s.
DECLARE @description varchar(50)
DECLARE @idinvkind int
DECLARE @yinv int
DECLARE @ninv int

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT description, idinvkind, yinv, ninv FROM #invoicePettycash
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @description, @idinvkind, @yinv, @ninv
 
	WHILE (@@fetch_status=0) 
	BEGIN
	
			UPDATE #invoicedet SET movdescription =  isnull(movdescription,'') + @description + '; '
			WHERE isnull(ispettycash,0)=1 AND #invoicedet.idinvkind = @idinvkind AND #invoicedet.yinv = @yinv AND #invoicedet.ninv = @ninv

			FETCH NEXT FROM cursore 
			INTO @description, @idinvkind, @yinv, @ninv
	END
CLOSE cursore
DEALLOCATE cursore


-- Integra le fatture considerate, con le autofatture senza dettagli ad esse associate:
	INSERT INTO #invoicedet(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxable,ivagross,ivaunabatable,
		idivaregisterkind, idivakind
	)
	(
	SELECT 
		I.idinvkind,I.yinv,I.ninv, M.rownum, M.flagdeferred, M.flagmixed,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 	THEN 'A'   ELSE 'V'		END, --Tipo
		M.flagintracom, 		
		CASE	WHEN (IK.flag & 4) = 0 THEN 'N'	ELSE 'S'	END,  -- flagvariation
		M.taxable, M.ivagross, M.ivaunabatable,
		IRK.idivaregisterkind, M.idivakind
	  FROM #invoicedet M
	join invoice I						on I.idinvkind_real= M.idinvkind	and I.yinv_real= M.yinv		and I.ninv= M.ninv
	JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind			
	WHERE (@idsor01 IS NULL OR I.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)

	DECLARE @proratarate decimal(19,6)
	SELECT @proratarate = prorata
	FROM iva_prorata
	WHERE ayear = @year
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed
	FROM iva_mixed
	WHERE ayear = @year

	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @year
	--Per chi scegli di applicare il calcolo sul totale, anche il promiscuo sarà applicato sul totale.
	if (@flagivapaybyrow='N') 
	Begin
		SET @proratarate=1 --non applica il prorata in questo caso
		SET @mixedrate = 1
	End



	update #invoicedet set ivaabatable= convert(decimal(19,2),  ROUND((ivagross-ivaunabatable)*@proratarate*@mixedrate,2) )
					WHERE registerclass='A' and flagmixed='S'


	update #invoicedet set ivaabatable= convert(decimal(19,2),  ROUND((ivagross-ivaunabatable)*@proratarate,2) )
					WHERE registerclass='A' and flagmixed='N'


	update #invoicedet set ivaabatable=ivagross where registerclass='V'
	
	update #invoicedet set ivaunabatable=ivagross-ivaabatable

	update #invoicedet set  kind = registerclass, taxable=-taxable ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
			) = 1
		--AND flagintracom  <> 'S'


	update #invoicedet set  taxable=-taxable,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		 where flagvariation='S'

		--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoicedet set kind = 'A',
				taxable=-taxable,
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

	SELECT
		ivaregisterkind.registerclass,
		ivaregister.yivaregister, 
		ivaregister.nivaregister,
		invoice.adate,
		ISNULL(invoicekind.description,'')  AS idinvkinddescr,
		#invoicedet.movdescription,
		#invoicedet.paymentproceeds,
		#invoicedet.movdate,
		invoice.doc,
		invoice.docdate,
		currency.codecurrency as idcurrency,
		invoice.exchangerate,
		SUM(#invoicedet.taxable) AS taxabletotal,
		SUM(#invoicedet.ivagross) as ivagross,
		SUM(#invoicedet.ivaabatable) as ivaabatable,
		SUM(#invoicedet.ivaunabatable) as ivaunabatable,
		ivakind.description AS idivakind,
		ivakind.rate AS ivarate,
		invoice.flag_enable_split_payment,
		case when isnull(invoice.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end AS title
	FROM #invoicedet
	JOIN invoice				ON invoice.idinvkind = #invoicedet.idinvkind AND invoice.yinv = #invoicedet.yinv AND invoice.ninv = #invoicedet.ninv
	JOIN ivaregister			ON invoice.idinvkind = ivaregister.idinvkind	AND invoice.yinv = ivaregister.yinv 	AND invoice.ninv = ivaregister.ninv
	JOIN ivaregisterkind		ON ivaregister.idivaregisterkind = ivaregisterkind.idivaregisterkind
	JOIN invoicekind			ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivakind				ON ivakind.idivakind = #invoicedet.idivakind
	JOIN registry				on registry.idreg = invoice.idreg
	LEFT OUTER JOIN currency	ON currency.idcurrency = invoice.idcurrency
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
	group by ivaregisterkind.registerclass , invoice.adate,
		 ivaregister.yivaregister,ivaregister.nivaregister, 
		 #invoicedet.movdate,ISNULL(invoicekind.description,''),
		 #invoicedet.movdescription, #invoicedet.paymentproceeds,
		 #invoicedet.movdate,invoice.doc,invoice.docdate,currency.codecurrency ,	
		 invoice.exchangerate,ivakind.description,ivakind.rate, invoice.flag_enable_split_payment, registry.title,isnull(invoice.autoinvoice,'N')			
	ORDER BY nivaregister
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

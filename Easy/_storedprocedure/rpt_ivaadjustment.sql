
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_ivaadjustment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_ivaadjustment]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--[rpt_ivaadjustment] 2017

CREATE  PROCEDURE [rpt_ivaadjustment]
	@ayear smallint
AS BEGIN

	declare @perc_prorata decimal(19,6)
	declare @perc_prorata_provv decimal(19,6)

	declare @perc_promiscuo decimal(19,6)
	
	select  @perc_prorata= prorata from iva_prorata where ayear=@ayear+1
	select  @perc_prorata_provv = prorata from iva_prorata where ayear=@ayear
	
	select  @perc_promiscuo= mixed from iva_mixed where ayear=@ayear
	
	declare @ModoCalcolo_RigaPerRiga char(1)
	select  @ModoCalcolo_RigaPerRiga= isnull(flagivapaybyrow,'N') from config where ayear=@ayear
	
	declare @saldo_iniziale decimal (19,2)
	select  @saldo_iniziale = isnull(-startivabalance,0) from config where ayear = @ayear
	
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita
	
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		registerclass char(1), -- tipo registro A/V
		kind char(1), -- tipo fattura A/V
		flagmixed char(1),
		flagdeferred char(1),
		flagactivity int,
		flagvariation char(1),
		taxabletotal decimal(19,2),
		ivagross decimal(19,2),
		ivaunabatable decimal(19,2), -- unabatable corrente, applicare segno
		ivaabatable decimal(19,2),   -- calcolato qui
		ivaunabatable_def decimal(19,2), -- unabatable corrente, applicare segno
		ivaabatable_def decimal(19,2),   -- calcolato qui
		idivaregisterkind int, 
		idivakind int,
		flagintracom char(1),
		flagctivity char(1)
	)
	


	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture  intracom con la doppia presenza A/V è da cancellare la riga in vendita

	--1) tutte le fatture non istituzionali non promiscue
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,idivaregisterkind, flagintracom,adate,flagactivity
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum, I.flagdeferred,
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
		IDET.idivakind,IRK.idivaregisterkind,
		I.flagintracom,I.adate,IRK.flagactivity
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
	WHERE 	
		YEAR(I.adate) = @ayear 
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)

	-- chiamiamo 'T' le fatture differite, a prescindere da quando vengono pagate
	UPDATE #invoicedet set flagdeferred='T' where flagdeferred='S'
	
	-- 2)
	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- 	la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	-- Stessa insert di prima, ma per le fatture NON INTRACOM

		
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom,flagctivity
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
		IRK.idivaregisterkind,IDET.idivakind,
		PE1.competencydate,
		I.flagintracom,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PE1.competencydate) = @ayear -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
	--3)
	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- 	la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	-- Stessa insert di prima, ma per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom,flagactivity
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
		IRK.idivaregisterkind,IDET.idivakind,
		PE1.competencydate,
		I.flagintracom,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PE1.competencydate) = @ayear -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)


	--4)
	--variazioni su entrata
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom,flagactivity
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
		IRK.idivaregisterkind,IDET.idivakind,
		PE1.competencydate,
		I.flagintracom,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PE1.competencydate) = @ayear  
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)

	--5)
	--variazioni su entrata
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom,flagactivity
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
		IRK.idivaregisterkind,IDET.idivakind,
		PE1.competencydate,
		I.flagintracom,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PE1.competencydate) = @ayear 
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)


--6)
-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (escluse  note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture NON intracom
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
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
		IRK.idivaregisterkind,IDET.idivakind,
		PC1.competencydate,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PC1.competencydate) = @ayear 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
	--7) 
	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
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
		IRK.idivaregisterkind,IDET.idivakind,
		PC1.competencydate,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PC1.competencydate) = @ayear 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
	--8) 
	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture non intracom
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'S',
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
		IRK.idivaregisterkind,IDET.idivakind,
		PC1.competencydate,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PC1.competencydate) = @ayear 
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
	--9)
	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima, ma solo per le fatture INTRACOM
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 	
		I.flagintracom,
		'S',
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
		IRK.idivaregisterkind,IDET.idivakind,
		PC1.competencydate,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		and Year(PC1.competencydate) = @ayear 
		AND (IK.flag & 4) <> 0	 -- note di variazione
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)

--10)
	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
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
		 IRK.idivaregisterkind, IDET.idivakind,IDET.paymentcompetency,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE  
		I.flagdeferred = 'S'
		AND Year(IDET.paymentcompetency) = @ayear 
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
	--11) 
	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,flagvariation,	flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate,flagactivity
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv, IDET.rownum, 'S', 		
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
		IRK.idivaregisterkind,IDET.idivakind,
		NULL	--PCO.adate ---> La data non la usa mai!
		,IRK.flagactivity
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
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
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
						and Year(PCO.adate) = @ayear 
				)
		AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IRK.registerclass<>'P'
	)
	
-- 12  Integra le fatture considerate con le autofatture senza dettagli ad esse associate:

INSERT INTO #invoicedet(
	idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
	registerclass, kind,flagintracom,flagvariation,
	taxabletotal,ivagross,ivaunabatable,
	idivaregisterkind, idivakind, adate,flagactivity
	)
	(
SELECT 
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
	IRK.idivaregisterkind, M.idivakind, M.adate,IRK.flagactivity
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
JOIN ivaregisterkind IRK
			ON IRK.idivaregisterkind = IR.idivaregisterkind	
	)
	
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
DECLARE @proratarate decimal(19,6)
SELECT @proratarate = prorata 	FROM iva_prorata WHERE ayear = @ayear
SET @proratarate= isnull(@proratarate,1)
	
DECLARE @mixedrate decimal(19,6)	
SELECT @mixedrate = mixed FROM iva_mixed WHERE ayear = @ayear
SET @mixedrate= isnull(@mixedrate,1)
	

DECLARE @flagivapaybyrow char(1)
SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @ayear

--Per chi scegli di applicare il calcolo sul totale, anche il promiscuo sarà applicato sul totale.
IF (@flagivapaybyrow='N') 
BEGIN
	SET @proratarate=1 --non applica il prorata in questo caso
	SET @mixedrate = 1
END


UPDATE #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate*@mixedrate )
WHERE registerclass='A' and flagmixed='S'

UPDATE #invoicedet set ivaabatable= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@proratarate )
WHERE registerclass='A' and flagmixed='N'


UPDATE #invoicedet set ivaabatable_def= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@perc_prorata*@mixedrate )
WHERE registerclass='A' and flagmixed='S'

UPDATE #invoicedet set ivaabatable_def= CONVERT(decimal(19,2),	(ivagross-ivaunabatable)*@perc_prorata)
WHERE registerclass='A' and flagmixed='N'


UPDATE #invoicedet set ivaabatable= ivagross, 	ivaabatable_def = ivagross
WHERE registerclass='V'

UPDATE #invoicedet SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)
UPDATE #invoicedet SET ivaunabatable_def = ISNULL(ivagross,0) - ISNULL(ivaabatable_def,0)


--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
UPDATE #invoicedet set kind = registerclass,
	taxabletotal=-taxabletotal ,
	ivagross=-ivagross,
	ivaabatable=-ivaabatable,
	ivaunabatable= -ivaunabatable,
	ivaabatable_def = - ivaabatable_def,
	ivaunabatable_def = - ivaunabatable_def
 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
			) = 1

UPDATE #invoicedet set taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable,
				ivaabatable_def = - ivaabatable_def,
				ivaunabatable_def = - ivaunabatable_def
WHERE flagvariation='S'

--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoicedet set kind = 'A',
				taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable,
				ivaabatable_def = - ivaabatable_def,
				ivaunabatable_def = - ivaunabatable_def
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'

--select * from #invoicedet WHERE registerclas = 'V'
-- Tabella finale, dove sono presenti i vari tipi IVA con gli importi calcolati
	CREATE TABLE #ivakind
	(
		idivakind int,
		kind char(1),
		flagdeferred char(1),
		flagcurrent char(1),
		flagintracom char(1),
		taxabletotal_period decimal(19,2),
		ivatotal_period decimal(19,2),
		ivaunabatable_period decimal(19,2),
		ivaabatable_period decimal(19,2),
		ivaunabatable_defin_period decimal(19,2),
		ivaabatable_defin_period decimal(19,2),
		
		taxabletotal_dif_current decimal(19,2),
		ivatotal_dif_current decimal(19,2),
		ivaunabatable_dif_current decimal(19,2),
		ivaabatable_dif_current decimal(19,2),
		ivaunabatable_defin_dif_current decimal(19,2),
		ivaabatable_defin_dif_current decimal(19,2),
		
		taxabletotal_dif_prec decimal(19,2),
		ivatotal_dif_prec decimal(19,2),
		ivaunabatable_dif_prec decimal(19,2),
		ivaabatable_dif_prec decimal(19,2),
		ivaunabatable_defin_dif_prec decimal(19,2),
		ivaabatable_defin_dif_prec decimal(19,2),
		
		taxabletotal_totdif decimal(19,2),
		ivatotal_totdif decimal(19,2),
		ivaunabatable_totdif decimal(19,2),
		ivaabatable_totdif decimal(19,2),
		ivaunabatable_defin_totdif decimal(19,2),
		ivaabatable_defin_totdif decimal(19,2)
	)
	

	INSERT INTO #ivakind
	(
		idivakind,
		kind,
		flagdeferred,
		flagcurrent,
		flagintracom,
		taxabletotal_period,
		ivatotal_period,
		ivaunabatable_period,
		ivaabatable_period,
		ivaunabatable_defin_period,
		ivaabatable_defin_period
	)
	SELECT idivakind,registerclass,flagdeferred,'S',flagintracom,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable),
	SUM(ivaunabatable_def),SUM(ivaabatable_def)  
	FROM #invoicedet where flagdeferred = 'N' 
	group by idivakind,registerclass,flagdeferred,flagintracom

	INSERT INTO #ivakind
	(
		idivakind,
		kind,
		flagdeferred,
		flagcurrent,
		flagintracom,
		taxabletotal_dif_current,
		ivatotal_dif_current,
		ivaunabatable_dif_current,
		ivaabatable_dif_current,
		ivaunabatable_defin_dif_current,
		ivaabatable_defin_dif_current		
	)

	SELECT idivakind,registerclass,flagdeferred,'S',flagintracom,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable) 
	,SUM(ivaunabatable_def),SUM(ivaabatable_def)  
	FROM #invoicedet where flagdeferred = 'S' and yinv  = @ayear
	group by idivakind,registerclass,flagdeferred, flagintracom
	
	
	INSERT INTO #ivakind
	(
		idivakind,
		kind,
		flagdeferred,
		flagcurrent,
		flagintracom,
		taxabletotal_dif_prec,
		ivatotal_dif_prec,
		ivaunabatable_dif_prec,
		ivaabatable_dif_prec,
		ivaunabatable_defin_dif_prec,
		ivaabatable_defin_dif_prec		
	)

	SELECT idivakind,registerclass,flagdeferred,'N',flagintracom,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable) 
	,SUM(ivaunabatable_def),SUM(ivaabatable_def)  
	FROM #invoicedet where flagdeferred = 'S' and yinv  < @ayear
	group by idivakind,registerclass,flagdeferred, flagintracom
	
	
	--INSERT INTO #ivakind
	--(
	--	idivakind,
	--	kind,
	--	flagdeferred,
	--	flagcurrent,
	--	taxabletotal_totdif,
	--	ivatotal_totdif,
	--	ivaunabatable_totdif,
	--	ivaabatable_totdif,
	--	ivaunabatable_defin_totdif,
	--	ivaabatable_defin_totdif			
	--)

	--SELECT idivakind,kind,flagdeferred,'N',SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable) 
	--,SUM(ivaunabatable_def),SUM(ivaabatable_def)  
	--FROM #invoicedet where flagdeferred = 'T'
	--group by idivakind,kind,flagdeferred

	DECLARE @departmentname varchar(500)
	SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')


IF ((select count(*) from #ivakind)=0)
-- Se il diparimento non usa l'IVA ossia la #output è vuota deve restituire una riga vuota col nome del Dipartimento
BEGIN
        SELECT
        @departmentname as departmentname,
		@ayear AS curryear,
		@perc_prorata_provv as prorata_rate_provv,
		@perc_prorata as prorata_rate,
		@saldo_iniziale as saldo_iniziale,
		NULL as kind,
		NULL AS flagdeferred,
		NULL AS flagcurrent,
		NULL AS flagintracom,
		NULL as idivakind,-- #outtable.idivakind,
		NULL AS ivakinddescr,
		0 AS rate,
		0 AS unabatabilitypercentage,
		0 AS taxabletotal_imm, -- Imponibile (dei documenti immediati)
		0 AS ivatotal_imm, -- Iva Totale dei documenti immediati
		0 AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
		0 AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
		0 AS ivaunabatable_defin_imm, -- IVA Indetraibile prorata definitivo (dei documenti immediati)
		0 AS ivaabatable_defin_imm,   -- IVA Detraibile prorata definitivo (dei documenti immediati)
		
		0 AS taxabletotal_dif_current, -- Imponibile (dei documenti differiti divenuti immediati)
		0 AS ivatotal_dif_current, -- Iva Totale dei documenti differiti divenuti immediati
		0 AS ivaunabatable_dif_current, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
		0 AS ivaabatable_dif_current, -- IVA Detraibile (dei documenti differiti divenuti immediati)
		0 AS ivaunabatable_defin_dif_current, -- IVA Indetraibile prorata definitivo (dei documenti differiti divenuti immediati)
		0 AS ivaabatable_defin_dif_current,   -- IVA Detraibile prorata definitivo (dei documenti differiti divenuti immediati)
		
		0 AS taxabletotal_dif_prec, -- Imponibile (dei documenti differiti divenuti immediati)
		0 AS ivatotal_dif_prec, -- Iva Totale dei documenti differiti divenuti immediati
		0 AS ivaunabatable_dif_prec, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
		0 AS ivaabatable_dif_prec, -- IVA Detraibile (dei documenti differiti divenuti immediati)
		0 AS ivaunabatable_defin_dif_prec, -- IVA Indetraibile prorata definitivo (dei documenti differiti divenuti immediati)
		0 AS ivaabatable_defin_dif_prec--,   -- IVA Detraibile prorata definitivo (dei documenti differiti divenuti immediati)

		--0 AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)
		--0 AS ivatotal_totdif, -- Iva Totale dei documenti differiti
		--0 AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
		--0 AS ivaabatable_totdif, -- IVA Detraibile (dei documenti differiti)
		--0 AS ivaunabatable_defin_totdif, -- IVA Indetraibile prorata definitivo (dei documenti differiti)
		--0 AS ivaabatable_defin_totdif -- IVA Detraibile  prorata definitivo(dei documenti differiti)
END
ELSE
BEGIN
SELECT
        @departmentname as departmentname,
        @ayear AS curryear,
  		@perc_prorata_provv as prorata_rate_provv,
		@perc_prorata as prorata_rate,
		@saldo_iniziale as saldo_iniziale,
        kind as kind,
        flagdeferred,
        flagcurrent,
        flagintracom,
		ivakind.codeivakind as idivakind,-- #outtable.idivakind,
		ivakind.description AS ivakinddescr,
		ivakind.rate,
		ivakind.unabatabilitypercentage,
		SUM(ISNULL(taxabletotal_period,0)) AS taxabletotal_imm, -- Imponibile (dei documenti immediati)
		SUM(ISNULL(ivatotal_period,0)) AS ivatotal_imm, -- Iva Totale dei documenti immediati
		SUM(ISNULL(ivaunabatable_period,0)) AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
		SUM(ISNULL(ivaabatable_period,0)) AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
		SUM(ISNULL(ivaunabatable_defin_period,0)) AS ivaunabatable_defin_imm, -- IVA Indetraibile prorata definitivo(dei documenti immediati)
		SUM(ISNULL(ivaabatable_defin_period,0)) AS ivaabatable_defin_imm, -- IVA Detraibile prorata definitivo(dei documenti immediati)
		-- DIFFERITE DIVENUTE IMMEDIATE REGISTRATE IN ESERCIZIO CORRENTE
		SUM(ISNULL(taxabletotal_dif_current,0)) AS taxabletotal_dif_current, -- Imponibile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivatotal_dif_current,0))  AS ivatotal_dif_current, -- Iva Totale dei documenti differiti divenuti immediati
		SUM(ISNULL(ivaunabatable_dif_current,0)) AS ivaunabatable_dif_current, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaabatable_dif_current,0)) AS ivaabatable_dif_current, -- IVA Detraibile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaunabatable_defin_dif_current,0)) AS ivaunabatable_defin_dif_current, -- IVA Indetrabile prorata definitivo(dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaabatable_defin_dif_current,0)) AS ivaabatable_defin_dif_current, -- IVA Detraibile prorata defintivo(dei documenti differiti divenuti immediati)
		-- DIFFERITE DIVENUTE IMMEDIATE REGISTRATE IN ESERCIZI PRECEDENTI
		SUM(ISNULL(taxabletotal_dif_prec,0)) AS taxabletotal_dif_prec, -- Imponibile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivatotal_dif_prec,0))  AS ivatotal_dif_prec, -- Iva Totale dei documenti differiti divenuti immediati
		SUM(ISNULL(ivaunabatable_dif_prec,0)) AS ivaunabatable_dif_prec, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaabatable_dif_prec,0)) AS ivaabatable_dif_prec, -- IVA Detraibile (dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaunabatable_defin_dif_prec,0)) AS ivaunabatable_defin_dif_prec, -- IVA Indetrabile prorata definitivo(dei documenti differiti divenuti immediati)
		SUM(ISNULL(ivaabatable_defin_dif_prec,0)) AS ivaabatable_defin_dif_prec --, -- IVA Detraibile prorata defintivo(dei documenti differiti divenuti immediati)

		--SUM(ISNULL(taxabletotal_totdif,0)) AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)
		--SUM(ISNULL(ivatotal_totdif,0)) AS ivatotal_totdif, -- Imponibile (dei documenti differiti)
		--SUM(ISNULL(ivaunabatable_totdif,0)) AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
		--SUM(ISNULL(ivaabatable_totdif,0)) AS ivaabatable_totdif, -- IVA Detraibile (dei documenti differiti)
		--SUM(ISNULL(ivaunabatable_defin_totdif,0)) AS ivaunabatable_defin_totdif, -- IVA Indetraibile prorata definitivo(dei documenti differiti)
		--SUM(ISNULL(ivaabatable_defin_totdif,0)) AS ivaabatable_defin_totdif -- IVA Detraibile prorata definitivo (dei documenti differiti)
		FROM #ivakind
		JOIN ivakind
			ON ivakind.idivakind = #ivakind.idivakind
		group by  kind ,flagcurrent,ivakind.codeivakind,ivakind.description,ivakind.rate,ivakind.unabatabilitypercentage,flagdeferred,flagintracom
		order by kind desc, rate asc
END





END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

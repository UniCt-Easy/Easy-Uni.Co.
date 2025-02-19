
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


-- setuser'amm' inistrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_riepilogoregistro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_riepilogoregistro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [rpt_riepilogoregistro]
	@idivaregisterkind int,
	@year int,
	@startmonth int,
	@stopmonth int,
	@official char(1),
	@unified  char(1),
	@codeivaregisterkind  varchar(20),
	@split_payment char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS  BEGIN

	-- setuser 'amm'
	-- rpt_riepilogoregistro 1, 2017, 1, 12, 'N','N',null,'T'
	CREATE TABLE #ivaregisterkind (
	idivaregisterkind int,
	flagactivity int,
	registerclass char(1),
	description varchar(50)
	)

	IF (@unified ='S')  --Aggiunta Unified
	Begin
		--in questo caso in @idivaregisterkind c'� l'idivaregisterkindunified ed il codice iva del tipo iva scelto  
--		SET @idivaregisterkind = ISNULL((SELECT idivaregisterkind FROM ivaregisterkind WHERE idivaregisterkindunified = @idivaregisterkind)
--										, (SELECT idivaregisterkind FROM ivaregisterkind WHERE codeivaregisterkind = @codeivaregisterkind))

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


CREATE TABLE #invoice
(
	idinvkind int,		
	yinv int,
	ninv int,
	idivaregisterkind int,	
	registerclass char(1), --tipo registro A/V
	kind char(1), --tipo fattura A/V

	flagdeferred char(1),
	ivagross decimal(19,2),
	ivaabatable decimal(19,2),
	ivaunabatable decimal(19,2),
	taxabletotal decimal(19,2),
	idivakind int		
)
	
	-- Tabella di output dove confluiscono tutte le fatture e note di credito partecipanti alla liquidazione
	CREATE TABLE #invoicedet
	(	idinvkind int,
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
		flagintracom char(1)		
	)
	-- il segno � da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V � da cancellare la riga in vendita
	


--1)  Fatture registrate nel corso dell'anno e nel periodo di riferimento
	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagvariation,
		taxabletotal,ivagross,	ivaunabatable,
		idivakind,idivaregisterkind, flagintracom,adate
	)
	SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum, 
		case
			-- se la fattura � di vendita e soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			when (I.flagdeferred='S') then 'T'	 -- Ho spostato qui l'update che faceva successivament
			when (I.flagdeferred='N') then 'N'	
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
		IDET.idivakind,IRK.idivaregisterkind,
		I.flagintracom,I.adate
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
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 	
		YEAR(I.adate) = @year 
		AND MONTH(I.adate) BETWEEN @startmonth AND @stopmonth
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
			
	-- chiamiamo 'T' le fatture differite, a prescindere da quando vengono pagate
	--UPDATE #invoicedet set flagdeferred='T' where flagdeferred='S' --Spostata nella SELECT precedente
	
	--2)
	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- 	la cui REVERSALE associata � stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	-- SOLO per fatture NON INTRACOM
	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		I.flagintracom
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
	WHERE 
		I.flagintracom='N'
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)

 --3)
	-- Sezione 2.1 IVA Differita  - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  
	-- 	la cui REVERSALE associata � stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	-- Stessa insert di prima, ma per fatture INTRACOM

	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		I.flagintracom
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
	WHERE 
		I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	

	)

--4)
-- solo fatture NON INTRACOM
	--variazioni su entrata
	
	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		I.flagintracom
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
	WHERE I.flagintracom='N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)
	
--5)
-- Stessa insert di prima ma per fatture INTRACOM
	--variazioni su entrata
	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagvariation,		
		taxabletotal,ivagross,	
		idivaregisterkind,idivakind,adate,flagintracom
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		I.flagintracom
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
	WHERE 
		I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PE1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PE1.competencydate) = @year -- BETWEEN @datebegin AND @dateend
		AND (IK.flag & 4) <> 0	 -- note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)


	--6)
	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato � stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture NON intracom
	
	INSERT INTO #invoicedet
	(	idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		PC1.competencydate
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
	WHERE I.flagintracom='N'
		AND I.flagdeferred = 'S'
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)

	--7)
	-- Sezione 2.2 IVA Differita  - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato � stato trasmesso nel range di date fornito in input alla SP
	-- Stessa INSERT di prima ma per fatture a iva INTRACOM

	INSERT INTO #invoicedet
	(	idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		PC1.competencydate
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
	WHERE I.flagintracom<>'N' 
		AND I.flagdeferred = 'S'
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) = 0	 --salta le note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)
		

--8)
	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato � stato trasmesso nel range di date fornito in input alla SP
	-- Valuta solo le fatture non INTRACOM	
	INSERT INTO #invoicedet
	(	idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
	)
	(SELECT	
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		PC1.competencydate
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
	WHERE I.flagintracom='N' 
		AND I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) <> 0	 -- note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)


--9)
	-- Sezione 2.2 IVA Differita  VARIAZIONI - DATA MANDATO 
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato � stato trasmesso nel range di date fornito in input alla SP
	-- Stessa insert di prima ma solo per le fatture INTRACOM	
	INSERT INTO #invoicedet
	(	idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 	kind,flagintracom, flagvariation, flagmixed,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
	)
	(SELECT 
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		PC1.competencydate
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
	WHERE I.flagintracom<>'N' 
		AND	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND month(PC1.competencydate) BETWEEN @startmonth and 	@stopmonth
		and Year(PC1.competencydate) = @year 
		AND (IK.flag & 4) <> 0	 -- note di variazione
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)

-- 10)
	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoicedet
	(	
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
	)
	(SELECT 
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		 IRK.idivaregisterkind, IDET.idivakind,IDET.paymentcompetency
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
	WHERE  
		I.flagdeferred = 'S'
		AND month(IDET.paymentcompetency)  BETWEEN @startmonth and 	@stopmonth
		AND Year(IDET.paymentcompetency) = @year 
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
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
		idivaregisterkind, idivakind,adate
	)
	(SELECT	
		I.idinvkind, I.yinv, I.ninv, IDET.rownum, 
		I.flagdeferred	,  
		/*case
			-- se fattura di acquito, legge il valore
			when (IK.flag & 1)=0 then I.flagdeferred	
			-- se la fattura � soggetta a split payment, non ha senso parlare di iva differita. Quindi viene intesa come immediata. Vedi task 6507  
			when ((IK.flag & 1)<>0 and	isnull(I.flag_enable_split_payment,'N')='S') then 'N' 
			else I.flagdeferred
		end,*/
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
		NULL --PCO.adate
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
	WHERE 	I.flagdeferred = 'S'
	 	AND IDET.paymentcompetency IS NULL
	 	AND EXISTS (SELECT * FROM pettycashoperationinvoice PCOI
					JOIN pettycashoperation PCO
							ON PCO.idpettycash = PCOI.idpettycash
							AND PCO.yoperation = PCOI.yoperation
							AND PCO.noperation = PCOI.noperation 
					WHERE 	PCOI.idinvkind = I.idinvkind
							AND PCOI.yinv = I.yinv
							AND PCOI.ninv = I.ninv
							AND month(PCO.adate) BETWEEN @startmonth and 	@stopmonth
							and Year(PCO.adate) = @year  )
		and
		(@split_payment = 'T' 
			or (@split_payment='S' and isnull(I.flag_enable_split_payment,'N') = 'S') 
			or (@split_payment='N' and isnull(I.flag_enable_split_payment,'N') = 'N')	)
		AND ISNULL(IDET.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- Sta prendendo quelle a iva differita, quindi se sono di acquito, ok, ma se sono di vendita soggette a split NON le deve prendere perch� vengono intese a iva immediata e rientrano nella prima SELECT, ora sta prendendo
		-- solo quelle "veramente" differite
		and( (IK.flag & 1)=0 
			OR
			((IK.flag & 1)<>0 and isnull(I.flag_enable_split_payment,'N')='N') )
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
	)


--12) 
-- Integra le fatture considerate, con le autofatture senza dettagli ad esse associate:

	insert into #invoicedet( 
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		taxabletotal,ivagross,ivaunabatable,
		idivaregisterkind, idivakind,adate
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
			IRK.idivaregisterkind, M.idivakind, M.adate
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
		JOIN #ivaregisterkind IRK
					ON IRK.idivaregisterkind = IR.idivaregisterkind				
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)	
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
	SELECT @proratarate = prorata 	FROM iva_prorata WHERE ayear = @year
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed FROM iva_mixed WHERE ayear = @year
	set @mixedrate= isnull(@mixedrate,1)
	

	DECLARE @flagivapaybyrow char(1)
	SELECT @flagivapaybyrow= flagivapaybyrow from config WHERE ayear = @year

	--Per chi scegli di applicare il calcolo sul totale, anche il promiscuo sar� applicato sul totale.
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
	update #invoicedet set kind = registerclass,taxabletotal=-taxabletotal ,
				ivagross=-ivagross,
				ivaabatable=-ivaabatable,
				ivaunabatable= -ivaunabatable
		where registerclass<>kind -- AND flagintracom = 'N'
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
	(	idivaregisterkind int,
		idivakind int,
		taxabletotal_period decimal(19,2),
		ivatotal_period decimal(19,2),
		ivaunabatable_period decimal(19,2),
		ivaabatable_period decimal(19,2),
		taxabletotal_current decimal(19,2),
		ivatotal_current decimal(19,2),
		ivaunabatable_current decimal(19,2),
		ivaabatable_current decimal(19,2),
		taxabletotal_prec decimal(19,2),
		ivatotal_prec decimal(19,2),
		ivaunabatable_prec decimal(19,2),
		ivaabatable_prec decimal(19,2),
		taxabletotal_totdif decimal(19,2),
		ivatotal_totdif decimal(19,2),
		ivaunabatable_totdif decimal(19,2),
		ivaabatable_totdif decimal(19,2),
		kind varchar(1)

	)


	INSERT INTO #ivakind
	( 
		idivaregisterkind,
		idivakind,
		taxabletotal_period,
		ivatotal_period,
		ivaunabatable_period,
		ivaabatable_period,
		kind		
	)
	SELECT idivaregisterkind,idivakind,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable),registerclass 
	FROM #invoicedet where flagdeferred = 'N' 
	group by idivaregisterkind,idivakind, registerclass

	INSERT INTO #ivakind
	(	idivaregisterkind,
		idivakind,		taxabletotal_current,		ivatotal_current,
		ivaunabatable_current,		ivaabatable_current,		kind		
	)
	SELECT idivaregisterkind,idivakind,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable), registerclass 
	FROM #invoicedet where flagdeferred = 'S' AND yinv  = @year
	group by idivaregisterkind,idivakind, registerclass

	

	INSERT INTO #ivakind
	(	idivaregisterkind,		idivakind,		taxabletotal_prec,
		ivatotal_prec,		ivaunabatable_prec,		ivaabatable_prec,
		kind		
	)
	SELECT idivaregisterkind,idivakind,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable), registerclass 
	FROM #invoicedet where flagdeferred = 'S' AND  	yinv  < @year
	group by idivaregisterkind,idivakind, registerclass


	INSERT INTO #ivakind
	(	idivaregisterkind,		idivakind,		taxabletotal_totdif,
		ivatotal_totdif,		ivaunabatable_totdif,		ivaabatable_totdif,
		kind		
	)

	SELECT idivaregisterkind,idivakind,SUM(taxabletotal),SUM(ivagross),SUM(ivaunabatable),SUM(ivaabatable), registerclass
	FROM #invoicedet where flagdeferred = 'T'
	group by idivaregisterkind,idivakind, registerclass



	DECLARE @departmentname varchar(500)
	SET  @departmentname  = ISNULL( (SELECT TOP 1 paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @year) 
				and (stop is null or year(stop) >= @year)
				),'Manca Cfg. Parametri Tutte le stampe')



IF ((select count(*) from #ivakind)=0)
-- Se il diparimento non usa l'IVA ossia la #output � vuota deve restituire una riga vuota col nome del Dipartimento
BEGIN
    SELECT
    @departmentname as departmentname,
	@monthname AS currmonth,
	@year AS curryear,
	description AS registername,
	NULL as idivakind,-- #outtable.idivakind,
	NULL AS ivakinddescr,
	0 AS rate,
	0 AS unabatabilitypercentage,
	0 AS taxabletotal_imm, -- Imponibile (dei documenti immediati)
	0 AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
	0 AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
	0 AS taxabletotal_curr, -- Imponibile (dei documenti differiti divenuti immediati) es. corr
	0 AS ivaunabatable_curr, -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. corr
	0 AS ivaabatable_curr, -- IVA Detraibile (dei documenti differiti divenuti immediati) es. corr
	0 AS taxabletotal_prec, -- Imponibile (dei documenti differiti divenuti immediati) es. prec
	0 AS ivaunabatable_prec, -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. prec
	0 AS ivaabatable_prec, -- IVA Detraibile (dei documenti differiti divenuti immediati) es. prec
	0 AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)
	0 AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
	0 AS ivaabatable_totdif,
	' ' AS kind -- Tipologia del Registro (utile al report)
	FROM #ivaregisterkind
END
ELSE
BEGIN

	SELECT
	@departmentname as departmentname,
	@monthname AS currmonth,
	@year AS curryear,
	IRK.description AS registername,
	ivakind.codeivakind as idivakind,-- #outtable.idivakind,
	ivakind.description AS ivakinddescr,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	SUM(ISNULL(taxabletotal_period,0)) AS taxabletotal_imm, -- Imponibile (dei documenti immediati)
	SUM(ISNULL(ivaunabatable_period,0)) AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
	SUM(ISNULL(ivaabatable_period,0)) AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
	SUM(ISNULL(taxabletotal_current,0)) AS taxabletotal_curr, -- Imponibile (dei documenti differiti divenuti immediati) es. corr
	SUM(ISNULL(ivaunabatable_current,0)) AS ivaunabatable_curr, -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. corr
	SUM(ISNULL(ivaabatable_current,0)) AS ivaabatable_curr, -- IVA Detraibile (dei documenti differiti divenuti immediati) es. corr
	SUM(ISNULL(taxabletotal_prec,0)) AS taxabletotal_prec, -- Imponibile (dei documenti differiti divenuti immediati) es. prec
	SUM(ISNULL(ivaunabatable_prec,0)) AS ivaunabatable_prec, -- IVA Indetrabile (dei documenti differiti divenuti immediati) es. prec
	SUM(ISNULL(ivaabatable_prec,0)) AS ivaabatable_prec, -- IVA Detraibile (dei documenti differiti divenuti immediati) es. prec
	SUM(ISNULL(taxabletotal_totdif,0)) AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)
	SUM(ISNULL(ivaunabatable_totdif,0)) AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
	SUM(ISNULL(ivaabatable_totdif,0)) AS ivaabatable_totdif, -- IVA Detraibile (dei documenti differiti)
	ISNULL(#ivakind.kind,' ') AS kind
	FROM #ivakind
	JOIN ivakind
		ON ivakind.idivakind = #ivakind.idivakind
	JOIN #ivaregisterkind IRK
		ON IRK.idivaregisterkind = #ivakind.idivaregisterkind
	group by  IRK.description,ivakind.codeivakind,ivakind.description,ivakind.rate,ivakind.unabatabilitypercentage,#ivakind.kind

END

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

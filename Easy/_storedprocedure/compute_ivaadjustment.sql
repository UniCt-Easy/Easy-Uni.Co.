
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_ivaadjustment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_ivaadjustment]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--[compute_ivaadjustment] 2017

CREATE  PROCEDURE [compute_ivaadjustment]
	@ayear smallint
AS BEGIN

	declare @perc_prorata decimal(19,6)
	declare @perc_promiscuo decimal(19,6)
	
	select @perc_prorata= prorata from iva_prorata where ayear=@ayear+1
	select @perc_promiscuo= mixed from iva_mixed where ayear=@ayear
	
	declare @ModoCalcolo_RigaPerRiga char(1)
	select @ModoCalcolo_RigaPerRiga= isnull(flagivapaybyrow,'N') from config where ayear=@ayear



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
		flagmixed char(1),
		flagdeferred char(1),
		flagvariation char(1),
		currivagrosspayed decimal(19,2),   -- viene messo in ivatotalpayed di invoicedeferred - è poi da applicare il segno
		currivaunabatable decimal(19,2), --unabatable corrente, applicare segno
		idreg int,
		idivaregisterkind int,
		taxable decimal(19,2),
		flagactivity int,
		istituzionale char(1),
        commerciale char(1),
        promiscuo char(1),
		immediata char(1),
		acquisto char(1),
		imposta decimal(19,2),
		indetraibile decimal(19,2),
		detraibile decimal(19,2),
		indetraibile_singolo decimal(19,2)

	)
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita
	




	-- Sezione 1. Calcolo dell'IVA IMMEDIATA a Debito e a Credito
	-- Si prendono tutte le fatture con IVA immediata 
	-- 	la cui data di registrazione ricade nel range di date comunicato in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum, flagdeferred, flagmixed,
		registerclass,kind,flagintracom,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum,  'N',
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --kind		--tipo fattura (A/V)
		I.flagintracom,
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
		 ) --taxabletotal

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
	WHERE 	year(I.adate) =@ayear
		AND I.flagdeferred = 'N'
		AND idinvkind_real is null
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
	)
	  
	-- Sezione 2.1 IVA Differita a DEBITO (fatt.vendita) - DATA REVERSALE
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  (incluse note di variazione)
	-- 	la cui REVERSALE associata è stata EMESSA nel range di date fornito in input alla SP
	--		e aventi data competenza del dettaglio NULL
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --kind	
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --flagvariation
		ISNULL(IDET.tax,0),					
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_iva 
		--ON (PE1.idinc = IDET.idinc_iva AND I.flagintracom='N') OR (PE1.idinc = IDET.idinc_taxable AND I.flagintracom='S') 
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
		AND I.flagintracom='N'-- non INTRA
		AND IDET.paymentcompetency IS NULL
		AND year(PE1.competencydate)= @ayear
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
	)


-- Come la sezione precedente ma considerando solo le fatture a iva INTRACOMUNITARIA
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo	
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		ISNULL(IDET.tax,0),					
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal
		
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN proceedsemitted PE1
		ON PE1.idinc = IDET.idinc_taxable
		--ON (PE1.idinc = IDET.idinc_iva AND I.flagintracom='N') OR (PE1.idinc = IDET.idinc_taxable AND I.flagintracom='S') 
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
		AND I.flagintracom<>'N'-- INTRA	o EXTRA-UE
		AND IDET.paymentcompetency IS NULL
		AND year(PE1.competencydate)= @ayear
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
	)





	-- Sezione 2.2 IVA Differita  - DATA MANDATO
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato è stato trasmesso nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 
		kind,flagintracom,
		flagvariation,
		flagmixed,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo		
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_iva 
		--ON (PC1.idexp = IDET.idexp_iva AND I.flagintracom='N') OR (PC1.idexp = IDET.idexp_taxable AND I.flagintracom='S') 
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
		AND I.flagintracom ='N' -- non INTRA
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND year(PC1.competencydate)= @ayear
				
	)

-- Come la sezione precedente ma considerando solo le fatture a iva INTRACOMUNITARIA

	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, 
		registerclass, 
		kind,flagintracom,
		flagvariation,
		flagmixed,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo		
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

	FROM invoice I
	JOIN invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv	
	JOIN paymentcommunicated PC1
		ON PC1.idexp = IDET.idexp_taxable 
		-- ON (PC1.idexp = IDET.idexp_iva AND I.flagintracom='N') OR (PC1.idexp = IDET.idexp_taxable AND I.flagintracom='S') 
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
		AND I.flagintracom <>'N'-- INRA o EXRRA-UE
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND year(PC1.competencydate)= @ayear
				
	)
	











	
	-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv,rownum, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagvariation,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, 'S', 
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo	
		I.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, --Variazione
		ISNULL(IDET.tax,0),
		ISNULL(IDET.unabatable,0),	
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

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
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND year(IDET.paymentcompetency)= @ayear

	)
	




	
	-- Sezione 4 Contabilizzazione con FONDO ECONOMALE
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto
	-- contabilizzate mediante operazione del fondo economale la cui data contabile
	-- ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		idinvkind, yinv, ninv, rownum,flagdeferred, 
		registerclass, kind,flagintracom,flagvariation,
		flagmixed,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(SELECT
		I.idinvkind, I.yinv, I.ninv, IDET.rownum, 'S', 		
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, --Tipo		
		I.flagintracom,
		'N',
		CASE
			WHEN (IK.flag & 2) <> 0 THEN 'S'
			ELSE 'N'
		END,
		ISNULL(IDET.tax,0) ,
		ISNULL(IDET.unabatable,0),
		I.idreg,IRK.idivaregisterkind,
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,6),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

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
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
		AND IDET.paymentcompetency IS NULL
		AND exists (SELECT * FROM pettycashoperationinvoice PCOI
					JOIN pettycashoperation PCO
						ON PCO.idpettycash = PCOI.idpettycash
						AND PCO.yoperation = PCOI.yoperation
						AND PCO.noperation = PCOI.noperation 
					WHERE PCOI.idinvkind = I.idinvkind
							AND PCOI.yinv = I.yinv
							AND PCOI.ninv = I.ninv
							AND year(PCO.adate) =@ayear)
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
		registerclass,kind,flagintracom,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable
	)
	(
	   select 
		I.idinvkind,I.yinv,I.ninv, II.rownum, II.flagdeferred, II.flagmixed,
		IRK.registerclass, 
		CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END, --Tipo
		II.flagintracom,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END,  -- flagvariation
		II.currivagrosspayed,II.currivaunabatable,II.idreg,
		IRK.idivaregisterkind,II.taxable
	   from #invoice II
				join invoice I on I.idinvkind_real= II.idinvkind
								and I.yinv_real= II.yinv
								and I.ninv= II.ninv
				JOIN invoicekind IK
							ON I.idinvkind = IK.idinvkind
				JOIN ivaregister IR
							ON IR.idinvkind = I.idinvkind
								AND IR.yinv = I.yinv
								AND IR.ninv = I.ninv
				JOIN ivaregisterkind IRK
							ON IRK.idivaregisterkind = IR.idivaregisterkind				
	)

	
	--aggiusta il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	 UPDATE #invoice set currivagrosspayed=-currivagrosspayed,  
						 currivaunabatable=-currivaunabatable,
						 taxable=-taxable   
	 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass<>'P'
			) = 1

		 UPDATE #invoice set currivagrosspayed=-currivagrosspayed,  
						 currivaunabatable=-currivaunabatable,
						 taxable=-taxable  
	      where flagvariation='S'
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
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'
	

	update #invoice set flagactivity= (select flagactivity from ivaregisterkind I where I.idivaregisterkind=#invoice.idivaregisterkind)

	update #invoice set istituzionale='N', commerciale='N', promiscuo='N'				
	update #invoice set istituzionale='S' where flagactivity=1
	update #invoice set commerciale='S' where flagactivity=2
	update #invoice set promiscuo='S' where flagactivity=3


	update #invoice set flagintracom='N'			
	update #invoice set flagintracom='S' where isnull(flagintracom,'S')<>'N'

	--delete from invoice where istituzionale='S' and flagintracom='N' (questo
	delete from #invoice where istituzionale='S'  --salto tutta l'iva istituzionale	

	update #invoice set immediata='N'			
	update #invoice set immediata='S' where flagdeferred='N'

	update #invoice set acquisto='N'			
	update #invoice set acquisto='S' where registerclass='A'

	update #invoice set imposta=currivagrosspayed;
	update #invoice set indetraibile=currivaunabatable;
    
	update #invoice set indetraibile=imposta where istituzionale='S'  --superfluo ma tant'è, nel c# lo fa
	
	--acquisto promiscuo
	update #invoice set   detraibile = round((imposta - indetraibile) * @perc_promiscuo * @perc_prorata, 2)
			where acquisto='S' and promiscuo='S'


	--acquisto commerciale
	update #invoice set   detraibile = round((imposta - indetraibile)  * @perc_prorata, 2)
			where acquisto='S' and commerciale='S'


    if (@ModoCalcolo_RigaPerRiga='S')
		update #invoice set  indetraibile_singolo= imposta - detraibile
		where acquisto='S' and istituzionale='N'
	else
		update #invoice set indetraibile_singolo= indetraibile
		where acquisto='S' and istituzionale='N'
		


	--superflua
	--update #invoice set singola= imposta, 	indetraibile_singolo= singola 	where  acquisto='S' and istituzionale='S'	

	declare @acqprom_immediata decimal(19,2)
	declare @acqprom_immediata_indetr decimal(19,2)
	select @acqprom_immediata= sum(imposta) from #invoice where acquisto='S' and promiscuo='S' and immediata='S'
	select @acqprom_immediata_indetr= sum(indetraibile_singolo) from #invoice where acquisto='S' and promiscuo='S' and immediata='S'

	declare @acqcomm_immediata decimal(19,2)
	declare @acqcomm_immediata_indetr decimal(19,2)
	select @acqcomm_immediata= sum(imposta) from #invoice where acquisto='S' and commerciale='S' and immediata='S'
	select @acqcomm_immediata_indetr= sum(indetraibile_singolo) from #invoice where acquisto='S' and commerciale='S' and immediata='S'


	declare @acqprom_deferred decimal(19,2)
	declare @acqprom_deferred_indetr decimal(19,2)
	select @acqprom_deferred= sum(imposta) from #invoice where acquisto='S' and promiscuo='S' and immediata='N'
	select @acqprom_deferred_indetr= sum(indetraibile_singolo) from #invoice where acquisto='S' and promiscuo='S' and immediata='N'


	declare @acqcomm_deferred decimal(19,2)
	declare @acqcomm_deferred_indetr decimal(19,2)
	select @acqcomm_deferred= sum(imposta) from #invoice where  acquisto='S' and promiscuo='S' and immediata='N'
	select @acqcomm_deferred_indetr= sum(indetraibile_singolo) from #invoice where  acquisto='S' and commerciale='S' and immediata='N'

	declare @totale_iva_credito decimal(19,2)
	select @totale_iva_credito= sum(detraibile) from #invoice where acquisto='S' and istituzionale='N'

	declare @credito_immediato decimal(19,2)
	select @totale_iva_credito= sum(detraibile) from #invoice where acquisto='S' and  istituzionale='N' and immediata='S'
	
	declare @credito_differito decimal(19,2)
	select @credito_differito= sum(detraibile) from #invoice where acquisto='S' and  istituzionale='N' and immediata='N'

	--vendite
	 
	declare @vendite_immediata decimal(19,2)
	select @vendite_immediata= sum(imposta) from #invoice where acquisto='N' and istituzionale='N' and immediata='S'
 
	declare @vendite_deferred decimal(19,2)
	select @vendite_deferred= sum(imposta) from #invoice where acquisto='N' and istituzionale='N' and immediata='N'


	
	declare @detraibile_immediata_comm decimal(19,2)
	set @detraibile_immediata_comm=isnull(@acqcomm_immediata,0)- isnull(@acqcomm_immediata_indetr,0)

	declare @detraibile_differita_comm decimal(19,2)
	set @detraibile_differita_comm=isnull(@acqcomm_deferred,0)- isnull(@acqcomm_deferred_indetr,0)

	declare @detraibile_commerciale decimal(19,2)
	set @detraibile_commerciale = @detraibile_immediata_comm + @detraibile_differita_comm
    


	declare @detraibile_immediata_prom decimal(19,2)
	set @detraibile_immediata_prom = @acqprom_immediata - @acqprom_immediata_indetr

	declare @detraibile_differita_prom decimal(19,2)
	set @detraibile_differita_prom = @acqprom_deferred - @acqprom_deferred_indetr	

	declare @detraibile_promiscui decimal(19,2)
	set @detraibile_promiscui = @detraibile_immediata_prom + @detraibile_differita_prom


	declare @detraibile_promiscuiPOST decimal(19,2)
	set @detraibile_promiscuiPOST = @detraibile_promiscui

    if (@ModoCalcolo_RigaPerRiga='N') 
                set @detraibile_promiscuiPOST = round(@detraibile_promiscui * @perc_promiscuo, 2)

    declare @ivacredito   decimal(19,2)
	set @ivacredito = @detraibile_commerciale + @detraibile_promiscuiPOST


    if (@ModoCalcolo_RigaPerRiga='N') 
                set @totale_iva_credito = round(@ivacredito * @perc_prorata, 2)

	 declare @totale_iva_debito decimal(19,2)
	 set @totale_iva_debito = @vendite_immediata + @vendite_deferred;


	/* iva complessiva dovuta per l'anno facendo il ricalcolo con i nuovi parametri */
	/* ATTENZIONE: non considera il saldo iniziale dell'anno */
	declare @ivadelperiodo decimal(19,2)            
	set @ivadelperiodo = @totale_iva_debito - @totale_iva_credito
	

	declare @startivabalance decimal(19,2)
	select @startivabalance= startivabalance from config where ayear=@ayear

	declare @saldoiniziale decimal(19,2)
	set @saldoiniziale = - isnull(@startivabalance,0)

	declare @totale_iva_ricalcolata decimal(19,2)
	set @totale_iva_ricalcolata = isnull(@saldoiniziale,0)+isnull(@ivadelperiodo,0)
	
	--iva col vecchio calcolo
	declare @total_debit_previous decimal(19,2)
	select @total_debit_previous = SUM(totaldebit) from ivapay where yivapay=@ayear	

	--iva col vecchio calcolo
	declare @total_credit_previous decimal(19,2)
	select @total_credit_previous = SUM(totalcredit) from ivapay where yivapay=@ayear	

	declare @total_previous decimal(19,2)
	set @total_previous = isnull(@saldoiniziale,0)+isnull(@total_debit_previous,0)-isnull(@total_debit_previous,0)

	declare @totaldiff decimal(19,2)
	set @totaldiff= @totale_iva_ricalcolata - @total_previous



	--select 11, * from #invoice  where ninv = 28
	-- La select inale visualizza tutte le fatture che hanno IVA lorda diversa da zero
	-- oppure IVA netta diversa da zero ma immediata.	
	SELECT #invoice.*,ivaregisterkind.codeivaregisterkind, ivaregisterkind.description,
				ivaregisterkind.flagactivity  FROM #invoice
		JOIN ivaregisterkind
			ON ivaregisterkind.idivaregisterkind = #invoice.idivaregisterkind
		

	WHERE currivagrosspayed <> 0

	ORDER BY idinvkind,yinv,ninv,rownum,flagdeferred
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



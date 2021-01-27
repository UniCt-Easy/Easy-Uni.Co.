
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_ivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_ivapay]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
-- compute_ivapay '2014/02/01','2015/03/01'

CREATE  PROCEDURE [compute_ivapay]
	@datebegin datetime,
	@dateend datetime
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
		taxable decimal(19,2)
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
		idreg,idivaregisterkind,taxable
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
		 CONVERT(decimal(19,10),I.exchangerate) *
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
	WHERE 	I.adate BETWEEN @datebegin AND @dateend
		AND I.flagdeferred = 'N'
		AND idinvkind_real is null
		AND IRK.registerclass<>'P'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
		--AND IRK.flagactivity <> 1 --non prende i registri istituzionali
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
		idreg,idivaregisterkind,taxable
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
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

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
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
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
		idreg,idivaregisterkind,taxable
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
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

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
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
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
		idreg,idivaregisterkind,taxable
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
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE 
		I.flagdeferred = 'S'
		AND IDET.paymentcompetency BETWEEN @datebegin AND @dateend		
		AND IRK.registerclass<>'P'		
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
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
		idreg,idivaregisterkind,taxable
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
		ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) --taxabletotal

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
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(idet.flagbit,0) & 4) = 0
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
		idreg,idivaregisterkind,taxable
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
		IRK.idivaregisterkind,II.taxable
	   from #invoice II
				join invoice I on I.idinvkind_real= II.idinvkind		and I.yinv_real= II.yinv	and I.ninv= II.ninv
				JOIN invoicekind IK		ON I.idinvkind = IK.idinvkind	
				JOIN ivaregister IR		ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
				JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind				
	)

	
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

	
	--cambia il segno di currivagrosspayed,currivaunabatable in base a registerclass/kind/flagvariation
	update #invoice set currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoice.idinvkind
					and RK.registerclass<>'P'
			) = 1

		--AND flagintracom = 'N'
	


	update #invoice set currivagrosspayed=-currivagrosspayed,
						currivaunabatable=-currivaunabatable,
						taxable=-taxable
		 where flagvariation='S'			--serve solo per le intrastat istituz. acquisti
		

	--select 11, * from #invoice  where ninv = 28
	-- La select inale visualizza tutte le fatture che hanno IVA lorda diversa da zero
	-- oppure IVA netta diversa da zero ma immediata.	
	SELECT #invoice.*,ivaregisterkind.codeivaregisterkind, ivaregisterkind.description,
				ivaregisterkind.flagactivity, ID.idepexp,ID.idepacc
	 FROM #invoice
		JOIN ivaregisterkind
			ON ivaregisterkind.idivaregisterkind = #invoice.idivaregisterkind
		JOIN invoicedetail ID on 
				ID.idinvkind=#invoice.idinvkind and ID.yinv=#invoice.yinv and ID.ninv= #invoice.ninv and ID.rownum= #invoice.rownum	
	WHERE currivagrosspayed <> 0

	ORDER BY idinvkind,yinv,ninv,rownum,flagdeferred
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


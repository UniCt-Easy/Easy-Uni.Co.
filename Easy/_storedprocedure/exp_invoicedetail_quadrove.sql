
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicedetail_quadrove]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicedetail_quadrove]
GO
 
 --[exp_invoicedetail_quadrove] 2017, 'A',12
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--[exp_invoicedetail_quadrove] 2016, 'A',1
--[exp_invoicedetail_quadrove] 2016, 'A',2
--[exp_invoicedetail_quadrove] 2016, 'A',3
--[exp_invoicedetail_quadrove] 2016, 'A',4
--[exp_invoicedetail_quadrove] 2016, 'A',5
--[exp_invoicedetail_quadrove] 2016, 'A',6
--[exp_invoicedetail_quadrove] 2016, 'A',7
--[exp_invoicedetail_quadrove] 2016, 'A',8
--[exp_invoicedetail_quadrove] 2016, 'A',9
--[exp_invoicedetail_quadrove] 2016, 'A',10
--[exp_invoicedetail_quadrove] 2016, 'A',11
--[exp_invoicedetail_quadrove] 2016, 'A',12

--[exp_invoicedetail_quadrove] 2016, 'D',1
--[exp_invoicedetail_quadrove] 2016, 'D',2
--[exp_invoicedetail_quadrove] 2016, 'D',3
--[exp_invoicedetail_quadrove] 2016, 'D',4
--[exp_invoicedetail_quadrove] 2016, 'D',5
--[exp_invoicedetail_quadrove] 2016, 'D',6
--[exp_invoicedetail_quadrove] 2016, 'D',7
--[exp_invoicedetail_quadrove] 2016, 'D',8
--[exp_invoicedetail_quadrove] 2016, 'D',9
--[exp_invoicedetail_quadrove] 2016, 'D',10
--[exp_invoicedetail_quadrove] 2016, 'D',11
--[exp_invoicedetail_quadrove] 2016, 'D',12


CREATE  PROCEDURE [exp_invoicedetail_quadrove]
	@ayear   int,
	@kind    char(1),  -- tipo visualizzazione (A--> Aggregata, D-->Dettagliata)
	@opkind  int		-- operazioni da considerare (vedi tabella)
AS BEGIN
	--1-	Operazioni imponibili distinte per aliquota
	--2-	Esportazioni beni
	--3-	Cessioni intracomunitarie beni
	--4-	Cessioni beni verso San Marino
	--5-	Operazioni esenti (art. 10)
	--6-	Operazioni non soggette artt. 7-7-septies
	--7-	Operazioni reverse charge
	--8-	Operazioni con imposta esigibile in anni successivi
	--9-	Operazioni verso PA art. 17-ter
	--10-	Operazioni anni precedenti con IVA esigibile nell''anno
	--11-	Operazioni non imponibili a seguito di dichiarazione di intento
    --12-	Altre operazioni non imponibili

	-- Classificazione usata per scorporare le varie voci
	--'Esportazioni beni - Esp. 2' '001' 
	--'Cessioni intracomunitarie beni - Esp. 3' '002' 
	--'Cessioni beni verso San Marino - Esp. 4' '003' 
	--'Operazioni esenti (art. 10) - Esp. 5' '004', 
	--'Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005

	-- Tabella di output dove confluiscono tutte le fatture  
	--4) Nell'Esportazione 1-Operazioni imponibili distinte per aliquota DETTAGLIATA 
	--vengono fuori anche le fatture intra e extra-ue. Era stato chiesto "4.	
	--Vanno esclusi tutti i dettagli fattura vendita che hanno le condizioni riportate nei punti successivi". 
	--Quindi vanno escluse le fatture intra, le extra-ue, le fatture emesse a san marino, quelle con flag reverse charge
	----  classificazione tipo IVA IVAKIND
DECLARE @codeclassivakind varchar(20)
SET @codeclassivakind = '016_CLASSIVAKIND'  
 
DECLARE @idclassivakind int
SELECT  @idclassivakind = idsorkind FROM sortingkind WHERE codesorkind = @codeclassivakind

	CREATE TABLE #invoice
	(
		label_tipo_esportazione varchar (150), 
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		adate datetime, 
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
		ivakind varchar(50),
		ivaperc decimal(19,2),
		idnation int,
		idcity int,
		opkind char(1),
		idinc_iva int, 
		paymentcompetency datetime
	)
	--Condizioni fatture da comprendere nell’esportazione: 
	--1.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anno di dichiarazione e flag IVA immediata
	--2.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anno di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
	--3.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anni precedenti a quello di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
	IF (@opkind = 1)
	BEGIN
	
	--sp_help invoicedetail
	-- il segno è da cambiare se flagdeferred oppure se kind<>registerclass
	-- inoltre per le fatture non intracom con la doppia presenza A/V è da cancellare la riga in vendita

	-- Sezione 2 IVA Immediata a DEBITO (fatt.vendita) - DATA REVERSALE
	--1.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anno di dichiarazione e flag IVA immediata
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum, adate, paymentcompetency, flagdeferred, flagmixed,
		registerclass,kind,flagintracom,flagsplit,flagvariation,
		currivagrosspayed,currivaunabatable,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'1-	Operazioni imponibili distinte per aliquota',
		I.idinvkind,I.yinv,I.ninv,  IDET.rownum, I.adate, IDET.paymentcompetency,'N',
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation	
		CASE
			WHEN (IK.flag & 4) = 0 THEN  ISNULL(IDET.unabatable,0)
			ELSE -ISNULL(IDET.unabatable,0) 
		END,  	
		I.idreg,IRK.idivaregisterkind,
		CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		  )
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 )
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
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
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear --  BETWEEN @datebegin AND @dateend
		AND I.flagdeferred = 'N'
		AND idinvkind_real is null
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND ISNULL(IVA.rate,0) * 100 in (4.00 , 10.00, 22.00)
		-- CASI DA ESCLUDERE PERCHè COMPRESI NELLE ALTRE ESPORTAZIONI
		AND NOT ( 
			--'Esportazioni beni - Esp. 2' '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) OR 

			--'Escludo Cessioni intracomunitarie beni - Esp. 3' '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. 4' '003' 
			( ((I.flagintracom) = 'X' OR (I.flagintracom) = 'S')  AND  
			ISNULL(SOR.sortcode,'') IN ('002','003') )  OR   

			--'Escludo Operazioni esenti (art. 10) - Esp. 5' '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005
			ISNULL(SOR.sortcode,'') IN ('004','005') OR 

			--7-	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo --8-	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo '9-	Operazioni verso PA art. 17-ter'
			OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					--AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)
		) 
	)
	  
	-- Sezione 2 IVA Differita a DEBITO (fatt.vendita) - DATA REVERSALE
	--2.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anno di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'1-	Operazioni imponibili distinte per aliquota',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate,IDET.paymentcompetency,'S', 
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
		CASE
			WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
			ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation				
		I.idreg,IRK.idivaregisterkind,

		CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		  )
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 )
		END, --flagvariation	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_iva 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear AND	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND YEAR(PE1.competencydate) = @ayear   -- BETWEEN @datebegin AND @dateend
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) * 100 in (4.00 , 10.00, 22.00)
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. 2' '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) OR 

			--'Escludo Cessioni intracomunitarie beni - Esp. 3' '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. 4' '003' 
			( ((I.flagintracom) = 'X' OR (I.flagintracom) = 'S')  AND  
			ISNULL(SOR.sortcode,'') IN ('002','003') )  OR   

			--'Escludo Operazioni esenti (art. 10) - Esp. 5' '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005
			ISNULL(SOR.sortcode,'') IN ('004','005') OR 

			--7-	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo --8-	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo '9-	Operazioni verso PA art. 17-ter'
			OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					--AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)
		) 
			 
	)

-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acqusito, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv,rownum, adate, paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit, flagvariation,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable,idinc_iva
	)
	(SELECT
		'1-	Operazioni imponibili distinte per aliquota',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate, IDET.paymentcompetency,'S', 
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
		CASE
			WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
			ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation	
		CASE
			WHEN (IK.flag & 4) = 0 THEN  ISNULL(IDET.unabatable,0)
			ELSE -ISNULL(IDET.unabatable,0) 
		END,  
		I.idreg,IRK.idivaregisterkind,
			CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		  )
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 )
		END, --TAXABLETOTAL	,
		 IDET.idinc_iva

	FROM invoice I
	join registry R on R.idreg = I.idreg 
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK			ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 
		I.flagdeferred = 'S'
		AND YEAR(IDET.paymentcompetency)= @ayear 	
		AND IRK.registerclass = 'V'		
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) * 100 in (4.00 , 10.00, 22.00)
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. 2' '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) OR 

			--'Escludo Cessioni intracomunitarie beni - Esp. 3' '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. 4' '003' 
			( ((I.flagintracom) = 'X' OR (I.flagintracom) = 'S')  AND  
			ISNULL(SOR.sortcode,'') IN ('002','003') )  OR   

			--'Escludo Operazioni esenti (art. 10) - Esp. 5' '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005
			ISNULL(SOR.sortcode,'') IN ('004','005') OR 

			--7-	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo --8-	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo '9-	Operazioni verso PA art. 17-ter'
			OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					--AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)
		) 
 

	)
	



 
 -- Sezione 3 IVA Differita a DEBITO (fatt.vendita) - DATA REVERSALE
	--3.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
	--con esercizio anni precedenti a quello di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'1-	Operazioni imponibili distinte per aliquota',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
			WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
			ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
			CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		  )
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 )
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_iva 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) < @ayear AND	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND YEAR(PE1.competencydate) = @ayear   -- BETWEEN @datebegin AND @dateend
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) * 100 in (4.00 , 10.00, 22.00)
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. 2' '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) OR 

			--'Escludo Cessioni intracomunitarie beni - Esp. 3' '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. 4' '003' 
			( ((I.flagintracom) = 'X' OR (I.flagintracom) = 'S')  AND  
			ISNULL(SOR.sortcode,'') IN ('002','003') )  OR   

			--'Escludo Operazioni esenti (art. 10) - Esp. 5' '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005
			ISNULL(SOR.sortcode,'') IN ('004','005') OR 

			--7-	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo --8-	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo '9-	Operazioni verso PA art. 17-ter'
			OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					--AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)
		) 
	)


	
	END


	-- 2. Esportazione Beni
	--	AND InvDet.intra12operationkind = 'B'--> Beni
	/*
	Colonne esportazione modalità A: Imponibile, Imposta
	Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
	Condizioni fatture da comprendere nell’esportazione: 
	1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con flag intracom =X escluso San marino(*)
	2. Determino i dettagli che sono vendite di Beni da una specifica classificazione sul tipo aliquota
	(*)Deve escludere i dettagli che hanno come anagrafica un residente in San Marino
		e
	   non hanno un Tipo aliquota IVA classificato con codice 001 della classificazione 016_CLASSIVAKIND.
	*/

	
--	4-	Cessioni beni verso San Marino
--Colonne esportazione modalità A: Imponibile, Imposta 
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura  
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione, che contengono un’anagrafica con Stato estero SAN MARINO
-- 2. Determino i dettagli che sono vendite di Beni da una specifica classificazione sul tipo aliquota
	IF ((@opkind = 2) OR (@opkind = 4)) --2. Esportazione Beni o 4-	Cessioni beni verso San Marino
	BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione, idinvkind, yinv, ninv, rownum, adate, paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
		)
		(SELECT
			CASE @opkind
				WHEN 2 THEN '2. Esportazione Beni'
				ELSE  '4-	Cessioni beni verso San Marino'
			END, 
			I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate, IDET.paymentcompetency, 'S', 
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
			CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
			END, --flagvariation				
			I.idreg,IRK.idivaregisterkind,
			CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		  )
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 )
		END, --TAXABLETOTAL	
			 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind

		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'V'
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			AND (IK.flag & 1) <> 0 -- VENDITA
			AND (I.flagintracom) = 'X' -- In seguito escludo San Marino ciclando sull'indirizzo di residenza cliente estero
			AND ( SOR.sortcode = '001' OR -- '2. Esportazione Beni'
				  SOR.sortcode = '003'  ) --'4-	Cessioni beni verso San Marino'
		)
		DECLARE  @idinvkind INT,
	     @yinv INT,
         @ninv INT ,
		 @adate datetime,
		 @idreg INT,
		 @idnation INT,
		 @idcity INT
DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT I.idinvkind,
	   I.yinv,
       I.ninv,
       I.adate,
	   I.idreg
FROM #invoice I
 
FOR READ ONLY
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO  @idinvkind,
	  @yinv,
      @ninv,
      @adate,
	  @idreg
WHILE @@FETCH_STATUS = 0
BEGIN 
SET @idnation = NULL
set @idcity  = NULL

EXECUTE [get_nation_city_address] 
   @idreg
  ,@adate
  ,@idnation OUTPUT
  ,@idcity OUTPUT

print @idnation-- 48 STATO DI SAN MARINO
--	IF (@idnation <> 48) 
	BEGIN
	--  CICLO CON CURSORE PER DETERMINARE IL PAESE DI RESIDENZA DEL CLIENTE/FORNITORE
		UPDATE #invoice SET idnation = @idnation, idcity = @idcity  
		WHERE idinvkind = @idinvkind AND  yinv = @yinv AND ninv = @ninv 
	END
	FETCH NEXT FROM rowcursor
	INTO @idinvkind,
		 @yinv,
         @ninv,
         @adate,
	     @idreg
END 
DEALLOCATE rowcursor
IF (@opkind = 2) 
BEGIN
	DELETE FROM #invoice WHERE idnation = 48   -- escludo San Marino
	and idinvkind not in (select I.idinvkind from invoicesorting I -- non hanno un Tipo aliquota IVA classificato con codice 001 della classificazione 016_CLASSIVAKIND.
									join sorting s
										on S.idsor = I.idsor AND S.idsorkind = @idclassivakind
									where S.sortcode = '001')	
END
ELSE -- (@opkind = 4) 
BEGIN
	DELETE FROM #invoice WHERE idnation <>  48 -- solo vendite verso San Marino
END
 
END


--	3-	Cessioni intracomunitarie beni
--Colonne esportazione modalità A: Imponibile, Imposta
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione: 
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con flag intracom =I
	IF (@opkind = 3) --3-	Cessioni intracomunitarie beni 
	BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
		)
		(SELECT
			'3-	Cessioni intracomunitarie beni',
			I.idinvkind, I.yinv, I.ninv, IDET.rownum,I.adate,IDET.paymentcompetency, 'S', 
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
			CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
			END, --flagvariation					
			I.idreg,IRK.idivaregisterkind,
			CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			  )
				ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			 )
			END, --TAXABLETOTAL	
			 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'V'
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			AND (IK.flag & 1) <> 0 -- VENDITA
			AND (I.flagintracom) = 'S' 
			AND SOR.sortcode = '002' -- 'Cessioni intracomunitarie beni - Esp. 3' '002' 
		)
	END

	 
	 

 
--	5-	Operazioni esenti (art. 10)
--Colonne esportazione modalità A: Imponibile, Imposta
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione e 
--con un Tipo aliquota classificato con un determinato codice che stabiliremo
-- al momento non esiste una tabella di classificazione dle tipo iva ivakind sorting



IF (@opkind = 5) -- 5-	Operazioni esenti (art. 10)
BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate, paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
		)
		(SELECT
			'5-	Operazioni esenti (art. 10)',
			I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate,IDET.paymentcompetency, 'S', 
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
			CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
			END, --flagvariation					
			I.idreg,IRK.idivaregisterkind,
			CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			  )
				ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			 )
			END, --TAXABLETOTAL	
			 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'V'
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			AND (IK.flag & 1) <> 0 -- VENDITA
			AND SOR.sortcode in ('004')   --'Operazioni esenti (art. 10) - Esp. 5' '004', 
		)
END
--6-	Operazioni non soggette artt. 7-7-septies
--Colonne esportazione modalità A: Imponibile, Imposta
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota 
-- classificato con un determinato codice che stabiliremo
-- al momento non esiste una tabella di classificazione del tipo iva


IF (@opkind = 6) --6-	Operazioni non soggette artt. 7-7-septies
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'6-	Operazioni non soggette artt. 7-7-septies',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			  )
				ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			 )
			END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND SOR.sortcode in ('005') --'Operazioni non soggette artt. 7-7-septies - Esp. 6' ,'005
	)
 
 END
-- 7-	Operazioni reverse charge
--Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione che hanno il flag reverse charge = S

if (@opkind = 7)
-- 7-	Operazioni reverse charge
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'7-	Operazioni reverse charge',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
		WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND ISNULL(flag_reverse_charge, 'N') = 'S'
		-- Escludo le fatture di quest'anno  comprese in altri punti precedenti
		AND NOT (ISNULL(SOR.sortcode,'') in ('001','002','003','004','005'))

		--escludo --8-	Operazioni con imposta esigibile in anni successivi
		AND  
		(
				EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
				AND YEAR(PE.competencydate) = @ayear
				)  
				OR	I.flagdeferred = 'N'
		)
		--escludo '9-	Operazioni verso PA art. 17-ter'
		AND   
		(
				ISNULL(flag_enable_split_payment, 'N') = 'N'
				--OR ISNULL(R.flagbankitaliaproceeds,'N') = 'N'

		)

)
END

IF (@opkind = 8) --8-	Operazioni con imposta esigibile in anni successivi
--8-	Operazioni con imposta esigibile in anni successivi
--Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione, ad IVA differita,
--non incassate al 31/12 e quindi non entrate in liquidazione nell'anno in corso.
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		
		'8-	Operazioni con imposta esigibile in anni successivi',  
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate,IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
		WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear  AND	I.flagdeferred = 'S'
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = IDET.idinc_iva 
		AND YEAR(PE.competencydate) = @ayear
		)  
		-- Escludo le fatture di quest'anno  comprese in altri punti
		AND NOT (ISNULL(SOR.sortcode,'') in ('001','002','003','004','005'))
		--7-	escludo Operazioni reverse charge
		AND ISNULL(flag_reverse_charge, 'N') = 'N'
		-- Escludo i dettagli che  rientrano nell'esportazione 9, le fatture split payment o i cui fornitori non sono enti pubblici
		AND   
		(
				ISNULL(flag_enable_split_payment, 'N') = 'N'
				--OR ISNULL(R.flagbankitaliaproceeds,'N') = 'N'
		)
)
END

IF (@opkind = 9) --9-	Operazioni verso PA art. 17-ter
--9-	Operazioni verso PA art. 17-ter
BEGIN
--Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio anno dichiarazione, che hanno il flag enable split payment= S


	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate, paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'9-	Operazioni verso soggetti di cui all''art. 17-ter',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
		WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND ISNULL(flag_enable_split_payment, 'N') = 'S'
		-- escludendo anagrafiche senza il flag Regolarizza riscossioni presso Banca d'Italia
		-- AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'  task 12482

		-- Escludo le fatture di quest'anno comprese in altri punti
		AND NOT (ISNULL(SOR.sortcode,'') in ('001','002','003','004','005','012'))
		--7-	escludo Operazioni reverse charge
		AND ISNULL(flag_reverse_charge, 'N') = 'N'
		--escludo --8-	Operazioni a iva differita con imposta esigibile in anni successivi
		AND  
		(
				EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc in (IDET.idinc_taxable , IDET.idinc_iva) 
				AND YEAR(PE.competencydate) = @ayear
				)  
				OR	I.flagdeferred = 'N'
		)

)
END

IF (@opkind = 10) --10-	Operazioni anni precedenti con IVA esigibile nell'anno
--10-	Operazioni anni precedenti con IVA esigibile nell'anno
--Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
--Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
--Condizioni fatture da comprendere nell’esportazione:
--1.	Dettagli fatture di vendita con esercizio precedente a quello in corso, ad IVA differita,
--ad IVA, incassate nell'anno in corso e quindi entrate in liquidazione nell'anno in corso
-- Vanno esclusi i dettagli fatture di vendita con flag “Applica Split payment” ed emesse ad anagrafiche con flag “Regolarizzazione riscossioni presso TPS”, nella scheda Altri dati dell’Anagrafica
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idinc_iva
	)
	(SELECT
		'10-	Operazioni anni precedenti con IVA esigibile nell''anno',
		I.idinvkind, I.yinv, I.ninv,IDET.rownum, I.adate,IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
		WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
			ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			)
		END, --TAXABLETOTAL	
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN proceedsemitted PE			ON PE.idinc = IDET.idinc_iva
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN registry R
		on R.idreg = I.idreg
	WHERE 	YEAR(I.adate) < @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND YEAR(PE.competencydate) = @ayear  
		and I.flagdeferred='S'
		and (I.flag_enable_split_payment<>'S')  --12482      rimuovo NOT ( isnull(R.flagbankitaliaproceeds,'N')='S' and ... = 'S')
)
END


--Condizioni fatture da comprendere nell’esportazione:
--	1. Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota classificato con codice 006 della classificazione 016_CLASSIVAKIND.

IF (@opkind = 11) 
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivakind,ivaperc,idinc_iva
	)
	(SELECT
		'11- Operazioni non imponibili lettere d'' intento',
			I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			  )
				ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			 )
			END, --TAXABLETOTAL	
			IVA.description,
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0  --Abbuono passivo: Il dettaglio fattura è stato inserito per rappresentare una riduzione del ricavo a causa dei costi di incasso detratti dalla banca. Non fa parte effettivamente della fattura
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND SOR.sortcode in ('006') -- 11- Operazioni non imponibili a seguito di dichiarazione di intento
	)

END


--Condizioni fatture da comprendere nell’esportazione:
--	1. Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota classificato con codice 006 della classificazione 016_CLASSIVAKIND.

IF (@opkind = 12) 
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivakind,ivaperc,idinc_iva
	)
	(SELECT
		'12- Altre operazioni non imponibili',
			I.idinvkind, I.yinv, I.ninv,IDET.rownum,I.adate, IDET.paymentcompetency, 'S', 
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
		CASE
				WHEN (IK.flag & 4) = 0 THEN ISNULL(IDET.tax,0)
				ELSE -ISNULL(IDET.tax,0)
		END, --flagvariation					
		I.idreg,IRK.idivaregisterkind,
		CASE
			WHEN (IK.flag & 4) = 0 THEN ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			  )
				ELSE -ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
			 )
			END, --TAXABLETOTAL	
			IVA.description,
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idinc_iva
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'V'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0  --Abbuono passivo: Il dettaglio fattura è stato inserito per rappresentare una riduzione del ricavo a causa dei costi di incasso detratti dalla banca. Non fa parte effettivamente della fattura
		AND (IK.flag & 1) <> 0 -- VENDITA
		AND SOR.sortcode in ('007') ---1. Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota classificato con codice 007 della classificazione 016_CLASSIVAKIND.
	)

END
	--1-	Operazioni imponibili distinte per aliquota
	--2-	Esportazioni beni
	--3-	Cessioni intracomunitarie beni
	--4-	Cessioni beni verso San Marino
	--5-	Operazioni esenti (art. 10)
	--6-	Operazioni non soggette artt. 7-7-septies
	--7-	Operazioni reverse charge
	--8-	Operazioni con imposta esigibile in anni successivi
	--9-	Operazioni verso PA art. 17-ter
	--10-	Operazioni anni precedenti con IVA esigibile nell''anno
	--11-	Operazioni non imponibili a seguito di dichiarazione di intento
	--12-	Altre operazioni non imponibili

IF (@kind = 'D') --dettagliata
 SELECT   label_tipo_esportazione as 'Tipo',
	invoicedetailview.invoicekind as 'Fattura',  --!! invoicekind ce l'ho 
	invoicedetailview.yinv as  'Eserc. Fattura' ,
	invoicedetailview.ninv as 'Num. Fattura' ,
	invoicedetailview.registry as 'Cliente/Fornitore',--!!
	invoicedetailview.cf as 'CF Cliente/Fornitore', --!! 
	invoicedetailview.p_iva as 'P. IVA Cliente/Fornitore',--!! 
	CASE
		WHEN ISNULL(registry.flagbankitaliaproceeds, 'N' ) = 'S' THEN 'SI'
		ELSE 'NO'
	END as 'Regolarizza disposizioni presso TPS',
	CASE 
		WHEN invoicedetailview.flagbuysell = 'A' THEN 'Acquisto'
		ELSE 'Vendita'
	END as 'Acquisto / Vendita',
	CASE 
		WHEN invoicedetailview.flagvariation = 'S' THEN 'SI'
		ELSE 'NO'
	END  as 'Nota di Variazione',
	CASE 
		WHEN #invoice.flagdeferred = 'N' THEN 'Immediata'
		WHEN #invoice.flagdeferred = 'S' and #invoice.yinv < @ayear 
										 and EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = #invoice.idinc_iva 
													and YEAR(PE.competencydate) = @ayear)  
		THEN 'Vendita  anni prec. diven. esigibili'
		WHEN #invoice.flagdeferred = 'S' and #invoice.yinv = @ayear 
										 and EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = #invoice.idinc_iva 
													and YEAR(PE.competencydate) = @ayear)  
		THEN 'Vendita anno corr. diven. esigibili'
		WHEN #invoice.flagdeferred = 'S' and #invoice.yinv = @ayear 
										 and NOT EXISTS (SELECT * FROM proceedsemitted PE WHERE PE.idinc = #invoice.idinc_iva 
													and YEAR(PE.competencydate) = @ayear)   
		THEN 'Vendita  anno corr. non ancora esigibili'
		ELSE null
	END as 'Esigibilità',
	CASE 
		WHEN #invoice.flagsplit = 'S' THEN 'SI'
		ELSE 'NO'
	END as 'Split Payment',
	invoicedetailview.rownum as 'Num. riga', 
	invoicedetailview.detaildescription as 'Descrizione', --!! 
	invoicedetailview.number as 'Q.tà ',  --!! 
	invoicedetailview.description as 'Descrizione Fattura', --!!
	CASE WHEN (invoicedetailview.flagvariation = 'N') THEN invoicedetailview.taxable ELSE -invoicedetailview.taxable
	END as 'Importo Unitario', --!! 
	CASE WHEN (invoicedetailview.flagvariation = 'N') THEN invoicedetailview.taxable_euro ELSE -invoicedetailview.taxable_euro
	END as 'Imponibile totale',  --!! 
	#invoice.ivaperc as 'Aliquota IVA',  --!! 
	invoicedetailview.ivakind as 'Tipo IVA', --!! 
	CASE WHEN (invoicedetailview.flagvariation = 'N') THEN invoicedetailview.iva_euro ELSE -invoicedetailview.iva_euro
	END as 'Iva',  --!! 
	CASE WHEN (invoicedetailview.flagvariation = 'N')  THEN invoicedetailview.rowtotal ELSE -invoicedetailview.rowtotal
	END as 'Totale riga', --!!
	invoicedetailview.competencystart as 'Inizio comp.',  --!! 
	invoicedetailview.competencystop as 'Fine comp.', --!! 
	invoicedetailview.va3typedescription as 'Quadro VF26', --!! 
	invoicedetailview.code as 'Cod.Nomenclatura', 
	invoicedetailview.intrastatcode as 'Nomenclatura',  --!! 
	invoicedetailview.intrastatmeasure as 'Unità di misura', --!! 
	invoicedetailview.intrastatoperationkind as 'Beni/Servizi', --!! 
	invoicedetailview.servicecode as 'Cod.Servizi', --!!
	invoicedetailview.intrastatservice as 'Servizi', --!!
	invoicedetailview.supplymethodcode as 'Cod.Erogazione', --!!
	invoicedetailview.intrastatsupplymethod as 'Erogazione',  --!! 
	invoicedetailview.toincludeinpaymentindicator as 'Includi in Indicatore Tempest. dei Pagamenti', --!!
	invoicedetailview.touniqueregister as 'Protocolla nel Registro Unico', --!! 
	invoicedetailview.ymov_taxable as 'Eserc. Contab. Imponibile', --!!
	invoicedetailview.nmov_taxable as 'Num. Contab. Imponibile',  --!!
	invoicedetailview.ymov_iva as 'Eserc. Contab. Iva',  --!!
	invoicedetailview.nmov_iva as 'Num. Contab. Iva', --!!
	invoicedetailview.yepexp as 'Eserc. Imp. Budget', --!!
	invoicedetailview.nepexp as 'Num. Imp. Budget', --!!
	invoicedetailview.yepacc as 'Eserc. Accert. Budget',  --
	invoicedetailview.nepacc as 'Num. Accert. Budget'--!! 
 FROM #invoice
 JOIN invoicedetailview  ON #invoice.idinvkind = invoicedetailview.idinvkind
 AND    #invoice.yinv = invoicedetailview.yinv
 AND    #invoice.ninv = invoicedetailview.ninv
 AND    #invoice.rownum = invoicedetailview.rownum
 JOIN registry ON registry.idreg = #invoice.idreg
 ORDER BY invoicedetailview.invoicekind,  invoicedetailview.yinv, 
		  invoicedetailview.ninv,invoicedetailview.rownum
ELSE   -- (@kind = 'A')  --aggregata
BEGIN
	 IF ( @opkind  = 1)
	 BEGIN
		 SELECT  
			 ivaperc AS 'Aliquota',
			 label_tipo_esportazione as 'Tipo',
			 SUM(taxable) AS 'Imponibile',
			 SUM(currivagrosspayed) AS 'Imposta'    
		 FROM #invoice 
		GROUP BY label_tipo_esportazione,ivaperc 
		ORDER BY ivaperc
	 END
 
	 IF ( @opkind IN (2,3,4,5,6))
	 BEGIN
		 SELECT  label_tipo_esportazione as 'Tipo',
		 SUM(taxable) AS 'Imponibile',
		 SUM(currivagrosspayed) AS 'Imposta'     
		 FROM #invoice
		 GROUP BY label_tipo_esportazione
	 END

	IF ( @opkind IN (7,8,9,10))
	 BEGIN
		 SELECT  label_tipo_esportazione as 'Tipo',
		 SUM(taxable)  AS 'Ammontare complessivo (Totale imponibile)'
		 FROM #invoice
		 GROUP BY label_tipo_esportazione
	 END
	  IF ( @opkind IN (11,12))
	 BEGIN
		 SELECT  
		 	 label_tipo_esportazione as 'Tipo',
			 ivakind AS 'Tipo IVA',
			 ivaperc AS 'Aliquota',
			 SUM(taxable) AS 'Imponibile',
			 SUM(currivagrosspayed) AS 'Imposta'    
		 FROM #invoice 
		GROUP BY label_tipo_esportazione,ivaperc,ivakind
		ORDER BY ivakind,ivaperc
	 END
 END
--sp_help invoice
--SP_HELP IVAKIND

 END
 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

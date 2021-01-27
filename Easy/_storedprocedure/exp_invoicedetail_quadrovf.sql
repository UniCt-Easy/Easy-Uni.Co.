
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicedetail_quadrovf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicedetail_quadrovf]
GO
 
 -- [exp_invoicedetail_quadrovf] 2018, 'A',10
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
CREATE  PROCEDURE [exp_invoicedetail_quadrovf]
	@ayear   int,
	@kind    char(1),  -- tipo visualizzazione (A--> Aggregata, D-->Dettagliata)
	@opkind  int		-- operazioni da considerare (vedi tabella)
AS BEGIN
	--				QUADRO VE				=>			QUADRO VF
	--1.	Operazioni imponibili distinte per aliquota = idem
	--2.	Esportazioni beni 					=> 10.Ripartizione totale acquisti e importazioni	
	--3.	Cessioni intracomunitarie beni				=> 7. Acquisti di beni IntraUE VF26
	--4.	Cessioni beni verso San Marino				=> 9. acquisti San Mario
	--5.	Operazioni esenti (art. 10)				=> 3 - Acquisti esenti art.10 e importazioni non soggette VF16
	--7.	Operazioni reverse charge				=> 8) Acquisti di beni ExtraUE
	--8.	Operazioni con imposta esigibile in anni successivi	=> 5) Acquisti registrati nell'anno con detrazione differita ad anni successivi VF21
	--9.	Operazioni verso PA art. 17-ter				=> 4) Acquisti da sogg. regimi agevolativi VF17
	--10.	Operazioni anni precedenti con IVA esigibile nell''anno	=> 6. Acquisti anni precedenti con detrazione nell'anno corrente VF22
	--6.	Operazioni non soggette artt. 7-7-septies 		=> 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15
	--11.	Operazioni non imponibili a seguito di dichiarazione di intento=> 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15
   	--12.	Altre operazioni non imponibili				=> 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15	

DECLARE @codeclassivakind varchar(20)
SET @codeclassivakind = '016_CLASSIVAKIND'  
 
DECLARE @idclassivakind int
SELECT  @idclassivakind = idsorkind FROM sortingkind WHERE codesorkind = @codeclassivakind
--select  * from sortingkind where codesorkind = '016_CLASSIVAKIND'  
--select  * from sorting where idsorkind = 66
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
		idexp_iva int, 
		paymentcompetency datetime,
		va3type char(1)
	)
	-- QUADRO VE
		--Condizioni fatture da comprendere nell’esportazione: 
		--1.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
		--con esercizio anno di dichiarazione e flag IVA immediata
		--2.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
		--con esercizio anno di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
		--3.	Dettagli fatture di vendita, con aliquota 4% o 10% o 22%, 
		--con esercizio anni precedenti a quello di dichiarazione, flag IVA differita e incassate nell’esercizio di dichiarazione
	-- QUADRO VF
		--1 - Operazioni imponibili distinte per aliquota  VF1-VF13
		--Indicare gli acquisti commerciali (da fornitori IT, EU ed EXTRAUE) assoggettati ad imposta (% aliquota iva diversa da 0), per i quali si è verificata
		-- l’esigibilità ed è stato esercitato, nel 2017, il diritto alla detrazione. Vanno inclusi anche gli acquisti effettuati negli anni precedenti e per i quali l’imposta è divenuta esigibile.
		--Nei righi devono essere compresi anche gli acquisti e le importazioni per i quali è stato applicato il meccanismo del reverse-charge (% aliquota iva è diversa da 0).

		--Condizioni fatture comprese nell’esportazione:
		--1. Dettagli fatture di acquisto con data contabile anno di dichiarazione e flag IVA immediata
		--2. Dettagli fatture di acquisto con data contabile anno di dichiarazione e flag IVA differita, pagate nell’esercizio di dichiarazione
		--3. Dettagli fatture di acquisto con data contabile anni precedenti a quello di dichiarazione e flag IVA differita, pagate nell’esercizio di dichiarazione.
		--Risultano esclusi dall’esportazione 1 tutti i dettagli fattura aventi Tipo aliquota IVA a percentuale 0,00.
	IF (@opkind = 1)
	BEGIN
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
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
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
		 IDET.idexp_iva,
		 IDET.va3type
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
	WHERE 	YEAR(I.adate) = @ayear 
		AND I.flagdeferred = 'N'-- Iva immediata
		AND idinvkind_real is null
		AND IRK.registerclass = 'A' -- Acquisto
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (IK.flag & 1) = 0 -- Acquisto
		AND ISNULL(IVA.rate,0) <>0

		and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	


		-- CASI DA ESCLUDERE PERCHè COMPRESI NELLE ALTRE ESPORTAZIONI
		AND NOT ( 
			--'Esportazioni beni - Esp. VE.2/VF.10 '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) 

			OR 
			--'Escludo Cessioni intracomunitarie beni - Esp. VE.3/VF.7 '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. VE.4/VF.9 '003' 
			( 	( I.flagintracom = 'X' OR  I.flagintracom = 'S')  AND  	ISNULL(SOR.sortcode,'') IN ('002','003')	)  
			
			OR   
			--'Escludo Operazioni esenti (art. 10) - Esp. VE.5/VF.3 '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. VE.6/VF.2 '005
			ISNULL(SOR.sortcode,'') IN ('004','005','006','007','008','009') OR 

			-- VE.7/VF.8	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo VE.8/VF.5	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo VE.9/VF.4 -	Operazioni verso PA art. 17-ter'
			/*OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					AND
					ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)*/
		) 
	)

	-- Sezione 2 IVA Differita - DATA MANDATO
	--2.	Dettagli fatture di acquito, con aliquota <>0 
	--con esercizio anno di dichiarazione, flag IVA differita e pagate nell’esercizio di dichiarazione
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
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
		 IDET.idexp_iva,
		 IDET.va3type
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN paymentemitted PE1		ON PE1.idexp = IDET.idexp_iva 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear AND	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND YEAR(PE1.competencydate) = @ayear  
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) >0
		and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. VE.2/VF.10 '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) 

			OR 
			--'Escludo Cessioni intracomunitarie beni - Esp. VE.3/VF.7 '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. VE.4/VF.9 '003' 
			( 	( I.flagintracom = 'X' OR  I.flagintracom = 'S')  AND  	ISNULL(SOR.sortcode,'') IN ('002','003')	)  
			
			OR   
			--'Escludo Operazioni esenti (art. 10) - Esp. VE.5/VF.3 '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. VE.6/VF.2 '005
			ISNULL(SOR.sortcode,'') IN ('004','005','006','007','008','009') OR 

			-- VE.7/VF.8	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo VE.8/VF.5	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo VE.9/VF.4 -	Operazioni verso PA art. 17-ter'
			/*OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					AND
					ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)*/
		) 
			 
	)


-- Sezione 3  IVA Differita a DEBITO (fatt.vendita) E A CREDITO (fatt. acquisto)- DATA COMPETENZA DETTAGLIO
	-- Vengono inseriti tutti i dettagli delle fatture di acquisto, vendita e note di variazione
	-- la cui data di compentenza (paymentcompetency) ricade nel range di date fornito in input alla SP
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv,rownum, adate, paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit, flagvariation,
		currivagrosspayed,
		currivaunabatable,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva, va3type
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
		 ISNULL(IVA.rate,0) * 100,
		 IDET.idexp_iva,
		 IDET.va3type
		 
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
		AND IRK.registerclass = 'A'		
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) >0
		and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. VE.2/VF.10 '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) 

			OR 
			--'Escludo Cessioni intracomunitarie beni - Esp. VE.3/VF.7 '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. VE.4/VF.9 '003' 
			( 	( I.flagintracom = 'X' OR  I.flagintracom = 'S')  AND  	ISNULL(SOR.sortcode,'') IN ('002','003')	)  
			
			OR   
			--'Escludo Operazioni esenti (art. 10) - Esp. VE.5/VF.3 '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. VE.6/VF.2 '005
			ISNULL(SOR.sortcode,'') IN ('004','005','006','007','008','009') OR 

			-- VE.7/VF.8	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo VE.8/VF.5	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo VE.9/VF.4 -	Operazioni verso PA art. 17-ter'
			/*OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					AND
					ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)*/
		) 
 	)

 -- Sezione 3 IVA Differita - DATA MANDATO
	--3.	Dettagli fatture di acquisto, con aliquota <>0
	--con esercizio anni precedenti a quello di dichiarazione, flag IVA differita e pagate nell’esercizio di dichiarazione
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva, va3type
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
		 IDET.idexp_iva,
		 IDET.va3type
	FROM invoice I
	join registry R on R.idreg = I.idreg 
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN paymentemitted PE1		ON PE1.idexp = IDET.idexp_iva 
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	LEFT OUTER JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	LEFT OUTER JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) < @ayear AND	I.flagdeferred = 'S'
		AND IDET.paymentcompetency IS NULL
		AND YEAR(PE1.competencydate) = @ayear  
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND ISNULL(IVA.rate,0) >0
		and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		-- CASI DA ESCLUDERE PERCHè COMPRESI NEI PUNTI SUCCESSIVI
		AND NOT ( 
			--'Esportazioni beni - Esp. VE.2/VF.10 '001' 
			(ISNULL(SOR.sortcode,'') = '001' ) 

			OR 
			--'Escludo Cessioni intracomunitarie beni - Esp. VE.3/VF.7 '002' 
			--'Escludo Cessioni beni verso San Marino - Esp. VE.4/VF.9 '003' 
			( 	( I.flagintracom = 'X' OR  I.flagintracom = 'S')  AND  	ISNULL(SOR.sortcode,'') IN ('002','003')	)  
			
			OR   
			--'Escludo Operazioni esenti (art. 10) - Esp. VE.5/VF.3 '004', 
			--'Escludo Operazioni non soggette artt. 7-7-septies - Esp. VE.6/VF.2 '005
			ISNULL(SOR.sortcode,'') IN ('004','005','006','007','008','009') OR 

			-- VE.7/VF.8	escludo Operazioni reverse charge
			ISNULL(flag_reverse_charge, 'N') = 'S'

			--escludo VE.8/VF.5	Operazioni con imposta esigibile in anni successivi
			OR   
			(
					NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
					AND YEAR(PE.competencydate) = @ayear
					)  
					AND 	I.flagdeferred = 'S'
			)
			--escludo VE.9/VF.4 -	Operazioni verso PA art. 17-ter'
			/*OR   
			(
					ISNULL(flag_enable_split_payment, 'N') = 'S'
					AND
					ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

			)*/
		) 
	)
	END

	 	 
/*
QUADRO VE
	6.	Operazioni non soggette artt. 7-7-septies
		Colonne esportazione modalità A: Imponibile, Imposta
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
		Condizioni fatture da comprendere nell’esportazione:
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota 
		 classificato con un determinato codice che stabiliremo
		 al momento non esiste una tabella di classificazione del tipo iva
	11.
		Condizioni fatture da comprendere nell’esportazione:
		1. Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota classificato con codice 006 della classificazione 016_CLASSIVAKIND.
	12.
		Condizioni fatture da comprendere nell’esportazione:
		1. Dettagli fatture di vendita con esercizio anno dichiarazione e con un Tipo aliquota classificato con codice 006 della classificazione 016_CLASSIVAKIND.

QUADRO VF
	2. Acquisti non imponibili, non soggetti, altri regimi speciali VF15
		L’esportazione conterrà tutte le operazioni commerciali non imponibili, non soggette e regimi speciali (beni usati, attività agricole connesse).

		Condizioni fatture comprese nell’esportazione:
		Dettagli fatture di acquisto commerciale (da fornitori IT, UE, EXTRAUE) con data contabile anno dichiarazione e con un Tipo aliquota classificato 
		con codice 005 + codice 006 + codice 007 della classificazione 016_CLASSIVAKIND
*/

--	VE 6.	Operazioni non soggette artt. 7-7-septies 						=> VF 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15
--	VE 11.	Operazioni non imponibili a seguito di dichiarazione di intento	=> VF 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15
--  VE 12.	Altre operazioni non imponibili									=> VF 2 - Acquisti non imponibili, non soggetti, altri regimi speciali VF15	


IF (@opkind = 2) 
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
	)
	(SELECT
		'2-	Acquisti non imponibili, non soggetti, altri regimi speciali VF15',
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
		 IDET.idexp_iva,
		 IDET.va3type
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
	JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
	WHERE 	YEAR(I.adate) = @ayear
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		--RIMOSSO  and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		AND (IK.flag & 1) =0 -- Acquisto
		AND SOR.sortcode in ('005','006','007') --'Operazioni non soggette artt. 7-7-septies ( Esp. 6' ,'005)
		-- Operazioni non imponibili a seguito di dichiarazione di intento(006)
		-- Dettagli fatture di vendita con esercizio anno dichiarazione (007)
	)
  END

  
 /*
 QUADRO VE
	5.	Operazioni esenti (art. 10)
			Colonne esportazione modalità A: Imponibile, Imposta
			Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
			Condizioni fatture da comprendere nell’esportazione:
			1.	Dettagli fatture di vendita con esercizio anno dichiarazione e 
			con un Tipo aliquota classificato con un determinato codice che stabiliremo
			al momento non esiste una tabella di classificazione dle tipo iva ivakind sorting
QUADRO VF
	3. Acquisti esenti art.10 e importazioni non soggette VF16
		Acquisti all’interno esenti art.10 (codice 004), acquisti intracomunitari esenti (art. 42, comma 1, d.l. 331/93 (codice 008)  e importazioni non soggette all’imposta (codice 009) (art. 68, esclusa la lett. a):  campioni gratuiti di modico valore;  ogni altra importazione definitiva di beni la cui cessione è esente dall'imposta o non vi è soggetta a norma dell'articolo 72; la reintroduzione di beni nello stato originario, da parte dello stesso soggetto che li aveva esportati, sempre che ricorrano le condizioni per la franchigia doganale; l'importazione di beni donati ad enti pubblici ovvero ad associazioni riconosciute o fondazioni aventi esclusivamente finalita' di assistenza, beneficenza, educazione, istruzione, studio o ricerca scientifica, nonche' quella di beni donati a favore delle popolazioni colpite da calamita' naturali o catastrofi dichiarate tali ai sensi della legge 8 dicembre 1970, n.996; le importazioni dei beni indicati nel terzo comma, lettera l) dell'art. 2; le importazioni di gas mediante un sistema di gas naturale o una rete connessa a un tale sistema, ovvero di gas immesso da una nave adibita al trasporto di gas in un sistema di gas naturale o in una rete di gasdotti a monte, di energia elettrica, di calore o di freddo mediante reti di riscaldamento o di raffreddamento.

		Condizioni fatture comprese nell’esportazione:
		Dettagli fatture di acquisto commerciale (da fornitori IT, UE, EXTRAUE) con data contabile anno dichiarazione e
		 con un Tipo aliquota classificato con codice 004 + 008 + 009 della classificazione 016_CLASSIVAKIND.
 */
-- VE 5. Operazioni esenti (art. 10)		=> VF: 3. Acquisti esenti art.10 e importazioni non soggette VF16

IF (@opkind = 3) 
BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate, paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
		)
		(SELECT
			'3. Acquisti esenti art.10 e importazioni non soggette VF16',
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
		 IDET.idexp_iva,
		 IDET.va3type
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'A'
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			--RIMOSSO  and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
			AND IRK.flagactivity  = 2      --> 2 - attività commerciale
			AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
			AND (IK.flag & 1) = 0 -- ACQUISTO
			AND SOR.sortcode in ('004','008','009')   -- Operazioni esenti (art. 10) - Esp.5E - Esp.3F
		)
END


  /*
QUADRO VE
	9.	Operazioni verso PA art. 17-ter
		Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
		Condizioni fatture da comprendere nell’esportazione:
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione, che hanno il flag enable split payment= S
QUADRO VF
	4. Acquisti da sogg. regimi agevolativi VF17
		Condizioni fatture comprese nell’esportazione:
		Dettagli fatture di acquisto commerciali con data contabile anno dichiarazione e con un Tipo aliquota classificato con 
		codice 010 (Regime del vantaggio DL 98/2011) + codice 011 (Regime forfettario L 190/2014) della classificazione 016_CLASSIVAKIND.
*/
--	VE 9.	Operazioni verso PA art. 17-ter				=> VF 4. Acquisti da sogg. regimi agevolativi VF17
IF (@opkind = 4) 
BEGIN


	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate, paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva, va3type
	)
	(SELECT
		'4 - Acquisti da sogg. regimi agevolativi VF17',
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
		 IDET.idexp_iva,
		 IDET.va3type
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
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		--RIMOSSO and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		AND (IK.flag & 1) = 0 -- Acquisti
		AND ISNULL(SOR.sortcode,'') in ('010','011')
		--RIMOSSO AND ISNULL(flag_enable_split_payment, 'N') = 'S'
		-- escludendo anagrafiche senza il flag Regolarizza riscossioni presso Banca d'Italia
		--RIMOSSO AND ISNULL(R.flagbankitaliaproceeds,'N') = 'S'

		--7-	escludo Operazioni reverse charge
		--RIMOSSO AND ISNULL(flag_reverse_charge, 'N') = 'N'
		--escludo -- VE 8.Operazioni a iva differita con imposta esigibile in anni successivi
		--			VF 5. Acquisti registrati nell'anno con detrazione differita ad anni successivi VF21
		AND  
		(
				EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp in (IDET.idexp_taxable , IDET.idexp_iva) 
				AND YEAR(PE.competencydate) = @ayear
				)  
				OR	I.flagdeferred = 'N'
		)

)
END


/*
QUADRO VE
	8.	Operazioni con imposta esigibile in anni successivi
	Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
	Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
	Condizioni fatture da comprendere nell’esportazione:
	1.	Dettagli fatture di vendita con esercizio anno dichiarazione, ad IVA differita,
	non incassate al 31/12 e quindi non entrate in liquidazione nell'anno in corso.
QUADRO VF
	5. Acquisti registrati nell'anno con detrazione differita ad anni successivi VF21
	Condizioni fatture comprese nell’esportazione:
	• Dettagli fatture di acquisto commerciale con data contabile anno dichiarazione, ad IVA differita, non pagate al 31/12 dell'anno dichiarazione.
*/

-- VE 8.Operazioni con imposta esigibile in anni successivi => VF 5. Acquisti registrati nell'anno con detrazione differita ad anni successivi VF21
IF (@opkind = 5) 
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
	)
	(SELECT
		
		'5-	Acquisti registrati nell''anno con detrazione differita ad anni successivi VF21',  
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
		 IDET.idexp_iva,
		 IDET.va3type
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
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		--RIMOSSO and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		AND (IK.flag & 1) = 0 -- Acquisti
		AND NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
		AND YEAR(PE.competencydate) = @ayear
		)  
		-- Escludo le fatture di quest'anno  comprese in altri punti
		AND NOT (ISNULL(SOR.sortcode,'') in ('001','002','003','004','005','006','007','008','009'))
		--7-	escludo Operazioni reverse charge
		--RIMOSSO AND ISNULL(flag_reverse_charge, 'N') = 'N'
		-- Escludo i dettagli che  rientrano nell'esportazione VE 9/VF 4, le fatture split payment o i cui fornitori non sono enti pubblici
		/*AND   
		(
				ISNULL(flag_enable_split_payment, 'N') = 'N'
				OR
				ISNULL(R.flagbankitaliaproceeds,'N') = 'N'
		)*/
)
END


/*
QUADRO VE
	10.	Operazioni anni precedenti con IVA esigibile nell'anno
	Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
	Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
	Condizioni fatture da comprendere nell’esportazione:
	1.	Dettagli fatture di vendita con esercizio precedente a quello in corso, ad IVA differita,
	ad IVA, incassate nell'anno in corso e quindi entrate in liquidazione nell'anno in corso
	Vanno esclusi i dettagli fatture di vendita con flag “Applica Split payment” ed emesse ad anagrafiche con flag “Regolarizzazione riscossioni presso TPS”, nella scheda Altri dati dell’Anagrafica
QUADRO VF
	6. Acquisti anni precedenti con detrazione nell'anno corrente VF22
	Condizioni fatture comprese nell’esportazione:
	• Dettagli fatture di acquisto commerciale con data contabile < anno dichiarazione, ad IVA differita, pagate nell'anno dichiarazione.

 */
--	VE 10.	Operazioni anni precedenti con IVA esigibile nell''anno	=> VF 6. Acquisti anni precedenti con detrazione nell'anno corrente VF22
IF (@opkind = 6) 
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency,  flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
	)
	(SELECT
		'6-	Acquisti anni precedenti con detrazione nell''anno corrente VF22',
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
		 IDET.idexp_iva,
		 IDET.va3type
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN paymentemitted PE			ON PE.idexp = IDET.idexp_iva
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
	JOIN registry R
		on R.idreg = I.idreg
	WHERE 	YEAR(I.adate) < @ayear
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		--RIMOSSO and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		AND (IK.flag & 1) = 0 -- Acquisto
		AND YEAR(PE.competencydate) = @ayear  
		and I.flagdeferred='S'
		-- and not(isnull(R.flagbankitaliaproceeds,'N')='S' and*I.flag_enable_split_payment='S')
)
END


/*
	QUADRO VE
	 3.	Cessioni intracomunitarie beni
		Colonne esportazione modalità A: Imponibile, Imposta
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
		Condizioni fatture da comprendere nell’esportazione: 
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con flag intracom =I
	QUADRO VF
	7. Acquisti di beni IntraUE VF26
		Condizioni fatture comprese nell’esportazione:
		 Dettagli fatture di acquisto commerciale con data contabile anno dichiarazione, da fornitori 
		 IntraUE (fatture con pallino su Fattura Intracomunitaria) e pallino su BENI nella scheda Intrastat del dettaglio.
*/

-- VE : 3.	Cessioni intracomunitarie beni	=>	VF: 7. Acquisti di beni IntraUE VF26 
	IF (@opkind = 7) 
	BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
		)
		(SELECT
			'7. Acquisti di beni IntraUE VF26', 
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
		 IDET.idexp_iva,
		 IDET.va3type
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		--JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		--JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind
		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'A'
			--RIMOSSO and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
			AND IRK.flagactivity  = 2      --> 2 - attività commerciale
			AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
			AND IDET.intrastatoperationkind='B' ---<<< beni
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			AND (IK.flag & 1) = 0 -- acquisti
			AND (I.flagintracom) = 'S' 
			-- AND SOR.sortcode = '002' -- Cessioni/acquisti intracomunitarie beni - Esp. 3
		)
	END

 /*
 QUADRO VE
	7.	Operazioni reverse charge
		Colonne esportazione modalità A: Ammontare complessivo (Totale imponibile)
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
		Condizioni fatture da comprendere nell’esportazione:
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione che hanno il flag reverse charge = S
QUADRO VF
	8. Acquisti di beni ExtraUE VF26
		Per gestire questa casistica occorre modificare la sezione QuadroVF del dettaglio fattura. Se e solo se la fattura è extraue e commerciale, 
		se si abilita l’opzione (altri acquisti e importazioni) (solo per chi gestisce il VF task 12392) 
		invoicedetail.VA3Type:A   l’opzione deve essere splittata in:  a) altri acquisti e importazioni beni  b) altri acquisti e importazioni servizi.
		Condizioni fatture comprese nell’esportazione:
		• Dettagli fatture di acquisto commerciale con data contabile anno dichiarazione, da fornitori ExtraUE, con le opzioni  
		invoicedetail.VA3Type:S, invoicedetail.VA3Type:N, invoicedetail.VA3Type:R e invoicedetail.VA3Type:A b)
	
*/
-- VE 7-	Operazioni reverse charge => VF 8. Acquisti di beni ExtraUE
if (@opkind = 8)
BEGIN
	INSERT INTO #invoice
	(
		label_tipo_esportazione,idinvkind, yinv, ninv, rownum,adate,paymentcompetency, flagdeferred, flagmixed,
		registerclass, kind,flagintracom,flagsplit,flagvariation,		
		currivagrosspayed,
		idreg,idivaregisterkind,taxable,ivaperc,idexp_iva, va3type
	)
	(SELECT
		'8-	Acquisti di beni ExtraUE',
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
		 IDET.idexp_iva,
		 IDET.va3type
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
		AND IRK.registerclass = 'A'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (I.flagintracom) = 'X' --> Extra UE
		AND IRK.flagactivity  = 2      --> 2 - attività commerciale
		AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
		AND (IK.flag & 1) = 0 -- Acquisto
		AND IDET.va3type in ('N','R','S')
		-- Escludo le fatture di quest'anno  comprese in altri punti precedenti
		AND NOT (ISNULL(SOR.sortcode,'') in ('001','002','003','004','005', '006','007','008','009'))
		--escludo : 	8.	Operazioni con imposta esigibile in anni successivi	=> 5) Acquisti registrati nell'anno con detrazione differita ad anni successivi VF21
		AND  
		(
				EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = IDET.idexp_iva 
				AND YEAR(PE.competencydate) = @ayear
				)  
				OR	I.flagdeferred = 'N'
		)
)

-- exec 	 [exp_invoicedetail_quadrovf] 2017, 'D', 8
END
/*
	QUADRO VE 2 e 4
	2. Esportazione Beni

		Colonne esportazione modalità A: Imponibile, Imposta
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura
		Condizioni fatture da comprendere nell’esportazione: 
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione e con flag intracom =X escluso San marino(*)
		2. Determino i dettagli che sono vendite di Beni da una specifica classificazione sul tipo aliquota
		(*)Deve escludere i dettagli che hanno come anagrafica un residente in San Marino
			e
		   non hanno un Tipo aliquota IVA classificato con codice 001 della classificazione 016_CLASSIVAKIND.
	4.	Cessioni beni verso San Marino
		Colonne esportazione modalità A: Imponibile, Imposta 
		Colonne esportazione modalità B: Vedi campi elenco Dettagli fattura  
		Condizioni fatture da comprendere nell’esportazione:
		1.	Dettagli fatture di vendita con esercizio anno dichiarazione, che contengono un’anagrafica con Stato estero SAN MARINO
		2. Determino i dettagli che sono vendite di Beni da una specifica classificazione sul tipo aliquota

	VE : 2.Esportazioni beni 					VF : 10.Ripartizione totale acquisti e importazioni	
	VE : 4.Cessioni beni verso San Marino		VF : 9. acquisti San Mario

	QUADRO VF
	9. Acquisti di beni da San Marino
		Condizioni fatture comprese nell’esportazione:
		Come esportazione 8, con anagrafiche residenti a San Marino.
		NB Le anagrafiche residenti a San Marino spesso sono inserite come ExtraUE. In tal caso non devono essere considerate nell’esportazione 8.
		L’esportazione restituirà dati solo se in configurazione annuale è presente l’opzione Gestisci VF.

	10. Ripartizione totale acquisti e importazioni
		Estrarre i dettagli fatture di acquisto (IT, UE e ExtraUE) con data contabile anno dichiarazione e riportare l'informazione 
		presente nella scheda QuadroVF del dettaglio (Beni ammortizzabili, Beni strumentali non ammortizzabili, Beni destinati alla rivendita, Altri acquisti e importazioni).
*/

	IF ((@opkind = 9) OR (@opkind = 10)) 
	BEGIN
		INSERT INTO #invoice
		(
			label_tipo_esportazione, idinvkind, yinv, ninv, rownum, adate, paymentcompetency, flagdeferred, flagmixed,
			registerclass, kind,flagintracom,flagsplit,flagvariation,		
			currivagrosspayed,
			idreg,idivaregisterkind,taxable,ivaperc,idexp_iva,va3type
		)
		(SELECT
			CASE @opkind
				WHEN 10 THEN '10. Ripartizione totale acquisti e importazioni'
				ELSE  '9. Acquisti di beni da San Marino'
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
		 IDET.idexp_iva,
		 IDET.va3type
		FROM invoice I
		join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
		JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
		JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
		JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
		JOIN ivakind IVA ON IVA.idivakind = IDET.idivakind
		left outer JOIN ivakindsorting IVASOR ON IVA.idivakind = IVASOR.idivakind 
		left outer JOIN sorting SOR ON SOR.idsor = IVASOR.idsor AND idsorkind = @idclassivakind

		WHERE 	YEAR(I.adate) = @ayear
			AND IRK.registerclass = 'A'
			AND ISNULL(IDET.rounding,'N') <>'S'
			and (isnull(IDET.flagbit,0) & 4) = 0
			and IDET.va3type is not null
			AND (IK.flag & 1) = 0 --ACQUISTO
			and IVA.idivataxablekind not in (5,6) --> ESCLUSI i dettagli con aliquota iva con tipo imposizione = 5 - FUORI CAMPO e 6 -ESCLUSE)
			AND IRK.flagactivity  = 2      --> 2 - attività commerciale
			AND ((ISNULL(IVA.flag,0)&6) <> 0) -->  Aliquota iva con flag Commerciale e\o promiscuo (indipendentemente se è flaggato anche Istituzionale)	
			--- attenzione se '10. Ripartizione totale acquisti e importazioni' le fatture possono essere (IT, UE e ExtraUE)  come specificato nell'analisi 
			AND ((I.flagintracom) = 'X' OR @opkind = 10) -- In seguito escludo San Marino ciclando sull'indirizzo di residenza cliente estero
			AND ( SOR.sortcode is null or SOR.sortcode = '001' OR -- Esportazioni beni - Esp. 2
				  SOR.sortcode = '003'  ) -- Cessioni/Acquisti beni da/verso San Marino - Esp.4E - Esp.9F
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

--IF (@opkind = 2) 
--BEGIN
--	DELETE FROM #invoice WHERE idnation = 48   -- escludo San Marino
--	and idinvkind not in (select I.idinvkind from invoicesorting I -- non hanno un Tipo aliquota IVA classificato con codice 001 della classificazione 016_CLASSIVAKIND.
--									join sorting s
--										on S.idsor = I.idsor AND S.idsorkind = @idclassivakind
--									where S.sortcode = '001')	
--END
--ELSE -- (@opkind = 9) 
--BEGIN
--	DELETE FROM #invoice WHERE idnation <>  48 -- solo vendite verso San Marino
--END


IF (@opkind = 9) 
BEGIN
	DELETE FROM #invoice WHERE idnation <>  48 -- solo vendite verso San Marino
END
ELSE 
BEGIN
	DELETE FROM #invoice WHERE idnation = 48   -- escludo San Marino
	and idinvkind not in (select I.idinvkind from invoicesorting I -- non hanno un Tipo aliquota IVA classificato con codice 001 della classificazione 016_CLASSIVAKIND.
									join sorting s
										on S.idsor = I.idsor AND S.idsorkind = @idclassivakind
									where S.sortcode = '001')	
END
 
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
										 and EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = #invoice.idexp_iva 
													and YEAR(PE.competencydate) = @ayear)  
		THEN 'Acquisti  anni prec. diven. detraibili'
		WHEN #invoice.flagdeferred = 'S' and #invoice.yinv = @ayear 
										 and EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = #invoice.idexp_iva 
													and YEAR(PE.competencydate) = @ayear)  
		THEN 'Acquisti anno corr. diven. detraibili'
		WHEN #invoice.flagdeferred = 'S' and #invoice.yinv = @ayear 
										 and NOT EXISTS (SELECT * FROM paymentemitted PE WHERE PE.idexp = #invoice.idexp_iva 
													and YEAR(PE.competencydate) = @ayear)   
		THEN 'Acquisti  anno corr. non ancora detraibili'
		ELSE null
	END as 'Detraibilità',
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
	invoicedetailview.va3typedescription as 'Quadro VF',
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
			 SUM(currivagrosspayed) AS 'Imposta',
			 CASE va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN 'Altri acquisti e importazioni'
			END    as 'Quadro VF'
		FROM #invoice 
		GROUP BY label_tipo_esportazione,ivaperc,va3type 
		ORDER BY ivaperc
	 END
 
	 IF ( @opkind IN (2,3,4,5,6))
	 BEGIN
		 SELECT  label_tipo_esportazione as 'Tipo',
		 SUM(taxable) AS 'Imponibile',
		 SUM(currivagrosspayed) AS 'Imposta',
		  CASE va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN 'Altri acquisti e importazioni'
			END      as 'Quadro VF' 
		 FROM #invoice
		 GROUP BY label_tipo_esportazione,va3type
	 END

	IF ( @opkind IN (7,8,9,10))
	 BEGIN
		 SELECT  label_tipo_esportazione as 'Tipo',
		 SUM(taxable)  AS 'Ammontare complessivo (Totale imponibile)',
		   CASE va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN 'Altri acquisti e importazioni'
			END    as 'Quadro VF'
		 FROM #invoice
		 GROUP BY label_tipo_esportazione, va3type
	 END
	  IF ( @opkind IN (11,12))
	 BEGIN
		 SELECT  
		 	 label_tipo_esportazione as 'Tipo',
			 ivakind AS 'Tipo IVA',
			 ivaperc AS 'Aliquota',
			 SUM(taxable) AS 'Imponibile',
			 SUM(currivagrosspayed) AS 'Imposta' ,
			  CASE va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN 'Altri acquisti e importazioni'
			END    as 'Quadro VF'
		 FROM #invoice 
		GROUP BY label_tipo_esportazione,ivaperc,ivakind,va3type
		ORDER BY ivakind,ivaperc
	 END
 END

 END
 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

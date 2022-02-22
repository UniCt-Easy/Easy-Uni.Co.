
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_liq_iva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_liq_iva]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm'
--exp_check_liq_iva 2016,1,'E'
CREATE PROCEDURE [exp_check_liq_iva]
	@esercizio int,
	@trimestre int   ,
		@exigible_or_deductible  char(1)

AS  BEGIN

	DECLARE @meseinizio int
DECLARE @mesefine int
 
 SELECT 
  @meseinizio= case 
   when @trimestre = 1 then 1
   when @trimestre = 2 then 4
   when @trimestre = 3 then 7 
   when @trimestre = 4 then 10
   End,
  @mesefine = case
   when @trimestre = 1 then 3
   when @trimestre = 2 then 6
   when @trimestre = 3 then 9 
   when @trimestre = 4 then 12
   End



	CREATE TABLE #ivapay (
		yivapay int,
		nivapay int,
		mese int
	)

	INSERT INTO #ivapay (yivapay,nivapay,mese)
	SELECT 
    yivapay, 
    nivapay,
    month(start)
	FROM ivapay
	WHERE paymentkind = 'C'
	 AND yivapay = @esercizio
	 AND month(start) BETWEEN @meseinizio AND @mesefine
	 AND ((ivapay.flag&1) <> 0)   --- iva commerciale e promiscua
	ORDER BY start



	DECLARE @proratarate decimal(19,6)
	SELECT  @proratarate = prorata 	FROM iva_prorata WHERE ayear = @esercizio
	set @proratarate= isnull(@proratarate,1)
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT  @mixedrate = mixed FROM iva_mixed WHERE ayear = @esercizio
	set @mixedrate= isnull(@mixedrate,1)



	SELECT
	IRK.registerclass AS 'Classe Registro',
	CASE
		WHEN ((IK.flag&1)=0) THEN 'A'  
		WHEN (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = I.idinvkind
					and RK.registerclass<>'P'
				) = 2 THEN 'A'  
		else 'V'
	END as 'Acquisto o vendita', --flagbuysell
	#ivapay.nivapay as 'N. Liquidazione',
	#ivapay.mese as 'Mese' ,
	IRK.description as 'Registro',
	--IRK.idivaregisterkindunified as '#Cod. consolidamento',
	CASE
		WHEN flagdeferred='N' THEN 'Immediata'
		WHEN flagdeferred = 'S' AND (IK.flag & 1)=0 and I.yinv < @esercizio THEN 'Acquisto anni prec. diven. detraibili'
		WHEN flagdeferred = 'S' AND (IK.flag & 1)<>0 and I.yinv < @esercizio THEN 'Vendita  anni prec. diven. esigibili'
		WHEN flagdeferred = 'S' AND (IK.flag & 1)=0 and I.yinv = @esercizio THEN 'Acquisto anno corr. diven. detraibili'
		WHEN flagdeferred = 'S' AND (IK.flag & 1)<>0 and I.yinv = @esercizio THEN 'Vendita anno corr. diven. esigibili'
		--WHEN flagdeferred = 'S' AND (IK.flag & 1)=0 and I.yinv = @esercizio THEN 'Acquisto anno corr. non ancora detraibili'
		--WHEN flagdeferred = 'S' AND (IK.flag & 1)<>0 and I.yinv = @esercizio THEN 'Vendita  anno corr. non ancora esigibili'
		ELSE 'Differita'
	END as 'Esigibilità/Detraibilità',
	IK.description as 'Tipo Fattura', 
	CASE
		WHEN ((IK.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((IK.flag&4)<>0) THEN 'S'
	 END as 'Nota di variazione', 
	IDET.yinv as 'Eserc. Fattura', 
	IDET.ninv as 'Num. Fattura', 
	IDET.rownum as '# Dett',
	I.adate as 'Data Registr.',
	registry.cf as 'Codice Fiscale', 
	registry.p_iva as 'Partita IVA', 
	registry.foreigncf as 'CF Estero/Passaporto',
	CASE
			WHEN IRK.flagactivity = 3  THEN 'S'
			ELSE 'N'
	END as 'Promiscua',
	ROUND(	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END) * IDET.taxable * IDET.number * 
	CONVERT(decimal(19,10),I.exchangerate) *
	(1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
	)as 'Impon. Tot.', 
	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END) * ISNULL(IDET.tax,0) as 'IVA Tot.', --ivagross
		(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END)* ISNULL(IDET.unabatable,0) as 'IVA Indetr.', --ivaunabatable 
	CASE
		WHEN registerclass='A' and IRK.flagactivity = 3 THEN CONVERT(decimal(19,2),	 	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END)* ((ISNULL(IDET.tax,0) -ISNULL(IDET.unabatable,0)))*@proratarate*@mixedrate)--(ivagross-ivaunabatable)*@proratarate*@mixedrate)
		WHEN registerclass='A' and IRK.flagactivity <> 3 THEN CONVERT(decimal(19,2),	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END)*	 ((ISNULL(IDET.tax,0) -ISNULL(IDET.unabatable,0)))*@proratarate )--(ivagross-ivaunabatable)*@proratarate )
		WHEN registerclass='V' THEN 	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END) * ISNULL(IDET.tax,0)
	END as 'IVA Detr.', --ivaabatable
	(CASE
		WHEN ((IK.flag&4)<>0)  then -1 
		WHEN (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 ) then -1 
		ELSE 1 END) * ISNULL(invoicedetaildeferred.ivatotalpayed,0) as 'IVA Totalpayed.', --ivatotalpayed
	ivakind.description as 'Tipo IVA',
	I.doc as 'Doc. colleg.',
	I.docdate as 'Data Doc.', 
	registry.title as 'Fornitore/Cliente', 
	I.description  as 'Descrizione',
			CASE IRK.flagactivity 
				WHEN 1 THEN 'Istituzionale'
				WHEN 2 THEN 'Commerciale'
				WHEN 3 THEN 'Promiscua'
			END as 'Attività',
				CASE I.flagintracom 
			WHEN 'S' THEN 'Intra-UE'
			WHEN 'N' THEN 'Italia'
			WHEN 'X' THEN 'Extra-UE' 
			END as 'Operazione UE',
	--	reverse_charge as 'Reverse Charge', ?? vedendo da exp_riepilogoiva_dett 	UPDATE #invoicedet set reverse_charge = 'S'
		CASE IDET.intrastatoperationkind
			WHEN 'S' THEN 'Servizi'
			WHEN 'B' THEN 'Beni'
		END as 'Tipo oper. Intrastat',
	(select description  from intrastatservice where  idintrastatservice = IDET.idintrastatservice	)	as 'Servizio',
		CASE IDET.intrastatoperationkind
			WHEN 'S' THEN (select description from intrastatpaymethod where idintrastatpaymethod = I.idintrastatpaymethod)
			ELSE NULL 
		END as 'Modalità pagamento/incasso',		
	(select description from intrastatsupplymethod where idintrastatsupplymethod = IDET.idintrastatsupplymethod) as 'Modalità erogazione',	
		CASE IDET.intrastatoperationkind
			WHEN 'S' THEN (select description from intrastatnation where idintrastatnation = I.iso_payment)
		ELSE NULL 
		END as 'Paese pagam.',
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN 	(select description from intrastatkind where idintrastatkind=I.idintrastatkind)
			ELSE NULL 
		END as 'Nat. Transazione',	
	(select code from intrastatmeasure where idintrastatmeasure = IDET.idintrastatmeasure) as 'Un. misura suppl.',	
	(select code from intrastatcode where idintrastatcode = IDET.idintrastatcode) as 'Cod. Nomencl. combinata',	
	(select description from intrastatcode where idintrastatcode = IDET.idintrastatcode) as 'Nomencl. combinata',	
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN (select description from intrastatnation where idintrastatnation = I.iso_destination)
			ELSE NULL 
		END as 'Paese. destin.',	
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN (select description from intrastatnation where idintrastatnation = I.iso_origin)
			ELSE NULL 
		END  as 'Paese. orig.',
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN (select  description from intrastatnation where idintrastatnation = I.iso_provenance)
			ELSE NULL 
		END as 'Paese. proven.',	
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN (select province from geo_country where idcountry = I.idcountry_destination) 
			ELSE NULL 
		END as 'Prov. destin.', 
		CASE IDET.intrastatoperationkind
			WHEN 'B' THEN (select province from geo_country where idcountry = I.idcountry_origin)
		ELSE NULL 
		END as 'Prov. orig.',
		CASE 
			IDET.intra12operationkind
			WHEN 'S' THEN 'Servizi'
			WHEN 'B' THEN 'Beni'
		END as 'INTRA12 - Tipo oper.',
		CASE 
			WHEN IDET.intra12operationkind IS NOT NULL THEN IDET.move12 
		ELSE NULL 
		END as 'INTRA12 - Fornitore non resid. UE',
		CASE 
			WHEN IDET.intra12operationkind IS NOT NULL THEN IDET.exception12 
			ELSE NULL 
		END as 'INTRA12 - art.7-Ter DPR. n.633/72',
		CASE  IDET.va3type 
			WHEN 'S' THEN 'Beni Ammortizzabili'
			WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
			WHEN 'R' THEN 'Beni destinati alla rivendita'
			WHEN 'A' THEN 'Altri acquisti e importazioni'
			ELSE 'Non specificato'
		END as 'Tipologia VF24',
		I.flag_enable_split_payment as 'Split Payment',
		I.idsdi_acquisto as 'N.File(SdI Acquisto)' ,	
		I.ipa_acq as 'IPA acqisto',
		I.idsdi_vendita  as 'N.File(SdI Vendita)',
		I.ipa_ven_cliente as 'IPA cliente',
		(select iduniqueregister from uniqueregister where uniqueregister.idinvkind = I.idinvkind	AND uniqueregister.ninv = I.ninv AND uniqueregister.yinv = I.yinv) as 'N.Registro Unico',
		(select transmissiondate from paymenttransmission where kpaymenttransmission = (select kpaymenttransmission from paymentcommunicated where idexp = IDET.idexp_iva))  as 'Data di trasmissione della distinta pagamenti',
		(select transmissiondate from proceedstransmission join proceeds on proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission join proceedsemitted on proceedsemitted.kpro = proceeds.kpro where idinc = IDET.idinc_iva)  as 'Data di trasmissione della distinta incassi',
		
		CASE 
			WHEN (select transmissiondate from paymenttransmission where kpaymenttransmission = (select kpaymenttransmission from paymentcommunicated where idexp = IDET.idexp_iva)) IS NULL
			AND (select transmissiondate from proceedstransmission join proceeds on proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission join proceedsemitted on proceedsemitted.kpro = proceeds.kpro where idinc = IDET.idinc_iva) IS NULL THEN NULL
			ELSE IDET.tax
		END as 'IvaLiquidata',
		
		CASE 
			WHEN (select transmissiondate from paymenttransmission where kpaymenttransmission = (select kpaymenttransmission from paymentcommunicated where idexp = IDET.idexp_iva)) IS NULL 
			AND (select transmissiondate from proceedstransmission join proceeds on proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission join proceedsemitted on proceedsemitted.kpro = proceeds.kpro where idinc = IDET.idinc_iva) IS NULL THEN NULL
			ELSE IDET.taxable
		END as 'Imponibile Pagato/Incassato'
				
	from invoicedetaildeferred
	join invoice I on invoicedetaildeferred.idinvkind = I.idinvkind AND invoicedetaildeferred.yinv = I.yinv AND invoicedetaildeferred.ninv = I.ninv
	JOIN invoicedetail IDET
		 ON IDET.idinvkind=I.idinvkind
		 AND IDET.yinv=I.yinv
		 AND IDET.ninv=I.ninv
		 AND IDET.rownum=invoicedetaildeferred.rownum
	JOIN invoicekind IK
		 ON I.idinvkind = IK.idinvkind
	JOIN ivaregisterkind IRK
		 ON IRK.idivaregisterkind = invoicedetaildeferred.idivaregisterkind 
	JOIN registry 
		 ON registry.idreg = I.idreg
	JOIN ivakind 
		ON IDET.idivakind = ivakind.idivakind
	JOIN #ivapay
	on  invoicedetaildeferred.yivapay = #ivapay.yivapay and invoicedetaildeferred.nivapay = #ivapay.nivapay 
	WHERE IRK.flagactivity IN (2/*COMMERCIALE*/,3/*PROMISCUA*/) 
		AND ISNULL(IDET.rounding,'N') <>'S'
	 
		-- I FILTRI DELLE FATTURE DEVONO ESSERE COERENTI CON QUELLI SU INVOICEDEFERRED NELLA MASCHERA DELLA LIQUIDAZIONE IVA
	    -- IVA ESIGIBILE: FATTURE VENDITA FLAG SPLIT PAYMENT = 'N' E FATTURE ACQUISTO ANNOTATE SU REGISTRO INVERSIONE CONTABILE 
		AND
		(
		  (@exigible_or_deductible =  'E')  AND
		    (
			 (((IK.flag&1)<>0) /*vendita*/ AND (I.flag_enable_split_payment = 'N'))  /*FATTURE VENDITA NON SPLIT PAYMENT*/
			  OR 
			  -- le fatture contabilizzate in entrata ove ci siano due registri collegati. 
			  -- Infatti queste vanno trattate come se fossero note di variazione
			  (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 )  
			   OR
			 ( ((IK.flag&1)=0) /*ACQUISTO*/ AND  (IRK.registerclass = 'V') )
		    )
		)

		OR 

		(((@exigible_or_deductible =  'D') AND
			 (((IK.flag&1)= 0) /*acquisto*/ 	OR	  
			  -- le fatture contabilizzate in entrata ove ci siano due registri collegati. 
			  -- Infatti queste vanno trattate come se fossero note di variazione
			  (((IK.flag&1)<> 0) AND (select count(*) from invoicekindregisterkind  IRK
					join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
					 where  IRK.idinvkind = I.idinvkind
						and RK.registerclass<>'P') = 2 )   ) AND 
			  (IRK.registerclass = 'A') /*registro acquisti*/))
		
		ORDER BY (IK.flag&1) /*FLAGBUYSELL*/, 	#ivapay.mese , IK.description, I.yinv, I.ninv, IDET.rownum
 
		-- IVA ESIGIBILE FATTURE VENDITA 
		-- IVA ESIGIBILE, FATTURE ACQUISTO INVERSIONE CONTABILE e PSEUDO NOTE DI CREDITO INVERSIONE CONTABILE
		-- IVA DETRAIBILE FATTURE ACQUISTI E PSEUDO NOTE DI CREDITO
	END
	

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

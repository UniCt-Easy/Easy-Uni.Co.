
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


--setuser 'amministrazione'

--exp_invoice_intrastatunified '2019', null, null, 'A', 'M', 'B', 'N'

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice_intrastat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoice_intrastat]
GO

/*
setuser'amministrazione'
setuser 'amm'

exp_invoice_intrastatunified '2019', null, null, 'A', 'M', 'B', 'N'
*/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_invoice_intrastat] (
-- A seconda della periodicità ossia T o M, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni
	@periodicita char(1),	-- M = dichiarazione Mensile, T = dichiarazione Trimestrale, A = dichiarazione Annuale >> NON PIU' DISPONIBILE
	@tipoRecord char(1)		-- B -->Beni, S -->Servizi, T -- >Beni e Servizi
)
AS
BEGIN
 
CREATE TABLE #Dettaglio1_BENI
(	
	idreg int,
	kind char(1),
	flagvariation char(1),
	annorif int,
	meserif int,
	trimrif int,
	segno_variazione char(1),
	is_variation char(1),
	flagpaired char(1),
	idinvkind int,						-- tipo fattura
	yinv int,							-- anno fattura
	ninv int,							-- numero fattura	
	rownum int,							-- dettaglio fattura
	numerofattura varchar(15),			-- Numero Protocollo Fattura (Registro)
	datafattura varchar(6),				-- Data fattura formato (ggmmaa)
	codiceIVA varchar(14),				-- Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										-- L’operazione intracomunitaria
	ammontareinEuro decimal(19,2),		-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta decimal(19,2),	-- numerico Len.13 -- Ammontare delle operazioni in valuta
	iva decimal(19,2),
	ivaindetraibile decimal(19,2),
	importounitario decimal(19,5),
	codTransazione char(1),				-- Codice della natura dela transazione
	codNomenclatura varchar(8),			-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg int,						-- numerico Len. 10 -- Massa netta in kilogrammi
	unitasupp int,						-- numerico Len. 10 -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	codDest_codProv char(2),			-- Codice del paese di destinazione/provenienza
	codOrigineMerce char(2),			-- Codice del paese di origine della merce
	provOrigine_Dest char (2)			-- Codice della provincia di origine/destinazione della merce	

)

CREATE TABLE #Dettaglio3_SERVIZI
(	
	idreg int,
	kind char(1),
	flagvariation char(1),
	annorif int,
	meserif int,

	trimrif int,	
	segno_variazione char(1),
	is_variation char(1),
	flagpaired char(1),

	codiceIVA varchar(14),				--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										--	l’operazione intracomunitaria
	ammontareinEuro decimal(19,2),		-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta decimal(19,2),	-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	iva decimal(19,2),
	ivaindetraibile decimal(19,2),
	importounitario decimal(19,5),
	idinvkind int,						-- tipo fattura
	yinv int,							-- anno fattura
	ninv int,							-- numero fattura	
	rownum int,					
	numerofattura varchar(15),			-- Numero Protocollo Fattura (Registro)
	datafattura varchar(6),				-- Data fattura formato (ggmmaa)
	codServizio varchar(6),				-- numerico -- Codice del Servizio
	modErogazione char(1),				-- Modalità di erogazione
	modpagamento char(1),				-- Modalità pagamento/incasso 
	codPaesePagamento char(2)			-- Codice del paese di Pagamento

)


DECLARE @lencodNomenclatura int
SET @lencodNomenclatura = 8

DECLARE @lenCodServizi int
SET @lenCodServizi = 6

DECLARE @lenNumFattura int
SET @lenNumFattura = 15

DECLARE @lenweight int
SET @lenweight = 10

DECLARE @lenCodiceIVA int
SET @lenCodiceIVA = 14 -- codice stato membro 2 + p iva 12 = 14

DECLARE @lenunitasupp int 
SET @lenunitasupp = 10

DECLARE @lenanno INT
SET @lenanno = 2
DECLARE @lenmese INT
SET @lenmese = 2
DECLARE @lenday INT
SET @lenday = 2

DECLARE @meseinizio int
DECLARE @mesefine int
DECLARE @idcurrency int
SELECT @idcurrency = idcurrency FROM currency WHERE codecurrency='EUR'

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= (@trimestre-1)*3+1,
		@mesefine = @trimestre*3
end
ELSE 
begin
	SELECT 
		@meseinizio= @mese ,
		@mesefine = @mese
end

declare @flag_A char(1)
declare @flag_V char(1)
declare @flagAV char(1)
if (@tipoRiepilogo = 'C') --VENDITA
BEGIN
 SET @flagAV = 'V'
END
ELSE  -- ACQUISTO
BEGIN
 SET @flagAV = 'A'
END

INSERT INTO #Dettaglio1_BENI
(
	idreg ,
	annorif ,
	meserif ,

	kind,
	flagvariation,

	codiceIVA, 				-- codicestatomembro= Codice dello Stato membro dell'acquirente/fornitore + Codice IVA dell'acquitente /fornitore = DE123456788
	ammontareinEuro,		-- numerico -- Ammontare delle operazioni in euro
	ammontareinValuta,		-- numerico -- Ammontare delle operazioni in valuta
	iva,
	ivaindetraibile,
	importounitario,
	idinvkind,				-- tipo fattura
	yinv,					-- anno fattura
	ninv,					-- numero fattura
	rownum,					-- dettaglio fattura 
	numerofattura ,			-- Numero Protocollo Fattura
	datafattura ,			-- Data fattura formato (ggmmaa)
	codTransazione,			-- Codice della natura dela transazione
	codNomenclatura,		-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg,				-- numerico -- Massa netta in kilogrammi
	unitasupp,				-- numerico -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	codDest_codProv,		-- Codice del paese di destinazione/provenienza
	codOrigineMerce,		-- Codice del paese di origine della merce
	provOrigine_Dest		-- Codice della provincia di origine/destinazione della merce	
)
SELECT
	I.idreg,
	ISNULL(YEAR(I_MAIN.adate),YEAR(I.adate)),
	ISNULL(MONTH(I_MAIN.adate),MONTH(I.adate)),
	CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,  --kind (A/V) ossia SPESA/ENTRATA
	CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END,  --flagvariation
	UPPER( isnull(R.p_iva,'')+ SUBSTRING(replicate(' ',@lenCodiceIVA), 1, @lenCodiceIVA - DATALENGTH(isnull(R.p_iva,''))) ),
	--	ammontareinEuro,	
			--ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
			--	(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			--,2),
				CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
			  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
		)),

	--	ammontareinValuta,	
	CASE WHEN I.idcurrency <> @idcurrency
	THEN
			ROUND(InvDet.taxable * InvDet.npackage * (1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)
	ELSE 0
	END,

	--InvDet.iva_euro,
	--InvDet.unabatable_euro,

		CONVERT(decimal(19,2),ROUND(InvDet.tax
				,2)
			),--iva_euro
	CONVERT(decimal(19,2), ROUND(InvDet.unabatable 
					
			       ,2)
			),--unabatable_euro
			InvDet.taxable,

	I.idinvkind,
	I.yinv,
	I.ninv,	
	InvDet.rownum,
	-- Numero Fattura
	SUBSTRING(REPLICATE('0',@lenNumFattura),1,@lenNumFattura - DATALENGTH(ISNULL(convert(varchar(15),IR.protocolnum),''))) + ISNULL(convert(varchar(15),IR.protocolnum),''),
	--IR.protocolnum + SUBSTRING(SPACE(@lenNumFattura),1,@lenNumFattura - DATALENGTH(IR.protocolnum)),
	-- Data fattura formato (ggmmaa)
		 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(I.adate)))) + CONVERT(varchar(2),DAY(I.adate))
		+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(I.adate)))) + CONVERT(varchar(2),MONTH(I.adate))
		+ SUBSTRING(CONVERT(varchar(4),YEAR(I.adate)),3,2),
	K.idintrastatkind,	-- codTransazione			
	-- codNomenclatura	-> intrastatcode
	case 
		when @periodicita IN ('M','T') then SUBSTRING(REPLICATE('0',@lencodNomenclatura),1,@lencodNomenclatura - DATALENGTH(ISNULL(C.code,''))) + ISNULL(C.code,'')
		else REPLICATE('0',@lencodNomenclatura)
	end,
	Case
		When InvDet.idintrastatmeasure is not null THEN ROUND(ISNULL(InvDet.weight,0),0)
		Else ROUND (InvDet.npackage,0)
	End,			
	-- Unitasupp -> solo la quantità
	Case 
		When InvDet.idintrastatmeasure is not null THEN		ROUND (InvDet.npackage,0)
		Else 0
	End,
	--codDest_codProv,		
	case 
		when @tipoRiepilogo ='A' then Prov.idintrastatnation
		else Dest.idintrastatnation
	end,
	-- codOrigineMerce,		
	case 
		when @tipoRiepilogo ='A' then Orig.idintrastatnation
		else REPLICATE(' ',2)
	end,
	-- provOrigine_Dest				
	case 
		when @tipoRiepilogo ='A' then geo_country_destination.province
		else geo_country_origin.province
	end
FROM  invoice as I
JOIN registry as R						ON R.idreg = I.idreg
JOIN invoicekind IK						ON I.idinvkind = IK.idinvkind
JOIN intrastatkind as K					ON I.idintrastatkind = K.idintrastatkind
JOIN invoicedetail as InvDet			ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
JOIN intrastatcode as C					ON C.idintrastatcode = InvDet.idintrastatcode
join  ivaregister IR					ON IR.idinvkind=I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
JOIN invoicekindregisterkind INV_REG	ON INV_REG.idinvkind= I.idinvkind
JOIN 	ivaregisterkind IRK				ON IRK.idivaregisterkind= INV_REG.idivaregisterkind --AND IRK.registerclass='A'
LEFT OUTER JOIN intrastatnation as Dest	ON I.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig	ON I.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov	ON I.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination	ON I.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin		ON I.idcountry_origin = geo_country_origin.idcountry
LEFT OUTER JOIN invoice I_MAIN							ON I_MAIN.idinvkind=InvDet.idinvkind_main and I_MAIN.yinv=InvDet.yinv_main and I_MAIN.ninv=InvDet.ninv_main
WHERE I.flagintracom = 'S'
	AND InvDet.intrastatoperationkind = 'B'-- >>> Beni
	AND YEAR(I.adate) = @anno
	AND MONTH(I.adate) between @meseinizio and @mesefine 	
	AND I.idinvkind_real is null
	AND IRK.registerclass = @flagAV
	AND NOT -- fattura non annullata
	(
      InvDet.npackage = 0 
      AND InvDet.number  = 0
      AND InvDet.taxable  = 0
      AND InvDet.tax = 0
      AND InvDet.unabatable  = 0
    )
	-- Se esportiamo le Cessioni dobbiamo escludere la scrittura nel registro Vendite, in caso di doppia registrazione
	and(@tipoRiepilogo = 'C' and not exists(select * from ivaregisterview 
				where registerclass = 'A'and ivaregisterview.idinvkind = I.idinvkind 
					and ivaregisterview.yinv = I.yinv and ivaregisterview.ninv = I.ninv					)
	or
	@tipoRiepilogo = 'A'
	)


INSERT INTO #Dettaglio3_SERVIZI
(
	idreg,
	annorif ,
	meserif ,
	kind,
	flagvariation,

	codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
	ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti

	iva,
	ivaindetraibile,
	importounitario,

	idinvkind,					--
	yinv,
	ninv,
	rownum,						-- dettaglio fattura 
	numerofattura ,				-- Numero Fattura
	datafattura ,				-- Data fattura formato (ggmmaa)
	codServizio ,				-- numerico -- Codice del Servizio
	modErogazione ,				-- Modalità di erogazione
	modpagamento ,				-- Modalità pagamento/incasso 
	codPaesePagamento 			-- Codice del paese di Pagamento
)
SELECT 
	I.idreg,
	ISNULL(YEAR(I_MAIN.adate),YEAR(I.adate)),
	ISNULL(MONTH(I_MAIN.adate),MONTH(I.adate)),
	CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,  --kind (A/V) ossia SPESA/ENTRATA
	CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END,  --flagvariation

	UPPER( isnull(R.p_iva,'')+ SUBSTRING(replicate(' ',@lenCodiceIVA), 1, @lenCodiceIVA - DATALENGTH(isnull(R.p_iva,''))) ),
--	ammontareinEuro,	
			--ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
			--	(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			--,2),
				CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
			  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
		)),
--	ammontareinValuta,	
	CASE WHEN I.idcurrency <> @idcurrency
	THEN
		ROUND(InvDet.taxable * InvDet.npackage * (1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0))),2)
	ELSE 0
	END,

		CONVERT(decimal(19,2),ROUND(InvDet.tax
				,2)
			),--iva_euro
	CONVERT(decimal(19,2), ROUND(InvDet.unabatable 
					
			       ,2)
			),--unabatable_euro
			InvDet.taxable,

	I.idinvkind,
	I.yinv,
	I.ninv,	
	InvDet.rownum,
	-- Numero Protocollo Fattura
	SUBSTRING(REPLICATE('0',@lenNumFattura),1,@lenNumFattura - DATALENGTH(ISNULL(convert(varchar(15),IR.protocolnum),''))) + ISNULL(convert(varchar(15),IR.protocolnum),''),
	--IR.protocolnum + SUBSTRING(SPACE(@lenNumFattura),1,@lenNumFattura - DATALENGTH(IR.protocolnum)),
	-- Data fattura formato (ggmmaa)
		 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(I.adate)))) + CONVERT(varchar(2),DAY(I.adate))
		+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(I.adate)))) + CONVERT(varchar(2),MONTH(I.adate))
		+ SUBSTRING(CONVERT(varchar(4),YEAR(I.adate)),3,2),
	--  Codice del Servizio
	CONVERT(varchar(6),S.code),
	E.code,					-- Modalità di erogazione
	P.code ,				-- Modalità pagamento/incasso 
	Pag.idintrastatnation 	-- Codice del paese di Pagamento
FROM  invoice as I		
JOIN  registry as R							ON R.idreg = I.idreg
JOIN invoicekind IK							ON I.idinvkind = IK.idinvkind
JOIN invoicedetail as InvDet				ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
JOIN intrastatservice as S					ON S.idintrastatservice = InvDet.idintrastatservice
JOIN intrastatpaymethod as P				ON P.idintrastatpaymethod = I.idintrastatpaymethod
JOIN intrastatsupplymethod E				ON InvDet.idintrastatsupplymethod = E.idintrastatsupplymethod
JOIN intrastatnation as Pag					ON I.iso_payment = Pag.idintrastatnation
join  ivaregister IR						ON IR.idinvkind=I.idinvkind	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
join ivaregisterkind IR_MAIN				ON IR.idivaregisterkind = IR_MAIN.idivaregisterkind
JOIN invoicekindregisterkind INV_REG		ON INV_REG.idinvkind= I.idinvkind
JOIN ivaregisterkind IRK					ON IRK.idivaregisterkind= INV_REG.idivaregisterkind-- AND IRK.registerclass='A'
LEFT OUTER JOIN invoice I_MAIN				ON I_MAIN.idinvkind=InvDet.idinvkind_main and I_MAIN.yinv=InvDet.yinv_main and I_MAIN.ninv=InvDet.ninv_main
WHERE I.flagintracom = 'S'
	AND InvDet.intrastatoperationkind = 'S'-- >>> Servizi
	AND YEAR(I.adate) = @anno
	AND MONTH(I.adate) between @meseinizio and @mesefine 	
	AND I.idinvkind_real is null
	AND IR_MAIN.registerclass = @flagAV
	AND IRK.registerclass = @flagAV
	AND NOT -- fattura non annullata
	(
      InvDet.npackage = 0 
      AND InvDet.number  = 0
      AND InvDet.taxable  = 0
      AND InvDet.tax = 0
      AND InvDet.unabatable  = 0
    )
	-- Se esportiamo le Cessioni dobbiamo escludere la scrittura nel registro Vendite, in caso di doppia registrazione
	and(@tipoRiepilogo = 'C' and not exists(select * from ivaregisterview 
				where registerclass = 'A'and ivaregisterview.idinvkind = I.idinvkind 
					and ivaregisterview.yinv = I.yinv and ivaregisterview.ninv = I.ninv					)
	or
	@tipoRiepilogo = 'A'
	)

--calcola i trimestri
update #Dettaglio1_BENI set trimrif = ((meserif-1)/3)+1
update #Dettaglio3_SERVIZI set trimrif = ((meserif-1)/3)+1

--calcola is_variation
update #Dettaglio1_BENI set is_variation='N' where kind=@flagav AND flagvariation='N'
update #Dettaglio3_SERVIZI set is_variation='N' where kind=@flagav AND flagvariation='N'
update #Dettaglio1_BENI set is_variation='S' where kind<>@flagav OR flagvariation='S'
update #Dettaglio3_SERVIZI set is_variation='S' where kind<>@flagav OR flagvariation='S'
update #Dettaglio1_BENI set is_variation='N' where kind<>@flagav AND flagvariation='S'
update #Dettaglio3_SERVIZI set is_variation='N' where kind<>@flagav AND flagvariation='S'

--segna quali sono le fatture da compensare nel periodo stesso
update #Dettaglio1_BENI set flagpaired ='N'
update #Dettaglio1_BENI set flagpaired ='S' WHERE 
		flagvariation='S' AND 
		annorif=@anno and meserif between @meseinizio and @mesefine 
 
update #Dettaglio3_SERVIZI set flagpaired ='N'
update #Dettaglio3_SERVIZI set flagpaired ='S' WHERE  
		flagvariation='S' AND
		annorif=@anno and meserif between @meseinizio and @mesefine 

--aggiusta i segni negli importi NOI GESTIAMO SOLO VARIAZIONI NEGATIVE E MAI POSITIVE
update #Dettaglio1_BENI set  segno_variazione='-' where flagvariation='S' and flagpaired='N'
update #Dettaglio3_SERVIZI set segno_variazione='-' where flagvariation='S' and flagpaired='N'

update #Dettaglio1_BENI set  ammontareinEuro=-ammontareinEuro,ammontareinValuta=-ammontareinValuta,iva=-iva,ivaindetraibile=-ivaindetraibile,importounitario=-importounitario
				 where flagvariation='S' and flagpaired='S'
update #Dettaglio3_SERVIZI set ammontareinEuro=-ammontareinEuro,ammontareinValuta=-ammontareinValuta,iva=-iva,ivaindetraibile=-ivaindetraibile,importounitario=-importounitario
				 where flagvariation='S' and flagpaired='S'
 

--azzera annorif e meserif per tutte le righe tranne che per le variazioni non compensate
update #Dettaglio1_BENI set annorif=null, meserif=null,trimrif=null where flagvariation='N' or flagpaired='S'
update #Dettaglio3_SERVIZI set annorif=null, meserif=null,trimrif=null where flagvariation='N' or flagpaired='S'

--questo perché nella group by vanno raggruppate

--SELECT 'DETTAGLIO BENI', * FROM #Dettaglio1_BENI
--SELECT 'DETTAGLIO SERVIZI', * FROM #Dettaglio3_SERVIZI


IF(@tiporecord = 'B')
BEGIN
SELECT 
	'Beni' as 'Tipo',
	CASE @tipoRiepilogo
		WHEN 'A' THEN 'Acquisti'
		ELSE 'Cessioni'
	END as 'Tipo riep.',
	CASE @periodicita
		WHEN 'T' THEN 'Trimestrale'
		WHEN 'M' THEN 'Mensile'
	END as 'Periodicità',
	@anno as 'Anno',
	(SELECT title from monthname where code=@mese)
		as 'Mese Rif.',
	@trimestre as 'Trimestre Rif.',
	(SELECT title from monthname where code=MONTH(I.adate))
		as 'Mese Fattura',
	segno_variazione as 'Segno Var',
	R.title as 'Cliente/Fornitore',
	R.p_iva as 'P.Iva', 
	R.cf as 'Codice Fiscale',
	R.birthdate as 'Data Nasc.',
	IK.description as 'Tipo Doc. Iva', 
	I.yinv as 'Anno Fattura',
	I.ninv as 'Num. Fattura', 	
	InvDet.rownum as '# Dett.',
	IR.protocolnum as 'Num. Protocollo', 
	Curr.description as 'Valuta',
	CASE WHEN I.idcurrency <> @idcurrency
	THEN I.exchangerate
	ELSE null
	END  as 'Tasso Cambio',
	
	--CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
	---- + CONVERT(decimal(19,2),ROUND(ISNULL(InvDet.tax,0),2))	
	D.ammontareinEuro as 'Ammont. In Euro',
	--	ammontareinValuta,	
	--CASE WHEN I.idcurrency <> @idcurrency
	--THEN
	--	CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
	--ELSE 0
	--END 
	D.ammontareinValuta as 'Ammont. In Valuta',
	K.description as 'Natura Transazione',
	InvDet.code as 'Cod. Nomencl. Combinata',
	C.description as 'Nomencl. Combinata',
	InvDet.intrastatmeasure as 'Unità di Misura Suppl.',
	InvDet.weight as 'Peso in Kg',
	Orig.description as 'Paese Orig.',
	Prov.description as 'Paese Proven.',
	geo_country_destination.title as 'Provincia Destin.',
	Dest.description as 'Paese Destin.',
	geo_country_origin.title as 'Provincia Orig.',	
	null as 'Numero Fattura',				
	null as 'Data fattura formato (ggmmaa)',			
	Convert(varchar(6),intrastatservice.code) as 'Codice del Servizio', 	
	intrastatservice.description as 'Servizio',							
	intrastatsupplymethod.description as 'Modalità di erogazione',				
	null as 'Modalità pagamento/incasso',				
	null as 'Codice del paese di Pagamento', 			
	I.adate as 'Data Fattura',
	InvDet.detaildescription as 'Descr. Dettaglio',
	D.importounitario as 'Impon. Unitario',
	InvDet.npackage as 'Quantità',
	InvDet.discount as 'Sconto',
	InvDet.ivakind as 'Tipo Iva',
	--InvDet.iva_euro 
	D.iva as 'Iva',
	--InvDet.unabatable_euro
	D.ivaindetraibile as 'Iva Indetr.',
	CASE  InvDet.va3type 
		WHEN 'S' THEN 'Beni Ammortizzabili'
		WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
		WHEN 'R' THEN 'Beni destinati alla rivendita'
		WHEN 'A' THEN 'Altri acquisti e importazioni'
		ELSE 'Non specificato'
	END as 'Tipologia VF24'
FROM registry as R
JOIN #Dettaglio1_BENI as D					ON R.idreg = D.idreg	
JOIN invoicedetailview as InvDet			ON D.idinvkind = InvDet.idinvkind AND D.yinv = InvDet.yinv 
														AND D.ninv = InvDet.ninv  AND D.rownum = InvDet.rownum
JOIN invoice as I							ON InvDet.idinvkind = I.idinvkind AND InvDet.yinv = I.yinv  AND InvDet.ninv = I.ninv 
JOIN invoicekind IK							ON I.idinvkind = IK.idinvkind
join  ivaregister IR						ON IR.idinvkind=I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK					ON IRK.idivaregisterkind = IR.idivaregisterkind
LEFT OUTER JOIN intrastatservice			ON InvDet.idintrastatservice = intrastatservice.idintrastatservice
LEFT OUTER JOIN intrastatsupplymethod		ON InvDet.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN intrastatkind as K			ON I.idintrastatkind = K.idintrastatkind
LEFT OUTER JOIN intrastatcode as C			ON C.idintrastatcode = InvDet.idintrastatcode
LEFT OUTER JOIN currency as Curr			ON Curr.idcurrency = I.idcurrency
LEFT OUTER JOIN intrastatnation as Dest		ON I.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig		ON I.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov		ON I.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination		ON I.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin			ON I.idcountry_origin = geo_country_origin.idcountry
LEFT OUTER JOIN intrastatnation								ON I.iso_payment = intrastatnation.idintrastatnation
LEFT OUTER JOIN intrastatpaymethod							ON I.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
ORDER BY MONTH(D.meserif), I.idinvkind, I.yinv, I.ninv, InvDet.rownum
END
IF(@tiporecord = 'S')
BEGIN
SELECT 
	'Serv.' as 'Tipo',
	CASE @tipoRiepilogo
		WHEN 'A' THEN 'Acquisti'
		ELSE 'Cessioni'
	END as 'Tipo riep.',
	CASE @periodicita
		WHEN 'T' THEN 'Trimestrale'
		WHEN 'M' THEN 'Mensile'
	END as 'Periodicità',
	@anno as 'Anno',
	(SELECT title from monthname where code=@mese)
		as 'Mese Rif.',
	@trimestre as 'Trimestre Rif.',
	(SELECT title from monthname where code=MONTH(I.adate))
		as 'Mese Fattura',
	segno_variazione as 'Segno Var',
	R.title as 'Cliente/Fornitore',
	R.p_iva as 'P.Iva', 
	R.cf as 'Codice Fiscale',
	R.birthdate as 'Data Nasc.',
	IK.description as 'Tipo Doc. Iva', 
	I.yinv as 'Anno Fattura',
	I.ninv as 'Num. Fattura', 	
	InvDet.rownum as '# Dett.',
	IR.protocolnum as 'Num. Protocollo', 
	Curr.description as 'Valuta',
	CASE WHEN I.idcurrency <> @idcurrency
	THEN I.exchangerate
	ELSE null
	END  as 'Tasso Cambio',
	--CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
	---- + CONVERT(decimal(19,2),ROUND(ISNULL(InvDet.tax,0),2))	
	D.ammontareinEuro as 'Ammont. In Euro',
	--	ammontareinValuta,	
	--CASE WHEN I.idcurrency <> @idcurrency
	--THEN
	--	CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
			
	--ELSE 0 END
	D.ammontareinValuta as 'Ammont. In Valuta',
	null as 'Natura Transazione',
	InvDet.code as 'Cod. Nomencl. Combinata',
	C.description as 'Nomencl. Combinata',
	InvDet.intrastatmeasure as 'Unità di Misura Suppl.',
	InvDet.weight as 'Peso in Kg',
	null as 'Paese Orig.',
	null as 'Paese Proven.',
	null as 'Provincia Destin.',
	null as 'Paese Destin.',
	null as 'Provincia Orig.',	
	numerofattura as 'Numero Fattura',				
	datafattura as 'Data fattura formato (ggmmaa)',			
	Convert(varchar(6),intrastatservice.code) as 'Codice del Servizio', 	
	intrastatservice.description as 'Servizio',					
	intrastatsupplymethod.description as 'Modalità di erogazione',						
	intrastatpaymethod.description  as 'Modalità pagamento/incasso',	
	intrastatnation.description as 'Codice del paese di Pagamento', 			
	I.adate as 'Data Fattura',
	InvDet.detaildescription as 'Descr. Dettaglio',
	D.importounitario as 'Impon. Unitario',
	InvDet.npackage as 'Quantità',
	InvDet.discount as 'Sconto',
	InvDet.ivakind as 'Tipo Iva',
	--InvDet.iva_euro 
	D.iva as 'Iva',
	--InvDet.unabatable_euro 
	D.ivaindetraibile as 'Iva Indetr.',
	CASE  InvDet.va3type 
		WHEN 'S' THEN 'Beni Ammortizzabili'
		WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
		WHEN 'R' THEN 'Beni destinati alla rivendita'
		WHEN 'A' THEN 'Altri acquisti e importazioni'
		ELSE 'Non specificato'
	END as 'Tipologia VF24'
FROM registry as R
JOIN #Dettaglio3_Servizi as D
	ON R.idreg = D.idreg
JOIN invoicedetailview as InvDet 
	ON D.idinvkind = InvDet.idinvkind AND D.yinv = InvDet.yinv 
	AND D.ninv = InvDet.ninv  AND D.rownum = InvDet.rownum
JOIN invoice as I
	ON InvDet.idinvkind = I.idinvkind
	AND InvDet.yinv = I.yinv 
	AND InvDet.ninv = I.ninv 
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
join  ivaregister IR
	ON IR.idinvkind=I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
LEFT OUTER JOIN intrastatservice
	ON InvDet.idintrastatservice = intrastatservice.idintrastatservice
LEFT OUTER JOIN intrastatsupplymethod
	ON InvDet.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN intrastatkind as K
	ON I.idintrastatkind = K.idintrastatkind
LEFT OUTER JOIN intrastatcode as C 
	ON C.idintrastatcode = InvDet.idintrastatcode
LEFT OUTER JOIN currency as Curr 
	ON Curr.idcurrency = I.idcurrency
LEFT OUTER JOIN intrastatnation as Dest
	ON I.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig	
	ON I.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov
	ON I.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination
	ON I.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin
	ON I.idcountry_origin = geo_country_origin.idcountry
LEFT OUTER JOIN intrastatnation
	ON I.iso_payment = intrastatnation.idintrastatnation
LEFT OUTER JOIN intrastatpaymethod 
	ON I.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
ORDER BY MONTH(D.meserif), I.idinvkind, I.yinv, I.ninv, InvDet.rownum
END
IF(@tiporecord = 'T')
BEGIN
SELECT 
	'Beni' as 'Tipo',
	CASE @tipoRiepilogo
		WHEN 'A' THEN 'Acquisti'
		ELSE 'Cessioni'
	END as 'Tipo riep.',
	CASE @periodicita
		WHEN 'T' THEN 'Trimestrale'
		WHEN 'M' THEN 'Mensile'
	END as 'Periodicità',
	@anno as 'Anno',
	(SELECT title from monthname where code=@mese)
		as 'Mese Rif.',
	@trimestre as 'Trimestre Rif.',
	(SELECT title from monthname where code=MONTH(I.adate))
		as 'Mese Fattura',
	segno_variazione as 'Segno Var',
	R.title as 'Cliente/Fornitore',
	R.p_iva as 'P.Iva', 
	R.cf as 'Codice Fiscale',
	R.birthdate as 'Data Nasc.',
	IK.description as 'Tipo Doc. Iva', 
	I.yinv as 'Anno Fattura',
	I.ninv as 'Num. Fattura', 	
	InvDet.rownum as '# Dett.',
	IR.protocolnum as 'Num. Protocollo', 
	Curr.description as 'Valuta',
	CASE WHEN I.idcurrency <> @idcurrency
	THEN I.exchangerate
	ELSE null
	END  as 'Tasso Cambio',
	--CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
	---- + CONVERT(decimal(19,2),ROUND(ISNULL(InvDet.tax,0),2))	
	D.ammontareinEuro as 'Ammont. In Euro',
--	ammontareinValuta,	
	--CASE WHEN I.idcurrency <> @idcurrency
	--THEN
	--	CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
			
	--ELSE 0
	--END 
	D.ammontareinValuta as 'Ammont. In Valuta',
	K.description as 'Natura Transazione',
	InvDet.code as 'Cod. Nomencl. Combinata',
	C.description as 'Nomencl. Combinata',
	InvDet.intrastatmeasure as 'Unità di Misura Suppl.',
	InvDet.weight as 'Peso in Kg',
	Orig.description as 'Paese Orig.',
	Prov.description as 'Paese Proven.',
	geo_country_destination.title as 'Provincia Destin.',
	Dest.description as 'Paese Destin.',
	geo_country_origin.title as 'Provincia Orig.',	
	null as 'Numero Fattura',				
	null as 'Data fattura formato (ggmmaa)',
	Convert(varchar(6),intrastatservice.code) as 'Codice del Servizio', 	
	intrastatservice.description as 'Servizio',				
	intrastatsupplymethod.description as 'Modalità di erogazione',						
	null as 'Modalità pagamento/incasso',				
	null as 'Codice del paese di Pagamento', 				
	I.adate as 'Data Fattura',
	InvDet.detaildescription as 'Descr. Dettaglio',
	D.importounitario as 'Impon. Unitario',
	InvDet.npackage as 'Quantità',
	InvDet.discount as 'Sconto',
	InvDet.ivakind as 'Tipo Iva',
	--InvDet.iva_euro 
	D.iva as 'Iva',
	--InvDet.unabatable_euro 
	D.ivaindetraibile as 'Iva Indetr.',
	CASE  InvDet.va3type 
		WHEN 'S' THEN 'Beni Ammortizzabili'
		WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
		WHEN 'R' THEN 'Beni destinati alla rivendita'
		WHEN 'A' THEN 'Altri acquisti e importazioni'
		ELSE 'Non specificato'
	END as 'Tipologia VF24'
FROM registry as R
JOIN #Dettaglio1_BENI as D
	ON R.idreg = D.idreg
JOIN invoicedetailview as InvDet 
	ON D.idinvkind = InvDet.idinvkind AND D.yinv = InvDet.yinv 
	AND D.ninv = InvDet.ninv  AND D.rownum = InvDet.rownum
JOIN invoice as I
	ON InvDet.idinvkind = I.idinvkind
	AND InvDet.yinv = I.yinv 
	AND InvDet.ninv = I.ninv 
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
join  ivaregister IR
	ON IR.idinvkind=I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
LEFT OUTER JOIN intrastatservice
	ON InvDet.idintrastatservice = intrastatservice.idintrastatservice
LEFT OUTER JOIN intrastatsupplymethod
	ON InvDet.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN intrastatkind as K
	ON I.idintrastatkind = K.idintrastatkind
LEFT OUTER JOIN intrastatcode as C 
	ON C.idintrastatcode = InvDet.idintrastatcode
LEFT OUTER JOIN currency as Curr 
	ON Curr.idcurrency = I.idcurrency
LEFT OUTER JOIN intrastatnation as Dest
	ON I.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig	
	ON I.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov
	ON I.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination
	ON I.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin
	ON I.idcountry_origin = geo_country_origin.idcountry
LEFT OUTER JOIN intrastatnation
	ON I.iso_payment = intrastatnation.idintrastatnation
LEFT OUTER JOIN intrastatpaymethod 
	ON I.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
UNION
	SELECT
		'Serv.' as 'Tipo',
	CASE @tipoRiepilogo
		WHEN 'A' THEN 'Acquisti'
		ELSE 'Cessioni'
	END as 'Tipo riep.',
	CASE @periodicita
		WHEN 'T' THEN 'Trimestrale'
		WHEN 'M' THEN 'Mensile'
	END as 'Periodicità',
	@anno as 'Anno',
	(SELECT title from monthname where code=@mese)
		as 'Mese Rif.',
	@trimestre as 'Trimestre Rif.',
	(SELECT title from monthname where code=MONTH(I.adate))
		as 'Mese Fattura',
	segno_variazione as 'Segno Var',
	R.title as 'Cliente/Fornitore',
	R.p_iva as 'P.Iva', 
	R.cf as 'Codice Fiscale',
	R.birthdate as 'Data Nasc.',
	IK.description as 'Tipo Doc. Iva', 
	I.yinv as 'Anno Fattura',
	I.ninv as 'Num. Fattura', 	
	InvDet.rownum as '# Dett.',
	IR.protocolnum as 'Num. Protocollo', 
	Curr.description as 'Valuta',
	CASE WHEN I.idcurrency <> @idcurrency
	THEN I.exchangerate
	ELSE null
	END  as 'Tasso Cambio',
	
	--CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
	---- + CONVERT(decimal(19,2),ROUND(ISNULL(InvDet.tax,0),2))	
	D.ammontareinEuro as 'Ammont. In Euro',
--	ammontareinValuta,	
	--CASE WHEN I.idcurrency <> @idcurrency
	--THEN
	--	CONVERT(decimal(19,2), ROUND(InvDet.taxable * InvDet.npackage * 
	--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(InvDet.discount, 0.0))),2
	--	))
			
	--ELSE 0
	--END 
	D.ammontareinValuta as  'Ammont. In Valuta',
	null as 'Natura Transazione',
	InvDet.code as 'Cod. Nomencl. Combinata',
	C.description as 'Nomencl. Combinata',
	InvDet.intrastatmeasure as 'Unità di Misura Suppl.',
	InvDet.weight as 'Peso in Kg',
	null as 'Paese Orig.',
	null as 'Paese Proven.',
	null as 'Provincia Destin.',
	null as 'Paese Destin.',
	null as 'Provincia Orig.',		
	numerofattura as 'Numero Fattura',				
	datafattura as 'Data fattura formato (ggmmaa)',		
	Convert(varchar(6),intrastatservice.code) as 'Codice del Servizio', 
	intrastatservice.description as 'Servizio',				
	intrastatsupplymethod.description as 'Modalità di erogazione',						
	intrastatpaymethod.description  as 'Modalità pagamento/incasso',				
	intrastatnation.description as 'Codice del paese di Pagamento', 			
	I.adate as 'Data Fattura',
	InvDet.detaildescription as 'Descr. Dettaglio',
	D.importounitario as 'Impon. Unitario',
	InvDet.npackage as 'Quantità',
	InvDet.discount as 'Sconto',
	InvDet.ivakind as 'Tipo Iva',
	--InvDet.iva_euro 
	D.iva as 'Iva',
	--InvDet.unabatable_euro 
	D.ivaindetraibile as 'Iva Indetr.',
	CASE  InvDet.va3type 
		WHEN 'S' THEN 'Beni Ammortizzabili'
		WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
		WHEN 'R' THEN 'Beni destinati alla rivendita'
		WHEN 'A' THEN 'Altri acquisti e importazioni'
		ELSE 'Non specificato'
	END as 'Tipologia VF24'
FROM registry as R
JOIN #Dettaglio3_Servizi as D
	ON R.idreg = D.idreg
JOIN invoicedetailview as InvDet 
	ON D.idinvkind = InvDet.idinvkind AND D.yinv = InvDet.yinv 
	AND D.ninv = InvDet.ninv  AND D.rownum = InvDet.rownum
JOIN invoice as I
	ON InvDet.idinvkind = I.idinvkind
	AND InvDet.yinv = I.yinv 
	AND InvDet.ninv = I.ninv 
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
join  ivaregister IR
	ON IR.idinvkind=I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
LEFT OUTER JOIN intrastatservice
	ON InvDet.idintrastatservice = intrastatservice.idintrastatservice
LEFT OUTER JOIN intrastatsupplymethod
	ON InvDet.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN intrastatkind as K
	ON I.idintrastatkind = K.idintrastatkind
LEFT OUTER JOIN intrastatcode as C 
	ON C.idintrastatcode = InvDet.idintrastatcode
LEFT OUTER JOIN currency as Curr 
	ON Curr.idcurrency = I.idcurrency
LEFT OUTER JOIN intrastatnation as Dest
	ON I.iso_destination = Dest.idintrastatnation
LEFT OUTER JOIN intrastatnation as Orig	
	ON I.iso_origin = Orig.idintrastatnation
LEFT OUTER JOIN intrastatnation as Prov
	ON I.iso_provenance = Prov.idintrastatnation
LEFT OUTER JOIN geo_country as geo_country_destination
	ON I.idcountry_destination = geo_country_destination.idcountry
LEFT OUTER JOIN geo_country as geo_country_origin
	ON I.idcountry_origin = geo_country_origin.idcountry
LEFT OUTER JOIN intrastatnation
	ON I.iso_payment = intrastatnation.idintrastatnation
LEFT OUTER JOIN intrastatpaymethod 
	ON I.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
END

	
DROP TABLE #Dettaglio1_BENI
DROP TABLE #Dettaglio3_SERVIZI

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--  select * from registry R left outer join expense E on E.idreg= R.idreg+999999999 where isnull(E.idreg,-2) is null
--  EXEC exp_mod_intrastat 2010,5,null,'A','M','B'

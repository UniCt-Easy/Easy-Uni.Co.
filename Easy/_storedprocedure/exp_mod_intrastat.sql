
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intrastat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intrastat]
GO
 
/*
setuser'amministrazione'
EXEC exp_mod_intrastat 2017, null,2,'A','T','B'
exp_mod_intrastat_unified {ts '2017-06-07 00:00:00.000'} ,'2017' ,'6' ,'2', 'A', 'M' ,'XXXX' ,'123456' ,'0' ,'V', '1', 'E', 'N', '(null)'
*/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_intrastat] (
-- A seconda della periodicità ossia T o M, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni
	@periodicita char(1),	-- M = dichiarazione Mensile, T = dichiarazione Trimestrale, A = dichiarazione Annuale >> NON PIU' DISPONIBILE
	@tipoRecord char(1)
)
AS
BEGIN

CREATE TABLE #Dettaglio1_BENI
(	kind char(1),
	flagvariation char(1),
	annorif int,
	meserif int,

	trimrif int,
	segno_variazione char(1),
	is_variation char(1),
	flagpaired char(1),

	codiceIVA varchar(14),				-- - Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										-- l’operazione intracomunitaria
	ammontareinEuro int,				-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta int,				-- numerico Len.13 -- Ammontare delle operazioni in valuta
	codTransazione char(1),				-- Codice della natura dela transazione
	codNomenclatura varchar(8),			-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg int,						-- numerico Len. 10 -- Massa netta in kilogrammi
	unitasupp int,						-- numerico Len. 10 -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	codDest_codProv char(2),			-- Codice del paese di destinazione/provenienza
	codOrigineMerce char(2),			-- Codice del paese di origine della merce
	provOrigine_Dest char (2)				-- Codice della provincia di origine/destinazione della merce	

)

CREATE TABLE #Dettaglio3_SERVIZI
(	kind char(1),
	flagvariation char(1),
	annorif int,
	meserif int,

	trimrif int,	
	segno_variazione char(1),
	is_variation char(1),
	flagpaired char(1),

	codiceIVA varchar(14),				--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										--	l’operazione intracomunitaria
	ammontareinEuro int,				-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta int,				-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura varchar(15),			-- Numero Fattura
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
	annorif ,
	meserif ,

	kind,
	flagvariation,

	codiceIVA, 				-- codicestatomembro= Codice dello Stato membro dell'acquirente/fornitore + Codice IVA dell'acquitente /fornitore = DE123456788
	ammontareinEuro,		-- numerico -- Ammontare delle operazioni in euro
	ammontareinValuta,		-- numerico -- Ammontare delle operazioni in valuta
	codTransazione,			-- Codice della natura dela transazione
	codNomenclatura,		-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg,				-- numerico -- Massa netta in kilogrammi
	unitasupp,				-- numerico -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	codDest_codProv,		-- Codice del paese di destinazione/provenienza
	codOrigineMerce,		-- Codice del paese di origine della merce
	provOrigine_Dest		-- Codice della provincia di origine/destinazione della merce	
)
SELECT
	ISNULL(YEAR(I_MAIN.docdate),YEAR(I.docdate)),
	ISNULL(MONTH(I_MAIN.docdate),MONTH(I.docdate)),
	CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,  --kind (A/V) ossia SPESA/ENTRATA
	CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END,  --flagvariation
	UPPER( isnull(R.p_iva,'')+ SUBSTRING(replicate(' ',@lenCodiceIVA), 1, @lenCodiceIVA - DATALENGTH(isnull(R.p_iva,''))) ),
--	ammontareinEuro,	
	round ( SUM( 
			ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)   
		 ),0),

--	ammontareinValuta,	
	CASE WHEN I.idcurrency <> @idcurrency
	THEN
		round ( SUM( 
			ROUND(InvDet.taxable * InvDet.npackage * (1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)   
		 ),0)
	ELSE 0
	END,
	K.idintrastatkind,	-- codTransazione			
	-- codNomenclatura	-> intrastatcode
	case 
		when @periodicita IN ('M','T') then SUBSTRING(REPLICATE('0',@lencodNomenclatura),1,@lencodNomenclatura - DATALENGTH(ISNULL(C.code,''))) + ISNULL(C.code,'')
		else REPLICATE('0',@lencodNomenclatura)
	end,
	-- massainkg
	SUM(Case
		When InvDet.weight is not null THEN  ROUND( ISNULL(InvDet.npackage,InvDet.number) * InvDet.weight,0)* (CASE   WHEN (InvDet.taxable>=0) THEN 1 ELSE -1 END) 	--ROUND(ISNULL(InvDet.weight,0),0)
		Else 1 END)	,	
	-- Unitasupp -> solo la quantità
	SUM(Case 
		When InvDet.idintrastatmeasure is not null THEN		ROUND ( ISNULL(InvDet.npackage,InvDet.number) ,0)* (CASE   WHEN (InvDet.taxable>=0) THEN 1 ELSE -1 END)
		Else 0
	End  ),
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
JOIN registry as R
	ON R.idreg = I.idreg
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN intrastatkind as K
	ON I.idintrastatkind = K.idintrastatkind
JOIN invoicedetail as InvDet 
	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
JOIN intrastatcode as C 
	ON C.idintrastatcode = InvDet.idintrastatcode
JOIN invoicekindregisterkind INV_REG	
	ON INV_REG.idinvkind= I.idinvkind
JOIN 	ivaregisterkind IRK
	ON IRK.idivaregisterkind= INV_REG.idivaregisterkind --AND IRK.registerclass='A'
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
LEFT OUTER JOIN invoice I_MAIN
	ON I_MAIN.idinvkind=InvDet.idinvkind_main and I_MAIN.yinv=InvDet.yinv_main and I_MAIN.ninv=InvDet.ninv_main
WHERE I.flagintracom = 'S'
	AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
	and (isnull(InvDet.flagbit,0) & 4) = 0
	AND InvDet.intrastatoperationkind = 'B'-- >>> Beni
	AND YEAR(I.adate) = @anno
	AND MONTH(I.adate) between @meseinizio and @mesefine 	
	AND IRK.registerclass = @flagAV
	AND I.idinvkind_real is null
	-- Se esportiamo le Cessioni dobbiamo escludere la scrittura nel registro Vendite, in caso di doppia registrazione
	and(@tipoRiepilogo = 'C' and not exists(select * from ivaregisterview 
				where registerclass = 'A'and ivaregisterview.idinvkind = I.idinvkind 
					and ivaregisterview.yinv = I.yinv and ivaregisterview.ninv = I.ninv					)
	or
	@tipoRiepilogo = 'A'
	)
group by R.p_iva,I.idcurrency,K.idintrastatkind,C.code,
		Prov.idintrastatnation, Dest.idintrastatnation, Orig.idintrastatnation,geo_country_destination.province,geo_country_origin.province,
		I.docdate,I_MAIN.docdate,IK.flag, InvDet.idintrastatmeasure


INSERT INTO #Dettaglio3_SERVIZI
(
	annorif ,
	meserif ,

	kind,
	flagvariation,

	codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
	ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura ,				-- Numero Fattura
	datafattura ,				-- Data fattura formato (ggmmaa)
	codServizio ,				-- numerico -- Codice del Servizio
	modErogazione ,				-- Modalità di erogazione
	modpagamento ,				-- Modalità pagamento/incasso 
	codPaesePagamento 			-- Codice del paese di Pagamento
)
SELECT 
	ISNULL(YEAR(I_MAIN.docdate),YEAR(I.docdate)),
	ISNULL(MONTH(I_MAIN.docdate),MONTH(I.docdate)),
	CASE WHEN (IK.flag & 1)=0 THEN 'A'    ELSE 'V'	END,  --kind (A/V) ossia SPESA/ENTRATA
	CASE	WHEN (IK.flag & 4) = 0 THEN 'N'		ELSE 'S'	END,  --flagvariation

	UPPER( isnull(R.p_iva,'')+ SUBSTRING(replicate(' ',@lenCodiceIVA), 1, @lenCodiceIVA - DATALENGTH(isnull(R.p_iva,''))) ),
--	ammontareinEuro,	
	round(SUM(
			ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)
	),0),
--	ammontareinValuta,	
	CASE WHEN I.idcurrency <> @idcurrency
	THEN
	round(SUM(
			ROUND(InvDet.taxable * InvDet.npackage * (1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
			,2)
	),0)
	ELSE 0
	END,
	-- Numero Fattura
	SUBSTRING(REPLICATE('0',@lenNumFattura),1,@lenNumFattura - DATALENGTH(ISNULL(convert(varchar(15),I.doc),''))) + ISNULL(convert(varchar(15),I.doc),''),
	-- Data fattura formato (ggmmaa)
		 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(I.docdate)))) + CONVERT(varchar(2),DAY(I.docdate))
		+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(I.docdate)))) + CONVERT(varchar(2),MONTH(I.docdate))
		+ SUBSTRING(CONVERT(varchar(4),YEAR(I.docdate)),3,2),
	--  Codice del Servizio
	CONVERT(varchar(6),S.code),
	E.code,					-- Modalità di erogazione
	P.code ,				-- Modalità pagamento/incasso 
	Pag.idintrastatnation 	-- Codice del paese di Pagamento
FROM  invoice as I 
JOIN  registry as R
	ON R.idreg = I.idreg
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN invoicedetail as InvDet 
	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
JOIN intrastatservice as S 
	ON S.idintrastatservice = InvDet.idintrastatservice
JOIN intrastatpaymethod as P 
	ON P.idintrastatpaymethod = I.idintrastatpaymethod
JOIN intrastatsupplymethod E 
	ON InvDet.idintrastatsupplymethod = E.idintrastatsupplymethod
JOIN intrastatnation as Pag	
	ON I.iso_payment = Pag.idintrastatnation
join  ivaregister IR
	ON IR.idinvkind=I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
join ivaregisterkind IR_MAIN
	ON IR.idivaregisterkind = IR_MAIN.idivaregisterkind
JOIN 	invoicekindregisterkind INV_REG
	ON INV_REG.idinvkind= I.idinvkind
JOIN 	ivaregisterkind IRK
	ON IRK.idivaregisterkind= INV_REG.idivaregisterkind-- AND IRK.registerclass='A'
LEFT OUTER JOIN invoice I_MAIN
	ON I_MAIN.idinvkind=InvDet.idinvkind_main and I_MAIN.yinv=InvDet.yinv_main and I_MAIN.ninv=InvDet.ninv_main
WHERE I.flagintracom = 'S'
AND InvDet.intrastatoperationkind = 'S'-- >>> Servizi
AND YEAR(I.adate) = @anno
AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
and (isnull(InvDet.flagbit,0) & 4) = 0
AND MONTH(I.adate) between @meseinizio and @mesefine 	
AND I.idinvkind_real is null
AND IR_MAIN.registerclass = @flagAV
AND IRK.registerclass = @flagAV
	-- Se esportiamo le Cessioni dobbiamo escludere la scrittura nel registro Vendite, in caso di doppia registrazione
	and(@tipoRiepilogo = 'C' and not exists(select * from ivaregisterview 
				where registerclass = 'A'and ivaregisterview.idinvkind = I.idinvkind 
					and ivaregisterview.yinv = I.yinv and ivaregisterview.ninv = I.ninv					)
	or
	@tipoRiepilogo = 'A'
	)
group by R.p_iva,I.idinvkind,I.yinv, I.ninv,IK.flag,I.idcurrency,I.doc, I.docdate, S.code, 
	S.idintrastatservice, E.idintrastatsupplymethod, E.code, P.code,InvDet.npackage,	Pag.idintrastatnation,
	I.docdate,I_MAIN.docdate,IK.flag

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

update #Dettaglio1_BENI set  ammontareinEuro=-ammontareinEuro,ammontareinValuta=-ammontareinValuta,codTransazione=1
				 where flagvariation='S' and flagpaired='S'
update #Dettaglio3_SERVIZI set ammontareinEuro=-ammontareinEuro,ammontareinValuta=-ammontareinValuta
				 where flagvariation='S' and flagpaired='S'
 

--azzera annorif e meserif per tutte le righe tranne che per le variazioni non compensate
update #Dettaglio1_BENI set annorif=null, meserif=null,trimrif=null where flagvariation='N' or flagpaired='S'
update #Dettaglio3_SERVIZI set annorif=null, meserif=null,trimrif=null where flagvariation='N' or flagpaired='S'

--questo perché nella group by vanno raggruppate




IF(@tiporecord = 'B')
Begin
	SELECT 
	annorif ,
	meserif ,
	trimrif,
	segno_variazione,

	codiceIVA, 				-- codicestatomembro= Codice dello Stato membro dell'acquirente/fornitore + Codice IVA dell'acquitente /fornitore = DE123456788
	SUM(ammontareinEuro),		-- numerico -- Ammontare delle operazioni in euro
	SUM(ammontareinValuta),		-- numerico -- Ammontare delle operazioni in valuta
	codTransazione,			-- Codice della natura dela transazione
	codNomenclatura,		-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg,				-- numerico -- Massa netta in kilogrammi
	unitasupp,				-- numerico -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	REPLICATE('0',13) as valorestatisticoinEuro,	-- valorestatisticoinEuro  numerico -- Valore statistico in euro
	REPLICATE(' ',1) as codConsegna,	-- codConsegna,		 Codice delle condizioni di consegna	
	REPLICATE('0',1) as codTrasporto,	-- codTrasporto,	numerico -- Codice del modo di trasporto		

	codDest_codProv,		-- Codice del paese di destinazione/provenienza
	codOrigineMerce,		-- Codice del paese di origine della merce
	provOrigine_Dest		-- Codice della provincia di origine/destinazione della merce	
 FROM #Dettaglio1_BENI
	group by annorif,meserif,trimrif,segno_variazione,codiceIVA,codTransazione,codNomenclatura,massainkg,unitasupp,
			codDest_codProv,codOrigineMerce,provOrigine_Dest
	order by segno_variazione,annorif,meserif
End

IF(@tiporecord = 'S')
Begin
	SELECT 
	annorif ,
	meserif ,
	trimrif,
	segno_variazione,

	codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
	SUM(ammontareinEuro),			-- numerico Len.13 -- Ammontare delle operazioni in euro
	SUM(ammontareinValuta),			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura ,				-- Numero Fattura
	datafattura ,				-- Data fattura formato (ggmmaa)
	codServizio ,				-- numerico -- Codice del Servizio
	modErogazione ,				-- Modalità di erogazione
	modpagamento ,				-- Modalità pagamento/incasso 
	codPaesePagamento 			-- Codice del paese di Pagamento
 FROM #Dettaglio3_SERVIZI
	group by annorif,meserif,trimrif,segno_variazione,codiceIVA,numerofattura,datafattura,codServizio,modErogazione,
		modpagamento,codPaesePagamento
	order by segno_variazione,annorif,meserif


End
	
DROP TABLE #Dettaglio1_BENI
DROP TABLE #Dettaglio3_SERVIZI

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--- exp_mod_intrastat_unified {ts '2010-05-31 00:00:00000'}, '2010', '5', null, 'A', 'M', 'XXXX', '123456', '0', 'A', '1'
-- select * from registry R left outer join expense E on E.idreg= R.idreg+999999999 where isnull(E.idreg,-2) is null
--EXEC exp_mod_intrastat 2010,5,null,'A','M','B'
--select 3/3+1

--EXEC exp_mod_intrastat 2014,5,null,'A','M','B'

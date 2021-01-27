
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_docvendita_amm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_docvendita_amm]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE           PROCEDURE [rpt_docvendita_amm]
(
	@ayear int,
	@printkind char(1),
	@idinvkind int,
	@ninv_start int,
	@ninv_stop int,
	@official char(1),
	@autoinvoice char(1)
)
AS BEGIN
--	exec rpt_docvendita_amm 2019, 'I', 4, 13, 13, 'N','N'
	
IF @ayear = 0
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #sellingdoc
(
	header  varchar(150),	
	address varchar(150),
	ninv int,
	docdate datetime,
	idreg int,
	packinglistnum varchar(25),
	packinglistdate datetime,
	paymentexpiring smallint,
	idexpirationkind int,
	ref_desc varchar(150),
	description varchar(150),
	idcurrency int,
	exchangerate float,
	idivakind int,
	npackage decimal(19,2),
	discount float,
	taxable decimal(19,5),
	tax decimal(19,6),
	taxabletotal decimal(19,2),
	total decimal(19,2),
	notes varchar(400),
	notes1 text,
	notes2 text,
	notes3 text,
	ivadeferred varchar(255),
	invoicedesc varchar(150),
	doc varchar(35),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	idtreasurer int,
	banktitle varchar(50),
	cabtitle varchar(50),
	cin varchar(20),
	idbank varchar(20),
	idcab varchar(20),
	cc varchar(30),	
	descrizione varchar(150),
	addressbank varchar(100),
	iban varchar(50),
	bic varchar(15),
	nc varchar(1),
	autoinvoice char(1),
	invkind_real varchar(50),	
	ninv_real int,
	printingcode_real varchar(20),
	doc_real varchar(35),
	docdate_real datetime,
	AV_real char(1),
	flagbankitaliaproceeds char(1),  -- accredito banca d'italia
	flag_enable_split_payment char(1)
)


CREATE TABLE #printingdoc (num int, idinvkind_real int, ninv_real int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num, idinvkind_real, ninv_real) 
	SELECT ninv, invoice.idinvkind_real, invoice.ninv_real FROM invoice
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	WHERE (invoicekind.flag&1)<>0
		AND invoice.yinv = @ayear
		AND invoice.officiallyprinted <> 'S'
		AND invoicekind.idinvkind  = @idinvkind 
		AND (
		(@autoinvoice = 'N' AND isnull(invoice.autoinvoice,'') = 'N' )
		OR
		(@autoinvoice = 'S' AND  isnull(invoice.autoinvoice,'') = 'S' )
		)

END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num, idinvkind_real, ninv_real) 
	SELECT ninv, invoice.idinvkind_real, invoice.ninv_real FROM invoice
	WHERE (yinv = @ayear)
		AND (ninv BETWEEN @ninv_start AND @ninv_stop)
		AND (idinvkind = @idinvkind)
		AND (
		(@autoinvoice = 'N' AND isnull(invoice.autoinvoice,'') = 'N' )
		OR
		(@autoinvoice = 'S' AND  isnull(invoice.autoinvoice,'') = 'S' )
		)
END
	

DECLARE @ivadeferred varchar(255)
SET @ivadeferred = 'IVA ad esigibilità differita ai sensi dell''Articolo 6 Comma 5 D.P.R. 633/72'
CREATE TABLE #invoicedetail
(
	idinvkind int,
	yinv int,
	ninv int,
	idivakind int,
	detaildescription varchar(150),
	npackage decimal(19,2),
	discount float,
	taxable decimal(19,5),
	tax decimal(19,6),	
	annotations varchar(400),
	idupb varchar(36)
)
/*
il raggrupp. serve xkè nella stampa voglio vedere i dett. fattura ragrupp. in base al raggruppamento 
delle righe del contratto attivo. nel caso in cui i dett.fattura non fossero associati ad alcun
contratto attivo si raggruppa in base all'idgropu della fattura. ES:se ho due dett. preventivo ciascuno splittato in due e metto 
tutti e 4 i dettagli in fattura nella stampa ne vedrò 2. Se poi vado a splittare un dettagli di questa fattura, 
avrò 5 dett. in fattura ma nella stampa visualizzo sempre due righe (xkè chiaramente il raggrupp. del prev non cambia.
 e non cambia neanche il raggrupp. della fattura)
*/
INSERT INTO #invoicedetail
SELECT 
	i.idinvkind ,
	i.yinv ,
	i.ninv ,
	i.idivakind,
	i.detaildescription,
	i.npackage,
	i.discount,
	case when (ivakind.flag & 512 = 0 ) then sum(i.taxable) 
		when (ivakind.flag & 512 <> 0 ) then sum(i.taxable) + isnull(sum(i.tax),0) 
	end	,
	case when (ivakind.flag & 512 = 0 ) then sum(i.tax) 
		when (ivakind.flag & 512 <> 0 ) then 0
	end,
	i.annotations,
	i.idupb
FROM    invoicedetail i	
join ivakind on ivakind.idivakind = i.idivakind
left outer join estimatedetail e		on e.idestimkind = i.idestimkind	and e.yestim = i.yestim	and e.nestim = i.nestim	and e.rownum = i.estimrownum		
WHERE   i.yinv = @ayear				AND i.idinvkind= @idinvkind	AND i.ninv in (SELECT num FROM #printingdoc  WHERE idinvkind_real is null)
	and (isnull(i.flagbit,0) & 4) = 0
GROUP BY i.idinvkind,i.yinv,i.ninv,i.idivakind,ivakind.flag,
	e.idestimkind,e.yestim,e.nestim,e.idgroup,
	isnull(e.idgroup,i.idgroup),
	i.detaildescription,
	i.npackage,i.discount,i.annotations,i.idupb

INSERT INTO #invoicedetail
SELECT 
	r.idinvkind_real ,
	r.yinv_real ,
	r.ninv_real ,
	i.idivakind,
	i.detaildescription,
	i.npackage,
	i.discount,
	case when (ivakind.flag & 512 = 0 ) then sum(i.taxable) 
		when (ivakind.flag & 512 <> 0 ) then sum(i.taxable) + isnull(sum(i.tax),0) 
	end	,
	case when (ivakind.flag & 512 = 0 ) then sum(i.tax) 
		when (ivakind.flag & 512 <> 0 ) then 0
	end,
	i.annotations,
	i.idupb
FROM invoice r
JOIN invoicedetail i 	ON r.idinvkind_real = i.idinvkind 	AND r.yinv_real = i.yinv	AND r.ninv_real = i.ninv
join ivakind on ivakind.idivakind = i.idivakind
left outer join estimatedetail e	on e.idestimkind = i.idestimkind	and e.yestim = i.yestim	and e.nestim = i.nestim	and e.rownum = i.estimrownum
WHERE   r.yinv = @ayear 
	AND r.idinvkind= @idinvkind
	AND r.ninv in (SELECT num FROM #printingdoc  WHERE idinvkind_real is not null)
	and (isnull(i.flagbit,0) & 4) = 0
GROUP BY r.idinvkind_real, r.yinv_real,	r.ninv_real,i.idivakind,
	e.idestimkind,e.yestim,e.nestim,e.idgroup,
	isnull(e.idgroup,i.idgroup),
	i.detaildescription,ivakind.flag,
	i.npackage,i.discount,i.annotations,i.idupb


INSERT INTO #sellingdoc
(
	header,	
	address,
	ninv,
	docdate,
	idreg,
	packinglistnum,	
	packinglistdate,
	paymentexpiring,
	idexpirationkind,
	ref_desc,
	idcurrency,
	exchangerate,
	idivakind,
	description,
	npackage,
	discount,
	taxable,
	tax,
	taxabletotal,
	total,
	notes,
	notes1,
	notes2,
	notes3,
	ivadeferred,
	invoicedesc,
	doc,
	idupb,
	idtreasurer,
	banktitle,
	cabtitle,
	cin,
	idbank,
	idcab,
	cc,	
	descrizione,
	addressbank,
	iban,
	bic,
	nc,
	autoinvoice,
	printingcode_real,
	flagbankitaliaproceeds,
	flag_enable_split_payment 
)
SELECT 
	IK.header,	
	IK.address,
	I.ninv,
	I.docdate,
	I.idreg,
	I.packinglistnum,
	I.packinglistdate,
	I.paymentexpiring,
	I.idexpirationkind,
	I.registryreference,
	I.idcurrency,
	ISNULL(I.exchangerate,1),
	D.idivakind,
	D.detaildescription,
	D.npackage,
	D.discount,
	D.taxable,
	D.tax,
	CONVERT(decimal(19,2),
		ROUND(
		      D.taxable*
		      D.npackage*
		      CONVERT(decimal(19,10),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	),
	CONVERT(DECIMAL(19,2),
		ROUND(
		      D.taxable*
		      D.npackage*
		      CONVERT(decimal(19,10),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	)+
	ISNULL(D.tax,0)	,
	D.annotations,
	IK.notes1,
	IK.notes2,
	IK.notes3,
	CASE
		WHEN (I.flagdeferred = 'S'and  isnull(I.flag_enable_split_payment,'N')='N')THEN @ivadeferred
		ELSE NULL
	END,
	I.description,
	I.doc,
	D.idupb,
	I.idtreasurer,
	T.banktitle,
	T.cabtitle,
	T.cin,
	T.idbank,
	T.idcab,
	T.cc,	
	T.description,
	T.address,
	T.iban,
	T.bic,
	CASE WHEN (IK.flag & 4) <> 0 THEN 'S' 
	ELSE 'N'
	END,
	ISNULL(I.autoinvoice,'N'),
	IK.printingcode,
	ISNULL(R.flagbankitaliaproceeds,'N'),
	isnull(I.flag_enable_split_payment,'N')
FROM #invoicedetail D
JOIN invoice I
	ON isnull(I.idinvkind_real, I.idinvkind) = D.idinvkind
	AND isnull(I.yinv_real, I.yinv) = D.yinv
	AND isnull(I.ninv_real, I.ninv) = D.ninv
LEFT OUTER JOIN treasurerview T		ON I.idtreasurer = T.idtreasurer and T.ayear = @ayear
JOIN invoicekind IK					ON IK.idinvkind= D.idinvkind
JOIN registry R						ON R.idreg = I.idreg
WHERE I.yinv = @ayear
	AND I.ninv IN (SELECT num from #printingdoc)
	AND I.idinvkind = @idinvkind

DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @codeaddcustomer varchar(20)
SET @codeaddcustomer = '10_SW_FAT2'

DECLARE @stand int
SELECT  @stand = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @nostand int
SELECT  @nostand = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @addcustomer int
SELECT  @addcustomer = idaddress FROM address WHERE codeaddress = @codeaddcustomer

CREATE TABLE #address_sellingdoc
(
	idaddresskind int,
    idreg int,
	officename varchar(50),
	address varchar(100),	
	location varchar(120),
	cap varchar(20),		
	province varchar(2),
	nation varchar(65)
)
INSERT INTO #address_sellingdoc
SELECT 
	idaddresskind,
	idreg, 
	officename, 
	address,
	location = ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	cap = registryaddress.cap,
	province = geo_country.province,
	nation =
	CASE
		WHEN flagforeign = 'N' THEN 'ITALIA'
		ELSE geo_nation.title
	END
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE (registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			AND cdi.idreg = registryaddress.idreg))
	AND (idreg IN (SELECT idreg FROM #sellingdoc))
DELETE #address_sellingdoc
	WHERE #address_sellingdoc.idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM #address_sellingdoc r2 
		WHERE #address_sellingdoc.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #address_sellingdoc
	WHERE #address_sellingdoc.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #address_sellingdoc r2 
		WHERE #address_sellingdoc.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #address_sellingdoc
	WHERE (
		SELECT COUNT(*) FROM #address_sellingdoc r2 
		WHERE #address_sellingdoc.idreg = r2.idreg
	)>1

CREATE TABLE #address_customer
(
	idaddresskind int,
    idreg int,
	officename varchar(50),
	address varchar(100),	
	location varchar(120),
	cap varchar(20),		
	province varchar(2),
	nation varchar(65)
)

INSERT INTO #address_customer
SELECT 
	idaddresskind,
	idreg, 
	officename, 
	address,
	location = ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	cap = registryaddress.cap,
	province = geo_country.province,
	nation =
	CASE
		WHEN flagforeign = 'N' THEN 'ITALIA'
		ELSE geo_nation.title
	END
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE (registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			AND cdi.idreg = registryaddress.idreg))
	AND (idreg IN (SELECT idreg FROM #sellingdoc))
	AND registryaddress.idaddresskind = @addcustomer

DECLARE @banktitle varchar(50)
DECLARE @cabtitle varchar(50)
DECLARE @cin varchar(20)
DECLARE @idbank varchar(20)
DECLARE @idcab varchar(20)
DECLARE @cc varchar(30)		
DECLARE @description varchar(150)
DECLARE @addressbank varchar(100)
DECLARE @iban varchar(50)	
DECLARE @bic varchar(15)		

DECLARE @iban_f24 varchar(50)  -- è lo stesso conto di addebito dell'F24EP
SELECT  @iban_f24 = iban_f24 from config WHERE ayear = @ayear

SELECT @banktitle = banktitle, @cabtitle = cabtitle, @cin = cin, @idbank = idbank, @idcab = idcab, @cc = cc, @iban = iban,
@bic = bic, @description=description, @addressbank=address
FROM   treasurerview
WHERE  flagdefault = 'S' and ayear = @ayear

DECLARE @invkind varchar(50)
SELECT  @invkind = description FROM invoicekind WHERE idinvkind = @idinvkind


update #sellingdoc set
upb = (select title from upb where #sellingdoc.idupb=upb.idupb),
codeupb = (select codeupb from upb where #sellingdoc.idupb=upb.idupb)

IF(@autoinvoice = 'S')
Begin
	UPDATE	#sellingdoc
	SET
		invkind_real = invoicekind.description,
		ninv_real = #printingdoc.ninv_real,
		doc_real = M.doc,
		docdate_real = M.docdate,
		AV_real =CASE
				WHEN ((invoicekind.flag&1)=0) THEN 'A'
				WHEN ((invoicekind.flag&1)<>0) THEN 'V'
				END,
		printingcode_real = invoicekind.printingcode
	FROM #printingdoc
	JOIN invoice M	
		ON  M.idinvkind = #printingdoc.idinvkind_real
		AND M.ninv = #printingdoc.ninv_real
	JOIN invoicekind
		ON invoicekind.idinvkind = #printingdoc.idinvkind_real
	WHERE #sellingdoc.ninv = #printingdoc.num
		AND M.yinv = @ayear
End

DECLARE @AV char(1)
SET @AV= ( SELECT
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END
	FROM invoicekind
	where idinvkind=@idinvkind
)

SELECT
	@invkind AS invkind,
	#sellingdoc.header,
	#sellingdoc.address as dep_address,
	#sellingdoc.ninv,
	#sellingdoc.invkind_real,
	#sellingdoc.ninv_real,
	#sellingdoc.doc_real,
	#sellingdoc.docdate_real,
	#sellingdoc.docdate,
	#sellingdoc.idreg,
	#sellingdoc.packinglistnum,	
	#sellingdoc.packinglistdate,
	R.title AS registry,
	#address_sellingdoc.officename, 
	#address_sellingdoc.address, 
	#address_sellingdoc.location, 
	#address_sellingdoc.cap,
	#address_sellingdoc.province,  
	#address_sellingdoc.nation, 
	#address_customer.officename as 'cust_officename', 
	#address_customer.address as 'cust_address', 
	#address_customer.location as 'cust_location', 
	#address_customer.cap as 'cust_cap',
	#address_customer.province as 'cust_province',  
	#address_customer.nation as 'cust_nation', 
	REPLACE(expirationkind.shorttitle,'%',isnull(#sellingdoc.paymentexpiring,'')) as expiration,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN #sellingdoc.banktitle
		ELSE @banktitle 
	END AS bank,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN #sellingdoc.cabtitle
		ELSE @cabtitle 
	END AS cabtitle,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN #sellingdoc.cin
		ELSE @cin 
	END AS cin,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN #sellingdoc.idbank
		ELSE @idbank 
	END AS  idbank,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN #sellingdoc.idcab
		ELSE @idcab 
	END AS idcab,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN  #sellingdoc.cc
		ELSE @cc 
	END AS cc,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN  #sellingdoc.iban
		ELSE @iban 
	END AS iban,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN  #sellingdoc.descrizione
		ELSE @description 
	END as descrizione,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN  #sellingdoc.addressbank
		ELSE @addressbank 
	END as addressbank,
	CASE 
		WHEN #sellingdoc.idtreasurer IS NOT NULL THEN  #sellingdoc.bic
		ELSE @bic 
	END AS bic,
	ISNULL(R.cf,R.foreigncf) AS cf,
	R.p_iva AS p_iva,
	#sellingdoc.ref_desc,
	#sellingdoc.description,
	currency.codecurrency as idcurrency,
	#sellingdoc.exchangerate,
	IK.description AS ivakind_desc,
	#sellingdoc.npackage AS number,
	#sellingdoc.discount,
	#sellingdoc.taxable,
	case when (IK.flag & 512 = 0 ) then IK.rate
		when (IK.flag & 512 <> 0 ) then 0
	end	as ivarate, 
	#sellingdoc.tax,
	#sellingdoc.taxabletotal,
	#sellingdoc.total,
	#sellingdoc.notes,
	#sellingdoc.notes1,
	#sellingdoc.notes2,
	#sellingdoc.notes3,
	#sellingdoc.ivadeferred,
	#sellingdoc.invoicedesc,
	#sellingdoc.doc,
	#sellingdoc.upb,
	#sellingdoc.codeupb,
	#sellingdoc.nc,
	#sellingdoc.autoinvoice,
	isnull(AV_real, @AV) as av, --> Per le Autofattura senza dettagli consideriamo il registro della madre.
	#sellingdoc.printingcode_real,
	#sellingdoc.flagbankitaliaproceeds,
	@iban_f24 as iban_f24,
	SUBSTRING(@iban_f24,21,7) as nacc_bankitalia,
	#sellingdoc.flag_enable_split_payment
FROM #sellingdoc				
LEFT OUTER JOIN #address_sellingdoc		ON #address_sellingdoc.idreg = #sellingdoc.idreg
LEFT OUTER JOIN #address_customer		ON #address_customer.idreg = #sellingdoc.idreg
LEFT OUTER JOIN registry R				ON R.idreg = #sellingdoc.idreg
JOIN ivakind IK							ON IK.idivakind = #sellingdoc.idivakind
LEFT OUTER JOIN currency				ON currency.idcurrency = #sellingdoc.idcurrency
LEFT OUTER JOIN expirationkind			ON expirationkind.idexpirationkind = #sellingdoc.idexpirationkind
ORDER BY #sellingdoc.ninv ASC
END










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



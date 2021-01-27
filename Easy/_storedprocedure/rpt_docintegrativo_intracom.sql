
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_docintegrativo_intracom]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_docintegrativo_intracom]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
CREATE  PROCEDURE [rpt_docintegrativo_intracom]
(
	@ayear int,
	@printkind char(1),
	@idinvkind int,
	@ninv_start int,
	@ninv_stop int,
	@official char(1)
)
AS BEGIN
--	exec [rpt_docintegrativo_intracom] 2010, 'I', 2, 1, 100, 'N'
IF @ayear = 0
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #invoice 
(
	header  varchar(150),	
	dep_address varchar(150),
	ninv int,
	adate datetime,
	docdate datetime,
	idreg int,
	packinglistnum varchar(25),
	packinglistdate datetime,
	paymentexpiring smallint,
	idexpirationkind int,
	idtreasurer int,
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
	taxabletotal_valuta decimal(19,2),
	total decimal(19,2),
	va3type	char(1),
	idintrastatcode int, 
	idintrastatmeasure int, 
	weight decimal(19,2), 
	idintrastatkind varchar(2),
	intrastatoperationkind char(1),
	idintrastatservice  int,
	idintrastatsupplymethod int ,
	idintrastatpaymethod int,
	notes varchar(400),
	ivadeferred varchar(255),
	invoicedesc varchar(150),
	doc varchar(35),
	invoiceannotations text,
	notes1 text,
	notes2 text,
	notes3 text,
    islinkedbill char(1),
	flagvariation char(1),
	idupb varchar(36),
	flagintracom char(1),
	flagactivity int,
	iso_origin varchar(2),
	iso_provenance varchar(2),
	idcountry_destination int,
	iso_payment varchar(2),
	invkind_real varchar(50),
	header_real varchar(50),	
	ninv_real int,
	printingcode_real varchar(20),
	doc_real varchar(35),
	docdate_real datetime,
	AV_real char(1)
)

-- i campi _real sono valorizzati solo per le autofatture
CREATE TABLE #printingdoc (num int, idinvkind_real int, ninv_real int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num, idinvkind_real, ninv_real) 
	SELECT ninv, invoice.idinvkind_real, invoice.ninv_real FROM invoice
	WHERE invoice.yinv = @ayear
		AND invoice.officiallyprinted <> 'S'
		AND invoice.idinvkind  = @idinvkind
		AND ISNULL(flagintracom,'N') = 'S'

END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num, idinvkind_real, ninv_real) 
	SELECT ninv, invoice.idinvkind_real, invoice.ninv_real FROM invoice
	WHERE (yinv = @ayear)
		AND (ninv BETWEEN @ninv_start AND @ninv_stop)
		AND (idinvkind = @idinvkind)
		AND ISNULL(flagintracom,'N') = 'S'
END
	
DECLARE @ivadeferred varchar(255)
SET @ivadeferred = 'IVA ad esigibilità differita ai sensi dell''Articolo 6 Comma 5 D.P.R. 633/72'
CREATE TABLE #invoicedetail
(
	idinvkind int,
	yinv int,
	ninv int,
	idivakind int,
	idupb varchar(36),
	detaildescription varchar(150),
	npackage decimal(19,2),
	discount float,
	taxable decimal(19,5), -- può essere in euro o in valuta
	tax decimal(19,6),	 -- solo euro
	idintrastatcode int, 
	idintrastatmeasure int, 
	weight decimal(19,2), 
	intrastatoperationkind char(1),
	idintrastatservice  int,
	idintrastatsupplymethod int ,
	va3type	char(1),
	annotations varchar(400)
)
/*
il raggrupp. serve xkè nella stampa voglio vedere i dett. fattura ragrupp. in base al raggruppamento 
delle righe del contratto passivo. nel caso in cui i dett.fattura non fossero associati ad alcun
contratto passivo si raggruppa in base all'idgropu della fattura. ES:se ho due dett. preventivo ciascuno splittato in due e metto 
tutti e 4 i dettagli in fattura nella stampa ne vedrò 2. Se poi vado a splittare un dettagli di questa fattura, 
avrò 5 dett. in fattura ma nella stampa visualizzo sempre due righe (xkè chiaramente il raggrupp. del prev non cambia.
 e non cambia neanche il raggrupp. della fattura)
*/
INSERT INTO #invoicedetail
(
	idinvkind,
	yinv,
	ninv,
	idivakind,
	idupb,
	detaildescription,
	npackage,
	discount,
	taxable,
	tax,	
	idintrastatcode, 
	idintrastatmeasure, 
	weight, 
	va3type,
	intrastatoperationkind,
	idintrastatservice,
	idintrastatsupplymethod,
	annotations 
	)
SELECT 
	i.idinvkind ,
	i.yinv ,
	i.ninv ,
	i.idivakind,
	i.idupb,
	i.detaildescription,
	i.npackage,
	i.discount,
	sum(i.taxable),
	sum(i.tax), 	
	i.idintrastatcode, 
	i.idintrastatmeasure, 
	i.weight, 
	i.va3type,
	i.intrastatoperationkind,
	i.idintrastatservice,
	i.idintrastatsupplymethod,
	i.annotations
FROM    invoicedetail i
left outer join mandatedetail m
	on m.idmankind = i.idmankind
	and m.yman = i.yman
	and m.nman = i.nman
	and m.rownum = i.manrownum
WHERE   i.yinv = @ayear
	AND i.idinvkind= @idinvkind
	AND i.ninv in (SELECT num FROM #printingdoc WHERE idinvkind_real is null)
GROUP BY i.idinvkind,i.yinv,i.ninv,i.idivakind,
	i.idmankind,i.yman,i.nman,i.idgroup,
	isnull(m.idgroup,i.idgroup),
	i.detaildescription,
	i.idintrastatcode, 
	i.idintrastatmeasure, 
	i.weight, i.va3type,
	i.intrastatoperationkind,
	i.idintrastatservice,
	i.idintrastatsupplymethod,
	i.npackage,i.discount,i.annotations,i.idupb

INSERT INTO #invoice
(
	ninv,
	adate,
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
	idupb,
	description,
	npackage,
	discount,
	taxable,
	tax,
	taxabletotal,
	taxabletotal_valuta,
	total,
	idintrastatcode, 
	idintrastatmeasure, 
	weight, 
	va3type,
	intrastatoperationkind,
	idintrastatservice,
	idintrastatsupplymethod,
	idintrastatpaymethod,
	notes,
	ivadeferred,
	invoicedesc,
	doc,
	invoiceannotations,
	notes1,
	notes2,
	notes3,
	flagvariation,
	flagintracom,
	idintrastatkind,
	iso_origin,
	iso_provenance,
	idcountry_destination, 
	iso_payment,
	printingcode_real
)
SELECT 
	I.ninv,
	I.adate,
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
	D.idupb,
	D.detaildescription,
	D.npackage,
	D.discount,
	D.taxable,
	D.tax,
	-- taxabletotal
	CONVERT(decimal(19,2),
		ROUND(
		      D.taxable*
		      D.npackage*
		      CONVERT(decimal(19,10),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	),
	--taxabletotal_valuta
	CONVERT(decimal(19,2),
		ROUND(
		      D.taxable*
		      D.npackage*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	),
	-- total
	CONVERT(DECIMAL(19,2),
		ROUND(
		      D.taxable*
		      D.npackage*
		      CONVERT(decimal(19,10),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	)
	+ ISNULL(D.tax,0),
	D.idintrastatcode, 
	D.idintrastatmeasure, 
	D.weight, 
	D.va3type,
	D.intrastatoperationkind,
	D.idintrastatservice,
	D.idintrastatsupplymethod,
	I.idintrastatpaymethod,
	D.annotations,
	CASE
		WHEN I.flagdeferred = 'S' THEN @ivadeferred
		ELSE NULL
	END,
	I.description,
	I.doc,
	I.txt,
	invoicekind.notes1,
	invoicekind.notes2,
	invoicekind.notes3,
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END,
	I.flagintracom,
	I.idintrastatkind,
	I.iso_origin,
	I.iso_provenance,
	I.idcountry_destination, 
	I.iso_payment,
	invoicekind.printingcode
FROM #invoicedetail D
JOIN invoice I
	ON isnull(I.idinvkind_real, I.idinvkind) = D.idinvkind
	AND isnull(I.yinv_real, I.yinv) = D.yinv
	AND isnull(I.ninv_real, I.ninv) = D.ninv
JOIN invoicekind
	ON I.idinvkind = invoicekind.idinvkind
JOIN registry R
	ON R.idreg = I.idreg
WHERE I.yinv = @ayear
	AND I.ninv IN (SELECT num from #printingdoc)
	AND I.idinvkind = @idinvkind


update #invoice SET flagactivity = 
(SELECT TOP 1 IRK.FLAGACTIVITY 
   FROM invoicekind INK
JOIN ivaregister IR
	ON IR.idinvkind = INK.idinvkind 
	AND IR.yinv = @ayear
	AND IR.ninv = #invoice.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
	WHERE  INK.idinvkind = @idinvkind
)
--select * from  #invoicedetail
--select * from  #invoice

DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

CREATE TABLE #address_supplier
(
	idaddresskind int,
    idreg int,
	officename varchar(50),
	address varchar(100),	
	location varchar(120),
	cap varchar(16),		
	province varchar(2),
	nation varchar(65)
)
INSERT INTO #address_supplier
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
	AND (idreg IN (SELECT idreg FROM #invoice))
DELETE #address_supplier
	WHERE #address_supplier.idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM #address_supplier r2 
		WHERE #address_supplier.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #address_supplier
	WHERE #address_supplier.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #address_supplier r2 
		WHERE #address_supplier.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #address_supplier
	WHERE (
		SELECT COUNT(*) FROM #address_supplier r2 
		WHERE #address_supplier.idreg = r2.idreg
	)>1



DECLARE @invkind varchar(50)
SELECT  @invkind = description FROM invoicekind WHERE idinvkind = @idinvkind

UPDATE #invoice SET header = invoicekind.header, dep_address = invoicekind.address FROM  invoicekind WHERE idinvkind = @idinvkind

 
DECLARE @AV char(1)
SET @AV= ( SELECT
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END
	FROM invoicekind
	WHERE idinvkind=@idinvkind
)
SELECT
	@invkind AS invkind,
	#invoice.header,
	#invoice.dep_address,
	#invoice.ninv,
	#invoice.adate,
	#invoice.docdate,
	#invoice.idreg,
	#invoice.packinglistnum,	
	#invoice.packinglistdate,
	R.title AS registry,
	#address_supplier.officename, 
	#address_supplier.address, 
	#address_supplier.location, 
	#address_supplier.cap,
	#address_supplier.province,  
	#address_supplier.nation, 
	REPLACE(expirationkind.shorttitle,'%', convert(varchar(4),#invoice.paymentexpiring) + ' gg') as expiration,
	'P.I. ' + R.p_iva AS PivaCF, 
	#invoice.ref_desc,
	#invoice.description,
	currency.codecurrency as codecurrency,
	currency.description as currency,
	#invoice.exchangerate,
	IK.description as ivakind_desc, 
	#invoice.idupb,
	upb.title as upb,
	#invoice.npackage AS number,
	#invoice.discount,
	#invoice.taxable,
	IK.rate  as ivarate, 
	#invoice.tax,
	#invoice.taxabletotal,
	#invoice.taxabletotal_valuta,
	#invoice.total,
	ISNULL(#invoice.description,'') + ' ' + ISNULL(#invoice.notes,'') as uniondescr,-->> #invoice.notes,
	#invoice.ivadeferred,
	#invoice.invoicedesc,
	#invoice.doc,
	#invoice.invoiceannotations,
	#invoice.notes1,
	#invoice.notes2,
	#invoice.notes3,
	#invoice.flagvariation,
	ITK.idivataxablekind,
	ITK.description as ivataxablekind,
	CASE #invoice.flagactivity
		WHEN 2 THEN 'Attività commerciale'
		WHEN 3 THEN 'Attività commerciale/istituzionale'
		WHEN 1 THEN 'Attività istituzionale'
	END AS 'activity',
	intrastatkind.description as 'intrastatkind',
	#invoice.iso_origin,
	intrastatnation_origin.description as 'intrastatnation_origin',
	#invoice.iso_provenance,
	intrastatnation_provenance.description as 'intrastatnation_provenance',
	#invoice.idcountry_destination,
	geo_country_destination.title as 'country_destination',
	intrastatcode.code as 'codeintrastat',
	intrastatcode.description as 'intrastatcode',
	intrastatmeasure.code as 'codemeasure',
	intrastatmeasure.description as 'intrastatmeasure',
	#invoice.weight, 
	#invoice.va3type,
	CASE #invoice.va3type
    WHEN 'S' THEN 'Beni ammortizzabili'
    WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
    WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
    WHEN 'A' THEN 'Altri acquisti e importazioni'
	END as 'activitykindvf24',
	#invoice.intrastatoperationkind,  -- 'Beni/Servizi'
 	#invoice.iso_payment,
	intrastatnation_payment.description as 'intrastatnation_payment',
	intrastatservice.code as 'codeservice',
	intrastatservice.description as 'intrastatservice',
	intrastatsupplymethod.code as 'codesupplymethod',
	intrastatsupplymethod.description as 'intrastatsupplymethod',
	intrastatpaymethod.code as 'codepaymethod',
	intrastatpaymethod.description as 'intrastatpaymethod'
FROM #invoice
JOIN ivakind IK
	ON IK.idivakind = #invoice.idivakind
JOIN ivataxablekind ITK
	ON IK.idivataxablekind = ITK.idivataxablekind	
LEFT OUTER JOIN #address_supplier
	ON #address_supplier.idreg = #invoice.idreg
LEFT OUTER JOIN registry R
	ON R.idreg = #invoice.idreg
LEFT OUTER JOIN currency
	ON currency.idcurrency = #invoice.idcurrency
LEFT OUTER JOIN upb
	ON upb.idupb = #invoice.idupb
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #invoice.idexpirationkind
LEFT OUTER JOIN intrastatkind 
	ON intrastatkind.idintrastatkind = #invoice.idintrastatkind
LEFT OUTER JOIN intrastatnation intrastatnation_origin
	ON intrastatnation_origin.idintrastatnation = #invoice.iso_origin
LEFT OUTER JOIN intrastatnation intrastatnation_provenance
	ON intrastatnation_provenance.idintrastatnation = #invoice.iso_provenance
LEFT OUTER JOIN geo_country geo_country_destination
	ON geo_country_destination.idcountry = #invoice.idcountry_destination
LEFT OUTER JOIN intrastatcode 
	ON intrastatcode.idintrastatcode = #invoice.idintrastatcode
	AND intrastatcode.ayear = @ayear
LEFT OUTER JOIN intrastatmeasure
	ON  intrastatmeasure.idintrastatmeasure = intrastatcode.idintrastatmeasure
LEFT OUTER JOIN intrastatservice
	ON intrastatservice.idintrastatservice = #invoice.idintrastatservice
	AND intrastatservice.ayear = @ayear
LEFT OUTER JOIN intrastatnation intrastatnation_payment
	ON intrastatnation_payment.idintrastatnation = #invoice.iso_payment
LEFT OUTER JOIN intrastatsupplymethod
	ON  intrastatsupplymethod.idintrastatsupplymethod = #invoice.idintrastatsupplymethod
LEFT OUTER JOIN intrastatpaymethod
	ON  intrastatpaymethod.idintrastatpaymethod = #invoice.idintrastatpaymethod
 
ORDER BY #invoice.ninv ASC
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

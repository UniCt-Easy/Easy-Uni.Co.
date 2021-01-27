
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_docvendita]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_docvendita]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE  PROCEDURE [rpt_docvendita]
(
	@ayear int,
	@printkind char(1),
	@idinvkind int,
	@ninv_start int,
	@ninv_stop int,
	@official char(1),
	@showcfpiva char(1),
	@autoinvoice char(1)
)
AS BEGIN
--	exec rpt_docvendita 2019, 'I', 4, 13, 13, 'N', 'P','N'
IF @ayear = 0
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #sellingdoc
(
	header  varchar(150),	
	dep_address varchar(150),
	ninv int,
	docdate datetime,
	idreg int,
	packinglistnum varchar(25),
	packinglistdate datetime,
	paymentexpiring smallint,
	idexpirationkind int,
	idtreasurer int,
	banktitle varchar(150),
	cabtitle varchar(50),
	cin varchar(20),
	idbank varchar(20),
	idcab varchar(20),
	cc varchar(30),	
	iban varchar(50),
	bic varchar(15),
	header_treasurer varchar(150),
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
	autoinvoice char(1),
	invkind_real varchar(50),
	header_real varchar(50),	
	ninv_real int,
	printingcode_real varchar(20),
	doc_real varchar(35),
	docdate_real datetime,
	AV_real char(1),
	flagbankitaliaproceeds char(1),
	flag_enable_split_payment char(1),
	cupcode	varchar(15),
	cigcode	varchar(10)
)
CREATE TABLE #printingdoc (num int, idinvkind_real int, ninv_real int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num, idinvkind_real, ninv_real) 
	SELECT ninv, invoice.idinvkind_real, invoice.ninv_real FROM invoice
	WHERE invoice.yinv = @ayear
		AND invoice.officiallyprinted <> 'S'
		AND invoice.idinvkind  = @idinvkind 
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
	idupb varchar(36),
	detaildescription varchar(150),
	npackage decimal(19,2),
	discount float,
	taxable decimal(19,5),
	tax decimal(19,6),	
	annotations varchar(400),
	cupcode	varchar(15),
	cigcode	varchar(10)
)
/*
il raggrupp. serve xkè nella stampa voglio vedere i dett. fattura ragrupp. in base al raggruppamento 
delle righe del contratto attivo. nel caso in cui i dett.fattura non fossero associati ad alcun
contratto attivo si raggruppa in base all'idgropu della fattura. ES:se ho due dett. preventivo ciascuno splittato in due e metto 
tutti e 4 i dettagli in fattura nella stampa ne vedrò 2. Se poi vado a splittare un dettagli di questa fattura, 
avrò 5 dett. in fattura ma nella stampa visualizzo sempre due righe (xkè chiaramente il raggrupp. del prev non cambia.
 e non cambia neanche il raggrupp. della fattura)
*/
DECLARE @MostraUpb varchar(20)
SELECT  @MostraUpb = paramvalue FROM reportadditionalparam
	WHERE   reportname = 'fatturavendita' AND paramname = 'MostraUpb'

DECLARE @MostraCig varchar(20)
SELECT  @MostraCig = paramvalue FROM reportadditionalparam
	WHERE   reportname = 'fatturavendita' AND paramname = 'MostraCIG'

DECLARE @MostraCup varchar(20)
SELECT  @MostraCup = paramvalue FROM reportadditionalparam
	WHERE   reportname = 'fatturavendita' AND paramname = 'MostraCUP'

INSERT INTO #invoicedetail
SELECT 
	i.idinvkind ,
	i.yinv ,
	i.ninv ,
	i.idivakind,
	case when @MostraUpb = 'S' then i.idupb
		else null
	end,
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
	case when @MostraCup = 'S' then i.cupcode
		else null
	end,
	case when @MostraCig = 'S' then i.cigcode
		else null
	end
FROM    invoicedetail i
join ivakind
	on ivakind.idivakind = i.idivakind
left outer join estimatedetail e
	on e.idestimkind = i.idestimkind
	and e.yestim = i.yestim
	and e.nestim = i.nestim
	and e.rownum = i.estimrownum
WHERE   i.yinv = @ayear
	AND i.idinvkind= @idinvkind
	AND i.ninv in (SELECT num FROM #printingdoc WHERE idinvkind_real is null)
	and (isnull(i.flagbit,0) & 4) = 0
GROUP BY i.idinvkind,i.yinv,i.ninv,i.idivakind,
	e.idestimkind,e.yestim,e.nestim,e.idgroup,
	isnull(e.idgroup,i.idgroup),
	i.detaildescription,ivakind.flag,
	i.npackage,i.discount,i.annotations, ( case when @MostraUpb = 'S' then i.idupb else null end ),
	(case when @MostraCup = 'S' then i.cupcode else null end),	(case when @MostraCig = 'S' then i.cigcode 	else null end)


INSERT INTO #invoicedetail
SELECT 
	r.idinvkind_real,
	r.yinv_real,
	r.ninv_real,
	i.idivakind,
	case when @MostraUpb = 'S' then i.idupb
		else null
	end,
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
	case when @MostraCup = 'S' then i.cupcode
		else null
	end,
	case when @MostraCig = 'S' then i.cigcode
		else null
	end
FROM invoice r
JOIN invoicedetail i	ON r.idinvkind_real = i.idinvkind AND r.yinv_real = i.yinv	AND r.ninv_real = i.ninv
join ivakind
	on ivakind.idivakind = i.idivakind
left outer join estimatedetail e	on e.idestimkind = i.idestimkind and e.yestim = i.yestim and e.nestim = i.nestim and e.rownum = i.estimrownum
WHERE   r.yinv = @ayear		AND r.idinvkind= @idinvkind	AND r.ninv in (SELECT num FROM #printingdoc WHERE idinvkind_real is not null)
		and (isnull(i.flagbit,0) & 4) = 0
GROUP BY r.idinvkind_real, r.yinv_real,	r.ninv_real,i.idivakind,
	e.idestimkind,e.yestim,e.nestim,e.idgroup,
	isnull(e.idgroup,i.idgroup),
	i.detaildescription,ivakind.flag,
	i.npackage,i.discount,i.annotations, (case when @MostraUpb = 'S' then i.idupb else null end), 
	(case when @MostraCup = 'S' then i.cupcode else null end),	(case when @MostraCig = 'S' then i.cigcode 	else null end)


INSERT INTO #sellingdoc
(
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
	idupb,
	description,
	npackage,
	discount,
	taxable,
	tax,
	taxabletotal,
	total,
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
	autoinvoice,
	idtreasurer,
	banktitle,
	cabtitle,
	cin,
	idbank,
	idcab,
	cc,	
	iban,
	bic,
	header_treasurer,
	printingcode_real,
	flagbankitaliaproceeds,
	flag_enable_split_payment,
	cupcode,
	cigcode
)
SELECT 
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
	D.annotations,
	CASE
		WHEN (I.flagdeferred = 'S' and isnull(I.flag_enable_split_payment	,'N') ='N') THEN @ivadeferred
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
	ISNULL(I.autoinvoice,'N'),
	I.idtreasurer,
	T.banktitle,
	T.cabtitle,
	T.cin,
	T.idbank,
	T.idcab,
	T.cc,	
	T.iban,
	T.bic,
	T.header,
	invoicekind.printingcode,
	ISNULL(R.flagbankitaliaproceeds,'N'),
	isnull(I.flag_enable_split_payment	,'N'),
	D.cupcode,
	D.cigcode
FROM #invoicedetail D
JOIN invoice I				ON isnull(I.idinvkind_real, I.idinvkind) = D.idinvkind	AND isnull(I.yinv_real, I.yinv) = D.yinv	AND isnull(I.ninv_real, I.ninv) = D.ninv
JOIN invoicekind			ON I.idinvkind = invoicekind.idinvkind
JOIN registry R				ON R.idreg = I.idreg
LEFT OUTER JOIN treasurerview T		ON I.idtreasurer = T.idtreasurer and T.ayear = @ayear
WHERE I.yinv = @ayear		AND I.ninv IN (SELECT num from #printingdoc)	AND I.idinvkind = @idinvkind

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
LEFT OUTER JOIN geo_city		ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country		ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation		ON geo_nation.idnation = registryaddress.idnation
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
DECLARE @banktitle varchar(150)
DECLARE @cabtitle varchar(50)
DECLARE @cin varchar(20)
DECLARE @idbank varchar(20)
DECLARE @idcab varchar(20)
DECLARE @cc varchar(30)	
DECLARE @iban varchar(50)		
DECLARE @bic varchar(15)
declare @header_treasurer varchar(150)
SELECT @banktitle = banktitle, @cabtitle = cabtitle, @cin = cin, @idbank = idbank, @idcab = idcab, @cc = cc, @iban = iban,@bic = bic, @header_treasurer = header
FROM treasurerview
WHERE flagdefault = 'S'

-- Imposta il cassiere col cassiere di default, SOLO se tutte le info in fatture sono null, ossia non è stato specificato il cassiere
update #sellingdoc set banktitle = @banktitle, cabtitle = @cabtitle, cin = @cin, idbank = @idbank, idcab = @idcab,cc=@cc,iban=@iban,bic=@bic,header_treasurer = @header_treasurer
					where (idtreasurer is null)

DECLARE @iban_f24 varchar(50)  -- è lo stesso conto di addebito dell'F24EP
SELECT  @iban_f24 = iban_f24 from config WHERE ayear = @ayear


DECLARE @invkind varchar(50)
SELECT  @invkind = description FROM invoicekind WHERE idinvkind = @idinvkind

UPDATE #sellingdoc SET header = invoicekind.header, dep_address = invoicekind.address FROM  invoicekind WHERE idinvkind = @idinvkind

UPDATE #sellingdoc SET islinkedbill = 'S'
                WHERE EXISTS (SELECT * FROM  incomeinvoice I
                                JOIN incomelast IL
                                        ON I.idinc = IL.idinc
                        WHERE IL.nbill is not null AND I.idinvkind = @idinvkind AND I.ninv = #sellingdoc.ninv AND I.yinv = @ayear)

DECLARE @idsorkind int
DECLARE @codesorkind varchar(20)
SELECT  @codesorkind = paramvalue FROM reportadditionalparam
	WHERE   reportname = 'fatturavendita' AND paramname = 'classfattura'
SELECT  @idsorkind = idsorkind from sortingkind where codesorkind = @codesorkind

CREATE TABLE #sortinginvoice(
	ninv int,
	idsor int,
	sortcode varchar(20),
	sort varchar(200)
)

INSERT INTO #sortinginvoice(
	ninv,
	idsor,
	sortcode,
	sort
)
SELECT 
	invoice.ninv,
	invoicesorting.idsor,
	sorting.sortcode,
	sorting.description
FROM invoicesorting
JOIN invoice		ON invoice.idinvkind = invoicesorting.idinvkind	AND invoice.yinv = invoicesorting.yinv	AND invoice.ninv = invoicesorting.ninv
JOIN sorting		ON sorting.idsor = invoicesorting.idsor
WHERE invoice.yinv = @ayear
	AND invoice.ninv IN (SELECT num from #printingdoc)
	AND invoice.idinvkind = @idinvkind
	AND sorting.idsorkind = @idsorkind


IF(@autoinvoice = 'S')
Begin
	UPDATE	#sellingdoc
	SET
		invkind_real = invoicekind.description,
		header_real = invoicekind.header,
		ninv_real = #printingdoc.ninv_real,
		doc_real = M.doc,	
		docdate_real = M.docdate,
		AV_real =CASE
				WHEN ((invoicekind.flag&1)=0) THEN 'A'
				WHEN ((invoicekind.flag&1)<>0) THEN 'V'
				END,
		printingcode_real = invoicekind.printingcode
	FROM #printingdoc
	JOIN invoice M			ON  M.idinvkind = #printingdoc.idinvkind_real		AND M.ninv = #printingdoc.ninv_real
	JOIN invoicekind		ON invoicekind.idinvkind = #printingdoc.idinvkind_real
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
	WHERE idinvkind=@idinvkind
)

SELECT
	@invkind AS invkind,
	#sellingdoc.header,
	#sellingdoc.dep_address,
	#sellingdoc.ninv,
	#sellingdoc.invkind_real,
	#sellingdoc.header_real,
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
	REPLACE(expirationkind.shorttitle,'%', convert(varchar(4),#sellingdoc.paymentexpiring) + ' gg') as expiration,

	#sellingdoc.banktitle AS bank,
	#sellingdoc.cabtitle AS cabtitle,
	#sellingdoc.cin AS cin,
	#sellingdoc.idbank AS  idbank,
	#sellingdoc.idcab AS idcab,
	#sellingdoc.cc AS cc,
	#sellingdoc.iban AS iban,
	#sellingdoc.bic AS bic,
	#sellingdoc.header_treasurer as header_treasurer,
	case 
-- isnull(R.p_iva, isnull(R.cf, R.foreigncf))
		when (@showcfpiva = 'P' and R.p_iva is not null)	then 'P.I. ' + R.p_iva
		when (@showcfpiva = 'P' and R.p_iva is null)		then 'C.F. ' + isnull(R.cf, R.foreigncf)
--isnull(R.cf, isnull(R.foreigncf, R.p_iva))
		when (@showcfpiva = 'C' and (R.cf is NOT null OR R.foreigncf is NOT null ))	then  'C.F. ' + isnull(R.cf, R.foreigncf) 
		when (@showcfpiva = 'C' and (R.cf is null and R.foreigncf is null ))			then 'P.I. ' + R.p_iva
--R.p_iva + isnull(R.cf, R.foreigncf)
		when (@showcfpiva = 'E' and R.p_iva is not null and  (R.cf is NOT null OR R.foreigncf is NOT null ))	then 'P.I. ' + R.p_iva+'C.F. ' + isnull(R.cf, R.foreigncf)
		when (@showcfpiva = 'E' and R.p_iva is null and  (R.cf is NOT null OR R.foreigncf is NOT null ))		then 'C.F. ' + isnull(R.cf, R.foreigncf)
		when (@showcfpiva = 'E' and R.p_iva is not null and  (R.cf is null and R.foreigncf is null ))		then 'P.I. ' + R.p_iva
	end AS PivaCF, 
	#sellingdoc.ref_desc,
	#sellingdoc.description,
	currency.codecurrency as idcurrency,
	#sellingdoc.exchangerate,
	IK.description as ivakind_desc, 
	#sellingdoc.idupb,
	upb.title as upb,
	#sellingdoc.npackage AS number,
	#sellingdoc.discount,
	#sellingdoc.taxable,
	case when (IK.flag & 512 = 0 ) then IK.rate
		when (IK.flag & 512 <> 0 ) then 0
	end	as ivarate, 
	#sellingdoc.tax,
	#sellingdoc.taxabletotal,
	#sellingdoc.total,
	ISNULL(#sellingdoc.description,'') + ' ' + ISNULL(#sellingdoc.notes,'') as uniondescr,-->> #sellingdoc.notes,
	#sellingdoc.ivadeferred,
	#sellingdoc.invoicedesc,
	#sellingdoc.doc,
	#sellingdoc.invoiceannotations,
	#sellingdoc.notes1,
	#sellingdoc.notes2,
	#sellingdoc.notes3,
    ISNULL(islinkedbill,'N') as islinkedbill,
	#sellingdoc.flagvariation,
	#sortinginvoice.sort,
	ITK.idivataxablekind,
	ITK.description as ivataxablekind,
	#sellingdoc.autoinvoice,
	isnull(AV_real, @AV) as av, --> Per le Autofattura senza dettagli consideriamo il registro della madre.
	#sellingdoc.printingcode_real,
	#sellingdoc.flagbankitaliaproceeds,
	@iban_f24 as iban_f24,
	SUBSTRING(@iban_f24,21,7) as 'nacc_bankitalia',
	#sellingdoc.flag_enable_split_payment,
	#sellingdoc.cupcode,
	#sellingdoc.cigcode
FROM #sellingdoc
JOIN ivakind IK
	ON IK.idivakind = #sellingdoc.idivakind
JOIN ivataxablekind ITK
	ON IK.idivataxablekind = ITK.idivataxablekind	
LEFT OUTER JOIN #address_sellingdoc
	ON #address_sellingdoc.idreg = #sellingdoc.idreg
LEFT OUTER JOIN registry R
	ON R.idreg = #sellingdoc.idreg
LEFT OUTER JOIN currency
	ON currency.idcurrency = #sellingdoc.idcurrency
LEFT OUTER JOIN upb
	ON upb.idupb = #sellingdoc.idupb
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #sellingdoc.idexpirationkind
LEFT OUTER JOIN #sortinginvoice
	ON #sellingdoc.ninv = #sortinginvoice.ninv
ORDER BY #sellingdoc.ninv ASC
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


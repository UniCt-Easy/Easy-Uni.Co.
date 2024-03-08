
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contrattoattivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contrattoattivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 -- setuser 'amm'
--- exec rpt_contrattoattivo 2022, 'I', 'SOLOTEST', 1, 1, NULL, {ts '2022-11-24 00:00:00'}, 'N', 'N', NULL, NULL, NULL, NULL, NULL
CREATE  PROCEDURE [rpt_contrattoattivo]
(
	@ayear int,
	@printkind char(1),
	@idestimkind varchar(20),
	@nestim_start int,
	@nestim_stop int,
	@idman int,
	@competencydate	smalldatetime,
	@filtercompetency char(1),
	@official char(1),
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS BEGIN
IF @ayear = 0
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #estimatedetail
(
	nestim int,
	docdate datetime,
	idreg int,
	idreg_detail int,
	idman int,
	deliveryexpiration varchar(50),
	deliveryaddress varchar(400),
	paymentexpiring smallint,
	idexpirationkind int,
	ref_desc varchar(150),
	description varchar(150),
	idcurrency int,
	exchangerate float,
	idivakind int,
	number decimal(19,2),
	discount float,
	taxable decimal(19,5),
	tax decimal(19,6),
	taxabletotal decimal(19,2),
	total decimal(19,2),
	notes varchar(400),
	estimatedesc varchar(150),
	doc varchar(35),
	codeupb varchar(50),
	description_upb varchar(150),
	codemotive varchar(50),
	accmotive varchar(150),
	upb varchar(800),
	idgroup int,
	rownum_main int,
	stop datetime,
	adate datetime
)
CREATE TABLE #printingdoc (num int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT nestim FROM estimate
	JOIN estimatekind 
		ON estimatekind.idestimkind = estimate.idestimkind
	WHERE estimate.yestim = @ayear
		AND estimate.officiallyprinted <> 'S'  
		AND estimatekind.idestimkind  = @idestimkind 
		AND (	(@idman is not null  AND idman = @idman ) OR (@idman is null)	)
										and (	(@idman is not null  AND idman = @idman ) OR (@idman is null)	)
	AND (isnull(estimate.idsor01,estimatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(estimate.idsor02,estimatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(estimate.idsor03,estimatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(estimate.idsor04,estimatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(estimate.idsor05,estimatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT nestim FROM estimate
		JOIN estimatekind 
		ON estimatekind.idestimkind = estimate.idestimkind
	WHERE yestim = @ayear
		AND nestim BETWEEN @nestim_start AND @nestim_stop
		AND estimate.idestimkind = @idestimkind
		AND (	(@idman is not null  AND idman = @idman ) OR (@idman is null)	)
		AND (isnull(estimate.idsor01,estimatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (isnull(estimate.idsor02,estimatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (isnull(estimate.idsor03,estimatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (isnull(estimate.idsor04,estimatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (isnull(estimate.idsor05,estimatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
END

INSERT INTO #estimatedetail
(
	nestim,
	docdate,
	idreg,idreg_detail,
	idman,
	deliveryexpiration,	
	deliveryaddress,
	paymentexpiring,
	idexpirationkind,
	ref_desc,
	idcurrency,
	exchangerate,
	idivakind,
	description,
	number,
	discount,
	taxable,
	tax,
	taxabletotal,
	total,
	notes,
	estimatedesc,
	doc,
	codeupb,
	description_upb,
	codemotive,	accmotive,
	idgroup,
	rownum_main,
	stop,
	adate
)
SELECT 
	I.nestim,
	I.docdate,
	I.idreg,D.idreg,
	I.idman,
	I.deliveryexpiration,	
	I.deliveryaddress,
	I.paymentexpiring,
	I.idexpirationkind,
	I.registryreference,
	I.idcurrency,
	ISNULL(I.exchangerate,1),
	D.idivakind,
	D.detaildescription,
	D.number,
	D.discount,
	SUM(D.taxable),
	SUM(D.tax), 
-- taxabletotal
SUM(
	CONVERT(decimal(19,2),
		ROUND(
		      D.taxable*
		      D.number*
		      CONVERT(decimal(19,6),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	)
),
-- total
SUM(
	CONVERT(DECIMAL(19,2),
		ROUND(
		      D.taxable*
		      D.number*
		      CONVERT(decimal(19,6),I.exchangerate)*
		      (1-CONVERT(decimal(19,6),ISNULL(D.discount,0))),2
			     )
	)+
	CONVERT(DECIMAL(19,2),
		ROUND(

		      CONVERT(decimal(19,6),ISNULL(D.tax,0))*
		      CONVERT(decimal(19,6),I.exchangerate) ,2
			     )
	)
),
	D.annotations,
	I.description,
	I.doc,
	U.codeupb,
	U.title,
	accmotive.codemotive, accmotive.title,
	D.idgroup,
	D.rownum_main,
	D.stop,
	I.adate
FROM estimatedetail D
JOIN estimate I
	ON I.idestimkind = D.idestimkind
	AND I.yestim = D.yestim
	AND I.nestim = D.nestim
LEFT OUTER JOIN upb U
	ON D.idupb = U.idupb
LEFT OUTER JOIN accmotive
	on accmotive.idaccmotive = D.idaccmotive
WHERE I.yestim = @ayear
	AND I.nestim IN (SELECT num from #printingdoc)
	AND I.idestimkind = @idestimkind
	AND (
		(ISNULL(@filtercompetency,'N') = 'S' AND @competencydate IS NOT NULL AND @competencydate BETWEEN D.competencystart AND D.competencystop) OR
		(ISNULL(@filtercompetency,'N') = 'N') OR
		(@competencydate IS NULL)
		)	
GROUP BY I.nestim,I.docdate,D.idgroup,I.idreg,D.idreg,I.paymentexpiring,I.idexpirationkind,
	I.registryreference,I.idcurrency,I.exchangerate,D.idivakind,D.detaildescription,
	D.number,D.discount,D.annotations,I.description,I.doc,I.deliveryexpiration,I.deliveryaddress,
	U.codeupb,U.title, D.competencystart, D.competencystop,	D.rownum_main,
	D.stop, I.idman,accmotive.codemotive, accmotive.title, I.adate

	
-- Concatena i vari codici UPB 
DECLARE @nestim int
DECLARE @idgroup int 
DECLARE	@codeupb varchar(50)
DECLARE @description_upb varchar(150)

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT nestim, idgroup, codeupb, description_upb FROM #estimatedetail
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @nestim,  @idgroup, @codeupb,@description_upb
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#estimatedetail set
	  upb = case	when @codeupb is not null 
					then isnull(upb,'') +' Cod.UPB:' + @codeupb +' UPB:' + @description_upb +'. '
							else upb
							end
	 WHERE nestim = @nestim and idgroup = @idgroup 

		FETCH NEXT FROM cursore 
		INTO @nestim,  @idgroup, @codeupb,@description_upb
	END
CLOSE cursore


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
	AND (idreg IN (SELECT idreg FROM #estimatedetail))
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

DECLARE @estimkind varchar(50)
DECLARE @estimkindnote varchar(250)

SELECT @estimkind = description,
	   @estimkindnote = txt
FROM estimatekind WHERE idestimkind = @idestimkind

DECLARE @banktitle varchar(50)
DECLARE @cabtitle varchar(50)
DECLARE @cin varchar(20)
DECLARE @idbank varchar(20)
DECLARE @idcab varchar(20)
DECLARE @cc varchar(30)	
DECLARE @iban varchar(50)		
SELECT @banktitle = banktitle, @cabtitle = cabtitle, @cin = cin, @idbank = idbank, @idcab = idcab, @cc = cc, @iban = iban
FROM treasurerview
WHERE flagdefault = 'S' and ayear = @ayear

SELECT
	@estimkind AS estimkind,
	estimatekind.header,
	estimatekind.address as dep_address,
	#estimatedetail.nestim,
	#estimatedetail.docdate,
	#estimatedetail.idreg,
	R.title AS registry,
	R_detail.title as registry_detail_title,
	#estimatedetail.idman,
	manager.title as manager,
	#address_sellingdoc.officename, 
	#address_sellingdoc.address, 
	#address_sellingdoc.location, 
	#address_sellingdoc.cap,
	#address_sellingdoc.province,  
	#address_sellingdoc.nation, 
	#estimatedetail.deliveryexpiration,	
	#estimatedetail.deliveryaddress,
	REPLACE(expirationkind.shorttitle,'%',#estimatedetail.paymentexpiring) as expiration,
	@banktitle AS bank,
	@cabtitle AS cabtitle,
	@cin AS cin,
	@idbank AS  idbank,
	@idcab AS idcab,
	@cc AS cc,
	@iban AS iban,
	R.cf AS cf,
	R.p_iva AS p_iva,
	#estimatedetail.ref_desc,
	#estimatedetail.description,
	currency.codecurrency as idcurrency,
	#estimatedetail.exchangerate,
	IK.description AS ivakind_desc,
	#estimatedetail.number,
	#estimatedetail.discount,
	sum(#estimatedetail.taxable) as taxable,
	IK.rate AS ivarate,
	ITK.idivataxablekind,
	ITK.description as ivataxablekind,
	sum(#estimatedetail.tax) as tax,
	sum(#estimatedetail.taxabletotal) as taxabletotal,
	sum(#estimatedetail.total) as total,
	#estimatedetail.notes,
    #estimatedetail.estimatedesc,
	#estimatedetail.doc,
	@estimkindnote as estimatekindnote,
	#estimatedetail.upb,
	#estimatedetail.codemotive,	
	#estimatedetail.accmotive,
	#estimatedetail.adate
FROM #estimatedetail
JOIN estimatekind  
	ON estimatekind.idestimkind  = @idestimkind
LEFT OUTER JOIN #address_sellingdoc
	ON #address_sellingdoc.idreg = #estimatedetail.idreg
LEFT OUTER JOIN registry R
	ON R.idreg = #estimatedetail.idreg
LEFT OUTER JOIN registry as R_detail
	ON #estimatedetail.idreg_detail = R_detail.idreg
LEFT OUTER JOIN manager
	ON manager.idman = #estimatedetail.idman
JOIN ivakind IK
	ON IK.idivakind = #estimatedetail.idivakind
JOIN ivataxablekind ITK
	ON IK.idivataxablekind = ITK.idivataxablekind	
LEFT OUTER JOIN currency
	ON currency.idcurrency = #estimatedetail.idcurrency
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #estimatedetail.idexpirationkind
where ( #estimatedetail.rownum_main is null and #estimatedetail.stop is null)
GROUP BY estimatekind.header,
	estimatekind.address,
	#estimatedetail.nestim,	#estimatedetail.docdate,	#estimatedetail.idreg,	R.title ,	R_detail.title,
	#estimatedetail.idman,	manager.title,
	#address_sellingdoc.officename, 	#address_sellingdoc.address, 	#address_sellingdoc.location, 	#address_sellingdoc.cap,
	#address_sellingdoc.province,  	#address_sellingdoc.nation, 	#estimatedetail.deliveryexpiration,		#estimatedetail.deliveryaddress,
	REPLACE(expirationkind.shorttitle,'%',#estimatedetail.paymentexpiring) ,
	R.cf ,	R.p_iva,	#estimatedetail.ref_desc,	#estimatedetail.description,	currency.codecurrency,	#estimatedetail.exchangerate,
	IK.description ,	#estimatedetail.number,	#estimatedetail.discount,	IK.rate,	ITK.idivataxablekind,
	ITK.description,
	#estimatedetail.notes,    #estimatedetail.estimatedesc,	#estimatedetail.doc,
	#estimatedetail.upb,
	#estimatedetail.codemotive,	
	#estimatedetail.accmotive,
	#estimatedetail.rownum_main,
	#estimatedetail.stop ,
	#estimatedetail.adate
	ORDER BY #estimatedetail.nestim, #estimatedetail.upb ASC
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


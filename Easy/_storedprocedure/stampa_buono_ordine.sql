
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE     PROCEDURE [rpt_buono_ordine]
	@ayear int,
	@printkind char(1),
	@mandatekind varchar(20),
	@startnman int,
	@stopnman int,
	@official char(1),
	@includevariation char(1), 
	@variationdate smalldatetime 	
AS BEGIN
IF (@ayear=0)
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #mandate
(
	yman int  ,
	nman int  ,
	idmankind varchar(20),
	idreg int  ,
	idexpirationkind char(1)  ,
	idcurrency varchar(20)  ,
	exchangerate float  ,
	idman int,
	numintegration int  ,
	numannulled int  
)
CREATE TABLE #printing
(
	nman int  
)
IF @printkind = 'A' 
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate  where (yman=@ayear) and (idmankind = @mandatekind) AND (officiallyprinted <>'S')
	
IF @printkind  <> 'A'
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate where (yman=@ayear) and (idmankind = @mandatekind) AND (nman BETWEEN @startnman AND @stopnman)
INSERT INTO #mandate
(
	yman,
	nman,
	idmankind,
	idreg,
	idexpirationkind,
	idcurrency,
	exchangerate,
	idman,
	numintegration,
	numannulled)
SELECT 
	mandate.yman,
	mandate.nman,
	mandate.idmankind,
	mandate.idreg,
	mandate.idexpirationkind,
	mandate.idcurrency,
	mandate.exchangerate,
	mandate.idman,
	0,
	0		
FROM mandate
WHERE mandate.yman = @ayear
	AND mandate.idmankind= @mandatekind
	AND mandate.nman in (SELECT nman FROM #printing)
DECLARE @NOSTAND varchar(6)
SET @NOSTAND = 'ORDIN'
DECLARE @STAND varchar(6)
SET @STAND 	= 'STAND'
DECLARE @dateindi smalldatetime
SET @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)
CREATE TABLE #address_mandate
(
	idaddresskind 	varchar(6),
	idreg		int,
	officename 	varchar(50),
	address		varchar(100),
	location	varchar(120),
	cap		varchar(20),
	province	varchar(2),
	nation		varchar(65)	 
)
INSERT INTO #address_mandate
(
	idaddresskind,
	idreg,
	officename,
	address,
	location,
	cap,
	province,
	nation						
)
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	location = isnull(geo_city.title,'')+' ' +isnull(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	nation = 
	case 
		when flagforeign = 'N' then 'Italia'
		else geo_nation.title
	end
FROM registryaddress
left outer join geo_city
	ON geo_city.idcity = registryaddress.idcity
left outer join geo_country
	ON geo_city.idcountry = geo_country.idcountry
left outer join geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 
	(
	registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active <>'N' 
		AND cdi.start <= @dateindi
		and cdi.idreg = registryaddress.idreg))
	AND (idreg in (SELECT idreg from #mandate))
delete #address_mandate
where #address_mandate.idaddresskind <> @nostand
	and exists
		(select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @nostand)
delete #address_mandate
where #address_mandate.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @stand
		)
delete #address_mandate
where (
	select count(*) from #address_mandate r2 
	where #address_mandate.idreg=r2.idreg
	)>1
UPDATE  #mandate 
SET numannulled= (SELECT count(distinct idgroup) 
			FROM mandatedetail 
		       WHERE yman = #mandate.yman AND
			     nman = #mandate.nman AND 
			     idmankind = @mandatekind AND
			     mandatedetail.stop is not null and 
			     mandatedetail.stop <= @variationdate
			)
UPDATE  #mandate 
SET numintegration= (SELECT count(distinct idgroup) 
			FROM mandatedetail 
		       WHERE yman = #mandate.yman AND
			     nman = #mandate.nman AND 
			     idmankind = @mandatekind AND
			     mandatedetail.start is not null and 
			     mandatedetail.start <= @variationdate
			)
CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
	detaildescription varchar(150),
	annotations varchar(400),
	number decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime
)
INSERT INTO #mandatedetail
(
	yman,
	nman,
	idmankind ,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop 
)
SELECT 
	yman,
	nman,
	idmankind,
	detaildescription,
	annotations,
	number,
	sum(taxable),
	taxrate,
	sum(tax),
	discount,
	start,
	stop
FROM    mandatedetail
WHERE   mandatedetail.yman = @ayear
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman in (SELECT nman FROM #printing)
GROUP BY yman,nman,idmankind,detaildescription,annotations,
	number,taxrate,discount,start,stop,idgroup
SELECT 
	#mandate.yman,
	#mandate.nman,
	mandatekind.description AS mandatekind,
	mandate.description ,
	mandatekind.office,
	mandatekind.phonenumber AS phonenumber_office,
	mandatekind.faxnumber AS faxnumber_office,
	mandatekind.email AS email_office,
	mandate.adate,
	#mandate.idreg ,
	registry.title ,
	#address_mandate.officename,
	#address_mandate.address,
	#address_mandate.location,
	#address_mandate.cap,
	#address_mandate.province,
	#address_mandate.nation,
	(ISNULL(registryreference.phonenumber,'')) as phone,
	(ISNULL(registryreference.faxnumber,'')) as fax,
	registryreference.email,
	registry.p_iva,
	mandate.paymentexpiring ,
	#mandate.idexpirationkind ,
	expirationkind.description  as expirationdescription,
	mandate.registryreference ,
	mandate.deliveryexpiration ,
	mandate.deliveryaddress ,
	manager.title as manager,
	#mandate.idcurrency ,
	#mandate.exchangerate ,
	isnull(#mandatedetail.detaildescription,'') + ' ' + isnull(#mandatedetail.annotations,'') as uniondescr,
	--upb.title as upb,
	ISNULL(#mandatedetail.number, 0) as number ,
	ISNULL(#mandatedetail.taxable, 0) as taxable ,
	ISNULL(#mandatedetail.taxrate, 0) as taxrate,
	ISNULL(#mandatedetail.discount, 0)as discount ,
		CASE 
			WHEN ((mandate.idcurrency IS NULL) OR (mandate.idcurrency = 'ITL') OR (mandate.idcurrency = 'EUR')) THEN 'N'
			ELSE 'S'
		END 
	as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
	mandate.txt as notes,
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
  		     )
	) as rowtaxable,
-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
  		     )
	)+
	ROUND(#mandatedetail.tax * CONVERT(decimal(19,6), #mandate.exchangerate),2) as totalrow,
	#mandate.numannulled,
	#mandate.numintegration
FROM #mandate
JOIN mandate
	ON mandate.yman = #mandate.yman
	AND mandate.nman = #mandate.nman
	and mandate.idmankind = #mandate.idmankind
JOIN mandatekind  
	ON #mandate.idmankind = mandatekind.idmankind 
JOIN #mandatedetail
	ON #mandate.yman = #mandatedetail.yman
	AND #mandate.nman = #mandatedetail.nman
	AND #mandate.idmankind = #mandatedetail.idmankind
--LEFT OUTER JOIN upb
	--ON upb.idupb = #mandatedetail.idupb
LEFT OUTER JOIN registry
	ON #mandate.idreg = registry.idreg
LEFT OUTER JOIN manager
	ON manager.idman = #mandate.idman
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = #mandate.idreg
	AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #mandate.idexpirationkind
LEFT OUTER JOIN #address_mandate
	ON #mandate.idreg = #address_mandate.idreg
WHERE #mandatedetail.start is null 
	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_annullamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_annullamenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [rpt_buono_ordine_annullamenti]
	@yman int,
	@nman int,
	@mandatekind varchar(20),
	@datarifer smalldatetime
AS BEGIN
CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
	detaildescription varchar(150),
	annotations varchar(400),
	number decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime
)
INSERT INTO #mandatedetail
(
	yman,
	nman,
	idmankind ,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop 
)
SELECT 
	@yman,
	@nman,
	@mandatekind,
	detaildescription,
	annotations,
	number,
	sum(taxable),
	taxrate,
	sum(tax),
	discount,
	start,
	stop
FROM    mandatedetail
WHERE   mandatedetail.yman = @yman
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman = @nman
GROUP BY  detaildescription,annotations,number,
	taxrate,discount,start,stop,idgroup
--select * from #mandatedetail
SELECT 
	mandate.yman,
	mandate.nman,
	mandatekind.description as mandatekind,
	mandate.exchangerate ,
	#mandatedetail.detaildescription + ' ' + isnull( #mandatedetail.annotations,'') as uniondescr,
	ISNULL(#mandatedetail.number, 0) as number,
	ISNULL(#mandatedetail.taxable, 0.0) as taxable,
	ISNULL(#mandatedetail.taxrate, 0.0) as taxrate,
	ISNULL(#mandatedetail.discount, 0.0)as discount ,
	CASE 
		WHEN ((mandate.idcurrency IS NULL) OR (mandate.idcurrency = 'ITL') OR (mandate.idcurrency = 'EUR')) THEN 'N'
		ELSE 'S'
	END as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	) as rowtaxable,
-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	)+
	ROUND(#mandatedetail.tax * CONVERT(decimal(19,6), #mandate.exchangerate),2) as rowtotal
FROM mandate
JOIN #mandatedetail
	ON mandate.yman = #mandatedetail.yman
	AND mandate.nman = #mandatedetail.nman
	AND mandate.idmankind = #mandatedetail.idmankind
JOIN mandatekind
	ON mandatekind.idmankind = mandate.idmankind
WHERE mandate.yman = @yman
	AND   mandate.idmankind = @mandatekind
	AND mandate.nman = @nman
	AND #mandatedetail.stop is not  null      
	AND #mandatedetail.stop <= @datarifer 
ORDER BY #mandatedetail.stop ASC
	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_integrazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_integrazioni]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [rpt_buono_ordine_integrazioni]
	@yman int,
	@nman int,
	@mandatekind varchar(20),
	@datarifer smalldatetime
AS BEGIN
CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
	detaildescription varchar(150),
	annotations varchar(400),
	number decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime
)
INSERT INTO #mandatedetail
(
	yman,
	nman,
	idmankind ,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop 
)
SELECT 
	@yman,
	@nman,
	@mandatekind,
	detaildescription,
	annotations,
	number,
	sum(taxable),
	taxrate,
	sum(tax),
	discount,
	start,
	stop
FROM    mandatedetail
WHERE   mandatedetail.yman = @yman
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman = @nman
GROUP BY  detaildescription,annotations,number,
	taxrate,discount,start,stop,idgroup
--select * from #mandatedetail
SELECT 
	mandate.yman ,
	mandate.nman,
	mandatekind.description as mandatekind,
	mandate.exchangerate as exchangerate,
	#mandatedetail.detaildescription + ' ' + isnull(#mandatedetail.annotations,'') as uniondescr,
	ISNULL(#mandatedetail.number, 0) as number ,
	ISNULL(#mandatedetail.taxable, 0.0) as taxable,
	ISNULL(#mandatedetail.taxrate, 0.0)  as taxrate,
	ISNULL(#mandatedetail.discount, 0.0) as discount ,
	CASE 
		WHEN ((mandate.idcurrency IS NULL) OR (mandate.idcurrency = 'ITL') OR (mandate.idcurrency = 'EUR')) THEN 'N'
		ELSE 'S'
	END as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
-- Imponibile totale della riga di dettaglio
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	) as rowtaxable,
-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	)+
	ROUND(#mandatedetail.tax * CONVERT(decimal(19,6), #mandate.exchangerate),2) as totalrow
FROM mandate
JOIN #mandatedetail
	ON  mandate.yman = #mandatedetail.yman
	AND mandate.nman = #mandatedetail.nman
	AND mandate.idmankind = #mandatedetail.idmankind
JOIN mandatekind 
	ON  mandatekind.idmankind = mandate.idmankind
WHERE mandate.yman = @yman
	AND mandate.nman = @nman
	AND mandate.idmankind = @mandatekind
	AND #mandatedetail.start is not  null   
	AND #mandatedetail.start <= @datarifer
ORDER BY #mandatedetail.start ASC
	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_contabilizzato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_contabilizzato]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [rpt_buono_ordine_contabilizzato]
	@ayear	int,
	@printkind	char(1),
	@mandatekind    varchar(20),
	@startnman	int,
	@stopnman	int,
	@official	char(1),
	@includevariation	char(1),
	@variationdate	smalldatetime
AS BEGIN
IF (@ayear=0)
BEGIN
	SET @ayear='1900'
END
CREATE TABLE #printing
(
	nman int  
)
IF @printkind = 'A' 
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate  where (yman=@ayear) and (idmankind =@mandatekind) and (officiallyprinted <>'S')
	
IF @printkind <> 'A'
	INSERT INTO #printing (nman) 
	SELECT nman from  mandate where (yman=@ayear) and (idmankind =@mandatekind) and (nman BETWEEN @startnman AND @stopnman)
CREATE TABLE #mandate
(
	yman int,
	nman int,
	idmankind varchar(20),
	idreg int,
	idexpirationkind char(1),
	idcurrency varchar(20),
	exchangerate decimal(19,6),
	idman varchar(20),
	numintegration int ,
	numannulled int  
)
INSERT INTO #mandate
(
	yman,
	nman,
	idmankind,
	idreg,
	idexpirationkind,
	idcurrency,
	exchangerate,
	idman,
	numintegration,
	numannulled
)
SELECT 
	mandate.yman,
	mandate.nman,
	mandate.idmankind,
	mandate.idreg,
	mandate.idexpirationkind,
	mandate.idcurrency,
	mandate.exchangerate,
	mandate.idman,
	0,
	0
FROM mandate
WHERE mandate.yman = @ayear
	AND mandate.nman in (SELECT nman FROM #printing)
	AND mandate.idmankind= @mandatekind
DECLARE @dateindi smalldatetime
SELECT @dateindi= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)
DECLARE @NOSTAND varchar(6)
SELECT @NOSTAND = 'ORDIN'
DECLARE @STAND varchar(6)
SELECT @STAND = 'STAND'
CREATE TABLE #address_mandate
( 
	idaddresskind varchar(6),
	idreg int,
	officename varchar(50),
	address varchar(100),
	location varchar(120),
	cap varchar(5),
	province varchar(2),
	nation varchar(65)	 
)
INSERT INTO #address_mandate
(
	idaddresskind,
	idreg,
	officename,
	address,
	location,
	cap,
	province,
	nation
)
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	location = isnull(geo_city.title,'')+' ' +isnull(registryaddress.location,'')  ,
	registryaddress.cap,
	geo_country.province,
	nation =
	case 
		when flagforeign = 'N' then 'Italia'
		else geo_nation.title
	end
FROM registryaddress
left outer join geo_city
	ON geo_city.idcity = registryaddress.idcity
left outer join geo_country
	ON geo_city.idcountry = geo_country.idcountry
left outer join geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE ( registryaddress.active <>'N' 
	AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active <>'N' 
		AND cdi.start <= @dateindi
		and cdi.idreg = registryaddress.idreg))
	AND
	(idreg in (SELECT idreg from #mandate))
delete #address_mandate
	where #address_mandate.idaddresskind != @nostand
	and exists (
		select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @nostand
	)
delete #address_mandate
	where #address_mandate.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
		and r2.idaddresskind = @stand
	)
delete #address_mandate
	where (
		select count(*) from #address_mandate r2 
		where #address_mandate.idreg=r2.idreg
	)>1
	
-- Elimino dalla tabella tutti gli ordini non totalmente impegnati
DELETE FROM #mandate WHERE #mandate.nman NOT IN
(	
	SELECT nman from mandateavailable where yman=@ayear 
	and (idmankind =@mandatekind) and residual=0
)
UPDATE  #mandate 
SET numannulled= (SELECT count(*) 
		FROM mandatedetail 
	       WHERE yman = #mandate.yman AND
		     nman = #mandate.nman AND 
		     idmankind =@mandatekind AND
		     mandatedetail.stop is not null and 
		     mandatedetail.stop <= @variationdate
		)
UPDATE  #mandate 
SET numintegration= (SELECT count(*) 
		FROM mandatedetail 
	       WHERE yman = #mandate.yman AND
		     nman = #mandate.nman AND 
		     idmankind =@mandatekind AND
		     mandatedetail.start is not null and 
		     mandatedetail.start <= @variationdate
		)
SELECT
	#mandate.yman ,
	#mandate.nman ,
	mandatekind.description AS mandatekind,
	mandate.adate ,
	mandate.description ,
	mandatekind.office,
	mandatekind.phonenumber AS phonenumber_office,
	mandatekind.faxnumber AS faxnumber_office,
	mandatekind.email AS email_office,
	#mandate.idreg ,
	registry.title ,
	#address_mandate.officename, 
	#address_mandate.address, 
   	#address_mandate.location, 
  	#address_mandate.cap,
	#address_mandate.province,  
	#address_mandate.nation,
	(ISNULL(registryreference.phoneprefix,'') + ISNULL(registryreference.phonenumber,'')) as phone,
	(ISNULL(registryreference.faxprefix,'') + ISNULL(registryreference.faxnumber,'')) as fax,
	registryreference.email,
	registry.p_iva,
	mandate.paymentexpiring ,
	#mandate.idexpirationkind ,
	mandate.registryreference ,
	mandate.deliveryexpiration ,
	mandate.deliveryaddress ,
	manager.title as manager,
	#mandate.idcurrency ,
	#mandate.exchangerate ,
	isnull(mandatedetail.detaildescription,'') + ' ' + isnull(mandatedetail.annotations,'') as uniondescr,
	ISNULL(mandatedetail.number, 0)as number ,
	upb.title as upb,
	ISNULL(mandatedetail.taxable, 0)  as taxable,
	ISNULL(mandatedetail.taxrate, 0) as taxrate ,
	ISNULL(mandatedetail.discount, 0) as discount,
		CASE 
			WHEN ((mandate.idcurrency IS NULL) OR (mandate.idcurrency = 'ITL') OR (mandate.idcurrency = 'EUR')) THEN 'N'
			ELSE 'S'
		END 
		as is_english,
		mandatedetail.start,
		mandatedetail.stop,
		mandate.txt as notes,
		CONVERT(DECIMAL(19,2),
		ROUND(
		      mandatedetail.taxable*
		      mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0.0))),2
			     )
	) as rowtaxable,
	-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
	-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
			CONVERT(DECIMAL(19,2),
		ROUND(
		      mandatedetail.taxable*
		      mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0.0))),2
			     )
	)+
	ROUND(#mandatedetail.tax * CONVERT(decimal(19,6), #mandate.exchangerate),2) as rowtotal,
	#mandate.numannulled,
	#mandate.numintegration
FROM #mandate
JOIN mandate
	ON mandate.yman = #mandate.yman
	AND mandate.nman = #mandate.nman
	and mandate.idmankind = #mandate.idmankind
JOIN mandatekind  
	ON #mandate.idmankind = mandatekind.idmankind 
JOIN mandatedetail
	ON #mandate.yman = mandatedetail.yman
	AND #mandate.nman = mandatedetail.nman
	AND #mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN upb
	ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN registry
	ON #mandate.idreg = registry.idreg
LEFT OUTER JOIN manager
	ON manager.idman = #mandate.idman
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = #mandate.idreg
	AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN expirationkind 
	ON expirationkind.idexpirationkind = #mandate.idexpirationkind
LEFT OUTER JOIN #address_mandate
	ON #mandate.idreg = #address_mandate.idreg
WHERE mandatedetail.start is null 
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



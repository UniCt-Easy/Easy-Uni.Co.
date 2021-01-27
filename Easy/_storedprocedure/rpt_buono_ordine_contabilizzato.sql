
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_contabilizzato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_contabilizzato]
GO

--setuser 'amm'
CREATE        PROCEDURE [rpt_buono_ordine_contabilizzato]
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
	idexpirationkind int,
	idcurrency int,
	exchangerate decimal(19,6),
	idman int,
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

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_ORD'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

CREATE TABLE #address_mandate
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
	ISNULL(registryreference.phonenumber,'') as phone,
	ISNULL(registryreference.faxnumber,'') as fax,
	registryreference.email,
	registry.p_iva,
	mandate.paymentexpiring ,
	#mandate.idexpirationkind ,
	mandate.registryreference ,
	mandate.deliveryexpiration ,
	mandate.deliveryaddress ,
	manager.title as manager,
	currency.codecurrency as idcurrency ,
	#mandate.exchangerate ,
	isnull(mandatedetail.detaildescription,'') + ' ' + isnull(mandatedetail.annotations,'') as uniondescr,
	ISNULL(mandatedetail.npackage, 0)as number ,
	upb.title as upb,
	ISNULL(mandatedetail.taxable, 0)  as taxable,
	case when isnull(mandate.flagintracom,'N')='N' then	ISNULL(mandatedetail.taxrate, 0) ELSE 0 END as taxrate ,
	ISNULL(mandatedetail.discount, 0) as discount,
		CASE 
			WHEN ((currency.codecurrency IS NULL) OR (currency.codecurrency = 'ITL') OR (currency.codecurrency = 'EUR')) THEN 'N'
			ELSE 'S'
		END 
		as is_english,
		mandatedetail.start,
		mandatedetail.stop,
		mandate.txt as notes,
		CONVERT(DECIMAL(19,2),
		ROUND(
		      mandatedetail.taxable*
		      mandatedetail.npackage*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0.0))),2
			     )
	) as rowtaxable,
	-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
	-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
			CONVERT(DECIMAL(19,2),
		ROUND(
		      mandatedetail.taxable*
		      mandatedetail.npackage*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount,0.0))),2
			     )
	)+
		case when isnull(mandate.flagintracom,'N')='N' then	ROUND(mandatedetail.tax,2)  ELSE 0 END 
	as rowtotal,
	#mandate.numannulled,
	#mandate.numintegration
FROM #mandate
JOIN mandate				ON mandate.yman = #mandate.yman
								AND mandate.nman = #mandate.nman
								and mandate.idmankind = #mandate.idmankind
JOIN mandatekind			ON #mandate.idmankind = mandatekind.idmankind 
JOIN mandatedetail			ON #mandate.yman = mandatedetail.yman
								AND #mandate.nman = mandatedetail.nman
								AND #mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN upb			ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN registry	ON #mandate.idreg = registry.idreg
LEFT OUTER JOIN manager		ON manager.idman = #mandate.idman
LEFT OUTER JOIN registryreference	ON registryreference.idreg = #mandate.idreg
											AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN expirationkind		ON expirationkind.idexpirationkind = #mandate.idexpirationkind
LEFT OUTER JOIN #address_mandate	ON #mandate.idreg = #address_mandate.idreg
LEFT OUTER JOIN currency			ON currency.idcurrency = #mandate.idcurrency
WHERE mandatedetail.start is null 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

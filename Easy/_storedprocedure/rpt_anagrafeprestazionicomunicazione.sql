
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anagrafeprestazionicomunicazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anagrafeprestazionicomunicazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [rpt_anagrafeprestazionicomunicazione]
(
	@ayear smallint, 
	@idreg int, 
	@show_addr_anagp char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
-- Questa stampa considera SOLO i dipendenti
-- exec rpt_anagrafeprestazionicomunicazione 2008,732,'S'
CREATE TABLE #serviceregistry
(
	idreg int,
	registry varchar(100),
	cf varchar(16),
	nservreg int,
	birthdate smalldatetime,
	grossamount decimal (19,2),
	service varchar(50),
	npay int,
	start smalldatetime,
	stop smalldatetime,
    apactivitykind varchar(150),
    authorizationdate smalldatetime,
    annoliquidazione smallint,
    department varchar(150),
    description varchar(200)
)
CREATE TABLE #address_to_send
(
	idaddresskind int,
	idreg int,
	officename varchar(50),
	address varchar(100),
	location varchar(120),
	cap varchar(20),
	province varchar(2),
	nation varchar(65),
	recipientagency varchar(50)
)

CREATE TABLE #address_residence
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

CREATE TABLE #registry_birth
(	idreg int,
	city_title varchar(120),
	province varchar(2),
	nation_title varchar(65)
)

IF @ayear = 0
BEGIN
	SET @ayear='1900'
END

DECLARE @dateaddress datetime
SELECT  @dateaddress = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)


INSERT INTO #serviceregistry
(
	idreg,
	registry,
	nservreg,
	cf,
	birthdate ,
	grossamount,
	start,
	stop,
	apactivitykind,
	authorizationdate,
	annoliquidazione,
	description
)
SELECT
	R.idreg,
	R.title,
	R.nservreg,
	R.cf,
	R.birthdate ,
	ISNULL(SUM(payedamount),0),
	R.start,
	R.stop,
	R.apactivitykind,
	R.authorizationdate,
	P.ypay,
	R.description
FROM serviceregistryview R
JOIN servicepayment P
        ON R.yservreg = P.yservreg AND R.nservreg = P.nservreg
WHERE  (R.idreg=@idreg OR @idreg=0)
        AND P.ypay = @ayear
	AND R.employkind <> 'D'
	AND (@idsor01 IS NULL OR R.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR R.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR R.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR R.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR R.idsor05 = @idsor05)
GROUP BY R.idreg,R.title, R.cf,R.birthdate,P.ypay,R.nservreg, R.description,
        R.start,R.stop,R.apactivitykind,R.authorizationdate

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_ANP'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

-- Inizio calcolo indirizzi
INSERT INTO #address_to_send
(
	idaddresskind,
	idreg,
	officename,
	address,
	location,
	cap,
	province,
	nation,
	recipientagency
)
SELECT 
	idaddresskind,
	idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	CASE
		WHEN flagforeign = 'N' THEN 'Italia'
		ELSE geo_nation.title
	END,
	recipientagency
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE (registryaddress.active <>'N' 
        AND (idreg IN (select idreg from  #serviceregistry))
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateaddress
			AND cdi.idreg = registryaddress.idreg)
)

DELETE #address_to_send
WHERE #address_to_send.idaddresskind <> @nostand  -- Restano solo 07_SW_ANP
AND EXISTS(
	SELECT * FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)  

DELETE #address_to_send
WHERE #address_to_send.idaddresskind NOT IN (@NOSTAND, @STAND)
AND EXISTS(
	SELECT * FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
		AND r2.idaddresskind = @STAND
	)  --restano solo 07_SW_ANP  o solo 07_SW_DEF

DELETE #address_to_send
WHERE (
	SELECT COUNT(*) FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
)>1  -- cancello quelli con più  indirizzi

		

SET @codenostand = '07_SW_DOM'
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codestand

INSERT INTO #address_residence
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
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	CASE
		WHEN flagforeign = 'N' THEN 'Italia'
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
                AND (idreg IN (select idreg from  #serviceregistry))
		AND registryaddress.start = 
			(SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
				AND cdi.active <>'N' 
				AND cdi.start <= @dateaddress
				AND cdi.idreg = registryaddress.idreg)
			)

DELETE #address_residence
WHERE #address_residence.idaddresskind <> @NOSTAND
AND EXISTS (
	SELECT * FROM #address_residence r2 
	WHERE #address_residence.idreg = r2.idreg
		AND r2.idaddresskind = @NOSTAND
	)

DELETE #address_residence
WHERE #address_residence.idaddresskind NOT IN (@nostand, @stand)
AND EXISTS (
	SELECT * FROM #address_residence r2 
	WHERE #address_residence.idreg = r2.idreg
		AND r2.idaddresskind = @STAND
	)

DELETE #address_residence
WHERE (
	SELECT COUNT(*) FROM #address_residence r2 
	WHERE #address_residence.idreg = r2.idreg
	)>1
	
-- Fine calcolo indirizzi

INSERT INTO #registry_birth
(
	idreg,
	city_title,
	province,
	nation_title
)
SELECT
	registry.idreg,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''),
	ISNULL(geo_nation.title, 'ITALIA')
FROM registry
LEFT OUTER JOIN geo_city
	ON registry.idcity = geo_city.idcity  
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registry.idnation = geo_nation.idnation  
WHERE  (idreg IN (select idreg from  #serviceregistry))


DECLARE @departmentname varchar(500)

SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


IF (ISNULL(@show_addr_anagp,'N') = 'N' )
BEGIN	
	SELECT
		@departmentname as departmentname,
		#serviceregistry.idreg,
		ISNULL(#serviceregistry.registry,registry.title) as registry,
		#serviceregistry.nservreg,
		#serviceregistry.cf,
		#serviceregistry.birthdate ,
		#serviceregistry.grossamount,
		#serviceregistry.start,
		#serviceregistry.stop,
		#serviceregistry.apactivitykind,
		#serviceregistry.authorizationdate,
		#serviceregistry.annoliquidazione,
		#registry_birth.city_title AS b_city,
		#registry_birth.province AS b_province,
		#registry_birth.nation_title AS b_nation,
		#address_to_send.recipientagency AS sent_agency,
		#address_to_send.officename AS sent_office,
		#address_to_send.address AS sent_address,
		isnull(add_sen.codeaddress,'') AS sent_idaddresskind, 
		#address_to_send.location AS sent_location,
		#address_to_send.cap AS sent_cap,
		#address_to_send.province AS sent_province,
		#address_to_send.nation AS sent_nation,
		#address_residence.address AS residence_address,
		add_res.codeaddress AS residence_idaddresskind,
		#address_residence.location AS residence_location,
		#address_residence.cap AS residence_cap,
		#address_residence.province AS residence_province,
		#address_residence.nation AS residence_nation,
		#serviceregistry.description
	FROM #serviceregistry
	JOIN registry
		ON #serviceregistry.idreg = registry.idreg
	JOIN #registry_birth
		ON #serviceregistry.idreg = #registry_birth.idreg
	LEFT OUTER JOIN #address_to_send
		ON #address_to_send.idreg = #serviceregistry.idreg
	LEFT OUTER JOIN address add_sen
		ON add_sen.idaddress = #address_to_send.idaddresskind
	LEFT OUTER JOIN #address_residence
		ON #address_residence.idreg = #serviceregistry.idreg
	LEFT OUTER JOIN address add_res
		ON add_res.idaddress = #address_to_send.idaddresskind
END
ELSE
BEGIN
		SELECT
		@departmentname as departmentname,
		#serviceregistry.idreg,
		ISNULL(#serviceregistry.registry,registry.title) as registry,
		#serviceregistry.nservreg,
		#serviceregistry.cf,
		#serviceregistry.birthdate ,
		#serviceregistry.grossamount,
		#serviceregistry.start,
		#serviceregistry.stop,
		#serviceregistry.apactivitykind,
		#serviceregistry.authorizationdate,
		#serviceregistry.annoliquidazione,
		#registry_birth.city_title AS b_city,
		#registry_birth.province AS b_province,
		#registry_birth.nation_title AS b_nation,
		#address_to_send.recipientagency AS sent_agency,
		#address_to_send.officename AS sent_office,
		#address_to_send.address AS sent_address,
		isnull(add_sen.codeaddress,'') AS sent_idaddresskind, 
		#address_to_send.location AS sent_location,
		#address_to_send.cap AS sent_cap,
		#address_to_send.province AS sent_province,
		#address_to_send.nation AS sent_nation,
		#address_residence.address AS residence_address,
		add_res.codeaddress AS residence_idaddresskind,
		#address_residence.location AS residence_location,
		#address_residence.cap AS residence_cap,
		#address_residence.province AS residence_province,
		#address_residence.nation AS residence_nation,
		#serviceregistry.description
	FROM #serviceregistry
	JOIN registry
		ON #serviceregistry.idreg = registry.idreg
	JOIN #registry_birth
		ON #serviceregistry.idreg = #registry_birth.idreg
	LEFT OUTER JOIN #address_to_send
		ON #address_to_send.idreg = #serviceregistry.idreg
	LEFT OUTER JOIN address add_sen
		ON add_sen.idaddress = #address_to_send.idaddresskind
	LEFT OUTER JOIN #address_residence
		ON #address_residence.idreg = #serviceregistry.idreg
	LEFT OUTER JOIN address add_res
		ON add_res.idaddress = #address_to_send.idaddresskind
	WHERE ISNULL(add_sen.codeaddress,'07_SW_DEF') =  '07_SW_ANP'
END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- all
-- setuser 'amm'

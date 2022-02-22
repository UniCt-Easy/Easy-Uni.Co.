
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certificazione_premi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certificazione_premi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [rpt_certificazione_premi]
(
	@ayear smallint, 
	@idreg int, 
	@certificatekind char(1)
)
AS BEGIN

CREATE TABLE #expensetax
(
	idexp int,
	idreg int,
	registry varchar(100),
	cf varchar(16),
	birthdate smalldatetime,
	taxdescription varchar(50),
	expensedescription varchar(150),	
	commondetail char(1),
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	grossamount decimal (19,2),
	taxablegross decimal (19,2),
	service varchar(50),
	idser int,
	npay int
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
	nation varchar(65)
)

CREATE TABLE #registry_birth
(	idreg int,
	city_title varchar(120),
	province varchar(2),
	nation_title varchar(65),
)


DECLARE @dateaddress datetime
SELECT  @dateaddress = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

/*DECLARE @idreg int

IF @registry = '%' 
BEGIN
	SET  @idreg = 0
END
ELSE
BEGIN
	SET  @idreg = (SELECT idreg FROM registry WHERE title like @registry)
END*/

INSERT INTO #expensetax
(
	idexp,
	idreg,
	registry,
	birthdate,
	cf,
	taxdescription,
	expensedescription,
	taxablenet,
	employtax, 
	admintax, 
	taxablegross,-- Imponibile Lordo
	grossamount,--Importo Lordo del Pagamento
	service,
	idser,
	npay
)
SELECT
	T.idexp,
	T.idreg,
	registry.title,
	registry.birthdate,
	registry.cf,
	T.taxdescription,
	T.expensedescription,
	SUM(T.taxablenet),
	SUM(T.employtax),
	SUM(T.admintax), 
	T.taxablegross,
	ISNULL(expensetotal.curramount,0),
	service.description,
	service.idser,
	payment.npay
FROM
	(SELECT
		SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
		SUM(ISNULL(E.employtax,0)) AS employtax,
		SUM(ISNULL(E.admintax,0)) AS admintax,
		isnull(E.taxablegross,0) as taxablegross,
		E.idexp,
		expense.idreg,
		E.description as taxdescription,
		expense.description as expensedescription,
		expense.idman,
		expenselast.idser,
		expenselast.kpay
	FROM expensetaxofficialview AS E
	JOIN expense 
		ON expense.idexp = E.idexp
	JOIN expenselast
		ON expenselast.idexp = expense.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	WHERE expense.ymov = @ayear  
		AND (expense.idreg=@idreg OR @idreg=0)
		AND service.certificatekind = @certificatekind
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,
		E.description,expense.description,
	expense.idman,expenselast.idser,expense.ymov,expenselast.kpay,e.taxablegross) AS T
JOIN registry 
	ON T.idreg = registry.idreg  
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN fin
	ON expenseyear.idfin = fin.idfin
JOIN upb
	ON expenseyear.idupb = upb.idupb
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
WHERE   YEAR(paymenttransmission.transmissiondate) = @ayear
	AND service.certificatekind = @certificatekind
	AND expensetotal.ayear = @ayear
	AND expenseyear.ayear  = @ayear
GROUP BY T.idreg, T.idexp, registry.title, registry.birthdate, registry.cf,
	 T.taxdescription, expensetotal.curramount, service.description,
	 service.idser,
	 payment.npay,
	 T.taxablegross,T.expensedescription	

DECLARE  @appropriation tinyint
SELECT   @appropriation = expensephase FROM config WHERE ayear =@ayear
PRINT    @appropriation

		

---------------------------------
    
DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_CER'

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
	nation
)
SELECT 
	idaddresskind,
	registryaddress.idreg, 
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
        AND (idreg IN (select idreg from  #expensetax))
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateaddress
			AND cdi.idreg = registryaddress.idreg)
)

DELETE #address_to_send
WHERE #address_to_send.idaddresskind <> @nostand
AND EXISTS(
	SELECT * FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
		AND r2.idaddresskind = @NOSTAND
	)

DELETE #address_to_send
WHERE #address_to_send.idaddresskind NOT IN (@NOSTAND, @STAND)
AND EXISTS(
	SELECT * FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
		AND r2.idaddresskind = @STAND
	)

DELETE #address_to_send
WHERE (
	SELECT COUNT(*) FROM #address_to_send r2 
	WHERE #address_to_send.idreg = r2.idreg
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
WHERE  (idreg IN (select idreg from  #expensetax))

		
DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


SELECT
        @departmentname as departmentname,
	#expensetax.idexp,
	#expensetax.idreg,
	#expensetax.registry,
	#registry_birth.city_title AS b_city,
	#expensetax.birthdate,
	#registry_birth.province AS b_province,
	#registry_birth.nation_title AS b_nation,
	#expensetax.cf,
	#expensetax.taxdescription,
	expensedescription,	
	#expensetax.service,
	#expensetax.idser,
	#expensetax.npay,
	(#expensetax.taxablenet) as taxablenet,
	#expensetax.grossamount,--Importo Lordo del Pagamento
	(#expensetax.employtax) as employtax,
	(#expensetax.admintax) as admintax,
	#expensetax.taxablegross, -- Imponibile Lordo
	#address_to_send.officename AS sent_office,
	#address_to_send.address AS sent_address,
	address.codeaddress AS sent_idaddresskind, 
	#address_to_send.location AS sent_location,
	#address_to_send.cap AS sent_cap,
	#address_to_send.province AS sent_province,
	#address_to_send.nation AS sent_nation
FROM #expensetax
JOIN #registry_birth
	ON #expensetax.idreg = #registry_birth.idreg
LEFT OUTER JOIN #address_to_send
	ON #address_to_send.idreg = #expensetax.idreg
LEFT OUTER JOIN address
	ON address.idaddress = #address_to_send.idaddresskind
ORDER BY #expensetax.registry

DROP TABLE #expensetax
DROP TABLE #address_to_send
DROP TABLE #registry_birth

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

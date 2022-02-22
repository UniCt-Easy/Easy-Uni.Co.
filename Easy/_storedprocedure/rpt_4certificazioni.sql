
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_4certificazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_4certificazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [rpt_4certificazioni]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@certificatekind char(1)
)
AS BEGIN

/*
	exec rpt_4certificazioni 2013,21,{ts '2013-01-20 00:00:00'},{ts '2013-12-31 00:00:00'}, 'F'
*/
CREATE TABLE #expensetax
(
	idexp int,
	idreg int,
	taxdescription varchar(50),
	expensedescription varchar(150),	
	commondetail char(1),
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	grossamount decimal (19,2),
	--taxablegross decimal (19,2), IL REPORT NON LO USA !
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

IF @ayear = 0
BEGIN
	SET @ayear='1900'
END

DECLARE @dateaddress datetime
SELECT @dateaddress = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

INSERT INTO #expensetax
(
	idexp,
	idreg,
	taxdescription,
	expensedescription,
	taxablenet,
	employtax, 
	admintax, 
	--taxablegross,-- Imponibile Lordo
	grossamount,--Importo Lordo del Pagamento
	service,
	idser,
	npay
)
SELECT
	T.idexp,
	T.idreg,
	T.taxdescription,
	T.expensedescription,
	SUM(T.taxablenet),
	SUM(T.employtax),
	SUM(T.admintax), 
	--T.taxablegross,
	ISNULL(expensetotal.curramount,0),
	service.description,
	service.idser,
	payment.npay
FROM
	(SELECT
		ISNULL(SUM(E.taxablenet),0) AS taxablenet,
		ISNULL(SUM(E.employtax),0) AS employtax,
		ISNULL(SUM(E.admintax),0) AS admintax,
		--isnull(E.taxablegross,0) as taxablegross,
		E.idexp,
		expense.idreg,
		E.description as taxdescription,
		expense.description as expensedescription,
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
	GROUP BY expense.idreg,E.idexp,expenselast.idser,
		E.description,expense.description,
                expenselast.kpay,service.module
    HAVING ((ISNULL(SUM(E.employtax),0)  <> 0   OR  ISNULL(SUM(E.admintax),0)  <> 0)   AND ISNULL(service.module,'') = 'OCCASIONALE')
    OR    ISNULL(service.module,'') <> 'OCCASIONALE' ) AS T
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
WHERE (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	AND service.certificatekind = @certificatekind
	AND expensetotal.ayear = @ayear
	AND expenseyear.ayear = @ayear
GROUP BY T.idreg, T.idexp,
	T.taxdescription, expensetotal.curramount, service.description,
	service.idser,payment.npay,T.expensedescription--,T.taxablegross	

DECLARE  @appropriation tinyint
SELECT  @appropriation = expensephase FROM config WHERE ayear =@ayear

-- Fondo economale :

UPDATE #expensetax
		SET grossamount = grossamount + isnull(
			(SELECT SUM(pettycashoperation.amount)
		FROM pettycashoperation
		JOIN pettycashoperationcasualcontract
			ON  pettycashoperation.idpettycash = pettycashoperationcasualcontract.idpettycash
			AND pettycashoperation.yoperation  = pettycashoperationcasualcontract.yoperation
			AND pettycashoperation.noperation  = pettycashoperationcasualcontract.noperation
		JOIN casualcontract 
			ON  casualcontract.ycon  = pettycashoperationcasualcontract.ycon
			AND casualcontract.ncon  = pettycashoperationcasualcontract.ncon
		join expensecasualcontract
			ON expensecasualcontract.ycon = casualcontract.ycon
			and expensecasualcontract.ncon = casualcontract.ncon
		join expense
			ON expense.idexp = expensecasualcontract.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
 		WHERE 
			expenselink.nlevel = @appropriation
			and casualcontract.idreg = #expensetax.idreg
			AND casualcontract.idser = #expensetax.idser
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperation.adate BETWEEN @start AND @stop) 
                        )
		,0)

UPDATE #expensetax
		SET grossamount =  grossamount + isnull(
			(SELECT SUM(ISNULL(pettycashoperation.amount, 0))
		FROM pettycashoperation
		JOIN pettycashoperationprofservice
			ON pettycashoperation.idpettycash = pettycashoperationprofservice.idpettycash
			AND pettycashoperation.yoperation = pettycashoperationprofservice.yoperation
			AND pettycashoperation.noperation = pettycashoperationprofservice.noperation
		JOIN profservice 
			ON  profservice.ycon  = pettycashoperationprofservice.ycon
			AND profservice.ncon  = pettycashoperationprofservice.ncon
		join expenseprofservice
			ON expenseprofservice.ycon = profservice.ycon
			and expenseprofservice.ncon = profservice.ncon
		join expense
			ON expense.idexp = expenseprofservice.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
		WHERE expenselink.nlevel = @appropriation
			AND (profservice.idreg = #expensetax.idreg)
			AND profservice.idser = #expensetax.idser
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperation.adate BETWEEN @start AND @stop)
                        )
		,0)
		
UPDATE #expensetax
		SET grossamount =  grossamount + isnull(
			(SELECT SUM(ISNULL(pettycashoperation.amount, 0))
		FROM pettycashoperation
		JOIN pettycashoperationitineration
			ON pettycashoperation.idpettycash = pettycashoperationitineration.idpettycash
			AND pettycashoperation.yoperation = pettycashoperationitineration.yoperation
			AND pettycashoperation.noperation = pettycashoperationitineration.noperation
		JOIN itineration 
			ON itineration.iditineration  = pettycashoperationitineration.iditineration
		join expenseitineration
			ON expenseitineration.iditineration = itineration.iditineration
		join expense
			ON expense.idexp = expenseitineration.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
		WHERE expenselink.nlevel = @appropriation
			AND (itineration.idreg = #expensetax.idreg)
			AND itineration.idser = #expensetax.idser
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperationitineration.movkind = 6)
			AND (pettycashoperation.adate BETWEEN @start AND @stop)	
                        )
			,0)
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
	address,
	location,
	cap,
	province
)
SELECT 
	idaddresskind,
	registryaddress.idreg, 
	address,
	ISNULL(geo_city.title + ' ','') + ISNULL(registryaddress.location,'') + 
	CASE 
		WHEN registryaddress.idnation IS NOT NULL THEN ' ' + geo_nation.title ELSE ''
	END,
	registryaddress.cap,
	geo_country.province
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
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
	registry.title as registry,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,'') AS b_city,
	registry.birthdate,
	ISNULL(geo_country.province, '') AS b_province,
	ISNULL(geo_nation.title, 'ITALIA') AS b_nation,
	registry.cf, 
        registry.p_iva,
	#expensetax.taxdescription,
	expensedescription,	
	#expensetax.service,
	#expensetax.idser,
	#expensetax.npay,
	(#expensetax.taxablenet) as taxablenet,
	#expensetax.grossamount,--Importo Lordo del Pagamento
	(#expensetax.employtax) as employtax,
	(#expensetax.admintax) as admintax,
	--#expensetax.taxablegross, -- Imponibile Lordo        IL REPORT NON LO USA
	#address_to_send.address AS sent_address,
	#address_to_send.location AS sent_location,
	#address_to_send.cap AS sent_cap,
	#address_to_send.province AS sent_province,
	registry.foreigncf
FROM #expensetax
JOIN registry 
        ON #expensetax.idreg = registry.idreg
LEFT OUTER JOIN geo_city
	ON registry.idcity = geo_city.idcity  
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registry.idnation = geo_nation.idnation  
LEFT OUTER JOIN #address_to_send
	ON #address_to_send.idreg = #expensetax.idreg
order by registry.title

DROP TABLE #expensetax
DROP TABLE #address_to_send

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certificazioneprestazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certificazioneprestazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [rpt_certificazioneprestazioni]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@idser int,
	@showallser char(1) -- mostra le prestazioni non associate a certificazioni specifiche
)
AS BEGIN

/*
	exec rpt_certificazioneprestazioni 2008,0,{ts '2008-01-20 00:00:00'},
	{ts '2008-12-31 00:00:00'}, null,'N'
*/
CREATE TABLE #expensetax
(
	idexp int,
	idreg int,
	registry varchar(100),
	cf varchar(16),
	birthdate smalldatetime,
	taxcode int,   
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
	registry,
	birthdate,
	cf,
	taxcode,
	taxdescription,
	expensedescription,
	taxablenet,
	employtax, 
	admintax, 
	taxablegross,
	grossamount,
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
	T.taxcode,
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
		expense.idexp,
		E.taxcode, 
		expense.idreg,
		E.description as taxdescription,
		expense.description as expensedescription,
		expense.idman,
		expenselast.idser,
		expenselast.kpay
	FROM expense 
	JOIN expenselast
		ON expenselast.idexp = expense.idexp 
	LEFT OUTER JOIN expensetaxofficialview AS E	
		ON expense.idexp = E.idexp
	WHERE expense.ymov = @ayear  
		AND (expense.idreg=@idreg OR @idreg=0)
		AND (    expenselast.idser = @idser OR (@idser is null and expenselast.idser is not null)     )
		AND E.stop IS NULL
	GROUP BY expense.idreg, expense.idexp,E.taxcode,E.description,expense.description,
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
WHERE (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	/*
	------------------------------------------------
	--------- ELENCO CERTIFICAZIONI ----------------
	------------------------------------------------
	A	Certificazione Retribuzioni Aggiuntive	
	C	Certificazione stranieri in Convenzione	
	F	Certificazione Ritenuta d'Acconto	
	I	Certificazione INPS a gestione separata	
	P	Certificazione Premi di Studio e altri Premi	
	S	Modello Assegnisti	
	T	Certificazione a Titolo d'imposta	
	U	Modello CUD	
	------------------------------------------------
	------------------------------------------------
	------------------------------------------------
	*/
	AND ISNULL(service.certificatekind,'') <>'U'
	AND 
	(
		ISNULL(@showallser,'N') = 'N' OR
		(
			ISNULL(@showallser,'N') = 'S' AND
			ISNULL(service.certificatekind,'') NOT IN ('A','C','F','I','P','S','T') 
		)
	)
	AND expensetotal.ayear = @ayear
	AND expenseyear.ayear = @ayear
GROUP BY T.idreg, T.idexp, registry.title, registry.birthdate, registry.cf,
	T.taxcode, T.taxdescription, expensetotal.curramount, service.description,
	service.idser,
	payment.npay,
	T.taxablegross,T.expensedescription	

DECLARE  @appropriation tinyint
SELECT  @appropriation = expensephase FROM config WHERE ayear =@ayear
PRINT @appropriation

--- fondo economale -----------------------

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
		JOIN service
			ON service.idser = casualcontract.idser				
		JOIN registry
			ON registry.idreg = casualcontract.idreg
		join expensecasualcontract
			ON expensecasualcontract.ycon = casualcontract.ycon
			and expensecasualcontract.ncon = casualcontract.ncon
		join expense
			ON expense.idexp = expensecasualcontract.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
 		WHERE 
			expenselink.nlevel = @appropriation
			and registry.idreg = #expensetax.idreg
			AND service.idser = #expensetax.idser 
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperation.adate BETWEEN @start AND @stop) )
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
		JOIN service
			ON service.idser = profservice.idser				
		JOIN registry
			ON registry.idreg = profservice.idreg
		join expenseprofservice
			ON expenseprofservice.ycon = profservice.ycon
			and expenseprofservice.ncon = profservice.ncon
		join expense
			ON expense.idexp = expenseprofservice.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
		WHERE 
			expenselink.nlevel = @appropriation
			AND (registry.idreg = #expensetax.idreg)
			AND service.idser = #expensetax.idser
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperation.adate BETWEEN @start AND @stop)	)
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
		JOIN service
			ON service.idser = itineration.idser				
		JOIN registry
			ON registry.idreg = itineration.idreg
		join expenseitineration
			ON expenseitineration.iditineration = itineration.iditineration
		join expense
			ON expense.idexp = expenseitineration.idexp
		join expenselink 
			on expenselink.idparent = expense.idexp 
			and expenselink.nlevel = @appropriation
			AND (registry.idreg = #expensetax.idreg)
			AND service.idser = #expensetax.idser 
			AND expenselink.idchild = #expensetax.idexp
			AND (pettycashoperationitineration.movkind = 6)
			AND (pettycashoperation.adate BETWEEN @start AND @stop)	)
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
WHERE   (idreg IN (select idreg from  #expensetax))

DECLARE @departmentname varchar(500)


SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


SELECT @departmentname as departmentname,
	#expensetax.idexp,
	#expensetax.idreg,
	#expensetax.registry,
	#registry_birth.city_title AS b_city,
	#expensetax.birthdate,
	#registry_birth.province AS b_province,
	#registry_birth.nation_title AS b_nation,
	#expensetax.cf,
	#expensetax.taxcode,   
	#expensetax.taxdescription,
	expensedescription,	
	#expensetax.service,
	#expensetax.idser,
	#expensetax.npay,
	#expensetax.taxablenet,
	#expensetax.grossamount,
	#expensetax.employtax,
	#expensetax.admintax,
	#expensetax.taxablegross,
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

DROP TABLE #expensetax 
DROP TABLE #registry_birth
DROP TABLE #address_to_send
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certritacconto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certritacconto]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [rpt_certritacconto]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@certificatekind char(1)
)
AS BEGIN

/*
	exec rpt_certritacconto 2018,0 ,{ts '2018-01-01 00:00:00'},{ts '2018-12-31 00:00:00'}, 'F'
	exec [rpt_unified_certritacconto] 2010,15317,{ts '2010-01-01 00:00:00'},{ts '2010-12-31 00:00:00'}, 'F', 'S'
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
	service varchar(50),
	module varchar(15),
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
	grossamount,--Importo Lordo del Pagamento
	service,
	idser,
	module,
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
	CASE 
	WHEN service.module in ('OCCASIONALE','DIPENDENTE') THEN
	(ISNULL(expenseyear.amount,0) + 
	 ISNULL(
		(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expensevar v
		WHERE idexp=T.idexp					
			AND (ISNULL(v.autokind,0)<>4)					
		),0)		
	)
	ELSE NULL
	END,
	service.description,
	service.idser,
	service.module,
	payment.npay
FROM
	(SELECT
		SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
		SUM(ISNULL(E.employtax,0)) AS employtax,
		SUM(ISNULL(E.admintax,0)) AS admintax,
		expense.idexp,
		expense.idreg,
		E.description as taxdescription,
		expense.description as expensedescription,
		expenselast.idser,
		expenselast.kpay
	FROM expense 
	JOIN expenselast
		ON expenselast.idexp = expense.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	LEFT OUTER JOIN expensetaxofficialview AS E
		ON expense.idexp = E.idexp
	WHERE expense.ymov = @ayear  
		AND (expense.idreg=@idreg OR @idreg=0)
		AND service.certificatekind = @certificatekind
		AND E.stop IS NULL
	GROUP BY expense.idreg, expense.idexp,expenselast.idser,
		E.description,expense.description,
                expenselast.kpay) AS T
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
	T.taxdescription, expenseyear.amount, service.description, service.module,
	service.idser,payment.npay,T.expensedescription--,T.taxablegross	

DECLARE  @appropriation tinyint
SELECT  @appropriation = expensephase FROM config WHERE ayear =@ayear

-- VALORIZZAZIONE DEL CAMPO grossamount per i contratti professionali
-- CICLO SU #expensetax

DECLARE  @idreg1 INT
DECLARE  @idexp  INT

DECLARE @spesededucibilifis decimal(19,2)
DECLARE @imponibilereale decimal(19,2)	
DECLARE @impon_spesa decimal(19,2)
DECLARE @impon_contratto decimal(19,2)
DECLARE @quota_contratto float
DECLARE @ypro int
DECLARE @npro int
	SET @ypro = null
	SET @npro = null


DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT  idreg,idexp
FROM #expensetax
WHERE module = 'PROFESSIONALE'
ORDER BY idreg asc
FOR READ ONLY
OPEN rowcursor
	
FETCH NEXT FROM rowcursor
INTO @idreg1, @idexp
WHILE @@FETCH_STATUS = 0
BEGIN 

SELECT @ypro = ycon, @npro = ncon
		FROM profservice  C
		--WHERE EXISTS(select * from expenseprofservice EC
		--		join expenselink EL on EC.idexp=EL.idparent						
		--		where EL.idchild=@idexp
		--			AND C.ycon=EC.ycon and C.ncon=EC.ncon)
		WHERE EXISTS(select * from expenseinvoice EC
				join invoice I
					on EC.idinvkind = I.idinvkind and EC.yinv = I.yinv and EC.ninv = I.ninv
				join profservice P
						on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
				where EC.idexp=@idexp
					AND C.ycon=P.ycon and C.ncon=P.ncon)

		IF (@ypro is not null)  -- si tratta di un contratto professionale
		BEGIN
			SELECT @spesededucibilifis= SUM(amount) FROM profservicerefund PR
				join profrefund P on PR.idlinkedrefund=P.idlinkedrefund
				WHERE P.flagfiscaldeduction='S' AND
					PR.ycon=@ypro and PR.ncon=@npro
					
			SET @imponibilereale = 0		
			SELECT @imponibilereale = SUM(convert(DECIMAL(19,2),
					ROUND(taxablenet*isnull(taxabledenominator,1)/isnull(taxablenumerator,1),2)))
					FROM profservicetax	 
					JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1	
					and isnull(taxablenet,0)<>0 and isnull(taxabledenominator,0)<>0
			-----------------------------------------------------------------------	
			-- IMPONIBILE DELLA SPESA ---------------------------------------------
			-----------------------------------------------------------------------
			select  @impon_spesa = SUM(ET.taxablegross) from expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 	
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
				
			select  @impon_contratto = taxablegross from profservicetax	
				JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1		
				
			if (isnull(@impon_spesa,0)=0 OR isnull(@impon_contratto,0)=0)
				SET     @quota_contratto=1
			ELSE
				SET     @quota_contratto=isnull(@impon_spesa,0)/isnull(@impon_contratto,0)
			
			--- VALORIZZO L'AMMONTARE LORDO CORRISPOSTO
			UPDATE  #expensetax
			SET grossamount =
								ISNULL(ROUND(@quota_contratto*(isnull(@spesededucibilifis,0)+isnull(@imponibilereale,0) ),2),0)
			WHERE #expensetax.idreg = @idreg1
			AND	  #expensetax.idexp = @idexp
		END
		
FETCH NEXT FROM rowcursor
INTO @idreg1, @idexp
END 
DEALLOCATE rowcursor

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
	#expensetax.module,
	#expensetax.npay,
	(#expensetax.taxablenet) as taxablenet,
	(SELECT SUM(TGROSS.expenseamount)
		FROM (	SELECT MAX(E1.grossamount) AS expenseamount
			FROM  #expensetax  E1
			WHERE E1.idreg = #expensetax.idreg and E1.idser = #expensetax.idser
		GROUP BY E1.idexp) AS TGROSS) AS grossamount,--Importo Lordo del Pagamento*/
	(#expensetax.employtax) as employtax,
	(#expensetax.admintax) as admintax,
	#address_to_send.address AS sent_address,
	#address_to_send.location AS sent_location,
	#address_to_send.cap AS sent_cap,
	#address_to_send.province AS sent_province,
	registry.foreigncf,
	registryclass.flaghuman
FROM #expensetax
JOIN registry 
        ON #expensetax.idreg = registry.idreg
JOIN registryclass 
        ON registryclass.idregistryclass = registry.idregistryclass
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


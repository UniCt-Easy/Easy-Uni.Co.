
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certfiscali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certfiscali]
GO

CREATE   PROCEDURE [rpt_certfiscali]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idreg varchar(50),
	@certificationkind char(1)
)
AS
BEGIN	

--	exec rpt_certfiscali 2008, {ts '2008-01-20 00:00:00'},{ts '2008-10-20 00:00:00'},0,'A'
CREATE TABLE #fiscal_declaration
(
	idreg int,
	registry varchar(100),
	birthnation varchar(65),
	birthplace varchar(120),
	birthprovince varchar(2),
	birthdate datetime,
	cf varchar(16),
	amountgross decimal(19,2),
	taxable decimal(19,2),
	fiscalretension decimal(19,2),
	otherretensions decimal(19,2)	
)
	
IF @ayear  = 0
BEGIN
	SET @ayear='1900'
END

DECLARE @filter varchar(50)
IF @idreg = 0
BEGIN
	SELECT @filter = '%'
END
ELSE
BEGIN
	SELECT @filter = title FROM registry WHERE idreg = @idreg
END

	INSERT INTO #fiscal_declaration
	(
		idreg,
		registry,
		birthdate,
		birthplace,
		birthprovince,
		birthnation,
		cf,
		amountgross
	)
	SELECT
		expense.idreg,
		registry.title,
		registry.birthdate,
		ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location, ''),
		ISNULL(geo_country.province, ''),
		ISNULL(geo_nation.title, 'ITALIA'),
		registry.cf,
		CASE 
			WHEN @certificationkind = 'C' THEN SUM(ISNULL(expenseyear_starting.amount, 0)) --expense.amount
			ELSE 0
		END
	FROM expense 
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN payment 
		ON payment.kpay = expenselast.kpay
	JOIN paymenttransmission
		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	JOIN service
		ON service.idser = expenselast.idser				
	JOIN registry
		ON registry.idreg = expense.idreg
	LEFT OUTER JOIN geo_city
		ON geo_city.idcity = registry.idcity
	LEFT OUTER JOIN geo_country
		ON geo_city.idcountry = geo_country.idcountry
	LEFT OUTER JOIN geo_nation
		ON geo_nation.idnation = registry.idnation

	LEFT OUTER JOIN expensetotal expensetotal_firstyear
	  	ON expensetotal_firstyear.idexp = expense.idexp
	  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting 
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear

	WHERE 
	(service.certificatekind =@certificationkind) AND
	(@certificationkind = 'C' OR
	((service.flagalwaysinfiscalmodels='S') OR
	(exists (SELECT * from expensetax D 
	           JOIN tax t
		     ON t.taxcode= D.taxcode 
	          WHERE t.taxkind=1 and D.idexp = expense.idexp)

	))
	)
	 and
	(registry.title LIKE @filter)  and
	(paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	GROUP BY
	expense.idreg,
	registry.title,
	registry.birthdate,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location, ''),
	ISNULL(geo_country.province, ''),
	ISNULL(geo_nation.title, 'ITALIA'),
	registry.cf
	
	if UPPER(@certificationkind) = 'C'
	BEGIN
		UPDATE #fiscal_declaration
		SET amountgross = amountgross +
			(SELECT SUM(ISNULL(expensevar.amount, 0))
		FROM expensevar
		JOIN expense 
			ON expensevar.idexp = expense.idexp
		JOIN expenselast
			ON expense.idexp = expenselast.idexp
		JOIN payment 
			ON payment.kpay = expenselast.kpay
		JOIN paymenttransmission
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		JOIN service
			ON service.idser = expenselast.idser				
		JOIN registry
			ON registry.idreg = expense.idreg
		WHERE 
			(service.certificatekind = 'C')
			AND 
			(
			    (service.flagalwaysinfiscalmodels='S') OR
			    (exists (SELECT * from expensetax D 
	          		          JOIN tax t
		                            ON t.taxcode= D.taxcode 
	                                 WHERE t.taxkind=1 and D.idexp = expense.idexp))
			)
			AND (registry.idreg = #fiscal_declaration.idreg)
			AND ISNULL(expensevar.autokind,0) <> 4 -- RITEN
			AND (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
		)
	END
	------------------------------------------------------------------------------
	---------------------Certificazione Fiscale Modello C, D----------------------
	------------------------------------------------------------------------------
	
	if UPPER(@certificationkind) IN ('C','D')
	BEGIN
		UPDATE #fiscal_declaration
		SET amountgross = amountgross +
			(SELECT SUM(ISNULL(pettycashoperation.amount, 0))
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
		WHERE 
			(service.certificatekind in ('C','D'))
			AND (service.flagalwaysinfiscalmodels='S') 
			AND (registry.idreg = #fiscal_declaration.idreg)
			AND (pettycashoperation.adate BETWEEN @start AND @stop)
		)
		
		UPDATE #fiscal_declaration
		SET amountgross = amountgross + 
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
		WHERE 
			(service.certificatekind in ('C','D'))
			AND (service.flagalwaysinfiscalmodels='S') 
			AND (registry.idreg = #fiscal_declaration.idreg)
			AND (pettycashoperation.adate BETWEEN @start AND @stop)
		)
		
		
		UPDATE #fiscal_declaration
		SET amountgross = amountgross +
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
		WHERE 
			(service.certificatekind in ('C','D'))
			AND (service.flagalwaysinfiscalmodels='S') 
			AND (registry.idreg = #fiscal_declaration.idreg)
			AND (pettycashoperationitineration.movkind IN ('ANPAG'))
			AND (pettycashoperation.adate BETWEEN @start AND @stop)
		)
	END

	------------------------------------------------------------------------------------------- 	
	
	CREATE TABLE #address_to_send
	(
		idaddresskind int,
		idreg int,
		officename varchar(50),
		sendaddress varchar(100),
		sendlocation varchar(120),
		sendcap varchar(20),
		sendprovince varchar(2),
		sendnation varchar(65)	
	)

	DECLARE @codestandardaddresskind varchar(20)
	SELECT @codestandardaddresskind = '07_SW_DEF'

	DECLARE @standardaddresskind int
	SELECT @standardaddresskind = idaddress FROM address WHERE codeaddress = @codestandardaddresskind

	DECLARE @validityaddress datetime
	SELECT @validityaddress = CONVERT(datetime, '31-12-'+ convert(varchar(4),@ayear), 105)

	DECLARE @coderesidaddresskind varchar(20)
	SELECT  @coderesidaddresskind = '07_SW_DOM'

	DECLARE @codesendaddresskind varchar(20)

	IF  UPPER(@certificationkind) = 'A' 
	BEGIN
	    SELECT @codesendaddresskind = '07_SW_CER'
	END

	IF  UPPER(@certificationkind) = 'B' 
	BEGIN
	    SELECT @codesendaddresskind = '07_SW_DOM'
	END
	IF  UPPER(@certificationkind) = 'C' 
	BEGIN
	    SELECT @codesendaddresskind = '07_SW_DOM'
	END
	IF  UPPER(@certificationkind) = 'D'  
	BEGIN
	    SELECT @codesendaddresskind = 'DICRF'
	END

	DECLARE @sendaddresskind int
	SELECT @sendaddresskind = idaddress FROM address WHERE codeaddress = @codesendaddresskind
	
	DECLARE @residaddresskind int
	SELECT @residaddresskind = idaddress FROM address WHERE codeaddress = @coderesidaddresskind
	

	INSERT INTO #address_to_send
	SELECT
		idaddresskind,
		idreg, 
		officename, 
		address,
		ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,''),
		registryaddress.cap,
		geo_country.province,
		CASE 
			when flagforeign = 'N' then 'Italia'
			else geo_nation.title
		END
	FROM registryaddress
	LEFT OUTER JOIN geo_city
		ON geo_city.idcity = registryaddress.idcity
	LEFT OUTER JOIN geo_country
		ON geo_city.idcountry = geo_country.idcountry
	LEFT OUTER JOIN geo_nation
		ON geo_nation.idnation = registryaddress.idnation
	WHERE (
	registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @validityaddress
			and cdi.idreg = registryaddress.idreg)
	)

	delete #address_to_send
	where #address_to_send.idaddresskind != @sendaddresskind
	and exists (
		select * from #address_to_send r2 
		where #address_to_send.idreg=r2.idreg
		and r2.idaddresskind = @sendaddresskind
		)
	delete #address_to_send
	where #address_to_send.idaddresskind not in (@sendaddresskind, @standardaddresskind)
	and exists (
		select * from #address_to_send r2 
		where #address_to_send.idreg=r2.idreg
		and r2.idaddresskind = @standardaddresskind
		)
	delete #address_to_send
	where (
		select count(*) from #address_to_send r2 
		where #address_to_send.idreg=r2.idreg
	)>1
		
	CREATE TABLE #residence_address
	(
		idaddresskind varchar(6),
		idreg int,
		officename varchar(50),
		residaddress varchar(100),
		residlocation varchar(120),
		residcap varchar(20),
		residprovince varchar(2),
		residnation varchar(65)	
	)

	INSERT 	INTO #residence_address
	SELECT 	idaddresskind,
		idreg, 
		officename, 
		address,
		ISNULL(geo_city.title,'')+' '+ISNULL(registryaddress.location,'') ,
		registryaddress.cap,
		geo_country.province,
		CASE 
			when flagforeign = 'N' then 'Italia'
			else geo_nation.title
		END
	FROM registryaddress
	LEFT OUTER JOIN geo_city
		ON geo_city.idcity = registryaddress.idcity
	LEFT OUTER JOIN geo_country
		ON geo_city.idcountry = geo_country.idcountry
	LEFT OUTER JOIN geo_nation
		ON geo_nation.idnation = registryaddress.idnation
	WHERE 
		(	
		registryaddress.active <>'N' 
		AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start  <= @validityaddress
			AND cdi.idreg  =  registryaddress.idreg)
	)
	delete #residence_address
	where #residence_address.idaddresskind != @residaddresskind
	and exists (
		select * from #residence_address r2 
		where #residence_address.idreg=r2.idreg
		and r2.idaddresskind = @residaddresskind
		)
	delete #residence_address
	where #residence_address.idaddresskind not in (@residaddresskind, @standardaddresskind)
	and exists (
		select * from #residence_address r2 
		where #residence_address.idreg=r2.idreg
		and r2.idaddresskind = @standardaddresskind
		)
	delete #residence_address
	where (
		select count(*) from #residence_address r2 
		where #residence_address.idreg=r2.idreg
		)>1
IF UPPER(@certificationkind) in ('A','B','D')
BEGIN
	UPDATE #fiscal_declaration 
	SET taxable = 
		(SELECT ISNULL(SUM(tabella.taxablelordo),0)
		FROM 
		(select max(E.taxablegross) as 'taxablelordo',E.idexp
		   from expensetax as E
		   JOIN tax
		   	ON tax.taxcode = E.taxcode
		   JOIN expense
		   	ON expense.idexp = E.idexp
		  JOIN expenselast
			ON expense.idexp = expenselast.idexp	
		   JOIN payment
		   	ON payment.kpay = expenselast.kpay
		   JOIN paymenttransmission
		  	 ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		   JOIN service
		   	ON service.idser=expenselast.idser
		   JOIN registry
		  	 ON registry.idreg = expense.idreg
		   WHERE 
		   service.certificatekind = @certificationkind AND
		   tax.taxkind=1 AND
		   registry.idreg = #fiscal_declaration.idreg AND
		   paymenttransmission.transmissiondate BETWEEN @start AND @stop 
		   group by E.idexp
	           ) as tabella)
 
	UPDATE #fiscal_declaration 
	SET fiscalretension =
		(SELECT  ISNULL(SUM(expensetax.employtax),0)
		FROM expensetax
		JOIN tax ON tax.taxcode = expensetax.taxcode
		JOIN expense ON expense.idexp = expensetax.idexp
		JOIN expenselast ON expense.idexp = expenselast.idexp	
		JOIN payment ON payment.kpay = expenselast.kpay
		JOIN paymenttransmission ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		JOIN service ON service.idser=expenselast.idser
		JOIN registry ON registry.idreg = expense.idreg
		WHERE 
		(service.certificatekind = @certificationkind)AND
		(tax.taxkind=1) AND
		(registry.idreg = #fiscal_declaration.idreg) AND
		(paymenttransmission.transmissiondate BETWEEN @start AND @stop)
		)
END
------------------------------------------------------------------------------
---------------------Certificazione Fiscale Modello A-------------------------
------------------------------------------------------------------------------
if UPPER(@certificationkind) = 'A'
BEGIN
	UPDATE #fiscal_declaration
	SET otherretensions =
		(SELECT ISNULL(SUM(ISNULL(expensetax.employtax,0)),0)
		FROM expensetax
		JOIN tax 
			ON tax.taxcode = expensetax.taxcode
		JOIN expense 	
			ON expense.idexp = expensetax.idexp
		JOIN expenselast
			ON expense.idexp = expenselast.idexp	
		JOIN service 
			ON service.idser=expenselast.idser
		JOIN registry 
			ON registry.idreg = expense.idreg
		JOIN payment  
			ON payment.kpay = expenselast.kpay
		JOIN paymenttransmission   
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		WHERE 
			(service.certificatekind = 'A')AND
			(tax.taxkind=3) AND
			(registry.idreg = #fiscal_declaration.idreg) AND
			(paymenttransmission.transmissiondate BETWEEN @start AND @stop) 
		)
END

--------------------------------------------------------------------------------------
---------------------Certificazione Fiscale Modello D---------------------------------
--------------------------------------------------------------------------------------
if UPPER(@certificationkind) = 'D'
BEGIN
	UPDATE #fiscal_declaration
	SET amountgross = amountgross + (SELECT SUM(ISNULL(expenseyear_starting.amount, 0)) /*+ --- EXPENSE.AMOUNT
					(SELECT SUM(ISNULL(expensevar.amount, 0)) 
					 FROM expensevar WHERE  expense.idexp = expensevar.idexp
					 AND  ISNULL(expensevar.autokind,'') <> 'RITEN')*/
		FROM expense
	 	JOIN expenselast
			ON expense.idexp = expenselast.idexp	
		JOIN service 
			ON service.idser=expenselast.idser
		JOIN payment 
			ON payment.kpay = expenselast.kpay
		JOIN paymenttransmission	
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission

		LEFT OUTER JOIN expensetotal expensetotal_firstyear
		  	ON expensetotal_firstyear.idexp = expense.idexp
		  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear

		WHERE 
		(service.certificatekind = 'D') 
		AND
		((service.flagalwaysinfiscalmodels='S') OR
		 (exists (SELECT * from expensetax D 
	          JOIN tax t
	         ON t.taxcode= D.taxcode 
		 WHERE t.taxkind=1 and D.idexp = expense.idexp)
		))
		AND (expense.idexp NOT IN (SELECT idexp FROM expenseitineration))
		AND (expense.idreg = #fiscal_declaration.idreg)
		AND (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	)
	
	UPDATE #fiscal_declaration
	SET amountgross = amountgross + (SELECT SUM(ISNULL(expensevar.amount, 0))
		FROM expensevar
		JOIN expense
			ON expense.idexp = expensevar.idexp
		JOIN expenselast
			ON expense.idexp = expenselast.idexp	
		JOIN service 
			ON service.idser=expenselast.idser
		JOIN payment 
			ON payment.kpay = expenselast.kpay
		JOIN paymenttransmission	
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		WHERE 
		(service.certificatekind = 'D') 
		AND
		((service.flagalwaysinfiscalmodels='S') OR
		 (exists (SELECT * from expensetax D 
	          JOIN tax t
	         ON t.taxcode= D.taxcode 
		 WHERE t.taxkind=1 and D.idexp = expense.idexp)
		))
		AND (expense.idexp NOT IN (SELECT idexp FROM expenseitineration))
		AND (expense.idreg = #fiscal_declaration.idreg)
		AND (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
		AND ISNULL(expensevar.autokind,0) <> 4 -- RITEN
	)

	UPDATE #fiscal_declaration
	SET amountgross =  amountgross + 
		ISNULL(amountgross, 0) +
		ISNULL((SELECT SUM(ISNULL(expenseyear_starting.amount, 0))  -- expense.amount
			FROM expense
			JOIN expenselast
				ON expense.idexp = expenselast.idexp	
			JOIN service 
				ON service.idser=expenselast.idser
			JOIN payment 
				ON payment.kpay = expenselast.kpay
			JOIN paymenttransmission	
				ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
			  	ON expensetotal_firstyear.idexp = expense.idexp
			  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	
			WHERE 
			(service.certificatekind = 'D') 
			AND ((service.flagalwaysinfiscalmodels='S') OR
			 	(exists (SELECT * from expensetax D 
                         		 JOIN tax t
                        		 	ON t.taxcode= D.taxcode 
			 		WHERE t.taxkind=1 and D.idexp = expense.idexp)
				))
			AND (expense.idexp IN 
				   (SELECT m1.idexp FROM expenseitineration m1
					WHERE m1.movkind = 'SALDO' OR 
					(m1.movkind = 'ANPAG' 
					  AND EXISTS (SELECT * FROM expenseitineration m2
							JOIN expenseyear	ON expenseyear.idexp = m2.idexp													
							WHERE m2.movkind = 'SALDO' 
							      AND expenseyear.ayear = @ayear	
							      AND m1.iditineration = m2.iditineration
						     )
					)
				    )
			    )
			AND expense.idreg = #fiscal_declaration.idreg
			AND paymenttransmission.transmissiondate BETWEEN @start AND @stop
			),0)
			
		UPDATE #fiscal_declaration
		SET amountgross =  ISNULL(amountgross, 0) + 
			ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0))
			FROM expensevar
			JOIN expense
			ON expense.idexp = expensevar.idexp
			JOIN expenselast
				ON expense.idexp = expenselast.idexp	
			JOIN service 
				ON service.idser=expenselast.idser
			JOIN payment 
				ON payment.kpay = expenselast.kpay
			JOIN paymenttransmission	
				ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
			WHERE 
			(service.certificatekind = 'D') 
			AND ((service.flagalwaysinfiscalmodels='S') OR
			 	(exists (SELECT * from expensetax D 
                         		 JOIN tax t
                        		 	ON t.taxcode= D.taxcode 
			 		WHERE t.taxkind=1 and D.idexp = expense.idexp)
				))
			AND (expense.idexp IN 
				   (SELECT m1.idexp FROM expenseitineration m1
					WHERE m1.movkind = 'SALDO' OR 
					(m1.movkind = 'ANPAG' 
					  AND EXISTS (SELECT * FROM expenseitineration m2
							JOIN expenseyear	ON expenseyear.idexp = m2.idexp													
							WHERE m2.movkind = 'SALDO' 
							      AND expenseyear.ayear = @ayear	
							      AND m1.iditineration = m2.iditineration
						     )
					)
				    )
			    )
			AND expense.idreg = #fiscal_declaration.idreg
			AND paymenttransmission.transmissiondate BETWEEN @start AND @stop
			AND ISNULL(expensevar.autokind,0) <> 4 -- ISNULL(expensevar.autokind,'') <> 'RITEN'
			),0)
END


------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
SELECT
	#fiscal_declaration.idreg,
	#fiscal_declaration.registry,
	#fiscal_declaration.birthdate,
	#fiscal_declaration.birthplace,
	#fiscal_declaration.birthprovince,
	#fiscal_declaration.birthnation,
	#fiscal_declaration.cf,
	#fiscal_declaration.amountgross,
	#fiscal_declaration.taxable,
	#fiscal_declaration.fiscalretension,
	#fiscal_declaration.otherretensions,
	#address_to_send.officename,
	#address_to_send.sendaddress as spedaddress,
	#address_to_send.sendlocation as spedlocation,
	#address_to_send.sendcap,
	#address_to_send.sendprovince as spedprovince,
	#address_to_send.sendnation as spednation,
	#residence_address.residaddress as residaddress,
	#residence_address.residlocation as residlocation,
	#residence_address.residcap,
	#residence_address.residprovince as residprovince,
	#residence_address.residnation 	as residnation
	FROM #fiscal_declaration
	LEFT OUTER JOIN #address_to_send
		ON #address_to_send.idreg = #fiscal_declaration.idreg
	LEFT OUTER JOIN #residence_address
		ON #residence_address.idreg = #fiscal_declaration.idreg
ORDER BY #fiscal_declaration.registry ASC
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

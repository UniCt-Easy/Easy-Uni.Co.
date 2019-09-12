if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certfiscale_assegnisti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certfiscale_assegnisti]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE     PROCEDURE [rpt_certfiscale_assegnisti]
	@ayear int,
	@idreg int
AS BEGIN	
	
-- exec rpt_certfiscale_assegnisti 2007, 0
CREATE TABLE #sendingaddress
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

CREATE TABLE #fiscaldeclaration
(
	idreg int,
	registry varchar(100),
	service varchar(50),
	causale varchar(250),
	birthdate datetime,
	b_place varchar(120),
	b_province varchar(2),
	b_nation varchar(65),
	cf varchar(16),
	cfestero varchar(40),
	taxable decimal(19,2),
	taxableass decimal(19,2),
	adminretension decimal(19,2),
	employretension decimal(19,2),
	adminretensionass decimal(19,2),
	employretensionass decimal(19,2),
	amountgross decimal(19,2)
)
	
CREATE TABLE #residenceaddress
(
	idaddresskind int,
	idreg int,
	officename varchar(50),
	residaddress varchar(100),
	residlocation varchar(120),
	residcap varchar(20),
	residprovince varchar(2),
	residnation varchar(65)	
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

DECLARE @expensephase tinyint
SELECT @expensephase = expensephase FROM config WHERE ayear = @ayear
INSERT INTO #fiscaldeclaration
(
	idreg,
	registry,
	service,
	birthdate,
	b_place,
	b_province,  
	b_nation,
	cf
)
SELECT
	expense.idreg,
	registry.title,
	service.description,
	registry.birthdate,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''),
	ISNULL(geo_nation.title, 'ITALIA'),
	registry.cf
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
LEFT OUTER JOIN expenselink
	ON expense.idexp = expenselink.idchild
	AND expenselink.nlevel = @expensephase
LEFT OUTER JOIN expensepayroll
	ON expensepayroll.idexp = expenselink.idparent
LEFT OUTER JOIN payroll
	ON payroll.idpayroll = expensepayroll.idpayroll
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
WHERE service.certificatekind = 'S' AND  
EXISTS (SELECT * FROM expensetaxofficial D 
            JOIN tax t
	      	 ON t.taxcode= D.taxcode 
           WHERE D.idexp = expense.idexp
		AND D.stop IS NULL)
	AND registry.title LIKE @filter
	AND (
		((YEAR(paymenttransmission.transmissiondate) = @ayear)
		AND (payroll.fiscalyear IS NULL))
		OR (payroll.fiscalyear = @ayear)
	)
GROUP BY expense.idreg, registry.title, registry.birthdate,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''), ISNULL(geo_nation.title, 'ITALIA'),
	service.description, registry.cf
		
DECLARE @codesendaddresskind varchar(20)
SELECT 	@codesendaddresskind = '07_SW_DOM'

DECLARE @coderesidaddresskind varchar(20)
SELECT  @coderesidaddresskind = '07_SW_DOM'

DECLARE @codestandardaddresskind varchar(20)
SELECT  @codestandardaddresskind = '07_SW_DEF'

DECLARE @sendaddresskind int
SELECT  @sendaddresskind = idaddress FROM address WHERE codeaddress = @codesendaddresskind

DECLARE @residaddresskind int
SELECT  @residaddresskind = idaddress FROM address WHERE codeaddress = @coderesidaddresskind

DECLARE @standardaddresskind int
SELECT  @standardaddresskind = idaddress FROM address WHERE codeaddress = @codestandardaddresskind

DECLARE @validityaddress datetime
SELECT  @validityaddress = CONVERT(datetime, '31-12-' + CONVERT(varchar(4),@ayear), 105)
	
INSERT INTO #sendingaddress
SELECT 	idaddresskind,
	registryaddress.idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
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
        AND (idreg IN (select idreg from  #fiscaldeclaration))
AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active <>'N' 
		AND cdi.start <= @validityaddress
		and cdi.idreg = registryaddress.idreg)
)
	delete #sendingaddress
	where #sendingaddress.idaddresskind != @sendaddresskind
	and exists (
		select * from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
		and r2.idaddresskind = @sendaddresskind
		)
	delete #sendingaddress
	where #sendingaddress.idaddresskind not in (@sendaddresskind, @standardaddresskind)
	and exists (
		select * from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
		and r2.idaddresskind = @standardaddresskind
		)
	delete #sendingaddress
	where (
		select count(*) from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
	)>1
 
 
	 UPDATE #fiscaldeclaration 
 		SET taxable = 
  			(SELECT ISNULL(SUM(tabella.taxablelordo),0)
 		 	 FROM 
				  (select max(E.taxablegross) as 'taxablelordo',E.idexp
				     from expensetaxofficial as E
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
					LEFT OUTER JOIN expenselink
						ON expense.idexp = expenselink.idchild
						AND expenselink.nlevel = @expensephase
					LEFT OUTER JOIN expensepayroll
						ON expensepayroll.idexp = expenselink.idparent
					LEFT OUTER JOIN payroll
						ON payroll.idpayroll = expensepayroll.idpayroll
				     WHERE 
				     service.certificatekind = 'S' AND
				     tax.taxkind=3 AND  
					E.stop IS NULL AND
				     registry.idreg = #fiscaldeclaration.idreg
					AND (
						((YEAR(paymenttransmission.transmissiondate) = @ayear)
						AND (payroll.fiscalyear IS NULL))
						OR (payroll.fiscalyear = @ayear)
					)
				     group by E.idexp
				     ) as tabella)

	UPDATE #fiscaldeclaration 
 		SET taxableass = 
  			(SELECT ISNULL(SUM(tabella.taxablelordo),0)
 		 	 FROM 
				  (select max(E.taxablegross) as 'taxablelordo',E.idexp
				     from expensetaxofficial as E
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
					LEFT OUTER JOIN expenselink
						ON expense.idexp = expenselink.idchild
						AND expenselink.nlevel = @expensephase
					LEFT OUTER JOIN expensepayroll
						ON expensepayroll.idexp = expenselink.idparent
					LEFT OUTER JOIN payroll
						ON payroll.idpayroll = expensepayroll.idpayroll
				     WHERE 
				     service.certificatekind = 'S' AND
					E.stop IS NULL AND
				     tax.taxkind=4 AND  
				     registry.idreg = #fiscaldeclaration.idreg
					AND (
						((YEAR(paymenttransmission.transmissiondate) = @ayear)
						AND (payroll.fiscalyear IS NULL))
						OR (payroll.fiscalyear = @ayear)
					)
				     group by E.idexp
				     ) as tabella)
 
	UPDATE #fiscaldeclaration 
	SET adminretension =
		(SELECT ISNULL(SUM(E.admintax),0) 
		   	FROM expensetaxofficial as E
		   	JOIN expense
		   		ON expense.idexp = E.idexp
			JOIN tax 
				ON tax.taxcode = E.taxcode
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
			LEFT OUTER JOIN expenselink
				ON expense.idexp = expenselink.idchild
				AND expenselink.nlevel = @expensephase
			LEFT OUTER JOIN expensepayroll
				ON expensepayroll.idexp = expenselink.idparent
			LEFT OUTER JOIN payroll
				ON payroll.idpayroll = expensepayroll.idpayroll
		  	 WHERE 
		  		 service.certificatekind = 'S' AND
				E.stop IS NULL AND
				 tax.taxkind=3 AND
		   		 registry.idreg = #fiscaldeclaration.idreg
					AND (
						((YEAR(paymenttransmission.transmissiondate) = @ayear)
						AND (payroll.fiscalyear IS NULL))
						OR (payroll.fiscalyear = @ayear)
					)
	           	)

	UPDATE #fiscaldeclaration 
	SET adminretensionass=
		(SELECT ISNULL(SUM(E.admintax),0) 
		   	FROM expensetaxofficial as E
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
			JOIN tax 
				ON tax.taxcode = E.taxcode
		   	JOIN registry
		  	 	ON registry.idreg = expense.idreg
			LEFT OUTER JOIN expenselink
				ON expense.idexp = expenselink.idchild
				AND expenselink.nlevel = @expensephase
			LEFT OUTER JOIN expensepayroll
				ON expensepayroll.idexp = expenselink.idparent
			LEFT OUTER JOIN payroll
				ON payroll.idpayroll = expensepayroll.idpayroll
		  	 WHERE 
		  		 service.certificatekind = 'S' AND
				 tax.taxkind=4 AND
				E.stop IS NULL AND
		   		 registry.idreg = #fiscaldeclaration.idreg
				AND (
					((YEAR(paymenttransmission.transmissiondate) = @ayear)
					AND (payroll.fiscalyear IS NULL))
					OR (payroll.fiscalyear = @ayear)
				)
	           	)

	UPDATE #fiscaldeclaration 
	SET employretension =
		(SELECT ISNULL(SUM(E.employtax),0) 
		   	FROM expensetaxofficial as E
		   	JOIN expense
		   		ON expense.idexp = E.idexp
			JOIN tax 
				ON tax.taxcode = E.taxcode
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
			LEFT OUTER JOIN expenselink
				ON expense.idexp = expenselink.idchild
				AND expenselink.nlevel = @expensephase
			LEFT OUTER JOIN expensepayroll
				ON expensepayroll.idexp = expenselink.idparent
			LEFT OUTER JOIN payroll
				ON payroll.idpayroll = expensepayroll.idpayroll
		  	 WHERE 
		  		 service.certificatekind = 'S' AND
				 tax.taxkind=3 AND
				E.stop IS NULL AND
		   		 registry.idreg = #fiscaldeclaration.idreg
				AND (
					((YEAR(paymenttransmission.transmissiondate) = @ayear)
					AND (payroll.fiscalyear IS NULL))
					OR (payroll.fiscalyear = @ayear)
				)
	         )

	UPDATE #fiscaldeclaration 
	SET employretensionass =
		(SELECT ISNULL(SUM(E.employtax),0) 
		   	FROM expensetaxofficial as E
		   	JOIN expense
		   		ON expense.idexp = E.idexp
			JOIN tax 
				ON tax.taxcode = E.taxcode
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
			LEFT OUTER JOIN expenselink
				ON expense.idexp = expenselink.idchild
				AND expenselink.nlevel = @expensephase
			LEFT OUTER JOIN expensepayroll
				ON expensepayroll.idexp = expenselink.idparent
			LEFT OUTER JOIN payroll
				ON payroll.idpayroll = expensepayroll.idpayroll
		  	 WHERE 
		  		 service.certificatekind = 'S' AND
				 tax.taxkind=4 AND
				E.stop IS NULL AND
		   		 registry.idreg = #fiscaldeclaration.idreg
				AND (
					((YEAR(paymenttransmission.transmissiondate) = @ayear)
					AND (payroll.fiscalyear IS NULL))
					OR (payroll.fiscalyear = @ayear)
				)
	         )

	/*
	UPDATE #fiscaldeclaration 
	SET employretensionass = employretension ----------togliere solo per test 
	*/
	UPDATE #fiscaldeclaration
	SET amountgross = (SELECT ISNULL(SUM(expenseyear_starting.amount), 0)
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
		JOIN registry
		  	ON registry.idreg = expense.idreg
		LEFT OUTER JOIN expenselink
			ON expense.idexp = expenselink.idchild
			AND expenselink.nlevel = @expensephase
		LEFT OUTER JOIN expensepayroll
			ON expensepayroll.idexp = expenselink.idparent
		LEFT OUTER JOIN payroll
			ON payroll.idpayroll = expensepayroll.idpayroll
		WHERE 
		  	service.certificatekind = 'S' AND
			registry.idreg = #fiscaldeclaration.idreg
			AND (
				((YEAR(paymenttransmission.transmissiondate) = @ayear)
				AND (payroll.fiscalyear IS NULL))
				OR (payroll.fiscalyear = @ayear)
			)
	)
	
	UPDATE #fiscaldeclaration
	SET amountgross = amountgross + (SELECT ISNULL(SUM(expensevar.amount), 0)
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
		JOIN registry
		  	ON registry.idreg = expense.idreg
		LEFT OUTER JOIN expenselink
			ON expense.idexp = expenselink.idchild
			AND expenselink.nlevel = @expensephase
		LEFT OUTER JOIN expensepayroll
			ON expensepayroll.idexp = expenselink.idparent
		LEFT OUTER JOIN payroll
			ON payroll.idpayroll = expensepayroll.idpayroll
		WHERE service.certificatekind = 'S' AND
		      registry.idreg = #fiscaldeclaration.idreg
			AND (
				((YEAR(paymenttransmission.transmissiondate) = @ayear)
				AND (payroll.fiscalyear IS NULL))
				OR (payroll.fiscalyear = @ayear)
			)
		      AND ISNULL(expensevar.autokind,0) <> 4 -- Ritenuta
	)
	
	DECLARE @service varchar(50)
	DECLARE @service1 varchar(50)
	DECLARE @idreg2   int
	DECLARE @idreg3   int
	DECLARE @causale varchar(250)
	-- Costruzione della causale
	DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT  service,idreg
		FROM 	#fiscaldeclaration
		ORDER BY idreg,service asc
		FOR READ ONLY
		OPEN rowcursor
		FETCH NEXT FROM rowcursor
		INTO  @service, @idreg2
		SET @causale = @service
		print @service
		print @idreg2
		IF @@FETCH_STATUS = 0
		BEGIN 
			FETCH NEXT FROM rowcursor
			INTO  @service1, @idreg3
			print @service1
			print @idreg3
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				
				IF  @idreg3 <> @idreg2 
					BEGIN   
						UPDATE 	#fiscaldeclaration
						SET 	causale = @causale
						WHERE 	idreg   = @idreg2
						SET     @causale  = @service1
					END
				ELSE	
					BEGIN
						IF  @causale  is null 
						BEGIN
							SET @causale = @service
						END
					
						IF  @service1 <> @service
						SET @causale  = @causale + ' / ' + @service1
						PRINT   @causale
					END
				SELECT @idreg2 = @idreg3, @service = @service1
				FETCH NEXT FROM rowcursor
				INTO  @service1, @idreg3
				print @service1
				print @idreg3
			END
			UPDATE 	#fiscaldeclaration
			SET 	causale = @causale
			WHERE 	idreg   = @idreg2
		END 
		DEALLOCATE rowcursor
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
DECLARE @departmentname varchar(500)


SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')



SELECT DISTINCT
        @departmentname as departmentname,
	#fiscaldeclaration.idreg,
	#fiscaldeclaration.registry,
	#fiscaldeclaration.causale,
	#fiscaldeclaration.birthdate,
	#fiscaldeclaration.b_place,
	#fiscaldeclaration.b_province,
	#fiscaldeclaration.b_nation,
	#fiscaldeclaration.cf,
	#fiscaldeclaration.cfestero,
	#fiscaldeclaration.taxable,
	#fiscaldeclaration.taxableass,
	#fiscaldeclaration.adminretension,
	#fiscaldeclaration.employretension,
	#fiscaldeclaration.adminretensionass,
	#fiscaldeclaration.employretensionass,
	#fiscaldeclaration.amountgross,
	#sendingaddress.officename,
	#sendingaddress.sendaddress 	as 'spedaddress',
	#sendingaddress.sendlocation 	as 'spedlocation',
	#sendingaddress.sendcap		as 'spedcap',
	#sendingaddress.sendprovince 	as 'spedprovince',
	#sendingaddress.sendnation 	as 'spednation'
	FROM #fiscaldeclaration
	LEFT OUTER JOIN #sendingaddress
		ON #sendingaddress.idreg = #fiscaldeclaration.idreg
	LEFT OUTER JOIN #residenceaddress
		ON #residenceaddress.idreg  = #fiscaldeclaration.idreg
ORDER BY #fiscaldeclaration.registry ASC

DROP TABLE #fiscaldeclaration
DROP TABLE #sendingaddress
DROP TABLE #residenceaddress
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


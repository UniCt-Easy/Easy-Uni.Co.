-- CREAZIONE VISTA payedtaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[payedtaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payedtaxview]
GO




CREATE   VIEW [payedtaxview]
(
	cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	payed_city,
	payed_fiscaltaxregion,
	idexp,
	nbracket,
	abatements,
	nphase,
	phase,
	ymov,
	nmov,
	idreg,
	registry,
	expensedescription,
	adate,
	idser,
	codeser,
	service,
	certificatekind,
	servicestart,
	servicestop,
	taxcode,
	taxref,
	description,
	taxkind,
        taxcategory,
	taxablegross,
	taxablenet,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	competencydate,
	datetaxpay,
	ytaxpay,
	ntaxpay,
	cu,
	ct,
	lu,
	lt,
	idtreasurer,
	department
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	pgc.title,
	pftr.title,
	expensetax.idexp, 
	expensetax.nbracket, 
	expensetax.abatements,
	expense.nphase, 
	expensephase.description, 
	expense.ymov, 
	expense.nmov, 
	expense.idreg, 
	registry.title, 
	expense.description, 
	expense.adate, 
	expenselast.idser, 
	service.codeser,
	service.description, 
	service.certificatekind, 
	expenselast.servicestart, 
	expenselast.servicestop, 
	expensetax.taxcode, 
	tax.taxref,
	tax.description, 
	tax.taxkind, 
        CASE tax.taxkind
                WHEN 1 THEN 'Fiscale'
                WHEN 2 THEN 'Assistenziale'
                WHEN 3 THEN 'Previdenziale'
                WHEN 4 THEN 'Assicurativa'
                WHEN 5 THEN 'Arretrati'
                WHEN 6 THEN 'Altro'
        END,
	expensetax.taxablegross, 
	expensetax.taxablenet, 
	expensetax.employrate, 
	expensetax.employnumerator, 
	expensetax.employdenominator, 
	expensetax.employtax, 
	expensetax.adminrate, 
	expensetax.adminnumerator, 
	expensetax.admindenominator, 
	expensetax.admintax, 
	expensetax.competencydate, 
	CASE config.taxvaliditykind 
		WHEN 3 THEN payment.adate 
		WHEN 4 THEN payment.printdate
		WHEN 5 THEN  paymenttransmission.transmissiondate
		WHEN 6 THEN (SELECT MIN(banktransaction.transactiondate)
			FROM banktransaction 
			WHERE banktransaction.kpay=expenselast.kpay)
		-- data ultima fase di spesa
		WHEN 2 THEN expense.adate 
		ELSE expensetax.competencydate
	END,
	expensetax.ytaxpay, 
	expensetax.ntaxpay,
	expensetax.cu, expensetax.ct, expensetax.lu, expensetax.lt,
	payment.idtreasurer,
	isnull(treasurer.header,treasurer.description)
FROM expensetax
JOIN tax				ON tax.taxcode = expensetax.taxcode
JOIN expense			ON expense.idexp = expensetax.idexp
JOIN expenselast		ON expense.idexp = expenselast.idexp
JOIN config				ON expense.ymov = config.ayear
JOIN expensephase		ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN payment	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry		ON registry.idreg = expense.idreg
LEFT OUTER JOIN service			ON service.idser = expenselast.idser
LEFT OUTER JOIN registryaddress	ON registryaddress.idreg = expense.idreg
LEFT OUTER JOIN geo_city		ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country		ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation		ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc	ON pgc.idcity = expensetax.idcity
LEFT OUTER JOIN fiscaltaxregion pftr		ON pftr.idfiscaltaxregion = expensetax.idfiscaltaxregion
LEFT OUTER JOIN treasurer					ON payment.idtreasurer=treasurer.idtreasurer
WHERE (registryaddress.idaddresskind IS NULL OR registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))



GO

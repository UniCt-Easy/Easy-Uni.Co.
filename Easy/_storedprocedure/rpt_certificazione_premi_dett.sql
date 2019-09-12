if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certificazione_premi_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certificazione_premi_dett]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [rpt_certificazione_premi_dett]
(
	@ayear smallint, 
	@idreg int, 
	@certificatekind char(1)
	
)
AS BEGIN

CREATE TABLE #expensetax
(
	idexp varchar(40),
	idreg int,
	registry varchar(100),
	taxdescription varchar(50),
	expensedescription varchar(150),	
	commondetail char(1),
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	grossamount decimal (19,2),
	taxablegross decimal (19,2),
	service varchar(50),
	npay int,
	countidser int,
	taxkind int
)

INSERT INTO #expensetax
(
	idexp,
	idreg,
	registry,
	taxdescription,
	expensedescription,
	taxablenet,
	employtax, 
	taxablegross,
	grossamount,
	service,
	npay,
	taxkind
)
SELECT
	T.idexp,
	T.idreg,
	registry.title,
	T.taxdescription,
	T.expensedescription,
	SUM(T.taxablenet),
	SUM(T.employtax),
	T.taxablegross,
	expensetotal.curramount,
	service.description,
	payment.npay,
	T.taxkind
FROM
	(SELECT
		SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
		SUM(ISNULL(E.employtax,0)) AS employtax,
		isnull(E.taxablegross,0) as taxablegross,
		E.idexp,
		expense.idreg,
		case 
			when E.taxkind in (1,2,3) then E.description
			Else 'Altre Ritenute'
		end as taxdescription,
		expense.description as expensedescription,
		expense.idman,
		expenselast.idser,
		expenselast.kpay,
		case 
			when E.taxkind in (1,2,3) then E.taxkind
			Else 99
		end as taxkind
	FROM expensetaxofficialview AS E
	JOIN expense 
		ON expense.idexp = E.idexp
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN service
		ON service.idser = expenselast.idser
	WHERE expense.ymov = @ayear  
		AND expense.idreg=@idreg 
		AND service.certificatekind = @certificatekind
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,
		E.description,expense.description,
		expense.idman, expenselast.idser,
		expense.ymov,expenselast.kpay,e.taxablegross,E.taxkind	) AS T
JOIN registry 
	ON T.idreg = registry.idreg  
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
WHERE (YEAR(paymenttransmission.transmissiondate) = @ayear)
	AND service.certificatekind = @certificatekind
	AND expensetotal.ayear = @ayear
	AND expenseyear.ayear = @ayear
GROUP BY T.idreg, T.idexp, registry.title, registry.birthdate, registry.cf,
	T.taxdescription, expensetotal.curramount, service.description,
	service.idser,
	payment.npay,
	T.taxablegross,T.expensedescription,T.taxkind		
	
SELECT countidser,
	 #expensetax.idreg,
	 #expensetax.registry,
	 #expensetax.taxdescription,
	 sum(isnull(#expensetax.taxablenet,0)) AS taxablenet,
	 sum(isnull(#expensetax.taxablegross,0)) AS taxablegross ,
	 sum(isnull(#expensetax.employtax,0)) as employtax,
	 taxkind
FROM     #expensetax
WHERE    employtax <>0
group by #expensetax.idreg,#expensetax.registry,
	 #expensetax.taxdescription,countidser,taxkind
ORDER BY #expensetax.registry,taxkind
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
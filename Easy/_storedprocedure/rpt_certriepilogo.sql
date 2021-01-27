
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certriepilogo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [rpt_certriepilogo]
(
	@ayear smallint, 
	@start datetime,
	@stop datetime,
	@idreg int, 
	@idser int,
	@showallser  char(1)
)
AS BEGIN
-- exec rpt_certriepilogo 2007,{ts '2007-01-20 00:00:00'},{ts '2007-12-31 00:00:00'},null ,null

CREATE TABLE #expensetax
(
	idexp varchar(40),
	idreg int,
	registry varchar(100),
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
	npay int,
	countidser int
)

IF @ayear = 0
BEGIN
	SET @ayear='1900'
END

INSERT INTO #expensetax
(
	idexp,
	idreg,
	registry,
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
	T.taxcode,
	T.taxdescription,
	T.expensedescription,
	SUM(T.taxablenet),
	SUM(T.employtax),
	SUM(T.admintax), 
	T.taxablegross,
	expensetotal.curramount,
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
		E.taxcode,
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
		ON expense.idexp = expenselast.idexp
	WHERE expense.ymov = @ayear  
		AND (expense.idreg=@idreg )
		AND (    expenselast.idser = @idser OR (@idser is null and expenselast.idser is not null)     )
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,E.taxcode,E.description,expense.description,
	expense.idman,expenselast.idser,expense.ymov,expenselast.kpay,e.taxablegross) AS T
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
WHERE (paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	AND ISNULL(service.certificatekind,'')<>'U'
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
	

update #expensetax set countidser = (select count(distinct i.idexp)
					from #expensetax i
					where i.idreg = #expensetax.idreg
					)	 
SELECT countidser,
	#expensetax.idreg,
	#expensetax.registry,
	#expensetax.taxcode,   
	#expensetax.taxdescription,
	sum(isnull(#expensetax.taxablenet,0)) AS taxablenet,
	sum(isnull(#expensetax.taxablegross,0)) AS taxablegross ,
	sum(isnull(#expensetax.employtax,0)) as employtax,
	sum(isnull(#expensetax.admintax,0)) as admintax
FROM #expensetax
group by #expensetax.idreg,#expensetax.registry,
	#expensetax.taxcode,#expensetax.taxdescription,countidser
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

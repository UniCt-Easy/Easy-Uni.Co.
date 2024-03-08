
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_taxpay_count]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_taxpay_count]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_taxpay_count]
(	
	@ayear int,
	@taxcode int,
	@stop datetime,
	@res int output
)
AS BEGIN
-- SETUSER 'amministrazione'
--DECLARE @outvar int
--EXECUTE       [compute_taxpay_count]  2023, 1, '2023-07-01',  @outvar  out
--SELECT @outvar
SET @res = 0
DECLARE @ayear_start int
set @ayear_start =year(@stop)			--anno inizio = anno data stop

DECLARE @start datetime
SET @start = CONVERT(datetime, '01-01-' + CONVERT(varchar(4), @ayear_start), 105)	--data inizio = 1/1/anno inizio
 


DECLARE @stop_new datetime 
SET @stop_new = DATEADD(day,-1, @stop)  
 
CREATE TABLE #automov
(
	datetaxpay datetime,
	title varchar(200),
	idexp int,
	idfin int, 
	idupb varchar(36),
	idman int, 
	employtax decimal(19,2),
	admintax decimal(19,2),
	idreg int,
	idser int,
	idcity int,
	idfiscaltaxregion varchar(50),
	sourcekind char(1),
	fiscaltaxcode varchar(50),
	ayear int,
	refmonth int
)

INSERT INTO  #automov

(	datetaxpay,
	title,
	idexp ,
	idfin , 
	idupb ,
	idman , 
	employtax ,
	admintax,
	idreg ,
	idser ,
	idcity ,
	idfiscaltaxregion,
	sourcekind, 
	fiscaltaxcode,
	ayear ,
	refmonth )

SELECT
	expensetaxview.datetaxpay AS datetaxpay, registry.title AS title, expensetaxview.idexp AS idexp, 
	CASE 
		WHEN @ayear = expenseyear.ayear THEN expenseyear.idfin
		WHEN @ayear = expenseyear.ayear + 1 THEN finlookup.newidfin
		ELSE expenseyear.idfin
	END, expenseyear.idupb, expense.idman,
	ISNULL(SUM(expensetaxview.employtax), 0) AS employtax,
	ISNULL(SUM(expensetaxview.admintax), 0) AS admintax,
	expense.idreg, expenselast.idser,
	expensetaxview.idcity, expensetaxview.idfiscaltaxregion, 'R' AS sourcekind,
	tax.fiscaltaxcode, expensetaxview.ayear,
	--CASE
	--	WHEN expensetaxview.ayear < @ayear THEN 12 ELSE
	MONTH(paymenttransmission.transmissiondate)
	--END
	AS refmonth
FROM expensetaxview
JOIN expense				ON expense.idexp = expensetaxview.idexp
JOIN expenseyear			ON expenseyear.idexp = expense.idexp
LEFT OUTER JOIN finlookup ON expenseyear.idfin = finlookup.oldidfin
JOIN expenselast			ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment		ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry				ON expense.idreg = registry.idreg
LEFT OUTER JOIN tax						ON tax.taxcode = expensetaxview.taxcode
WHERE expenseyear.ayear = @ayear_start 
	AND ISNULL(tax.maintaxcode,tax.taxcode) = @taxcode
	AND expensetaxview.ytaxpay IS NULL
	AND expensetaxview.datetaxpay BETWEEN @start AND @stop_new
	AND
	(
		(
			(expensetaxview.idinc IS NULL)
			AND (ISNULL(expensetaxview.admintax,0) + 
			ISNULL(expensetaxview.employtax,0)) < 0
		)
		OR (ISNULL(expensetaxview.admintax,0) + 
		ISNULL(expensetaxview.employtax,0)) > 0
	)
		 
GROUP BY
	expensetaxview.competencydate, registry.title, expensetaxview.ayear,expenseyear.ayear,
	expensetaxview.idexp,expenseyear.idfin,finlookup.newidfin,expenseyear.idupb, expense.idman, expensetaxview.datetaxpay,
	expense.idreg, expenselast.idser, expensetaxview.idcity, expensetaxview.idfiscaltaxregion, tax.fiscaltaxcode,
	paymenttransmission.transmissiondate
UNION ALL
SELECT
	expensetaxcorrige.adate AS datetaxpay,
	registry.title AS title,
	expensetaxcorrige.idexp AS idexp, 
	CASE 
		WHEN @ayear = expenseyear.ayear THEN expenseyear.idfin
		WHEN @ayear = expenseyear.ayear + 1 THEN finlookup.newidfin
		ELSE expenseyear.idfin
	END, expenseyear.idupb, expense.idman,
	ISNULL(SUM(expensetaxcorrige.employamount), 0) AS employtax,
	ISNULL(SUM(expensetaxcorrige.adminamount), 0) AS admintax,
	expense.idreg, expenselast.idser,
	expensetaxcorrige.idcity, expensetaxcorrige.idfiscaltaxregion, 'C' AS sourcekind,
	tax.fiscaltaxcode, expensetaxcorrige.ayear,
	--CASE
	--	WHEN expensetaxcorrige.ayear < @ayear THEN 12 ELSE
	MONTH(expensetaxcorrige.adate)
	--END 
	AS refmonth
FROM expensetaxcorrige
JOIN expense					ON expense.idexp = expensetaxcorrige.idexp
JOIN expenseyear				ON expenseyear.idexp = expense.idexp
LEFT OUTER JOIN finlookup ON expenseyear.idfin = finlookup.oldidfin
JOIN expenselast				ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment			ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry				ON expense.idreg = registry.idreg
LEFT OUTER JOIN tax						ON tax.taxcode = expensetaxcorrige.taxcode
WHERE --expenseyear.ayear = @ayear_start AND[16412]
	ISNULL(tax.maintaxcode,tax.taxcode) = @taxcode
	AND expensetaxcorrige.ytaxpay IS NULL
	AND expensetaxcorrige.adate IS NOT NULL
	--AND expensetaxcorrige.ayear = @ayear
	AND expensetaxcorrige.adate BETWEEN @start AND @stop_new
	AND (
		(
			(expensetaxcorrige.linkedidinc IS NULL)
			AND (ISNULL(expensetaxcorrige.adminamount,0) + 
			ISNULL(expensetaxcorrige.employamount,0)) < 0
		)
		OR
		(
			ISNULL(expensetaxcorrige.adminamount,0) + 
			ISNULL(expensetaxcorrige.employamount,0) > 0
		)
	)

GROUP BY
	expensetaxcorrige.adate, registry.title, expensetaxcorrige.ayear,expenseyear.ayear,
	expensetaxcorrige.idexp,expenseyear.idfin,finlookup.newidfin, expenseyear.idupb, expense.idman, 
	expense.idreg, expenselast.idser,expensetaxcorrige.idcity, expensetaxcorrige.idfiscaltaxregion, tax.fiscaltaxcode,
	paymenttransmission.transmissiondate
ORDER BY idexp

  
 	SET @res = @res + ISNULL((SELECT COUNT(*) FROM #automov),0)

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


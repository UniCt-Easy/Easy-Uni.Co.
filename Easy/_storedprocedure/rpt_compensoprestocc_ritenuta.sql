
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc_ritenuta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc_ritenuta]
GO


CREATE  PROCEDURE [rpt_compensoprestocc_ritenuta]
	@ayear		int,
	@ycon		int, 
	@ncon		int
AS
BEGIN

CREATE TABLE #allpayed
( ayear int,
  idexp int,
  taxcode int,
  description varchar(50),
  taxkind int,
  deduction decimal(19,2),
  taxablegross decimal(19,2),
  taxablenet decimal(19,2),
  taxablenumerator decimal(19,6),
  taxabledenominator decimal(19,6),
  adminrate  decimal(19,6), 
  employrate decimal(19,6), 
  admintax decimal(19,2), 
  employtax decimal(19,2)
)

DECLARE @feegross decimal(19,2)
set     @feegross = (SELECT ISNULL(feegross,0) 
			    FROM casualcontract 
			   WHERE casualcontract.ycon = @ycon
	   		     AND casualcontract.ncon = @ncon)

	INSERT INTO #allpayed
	(ayear,idexp,taxcode,description, taxkind,
	 taxablegross, taxablenet, taxablenumerator,taxabledenominator, 
	adminrate, employrate, admintax, employtax)
	(SELECT  E.ymov,ETO.idexp, ETO.taxcode,T.description, T.taxkind, 
	 EY.amount, ETO.taxablenet, ISNULL(ETO.taxablenumerator,100), ISNULL(ETO.taxabledenominator,100),
	 ETO.adminrate, ETO.employrate, ETO.admintax, ETO.employtax
	 FROM expensetaxofficial ETO
	 JOIN expenselast EL
		ON EL.idexp = ETO.idexp
	 JOIN expense E
		ON E.idexp = EL.idexp
	 JOIN  expenseyear EY
		ON EY.idexp = EL.idexp
		--AND EY.ayear = @ayear
	 JOIN expenselink ELI
		ON  ELI.idchild = EL.idexp
		AND ELI.nlevel = 
			( SELECT expensephase 
		     	  FROM config WHERE ayear = @ycon) 
	 JOIN expensecasualcontract EC 
		ON EC.idexp  = ELI.idparent 
	 JOIN casualcontract C 
		ON C.ycon = EC.ycon
		AND C.ncon = EC.ncon 
	 JOIN dbo.tax T
		ON T.taxcode = ETO.taxcode
	 JOIN dbo.service S
		ON S.idser = EL.idser
	 WHERE 
	 S.module   = 'OCCASIONALE'
	 AND ETO.stop IS NULL 
	 AND C.ycon =@ycon AND C.ncon = @ncon
	)


IF EXISTS (SELECT * 
	   FROM pettycashoperationcasualcontract 
	   WHERE pettycashoperationcasualcontract.ycon = @ycon
	   AND pettycashoperationcasualcontract.ncon = @ncon )
BEGIN
	UPDATE #allpayed set taxablegross = @feegross

END

-- 

UPDATE #allpayed SET deduction = 
(SELECT 
		ISNULL(SUM (T.alldeduction),0)
		FROM
		(	SELECT (MAX(taxablegross)  - 
			SUM (ISNULL(taxablenet,0) /(taxablenumerator/taxabledenominator))) 
			AS alldeduction
			FROM #allpayed P WHERE #allpayed.ayear= P.ayear and #allpayed.taxcode = P.taxcode
			GROUP BY idexp,taxcode
		) as T)

--select * from #allpayed

IF (@ayear IS NULL)
BEGIN
	SELECT 
		ETO.ayear,
		taxcode,
		ETO.description,
		'taxkind' = CASE ETO.taxkind
			WHEN  1 THEN 'Fiscale'
			WHEN  2 THEN 'Assistenziale'
			WHEN  3 THEN 'Previdenziale'
			WHEN  4 THEN 'Assicurativa'
			WHEN  5 THEN 'Arretrati'
			WHEN  6 THEN 'Altro'
		ELSE ''
		END,
		SUM(taxablegross) as 'taxablegross',
		SUM(ISNULL(taxablenet,0) /(ISNULL(taxablenumerator,1)/ISNULL(taxabledenominator,1)))  as 'taxablenet',
		MAX(deduction) as 'deduzioni',
		adminrate*100 	  as 'aliquotaamministrazione' ,
		employrate*100    as 'aliquotadipendente',
		SUM(admintax) 	  as 'admintax',
		SUM(employtax) 	  as 'employtax'
	FROM  #allpayed ETO
	GROUP BY ETO.ayear, ETO.taxcode, ETO.description,ETO.taxkind, adminrate, employrate 
	ORDER BY ETO.ayear, ETO.taxcode
END
ELSE
BEGIN
	SELECT 
		ETO.ayear,
		taxcode,
		ETO.description,
		'taxkind' = CASE ETO.taxkind
			WHEN  1 THEN 'Fiscale'
			WHEN  2 THEN 'Assistenziale'
			WHEN  3 THEN 'Previdenziale'
			WHEN  4 THEN 'Assicurativa'
			WHEN  5 THEN 'Arretrati'
			WHEN  6 THEN 'Altro'
		ELSE ''
		END,
		SUM(taxablegross) as 'taxablegross',
		SUM(ISNULL(taxablenet,0) /(ISNULL(taxablenumerator,1)/ISNULL(taxabledenominator,1)))  as 'taxablenet',
		MAX(deduction) as 'deduzioni',
		adminrate*100 	  as 'aliquotaamministrazione' ,
		employrate*100    as 'aliquotadipendente',
		SUM(admintax) 	  as 'admintax',
		SUM(employtax) 	  as 'employtax'
	FROM  #allpayed ETO
	WHERE ETO.ayear = @ayear 
	GROUP BY ETO.ayear, ETO.taxcode, ETO.description,ETO.taxkind, adminrate, employrate 
	ORDER BY ETO.ayear, ETO.taxcode
END
END

go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec [rpt_compensoprestocc_ritenuta] 2009, 179


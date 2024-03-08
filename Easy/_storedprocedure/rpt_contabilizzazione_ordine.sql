
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contabilizzazione_ordine]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contabilizzazione_ordine]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
CREATE    PROCEDURE [rpt_contabilizzazione_ordine]
	@ayear int,
	@yman int,
	@nman int,
	@mandatekind varchar(20)
AS
BEGIN

--setuser 'amministrazione'
--exec rpt_contabilizzazione_ordine 2016, 2016, 2, 'AMM_BO_IST_COF'
--modifiche task 10093
declare @flag int;
set @flag = (select flag from uniconfig);
--fine modifiche task 10093

CREATE TABLE #mandate_amount
(
	expensephase varchar(50),
	ymov int,
	nmov int,
	adate datetime,
	description varchar(200),
	idfin int,
	idupb varchar(36),
	amount decimal(19,2),
	idexp int,
	expenseyear int		
)
INSERT INTO #mandate_amount
(
	expensephase,
	ymov,
	nmov,
	adate,
	description,
	idfin,
	idupb,
	amount,
	idexp,
	expenseyear
)
SELECT  DISTINCT
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	expenseyear.idfin,
	expenseyear.idupb, 	
	expenseyear.amount +
-- Somma delle variazioni sull'importo (prima non considerata)
	ISNULL(
		 (SELECT SUM(v.amount) 
		FROM expensevar v 
		JOIN expensemandate o
			ON o.idexp = v.idexp 
		WHERE o.yman = @yman AND o.nman = @nman 
			AND o.idmankind = @mandatekind
			and expenseyear.idexp = v.idexp),0
		 ),
	expenseyear.idexp,
	expenseyear.ayear

FROM expensemandate
JOIN expense
	ON expense.idexp = expensemandate.idexp
JOIN expenseyear
	ON expenseyear.idexp = expensemandate.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
WHERE expensemandate.yman = @yman
	AND expensemandate.nman = @nman
	AND expensemandate.idmankind = @mandatekind
-- La seguente DELETE elimina i movimenti di spesa uguali presenti in esercizi differenti
DELETE FROM #mandate_amount
WHERE expenseyear > (SELECT min(expenseyear) 
				from #mandate_amount i2 
				where #mandate_amount.idexp = i2.idexp)



declare @budget int;	--modifiche task 10093
set @budget = CASE 
				WHEN @flag&8 <> 0 AND not exists(select idepexp from mandatedetail md where md.idmankind = @mandatekind and md.nman = @nman and md.yman = @yman and idepexp is not null) THEN 1
				ELSE 0
			  END

SELECT 	
	@yman as yman,
	@nman as nman ,
	expensephase ,

	--modifiche task 10093

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	ymov
	END as ymov,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	nmov
	END as nmov,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	adate
	END as adate,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	description
	END as description,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	fin.codefin
	END as codefin,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	fin.title
	END as fin,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	codeupb
	END as codeupb,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	#mandate_amount.idupb
	END as idupb,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	upb.title
	END as upb,

	CASE 
		WHEN @budget=1 then NULL --dettaglio privo di impegno di budget
		ELSE 	amount
	END as amount
	--fine modifiche task 10093

FROM #mandate_amount
LEFT OUTER JOIN fin
	ON fin.idfin = #mandate_amount.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = #mandate_amount.idupb
ORDER BY ymov, nmov
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contabilizzazione_contrattoattivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contabilizzazione_contrattoattivo]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [rpt_contabilizzazione_contrattoattivo]
	@yestim int,
	@nestim int,
	@estimatekind varchar(20)
AS

-- exec rpt_contabilizzazione_contrattoattivo  2016, 10, 'AMM_CA fattura'
BEGIN
CREATE TABLE #estimate_amount
(
	incomephase varchar(50),
	ymov int,
	nmov int,
	adate datetime,
	description varchar(200),
	idfin int,
	idupb varchar(36),
	amount decimal(19,2),
	idinc int,
	incomeyear int	
)
INSERT INTO #estimate_amount
(
	incomephase,
	ymov,
	nmov,
	adate,
	description,
	idfin,
	idupb,
	amount,
	idinc,
	incomeyear
)
SELECT  DISTINCT
	incomephase.description,
	income.ymov,
	income.nmov,
	income.adate,
	income.description,
	incomeyear.idfin,
	incomeyear.idupb, 			
	incomeyear.amount +
-- Somma delle variazioni sull'importo (prima non considerata)
	ISNULL(
		 (SELECT SUM(v.amount) 
		FROM incomevar v 
		JOIN incomeestimate o
			ON o.idinc = v.idinc 
		WHERE o.yestim = @yestim AND o.nestim = @nestim 
			AND o.idestimkind = @estimatekind
			and incomeyear.idinc = v.idinc),0
		 ),
	incomeyear.idinc,
	incomeyear.ayear
FROM incomeestimate
JOIN income
	ON income.idinc = incomeestimate.idinc
JOIN incomeyear
	ON incomeyear.idinc = incomeestimate.idinc
JOIN incomephase
	ON incomephase.nphase = income.nphase
LEFT OUTER JOIN incomesorted 
	ON income.idinc = incomesorted.idinc

WHERE incomeestimate.yestim = @yestim
	AND incomeestimate.nestim = @nestim
	AND incomeestimate.idestimkind = @estimatekind
-- La seguente DELETE elimina i movimenti di entrata uguali presenti in esercizi differenti
DELETE FROM #estimate_amount
WHERE incomeyear > (SELECT min(incomeyear) 
				from #estimate_amount i2 
				where #estimate_amount.idinc = i2.idinc)

SELECT 	@yestim as yestim,
	@nestim as nestim ,
	incomephase ,
	ymov,
	nmov,
	adate,
	description,
	fin.codefin,
	fin.title as fin,
	codeupb,
	#estimate_amount.idupb,
	upb.title as upb,
	amount 
FROM #estimate_amount
LEFT OUTER JOIN fin
	ON fin.idfin = #estimate_amount.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = #estimate_amount.idupb
ORDER BY ymov, nmov
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

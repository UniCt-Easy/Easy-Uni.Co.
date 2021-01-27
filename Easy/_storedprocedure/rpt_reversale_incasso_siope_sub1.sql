
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


/* Versione 1.0.0 del 11/09/2007 ultima modifica: PIERO */
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_reversale_incasso_siope_sub1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_reversale_incasso_siope_sub1]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amm'
--[rpt_reversale_incasso_siope_sub1] 2016, 11
CREATE               PROCEDURE [rpt_reversale_incasso_siope_sub1]
	@y int,
	@n int
AS
BEGIN
DECLARE @sorkind int
DECLARE @npos int
DECLARE @codesorkind_siopeentrate varchar(20)
SELECT  @codesorkind_siopeentrate  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07E_SIOPE'
	ELSE   'SIOPE_E_18'
END
print @codesorkind_siopeentrate
select @sorkind = idsorkind from sortingkind where codesorkind = @codesorkind_siopeentrate

SELECT  @npos  =  
CASE  
	WHEN  (@y<= 2006) THEN  2
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  1
	ELSE   1
END

DECLARE @sortcode varchar(20)
SELECT @sortcode = sorting.sortcode 
FROM incomesorted
JOIN income 
	ON incomesorted.idinc = income.idinc
JOIN incomelast 
	ON incomelast.idinc = income.idinc
join proceeds on proceeds.kpro = incomelast.kpro
JOIN sorting
	ON sorting.idsor = incomesorted.idsor
WHERE 	incomesorted.ayear = @y
		AND sorting.idsorkind = @sorkind
		AND income.ymov = @y
		AND proceeds.npro = @n
IF (@sortcode is null) 
 SELECT 	sorting.sortcode as sortcode,
	sorting.description as sort,
	sum(incomeyear_starting.amount) as amount
 FROM finsorting
 JOIN sorting 
	ON finsorting.idsor=sorting.idsor
 JOIN incomeyear 
 	ON finsorting.idfin=incomeyear.idfin	
 JOIN income 
	ON incomeyear.idinc=income.idinc 
 JOIN incomelast 
	ON incomelast.idinc = income.idinc
 join proceeds on proceeds.kpro = incomelast.kpro
 LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
 LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
 WHERE proceeds.npro=@n and income.ymov=@y and sorting.idsorkind=@sorkind
 GROUP BY sortcode,sorting.description
 ORDER BY sortcode

ELSE

 SELECT  	
		SUBSTRING(sorting.sortcode,@npos,LEN(sorting.sortcode)) AS sortcode,
		sorting.description AS sort,
		SUM(incomesorted.amount) as amount 
 FROM incomesorted
 JOIN income 
	ON incomesorted.idinc = income.idinc
 JOIN incomelast 
	ON incomelast.idinc = income.idinc
 join proceeds on proceeds.kpro = incomelast.kpro
 JOIN sorting
	ON sorting.idsor = incomesorted.idsor
 WHERE 	incomesorted.ayear = @y
		AND sorting.idsorkind = @sorkind-- Ipotesi fondamentale
		AND income.ymov = @y
		AND proceeds.npro = @n
 GROUP BY sortcode,sorting.description
 ORDER BY sortcode



END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

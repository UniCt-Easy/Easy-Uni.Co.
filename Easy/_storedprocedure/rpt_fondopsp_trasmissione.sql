
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_fondopsp_trasmissione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_fondopsp_trasmissione
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE rpt_fondopsp_trasmissione
	@ayear	smallint,
	@idpettycash	int,
	@codefin		varchar(50),
	@nlist int,
	@start	smalldatetime,
	@stop	smalldatetime,
	@adate smalldatetime

AS BEGIN 
declare @bursarship varchar(100)
select @bursarship = bursarship from pettycash where idpettycash = @idpettycash


--rpt_fondopsp_trasmissione  2015, 1,  '', {ts '2015-01-01 00:00:00'}, {ts '2015-12-31 00:00:00'}, {ts '2015-12-31 00:00:00'}
DECLARE @idfin int
IF (@codefin IS NULL OR @codefin = '' OR @codefin = '%')
	BEGIN
		SET @idfin = null	
	END
Else
	BEGIN
	   	SET @idfin = (select idfin 
				from fin 
				where codefin = @codefin 
				and ayear=@ayear 
				and (fin.flag&1)=1) --Spesa
	END

CREATE TABLE #pettycash
(
	noperation int,
	adate datetime,
	idfin int,
	codefin varchar(50),	
	finance varchar(150),
	amount decimal(19,2),
	idexp int
)

INSERT INTO #pettycash
(
	noperation,
	adate,
	codefin,idfin,finance,
	amount,
	idexp
)

SELECT
	pettycashoperation.noperation,
	pettycashoperation.adate,
	fin.codefin,fin.idfin,fin.title,
	pettycashoperation.amount,
	pettycashoperation.idexp
FROM pettycashoperation
LEFT OUTER JOIN fin
	ON pettycashoperation.idfin = fin.idfin
LEFT OUTER JOIN expense
	ON expense.idexp = pettycashoperation.idexp
LEFT OUTER JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expenseyear.ayear = @ayear
WHERE pettycashoperation.yoperation = @ayear
 AND pettycashoperation.idpettycash = @idpettycash
 AND (pettycashoperation.flag& 8)<>0  -- SPESA
 AND
 (
 ( @nlist IS NULL
  AND pettycashoperation.nrestore is null
       AND pettycashoperation.adate 
  BETWEEN ISNULL(@start, {d '1900-01-01'}) AND ISNULL(@stop, {d '2079-06-06'})
 )
 OR
 ( pettycashoperation.nlist = @nlist)
 )

-- Aggiornamento della voce di bilancio nel caso di operazione associata ad un movimento di spesa
UPDATE #pettycash
SET idfin = fin.idfin,
	codefin = fin.codefin,
	finance = fin.title
FROM fin
JOIN expenseyear
	ON fin.idfin = expenseyear.idfin
WHERE expenseyear.idexp = #pettycash.idexp
	AND expenseyear.ayear = @ayear

DECLARE @datemin datetime
DECLARE @datemax datetime

SET @datemin = (SELECT MIN(adate) FROM #pettycash)
SET @datemax = (SELECT MAX(adate) FROM #pettycash)


SELECT
	@nlist as numnote,
	@datemin as datemin,
	@datemax as datemax,
	@idpettycash as idpettycash,
	(SELECT description FROM pettycash
		WHERE idpettycash = @idpettycash) 
	AS description,
	codefin,
	finance,
	ISNULL(SUM(amount),0) as total,
	@adate as adate,
	@bursarship as bursarship
FROM #pettycash 
WHERE (@idfin IS NULL OR  (#pettycash.idfin = @idfin and @idfin is not null))
GROUP BY codefin, finance
ORDER BY codefin


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



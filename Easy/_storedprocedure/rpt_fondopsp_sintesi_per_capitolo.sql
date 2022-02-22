
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_fondopsp_sintesi_per_capitolo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_fondopsp_sintesi_per_capitolo
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE rpt_fondopsp_sintesi_per_capitolo
	@ayear	smallint,
	@idpettycash	int,
	@codefin		varchar(50),
	@nlist int,
	@start	smalldatetime,
	@stop	smalldatetime,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1)

-- exec rpt_fondopsp_sintesi_per_capitolo 2014,5, '%',null,null,null,'N','%','S'
AS BEGIN 

declare @bursarship varchar(100)
select @bursarship = bursarship from pettycash where idpettycash = @idpettycash

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

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

CREATE TABLE #pettycash
(
	noperation int,
	adate datetime,
	operationdescription varchar(200),
	idfin int,
	codefin varchar(50),	
	finance varchar(150),
	amount decimal(19,2),
	doc varchar(50),
	docdate datetime,
	idman int,
	manager varchar(150),
	idexp int,
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150)
)


INSERT INTO #pettycash
(
	noperation,
	adate,
	operationdescription,
	codefin,idfin,finance,
	codeupb,idupb,upb,
	amount,
	doc,
	docdate,
	idexp,
	idman,
	manager
)

SELECT
	pettycashoperation.noperation,
	pettycashoperation.adate,
	pettycashoperation.description,
	fin.codefin,fin.idfin,fin.title,
	upb.codeupb,upb.idupb,upb.title,
	pettycashoperation.amount,
	pettycashoperation.doc,
	pettycashoperation.docdate,
	pettycashoperation.idexp,
	pettycashoperation.idman,
	manager.title
FROM pettycashoperation
LEFT OUTER JOIN fin
	ON pettycashoperation.idfin = fin.idfin
LEFT OUTER JOIN upb
	ON pettycashoperation.idupb = upb.idupb
LEFT OUTER JOIN expense
	ON expense.idexp = pettycashoperation.idexp
LEFT OUTER JOIN manager
	ON manager.idman = pettycashoperation.idman
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
SET  idfin = fin.idfin,
	codefin = fin.codefin,
	finance = fin.title
FROM fin
JOIN expenseyear
	ON fin.idfin = expenseyear.idfin
WHERE expenseyear.idexp = #pettycash.idexp
	AND expenseyear.ayear = @ayear


UPDATE #pettycash
SET  idupb = upb.idupb,
	codeupb = upb.codeupb,
	upb = upb.title
FROM upb
JOIN expenseyear
	ON upb.idupb = expenseyear.idupb
WHERE expenseyear.idexp = #pettycash.idexp
	AND expenseyear.ayear = @ayear

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #pettycash SET  
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #pettycash	
				WHERE idupb = @idupboriginal),
			upb =(SELECT TOP 1 upb
				FROM #pettycash	
				WHERE idupb = @idupboriginal)
		WHERE idupb IS NOT NULL
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
			UPDATE #pettycash SET  
			idupb = null,
			codeupb = null,
			upb = null

	SELECT
	@nlist as numnote,
	noperation,
	@idpettycash as idpettycash,
	(SELECT description FROM pettycash
		WHERE idpettycash = @idpettycash) 
	AS description,
	adate,
	operationdescription,
	codefin,
	finance,
	codeupb,upb,
	amount,
	doc,
	docdate,
	manager,
	idexp,
	@bursarship as bursarship
FROM #pettycash 
WHERE (@idfin IS NULL OR  (#pettycash.idfin = @idfin and @idfin is not null))
and (idupb like @idupb OR idupb is null)
ORDER BY codeupb, codefin,idpettycash, adate, noperation


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--exec rpt_fondopsp_sintesi_per_capitolo 2015, 5, '%', NULL, {ts '2015-01-01 00:00:00'}, {ts '2015-12-31 00:00:00'}, 'N', '%', 'N'

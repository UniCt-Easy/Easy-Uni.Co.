
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_pettycashrestore]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_pettycashrestore]
GO


CREATE        PROCEDURE [compute_pettycashrestore]
(
	@ayear smallint,
	@idpettycash int,
	@nlist int
)
AS BEGIN
CREATE TABLE #automov_ungrouped
(
	parentidexp int, 
	idreg int,
	idfin int,
	idupb varchar(36),
	idman int, 
	nbill int,
	amount decimal(19,2)
)
DECLARE @descrpettycash varchar(50)
SELECT @descrpettycash = description FROM pettycash WHERE idpettycash = @idpettycash
DECLARE @idreg int	
SELECT @idreg = registrymanager
FROM pettycashsetupview
WHERE ayear = @ayear
AND idpettycash = @idpettycash
      
INSERT INTO #automov_ungrouped
SELECT
	NULL,
	@idreg,
	idfin,
	idupb,
	idman,
	nbill,
	amount
FROM pettycashoperation
WHERE yoperation = @ayear
	AND yrestore IS NULL AND nrestore IS NULL
	AND idpettycash = @idpettycash
	AND ((flag & 8) <> 0)
	AND (idfin IS NOT NULL AND idexp IS NULL) 
	AND (ISNULL(@nlist,0) = 0 OR pettycashoperation.nlist = @nlist)

INSERT INTO #automov_ungrouped
SELECT
	E.idexp,
	ISNULL(E.idreg,@idreg),
	ISNULL(EY.idfin, PCO.idfin), 
	ISNULL(EY.idupb, PCO.idupb),
	ISNULL(E.idman, PCO.idman),
	PCO.nbill,
	PCO.amount
FROM pettycashoperation PCO
JOIN expense E
	ON PCO.idexp = E.idexp
JOIN expenseyear EY
	ON EY.idexp = PCO.idexp
WHERE yoperation = @ayear
	AND yrestore IS NULL AND nrestore IS NULL
	AND idpettycash = @idpettycash
	AND (ISNULL(@nlist,0) = 0 OR PCO.nlist = @nlist)
	AND (flag & 8)<>0
	AND EY.ayear = @ayear
	
CREATE TABLE #automov
(
	parentidexp int, 
	idreg int,
	idfin int, 
	idupb varchar(36),
	idman int, 
	nbill int,
	amount decimal(19,2)
)

INSERT INTO #automov 
SELECT parentidexp, idreg, idfin, idupb, idman, nbill, SUM(amount)
FROM #automov_ungrouped
GROUP BY parentidexp, idreg, idfin, idupb, idman, nbill
SELECT 
	'Spesa' AS movkind,
	#automov.parentidexp,
	#automov.idreg,
	R.title AS registry,
	#automov.idfin,
	F.codefin,
	#automov.idupb,
	U.codeupb, 
	#automov.idman,
	M.title AS manager ,
	CASE 
		WHEN ISNULL(@nlist,0) = 0 THEN 'Reintegro fondo economale ' + @descrpettycash
		ELSE 'Reintegro fondo economale ' + @descrpettycash + ' Nota spese n° ' + convert(varchar(10),@nlist)
	END as description,
	#automov.nbill,
    #automov.amount
FROM #automov 
LEFT OUTER JOIN registry R
	ON R.idreg = #automov.idreg
LEFT OUTER JOIN fin F
	ON F.idfin = #automov.idfin
LEFT OUTER JOIN upb U
	ON U.idupb = #automov.idupb
LEFT OUTER JOIN manager M
	ON M.idman = #automov.idman
ORDER BY  R.title,F.codefin, U.codeupb
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


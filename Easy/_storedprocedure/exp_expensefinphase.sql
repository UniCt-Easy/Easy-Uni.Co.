
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expensefinphase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expensefinphase]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE            PROCEDURE [exp_expensefinphase]
@ayear int,
@start datetime,
@stop  datetime,
@idupb varchar(36),
@showchildupb char(1),
@codefin varchar(50),
@idman int,
@nphase tinyint 

AS BEGIN 
--	exec exp_expensefinphase '2013', {ts '2013-01-01 00:00:00.000'}, {ts '2013-11-06 00:00:00.000'}, '%', 'N', null, null,1
SET @codefin = ISNULL(@codefin,'')+'%'
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END


/*
Aggiunto il parametro alla sp in seguito al task 5002.
DECLARE @finphase tinyint
SELECT @finphase = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphase IS NULL
BEGIN
	SELECT @finphase = expensefinphase FROM uniconfig
END
*/
SELECT 
    MAN.title AS Responsabile,
	F.codefin AS 'Codice Bilancio',
	F.title AS 'Denom. Bilancio' ,
	PHASE.description AS Fase,
	EX.ymov  AS 'Eserc. Movimento',
	EX.nmov AS 'Num. Movimento',
	EX.description AS Descrizione,
	EXY.amount AS 'Importo Originale',
	EXT.curramount AS 'Importo Corrente',
	EX.doc AS 'Documento collegato',
	EX.docdate AS 'Data Documento collegato',
	EX.adate AS 'Data Contabile Movimento',
	EX.expiration AS 'Data Scadenza',
	REG.title AS Percipiente,	
	U.codeupb AS 'Codice UPB',
	U.title AS UPB,
   	CASE
		when (( EXT.flag & 1)=0) then 'C/Residui'
		when (( EXT.flag & 1)=1) then 'C/Competenza' 
	End AS Competenza
FROM expense EX (NOLOCK)
JOIN expensephase PHASE (NOLOCK)
	ON PHASE.nphase = EX.nphase
JOIN expenseyear EXY(NOLOCK)
	ON EXY.idexp = EX.idexp
JOIN expensetotal EXT(NOLOCK)
	ON EXT.idexp = EX.idexp
	AND EXT.ayear = EXY.ayear
LEFT OUTER JOIN fin F (NOLOCK)
	ON F.idfin = EXY.idfin
LEFT OUTER JOIN upb U(NOLOCK)
	ON U.idupb = EXY.idupb
LEFT OUTER JOIN registry REG(NOLOCK)
	ON REG.idreg = EX.idreg
LEFT OUTER JOIN manager MAN(NOLOCK) 
	ON MAN.idman = EX.idman
WHERE EX.adate BETWEEN @start AND @stop 
	AND EX.nphase = @nphase
	AND EXY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (EX.idman = @idman or @idman is null)
	AND (EXY.idupb LIKE @idupb)
ORDER BY EX.idman, F.codefin, EX.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


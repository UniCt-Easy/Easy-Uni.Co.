
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_sumcasual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_sumcasual]
GO

CREATE PROCEDURE [compute_sumcasual]
(
	@ayear int, 
	@idreg int,
	@res decimal(19,2) out
)
AS BEGIN


CREATE TABLE #app (value decimal(19,2))
DECLARE @currdep varchar(50)
SET @currdep = USER

DECLARE @iddbdepartment varchar(50)
DECLARE @ayearstr varchar(4)
SET @ayearstr = CONVERT(varchar(4), @ayear)

DECLARE @idregstr varchar(10)
SET @idregstr = CONVERT(varchar(10), @idreg)

DECLARE @cursore cursor
SET @cursore = CURSOR FOR
SELECT  iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)

OPEN @cursore
FETCH NEXT FROM @cursore INTO @iddbdepartment
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @sql nvarchar(4000)
SET @sql = N'SELECT ISNULL(
		(SELECT SUM(imponibile) FROM  
			(SELECT(MAX((EY.amount/C.feegross) * ETO.taxablegross)) AS imponibile
		FROM [' + @iddbdepartment + '].expensetaxofficial ETO
		JOIN [' + @iddbdepartment + '].expenselast EL
			ON EL.idexp = ETO.idexp
		JOIN [' + @iddbdepartment + '].expense E
			ON E.idexp = EL.idexp
		JOIN [' + @iddbdepartment + '].expenseyear EY
			ON EY.idexp = EL.idexp
			AND EY.ayear = ' + @ayearstr + 
		' JOIN [' + @iddbdepartment + '].expenselink ELI
			ON  ELI.idchild = EL.idexp
			AND ELI.nlevel = ( SELECT expensephase 
					     FROM config WHERE ayear = ' + @ayearstr + ') ' +
		' JOIN [' + @iddbdepartment + '].expensecasualcontract EC 
			ON EC.idexp  = ELI.idparent ' + 
		' JOIN [' + @iddbdepartment + '].casualcontract C 
			ON C.ycon = EC.ycon
			AND C.ncon = EC.ncon ' +  
		'JOIN dbo.tax T
			ON T.taxcode = ETO.taxcode
		JOIN dbo.service S
			ON S.idser = EL.idser
		JOIN dbo.motive770service MS
			ON MS.idser = S.idser
		WHERE E.ymov = ' + @ayearstr +
			' AND T.taxkind = 1
			AND S.module = ''OCCASIONALE''
			AND MS.idmot IN (''C'', ''V'', ''M'')
			AND MS.ayear = ' + @ayearstr +
			' AND E.idreg = ' + @idregstr +
			' AND ETO.stop IS NULL ' + 
			' GROUP BY ETO.idexp) AS T) ' +
	' ,0) ' 


	print @sql
	INSERT INTO #app (value)
	EXEC SP_EXECUTESQL @sql

	SET @res = ISNULL(@res,0) + ISNULL((SELECT value FROM #app),0)

	DELETE FROM #app
	FETCH NEXT FROM @cursore INTO @iddbdepartment
END

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


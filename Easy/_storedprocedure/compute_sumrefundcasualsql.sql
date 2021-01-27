
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_sumrefundcasual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_sumrefundcasual]
GO

CREATE PROCEDURE [compute_sumrefundcasual]
(
	@ayear int, 
	@idreg int,
	@kind char,
	@ycontoskip int,	
	@ncontoskip int,	
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

DECLARE @ncontoskipstr varchar(10)
SET @ncontoskipstr = CONVERT(varchar(10), @ncontoskip)

DECLARE @ycontoskipstr varchar(10)
SET @ycontoskipstr = CONVERT(varchar(10), @ycontoskip)



DECLARE @cursore cursor
SET @cursore = CURSOR FOR
SELECT iddbdepartment FROM dbdepartment
WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @cursore
FETCH NEXT FROM @cursore INTO @iddbdepartment
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @sql nvarchar(4000)
	if @iddbdepartment <> @currdep	
	begin	
	SET @sql = N'SELECT ISNULL( (SELECT SUM(CR.amount) 
		FROM [' + @iddbdepartment + '].casualcontractrefund CR
                JOIN [' + @iddbdepartment + '].casualrefund  CC ON CC.idlinkedrefund = CR.idlinkedrefund 
		WHERE 
			CC.deduction ='''+@kind+''' 
		AND EXISTS (SELECT * from [' + @iddbdepartment + '].expensecasualcontract EC		
			join  [' + @iddbdepartment + '].casualcontract C on C.ycon=EC.ycon and C.ncon=EC.ncon
			join  [' + @iddbdepartment + '].expenselink EL on EC.idexp=EL.idparent
			join  [' + @iddbdepartment + '].expenselast ELA on EL.idchild=ELA.idexp
			join  [' + @iddbdepartment + '].expensetaxofficial ETO on ETO.idexp = ELA.idexp
			join  [DBO].tax T on T.taxcode = ETO.taxcode
			join  [' + @iddbdepartment + '].expense E on ELA.idexp=E.idexp
			JOIN dbo.service S ON S.idser = C.idser
			JOIN dbo.motive770service MS	ON MS.idser = S.idser
			WHERE EC.ycon=CR.ycon and EC.ncon=CR.ncon and
				E.ymov = ' + @ayearstr +
			' AND S.module = ''OCCASIONALE'' AND T.taxkind = 1 
			AND MS.idmot IN (''C'', ''V'', ''M'')
			AND MS.ayear = ' + @ayearstr +
			' AND C.idreg = ' + @idregstr +')'+
			'),0)'

	end
	else
	begin
	SET @sql = N'SELECT ISNULL( (SELECT SUM(CR.amount) 
		FROM [' + @iddbdepartment + '].casualcontractrefund CR
                JOIN [' + @iddbdepartment + '].casualrefund  CC ON CC.idlinkedrefund = CR.idlinkedrefund 
		WHERE 
			CC.deduction ='''+@kind+''' 
		AND EXISTS (SELECT * from [' + @iddbdepartment + '].expensecasualcontract EC		
			join  [' + @iddbdepartment + '].casualcontract C on C.ycon=EC.ycon and C.ncon=EC.ncon
			join  [' + @iddbdepartment + '].expenselink EL on EC.idexp=EL.idparent
			join  [' + @iddbdepartment + '].expenselast ELA on EL.idchild=ELA.idexp
			join  [' + @iddbdepartment + '].expensetaxofficial ETO on ETO.idexp = ELA.idexp
			join  [DBO].tax T on T.taxcode = ETO.taxcode
			join  [' + @iddbdepartment + '].expense E on ELA.idexp=E.idexp
			JOIN dbo.service S ON S.idser = C.idser
			JOIN dbo.motive770service MS	ON MS.idser = S.idser
			WHERE   EC.ycon=CR.ycon and EC.ncon=CR.ncon and
			 E.ymov = ' + @ayearstr +
			' AND S.module = ''OCCASIONALE'' AND T.taxkind = 1 
			AND MS.idmot IN (''C'', ''V'', ''M'')
			AND MS.ayear = ' + @ayearstr +
			' AND C.idreg = ' + @idregstr +
			' and (EC.ycon<>'+@ycontoskipstr+' OR EC.ncon<>'+@ncontoskipstr+'))'+
			'),0)'


	end
print @sql

	INSERT INTO #app (value)
	EXEC SP_EXECUTESQL @sql

	SET @res = ISNULL(@res,0) + ISNULL((SELECT value FROM #app),0)

	DELETE FROM #app
	FETCH NEXT FROM @cursore INTO @iddbdepartment
	
END
	drop table #app


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_parasubcontractcommunicated]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_parasubcontractcommunicated]
GO

CREATE  PROCEDURE compute_parasubcontractcommunicated
(
	@ayear int,
	@idcon varchar(8),
	@iddbdepartment varchar(50),
	@res char(1) output
)
AS BEGIN
-- @res resituisce S se il cedolino di conguaglio è stato trasmesso in banca; N altrimenti

DECLARE @stringaSQL nvarchar(4000)
SET @stringaSQL = N'SELECT P.npayroll FROM [' + @iddbdepartment + '].payroll P
	WHERE P.idcon = ''' + @idcon + '''
	AND P.fiscalyear = ' + CONVERT(varchar(4), @ayear) + '
	AND P.flagbalance = ''S'''

CREATE TABLE #temp (value int)

INSERT INTO #temp (value)
EXEC SP_EXECUTESQL @stringaSQL

DECLARE @npayroll_C int

SELECT @npayroll_C = value
FROM #temp

DELETE FROM #temp

DECLARE @idpayroll_R int

SET @stringaSQL = N'SELECT P.idpayroll FROM [' + @iddbdepartment + '].payroll P
	WHERE P.idcon = ''' + @idcon + '''
	AND P.fiscalyear = ' + CONVERT(varchar(4), @ayear) + '
	AND P.flagbalance <> ''S''
	AND P.npayroll = ' + CONVERT(varchar(10), @npayroll_C)

INSERT INTO #temp (value)
EXEC SP_EXECUTESQL @stringaSQL

SELECT @idpayroll_R = value
FROM #temp

IF (@idpayroll_R IS NULL)
BEGIN
	SET @res = 'N'
	DROP TABLE #temp
	RETURN
END

DELETE FROM #temp

SET @stringaSQL = N'SELECT U.idexp FROM [' + @iddbdepartment + '].payroll R
	JOIN [' + @iddbdepartment + '].expensepayroll E
		ON E.idpayroll = R.idpayroll
	JOIN [' + @iddbdepartment + '].expenselink L
		ON L.idparent = E.idexp
	JOIN [' + @iddbdepartment + '].expenselast U
		ON U.idexp = L.idchild
	JOIN [' + @iddbdepartment + '].payment P
		ON P.kpay = U.kpay
	JOIN [' + @iddbdepartment + '].paymenttransmission T
		ON T.kpaymenttransmission = P.kpaymenttransmission
	WHERE R.idpayroll = ' + CONVERT(varchar(10), @idpayroll_R)

INSERT INTO #temp (value)
EXEC SP_EXECUTESQL @stringaSQL

IF ((SELECT COUNT(*) FROM #temp) > 0)
BEGIN
	SET @res = 'S'
END
ELSE
BEGIN
	SET @res = 'N'
END

DROP TABLE #temp

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_expense]
GO


CREATE    TRIGGER [trigger_d_expense] ON [expense] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN

	CREATE TABLE #expense (idexp int, autokind tinyint, nphase tinyint)

	INSERT INTO #expense (idexp, autokind, nphase)
	SELECT idexp, autokind, nphase FROM deleted

	CREATE TABLE #taxpay (ytaxpay int, ntaxpay int)

	INSERT INTO #taxpay (ytaxpay, ntaxpay)
	SELECT DISTINCT ytaxpay, ntaxpay
	FROM taxpayexpense
	JOIN #expense T
	ON taxpayexpense.idexp = T.idexp
	WHERE T.autokind = 2 AND (T.nphase = 1
	OR ISNULL(
		(SELECT autokind FROM expense WHERE parentidexp = T.idexp),0) <> 2)

	UPDATE expensetax SET ytaxpay = NULL, ntaxpay = NULL
	FROM #taxpay
	WHERE expensetax.ytaxpay = #taxpay.ytaxpay
		AND expensetax.ntaxpay = #taxpay.ntaxpay

	UPDATE expensetaxcorrige SET ytaxpay = NULL, ntaxpay = NULL
	FROM #taxpay
	WHERE expensetaxcorrige.ytaxpay = #taxpay.ytaxpay
		AND expensetaxcorrige.ntaxpay = #taxpay.ntaxpay

	DELETE FROM taxpay
	WHERE EXISTS(SELECT * FROM #taxpay T WHERE T.ytaxpay = taxpay.ytaxpay AND T.ntaxpay = taxpay.ntaxpay)

        DELETE FROM ivapayexpense WHERE idexp IN (SELECT idexp FROM #expense)
	DELETE FROM mainivapayexpense WHERE idexp IN (SELECT idexp FROM #expense)
        DELETE FROM taxpayexpense WHERE idexp IN (SELECT idexp FROM #expense)
        DELETE FROM pettycashexpense WHERE idexp IN (SELECT idexp FROM #expense)
	DELETE FROM csa_import_expense WHERE idexp IN (SELECT idexp FROM #expense)
        DELETE FROM expenseyear WHERE idexp IN (SELECT idexp FROM #expense) AND amount = 0
	DELETE FROM expenselink
	WHERE idchild IN (SELECT idexp FROM #expense)
END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


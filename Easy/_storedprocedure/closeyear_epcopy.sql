
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_epcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_epcopy]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE       PROCEDURE [closeyear_epcopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #log (messaggio varchar(255))
DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)

EXEC closeyear_patrimonycopy @ayear

EXEC closeyear_placcountcopy @ayear

CREATE TABLE #patrimonylookup (oldidpatrimony varchar(31), newidpatrimony varchar(31))
	
INSERT #patrimonylookup
EXECUTE closeyear_fillpatrimonylookup @ayear

CREATE TABLE #placcountlookup (oldidplaccount varchar(31), newidplaccount varchar(31))
	
INSERT #placcountlookup
EXECUTE closeyear_fillplaccountlookup @ayear

IF NOT EXISTS (SELECT * FROM accountlevel WHERE ayear = @nextayear)
BEGIN
	INSERT INTO accountlevel
		(
			ayear, nlevel, description,
			flagusable,
			cu, ct, lu, lt
		)
		SELECT
			@nextayear, nlevel, description,
			flagusable,
			cu, GETDATE(), lu, GETDATE()
		FROM accountlevel
		WHERE ayear = @ayear
	
		INSERT INTO #log
		VALUES('Trasferiti livelli piano dei conti annuale per esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM account WHERE ayear = @nextayear)
BEGIN
	INSERT INTO account
		(
			idacc,
			ayear, codeacc,
			nlevel, paridacc, printingorder,rtf,txt, title, 
			idpatrimony,idplaccount,
			flagregistry, flagtransitory, flagupb,flagprofit,flagloss, 
			idaccountkind,placcount_sign,patrimony_sign, flagcompetency,flag,
			flagaccountusage,flagenablebudgetprev,
			idsor_economicbudget, economicbudget_sign, idsor_investmentbudget,investmentbudget_sign,
			cu, ct, lu, lt
		)
		SELECT
			SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(idacc, 3, 36),
			@nextayear, codeacc,nlevel,
			SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(paridacc, 3, 36),
			printingorder,rtf,txt, title, 
			CASE
				WHEN idpatrimony IS NULL THEN NULL
				ELSE
				#patrimonylookup.newidpatrimony
			END,
			CASE
				WHEN idplaccount IS NULL THEN NULL
				ELSE
				#placcountlookup.newidplaccount
			END,
			flagregistry, flagtransitory, flagupb,flagprofit,flagloss, 
			idaccountkind,placcount_sign,patrimony_sign, flagcompetency, account.flag, 
			flagaccountusage,flagenablebudgetprev,
			account.idsor_economicbudget, account.economicbudget_sign, account.idsor_investmentbudget, account.investmentbudget_sign,
			cu, GETDATE(), lu, GETDATE()
		FROM account
		LEFT OUTER JOIN #patrimonylookup 
		ON #patrimonylookup.oldidpatrimony = account.idpatrimony
		LEFT OUTER JOIN #placcountlookup 
		ON #placcountlookup.oldidplaccount = account.idplaccount	
		WHERE ayear = @ayear
				and not exists(select * from account where idacc  =SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(idacc, 3, 36))

		INSERT INTO #log
		VALUES('Trasferite voci del piano dei conti annuale per esercizio ' + @nextayearstr)
END
/*
Questa parte la fa la finsetupcopy, poiché si tratta di una tabella non DBO
IF NOT EXISTS (SELECT * FROM accountsorting WHERE idacc IN 
	(SELECT idacc FROM account WHERE ayear = @nextayear))
BEGIN
		INSERT INTO accountsorting
		(
			idsor,
			idacc,
			quota,
			cu, ct, lu, lt
		)
		SELECT
		idsor,
		SUBSTRING(@nextayearstr, 3, 2) +  SUBSTRING(idacc, 3, 36),
		quota,
		cu, GETDATE(), lu, GETDATE()
		FROM accountsorting
		WHERE SUBSTRING(idacc, 1,2) = SUBSTRING(CONVERT(char(4), @ayear), 3, 2)
	
		INSERT INTO #log
		VALUES('Trasferite classificazioni voci del piano dei conti annuale per esercizio ' + @nextayearstr)
END

*/

/*
idem come accouintsorting
IF NOT EXISTS (SELECT * FROM accmotivedetail WHERE ayear = @nextayear)
BEGIN
	INSERT INTO accmotivedetail
	(
		ayear, idacc, idaccmotive,
		cu, ct, lu, lt
	)
	SELECT
		@nextayear, SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(idacc, 3, 36), idaccmotive,
		cu, GETDATE(), lu, GETDATE()
	FROM accmotivedetail
	WHERE ayear = @ayear
	
	INSERT INTO #log VALUES('Trasferita associazione causali - conti per esercizio ' + @nextayearstr)
END

*/
	
END


SET QUOTED_IDENTIFIER ON 


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


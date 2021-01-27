
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_commontable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_commontable]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE closeyear_check_commontable
(
	@ayear int
)
AS
BEGIN
CREATE TABLE #errors (errordescr varchar(255))

IF ((SELECT COUNT(*) FROM dbdepartment) > 1 AND (UPPER(USER) <> 'AMMINISTRAZIONE'))
BEGIN
	INSERT INTO #errors VALUES('L''utente non ha i diritti per effettuare questa fase della chiusura')
END

DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)



IF EXISTS (SELECT * FROM patrimonylevel WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Livelli dello stato patrimoniale annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM placcountlevel WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Livelli del conto economico annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM accountlevel WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Livelli del piano dei conti annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM finlevel WHERE ayear = @nextayear )
BEGIN
	INSERT INTO #errors VALUES('Livelli del bilancio annuale per esercizio ' + @nextayearstr + ' esistenti.')

END

IF EXISTS (SELECT * FROM patrimony WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Voci dello stato patrimoniale annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM placcount WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Voci dello conto economico annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM account WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Voci del piano dei conti annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM fin WHERE ayear = @nextayear )
BEGIN
	INSERT INTO #errors VALUES('Voci del bilancio annuale per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM accountsorting WHERE idacc LIKE SUBSTRING(@nextayearstr, 3, 2) + '%')
BEGIN
	INSERT INTO #errors VALUES('Classificazioni piano dei conti per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM accmotivedetail WHERE idacc LIKE SUBSTRING(@nextayearstr, 3, 2) + '%')
BEGIN
	INSERT INTO #errors VALUES('Config. causali EP - conti da movimentare per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contractkindrules where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Regole di individuazione dei tipi di contratti CSA ' + @nextayearstr + ' esistenti.')
END

SELECT * FROM #errors

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


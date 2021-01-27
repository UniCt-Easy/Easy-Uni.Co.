
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_finsetupcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_finsetupcopy]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser'amministrazione'
--[closeyear_check_finsetupcopy] 2017
CREATE   PROCEDURE [closeyear_check_finsetupcopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errors (errordescr varchar(255))
DECLARE @nextayear int
SET @nextayear = @ayear + 1


DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)


IF EXISTS (SELECT * FROM taxsetup WHERE ayear = @ayear + 1)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi ritenute per esercizio ' + @nextayearstr + ' esistente.')
END


IF EXISTS (SELECT * FROM taxregionsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi ritenute ripartizione regionale per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS (SELECT * FROM taxpaymentpartsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi ritenute ripartizione percentuale per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS (SELECT * FROM clawbacksetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi recuperi per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS
	(SELECT * FROM autoincomesorting
	JOIN sortingkind ON sortingkind.idsorkind = autoincomesorting.idsorkind
	WHERE (autoincomesorting.ayear = @nextayear)
)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi per la classificazione dei mov. di entrata per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS
	(SELECT * FROM autoexpensesorting
	JOIN sortingkind ON sortingkind.idsorkind = autoexpensesorting.idsorkind
	WHERE (autoexpensesorting.ayear = @nextayear)
)
BEGIN
	INSERT INTO #errors VALUES('Configurazione automatismi per la classificazione dei mov. di spesa per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS
	(SELECT * FROM sortingincomefilter
	JOIN sortingkind  ON sortingkind.idsorkind = sortingincomefilter.idsorkind
	WHERE (sortingincomefilter.ayear = @nextayear)
)
BEGIN
	INSERT INTO #errors VALUES('Configurazione filtri per la classificazione dei mov. di entrata per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS
	(SELECT * FROM sortingexpensefilter
	JOIN sortingkind
		ON sortingkind.idsorkind = sortingexpensefilter.idsorkind
	WHERE (sortingexpensefilter.ayear = @nextayear)
)
BEGIN
	INSERT INTO #errors VALUES('Configurazione filtri per la classificazione dei mov. di spesa per esercizio ' + @nextayearstr + ' esistente.')
END


IF  EXISTS(SELECT * FROM autoclawbacksorting	 
			   WHERE autoclawbacksorting.ayear = @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione classificazione automatica dei recuperi per esercizio ' + @nextayearstr + ' esistente.')
END


IF EXISTS (SELECT * FROM taxsortingsetup WHERE ayear = @nextayear
)
BEGIN			
	INSERT INTO #errors VALUES('Configurazione classificazione delle ritenute per esercizio ' + @nextayearstr + ' esistente.')
END


IF EXISTS (SELECT * FROM partincomesetup P join fin fin1 on fin1.idfin= P.idfinincome and fin1.ayear= @nextayear) OR
  EXISTS (SELECT * FROM partincomesetup P join fin fin2 on fin2.idfin= P.idfinexpense and fin2.ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Ripartizioni assegnazioni entrate per esercizio ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contractkindyear where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Tipi contratti CSA ' + @nextayearstr + ' esistenti.')
END


IF EXISTS (SELECT * FROM csa_contractkinddata where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Attribuzioni tipi Contratti alle voci CSA ' + @nextayearstr + ' esistenti.')
END


IF EXISTS (SELECT * FROM csa_incomesetup where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione Entrate CSA ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contract where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Contratti CSA ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contract_partition where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione Ripartizione Contratti CSA ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contractregistry where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Associazioni Matricole-Contratti CSA ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contracttax where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione Contributi Contratti CSA ' + @nextayearstr + ' esistenti.')
END

IF EXISTS (SELECT * FROM csa_contracttax_partition where ayear= @nextayear)
BEGIN
	INSERT INTO #errors VALUES('Configurazione Ripartizione Contributi Contratti CSA ' + @nextayearstr + ' esistenti.')
END

INSERT INTO #errors
SELECT distinct ('Tipo contratto di competenza CSA ' + CK1.contractkindcode  + ' corrisponde a più tipi contratto  residui ed è associato a contratti da trasferire')
			FROM csa_contract
			JOIN csa_contractkind CK1
				ON CK1.idcsa_contractkind = csa_contract.idcsa_contractkind
			JOIN  csa_contractkindyear CKY1
					ON CKY1.idcsa_contractkind = CK1.idcsa_contractkind 
					AND CKY1.ayear = @ayear
		WHERE csa_contract.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(CK1.flagcr,'C') = 'C'
	    AND 
( SELECT COUNT(CK2.idcsa_contractkind) 
	FROM csa_contractkind CK2
	JOIN csa_contractkindyear CKY2
		ON CKY2.idcsa_contractkind = CK2.idcsa_contractkind 
		AND CKY2.ayear = CKY1.ayear
WHERE
	ISNULL(CK2.flagcr,'C') = 'R'
	AND ISNULL(CK2.flagkeepalive,'N') = 'S'
	AND  CK1.idcsa_contractkind <> CK2.idcsa_contractkind
	AND  CK1.contractkindcode = CK2.contractkindcode
) > 1

INSERT INTO #errors
SELECT distinct ('Tipo contratto di competenza CSA ' + CK1.contractkindcode  + ' non ha un corrispondente di tipo residui ed è associato a contratti da trasferire')
			FROM csa_contract
			JOIN csa_contractkind CK1
				ON CK1.idcsa_contractkind = csa_contract.idcsa_contractkind
			JOIN  csa_contractkindyear CKY1
					ON CKY1.idcsa_contractkind = CK1.idcsa_contractkind 
					AND CKY1.ayear =@ayear
		WHERE csa_contract.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(CK1.flagcr,'C') = 'C'
	    AND  NOT  EXISTS
( SELECT (CK2.idcsa_contractkind) 
	FROM csa_contractkind CK2
	JOIN csa_contractkindyear CKY2
		ON CKY2.idcsa_contractkind = CK2.idcsa_contractkind 
		AND CKY2.ayear = CKY1.ayear
WHERE
	ISNULL(CK2.flagcr,'C') = 'R'
	AND ISNULL(CK2.flagkeepalive,'N') = 'S'
	AND  CK1.idcsa_contractkind <> CK2.idcsa_contractkind
	AND  CK1.contractkindcode = CK2.contractkindcode
) 


SELECT * FROM #errors
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


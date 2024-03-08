
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_proceeds_bank]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_proceeds_bank]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE compute_proceeds_bank
(
	@kpro int
)
AS BEGIN
-- Ripristino situazione iniziale
-- Cancellazione dei movimenti bancari associati alla reversale

IF (SELECT COUNT(*) FROM banktransaction WHERE kpro = @kpro) > 0
BEGIN
	
	UPDATE proceeds_bank SET amount =
		(SELECT SUM(i.curramount) 
		FROM incometotal i
			JOIN incomelast l				ON i.idinc = l.idinc
		WHERE l.kpro = proceeds_bank.kpro	AND l.idpro = proceeds_bank.idpro)
	WHERE proceeds_bank.kpro = @kpro
		AND EXISTS (
			SELECT *
		FROM incometotal i
			JOIN incomelast l				ON i.idinc = l.idinc
		WHERE l.kpro = proceeds_bank.kpro	AND l.idpro = proceeds_bank.idpro)

	RETURN
END

DELETE FROM proceeds_bank WHERE kpro = @kpro

-- Scollegamento dei movimenti bancari dai movimenti finanziari associati alla reverasle
--UPDATE incomelast SET idpro = NULL WHERE ypro = @ypro AND npro = @npro
UPDATE incomelast SET idpro = NULL WHERE kpro = @kpro



	DECLARE @idinc int
	DECLARE @idreg int
	DECLARE @description varchar(200)
	DECLARE @curramount decimal(19,2)
	DECLARE @doc varchar(35)
	DECLARE @docdate datetime
	DECLARE @nbill int
	DECLARE @idpro_free int

	DECLARE pro_crs INSENSITIVE CURSOR FOR
	
	SELECT v.idinc, v.idreg, v.description, v.doc, v.docdate, v.curramount, v.nbill
	FROM incomeview v
	JOIN incomelast	l
		ON v.idinc = l.idinc 
	WHERE l.kpro = @kpro
	FOR READ ONLY
	
	OPEN pro_crs
	FETCH NEXT FROM pro_crs INTO @idinc, @idreg, @description, @doc, @docdate, @curramount, @nbill
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	IF (@doc IS NOT NULL)
		BEGIN
			SET @description = @description + ' Doc. ' + @doc
			IF (@docdate IS NOT NULL)
			BEGIN
				SET @description = @description + ' del ' + CONVERT(varchar(20), @docdate, 105)
			END
		END

		SET @idpro_free = ISNULL((SELECT MAX(idpro) FROM proceeds_bank WHERE kpro = @kpro),0) + 1
	
		INSERT INTO proceeds_bank (kpro, idpro, idreg, description, amount, ct, cu, lt, lu) 
		VALUES(@kpro, @idpro_free, @idreg, @description, @curramount,  GETDATE(), 'SP', GETDATE(), '''SP''')
	
		UPDATE incomelast SET idpro = @idpro_free WHERE idinc = @idinc
	
		FETCH NEXT FROM pro_crs INTO @idinc, @idreg, @description, @doc, @docdate, @curramount, @nbill 
	END
	CLOSE pro_crs
	DEALLOCATE pro_crs
	
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

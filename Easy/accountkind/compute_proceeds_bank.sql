
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
	@ypro smallint,
	@npro int
)
AS BEGIN
-- Ripristino situazione iniziale
-- Cancellazione dei movimenti bancari associati alla reversale

IF (SELECT COUNT(*) FROM banktransaction WHERE ypro = @ypro AND npro = @npro) > 0
BEGIN
	
	UPDATE proceeds_bank SET amount =
			(SELECT SUM(i.curramount) 
			FROM incomeview i
			JOIN incomelast l
				ON i.idinc = l.idinc
			WHERE i.ymov = proceeds_bank.ypro
				AND l.npro = proceeds_bank.npro
				AND l.idpro = proceeds_bank.idpro)
	WHERE proceeds_bank.ypro = @ypro
		AND proceeds_bank.npro = @npro
	RETURN
END

DELETE FROM proceeds_bank WHERE ypro = @ypro AND npro = @npro
-- Scollegamento dei movimenti bancari dai movimenti finanziari associati alla reverasle
--UPDATE incomelast SET idpro = NULL WHERE ypro = @ypro AND npro = @npro
-- DA RIVEDERE QUESTA UPDATE
UPDATE incomelast SET idpro = NULL
			from incomelast el
			join income e
				on e.idinc = el.idinc
			where e.ymov = @ypro and npro = @npro
	
DECLARE @groupby char(1)
SELECT @groupby = proceeds_groupingkind
FROM config
WHERE ayear = @ypro
	
DECLARE @idpro_free int
	
IF (@groupby = 'N')
BEGIN
	DECLARE @idinc int --varchar(40)
	DECLARE @idreg int
	DECLARE @description varchar(150)
	DECLARE @curramount float
	DECLARE @doc varchar(35)
	DECLARE @docdate datetime
	DECLARE @nbill int
	
	DECLARE pro_crs INSENSITIVE CURSOR FOR
	
	SELECT v.idinc, v.idreg, v.description, v.doc, v.docdate, v.curramount, v.nbill
	FROM incomeview v
	JOIN incomelast	l
		ON v.idinc = l.idinc 
	WHERE v.ymov = @ypro AND l.npro = @npro
	FOR READ ONLY
	
	OPEN pro_crs
	FETCH NEXT FROM pro_crs INTO @idinc, @idreg, @description, @doc, @docdate, @curramount, @nbill
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF @doc IS NOT NULL
		BEGIN
			SELECT @description = 'Pag. ' + @doc
		END
		IF @doc IS NOT NULL AND @docdate IS NOT NULL
		BEGIN
			SELECT @description = @description + ' del ' + CONVERT(varchar(20), @docdate, 105)
		END
		SET @idpro_free = ISNULL((SELECT MAX(idpro) FROM proceeds_bank WHERE ypro = @ypro AND npro = @npro),0) + 1
	
		INSERT INTO proceeds_bank (ypro, npro, idpro, idreg, description, amount, ct, cu, lt, lu) 
		VALUES(@ypro, @npro, @idpro_free, @idreg, @description, @curramount,  GETDATE(), 'SP', GETDATE(), '''SP''')
	
		UPDATE incomelast
		SET idpro = @idpro_free
		WHERE idinc = @idinc
	
		FETCH NEXT FROM pro_crs INTO @idinc, @idreg, @description, @doc, @docdate, @curramount, @nbill 
	END
	CLOSE pro_crs
	DEALLOCATE pro_crs
END
IF (@groupby = 'C') 
BEGIN
		DECLARE @idinc_1 int --varchar(40)
		DECLARE @idreg_1 int
		DECLARE @description_1 varchar(150)
		DECLARE @curramount_1 decimal(19,2)
		DECLARE @idinc_2 int --varchar(40)
		DECLARE @idreg_2 int
		DECLARE @description_2 varchar(150)
		DECLARE @curramount_2 decimal(19,2)
		DECLARE @nbill_1 int
		DECLARE @nbill_2 int
		DECLARE @flagsingle char(1)
		SELECT  @flagsingle = 'S'
		DECLARE @pbank_amount decimal(19,2)
		SELECT  @pbank_amount = 0
		DECLARE @pbank_descr varchar(150)
		SELECT  @pbank_descr = 'Incassi diversi'
		DECLARE pro_crs INSENSITIVE CURSOR FOR

		SELECT v.idinc, v.idreg, v.description, v.curramount, v.nbill
		FROM incomeview v
		JOIN incomelast l
			ON v.idinc = l.idinc
		WHERE v.ymov = @ypro AND l.npro = @npro
		ORDER BY v.idreg, v.nbill
		FOR READ ONLY
	
		OPEN pro_crs
	
		FETCH NEXT FROM pro_crs INTO @idinc_1, @idreg_1, @description_1,
			@curramount_1, @nbill_1
		IF (@@FETCH_STATUS = 0)
		BEGIN
			FETCH NEXT FROM pro_crs INTO @idinc_2, @idreg_2, @description_2,
				@curramount_2, @nbill_2
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				SET @idpro_free = ISNULL((SELECT MAX(idpro) FROM proceeds_bank WHERE ypro = @ypro AND npro = @npro),0) + 1
	
				SELECT @pbank_amount = ISNULL(@pbank_amount, 0) + @curramount_1
	
				IF @idreg_1 <> @idreg_2
					OR ISNULL(@nbill_1,0) <> ISNULL(@nbill_2,0)
				BEGIN
					IF @flagsingle = 'S'
					BEGIN
						SELECT @pbank_descr = @description_1
					END
					INSERT INTO proceeds_bank (ypro, npro, idpro, idreg, description, amount, ct, cu, lt, lu) 
					VALUES
					(@ypro, @npro, @idpro_free, @idreg_1, @pbank_descr, @pbank_amount,  GETDATE(), 'SP', GETDATE(), '''SP''')
					SELECT @pbank_amount = 0
					SELECT @flagsingle = 'S'
					SELECT @pbank_descr = 'Incassi diversi'
				END
				ELSE
				BEGIN
					SELECT @flagsingle = 'N'
				END
				UPDATE incomelast
				SET idpro = @idpro_free
				WHERE idinc = @idinc_1
	
				SELECT 
					@idinc_1 = @idinc_2, @idreg_1 = @idreg_2, 
					@description_1 = @description_2, @curramount_1 = @curramount_2,
					@nbill_1 = @nbill_2
	
				FETCH NEXT FROM pro_crs INTO @idinc_2, @idreg_2, @description_2,
					@curramount_2, @nbill_2
			END
	
			SET @idpro_free = ISNULL((SELECT MAX(idpro) FROM proceeds_bank WHERE ypro = @ypro AND npro = @npro),0) + 1
			IF @flagsingle = 'S'
			BEGIN
				SELECT @pbank_descr = @description_1
			END
	
			SELECT @pbank_amount = ISNULL(@pbank_amount, 0) + @curramount_1
	
			INSERT INTO proceeds_bank (ypro, npro, idpro, idreg, description, amount, ct, cu, lt, lu) 
			VALUES
			(@ypro, @npro, @idpro_free, @idreg_1, @pbank_descr, @pbank_amount,  GETDATE(), 'SP', GETDATE(), '''SP''')
			UPDATE incomelast
			SET idpro = @idpro_free
			WHERE idinc = @idinc_1
		END
		CLOSE pro_crs 
		DEALLOCATE pro_crs
	END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


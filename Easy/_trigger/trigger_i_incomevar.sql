
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_incomevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_incomevar]
GO


CREATE TRIGGER [trigger_i_incomevar] ON [incomevar] FOR INSERT
AS BEGIN
	DECLARE @finphase tinyint
	SELECT @finphase = incomefinphase FROM uniconfig

	DECLARE @proceedsphase tinyint	
	SELECT @proceedsphase = MAX(nphase) FROM incomephase

	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

	DECLARE @idinc int
	DECLARE @yvar int
	DECLARE @amount decimal(19,2)
	DECLARE @lu varchar(64)
	DECLARE @lt datetime
	
	SELECT
		@yvar = yvar, 
		@idinc = idinc, 
		@amount = amount,
		@lu = lu,
		@lt = lt
	FROM inserted

	DECLARE @nphase tinyint
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @parentidinc int
	DECLARE @idunderwriting int

	SELECT
		@idfin = incomeyear.idfin,
		@idupb = incomeyear.idupb,
		@nphase = income.nphase,
		@parentidinc = income.parentidinc,
		@idunderwriting = income.idunderwriting	
	FROM incomeyear
	JOIN income
		ON income.idinc = incomeyear.idinc
	WHERE income.idinc = @idinc
	AND ayear = @yvar
	
	EXECUTE trg_amount_variation
	@yvar,
	'I',
	@idinc,
	@parentidinc,
	@nphase,
	0,
	@amount
	
	DECLARE @kpro int
	DECLARE @idtreasurer int
	
	SELECT @kpro = kpro FROM incomelast 
	WHERE idinc = @idinc
	
	SELECT @idtreasurer = idtreasurer 
	FROM proceeds WHERE kpro = @kpro
	
	IF (@kpro IS NOT NULL AND @idtreasurer IS NOT NULL) BEGIN
		-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
		EXEC trg_upd_treasurercashtotal
		@yvar,
		@idtreasurer,
		'I',
		0,
		@amount
	END
	
	DECLARE @ymovpar int
	SELECT @ymovpar = income.ymov 
	FROM incomelink
	JOIN income
	ON incomelink.idparent = income.idinc
	WHERE idchild = @idinc
		AND nlevel = @finphase

	IF @idfin IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			EXECUTE trg_upd_upbmovtotal 
			'I', 
			@idfin, 
			@idupb,
			'C', 
			@nphase, 
			@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_upbmovtotal 
			'I', 
			@idfin, 
			@idupb,
			'R', 
			@nphase, 
			@amount
		END
	END

	IF @idunderwriting IS NOT NULL
	BEGIN
		IF (@ymovpar = @yvar)
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'I', 
			@idunderwriting,
			@idupb,
			@idfin,
			'C', 
			@nphase, 
			@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'I', 
			@idunderwriting,
			@idupb,
			@idfin,
			'R', 
			@nphase, 
			@amount
		END
	END
	
	IF @yvar = @ybalance
	BEGIN
		IF @nphase < @proceedsphase
		BEGIN
			EXECUTE trg_evaluatearrears
			'I',
			@idinc,
			@yvar,
			@nphase
		END
		ELSE
		BEGIN
			DECLARE @currentphase tinyint
			DECLARE @idcurrentinc int
			SET @idcurrentinc = @idinc
			SELECT @currentphase = (@proceedsphase - 1)
			WHILE @currentphase > 0 
			BEGIN
				SELECT @idcurrentinc = idparent FROM incomelink WHERE idchild = @idcurrentinc
					AND nlevel = @currentphase

				EXECUTE trg_evaluatearrears
				'I',
				@idcurrentinc,
				@yvar,
				@currentphase
	
				SELECT @currentphase = @currentphase - 1
			END
/*
			DECLARE @currentphase tinyint
			DECLARE @idcurrentinc int
			SET @idcurrentinc = @idinc
			SELECT @currentphase = 1
			WHILE @currentphase < @proceedsphase
			BEGIN
				SELECT @idcurrentinc = idparent FROM incomelink WHERE idchild = @idinc
					AND nlevel = @currentphase

				EXECUTE trg_evaluatearrears
				'I',
				@idcurrentinc,
				@yvar,
				@currentphase
	
				SELECT @currentphase = @currentphase + 1
			END
*/
		END
	END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


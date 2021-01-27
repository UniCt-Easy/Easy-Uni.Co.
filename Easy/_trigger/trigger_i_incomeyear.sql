
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_incomeyear]
GO

CREATE    TRIGGER [trigger_i_incomeyear] ON [incomeyear] FOR INSERT
AS BEGIN
	DECLARE @finphase tinyint
	SET @finphase = 1 --incomefinphase FROM uniconfig
	
	DECLARE @proceedsphase tinyint	
	SELECT @proceedsphase = MAX(nphase) FROM incomephase

	DECLARE @ybalance int	
	SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=4) 
	DECLARE @idinc int
	DECLARE @ayear int
	DECLARE @nphase tinyint
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @ymov int
	DECLARE @parentidinc int
	DECLARE @idunderwriting int

	SELECT @idinc = inserted.idinc, 
	@ayear = inserted.ayear, 
	@nphase = income.nphase, 
	@idfin = inserted.idfin, 
	@idupb = inserted.idupb,
	@amount = inserted.amount,
	@ymov = income.ymov,
	@parentidinc = income.parentidinc,
	@idunderwriting = income.idunderwriting	
	FROM inserted
	JOIN income
	ON income.idinc = inserted.idinc

	if (@idinc is null) return 

	DECLARE @firstyear tinyint
	SET @firstyear = CASE WHEN @ymov = @ayear THEN 2 ELSE 0 END

	DECLARE @ymovparfin int
	SELECT @ymovparfin = income.ymov 
	FROM incomelink
	JOIN income
	ON incomelink.idparent = income.idinc
	WHERE idchild = @idinc
		AND nlevel = @finphase

	--IF @idfin IS NOT NULL
	--BEGIN
		IF (@ymovparfin = @ayear)
		BEGIN
			EXECUTE trg_ins_amount @ayear, 'I', @idinc, @parentidinc,@amount, 	0, -- Competenza
							@firstyear

			EXECUTE trg_upd_upbmovtotal 'I', @idfin, @idupb,'C', @nphase, 	@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_ins_amount 	@ayear, 'I', @idinc, @parentidinc,	@amount, 1, -- Residuo
							@firstyear

			EXECUTE trg_upd_upbmovtotal  'I', @idfin, @idupb,'R', @nphase, 	@amount
		END
	--END
	--ELSE
	--BEGIN
	--		EXECUTE trg_ins_amount 
	--		@ayear, 
	--		'I', 
	--		@idinc, 
	--		@parentidinc,
	--		@amount, 
	--		0,
	--		@firstyear
	--END

	IF @idunderwriting IS NOT NULL
	BEGIN		
			
		IF (@ymovparfin = @ayear)
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 'I', @idunderwriting,@idupb,@idfin,'C', @nphase, 	@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 'I', @idunderwriting,@idupb,@idfin,'R', @nphase, 	@amount
		END
	END
	
	IF @ayear = @ybalance
	BEGIN
		IF @nphase < @proceedsphase
		BEGIN
			--EXECUTE trg_evaluatearrears 'I',@idinc,	@ayear,	@nphase
			execute trg_updatearrears 'I',@idinc,	@ayear,	@nphase,@idfin,@idupb,@amount
		END
		ELSE
		BEGIN
			SET @amount=-@amount
			SET @nphase = @nphase-1
			WHILE @nphase > 0 
			BEGIN
				SELECT @idinc = parentidinc FROM income WHERE idinc = @idinc
					
				--EXECUTE trg_evaluatearrears 'E',@idcurrentexp,@ayear,@currentphase
				execute trg_updatearrears 'I',@idinc,	@ayear,	@nphase,@idfin,@idupb,@amount

				SET @nphase = @nphase-1
			END

		END
	END

	IF (@nphase = @proceedsphase) AND exists(select * from incomelast where idinc=@idinc) BEGIN

		DECLARE @idtreasurer int
		set @idtreasurer=null
		DECLARE @ypro int
		DECLARE @curramount decimal(19,2)

		SELECT 		@idtreasurer = idtreasurer, 	@ypro = ypro
			FROM proceeds 
			join incomelast on proceeds.kpro=incomelast.kpro
			WHERE incomelast.idinc= @idinc

		if (@idtreasurer is not null)
		BEGIN

			EXEC trg_upd_treasurercashtotal		@ypro,		@idtreasurer,		'I',		0,		@amount
		END

	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


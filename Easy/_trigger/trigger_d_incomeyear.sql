
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_incomeyear]
GO

CREATE      TRIGGER [trigger_d_incomeyear] ON [incomeyear] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @ybalance int
	EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

	DECLARE @finphase tinyint
	SELECT @finphase = incomefinphase FROM uniconfig

	DECLARE @proceedsphase tinyint
	SELECT @proceedsphase = MAX(nphase) FROM incomephase

	DECLARE @idinc int
	DECLARE @ayear int
	DECLARE @amount decimal(19,2)
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @flagarrear char(1)
	DECLARE @nphase tinyint
	DECLARE @parentidinc int
	DECLARE @idunderwriting int 

	-- dobbiamo essere certi che esista INCOME in caso la riga sia stata già cancellata non verranno eseguiti pezzi 
	-- del trigger che però replicheremo come esecuzione nel trigger in delete su income
	SELECT
		@idinc = D.idinc, @ayear = D.ayear, @idfin = D.idfin, @idupb = D.idupb,
		@nphase = I.nphase, @amount = - IT.curramount,
		@flagarrear = 
		CASE
			WHEN ((IT.flag&1)=0) THEN 'C'
			WHEN ((IT.flag&1)=1) THEN 'R'
		END,
		@parentidinc = I.parentidinc,
		@idunderwriting = I.idunderwriting	
	FROM deleted D
	JOIN incometotal IT
		ON IT.idinc = D.idinc
		AND IT.ayear = D.ayear
	LEFT OUTER JOIN income I
		ON I.idinc = D.idinc

	IF (@idfin IS NOT NULL)	AND (@nphase IS NOT NULL)
	BEGIN
		EXECUTE trg_upd_upbmovtotal 
		'I', 
		@idfin, 
		@idupb,
		@flagarrear, 
		@nphase, 
		@amount
	END

	IF (@idunderwriting IS NOT NULL)
	BEGIN
		EXECUTE trg_upd_underwritingmovtotal 
		'I', 
		@idunderwriting,
		@idupb,
		@idfin,
		@flagarrear, 
		@nphase, 
		@amount
	END
			
	EXECUTE trg_del_amount 
	@ayear, 
	'I', 
	@idinc,
	@parentidinc,
	@nphase,
	@amount

--- Aggiorniamo il totalizzatore del saldo iniziale
IF (@nphase = @proceedsphase)
Begin
	DECLARE @idtreasurer int
	SELECT 
		@idtreasurer = proceeds.idtreasurer 
	FROM proceeds 
	JOIN incomelast
		on proceeds.kpro = incomelast.kpro
	WHERE ypro = @ayear
		and incomelast.idinc = @idinc
		
	declare @amountPos decimal(19,2) 
	SET @amountPos= -@amount
	IF (@idtreasurer is not null)
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ayear,
		@idtreasurer,
		'I',
		@amountPos,
		0
	END
End

	IF @ayear = @ybalance
	BEGIN
		IF @nphase < @proceedsphase
		BEGIN
			EXECUTE trg_evaluatearrears
			'I',
			@idinc,
			@ayear,
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
				@ayear,
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
				@ayear,
				@currentphase
				SELECT @currentphase = @currentphase + 1
			END
*/
		END
	END
END
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


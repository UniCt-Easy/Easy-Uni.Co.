
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomeyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomeyear]
GO

CREATE    TRIGGER [trigger_u_incomeyear] ON [incomeyear] FOR UPDATE
AS BEGIN
IF UPDATE(idfin) OR
UPDATE(idupb) OR
UPDATE(amount)
BEGIN
	DECLARE @ybalance int	
	EXECUTE trg_yearbalance 'I', @ybalance OUTPUT	

	DECLARE @ayear int
	DECLARE @parentidinc int
	DECLARE @idinc int
	DECLARE @flagarrear char(1)
	DECLARE @nphase tinyint
	DECLARE @newidfin int
	DECLARE @newidupb varchar(36)
	DECLARE @newamount decimal(19,2)

	SELECT
		@idinc = INS.idinc, 
		@parentidinc = I.parentidinc,
		@ayear = INS.ayear, 
		@nphase = I.nphase, 
		@newidfin = INS.idfin, 
		@newidupb = INS.idupb,
		@newamount = INS.amount,
		@flagarrear =
 		CASE
			WHEN ((IT.flag&1)=0) THEN 'C'
			WHEN ((IT.flag&1)=1) THEN 'R'
		END
	FROM inserted INS
	JOIN income I
		ON I.idinc = INS.idinc
	JOIN incometotal IT
		ON IT.idinc = INS.idinc
		AND IT.ayear = INS.ayear

	DECLARE @oldidfin int
	DECLARE @oldidupb varchar(36)
	DECLARE @oldamount decimal(19,2)
	SELECT @oldidfin = idfin, 
	@oldidupb = idupb,
	@oldamount = -amount
	FROM deleted

	DECLARE @finphase tinyint
	SELECT @finphase = incomefinphase FROM uniconfig

	DECLARE @proceedsphase tinyint
	SELECT @proceedsphase = MAX(nphase) FROM incomephase

	DECLARE @variationsamount decimal(19,2)
	SELECT @variationsamount = curramount + @oldamount 
	FROM incometotal WHERE idinc = @idinc AND ayear = @ayear

	DECLARE @oldcurrentamount decimal(19,2)
	SELECT @oldcurrentamount = @oldamount - @variationsamount

	DECLARE @newcurrentamount decimal(19,2)
	SELECT @newcurrentamount = @newamount + @variationsamount

	IF (@nphase >= @finphase) AND
	((@newidfin <> @oldidfin) OR (@newidupb <> @oldidupb))
	BEGIN
		EXECUTE trg_upd_upb
		'I',
		@idinc,
		@ayear, 
		@nphase, 
		@newidfin,
		@newidupb
	END
	IF @nphase = @finphase AND @newidfin <> @oldidfin
	BEGIN
		EXECUTE trg_upd_doc
		'E', -- Parte di bilancio
		@idinc,
		@ayear,
		@newidfin
	END
	
	DECLARE @idunderwritingCurr int -- > E' inteso come il NEW
	SELECT @idunderwritingCurr = isnull(idunderwriting,0) FROM income WHERE idinc = @idinc 
	
	IF @nphase >= @finphase AND
	((@oldidfin <> @newidfin) OR (@oldidupb <> @newidupb))
	BEGIN
		-- Se è cambiata solo la voce di bilancio aggiorno solo UPBINCOMETOTAL
		EXECUTE trg_upd_upbmovtotal
		'I', 
		@oldidfin, 
		@oldidupb,
		@flagarrear, 
		@nphase, 
		@oldcurrentamount

		EXECUTE trg_upd_upbmovtotal
		'I', 
		@newidfin, 
		@newidupb,
		@flagarrear, 
		@nphase, 
		@newcurrentamount

	-- Se cambio il finanziamento non posso modificare nient'altro. E' stato creato un task per consentire la modifica al finanziamento col wizard.
	-- Quindi se ho modificato l'importo, o idfin, o idupb, vuol dire che il finanziamento non è cambiato

		EXECUTE trg_upd_underwritingmovtotal		
		'I', 
		@idunderwritingCurr, 
		@oldidupb,
		@oldidfin,
		@flagarrear, 
		@nphase, 
		@oldcurrentamount

		EXECUTE trg_upd_underwritingmovtotal		
		'I', 
		@idunderwritingCurr, 
		@newidupb,
		@newidfin,
		@flagarrear, 
		@nphase, 
		@newcurrentamount		
		
		-- Se è cambiato l'UPB aggiorno sia UPBINCOMETOTAL sia UPBTOTAL
		DECLARE @lessamount decimal(19,2)
		IF (@oldidupb <> @newidupb)
		BEGIN
		DECLARE @idexpensefin int
		DECLARE @amount decimal(19,2)
		--	-- Modifica delle ASSEGNAZIONI CREDITI
		--	IF EXISTS(SELECT * FROM creditpart WHERE idinc = @idinc AND ycreditpart = @ayear)
		--	BEGIN
		--		DECLARE #crediti INSENSITIVE CURSOR FOR
		--		SELECT SUM(amount),idfin
		--		FROM creditpart
		--		WHERE idinc = @idinc AND ycreditpart = @ayear
		--		GROUP BY idfin
		--		FOR READ ONLY
		--		OPEN #crediti

		--		FETCH NEXT FROM #crediti INTO @amount,@idexpensefin
		--		WHILE (@@FETCH_STATUS = 0)
		--		BEGIN
		--			SET @lessamount = -@amount
		--			EXECUTE trg_upd_upbtotal
		--			@idexpensefin,
		--			@oldidupb,
		--			'totcreditpart',
		--			@lessamount

		--			EXECUTE trg_upd_upbtotal
		--			@idexpensefin,
		--			@newidupb,
		--			'totcreditpart',
		--			@amount
		--			FETCH NEXT FROM #crediti INTO @amount,@idexpensefin
		--		END
		--		CLOSE #crediti
		--		DEALLOCATE #crediti
		--	END

		--	-- Modifica delle ASSEGNAZIONI INCASSI
		--	IF EXISTS(
		--		SELECT * FROM proceedspart WHERE idinc = @idinc AND yproceedspart = @ayear)
		--	BEGIN
		--		DECLARE #incassi INSENSITIVE CURSOR FOR
		--		SELECT SUM(proceedspart.amount), proceedspart.idfin
		--		FROM income
		--		JOIN incomelink
		--			ON income.idinc = incomelink.idparent
		--		JOIN proceedspart
		--			ON proceedspart.idinc = incomelink.idchild
		--		WHERE income.idinc = @idinc
		--			AND proceedspart.yproceedspart = @ayear
		--		GROUP BY proceedspart.idfin
		--		FOR READ ONLY
		--		OPEN #incassi

		--		FETCH NEXT FROM #incassi INTO @amount,@idexpensefin
		--		WHILE (@@FETCH_STATUS = 0)
		--		BEGIN
		--			SET @lessamount = -@amount
		--			EXECUTE trg_upd_upbtotal
		--			@idexpensefin,
		--			@oldidupb,
		--			'totproceedspart',
		--			@lessamount

		--			EXECUTE trg_upd_upbtotal
		--			@idexpensefin,
		--			@newidupb,
		--			'totproceedspart',
		--			@amount
		--			FETCH NEXT FROM #incassi INTO @amount,@idexpensefin
		--		END
		--		CLOSE #incassi
		--		DEALLOCATE #incassi
		--	END
		END
	END
	
	IF (@nphase >= @finphase)
	AND (@newidfin = @oldidfin)
	AND (@newidupb = @oldidupb)
	AND (ABS(@oldcurrentamount) <> @newcurrentamount)
	BEGIN
		DECLARE @diff decimal(19,2)
		SET @diff = @oldcurrentamount + @newcurrentamount
		EXECUTE trg_upd_upbmovtotal 
		'I', 
		@oldidfin, @oldidupb,
		@flagarrear, 
		@nphase, 
		@diff
	
		-- Se cambio il finanziamento non posso modificare nient'altro. E' stato creato un task per consentire la modifica al finanziamento col wizard.
		-- Quindi se ho modificato l'importo, o idfin, o idupb, vuol dire che il finanziamento non è cambiato
		EXECUTE trg_upd_underwritingmovtotal		
		'I', 
		@idunderwritingCurr, 
		@oldidupb,
		@oldidfin,
		@flagarrear, 
		@nphase, 
		@diff

	END
	
declare @amountPos decimal(19,2) 
	SET @amountPos= -@oldamount
	
--- Aggiorniamo il totalizzatore del saldo iniziale
IF (@nphase = @proceedsphase) AND 
	((@newamount != @amountPos) OR
	(@newamount IS NULL AND @amountPos IS NOT NULL) OR
	(@newamount IS NOT NULL AND @amountPos IS NULL))
Begin	
	
	
	DECLARE @idtreasurer int
	SELECT 
		@idtreasurer = proceeds.idtreasurer 
	FROM proceeds 
	JOIN incomelast
		on proceeds.kpro = incomelast.kpro
	WHERE ypro = @ayear
		and incomelast.idinc = @idinc
		
	IF (@idtreasurer is not null)
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ayear,
		@idtreasurer,
		'I',
		@amountPos,
		@newamount
		
	END
End
	
	IF @newamount <> -@oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL)
	BEGIN
		EXECUTE trg_upd_amount 
		@ayear, 
		'I', 
		@parentidinc,
		@idinc,
		@newamount, 
		@oldamount
	END
	IF @ayear = @ybalance AND 
	(@newamount != @oldamount OR
	(@newamount IS NULL AND @oldamount IS NOT NULL) OR
	(@newamount IS NOT NULL AND @oldamount IS NULL))
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



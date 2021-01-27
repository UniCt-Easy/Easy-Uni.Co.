
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_income]
GO


CREATE  TRIGGER [trigger_u_income] ON income FOR UPDATE
AS BEGIN
DECLARE @idinc int
DECLARE @nphase tinyint

IF UPDATE(parentidinc)
BEGIN
	DECLARE @newidparent int
	SELECT @idinc = idinc, @newidparent = parentidinc, @nphase = nphase FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #incomelink (idchild int)
	
	INSERT INTO #incomelink
	SELECT idchild
	FROM incomelink
	WHERE incomelink.idparent = @idinc
	
	UPDATE incomelink
	SET idparent = (SELECT idparent FROM incomelink IL2 WHERE IL2.idchild = @newidparent AND IL2.nlevel = incomelink.nlevel)
	FROM #incomelink T
	WHERE incomelink.idchild = T.idchild
	AND nlevel < @nphase
END

IF UPDATE(idreg)
BEGIN
	DECLARE @oldidreg int
	DECLARE @newidreg int


	SELECT @oldidreg = idreg FROM deleted

	SELECT @newidreg = idreg, @idinc = idinc, @nphase = nphase FROM inserted

	DECLARE @regphase tinyint
	SELECT @regphase = incomeregphase FROM uniconfig

	IF (@nphase <> @regphase) RETURN

        IF (ISNULL(@oldidreg, -1) <> ISNULL(@newidreg, -1))
	BEGIN
		UPDATE income
		SET idreg = @newidreg
		FROM incomelink
		WHERE incomelink.idparent = @idinc
		AND incomelink.idchild <> @idinc
		AND income.idinc = incomelink.idchild
		AND ISNULL(income.idreg,-1) = ISNULL(@oldidreg,-1)
	END
END

IF UPDATE(idunderwriting)
BEGIN
	DECLARE @oldidunderwriting int
	DECLARE @newidunderwriting int

	SELECT @oldidunderwriting = idunderwriting FROM deleted
	SELECT @newidunderwriting = idunderwriting, @idinc = idinc, @nphase = nphase FROM inserted

	DECLARE @finphase tinyint
	SELECT @finphase = incomefinphase FROM uniconfig

	EXECUTE trg_upd_underwriting
	'I',
	@idinc,
	@nphase, 
	@newidunderwriting

	DECLARE @curramount decimal(19,2)
	DECLARE @curramount_neg decimal(19,2)
	DECLARE @flagarrear char(1)
	DECLARE @idupb varchar(36)	
	DECLARE @idfin int
					
	SELECT 
			@idupb = IY.idupb,
			@idfin = IY.idfin,
			@curramount = IT.curramount,
			@curramount_neg = -IT.curramount,
			@flagarrear =
			CASE
				WHEN ((IT.flag&1)=0) THEN 'C'
				WHEN ((IT.flag&1)=1) THEN 'R'
			END
	FROM inserted I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc  
		AND IY.ayear = I.ymov	
	JOIN incometotal IT
		ON IT.idinc = I.idinc
		AND IT.ayear = I.ymov
		
	EXECUTE trg_upd_underwritingmovtotal
		'I', 
		@oldidunderwriting, 
		@idupb,
		@idfin,
		@flagarrear, 
		@nphase, 
		@curramount_neg

	EXECUTE trg_upd_underwritingmovtotal
		'I', 
		@newidunderwriting, 
		@idupb,
		@idfin,
		@flagarrear, 
		@nphase, 
		@curramount
	
		DECLARE @idfindetail int
		DECLARE @idupbdetail varchar(36)
		DECLARE @amountdetail decimal(19,2)
		DECLARE @amountdetail_neg decimal(19,2)
		
		DECLARE #dettaglio INSENSITIVE CURSOR FOR
		SELECT idfin,idupb,amount FROM creditpart WHERE idinc = @idinc
		FOR READ ONLY
		OPEN #dettaglio

		FETCH NEXT FROM #dettaglio INTO @idfindetail, @idupbdetail,@amountdetail
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
		-----------------codice ------------------------------------
		
			IF (@idfindetail IS NOT NULL) AND (@idupbdetail IS NOT NULL) AND (@oldidunderwriting IS NOT NULL)
			BEGIN
				SET @amountdetail_neg = - @amountdetail  
				
				EXECUTE trg_upd_upbunderwritingtotal 
				@idfindetail,
				@idupbdetail,
				@oldidunderwriting,
				'totcreditpart',
				@amountdetail_neg
			END	

			IF (@idfindetail IS NOT NULL) AND (@idupbdetail IS NOT NULL) AND (@newidunderwriting IS NOT NULL)
			BEGIN
				EXECUTE trg_upd_upbunderwritingtotal 
					@idfindetail,
					@idupbdetail,
					@newidunderwriting,
					'totcreditpart',
					@amountdetail
			END
		
		
		FETCH NEXT FROM #dettaglio INTO @idfindetail,@idupbdetail,@amountdetail
		END
		CLOSE #dettaglio
		DEALLOCATE #dettaglio
	
		DECLARE #dettaglio INSENSITIVE CURSOR FOR
		SELECT idfin,idupb,amount FROM proceedspart WHERE idinc = @idinc
		FOR READ ONLY
		OPEN #dettaglio

		FETCH NEXT FROM #dettaglio INTO @idfindetail, @idupbdetail,@amountdetail
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
		-----------------codice ------------------------------------
		
		IF (@idfindetail IS NOT NULL) AND (@idupbdetail IS NOT NULL) AND (@oldidunderwriting IS NOT NULL)
		BEGIN
			SET @amountdetail_neg = - @amountdetail 

			EXECUTE trg_upd_upbunderwritingtotal 
			@idfindetail,
			@idupbdetail,
			@oldidunderwriting,
			'totproceedspart',
			@amountdetail_neg
		END	
		
		IF (@idfindetail IS NOT NULL) AND (@idupbdetail IS NOT NULL) AND (@newidunderwriting IS NOT NULL)
		BEGIN
			EXECUTE trg_upd_upbunderwritingtotal 
			@idfindetail,
			@idupbdetail,
			@newidunderwriting,
			'totproceedspart',
			@amountdetail
		END
		
		
		FETCH NEXT FROM #dettaglio INTO @idfindetail,@idupbdetail,@amountdetail
		END
		CLOSE #dettaglio
		DEALLOCATE #dettaglio
	END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

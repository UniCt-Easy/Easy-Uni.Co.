
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finvar]
GO

CREATE TRIGGER [trigger_u_finvar] ON [finvar] FOR UPDATE
AS BEGIN
	IF UPDATE(flagprevision)
	OR UPDATE(flagsecondaryprev)
	OR UPDATE(flagcredit)
	OR UPDATE(flagproceeds)
	OR UPDATE(idfinvarstatus)
	BEGIN
		DECLARE @yvar int
		DECLARE @nvar int
		DECLARE @variationkind tinyint
		DECLARE @oldflagprevision char(1)
		DECLARE @oldflagprevision_inserted char(1)
		DECLARE @oldflagsecondaryprev char(1)
		DECLARE @oldflagcredit char(1)
		DECLARE @oldflagproceeds char(1)
		DECLARE @newflagprevision char(1)
		DECLARE @newflagprevision_inserted char(1)
		DECLARE @newflagsecondaryprev char(1)
		DECLARE @newflagcredit char(1)
		DECLARE @newflagproceeds char(1)
		DECLARE @oldidfinvarstatus smallint
		DECLARE @newidfinvarstatus smallint

   		SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@variationkind = ISNULL(variationkind,0),
		@newflagprevision = ISNULL(flagprevision,'N'),
		@newflagsecondaryprev = ISNULL(flagsecondaryprev,'N'),
		@newflagcredit = ISNULL(flagcredit,'N'),
		@newflagproceeds = ISNULL(flagproceeds,'N'),
		@newidfinvarstatus = ISNULL(idfinvarstatus,0)
		FROM inserted

		set @newflagprevision_inserted= @newflagprevision

		if (@newidfinvarstatus<>5) BEGIN
			SET @newflagprevision='N'
			SET @newflagsecondaryprev='N'
			SET @newflagcredit='N'
			SET @newflagproceeds='N'
		END
		
		if (@newidfinvarstatus<>4 and @newidfinvarstatus<>5) BEGIN --non è previsione inserita e nemmeno approvata
			SET @newflagprevision_inserted='N'
		END

		SELECT
		@oldflagprevision = ISNULL(flagprevision,'N'),
		@oldflagsecondaryprev = ISNULL(flagsecondaryprev,'N'),
		@oldflagcredit = ISNULL(flagcredit,'N'),
		@oldflagproceeds = ISNULL(flagproceeds,'N'),
		@oldidfinvarstatus = ISNULL(idfinvarstatus,0)
		FROM deleted

		set @oldflagprevision_inserted= @oldflagprevision

		if (@oldidfinvarstatus<>5) BEGIN
			SET @oldflagprevision='N'
			SET @oldflagsecondaryprev='N'
			SET @oldflagcredit='N'
			SET @oldflagproceeds='N'
		END

		if (@oldidfinvarstatus<>4 and @oldidfinvarstatus<>5) BEGIN --non è previsione inserita e nemmeno approvata
			SET @oldflagprevision_inserted='N'
		END

		if (@newflagprevision='S' and @oldflagprevision='N') BEGIN
			update lcardtotal set lcardtotal.amount= lcardtotal.amount - finvardetail.amount
				from lcardtotal join
				finvardetail on finvardetail.idlcard= lcardtotal.idlcard
				where finvardetail.yvar=@yvar
				  and 
				  finvardetail.nvar=@nvar
				and finvardetail.idlcard is not null
		END

		if (@newflagprevision='N' and @oldflagprevision='S') BEGIN
			update lcardtotal set lcardtotal.amount= lcardtotal.amount + finvardetail.amount
				from lcardtotal join
				finvardetail on finvardetail.idlcard= lcardtotal.idlcard
				where finvardetail.yvar=@yvar
				  and 
				  finvardetail.nvar=@nvar
				and finvardetail.idlcard is not null
		END

		DECLARE @idfindetail int
		DECLARE @idupbdetail varchar(36)
		DECLARE @idunderwritingdetail int
		DECLARE @amountdetail decimal(19,2)
		DECLARE @finpart char(1)
		
		
		DECLARE #dettaglio INSENSITIVE CURSOR FOR
		SELECT finvardetail.idfin,finvardetail.idupb,finvardetail.idunderwriting,finvardetail.amount,
				CASE		when (( fin.flag & 1)=0) then 'E'
									when (( fin.flag & 1)=1) then 'S'
						End 
				FROM finvardetail 
				join fin on finvardetail.idfin=fin.idfin
				WHERE yvar = @yvar AND nvar = @nvar
		FOR READ ONLY
		OPEN #dettaglio

		FETCH NEXT FROM #dettaglio INTO @idfindetail, @idupbdetail, @idunderwritingdetail,@amountdetail,@finpart
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			DECLARE @lessamountdetail decimal(19,2)
			SET @lessamountdetail = -@amountdetail
			-- Cambio FLAGPREVISION
			IF (@variationkind <>5)
				BEGIN
				IF (@oldflagprevision <> @newflagprevision) 
				BEGIN
					IF (@newflagprevision = 'N') 
					BEGIN			
						EXEC trg_upd_upbtotal 	@idfindetail ,	@idupbdetail, 'previsionvariation',	@lessamountdetail
						
						IF (@idunderwritingdetail IS NOT NULL)
						BEGIN
							EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,	@idupbdetail,	@idunderwritingdetail,
								'previsionvariation',	@lessamountdetail
						END	
					END
					ELSE --(@newflagprevision = 'S')
					BEGIN
						EXEC trg_upd_upbtotal 	@idfindetail,	@idupbdetail,'previsionvariation',	@amountdetail
						
						IF (@idunderwritingdetail IS NOT NULL)
						BEGIN
							EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,@idupbdetail,	@idunderwritingdetail,
									'previsionvariation',	@amountdetail
						END	
					END
					END
			END

			-- Cambio FLAGPREVISION_INSERTED
			IF (@variationkind <>5)
				BEGIN
				IF (@oldflagprevision_inserted <> @newflagprevision_inserted) 
				BEGIN
					IF (@newflagprevision_inserted = 'N') 
					BEGIN			
						EXEC trg_upd_upbtotal 	@idfindetail ,	@idupbdetail, 'previsionvariation_inserted',	@lessamountdetail
						
						IF (@idunderwritingdetail IS NOT NULL)
						BEGIN
							EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,	@idupbdetail,	@idunderwritingdetail,
								'previsionvariation',	@lessamountdetail
						END	
					END
				    ELSE --(@newflagprevision_inserted = 'S')
					BEGIN
						EXEC trg_upd_upbtotal 	@idfindetail,	@idupbdetail,'previsionvariation_inserted',	@amountdetail
						
						IF (@idunderwritingdetail IS NOT NULL)
						BEGIN
							EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,@idupbdetail,	@idunderwritingdetail,
									'previsionvariation_inserted',	@amountdetail
						END	
					END
					END
			END


			IF (@variationkind = 5)
				BEGIN
				IF (@oldflagprevision <> @newflagprevision)
					BEGIN
					IF (@newflagprevision = 'N') 
					BEGIN
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal @idfindetail,	@idupbdetail,@idunderwritingdetail,	'currentprev',	@lessamountdetail
					END	
				END
					ELSE --(@newflagprevision = 'S')
					BEGIN
						IF (@idunderwritingdetail IS NOT NULL)
						BEGIN
							EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,	@idupbdetail,@idunderwritingdetail,	'currentprev',@amountdetail
						END	
					END
				END
			END
			
			
			-- Cambio FLAGSECONDARYPREV
			IF (@variationkind <>5) AND  (@oldflagsecondaryprev <> @newflagsecondaryprev)
			BEGIN
				IF (@newflagsecondaryprev = 'N')
				BEGIN
					EXEC trg_upd_upbtotal		@idfindetail,@idupbdetail,'secondaryvariation',@lessamountdetail				
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,@idupbdetail,@idunderwritingdetail,'secondaryvariation',@lessamountdetail
					END	
				
				END
				ELSE --(@newflagsecondaryprev = 'S')
				BEGIN
					EXEC trg_upd_upbtotal	@idfindetail ,	@idupbdetail,'secondaryvariation',	@amountdetail
					
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal @idfindetail,	@idupbdetail,@idunderwritingdetail,	'secondaryvariation',	@amountdetail
					END	
				END
			END
			
			
		
			
			IF (@variationkind = 5)AND (@oldflagsecondaryprev <> @newflagsecondaryprev) 
			BEGIN
				IF (@newflagsecondaryprev = 'N')
				BEGIN
				
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal @idfindetail,@idupbdetail,@idunderwritingdetail,'currentsecondaryprev',@lessamountdetail
					END	
				END
				ELSE --(@newflagprevision = 'S')
				BEGIN
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,@idupbdetail,	@idunderwritingdetail,'currentsecondaryprev',@amountdetail
					
					END	
				END				
			END
			
			
			-- Cambio FLAGCREDIT
			IF (@oldflagcredit <> @newflagcredit  and @finpart='S' and (@variationkind <> 5))
			BEGIN
				IF (@newflagcredit = 'N')
				BEGIN
					EXEC trg_upd_upbtotal	@idfindetail,	@idupbdetail,	'creditvariation',	@lessamountdetail
					
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal @idfindetail,@idupbdetail,@idunderwritingdetail,'creditvariation',	@lessamountdetail
					END	
				END
				ELSE --(@newflagcredit = 'S')
				BEGIN
				
					EXEC trg_upd_upbtotal	@idfindetail,@idupbdetail,'creditvariation',@amountdetail					
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,	@idupbdetail,@idunderwritingdetail,	'creditvariation',	@amountdetail
					END	
				END
			END
			
			
			-- Cambio FLAGPROCEEDS
			IF (@oldflagproceeds <> @newflagproceeds and @finpart='S' and (@variationkind <> 5))
			BEGIN
				IF (@newflagproceeds = 'N')
				BEGIN
					EXEC trg_upd_upbtotal @idfindetail, @idupbdetail,'proceedsvariation',	@lessamountdetail
					
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal @idfindetail,@idupbdetail,	@idunderwritingdetail,'proceedsvariation',	@lessamountdetail
					END	
				END
				ELSE --(@newflagproceeds = 'S')
				BEGIN
					EXEC trg_upd_upbtotal @idfindetail ,@idupbdetail,'proceedsvariation',@amountdetail
					
					IF (@idunderwritingdetail IS NOT NULL)
					BEGIN
						EXECUTE trg_upd_upbunderwritingtotal 	@idfindetail,@idupbdetail,@idunderwritingdetail,	'proceedsvariation',@amountdetail
					END	
				END
			END
			
			FETCH NEXT FROM #dettaglio INTO @idfindetail,@idupbdetail,@idunderwritingdetail,@amountdetail,@finpart
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




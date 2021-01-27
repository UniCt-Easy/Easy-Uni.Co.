
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_accountvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_accountvar]
GO

CREATE TRIGGER [trigger_u_accountvar] ON [accountvar] FOR UPDATE
AS BEGIN
	IF UPDATE(idaccountvarstatus)
	BEGIN
		DECLARE @yvar int
		DECLARE @nvar int
		DECLARE @variationkind tinyint
		DECLARE @oldidaccountvarstatus smallint
		DECLARE @newidaccountvarstatus  smallint
		DECLARE @newflagprevision char(1)
		DECLARE @oldflagprevision char(1)


   		SELECT 
		@yvar = yvar,
		@nvar = nvar,
		@variationkind = ISNULL(variationkind,0),
		@newidaccountvarstatus = ISNULL(idaccountvarstatus,0)
		FROM inserted
		SET @newflagprevision='S'
		if (@newidaccountvarstatus<>5) BEGIN
			SET @newflagprevision='N'
		END

		SELECT
			@oldidaccountvarstatus = ISNULL(idaccountvarstatus,0)
		FROM deleted

		SET @oldflagprevision='S'
		if (@oldidaccountvarstatus<>5) BEGIN
			SET @oldflagprevision='N'
		END
		
		DECLARE @idaccountdetail varchar(38)
		DECLARE @idupbdetail varchar(36)
		DECLARE @amountdetail decimal(19,2)
		DECLARE @amountdetail2 decimal(19,2)
		DECLARE @amountdetail3 decimal(19,2)
		DECLARE @amountdetail4 decimal(19,2)
		DECLARE @amountdetail5 decimal(19,2)
		
		
		DECLARE #dettaglio INSENSITIVE CURSOR FOR
		SELECT idacc,idupb,amount,amount2,amount3,amount4,amount5
				FROM accountvardetail 
				WHERE yvar = @yvar AND nvar = @nvar
		FOR READ ONLY
		OPEN #dettaglio

		FETCH NEXT FROM #dettaglio INTO @idaccountdetail, @idupbdetail,
				 @amountdetail,@amountdetail2,@amountdetail3,@amountdetail4,@amountdetail5
		WHILE(@@FETCH_STATUS = 0)
		BEGIN
			DECLARE @lessamountdetail decimal(19,2)
			DECLARE @lessamountdetail2 decimal(19,2)
			DECLARE @lessamountdetail3 decimal(19,2)
			DECLARE @lessamountdetail4 decimal(19,2)
			DECLARE @lessamountdetail5 decimal(19,2)

			SET @lessamountdetail = -@amountdetail
			SET @lessamountdetail2 = -@amountdetail2
			SET @lessamountdetail3 = -@amountdetail3
			SET @lessamountdetail4 = -@amountdetail4
			SET @lessamountdetail5 = -@amountdetail5
			-- Cambio FLAGPREVISION
			IF (@variationkind <>5)
			BEGIN
				IF (@oldflagprevision <> @newflagprevision) 
				BEGIN
					IF (@newflagprevision = 'N') 
					BEGIN			
						if (isnull(@lessamountdetail,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation',	@lessamountdetail
						if (isnull(@lessamountdetail2,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation2',@lessamountdetail2
						if (isnull(@lessamountdetail3,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation3',@lessamountdetail3
						if (isnull(@lessamountdetail4,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation4',@lessamountdetail4
						if (isnull(@lessamountdetail5,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation5',@lessamountdetail5											
					END
					ELSE --(@newflagprevision = 'S')
					BEGIN
						if (isnull(@amountdetail,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation',	@amountdetail
						if (isnull(@amountdetail2,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation2',@amountdetail2
						if (isnull(@amountdetail3,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation3',@amountdetail3
						if (isnull(@amountdetail4,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation4',@amountdetail4
						if (isnull(@amountdetail5,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'previsionvariation5',@amountdetail5
												
					END
				END
			END

			--IF (@variationkind = 5)
			--BEGIN
			--	IF (@oldflagprevision <> @newflagprevision)
			--	BEGIN
			--		IF (@newflagprevision = 'N') 
			--		BEGIN
			--			if (isnull(@lessamountdetail,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev',@lessamountdetail
			--			if (isnull(@lessamountdetail2,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev2',@lessamountdetail2
			--			if (isnull(@lessamountdetail3,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev3',@lessamountdetail3
			--			if (isnull(@lessamountdetail4,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev4',@lessamountdetail4
			--			if (isnull(@lessamountdetail5,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev5',@lessamountdetail5
			--		END
			--		ELSE --(@newflagprevision = 'S')
			--		BEGIN
			--			if (isnull(@amountdetail,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev',@amountdetail
			--			if (isnull(@amountdetail2,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev2',@amountdetail2
			--			if (isnull(@amountdetail3,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev3',@amountdetail3
			--			if (isnull(@amountdetail4,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev4',@amountdetail4
			--			if (isnull(@amountdetail5,0)<>0)  EXEC trg_upd_upbaccounttotal 	@idaccountdetail ,	@idupbdetail, 'currentprev5',@amountdetail5
			--		END
			--	END
			--END
			
			
			FETCH NEXT FROM #dettaglio INTO @idaccountdetail, @idupbdetail,
				 @amountdetail,@amountdetail2,@amountdetail3,@amountdetail4,@amountdetail5
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




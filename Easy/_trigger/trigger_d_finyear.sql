
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_finyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_finyear]
GO


CREATE TRIGGER [trigger_d_finyear] ON [finyear] FOR DELETE
AS BEGIN
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE	@prevision decimal(19, 2)
	DECLARE	@previousprevision decimal(19, 2)
	DECLARE	@secondaryprev decimal(19, 2)
	DECLARE	@previoussecondaryprev decimal(19, 2)
	DECLARE	@currentarrears decimal(19, 2)
	DECLARE	@previousarrears decimal(19, 2)
	DECLARE @ayear int

	SELECT	@idfin = idfin, @idupb = idupb,
	@prevision=-prevision, @previousprevision=-previousprevision, 
	@secondaryprev=-secondaryprev, @previoussecondaryprev=-previoussecondaryprev,
	@currentarrears=-currentarrears, @previousarrears=-previousarrears,
	@ayear = ayear
	FROM deleted
	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin
	DECLARE @minlevelop tinyint
	SELECT @minlevelop = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear

	IF (@nlevel <= @minlevelop)
	BEGIN
		EXEC trg_upd_upbextended @idfin,@idupb,@previousprevision,@prevision,@previoussecondaryprev,@secondaryprev,@previousarrears,@currentarrears
	END
		
	DECLARE @idfinincomesurplus int
	SELECT @idfinincomesurplus = idfinincomesurplus FROM config WHERE ayear = @ayear

	-- totalizza sugli UPB la previsione principale nel campo totprev di upbconstotal
	EXEC trg_totalizza_upbconstotal @idfin,@idupb, @prevision,'A'/*	I clienti non hanno questo trigger, rettorato_ok invece si. Affinchè non scatti il DB error al salvataggio di una	
																		previsione per la mancanza del parametro:
																		@A_I char(1) : A per approvata, I per inserita
																		che invece la sp trg_totalizza_upbconstotal richiede, gli passo 'A' .
																	*/
	
	DELETE FROM upbtotal WHERE idfin = @idfin and idupb = @idupb
	IF (@idfinincomesurplus = @idfin)
	BEGIN
		DECLARE @fin_kind tinyint

		SELECT @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear
		IF (@fin_kind = 3)
		BEGIN
			EXEC rebuild_currentfloatfund @ayear
		END
		IF (@fin_kind = 2)
		BEGIN
			EXEC rebuild_currentfloatfund @ayear
		END
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


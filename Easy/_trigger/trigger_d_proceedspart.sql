
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_proceedspart]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_proceedspart]
GO


CREATE  TRIGGER [trigger_d_proceedspart] ON [proceedspart] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @idinc int
	DECLARE @yproceedspart int
	DECLARE @amount decimal(19,2)
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @idunderwriting int

	SELECT
		@yproceedspart = yproceedspart, 
		@idfin = idfin, 
		@idupb = idupb,
		@idinc = idinc, 
		@amount = -amount
	FROM deleted
	
	SELECT
		@idunderwriting = idunderwriting
	FROM income  
	WHERE idinc = @idinc

	
	EXECUTE trg_upd_partitioned
	@yproceedspart,
	@idinc,
	0,
	@amount

	IF (@idfin IS NOT NULL) AND (@idupb IS NOT NULL)
	BEGIN
		EXECUTE trg_upd_upbtotal 
		@idfin, 
		@idupb,
		'totproceedspart', 
		@amount
	END
	
	IF (@idfin IS NOT NULL) AND (@idupb IS NOT NULL) AND (@idunderwriting IS NOT NULL)
	BEGIN
		EXECUTE trg_upd_upbunderwritingtotal 
		@idfin,
		@idupb,
		@idunderwriting,
		'totproceedspart',
		@amount
	END
END
END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


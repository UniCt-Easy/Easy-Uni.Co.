
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_invoice]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_invoice]
GO

CREATE  TRIGGER [trigger_d_invoice] ON invoice FOR DELETE
AS BEGIN
	DECLARE @idinvkind int
	DECLARE @yinv int
	DECLARE @ninv int
	
	SELECT	
	@idinvkind = idinvkind,
	@yinv = yinv,
	@ninv = ninv
	FROM deleted
	
	DELETE FROM incomeinvoice
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv
	
	DELETE FROM expenseinvoice
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv

	DELETE FROM pettycashoperationinvoice
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv
	
	UPDATE incomevar
	SET idinvkind = NULL, yinv = NULL, ninv = NULL, movkind = NULL
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv
	
	UPDATE expensevar
	SET idinvkind = NULL, yinv = NULL, ninv = NULL, movkind = NULL
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv

	DELETE FROM unifiedivaregister
	WHERE idinvkind = @idinvkind
	AND yinv = @yinv
	AND ninv = @ninv
	AND iddbdepartment = system_user
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


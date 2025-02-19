
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_billincomeexpenseview]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_billincomeexpenseview]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE                               PROCEDURE exp_billincomeexpenseview
	@kind char(1),	
	@ayear int,
	@start datetime,
	@stop datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
	BEGIN
		IF @kind = 'E'
			EXEC exp_billincomeview 
				@ayear,
				@start,
				@stop,
				@idsor01,
				@idsor02,
				@idsor03,
				@idsor04,
				@idsor05
		ELSE
			EXEC exp_billexpenseview 
				@ayear,
				@start,
				@stop,
				@idsor01,
				@idsor02,
				@idsor03,
				@idsor04,
				@idsor05
  END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



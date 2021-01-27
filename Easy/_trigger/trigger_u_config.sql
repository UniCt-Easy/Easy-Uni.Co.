
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_config]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_config]
GO


CREATE   TRIGGER [trigger_u_config] ON [config] FOR UPDATE
AS
BEGIN

declare @oldidfin int
declare @oldfinkind int
declare @newidfin int
declare @newfinkind int
declare @ayear smallint

SELECT	@oldidfin=idfinincomesurplus,
		@oldfinkind= isnull(fin_kind,0)
	FROM deleted

set @oldfinkind=isnull(@oldfinkind,99)
set @oldidfin= isnull(@oldidfin,0)


SELECT	@newidfin= isnull(idfinincomesurplus,0),
		@newfinkind= isnull(fin_kind,0),
		@ayear=ayear
	FROM inserted


if       (@oldfinkind<2 and @newfinkind>=2) OR  (@oldfinkind>=2 and @newfinkind<2)  OR 
		(@newfinkind>=2 AND @oldidfin<>@newidfin)
BEGIN
			EXEC rebuild_currentfloatfund @ayear
END


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



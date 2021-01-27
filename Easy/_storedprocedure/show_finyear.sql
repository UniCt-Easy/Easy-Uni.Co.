
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [show_finyear]
(
	@date datetime,
	@idupb varchar(36),
	@idfin int,
	@finpart char(1)
)
AS BEGIN
DECLARE @fin_kind tinyint
DECLARE @ayear int
SELECT @ayear = YEAR(@date)

SELECT @fin_kind = ISNULL(fin_kind,0)
FROM config
WHERE ayear = @ayear
IF (@fin_kind = 1)
BEGIN
	EXEC show_finyear_comp @date,@idupb,@idfin,@finpart
END
IF (@fin_kind = 3)
BEGIN
	EXEC show_finyear_compcash @date,@idupb,@idfin,@finpart
END
IF (@fin_kind = 2)
BEGIN
	EXEC show_finyear_onlycash @date,@idupb,@idfin,@finpart
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


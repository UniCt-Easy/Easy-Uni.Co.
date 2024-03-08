
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_fin]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [show_fin]
(
	@date datetime,
	@idfin int ,
	@finpart char(1)
)
AS BEGIN
--DECLARE @prevision char(1)
--DECLARE @secondaryprev char(1)
DECLARE @fin_kind tinyint
DECLARE @ayear int
SELECT @ayear = YEAR(@date)
SELECT @fin_kind = fin_kind
FROM config
WHERE ayear = @ayear
IF (@fin_kind = 1)
BEGIN
	EXEC show_fin_comp @date,@idfin,@finpart
END
IF (@fin_kind = 3)
BEGIN
	EXEC show_fin_compcash @date,@idfin,@finpart
END
IF (@fin_kind = 2)
BEGIN
	EXEC show_fin_onlycash @date,@idfin,@finpart
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


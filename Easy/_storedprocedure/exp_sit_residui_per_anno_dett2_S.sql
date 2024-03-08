
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sit_residui_per_anno_dett2_S]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sit_residui_per_anno_dett2_S]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE[exp_sit_residui_per_anno_dett2_S]
	@ayear 		int,
	@date		datetime,
	-- @finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN
EXEC [rpt_sit_residui_per_anno_dett2] @ayear,@date,'S',@levelusable,@idupb,@showupb,@showchildupb
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
 

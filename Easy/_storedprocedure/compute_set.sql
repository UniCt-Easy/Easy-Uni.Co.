
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_set]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_set]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE compute_set
(
	@ayear int,
	@iduser varchar(50),
	@idflowchart varchar(34),
	@varname varchar(30)
)
AS BEGIN

CREATE TABLE #outtable
(
	yn char(1),
	mustquote char(1)
)

IF (@idflowchart IS NULL)
BEGIN
	INSERT INTO #outtable VALUES('S','S')
	SELECT yn,mustquote FROM #outtable
	RETURN
END

DECLARE @nrowfound int
SET @nrowfound =
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = @varname)

IF (@nrowfound > 0)
BEGIN
	INSERT INTO #outtable VALUES('S','S')
	SELECT yn,mustquote FROM #outtable
END
ELSE
BEGIN
	INSERT INTO #outtable VALUES('N','S')
	SELECT yn,mustquote FROM #outtable
END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

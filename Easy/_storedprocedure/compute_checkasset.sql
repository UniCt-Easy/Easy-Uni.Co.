
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_checkasset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_checkasset]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE compute_checkasset
(
	@idinventory int,
        @startnumber int,
	@number int,
	@is_ok char(1) output
)
AS BEGIN
DECLARE @counter int
SELECT @counter = @startnumber
SELECT @is_ok = 'S'
WHILE @counter < @startnumber + @number
BEGIN
	IF NOT EXISTS
		(SELECT * FROM assetview
		WHERE idinventory = @idinventory
			AND ninventory = @counter
			AND idassetunload IS NULL)
	BEGIN
		SELECT @is_ok = 'N'
		RETURN
	END
	SELECT @counter = @counter + 1
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


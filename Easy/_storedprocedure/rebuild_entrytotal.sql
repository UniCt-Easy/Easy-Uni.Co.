
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_entrytotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_entrytotal]
GO
-- exec rebuild_entrytotal 
-- select * from entrytotal
CREATE     PROCEDURE [rebuild_entrytotal]
(
	@ayear int = null
)
AS BEGIN

	IF (@ayear IS NULL) 
	BEGIN
		DELETE FROM entrytotal

		INSERT INTO entrytotal (yentry, nentry, amount) 
		SELECT   yentry, nentry, isnull(sum(amount),0)
		FROM entrydetail  
		GROUP BY yentry, nentry

	END
	ELSE -- @ayear specificato
	BEGIN 
		DELETE FROM entrytotal WHERE yentry = @ayear

		INSERT INTO entrytotal (yentry, nentry, amount) 
		SELECT   yentry, nentry, isnull(sum(amount),0)
		FROM entrydetail  
		WHERE yentry = @ayear
		GROUP BY yentry, nentry

	END

	
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

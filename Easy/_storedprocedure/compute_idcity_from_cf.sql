
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_idcity_from_cf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_idcity_from_cf]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [compute_idcity_from_cf] (
	@codecity varchar(4), 
	@idcity int output
)
AS BEGIN
CREATE TABLE #city (idcity int, oldcity int, newcity int)
INSERT INTO #city (idcity, oldcity, newcity)
SELECT ce.idcity, c.oldcity, c.newcity
FROM geo_city_agency ce 
JOIN geo_city c
	ON ce.idcity = c.idcity
WHERE ce.value = @codecity
	AND ce.idagency = 1
	AND ce.idcode = 1
IF(SELECT COUNT(*) FROM #city) = 1
BEGIN
	SELECT @idcity = idcity FROM #city
	RETURN
END
DECLARE @old int
DECLARE @new int
DECLARE @cursore cursor 
SET @cursore = CURSOR FOR SELECT * FROM #city
OPEN @cursore
FETCH NEXT FROM @cursore INTO @idcity, @old, @new
WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF NOT EXISTS(SELECT * FROM #city WHERE idcity = @new OR oldcity = @idcity)
	BEGIN
		RETURN
	END
	FETCH NEXT FROM @cursore INTO @idcity, @old, @new
END
DECLARE @count int
SELECT @count = COUNT(*)
FROM geo_city_agency ce 
JOIN geo_cityusable c
	ON c.idcity=ce.idcity
WHERE ce.value = @codecity
	AND ce.idagency=1
	AND ce.idcode=1
IF (@count=1)
BEGIN
	SELECT @idcity=ce.idcity 
	FROM geo_city_agency ce 
	JOIN geo_cityusable c
		ON c.idcity=ce.idcity
	WHERE ce.value = @codecity
		AND ce.idagency=1
		AND ce.idcode=1
	RETURN
END
SET @idcity = NULL
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


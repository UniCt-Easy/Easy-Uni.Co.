
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


if exists (select * from dbo.sysobjects where id = object_id(N'[find_agencycode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [find_agencycode]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE              PROCEDURE [find_agencycode]
(@idgeo INT,
@idente INT, 
@idcodice INT,
@tipo CHAR(1))
AS
BEGIN
	--comune
	IF @tipo IS NULL OR UPPER(@tipo) = 'C'
	BEGIN
		SELECT value FROM geo_city_agency 
		WHERE idcity=@idgeo AND idagency=@idente and idcode=@idcodice
		ORDER BY value ASC
		RETURN
	END
	--provincia
	IF UPPER(@tipo) = 'P'
	BEGIN
		SELECT value FROM geo_country_agency 
		WHERE idcountry=@idgeo AND idagency=@idente and idcode=@idcodice
		ORDER BY value ASC
		RETURN
	END
	--regione
	IF UPPER(@tipo) = 'R'
	BEGIN
		SELECT value FROM geo_region_agency 
		WHERE idregion = @idgeo AND idagency=@idente and idcode=@idcodice
		ORDER BY value ASC
		RETURN
	END
	--nazione
	IF UPPER(@tipo) = 'N'
	BEGIN
		SELECT value FROM geo_nation_agency 
		WHERE idnation = @idgeo AND idagency=@idente and idcode=@idcodice
		ORDER BY value ASC
		RETURN
	END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


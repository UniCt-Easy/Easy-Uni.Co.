
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_idnation_from_cf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_idnation_from_cf]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [compute_idnation_from_cf] (
	@codenation varchar(4), 
	@idnation int output
)
AS BEGIN
DECLARE @ultimadatafine datetime
SELECT @ultimadatafine = MAX(ISNULL(stop, {d '2079-06-06'}))
FROM geo_nation_agency g2
WHERE idcode = 1
	AND idagency=1
	AND value = @codenation
SELECT @idnation = idnation 
FROM geo_nation_agency 
WHERE idcode = 1
	AND idagency = 1
	AND value = @codenation
	AND ISNULL(stop, {d '2079-06-06'}) = @ultimadatafine
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


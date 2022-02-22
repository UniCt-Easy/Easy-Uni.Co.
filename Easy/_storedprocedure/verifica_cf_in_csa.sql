
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[verifica_cf_in_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [dbo].[verifica_cf_in_csa]

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO

-- exec [verifica_cf_in_csa_test]

/*
CREATE TABLE importAnagrRecord800
(
lastmatr varchar(40),
ct datetime,
cu varchar(64),
lt datetime,
lu varchar(64),
kind char(1)
)

*/
CREATE PROCEDURE [dbo].[verifica_cf_in_csa](
    @cf varchar(16),
    @employkind char(1)
)

AS BEGIN

DECLARE @origine_dato varchar(3)

IF (@employkind = 'D') begin SET @origine_dato = '049' end
IF (@employkind = 'A') begin SET @origine_dato = '849' end


CREATE TABLE #result (count_cf INT)

INSERT INTO #result(count_cf)
SELECT COUNT(*) FROM  EASY_ANAGRAFICA_8000 
WHERE  CF =  @CF AND ORIGINE_DATO =  @origine_dato

SELECT count_cf FROM #result

END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

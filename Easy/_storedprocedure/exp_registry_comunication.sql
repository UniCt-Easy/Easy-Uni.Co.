
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registry_comunication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registry_comunication]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
-- exp_registry_comunication '01',null
CREATE    PROCEDURE [exp_registry_comunication]
(
	@idregistryclass varchar(2),
	@title varchar(100)
)
AS
BEGIN

IF @title IS NULL SET @title='%'

SELECT 
	r.idreg as "Codice", 
	rc.description as 'Tipologia di Anagrafica',
	r.title as 'Denominazione',
	CASE
		WHEN (r.cf is not null) THEN r.cf 
		WHEN (r.cf is null) AND (r.foreigncf is NOT NULL) THEN r.foreigncf
	END as 'Codice Fiscale',
	r.p_iva AS 'Partita Iva',
	a.description as 'Tipo di indirizzo',
	ra.officename as 'Ufficio',
	ra.address as 'Indirizzo',
	CASE 
		WHEN (ra.idcity is not null) THEN gc.title 
		WHEN (ra.idcity is null) AND (ra.idnation is NOT NULL) THEN gn.title
	END AS 'Città',
	ra.cap as 'C.A.P.',
	ra.location as 'Località',
	rr.email as 'e-mail'
FROM registry r
	JOIN registryclass rc				ON r.idregistryclass = rc.idregistryclass
	JOIN registryaddress ra				ON r.idreg = ra.idreg
	JOIN address a						ON ra.idaddresskind = a.idaddress
	LEFT OUTER JOIN geo_city gc			ON ra.idcity = gc.idcity
	LEFT OUTER JOIN geo_nation gn		ON ra.idnation = gn.idnation
	LEFT OUTER JOIN registryreference rr		ON r.idreg = rr.idreg	AND rr.flagdefault='S'
WHERE (rc.idregistryclass = @idregistryclass OR @idregistryclass IS NULL)
AND ra.active ='S'
AND a.codeaddress = '07_SW_DEF'
AND ra.stop IS NULL
AND r.active ='S'
AND r.title like @title
ORDER BY rc.description, r.title

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


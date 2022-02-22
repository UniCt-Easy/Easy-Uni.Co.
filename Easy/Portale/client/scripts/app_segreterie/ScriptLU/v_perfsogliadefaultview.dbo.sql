
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


-- CREAZIONE VISTA perfsogliadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfsogliadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfsogliadefaultview]
GO

CREATE VIEW [dbo].[perfsogliadefaultview] AS 
SELECT  perfsoglia.ct AS perfsoglia_ct, perfsoglia.cu AS perfsoglia_cu, perfsoglia.idperfsoglia,
 [dbo].perfsogliakind.idperfsogliakind AS perfsogliakind_idperfsogliakind, perfsoglia.idperfsogliakind, perfsoglia.lt AS perfsoglia_lt, perfsoglia.lu AS perfsoglia_lu, perfsoglia.valore AS perfsoglia_valore,
 [dbo].year.year AS year_year, perfsoglia.year AS perfsoglia_year
FROM [dbo].perfsoglia WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfsogliakind WITH (NOLOCK) ON perfsoglia.idperfsogliakind = [dbo].perfsogliakind.idperfsogliakind
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfsoglia.year = [dbo].year.year
WHERE  perfsoglia.idperfsoglia IS NOT NULL 
GO


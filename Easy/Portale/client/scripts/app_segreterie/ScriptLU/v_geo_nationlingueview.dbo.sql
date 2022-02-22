
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


-- CREAZIONE VISTA geo_nationlingueview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nationlingueview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_nationlingueview]
GO

CREATE VIEW [dbo].[geo_nationlingueview] AS 
SELECT 
 [dbo].geo_continent.title AS geo_continent_title, geo_nation.idcontinent, geo_nation.idnation, geo_nation.lang, geo_nation.lt AS geo_nation_lt, geo_nation.lu AS geo_nation_lu,
 geo_nation_1.title AS geo_nation_1_title, geo_nation.newnation,
 geo_nation_2.title AS geo_nation_2_title, geo_nation.oldnation, geo_nation.start AS geo_nation_start, geo_nation.stop AS geo_nation_stop, geo_nation.title AS geo_nation_title,
 isnull('Lingua: ' + geo_nation.lang + '; ','') as dropdown_title
FROM [dbo].geo_nation WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_continent WITH (NOLOCK) ON geo_nation.idcontinent = [dbo].geo_continent.idcontinent
LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_1 WITH (NOLOCK) ON geo_nation.newnation = geo_nation_1.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_2 WITH (NOLOCK) ON geo_nation.oldnation = geo_nation_2.idnation
WHERE  geo_nation.idnation IS NOT NULL  AND geo_nation.lang <> ''
GO


-- GENERAZIONE DATI PER geo_nationlingueview --

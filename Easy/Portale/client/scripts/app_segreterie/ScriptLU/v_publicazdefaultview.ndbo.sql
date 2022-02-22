
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


-- CREAZIONE VISTA publicazdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[publicazdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [publicazdefaultview]
GO

CREATE VIEW [publicazdefaultview] AS 
SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo,
 [dbo].geo_city.title AS geo_city_title, publicaz.idcity,
 geo_cityed.title AS geo_cityed_title, publicaz.idcity_ed,
 geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed,
 geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang,
 progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume,
 isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title
FROM [dbo].publicaz WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON publicaz.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_city AS geo_cityed WITH (NOLOCK) ON publicaz.idcity_ed = geo_cityed.idcity
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto
WHERE  publicaz.idpublicaz IS NOT NULL 
GO


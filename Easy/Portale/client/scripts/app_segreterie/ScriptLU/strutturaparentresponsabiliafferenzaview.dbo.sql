
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


-- CREAZIONE VISTA strutturaparentresponsabiliafferenzaview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentresponsabiliafferenzaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
GO






CREATE VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
AS
SELECT  v.idstruttura, v.title, s.idstruttura AS idstruttura_parent, s.title AS titlestrutturaparent, r.idreg, r.title AS registry_title,
sr.start as strutturaresponsabile_start, sr.stop as strutturaresponsabile_stop,  sr.idperfruolo, a.idreg as afferente_idreg, ra.title as afferente_title, a.start, a.stop
FROM  dbo.strutturaparentview AS v INNER JOIN
dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
dbo.strutturaresponsabile as sr on s.idstruttura = sr.idstruttura LEFT OUTER JOIN
dbo.registry AS r ON r.idreg = sr.idreg LEFT OUTER JOIN
dbo.afferenza as a on a.idstruttura = s.idstruttura LEFT OUTER JOIN
dbo.registry AS ra ON ra.idreg = a.idreg 





GO


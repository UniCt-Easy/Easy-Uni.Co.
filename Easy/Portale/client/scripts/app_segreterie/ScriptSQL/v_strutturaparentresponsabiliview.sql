
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


USE [unibas_easy]
GO

/****** Object:  View [dbo].[strutturaparentresponsabiliview]    Script Date: 02/12/2021 08:54:39 ******/
DROP VIEW [dbo].[strutturaparentresponsabiliview]
GO

/****** Object:  View [dbo].[strutturaparentresponsabiliview]    Script Date: 02/12/2021 08:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[strutturaparentresponsabiliview]
AS
SELECT  v.idstruttura, v.title, s.idstruttura AS idstruttura_parent, s.title AS titlestrutturaparent, r.idreg , r.title AS registry_title, sr.idperfruolo, a.start, a.stop
FROM    dbo.strutturaparentview AS v INNER JOIN
dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
dbo.strutturaresponsabile as sr on s.idstruttura = sr.idstruttura LEFT OUTER JOIN
dbo.registry AS r ON r.idreg = sr.idreg LEFT OUTER JOIN
dbo.afferenza as a on a.idreg = r.idreg
GO


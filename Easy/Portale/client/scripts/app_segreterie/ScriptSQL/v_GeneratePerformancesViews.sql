
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


/****** Object:  View [dbo].[strutturaparentview]    Script Date: 10/11/2021 10:37:12 ******/
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentview]
GO

CREATE VIEW [dbo].[strutturaparentview]
AS
WITH cte_org AS (SELECT        ';' + CAST(ISNULL(idstruttura, 0) AS varchar(MAX)) + ';' AS ramo, idstruttura, title, paridstruttura
                                       FROM            dbo.struttura
                                       WHERE        (paridstruttura IS NULL)
                                       UNION ALL
                                       SELECT        ';' + CAST(ISNULL(e.idstruttura, 0) AS varchar(MAX)) + o.ramo AS ramo, e.idstruttura, e.title, e.paridstruttura
                                       FROM            dbo.struttura AS e INNER JOIN
                                                                cte_org AS o ON o.idstruttura = e.paridstruttura)
    SELECT        ramo, idstruttura, title, paridstruttura
     FROM            cte_org AS cte_org_1
GO


/****** Object:  View [dbo].[strutturaparentresponsabiliview]    Script Date: 10/11/2021 10:37:00 ******/
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentresponsabiliview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentresponsabiliview]
GO

CREATE VIEW [dbo].[strutturaparentresponsabiliview]
AS
SELECT        v.idstruttura, v.title, s.idstruttura AS strutturaparent, s.title AS titlestrutturaparent, s.idreg_resp, r.title AS responsabile, s.idreg_valut, va.title AS valutatore, s.idreg_appr, ap.title AS approvatore
FROM            dbo.strutturaparentview AS v INNER JOIN
                         dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
                         dbo.registry AS r ON r.idreg = s.idreg_resp LEFT OUTER JOIN
                         dbo.registry AS va ON va.idreg = s.idreg_valut LEFT OUTER JOIN
                         dbo.registry AS ap ON ap.idreg = s.idreg_appr
GO

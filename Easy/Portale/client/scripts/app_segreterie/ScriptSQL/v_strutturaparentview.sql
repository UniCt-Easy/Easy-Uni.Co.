
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

/****** Object:  View [dbo].[strutturaparentview]    Script Date: 02/12/2021 08:55:06 ******/
DROP VIEW [dbo].[strutturaparentview]
GO

/****** Object:  View [dbo].[strutturaparentview]    Script Date: 02/12/2021 08:55:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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



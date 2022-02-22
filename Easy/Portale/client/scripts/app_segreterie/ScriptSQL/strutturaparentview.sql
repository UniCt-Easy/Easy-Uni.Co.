
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


-- CREAZIONE VISTA strutturaparentview
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

-- VERIFICA DI strutturaparentview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'strutturaparentview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentview','int','Generator','idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentview','int','Generator','paridstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentview','varchar(max)','Generator','ramo','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentview','varchar(1024)','Generator','title','1024','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI strutturaparentview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'strutturaparentview')
UPDATE customobject set isreal = 'N' where objectname = 'strutturaparentview'
ELSE
INSERT INTO customobject (objectname, isreal) values('strutturaparentview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


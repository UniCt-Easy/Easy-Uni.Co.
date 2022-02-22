
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


-- CREAZIONE VISTA affidamentokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentokinddefaultview]
GO

CREATE VIEW [dbo].[affidamentokinddefaultview] AS 
SELECT CASE WHEN affidamentokind.active = 'S' THEN 'Si' WHEN affidamentokind.active = 'N' THEN 'No' END AS affidamentokind_active, affidamentokind.costoora AS affidamentokind_costoora,CASE WHEN affidamentokind.costoorariodacontratto = 'S' THEN 'Si' WHEN affidamentokind.costoorariodacontratto = 'N' THEN 'No' END AS affidamentokind_costoorariodacontratto, affidamentokind.ct AS affidamentokind_ct, affidamentokind.cu AS affidamentokind_cu, affidamentokind.description AS affidamentokind_description, affidamentokind.idaffidamentokind, affidamentokind.lt AS affidamentokind_lt, affidamentokind.lu AS affidamentokind_lu, affidamentokind.sortcode AS affidamentokind_sortcode, affidamentokind.title,
 isnull('Tipologia: ' + affidamentokind.title + '; ','') as dropdown_title
FROM [dbo].affidamentokind WITH (NOLOCK) 
WHERE  affidamentokind.idaffidamentokind IS NOT NULL 
GO

-- VERIFICA DI affidamentokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokinddefaultview','varchar(2)','ASSISTENZA','affidamentokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokinddefaultview','decimal(9,2)','ASSISTENZA','affidamentokind_costoora','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentokinddefaultview','varchar(2)','ASSISTENZA','affidamentokind_costoorariodacontratto','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','datetime','ASSISTENZA','affidamentokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','varchar(64)','ASSISTENZA','affidamentokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','varchar(256)','ASSISTENZA','affidamentokind_description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','datetime','ASSISTENZA','affidamentokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','varchar(64)','ASSISTENZA','affidamentokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','int','ASSISTENZA','affidamentokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','int','ASSISTENZA','idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'affidamentokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER affidamentokinddefaultview --
-- FINE GENERAZIONE SCRIPT --



/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA perfschedastatusdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedastatusdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfschedastatusdefaultview]
GO

CREATE VIEW [dbo].[perfschedastatusdefaultview] AS 
SELECT CASE WHEN perfschedastatus.active = 'S' THEN 'Si' WHEN perfschedastatus.active = 'N' THEN 'No' END AS perfschedastatus_active, perfschedastatus.ct AS perfschedastatus_ct, perfschedastatus.cu AS perfschedastatus_cu, perfschedastatus.description AS perfschedastatus_description, perfschedastatus.idperfschedastatus, perfschedastatus.lt AS perfschedastatus_lt, perfschedastatus.lu AS perfschedastatus_lu, perfschedastatus.title,
 isnull('Stato: ' + perfschedastatus.title + '; ','') as dropdown_title
FROM [dbo].perfschedastatus WITH (NOLOCK) 
WHERE  perfschedastatus.idperfschedastatus IS NOT NULL 
GO

-- VERIFICA DI perfschedastatusdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedastatusdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','varchar(1033)','ASSISTENZA','dropdown_title','1033','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','int','ASSISTENZA','idperfschedastatus','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatusdefaultview','varchar(2)','ASSISTENZA','perfschedastatus_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','datetime','ASSISTENZA','perfschedastatus_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','varchar(64)','ASSISTENZA','perfschedastatus_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatusdefaultview','varchar(max)','ASSISTENZA','perfschedastatus_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','datetime','ASSISTENZA','perfschedastatus_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedastatusdefaultview','varchar(64)','ASSISTENZA','perfschedastatus_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedastatusdefaultview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI perfschedastatusdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedastatusdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfschedastatusdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedastatusdefaultview', 'N')
GO

-- GENERAZIONE DATI PER perfschedastatusdefaultview --
-- FINE GENERAZIONE SCRIPT --

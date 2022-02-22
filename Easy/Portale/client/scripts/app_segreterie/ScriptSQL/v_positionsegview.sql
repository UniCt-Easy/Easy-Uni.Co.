
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


-- CREAZIONE VISTA positionsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[positionsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[positionsegview]
GO

CREATE VIEW [dbo].[positionsegview] AS 
SELECT CASE WHEN position.active = 'S' THEN 'Si' WHEN position.active = 'N' THEN 'No' END AS position_active, position.codeposition AS position_codeposition, position.ct AS position_ct, position.cu AS position_cu, position.description,CASE WHEN position.foreignclass = 'S' THEN 'Si' WHEN position.foreignclass = 'N' THEN 'No' END AS position_foreignclass, position.idposition, position.lt AS position_lt, position.lu AS position_lu, position.maxincomeclass AS position_maxincomeclass
FROM [dbo].position WITH (NOLOCK) 
WHERE  position.idposition IS NOT NULL 
GO

-- VERIFICA DI positionsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'positionsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','varchar(50)','ASSISTENZA','description','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','int','ASSISTENZA','idposition','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionsegview','varchar(2)','ASSISTENZA','position_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','varchar(20)','ASSISTENZA','position_codeposition','20','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','datetime','ASSISTENZA','position_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','varchar(64)','ASSISTENZA','position_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionsegview','varchar(2)','ASSISTENZA','position_foreignclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','datetime','ASSISTENZA','position_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionsegview','varchar(64)','ASSISTENZA','position_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionsegview','smallint','ASSISTENZA','position_maxincomeclass','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI positionsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'positionsegview')
UPDATE customobject set isreal = 'N' where objectname = 'positionsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('positionsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


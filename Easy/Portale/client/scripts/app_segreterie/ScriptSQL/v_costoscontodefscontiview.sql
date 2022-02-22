
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


-- CREAZIONE VISTA costoscontodefscontiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[costoscontodefscontiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[costoscontodefscontiview]
GO

CREATE VIEW [dbo].[costoscontodefscontiview] AS 
SELECT  costoscontodef.ct AS costoscontodef_ct, costoscontodef.cu AS costoscontodef_cu, costoscontodef.idcostoscontodef, costoscontodef.idcostoscontodefkind AS costoscontodef_idcostoscontodefkind, costoscontodef.lt AS costoscontodef_lt, costoscontodef.lu AS costoscontodef_lu,
 costoscontodefparent.title AS costoscontodefparent_title, costoscontodef.paridcostoscontodef, costoscontodef.title,
 isnull('Titolo: ' + costoscontodef.title + '; ','') as dropdown_title
FROM [dbo].costoscontodef WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].costoscontodef AS costoscontodefparent WITH (NOLOCK) ON costoscontodef.paridcostoscontodef = costoscontodefparent.idcostoscontodef
WHERE  costoscontodef.idcostoscontodef IS NOT NULL 
GO

-- VERIFICA DI costoscontodefscontiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'costoscontodefscontiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','datetime','ASSISTENZA','costoscontodef_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','varchar(64)','ASSISTENZA','costoscontodef_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefscontiview','int','ASSISTENZA','costoscontodef_idcostoscontodefkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','datetime','ASSISTENZA','costoscontodef_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','varchar(64)','ASSISTENZA','costoscontodef_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','nvarchar(2024)','ASSISTENZA','costoscontodefparent_title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefscontiview','nvarchar(2034)','ASSISTENZA','dropdown_title','2034','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','costoscontodefscontiview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','int','ASSISTENZA','paridcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','costoscontodefscontiview','nvarchar(2024)','ASSISTENZA','title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI costoscontodefscontiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'costoscontodefscontiview')
UPDATE customobject set isreal = 'N' where objectname = 'costoscontodefscontiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('costoscontodefscontiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


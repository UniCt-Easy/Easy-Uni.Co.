
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


-- CREAZIONE VISTA assetdiaryorasegsalview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryorasegsalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiaryorasegsalview]
GO

CREATE VIEW [assetdiaryorasegsalview] AS SELECT  assetdiaryora.amount AS assetdiaryora_amount, assetdiaryora.ct AS assetdiaryora_ct, assetdiaryora.cu AS assetdiaryora_cu, assetdiaryora.idassetdiary, assetdiaryora.idassetdiaryora, sal.start AS sal_start, sal.stop AS sal_stop, assetdiaryora.idsal, assetdiaryora.idworkpackage, assetdiaryora.lt AS assetdiaryora_lt, assetdiaryora.lu AS assetdiaryora_lu, assetdiaryora.start AS assetdiaryora_start, assetdiaryora.stop AS assetdiaryora_stop FROM assetdiaryora WITH (NOLOCK)  LEFT OUTER JOIN sal WITH (NOLOCK) ON assetdiaryora.idsal = sal.idsal WHERE  assetdiaryora.idassetdiary IS NOT NULL  AND assetdiaryora.idassetdiaryora IS NOT NULL  AND assetdiaryora.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI assetdiaryorasegsalview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiaryorasegsalview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','decimal(9,2)','ASSISTENZA','assetdiaryora_amount','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','datetime','ASSISTENZA','assetdiaryora_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','varchar(64)','ASSISTENZA','assetdiaryora_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','datetime','ASSISTENZA','assetdiaryora_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','varchar(64)','ASSISTENZA','assetdiaryora_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','datetime','ASSISTENZA','assetdiaryora_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','datetime','ASSISTENZA','assetdiaryora_stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','int','','idassetdiary','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','int','','idassetdiaryora','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','int','','idsal','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryorasegsalview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','date','','sal_start','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryorasegsalview','date','','sal_stop','3','N','date','System.DateTime','','','','','N')
GO

-- VERIFICA DI assetdiaryorasegsalview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiaryorasegsalview')
UPDATE customobject set isreal = 'N' where objectname = 'assetdiaryorasegsalview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiaryorasegsalview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


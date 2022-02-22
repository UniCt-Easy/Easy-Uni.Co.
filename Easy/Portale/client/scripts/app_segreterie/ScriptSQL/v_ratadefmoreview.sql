
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


--[DBO]--
-- CREAZIONE VISTA ratadefmoreview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ratadefmoreview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ratadefmoreview]
GO

CREATE VIEW [dbo].[ratadefmoreview] AS SELECT  ratadef.ct AS ratadef_ct, ratadef.cu AS ratadef_cu, ratadef.decorrenza AS ratadef_decorrenza, ratadef.idcostoscontodef, ratadef.idfasciaiseedef, ratadef.idratadef, ratadef.idratakind, ratadef.lt AS ratadef_lt, ratadef.lu AS ratadef_lu, ratadef.scadenza AS ratadef_scadenza, isnull('Tipologia: ' + ratadef.idratakind + '; ','') as dropdown_title FROM [dbo].ratadef WITH (NOLOCK)  WHERE  ratadef.idcostoscontodef IS NOT NULL  AND ratadef.idfasciaiseedef IS NOT NULL  AND ratadef.idratadef IS NOT NULL 
GO

-- VERIFICA DI ratadefmoreview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ratadefmoreview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','int','ASSISTENZA','idfasciaiseedef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','int','ASSISTENZA','idratadef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefmoreview','varchar(50)','ASSISTENZA','idratakind','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','datetime','ASSISTENZA','ratadef_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','varchar(64)','ASSISTENZA','ratadef_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefmoreview','datetime','ASSISTENZA','ratadef_decorrenza','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','datetime','ASSISTENZA','ratadef_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefmoreview','varchar(64)','ASSISTENZA','ratadef_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefmoreview','datetime','ASSISTENZA','ratadef_scadenza','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ratadefmoreview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ratadefmoreview')
UPDATE customobject set isreal = 'N' where objectname = 'ratadefmoreview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ratadefmoreview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


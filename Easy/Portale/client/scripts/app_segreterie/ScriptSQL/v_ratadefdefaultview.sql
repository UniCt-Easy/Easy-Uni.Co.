
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
-- CREAZIONE VISTA ratadefdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[ratadefdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ratadefdefaultview]
GO

CREATE VIEW [dbo].[ratadefdefaultview] AS SELECT  ratadef.ct AS ratadef_ct, ratadef.cu AS ratadef_cu, ratadef.decorrenza AS ratadef_decorrenza, ratadef.idcostoscontodef, ratadef.idfasciaiseedef, ratadef.idratadef, ratadef.idratakind, ratadef.lt AS ratadef_lt, ratadef.lu AS ratadef_lu, ratadef.scadenza AS ratadef_scadenza, isnull('Tipologia: ' + ratadef.idratakind + '; ','') as dropdown_title FROM [dbo].ratadef WITH (NOLOCK)  WHERE  ratadef.idcostoscontodef IS NOT NULL  AND ratadef.idfasciaiseedef IS NOT NULL  AND ratadef.idratadef IS NOT NULL 
GO

-- VERIFICA DI ratadefdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'ratadefdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','int','ASSISTENZA','idcostoscontodef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','int','ASSISTENZA','idfasciaiseedef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','int','ASSISTENZA','idratadef','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefdefaultview','varchar(50)','ASSISTENZA','idratakind','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','datetime','ASSISTENZA','ratadef_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','varchar(64)','ASSISTENZA','ratadef_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefdefaultview','datetime','ASSISTENZA','ratadef_decorrenza','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','datetime','ASSISTENZA','ratadef_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','ratadefdefaultview','varchar(64)','ASSISTENZA','ratadef_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','ratadefdefaultview','datetime','ASSISTENZA','ratadef_scadenza','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI ratadefdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'ratadefdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'ratadefdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('ratadefdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


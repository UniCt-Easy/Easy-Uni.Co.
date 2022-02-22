
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


-- CREAZIONE VISTA creditosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[creditosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[creditosegview]
GO

CREATE VIEW [dbo].[creditosegview] AS 
SELECT CASE WHEN credito.autorizzato = 'S' THEN 'Si' WHEN credito.autorizzato = 'N' THEN 'No' END AS credito_autorizzato, credito.ct AS credito_ct, credito.cu AS credito_cu, credito.idcredito, credito.iddebito, credito.idpagamento, credito.idreg, credito.lt AS credito_lt, credito.lu AS credito_lu
FROM [dbo].credito WITH (NOLOCK) 
WHERE  credito.idcredito IS NOT NULL  AND credito.iddebito IS NOT NULL  AND credito.idpagamento IS NOT NULL  AND credito.idreg IS NOT NULL 
GO

-- VERIFICA DI creditosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'creditosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','creditosegview','varchar(2)','ASSISTENZA','credito_autorizzato','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','datetime','ASSISTENZA','credito_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','varchar(64)','ASSISTENZA','credito_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','datetime','ASSISTENZA','credito_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','varchar(64)','ASSISTENZA','credito_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','int','ASSISTENZA','idcredito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','int','ASSISTENZA','iddebito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','int','ASSISTENZA','idpagamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','creditosegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI creditosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'creditosegview')
UPDATE customobject set isreal = 'N' where objectname = 'creditosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('creditosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA restrictedfunctionsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[restrictedfunctionsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[restrictedfunctionsegview]
GO

CREATE VIEW [dbo].[restrictedfunctionsegview] AS 
SELECT  restrictedfunction.ct AS restrictedfunction_ct, restrictedfunction.cu AS restrictedfunction_cu, restrictedfunction.description, restrictedfunction.idrestrictedfunction, restrictedfunction.lt AS restrictedfunction_lt, restrictedfunction.lu AS restrictedfunction_lu, restrictedfunction.variablename AS restrictedfunction_variablename,
 isnull('Descrizione: ' + restrictedfunction.description + '; ','') + ' ' + isnull('Variabile: ' + restrictedfunction.variablename + '; ','') as dropdown_title
FROM [dbo].restrictedfunction WITH (NOLOCK) 
WHERE  restrictedfunction.idrestrictedfunction IS NOT NULL 
GO

-- VERIFICA DI restrictedfunctionsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'restrictedfunctionsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','varchar(100)','ASSISTENZA','description','100','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','varchar(179)','ASSISTENZA','dropdown_title','179','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','int','ASSISTENZA','idrestrictedfunction','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','datetime','ASSISTENZA','restrictedfunction_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','varchar(64)','ASSISTENZA','restrictedfunction_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','datetime','ASSISTENZA','restrictedfunction_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','varchar(64)','ASSISTENZA','restrictedfunction_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','restrictedfunctionsegview','varchar(50)','ASSISTENZA','restrictedfunction_variablename','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI restrictedfunctionsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'restrictedfunctionsegview')
UPDATE customobject set isreal = 'N' where objectname = 'restrictedfunctionsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('restrictedfunctionsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


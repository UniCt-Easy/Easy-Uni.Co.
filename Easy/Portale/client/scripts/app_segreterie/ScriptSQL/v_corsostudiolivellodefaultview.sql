
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


-- CREAZIONE VISTA corsostudiolivellodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiolivellodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudiolivellodefaultview]
GO

CREATE VIEW [dbo].[corsostudiolivellodefaultview] AS 
SELECT 
 [dbo].corsostudiokind.title AS corsostudiokind_title, corsostudiolivello.idcorsostudiokind AS corsostudiolivello_idcorsostudiokind, corsostudiolivello.idcorsostudiolivello, corsostudiolivello.lt AS corsostudiolivello_lt, corsostudiolivello.lu AS corsostudiolivello_lu, corsostudiolivello.title,
 isnull('Livello: ' + corsostudiolivello.title + '; ','') as dropdown_title
FROM [dbo].corsostudiolivello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON corsostudiolivello.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
WHERE  corsostudiolivello.idcorsostudiolivello IS NOT NULL 
GO

-- VERIFICA DI corsostudiolivellodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudiolivellodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiolivellodefaultview','varchar(50)','ASSISTENZA','corsostudiokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiolivellodefaultview','int','ASSISTENZA','corsostudiolivello_idcorsostudiokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivellodefaultview','datetime','ASSISTENZA','corsostudiolivello_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivellodefaultview','varchar(64)','ASSISTENZA','corsostudiolivello_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivellodefaultview','varchar(61)','ASSISTENZA','dropdown_title','61','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivellodefaultview','int','ASSISTENZA','idcorsostudiolivello','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiolivellodefaultview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudiolivellodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudiolivellodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'corsostudiolivellodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudiolivellodefaultview', 'N')
GO

-- GENERAZIONE DATI PER corsostudiolivellodefaultview --
-- FINE GENERAZIONE SCRIPT --

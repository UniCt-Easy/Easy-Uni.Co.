
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


-- CREAZIONE VISTA classescuolakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[classescuolakinddefaultview]
GO

CREATE VIEW [dbo].[classescuolakinddefaultview] AS 
SELECT  classescuolakind.idclassescuolakind,
 [dbo].corsostudiokind.title AS corsostudiokind_title, classescuolakind.idcorsostudiokind AS classescuolakind_idcorsostudiokind,
 [dbo].corsostudiolivello.title AS corsostudiolivello_title, classescuolakind.idcorsostudiolivello, classescuolakind.title,
 isnull('Tipologia: ' + classescuolakind.title + '; ','') as dropdown_title
FROM [dbo].classescuolakind WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudiokind WITH (NOLOCK) ON classescuolakind.idcorsostudiokind = [dbo].corsostudiokind.idcorsostudiokind
LEFT OUTER JOIN [dbo].corsostudiolivello WITH (NOLOCK) ON classescuolakind.idcorsostudiolivello = [dbo].corsostudiolivello.idcorsostudiolivello
WHERE  classescuolakind.idclassescuolakind IS NOT NULL 
GO

-- VERIFICA DI classescuolakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'classescuolakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolakinddefaultview','int','ASSISTENZA','classescuolakind_idcorsostudiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolakinddefaultview','varchar(50)','ASSISTENZA','corsostudiokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolakinddefaultview','varchar(50)','ASSISTENZA','corsostudiolivello_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolakinddefaultview','nvarchar(1037)','ASSISTENZA','dropdown_title','1037','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolakinddefaultview','nvarchar(50)','ASSISTENZA','idclassescuolakind','50','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolakinddefaultview','int','ASSISTENZA','idcorsostudiolivello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolakinddefaultview','nvarchar(1024)','ASSISTENZA','title','1024','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI classescuolakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'classescuolakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'classescuolakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('classescuolakinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER classescuolakinddefaultview --
-- FINE GENERAZIONE SCRIPT --


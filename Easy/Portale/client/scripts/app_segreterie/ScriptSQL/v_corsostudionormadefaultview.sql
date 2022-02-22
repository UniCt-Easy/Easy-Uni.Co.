
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


-- CREAZIONE VISTA corsostudionormadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudionormadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudionormadefaultview]
GO

CREATE VIEW [dbo].[corsostudionormadefaultview] AS 
SELECT  corsostudionorma.idcorsostudionorma,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, corsostudionorma.idistitutokind AS corsostudionorma_idistitutokind, corsostudionorma.lt AS corsostudionorma_lt, corsostudionorma.lu AS corsostudionorma_lu, corsostudionorma.title,
 isnull('Denominazione: ' + corsostudionorma.title + '; ','') as dropdown_title
FROM [dbo].corsostudionorma WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON corsostudionorma.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  corsostudionorma.idcorsostudionorma IS NOT NULL 
GO

-- VERIFICA DI corsostudionormadefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudionormadefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','int','ASSISTENZA','corsostudionorma_idistitutokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','datetime','ASSISTENZA','corsostudionorma_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','varchar(64)','ASSISTENZA','corsostudionorma_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','int','ASSISTENZA','idcorsostudionorma','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudionormadefaultview','varchar(256)','ASSISTENZA','istitutokind_tipoistituto','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudionormadefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudionormadefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudionormadefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'corsostudionormadefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudionormadefaultview', 'N')
GO

-- GENERAZIONE DATI PER corsostudionormadefaultview --
-- FINE GENERAZIONE SCRIPT --


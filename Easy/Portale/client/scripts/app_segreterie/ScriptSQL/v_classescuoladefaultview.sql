
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


-- CREAZIONE VISTA classescuoladefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuoladefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[classescuoladefaultview]
GO

CREATE VIEW [dbo].[classescuoladefaultview] AS 
SELECT  classescuola.idclassescuola,
 [dbo].classescuolaarea.title AS classescuolaarea_title, classescuola.idclassescuolaarea,
 [dbo].classescuolakind.title AS classescuolakind_title, classescuola.idclassescuolakind AS classescuola_idclassescuolakind,
 [dbo].corsostudionorma.title AS corsostudionorma_title, classescuola.idcorsostudionorma, classescuola.indicecineca AS classescuola_indicecineca, classescuola.lt AS classescuola_lt, classescuola.lu AS classescuola_lu, classescuola.obbform AS classescuola_obbform, classescuola.prospocc AS classescuola_prospocc, classescuola.sigla, classescuola.title AS classescuola_title,
 isnull('Sigla: ' + classescuola.sigla + '; ','') + ' ' + isnull('Denominazione: ' + classescuola.title + '; ','') as dropdown_title
FROM [dbo].classescuola WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].classescuolaarea WITH (NOLOCK) ON classescuola.idclassescuolaarea = [dbo].classescuolaarea.idclassescuolaarea
LEFT OUTER JOIN [dbo].classescuolakind WITH (NOLOCK) ON classescuola.idclassescuolakind = [dbo].classescuolakind.idclassescuolakind
LEFT OUTER JOIN [dbo].corsostudionorma WITH (NOLOCK) ON classescuola.idcorsostudionorma = [dbo].corsostudionorma.idcorsostudionorma
WHERE  classescuola.idclassescuola IS NOT NULL 
GO

-- VERIFICA DI classescuoladefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'classescuoladefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','nvarchar(50)','ASSISTENZA','classescuola_idclassescuolakind','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','int','ASSISTENZA','classescuola_indicecineca','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuoladefaultview','datetime','ASSISTENZA','classescuola_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuoladefaultview','varchar(64)','ASSISTENZA','classescuola_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','nvarchar(max)','ASSISTENZA','classescuola_obbform','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','nvarchar(max)','ASSISTENZA','classescuola_prospocc','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuoladefaultview','varchar(256)','ASSISTENZA','classescuola_title','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','nvarchar(50)','ASSISTENZA','classescuolaarea_title','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','nvarchar(1024)','ASSISTENZA','classescuolakind_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','varchar(50)','ASSISTENZA','corsostudionorma_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuoladefaultview','varchar(333)','ASSISTENZA','dropdown_title','333','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuoladefaultview','int','ASSISTENZA','idclassescuola','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','int','ASSISTENZA','idclassescuolaarea','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','int','ASSISTENZA','idcorsostudionorma','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuoladefaultview','varchar(50)','ASSISTENZA','sigla','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI classescuoladefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'classescuoladefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'classescuoladefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('classescuoladefaultview', 'N')
GO

-- GENERAZIONE DATI PER classescuoladefaultview --
-- FINE GENERAZIONE SCRIPT --


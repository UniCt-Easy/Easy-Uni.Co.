
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
-- CREAZIONE VISTA diderogdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[diderogdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[diderogdefaultview]
GO

CREATE VIEW [dbo].[diderogdefaultview] AS SELECT  diderog.aa, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, diderog.idcorsostudio, [dbo].sede.title AS sede_title, diderog.idsede,CASE WHEN diderog.inesaurimento = 'S' THEN 'Si' WHEN diderog.inesaurimento = 'N' THEN 'No' END AS diderog_inesaurimento, isnull('Corso di studio: ' + [dbo].corsostudio.title + '; ','') + ' ' + isnull('Corso di studio: ' + CAST( [dbo].corsostudio.annoistituz AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno Accademico: ' + diderog.aa + '; ','') + ' ' + isnull('Identificativo: ' + [dbo].sede.title + '; ','') as dropdown_title FROM [dbo].diderog WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON diderog.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON diderog.idsede = [dbo].sede.idsede WHERE  diderog.aa IS NOT NULL  AND diderog.idcorsostudio IS NOT NULL  AND diderog.idsede IS NOT NULL 
GO

-- VERIFICA DI diderogdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'diderogdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','varchar(2)','ASSISTENZA','diderog_inesaurimento','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','nvarchar(2199)','ASSISTENZA','dropdown_title','2199','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI diderogdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'diderogdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'diderogdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('diderogdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA iscrizionedotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizionedotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizionedotmasview]
GO

CREATE VIEW [dbo].[iscrizionedotmasview] AS 
SELECT  iscrizione.aa, iscrizione.anno AS iscrizione_anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio, iscrizione.iddidprog, iscrizione.idiscrizione,
 [dbo].registry.title AS registry_title, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola,
 isnull('Matricola: ' + iscrizione.matricola + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico: ' +aa + '; ' + 'Sede: ' +CAST( idsede AS NVARCHAR(64)) from didprog x where x.iddidprog = iscrizione.iddidprog) + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, iscrizione.data, 103),'') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON iscrizione.idreg = [dbo].registry.idreg
WHERE  iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO

-- VERIFICA DI iscrizionedotmasview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'iscrizionedotmasview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','nvarchar(1383)','ASSISTENZA','dropdown_title','1383','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','datetime','ASSISTENZA','iscrizione_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','varchar(64)','ASSISTENZA','iscrizione_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','datetime','ASSISTENZA','iscrizione_data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','datetime','ASSISTENZA','iscrizione_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','iscrizionedotmasview','varchar(64)','ASSISTENZA','iscrizione_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','varchar(50)','ASSISTENZA','matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','iscrizionedotmasview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI iscrizionedotmasview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'iscrizionedotmasview')
UPDATE customobject set isreal = 'N' where objectname = 'iscrizionedotmasview'
ELSE
INSERT INTO customobject (objectname, isreal) values('iscrizionedotmasview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

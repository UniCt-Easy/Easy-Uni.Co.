
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
-- CREAZIONE VISTA nacedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[nacedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[nacedefaultview]
GO

CREATE VIEW [dbo].[nacedefaultview] AS SELECT  nace.activity AS nace_activity, nace.idnace, nace.lt AS nace_lt, nace.lu AS nace_lu, isnull('Codice: ' + nace.idnace + '; ','') + ' ' + isnull('Activity: ' + nace.activity + '; ','') as dropdown_title FROM [dbo].nace WITH (NOLOCK)  WHERE  nace.idnace IS NOT NULL 
GO

-- VERIFICA DI nacedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'nacedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nacedefaultview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nacedefaultview','nvarchar(50)','ASSISTENZA','idnace','50','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nacedefaultview','nvarchar(max)','ASSISTENZA','nace_activity','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nacedefaultview','datetime','ASSISTENZA','nace_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nacedefaultview','varchar(64)','ASSISTENZA','nace_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI nacedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'nacedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'nacedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('nacedefaultview', 'N')
GO

-- GENERAZIONE DATI PER nacedefaultview --
-- FINE GENERAZIONE SCRIPT --


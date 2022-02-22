
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


-- CREAZIONE VISTA duratakinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[duratakinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[duratakinddefaultview]
GO



CREATE VIEW [dbo].[duratakinddefaultview] AS SELECT CASE WHEN duratakind.active = 'S' THEN 'Si' WHEN duratakind.active = 'N' THEN 'No' END AS duratakind_active, duratakind.ans AS duratakind_ans, duratakind.idduratakind, duratakind.lt AS duratakind_lt, duratakind.lu AS duratakind_lu, duratakind.sortcode AS duratakind_sortcode, duratakind.title, isnull('Tipologia: ' + duratakind.title + '; ','') as dropdown_title FROM [dbo].duratakind WITH (NOLOCK)  WHERE  duratakind.idduratakind IS NOT NULL 

GO

-- VERIFICA DI duratakinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'duratakinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','duratakinddefaultview','varchar(2)','ASSISTENZA','duratakind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','duratakinddefaultview','varchar(10)','ASSISTENZA','duratakind_ans','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','datetime','ASSISTENZA','duratakind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','varchar(64)','ASSISTENZA','duratakind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','int','ASSISTENZA','duratakind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','int','ASSISTENZA','idduratakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','duratakinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI duratakinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'duratakinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'duratakinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('duratakinddefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


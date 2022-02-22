
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


-- CREAZIONE VISTA accmotivedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotivedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotivedefaultview]
GO



CREATE VIEW [dbo].[accmotivedefaultview] AS SELECT CASE WHEN accmotive.active = 'S' THEN 'Si' WHEN accmotive.active = 'N' THEN 'No' END AS accmotive_active, accmotive.codemotive, accmotive.ct AS accmotive_ct, accmotive.cu AS accmotive_cu, accmotive.expensekind AS accmotive_expensekind, accmotive.flag AS accmotive_flag,CASE WHEN accmotive.flagamm = 'S' THEN 'Si' WHEN accmotive.flagamm = 'N' THEN 'No' END AS accmotive_flagamm,CASE WHEN accmotive.flagdep = 'S' THEN 'Si' WHEN accmotive.flagdep = 'N' THEN 'No' END AS accmotive_flagdep, accmotive.idaccmotive, accmotive.lt AS accmotive_lt, accmotive.lu AS accmotive_lu, accmotiveparent.codemotive AS accmotiveparent_codemotive, accmotiveparent.title AS accmotiveparent_title, accmotive.paridaccmotive, accmotive.title AS accmotive_title, isnull('Codice: ' + accmotive.codemotive + '; ','') + ' ' + isnull('Denominazione: ' + accmotive.title + '; ','') as dropdown_title FROM [dbo].accmotive WITH (NOLOCK)  LEFT OUTER JOIN [dbo].accmotive AS accmotiveparent WITH (NOLOCK) ON accmotive.paridaccmotive = accmotiveparent.idaccmotive WHERE  accmotive.idaccmotive IS NOT NULL 

GO

-- VERIFICA DI accmotivedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accmotivedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(2)','ASSISTENZA','accmotive_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','datetime','ASSISTENZA','accmotive_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(64)','ASSISTENZA','accmotive_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(2)','ASSISTENZA','accmotive_expensekind','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','int','ASSISTENZA','accmotive_flag','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(2)','ASSISTENZA','accmotive_flagamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(2)','ASSISTENZA','accmotive_flagdep','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','datetime','ASSISTENZA','accmotive_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(64)','ASSISTENZA','accmotive_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(150)','ASSISTENZA','accmotive_title','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(50)','ASSISTENZA','accmotiveparent_codemotive','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(150)','ASSISTENZA','accmotiveparent_title','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(50)','ASSISTENZA','codemotive','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(228)','ASSISTENZA','dropdown_title','228','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotivedefaultview','varchar(36)','ASSISTENZA','idaccmotive','36','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotivedefaultview','varchar(36)','ASSISTENZA','paridaccmotive','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accmotivedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accmotivedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'accmotivedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accmotivedefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA learningagrstudsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrstudsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[learningagrstudsegview]
GO

CREATE VIEW [dbo].[learningagrstudsegview] AS 
SELECT  learningagrstud.ct AS learningagrstud_ct, learningagrstud.cu AS learningagrstud_cu, learningagrstud.idbandomi, learningagrstud.idiscrizionebmi,
 [dbo].learningagrkind.title AS learningagrkind_title, [dbo].learningagrkind.description AS learningagrkind_description, learningagrstud.idlearningagrkind AS learningagrstud_idlearningagrkind, learningagrstud.idlearningagrstud, learningagrstud.idreg,
 registry_registry_istitutiesteriistitutiesteri.title AS registryistitutiesteri_title, learningagrstud.idreg_istitutiesteri, learningagrstud.lt AS learningagrstud_lt, learningagrstud.lu AS learningagrstud_lu, learningagrstud.note AS learningagrstud_note, learningagrstud.start AS learningagrstud_start, learningagrstud.stop AS learningagrstud_stop,(select top 1 idcefr_compasc 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_compasc,
						(select top 1 idcefr_complett 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_complett,
						(select top 1 idcefr_parlinter 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlinter,
						(select top 1 idcefr_parlprod 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_parlprod,
						(select top 1 idcefr_scritto 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as cefrlanglevel_idcefr_scritto,
						(select top 1 idnation 
						from dbo.cefrlanglevel 
						where dbo.cefrlanglevel.idlearningagrstud = learningagrstud.idlearningagrstud
						 order by cefrlanglevel.idnation desc) as idnation
FROM [dbo].learningagrstud WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].learningagrkind WITH (NOLOCK) ON learningagrstud.idlearningagrkind = [dbo].learningagrkind.idlearningagrkind
LEFT OUTER JOIN [dbo].registry_istitutiesteri AS registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON learningagrstud.idreg_istitutiesteri = registry_istitutiesteriistitutiesteri.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON registry_istitutiesteriistitutiesteri.idreg = registry_registry_istitutiesteriistitutiesteri.idreg
WHERE  learningagrstud.idbandomi IS NOT NULL  AND learningagrstud.idiscrizionebmi IS NOT NULL  AND learningagrstud.idlearningagrstud IS NOT NULL  AND learningagrstud.idreg IS NOT NULL 
GO

-- VERIFICA DI learningagrstudsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrstudsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','cefrlanglevel_idcefr_compasc','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','cefrlanglevel_idcefr_complett','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','cefrlanglevel_idcefr_parlinter','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','cefrlanglevel_idcefr_parlprod','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','cefrlanglevel_idcefr_scritto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','int','ASSISTENZA','idlearningagrstud','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','','idnation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','int','ASSISTENZA','idreg_istitutiesteri','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','varchar(256)','ASSISTENZA','learningagrkind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','varchar(50)','ASSISTENZA','learningagrkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','datetime','ASSISTENZA','learningagrstud_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','varchar(64)','ASSISTENZA','learningagrstud_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','int','ASSISTENZA','learningagrstud_idlearningagrkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','datetime','ASSISTENZA','learningagrstud_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','varchar(64)','ASSISTENZA','learningagrstud_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','varchar(max)','ASSISTENZA','learningagrstud_note','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','date','ASSISTENZA','learningagrstud_start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrstudsegview','date','ASSISTENZA','learningagrstud_stop','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrstudsegview','varchar(101)','ASSISTENZA','registryistitutiesteri_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI learningagrstudsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrstudsegview')
UPDATE customobject set isreal = 'N' where objectname = 'learningagrstudsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrstudsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


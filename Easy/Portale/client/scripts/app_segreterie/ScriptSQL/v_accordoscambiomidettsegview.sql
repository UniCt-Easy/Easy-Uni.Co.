
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


-- CREAZIONE VISTA accordoscambiomidettsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidettsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomidettsegview]
GO

CREATE VIEW [dbo].[accordoscambiomidettsegview] AS 
SELECT  accordoscambiomidett.ct AS accordoscambiomidett_ct, accordoscambiomidett.cu AS accordoscambiomidett_cu, accordoscambiomidett.idaccordoscambiomi, accordoscambiomidett.idaccordoscambiomidett,
 [dbo].isced2013.detailedfield AS isced2013_detailedfield, accordoscambiomidett.idisced2013,
 registry_registry_istitutiesteriistitutiesteri.title AS registryistitutiesteri_title, accordoscambiomidett.idreg_istitutiesteri,
 [dbo].torkind.title AS torkind_title, [dbo].torkind.description AS torkind_description, accordoscambiomidett.idtorkind AS accordoscambiomidett_idtorkind, accordoscambiomidett.lt AS accordoscambiomidett_lt, accordoscambiomidett.lu AS accordoscambiomidett_lu, accordoscambiomidett.numdocincoming AS accordoscambiomidett_numdocincoming, accordoscambiomidett.numdocoutgoing AS accordoscambiomidett_numdocoutgoing, accordoscambiomidett.numpersincoming AS accordoscambiomidett_numpersincoming, accordoscambiomidett.numpersoutgoing AS accordoscambiomidett_numpersoutgoing, accordoscambiomidett.numstulearincoming AS accordoscambiomidett_numstulearincoming, accordoscambiomidett.numstulearoutgoing AS accordoscambiomidett_numstulearoutgoing, accordoscambiomidett.numstutraincoming AS accordoscambiomidett_numstutraincoming, accordoscambiomidett.numstutraoutgoing AS accordoscambiomidett_numstutraoutgoing, accordoscambiomidett.stipula AS accordoscambiomidett_stipula, accordoscambiomidett.stop AS accordoscambiomidett_stop
FROM [dbo].accordoscambiomidett WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].isced2013 WITH (NOLOCK) ON accordoscambiomidett.idisced2013 = [dbo].isced2013.idisced2013
LEFT OUTER JOIN [dbo].registry_istitutiesteri AS registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON accordoscambiomidett.idreg_istitutiesteri = registry_istitutiesteriistitutiesteri.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiesteriistitutiesteri WITH (NOLOCK) ON registry_istitutiesteriistitutiesteri.idreg = registry_registry_istitutiesteriistitutiesteri.idreg
LEFT OUTER JOIN [dbo].torkind WITH (NOLOCK) ON accordoscambiomidett.idtorkind = [dbo].torkind.idtorkind
WHERE  accordoscambiomidett.idaccordoscambiomi IS NOT NULL  AND accordoscambiomidett.idaccordoscambiomidett IS NOT NULL  AND accordoscambiomidett.idreg_istitutiesteri IS NOT NULL 
GO

-- VERIFICA DI accordoscambiomidettsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomidettsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','datetime','ASSISTENZA','accordoscambiomidett_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','varchar(64)','ASSISTENZA','accordoscambiomidett_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_idtorkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','datetime','ASSISTENZA','accordoscambiomidett_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','varchar(64)','ASSISTENZA','accordoscambiomidett_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numdocincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numdocoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numpersincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numpersoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numstulearincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numstulearoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numstutraincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','accordoscambiomidett_numstutraoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','date','ASSISTENZA','accordoscambiomidett_stipula','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','date','ASSISTENZA','accordoscambiomidett_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','int','ASSISTENZA','idaccordoscambiomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','int','ASSISTENZA','idaccordoscambiomidett','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','int','ASSISTENZA','idisced2013','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidettsegview','int','ASSISTENZA','idreg_istitutiesteri','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','varchar(64)','ASSISTENZA','isced2013_detailedfield','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','varchar(101)','ASSISTENZA','registryistitutiesteri_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','varchar(256)','ASSISTENZA','torkind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidettsegview','varchar(50)','ASSISTENZA','torkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accordoscambiomidettsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomidettsegview')
UPDATE customobject set isreal = 'N' where objectname = 'accordoscambiomidettsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomidettsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA getcontrattidefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[getcontrattidefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcontrattidefaultview]
GO

CREATE VIEW [getcontrattidefaultview] AS 
SELECT  getcontratti.costolordoannuo AS getcontratti_costolordoannuo, getcontratti.costomese AS getcontratti_costomese, getcontratti.costoora AS getcontratti_costoora,
 [dbo].contrattokind.title AS contrattokind_title, [dbo].contratto.idcontrattokind AS contratto_idcontrattokind, [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, [dbo].inquadramento.tempdef AS inquadramento_tempdef, [dbo].contratto.idinquadramento AS contratto_idinquadramento, [dbo].contratto.start AS contratto_start, [dbo].contratto.stop AS contratto_stop, getcontratti.idcontratto,
 contrattokind_getcontratti.title AS contrattokind_getcontratti_title, getcontratti.idcontrattokind AS getcontratti_idcontrattokind,
 inquadramento_getcontratti.idcontrattokind AS inquadramento_getcontratti_idcontrattokind, inquadramento_getcontratti.title AS inquadramento_getcontratti_title, inquadramento_getcontratti.tempdef AS inquadramento_getcontratti_tempdef, getcontratti.idinquadramento,
 [dbo].registry.title AS registry_title, getcontratti.idreg, getcontratti.oremax AS getcontratti_oremax, getcontratti.oremaxdida AS getcontratti_oremaxdida, getcontratti.oremaxgg AS getcontratti_oremaxgg, getcontratti.oremindida AS getcontratti_oremindida, getcontratti.parttime AS getcontratti_parttime, getcontratti.scatto AS getcontratti_scatto, getcontratti.start AS getcontratti_start, getcontratti.stop AS getcontratti_stop,CASE WHEN getcontratti.tempdef = 'S' THEN 'Si' WHEN getcontratti.tempdef = 'N' THEN 'No' END AS getcontratti_tempdef, getcontratti.title, getcontratti.totale_inquadramento AS getcontratti_totale_inquadramento, getcontratti.totale_stipendioannuo AS getcontratti_totale_stipendioannuo, getcontratti.totale_tabellastipendiale AS getcontratti_totale_tabellastipendiale, getcontratti.totale_tipologiacontrattuale AS getcontratti_totale_tipologiacontrattuale,
 isnull('Ruolo/Figura contrattuale: ' + getcontratti.title + '; ','') as dropdown_title
FROM getcontratti WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contratto WITH (NOLOCK) ON getcontratti.idcontratto = [dbo].contratto.idcontratto
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON [dbo].contratto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON [dbo].contratto.idinquadramento = [dbo].inquadramento.idinquadramento
LEFT OUTER JOIN [dbo].contrattokind AS contrattokind_getcontratti WITH (NOLOCK) ON getcontratti.idcontrattokind = contrattokind_getcontratti.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento AS inquadramento_getcontratti WITH (NOLOCK) ON getcontratti.idinquadramento = inquadramento_getcontratti.idinquadramento
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON getcontratti.idreg = [dbo].registry.idreg
WHERE  getcontratti.idcontratto IS NOT NULL 
GO

-- VERIFICA DI getcontrattidefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcontrattidefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','contratto_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','contratto_idinquadramento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','date','ASSISTENZA','contratto_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','date','ASSISTENZA','contratto_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(50)','ASSISTENZA','contrattokind_getcontratti_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','varchar(79)','ASSISTENZA','dropdown_title','79','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','decimal(19,2)','ASSISTENZA','getcontratti_costolordoannuo','9','S','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(18,2)','ASSISTENZA','getcontratti_costomese','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(18,2)','ASSISTENZA','getcontratti_costoora','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','int','ASSISTENZA','getcontratti_idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','getcontratti_oremax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','getcontratti_oremaxdida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','getcontratti_oremaxgg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','getcontratti_oremindida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(5,2)','ASSISTENZA','getcontratti_parttime','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','getcontratti_scatto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','date','ASSISTENZA','getcontratti_start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','date','ASSISTENZA','getcontratti_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(2)','ASSISTENZA','getcontratti_tempdef','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(9,2)','ASSISTENZA','getcontratti_totale_inquadramento','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(19,2)','ASSISTENZA','getcontratti_totale_stipendioannuo','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(18,2)','ASSISTENZA','getcontratti_totale_tabellastipendiale','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','decimal(9,2)','ASSISTENZA','getcontratti_totale_tipologiacontrattuale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','int','ASSISTENZA','idcontratto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','idinquadramento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','inquadramento_getcontratti_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','char(1)','ASSISTENZA','inquadramento_getcontratti_tempdef','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(2048)','ASSISTENZA','inquadramento_getcontratti_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','int','ASSISTENZA','inquadramento_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','char(1)','ASSISTENZA','inquadramento_tempdef','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(2048)','ASSISTENZA','inquadramento_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattidefaultview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattidefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getcontrattidefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcontrattidefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'getcontrattidefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcontrattidefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


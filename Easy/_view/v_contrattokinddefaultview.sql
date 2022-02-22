
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
-- CREAZIONE VISTA contrattokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattokinddefaultview]
GO

CREATE VIEW [dbo].[contrattokinddefaultview] AS SELECT CASE WHEN contrattokind.active = 'S' THEN 'Si' WHEN contrattokind.active = 'N' THEN 'No' END AS contrattokind_active,CASE WHEN contrattokind.assegnoaggiuntivo = 'S' THEN 'Si' WHEN contrattokind.assegnoaggiuntivo = 'N' THEN 'No' END AS contrattokind_assegnoaggiuntivo, contrattokind.costolordoannuo AS contrattokind_costolordoannuo, contrattokind.costolordoannuooneri AS contrattokind_costolordoannuooneri, contrattokind.ct AS contrattokind_ct, contrattokind.cu AS contrattokind_cu, contrattokind.description AS contrattokind_description,CASE WHEN contrattokind.elementoperequativo = 'S' THEN 'Si' WHEN contrattokind.elementoperequativo = 'N' THEN 'No' END AS contrattokind_elementoperequativo, contrattokind.idcontrattokind,CASE WHEN contrattokind.indennitadiateneo = 'S' THEN 'Si' WHEN contrattokind.indennitadiateneo = 'N' THEN 'No' END AS contrattokind_indennitadiateneo,CASE WHEN contrattokind.indennitadiposizione = 'S' THEN 'Si' WHEN contrattokind.indennitadiposizione = 'N' THEN 'No' END AS contrattokind_indennitadiposizione,CASE WHEN contrattokind.indvacancacontrattuale = 'S' THEN 'Si' WHEN contrattokind.indvacancacontrattuale = 'N' THEN 'No' END AS contrattokind_indvacancacontrattuale, contrattokind.lt AS contrattokind_lt, contrattokind.lu AS contrattokind_lu, contrattokind.oremaxcompitididatempoparziale AS contrattokind_oremaxcompitididatempoparziale, contrattokind.oremaxcompitididatempopieno AS contrattokind_oremaxcompitididatempopieno, contrattokind.oremaxdidatempoparziale AS contrattokind_oremaxdidatempoparziale, contrattokind.oremaxdidatempopieno AS contrattokind_oremaxdidatempopieno, contrattokind.oremaxgg AS contrattokind_oremaxgg, contrattokind.oremaxtempoparziale AS contrattokind_oremaxtempoparziale, contrattokind.oremaxtempopieno AS contrattokind_oremaxtempopieno, contrattokind.oremincompitididatempoparziale AS contrattokind_oremincompitididatempoparziale, contrattokind.oremincompitididatempopieno AS contrattokind_oremincompitididatempopieno, contrattokind.oremindidatempoparziale AS contrattokind_oremindidatempoparziale, contrattokind.oremindidatempopieno AS contrattokind_oremindidatempopieno, contrattokind.oremintempoparziale AS contrattokind_oremintempoparziale, contrattokind.oremintempopieno AS contrattokind_oremintempopieno, contrattokind.orestraordinariemax AS contrattokind_orestraordinariemax,CASE WHEN contrattokind.parttime = 'S' THEN 'Si' WHEN contrattokind.parttime = 'N' THEN 'No' END AS contrattokind_parttime,CASE WHEN contrattokind.scatto = 'S' THEN 'Si' WHEN contrattokind.scatto = 'N' THEN 'No' END AS contrattokind_scatto, contrattokind.sortcode AS contrattokind_sortcode,CASE WHEN contrattokind.tempdef = 'S' THEN 'Si' WHEN contrattokind.tempdef = 'N' THEN 'No' END AS contrattokind_tempdef, contrattokind.title,CASE WHEN contrattokind.totaletredicesima = 'S' THEN 'Si' WHEN contrattokind.totaletredicesima = 'N' THEN 'No' END AS contrattokind_totaletredicesima,CASE WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'S' THEN 'Si' WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'N' THEN 'No' END AS contrattokind_tredicesimaindennitaintegrativaspeciale, isnull('Tipologia: ' + contrattokind.title + '; ','') as dropdown_title FROM [dbo].contrattokind WITH (NOLOCK)  WHERE  contrattokind.idcontrattokind IS NOT NULL 
GO

-- VERIFICA DI contrattokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'contrattokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_assegnoaggiuntivo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','decimal(9,2)','ASSISTENZA','contrattokind_costolordoannuo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','decimal(9,2)','ASSISTENZA','contrattokind_costolordoannuooneri','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','datetime','ASSISTENZA','contrattokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','varchar(64)','ASSISTENZA','contrattokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(256)','ASSISTENZA','contrattokind_description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_elementoperequativo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_indennitadiateneo','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_indennitadiposizione','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_indvacancacontrattuale','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','datetime','ASSISTENZA','contrattokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','varchar(64)','ASSISTENZA','contrattokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxcompitididatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxcompitididatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxdidatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxdidatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxgg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxtempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremaxtempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremincompitididatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremincompitididatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremindidatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremindidatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremintempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_oremintempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','int','ASSISTENZA','contrattokind_orestraordinariemax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_parttime','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_scatto','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','int','ASSISTENZA','contrattokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_tempdef','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_totaletredicesima','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokinddefaultview','varchar(2)','ASSISTENZA','contrattokind_tredicesimaindennitaintegrativaspeciale','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokinddefaultview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI contrattokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'contrattokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'contrattokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('contrattokinddefaultview', 'N')
GO

-- GENERAZIONE DATI PER contrattokinddefaultview --
-- FINE GENERAZIONE SCRIPT --


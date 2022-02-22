
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


-- CREAZIONE VISTA protocollosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[protocollosegview]
GO

CREATE VIEW [dbo].[protocollosegview] AS 
SELECT CASE WHEN protocollo.annullato = 'S' THEN 'Si' WHEN protocollo.annullato = 'N' THEN 'No' END AS protocollo_annullato, protocollo.codiceammipa AS protocollo_codiceammipa, protocollo.codiceregistro AS protocollo_codiceregistro, protocollo.ct AS protocollo_ct, protocollo.cu AS protocollo_cu, protocollo.dataannullamento AS protocollo_dataannullamento,
 [dbo].aoo.title AS aoo_title, protocollo.idaoo,
 registryorigine.title AS registryorigine_title, protocollo.idreg_origine, protocollo.lt AS protocollo_lt, protocollo.lu AS protocollo_lu, protocollo.oggetto AS protocollo_oggetto, protocollo.originecodiceaoo AS protocollo_originecodiceaoo, protocollo.origineidamm AS protocollo_origineidamm, protocollo.originemail AS protocollo_originemail, protocollo.protanno, protocollo.protdata AS protocollo_protdata, protocollo.protnumero, protocollo.testo AS protocollo_testo,
 isnull('Numero di protocollo: ' + CAST( protocollo.protnumero AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di protocollo: ' + CAST( protocollo.protanno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Registro (univoco nell''Istituto): ' + protocollo.codiceregistro + '; ','') as dropdown_title
FROM [dbo].protocollo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON protocollo.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].registry AS registryorigine WITH (NOLOCK) ON protocollo.idreg_origine = registryorigine.idreg
WHERE  protocollo.protanno IS NOT NULL  AND protocollo.protnumero IS NOT NULL 
GO

-- VERIFICA DI protocollosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'protocollosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(1024)','ASSISTENZA','aoo_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','nvarchar(1243)','ASSISTENZA','dropdown_title','1243','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','int','ASSISTENZA','idreg_origine','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','int','ASSISTENZA','protanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','int','ASSISTENZA','protnumero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(2)','ASSISTENZA','protocollo_annullato','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','varchar(50)','ASSISTENZA','protocollo_codiceammipa','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','varchar(1024)','ASSISTENZA','protocollo_codiceregistro','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','datetime','ASSISTENZA','protocollo_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(64)','ASSISTENZA','protocollo_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','datetime','ASSISTENZA','protocollo_dataannullamento','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','datetime','ASSISTENZA','protocollo_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(64)','ASSISTENZA','protocollo_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','varchar(1024)','ASSISTENZA','protocollo_oggetto','1024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(50)','ASSISTENZA','protocollo_originecodiceaoo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(50)','ASSISTENZA','protocollo_origineidamm','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(512)','ASSISTENZA','protocollo_originemail','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollosegview','date','ASSISTENZA','protocollo_protdata','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(max)','ASSISTENZA','protocollo_testo','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollosegview','varchar(101)','ASSISTENZA','registryorigine_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI protocollosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'protocollosegview')
UPDATE customobject set isreal = 'N' where objectname = 'protocollosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('protocollosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


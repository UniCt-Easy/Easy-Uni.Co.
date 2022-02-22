
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
-- CREAZIONE VISTA decadenzasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[decadenzasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[decadenzasegview]
GO

CREATE VIEW [dbo].[decadenzasegview] AS SELECT  decadenza.aa, decadenza.ct AS decadenza_ct, decadenza.cu AS decadenza_cu, decadenza.data AS decadenza_data, decadenza.iddecadenza, [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].annoaccademico.aa AS annoaccademico_aa, decadenza.idiscrizione, registry_registry_studentistudenti.title AS registrystudenti_title, decadenza.idreg_studenti, decadenza.lt AS decadenza_lt, decadenza.lu AS decadenza_lu, decadenza.protanno AS decadenza_protanno, decadenza.protnumero AS decadenza_protnumero, isnull('Stud. : ' + registry_registry_studentistudenti.title + '; ','') + ' ' + isnull('Iscr. : ' + CAST( [dbo].iscrizione.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscr. : ' + CAST( [dbo].iscrizione.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('AA : ' + decadenza.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') as dropdown_title FROM [dbo].decadenza WITH (NOLOCK)  LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON decadenza.idiscrizione = [dbo].iscrizione.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON iscrizione.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON decadenza.idreg_studenti = registry_studentistudenti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg WHERE  decadenza.iddecadenza IS NOT NULL  AND decadenza.idiscrizione IS NOT NULL  AND decadenza.idreg_studenti IS NOT NULL 
GO

-- VERIFICA DI decadenzasegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'decadenzasegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','decadenzasegview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','datetime','ASSISTENZA','decadenza_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','varchar(64)','ASSISTENZA','decadenza_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','datetime','ASSISTENZA','decadenza_data','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','datetime','ASSISTENZA','decadenza_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','varchar(64)','ASSISTENZA','decadenza_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','int','ASSISTENZA','decadenza_protanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','int','ASSISTENZA','decadenza_protnumero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','nvarchar(314)','ASSISTENZA','dropdown_title','314','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','int','ASSISTENZA','iddecadenza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','decadenzasegview','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','decadenzasegview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','decadenzasegview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','decadenzasegview','varchar(101)','ASSISTENZA','registrystudenti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI decadenzasegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'decadenzasegview')
UPDATE customobject set isreal = 'N' where objectname = 'decadenzasegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('decadenzasegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


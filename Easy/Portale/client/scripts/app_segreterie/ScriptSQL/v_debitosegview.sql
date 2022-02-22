
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


-- CREAZIONE VISTA debitosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[debitosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[debitosegview]
GO

CREATE VIEW [dbo].[debitosegview] AS 
SELECT  debito.codicebollettino AS debito_codicebollettino, debito.codicemav AS debito_codicemav, debito.ct AS debito_ct, debito.cu AS debito_cu, debito.iddebito,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, debito.idiscrizione,
 [dbo].istanza.aa AS istanza_aa, [dbo].istanza.extension AS istanza_extension, debito.idistanza,
 [dbo].nullaosta.data AS nullaosta_data, debito.idnullaosta, debito.idreg,
 [dbo].tassaconf.title AS tassaconf_title, debito.idtassaconf, debito.IUV AS debito_IUV, debito.lt AS debito_lt, debito.lu AS debito_lu, debito.scadenza AS debito_scadenza, debito.title,
 isnull('Denominazione: ' + debito.title + '; ','') as dropdown_title
FROM [dbo].debito WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON debito.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].istanza WITH (NOLOCK) ON debito.idistanza = [dbo].istanza.idistanza
LEFT OUTER JOIN [dbo].nullaosta WITH (NOLOCK) ON debito.idnullaosta = [dbo].nullaosta.idnullaosta
LEFT OUTER JOIN [dbo].tassaconf WITH (NOLOCK) ON debito.idtassaconf = [dbo].tassaconf.idtassaconf
WHERE  debito.iddebito IS NOT NULL  AND debito.idreg IS NOT NULL 
GO

-- VERIFICA DI debitosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'debitosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','nchar(10)','ASSISTENZA','debito_codicebollettino','10','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','varchar(50)','ASSISTENZA','debito_codicemav','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','datetime','ASSISTENZA','debito_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','varchar(64)','ASSISTENZA','debito_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','char(35)','ASSISTENZA','debito_IUV','35','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','datetime','ASSISTENZA','debito_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','varchar(64)','ASSISTENZA','debito_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','date','ASSISTENZA','debito_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','nvarchar(2041)','ASSISTENZA','dropdown_title','2041','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','int','ASSISTENZA','iddebito','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','idistanza','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','idnullaosta','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','debitosegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','idtassaconf','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','varchar(9)','ASSISTENZA','iscrizione_aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','nvarchar(9)','ASSISTENZA','istanza_aa','9','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','varchar(200)','ASSISTENZA','istanza_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','datetime','ASSISTENZA','nullaosta_data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','varchar(2024)','ASSISTENZA','tassaconf_title','2024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','debitosegview','nvarchar(2024)','ASSISTENZA','title','2024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI debitosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'debitosegview')
UPDATE customobject set isreal = 'N' where objectname = 'debitosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('debitosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


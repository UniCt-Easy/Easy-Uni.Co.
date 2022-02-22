
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


-- CREAZIONE VISTA bandomisegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomisegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[bandomisegview]
GO

CREATE VIEW [dbo].[bandomisegview] AS 
SELECT  bandomi.aa, bandomi.cfminimi AS bandomi_cfminimi, bandomi.codice AS bandomi_codice, bandomi.ct AS bandomi_ct, bandomi.cu AS bandomi_cu, bandomi.datariferimentorequisiti AS bandomi_datariferimentorequisiti, bandomi.durata AS bandomi_durata,
 [dbo].accordoscambiomi.title AS accordoscambiomi_title, bandomi.idaccordoscambiomi AS bandomi_idaccordoscambiomi,
 [dbo].assicurazione.societaassicura AS assicurazione_societaassicura, [dbo].assicurazione.datascadenza AS assicurazione_datascadenza, bandomi.idassicurazione, bandomi.idbandomi,
 [dbo].bandomobilitaintkind.title AS bandomobilitaintkind_title, bandomi.idbandomobilitaintkind AS bandomi_idbandomobilitaintkind,
 [dbo].duratakind.title AS duratakind_title, bandomi.idduratakind AS bandomi_idduratakind,
 [dbo].graduatoria.title AS graduatoria_title, bandomi.idgraduatoria,
 [dbo].programmami.acronimo AS programmami_acronimo, bandomi.idprogrammami AS bandomi_idprogrammami,
 [dbo].residence.description AS residence_description, bandomi.idresidence,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, bandomi.idstruttura,CASE WHEN bandomi.iscrittonellanno = 'S' THEN 'Si' WHEN bandomi.iscrittonellanno = 'N' THEN 'No' END AS bandomi_iscrittonellanno, bandomi.lt AS bandomi_lt, bandomi.lu AS bandomi_lu, bandomi.maxpreferenze AS bandomi_maxpreferenze, bandomi.mediaminima AS bandomi_mediaminima,CASE WHEN bandomi.nessundebito = 'S' THEN 'Si' WHEN bandomi.nessundebito = 'N' THEN 'No' END AS bandomi_nessundebito, bandomi.numeroesamiminimo AS bandomi_numeroesamiminimo, bandomi.startcandidature AS bandomi_startcandidature, bandomi.startgraduatoria AS bandomi_startgraduatoria, bandomi.startpermanenza AS bandomi_startpermanenza, bandomi.startpresentazione AS bandomi_startpresentazione, bandomi.stopcadidature AS bandomi_stopcadidature, bandomi.stopgraduatoria AS bandomi_stopgraduatoria, bandomi.stoppermanenza AS bandomi_stoppermanenza, bandomi.stoppresentazione AS bandomi_stoppresentazione, bandomi.testodomanda AS bandomi_testodomanda, bandomi.title, bandomi.titolodomanda AS bandomi_titolodomanda,
 isnull('Titolo del bando: ' + bandomi.title + '; ','') as dropdown_title
FROM [dbo].bandomi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].accordoscambiomi WITH (NOLOCK) ON bandomi.idaccordoscambiomi = [dbo].accordoscambiomi.idaccordoscambiomi
LEFT OUTER JOIN [dbo].assicurazione WITH (NOLOCK) ON bandomi.idassicurazione = [dbo].assicurazione.idassicurazione
LEFT OUTER JOIN [dbo].bandomobilitaintkind WITH (NOLOCK) ON bandomi.idbandomobilitaintkind = [dbo].bandomobilitaintkind.idbandomobilitaintkind
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON bandomi.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON bandomi.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].programmami WITH (NOLOCK) ON bandomi.idprogrammami = [dbo].programmami.idprogrammami
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON bandomi.idresidence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON bandomi.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  bandomi.idbandomi IS NOT NULL 
GO

-- VERIFICA DI bandomisegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandomisegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','nvarchar(9)','ASSISTENZA','aa','9','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(max)','ASSISTENZA','accordoscambiomi_title','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','date','ASSISTENZA','assicurazione_datascadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(1024)','ASSISTENZA','assicurazione_societaassicura','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','decimal(9,2)','ASSISTENZA','bandomi_cfminimi','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','varchar(50)','ASSISTENZA','bandomi_codice','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','varchar(64)','ASSISTENZA','bandomi_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','date','ASSISTENZA','bandomi_datariferimentorequisiti','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','bandomi_durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','int','ASSISTENZA','bandomi_idaccordoscambiomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','int','ASSISTENZA','bandomi_idbandomobilitaintkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','bandomi_idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','int','ASSISTENZA','bandomi_idprogrammami','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(2)','ASSISTENZA','bandomi_iscrittonellanno','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','varchar(64)','ASSISTENZA','bandomi_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','bandomi_maxpreferenze','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','decimal(9,2)','ASSISTENZA','bandomi_mediaminima','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(2)','ASSISTENZA','bandomi_nessundebito','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','bandomi_numeroesamiminimo','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_startcandidature','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_startgraduatoria','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','date','ASSISTENZA','bandomi_startpermanenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_startpresentazione','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_stopcadidature','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_stopgraduatoria','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','date','ASSISTENZA','bandomi_stoppermanenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','datetime','ASSISTENZA','bandomi_stoppresentazione','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(max)','ASSISTENZA','bandomi_testodomanda','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(max)','ASSISTENZA','bandomi_titolodomanda','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','nvarchar(200)','ASSISTENZA','bandomobilitaintkind_title','200','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(50)','ASSISTENZA','duratakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(256)','ASSISTENZA','graduatoria_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','idassicurazione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','idgraduatoria','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','ASSISTENZA','idresidence','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(50)','ASSISTENZA','programmami_acronimo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','int','','struttura_idstrutturakind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomisegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomisegview','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandomisegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandomisegview')
UPDATE customobject set isreal = 'N' where objectname = 'bandomisegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandomisegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


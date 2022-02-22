
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


-- CREAZIONE VISTA istanzarein_seganagstuview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzarein_seganagstuview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzarein_seganagstuview]
GO

CREATE VIEW [dbo].[istanzarein_seganagstuview] AS SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, istanza.idcorsostudio AS istanza_idcorsostudio, [dbo].didprog.title AS didprog_title, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].sede.title AS sede_title, istanza.iddidprog, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind, registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti, [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza AS istanza_paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_rein.aarindec, istanza_rein.ct AS istanza_rein_ct, istanza_rein.cu AS istanza_rein_cu,CASE WHEN istanza_rein.darindec = 'D' THEN 'Decadenza' WHEN istanza_rein.darindec = 'R' THEN 'Rinuncia' END AS istanza_rein_darindec, istanza_rein.datarindec AS istanza_rein_datarindec, istanza_rein.iddidprog AS istanza_rein_iddidprog, istanza_rein.idiscrizione AS istanza_rein_idiscrizione, iscrizionefrom.anno AS iscrizionefrom_anno, iscrizionefrom.iddidprog AS iscrizionefrom_iddidprog, annoaccademico_iscrizione.aa AS annoaccademico_iscrizione_aa, istanza_rein.idiscrizione_from, istanza_rein.idistanza AS istanza_rein_idistanza, istanza_rein.idistanzakind AS istanza_rein_idistanzakind, istanza_rein.idreg AS istanza_rein_idreg, [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, annoaccademico_titolostudio.aa AS annoaccademico_titolostudio_aa, istanza_rein.idtitolostudio, istanza_rein.lt AS istanza_rein_lt, istanza_rein.lu AS istanza_rein_lu, isnull('Studente: ' + registry_registry_studentistudenti.title + '; ','') + ' ' + isnull('Titolo di studio Titolo ISTAT: ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, istanza.data, 103),'') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Status: ' + [dbo].statuskind.title + '; ','') + ' ' + isnull('Codice Anno accademco: ' + annoaccademico_titolostudio.aa + '; ','') as dropdown_title FROM [dbo].istanza WITH (NOLOCK)  INNER JOIN istanza_rein WITH (NOLOCK) ON istanza.idistanza = istanza_rein.idistanza AND istanza.idistanzakind = istanza_rein.idistanzakind AND istanza.idreg_studenti = istanza_rein.idreg LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON didprog.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind LEFT OUTER JOIN [dbo].iscrizione AS iscrizionefrom WITH (NOLOCK) ON istanza_rein.idiscrizione_from = iscrizionefrom.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione WITH (NOLOCK) ON iscrizionefrom.aa = annoaccademico_iscrizione.aa LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON istanza_rein.idtitolostudio = [dbo].titolostudio.idtitolostudio LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_titolostudio WITH (NOLOCK) ON titolostudio.aa = annoaccademico_titolostudio.aa WHERE  istanza.iddidprog IS NOT NULL  AND istanza.idiscrizione IS NOT NULL  AND istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_rein.iddidprog IS NOT NULL  AND istanza_rein.idiscrizione IS NOT NULL  AND istanza_rein.idistanza IS NOT NULL  AND istanza_rein.idistanzakind IS NOT NULL  AND istanza_rein.idreg IS NOT NULL 
GO

-- VERIFICA DI istanzarein_seganagstuview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istanzarein_seganagstuview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','nvarchar(9)','ASSISTENZA','aa','9','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(9)','ASSISTENZA','aarindec','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','nvarchar(9)','ASSISTENZA','annoaccademico_aa','9','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','nvarchar(9)','ASSISTENZA','annoaccademico_iscrizione_aa','9','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','nvarchar(9)','ASSISTENZA','annoaccademico_titolostudio_aa','9','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','nvarchar(2421)','ASSISTENZA','dropdown_title','2421','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','idiscrizione_from','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','iscrizionefrom_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','iscrizionefrom_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','datetime','ASSISTENZA','istanza_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','varchar(64)','ASSISTENZA','istanza_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','datetime','ASSISTENZA','istanza_data','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(200)','ASSISTENZA','istanza_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','istanza_idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','istanza_idstatuskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','datetime','ASSISTENZA','istanza_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','varchar(64)','ASSISTENZA','istanza_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','istanza_paridistanza','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_protanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_protnumero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','datetime','ASSISTENZA','istanza_rein_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','varchar(64)','ASSISTENZA','istanza_rein_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(9)','ASSISTENZA','istanza_rein_darindec','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','date','ASSISTENZA','istanza_rein_datarindec','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_rein_iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_rein_idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_rein_idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_rein_idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','int','ASSISTENZA','istanza_rein_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','datetime','ASSISTENZA','istanza_rein_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzarein_seganagstuview','varchar(64)','ASSISTENZA','istanza_rein_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(1024)','ASSISTENZA','istattitolistudio_titolo','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(101)','ASSISTENZA','registrystudenti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','varchar(50)','ASSISTENZA','statuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','titolostudio_voto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','char(1)','ASSISTENZA','titolostudio_votolode','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzarein_seganagstuview','int','ASSISTENZA','titolostudio_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istanzarein_seganagstuview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istanzarein_seganagstuview')
UPDATE customobject set isreal = 'N' where objectname = 'istanzarein_seganagstuview'
ELSE
INSERT INTO customobject (objectname, isreal) values('istanzarein_seganagstuview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


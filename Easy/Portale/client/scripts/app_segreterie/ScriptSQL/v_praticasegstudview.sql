
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
-- CREAZIONE VISTA praticasegstudview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[praticasegstudview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[praticasegstudview]
GO

CREATE VIEW [dbo].[praticasegstudview] AS SELECT  pratica.ct AS pratica_ct, pratica.cu AS pratica_cu, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, pratica.idcorsostudio, [dbo].dichiarkind.title AS dichiarkind_title, [dbo].dichiar.idreg AS dichiar_idreg, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].dichiar.date AS dichiar_date, pratica.iddichiar, [dbo].didprog.title AS didprog_title, annoaccademico_didprog.aa AS annoaccademico_didprog_aa, [dbo].sede.title AS sede_title, pratica.iddidprog, [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, annoaccademico_iscrizione.aa AS annoaccademico_iscrizione_aa, pratica.idiscrizione, iscrizione_pratica.anno AS iscrizione_pratica_anno, iscrizione_pratica.iddidprog AS iscrizione_pratica_iddidprog, annoaccademico_iscrizione_1.aa AS annoaccademico_iscrizione_1_aa, pratica.idiscrizione_from AS pratica_idiscrizione_from, istanza_istanza_imm.idistanzakind AS istanza_idistanzakind, istanza_istanza_imm.idreg_studenti AS istanza_idreg_studenti, istanza_istanza_imm.aa AS istanza_aa, istanza_istanza_imm.data AS istanza_data, istanza_istanza_imm.iddidprog AS istanza_iddidprog, istanza_istanza_imm.idstatuskind AS istanza_idstatuskind, istanza_istanza_imm.idiscrizione AS istanza_idiscrizione, pratica.idistanza, [dbo].istanzakind.title AS istanzakind_title, pratica.idistanzakind, pratica.idpratica, [dbo].registry.title AS registry_title, pratica.idreg, [dbo].statuskind.title AS statuskind_title, pratica.idstatuskind AS pratica_idstatuskind, [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, annoaccademico_titolostudio.aa AS annoaccademico_titolostudio_aa, pratica.idtitolostudio AS pratica_idtitolostudio, pratica.lt AS pratica_lt, pratica.lu AS pratica_lu, pratica.protanno AS pratica_protanno, pratica.protnumero AS pratica_protnumero, isnull('Tipologia Tipologia: ' + [dbo].dichiarkind.title + '; ','') + ' ' + isnull('Studente: ' + [dbo].registry.title + '; ','') + ' ' + isnull('Titolo di studio Titolo ISTAT: ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Codice Anno Accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_didprog.aa + '; ','') + ' ' + isnull('Didattica programmata: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione_1.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Codice Anno accademco: ' + annoaccademico_titolostudio.aa + '; ','') as dropdown_title FROM [dbo].pratica WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON pratica.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].dichiar WITH (NOLOCK) ON pratica.iddichiar = [dbo].dichiar.iddichiar LEFT OUTER JOIN [dbo].dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = [dbo].dichiarkind.iddichiarkind LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON dichiar.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON pratica.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_didprog WITH (NOLOCK) ON didprog.aa = annoaccademico_didprog.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON pratica.idiscrizione = [dbo].iscrizione.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione WITH (NOLOCK) ON iscrizione.aa = annoaccademico_iscrizione.aa LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_pratica WITH (NOLOCK) ON pratica.idiscrizione_from = iscrizione_pratica.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione_1 WITH (NOLOCK) ON iscrizione.aa = annoaccademico_iscrizione_1.aa LEFT OUTER JOIN [dbo].istanza_imm WITH (NOLOCK) ON pratica.idistanza = [dbo].istanza_imm.idistanza LEFT OUTER JOIN [dbo].istanza AS istanza_istanza_imm WITH (NOLOCK) ON [dbo].istanza_imm.idistanza = istanza_istanza_imm.idistanza LEFT OUTER JOIN [dbo].istanzakind WITH (NOLOCK) ON pratica.idistanzakind = [dbo].istanzakind.idistanzakind LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON pratica.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON pratica.idstatuskind = [dbo].statuskind.idstatuskind LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON pratica.idtitolostudio = [dbo].titolostudio.idtitolostudio LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_titolostudio WITH (NOLOCK) ON titolostudio.aa = annoaccademico_titolostudio.aa WHERE  pratica.idcorsostudio IS NOT NULL  AND pratica.iddidprog IS NOT NULL  AND pratica.idiscrizione IS NOT NULL  AND pratica.idistanza IS NOT NULL  AND pratica.idistanzakind IS NOT NULL  AND pratica.idpratica IS NOT NULL  AND pratica.idreg IS NOT NULL 
GO

-- VERIFICA DI praticasegstudview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'praticasegstudview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','annoaccademico_didprog_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','annoaccademico_iscrizione_1_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','annoaccademico_iscrizione_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','annoaccademico_titolostudio_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','corsostudio_annoistituz','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','date','ASSISTENZA','dichiar_date','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','dichiar_idreg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(50)','','dichiarkind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','nvarchar(3521)','ASSISTENZA','dropdown_title','3521','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','iddichiar','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idpratica','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','iscrizione_pratica_anno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','iscrizione_pratica_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(9)','','istanza_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','datetime','ASSISTENZA','istanza_data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','istanza_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','istanza_idiscrizione','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','istanza_idistanzakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','istanza_idreg_studenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','','istanza_idstatuskind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(50)','ASSISTENZA','istanzakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(1024)','','istattitolistudio_titolo','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','datetime','ASSISTENZA','pratica_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','varchar(64)','ASSISTENZA','pratica_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','pratica_idiscrizione_from','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','int','ASSISTENZA','pratica_idstatuskind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','pratica_idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','datetime','ASSISTENZA','pratica_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegstudview','varchar(64)','ASSISTENZA','pratica_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','pratica_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','pratica_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','nvarchar(1024)','','sede_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','varchar(50)','ASSISTENZA','statuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','titolostudio_voto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','char(1)','ASSISTENZA','titolostudio_votolode','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegstudview','int','ASSISTENZA','titolostudio_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI praticasegstudview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'praticasegstudview')
UPDATE customobject set isreal = 'N' where objectname = 'praticasegstudview'
ELSE
INSERT INTO customobject (objectname, isreal) values('praticasegstudview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA istanzasosp_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzasosp_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzasosp_segview]
GO

CREATE VIEW [dbo].[istanzasosp_segview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, istanza.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind,
 registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu,
 istanzaparent.idistanzakind AS istanzaparent_idistanzakind, istanzaparent.idreg_studenti AS istanzaparent_idreg_studenti, istanzaparent.aa AS istanzaparent_aa, istanzaparent.data AS istanzaparent_data, didprog_istanza.title AS didprog_istanza_title, didprog_istanza.aa AS didprog_istanza_aa, didprog_istanza.idsede AS didprog_istanza_idsede, didprog_istanza.iddidprog AS didprog_istanza_iddidprog, statuskind_istanza.title AS statuskind_istanza_title, statuskind_istanza.idstatuskind AS statuskind_istanza_idstatuskind, iscrizione_istanza.anno AS iscrizione_istanza_anno, iscrizione_istanza.iddidprog AS iscrizione_istanza_iddidprog, iscrizione_istanza.aa AS iscrizione_istanza_aa, iscrizione_istanza.idiscrizione AS iscrizione_istanza_idiscrizione, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_sosp.ct AS istanza_sosp_ct, istanza_sosp.cu AS istanza_sosp_cu, istanza_sosp.idistanza AS istanza_sosp_idistanza, istanza_sosp.idistanzakind AS istanza_sosp_idistanzakind, istanza_sosp.idreg AS istanza_sosp_idreg, istanza_sosp.lt AS istanza_sosp_lt, istanza_sosp.lu AS istanza_sosp_lu, istanza_sosp.motivo AS istanza_sosp_motivo, istanza_sosp.start AS istanza_sosp_start, istanza_sosp.stop AS istanza_sosp_stop,
 isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Denominazione Didattica programmata: ' + didprog_istanza.title + '; ','') + ' ' + isnull('Stato Status: ' + statuskind_istanza.title + '; ','') + ' ' + isnull('Anno accademico Didattica programmata: ' + didprog_istanza.aa + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Sede Didattica programmata: ' + CAST( didprog_istanza.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Didattica programmata: ' + CAST( didprog_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Status Status: ' + CAST( statuskind_istanza.idstatuskind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di corso Iscrizione: ' + CAST( iscrizione_istanza.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Iscrizione: ' + CAST( iscrizione_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno accademico Iscrizione: ' + iscrizione_istanza.aa + '; ','') + ' ' + isnull('Iscrizione Iscrizione: ' + CAST( iscrizione_istanza.idiscrizione AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
INNER JOIN istanza_sosp WITH (NOLOCK) ON istanza.idistanza = istanza_sosp.idistanza AND istanza.idistanzakind = istanza_sosp.idistanzakind AND istanza.idreg_studenti = istanza_sosp.idreg
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].istanza AS istanzaparent WITH (NOLOCK) ON istanza.paridistanza = istanzaparent.idistanza
LEFT OUTER JOIN [dbo].didprog AS didprog_istanza WITH (NOLOCK) ON istanzaparent.iddidprog = didprog_istanza.iddidprog
LEFT OUTER JOIN [dbo].statuskind AS statuskind_istanza WITH (NOLOCK) ON istanzaparent.idstatuskind = statuskind_istanza.idstatuskind
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza WITH (NOLOCK) ON istanzaparent.idiscrizione = iscrizione_istanza.idiscrizione
WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind =7 AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza_sosp.idistanza IS NOT NULL  AND istanza_sosp.idistanzakind =7 AND istanza_sosp.idistanzakind IS NOT NULL  AND istanza_sosp.idreg IS NOT NULL 
GO

-- VERIFICA DI istanzasosp_segview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istanzasosp_segview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','nvarchar(9)','ASSISTENZA','aa','9','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','corsostudio_annoistituz','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(9)','','didprog_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(9)','','didprog_istanza_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','didprog_istanza_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','didprog_istanza_idsede','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(1024)','','didprog_istanza_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','nvarchar(2919)','','dropdown_title','2919','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(9)','','iscrizione_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','iscrizione_anno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','iscrizione_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(9)','','iscrizione_istanza_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','iscrizione_istanza_anno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','iscrizione_istanza_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','iscrizione_istanza_idiscrizione','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','datetime','ASSISTENZA','istanza_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','varchar(64)','ASSISTENZA','istanza_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','datetime','ASSISTENZA','istanza_data','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(200)','ASSISTENZA','istanza_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','istanza_idstatuskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','datetime','ASSISTENZA','istanza_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','varchar(64)','ASSISTENZA','istanza_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','istanza_protanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','istanza_protnumero','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','datetime','ASSISTENZA','istanza_sosp_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','varchar(64)','ASSISTENZA','istanza_sosp_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','istanza_sosp_idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','istanza_sosp_idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','int','ASSISTENZA','istanza_sosp_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','datetime','ASSISTENZA','istanza_sosp_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istanzasosp_segview','varchar(64)','ASSISTENZA','istanza_sosp_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(max)','ASSISTENZA','istanza_sosp_motivo','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','date','ASSISTENZA','istanza_sosp_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','date','ASSISTENZA','istanza_sosp_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','nvarchar(9)','','istanzaparent_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','datetime','ASSISTENZA','istanzaparent_data','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','istanzaparent_idistanzakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','istanzaparent_idreg_studenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','ASSISTENZA','paridistanza','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(101)','ASSISTENZA','registrystudenti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','sede_idsede','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','nvarchar(1024)','','sede_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','int','','statuskind_istanza_idstatuskind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(50)','','statuskind_istanza_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istanzasosp_segview','varchar(50)','ASSISTENZA','statuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istanzasosp_segview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istanzasosp_segview')
UPDATE customobject set isreal = 'N' where objectname = 'istanzasosp_segview'
ELSE
INSERT INTO customobject (objectname, isreal) values('istanzasosp_segview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

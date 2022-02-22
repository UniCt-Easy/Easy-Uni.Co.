
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


-- CREAZIONE VISTA praticasegistpassview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[praticasegistpassview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[praticasegistpassview]
GO

CREATE VIEW [dbo].[praticasegistpassview] AS 
SELECT  pratica.ct AS pratica_ct, pratica.cu AS pratica_cu, pratica.idcorsostudio,
 [dbo].dichiar.aa AS dichiar_aa, [dbo].dichiar.extension AS dichiar_extension, pratica.iddichiar, pratica.iddidprog,
 [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, [dbo].iscrizione.aa AS iscrizione_aa, pratica.idiscrizione,
 iscrizione_pratica.anno AS iscrizione_pratica_anno, iscrizione_pratica.iddidprog AS iscrizione_pratica_iddidprog, iscrizione_pratica.aa AS iscrizione_pratica_aa, pratica.idiscrizione_from, pratica.idistanza, pratica.idistanzakind, pratica.idpratica, pratica.idreg,
 [dbo].statuskind.title AS statuskind_title, pratica.idstatuskind AS pratica_idstatuskind,
 [dbo].istattitolistudio.titolo AS istattitolistudio_titolo, [dbo].istattitolistudio.idistattitolistudio AS istattitolistudio_idistattitolistudio, [dbo].titolostudio.voto AS titolostudio_voto, [dbo].titolostudio.votosu AS titolostudio_votosu, [dbo].titolostudio.votolode AS titolostudio_votolode, [dbo].titolostudio.aa AS titolostudio_aa, pratica.idtitolostudio, pratica.lt AS pratica_lt, pratica.lu AS pratica_lu, pratica.protanno AS pratica_protanno, pratica.protnumero AS pratica_protnumero,
 isnull('Titolo : ' + [dbo].istattitolistudio.titolo + '; ','') + ' ' + isnull('Titolo : ' + CAST( [dbo].istattitolistudio.idistattitolistudio AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].pratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].dichiar WITH (NOLOCK) ON pratica.iddichiar = [dbo].dichiar.iddichiar
LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON pratica.idiscrizione = [dbo].iscrizione.idiscrizione
LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_pratica WITH (NOLOCK) ON pratica.idiscrizione_from = iscrizione_pratica.idiscrizione
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON pratica.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].titolostudio WITH (NOLOCK) ON pratica.idtitolostudio = [dbo].titolostudio.idtitolostudio
LEFT OUTER JOIN [dbo].istattitolistudio WITH (NOLOCK) ON titolostudio.idistattitolistudio = [dbo].istattitolistudio.idistattitolistudio
WHERE  pratica.idcorsostudio IS NOT NULL  AND pratica.iddidprog IS NOT NULL  AND pratica.idiscrizione IS NOT NULL  AND pratica.idistanza IS NOT NULL  AND pratica.idistanzakind IS NOT NULL  AND pratica.idpratica IS NOT NULL  AND pratica.idreg IS NOT NULL 
GO

-- VERIFICA DI praticasegistpassview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'praticasegistpassview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(9)','ASSISTENZA','dichiar_aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','nvarchar(1111)','ASSISTENZA','dropdown_title','1111','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','iddichiar','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','idiscrizione_from','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idpratica','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(9)','','iscrizione_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','','iscrizione_anno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','','iscrizione_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(9)','','iscrizione_pratica_aa','9','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','','iscrizione_pratica_anno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','','iscrizione_pratica_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','istattitolistudio_idistattitolistudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(1024)','ASSISTENZA','istattitolistudio_titolo','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','datetime','ASSISTENZA','pratica_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','varchar(64)','ASSISTENZA','pratica_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','int','ASSISTENZA','pratica_idstatuskind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','datetime','ASSISTENZA','pratica_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','praticasegistpassview','varchar(64)','ASSISTENZA','pratica_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','pratica_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','pratica_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(50)','ASSISTENZA','statuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','varchar(9)','ASSISTENZA','titolostudio_aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','titolostudio_voto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','char(1)','ASSISTENZA','titolostudio_votolode','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','praticasegistpassview','int','ASSISTENZA','titolostudio_votosu','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI praticasegistpassview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'praticasegistpassview')
UPDATE customobject set isreal = 'N' where objectname = 'praticasegistpassview'
ELSE
INSERT INTO customobject (objectname, isreal) values('praticasegistpassview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


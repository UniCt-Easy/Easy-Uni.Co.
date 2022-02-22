
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


-- CREAZIONE VISTA attivformerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformerogataview]
GO

CREATE VIEW [dbo].[attivformerogataview] AS 
SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, attivform.iddidprog,
 [dbo].didproganno.title AS didproganno_title, attivform.iddidproganno,
 [dbo].didprogcurr.title AS didprogcurr_title, attivform.iddidprogcurr,
 [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp,
 [dbo].didprogori.title AS didprogori_title, attivform.iddidprogori,
 [dbo].didprogporzanno.title AS didprogporzanno_title, attivform.iddidprogporzanno,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'P' THEN 'Profitto' WHEN attivform.tipovalutaz = 'I' THEN 'Idoneità' END AS attivform_tipovalutaz, attivform.title,
 isnull('Attività formativa: ' + attivform.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull(CAST(attivformcaratteristica.cf AS NVARCHAR(64)),'0.00') AS Crediti,attivformcaratteristica.json AS Caratteristiche,isnull((Select top 1 'Denominazione: ' +title from tipoattform x where x.idtipoattform = attivformcaratteristica.idtipoattform) + '; ','') AS Tipo_di_attività_formativa,isnull((Select top 1 'Ambito: ' +title from ambitoareadisc x where x.idambitoareadisc = attivformcaratteristica.idambitoareadisc) + '; ','') AS Ambito_o_area_disciplinare,isnull((Select top 1 'Gruppo: ' +title from sasdgruppo x where x.idsasdgruppo = attivformcaratteristica.idsasdgruppo) + '; ','') AS Gruppo,isnull((Select top 1 'Codice: ' +codice + '; ' + 'Denominazione: ' +title from sasd x where x.idsasd = attivformcaratteristica.idsasd) + '; ','') AS SASD,isnull('' + CASE WHEN attivformcaratteristica.profess = 'S' THEN 'Professionalizzante' ELSE 'non Professionalizzante' END,'') AS Professionalizzante FROM  dbo.attivformcaratteristica
 WHERE attivformcaratteristica.aa = attivform.aa AND attivformcaratteristica.idattivform = attivform.idattivform AND attivformcaratteristica.idcorsostudio = attivform.idcorsostudio AND attivformcaratteristica.iddidprog = attivform.iddidprog AND attivformcaratteristica.iddidproganno = attivform.iddidproganno AND attivformcaratteristica.iddidprogcurr = attivform.iddidprogcurr AND attivformcaratteristica.iddidprogori = attivform.iddidprogori AND attivformcaratteristica.iddidprogporzanno = attivform.iddidprogporzanno FOR XML path, root)))) AS XXattivformcaratteristica 
FROM [dbo].attivform WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON attivform.iddidproganno = [dbo].didproganno.iddidproganno
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON attivform.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON attivform.iddidprogori = [dbo].didprogori.iddidprogori
LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON attivform.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg
WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 
GO

-- VERIFICA DI attivformerogataview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'attivformerogataview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','datetime','ASSISTENZA','attivform_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','varchar(64)','ASSISTENZA','attivform_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','int','ASSISTENZA','attivform_iddidproggrupp','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','datetime','ASSISTENZA','attivform_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','varchar(64)','ASSISTENZA','attivform_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','nvarchar(max)','ASSISTENZA','attivform_obbform','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','nvarchar(max)','ASSISTENZA','attivform_obbform_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','int','ASSISTENZA','attivform_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','date','ASSISTENZA','attivform_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','date','ASSISTENZA','attivform_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(8)','ASSISTENZA','attivform_tipovalutaz','8','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(2048)','ASSISTENZA','didproganno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(256)','ASSISTENZA','didprogcurr_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(256)','ASSISTENZA','didproggrupp_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(256)','ASSISTENZA','didprogori_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(2048)','ASSISTENZA','didprogporzanno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','int','ASSISTENZA','idinsegninteg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformerogataview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(50)','ASSISTENZA','insegn_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(256)','ASSISTENZA','insegn_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(50)','ASSISTENZA','insegninteg_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','varchar(256)','ASSISTENZA','insegninteg_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','nvarchar(max)','ASSISTENZA','title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformerogataview','nvarchar(max)','','XXattivformcaratteristica','0','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI attivformerogataview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'attivformerogataview')
UPDATE customobject set isreal = 'N' where objectname = 'attivformerogataview'
ELSE
INSERT INTO customobject (objectname, isreal) values('attivformerogataview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


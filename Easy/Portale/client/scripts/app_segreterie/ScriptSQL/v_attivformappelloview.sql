
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


-- CREAZIONE VISTA attivformappelloview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[attivformappelloview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[attivformappelloview]
GO



CREATE VIEW [dbo].[attivformappelloview] AS SELECT  attivform.aa, attivform.ct AS attivform_ct, attivform.cu AS attivform_cu, attivform.idattivform, attivform.idcorsostudio, [dbo].didprog.title AS didprog_title, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].sede.title AS sede_title, attivform.iddidprog, attivform.iddidproganno, attivform.iddidprogcurr, [dbo].didproggrupp.title AS didproggrupp_title, attivform.iddidproggrupp AS attivform_iddidproggrupp, attivform.iddidprogori, attivform.iddidprogporzanno, [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, attivform.idinsegn, [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, attivform.idinsegninteg, sede_attivform.title AS sede_attivform_title, attivform.idsede, attivform.lt AS attivform_lt, attivform.lu AS attivform_lu, attivform.obbform AS attivform_obbform, attivform.obbform_en AS attivform_obbform_en, attivform.sortcode AS attivform_sortcode, attivform.start AS attivform_start, attivform.stop AS attivform_stop,CASE WHEN attivform.tipovalutaz = 'S' THEN 'Si' WHEN attivform.tipovalutaz = 'N' THEN 'No' END AS attivform_tipovalutaz, attivform.title, isnull('Attività formativa: ' + attivform.title + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') as dropdown_title FROM [dbo].attivform WITH (NOLOCK)  LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON attivform.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON didprog.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].didproggrupp WITH (NOLOCK) ON attivform.iddidproggrupp = [dbo].didproggrupp.iddidproggrupp LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON attivform.idinsegn = [dbo].insegn.idinsegn LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON attivform.idinsegninteg = [dbo].insegninteg.idinsegninteg LEFT OUTER JOIN [dbo].sede AS sede_attivform WITH (NOLOCK) ON attivform.idsede = sede_attivform.idsede WHERE  attivform.aa IS NOT NULL  AND attivform.idattivform IS NOT NULL  AND attivform.idcorsostudio IS NOT NULL  AND attivform.iddidprog IS NOT NULL  AND attivform.iddidproganno IS NOT NULL  AND attivform.iddidprogcurr IS NOT NULL  AND attivform.iddidprogori IS NOT NULL  AND attivform.iddidprogporzanno IS NOT NULL  AND attivform.idsede IS NOT NULL 

GO

-- VERIFICA DI attivformappelloview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'attivformappelloview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','datetime','ASSISTENZA','attivform_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','varchar(64)','ASSISTENZA','attivform_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','int','ASSISTENZA','attivform_iddidproggrupp','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','datetime','ASSISTENZA','attivform_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','varchar(64)','ASSISTENZA','attivform_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(max)','ASSISTENZA','attivform_obbform','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(max)','ASSISTENZA','attivform_obbform_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','int','ASSISTENZA','attivform_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','date','ASSISTENZA','attivform_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','date','ASSISTENZA','attivform_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(2)','ASSISTENZA','attivform_tipovalutaz','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(256)','ASSISTENZA','didproggrupp_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','int','ASSISTENZA','idinsegninteg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','attivformappelloview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(50)','ASSISTENZA','insegn_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(256)','ASSISTENZA','insegn_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(50)','ASSISTENZA','insegninteg_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','varchar(256)','ASSISTENZA','insegninteg_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(1024)','','sede_attivform_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','attivformappelloview','nvarchar(max)','ASSISTENZA','title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI attivformappelloview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'attivformappelloview')
UPDATE customobject set isreal = 'N' where objectname = 'attivformappelloview'
ELSE
INSERT INTO customobject (objectname, isreal) values('attivformappelloview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


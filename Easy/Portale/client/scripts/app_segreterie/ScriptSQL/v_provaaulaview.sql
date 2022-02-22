
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
-- CREAZIONE VISTA provaaulaview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provaaulaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provaaulaview]
GO

CREATE VIEW [dbo].[provaaulaview] AS SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello AS prova_idappello, [dbo].attivform.title AS attivform_title, prova.idattivform, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, prova.idcorsostudio, [dbo].didprog.title AS didprog_title, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].sede.title AS sede_title, prova.iddidprog, prova.idprova, [dbo].questionario.title AS questionario_title, prova.idquestionario, [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title, isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') as dropdown_title FROM [dbo].prova WITH (NOLOCK)  LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON prova.idattivform = [dbo].attivform.idattivform LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON prova.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON prova.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON didprog.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind WHERE  prova.idprova IS NOT NULL 
GO

-- VERIFICA DI provaaulaview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'provaaulaview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','nvarchar(9)','','annoaccademico_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','nvarchar(max)','ASSISTENZA','attivform_title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','','corsostudio_annoistituz','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','nvarchar(1185)','ASSISTENZA','dropdown_title','1185','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','idattivform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','int','ASSISTENZA','idprova','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','idquestionario','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','datetime','ASSISTENZA','prova_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','varchar(64)','ASSISTENZA','prova_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','prova_idappello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','int','ASSISTENZA','prova_idvalutazionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','datetime','ASSISTENZA','prova_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaaulaview','varchar(64)','ASSISTENZA','prova_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','nvarchar(max)','ASSISTENZA','prova_programma','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','datetime','ASSISTENZA','prova_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','datetime','ASSISTENZA','prova_stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','varchar(50)','ASSISTENZA','questionario_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','nvarchar(1024)','','sede_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaaulaview','varchar(50)','ASSISTENZA','valutazionekind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI provaaulaview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'provaaulaview')
UPDATE customobject set isreal = 'N' where objectname = 'provaaulaview'
ELSE
INSERT INTO customobject (objectname, isreal) values('provaaulaview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


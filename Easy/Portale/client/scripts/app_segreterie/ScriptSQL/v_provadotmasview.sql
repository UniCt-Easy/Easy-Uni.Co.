
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


--[DBO]--
-- CREAZIONE VISTA provadotmasview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provadotmasview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provadotmasview]
GO

CREATE VIEW [dbo].[provadotmasview] AS SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello AS prova_idappello, prova.idattivform AS prova_idattivform, prova.idcorsostudio, prova.iddidprog, prova.idprova, [dbo].questionario.title AS questionario_title, prova.idquestionario, [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title, isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') as dropdown_title FROM [dbo].prova WITH (NOLOCK)  LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind WHERE  prova.idcorsostudio IS NOT NULL  AND prova.iddidprog IS NOT NULL  AND prova.idprova IS NOT NULL 
GO

-- VERIFICA DI provadotmasview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'provadotmasview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','varchar(102)','ASSISTENZA','dropdown_title','102','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','int','ASSISTENZA','idprova','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','idquestionario','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','datetime','ASSISTENZA','prova_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','varchar(64)','ASSISTENZA','prova_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','prova_idappello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','prova_idattivform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','int','ASSISTENZA','prova_idvalutazionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','datetime','ASSISTENZA','prova_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provadotmasview','varchar(64)','ASSISTENZA','prova_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','nvarchar(max)','ASSISTENZA','prova_programma','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','datetime','ASSISTENZA','prova_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','datetime','ASSISTENZA','prova_stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','varchar(50)','ASSISTENZA','questionario_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provadotmasview','varchar(50)','ASSISTENZA','valutazionekind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI provadotmasview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'provadotmasview')
UPDATE customobject set isreal = 'N' where objectname = 'provadotmasview'
ELSE
INSERT INTO customobject (objectname, isreal) values('provadotmasview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

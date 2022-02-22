
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


-- CREAZIONE VISTA provaingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provaingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provaingressoview]
GO

CREATE VIEW [dbo].[provaingressoview] AS 
SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello AS prova_idappello, prova.idattivform AS prova_idattivform, prova.idcorsostudio, prova.iddidprog, prova.idprova,
 [dbo].questionario.title AS questionario_title, prova.idquestionario,
 [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title,(select top 1 idreg_docenti 
						from dbo.commiss 
						where dbo.commiss.idprova = prova.idprova
						 order by commiss.idcommiss asc ) as idreg_docenti,
 isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') as dropdown_title
FROM [dbo].prova WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario
LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind
WHERE  prova.idcorsostudio IS NOT NULL  AND prova.iddidprog IS NOT NULL  AND prova.idprova IS NOT NULL 
GO

-- VERIFICA DI provaingressoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'provaingressoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','varchar(102)','ASSISTENZA','dropdown_title','102','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','int','ASSISTENZA','idprova','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','idquestionario','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','datetime','ASSISTENZA','prova_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','varchar(64)','ASSISTENZA','prova_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','prova_idappello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','prova_idattivform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','int','ASSISTENZA','prova_idvalutazionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','datetime','ASSISTENZA','prova_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','provaingressoview','varchar(64)','ASSISTENZA','prova_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','nvarchar(max)','ASSISTENZA','prova_programma','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','datetime','ASSISTENZA','prova_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','datetime','ASSISTENZA','prova_stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','varchar(50)','ASSISTENZA','questionario_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','provaingressoview','varchar(50)','ASSISTENZA','valutazionekind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI provaingressoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'provaingressoview')
UPDATE customobject set isreal = 'N' where objectname = 'provaingressoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('provaingressoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


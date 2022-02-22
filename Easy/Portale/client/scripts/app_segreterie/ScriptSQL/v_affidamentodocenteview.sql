
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


-- CREAZIONE VISTA affidamentodocenteview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodocenteview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodocenteview]
GO

CREATE VIEW [dbo].[affidamentodocenteview] AS 
SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno,
 [dbo].erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title, affidamento.urlcorso AS affidamento_urlcorso,
 isnull('Denominazione: ' + affidamento.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT affidamentocaratteristica.json AS Caratteristiche FROM  dbo.affidamentocaratteristica
 WHERE affidamentocaratteristica.aa = affidamento.aa AND affidamentocaratteristica.idaffidamento = affidamento.idaffidamento AND affidamentocaratteristica.idattivform = affidamento.idattivform AND affidamentocaratteristica.idcanale = affidamento.idcanale AND affidamentocaratteristica.idcorsostudio = affidamento.idcorsostudio AND affidamentocaratteristica.iddidprog = affidamento.iddidprog AND affidamentocaratteristica.iddidproganno = affidamento.iddidproganno AND affidamentocaratteristica.iddidprogcurr = affidamento.iddidprogcurr AND affidamentocaratteristica.iddidprogori = affidamento.iddidprogori AND affidamentocaratteristica.iddidprogporzanno = affidamento.iddidprogporzanno FOR XML path, root)))) AS XXaffidamentocaratteristica 
FROM [dbo].affidamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = [dbo].erogazkind.iderogazkind
WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL  AND affidamento.idreg_docenti IS NOT NULL 
GO

-- VERIFICA DI affidamentodocenteview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentodocenteview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','datetime','ASSISTENZA','affidamento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','varchar(64)','ASSISTENZA','affidamento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(2)','ASSISTENZA','affidamento_freqobbl','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','int','ASSISTENZA','affidamento_frequenzaminima','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','int','ASSISTENZA','affidamento_frequenzaminimadebito','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(2)','ASSISTENZA','affidamento_gratuito','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','affidamento_idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','int','ASSISTENZA','affidamento_iderogazkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','affidamento_idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_json','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_jsonancestor','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','datetime','ASSISTENZA','affidamento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','varchar(64)','ASSISTENZA','affidamento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_orariric','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_orariric_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','int','ASSISTENZA','affidamento_paridaffidamento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_prog','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_prog_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(2)','ASSISTENZA','affidamento_riferimento','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','date','ASSISTENZA','affidamento_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','date','ASSISTENZA','affidamento_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_testi','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','affidamento_testi_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(512)','ASSISTENZA','affidamento_urlcorso','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(50)','ASSISTENZA','affidamentokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','varchar(50)','ASSISTENZA','erogazkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocenteview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocenteview','nvarchar(max)','ASSISTENZA','XXaffidamentocaratteristica','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentodocenteview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentodocenteview')
UPDATE customobject set isreal = 'N' where objectname = 'affidamentodocenteview'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentodocenteview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


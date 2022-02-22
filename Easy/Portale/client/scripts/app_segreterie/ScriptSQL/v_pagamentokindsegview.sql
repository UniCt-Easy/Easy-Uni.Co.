
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


-- CREAZIONE VISTA pagamentokindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pagamentokindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pagamentokindsegview]
GO

CREATE VIEW [dbo].[pagamentokindsegview] AS 
SELECT CASE WHEN pagamentokind.active = 'S' THEN 'Si' WHEN pagamentokind.active = 'N' THEN 'No' END AS pagamentokind_active, pagamentokind.ct AS pagamentokind_ct, pagamentokind.cu AS pagamentokind_cu, pagamentokind.idpagamentokind, pagamentokind.lt AS pagamentokind_lt, pagamentokind.lu AS pagamentokind_lu, pagamentokind.sortcode AS pagamentokind_sortcode, pagamentokind.title,
 isnull('Tipologia: ' + pagamentokind.title + '; ','') as dropdown_title
FROM [dbo].pagamentokind WITH (NOLOCK) 
WHERE  pagamentokind.idpagamentokind IS NOT NULL 
GO

-- VERIFICA DI pagamentokindsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pagamentokindsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','varchar(63)','ASSISTENZA','dropdown_title','63','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','int','ASSISTENZA','idpagamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pagamentokindsegview','varchar(2)','ASSISTENZA','pagamentokind_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','datetime','ASSISTENZA','pagamentokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','varchar(64)','ASSISTENZA','pagamentokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','datetime','ASSISTENZA','pagamentokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','varchar(64)','ASSISTENZA','pagamentokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','int','ASSISTENZA','pagamentokind_sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pagamentokindsegview','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pagamentokindsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pagamentokindsegview')
UPDATE customobject set isreal = 'N' where objectname = 'pagamentokindsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pagamentokindsegview', 'N')
GO

-- GENERAZIONE DATI PER pagamentokindsegview --
-- FINE GENERAZIONE SCRIPT --


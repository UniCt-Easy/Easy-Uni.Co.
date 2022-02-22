
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


-- CREAZIONE VISTA inquadramentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inquadramentodefaultview]
GO

CREATE VIEW [dbo].[inquadramentodefaultview] AS 
SELECT  inquadramento.costolordoannuo AS inquadramento_costolordoannuo, inquadramento.costolordoannuooneri AS inquadramento_costolordoannuooneri, inquadramento.ct AS inquadramento_ct, inquadramento.cu AS inquadramento_cu, inquadramento.idcontrattokind, inquadramento.idinquadramento, inquadramento.lt AS inquadramento_lt, inquadramento.lu AS inquadramento_lu, inquadramento.siglaimportazione AS inquadramento_siglaimportazione, inquadramento.start AS inquadramento_start, inquadramento.stop AS inquadramento_stop,CASE WHEN inquadramento.tempdef = 'S' THEN 'Si' WHEN inquadramento.tempdef = 'N' THEN 'No' END AS inquadramento_tempdef, inquadramento.title,
 isnull('Denominazione: ' + inquadramento.title + '; ','') + ' ' + isnull('' + CASE WHEN inquadramento.tempdef = 'S' THEN 'Tempo definito' ELSE 'non Tempo definito' END,'') as dropdown_title
FROM [dbo].inquadramento WITH (NOLOCK) 
WHERE  inquadramento.idcontrattokind IS NOT NULL  AND inquadramento.idinquadramento IS NOT NULL 
GO

-- VERIFICA DI inquadramentodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inquadramentodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','varchar(2085)','ASSISTENZA','dropdown_title','2085','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','int','ASSISTENZA','idinquadramento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','decimal(9,2)','','inquadramento_costolordoannuo','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','decimal(9,2)','','inquadramento_costolordoannuooneri','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','datetime','ASSISTENZA','inquadramento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','varchar(64)','ASSISTENZA','inquadramento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','datetime','ASSISTENZA','inquadramento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentodefaultview','varchar(64)','ASSISTENZA','inquadramento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','varchar(1024)','','inquadramento_siglaimportazione','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','datetime','','inquadramento_start','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','datetime','','inquadramento_stop','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','varchar(2)','','inquadramento_tempdef','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentodefaultview','varchar(2048)','','title','2048','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI inquadramentodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inquadramentodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'inquadramentodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('inquadramentodefaultview', 'N')
GO

-- GENERAZIONE DATI PER inquadramentodefaultview --
-- FINE GENERAZIONE SCRIPT --


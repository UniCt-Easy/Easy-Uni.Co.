
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


-- CREAZIONE VISTA inquadramentoelencoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramentoelencoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inquadramentoelencoview]
GO

CREATE VIEW [dbo].[inquadramentoelencoview] AS 
SELECT  inquadramento.costolordoannuo AS inquadramento_costolordoannuo, inquadramento.costolordoannuooneri AS inquadramento_costolordoannuooneri, inquadramento.ct AS inquadramento_ct, inquadramento.cu AS inquadramento_cu,
 [dbo].contrattokind.title AS contrattokind_title, inquadramento.idcontrattokind, inquadramento.idinquadramento, inquadramento.lt AS inquadramento_lt, inquadramento.lu AS inquadramento_lu, inquadramento.siglaimportazione AS inquadramento_siglaimportazione, inquadramento.start AS inquadramento_start, inquadramento.stop AS inquadramento_stop,CASE WHEN inquadramento.tempdef = 'S' THEN 'Si' WHEN inquadramento.tempdef = 'N' THEN 'No' END AS inquadramento_tempdef, inquadramento.title AS inquadramento_title,
 isnull('Tipologia contrattuale: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('Inquadramento: ' + inquadramento.title + '; ','') as dropdown_title
FROM [dbo].inquadramento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON inquadramento.idcontrattokind = [dbo].contrattokind.idcontrattokind
WHERE  inquadramento.idcontrattokind IS NOT NULL  AND inquadramento.idinquadramento IS NOT NULL 
GO

-- VERIFICA DI inquadramentoelencoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inquadramentoelencoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','varchar(2142)','ASSISTENZA','dropdown_title','2142','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','int','ASSISTENZA','idinquadramento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','decimal(9,2)','ASSISTENZA','inquadramento_costolordoannuo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','decimal(9,2)','ASSISTENZA','inquadramento_costolordoannuooneri','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','datetime','ASSISTENZA','inquadramento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','varchar(64)','ASSISTENZA','inquadramento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','datetime','ASSISTENZA','inquadramento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramentoelencoview','varchar(64)','ASSISTENZA','inquadramento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','varchar(1024)','','inquadramento_siglaimportazione','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','datetime','ASSISTENZA','inquadramento_start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','datetime','ASSISTENZA','inquadramento_stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','varchar(2)','ASSISTENZA','inquadramento_tempdef','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramentoelencoview','varchar(2048)','ASSISTENZA','inquadramento_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI inquadramentoelencoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inquadramentoelencoview')
UPDATE customobject set isreal = 'N' where objectname = 'inquadramentoelencoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('inquadramentoelencoview', 'N')
GO

-- GENERAZIONE DATI PER inquadramentoelencoview --
-- FINE GENERAZIONE SCRIPT --


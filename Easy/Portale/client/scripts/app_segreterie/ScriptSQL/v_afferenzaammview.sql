
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


-- CREAZIONE VISTA afferenzaammview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[afferenzaammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[afferenzaammview]
GO

CREATE VIEW [dbo].[afferenzaammview] AS 
SELECT  afferenza.ct AS afferenza_ct, afferenza.cu AS afferenza_cu, afferenza.idafferenza,
 [dbo].mansionekind.title AS mansionekind_title, afferenza.idmansionekind AS afferenza_idmansionekind, afferenza.idreg,
 [dbo].struttura.title AS struttura_title, strutturaparent.title AS strutturaparent_title, [dbo].struttura.paridstruttura AS struttura_paridstruttura, afferenza.idstruttura, afferenza.lt AS afferenza_lt, afferenza.lu AS afferenza_lu, afferenza.start AS afferenza_start, afferenza.stop AS afferenza_stop,
 isnull('U.O.: ' + [dbo].struttura.title + '; ','') + ' ' + isnull('Denominazione U.O. madre: ' + strutturaparent.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, afferenza.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, afferenza.stop, 103),'') + ' ' + isnull('Mansione: ' + [dbo].mansionekind.title + '; ','') as dropdown_title
FROM [dbo].afferenza WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON [dbo].struttura.paridstruttura = strutturaparent.idstruttura
WHERE  afferenza.idafferenza IS NOT NULL  AND afferenza.idreg IS NOT NULL 
GO

-- VERIFICA DI afferenzaammview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'afferenzaammview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','datetime','ASSISTENZA','afferenza_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','varchar(64)','ASSISTENZA','afferenza_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','int','ASSISTENZA','afferenza_idmansionekind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','datetime','ASSISTENZA','afferenza_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','varchar(64)','ASSISTENZA','afferenza_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','date','ASSISTENZA','afferenza_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','date','ASSISTENZA','afferenza_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','varchar(4215)','ASSISTENZA','dropdown_title','4215','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','int','ASSISTENZA','idafferenza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','afferenzaammview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','varchar(2048)','ASSISTENZA','mansionekind_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','int','ASSISTENZA','struttura_paridstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','afferenzaammview','varchar(1024)','ASSISTENZA','strutturaparent_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI afferenzaammview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'afferenzaammview')
UPDATE customobject set isreal = 'N' where objectname = 'afferenzaammview'
ELSE
INSERT INTO customobject (objectname, isreal) values('afferenzaammview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


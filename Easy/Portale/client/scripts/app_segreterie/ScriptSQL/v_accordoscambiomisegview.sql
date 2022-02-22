
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


-- CREAZIONE VISTA accordoscambiomisegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomisegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomisegview]
GO

CREATE VIEW [dbo].[accordoscambiomisegview] AS 
SELECT  accordoscambiomi.aa_start, accordoscambiomi.aa_stop, accordoscambiomi.ct AS accordoscambiomi_ct, accordoscambiomi.cu AS accordoscambiomi_cu, accordoscambiomi.description AS accordoscambiomi_description, accordoscambiomi.idaccordoscambiomi,
 [dbo].programmami.acronimo AS programmami_acronimo, accordoscambiomi.idprogrammami, accordoscambiomi.lt AS accordoscambiomi_lt, accordoscambiomi.lu AS accordoscambiomi_lu, accordoscambiomi.title,
 isnull('Titolo: ' + accordoscambiomi.title + '; ','') as dropdown_title
FROM [dbo].accordoscambiomi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].programmami WITH (NOLOCK) ON accordoscambiomi.idprogrammami = [dbo].programmami.idprogrammami
WHERE  accordoscambiomi.idaccordoscambiomi IS NOT NULL 
GO

-- VERIFICA DI accordoscambiomisegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomisegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','varchar(9)','ASSISTENZA','aa_start','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomisegview','varchar(9)','ASSISTENZA','aa_stop','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','datetime','ASSISTENZA','accordoscambiomi_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','varchar(64)','ASSISTENZA','accordoscambiomi_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomisegview','varchar(max)','ASSISTENZA','accordoscambiomi_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','datetime','ASSISTENZA','accordoscambiomi_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','varchar(64)','ASSISTENZA','accordoscambiomi_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','int','ASSISTENZA','idaccordoscambiomi','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomisegview','int','ASSISTENZA','idprogrammami','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomisegview','varchar(50)','ASSISTENZA','programmami_acronimo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomisegview','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accordoscambiomisegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomisegview')
UPDATE customobject set isreal = 'N' where objectname = 'accordoscambiomisegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomisegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


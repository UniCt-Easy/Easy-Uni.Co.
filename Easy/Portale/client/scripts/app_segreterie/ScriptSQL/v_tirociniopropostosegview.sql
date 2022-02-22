
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


-- CREAZIONE VISTA tirociniopropostosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirociniopropostosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[tirociniopropostosegview]
GO

CREATE VIEW [dbo].[tirociniopropostosegview] AS 
SELECT  tirocinioproposto.ct AS tirocinioproposto_ct, tirocinioproposto.cu AS tirocinioproposto_cu, tirocinioproposto.description AS tirocinioproposto_description, tirocinioproposto.description_en AS tirocinioproposto_description_en,
 [dbo].aoo.title AS aoo_title, tirocinioproposto.idaoo,
 registryreferente.title AS registryreferente_title, tirocinioproposto.idreg_referente,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, tirocinioproposto.idstruttura, tirocinioproposto.idtirocinioproposto, tirocinioproposto.lt AS tirocinioproposto_lt, tirocinioproposto.lu AS tirocinioproposto_lu, tirocinioproposto.ore AS tirocinioproposto_ore, tirocinioproposto.title, tirocinioproposto.title_en AS tirocinioproposto_title_en,
 isnull('Titolo: ' + tirocinioproposto.title + '; ','') + ' ' + isnull('Descrizione: ' + tirocinioproposto.description + '; ','') + ' ' + isnull('Descrizione in inglese: ' + tirocinioproposto.description_en + '; ','') as dropdown_title
FROM [dbo].tirocinioproposto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON tirocinioproposto.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].registry AS registryreferente WITH (NOLOCK) ON tirocinioproposto.idreg_referente = registryreferente.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON tirocinioproposto.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  tirocinioproposto.idreg_referente IS NOT NULL  AND tirocinioproposto.idtirocinioproposto IS NOT NULL 
GO

-- VERIFICA DI tirociniopropostosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirociniopropostosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(1024)','ASSISTENZA','aoo_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','int','ASSISTENZA','idreg_referente','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','int','ASSISTENZA','idtirocinioproposto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(101)','ASSISTENZA','registryreferente_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','int','','struttura_idstrutturakind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','datetime','ASSISTENZA','tirocinioproposto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','varchar(64)','ASSISTENZA','tirocinioproposto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(max)','ASSISTENZA','tirocinioproposto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(max)','ASSISTENZA','tirocinioproposto_description_en','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','datetime','ASSISTENZA','tirocinioproposto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','varchar(64)','ASSISTENZA','tirocinioproposto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','int','ASSISTENZA','tirocinioproposto_ore','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirociniopropostosegview','varchar(max)','ASSISTENZA','tirocinioproposto_title_en','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirociniopropostosegview','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tirociniopropostosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirociniopropostosegview')
UPDATE customobject set isreal = 'N' where objectname = 'tirociniopropostosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirociniopropostosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


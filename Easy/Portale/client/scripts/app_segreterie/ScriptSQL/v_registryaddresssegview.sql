
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


-- CREAZIONE VISTA registryaddresssegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddresssegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaddresssegview]
GO

CREATE VIEW [dbo].[registryaddresssegview] AS 
SELECT CASE WHEN registryaddress.active = 'S' THEN 'Si' WHEN registryaddress.active = 'N' THEN 'No' END AS registryaddress_active, registryaddress.address AS registryaddress_address, registryaddress.annotations AS registryaddress_annotations, registryaddress.cap AS registryaddress_cap, registryaddress.ct AS registryaddress_ct, registryaddress.cu AS registryaddress_cu,CASE WHEN registryaddress.flagforeign = 'S' THEN 'Si' WHEN registryaddress.flagforeign = 'N' THEN 'No' END AS registryaddress_flagforeign,
 [dbo].address.description AS address_description, registryaddress.idaddresskind,
 [dbo].geo_city.title AS geo_city_title, registryaddress.idcity,
 [dbo].geo_nation.title AS geo_nation_title, registryaddress.idnation, registryaddress.idreg, registryaddress.location AS registryaddress_location, registryaddress.lt AS registryaddress_lt, registryaddress.lu AS registryaddress_lu, registryaddress.officename AS registryaddress_officename, registryaddress.recipientagency AS registryaddress_recipientagency, registryaddress.start, registryaddress.stop AS registryaddress_stop,
 isnull('Tipologia: ' + [dbo].address.description + '; ','') + ' ' + isnull('Indirizzo: ' + registryaddress.address + '; ','') + ' ' + isnull('CAP: ' + registryaddress.cap + '; ','') + ' ' + isnull('Comune: ' + [dbo].geo_city.title + '; ','') + ' ' + isnull('Nazione: ' + [dbo].geo_nation.title + '; ','') as dropdown_title
FROM [dbo].registryaddress WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].address WITH (NOLOCK) ON registryaddress.idaddresskind = [dbo].address.idaddress
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registryaddress.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registryaddress.idnation = [dbo].geo_nation.idnation
WHERE  registryaddress.idaddresskind IS NOT NULL  AND registryaddress.idreg IS NOT NULL  AND registryaddress.start IS NOT NULL 
GO

-- VERIFICA DI registryaddresssegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryaddresssegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(60)','ASSISTENZA','address_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddresssegview','varchar(368)','','dropdown_title','368','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddresssegview','int','ASSISTENZA','idaddresskind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddresssegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(2)','ASSISTENZA','registryaddress_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(100)','ASSISTENZA','registryaddress_address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(400)','ASSISTENZA','registryaddress_annotations','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(20)','ASSISTENZA','registryaddress_cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','datetime','ASSISTENZA','registryaddress_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(64)','ASSISTENZA','registryaddress_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(2)','ASSISTENZA','registryaddress_flagforeign','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(50)','ASSISTENZA','registryaddress_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','datetime','ASSISTENZA','registryaddress_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(64)','ASSISTENZA','registryaddress_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(50)','ASSISTENZA','registryaddress_officename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','varchar(50)','ASSISTENZA','registryaddress_recipientagency','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddresssegview','date','ASSISTENZA','registryaddress_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddresssegview','date','ASSISTENZA','start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryaddresssegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryaddresssegview')
UPDATE customobject set isreal = 'N' where objectname = 'registryaddresssegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryaddresssegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


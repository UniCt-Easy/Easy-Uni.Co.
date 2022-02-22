
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


--[DBO]--
-- CREAZIONE VISTA geo_regionsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_regionsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_regionsegview]
GO

CREATE VIEW [dbo].[geo_regionsegview] AS SELECT  [dbo].geo_nation.title AS geo_nation_title, geo_region.idnation, geo_region.idregion, geo_region.lt AS geo_region_lt, geo_region.lu AS geo_region_lu, geo_region_1.title AS geo_region_1_title, geo_region.newregion, geo_region_2.title AS geo_region_2_title, geo_region.oldregion, geo_region.start AS geo_region_start, geo_region.stop AS geo_region_stop, geo_region.title, isnull('Denominazione: ' + geo_region.title + '; ','') as dropdown_title FROM [dbo].geo_region WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON geo_region.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].geo_region AS geo_region_1 WITH (NOLOCK) ON geo_region.newregion = geo_region_1.idregion LEFT OUTER JOIN [dbo].geo_region AS geo_region_2 WITH (NOLOCK) ON geo_region.oldregion = geo_region_2.idregion WHERE  geo_region.idregion IS NOT NULL 
GO

-- VERIFICA DI geo_regionsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_regionsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_regionsegview','varchar(67)','ASSISTENZA','dropdown_title','67','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','varchar(50)','ASSISTENZA','geo_region_1_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','varchar(50)','ASSISTENZA','geo_region_2_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','datetime','ASSISTENZA','geo_region_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','varchar(64)','ASSISTENZA','geo_region_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','date','ASSISTENZA','geo_region_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','date','ASSISTENZA','geo_region_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_regionsegview','int','ASSISTENZA','idregion','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','int','ASSISTENZA','newregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','int','ASSISTENZA','oldregion','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_regionsegview','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_regionsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_regionsegview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_regionsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_regionsegview', 'N')
GO

-- GENERAZIONE DATI PER geo_regionsegview --
-- FINE GENERAZIONE SCRIPT --



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
-- CREAZIONE VISTA geo_nationsegchildview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nationsegchildview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_nationsegchildview]
GO

CREATE VIEW [dbo].[geo_nationsegchildview] AS SELECT  geo_nation.idcontinent AS geo_nation_idcontinent, geo_nation.idnation, geo_nation.lang AS geo_nation_lang, geo_nation.lt AS geo_nation_lt, geo_nation.lu AS geo_nation_lu, geo_nation_1.title AS geo_nation_1_title, geo_nation.newnation, geo_nation_2.title AS geo_nation_2_title, geo_nation.oldnation, geo_nation.start AS geo_nation_start, geo_nation.stop AS geo_nation_stop, geo_nation.title, isnull('Denominazione: ' + geo_nation.title + '; ','') as dropdown_title FROM [dbo].geo_nation WITH (NOLOCK)  LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_1 WITH (NOLOCK) ON geo_nation.newnation = geo_nation_1.idnation LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_2 WITH (NOLOCK) ON geo_nation.oldnation = geo_nation_2.idnation WHERE  geo_nation.idnation IS NOT NULL 
GO

-- VERIFICA DI geo_nationsegchildview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_nationsegchildview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_nationsegchildview','varchar(82)','ASSISTENZA','dropdown_title','82','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','varchar(65)','ASSISTENZA','geo_nation_1_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','varchar(65)','ASSISTENZA','geo_nation_2_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','int','ASSISTENZA','geo_nation_idcontinent','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','varchar(64)','ASSISTENZA','geo_nation_lang','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','datetime','ASSISTENZA','geo_nation_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','varchar(64)','ASSISTENZA','geo_nation_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','date','ASSISTENZA','geo_nation_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','date','ASSISTENZA','geo_nation_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_nationsegchildview','int','ASSISTENZA','idnation','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','int','ASSISTENZA','newnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','int','ASSISTENZA','oldnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationsegchildview','varchar(65)','ASSISTENZA','title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_nationsegchildview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_nationsegchildview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_nationsegchildview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_nationsegchildview', 'N')
GO

-- GENERAZIONE DATI PER geo_nationsegchildview --
-- FINE GENERAZIONE SCRIPT --


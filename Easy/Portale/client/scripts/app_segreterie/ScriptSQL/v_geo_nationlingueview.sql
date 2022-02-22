
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


-- CREAZIONE VISTA geo_nationlingueview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nationlingueview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_nationlingueview]
GO

CREATE VIEW [dbo].[geo_nationlingueview] AS 
SELECT 
 [dbo].geo_continent.title AS geo_continent_title, geo_nation.idcontinent, geo_nation.idnation, geo_nation.lang, geo_nation.lt AS geo_nation_lt, geo_nation.lu AS geo_nation_lu,
 geo_nation_1.title AS geo_nation_1_title, geo_nation.newnation,
 geo_nation_2.title AS geo_nation_2_title, geo_nation.oldnation, geo_nation.start AS geo_nation_start, geo_nation.stop AS geo_nation_stop, geo_nation.title AS geo_nation_title,
 isnull('Lingua: ' + geo_nation.lang + '; ','') as dropdown_title
FROM [dbo].geo_nation WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_continent WITH (NOLOCK) ON geo_nation.idcontinent = [dbo].geo_continent.idcontinent
LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_1 WITH (NOLOCK) ON geo_nation.newnation = geo_nation_1.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nation_2 WITH (NOLOCK) ON geo_nation.oldnation = geo_nation_2.idnation
WHERE  geo_nation.idnation IS NOT NULL  AND geo_nation.lang <> ''
GO

-- VERIFICA DI geo_nationlingueview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_nationlingueview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_nationlingueview','varchar(74)','ASSISTENZA','dropdown_title','74','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','nvarchar(50)','ASSISTENZA','geo_continent_title','50','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','varchar(65)','ASSISTENZA','geo_nation_1_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','varchar(65)','ASSISTENZA','geo_nation_2_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','datetime','ASSISTENZA','geo_nation_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','varchar(64)','ASSISTENZA','geo_nation_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','date','ASSISTENZA','geo_nation_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','date','ASSISTENZA','geo_nation_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','int','ASSISTENZA','idcontinent','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','geo_nationlingueview','int','ASSISTENZA','idnation','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','varchar(64)','ASSISTENZA','lang','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','int','ASSISTENZA','newnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','geo_nationlingueview','int','ASSISTENZA','oldnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI geo_nationlingueview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_nationlingueview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_nationlingueview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_nationlingueview', 'N')
GO

-- GENERAZIONE DATI PER geo_nationlingueview --
-- FINE GENERAZIONE SCRIPT --


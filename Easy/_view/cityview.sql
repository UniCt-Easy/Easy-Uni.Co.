
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


-- CREAZIONE VISTA cityview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cityview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[cityview]
GO

CREATE VIEW dbo.cityview
AS
SELECT     *
FROM         dbo.geo_city
WHERE     (newcity IS NULL) AND (NOT EXISTS
                          (SELECT     *
                            FROM          geo_city g
                            WHERE      g.OLDcity = geo_city.idcity))

GO

-- VERIFICA DI cityview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cityview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'cityview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'cityview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','cityview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'idcountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'cityview' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','cityview','N','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'cityview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','cityview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'cityview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','cityview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'newcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '4',field = 'newcity',col_precision = '' where tablename = 'cityview' AND field = 'newcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','cityview','N','','4','newcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'oldcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '4',field = 'oldcity',col_precision = '' where tablename = 'cityview' AND field = 'oldcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','cityview','N','','4','oldcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'cityview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','cityview','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'cityview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','cityview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'cityview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'cityview',denynull = 'N',format = '',col_len = '65',field = 'title',col_precision = '' where tablename = 'cityview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','cityview','N','','65','title','')
GO

-- VERIFICA DI cityview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cityview')
UPDATE customobject set isreal = 'N' where objectname = 'cityview'
ELSE
INSERT INTO customobject (objectname, isreal) values('cityview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


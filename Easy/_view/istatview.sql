
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA istatview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istatview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istatview]
GO

CREATE VIEW dbo.istatview
AS
SELECT     dbo.cityview.idcity, dbo.cityview.idcountry, dbo.cityview.lt, dbo.cityview.lu, dbo.cityview.newcity, dbo.cityview.oldcity, dbo.cityview.title, 
                      dbo.geo_city_agency.idagency, dbo.geo_city_agency.idcode, dbo.geo_city_agency.version, dbo.geo_city_agency.start, dbo.geo_city_agency.stop, 
                      dbo.geo_city_agency.[value], dbo.cityview.start AS startcity, dbo.cityview.stop AS stopcity
FROM         dbo.cityview INNER JOIN
                      dbo.geo_city_agency ON dbo.cityview.idcity = dbo.geo_city_agency.idcity
WHERE     (dbo.geo_city_agency.idagency = 2) AND (dbo.geo_city_agency.version =
                          (SELECT     MAX(version)
                            FROM          geo_city_agency g2
                            WHERE      geo_city_agency.idcity = g2.idcity AND g2.idagency = 2))

GO

-- VERIFICA DI istatview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istatview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'idagency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'S',format = '',col_len = '4',field = 'idagency',col_precision = '' where tablename = 'istatview' AND field = 'idagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','istatview','S','','4','idagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'istatview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','istatview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'idcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'S',format = '',col_len = '4',field = 'idcode',col_precision = '' where tablename = 'istatview' AND field = 'idcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','istatview','S','','4','idcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'idcountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'istatview' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','istatview','N','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'istatview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','istatview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'istatview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','istatview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'newcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'newcity',col_precision = '' where tablename = 'istatview' AND field = 'newcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','istatview','N','','4','newcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'oldcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'oldcity',col_precision = '' where tablename = 'istatview' AND field = 'oldcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','istatview','N','','4','oldcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'istatview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','istatview','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'startcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'startcity',col_precision = '' where tablename = 'istatview' AND field = 'startcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','istatview','N','','4','startcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'istatview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','istatview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'stopcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '4',field = 'stopcity',col_precision = '' where tablename = 'istatview' AND field = 'stopcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','istatview','N','','4','stopcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '65',field = 'title',col_precision = '' where tablename = 'istatview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','istatview','N','','65','title','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'value')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'istatview',denynull = 'N',format = '',col_len = '20',field = 'value',col_precision = '' where tablename = 'istatview' AND field = 'value'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','istatview','N','','20','value','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'istatview' AND field = 'version')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'istatview',denynull = 'S',format = '',col_len = '4',field = 'version',col_precision = '' where tablename = 'istatview' AND field = 'version'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','istatview','S','','4','version','')
GO

-- VERIFICA DI istatview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istatview')
UPDATE customobject set isreal = 'N' where objectname = 'istatview'
ELSE
INSERT INTO customobject (objectname, isreal) values('istatview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


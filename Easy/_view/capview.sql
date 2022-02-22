
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


-- CREAZIONE VISTA capview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[capview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[capview]
GO

CREATE VIEW dbo.capview
AS
SELECT     dbo.geo_city.title, dbo.geo_city_agency.*
FROM         dbo.geo_city INNER JOIN
                      dbo.geo_city_agency ON dbo.geo_city.idcity = dbo.geo_city_agency.idcity
WHERE     (dbo.geo_city_agency.idagency = 3) AND (dbo.geo_city_agency.idcode = 1) AND (dbo.geo_city_agency.stop IS NULL)

GO

-- VERIFICA DI capview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'capview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'idagency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'capview',denynull = 'S',format = '',col_len = '4',field = 'idagency',col_precision = '' where tablename = 'capview' AND field = 'idagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','capview','S','','4','idagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'capview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'capview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','capview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'idcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'capview',denynull = 'S',format = '',col_len = '4',field = 'idcode',col_precision = '' where tablename = 'capview' AND field = 'idcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','capview','S','','4','idcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'capview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','capview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'capview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','capview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'capview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','capview','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'capview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','capview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '65',field = 'title',col_precision = '' where tablename = 'capview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','capview','N','','65','title','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'value')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'capview',denynull = 'N',format = '',col_len = '20',field = 'value',col_precision = '' where tablename = 'capview' AND field = 'value'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','capview','N','','20','value','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'capview' AND field = 'version')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'capview',denynull = 'S',format = '',col_len = '4',field = 'version',col_precision = '' where tablename = 'capview' AND field = 'version'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','capview','S','','4','version','')
GO

-- VERIFICA DI capview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'capview')
UPDATE customobject set isreal = 'N' where objectname = 'capview'
ELSE
INSERT INTO customobject (objectname, isreal) values('capview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


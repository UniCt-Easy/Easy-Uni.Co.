
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


-- CREAZIONE VISTA geo_nationusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nationusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_nationusable]
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:01
CREATE                                    view [DBO].[geo_nationusable] as 
	select * from geo_nation g1 where newnation is null and stop is null
	and not exists (select * from geo_nation g2 where g1.idnation=g2.oldnation)



GO

-- VERIFICA DI geo_nationusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_nationusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'idcontinent')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '4',field = 'idcontinent',col_precision = '' where tablename = 'geo_nationusable' AND field = 'idcontinent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_nationusable','N','','4','idcontinent','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'idnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_nationusable',denynull = 'S',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'geo_nationusable' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_nationusable','S','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'geo_nationusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','geo_nationusable','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'geo_nationusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(64)','N','geo_nationusable','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'newnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '4',field = 'newnation',col_precision = '' where tablename = 'geo_nationusable' AND field = 'newnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_nationusable','N','','4','newnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'oldnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '4',field = 'oldnation',col_precision = '' where tablename = 'geo_nationusable' AND field = 'oldnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_nationusable','N','','4','oldnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'geo_nationusable' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_nationusable','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'geo_nationusable' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_nationusable','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_nationusable' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'geo_nationusable',denynull = 'N',format = '',col_len = '65',field = 'title',col_precision = '' where tablename = 'geo_nationusable' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_nationusable','N','','65','title','')
GO

-- VERIFICA DI geo_nationusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_nationusable')
UPDATE customobject set isreal = 'N' where objectname = 'geo_nationusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_nationusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


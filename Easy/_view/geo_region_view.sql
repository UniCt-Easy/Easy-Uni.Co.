
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


-- CREAZIONE VISTA geo_region_view
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_region_view]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_region_view]
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                   VIEW [DBO].[geo_region_view]
(
idregion, 
title, 
start, 
stop, 
oldregion, 
newregion, 
idnation, 
idcontinent, 
nation, 
nationdatestart, 
nationdatestop, 
oldnation, 
newnation
)
AS
SELECT     geo_region.idregion, 
                      geo_region.title, geo_region.start, geo_region.stop, 
                      geo_region.oldregion, geo_region.newregion, geo_nation.idnation, geo_nation.idcontinent, 
                      geo_nation.title AS nazione, geo_nation.start AS datainizionazione, geo_nation.stop AS datafinenazione, 
                      geo_nation.oldnation, geo_nation.newnation
FROM       geo_region INNER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation



GO

-- VERIFICA DI geo_region_view IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_region_view'
IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'idcontinent')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'idcontinent',col_precision = '' where tablename = 'geo_region_view' AND field = 'idcontinent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_region_view','N','','4','idcontinent','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'idnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'S',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'geo_region_view' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_region_view','S','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'idregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'S',format = '',col_len = '4',field = 'idregion',col_precision = '' where tablename = 'geo_region_view' AND field = 'idregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','geo_region_view','S','','4','idregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'nation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'geo_region_view' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_region_view','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'nationdatestart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'nationdatestart',col_precision = '' where tablename = 'geo_region_view' AND field = 'nationdatestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_region_view','N','','4','nationdatestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'nationdatestop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'nationdatestop',col_precision = '' where tablename = 'geo_region_view' AND field = 'nationdatestop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_region_view','N','','4','nationdatestop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'newnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'newnation',col_precision = '' where tablename = 'geo_region_view' AND field = 'newnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_region_view','N','','4','newnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'newregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'newregion',col_precision = '' where tablename = 'geo_region_view' AND field = 'newregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_region_view','N','','4','newregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'oldnation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'oldnation',col_precision = '' where tablename = 'geo_region_view' AND field = 'oldnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_region_view','N','','4','oldnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'oldregion')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'oldregion',col_precision = '' where tablename = 'geo_region_view' AND field = 'oldregion'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','S','System.Int32','int','N','geo_region_view','N','','4','oldregion','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'geo_region_view' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_region_view','N','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'geo_region_view' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_region_view','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'geo_region_view' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'geo_region_view',denynull = 'N',format = '',col_len = '50',field = 'title',col_precision = '' where tablename = 'geo_region_view' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_region_view','N','','50','title','')
GO

-- VERIFICA DI geo_region_view IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_region_view')
UPDATE customobject set isreal = 'N' where objectname = 'geo_region_view'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_region_view', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


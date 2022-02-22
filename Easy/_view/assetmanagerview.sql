
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA assetmanagerview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetmanagerview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetmanagerview]
GO



CREATE VIEW assetmanagerview
(
	idasset,
	start,
	idman,
	manager,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetmanager.idasset,
	assetmanager.start,
	assetmanager.idman,
	manager.title,
	assetmanager.cu,
	assetmanager.ct,
	assetmanager.lu,
	assetmanager.lt
FROM assetmanager
JOIN manager
	ON manager.idman = assetmanager.idman



GO

-- VERIFICA DI assetmanagerview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetmanagerview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'assetmanagerview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetmanagerview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'assetmanagerview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetmanagerview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'idasset')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '4',field = 'idasset',col_precision = '' where tablename = 'assetmanagerview' AND field = 'idasset'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetmanagerview','S','','4','idasset','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'assetmanagerview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetmanagerview','S','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'assetmanagerview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetmanagerview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'assetmanagerview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetmanagerview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'assetmanagerview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetmanagerview','S','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetmanagerview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'assetmanagerview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'assetmanagerview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','assetmanagerview','S','','4','start','')
GO

-- VERIFICA DI assetmanagerview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetmanagerview')
UPDATE customobject set isreal = 'N' where objectname = 'assetmanagerview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetmanagerview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


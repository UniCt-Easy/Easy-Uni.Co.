
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


-- CREAZIONE VISTA locationusable
IF EXISTS(select * from sysobjects where id = object_id(N'[locationusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [locationusable]
GO



CREATE VIEW locationusable
(
	idlocation,
	locationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	location.idlocation,
	location.locationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman
WHERE locationlevel.flag & 2 <> 0
	AND location.idlocation NOT IN
		(SELECT paridlocation FROM location
		WHERE paridlocation IS NOT NULL)






GO

-- VERIFICA DI locationusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'locationusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'locationusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','locationusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'locationusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','locationusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'locationusable' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','locationusable','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'idlocation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '4',field = 'idlocation',col_precision = '' where tablename = 'locationusable' AND field = 'idlocation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','locationusable','S','','4','idlocation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationusable',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'locationusable' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','S','System.Int32','int','N','locationusable','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'locationusable' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','locationusable','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'locationcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '50',field = 'locationcode',col_precision = '' where tablename = 'locationusable' AND field = 'locationcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','locationusable','S','','50','locationcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'locationusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','locationusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'locationusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','locationusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'locationusable',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'locationusable' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(150)','N','locationusable','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'locationusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'locationusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','tinyint','','N','System.Byte','tinyint','N','locationusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationusable' AND field = 'paridlocation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationusable',denynull = 'N',format = '',col_len = '4',field = 'paridlocation',col_precision = '' where tablename = 'locationusable' AND field = 'paridlocation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','S','System.Int32','int','N','locationusable','N','','4','paridlocation','')
GO

-- VERIFICA DI locationusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'locationusable')
UPDATE customobject set isreal = 'N' where objectname = 'locationusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('locationusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


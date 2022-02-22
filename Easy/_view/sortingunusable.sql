
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


-- CREAZIONE VISTA sortingunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingunusable]
GO






CREATE        VIEW [sortingunusable]
(
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	movkind
)
AS SELECT
	sortingkind.codesorkind,
	sorting.idsorkind,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.start, 
	sorting.stop, 
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt,
	sorting.movkind
FROM sorting
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
WHERE (sortinglevel.flag & 2 = 0)
OR sorting.idsor IN
	(SELECT c1.paridsor FROM sorting c1
	WHERE c1.paridsor IS NOT NULL)





GO

-- VERIFICA DI sortingunusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingunusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingunusable' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(20)','N','sortingunusable','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingunusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingunusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingunusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingunusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '200',field = 'description',col_precision = '' where tablename = 'sortingunusable' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(200)','N','sortingunusable','S','','200','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'idsor')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingunusable' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','int','','N','System.Int32','int','N','sortingunusable','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingunusable' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','int','','N','System.Int32','int','N','sortingunusable','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'sortingunusable' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingunusable','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingunusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingunusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingunusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingunusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'movkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingunusable',denynull = 'N',format = '',col_len = '1',field = 'movkind',col_precision = '' where tablename = 'sortingunusable' AND field = 'movkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','char','','S','System.String','char(1)','N','sortingunusable','N','','1','movkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'sortingunusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','tinyint','','N','System.Byte','tinyint','N','sortingunusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'paridsor')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingunusable',denynull = 'N',format = '',col_len = '4',field = 'paridsor',col_precision = '' where tablename = 'sortingunusable' AND field = 'paridsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','int','','S','System.Int32','int','N','sortingunusable','N','','4','paridsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'sortcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingunusable',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'sortingunusable' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingunusable','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingunusable',denynull = 'N',format = '',col_len = '2',field = 'start',col_precision = '' where tablename = 'sortingunusable' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingunusable','N','','2','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingunusable' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingunusable',denynull = 'N',format = '',col_len = '2',field = 'stop',col_precision = '' where tablename = 'sortingunusable' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingunusable','N','','2','stop','')
GO

-- VERIFICA DI sortingunusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingunusable')
UPDATE customobject set isreal = 'N' where objectname = 'sortingunusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingunusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA finsortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[finsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finsortingview]
GO




CREATE        VIEW [finsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idfin,
	finpart,
	quota,
	ayear,
	codefin,
	title,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	finsorting.idsor,
	sorting.sortcode, 
	sorting.description,
	finsorting.idfin,
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	finsorting.quota,
	fin.ayear,
	fin.codefin,
	fin.title,
	finsorting.cu,
	finsorting.ct,
	finsorting.lu,
	finsorting.lt
FROM finsorting
JOIN sorting
	ON sorting.idsor = finsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN fin
	ON fin.idfin = finsorting.idfin

GO

-- VERIFICA DI finsortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finsortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'finsortingview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','finsortingview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'finsortingview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','finsortingview','S','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'finsortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','finsortingview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'finsortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','finsortingview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'finsortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','finsortingview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'finpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'finsortingview',denynull = 'N',format = '',col_len = '1',field = 'finpart',col_precision = '' where tablename = 'finsortingview' AND field = 'finpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(1)','N','finsortingview','N','','1','finpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'idfin')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'finsortingview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','int','','N','System.Int32','int','N','finsortingview','S','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'finsortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','int','','N','System.Int32','int','N','finsortingview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'finsortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','int','','N','System.Int32','int','N','finsortingview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'finsortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','finsortingview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'finsortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','finsortingview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'quota')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'float',defaultvalue = '',allownull = 'S',systemtype = 'System.Double',sqldeclaration = 'float',iskey = 'N',tablename = 'finsortingview',denynull = 'N',format = '',col_len = '8',field = 'quota',col_precision = '' where tablename = 'finsortingview' AND field = 'quota'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','float','','S','System.Double','float','N','finsortingview','N','','8','quota','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'finsortingview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','finsortingview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'finsortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','finsortingview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'finsortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','finsortingview','S','','50','sortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsortingview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'finsortingview',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'finsortingview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','finsortingview','S','','150','title','')
GO

-- VERIFICA DI finsortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finsortingview')
UPDATE customobject set isreal = 'N' where objectname = 'finsortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('finsortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


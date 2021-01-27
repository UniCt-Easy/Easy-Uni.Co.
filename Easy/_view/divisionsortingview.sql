
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


-- CREAZIONE VISTA divisionsortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[divisionsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [divisionsortingview]
GO




CREATE VIEW [divisionsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	iddivision,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	divisionsorting.idsor,
	sorting.sortcode,
	sorting.description,
	divisionsorting.iddivision,
	divisionsorting.cu,
	divisionsorting.ct,
	divisionsorting.lu,
	divisionsorting.lt
FROM divisionsorting
JOIN sorting
	ON sorting.idsor = divisionsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

-- VERIFICA DI divisionsortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'divisionsortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'divisionsortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','divisionsortingview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'divisionsortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','divisionsortingview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'divisionsortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','divisionsortingview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'iddivision')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '4',field = 'iddivision',col_precision = '' where tablename = 'divisionsortingview' AND field = 'iddivision'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','divisionsortingview','S','','4','iddivision','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'divisionsortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','divisionsortingview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'divisionsortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','divisionsortingview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'divisionsortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','divisionsortingview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'divisionsortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','divisionsortingview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'divisionsortingview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','divisionsortingview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'divisionsortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','divisionsortingview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'divisionsortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'divisionsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'divisionsortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','divisionsortingview','S','','50','sortingkind','')
GO

-- VERIFICA DI divisionsortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'divisionsortingview')
UPDATE customobject set isreal = 'N' where objectname = 'divisionsortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('divisionsortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


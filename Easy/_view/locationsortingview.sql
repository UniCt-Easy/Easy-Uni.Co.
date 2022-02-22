
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


-- CREAZIONE VISTA locationsortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[locationsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [locationsortingview]
GO




CREATE VIEW [locationsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idlocation,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	locationsorting.idsor,
	sorting.sortcode,
	sorting.description,
	locationsorting.idlocation,
	locationsorting.cu,
	locationsorting.ct,
	locationsorting.lu,
	locationsorting.lt
FROM locationsorting
JOIN sorting
	ON sorting.idsor = locationsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind




GO

-- VERIFICA DI locationsortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'locationsortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'locationsortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','locationsortingview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'locationsortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','locationsortingview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'locationsortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','locationsortingview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'idlocation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '4',field = 'idlocation',col_precision = '' where tablename = 'locationsortingview' AND field = 'idlocation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','locationsortingview','S','','4','idlocation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'locationsortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','locationsortingview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'locationsortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','locationsortingview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'locationsortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','locationsortingview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'locationsortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','locationsortingview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'locationsortingview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','locationsortingview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'locationsortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','locationsortingview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'locationsortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'locationsortingview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'locationsortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','locationsortingview','S','','50','sortingkind','')
GO

-- VERIFICA DI locationsortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'locationsortingview')
UPDATE customobject set isreal = 'N' where objectname = 'locationsortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('locationsortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


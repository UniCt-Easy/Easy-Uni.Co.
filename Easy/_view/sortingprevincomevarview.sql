
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


-- CREAZIONE VISTA sortingprevincomevarview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingprevincomevarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingprevincomevarview]
GO



CREATE VIEW sortingprevincomevarview
(
	yvar,
	nvar,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	ayear,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sortingprevincomevar.yvar,
	sortingprevincomevar.nvar,
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingprevincomevar.idsor,
	sorting.sortcode,
	sorting.description,
	sortingprevincomevar.ayear,
	sortingprevincomevar.description,
	sortingprevincomevar.amount,
	sortingprevincomevar.adate,
	sortingprevincomevar.cu,
	sortingprevincomevar.ct,
	sortingprevincomevar.lu,
	sortingprevincomevar.lt
FROM sortingprevincomevar
JOIN sorting
	ON sortingprevincomevar.idsor = sorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind




GO

-- VERIFICA DI sortingprevincomevarview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingprevincomevarview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'adate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'N',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','sortingprevincomevarview','N','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'amount')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'sortingprevincomevarview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','sortingprevincomevarview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'N',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','sortingprevincomevarview','N','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','sortingprevincomevarview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingprevincomevarview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingprevincomevarview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'N',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingprevincomevarview','N','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'N',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingprevincomevarview','N','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingprevincomevarview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingprevincomevarview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingprevincomevarview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'nvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '4',field = 'nvar',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'nvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingprevincomevarview','S','','4','nvar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '50',field = 'sortcode',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','sortingprevincomevarview','S','','50','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(200)','N','sortingprevincomevarview','S','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingprevincomevarview' AND field = 'yvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingprevincomevarview',denynull = 'S',format = '',col_len = '2',field = 'yvar',col_precision = '' where tablename = 'sortingprevincomevarview' AND field = 'yvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','sortingprevincomevarview','S','','2','yvar','')
GO

-- VERIFICA DI sortingprevincomevarview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingprevincomevarview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingprevincomevarview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingprevincomevarview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA sortingincomefilterview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingincomefilterview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingincomefilterview]
GO



CREATE        VIEW [sortingincomefilterview]
(
	codefin,finance,
	codeupb,upb,
	regsortingkind, 
	registrysortcode, 
	registrykind, 
	manager, 
	sortingkind, 
	sortingcode, 
	sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	ct,
	cu,
	jointolessspecifics,
	idfin,
	idsor,
	idsorreg,
	lt,
	lu,
	idman,
	idupb
)
AS
SELECT
	fin.codefin, fin.title,
	upb.codeupb, upb.title, 
	t2.description, 
	c2.sortcode, 
	c2.description, 
	manager.title,
	sortingkind.description,
	sorting.sortcode,
	sorting.description,
	A.ayear,
	A.idautosort,
	sorting.idsorkind,
	sortingkind.codesorkind,
	c2.idsorkind,
	t2.codesorkind,
	A.ct,
	A.cu,
	A.jointolessspecifics,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.lt,
	A.lu,
	A.idman,
	A.idupb
FROM sortingincomefilter A 
JOIN sortingkind
	ON A.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind t2
	ON A.idsorkindreg = t2.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin  and fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman

GO

-- VERIFICA DI sortingincomefilterview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingincomefilterview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingincomefilterview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'codefin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingincomefilterview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','sortingincomefilterview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'codesorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '20',field = 'codesorkindreg',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'codesorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','sortingincomefilterview','N','','20','codesorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingincomefilterview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','sortingincomefilterview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','sortingincomefilterview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'finance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingincomefilterview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idautosort')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '4',field = 'idautosort',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idautosort'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingincomefilterview','S','','4','idautosort','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingincomefilterview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingincomefilterview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingincomefilterview','S','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingincomefilterview','N','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idsorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorkindreg',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idsorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingincomefilterview','N','','4','idsorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idsorreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '4',field = 'idsorreg',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idsorreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','sortingincomefilterview','N','','4','idsorreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'idupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(36)','N','sortingincomefilterview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'jointolessspecifics')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '1',field = 'jointolessspecifics',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'jointolessspecifics'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','sortingincomefilterview','S','','1','jointolessspecifics','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','sortingincomefilterview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','sortingincomefilterview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingincomefilterview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'registrykind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '200',field = 'registrykind',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'registrykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','sortingincomefilterview','N','','200','registrykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'registrysortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '50',field = 'registrysortcode',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'registrysortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingincomefilterview','N','','50','registrysortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'regsortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '50',field = 'regsortingkind',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'regsortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingincomefilterview','N','','50','regsortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','sortingincomefilterview','N','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'sortingcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '50',field = 'sortingcode',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'sortingcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingincomefilterview','N','','50','sortingcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'S',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','sortingincomefilterview','S','','50','sortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingincomefilterview' AND field = 'upb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingincomefilterview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'sortingincomefilterview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','sortingincomefilterview','N','','150','upb','')
GO

-- VERIFICA DI sortingincomefilterview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingincomefilterview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingincomefilterview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingincomefilterview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


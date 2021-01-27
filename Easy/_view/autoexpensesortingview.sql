
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


-- CREAZIONE VISTA autoexpensesortingview
IF EXISTS(select * from sysobjects where id = object_id(N'[autoexpensesortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [autoexpensesortingview]
GO



CREATE VIEW autoexpensesortingview
(
	codefin,finance,
	codeupb,upb,
	regsortingkind,registrysortcode,registrykind,
	manager,
	sortingkind,sortingcode,sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	defaultn1,
	defaultn2,
	defaultn3,
	defaultn4,
	defaultn5,
	defaults1,
	defaults2,
	defaults3,
	defaults4,
	defaults5,
	denominator,
	flagnodate,
	idfin,
	idsor,
	idsorreg,
	numerator,
	ct,
	cu,
	lt,
	lu,
	idman,
	defaultv1,
	defaultv2,
	defaultv3,
	defaultv4,
	defaultv5,
	idupb
)
AS
SELECT     	
	fin.codefin, fin.title,
	upb.codeupb,upb.title,
	t2.description,c2.sortcode,c2.description,
	manager.title,
	sortingkind.description,sorting.sortcode,sorting.description,
	A.ayear,
	A.idautosort,
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	t2.idsorkind,
	t2.codesorkind,
	A.defaultn1,
	A.defaultn2,
	A.defaultn3,
	A.defaultn4,
	A.defaultn5,
	A.defaults1,
	A.defaults2,
	A.defaults3,
	A.defaults4,
	A.defaults5,
	A.denominator,
	A.flagnodate,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.numerator,
	A.ct,
	A.cu,
	A.lt,
	A.lu,
	A.idman,
	A.defaultv1,
	A.defaultv2,
	A.defaultv3,
	A.defaultv4,
	A.defaultv5,
	A.idupb
FROM autoexpensesorting A
JOIN sortingkind
	ON sortingkind.idsorkind = A.idsorkind
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind t2
	ON A.idsorkindreg = t2.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin
	AND fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman


GO

-- VERIFICA DI autoexpensesortingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'autoexpensesortingview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','autoexpensesortingview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'codefin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'codesorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'codesorkindreg',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'codesorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','codesorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','autoexpensesortingview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','autoexpensesortingview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultn1')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultn1',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultn1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultn1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultn2')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultn2',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultn2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultn2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultn3')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultn3',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultn3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultn3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultn4')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultn4',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultn4'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultn4','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultn5')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultn5',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultn5'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultn5','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaults1')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaults1',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaults1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaults1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaults2')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaults2',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaults2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaults2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaults3')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaults3',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaults3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaults3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaults4')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaults4',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaults4'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaults4','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaults5')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaults5',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaults5'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaults5','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultv1')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultv1',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultv1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultv1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultv2')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultv2',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultv2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultv2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultv3')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultv3',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultv3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultv3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultv4')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultv4',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultv4'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultv4','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'defaultv5')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '20',field = 'defaultv5',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'defaultv5'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','autoexpensesortingview','N','','20','defaultv5','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'denominator')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'denominator',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'denominator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','denominator','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'finance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '150',field = 'finance',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'finance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','autoexpensesortingview','N','','150','finance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'flagnodate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '1',field = 'flagnodate',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'flagnodate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','autoexpensesortingview','N','','1','flagnodate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idautosort')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'S',format = '',col_len = '4',field = 'idautosort',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idautosort'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','autoexpensesortingview','S','','4','idautosort','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idman')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idman',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idsor')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idsor',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idsor'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idsor','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idsorkindreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idsorkindreg',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idsorkindreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idsorkindreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idsorreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'idsorreg',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idsorreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','idsorreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'idupb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(36)','N','autoexpensesortingview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','autoexpensesortingview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','autoexpensesortingview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'manager')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '150',field = 'manager',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'manager'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','autoexpensesortingview','N','','150','manager','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'numerator')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '4',field = 'numerator',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'numerator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','autoexpensesortingview','N','','4','numerator','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'registrykind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '200',field = 'registrykind',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'registrykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','autoexpensesortingview','N','','200','registrykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'registrysortcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'registrysortcode',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'registrysortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','registrysortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'regsortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'regsortingkind',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'regsortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','regsortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'sorting')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '200',field = 'sorting',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'sorting'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','autoexpensesortingview','N','','200','sorting','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'sortingcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'sortingcode',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'sortingcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','sortingcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'sortingkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '50',field = 'sortingkind',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'sortingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','autoexpensesortingview','N','','50','sortingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'autoexpensesortingview' AND field = 'upb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'autoexpensesortingview',denynull = 'N',format = '',col_len = '150',field = 'upb',col_precision = '' where tablename = 'autoexpensesortingview' AND field = 'upb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','autoexpensesortingview','N','','150','upb','')
GO

-- VERIFICA DI autoexpensesortingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'autoexpensesortingview')
UPDATE customobject set isreal = 'N' where objectname = 'autoexpensesortingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('autoexpensesortingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA sortingapplicabilityview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingapplicabilityview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingapplicabilityview]
GO




CREATE VIEW  sortingapplicabilityview
(
	idsorkind,
	codesorkind,
	description,
	nphaseincome,
	incomephase,
	nphaseexpense,
	expensephase,
	flagcheckavailability,
	flagforced,
	active,
	cu,
	ct,
	lu,
	lt,
	tablename,
	start,
	stop
)
AS SELECT
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	sortingkind.nphaseincome,
	incomephase.description,
	sortingkind.nphaseexpense,
	expensephase.description,
	CASE 
		WHEN  ((sortingkind.flag&2)<> 0) THEN 'S'
		ELSE  'N'
	END,
	CASE 
		WHEN  ((sortingkind.flag&1)<> 0) THEN 'S'
		ELSE 'N'
	END,
	sortingkind.active,
	sortingkind.cu,
	sortingkind.ct,
	sortingkind.lu,
	sortingkind.lt,
	sortingapplicability.tablename,
	sortingkind.start,
	sortingkind.stop
FROM sortingkind 
LEFT OUTER JOIN incomephase 
	ON incomephase.nphase = sortingkind.nphaseincome
LEFT OUTER JOIN expensephase 
	ON expensephase.nphase = sortingkind.nphaseexpense
JOIN sortingapplicability
	ON sortingapplicability.idsorkind = sortingkind.idsorkind



GO

-- VERIFICA DI sortingapplicabilityview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingapplicabilityview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'active')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','sortingapplicabilityview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','sortingapplicabilityview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingapplicabilityview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingapplicabilityview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','sortingapplicabilityview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'expensephase')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '50',field = 'expensephase',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'expensephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingapplicabilityview','N','','50','expensephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'flagcheckavailability')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '1',field = 'flagcheckavailability',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'flagcheckavailability'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(1)','N','sortingapplicabilityview','S','','1','flagcheckavailability','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'flagforced')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '1',field = 'flagforced',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'flagforced'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(1)','N','sortingapplicabilityview','S','','1','flagforced','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortingapplicabilityview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'incomephase')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '50',field = 'incomephase',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'incomephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','sortingapplicabilityview','N','','50','incomephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','sortingapplicabilityview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','sortingapplicabilityview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'nphaseexpense')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '1',field = 'nphaseexpense',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'nphaseexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','S','System.Byte','tinyint','N','sortingapplicabilityview','N','','1','nphaseexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'nphaseincome')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '1',field = 'nphaseincome',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'nphaseincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','S','System.Byte','tinyint','N','sortingapplicabilityview','N','','1','nphaseincome','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '2',field = 'start',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','sortingapplicabilityview','N','','2','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'stop')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'N',format = '',col_len = '2',field = 'stop',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','sortingapplicabilityview','N','','2','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingapplicabilityview' AND field = 'tablename')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'sortingapplicabilityview',denynull = 'S',format = '',col_len = '150',field = 'tablename',col_precision = '' where tablename = 'sortingapplicabilityview' AND field = 'tablename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','sortingapplicabilityview','S','','150','tablename','')
GO

-- VERIFICA DI sortingapplicabilityview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingapplicabilityview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingapplicabilityview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingapplicabilityview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


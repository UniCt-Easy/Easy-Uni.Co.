
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


-- CREAZIONE VISTA sortingkindview
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingkindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingkindview]
GO






CREATE        VIEW sortingkindview
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
	start,
	stop,
	cu,
	ct,
	lu,
	lt
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
	sortingkind.start,
	sortingkind.stop,
	sortingkind.cu,
	sortingkind.ct,
	sortingkind.lu,
	sortingkind.lt
FROM sortingkind 
LEFT OUTER JOIN incomephase 
	ON incomephase.nphase = sortingkind.nphaseincome
LEFT OUTER JOIN expensephase 
	ON expensephase.nphase = sortingkind.nphaseexpense





GO

-- VERIFICA DI sortingkindview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortingkindview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'codesorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '20',field = 'codesorkind',col_precision = '' where tablename = 'sortingkindview' AND field = 'codesorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(20)','N','sortingkindview','S','','20','codesorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'ct')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'sortingkindview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingkindview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'cu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'sortingkindview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingkindview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'sortingkindview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','sortingkindview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'expensephase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '50',field = 'expensephase',col_precision = '' where tablename = 'sortingkindview' AND field = 'expensephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','S','System.String','varchar(50)','N','sortingkindview','N','','50','expensephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'flagcheckavailability')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '1',field = 'flagcheckavailability',col_precision = '' where tablename = 'sortingkindview' AND field = 'flagcheckavailability'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(1)','N','sortingkindview','S','','1','flagcheckavailability','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'flagforced')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '1',field = 'flagforced',col_precision = '' where tablename = 'sortingkindview' AND field = 'flagforced'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(1)','N','sortingkindview','S','','1','flagforced','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'idsorkind')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '4',field = 'idsorkind',col_precision = '' where tablename = 'sortingkindview' AND field = 'idsorkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','int','','N','System.Int32','int','N','sortingkindview','S','','4','idsorkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'incomephase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '50',field = 'incomephase',col_precision = '' where tablename = 'sortingkindview' AND field = 'incomephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','S','System.String','varchar(50)','N','sortingkindview','N','','50','incomephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'lt')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'sortingkindview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','sortingkindview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'lu')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'sortingkindview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'sortingkindview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','sortingkindview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'nphaseexpense')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '1',field = 'nphaseexpense',col_precision = '' where tablename = 'sortingkindview' AND field = 'nphaseexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','tinyint','','S','System.Byte','tinyint','N','sortingkindview','N','','1','nphaseexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'nphaseincome')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '1',field = 'nphaseincome',col_precision = '' where tablename = 'sortingkindview' AND field = 'nphaseincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''SARA''','','tinyint','','S','System.Byte','tinyint','N','sortingkindview','N','','1','nphaseincome','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '2',field = 'start',col_precision = '' where tablename = 'sortingkindview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingkindview','N','','2','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortingkindview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'sortingkindview',denynull = 'N',format = '',col_len = '2',field = 'stop',col_precision = '' where tablename = 'sortingkindview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','sortingkindview','N','','2','stop','')
GO

-- VERIFICA DI sortingkindview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortingkindview')
UPDATE customobject set isreal = 'N' where objectname = 'sortingkindview'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortingkindview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


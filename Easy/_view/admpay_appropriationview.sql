
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


-- CREAZIONE VISTA admpay_appropriationview
IF EXISTS(select * from sysobjects where id = object_id(N'[admpay_appropriationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [admpay_appropriationview]
GO




CREATE     VIEW admpay_appropriationview
(
yadmpay,
nadmpay,
nappropriation,
description,
idfin,
codefin,
idupb,
codeupb,
idexp,
ymov,
nmov,
nphase,
phase,
amount,
available,
cu,
ct,
lu,
lt,
linked
)
AS SELECT
admpay_appropriation.yadmpay,
admpay_appropriation.nadmpay,
admpay_appropriation.nappropriation,
admpay_appropriation.description,
admpay_appropriation.idfin,
fin.codefin,
admpay_appropriation.idupb,
upb.codeupb,
admpay_appropriation.idexp,
expense.ymov,
expense.nmov,
expense.nphase,
expensephase.description,
admpay_appropriation.amount,
admpay_appropriation.amount -
ISNULL(
	(SELECT SUM(amount)
	FROM admpay_expense
	WHERE admpay_expense.yadmpay = admpay_appropriation.yadmpay
	AND admpay_expense.nadmpay = admpay_appropriation.nadmpay
	AND admpay_expense.nappropriation = admpay_appropriation.nappropriation)
,0) -
ISNULL(
	(SELECT SUM(amount)
	FROM admpay_admintax
	WHERE admpay_admintax.yadmpay = admpay_appropriation.yadmpay
	AND admpay_admintax.nadmpay = admpay_appropriation.nadmpay
	AND admpay_admintax.nappropriation = admpay_appropriation.nappropriation)
,0),
admpay_appropriation.cu,
admpay_appropriation.ct,
admpay_appropriation.lu,
admpay_appropriation.lt,
CASE
	WHEN
		(SELECT COUNT(*) FROM admpay_expense
		WHERE admpay_expense.yadmpay = admpay_appropriation.yadmpay
		AND admpay_expense.nadmpay = admpay_appropriation.nadmpay
		AND admpay_expense.nappropriation = admpay_appropriation.nappropriation) +
		(SELECT COUNT(*) FROM admpay_admintax
		WHERE admpay_admintax.yadmpay = admpay_appropriation.yadmpay
		AND admpay_admintax.nadmpay = admpay_appropriation.nadmpay
		AND admpay_admintax.nappropriation = admpay_appropriation.nappropriation)
		 > 0 THEN 'S'
	ELSE 'N'
END
FROM admpay_appropriation
LEFT OUTER JOIN fin
ON fin.idfin = admpay_appropriation.idfin
LEFT OUTER JOIN upb
ON upb.idupb = admpay_appropriation.idupb
LEFT OUTER JOIN expense
ON expense.idexp = admpay_appropriation.idexp
LEFT OUTER JOIN expensephase
ON expense.nphase = expensephase.nphase






GO

-- VERIFICA DI admpay_appropriationview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'admpay_appropriationview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'admpay_appropriationview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','admpay_appropriationview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'available')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '17',field = 'available',col_precision = '38' where tablename = 'admpay_appropriationview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','admpay_appropriationview','N','','17','available','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_appropriationview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_appropriationview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_appropriationview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','admpay_appropriationview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','admpay_appropriationview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'idexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_appropriationview','N','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'idfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_appropriationview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'idupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(36)','N','admpay_appropriationview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'linked')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '1',field = 'linked',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'linked'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(1)','N','admpay_appropriationview','S','','1','linked','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_appropriationview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','admpay_appropriationview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'nadmpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '4',field = 'nadmpay',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'nadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_appropriationview','S','','4','nadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'nappropriation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '4',field = 'nappropriation',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'nappropriation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_appropriationview','S','','4','nappropriation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_appropriationview','N','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'nphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','S','System.Byte','tinyint','N','admpay_appropriationview','N','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'phase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_appropriationview','N','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'yadmpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'S',format = '',col_len = '4',field = 'yadmpay',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'yadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_appropriationview','S','','4','yadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_appropriationview' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'admpay_appropriationview',denynull = 'N',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'admpay_appropriationview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','S','System.Int16','smallint','N','admpay_appropriationview','N','','2','ymov','')
GO

-- VERIFICA DI admpay_appropriationview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'admpay_appropriationview')
UPDATE customobject set isreal = 'N' where objectname = 'admpay_appropriationview'
ELSE
INSERT INTO customobject (objectname, isreal) values('admpay_appropriationview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


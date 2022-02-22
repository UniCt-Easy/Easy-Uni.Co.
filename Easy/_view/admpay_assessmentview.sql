
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


-- CREAZIONE VISTA admpay_assessmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[admpay_assessmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [admpay_assessmentview]
GO






CREATE VIEW admpay_assessmentview
(
	yadmpay,
	nadmpay,
	nassessment,
	description,
	idfin,
	codefin,
	idupb,
	codeupb,
	idinc,
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
	admpay_assessment.yadmpay,
	admpay_assessment.nadmpay,
	admpay_assessment.nassessment,
	admpay_assessment.description,
	admpay_assessment.idfin,
	fin.codefin,
	admpay_assessment.idupb,
	upb.codeupb,
	admpay_assessment.idinc,
	income.ymov,
	income.nmov,
	income.nphase,
	incomephase.description,
	admpay_assessment.amount,
	admpay_assessment.amount -
	ISNULL(
		(SELECT SUM(amount)
		FROM admpay_income
		WHERE admpay_income.yadmpay = admpay_assessment.yadmpay
		AND admpay_income.nadmpay = admpay_assessment.nadmpay
		AND admpay_income.nassessment = admpay_assessment.nassessment)
	,0),
	admpay_assessment.cu,
	admpay_assessment.ct,
	admpay_assessment.lu,
	admpay_assessment.lt,
	CASE
		WHEN
			(SELECT COUNT(*) FROM admpay_income
			WHERE admpay_income.yadmpay = admpay_assessment.yadmpay
			AND admpay_income.nadmpay = admpay_assessment.nadmpay
			AND admpay_income.nassessment = admpay_assessment.nassessment)
			 > 0 THEN 'S'
		ELSE 'N'
	END
FROM admpay_assessment
LEFT OUTER JOIN fin
	ON fin.idfin = admpay_assessment.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = admpay_assessment.idupb
LEFT OUTER JOIN income
	ON income.idinc = admpay_assessment.idinc
LEFT OUTER JOIN incomephase
	ON income.nphase = incomephase.nphase






GO

-- VERIFICA DI admpay_assessmentview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'admpay_assessmentview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'admpay_assessmentview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','admpay_assessmentview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'available')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '17',field = 'available',col_precision = '38' where tablename = 'admpay_assessmentview' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','admpay_assessmentview','N','','17','available','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'codefin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '50',field = 'codefin',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'codefin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_assessmentview','N','','50','codefin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'codeupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '50',field = 'codeupb',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'codeupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_assessmentview','N','','50','codeupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_assessmentview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(68)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '68',field = 'cu',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(68)','N','admpay_assessmentview','S','','68','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','admpay_assessmentview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'idfin')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '4',field = 'idfin',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'idfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_assessmentview','N','','4','idfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'idinc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_assessmentview','N','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'idupb')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '36',field = 'idupb',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'idupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(36)','N','admpay_assessmentview','N','','36','idupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'linked')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '1',field = 'linked',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'linked'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(1)','N','admpay_assessmentview','S','','1','linked','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','admpay_assessmentview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(68)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '68',field = 'lu',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(68)','N','admpay_assessmentview','S','','68','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'nadmpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '4',field = 'nadmpay',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'nadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_assessmentview','S','','4','nadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'nassessment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '4',field = 'nassessment',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'nassessment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_assessmentview','S','','4','nassessment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','admpay_assessmentview','N','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'nphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','S','System.Byte','tinyint','N','admpay_assessmentview','N','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'phase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '50',field = 'phase',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'phase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','admpay_assessmentview','N','','50','phase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'yadmpay')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'S',format = '',col_len = '4',field = 'yadmpay',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'yadmpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','admpay_assessmentview','S','','4','yadmpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'admpay_assessmentview' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'admpay_assessmentview',denynull = 'N',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'admpay_assessmentview' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','S','System.Int16','smallint','N','admpay_assessmentview','N','','2','ymov','')
GO

-- VERIFICA DI admpay_assessmentview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'admpay_assessmentview')
UPDATE customobject set isreal = 'N' where objectname = 'admpay_assessmentview'
ELSE
INSERT INTO customobject (objectname, isreal) values('admpay_assessmentview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


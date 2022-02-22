
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


-- CREAZIONE VISTA partincomesetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[partincomesetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [partincomesetupview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:08
CREATE                                VIEW partincomesetupview
	(
	idfinincome,
	yfinincome,
	finincomecode,
	finincometitle,
	idfinexpense,
	yfinexpense,
	finexpensecode,
	finexpensetitle,
  percentage,
  cu,
  ct,
  lu,
  lt
 	)
	AS SELECT
	partincomesetup.idfinincome,
	bilancioentrata.ayear,
	bilancioentrata.codefin,
	bilancioentrata.title,
	partincomesetup.idfinexpense,
	bilanciospesa.ayear,
	bilanciospesa.codefin,
	bilanciospesa.title,
	partincomesetup.percentage,
	partincomesetup.cu,
	partincomesetup.ct,
	partincomesetup.lu,
	partincomesetup.lt
	FROM partincomesetup (NOLOCK)
	JOIN fin bilancioentrata (NOLOCK)
	ON bilancioentrata.idfin = partincomesetup.idfinincome
	JOIN fin bilanciospesa (NOLOCK)
	ON bilanciospesa.idfin = partincomesetup.idfinexpense





GO

-- VERIFICA DI partincomesetupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'partincomesetupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'partincomesetupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','partincomesetupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'partincomesetupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','partincomesetupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'finexpensecode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '50',field = 'finexpensecode',col_precision = '' where tablename = 'partincomesetupview' AND field = 'finexpensecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','partincomesetupview','S','','50','finexpensecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'finexpensetitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '150',field = 'finexpensetitle',col_precision = '' where tablename = 'partincomesetupview' AND field = 'finexpensetitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','partincomesetupview','S','','150','finexpensetitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'finincomecode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '50',field = 'finincomecode',col_precision = '' where tablename = 'partincomesetupview' AND field = 'finincomecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(50)','N','partincomesetupview','S','','50','finincomecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'finincometitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '150',field = 'finincometitle',col_precision = '' where tablename = 'partincomesetupview' AND field = 'finincometitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(150)','N','partincomesetupview','S','','150','finincometitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'idfinexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '4',field = 'idfinexpense',col_precision = '' where tablename = 'partincomesetupview' AND field = 'idfinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','partincomesetupview','S','','4','idfinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'idfinincome')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '4',field = 'idfinincome',col_precision = '' where tablename = 'partincomesetupview' AND field = 'idfinincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','partincomesetupview','S','','4','idfinincome','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'partincomesetupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','partincomesetupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'partincomesetupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(64)','N','partincomesetupview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'percentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'partincomesetupview',denynull = 'N',format = '',col_len = '9',field = 'percentage',col_precision = '19' where tablename = 'partincomesetupview' AND field = 'percentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','8','decimal','','S','System.Decimal','decimal(19,8)','N','partincomesetupview','N','','9','percentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'yfinexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '2',field = 'yfinexpense',col_precision = '' where tablename = 'partincomesetupview' AND field = 'yfinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','partincomesetupview','S','','2','yfinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'partincomesetupview' AND field = 'yfinincome')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'partincomesetupview',denynull = 'S',format = '',col_len = '2',field = 'yfinincome',col_precision = '' where tablename = 'partincomesetupview' AND field = 'yfinincome'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','partincomesetupview','S','','2','yfinincome','')
GO

-- VERIFICA DI partincomesetupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'partincomesetupview')
UPDATE customobject set isreal = 'N' where objectname = 'partincomesetupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('partincomesetupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA proceedssupposed
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedssupposed]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedssupposed]
GO




CREATE  VIEW [proceedssupposed]
(
	ayear,
	idinc,
	nphase,
	description,
	ymov,
	nmov,
	curramount,
	available,
	adate,
	expiration,
	kpro,
	ypro,
	npro,
	proceedsadate,
	kyproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	transmissiondate
)
AS
-- Incassi trasmessi
	SELECT i1.ayear,
	e1.idinc,
	e1.nphase,
	f1.description,
	e1.ymov,
	e1.nmov,
	i1.curramount,
	NULL,
	e1.adate,
	e1.expiration,
	d1.kpro,
	d1.ypro,
	d1.npro,
	d1.adate,
	t1.kproceedstransmission,
	t1.yproceedstransmission,
	t1.nproceedstransmission,
	t1.transmissiondate
	FROM income e1
	JOIN incometotal i1
		ON e1.idinc = i1.idinc
	JOIN incomeyear i2
		ON i1.idinc = i2.idinc
		AND i1.ayear = i2.ayear
	join incomelast ls
		on e1.idinc = ls.idinc
	JOIN incomephase f1
		ON f1.nphase = e1.nphase
	LEFT OUTER JOIN proceeds d1
		ON ls.kpro = d1.kpro
	LEFT OUTER JOIN proceedstransmission t1
		ON d1.kproceedstransmission = t1.kproceedstransmission
	UNION
	SELECT 
	i1.ayear,
	e1.idinc,
	e1.nphase,
	f1.description,
	e1.ymov,
	e1.nmov,
	NULL,
	i1.available,
	e1.adate,
	e1.expiration,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
	FROM income e1
	JOIN incometotal i1
		ON e1.idinc = i1.idinc
	JOIN incomeyear i2
		ON i1.idinc = i2.idinc
		AND i1.ayear = i2.ayear
	JOIN incomephase f1
		ON f1.nphase = e1.nphase
	WHERE i1.available <> 0
	AND f1.nphase >= (SELECT assessmentphasecode FROM config WHERE ayear = i2.ayear)
	AND f1.nphase < (SELECT MAX(nphase) FROM incomephase)



GO

-- VERIFICA DI proceedssupposed IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceedssupposed'
IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'proceedssupposed' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','proceedssupposed','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'available')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'proceedssupposed' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedssupposed','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'proceedssupposed' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedssupposed','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'proceedssupposed' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','proceedssupposed','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'proceedssupposed' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','proceedssupposed','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'proceedssupposed' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedssupposed','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'idinc')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'proceedssupposed' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedssupposed','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'kpro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'kpro',col_precision = '' where tablename = 'proceedssupposed' AND field = 'kpro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedssupposed','N','','4','kpro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'kyproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'kyproceedstransmission',col_precision = '' where tablename = 'proceedssupposed' AND field = 'kyproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedssupposed','N','','4','kyproceedstransmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'proceedssupposed' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','proceedssupposed','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'proceedssupposed' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','proceedssupposed','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'npro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'npro',col_precision = '' where tablename = 'proceedssupposed' AND field = 'npro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedssupposed','N','','4','npro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'nproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'nproceedstransmission',col_precision = '' where tablename = 'proceedssupposed' AND field = 'nproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','proceedssupposed','N','','4','nproceedstransmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'proceedsadate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'proceedsadate',col_precision = '' where tablename = 'proceedssupposed' AND field = 'proceedsadate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedssupposed','N','','4','proceedsadate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'transmissiondate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '4',field = 'transmissiondate',col_precision = '' where tablename = 'proceedssupposed' AND field = 'transmissiondate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','proceedssupposed','N','','4','transmissiondate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedssupposed',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'proceedssupposed' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','proceedssupposed','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'ypro')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '2',field = 'ypro',col_precision = '' where tablename = 'proceedssupposed' AND field = 'ypro'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedssupposed','N','','2','ypro','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'proceedssupposed' AND field = 'yproceedstransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'proceedssupposed',denynull = 'N',format = '',col_len = '2',field = 'yproceedstransmission',col_precision = '' where tablename = 'proceedssupposed' AND field = 'yproceedstransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','proceedssupposed','N','','2','yproceedstransmission','')
GO

-- VERIFICA DI proceedssupposed IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceedssupposed')
UPDATE customobject set isreal = 'N' where objectname = 'proceedssupposed'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceedssupposed', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


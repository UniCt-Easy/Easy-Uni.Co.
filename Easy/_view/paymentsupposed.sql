
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


-- CREAZIONE VISTA paymentsupposed
IF EXISTS(select * from sysobjects where id = object_id(N'[paymentsupposed]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paymentsupposed]
GO


CREATE  VIEW [paymentsupposed]
(
	ayear,
	idexp,
	nphase,
	description,
	ymov,
	nmov,
	curramount,
	available,
	adate,
	expiration,
	kpay,
	ypay,
	npay,
	paymentadate,
	ypaymenttransmission,
	npaymenttransmission,
	transmissiondate
)
AS
-- Pagamenti trasmessi
	SELECT 
	i1.ayear,
	s1.idexp,
	s1.nphase,
	f1.description,
	s1.ymov,
	s1.nmov,
	i1.curramount,
	NULL,
	s1.adate,
	s1.expiration,
	d1.kpay,
	d1.ypay,
	d1.npay,
	d1.adate,
	t1.ypaymenttransmission,
	t1.npaymenttransmission,
	t1.transmissiondate
	FROM expense s1
	JOIN expenselast l1
	ON l1.idexp = s1.idexp
	JOIN expensetotal i1
	ON s1.idexp = i1.idexp
	JOIN expenseyear i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	LEFT OUTER JOIN payment d1
	ON l1.kpay = d1.kpay
	LEFT OUTER JOIN paymenttransmission t1
	ON d1.kpaymenttransmission = t1.kpaymenttransmission
	JOIN expensephase f1
	ON f1.nphase = s1.nphase
	WHERE f1.nphase = (SELECT MAX(nphase) FROM expensephase)
	UNION
	SELECT
	i1.ayear,
	s1.idexp,
	s1.nphase,
	f1.description,
	s1.ymov,
	s1.nmov,
	NULL,
	i1.available,
	s1.adate,
	s1.expiration,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
	FROM expense s1
	JOIN expensetotal i1
	ON s1.idexp = i1.idexp
	JOIN expenseyear i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	JOIN expensephase f1
	ON f1.nphase = s1.nphase
	WHERE i1.available <> 0
	AND f1.nphase >= (SELECT appropriationphasecode FROM config WHERE ayear = i2.ayear)
	AND f1.nphase < (SELECT MAX(nphase) FROM expensephase)

GO

-- VERIFICA DI paymentsupposed IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'paymentsupposed'
IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'paymentsupposed' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','paymentsupposed','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'available')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '9',field = 'available',col_precision = '19' where tablename = 'paymentsupposed' AND field = 'available'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','paymentsupposed','N','','9','available','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'paymentsupposed' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','paymentsupposed','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'curramount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '9',field = 'curramount',col_precision = '19' where tablename = 'paymentsupposed' AND field = 'curramount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','paymentsupposed','N','','9','curramount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'paymentsupposed' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(50)','N','paymentsupposed','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'expiration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'paymentsupposed' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentsupposed','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'idexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'paymentsupposed' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','paymentsupposed','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'kpay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'kpay',col_precision = '' where tablename = 'paymentsupposed' AND field = 'kpay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentsupposed','N','','4','kpay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'paymentsupposed' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','paymentsupposed','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'npay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'npay',col_precision = '' where tablename = 'paymentsupposed' AND field = 'npay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentsupposed','N','','4','npay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'npaymenttransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'npaymenttransmission',col_precision = '' where tablename = 'paymentsupposed' AND field = 'npaymenttransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','S','System.Int32','int','N','paymentsupposed','N','','4','npaymenttransmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'nphase')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '1',field = 'nphase',col_precision = '' where tablename = 'paymentsupposed' AND field = 'nphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','N','System.Byte','tinyint','N','paymentsupposed','S','','1','nphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'paymentadate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'paymentadate',col_precision = '' where tablename = 'paymentsupposed' AND field = 'paymentadate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentsupposed','N','','4','paymentadate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'transmissiondate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '4',field = 'transmissiondate',col_precision = '' where tablename = 'paymentsupposed' AND field = 'transmissiondate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','paymentsupposed','N','','4','transmissiondate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentsupposed',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'paymentsupposed' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','paymentsupposed','S','','2','ymov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'ypay')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '2',field = 'ypay',col_precision = '' where tablename = 'paymentsupposed' AND field = 'ypay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','paymentsupposed','N','','2','ypay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'paymentsupposed' AND field = 'ypaymenttransmission')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'paymentsupposed',denynull = 'N',format = '',col_len = '2',field = 'ypaymenttransmission',col_precision = '' where tablename = 'paymentsupposed' AND field = 'ypaymenttransmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','S','System.Int16','smallint','N','paymentsupposed','N','','2','ypaymenttransmission','')
GO

-- VERIFICA DI paymentsupposed IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'paymentsupposed')
UPDATE customobject set isreal = 'N' where objectname = 'paymentsupposed'
ELSE
INSERT INTO customobject (objectname, isreal) values('paymentsupposed', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


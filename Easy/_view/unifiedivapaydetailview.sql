
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


-- CREAZIONE VISTA unifiedivapaydetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[unifiedivapaydetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [unifiedivapaydetailview]
GO


CREATE  VIEW [unifiedivapaydetailview]
(
	yunifiedivapay,
	nunifiedivapay,
	iddepartment,
	department,
	start,
	stop,
	idivaregisterkindunified,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	unifiedivapaydetail.yunifiedivapay,
	unifiedivapaydetail.nunifiedivapay,
	unifiedivapaydetail.iddepartment,
	department.description,
	unifiedivapay.start,
	unifiedivapay.stop,
	unifiedivapaydetail.idivaregisterkindunified,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	unifiedivapaydetail.iva,
	unifiedivapaydetail.ivadeferred,
	ISNULL(unifiedivapaydetail.iva,0) + ISNULL(unifiedivapaydetail.ivadeferred,0),
	unifiedivapaydetail.unabatable,
	unifiedivapaydetail.unabatabledeferred,
	ISNULL(unifiedivapaydetail.unabatable,0) + ISNULL(unifiedivapaydetail.unabatabledeferred,0),
	unifiedivapaydetail.prorata,
	unifiedivapaydetail.mixed,
	unifiedivapaydetail.ivanet,
	unifiedivapaydetail.ivanetdeferred,
	unifiedivapaydetail.cu, 
	unifiedivapaydetail.ct, 
	unifiedivapaydetail.lu,
	unifiedivapaydetail.lt 
	FROM unifiedivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkindunified = unifiedivapaydetail.idivaregisterkindunified
	JOIN unifiedivapay (NOLOCK)
	ON unifiedivapay.nunifiedivapay = unifiedivapaydetail.nunifiedivapay
	AND unifiedivapay.yunifiedivapay = unifiedivapaydetail.yunifiedivapay
	JOIN department
	ON department.iddepartment = unifiedivapaydetail.iddepartment








GO

-- VERIFICA DI unifiedivapaydetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'unifiedivapaydetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapaydetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','unifiedivapaydetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'department')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '50',field = 'department',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'department'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','unifiedivapaydetailview','S','','50','department','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'description')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','unifiedivapaydetailview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'iddepartment')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '4',field = 'iddepartment',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'iddepartment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapaydetailview','S','','4','iddepartment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'idivaregisterkindunified')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '20',field = 'idivaregisterkindunified',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'idivaregisterkindunified'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(20)','N','unifiedivapaydetailview','S','','20','idivaregisterkindunified','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'iva')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'iva',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'iva'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','iva','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'ivadeferred')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'ivadeferred',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'ivadeferred'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','ivadeferred','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'ivanet')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'ivanet',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'ivanet'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','ivanet','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'ivanetdeferred')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'ivanetdeferred',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'ivanetdeferred'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','ivanetdeferred','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'ivatotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(20,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '13',field = 'ivatotal',col_precision = '20' where tablename = 'unifiedivapaydetailview' AND field = 'ivatotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','unifiedivapaydetailview','N','','13','ivatotal','20')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapaydetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','unifiedivapaydetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'mixed')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'mixed',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'mixed'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedivapaydetailview','N','','9','mixed','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'nunifiedivapay')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '4',field = 'nunifiedivapay',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'nunifiedivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapaydetailview','S','','4','nunifiedivapay','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'prorata')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'prorata',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'prorata'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedivapaydetailview','N','','9','prorata','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'registerclass')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '1',field = 'registerclass',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'registerclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','unifiedivapaydetailview','S','','1','registerclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'start')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapaydetailview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'stop')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '8',field = 'stop',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','unifiedivapaydetailview','S','','8','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'unabatable')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'unabatable',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'unabatable'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','unabatable','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'unabatabledeferred')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '9',field = 'unabatabledeferred',col_precision = '19' where tablename = 'unifiedivapaydetailview' AND field = 'unabatabledeferred'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedivapaydetailview','N','','9','unabatabledeferred','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'unabatabletotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(20,2)',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'N',format = '',col_len = '13',field = 'unabatabletotal',col_precision = '20' where tablename = 'unifiedivapaydetailview' AND field = 'unabatabletotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','unifiedivapaydetailview','N','','13','unabatabletotal','20')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'unifiedivapaydetailview' AND field = 'yunifiedivapay')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'unifiedivapaydetailview',denynull = 'S',format = '',col_len = '4',field = 'yunifiedivapay',col_precision = '' where tablename = 'unifiedivapaydetailview' AND field = 'yunifiedivapay'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','unifiedivapaydetailview','S','','4','yunifiedivapay','')
GO

-- VERIFICA DI unifiedivapaydetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'unifiedivapaydetailview')
UPDATE customobject set isreal = 'N' where objectname = 'unifiedivapaydetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('unifiedivapaydetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


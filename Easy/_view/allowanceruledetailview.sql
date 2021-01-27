
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


-- CREAZIONE VISTA allowanceruledetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[allowanceruledetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[allowanceruledetailview]
GO




CREATE VIEW DBO.allowanceruledetailview
(
	idallowancerule,
	iddetail,
	start,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	amount,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idallowancerule,
	DET.iddetail,
	F.start,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.amount,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM allowanceruledetail DET
JOIN allowancerule F
	ON F.idallowancerule = DET.idallowancerule
LEFT OUTER JOIN position P
	ON P.idposition = DET.idposition




GO

-- VERIFICA DI allowanceruledetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'allowanceruledetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'advancepercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '9',field = 'advancepercentage',col_precision = '19' where tablename = 'allowanceruledetailview' AND field = 'advancepercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','N','System.Decimal','decimal(19,6)','N','allowanceruledetailview','S','','9','advancepercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'allowanceruledetailview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','allowanceruledetailview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'codeposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'N',format = '',col_len = '20',field = 'codeposition',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'codeposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','allowanceruledetailview','N','','20','codeposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','allowanceruledetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','allowanceruledetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'idallowancerule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idallowancerule',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'idallowancerule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','allowanceruledetailview','S','','4','idallowancerule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'iddetail')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iddetail',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'iddetail'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','allowanceruledetailview','S','','4','iddetail','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idposition',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','allowanceruledetailview','S','','4','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','allowanceruledetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','allowanceruledetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'maxincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'maxincomeclass',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'maxincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','allowanceruledetailview','S','','4','maxincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'minincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'minincomeclass',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'minincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','allowanceruledetailview','S','','4','minincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'N',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','allowanceruledetailview','N','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allowanceruledetailview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'allowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'allowanceruledetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','allowanceruledetailview','S','','8','start','')
GO

-- VERIFICA DI allowanceruledetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'allowanceruledetailview')
UPDATE customobject set isreal = 'N' where objectname = 'allowanceruledetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('allowanceruledetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


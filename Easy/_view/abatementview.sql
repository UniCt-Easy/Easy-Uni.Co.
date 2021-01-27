
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


-- CREAZIONE VISTA abatementview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[abatementview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[abatementview]
GO



CREATE     VIEW [dbo].abatementview
AS
SELECT     abatement.idabatement, abatementcode.ayear, abatementcode.code AS abatementcode,--codicedetrazione, 
		      abatement.calculationkind, 
                      abatement.taxcode, abatement.description, abatementcode.longdescription, abatement.validitystart, 
                      abatement.validitystop, abatement.evaluatesp, abatement.evaluationorder, 
                      abatementcode.description AS abatementtitle, --desccodicedetrazione, 
		      abatementcode.exemption, abatementcode.maximal, 
                      abatementcode.rate, abatement.appliance, abatement.flagabatableexpense,
		      tax.taxref
FROM         abatement INNER JOIN abatementcode 
				ON abatement.idabatement = abatementcode.idabatement
			INNER JOIN  TAX
				ON TAX.taxcode= abatement.taxcode

GO

-- VERIFICA DI abatementview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'abatementview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'abatementcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '20',field = 'abatementcode',col_precision = '' where tablename = 'abatementview' AND field = 'abatementcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','abatementview','N','','20','abatementcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'abatementtitle')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(110)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '110',field = 'abatementtitle',col_precision = '' where tablename = 'abatementview' AND field = 'abatementtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(110)','N','abatementview','N','','110','abatementtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'appliance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '1',field = 'appliance',col_precision = '' where tablename = 'abatementview' AND field = 'appliance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','abatementview','N','','1','appliance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'abatementview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','abatementview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'calculationkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '1',field = 'calculationkind',col_precision = '' where tablename = 'abatementview' AND field = 'calculationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','abatementview','S','','1','calculationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '50',field = 'description',col_precision = '' where tablename = 'abatementview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','abatementview','S','','50','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'evaluatesp')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '50',field = 'evaluatesp',col_precision = '' where tablename = 'abatementview' AND field = 'evaluatesp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','abatementview','S','','50','evaluatesp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'evaluationorder')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '4',field = 'evaluationorder',col_precision = '' where tablename = 'abatementview' AND field = 'evaluationorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','abatementview','N','','4','evaluationorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'exemption')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '9',field = 'exemption',col_precision = '19' where tablename = 'abatementview' AND field = 'exemption'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','abatementview','N','','9','exemption','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'flagabatableexpense')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '1',field = 'flagabatableexpense',col_precision = '' where tablename = 'abatementview' AND field = 'flagabatableexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','abatementview','S','','1','flagabatableexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'idabatement')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '4',field = 'idabatement',col_precision = '' where tablename = 'abatementview' AND field = 'idabatement'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','abatementview','S','','4','idabatement','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'longdescription')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '16',field = 'longdescription',col_precision = '' where tablename = 'abatementview' AND field = 'longdescription'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','text','','S','System.String','text','N','abatementview','N','','16','longdescription','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'maximal')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '9',field = 'maximal',col_precision = '19' where tablename = 'abatementview' AND field = 'maximal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','abatementview','N','','9','maximal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'rate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '9',field = 'rate',col_precision = '19' where tablename = 'abatementview' AND field = 'rate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','abatementview','N','','9','rate','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'abatementview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','abatementview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'taxref')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'abatementview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'abatementview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','abatementview','S','','20','taxref','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'validitystart')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '8',field = 'validitystart',col_precision = '' where tablename = 'abatementview' AND field = 'validitystart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','abatementview','N','','8','validitystart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'abatementview' AND field = 'validitystop')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'abatementview',denynull = 'N',format = '',col_len = '8',field = 'validitystop',col_precision = '' where tablename = 'abatementview' AND field = 'validitystop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','abatementview','N','','8','validitystop','')
GO

-- VERIFICA DI abatementview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'abatementview')
UPDATE customobject set isreal = 'N' where objectname = 'abatementview'
ELSE
INSERT INTO customobject (objectname, isreal) values('abatementview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA registryreferenceview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryreferenceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryreferenceview]
GO








CREATE   VIEW [DBO].registryreferenceview 
(
	idreg,
	idregistryreference,
	registry, 
	referencename, 
	registryreferencerole, 
	phonenumber,
	faxnumber, 
	mobilenumber,
	skypenumber,
	msnnumber,
	email,
	pec,
	userweb,
	passwordweb,
	flagdefault,
	cu, 
	ct, 
	lu,
	lt
)
AS SELECT
	registryreference.idreg, 
	registryreference.idregistryreference,
	registry.title, 
	registryreference.referencename, 
	registryreference.registryreferencerole, 
	registryreference.phonenumber, 
	registryreference.faxnumber, 
	registryreference.mobilenumber,
	registryreference.skypenumber,
	registryreference.msnnumber,
	registryreference.email, 
	registryreference.pec,
	registryreference.userweb,
	registryreference.passwordweb,
	registryreference.flagdefault,
	registryreference.cu, 
	registryreference.ct, 
	registryreference.lu, 
	registryreference.lt
FROM registryreference (NOLOCK)
JOIN registry (NOLOCK)
	ON registryreference.idreg = registry.idreg










GO

-- VERIFICA DI registryreferenceview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryreferenceview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registryreferenceview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','registryreferenceview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registryreferenceview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','registryreferenceview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'email')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '200',field = 'email',col_precision = '' where tablename = 'registryreferenceview' AND field = 'email'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(200)','N','registryreferenceview','N','','200','email','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'faxnumber')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '50',field = 'faxnumber',col_precision = '' where tablename = 'registryreferenceview' AND field = 'faxnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','registryreferenceview','N','','50','faxnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'flagdefault')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '1',field = 'flagdefault',col_precision = '' where tablename = 'registryreferenceview' AND field = 'flagdefault'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','registryreferenceview','N','','1','flagdefault','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'idreg')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registryreferenceview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','registryreferenceview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'idregistryreference')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '4',field = 'idregistryreference',col_precision = '' where tablename = 'registryreferenceview' AND field = 'idregistryreference'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','registryreferenceview','S','','4','idregistryreference','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registryreferenceview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','registryreferenceview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registryreferenceview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','registryreferenceview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'mobilenumber')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '20',field = 'mobilenumber',col_precision = '' where tablename = 'registryreferenceview' AND field = 'mobilenumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(20)','N','registryreferenceview','N','','20','mobilenumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'msnnumber')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '50',field = 'msnnumber',col_precision = '' where tablename = 'registryreferenceview' AND field = 'msnnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','registryreferenceview','N','','50','msnnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'passwordweb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(40)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '40',field = 'passwordweb',col_precision = '' where tablename = 'registryreferenceview' AND field = 'passwordweb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(40)','N','registryreferenceview','N','','40','passwordweb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'phonenumber')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '50',field = 'phonenumber',col_precision = '' where tablename = 'registryreferenceview' AND field = 'phonenumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','registryreferenceview','N','','50','phonenumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'referencename')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '50',field = 'referencename',col_precision = '' where tablename = 'registryreferenceview' AND field = 'referencename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','registryreferenceview','S','','50','referencename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'registry')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registryreferenceview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(100)','N','registryreferenceview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'registryreferencerole')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '50',field = 'registryreferencerole',col_precision = '' where tablename = 'registryreferenceview' AND field = 'registryreferencerole'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','registryreferenceview','N','','50','registryreferencerole','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'skypenumber')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '50',field = 'skypenumber',col_precision = '' where tablename = 'registryreferenceview' AND field = 'skypenumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','registryreferenceview','N','','50','skypenumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryreferenceview' AND field = 'userweb')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(40)',iskey = 'N',tablename = 'registryreferenceview',denynull = 'N',format = '',col_len = '40',field = 'userweb',col_precision = '' where tablename = 'registryreferenceview' AND field = 'userweb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(40)','N','registryreferenceview','N','','40','userweb','')
GO

-- VERIFICA DI registryreferenceview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryreferenceview')
UPDATE customobject set isreal = 'N' where objectname = 'registryreferenceview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryreferenceview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


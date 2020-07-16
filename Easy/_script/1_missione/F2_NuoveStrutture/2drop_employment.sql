/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿IF EXISTS(select * from sysobjects where id = object_id(N'[employment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE employment
	EXEC clear_table_info 'employment'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'position'
		and C.name ='idemployment'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [position] DROP COLUMN idemployment
	DELETE FROM columntypes WHERE tablename = 'position' AND field = 'idemployment'
END
GO

-- CREAZIONE VISTA registrymainview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrymainview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrymainview]
GO



CREATE   VIEW [DBO].[registrymainview]
(
	idreg, 
	title, 
	idregistryclass, 
	registryclass,
	surname, 
	forename, 
	cf, 
	p_iva, 
	residence, coderesidence,
	residencekind,
	annotation, 
	birthdate, 
	idcity, 
	city, 
	gender, 
	foreigncf, 
	idtitle,
	qualification, 
	idmaritalstatus, 
	maritalstatus, 
	sortcode, 
	registrykind,
	human, 
	active, 
	badgecode,
	maritalsurname, 
	idcategory,
	category, 
	extmatricula, 
	idcentralizedcategory,
	cu,
	ct,
	lu,
	lt,
	location,
	idnation,
	nation
)
AS
SELECT
	registry.idreg, registry.title, 
	registry.idregistryclass, 
	registryclass.description, 
	registry.surname, registry.forename, 
	registry.cf, registry.p_iva, 
	registry.residence, residence.coderesidence,
	residence.description, 
	registry.annotation, 
	registry.birthdate, 
	registry.idcity, geo_city.title,
	registry.gender, registry.foreigncf, 
	registry.idtitle, 
	title.description, 
	registry.idmaritalstatus, 
	maritalstatus.description, 
	registry.sortcode, 
	registrykind.description, 
	registryclass.flaghuman, registry.active, 
	registry.badgecode, 
	registry.maritalsurname, 
	registry.idcategory, 
	category.description,
	registry.extmatricula, 
	registry.idcentralizedcategory,
	registry.cu, 
	registry.ct, 
	registry.lu, 
	registry.lt,
	registry.location,
	registry.idnation,
	geo_nation.title
FROM registry
LEFT OUTER JOIN registrykind
	ON registrykind.sortcode = registry.sortcode
LEFT OUTER JOIN residence
	ON residence.idresidence = registry.residence
LEFT OUTER JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass
LEFT OUTER JOIN title
	ON title.idtitle = registry.idtitle
LEFT OUTER JOIN maritalstatus
	ON maritalstatus.idmaritalstatus = registry.idmaritalstatus
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
LEFT OUTER JOIN category
	ON category.idcategory = registry.idcategory










GO

-- VERIFICA DI registrymainview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrymainview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'active')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registrymainview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','char','','N','System.String','char(1)','N','registrymainview','S','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'annotation')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(400)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '400',field = 'annotation',col_precision = '' where tablename = 'registrymainview' AND field = 'annotation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(400)','N','registrymainview','N','','400','annotation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'badgecode')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '20',field = 'badgecode',col_precision = '' where tablename = 'registrymainview' AND field = 'badgecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','registrymainview','N','','20','badgecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'birthdate')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '4',field = 'birthdate',col_precision = '' where tablename = 'registrymainview' AND field = 'birthdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registrymainview','N','','4','birthdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'category')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'category',col_precision = '' where tablename = 'registrymainview' AND field = 'category'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','category','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'cf')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(16)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '16',field = 'cf',col_precision = '' where tablename = 'registrymainview' AND field = 'cf'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(16)','N','registrymainview','N','','16','cf','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'city')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'registrymainview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(65)','N','registrymainview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'coderesidence')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(10)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '10',field = 'coderesidence',col_precision = '' where tablename = 'registrymainview' AND field = 'coderesidence'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(10)','N','registrymainview','N','','10','coderesidence','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'ct')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registrymainview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','datetime','','N','System.DateTime','datetime','N','registrymainview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'cu')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registrymainview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(64)','N','registrymainview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'extmatricula')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(40)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '40',field = 'extmatricula',col_precision = '' where tablename = 'registrymainview' AND field = 'extmatricula'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(40)','N','registrymainview','N','','40','extmatricula','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'foreigncf')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(40)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '40',field = 'foreigncf',col_precision = '' where tablename = 'registrymainview' AND field = 'foreigncf'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(40)','N','registrymainview','N','','40','foreigncf','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'forename')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'forename',col_precision = '' where tablename = 'registrymainview' AND field = 'forename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','forename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'gender')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '1',field = 'gender',col_precision = '' where tablename = 'registrymainview' AND field = 'gender'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','char','','S','System.String','char(1)','N','registrymainview','N','','1','gender','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'human')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '1',field = 'human',col_precision = '' where tablename = 'registrymainview' AND field = 'human'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','char','','S','System.String','char(1)','N','registrymainview','N','','1','human','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idcategory')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '2',field = 'idcategory',col_precision = '' where tablename = 'registrymainview' AND field = 'idcategory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(2)','N','registrymainview','N','','2','idcategory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idcentralizedcategory')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '20',field = 'idcentralizedcategory',col_precision = '' where tablename = 'registrymainview' AND field = 'idcentralizedcategory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','registrymainview','N','','20','idcentralizedcategory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'registrymainview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','registrymainview','N','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idmaritalstatus')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '20',field = 'idmaritalstatus',col_precision = '' where tablename = 'registrymainview' AND field = 'idmaritalstatus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','registrymainview','N','','20','idmaritalstatus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idnation')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'registrymainview' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','registrymainview','N','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registrymainview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','registrymainview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idregistryclass')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(2)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '2',field = 'idregistryclass',col_precision = '' where tablename = 'registrymainview' AND field = 'idregistryclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(2)','N','registrymainview','N','','2','idregistryclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'idtitle')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '20',field = 'idtitle',col_precision = '' where tablename = 'registrymainview' AND field = 'idtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','registrymainview','N','','20','idtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'location')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'registrymainview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'lt')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registrymainview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','datetime','','N','System.DateTime','datetime','N','registrymainview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'lu')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registrymainview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(64)','N','registrymainview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'maritalstatus')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'maritalstatus',col_precision = '' where tablename = 'registrymainview' AND field = 'maritalstatus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','maritalstatus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'maritalsurname')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'maritalsurname',col_precision = '' where tablename = 'registrymainview' AND field = 'maritalsurname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','maritalsurname','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'nation')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'registrymainview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(65)','N','registrymainview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'p_iva')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(15)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '15',field = 'p_iva',col_precision = '' where tablename = 'registrymainview' AND field = 'p_iva'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(15)','N','registrymainview','N','','15','p_iva','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'qualification')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'qualification',col_precision = '' where tablename = 'registrymainview' AND field = 'qualification'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','qualification','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'registryclass')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '150',field = 'registryclass',col_precision = '' where tablename = 'registrymainview' AND field = 'registryclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(150)','N','registrymainview','N','','150','registryclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'registrykind')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'registrykind',col_precision = '' where tablename = 'registrymainview' AND field = 'registrykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','registrykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'residence')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '4',field = 'residence',col_precision = '' where tablename = 'registrymainview' AND field = 'residence'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','registrymainview','S','','4','residence','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'residencekind')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(60)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '60',field = 'residencekind',col_precision = '' where tablename = 'registrymainview' AND field = 'residencekind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(60)','N','registrymainview','N','','60','residencekind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'sortcode')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '20',field = 'sortcode',col_precision = '' where tablename = 'registrymainview' AND field = 'sortcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','registrymainview','N','','20','sortcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'surname')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrymainview',denynull = 'N',format = '',col_len = '50',field = 'surname',col_precision = '' where tablename = 'registrymainview' AND field = 'surname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','registrymainview','N','','50','surname','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrymainview' AND field = 'title')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registrymainview',denynull = 'S',format = '',col_len = '100',field = 'title',col_precision = '' where tablename = 'registrymainview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(100)','N','registrymainview','S','','100','title','')
GO

-- VERIFICA DI registrymainview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrymainview')
UPDATE customobject set isreal = 'N' where objectname = 'registrymainview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrymainview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



-- CREAZIONE VISTA legalstatuscontract
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[legalstatuscontract]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[legalstatuscontract]
GO




CREATE  VIEW [DBO].[legalstatuscontract]
	(
	idreg,
	idposition,
	position,
	incomeclass,
	incomeclassvalidity,
	maxincomeclass,
	start
	)
	AS SELECT 
	registrylegalstatus.idreg,
	registrylegalstatus.idposition,
	position.description,
	isnull(registrylegalstatus.incomeclass,0),
	registrylegalstatus.incomeclassvalidity,
	position.maxincomeclass,
	registrylegalstatus.start
	FROM registrylegalstatus (NOLOCK)
	JOIN position (NOLOCK)
	ON position.idposition = registrylegalstatus.idposition
	



GO

-- VERIFICA DI legalstatuscontract IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'legalstatuscontract'
IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'idposition')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '20',field = 'idposition',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','legalstatuscontract','N','','20','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'idreg')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','legalstatuscontract','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'incomeclass')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '2',field = 'incomeclass',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'incomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smallint','','N','System.Int16','smallint','N','legalstatuscontract','S','','2','incomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'incomeclassvalidity')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '4',field = 'incomeclassvalidity',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'incomeclassvalidity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','legalstatuscontract','N','','4','incomeclassvalidity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'maxincomeclass')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '2',field = 'maxincomeclass',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'maxincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smallint','','S','System.Int16','smallint','N','legalstatuscontract','N','','2','maxincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'position')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(50)','N','legalstatuscontract','S','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'start')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','legalstatuscontract','S','','4','start','')
GO

-- VERIFICA DI legalstatuscontract IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'legalstatuscontract')
UPDATE customobject set isreal = 'N' where objectname = 'legalstatuscontract'
ELSE
INSERT INTO customobject (objectname, isreal) values('legalstatuscontract', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

	
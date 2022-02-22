
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


-- CREAZIONE VISTA trasmissionmanagerview
IF EXISTS(select * from sysobjects where id = object_id(N'[trasmissionmanagerview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [trasmissionmanagerview]
GO



CREATE  VIEW [trasmissionmanagerview]
(
	ayear,
	idreg,
	annotations,
	registry,
	cf,
	idtrasmissiondocument,
	description,
	surname,
	forename,
	birthdate,
	idcity,
	gender,
	city,
	province,
	idnation,
	nation,
	phonenumber,
	faxnumber,
	email,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	trasmissionmanager.ayear,
	trasmissionmanager.idreg,
	trasmissionmanager.annotations,
	registry.title,
	registry.cf,
	trasmissiondocument.idtrasmissiondocument,
	trasmissiondocument.description,
	registry.surname,
	registry.forename,
	registry.birthdate,
	registry.idcity,
	registry.gender,
	geo_city.title,
	geo_country.province,
	registry.idnation,
	geo_nation.title,
	registryreference.phonenumber,
	registryreference.faxnumber,
	registryreference.email,
	trasmissionmanager.cu,
	trasmissionmanager.ct,
	trasmissionmanager.lu,
	trasmissionmanager.lt
FROM trasmissionmanager
JOIN trasmissiondocument
	ON trasmissionmanager.idtrasmissiondocument = trasmissiondocument.idtrasmissiondocument
JOIN registry
	ON registry.idreg = trasmissionmanager.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = trasmissionmanager.idreg
	AND registryreference.flagdefault = 'S'






GO

-- VERIFICA DI trasmissionmanagerview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'trasmissionmanagerview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'annotations')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(400)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '400',field = 'annotations',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'annotations'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(400)','N','trasmissionmanagerview','N','','400','annotations','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','trasmissionmanagerview','S','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'birthdate')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '4',field = 'birthdate',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'birthdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','trasmissionmanagerview','N','','4','birthdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'cf')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(16)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '16',field = 'cf',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'cf'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(16)','N','trasmissionmanagerview','N','','16','cf','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'city')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(65)','N','trasmissionmanagerview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'ct')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','datetime','','N','System.DateTime','datetime','N','trasmissionmanagerview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'cu')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(64)','N','trasmissionmanagerview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'description')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(150)','N','trasmissionmanagerview','N','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'email')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '200',field = 'email',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'email'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(200)','N','trasmissionmanagerview','N','','200','email','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'faxnumber')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '50',field = 'faxnumber',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'faxnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','trasmissionmanagerview','N','','50','faxnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'forename')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '50',field = 'forename',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'forename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','trasmissionmanagerview','N','','50','forename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'gender')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '1',field = 'gender',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'gender'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','char','','S','System.String','char(1)','N','trasmissionmanagerview','N','','1','gender','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','trasmissionmanagerview','N','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'idnation')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','trasmissionmanagerview','N','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','trasmissionmanagerview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'idtrasmissiondocument')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '20',field = 'idtrasmissiondocument',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'idtrasmissiondocument'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(20)','N','trasmissionmanagerview','S','','20','idtrasmissiondocument','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'lt')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','datetime','','N','System.DateTime','datetime','N','trasmissionmanagerview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'lu')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(64)','N','trasmissionmanagerview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'nation')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(65)','N','trasmissionmanagerview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'phonenumber')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '50',field = 'phonenumber',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'phonenumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','trasmissionmanagerview','N','','50','phonenumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'province')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(2)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '2',field = 'province',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'province'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','char','','S','System.String','char(2)','N','trasmissionmanagerview','N','','2','province','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'registry')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','N','System.String','varchar(100)','N','trasmissionmanagerview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'trasmissionmanagerview' AND field = 'surname')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'trasmissionmanagerview',denynull = 'N',format = '',col_len = '50',field = 'surname',col_precision = '' where tablename = 'trasmissionmanagerview' AND field = 'surname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','trasmissionmanagerview','N','','50','surname','')
GO

-- VERIFICA DI trasmissionmanagerview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'trasmissionmanagerview')
UPDATE customobject set isreal = 'N' where objectname = 'trasmissionmanagerview'
ELSE
INSERT INTO customobject (objectname, isreal) values('trasmissionmanagerview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


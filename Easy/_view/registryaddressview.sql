
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


-- CREAZIONE VISTA registryaddressview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddressview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaddressview]
GO


--Pino Rana, elaborazione del 10/08/2005 15:17:44
-- Inserire la CREATE VIEW qui--
CREATE  VIEW [DBO].[registryaddressview]
(
idreg,
registry,
start,
stop,
idaddresskind,
codeaddress,
addresskind,
officename,
address,
idcity,
city,
location,
active,
annotations,
ct,
cu,
lt,
lu,
cap,
flagforeign,
idnation,
nation
)
AS
SELECT     
	registryaddress.idreg, 
	registry.title, 
	registryaddress.start, 
	registryaddress.stop, 
	registryaddress.idaddresskind, 
	address.codeaddress,
	address.description AS descrtipoindirizzo,
	registryaddress.officename, 
	registryaddress.address, 
	registryaddress.idcity, 
	geo_city.title AS comune, 
	registryaddress.location, 
	registryaddress.active, 
	registryaddress.annotations, 
	registryaddress.ct, 
	registryaddress.cu, 
	registryaddress.lt, 
	registryaddress.lu, 
	registryaddress.cap,
	registryaddress.flagforeign,
	registryaddress.idnation,
	geo_nation.title
FROM         registryaddress INNER JOIN
                      address ON registryaddress.idaddresskind = address.idaddress INNER JOIN
                      registry ON registryaddress.idreg = registry.idreg LEFT OUTER JOIN
                      geo_city ON registryaddress.idcity = geo_city.idcity LEFT OUTER JOIN
                      geo_nation ON registryaddress.idnation = geo_nation.idnation




GO

-- VERIFICA DI registryaddressview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryaddressview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'active')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registryaddressview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryaddressview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'address')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '100',field = 'address',col_precision = '' where tablename = 'registryaddressview' AND field = 'address'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','registryaddressview','N','','100','address','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'addresskind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(60)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '60',field = 'addresskind',col_precision = '' where tablename = 'registryaddressview' AND field = 'addresskind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(60)','N','registryaddressview','S','','60','addresskind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'annotations')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(400)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '400',field = 'annotations',col_precision = '' where tablename = 'registryaddressview' AND field = 'annotations'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(400)','N','registryaddressview','N','','400','annotations','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'cap')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '20',field = 'cap',col_precision = '' where tablename = 'registryaddressview' AND field = 'cap'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','registryaddressview','N','','20','cap','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'city')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'registryaddressview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','registryaddressview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'codeaddress')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '20',field = 'codeaddress',col_precision = '' where tablename = 'registryaddressview' AND field = 'codeaddress'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','registryaddressview','S','','20','codeaddress','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registryaddressview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryaddressview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registryaddressview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryaddressview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'flagforeign')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '1',field = 'flagforeign',col_precision = '' where tablename = 'registryaddressview' AND field = 'flagforeign'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryaddressview','N','','1','flagforeign','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idaddresskind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'idaddresskind',col_precision = '' where tablename = 'registryaddressview' AND field = 'idaddresskind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryaddressview','S','','4','idaddresskind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'registryaddressview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','registryaddressview','N','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idnation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'idnation',col_precision = '' where tablename = 'registryaddressview' AND field = 'idnation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','registryaddressview','N','','4','idnation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registryaddressview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryaddressview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'location')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'registryaddressview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','registryaddressview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registryaddressview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryaddressview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registryaddressview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryaddressview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'nation')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '65',field = 'nation',col_precision = '' where tablename = 'registryaddressview' AND field = 'nation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','registryaddressview','N','','65','nation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'officename')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '50',field = 'officename',col_precision = '' where tablename = 'registryaddressview' AND field = 'officename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','registryaddressview','N','','50','officename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registryaddressview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registryaddressview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registryaddressview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registryaddressview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryaddressview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryaddressview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'registryaddressview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registryaddressview','N','','4','stop','')
GO

-- VERIFICA DI registryaddressview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryaddressview')
UPDATE customobject set isreal = 'N' where objectname = 'registryaddressview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryaddressview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


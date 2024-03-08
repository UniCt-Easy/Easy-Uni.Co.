
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- DROP idwor da registryrole
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registryrole'
		and C.name ='idwor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registryrole] DROP COLUMN idwor
	DELETE FROM columntypes WHERE tablename = 'registryrole' AND field = 'idwor'
END

IF EXISTS (SELECT * FROM sysindexes where name='xi2registrylegalstatus' and id=object_id('registrylegalstatus'))
	drop index registrylegalstatus.xi2registrylegalstatus
go

-- DROP idwor da registrylegalstatus
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'registrylegalstatus'
		and C.name ='idwor'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [registrylegalstatus] DROP COLUMN idwor
	DELETE FROM columntypes WHERE tablename = 'registrylegalstatus' AND field = 'idwor'
END

-- DROP workcontract
IF EXISTS(select * from sysobjects where id = object_id(N'[workcontract]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE workcontract
	EXEC clear_table_info 'workcontract'
END
GO

-- CREAZIONE VISTA legalstatuscontract
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[legalstatuscontract]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[legalstatuscontract]
GO


CREATE VIEW [DBO].[legalstatuscontract]
	(
	idreg,
	idposition,
	position,
	idemployment,
	incomeclass,
	incomeclassvalidity,
	maxincomeclass,
	start
	)
	AS SELECT 
	registrylegalstatus.idreg,
	registrylegalstatus.idposition,
	position.description,
	position.idemployment,
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
IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'idemployment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '1',field = 'idemployment',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'idemployment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','legalstatuscontract','S','','1','idemployment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '20',field = 'idposition',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','legalstatuscontract','N','','20','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','legalstatuscontract','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'incomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '2',field = 'incomeclass',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'incomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','legalstatuscontract','S','','2','incomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'incomeclassvalidity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '4',field = 'incomeclassvalidity',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'incomeclassvalidity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','legalstatuscontract','N','','4','incomeclassvalidity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'maxincomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'N',format = '',col_len = '2',field = 'maxincomeclass',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'maxincomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','legalstatuscontract','N','','2','maxincomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','legalstatuscontract','S','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'legalstatuscontract' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'legalstatuscontract',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'legalstatuscontract' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','legalstatuscontract','S','','4','start','')
GO

-- VERIFICA DI legalstatuscontract IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'legalstatuscontract')
UPDATE customobject set isreal = 'N' where objectname = 'legalstatuscontract'
ELSE
INSERT INTO customobject (objectname, isreal) values('legalstatuscontract', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



-- CREAZIONE VISTA registryroleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryroleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryroleview]
GO


--Pino Rana, elaborazione del 10/08/2005 15:17:45

CREATE                                   VIEW [DBO].registryroleview
AS
SELECT     registryrole.idreg, 
	   registryrole.idrole, registryrole.start, registryrole.ct, 
                      registryrole.cu, registryrole.stop, registryrole.active, registryrole.lt, registryrole.lu, 
                      registryrole.txt, registry.title as registry, role.description AS role
FROM       registryrole INNER JOIN
                      role ON registryrole.idrole = role.idrole  INNER JOIN
                      registry ON registryrole.idreg = registry.idreg




GO

-- VERIFICA DI registryroleview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryroleview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'active')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registryroleview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registryroleview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registryroleview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryroleview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registryroleview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryroleview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registryroleview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registryroleview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'idrole')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(5)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '5',field = 'idrole',col_precision = '' where tablename = 'registryroleview' AND field = 'idrole'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(5)','N','registryroleview','S','','5','idrole','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registryroleview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registryroleview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registryroleview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registryroleview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registryroleview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registryroleview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'role')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '150',field = 'role',col_precision = '' where tablename = 'registryroleview' AND field = 'role'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','registryroleview','S','','150','role','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryroleview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registryroleview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registryroleview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'stop')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'registryroleview' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registryroleview','N','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registryroleview' AND field = 'txt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'registryroleview',denynull = 'N',format = '',col_len = '16',field = 'txt',col_precision = '' where tablename = 'registryroleview' AND field = 'txt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','text','','S','System.String','text','N','registryroleview','N','','16','txt','')
GO

-- VERIFICA DI registryroleview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryroleview')
UPDATE customobject set isreal = 'N' where objectname = 'registryroleview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryroleview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA registrylegalstatusview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrylegalstatusview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrylegalstatusview]
GO






CREATE  VIEW [DBO].registrylegalstatusview 
(
	idreg,
	title, 
	start,
	idposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt
)
	AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt 
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
JOIN position 
	ON registrylegalstatus.idposition = position.idposition 
	








GO

-- VERIFICA DI registrylegalstatusview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrylegalstatusview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registrylegalstatusview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registrylegalstatusview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '20',field = 'idposition',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','registrylegalstatusview','N','','20','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registrylegalstatusview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'incomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '2',field = 'incomeclass',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'incomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','registrylegalstatusview','N','','2','incomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'incomeclassvalidity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '4',field = 'incomeclassvalidity',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'incomeclassvalidity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registrylegalstatusview','N','','4','incomeclassvalidity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registrylegalstatusview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registrylegalstatusview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'S',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','registrylegalstatusview','S','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registrylegalstatusview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registrylegalstatusview',denynull = 'S',format = '',col_len = '100',field = 'title',col_precision = '' where tablename = 'registrylegalstatusview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registrylegalstatusview','S','','100','title','')
GO

-- VERIFICA DI registrylegalstatusview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrylegalstatusview')
UPDATE customobject set isreal = 'N' where objectname = 'registrylegalstatusview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrylegalstatusview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA registrylegalstatusregview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrylegalstatusregview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrylegalstatusregview]
GO






CREATE  VIEW [DBO].[registrylegalstatusregview]
(
	idreg,
	registry,
	start,
	idposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt,
	active
)
AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt,
	registrylegalstatus.active
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
LEFT OUTER JOIN position 
	ON registrylegalstatus.idposition = position.idposition 






GO

-- VERIFICA DI registrylegalstatusregview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrylegalstatusregview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'active')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','registrylegalstatusregview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registrylegalstatusregview','N','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registrylegalstatusregview','N','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'idposition')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '20',field = 'idposition',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'idposition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','registrylegalstatusregview','N','','20','idposition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'idreg')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','registrylegalstatusregview','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'incomeclass')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '2',field = 'incomeclass',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'incomeclass'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','registrylegalstatusregview','N','','2','incomeclass','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'incomeclassvalidity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '4',field = 'incomeclassvalidity',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'incomeclassvalidity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','registrylegalstatusregview','N','','4','incomeclassvalidity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','registrylegalstatusregview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','registrylegalstatusregview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'position')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'N',format = '',col_len = '50',field = 'position',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'position'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','registrylegalstatusregview','N','','50','position','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(100)','N','registrylegalstatusregview','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'registrylegalstatusregview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'registrylegalstatusregview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'registrylegalstatusregview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','registrylegalstatusregview','S','','4','start','')
GO

-- VERIFICA DI registrylegalstatusregview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrylegalstatusregview')
UPDATE customobject set isreal = 'N' where objectname = 'registrylegalstatusregview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrylegalstatusregview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anticipo_missione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anticipo_missione]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_anticipo_missione]
	@ayear smallint, 
	@numberbegin int,
	@numberend int
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition varchar(20),
	incomeclass int,
	yitineration smallint,
	nitineration int,
	foreigngroupnumber smallint,
	start datetime
)

INSERT INTO #rls (idreg, idposition, incomeclass, yitineration, nitineration, start)
SELECT RLS.idreg, RLS.idposition, RLS.incomeclass, I.yitineration, I.nitineration, I.start
FROM registrylegalstatus RLS
JOIN itineration I
	ON I.idreg = RLS.idreg
WHERE I.yitineration = @ayear
	AND I.nitineration BETWEEN @numberbegin AND @numberend
AND RLS.start =
	(SELECT MAX(RLS2.start)
	FROM registrylegalstatus RLS2
	JOIN itineration I2
		ON I2.idreg = RLS2.idreg
	WHERE I2.idreg = RLS2.idreg
		AND RLS.start <= I2.start
		AND I.yitineration = I2.yitineration
		AND I.nitineration = I2.nitineration)

UPDATE #rls
SET foreigngroupnumber =
(SELECT DET.foreigngroupnumber
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F
	ON F.idforeigngrouprule = DET.idforeigngrouprule
WHERE DET.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
	AND F.start =
		(SELECT MAX(F2.start)
		FROM foreigngrouprule F2
		JOIN foreigngroupruledetail DET2
			ON F.idforeigngrouprule = DET.idforeigngrouprule
		WHERE DET2.idposition = #rls.idposition
			AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
			AND start <= #rls.start)
)

SELECT 
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	registry.title as registry,
	registry.extmatricula AS matricula,
	service.description as service,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	position.description as position,
	#rls.incomeclass AS currentclass,
	#rls.foreigngroupnumber AS foreigngroupnumber,
	itineration.totadvance,
	ISNULL(itinerationresidual.linkedanpag,0) + ISNULL(itinerationresidual.linkedangir,0) AS payedadvance
FROM itineration
JOIN itinerationresidual
	ON itineration.nitineration = itinerationresidual.nitineration AND
	itineration.yitineration = itinerationresidual.yitineration
JOIN registry
	ON registry.idreg = itineration.idreg
JOIN #rls
	ON itineration.yitineration = #rls.yitineration
	AND itineration.nitineration = #rls.nitineration
JOIN position
	ON position.idposition = #rls.idposition
JOIN service
	ON service.idser = itineration.idser
WHERE itineration.yitineration = @ayear
	AND itineration.nitineration BETWEEN @numberbegin AND @numberend
ORDER BY itineration.nitineration ASC
	END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_anticipo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_anticipo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_missione_anticipo]

	@yitineration smallint, 
	@nitineration int
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition varchar(20),
	incomeclass int
)

DECLARE @it_start datetime
DECLARE @idreg int
SELECT @it_start = start, @idreg = idreg
FROM itineration WHERE yitineration = @yitineration AND nitineration = @nitineration


INSERT INTO #rls (idreg, idposition, incomeclass)
SELECT TOP 1 @idreg, RLS.idposition, RLS.incomeclass
FROM registrylegalstatus RLS
WHERE RLS.start <= @it_start
AND RLS.idreg = @idreg
ORDER BY start DESC

DECLARE @curr_fgn int

SET @curr_fgn =
	(SELECT TOP 1 det.foreigngroupnumber
	FROM foreigngroupruledetail det
	JOIN #rls
	ON det.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN det.minincomeclass AND det.maxincomeclass
	JOIN foreigngrouprule f
	ON f.idforeigngrouprule = det.idforeigngrouprule
	WHERE f.start <= @it_start
	ORDER BY f.start DESC)

SELECT 
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	registry.title as registry,
	registry.extmatricula AS matricula,
	service.description as service,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	position.description as position,
	#rls.incomeclass AS currentclass,
	@curr_fgn AS foreigngroupnumber,
	itineration.totadvance,
	ISNULL(itinerationresidual.linkedanpag,0) + ISNULL(itinerationresidual.linkedangir,0) as payedadvance
FROM itineration
JOIN itinerationresidual
	ON itineration.nitineration = itinerationresidual.nitineration 
	AND itineration.yitineration = itinerationresidual.yitineration
JOIN registry
	ON registry.idreg = itineration.idreg
LEFT OUTER JOIN #rls
	ON registry.idreg = #rls.idreg
LEFT OUTER JOIN position
	ON position.idposition = #rls.idposition
JOIN service
	ON service.idser = itineration.idser
WHERE itineration.yitineration = @yitineration
	AND itineration.nitineration = @nitineration
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_prospetto_calcolo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_prospetto_calcolo]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE  rpt_missione_prospetto_calcolo
	@ayear smallint, 
	@yitineration smallint, 
	@numberbegin int,
	@numberend int
AS
BEGIN

CREATE TABLE #rls
(
	idreg int,
	idposition varchar(20),
	incomeclass int,
	yitineration smallint,
	nitineration int,
	foreigngroupnumber smallint,
	start datetime
)

INSERT INTO #rls (idreg, idposition, incomeclass, yitineration, nitineration, start)
SELECT RLS.idreg, RLS.idposition, isnull(RLS.incomeclass,0), I.yitineration, I.nitineration, I.start
FROM registrylegalstatus RLS
JOIN itineration I
	ON I.idreg = RLS.idreg
WHERE I.yitineration = @yitineration
	AND I.nitineration BETWEEN @numberbegin AND @numberend
AND RLS.start =
	(SELECT MAX(RLS2.start)
	FROM registrylegalstatus RLS2
	JOIN itineration I2
		ON I2.idreg = RLS2.idreg
	WHERE I2.idreg = RLS2.idreg
		AND RLS.start <= I2.start
		AND I.yitineration = I2.yitineration
		AND I.nitineration = I2.nitineration)

UPDATE #rls
SET foreigngroupnumber =
(SELECT DET.foreigngroupnumber
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F
	ON F.idforeigngrouprule = DET.idforeigngrouprule
WHERE DET.idposition = #rls.idposition
	AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
	AND F.start =
		(SELECT MAX(F2.start)
		FROM foreigngrouprule F2
		JOIN foreigngroupruledetail DET2
			ON F.idforeigngrouprule = DET.idforeigngrouprule
		WHERE DET2.idposition = #rls.idposition
			AND #rls.incomeclass BETWEEN DET.minincomeclass AND DET.maxincomeclass
			AND start <= #rls.start)
)

SELECT 
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	registry.title as registry,
	registry.extmatricula AS matricula,
	service.description as service,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	position.description as position,
	#rls.incomeclass AS currentclass,
	#rls.foreigngroupnumber
FROM itineration
JOIN registry
	ON registry.idreg = itineration.idreg
JOIN #rls
	ON itineration.yitineration = #rls.yitineration
	AND itineration.nitineration = #rls.nitineration
JOIN position
	ON position.idposition = #rls.idposition
JOIN service
	ON service.idser = itineration.idser
WHERE itineration.yitineration = @yitineration   
	AND itineration.nitineration BETWEEN @numberbegin AND @numberend
ORDER BY itineration.nitineration ASC
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



-- Regole 
delete from auditcheck where 
idaudit = 'ANAGR003' AND
idcheck = 1 AND
tablename = 'registryrole' AND
opkind = 'I'

delete from auditcheck where 
idaudit = 'ANAGR003' AND
idcheck = 1 AND
tablename = 'registryrole' AND
opkind = 'U'

delete from auditcheck where
idaudit = 'SYSTM002' AND
idcheck = 2 AND
tablename = 'workcontract' AND
opkind = 'D'

delete from auditcheck where 
idaudit = 'SYSTM001' AND
idcheck = 1 AND
tablename = 'workcontract' AND
opkind = 'I'

delete from auditcheck where
idaudit = 'SYSTM001' AND
idcheck = 2 AND
tablename = 'workcontract' AND
opkind = 'I'

delete from auditcheck where
idaudit = 'SYSTM001' AND
idcheck = 1 AND
tablename = 'workcontract' AND
opkind = 'U'

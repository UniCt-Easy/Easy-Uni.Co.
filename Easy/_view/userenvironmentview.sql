
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


-- CREAZIONE VISTA userenvironmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[userenvironmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [userenvironmentview]
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                  VIEW [userenvironmentview]
AS
SELECT     
userenvironment.variablename, 
userenvironment.idcustomuser, 
customuser.username, 
userenvironment.value, 
userenvironment.flagadmin, 
userenvironment.kind, 
userenvironment.lu, 
userenvironment.lt
FROM         userenvironment WITH (NOLOCK) LEFT OUTER JOIN
             customuser WITH (NOLOCK) 
             ON userenvironment.idcustomuser = customuser.idcustomuser



GO

-- VERIFICA DI userenvironmentview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'userenvironmentview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'flagadmin')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '1',field = 'flagadmin',col_precision = '' where tablename = 'userenvironmentview' AND field = 'flagadmin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','userenvironmentview','N','','1','flagadmin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'idcustomuser')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'S',format = '',col_len = '50',field = 'idcustomuser',col_precision = '' where tablename = 'userenvironmentview' AND field = 'idcustomuser'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(50)','N','userenvironmentview','S','','50','idcustomuser','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'kind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '1',field = 'kind',col_precision = '' where tablename = 'userenvironmentview' AND field = 'kind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','userenvironmentview','N','','1','kind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'userenvironmentview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','S','System.DateTime','datetime','N','userenvironmentview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'userenvironmentview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(64)','N','userenvironmentview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'username')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '50',field = 'username',col_precision = '' where tablename = 'userenvironmentview' AND field = 'username'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','userenvironmentview','N','','50','username','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'value')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'userenvironmentview',denynull = 'N',format = '',col_len = '16',field = 'value',col_precision = '' where tablename = 'userenvironmentview' AND field = 'value'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','text','','S','System.String','text','N','userenvironmentview','N','','16','value','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'userenvironmentview' AND field = 'variablename')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'userenvironmentview',denynull = 'S',format = '',col_len = '50',field = 'variablename',col_precision = '' where tablename = 'userenvironmentview' AND field = 'variablename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(50)','N','userenvironmentview','S','','50','variablename','')
GO

-- VERIFICA DI userenvironmentview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'userenvironmentview')
UPDATE customobject set isreal = 'N' where objectname = 'userenvironmentview'
ELSE
INSERT INTO customobject (objectname, isreal) values('userenvironmentview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


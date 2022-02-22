
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


-- CREAZIONE VISTA auditcheckview
IF EXISTS(select * from sysobjects where id = object_id(N'[auditcheckview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [auditcheckview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:11
CREATE                               VIEW auditcheckview 
	(
	tablename,
	opkind,
	idcheck,
	idaudit,
	title,
	severity,
	sqlcmd, 
	message,
	precheck,
	flag_comp,
	flag_cash,
	flag_both,
	flag_credit,
	flag_proceeds
	)
	AS SELECT
	auditcheck.tablename,
	auditcheck.opkind,
	auditcheck.idcheck,
	auditcheck.idaudit,
	audit.title,
	audit.severity,
	auditcheck.sqlcmd, 
	auditcheck.message,
	auditcheck.precheck,
	auditcheck.flag_comp,
	auditcheck.flag_cash,
	auditcheck.flag_both,
	auditcheck.flag_credit,
	auditcheck.flag_proceeds
	FROM auditcheck (NOLOCK)
	JOIN audit (NOLOCK)
	ON audit.idaudit = auditcheck.idaudit






GO

-- VERIFICA DI auditcheckview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'auditcheckview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'flag_both')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'flag_both',col_precision = '' where tablename = 'auditcheckview' AND field = 'flag_both'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','flag_both','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'flag_cash')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'flag_cash',col_precision = '' where tablename = 'auditcheckview' AND field = 'flag_cash'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','flag_cash','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'flag_comp')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'flag_comp',col_precision = '' where tablename = 'auditcheckview' AND field = 'flag_comp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','flag_comp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'flag_credit')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'flag_credit',col_precision = '' where tablename = 'auditcheckview' AND field = 'flag_credit'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','flag_credit','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'flag_proceeds')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'flag_proceeds',col_precision = '' where tablename = 'auditcheckview' AND field = 'flag_proceeds'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','flag_proceeds','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'idaudit')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(30)',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '30',field = 'idaudit',col_precision = '' where tablename = 'auditcheckview' AND field = 'idaudit'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','varchar','','N','System.String','varchar(30)','N','auditcheckview','S','','30','idaudit','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'idcheck')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '2',field = 'idcheck',col_precision = '' where tablename = 'auditcheckview' AND field = 'idcheck'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','smallint','','N','System.Int16','smallint','N','auditcheckview','S','','2','idcheck','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'message')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1000)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1000',field = 'message',col_precision = '' where tablename = 'auditcheckview' AND field = 'message'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','varchar','','S','System.String','varchar(1000)','N','auditcheckview','N','','1000','message','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'opkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '1',field = 'opkind',col_precision = '' where tablename = 'auditcheckview' AND field = 'opkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','N','System.String','char(1)','N','auditcheckview','S','','1','opkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'precheck')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '1',field = 'precheck',col_precision = '' where tablename = 'auditcheckview' AND field = 'precheck'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','S','System.String','char(1)','N','auditcheckview','N','','1','precheck','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'severity')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '1',field = 'severity',col_precision = '' where tablename = 'auditcheckview' AND field = 'severity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','char','','N','System.String','char(1)','N','auditcheckview','S','','1','severity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'sqlcmd')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(6000)',iskey = 'N',tablename = 'auditcheckview',denynull = 'N',format = '',col_len = '6000',field = 'sqlcmd',col_precision = '' where tablename = 'auditcheckview' AND field = 'sqlcmd'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','varchar','','S','System.String','varchar(6000)','N','auditcheckview','N','','6000','sqlcmd','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'tablename')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '150',field = 'tablename',col_precision = '' where tablename = 'auditcheckview' AND field = 'tablename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','varchar','','N','System.String','varchar(150)','N','auditcheckview','S','','150','tablename','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'auditcheckview' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(128)',iskey = 'N',tablename = 'auditcheckview',denynull = 'S',format = '',col_len = '128',field = 'title',col_precision = '' where tablename = 'auditcheckview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SARA''','','varchar','','N','System.String','varchar(128)','N','auditcheckview','S','','128','title','')
GO

-- VERIFICA DI auditcheckview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'auditcheckview')
UPDATE customobject set isreal = 'N' where objectname = 'auditcheckview'
ELSE
INSERT INTO customobject (objectname, isreal) values('auditcheckview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


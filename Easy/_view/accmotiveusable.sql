
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



-- CREAZIONE VISTA accmotiveusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotiveusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotiveusable]
GO


CREATE  VIEW [dbo].[accmotiveusable]
(
	idaccmotive,
	paridaccmotive,
	codemotive,
	title,
	active,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	accmotive.idaccmotive,
	accmotive.paridaccmotive,
	accmotive.codemotive,
	accmotive.title,
	accmotive.active,
	accmotive.cu,
	accmotive.ct,
	accmotive.lu,
	accmotive.lt
	FROM accmotive (NOLOCK)
	WHERE (SELECT count(*) FROM accmotive b1
	WHERE b1.paridaccmotive = accmotive.idaccmotive )=0




GO

-- VERIFICA DI accmotiveusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accmotiveusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'active')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'accmotiveusable' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accmotiveusable','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'codemotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '50',field = 'codemotive',col_precision = '' where tablename = 'accmotiveusable' AND field = 'codemotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','accmotiveusable','S','','50','codemotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'accmotiveusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotiveusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'accmotiveusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotiveusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'idaccmotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '36',field = 'idaccmotive',col_precision = '' where tablename = 'accmotiveusable' AND field = 'idaccmotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(36)','N','accmotiveusable','S','','36','idaccmotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'accmotiveusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotiveusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'accmotiveusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotiveusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'paridaccmotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'N',format = '',col_len = '36',field = 'paridaccmotive',col_precision = '' where tablename = 'accmotiveusable' AND field = 'paridaccmotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(36)','N','accmotiveusable','N','','36','paridaccmotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveusable' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accmotiveusable',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'accmotiveusable' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(150)','N','accmotiveusable','S','','150','title','')
GO

-- VERIFICA DI accmotiveusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accmotiveusable')
UPDATE customobject set isreal = 'N' where objectname = 'accmotiveusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('accmotiveusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


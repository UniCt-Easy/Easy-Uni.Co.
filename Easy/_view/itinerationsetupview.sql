
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


-- CREAZIONE VISTA itinerationsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationsetupview]
GO




CREATE   VIEW itinerationsetupview 
(
	ayear,
	idfinexpense,
	codefinexpense,
	expensefinance,
	idclawback,
	clawback,
	foreignhours,
	idaccmotive_admincar,
	codemotive_admincar,
	motive_admincar,
	idaccmotive_owncar,
	codemotive_owncar,
	motive_owncar,
	idaccmotive_foot,
	codemotive_foot,
	motive_foot,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	itinerationsetup.ayear,
	itinerationsetup.idfinexpense,
	fin.codefin,
	fin.title,
	clawback.idclawback,
	clawback.description,
	itinerationsetup.foreignhours,
	itinerationsetup.idaccmotive_admincar,
	AMAC.codemotive,
	AMAC.title,
	itinerationsetup.idaccmotive_owncar,
	AMOC.codemotive,
	AMOC.title,
	itinerationsetup.idaccmotive_foot,
	AMF.codemotive,
	AMF.title,
	itinerationsetup.cu, 
	itinerationsetup.ct, 
	itinerationsetup.lu, 
	itinerationsetup.lt
FROM itinerationsetup
LEFT OUTER JOIN fin
	ON itinerationsetup.idfinexpense = fin.idfin
LEFT OUTER JOIN clawback
	ON itinerationsetup.idclawback = clawback.idclawback
LEFT OUTER JOIN accmotive AMAC
	ON AMAC.idaccmotive = itinerationsetup.idaccmotive_admincar
LEFT OUTER JOIN accmotive AMOC
	ON AMOC.idaccmotive = itinerationsetup.idaccmotive_owncar
LEFT OUTER JOIN accmotive AMF
	ON AMF.idaccmotive = itinerationsetup.idaccmotive_foot







GO

-- VERIFICA DI itinerationsetupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationsetupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','smallint','','N','System.Int16','smallint','N','itinerationsetupview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'clawback')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '50',field = 'clawback',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'clawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(50)','N','itinerationsetupview','N','','50','clawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'codefinexpense')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '50',field = 'codefinexpense',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'codefinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(50)','N','itinerationsetupview','N','','50','codefinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'codemotive_admincar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_admincar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'codemotive_admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(50)','N','itinerationsetupview','N','','50','codemotive_admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'codemotive_foot')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_foot',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'codemotive_foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(50)','N','itinerationsetupview','N','','50','codemotive_foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'codemotive_owncar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_owncar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'codemotive_owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(50)','N','itinerationsetupview','N','','50','codemotive_owncar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','datetime','','N','System.DateTime','datetime','N','itinerationsetupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(64)','N','itinerationsetupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'expensefinance')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '150',field = 'expensefinance',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'expensefinance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(150)','N','itinerationsetupview','N','','150','expensefinance','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'foreignhours')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '4',field = 'foreignhours',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'foreignhours'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','int','','S','System.Int32','int','N','itinerationsetupview','N','','4','foreignhours','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'idaccmotive_admincar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_admincar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'idaccmotive_admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(36)','N','itinerationsetupview','N','','36','idaccmotive_admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'idaccmotive_foot')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_foot',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'idaccmotive_foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(36)','N','itinerationsetupview','N','','36','idaccmotive_foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'idaccmotive_owncar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_owncar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'idaccmotive_owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(36)','N','itinerationsetupview','N','','36','idaccmotive_owncar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'idclawback')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '20',field = 'idclawback',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'idclawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(20)','N','itinerationsetupview','N','','20','idclawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'idfinexpense')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '31',field = 'idfinexpense',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'idfinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(31)','N','itinerationsetupview','N','','31','idfinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','datetime','','N','System.DateTime','datetime','N','itinerationsetupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','N','System.String','varchar(64)','N','itinerationsetupview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'motive_admincar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '150',field = 'motive_admincar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'motive_admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(150)','N','itinerationsetupview','N','','150','motive_admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'motive_foot')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '150',field = 'motive_foot',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'motive_foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(150)','N','itinerationsetupview','N','','150','motive_foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationsetupview' AND field = 'motive_owncar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationsetupview',denynull = 'N',format = '',col_len = '150',field = 'motive_owncar',col_precision = '' where tablename = 'itinerationsetupview' AND field = 'motive_owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SA''','','varchar','','S','System.String','varchar(150)','N','itinerationsetupview','N','','150','motive_owncar','')
GO

-- VERIFICA DI itinerationsetupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationsetupview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationsetupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationsetupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA taxrateregioncitystartview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[taxrateregioncitystartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[taxrateregioncitystartview]
GO




CREATE  VIEW [DBO].[taxrateregioncitystartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idcity,
a1.idtaxrateregioncitystart,
c1.title as city,
p1.idcountry,
p1.title as country,
a1.start,
a1.enforcement
FROM taxrateregioncitystart a1
JOIN geo_city c1
ON a1.idcity = c1.idcity
JOIN geo_country p1
ON c1.idcountry = p1.idcountry
JOIN tax
ON tax.taxcode = a1.taxcode



GO

-- VERIFICA DI taxrateregioncitystartview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxrateregioncitystartview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'city')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(65)','N','taxrateregioncitystartview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'country')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'N',format = '',col_len = '50',field = 'country',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'country'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxrateregioncitystartview','N','','50','country','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'enforcement')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'N',format = '',col_len = '1',field = 'enforcement',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'enforcement'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','char','','S','System.String','char(1)','N','taxrateregioncitystartview','N','','1','enforcement','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregioncitystartview','S','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'idcountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '4',field = 'idcountry',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'idcountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregioncitystartview','S','','4','idcountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'idtaxrateregioncitystart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '4',field = 'idtaxrateregioncitystart',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'idtaxrateregioncitystart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregioncitystartview','S','','4','idtaxrateregioncitystart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxrateregioncitystartview','S','','8','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'taxcode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '4',field = 'taxcode',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'taxcode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','taxrateregioncitystartview','S','','4','taxcode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'taxrateregioncitystartview' AND field = 'taxref')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'taxrateregioncitystartview',denynull = 'S',format = '',col_len = '20',field = 'taxref',col_precision = '' where tablename = 'taxrateregioncitystartview' AND field = 'taxref'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','N','System.String','varchar(20)','N','taxrateregioncitystartview','S','','20','taxref','')
GO

-- VERIFICA DI taxrateregioncitystartview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxrateregioncitystartview')
UPDATE customobject set isreal = 'N' where objectname = 'taxrateregioncitystartview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxrateregioncitystartview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


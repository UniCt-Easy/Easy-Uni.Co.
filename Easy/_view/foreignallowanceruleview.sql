
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


-- CREAZIONE VISTA foreignallowanceruleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreignallowanceruleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[foreignallowanceruleview]
GO



CREATE  VIEW dbo.foreignallowanceruleview
AS
SELECT     dbo.foreignallowancerule.idforeignallowancerule, dbo.foreignallowancerule.idforeigncountry, 
 dbo.foreigncountry.codeforeigncountry,

	dbo.foreigncountry.description AS foreigncountry, 
                      dbo.foreignallowancerule.start
FROM         dbo.foreignallowancerule INNER JOIN
                      dbo.foreigncountry ON dbo.foreignallowancerule.idforeigncountry = dbo.foreigncountry.idforeigncountry



GO

-- VERIFICA DI foreignallowanceruleview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'foreignallowanceruleview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'codeforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '20',field = 'codeforeigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'codeforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','foreignallowanceruleview','S','','20','codeforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'foreigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '50',field = 'foreigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'foreigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','foreignallowanceruleview','S','','50','foreigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'idforeignallowancerule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '4',field = 'idforeignallowancerule',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'idforeignallowancerule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruleview','S','','4','idforeignallowancerule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'idforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '4',field = 'idforeigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'idforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruleview','S','','4','idforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreignallowanceruleview','S','','8','start','')
GO

-- VERIFICA DI foreignallowanceruleview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'foreignallowanceruleview')
UPDATE customobject set isreal = 'N' where objectname = 'foreignallowanceruleview'
ELSE
INSERT INTO customobject (objectname, isreal) values('foreignallowanceruleview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- VERIFICA DI pcspuntiorganicoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pcspuntiorganicoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','varchar(50)','Generator','contrattokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','char(1)','Generator','isdoc','1','S','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','int','Generator','year','4','S','int','System.Int32','','','','','N')
GO

-- VERIFICA DI pcspuntiorganicoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pcspuntiorganicoview')
UPDATE customobject set isreal = 'N' where objectname = 'pcspuntiorganicoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pcspuntiorganicoview', 'N')
GO

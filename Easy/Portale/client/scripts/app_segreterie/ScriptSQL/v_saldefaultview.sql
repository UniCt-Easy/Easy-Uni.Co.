
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


-- CREAZIONE VISTA saldefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[saldefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [saldefaultview]
GO

CREATE VIEW [saldefaultview] AS 
SELECT  sal.budget AS sal_budget, sal.datablocco AS sal_datablocco, sal.idprogetto, sal.idsal, sal.start, sal.stop AS sal_stop,
 isnull('dal ' + CONVERT(VARCHAR, sal.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, sal.stop, 103),'') as dropdown_title
FROM sal WITH (NOLOCK) 
WHERE  sal.idprogetto IS NOT NULL  AND sal.idsal IS NOT NULL 
GO

-- VERIFICA DI saldefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'saldefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','varchar(68)','','dropdown_title','68','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','int','','idsal','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','saldefaultview','decimal(16,2)','','sal_budget','9','N','decimal','System.Decimal','','2','','16','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','saldefaultview','date','','sal_datablocco','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','saldefaultview','date','','sal_stop','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','saldefaultview','date','','start','3','N','date','System.DateTime','','','','','N')
GO

-- VERIFICA DI saldefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'saldefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'saldefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('saldefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


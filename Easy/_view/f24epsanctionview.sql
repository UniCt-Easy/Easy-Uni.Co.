
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


-- CREAZIONE VISTA f24epsanctionview
IF EXISTS(select * from sysobjects where id = object_id(N'[f24epsanctionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [f24epsanctionview]
GO





CREATE VIEW [f24epsanctionview]
AS
SELECT DISTINCT 
a1.idsanctionf24,
a1.idf24ep,
a1.idsanction,
a1.idcity,
c1.title as city,
f1.idfiscaltaxregion,
f1.title as region
FROM f24epsanction a1
LEFT OUTER JOIN geo_city c1
ON a1.idcity= c1.idcity
LEFT OUTER JOIN fiscaltaxregion f1
ON a1.idfiscaltaxregion= f1.idfiscaltaxregion





GO

-- VERIFICA DI f24epsanctionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'f24epsanctionview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(65)','N','f24epsanctionview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','S','System.Int32','int','N','f24epsanctionview','N','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','f24epsanctionview','S','','4','idf24ep','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(5)','N','f24epsanctionview','N','','5','idfiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','f24epsanctionview','S','','4','idsanction','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','f24epsanctionview','S','','4','idsanctionf24','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(50)','N','f24epsanctionview','N','','50','region','')
GO

-- VERIFICA DI f24epsanctionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'f24epsanctionview')
UPDATE customobject set isreal = 'N' where objectname = 'f24epsanctionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('f24epsanctionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


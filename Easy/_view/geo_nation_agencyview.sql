
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


-- CREAZIONE VISTA geo_nation_agencyview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_nation_agencyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[geo_nation_agencyview]
GO


CREATE VIEW [DBO].[geo_nation_agencyview]
(
	idnation, 
	title,
	newnation,
	oldnation,
	idagency,
	agencyname,
	agencywebsite,
	idcode,
	version,
	codename,
	value,
	start,
	stop
)
AS
SELECT
	geo_nation_agency.idnation,
	geo_nation.title, 
	geo_nation.newnation,
	geo_nation.oldnation,
	geo_nation_agency.idagency, 
	geo_agency.title,
	geo_agency.website,
	geo_nation_agency.idcode, 
	geo_nation_agency.version,
	geo_code.codename,
	geo_nation_agency.value,
	geo_nation_agency.start, 
	geo_nation_agency.stop
FROM geo_code
JOIN geo_nation_agency
	ON geo_code.idagency = geo_nation_agency.idagency
	AND geo_code.idcode = geo_nation_agency.idcode
JOIN geo_nation
	ON geo_nation_agency.idnation = geo_nation.idnation
JOIN geo_agency
	ON geo_code.idagency = geo_agency.idagency





GO

-- VERIFICA DI geo_nation_agencyview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'geo_nation_agencyview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_nation_agencyview','N','','50','agencyname','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(60)','N','geo_nation_agencyview','N','','60','agencywebsite','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','geo_nation_agencyview','N','','50','codename','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','geo_nation_agencyview','S','','4','idagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','geo_nation_agencyview','S','','4','idcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','geo_nation_agencyview','S','','4','idnation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','geo_nation_agencyview','N','','4','newnation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','S','System.Int32','int','N','geo_nation_agencyview','N','','4','oldnation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_nation_agencyview','N','','4','start','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','geo_nation_agencyview','N','','4','stop','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(65)','N','geo_nation_agencyview','N','','65','title','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(20)','N','geo_nation_agencyview','N','','20','value','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','int','','N','System.Int32','int','N','geo_nation_agencyview','S','','4','version','')
GO

-- VERIFICA DI geo_nation_agencyview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'geo_nation_agencyview')
UPDATE customobject set isreal = 'N' where objectname = 'geo_nation_agencyview'
ELSE
INSERT INTO customobject (objectname, isreal) values('geo_nation_agencyview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


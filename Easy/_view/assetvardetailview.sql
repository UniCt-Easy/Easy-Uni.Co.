
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


-- CREAZIONE VISTA assetvardetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetvardetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetvardetailview]
GO




CREATE    VIEW [assetvardetailview]
(
	idassetvar,
	idassetvardetail,
	yvar,
	nvar,
	idinventoryagency,
	codeinventoryagency,
	inventoryagency,
	variationdescription,
	enactment,
	nenactment,
	enactmentdate,
	variationkind,
	idinv,
	codeinv,
	inventorytree,
	description,
	idinventory,
	inventory,
	amount,
	adate,
	idmot,
	motive,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	assetvardetail.idassetvar,
	assetvardetail.idassetvardetail,
	assetvar.yvar,
	assetvar.nvar,
	assetvar.idinventoryagency,
	inventoryagency.codeinventoryagency,
	inventoryagency.description,
	assetvar.description,
	assetvar.enactment,
	assetvar.nenactment,
	assetvar.enactmentdate,
	CASE
		WHEN assetvar.flag & 1 <> 0 THEN 'N'
		ELSE 'I'
	END,
	assetvardetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	assetvardetail.description,
	assetvardetail.idinventory,
	inventory.description,
	assetvardetail.amount,
	assetvar.adate,
	assetloadmotive.idmot,
	assetloadmotive.description,
	assetvardetail.cu,
	assetvardetail.ct,
	assetvardetail.lu,
	assetvardetail.lt
FROM assetvardetail
JOIN assetvar
	ON assetvardetail.idassetvar = assetvar.idassetvar
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = assetvar.idinventoryagency
JOIN inventorytree
	ON assetvardetail.idinv = inventorytree.idinv
LEFT OUTER JOIN inventory
	ON inventory.idinventory = assetvardetail.idinventory
LEFT OUTER JOIN assetloadmotive
	ON assetloadmotive.idmot = assetvardetail.idmot







GO

-- VERIFICA DI assetvardetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetvardetailview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','assetvardetailview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','assetvardetailview','N','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','assetvardetailview','S','','50','codeinv','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(20)','N','assetvardetailview','S','','20','codeinventoryagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetvardetailview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetvardetailview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(150)','N','assetvardetailview','N','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(150)','N','assetvardetailview','N','','150','enactment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','assetvardetailview','N','','4','enactmentdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvardetailview','S','','4','idassetvar','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvardetailview','S','','4','idassetvardetail','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvardetailview','S','','4','idinv','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','S','System.Int32','int','N','assetvardetailview','N','','4','idinventory','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvardetailview','S','','4','idinventoryagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','assetvardetailview','N','','4','idmot','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(50)','N','assetvardetailview','N','','50','inventory','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetvardetailview','S','','150','inventoryagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetvardetailview','S','','150','inventorytree','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetvardetailview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetvardetailview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','assetvardetailview','N','','50','motive','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(15)','N','assetvardetailview','N','','15','nenactment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvardetailview','S','','4','nvar','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetvardetailview','S','','150','variationdescription','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(1)','N','assetvardetailview','S','','1','variationkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smallint','','N','System.Int16','smallint','N','assetvardetailview','S','','2','yvar','')
GO

-- VERIFICA DI assetvardetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetvardetailview')
UPDATE customobject set isreal = 'N' where objectname = 'assetvardetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetvardetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


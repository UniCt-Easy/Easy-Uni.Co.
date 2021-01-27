
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


-- CREAZIONE VISTA expensetaxofficialview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensetaxofficialview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensetaxofficialview]
GO



CREATE   VIEW expensetaxofficialview
(
	idreg,
	registry,
	idexp,
	idexpensetaxofficial,
	taxcode,
	taxref,
	description,
	taxkind,
	ymov,
	nmov,
	adate,
	expensedescription,
	phase,
	nbracket,
	ayear,
	exemptionquota,
	abatements,
	taxablenumerator,
	taxabledenominator,
	taxablegross,
	taxablenet,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	start,
	stop,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	registry.idreg,
	registry.title,
	expensetaxofficial.idexp,
	expensetaxofficial.idexpensetaxofficial,
	expensetaxofficial.taxcode,
	tax.taxref,
	tax.description,
	tax.taxkind,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	expensephase.description,
	expensetaxofficial.nbracket,
	expensetaxofficial.ayear,
	expensetaxofficial.exemptionquota,
	expensetaxofficial.abatements,
	expensetaxofficial.taxablenumerator,
	expensetaxofficial.taxabledenominator,
	expensetaxofficial.taxablegross,
	expensetaxofficial.taxablenet,
	expensetaxofficial.employrate,
	expensetaxofficial.employnumerator,
	expensetaxofficial.employdenominator,
	expensetaxofficial.employtax,
	expensetaxofficial.adminrate,
	expensetaxofficial.adminnumerator,
	expensetaxofficial.admindenominator,
	expensetaxofficial.admintax,
	expensetaxofficial.idcity,
	geo_city.title,
	geo_country.province,
	expensetaxofficial.idfiscaltaxregion,
	fiscaltaxregion.title,
	expensetaxofficial.start,
	expensetaxofficial.stop,
	expensetaxofficial.ct,
	expensetaxofficial.cu,
	expensetaxofficial.lt,
	expensetaxofficial.lu
FROM expensetaxofficial
JOIN tax
	ON tax.taxcode = expensetaxofficial.taxcode
JOIN expense
	ON expense.idexp = expensetaxofficial.idexp
JOIN registry
	ON registry.idreg = expense.idreg
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = expensetaxofficial.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = expensetaxofficial.idfiscaltaxregion





GO

-- VERIFICA DI expensetaxofficialview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expensetaxofficialview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','abatements','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','expensetaxofficialview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','admindenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','adminnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','adminrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','admintax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','expensetaxofficialview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','expensetaxofficialview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','expensetaxofficialview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','expensetaxofficialview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','expensetaxofficialview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','employdenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','employnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','employrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','employtax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','exemptionquota','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(150)','N','expensetaxofficialview','S','','150','expensedescription','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','expensetaxofficialview','N','','50','fiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','expensetaxofficialview','N','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','idexp','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','idexpensetaxofficial','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(5)','N','expensetaxofficialview','N','','5','idfiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','expensetaxofficialview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','expensetaxofficialview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','nbracket','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','expensetaxofficialview','S','','50','phase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(2)','N','expensetaxofficialview','N','','2','provincecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(100)','N','expensetaxofficialview','S','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','expensetaxofficialview','N','','8','start','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','expensetaxofficialview','N','','8','stop','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','taxabledenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','taxablegross','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','expensetaxofficialview','N','','9','taxablenet','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','expensetaxofficialview','N','','9','taxablenumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expensetaxofficialview','S','','4','taxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','expensetaxofficialview','S','','2','taxkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','expensetaxofficialview','S','','20','taxref','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','expensetaxofficialview','S','','2','ymov','')
GO

-- VERIFICA DI expensetaxofficialview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expensetaxofficialview')
UPDATE customobject set isreal = 'N' where objectname = 'expensetaxofficialview'
ELSE
INSERT INTO customobject (objectname, isreal) values('expensetaxofficialview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


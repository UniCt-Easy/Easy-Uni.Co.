
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


-- CREAZIONE VISTA unifiedtaxview
IF EXISTS(select * from sysobjects where id = object_id(N'[unifiedtaxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [unifiedtaxview]
GO

 

-- SELECT * FROM unifiedtaxview
CREATE     VIEW [unifiedtaxview]
(
        cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	payed_city,
	payed_country,
	payed_fiscaltaxregion,
	idexp,
	nbracket,
	abatements,
        ymov,
        nmov,
	idreg,
	registry,
        taxcode,
        fiscaltaxcode,
	taxref,
	description,
	taxkind,
        taxcategory,
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
	competencydate,
	idunifiedtax, 
	idunifiedf24ep,
        ayear,      
	f24ep_ayear,      
        nmonth,
        iddbdepartment,
        department,
        npay,
        servicestart,
		servicestop,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	pgc.title,
	pgc_country.province,
	pftr.title,
	unifiedtax.idexp, 
	unifiedtax.nbracket, 
	unifiedtax.abatements,
	unifiedtax.ymov, 
	unifiedtax.nmov, 
	unifiedtax.idreg, 
	registry.title, 
	unifiedtax.taxcode, 
    CASE WHEN isnull(unifiedtax.admintax,0)+isnull(unifiedtax.employtax,0) > 0  THEN  tax.fiscaltaxcode ELSE ISNULL(tax.fiscaltaxcodecredit, tax.fiscaltaxcode ) END,
	tax.taxref,
	tax.description, 
	tax.taxkind, 
        CASE tax.taxkind
                WHEN 1 THEN 'Fiscale'
                WHEN 2 THEN 'Assistenziale'
                WHEN 3 THEN 'Previdenziale'
                WHEN 4 THEN 'Assicurativa'
                WHEN 5 THEN 'Arretrati'
                WHEN 6 THEN 'Altro'
        END,
	unifiedtax.taxablegross, 
	unifiedtax.taxablenet, 
	unifiedtax.employrate, 
	unifiedtax.employnumerator, 
	unifiedtax.employdenominator, 
	unifiedtax.employtax, 
	unifiedtax.adminrate, 
	unifiedtax.adminnumerator, 
	unifiedtax.admindenominator, 
	unifiedtax.admintax, 
	unifiedtax.competencydate, 
	unifiedtax.idunifiedtax, 
	unifiedtax.idunifiedf24ep,
        unifiedtax.ayear,
	unifiedf24ep.ayear,
        unifiedtax.nmonth,
        unifiedtax.iddbdepartment,
        dbdepartment.description,
        unifiedtax.npay,
          unifiedtax.servicestart,
		 unifiedtax.servicestop,
	unifiedtax.cu, unifiedtax.ct, unifiedtax.lu, unifiedtax.lt
FROM unifiedtax
JOIN tax
	ON tax.taxcode = unifiedtax.taxcode
LEFT OUTER JOIN unifiedf24ep
        ON unifiedtax.idunifiedf24ep = unifiedf24ep.idunifiedf24ep
LEFT OUTER JOIN dbdepartment
        ON unifiedtax.iddbdepartment = dbdepartment.iddbdepartment
LEFT OUTER JOIN registry
	ON registry.idreg = unifiedtax.idreg
LEFT OUTER JOIN registryaddress
	ON registryaddress.idreg = unifiedtax.idreg
LEFT OUTER JOIN geo_city
	ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc
	ON pgc.idcity = unifiedtax.idcity
LEFT OUTER JOIN geo_country pgc_country
	ON pgc_country.idcountry = pgc.idcountry
LEFT OUTER JOIN fiscaltaxregion pftr
	ON pftr.idfiscaltaxregion = unifiedtax.idfiscaltaxregion
WHERE (registryaddress.idaddresskind IS NULL OR registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))










GO

-- VERIFICA DI unifiedtaxview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'unifiedtaxview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxview','N','','9','abatements','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(100)','N','unifiedtaxview','N','','100','address','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','admindenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','adminnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','adminrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxview','N','','9','admintax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxview','N','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(20)','N','unifiedtaxview','N','','20','cap','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(16)','N','unifiedtaxview','N','','16','cf','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxview','N','','8','competencydate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','char','','S','System.String','char(2)','N','unifiedtaxview','N','','2','country','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','unifiedtaxview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','unifiedtaxview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(150)','N','unifiedtaxview','N','','150','department','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(50)','N','unifiedtaxview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','employdenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','employnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','6','decimal','','S','System.Decimal','decimal(19,6)','N','unifiedtaxview','N','','9','employrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxview','N','','9','employtax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxview','N','','2','f24ep_ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(20)','N','unifiedtaxview','N','','20','fiscaltaxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxview','N','','50','iddbdepartment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','idexp','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','idunifiedf24ep','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','unifiedtaxview','S','','4','idunifiedtax','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxview','N','','50','location','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','unifiedtaxview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','unifiedtaxview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxview','N','','65','nation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','nbracket','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxview','N','','2','nmonth','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxview','N','','4','npay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxview','N','','65','payed_city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','char','','S','System.String','char(2)','N','unifiedtaxview','N','','2','payed_country','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxview','N','','50','payed_fiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(100)','N','unifiedtaxview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxview','N','','8','servicestart','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxview','N','','8','servicestop','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxview','N','','9','taxablegross','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxview','N','','9','taxablenet','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(13)','N','unifiedtaxview','N','','13','taxcategory','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','unifiedtaxview','S','','4','taxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','N','System.Int16','smallint','N','unifiedtaxview','S','','2','taxkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(20)','N','unifiedtaxview','S','','20','taxref','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxview','N','','2','ymov','')
GO

-- VERIFICA DI unifiedtaxview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'unifiedtaxview')
UPDATE customobject set isreal = 'N' where objectname = 'unifiedtaxview'
ELSE
INSERT INTO customobject (objectname, isreal) values('unifiedtaxview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


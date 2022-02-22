
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


-- CREAZIONE VISTA unifiedtaxcorrigeview
IF EXISTS(select * from sysobjects where id = object_id(N'[unifiedtaxcorrigeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [unifiedtaxcorrigeview]
GO
 
-- SELECT idexpensetaxcorrige,* FROM unifiedtaxcorrigeview
CREATE      VIEW [unifiedtaxcorrigeview]
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
        idexpensetaxcorrige,
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
	adate,
        employamount,
        adminamount,
	idunifiedtaxcorrige, 
	idunifiedf24ep,
        ayear,                
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
	unifiedtaxcorrige.idexp, 
	unifiedtaxcorrige.idexpensetaxcorrige, 
	unifiedtaxcorrige.ymov, 
	unifiedtaxcorrige.nmov, 
	unifiedtaxcorrige.idreg, 
	registry.title, 
	unifiedtaxcorrige.taxcode, 
     CASE WHEN isnull(unifiedtaxcorrige.adminamount,0)+isnull(unifiedtaxcorrige.employamount,0) > 0  THEN  tax.fiscaltaxcode ELSE ISNULL(tax.fiscaltaxcodecredit, tax.fiscaltaxcode ) END,
	
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
        unifiedtaxcorrige.adate, 
        unifiedtaxcorrige.employamount,
        unifiedtaxcorrige.adminamount,
	unifiedtaxcorrige.idunifiedtaxcorrige, 
	unifiedtaxcorrige.idunifiedf24ep,
        unifiedf24ep.ayear,
        unifiedtaxcorrige.nmonth,
        unifiedtaxcorrige.iddbdepartment,
        dbdepartment.description,
        unifiedtaxcorrige.npay,
		unifiedtaxcorrige.servicestart,
		unifiedtaxcorrige.servicestop,
	unifiedtaxcorrige.cu, unifiedtaxcorrige.ct, unifiedtaxcorrige.lu, unifiedtaxcorrige.lt
FROM unifiedtaxcorrige
JOIN tax
	ON tax.taxcode = unifiedtaxcorrige.taxcode
LEFT OUTER JOIN unifiedf24ep
        ON unifiedtaxcorrige.idunifiedf24ep = unifiedf24ep.idunifiedf24ep
LEFT OUTER JOIN dbdepartment
        ON unifiedtaxcorrige.iddbdepartment = dbdepartment.iddbdepartment
LEFT OUTER JOIN registry
	ON registry.idreg = unifiedtaxcorrige.idreg
LEFT OUTER JOIN registryaddress
	ON registryaddress.idreg = unifiedtaxcorrige.idreg
LEFT OUTER JOIN geo_city
	ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc
	ON pgc.idcity = unifiedtaxcorrige.idcity
LEFT OUTER JOIN geo_country pgc_country
	ON pgc_country.idcountry = pgc.idcountry
LEFT OUTER JOIN fiscaltaxregion pftr
	ON pftr.idfiscaltaxregion = unifiedtaxcorrige.idfiscaltaxregion
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

-- VERIFICA DI unifiedtaxcorrigeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'unifiedtaxcorrigeview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxcorrigeview','N','','8','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(100)','N','unifiedtaxcorrigeview','N','','100','address','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxcorrigeview','N','','9','adminamount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxcorrigeview','N','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(20)','N','unifiedtaxcorrigeview','N','','20','cap','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(16)','N','unifiedtaxcorrigeview','N','','16','cf','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxcorrigeview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','char','','S','System.String','char(2)','N','unifiedtaxcorrigeview','N','','2','country','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','unifiedtaxcorrigeview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','unifiedtaxcorrigeview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(150)','N','unifiedtaxcorrigeview','N','','150','department','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(50)','N','unifiedtaxcorrigeview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','S','System.Decimal','decimal(19,2)','N','unifiedtaxcorrigeview','N','','9','employamount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(20)','N','unifiedtaxcorrigeview','N','','20','fiscaltaxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxcorrigeview','N','','50','iddbdepartment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxcorrigeview','N','','4','idexp','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','unifiedtaxcorrigeview','S','','4','idexpensetaxcorrige','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxcorrigeview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxcorrigeview','N','','4','idunifiedf24ep','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','unifiedtaxcorrigeview','S','','4','idunifiedtaxcorrige','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxcorrigeview','N','','50','location','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','unifiedtaxcorrigeview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','unifiedtaxcorrigeview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxcorrigeview','N','','65','nation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxcorrigeview','N','','2','nmonth','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxcorrigeview','N','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','unifiedtaxcorrigeview','N','','4','npay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(65)','N','unifiedtaxcorrigeview','N','','65','payed_city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','char','','S','System.String','char(2)','N','unifiedtaxcorrigeview','N','','2','payed_country','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(50)','N','unifiedtaxcorrigeview','N','','50','payed_fiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(100)','N','unifiedtaxcorrigeview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxcorrigeview','N','','8','servicestart','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','S','System.DateTime','datetime','N','unifiedtaxcorrigeview','N','','8','servicestop','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(13)','N','unifiedtaxcorrigeview','N','','13','taxcategory','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','unifiedtaxcorrigeview','S','','4','taxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','N','System.Int16','smallint','N','unifiedtaxcorrigeview','S','','2','taxkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(20)','N','unifiedtaxcorrigeview','S','','20','taxref','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','unifiedtaxcorrigeview','N','','2','ymov','')
GO

-- VERIFICA DI unifiedtaxcorrigeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'unifiedtaxcorrigeview')
UPDATE customobject set isreal = 'N' where objectname = 'unifiedtaxcorrigeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('unifiedtaxcorrigeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


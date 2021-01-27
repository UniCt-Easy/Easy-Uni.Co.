
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA csa_agencypaymethodview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_agencypaymethodview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_agencypaymethodview]
GO




CREATE       VIEW [csa_agencypaymethodview]
(
	idcsa_agency,
	ente,
	agency,
	idcsa_agencypaymethod,
	idregistrypaymethod,
	vocecsa,
	idreg,
	registry,
	regmodcode,
	paymentdescr,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	A.idcsa_agency,
	A.ente,
	A.description,
	AP.idcsa_agencypaymethod,
	AP.idregistrypaymethod,
	AP.vocecsa,
	A.idreg,
	R.title,
	RP.regmodcode,
	RP.paymentdescr,
	AP.cu,
	AP.ct,
	AP.lu,
	AP.lt
FROM csa_agencypaymethod AP
LEFT OUTER JOIN csa_agency A
ON A.idcsa_agency = AP.idcsa_agency
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg
LEFT OUTER JOIN registrypaymethod RP
ON RP.idreg = A.idreg
AND RP.idregistrypaymethod = AP.idregistrypaymethod




GO

-- VERIFICA DI csa_agencypaymethodview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'csa_agencypaymethodview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(200)','N','csa_agencypaymethodview','N','','200','agency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','csa_agencypaymethodview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','csa_agencypaymethodview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(200)','N','csa_agencypaymethodview','N','','200','ente','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','S','System.Int32','int','N','csa_agencypaymethodview','N','','4','idcsa_agency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','N','csa_agencypaymethodview','S','','4','idcsa_agencypaymethod','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','S','System.Int32','int','N','csa_agencypaymethodview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','N','csa_agencypaymethodview','S','','4','idregistrypaymethod','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','csa_agencypaymethodview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','csa_agencypaymethodview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(150)','N','csa_agencypaymethodview','N','','150','paymentdescr','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(100)','N','csa_agencypaymethodview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','','varchar','','S','System.String','varchar(50)','N','csa_agencypaymethodview','N','','50','regmodcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(200)','N','csa_agencypaymethodview','S','','200','vocecsa','')
GO

-- VERIFICA DI csa_agencypaymethodview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'csa_agencypaymethodview')
UPDATE customobject set isreal = 'N' where objectname = 'csa_agencypaymethodview'
ELSE
INSERT INTO customobject (objectname, isreal) values('csa_agencypaymethodview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


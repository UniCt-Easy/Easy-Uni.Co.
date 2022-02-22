
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


-- CREAZIONE VISTA paydispositionview
IF EXISTS(select * from sysobjects where id = object_id(N'[paydispositionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paydispositionview]
GO

--setuser 'amm'
--select * from paydispositionview

CREATE VIEW paydispositionview
(
	idpaydisposition,
	ayear,
	description,
	motive,
	kpay,
	ypay,
	npay,
	kpaymenttransmission,
	ypaymenttransmission,
	npaymenttransmission,
	total,
	idcbimotive,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	paydisposition.idpaydisposition,
	paydisposition.ayear,
	paydisposition.description,
	paydisposition.motive,
	paydisposition.kpay,
	payment.ypay,
	payment.npay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
	paymenttransmission.npaymenttransmission,
	ISNULL(
		(SELECT SUM(amount) FROM paydispositiondetail
		WHERE paydispositiondetail.idpaydisposition = paydisposition.idpaydisposition)
	,0),
	paydisposition.idcbimotive,
	paydisposition.ct,
	paydisposition.cu,
	paydisposition.lt,
	paydisposition.lu
FROM paydisposition
LEFT OUTER JOIN payment
	ON payment.kpay = paydisposition.kpay
LEFT OUTER JOIN paymenttransmission
	ON payment.kpaymenttransmission= paymenttransmission.kpaymenttransmission



GO

-- VERIFICA DI paydispositionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'paydispositionview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','N','System.Int16','smallint','N','paydispositionview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','paydispositionview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','paydispositionview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(100)','N','paydispositionview','N','','100','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','N','System.Int32','int','N','paydispositionview','S','','4','idpaydisposition','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','paydispositionview','N','','4','kpay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','paydispositionview','N','','4','kpaymenttransmission','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','datetime','','N','System.DateTime','datetime','N','paydispositionview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','N','System.String','varchar(64)','N','paydispositionview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','varchar','','S','System.String','varchar(80)','N','paydispositionview','N','','80','motive','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','paydispositionview','N','','4','npay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','int','','S','System.Int32','int','N','paydispositionview','N','','4','npaymenttransmission','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','2','decimal','','N','System.Decimal','decimal(38,2)','N','paydispositionview','S','','17','total','38')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','paydispositionview','N','','2','ypay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sara','''sara''','','smallint','','S','System.Int16','smallint','N','paydispositionview','N','','2','ypaymenttransmission','')
GO

-- VERIFICA DI paydispositionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'paydispositionview')
UPDATE customobject set isreal = 'N' where objectname = 'paydispositionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('paydispositionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA booktotalview
IF EXISTS(select * from sysobjects where id = object_id(N'[booktotalview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [booktotalview]
GO




CREATE    VIEW [booktotalview]
(
	idstore,
	store,
	deliveryaddress,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	idbooking,
	ybooking,
	nbooking,
	number,
	allocated,
	price,
	idman,
	manager,
	booked,
	idstock,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	store.idstore,
	store.description,
	store.deliveryaddress,
	list.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	booking.idbooking,
	booking.ybooking,
	booking.nbooking,
	ISNULL(booktotal.number,0),
	ISNULL(booktotal.allocated,0),
	bookingdetail.price,
	booking.idman,
	manager.title,
	bookingdetail.number,
	bookingdetail.idstock,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
	--- aggiungere il number del bookingdetail oltre a queello 
	--- (quantità originariamente prenotata) --booked
FROM bookingdetail  
JOIN list
	ON bookingdetail.idlist = list.idlist
JOIN store
	ON bookingdetail.idstore = store.idstore
JOIN  booking
	ON booking.idbooking = bookingdetail.idbooking
LEFT OUTER JOIN  booktotal
	ON bookingdetail.idbooking = booktotal.idbooking
	AND bookingdetail.idlist = booktotal.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN manager 
	ON manager.idman = booking.idman

GO

-- VERIFICA DI booktotalview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'booktotalview'
INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('2','allocated','S','N','booktotalview','decimal(19,2)','''sa''','19','','System.Decimal','sa','','N','decimal','9')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('2','booked','S','N','booktotalview','decimal(19,2)','''sa''','19','','System.Decimal','sa','','N','decimal','9')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','codelistclass','N','N','booktotalview','varchar(50)','''sa''','','','System.String','sa','','S','varchar','50')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','deliveryaddress','S','N','booktotalview','varchar(150)','''sa''','','','System.String','sa','','N','varchar','150')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idbooking','S','N','booktotalview','int','''sa''','','','System.Int32','sa','','N','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idlist','S','N','booktotalview','int','''sa''','','','System.Int32','sa','','N','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idlistclass','S','N','booktotalview','varchar(36)','''sa''','','','System.String','sa','','N','varchar','36')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idman','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idsor01','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idsor02','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idsor03','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idsor04','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idsor05','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idstock','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','idstore','S','N','booktotalview','int','''sa''','','','System.Int32','sa','','N','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','intcode','S','N','booktotalview','varchar(50)','''sa''','','','System.String','sa','','N','varchar','50')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','list','S','N','booktotalview','varchar(150)','''sa''','','','System.String','sa','','N','varchar','150')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','listclass','N','N','booktotalview','varchar(150)','''sa''','','','System.String','sa','','S','varchar','150')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','manager','N','N','booktotalview','varchar(150)','''sa''','','','System.String','sa','','S','varchar','150')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','nbooking','N','N','booktotalview','int','''sa''','','','System.Int32','sa','','S','int','4')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('2','number','S','N','booktotalview','decimal(19,2)','''sa''','19','','System.Decimal','sa','','N','decimal','9')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('2','price','N','N','booktotalview','decimal(19,2)','''sa''','19','','System.Decimal','sa','','S','decimal','9')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','store','S','N','booktotalview','varchar(50)','''sa''','','','System.String','sa','','N','varchar','50')
GO

INSERT INTO columntypes (col_scale,field,denynull,iskey,tablename,sqldeclaration,lastmoduser,col_precision,format,systemtype,createuser,defaultvalue,allownull,sqltype,col_len) VALUES('','ybooking','S','N','booktotalview','smallint','''sa''','','','System.Int16','sa','','N','smallint','2')
GO

-- VERIFICA DI booktotalview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'booktotalview')
UPDATE customobject set isreal = 'N' where objectname = 'booktotalview'
ELSE
INSERT INTO customobject (objectname, isreal) values('booktotalview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


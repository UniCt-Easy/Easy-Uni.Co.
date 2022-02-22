
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


-- CREAZIONE VISTA bookingview
IF EXISTS(select * from sysobjects where id = object_id(N'[bookingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [bookingview]
GO






CREATE  VIEW [bookingview] as
(
	select booking.idbooking as idbooking,
		   booking.ybooking as ybooking,
		   booking.nbooking as nbooking,
		   booking.forename as forename,
		   booking.surname  as surname,
		   booking.cf as cf,
		   booking.idcustomuser as idcustomuser,
		   manager.title as managertitle,
		   manager.idman as idman,
		   booking.idlcard
	from booking join manager on (booking.idman = manager.idman)

)


GO

-- VERIFICA DI bookingview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bookingview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(50)','N','bookingview','N','','50','cf','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(50)','N','bookingview','N','','50','forename','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','bookingview','S','','4','idbooking','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(30)','N','bookingview','N','','30','idcustomuser','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','bookingview','N','','4','idlcard','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','bookingview','S','','4','idman','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(150)','N','bookingview','S','','150','managertitle','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','bookingview','N','','4','nbooking','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(50)','N','bookingview','N','','50','surname','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','N','System.Int16','smallint','N','bookingview','S','','2','ybooking','')
GO

-- VERIFICA DI bookingview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bookingview')
UPDATE customobject set isreal = 'N' where objectname = 'bookingview'
ELSE
INSERT INTO customobject (objectname, isreal) values('bookingview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


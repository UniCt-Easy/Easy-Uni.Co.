
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


-- CREAZIONE VISTA showcasedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[showcasedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [showcasedetailview]
GO






CREATE  view [showcasedetailview]
as
(
	select showcasedetail.idshowcase as idshowcase,
		   showcase.idstore as idstore,
		   stocktotalview.store as store,
		   showcasedetail.idlist as idlist,
		   stocktotalview.list as list,
		   stocktotalview.intcode as intcode,
		   stocktotalview.idlistclass as idlistclass,
		   stocktotalview.codelistclass as codelistclass,
		   stocktotalview.listclass as listclass,
		   stocktotalview.number as number,
		   stocktotalview.ordered as ordered,
		   stocktotalview.booked as booked,
		   showcasedetail.idinvkind as idinvkind,
		   showcasedetail.competencystart as competencystart,
		   showcasedetail.competencystop as competencystop,
		   showcasedetail.idupb_iva as idupb_iva
	from showcasedetail join showcase on (showcasedetail.idshowcase=showcase.idshowcase)
						join stocktotalview on (showcasedetail.idlist=stocktotalview.idlist and showcase.idstore=stocktotalview.idstore)
)



GO

-- VERIFICA DI showcasedetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'showcasedetailview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','booked','9','''assistenza''','decimal(19,2)','showcasedetailview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codelistclass','50','''assistenza''','varchar(50)','showcasedetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencystart','3','''assistenza''','date','showcasedetailview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencystop','3','''assistenza''','date','showcasedetailview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idinvkind','4','''assistenza''','int','showcasedetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlist','4','''assistenza''','int','showcasedetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlistclass','36','''assistenza''','varchar(36)','showcasedetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idshowcase','4','''assistenza''','int','showcasedetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idstore','4','''assistenza''','int','showcasedetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb_iva','36','''assistenza''','varchar(36)','showcasedetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','intcode','50','''assistenza''','varchar(50)','showcasedetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','list','150','''assistenza''','varchar(150)','showcasedetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','listclass','150','''assistenza''','varchar(150)','showcasedetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','number','9','''assistenza''','decimal(19,2)','showcasedetailview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ordered','9','''assistenza''','decimal(19,2)','showcasedetailview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','store','50','''assistenza''','varchar(50)','showcasedetailview','','','','','N','N','varchar','assistenza','System.String')
GO

-- VERIFICA DI showcasedetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'showcasedetailview')
UPDATE customobject set isreal = 'N' where objectname = 'showcasedetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('showcasedetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


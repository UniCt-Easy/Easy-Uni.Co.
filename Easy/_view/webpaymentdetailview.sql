-- CREAZIONE VISTA webpaymentdetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[webpaymentdetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [webpaymentdetailview]
GO


-- select * from webpaymentdetailview
-- clear_table_info'webpaymentdetailview'


CREATE   VIEW [webpaymentdetailview]
(
	idstore,
	store,
	idwebpayment,
	iddetail,
	ywebpayment,
	nwebpayment,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	price,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	annotations,
	idinvkind,
	competencystart,
	competencystop,
	idupb_iva

)
AS SELECT
	webpaymentdetail.idstore,
	store.description,
	webpayment.idwebpayment,
	webpaymentdetail.iddetail,
	webpayment.ywebpayment,
	webpayment.nwebpayment,
	webpaymentdetail.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	webpaymentdetail.number,
	webpaymentdetail.price,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	webpaymentdetail.cu,
	webpaymentdetail.ct,
	webpaymentdetail.lu,
	webpaymentdetail.lt,
	webpaymentdetail.idsor1,
	webpaymentdetail.idsor2,
	webpaymentdetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	webpaymentdetail.annotations, 
	webpaymentdetail.idinvkind,
	webpaymentdetail.competencystart,
	webpaymentdetail.competencystop,
	webpaymentdetail.idupb_iva
FROM webpaymentdetail
JOIN webpayment 
	ON webpayment.idwebpayment = webpaymentdetail.idwebpayment
JOIN store
	ON store.idstore = webpaymentdetail.idstore
JOIN list 
	ON webpaymentdetail.idlist = list.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN sorting sorting1
	ON sorting1.idsor = webpaymentdetail.idsor1
LEFT OUTER JOIN sorting sorting2
	ON sorting2.idsor = webpaymentdetail.idsor2
LEFT OUTER JOIN sorting sorting3
	ON sorting3.idsor = webpaymentdetail.idsor3


GO

-- VERIFICA DI webpaymentdetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'webpaymentdetailview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','annotations','400','''assistenza''','varchar(400)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codelistclass','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencystart','3','''assistenza''','date','webpaymentdetailview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencystop','3','''assistenza''','date','webpaymentdetailview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ct','8','''assistenza''','datetime','webpaymentdetailview','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','cu','64','''assistenza''','varchar(64)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','iddetail','4','''assistenza''','int','webpaymentdetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idinvkind','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlist','4','''assistenza''','int','webpaymentdetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlistclass','36','''assistenza''','varchar(36)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor01','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor02','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor03','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor04','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor05','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor1','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor2','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor3','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idstore','4','''assistenza''','int','webpaymentdetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb_iva','36','''assistenza''','varchar(36)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idwebpayment','4','''assistenza''','int','webpaymentdetailview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','intcode','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','list','150','''assistenza''','varchar(150)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','listclass','150','''assistenza''','varchar(150)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lt','8','''assistenza''','datetime','webpaymentdetailview','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lu','64','''assistenza''','varchar(64)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','number','9','''assistenza''','decimal(19,2)','webpaymentdetailview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','nwebpayment','4','''assistenza''','int','webpaymentdetailview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','price','9','''assistenza''','decimal(19,2)','webpaymentdetailview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','sortcode1','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','sortcode2','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','sortcode3','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','store','50','''assistenza''','varchar(50)','webpaymentdetailview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ywebpayment','2','''assistenza''','smallint','webpaymentdetailview','','','','','N','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI webpaymentdetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'webpaymentdetailview')
UPDATE customobject set isreal = 'N' where objectname = 'webpaymentdetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('webpaymentdetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


-- CREAZIONE VISTA storeunloadview
IF EXISTS(select * from sysobjects where id = object_id(N'[storeunloadview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [storeunloadview]
GO





CREATE VIEW storeunloadview
(
	idstoreunload,
	ystoreunload,
	nstoreunload,
	description,
	idstoreunload_motive,
	storeunload_motive,
	idreg,
	registry,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	storeunload.idstoreunload,
	storeunload.ystoreunload,
	storeunload.nstoreunload,
	storeunload.description,
	storeunload.idstoreunload_motive,
	storeunload_motive.description,
	storeunload.idreg,
	registry.title,
	storeunload.adate,
	storeunload.cu,
	storeunload.ct,
	storeunload.lu,
	storeunload.lt
FROM storeunload
LEFT OUTER JOIN registry
	ON registry.idreg = storeunload.idreg
LEFT OUTER JOIN storeunload_motive
	ON storeunload.idstoreunload_motive = storeunload_motive.idstoreunload_motive


GO

-- VERIFICA DI storeunloadview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'storeunloadview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','storeunloadview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','storeunloadview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','storeunloadview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','storeunloadview','S','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','storeunloadview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','storeunloadview','S','','4','idstoreunload','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','storeunloadview','S','','4','idstoreunload_motive','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','storeunloadview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','storeunloadview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','storeunloadview','S','','4','nstoreunload','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','storeunloadview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','storeunloadview','N','','50','storeunload_motive','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','storeunloadview','S','','2','ystoreunload','')
GO

-- VERIFICA DI storeunloadview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'storeunloadview')
UPDATE customobject set isreal = 'N' where objectname = 'storeunloadview'
ELSE
INSERT INTO customobject (objectname, isreal) values('storeunloadview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


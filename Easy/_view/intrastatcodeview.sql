-- CREAZIONE VISTA intrastatcodeview
IF EXISTS(select * from sysobjects where id = object_id(N'[intrastatcodeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [intrastatcodeview]
GO







--Pino Rana, elaborazione del 10/08/2005 15:18:12
CREATE                                VIEW intrastatcodeview 
  (
	ayear,
	idintrastatcode,
	code,
	description,
	idintrastatmeasure,
	measurecode,
	measuredescription,
	lt,
	lu
  )
  AS SELECT
	intrastatcode.ayear,
	intrastatcode.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,
	intrastatcode.idintrastatmeasure,
	intrastatmeasure.code,
	intrastatmeasure.description,
	intrastatcode.lt,
	intrastatcode.lu
  	FROM intrastatcode (NOLOCK)
	LEFT OUTER JOIN intrastatmeasure (NOLOCK)	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure


GO

-- VERIFICA DI intrastatcodeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'intrastatcodeview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','intrastatcodeview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(8)','N','intrastatcodeview','S','','8','code','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','intrastatcodeview','S','','200','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','intrastatcodeview','S','','4','idintrastatcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','intrastatcodeview','N','','4','idintrastatmeasure','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','intrastatcodeview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','intrastatcodeview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(10)','N','intrastatcodeview','S','','10','measurecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','intrastatcodeview','S','','50','measuredescription','')
GO

-- VERIFICA DI intrastatcodeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'intrastatcodeview')
UPDATE customobject set isreal = 'N' where objectname = 'intrastatcodeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('intrastatcodeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


-- CREAZIONE VISTA stocklocationunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[stocklocationunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stocklocationunusable]
GO

CREATE       VIEW [stocklocationunusable]
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	stocklocation.idstocklocation,
	stocklocation.stocklocationcode,
	stocklocation.nlevel,
	stocklocationlevel.description,
	stocklocation.paridstocklocation,
	stocklocation.description,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel
WHERE stocklocationlevel.flag & 2 <> 2
	OR stocklocation.idstocklocation IN
		(SELECT paridstocklocation FROM stocklocation
		WHERE paridstocklocation IS NOT NULL)






GO

-- VERIFICA DI stocklocationunusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'stocklocationunusable'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','datetime','','N','System.DateTime','datetime','N','stocklocationunusable','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(64)','N','stocklocationunusable','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(150)','N','stocklocationunusable','S','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','stocklocationunusable','S','','4','idstocklocation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(50)','N','stocklocationunusable','S','','50','leveldescr','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','datetime','','N','System.DateTime','datetime','N','stocklocationunusable','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(64)','N','stocklocationunusable','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','tinyint','','N','System.Byte','tinyint','N','stocklocationunusable','S','','1','nlevel','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','stocklocationunusable','N','','4','paridstocklocation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(50)','N','stocklocationunusable','S','','50','stocklocationcode','')
GO

-- VERIFICA DI stocklocationunusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'stocklocationunusable')
UPDATE customobject set isreal = 'N' where objectname = 'stocklocationunusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('stocklocationunusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


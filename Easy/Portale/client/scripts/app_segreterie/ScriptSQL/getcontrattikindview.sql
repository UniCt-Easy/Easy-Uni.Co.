
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


-- CREAZIONE VISTA getcontrattikindview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindview]
GO


CREATE VIEW [dbo].[getcontrattikindview]
AS
SELECT        
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	ck.parttime, 
	ck.tempdef, 
	ck.costolordoannuo as costolordoannuo_ck,
	ck.costolordoannuo_inq,
	ck.costolordoannuo_stip,
	isnull(ck.costolordoannuo_stip,isnull(ck.costolordoannuo_inq,ck.costolordoannuo)) as costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((ck.costolordoannuo/12),2,1) as decimal(18,2)) costomese,
	oremaxtempoparziale, oremaxtempopieno,
	oremaxdidatempoparziale, oremaxdidatempopieno,
	oremindidatempoparziale, oremindidatempopieno
FROM (
	SELECT cckk.*, 
	(select min(costolordoannuo) from inquadramento i WHERE i.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_inq,
	(select min(totale) from stipendio s WHERE s.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_stip
	FROM dbo.contrattokind cckk
) ck 


GO

-- VERIFICA DI getcontrattikindview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcontrattikindview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(18,2)','Generator','costolordoannuo','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(9,2)','Generator','costolordoannuo_ck','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(9,2)','Generator','costolordoannuo_inq','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(18,2)','Generator','costolordoannuo_stip','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(18,2)','Generator','costomese','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','decimal(18,2)','Generator','costoora','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattikindview','int','Generator','idcontrattokind','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremaxdidatempoparziale','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremaxdidatempopieno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremaxgg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremaxtempoparziale','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremaxtempopieno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremindidatempoparziale','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','int','Generator','oremindidatempopieno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','char(1)','Generator','parttime','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontrattikindview','char(1)','Generator','tempdef','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontrattikindview','varchar(50)','Generator','title','50','S','varchar','System.String','','','','','N')
GO

-- VERIFICA DI getcontrattikindview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcontrattikindview')
UPDATE customobject set isreal = 'N' where objectname = 'getcontrattikindview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcontrattikindview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA assetsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetsegview]
GO

CREATE VIEW [assetsegview] AS 
SELECT  asset.amortizationquota AS asset_amortizationquota, asset.ct AS asset_ct, asset.cu AS asset_cu, asset.flag AS asset_flag, asset.idasset, asset.idasset_prev AS asset_idasset_prev, asset.idassetunload AS asset_idassetunload, asset.idcurrlocation AS asset_idcurrlocation, asset.idcurrman AS asset_idcurrman, asset.idcurrsubman AS asset_idcurrsubman,
 inventory.description AS inventory_description, asset.idinventory, asset.idinventoryamortization AS asset_idinventoryamortization, asset.idpiece, asset.idpiece_prev AS asset_idpiece_prev, asset.lifestart AS asset_lifestart, asset.lt AS asset_lt, asset.lu AS asset_lu, asset.multifield AS asset_multifield,
 assetacquire.description AS assetacquire_description, [dbo].inventorytree.codeinv AS inventorytree_codeinv, [dbo].inventorytree.description AS inventorytree_description, [dbo].inventorytree.idinv AS inventorytree_idinv, upb.codeupb AS upb_codeupb, upb.title AS upb_title, upb.idupb AS upb_idupb, asset.nassetacquire, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, asset.rtf AS asset_rtf,CASE WHEN asset.transmitted = 'S' THEN 'Si' WHEN asset.transmitted = 'N' THEN 'No' END AS asset_transmitted, asset.txt AS asset_txt,
 isnull('Inventario: ' + inventory.description + '; ','') + ' ' + isnull('Numero inventario: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Class. Inv.: ' + [dbo].inventorytree.codeinv + '; ','') + ' ' + isnull('Denominazione Class. Inv.: ' + [dbo].inventorytree.description + '; ','') + ' ' + isnull('Class. Inv. Class. Inv.: ' + CAST( [dbo].inventorytree.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice UPB: ' + upb.codeupb + '; ','') + ' ' + isnull('Denominazione UPB: ' + upb.title + '; ','') + ' ' + isnull('UPB UPB: ' + upb.idupb + '; ','') + ' ' + isnull('Numero parte: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Codice RFID: ' + asset.rfid + '; ','') as dropdown_title
FROM asset WITH (NOLOCK) 
LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory
LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire
LEFT OUTER JOIN [dbo].inventorytree WITH (NOLOCK) ON assetacquire.idinv = [dbo].inventorytree.idinv
LEFT OUTER JOIN upb WITH (NOLOCK) ON assetacquire.idupb = upb.idupb
WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 
GO

-- VERIFICA DI assetsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','float','ASSISTENZA','asset_amortizationquota','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','datetime','ASSISTENZA','asset_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','varchar(64)','ASSISTENZA','asset_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','tinyint','ASSISTENZA','asset_flag','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','ASSISTENZA','asset_idasset_prev','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idassetunload','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idcurrlocation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idcurrman','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idcurrsubman','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idinventoryamortization','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_idpiece_prev','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','date','','asset_lifestart','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','datetime','','asset_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','varchar(64)','','asset_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(4000)','','asset_multifield','4000','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','asset_ninventory','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(30)','','asset_rfid','30','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','image','','asset_rtf','16','N','image','System.Byte[]','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(2)','','asset_transmitted','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','text','','asset_txt','16','N','text','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(150)','','assetacquire_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','nvarchar(1156)','','dropdown_title','1156','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','int','','idasset','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','idinventory','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetsegview','int','','idpiece','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(50)','','inventory_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(50)','','inventorytree_codeinv','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(150)','','inventorytree_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','inventorytree_idinv','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','int','','nassetacquire','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(50)','','upb_codeupb','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(36)','','upb_idupb','36','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetsegview','varchar(150)','','upb_title','150','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI assetsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetsegview')
UPDATE customobject set isreal = 'N' where objectname = 'assetsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


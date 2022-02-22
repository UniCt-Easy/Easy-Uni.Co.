
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


-- CREAZIONE VISTA assetacquiresegview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetacquiresegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetacquiresegview]
GO

CREATE VIEW [assetacquiresegview] AS 
SELECT  assetacquire.abatable AS assetacquire_abatable, assetacquire.adate AS assetacquire_adate, assetacquire.ct AS assetacquire_ct, assetacquire.cu AS assetacquire_cu, assetacquire.description, assetacquire.discount AS assetacquire_discount, assetacquire.flag AS assetacquire_flag, assetacquire.historicalvalue AS assetacquire_historicalvalue,
 assetload.description AS assetload_description, assetacquire.idassetload,
 [dbo].inventorytree.codeinv AS inventorytree_codeinv, [dbo].inventorytree.description AS inventorytree_description, assetacquire.idinv,
 inventory.description AS inventory_description, assetacquire.idinventory, assetacquire.idinvkind AS assetacquire_idinvkind,
 [dbo].list.description AS list_description, assetacquire.idlist, assetacquire.idmankind AS assetacquire_idmankind, assetacquire.idmot AS assetacquire_idmot,
 [dbo].registry.title AS registry_title, assetacquire.idreg, assetacquire.idsor1 AS assetacquire_idsor1, assetacquire.idsor2 AS assetacquire_idsor2, assetacquire.idsor3 AS assetacquire_idsor3,
 upb.title AS upb_title, assetacquire.idupb, assetacquire.invrownum AS assetacquire_invrownum, assetacquire.lt AS assetacquire_lt, assetacquire.lu AS assetacquire_lu, assetacquire.nassetacquire, assetacquire.ninv AS assetacquire_ninv, assetacquire.nman AS assetacquire_nman, assetacquire.number AS assetacquire_number, assetacquire.rownum AS assetacquire_rownum, assetacquire.rtf AS assetacquire_rtf, assetacquire.startnumber AS assetacquire_startnumber, assetacquire.tax AS assetacquire_tax, assetacquire.taxable AS assetacquire_taxable, assetacquire.taxrate AS assetacquire_taxrate,CASE WHEN assetacquire.transmitted = 'S' THEN 'Si' WHEN assetacquire.transmitted = 'N' THEN 'No' END AS assetacquire_transmitted, assetacquire.txt AS assetacquire_txt, assetacquire.yinv AS assetacquire_yinv, assetacquire.yman AS assetacquire_yman,
 isnull('Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Class. Inv.: ' + [dbo].inventorytree.codeinv + '; ','') + ' ' + isnull('Class. Inv.: ' + [dbo].inventorytree.description + '; ','') + ' ' + isnull('UPB: ' + upb.title + '; ','') as dropdown_title
FROM assetacquire WITH (NOLOCK) 
LEFT OUTER JOIN assetload WITH (NOLOCK) ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN [dbo].inventorytree WITH (NOLOCK) ON assetacquire.idinv = [dbo].inventorytree.idinv
LEFT OUTER JOIN inventory WITH (NOLOCK) ON assetacquire.idinventory = inventory.idinventory
LEFT OUTER JOIN [dbo].list WITH (NOLOCK) ON assetacquire.idlist = [dbo].list.idlist
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON assetacquire.idreg = [dbo].registry.idreg
LEFT OUTER JOIN upb WITH (NOLOCK) ON assetacquire.idupb = upb.idupb
WHERE  assetacquire.nassetacquire IS NOT NULL 
GO

-- VERIFICA DI assetacquiresegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetacquiresegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','decimal(19,2)','','assetacquire_abatable','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','date','','assetacquire_adate','3','S','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','datetime','','assetacquire_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','varchar(64)','','assetacquire_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','float','','assetacquire_discount','8','N','float','System.Double','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','tinyint','','assetacquire_flag','1','S','tinyint','System.Byte','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','decimal(19,2)','','assetacquire_historicalvalue','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_idinvkind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(20)','','assetacquire_idmankind','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','int','','assetacquire_idmot','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_idsor1','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_idsor2','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_idsor3','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_invrownum','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','datetime','','assetacquire_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','varchar(64)','','assetacquire_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_ninv','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_nman','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','int','','assetacquire_number','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_rownum','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','image','','assetacquire_rtf','16','N','image','System.Byte[]','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','assetacquire_startnumber','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','decimal(19,2)','','assetacquire_tax','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','decimal(19,2)','','assetacquire_taxable','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','float','','assetacquire_taxrate','8','N','float','System.Double','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(2)','','assetacquire_transmitted','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','text','','assetacquire_txt','16','N','text','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','smallint','','assetacquire_yinv','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','smallint','','assetacquire_yman','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(150)','','assetload_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','varchar(150)','','description','150','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','varchar(555)','','dropdown_title','555','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','idassetload','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','int','','idinv','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','int','','idinventory','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','idlist','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','int','','idreg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(36)','','idupb','36','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(50)','','inventory_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(50)','','inventorytree_codeinv','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(150)','','inventorytree_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(150)','','list_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetacquiresegview','int','','nassetacquire','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(101)','','registry_title','101','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetacquiresegview','varchar(150)','','upb_title','150','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI assetacquiresegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetacquiresegview')
UPDATE customobject set isreal = 'N' where objectname = 'assetacquiresegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetacquiresegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


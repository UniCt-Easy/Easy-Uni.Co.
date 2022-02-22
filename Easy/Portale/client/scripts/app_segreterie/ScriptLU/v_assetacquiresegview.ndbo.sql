
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


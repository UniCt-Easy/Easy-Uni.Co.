
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


-- CREAZIONE VISTA assetgrantview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetgrantview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetgrantview]
GO


CREATE      VIEW [assetgrantview]
(

    idasset, 
	idpiece, 
	idgrant, 
    amount, 
	ygrant, 
	description, 
	doc, 
	docdate,     
	idgrantload, 
	lt, 
	lu, 
	ct, 
	cu, 
	idaccmotive,
	codemotive,     
	motive, 
	idunderwriting,
	codeunderwriting,
	underwriting, 
	ninventory, 
	idinventory, 
	codeinventory,
	inventory, 
    idinventoryagency,
    codeinventoryagency,
    inventoryagency,
	idinv,
	codeinv,
	inventorytree,
	cost,
	assetacquiretotal
)

AS
SELECT   asset.idasset, 
         asset.idpiece, 
		 assetgrant.idgrant, 
         assetgrant.amount,  
		 assetgrant.ygrant,  
		 assetgrant.description,  
		 assetgrant.doc,  
		 assetgrant.docdate, 
         assetgrant.idgrantload,  
		 assetgrant.lt,  
		 assetgrant.lu,  
		 assetgrant.ct,  
		 assetgrant.cu,
		 accmotive.idaccmotive, 
		 accmotive.codemotive, 
         accmotive.title, 
		 underwriting.idunderwriting, 
		 underwriting.codeunderwriting,
		 underwriting.title, 
		 assetmain.ninventory,  
		 inventory.idinventory,  
		 inventory.codeinventory, 
		 inventory.description,
		 inventoryagency.idinventoryagency,
		 inventoryagency.codeinventoryagency,
         inventoryagency.description,
		 inventorytree.idinv,
		 inventorytree.codeinv,
		 inventorytree.description,
		 -- Costo (copiato da assetview)
	CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		 		
	END
	,CONVERT(decimal(19, 2), ROUND(ISNULL(amm.assetacquire.taxable, 0) * (1 - ISNULL(amm.assetacquire.discount, 0)) + ROUND(ISNULL(amm.assetacquire.tax, 0), 2) / amm.assetacquire.number, 2)) 
FROM  assetgrant 
JOIN asset ON assetgrant.idasset = asset.idasset and assetgrant.idpiece=asset.idpiece 
JOIN  assetacquire ON asset.nassetacquire = assetacquire.nassetacquire 
JOIN inventory ON assetacquire.idinventory = inventory.idinventory 
JOIN inventoryagency ON inventory.idinventoryagency = inventoryagency.idinventoryagency
JOIN inventorytree ON assetacquire.idinv = inventorytree.idinv
JOIN asset  AS assetmain     ON assetgrant.idasset=assetmain.idasset and assetmain.idpiece = 1
JOIN inventorykind	ON inventory.idinventorykind= inventorykind.idinventorykind  
LEFT OUTER JOIN underwriting ON assetgrant.idunderwriting = underwriting.idunderwriting 
LEFT OUTER JOIN accmotive ON accmotive.idaccmotive = assetgrant.idaccmotive



GO



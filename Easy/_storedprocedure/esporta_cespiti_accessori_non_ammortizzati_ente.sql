
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_cespiti_accessori_non_ammortizzati_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_cespiti_accessori_non_ammortizzati_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE         PROCEDURE [esporta_cespiti_accessori_non_ammortizzati_ente]
@year			int,
@idinventoryagency	int,
@idinventoryamortization int,
@idinv			int,
@flagcategory		char(1)

AS BEGIN
-------------------------------------------------------------------------------------
-------------- Elenco cespiti e accessori non ammortizzati nell'anno ----------------
-------------------------------------------------------------------------------------
--esporta_cespiti_accessori_non_ammortizzati_ente 2015,null,null,null,null
--setuser 'amministrazione'
	SELECT @flagcategory= ISNULL(@flagcategory,'N')

	declare @firstlevelidinv int
	select @firstlevelidinv = idparent
		from inventorytreelink
		where idchild = @idinv
		and nlevel = 1

	DECLARE @firstday datetime
	SET @firstday = CONVERT(datetime, '01/01/' + CONVERT(char(4),@year), 105)
	
	DECLARE @amortizationkind  varchar(50)
	SELECT @amortizationkind = description 
		FROM inventoryamortization
		WHERE idinventoryamortization = @idinventoryamortization

   	SELECT
		@amortizationkind			as 'Tipo rivalutazione',
		CASE 
			WHEN cespite_o_accessorio.idpiece = 1 THEN     'Cespite' 
			WHEN cespite_o_accessorio.idpiece > 1 THEN     'Accessorio'
		END					as 'Tipo Carico',
		inventoryagency.codeinventoryagency	as 'Cod. Ente Inventario',
		inventoryagency.description  		as 'Ente Inventario', 
		inventory.description      		as 'Inventario',  
		inventorykind.description  		as 'Tipo Inventario',
		cespite.ninventory			as 'Numero inventario Cespite',
		carico.description   			as 'Descrizione',
		CASE 
			WHEN cespite_o_accessorio.idpiece = 1 THEN     NULL
			WHEN cespite_o_accessorio.idpiece > 1 THEN     caricocespite.description
		END					as 'Descrizione Cespite Associato',
		categoriainventariale.codeinv	as 'Categoria Inventariale',
		classinventariale.codeinv		as 'Class. Inventariale',
		cespite_o_accessorio.lifestart as 'Inizio esistenza',
		year(cespite_o_accessorio.lifestart) as 'Anno inizio esistenza',
		buono.yassetload as 'Anno buono carico',
		buono.nassetload as 'N.buono carico',
		buono.ratificationdate as 'Data ratifica buono',
		AC.currentvalue as 'Valore residuo'
	FROM asset as cespite_o_accessorio 
	JOIN assetview_current AC				on AC.idasset = cespite_o_accessorio.idasset  and AC.idpiece = cespite_o_accessorio.idpiece
	JOIN assetacquire as carico				ON carico.nassetacquire = cespite_o_accessorio.nassetacquire
	LEFT OUTER JOIN assetload as buono		on carico.idassetload = buono.idassetload
	JOIN asset as cespite					ON cespite.idasset = cespite_o_accessorio.idasset
	JOIN assetacquire as caricocespite		ON caricocespite.nassetacquire = cespite.nassetacquire
	JOIN inventory							ON carico.idinventory = inventory.idinventory
	JOIN inventoryagency					ON inventory.idinventoryagency = inventoryagency.idinventoryagency
	JOIN inventorykind						ON inventory.idinventorykind = inventorykind.idinventorykind   
	join inventorytreelink as linkcategoria		on linkcategoria.idchild = carico.idinv and linkcategoria.nlevel = 1
	join inventorytree as categoriainventariale		on categoriainventariale.idinv = linkcategoria.idparent
	join inventorytree as classinventariale		on classinventariale.idinv = carico.idinv 
	WHERE   cespite.idpiece = 1 
		-- in carico
		--AND (carico.idassetload is not null or carico.flag & 3 = 0) 
		AND AC.is_loaded= 'S'  and AC.is_unloaded='N'and AC.currentvalue<>0 
		AND (@idinventoryagency is null or inventory.idinventoryagency = @idinventoryagency)
		AND NOT EXISTS (SELECT  *
				FROM    assetamortization
				JOIN 	inventoryamortization 					ON assetamortization.idinventoryamortization = inventoryamortization.idinventoryamortization
				WHERE 	assetamortization.idasset = cespite_o_accessorio.idasset AND 	   	assetamortization.idpiece = cespite_o_accessorio.idpiece 
					AND	(@idinventoryamortization is null or @idinventoryamortization = assetamortization.idinventoryamortization ) AND
						YEAR(assetamortization.adate) = @year 
						)
		AND (@idinv is null
			or (categoriainventariale.idinv = @firstlevelidinv and @flagcategory = 'S')
	        	OR (carico.idinv = @idinv AND @flagcategory = 'N') )
	ORDER BY carico.nassetacquire
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

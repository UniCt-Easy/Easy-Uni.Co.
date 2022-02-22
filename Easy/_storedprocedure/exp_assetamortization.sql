
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_assetamortization]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_assetamortization
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--exp_assetamortization 2013
CREATE      PROCEDURE exp_assetamortization
 (
	@ayear int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)

as BEGIN

SELECT 
AMV.am_year as 'Anno ammortamento',
AMV.ass_year as 'Inizio esistenza Cespite',
AMV.namortization as 'N. Ammortamento',
AMV.inventoryamortization as 'Tipo ammortamento',
AMV.inventory as 'Inventario',
upb.codeupb as 'Cod. UPB',
epupbkind.title as 'Tipo UPB',
upb.title as 'UPB',
asset.ninventory as 'N. inventario',
AMV.description as 'Desc. Cespite',
AMV.assetvalue as 'Valore iniziale' ,
AMV.amortizationquota * 100 as 'Aliquota applicata' ,
AMV.amount as 'Importo' ,
AMV.codeinv as 'Cod. class inventariale',
AMV.inventorytree as 'Class. inventariale',
AMV.inventorytree_lev1 as 'Categoria inventariale',
IAY.codemotive as 'Cod. Causale Ammort.',
IAY.motive  as 'Causale Ammort.'
from assetamortizationview AMV
join asset on asset.idasset = AMV.idasset and asset.idpiece = AMV.idpiece
join assetacquire on asset.nassetacquire =assetacquire.nassetacquire 
join upb on assetacquire.idupb = upb.idupb
left outer join epupbkind on epupbkind.idepupbkind=upb.idepupbkind
left outer join inventorysortingamortizationyearview IAY
on IAY.idinv = AMV.idinv 
and IAY.idinventoryamortization = AMV.idinventoryamortization
and IAY.ayear = @ayear
where  am_year = @ayear 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


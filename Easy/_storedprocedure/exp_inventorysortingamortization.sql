
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_inventorysortingamortization]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_inventorysortingamortization
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_inventorysortingamortization 2013

CREATE PROCEDURE exp_inventorysortingamortization
(
	@ayear int = null
)
AS 
BEGIN

SELECT
	ayear as 'Esercizio',
	codeinv as 'Cod. Class. Inv.',
	nlevel as 'N. Liv.',
	leveldescr as 'Livello',
	description as 'Class. Inv.', 
	codeinv_lev1 'Cod. Class. Livello 1',
	inventorytree_lev1 as 'Class. Livello 1',
	codeinventoryamortization as 'Cod. Tipo Inventario',
	inventoryamortization as 'Tipo Inventario',
	amortizationquota * 100 as 'Quota',
	official as 'Ufficiale',
	ammort_sval 'Ammortamento/Svalutazione',
	active as 'Attivo',
	age as 'Età min.',
	agemax as 'Età max.',
	valuemin as 'Val. min.',
	valuemax  as 'Val. max.',
	codemotive as 'Cod. Causale',
	motive as 'Causale',
	codemotiveunload as 'Cod. Causale Scarico',
	motiveunload as 'Causale Scarico'
	from 
	inventorysortingamortizationyearview
	where inventorysortingamortizationyearview.ayear = @ayear or @ayear is null
	order by ayear, codeinv
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

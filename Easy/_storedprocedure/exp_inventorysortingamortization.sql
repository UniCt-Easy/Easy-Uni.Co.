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

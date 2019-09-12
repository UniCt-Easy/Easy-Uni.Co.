
-- CREAZIONE VISTA stocklocationview
IF EXISTS(select * from sysobjects where id = object_id(N'[stocklocationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stocklocationview]
GO


CREATE       VIEW [stocklocationview] 
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
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
	stocklocation.active,
	stocklocation.idsor01,
	stocklocation.idsor02,
	stocklocation.idsor03,
	stocklocation.idsor04,
	stocklocation.idsor05,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel









GO

-- CREAZIONE VISTA locationview
IF EXISTS(select * from sysobjects where id = object_id(N'[locationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [locationview]
GO




CREATE VIEW locationview 
(
	idlocation,
	locationcode,
	newlocationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
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
	location.idlocation,
	location.locationcode,
	location.newlocationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.active,
	location.idsor01,
	location.idsor02,
	location.idsor03,
	location.idsor04,
	location.idsor05,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman









GO

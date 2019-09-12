 -- CREAZIONE VISTA motive770serviceview
IF EXISTS(select * from sysobjects where id = object_id(N'[motive770serviceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [motive770serviceview]
GO

--SELECT * FROM motive770serviceview
CREATE VIEW [motive770serviceview]
(
	idser,
	codeser,
	servicecode770,
	module,
	rec770kind,
	service,
	ayear,
	ct,
	cu,
	idmot,
	lt,
	lu,
	annotation,
	exemptioncode,
	exemptiondescr,
	socialseccode,
	socialsecdescr,
	cfagency,
	titleagency
)
	AS SELECT
motive770service.idser,
service.codeser,
service.servicecode770,
service.module,
service.rec770kind,
service.description,
motive770service.ayear,
motive770service.ct,
motive770service.cu,
motive770service.idmot,
motive770service.lt,
motive770service.lu,
motive770service.annotation,
motive770service.exemptioncode,
mod770_exemptioncode.description,
motive770service.socialseccode,
mod770_socialsecuritycode.description,
mod770_socialsecuritycode.cfagency,
mod770_socialsecuritycode.titleagency
--select *
FROM motive770service
JOIN service ON motive770service.idser = service.idser
LEFT OUTER JOIN motive770 ON motive770service.idmot = motive770.idmot and motive770service.ayear = motive770.ayear
LEFT OUTER JOIN mod770_exemptioncode ON motive770service.exemptioncode = mod770_exemptioncode.exemptioncode
and motive770service.ayear = mod770_exemptioncode.ayear
LEFT OUTER JOIN mod770_socialsecuritycode ON motive770service.socialseccode = mod770_socialsecuritycode.socialseccode
and motive770service.ayear = mod770_socialsecuritycode.ayear

GO

 

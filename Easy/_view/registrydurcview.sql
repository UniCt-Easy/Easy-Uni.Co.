-- CREAZIONE VISTA registrydurcview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydurcview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydurcview]
GO








CREATE    VIEW [dbo].[registrydurcview] 
(
	idreg,
	registry,
	idregistrydurc,
	iddurckind,
	durckinddescr,
	start,
	stop,
	adate,
	selfcertification,
	durccertification,
	doc,
	docdate,
	inpscode,
	inailcode,
	buildingcode,
	otherinsurancecode,
	flagirregular,
	cu, 
	ct, 
	lu,
	lt
)
AS 
SELECT
	registrydurc.idreg, 
	registry.title, 
	registrydurc.idregistrydurc,
	registrydurc.iddurckind,
	durckind.description,
	registrydurc.start,
	registrydurc.stop,
	registrydurc.adate,
	registrydurc.selfcertification,
	registrydurc.durccertification,
	registrydurc.doc,
	registrydurc.docdate,
	registrydurc.inpscode,
	registrydurc.inailcode,
	registrydurc.buildingcode,
	registrydurc.otherinsurancecode,
	registrydurc.flagirregular,
	registrydurc.cu, 
	registrydurc.ct, 
	registrydurc.lu, 
	registrydurc.lt
FROM registrydurc (NOLOCK)
JOIN durckind
	ON registrydurc.iddurckind = durckind.iddurckind
JOIN registry (NOLOCK)
	ON registrydurc.idreg = registry.idreg



GO

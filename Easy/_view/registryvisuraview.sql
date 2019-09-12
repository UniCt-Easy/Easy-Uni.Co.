-- CREAZIONE VISTA registryvisuraview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryvisuraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryvisuraview]
GO





--select * from registryvisuraview


CREATE    VIEW [dbo].[registryvisuraview] 
(
	idreg,
	registry,
	idregistryvisura,
	start,
	stop,
	visuracertification,
	cu, 
	ct, 
	lu,
	lt
)
AS 
SELECT
	registryvisura.idreg, 
	registry.title, 
	registryvisura.idregistryvisura,
	registryvisura.start,
	registryvisura.stop,
	registryvisura.visuracertification,
	registryvisura.cu, 
	registryvisura.ct, 
	registryvisura.lu, 
	registryvisura.lt
FROM registryvisura (NOLOCK)
JOIN registry (NOLOCK)
	ON registryvisura.idreg = registry.idreg



GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registry_doublereference]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registry_doublereference]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [exp_registry_doublereference]
AS
BEGIN



SELECT 
	idreg AS 'Codice Anagrafica', 
	title AS 'Denominazione' FROM registry
WHERE (SELECT COUNT(*) FROM registryreference
			WHERE registry.idreg = registryreference.idreg
			AND registryreference.flagdefault = 'S') > 1

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


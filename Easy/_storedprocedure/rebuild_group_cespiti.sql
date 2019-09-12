SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_group_cespiti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_group_cespiti]
GO

CREATE PROCEDURE [rebuild_group_cespiti]
(@ayear int = NULL)
AS BEGIN
-- Il parametro @ayear non viene adoperato, viene passato per eventuali sviluppi futuri
	PRINT 'Ricostruzione di LOCATIONLINK...'
	EXEC rebuild_locationlink
	PRINT 'Ricostruzione di INVENTORYTREELINK...'
	EXEC rebuild_inventorytreelink
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


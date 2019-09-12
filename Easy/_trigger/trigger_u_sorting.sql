SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_sorting]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_sorting]
GO

CREATE TRIGGER [trigger_u_sorting] ON sorting FOR UPDATE
AS BEGIN
DECLARE @idsor int
DECLARE @nlevel tinyint

IF UPDATE(paridsor)
BEGIN
	DECLARE @newidparent int
	SELECT @idsor = idsor, @newidparent = paridsor, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #sortinglink (idchild int)
	
	INSERT INTO #sortinglink
	SELECT idchild
	FROM sortinglink
	WHERE sortinglink.idparent = @idsor
	
	UPDATE sortinglink
	SET idparent = (SELECT idparent FROM sortinglink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = sortinglink.nlevel)
	FROM #sortinglink T
	WHERE sortinglink.idchild = T.idchild
	AND nlevel < @nlevel
END
END

SET QUOTED_IDENTIFIER OFF



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


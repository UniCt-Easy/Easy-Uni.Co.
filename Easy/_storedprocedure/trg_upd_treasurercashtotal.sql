SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_treasurercashtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_treasurercashtotal]
GO

CREATE  PROCEDURE [trg_upd_treasurercashtotal]
(
	@ayear int,
	@idtreasurer int,
	@movkind char(1),
	@oldamount decimal(19,2),
	@newamount decimal(19,2)
)
AS BEGIN

DECLARE @diff decimal(19,2)

IF (( ISNULL(@newamount,0) <> ISNULL(@oldamount,0)) OR
	   (@newamount IS NOT NULL AND @oldamount IS NULL)
	   OR (@newamount IS NULL AND @oldamount IS NOT NULL))
	BEGIN
		IF (@movkind = 'I')
			SELECT @diff = - ISNULL(@oldamount,0) + ISNULL(@newamount,0)
		ELSE
			SELECT @diff = ISNULL(@oldamount,0) - ISNULL(@newamount,0)
		
		IF EXISTS(select * from treasurercashtotal WHERE idtreasurer = @idtreasurer AND ayear = @ayear)
			BEGIN
				UPDATE treasurercashtotal SET currentfloatfund = ISNULL(currentfloatfund,0) + @diff
				WHERE idtreasurer = @idtreasurer AND ayear = @ayear
			END
		ELSE
			BEGIN
				INSERT INTO treasurercashtotal	(idtreasurer, ayear, currentfloatfund)	VALUES (@idtreasurer, @ayear, @diff)
			END
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

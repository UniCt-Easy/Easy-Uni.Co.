if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_commontable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_commontable]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE closeyear_undo_commontable
(
	@ayear int
)
AS BEGIN
/* Versione 1.0.2 del 15/11/2007 ultima modifica: Pino */

DECLARE @nextayear int
SET @nextayear = @ayear + 1

DECLARE @minlevop tinyint
SELECT  @minlevop = MIN(nlevel) FROM finlevel WHERE flag&2 <> 0 AND ayear = @ayear

DELETE FROM finlevel
WHERE ayear = @nextayear
--AND nlevel <= @minlevop

DELETE FROM finlookup
WHERE  oldidfin IN (
SELECT idfin
FROM fin
WHERE ayear = @ayear
--AND nlevel <= @minlevop
)

DELETE FROM finlast
WHERE idfin IN (
SELECT idfin
FROM fin
WHERE ayear = @nextayear
--AND nlevel <= @minlevop
)

DELETE FROM finlink
WHERE idchild IN (
SELECT idfin
FROM fin
WHERE ayear = @nextayear
--AND nlevel <= @minlevop
)

DELETE FROM fin
WHERE ayear = @nextayear
--AND nlevel <= @minlevop

--UPDATE mainaccountingyear SET completed = 'N' WHERE ayear = @nextayear

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

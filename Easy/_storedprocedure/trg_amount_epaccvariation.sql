SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_amount_epaccvariation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_amount_epaccvariation]
GO

CREATE  PROCEDURE [trg_amount_epaccvariation]
(
	@ayear int,
	@idmov int,
	@parentidmovement int,
	@nphase tinyint,
	@diffnewold decimal(19,2),
	@diffnewold2 decimal(19,2),
	@diffnewold3 decimal(19,2),
	@diffnewold4 decimal(19,2),
	@diffnewold5 decimal(19,2)
)
AS BEGIN


	UPDATE epacctotal SET
	curramount = ISNULL(curramount,0) + @diffnewold,
	available = ISNULL(available,0) + @diffnewold,

	curramount2 = ISNULL(curramount2,0) + @diffnewold2,
	available2 = ISNULL(available2,0) + @diffnewold2,

	curramount3 = ISNULL(curramount3,0) + @diffnewold3,
	available3 = ISNULL(available3,0) + @diffnewold3,

	curramount4 = ISNULL(curramount4,0) + @diffnewold4,
	available4 = ISNULL(available4,0) + @diffnewold4,

	curramount5 = ISNULL(curramount5,0) + @diffnewold5,
	available5 = ISNULL(available5,0) + @diffnewold5
	WHERE idepacc = @idmov AND ayear = @ayear
	
	IF @parentidmovement IS NOT NULL
	BEGIN
		UPDATE epacctotal SET
				available = ISNULL(available,0) - @diffnewold,
				available2 = ISNULL(available2,0) - @diffnewold2,
				available3 = ISNULL(available3,0) - @diffnewold3,
				available4 = ISNULL(available4,0) - @diffnewold4,
				available5 = ISNULL(available5,0) - @diffnewold5
		WHERE idepacc = @parentidmovement AND ayear = @ayear
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




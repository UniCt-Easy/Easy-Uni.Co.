SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_epaccamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_epaccamount]
GO


CREATE   PROCEDURE [trg_upd_epaccamount]
(
	@ayear int,
	@paridmov int,
	@idmov int,
	@diffnew_old decimal(19,2),
	@diffnew_old2 decimal(19,2),
	@diffnew_old3 decimal(19,2),
	@diffnew_old4 decimal(19,2),
	@diffnew_old5 decimal(19,2)
	

)
AS BEGIN

		DECLARE @nphase tinyint
		SELECT @nphase = nphase FROM epacc WHERE idepacc = @idmov

		UPDATE epacctotal SET
			curramount = ISNULL(curramount,0) + isnull(@diffnew_old,0),
			available = ISNULL(available,0) + isnull(@diffnew_old,0),

			curramount2 = ISNULL(curramount2,0) + isnull(@diffnew_old2,0),
			available2 = ISNULL(available2,0) + isnull(@diffnew_old2,0),

			curramount3 = ISNULL(curramount3,0) + isnull(@diffnew_old3,0),
			available3 = ISNULL(available3,0) + isnull(@diffnew_old3,0),


			curramount4 = ISNULL(curramount4,0) + isnull(@diffnew_old4,0),
			available4 = ISNULL(available4,0) + isnull(@diffnew_old4,0),

			curramount5 = ISNULL(curramount5,0) + isnull(@diffnew_old5,0),
			available5 = ISNULL(available5,0) + isnull(@diffnew_old5,0)

		WHERE idepacc = @idmov
			AND ayear = @ayear

		IF ( @paridmov IS NOT NULL) 
		BEGIN
			UPDATE epacctotal SET
			available = ISNULL(available, 0) - isnull(@diffnew_old,0),
			available2 = ISNULL(available2, 0) - isnull(@diffnew_old2,0),
			available3 = ISNULL(available3, 0) - isnull(@diffnew_old3,0),
			available4 = ISNULL(available4, 0) - isnull(@diffnew_old4,0),
			available5 = ISNULL(available5, 0) - isnull(@diffnew_old5,0)
			WHERE idepacc = @paridmov
			AND ayear = @ayear
		END


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




if exists (select * from dbo.sysobjects where id = object_id(N'[trg_yearbalance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_yearbalance]
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [trg_yearbalance]
(
	@residualkind char(1),
	@ybalance int OUTPUT
)
AS BEGIN

	if (@residualkind = 'I') 
		SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=4)
	ELSE
		SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=5) 
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


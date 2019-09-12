if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_liquidazioneiva_acconto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure rpt_liquidazioneiva_acconto
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_liquidazioneiva_acconto
(
	@ayear int,
	@startmounth int,
	@stopmounth int
)
AS BEGIN

-- exec rpt_liquidazioneiva_acconto 2016,1 ,12

SELECT nivapay,
		start,
		stop,
		ISNULL(creditamount,0) as creditamount
FROM ivapay
where paymentkind='A'
	and yivapay = @ayear
	and month(start) between @startmounth and @stopmounth
order by start		

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
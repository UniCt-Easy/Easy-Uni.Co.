SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestprof_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestprof_spese]
GO


--exec rpt_compensoprestprof_spese_1 2006,1
CREATE  PROCEDURE [rpt_compensoprestprof_spese]
	@ycon int,
	@ncon int
AS
BEGIN
	SELECT
		profservicerefund.ycon,
		profservicerefund.ncon,
		profservicerefund.nrefund,
		profservicerefund.amount,
		profrefund.description
	FROM  profservicerefund	
	LEFT OUTER JOIN profrefund
		ON   profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
	WHERE 
	(profservicerefund.ycon = @ycon AND  profservicerefund.ncon = @ncon)
	ORDER BY profservicerefund.nrefund
		
END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


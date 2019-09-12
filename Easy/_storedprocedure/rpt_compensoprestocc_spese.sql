SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc_spese]
GO


--exec rpt_compensoprestocc_spese 2009,152
CREATE  PROCEDURE [rpt_compensoprestocc_spese]
	@ayear int,
	@ycon int,
	@ncon int
AS
BEGIN
	IF (@ayear IS NULL) 
	BEGIN
		SELECT
			casualcontractrefund.ycon,
			casualcontractrefund.ncon,
			casualcontractrefund.ayear,
			casualcontractrefund.nrefund,
			casualcontractrefund.amount,
			casualrefund.description,
			casualrefund.deduction 
		FROM  	casualcontractrefund	
		LEFT OUTER JOIN casualrefund
			ON   casualcontractrefund.idlinkedrefund = casualrefund.idlinkedrefund
		WHERE 
			casualcontractrefund.ycon = @ycon AND  casualcontractrefund.ncon = @ncon
		ORDER BY  casualcontractrefund.ayear, casualcontractrefund.nrefund
	END
	ELSE
	BEGIN
		SELECT
			casualcontractrefund.ycon,
			casualcontractrefund.ncon,
			casualcontractrefund.ayear,
			casualcontractrefund.nrefund,
			casualcontractrefund.amount,
			casualrefund.description,
			casualrefund.deduction 
		FROM  	casualcontractrefund	
		LEFT OUTER JOIN casualrefund
			ON   casualcontractrefund.idlinkedrefund = casualrefund.idlinkedrefund
		WHERE 
			casualcontractrefund.ycon  = @ycon AND  casualcontractrefund.ncon = @ncon
		AND	casualcontractrefund.ayear = @ayear
		ORDER BY  casualcontractrefund.ayear, casualcontractrefund.nrefund
	END
END 

go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
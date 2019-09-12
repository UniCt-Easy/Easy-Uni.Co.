if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestprof_imponibili]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestprof_imponibili]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE [rpt_compensoprestprof_imponibili]
	@ycon int,
	@ncon int
AS
BEGIN
	SELECT
		profservice.ycon,
		profservice.ncon,
		profservice.feegross as 'feegross',
		profservice.pensioncontributionrate as 'pensioncontributionrate',
		profservice.socialsecurityrate as 'socialsecurityrate',
		profservice.ivarate as 'ivarate',
		profservice.ivaamount as 'ivaamount',
		profservicetax.taxablenet as 'taxablegross',
		profservicetax.employrate,
		profservicetax.employtax,
		profservice.totalcost,
		-- Tipo IVA idivakind
		ivakind.description,
		-- Spese imponibili previdenzialmente
		(SELECT sum(amount)			
		FROM  profservicerefund  
		JOIN  profrefund 
		      ON profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
		WHERE ycon = @ycon 
		AND   ncon = @ncon
		AND  ISNULL(flagsecuritydeduction,'N') = 'N') as 'nosecuritydedrefund',	
		-- Spese imponibili ai fini IVA
		(SELECT sum(amount)			
		FROM  profservicerefund  
		JOIN  profrefund 
		      ON profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
		WHERE ycon = @ycon 
		AND   ncon = @ncon
		AND  ISNULL(flagivadeduction,'N')= 'N') as 'noivadedrefund',
		-- Spese imponibili fiscalmente
		(SELECT sum(amount)			
		FROM  profservicerefund  
		JOIN  profrefund 
		      ON profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
		WHERE ycon = @ycon 
		AND   ncon = @ncon
		AND  ISNULL(flagfiscaldeduction,'N') = 'N') as 'nofiscaldedrefund',
		-- Spese non imponibili
		(SELECT sum(amount)			
		FROM profservicerefund  
		JOIN  profrefund 
		      ON profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
		WHERE 	ycon = @ycon 
		AND ncon = @ncon
		AND  ISNULL(flagfiscaldeduction,'N')= 'S'
		AND  ISNULL(flagivadeduction,'N')= 'S'
		AND  ISNULL(flagsecuritydeduction,'N')= 'S'
		) as 'totdedrefund',
		(SELECT sum(amount)			
		FROM profservicerefund  
		WHERE 	ycon = @ycon 
		AND ncon = @ncon) as 'totalrefund'
	FROM  	profservice
		LEFT OUTER JOIN  profservicetax 
		ON    profservice.ycon = profservicetax.ycon AND
		      profservice.ncon = profservicetax.ncon 
		LEFT OUTER JOIN  ivakind 
		ON    profservice.idivakind = ivakind.idivakind 
	WHERE 
		profservice.ycon = @ycon AND  profservice.ncon = @ncon
END 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


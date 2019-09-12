SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestprof_ritenuta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestprof_ritenuta]
GO


CREATE  PROCEDURE [rpt_compensoprestprof_ritenuta]
	@ycon		smallint, 
	@ncon		int
AS
	BEGIN
		SELECT 
			profservicetax.taxcode,
			description,
			'taxkind' = CASE tax.taxkind
				WHEN  1 THEN 'Fiscale'
				WHEN  2 THEN 'Assistenziale'
				WHEN  3 THEN 'Previdenziale'
				WHEN  4 THEN 'Assicurativa'
				WHEN  5 THEN 'Arretrati'
				WHEN  6 THEN 'Altro'
			ELSE ''
			END,
			taxablegross,
			taxablenet,
			deduction,
			'aliquotaamministrazione' = adminrate*100,
			'aliquotadipendente' = employrate*100,
			admintax,
			employtax
			FROM profservicetax
			LEFT OUTER JOIN tax
			ON profservicetax.taxcode = tax.taxcode
			WHERE ycon = @ycon
			AND ncon = @ncon
      ORDER BY profservicetax.taxcode ASC
	END



go
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_partitario_cassa]
	@ayear smallint,
	@kind char(1),
	@idupb	varchar(36),
	@finpart char(1),
	@nlevel tinyint,
	@start smalldatetime,
	@stop smalldatetime,
	@showupb char (1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idfin int
AS
	BEGIN
/* Versione 1.0.1 del 11/09/2007 ultima modifica: SARA */
		IF @finpart = 'E'
			EXEC rpt_partitario_entrata_cassa
				@ayear,
				@kind,
				@idupb,
				@nlevel,
				@start,
				@stop,
				@showupb,
				@showchildupb,
				@suppressifblank,
				@flagnofficial,
				@idfin
		ELSE
			EXEC rpt_partitario_spesa_cassa
				@ayear,
				@kind,
				@idupb,
				@nlevel,
				@start,
				@stop,
				@showupb,
				@showchildupb,
				@suppressifblank,
				@flagnofficial,
				@idfin
  END








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


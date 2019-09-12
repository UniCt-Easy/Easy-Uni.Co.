SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_subresp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_subresp]
GO

CREATE  PROCEDURE [rpt_sitpatrim_subresp]
	@idmanager	int,
	@idinventory	int,
	@start		datetime,
	@stop		datetime
	AS
	BEGIN
		IF @idmanager = 0 SET @idmanager = NULL
		IF @idinventory = 0 SET @idinventory = NULL 
		EXEC [rpt_sitpatrim] NULL, NULL, @idmanager, NULL, NULL,
		@idinventory,@start,@stop,	'S'
	END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


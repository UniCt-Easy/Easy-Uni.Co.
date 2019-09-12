SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_class]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_class]
GO

CREATE  PROCEDURE [rpt_sitpatrim_class]
	@nlevelinvtree	tinyint,
	@codeinv	varchar(50),
	@idinventory    int,
	@start		datetime,
	@stop		datetime	
	AS
	BEGIN
		IF @nlevelinvtree = 0 SET @nlevelinvtree = NULL
		IF @codeinv = '' SET @codeinv = NULL
		IF @idinventory = 0 SET @idinventory = NULL
		EXEC [rpt_sitpatrim] NULL, NULL, NULL, @nlevelinvtree, @codeinv, 
		@idinventory,@start,@stop,	'C'
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


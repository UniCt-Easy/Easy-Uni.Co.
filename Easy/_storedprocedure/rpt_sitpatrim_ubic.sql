SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitpatrim_ubic]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitpatrim_ubic]
GO

CREATE     PROCEDURE [rpt_sitpatrim_ubic]
	@nlevellocation tinyint,
	@idlocation varchar(50),
	@nlevelinvtree tinyint,
	@codeinv varchar(50),
	@idinventory int,
	@start datetime,
	@stop datetime
	AS
	BEGIN
		IF @nlevellocation = 0 SET @nlevellocation = NULL
		IF @idlocation = '' SET @idlocation = NULL
		IF @nlevelinvtree = 0 SET @nlevelinvtree = NULL
		IF @codeinv = '' SET @codeinv = NULL
		IF @idinventory =  0 SET @idinventory = NULL
		EXEC [rpt_sitpatrim] @nlevellocation, @idlocation, NULL,  @nlevelinvtree, @codeinv, 
		@idinventory,@start,@stop,'U'
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


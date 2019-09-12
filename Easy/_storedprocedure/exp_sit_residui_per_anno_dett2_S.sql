if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sit_residui_per_anno_dett2_S]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sit_residui_per_anno_dett2_S]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE[exp_sit_residui_per_anno_dett2_S]
	@ayear 		int,
	@date		datetime,
	-- @finpart 	char(1),
	@levelusable 	tinyint,
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN
EXEC [rpt_sit_residui_per_anno_dett2] @ayear,@date,'S',@levelusable,@idupb,@showupb,@showchildupb
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
 
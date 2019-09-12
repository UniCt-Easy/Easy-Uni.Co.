if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazioneupbbilancio_e]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazioneupbbilancio_e]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE PROCEDURE [exp_situazioneupbbilancio_e]
(
	@ayear smallint,
	@date datetime,
	@finpart char(1),
	@idupb varchar(36) = null,
	@showchildupb char(1),
	@idfin int = null,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
	EXEC [exp_situazioneupbbilancio] @ayear, @date, @finpart, @idupb, @showchildupb, @idfin, @idsor01, @idsor02,@idsor03,@idsor04,@idsor05
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
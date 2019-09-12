if exists (select * from dbo.sysobjects where id = object_id(N'[compute_csa_versamenti_posticipati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_csa_versamenti_posticipati]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

CREATE  PROCEDURE [compute_csa_versamenti_posticipati]
(
	@ayear int,
	@idcsa_import int
)
AS BEGIN

-- setuser 'amministrazione'
-- select * from csa_import
-- [compute_csa_versamenti_posticipati] 2015,13

  --   + movkind 4 mov. spesa contributi/ritenute (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
  --   - movkind 10 mov. entrata di ricavo contributi (negativi) ( VERSAMENTI se liquidazione diretta)
  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)
  
       
SELECT * FROM f_compute_csa_versamenti_posticipati (@ayear, @idcsa_import)
return
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
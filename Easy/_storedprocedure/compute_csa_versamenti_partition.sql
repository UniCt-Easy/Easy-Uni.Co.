if exists (select * from dbo.sysobjects where id = object_id(N'[compute_csa_versamenti_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_csa_versamenti_partition]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 

if not exists (select * from systypes where name = 'int_list') begin 
	CREATE TYPE dbo.int_list AS TABLE      ( n int)  
end
GO
CREATE  PROCEDURE [compute_csa_versamenti_partition]
(
	@ayear int,
	@idcsa_import int,
	@lista_idcsa_import dbo.int_list  READONLY, -- @idcsa_import int,
	@lista_idreg_agency dbo.int_list  READONLY   --@idcsa_agency int
)
AS BEGIN

-- setuser 'amministrazione'
-- select * from csa_import
-- compute_csa_versamenti_partition 2015,13

  --   + movkind 4 mov. spesa contributi/ritenute (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
  --   - movkind 10 mov. entrata di ricavo contributi (negativi) ( VERSAMENTI se liquidazione diretta)
  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)
  
       
SELECT * FROM f_compute_csa_versamenti_partition (@ayear,@idcsa_import, @lista_idcsa_import,@lista_idreg_agency)
return

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
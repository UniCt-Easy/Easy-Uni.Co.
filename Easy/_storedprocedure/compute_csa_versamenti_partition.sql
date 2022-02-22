
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
 
 

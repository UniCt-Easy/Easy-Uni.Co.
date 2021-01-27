
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_libro_inventari_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_libro_inventari_new]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 --setuser 'amministrazione'
-- exec [rpt_libro_inventari_new] 8, '1900-01-01', '1900-01-01' ,'S','S',null,null,null,'S'

CREATE    PROCEDURE [rpt_libro_inventari_new]
(
	@levelinv	  int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36) = null,
	@showchildupb	char(1) = 'S',
	@idsor1 int = null,
	@showidsor1child char(1), 
	@idsor2 int = null,
	@idsor3 int = null,
	@apertura varchar(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null	
)
AS BEGIN

declare @ayear_rif int
set @ayear_rif=year(@stop)

SELECT 
	@ayear_rif as 'ayear_rif' 
END
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

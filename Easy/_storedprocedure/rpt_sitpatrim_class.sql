
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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



/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE                               PROCEDURE rpt_partitario
	@ayear int,
	@kind char(1),
	@idupb varchar(36),
	@finpart char(1),	
	@nlevel tinyint,
	@start datetime,
	@stop datetime,
	@showupb char (1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@flagnofficial	char(1),
	@idfin int
AS
	BEGIN
/* Versione 1.0.1 del 11/09/2007 ultima modifica: SARA */
		IF @finpart = 'E'
			EXEC rpt_partitario_entrata_tutte_fasi 
				@ayear,
				@kind,
				@idupb,
				@nlevel,
				@start,
				@stop,
				@showupb,
				@showchildupb,
				@suppressifblank,
				@flagnofficial,
				@idfin 

		ELSE
			EXEC rpt_partitario_spesa_tutte_fasi 
				@ayear,
				@kind,
				@idupb,
				@nlevel,
				@start,
				@stop,
				@showupb,
				@showchildupb,
				@suppressifblank,
				@flagnofficial,
				@idfin 
  END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


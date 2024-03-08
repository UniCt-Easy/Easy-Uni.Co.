
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_filtered_sortingkind_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_filtered_sortingkind_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE              PROCEDURE [compute_filtered_sortingkind_expense] 
@ayear int,
@idexp int,
@idreg int,
@idupb varchar(36),
@nphase char(1),
@idfin int,
@idman int,
@expenseamount decimal(23,2),
@idsorkind int,
@idsor int,
@idsubclass smallint,
@sortingamount decimal(23,2),
@description varchar(150),
@flagnodate char(1),
@tobecontinued char(1),
@start datetime,
@stop datetime,
@valuen1 decimal(23,2),
@valuen2 decimal(23,2),
@valuen3 decimal(23,2),
@valuen4 decimal(23,2),
@valuen5 decimal(23,2),
@values1 varchar(20),
@values2 varchar(20),
@values3 varchar(20),
@values4 varchar(20),
@values5 varchar(20),
@valuev1 decimal(23,6),
@valuev2 decimal(23,6),
@valuev3 decimal(23,6),
@valuev4 decimal(23,6),
@valuev5 decimal(23,6)
AS



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sorting_mov]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sorting_mov]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




--  rpt_sorting_mov '0001000100010001','07U_SIOPE','S'




CREATE   PROCEDURE [rpt_sorting_mov]
	@idsor varchar(32), 
	@idsorkind varchar(20),
	@finpart varchar(1)
AS
BEGIN

declare @nphase int



if @finpart='S' 
begin
	select @nphase=nphaseexpense from sortingkind where idsorkind=@idsorkind 
	
	select * from expensesorted es join expense ex on es.idexp=ex.idexp 
	join expenseyear ey on ex.idexp=ey.idexp

	where ex.nphase=@nphase
	and es.idsorkind=@idsorkind
	and es.idsor like isnull(@idsor,'%')

end
else
begin
	select @nphase=nphaseincome from sortingkind where idsorkind=@idsorkind 
	
	select * from incomesorted ic join income im on ic.idinc=im.idinc 
	join incomeyear iy on im.idinc=iy.idinc

	where im.nphase=@nphase
	and ic.idsorkind=@idsorkind
	and ic.idsor like isnull(@idsor,'%')

END

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


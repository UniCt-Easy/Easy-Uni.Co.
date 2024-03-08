
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_entry_onparentaccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_entry_onparentaccount]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE PROCEDURE [exp_entry_onparentaccount]
(
	@ayear int,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS 
BEGIN
-- exec exp_entry_onparentaccount 2016, null, null, null, null, null
	SELECT distinct 
		E.yentry as 'Eserc.Scrittura',
		E.nentry as 'Num.Scrittura',
		A.codeacc as 'Cod.Conto (padre)',
		A.title as 'Conto (padre)',
		U.codeupb as 'Cod.UPB',
		U.title as 'UPB',
		ED.amount as 'Importo',
		E.adate as 'Data contabile',
		M.codemotive as 'Cod.Causale',
		M.title as 'Causale'
	 FROM entry E
	join  entrydetail ED
		on E.yentry = ED.yentry and E.nentry = ED.nentry
	join account A
		on ED.idacc = A.idacc
	left outer join account A2 
		on A2.paridacc = A.idacc
	left outer join upb U
		on ED.idupb = U.idupb
	left outer join accmotive M
		on M.idaccmotive = ED.idaccmotive
	where E.yentry = @ayear
		and A2.paridacc is not null
		--and (select count(*) from account A2 where A2.paridacc = A.idacc) >0
		AND (@idsor01 IS NULL OR E.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR E.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR E.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR E.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR E.idsor05 = @idsor05)

END 

 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


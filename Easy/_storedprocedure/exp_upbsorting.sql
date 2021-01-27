
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_upbsorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_upbsorting
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exp_upbsorting 16, 'NONCLASSIFICATI'
CREATE      PROCEDURE exp_upbsorting
 (
	@idsorkind int,
	@kind varchar(20), -- 'CLASSIFICATI', 'NONCLASSIFICATI'
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)

as BEGIN
	
	--select * from sortingkind
	--select * from upbsortingview
	declare @codesorkind varchar(20)
	declare @sortingkind varchar(50)
 
	select @codesorkind = codesorkind,
	@sortingkind = description
	FROM sortingkind WHERE 
	idsorkind = @idsorkind
	
	IF ISNULL(@kind, 'CLASSIFICATI') = 'NONCLASSIFICATI'
	BEGIN
		SELECT 
		@codesorkind as '# Tipo Class.',
		@sortingkind as 'Tipo Class.',
		upb.idupb as '# UPB',
		upb.codeupb as 'Cod. UPB',
		upb.title as 'UPB',
		manager.title as 'Responsabile',
		parupb.idupb as '# UPB Padre',
		parupb.codeupb as 'Cod. UPB Padre',
		parupb.title as 'UPB Padre',
		upb.start as 'Data inizio',
		upb.stop as 'Data Fine', 
		upb.expiration as 'Data Scadenza'
		from upb 
		LEFT OUTER JOIN manager
		ON upb.idman = manager.idman
		LEFT OUTER JOIN upb parupb
		ON upb.paridupb = parupb.idupb
		WHERE NOT EXISTS (SELECT * FROM upbsorting 
							JOIN sorting  
							  ON upbsorting.idsor =  sorting.idsor 
						   WHERE upbsorting.idupb = upb.idupb 
							 AND sorting.idsorkind = @idsorkind)
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		ORDER BY upb.idupb
		RETURN
END
IF ISNULL(@kind, 'CLASSIFICATI') = 'CLASSIFICATI'
	BEGIN
		SELECT 
		@codesorkind as '# Tipo Class.',
		@sortingkind as 'Tipo Class.',
		sorting.sortcode as 'Cod. voce class.', 
		sorting.description as 'Voce class.',
		ROUND (upbsorting.quota * 100, 2) as '%',
		upb.idupb as '# UPB',
		upb.codeupb as 'Cod. UPB',
		upb.title as 'UPB',
		manager.title as 'Responsabile',
		parupb.idupb as '# UPB Padre',
		parupb.codeupb as 'Cod. UPB Padre',
		parupb.title as 'UPB Padre',
		upb.start as 'Data inizio',
		upb.stop as 'Data Fine', 
		upb.expiration as 'Data Scadenza'
		from upb 
		LEFT OUTER JOIN manager
			ON upb.idman = manager.idman
		LEFT OUTER JOIN upb parupb
			ON upb.paridupb = parupb.idupb
		join upbsorting  
			ON upbsorting.idupb = upb.idupb 
		JOIN sorting  
			ON upbsorting.idsor =  sorting.idsor 
		WHERE sorting.idsorkind = @idsorkind 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		ORDER BY upb.idupb
		RETURN
END

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

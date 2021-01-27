
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_class_child]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_class_child]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE [exp_class_child]
(
	@ayear int,
	@sourcelevel smallint,
	@destlevel smallint,
	@idsorkind int
)

AS BEGIN

select S.sortcode,
 SUM(
	case when (ES.ayear=@ayear) AND (ET_PARENT.flag & 1=0)  then ES.amount else 0 end
 ) as pagato_competenza_annocorr,
 SUM(
	case when (ES.ayear=@ayear) AND (ET_PARENT.flag & 1<>0)   then ES.amount else 0 end
 ) as pagato_residui_annocorr,
 SUM(
	case when (ES.ayear>@ayear) AND (ET_PARENT.flag & 1=0)  then ES.amount else 0 end
 ) as pagato_competenza_annisucc,
 SUM(
	case when (ES.ayear>@ayear) AND (ET_PARENT.flag & 1<>0)   then ES.amount else 0 end
 ) as pagato_residui_annisucc

 from sorting S
 left outer join expensesorted ES on ES.idsor=S.idsor
 join expense E on ES.idexp=E.idexp AND  E.nphase= @destlevel 
 join expenselink EL on 
        EL.idchild=E.idexp  AND EL.nlevel= @sourcelevel 
 join expensetotal ET_PARENT on 			--filtra l'impegno
        ET_PARENT.idexp=EL.idparent  AND ET_PARENT.ayear=@ayear    --sempre filtrato cosi
 join expenseyear EY_CHILD on  --filtra il pagamento
        EY_CHILD.idexp=E.idexp  AND EY_CHILD.ayear=ES.ayear
 
where S.idsorkind=@idsorkind
group by S.sortcode
order by S.sortcode
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


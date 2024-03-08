
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


-- Questa rebuild va eseguita se si � certi che incomeyear e incomevar contengano valori corretti,
-- perch� valorizza incometotal sulla base dei loro valori.
-- Quindi se vi fossero righe non referenziate, o situazioni anomale, si dovranno prima correggere e poi
-- procedere alla rebuild.
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_incometotal_idmov]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_incometotal_idmov]
GO

CREATE                          PROCEDURE [rebuild_incometotal_idmov]
(@ayear int = null,
@idmov int
)
AS BEGIN
DELETE from incometotal where ( (@ayear is null) or (ayear=@ayear))and idinc = @idmov 

declare @minfinyear int
select @minfinyear=min(ayear) from fin

DECLARE @finphase tinyint
SELECT @finphase = incomefinphase FROM uniconfig

INSERT INTO incometotal 
(
	idinc,
	ayear,
	curramount,
	flag
)
SELECT
	incomeyear.idinc,
	incomeyear.ayear,
	incomeyear.amount,
	CASE
		WHEN income.nphase < @finphase
		THEN 0
		WHEN (SELECT e2.ymov
			FROM incomelink
			JOIN income e2
				ON incomelink.idparent = e2.idinc
			WHERE incomelink.idchild = income.idinc
			AND incomelink.nlevel = @finphase) = incomeyear.ayear THEN 0
		ELSE 1
	END +
	CASE
		WHEN income.ymov = incomeyear.ayear or incomeyear.ayear=@minfinyear THEN 2
		ELSE 0
	END 
FROM incomeyear
JOIN income
	ON incomeyear.idinc = income.idinc
WHERE  ( (@ayear is null) or (ayear=@ayear)) and income.idinc = @idmov ;

with sumvar(idinc,yvar,amount) as 
		(select idinc,yvar,sum(amount) from incomevar
		where (@ayear is null) OR incomevar.yvar=@ayear					
		 group by idinc,yvar)
		update incometotal set curramount = isnull(curramount,0) + sumvar.amount
		from incometotal
		join sumvar on incometotal.idinc=sumvar.idinc 
					and incometotal.ayear=sumvar.yvar
		where ((@ayear is null) OR incometotal.ayear=@ayear) and incometotal.idinc = @idmov 					
					
;
with suminctot(idinc,ayear,amount) as
		(select E.parentidinc, ET.ayear, SUM(ET.curramount) from 
				incometotal ET
				join income e on e.idinc=ET.idinc
				WHERE ( (@ayear is null) OR ET.ayear=@ayear)and e.parentidinc = @idmov 
				group by E.parentidinc, ET.ayear
		)
		UPDATE incometotal
		SET available = ISNULL(ET.curramount, 0) - isnull(SE.amount,0)
		from incometotal ET
		left outer join suminctot SE on ET.idinc=SE.idinc and ET.ayear=SE.ayear 
		WHERE ( (@ayear is null) OR ET.ayear=@ayear) and ET.idinc = @idmov 
;



with sumcredit(idinc,ayear,amount) as
		(select E.idinc, ET.ycreditpart, SUM(ET.amount) from 
				creditpart ET
				join income e on e.idinc=ET.idinc 
				WHERE  ((@ayear is null) OR ET.ycreditpart=@ayear)and e.idinc = @idmov 
				group by E.idinc, ET.ycreditpart
		)
		UPDATE incometotal
		SET partitioned = isnull(SE.amount,0)
		from incometotal ET
		join income E on ET.idinc=E.idinc 
		left outer join sumcredit SE on ET.idinc=SE.idinc and ET.ayear=SE.ayear 
		WHERE E.nphase=1 and (@ayear is null or ET.ayear=@ayear) and E.idinc = @idmov 
;

DECLARE @maxphase int
SET @maxphase =
ISNULL(
	(SELECT CONVERT(int,MAX(nphase)) FROM incomephase)
,0)

;
with sumproceeds(idinc,ayear,amount) as
		(select E.idinc, ET.yproceedspart, SUM(ET.amount) from 
				proceedspart ET
				join income e on e.idinc=ET.idinc 
				WHERE  ((@ayear is null) OR ET.yproceedspart=@ayear) and e.idinc = @idmov 
				group by E.idinc, ET.yproceedspart
		)
		UPDATE incometotal
		SET partitioned = isnull(SE.amount,0)
		from incometotal ET
		join income E on ET.idinc=E.idinc 
		left outer join sumproceeds SE on ET.idinc=SE.idinc and ET.ayear=SE.ayear 
		where E.nphase=@maxphase  and (@ayear is null or ET.ayear=@ayear) and e.idinc = @idmov 
;



END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



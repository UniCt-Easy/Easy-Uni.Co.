
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budget_prev_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budget_prev_var]
GO

CREATE PROCEDURE [rpt_budget_prev_var]
(
	@ayear int,
	@date datetime,
	@idsorkind int,
	@idupb varchar(36),
	@showchildupb char(1),
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS BEGIN
-- exec rpt_budget_prev_var 2021, {d '2021-11-09'}, 22, '00010060005400010002', 'S', null,null,null,null,null
-- exec rpt_budget_prev_var 2021, {d '2021-11-09'}, 22, null, 'N', null,null,null,null,null
-- setuser 'amministrazione'

IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb = @idupb + '%' 
END

CREATE TABLE #budgetvardetailiniziale
(
	yvar int,
	nvar int,
	rownum int,
	idupb varchar(36),
	idfin int,
	amount decimal (19,2),
	idsor int,
	description varchar(150)
)

CREATE TABLE #budgetvardetailnoiniziale
(
	yvar int,
	nvar int,
	rownum int,
	idupb varchar(36),
	idfin int,
	amount decimal (19,2),
	idsor int,
	description varchar(150)
)

INSERT INTO #budgetvardetailiniziale(yvar, nvar, rownum, idupb, idfin, amount, idsor, description)
SELECT 
	fd.yvar,
	fd.nvar,
	DENSE_RANK() OVER(PARTITION BY fd.nvar order by fd.rownum,fd.idupb, fd.idfin,s.idsor),
	u.idupb,	
	f.idfin,	
	isnull(fd.amount * fs.quota, 0),	
	s.idsor,	
	fd.description
FROM finvardetail fd
JOIN finvar fv			ON fv.yvar = fd.yvar AND fv.nvar = fd.nvar
JOIN fin f		        ON f.idfin = fd.idfin 
JOIN finlast fl			ON f.idfin = fl.idfin
JOIN upb u				ON u.idupb = fd.idupb
JOIN finsorting fs		ON f.idfin = fs.idfin
JOIN sorting s			ON s.idsor = fs.idsor
WHERE f.ayear = @ayear
  AND s.idsorkind = @idsorkind  
  AND ISNULL(fv.flagprevision,'N') = 'S'
  AND fv.variationkind = 5 -- > solo di Tipo Iniziale
  AND fv.yvar = @ayear
  AND (u.idupb like @idupb or @idupb is null)  
  AND (s.idsor01 = @idsor01 or @idsor01 is null)
  AND (s.idsor02 = @idsor02 or @idsor02 is null)
  AND (s.idsor03 = @idsor03 or @idsor03 is null)
  AND (s.idsor04 = @idsor04 or @idsor04 is null)
  AND (s.idsor05 = @idsor05 or @idsor05 is null)
  AND (fv.adate <= @date or @date is null)

INSERT INTO #budgetvardetailnoiniziale(yvar, nvar, rownum, idupb, idfin, amount, idsor,	description)
SELECT 
	fd.yvar,	
	fd.nvar,	
	DENSE_RANK() OVER(PARTITION BY fd.nvar order by fd.rownum,fd.idupb, fd.idfin,s.idsor),
	u.idupb,	
	f.idfin,	
	isnull(fd.amount * fs.quota, 0),	
	s.idsor,	
	fd.description
FROM finvardetail fd
JOIN finvar fv			ON fv.yvar = fd.yvar AND fv.nvar = fd.nvar
JOIN fin f		        ON f.idfin = fd.idfin 
JOIN finlast fl			ON f.idfin = fl.idfin
JOIN upb u				ON u.idupb = fd.idupb
JOIN finsorting fs		ON f.idfin = fs.idfin
JOIN sorting s			ON s.idsor = fs.idsor
WHERE f.ayear = @ayear
  AND s.idsorkind = @idsorkind  
  AND ISNULL(fv.flagprevision,'N') = 'S'
  AND fv.variationkind <> 5 -- > Esclude quelle di Tipo Iniziale
  AND fv.yvar = @ayear
  AND (u.idupb like @idupb or @idupb is null)  
  AND (s.idsor01 = @idsor01 or @idsor01 is null)
  AND (s.idsor02 = @idsor02 or @idsor02 is null)
  AND (s.idsor03 = @idsor03 or @idsor03 is null)
  AND (s.idsor04 = @idsor04 or @idsor04 is null)
  AND (s.idsor05 = @idsor05 or @idsor05 is null)
  AND (fv.adate <= @date or @date is null)

select * from #budgetvardetailiniziale
select * from #budgetvardetailnoiniziale

select b.yvar, b.idupb, sum(b.amount) as am into #tempA from #budgetvardetailiniziale b
group by b.yvar, b.idupb

select b.yvar, b.idupb, sum(b.amount) as am into #tempB from #budgetvardetailnoiniziale b
group by b.yvar, b.idupb

--select * from #tempA
--select * from #tempB

select a.yvar, a.idupb, a.am as prevamount, b.am as varamount, (a.am + b.am) as amount into #out from #tempA a
join #tempB b on a.yvar = b.yvar and a.idupb = b.idupb

select * from #out
END
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

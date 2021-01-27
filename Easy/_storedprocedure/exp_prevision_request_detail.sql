
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prevision_request_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prevision_request_detail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [exp_prevision_request_detail]
(
	@ayear int,--> anno del bilancio di previsione
	@date datetime,
	@finpart char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@filtervarstatus char(1), -- I --> inserite e approvate, T --> Inserite richieste e approvate, A -->Approvate
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)

AS BEGIN
/*
  exp_prevision_request_detail 2012,'31-12-2011','E','%','N','N',null,null, null, null,null
*/
DECLARE @idsortingkind01 varchar(20)
DECLARE @idsortingkind02 varchar(20)
DECLARE @idsortingkind03 varchar(20)
DECLARE @idsortingkind04 varchar(20)
DECLARE @idsortingkind05 varchar(20)

SELECT
	@idsortingkind01 = idsorkind01,
	@idsortingkind02 = idsorkind02,
	@idsortingkind03 = idsorkind03,
	@idsortingkind04 = idsorkind04,
	@idsortingkind05 = idsorkind05
FROM uniconfig 


DECLARE @sortingkind01 varchar(50)
SELECT @sortingkind01 = description FROM sortingkind WHERE idsorkind = @idsortingkind01

DECLARE @sortingkind02 varchar(50)
SELECT @sortingkind02 = description FROM sortingkind WHERE idsorkind = @idsortingkind02

DECLARE @sortingkind03 varchar(50)
SELECT @sortingkind03 = description FROM sortingkind WHERE idsorkind = @idsortingkind03

DECLARE @sortingkind04 varchar(50)
SELECT @sortingkind04 = description FROM sortingkind WHERE idsorkind = @idsortingkind04

DECLARE @sortingkind05 varchar(50)
SELECT @sortingkind05 = description FROM sortingkind WHERE idsorkind = @idsortingkind05


IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

DECLARE @expensephase varchar(50)
SELECT @expensephase = description FROM expensephase where nphase =(select min(nphase) from expensephase)

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

SELECT 
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END as 'E/S',
	finvardetail.yvar as 'Eserc.',
	finvardetail.nvar as 'Num.',
	finvardetail.rownum as 'Num.Riga',
	upb.codeupb	as 'Cod.UPB',		
	upb.title as 'UPB',	
	fin.nlevel as 'Liv.Bilancio',
	fin.codefin as 'Cod.Bilancio',
	fin.title 'Bilancio',
	ISNULL(finvardetail.amount,0) as 'Previsione richiesta',
	underwriting.title as 'Finanziamento',
	finvar.description as 'Desc.Variazione',
	finvardetail.description as 'Desc. Dettaglio',
	finvarstatus.description as 'Stato',
	case 
		when isnull(finvardetail.createexpense,'N') ='S'
		then 'Richiedi '+ convert(varchar(50),@expensephase)
		else ''
	End	as 'Richiedi Mov.',
	case 
		when expense.nmov is not null then 'N. '+ convert(varchar(50),@expensephase)+ ' '+convert(varchar(10),expense.nmov)
		else ''
	End	as 'N.Mov.',
	case when (S01.sortcode is not null) then @sortingkind01 else''	end	as 'A1',
	S01.sortcode as  'Codice', 
	S01.description as 'Descrizione',
	case when (S02.sortcode is not null) then @sortingkind02 else''	end	as 'A2',
	S02.sortcode as 'Codice',
	S02.description as 'Descrizione',
	case when (S03.sortcode is not null) then @sortingkind03 else''	end	as 'A3',
	S03.sortcode as 'Codice',
	S03.description as 'Descrizione',
	case when (S04.sortcode is not null) then @sortingkind04 else''	end	as 'A4',
	S04.sortcode as 'Codice',
	S04.description as 'Descrizione',
	case when (S05.sortcode is not null) then @sortingkind05 else''	end	as 'A5',
	S05.sortcode as 'Codice',
	S05.description as 'Descrizione'
FROM finvardetail 
JOIN finvar 
	ON finvardetail.yvar = finvar.yvar
	AND finvardetail.nvar = finvar.nvar
JOIN fin 
	ON finvardetail.idfin = fin.idfin
JOIN upb 
	ON finvardetail.idupb=upb.idupb 	
JOIN finvarstatus
	ON finvarstatus.idfinvarstatus = finvar.idfinvarstatus
LEFT OUTER JOIN underwriting 
	ON finvardetail.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN sorting S01
	on finvar.idsor01 = S01.idsor and S01.idsorkind = @idsortingkind01 
LEFT OUTER JOIN sorting S02
	on finvar.idsor02 = S02.idsor and S02.idsorkind = @idsortingkind02 
LEFT OUTER JOIN sorting S03
 	on finvar.idsor03 = S03.idsor and S03.idsorkind = @idsortingkind03 
LEFT OUTER JOIN sorting S04
 	on finvar.idsor04 = S04.idsor and S04.idsorkind = @idsortingkind04 
LEFT OUTER JOIN sorting S05
 	on finvar.idsor05 = S05.idsor and S05.idsorkind = @idsortingkind05 
LEFT OUTER JOIN expense  
	ON finvardetail.idexp=  expense.idexp
WHERE finvar.yvar = @ayear
	AND finvar.adate <= @date
	AND finvar.flagprevision = 'S'
	AND (
	(ISNULL(@filtervarstatus,'A') = 'A' AND finvar.idfinvarstatus = 5)
	OR
	(ISNULL(@filtervarstatus,'A') = 'I' AND finvar.idfinvarstatus in(4,5))
	OR
	(ISNULL(@filtervarstatus,'A') = 'T' AND finvar.idfinvarstatus in(2,4,5))
	)
	AND finvar.variationkind = 5
	AND ((fin.flag & 1 ) = @finpart_bit) 
	AND fin.ayear = @ayear
	AND (finvardetail.idupb LIKE @idupb)
	AND (@idsor01 is null or ISNULL(finvar.idsor01,0) = @idsor01)
	AND (@idsor02 is null or ISNULL(finvar.idsor02,0) = @idsor02)
	AND (@idsor03 is null or ISNULL(finvar.idsor03,0) = @idsor03)
	AND (@idsor04 is null or ISNULL(finvar.idsor04,0) = @idsor04)
	AND (@idsor05 is null or ISNULL(finvar.idsor05,0) = @idsor05)
ORDER BY finvardetail.yvar, finvardetail.nvar, finvardetail.rownum, upb.codeupb, fin.codefin

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

	

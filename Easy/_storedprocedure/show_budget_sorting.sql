
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_budget_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_budget_sorting]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [show_budget_sorting]
(
	@date datetime,
	@idupb varchar(36),
	@idsor int 
)
AS
BEGIN
 -- EXEC [show_budget_sorting]  {ts '2013-06-20 00:00:00'},'0001',1568
DECLARE	@ayear int
SELECT @ayear = YEAR(@date)

DECLARE @idsorkind int
SELECT  @idsorkind = idsorkind FROM sorting WHERE idsor = @idsor 
 

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

DECLARE @descupb varchar(150)
DECLARE @codeupb varchar(50)
SELECT @descupb = title,
	@codeupb = codeupb
FROM upb
WHERE idupb = @idupb


DECLARE @sortingkind varchar(150)
DECLARE @codesorkind varchar(50)
SELECT  @sortingkind = description,
	    @codesorkind = codesorkind
FROM sortingkind
WHERE idsorkind = @idsorkind

DECLARE @levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT  @levelusable = MIN(nlevel) FROM sortinglevel WHERE (flag & 2)<>0 AND idsorkind = @idsorkind 
 

DECLARE	@nlevel tinyint -- Livello della voce di bilancio
DECLARE	@sortcode varchar(50) -- Codice di classificazione
DECLARE	@description varchar(150) -- Descrizione della voce di classificazione

SELECT @nlevel = nlevel, 
	   @sortcode = sortcode, 
	   @description = description 
FROM sorting WHERE idsor = @idsor

DECLARE	@prevision decimal(19,2)

IF (@nlevel < @levelusable) OR (@nlevel IS NULL)
BEGIN
-- ho scelto la categoria (x es)
	SELECT @prevision = ISNULL(SUM(prevision),0) 
	FROM budgetprevisionview 
	JOIN sortinglink
		ON sortinglink.idchild = budgetprevisionview.idsor
	join sorting
		ON budgetprevisionview.idsor = sorting.idsor
	WHERE budgetprevisionview.nlevel  = @levelusable
	and budgetprevisionview.ayear = @ayear
	AND idupb = @idupb
	AND (
		(sortinglink.idparent = @idsor AND sortinglink.nlevel = @nlevel) 
		OR 
		( @nlevel is null AND sortinglink.nlevel = @levelusable)
	    )
--	AND nlevel = @levelusable
END
ELSE
BEGIN
-- ho scelto la voce operativa
	SELECT @prevision= SUM(prevision) 
	FROM budgetprevision
	WHERE idsor = @idsor
	AND idupb = @idupb
	AND budgetprevision.ayear = @ayear
END

DECLARE	@var_prev_aum decimal(19,2)
SELECT  @var_prev_aum = SUM(BVD.amount)
FROM budgetvardetail BVD
JOIN budgetvar BV
	ON BV.ybudgetvar = BVD.ybudgetvar
	AND BV.nbudgetvar = BVD.nbudgetvar
JOIN sortinglink SLK
	ON SLK.idchild = BVD.idsor
join sorting S
	ON BVD.idsor = S.idsor
WHERE 
	(	(SLK.nlevel = @nlevel AND SLK.idparent = @idsor) OR (@idsor is null AND SLK.nlevel = @levelusable)   )
	AND BV.adate <= @date
	AND BVD.idupb = @idupb
	AND BVD.amount > 0

DECLARE	@var_prev_dim decimal(19,2)
SELECT @var_prev_dim = SUM(BVD.amount)
FROM budgetvardetail BVD
JOIN budgetvar BV
	ON BV.ybudgetvar = BVD.ybudgetvar
	AND BV.nbudgetvar = BVD.nbudgetvar
JOIN sortinglink SLK
	ON SLK.idchild = BVD.idsor
join sorting S
	ON BVD.idsor = S.idsor
WHERE 
	(	(SLK.nlevel = @nlevel AND SLK.idparent = @idsor) OR (@idsor is null AND SLK.nlevel = @levelusable)   )
	AND BV.adate <= @date
	AND BVD.idupb = @idupb
	AND BVD.amount < 0
	
-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_prev decimal(19,2)
SET @var_prev  = ISNULL(@var_prev_aum,0) + ISNULL(@var_prev_dim,0)
-- Calcolo della previsione principale attuale
DECLARE @prev_curr decimal(19,2)
SET @prev_curr = ISNULL(@prevision,0) + ISNULL(@var_prev,0)


DECLARE	@departmentname varchar(150)

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
DECLARE	@desc_level varchar(50)
SELECT @desc_level = description 
FROM  sortinglevel 
WHERE idsorkind = @idsorkind
	AND nlevel = @nlevel

INSERT INTO #situation VALUES ('U.P.B. ' + @codeupb + ' - ' + @descupb, NULL, 'H')
INSERT INTO #situation VALUES ('Classificazione '  + @sortingkind, NULL, 'H')
INSERT INTO #situation VALUES ('Livello ' + @desc_level + ' ' + @sortcode, NULL, 'H')
INSERT INTO #situation VALUES (@description,	NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES('B U D G E T',NULL,'N')
INSERT INTO #situation VALUES ('Budget iniziale', @prevision, '')
INSERT INTO #situation VALUES ('Variazioni di Budget', @var_prev, '')
INSERT INTO #situation	
	VALUES ('Budget attuale', ISNULL(@prev_curr,0), 'S')
SELECT value, amount, kind FROM #situation	
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


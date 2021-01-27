
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avanzo_ammin_cassa_effettivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avanzo_ammin_cassa_effettivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE          PROCEDURE [rpt_avanzo_ammin_cassa_effettivo]
  @ayear int,
  @kind varchar(1)
AS
BEGIN


-- Fondo Cassa all'1/1
DECLARE @floatfund_01_jan_used decimal(19,2) 
SELECT @floatfund_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='ff_jan01'

DECLARE @aa_01_jan_used decimal(19,2) 
SELECT @aa_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='aa_jan01'

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
DECLARE @floatfund_01_jan decimal(19,2) 
IF (SELECT COUNT(*) FROM surplus WHERE ayear= @ayear) >0
	Begin
		SELECT @floatfund_01_jan = 
			ISNULL(startfloatfund, 0) 
		FROM surplus 
		WHERE ayear = @ayear 
	end
ELSE
	SET @floatfund_01_jan = 0

-- Incassi conto competenza XXX
DECLARE @competencyproceeds decimal(19,2) 
SELECT @competencyproceeds = ISNULL(competencyproceeds,0) FROM surplus WHERE ayear = @ayear

-- Pagamenti conto competenza XXX
DECLARE @competencypayments decimal(19,2)
SELECT @competencypayments = ISNULL(competencypayments,0) FROM surplus WHERE ayear = @ayear

-- Incassi conto residui
DECLARE @residualproceeds decimal(19,2)
SELECT @residualproceeds = ISNULL(residualproceeds,0) FROM surplus where ayear = @ayear

-- Pagamenti conto residui
DECLARE @residualpayments decimal(19,2)
SELECT @residualpayments = ISNULL(residualpayments,0) FROM surplus where ayear = @ayear

-- Fondo Cassa alla data
DECLARE @floatfund_stilldate decimal(19,2) 
SELECT @floatfund_stilldate = @floatfund_01_jan + @competencyproceeds + @residualproceeds - @competencypayments - @residualpayments

-- Resuidui Attivi Precedenti XXX
DECLARE @previousrevenue decimal(19,2) 
SELECT @previousrevenue = ISNULL(previousrevenue,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Attivi Correnti XXX
DECLARE @currentrevenue decimal(19,2)
SELECT @currentrevenue = ISNULL(currentrevenue,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Passivi Precedenti XXX
DECLARE @previousexpenditure decimal(19,2)
SELECT @previousexpenditure = ISNULL(previousexpenditure,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Passivi Correnti Presunti XXX
DECLARE @currentexpenditure decimal(19,2)
SELECT @currentexpenditure = ISNULL(currentexpenditure,0) FROM surplus WHERE ayear = @ayear

-- Avanzo di Amministrazione effettivo al 31 Dicembre
DECLARE @creditsurplus_31_dec decimal(19,2)
SELECT @creditsurplus_31_dec = 
	@floatfund_stilldate +
	@previousrevenue + 
	@currentrevenue -
	@previousexpenditure -
	@currentexpenditure

DECLARE @cashvaliditykind char(1) 
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

-- Data di redazione della situazione
DECLARE @refer_date datetime 
SET @refer_date =  CONVERT(datetime,'31-12-' + CONVERT(varchar(4), @ayear),105)

SELECT 
	@refer_date AS earlydate,
	ISNULL(@floatfund_01_jan,0) AS floatfund_01_jan,
	ISNULL(@floatfund_01_jan_used,0) AS floatfund_01_jan_used,
	ISNULL(@aa_01_jan_used,0) AS aa_01_jan_used,
	ISNULL(@competencyproceeds,0) AS competencyproceeds,
	ISNULL(@competencypayments,0) AS competencypayments,
	ISNULL(@floatfund_stilldate,0) AS floatfund_stilldate,	
	ISNULL(@residualproceeds,0) AS residualproceeds,
	ISNULL(@residualpayments,0) AS residualpayments,
	ISNULL(@previousrevenue,0) AS previousrevenue,
	ISNULL(@currentrevenue,0) AS currentrevenue,
	ISNULL(@previousexpenditure,0)as previousexpenditure,
	ISNULL(@currentexpenditure,0) AS currentexpenditure,
	ISNULL(@creditsurplus_31_dec,0) AS creditsurplus_31_dec,
	@cashvaliditykind AS cashvaliditykind,
	@kind AS kind
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--exec rpt_avanzo_ammin_cassa_effettivo 2007, 'C'

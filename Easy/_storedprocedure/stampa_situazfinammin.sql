
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


if exists (select * from dbo.sysobjects where id = object_id(N'[stampa_situazfinammin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [stampa_situazfinammin]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE         PROCEDURE [stampa_situazfinammin]
  @ayear int,
  @tiposituazione varchar(1)
AS
BEGIN
-- Flag validita  Documenti
DECLARE @cashvaliditykind char(1) 
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
-- Data di redazione della situazione finanziaria/amministrativa
DECLARE @dataeffettivo datetime 
SELECT @dataeffettivo = (select convert(datetime,'31-12-'+convert(varchar(4), @ayear,105)))

-- Fondo Cassa all'1/1
-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
DECLARE @floatfund_01_gen decimal(19,2) 
SELECT @floatfund_01_gen = ISNULL(startfloatfund, 0) 
FROM surplus 
WHERE ayear = @ayear

-- Incassi conto competenza    XXX
DECLARE @competencyproceeds decimal(19,2) 
SELECT @competencyproceeds = ISNULL(competencyproceeds,0) FROM surplus WHERE ayear = @ayear
-- Pagamenti conto competenza   XXX
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
SELECT @floatfund_stilldate = @floatfund_01_gen + @competencyproceeds + @residualproceeds - @competencypayments - @residualpayments


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
DECLARE @creditsurplus_31_dic decimal(19,2)
SELECT @creditsurplus_31_dic = 
	@floatfund_stilldate +
	@previousrevenue + 
	@currentrevenue -
	@previousexpenditure -
	@currentexpenditure

SELECT 
	@dataeffettivo as datapresunto,
	ISNULL(@floatfund_01_gen,0) as fondocassa0101,
	ISNULL(@competencyproceeds,0) as incassicompetenza,
	ISNULL(@competencypayments,0) as pagamenticompetenza,
	ISNULL(@floatfund_stilldate,0) as fondocassa3112,	
	ISNULL(@residualproceeds,0) as incassiresidui,
	ISNULL(@residualpayments,0) as pagamentiresidui,
	ISNULL(@previousrevenue,0) as resattiviprec,
	ISNULL(@currentrevenue,0) as resattivicorr,
	ISNULL(@previousexpenditure,0)as respassiviprec,
	ISNULL(@currentexpenditure,0) as respassivicorr,
	ISNULL(@creditsurplus_31_dic,0) as avanzoamminpres3112,
	@cashvaliditykind as flagvaliditadoc,
	@tiposituazione as tiposituazione
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


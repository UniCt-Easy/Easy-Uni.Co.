
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avanzo_ammin_cassa_presunto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avanzo_ammin_cassa_presunto]
GO

CREATE         PROCEDURE [rpt_avanzo_ammin_cassa_presunto]
  @ayear int
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

DECLARE @supposed_ff_01_jan_used decimal(19,2) 
SELECT @supposed_ff_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='supposed_ff_jan01'

DECLARE @supposed_aa_01_jan_used decimal(19,2) 
SELECT @supposed_aa_01_jan_used = isnull((CONVERT(decimal(19,2), paramvalue)),0) 
FROM generalreportparameter 
WHERE idparam='supposed_aa_jan01'

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
DECLARE @floatfund_01_jan decimal(19,2) 
IF (SELECT COUNT(*) FROM surplus WHERE ayear= @ayear) >0
	Begin
		SELECT @floatfund_01_jan = ISNULL(startfloatfund, 0)  
		FROM surplus 
		WHERE ayear = @ayear 

	end
ELSE
	SET @floatfund_01_jan = 0


-- Incassi alla data
DECLARE @proceeds_01_jan decimal(19,2) 
SELECT @proceeds_01_jan = ISNULL(proceedstilldate,0) FROM surplus WHERE ayear = @ayear

-- Pagamenti certi alla data
DECLARE @payments_01_jan decimal(19,2)
SELECT @payments_01_jan = ISNULL(paymentstilldate,0) FROM surplus WHERE ayear = @ayear

-- Fondo Cassa alla data
DECLARE @floatfund_stilldate decimal(19,2) 
SELECT @floatfund_stilldate = @floatfund_01_jan + @proceeds_01_jan - @payments_01_jan

-- Incassi Presunti al 31 Dicembre
DECLARE @proceeds_31_dec decimal(19,2) 
SELECT @proceeds_31_dec = ISNULL(proceedstoendofyear,0) FROM surplus WHERE ayear = @ayear

-- Pagamenti Presunti al 31 Dicembre
DECLARE @payments_31_dec decimal(19,2) 
SELECT @payments_31_dec = ISNULL(paymentstoendofyear,0) FROM surplus WHERE ayear = @ayear

-- Fondo Cassa Presunto al 31 Dicembre
DECLARE @floatfund_supposed_31_dec decimal(19,2) 
SELECT @floatfund_supposed_31_dec = @floatfund_stilldate + @proceeds_31_dec - @payments_31_dec

-- Resuidui Attivi Precedenti Presunti
DECLARE @supposed_previousrevenue decimal(19,2) 
SELECT @supposed_previousrevenue = ISNULL(supposedpreviousrevenue,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Attivi Correnti Presunti
DECLARE @supposed_currentrevenue decimal(19,2)
SELECT @supposed_currentrevenue = ISNULL(supposedcurrentrevenue,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Passivi Precedenti Presunti
DECLARE @supposed_previousexpenditure decimal(19,2)
SELECT @supposed_previousexpenditure = ISNULL(supposedpreviousexpenditure,0) FROM surplus WHERE ayear = @ayear

-- Resuidui Passivi Correnti Presunti
DECLARE @supposed_currentexpenditure decimal(19,2)
SELECT @supposed_currentexpenditure = ISNULL(supposedcurrentexpenditure,0) FROM surplus WHERE ayear = @ayear

-- Avanzo di Amministrazione presunto al 31 Dicembre
DECLARE @supposed_creditsurplus_31_dec decimal(19,2)
SELECT @supposed_creditsurplus_31_dec = 
	@floatfund_supposed_31_dec +
	@supposed_previousrevenue + 
	@supposed_currentrevenue -
	@supposed_previousexpenditure -
	@supposed_currentexpenditure

DECLARE @cashvaliditykind tinyint
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

-- Data di redazione della situazione
DECLARE @refer_date datetime 
SELECT @refer_date = previsiondate FROM surplus WHERE ayear = @ayear

SELECT 
	@refer_date AS earlydate,
	ISNULL(@floatfund_01_jan,0) AS floatfund_01_jan,
	ISNULL(@floatfund_01_jan_used,0) AS floatfund_01_jan_used,
	ISNULL(@aa_01_jan_used,0) AS aa_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,		
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	ISNULL(@proceeds_01_jan,0) AS proceeds_01_jan,
	ISNULL(@payments_01_jan,0) AS payments_01_jan,
	ISNULL(@floatfund_stilldate,0) AS floatfund_stilldate,				
	ISNULL(@proceeds_31_dec,0) AS proceeds_31_dec,
	ISNULL(@payments_31_dec,0) AS payments_31_dec,
	ISNULL(@floatfund_supposed_31_dec,0) AS floatfund_supposed_31_dec,
	ISNULL(@supposed_previousrevenue,0) AS supposed_previousrevenue,
	ISNULL(@supposed_currentrevenue,0) AS supposed_currentrevenue,
	ISNULL(@supposed_previousexpenditure,0)as supposed_previousexpenditure,
	ISNULL(@supposed_currentexpenditure,0) AS supposed_currentexpenditure,
	ISNULL(@supposed_creditsurplus_31_dec,0) AS supposed_creditsurplus_31_dec,
	@cashvaliditykind AS cashvaliditykind
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

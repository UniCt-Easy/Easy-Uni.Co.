
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consolidamento_bari_residui_3112]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consolidamento_bari_residui_3112]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE exp_consolidamento_bari_residui_3112
(
	@ayear int,
	@finpart char(1),
	@levelusable tinyint
)
AS 
BEGIN
/* Versione 1.0.0 del 12/09/2007 ultima modifica: PIERO */
-- exec  exp_consolidamento_bari_residui_0101 2006,'S',3 
CREATE TABLE #residual_3112(
	printingorder varchar(50),
	code varchar(50),
	fintitle varchar(150),
	mov_finphase_C_univ decimal(19,2),
	mov_finphase_C_direct decimal(19,2),
	mov_finphase_C_internal decimal(19,2),
	var_finphase_C_univ decimal(19,2),
	var_finphase_C_direct decimal(19,2),
	var_finphase_C_internal decimal(19,2),
	mov_maxphase_C_univ decimal(19,2),
	mov_maxphase_C_direct decimal(19,2),
	mov_maxphase_C_internal decimal(19,2),
	var_maxphase_C_univ decimal(19,2),
	var_maxphase_C_direct decimal(19,2),
	var_maxphase_C_internal decimal(19,2),
	mov_finphase_R_univ decimal(19,2),
	mov_finphase_R_direct decimal(19,2),
	mov_finphase_R_internal decimal(19,2),
	var_finphase_R_univ decimal(19,2),
	var_finphase_R_direct decimal(19,2),
	var_finphase_R_internal decimal(19,2),
	mov_maxphase_R_univ decimal(19,2),
	mov_maxphase_R_direct decimal(19,2),
	mov_maxphase_R_internal decimal(19,2),
	var_maxphase_R_univ decimal(19,2),
	var_maxphase_R_direct decimal(19,2),
	var_maxphase_R_internal decimal(19,2),
	supposed_ff_jan01  decimal(19,2),
	supposed_aa_jan01  decimal(19,2),
	ff_jan01 decimal(19,2),
	aa_jan01 decimal(19,2)
)
DECLARE @date datetime
SET @date= CONVERT(datetime,'31-12-'+convert(varchar(4),@ayear),105)

INSERT INTO #residual_3112(
	printingorder,
	code,
	fintitle,
	mov_finphase_C_univ , 		
	mov_finphase_C_direct ,	
	mov_finphase_C_internal ,	
	var_finphase_C_univ ,		
	var_finphase_C_direct ,	
	var_finphase_C_internal 	,	
	mov_maxphase_C_univ ,		
	mov_maxphase_C_direct,		
	mov_maxphase_C_internal ,	
	var_maxphase_C_univ ,		
	var_maxphase_C_direct ,	
	var_maxphase_C_internal ,	
	mov_finphase_R_univ ,		
	mov_finphase_R_direct ,	
	mov_finphase_R_internal ,	
	var_finphase_R_univ ,		
	var_finphase_R_direct ,	
	var_finphase_R_internal ,	
	mov_maxphase_R_univ ,		
	mov_maxphase_R_direct ,	
	mov_maxphase_R_internal ,	
	var_maxphase_R_univ ,		
	var_maxphase_R_direct ,	
	var_maxphase_R_internal ,	
	supposed_ff_jan01  ,		
	supposed_aa_jan01  ,		
	ff_jan01 , -- fondo cassa 	
	aa_jan01  -- avanzo di amministrazione	
	)
EXEC  exp_consolidamento @ayear, @date,@finpart,@levelusable

IF @finpart = 'E'
BEGIN
	SELECT
		code as 'Codice di Bilancio',
		fintitle as 'Denominazione',
		mov_finphase_C_univ + var_finphase_C_univ - (mov_maxphase_C_univ + var_maxphase_C_univ) + mov_finphase_R_univ + var_finphase_R_univ - (mov_maxphase_R_univ + var_maxphase_R_univ) 
				as 'Residui attivi da entrate di proven. Amm.ne Centrale (1)'	,
		mov_finphase_C_internal + var_finphase_C_internal -(mov_maxphase_C_internal + var_maxphase_C_internal) + mov_finphase_R_internal + var_finphase_R_internal - (mov_maxphase_R_internal + var_maxphase_R_internal)	
				as 'Residui attivi da entrate di proven. Dip. e Centri (2)',
		mov_finphase_C_direct + var_finphase_C_direct - (mov_maxphase_C_direct + var_maxphase_C_direct) + mov_finphase_R_direct + var_finphase_R_direct - (mov_maxphase_R_direct + var_maxphase_R_direct)	
				as 'Residui attivi da entrate proprie (3)',
		mov_finphase_C_univ + var_finphase_C_univ - (mov_maxphase_C_univ	+var_maxphase_C_univ)
				+ mov_finphase_R_univ + var_finphase_R_univ - (mov_maxphase_R_univ + var_maxphase_R_univ)
				+ mov_finphase_C_internal	+var_finphase_C_internal -(mov_maxphase_C_internal +var_maxphase_C_internal)
				+ mov_finphase_R_internal + var_finphase_R_internal - (mov_maxphase_R_internal + var_maxphase_R_internal)
				+ mov_finphase_C_direct + var_finphase_C_direct - (mov_maxphase_C_direct	+var_maxphase_C_direct)	
				+ mov_finphase_R_direct + var_finphase_R_direct - (mov_maxphase_R_direct + var_maxphase_R_direct) 
				as 'Totali dei residui attivi (1+2+3) (4)' 
	FROM #residual_3112
	ORDER BY printingorder ASC,code ASC
END
	
ELSE

BEGIN
	SELECT 
		code as 'Codice di Bilancio',	
		fintitle as 'Denominazione',
		mov_finphase_C_univ + var_finphase_C_univ - (mov_maxphase_C_univ + var_maxphase_C_univ)
		+ mov_finphase_R_univ + var_finphase_R_univ - (mov_maxphase_R_univ + var_maxphase_R_univ) 
			as 'Residui passivi per somme a favore Amm.ne Centrale (1)',
		
		mov_finphase_C_internal + var_finphase_C_internal -(mov_maxphase_C_internal + var_maxphase_C_internal)
		+ mov_finphase_R_internal + var_finphase_R_internal - (mov_maxphase_R_internal + var_maxphase_R_internal)	
			as 'Residui passivi per somme a favore Dip. e Centri (2)',
		
		mov_finphase_C_direct + var_finphase_C_direct - (mov_maxphase_C_direct + var_maxphase_C_direct)	
		+ mov_finphase_R_direct + var_finphase_R_direct - (mov_maxphase_R_direct + var_maxphase_R_direct)	 
			as 'Altri residui passivi (3)',
		
		mov_finphase_C_univ + var_finphase_C_univ - (mov_maxphase_C_univ + var_maxphase_C_univ)
		+ mov_finphase_R_univ + var_finphase_R_univ - (mov_maxphase_R_univ + var_maxphase_R_univ) 
	 	+ mov_finphase_C_internal + var_finphase_C_internal -(mov_maxphase_C_internal + var_maxphase_C_internal)
		+ mov_finphase_R_internal + var_finphase_R_internal - (mov_maxphase_R_internal + var_maxphase_R_internal)
		+ mov_finphase_C_direct + var_finphase_C_direct - (mov_maxphase_C_direct + var_maxphase_C_direct)	
		+ mov_finphase_R_direct + var_finphase_R_direct - (mov_maxphase_R_direct + var_maxphase_R_direct)
			as 'Totali residui passivi (1+2+3) (4)'
	FROM #residual_3112
	ORDER BY printingorder ASC,code ASC
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


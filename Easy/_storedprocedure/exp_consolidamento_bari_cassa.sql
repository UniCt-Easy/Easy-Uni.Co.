
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consolidamento_bari_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consolidamento_bari_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE exp_consolidamento_bari_cassa
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint
)
AS 
BEGIN

/* Versione 1.0.0 del 12/09/2007 ultima modifica: PIERO */

--  exec exp_consolidamento_bari_cassa 2006,{ts '2006-08-30 00:00:00'},'S',3
CREATE TABLE #cash(
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

INSERT INTO #cash(
	printingorder,
	code ,
	fintitle ,
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

CREATE TABLE #output (
	printingorder varchar(50),
	code varchar(50),
	fintitle varchar(150),
	C1 decimal(19,2),
	C2 decimal(19,2),				
	C3 decimal(19,2),
	C4 decimal(19,2),
	C5 decimal(19,2),
	C6 decimal(19,2),
	C7 decimal(19,2),
	C8 decimal(19,2),
	C9 decimal(19,2) )

DECLARE @Totale decimal(19,2)
SELECT @Totale = (SELECT 
	  mov_maxphase_C_univ + var_maxphase_C_univ 
	+ mov_maxphase_C_internal + var_maxphase_C_internal
	+ mov_maxphase_C_direct + var_maxphase_C_direct 
	+ mov_maxphase_R_univ + var_maxphase_R_univ 
	+ mov_maxphase_R_internal + var_maxphase_R_internal 
	+ mov_maxphase_R_direct + var_maxphase_R_direct	
FROM #cash WHERE printingorder = '97')

INSERT INTO #output (printingorder,code,fintitle,
	c1,c2,c3,c4,c5,c6,c7,c8,c9)
SELECT printingorder,code,fintitle,	
	mov_maxphase_C_univ + var_maxphase_C_univ,		
	mov_maxphase_R_univ + var_maxphase_R_univ	,	
	mov_maxphase_C_internal + var_maxphase_C_internal	,
	mov_maxphase_R_internal + var_maxphase_R_internal	,	
	mov_maxphase_C_direct + var_maxphase_C_direct,	
	mov_maxphase_R_direct + var_maxphase_R_direct	,
	mov_maxphase_C_univ + var_maxphase_C_univ + mov_maxphase_C_internal + var_maxphase_C_internal + mov_maxphase_C_direct + var_maxphase_C_direct,
	mov_maxphase_R_univ + var_maxphase_R_univ + mov_maxphase_R_internal + var_maxphase_R_internal + mov_maxphase_R_direct + var_maxphase_R_direct,
	mov_maxphase_C_univ + var_maxphase_C_univ + mov_maxphase_C_internal + var_maxphase_C_internal + mov_maxphase_C_direct + var_maxphase_C_direct +
	mov_maxphase_R_univ + var_maxphase_R_univ + mov_maxphase_R_internal + var_maxphase_R_internal + mov_maxphase_R_direct + var_maxphase_R_direct	
FROM #cash 

IF @finpart = 'E'
BEGIN
	DECLARE @ff_jan01 decimal(19,2)
	SET @ff_jan01 = (select top 1 ff_jan01 from #cash)

	INSERT INTO #output (printingorder,code,fintitle,c1,c2,c3, c4, c5,c6, c7 ,c8,c9)
	VALUES ('98','','FONDO CASSA AL 01/01',0,0,0,0,0,0,0,0,@ff_jan01)


	INSERT INTO #output (printingorder,code,fintitle,C1,c2,c3,c4,c5,c6, c7 ,c8,c9)
	VALUES ('99','','TOTALE GENERALE',0,0,0,0,0,0,0,0,@ff_jan01+@Totale)

	SELECT	code as 'Codice di Bilancio' 	,	
		fintitle as 'Denominazione'  ,
		c1 as 'Incassi per trasferimento Ammin.Centrale c/Competenza (1)' ,		
		c2 as 'Incassi per trasferimento Ammin.Centrale c/Residui (2)' ,	
      		c3 as 'Incassi da altri Dipartimenti e Centri c/Competenza (3)' ,
		c4 as 'Incassi da altri Dipartimenti e Centri c/Residui (4)'	,	
      		c5 as 'Incassi diretti c/Competenza (5)' ,	
		c6 as 'Incassi diretti c/Residui (6)' ,
		c7 as 'Totale Incassi c/Competenza (1+3+5) (7)' ,
	      	c8 as 'Totale Incassi c/Residui (2+4+6) (8)' ,
		c9 as 'Totale Generale di cassa (7+8) (9)'
	FROM #output 
	ORDER BY printingorder ASC,code ASC
END

ELSE

BEGIN
	DECLARE @ff_dec31 decimal(19,2)

	SELECT @ff_dec31 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds, 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments, 0)
	FROM surplus
	WHERE ayear = @ayear

	INSERT INTO #output (printingorder,code,fintitle,c1,c2,c3, c4, c5,c6, c7 ,c8,c9)
	VALUES ('98','','FONDO CASSA AL 31/12',0,0,0,0,0,0,0,0,@ff_dec31)

	INSERT INTO #output (printingorder,code,fintitle,C1,c2,c3,c4,c5,c6, c7 ,c8,c9)
	VALUES ('99','','TOTALE GENERALE',0,0,0,0,0,0,0,0,@ff_dec31+@Totale)

	SELECT 
		code as 'Codice di Bilancio',	
		fintitle as 'Denominazione',		
		c1 as 'Pagamenti per trasferimento Ammin.Centrale c/Competenza (1)',		
		c2 as 'Pagamenti per trasferimento Ammin.Centrale c/Residui (2)'  ,	
		c3 as 'Pagamenti da altri Dipartimenti e Centri c/Competenza (3)' ,
		c4 as 'Pagamenti da altri Dipartimenti e Centri c/Residui (4)'  ,	
		c5 as 'Pagamenti diretti c/Competenza (5)',	
		c6 as 'Pagamenti diretti c/Residui (6)',
		c7 as 'Totale Pagamenti c/Competenza (1+3+5) (7)',
		c8 as 'Totale Pagamenti c/Residui (2+4+6) (8)',
		c9 as 'Totale Generale di cassa (7+8) (9)'
	FROM #output
	ORDER BY printingorder ASC,code ASC
END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


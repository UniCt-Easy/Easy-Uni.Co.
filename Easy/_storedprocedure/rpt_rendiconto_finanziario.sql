
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_rendicontofinanziario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_rendicontofinanziario]
GO
SET QUOTED_IDENTIFIER ON  
GO
SET ANSI_NULLS ON 
GO
 --SETUSER 'AMMINISTRAZIONE'
CREATE PROCEDURE rpt_rendicontofinanziario
--setuser'amm'
-- exec [rpt_rendicontofinanziario] 2016, {ts '2016-01-01 00:00:00'}, {ts '2016-12-31 00:00:00'},'%','S',null,null,null
-- exec [rpt_rendicontofinanziario] 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'},'%','S',null,null,null
-- exec [rpt_rendicontofinanziario] 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'},'%','S',null,null,null

(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@idsor1 int,
	@idsor2 int,
	@idsor3 int 	
)
AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END
	

DECLARE @firstday datetime
DECLARE @lastday datetime
SET @firstday = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear),105)
SET @lastday  = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

 
-----------------------------------------------------------------------
--------------------------- RISULTATO NETTO ---------------------------
-----------------------------------------------------------------------

DECLARE @RISULTATO_NETTO decimal(19,2)
-- Risultato d'esercizio…. Usare la formula del conto economico va preso 
-- il Risultato di esercizio come calcolato nella stampa del conto economico
-- Utile o Perdita dell'esercizio corrente - 
-- Plusvalenze da alienazione immobilizzazioni + Minusvalenze da alienazione immobilizzazioni
-- VOCE SCHEMA CONTO ECONOMICO DA CUI PRENDERE I VALORI:
-- Risultato gestione da stampa conto economico alla data
-- N.B: la perdita va valorizzata in negativo

CREATE TABLE #CONTO_ECONOMICO
(
	ayear         int,
	idupb         varchar(36),
	codeupb		  varchar(50),
	upb			  varchar(150),
	PY_C_BVIII1a  decimal(19,2),
	PY_C_BVIII1b  decimal(19,2),
	PY_C_BVIII1c  decimal(19,2),
	PY_C_BVIII1d  decimal(19,2),
	PY_C_BVIII1e  decimal(19,2),
	PY_C_BVIII2   decimal(19,2),
	PY_C_BVIII    decimal(19,2),
    PY_C_BIX1	  decimal(19,2),
	PY_C_BIX2     decimal(19,2),
	PY_C_BIX3     decimal(19,2),
	PY_C_BIX4	  decimal(19,2),
	PY_C_BIX5     decimal(19,2),
	PY_C_BIX6     decimal(19,2),
	PY_C_BIX7     decimal(19,2),
	PY_C_BIX8     decimal(19,2),
	PY_C_BIX9     decimal(19,2),
	PY_C_BIX10    decimal(19,2),
	PY_C_BIX11    decimal(19,2),
	PY_C_BIX12    decimal(19,2),
	PY_C_BIX	  decimal(19,2),
	PY_C_BX1      decimal(19,2),
	PY_C_BX2      decimal(19,2),
	PY_C_BX3	  decimal(19,2),
	PY_C_BX4	  decimal(19,2),
	PY_C_BX		  decimal(19,2),
	PY_C_BXI	  decimal(19,2),
	PY_C_BXII	  decimal(19,2),
	PY_C_B		  decimal(19,2),
	PY_C_C2		  decimal(19,2),
	PY_C_C3		  decimal(19,2),
	PY_C_C		  decimal(19,2),
	PY_C_D2		  decimal(19,2),
	PY_C_D		  decimal(19,2),
	PY_C_E2		  decimal(19,2),
	PY_C_E		  decimal(19,2),
	PY_C_F		  decimal(19,2),
	PY_TOTCOSTI   decimal(19,2),
	PY_R_AI1	  decimal(19,2),
	PY_R_AI2	  decimal(19,2),
	PY_R_AI3	  decimal(19,2),
	PY_R_AI		  decimal(19,2),
	PY_R_AII1	  decimal(19,2),
	PY_R_AII2	  decimal(19,2),
	PY_R_AII3	  decimal(19,2),
	PY_R_AII4	  decimal(19,2),
	PY_R_AII5	  decimal(19,2),
	PY_R_AII6  decimal(19,2),
	PY_R_AII7  decimal(19,2),
	PY_R_AII  decimal(19,2),
	PY_R_AIII  decimal(19,2),
	PY_R_AIV  decimal(19,2),
	PY_R_AV  decimal(19,2),
	PY_R_AVI  decimal(19,2),
	PY_R_AVII  decimal(19,2),
	PY_R_A  decimal(19,2),
	PY_R_C1  decimal(19,2),
	PY_R_C3  decimal(19,2),
	PY_R_C  decimal(19,2),
	PY_R_D1  decimal(19,2),
	PY_R_D  decimal(19,2),
	PY_R_E1  decimal(19,2),
	PY_R_E  decimal(19,2),
    PY_TOTRICAVI  decimal(19,2),
	
	C_BVIII1a  	decimal(19,2),
	C_BVIII1b  	decimal(19,2),
	C_BVIII1c  	decimal(19,2),
	C_BVIII1d  	decimal(19,2),
	C_BVIII1e  	decimal(19,2),
	C_BVIII2  	decimal(19,2),
	C_BVIII  	decimal(19,2),
	C_BIX1  	decimal(19,2),
	C_BIX2  	decimal(19,2),
	C_BIX3  	decimal(19,2),
	C_BIX4  	decimal(19,2),
	C_BIX5  	decimal(19,2),
	C_BIX6  	decimal(19,2),
	C_BIX7  	decimal(19,2),
	C_BIX8  	decimal(19,2),
	C_BIX9  	decimal(19,2),
	C_BIX11		decimal(19,2),  	
	C_BIX10		decimal(19,2), 	
	C_BIX12  	decimal(19,2),
	C_BIX  	decimal(19,2),
	C_BX1  	decimal(19,2),
	C_BX2  	decimal(19,2),
	C_BX3  	decimal(19,2),
	C_BX4  	decimal(19,2),
	C_BX  	decimal(19,2),
	C_BXI  	decimal(19,2),
	C_BXII  decimal(19,2),
	C_B  	decimal(19,2),
	C_C2	decimal(19,2),	
	C_C3	decimal(19,2),	
	C_C  	decimal(19,2),
	C_D2	decimal(19,2),	
	C_D  	decimal(19,2),
	C_E2	decimal(19,2),	
	C_E  	decimal(19,2),
	C_F  	decimal(19,2),
	TOTCOSTI  	decimal(19,2),
	R_AI1  	decimal(19,2),
	R_AI2  	decimal(19,2),
	R_AI3  	decimal(19,2),
	R_AI  	decimal(19,2),
	R_AII1  decimal(19,2),
	R_AII2  decimal(19,2),
	R_AII3  decimal(19,2),
	R_AII4  decimal(19,2),
	R_AII5  decimal(19,2),
	R_AII6  decimal(19,2),
	R_AII7  decimal(19,2),
	R_AII  	decimal(19,2),
	R_AIII  decimal(19,2),
	R_AIV  	decimal(19,2),
	R_AV  	decimal(19,2),
	R_AVI  	decimal(19,2),
	R_AVII  decimal(19,2),
	R_A  	decimal(19,2),
	R_C1	decimal(19,2),	
	R_C3    decimal(19,2),	
	R_C  	decimal(19,2),
	R_D1	decimal(19,2),	
	R_D  	decimal(19,2),
	R_E1	decimal(19,2),	
	R_E  	decimal(19,2), 
	TOTRICAVI  decimal(19,2),
	sortcode1 varchar(50),
	titlesortcode1 varchar(150)
)
	declare @s varchar(300)
		set @s = 'rpt_contoeconomico_dm2012'
 
 declare @showidsor1child char(1)
 set @showidsor1child = 'N'
 
 
INSERT INTO #CONTO_ECONOMICO
EXEC @s @ayear, @start, @stop,@idupb,@showchildupb,@idsor1,@showidsor1child,@idsor2,@idsor3


 SELECT @RISULTATO_NETTO =   - TOTCOSTI + TOTRICAVI FROM #CONTO_ECONOMICO
--SELECT @RISULTATO_NETTO = R_A- C_B+ R_C1 + C_C2 +R_c3-c_c3+ R_D + C_D+R_E+C_E+C_F FROM #CONTO_ECONOMICO

 PRINT '@RISULTATO_NETTO'
 PRINT @RISULTATO_NETTO

 -- occorre aggiungere plusvalenze e minusvalenze ma attendo indicazioni da Emilia
-----------------------------------------------------------------------
---------------- AMMORTAMENTI E SVALUTAZIONI ---------------------------
-----------------------------------------------------------------------
-- Conto Economico  VOCE SCHEMA  CONTO ECONOMICO RIFERIMENTO
-- B) X AMMORTAMENTI E SVALUTAZIONI
--Totale ammortamenti e svalutazioni

DECLARE @AMMORTAMENTI_E_SVALUTAZIONI decimal(19,2)
-->	B) X - AMMORTAMENTI E SVALUTAZIONI

DECLARE @CE_B_X1 decimal(19,2)
SET @CE_B_X1 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 1)'
	AND placcount.placcpart = 'C'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)

DECLARE @CE_B_X2 decimal(19,2)
SET @CE_B_X2 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)
/*
DECLARE @CE_B_X3 decimal(19,2)
SET @CE_B_X3 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)

DECLARE @CE_B_X4 decimal(19,2)
SET @CE_B_X4 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 4)'
	AND placcount.placcpart = 'C'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)
*/
DECLARE @CE_B_X decimal(19,2)
SET @CE_B_X = @CE_B_X1 + @CE_B_X2-- + @CE_B_X3 + @CE_B_X4

SET @AMMORTAMENTI_E_SVALUTAZIONI = @CE_B_X

-----------------------------------------------------------------------
--------- VARIAZIONE NETTA DEI FONDI RISCHI ED ONERI ------------------ 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- B) Fondi per rischi ed oneri (PASSIVO)
-- Totale accantonamento fondi rischi e oneri al 31/12 - Totale accantonamento fondi rischi e oneri al 01/01
DECLARE @VARIAZIONE_NETTA_FONDI_RISCHI_ED_ONERI DECIMAL(19,2)

DECLARE @SP_B_01_01 decimal(19,2)
SET @SP_B_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN  @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)



DECLARE @SP_B_31_12 decimal(19,2)
SET @SP_B_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	JOIN account	ON account.idacc = entrydetail.idacc
	JOIN patrimony	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

SET @VARIAZIONE_NETTA_FONDI_RISCHI_ED_ONERI = @SP_B_31_12 - @SP_B_01_01 -- con il proprio segno

-----------------------------------------------------------------------
----------------------- VARIAZIONE NETTA DEL TFR----------------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
--  C) Trattamento di fine rapporto di lavoro subordinato (PASSIVO)
--Totale accantonamento TFR al 31/12 - Totale accantonamento TFR al 01/01
DECLARE @VARIAZIONE_NETTA_TFR DECIMAL(19,2)

DECLARE @SP_C_01_01 decimal(19,2)
SET @SP_C_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry			ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	JOIN account		ON account.idacc = entrydetail.idacc
	JOIN patrimony		ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN  @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind = 7 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)



DECLARE @SP_C_31_12 decimal(19,2)
SET @SP_C_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN  @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO E L'APERTURA
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'C)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

SET @VARIAZIONE_NETTA_TFR= @SP_C_31_12 - @SP_C_01_01  -- con il proprio segno

-----------------------------------------------------------------------
------------- (AUMENTO)/DIMINUZIONE DEI CREDITI ----------------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- B) II Crediti (ATTIVO) Totale crediti al 31/12 - Totale crediti al 01/01
DECLARE @AUMENTO_DIMINUZIONE_CREDITI decimal(19,2)

DECLARE @SP_A_BI_01_01 decimal(19,2)
SET @SP_A_BI_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII1_01_01 decimal(19,2)
SET @SP_A_BII_bII1_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)o','B) II 1)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


 
-- Solo la parte esigibile
DECLARE @SP_A_BII_bII1e_01_01  decimal(19,2)
SET @SP_A_BII_bII1e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII2_01_01 decimal(19,2)
SET @SP_A_BII_bII2_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e','B) II 2)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


-- Solo la parte esigibile
DECLARE @SP_A_BII_bII2e_01_01 decimal(19,2)
SET @SP_A_BII_bII2e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind = 7
	AND entry.identrykind not in (6,11,12)-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII3_01_01 decimal(19,2)
SET @SP_A_BII_bII3_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind = 7-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e','B) II 3)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_BII_bII3e_01_01 decimal(19,2)
SET @SP_A_BII_bII3e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII4_01_01 decimal(19,2)
SET @SP_A_BII_bII4_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e','B) II 4)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_BII_bII4e_01_01 decimal(19,2)
SET @SP_A_BII_bII4e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII5_01_01 decimal(19,2)
SET @SP_A_BII_bII5_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e','B) II 5)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII5e_01_01 decimal(19,2)
SET @SP_A_BII_bII5e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII6_01_01 decimal(19,2)
SET @SP_A_BII_bII6_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e','B) II 6)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII6e_01_01 decimal(19,2)
SET @SP_A_BII_bII6e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12)-- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII7_01_01 decimal(19,2)
SET @SP_A_BII_bII7_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e','B) II 7)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII7e_01_01 decimal(19,2)
SET @SP_A_BII_bII7e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII8_01_01 decimal(19,2)
SET @SP_A_BII_bII8_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e','B) II 8)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII8e_01_01 decimal(19,2)
SET @SP_A_BII_bII8e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII9_01_01 decimal(19,2)
SET @SP_A_BII_bII9_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e','B) II 9)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII9e_01_01 decimal(19,2)
SET @SP_A_BII_bII9e_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------------------------
--------------- 31 12 -----------------------
---------------------------------------------

DECLARE @SP_A_BI_31_12 decimal(19,2)
SET @SP_A_BI_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII1_31_12  decimal(19,2)
SET @SP_A_BII_bII1_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)o','B) II 1)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


 
-- Solo la parte esigibile
DECLARE @SP_A_BII_bII1e_31_12  decimal(19,2)
SET @SP_A_BII_bII1e_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 1)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII2_31_12  decimal(19,2)
SET @SP_A_BII_bII2_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e','B) II 2)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


-- Solo la parte esigibile
DECLARE @SP_A_BII_bII2e_31_12  decimal(19,2)
SET @SP_A_BII_bII2e_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 2)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII3_31_12  decimal(19,2)
SET @SP_A_BII_bII3_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e','B) II 3)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_BII_bII3e_31_12  decimal(19,2)
SET @SP_A_BII_bII3e_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 3)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII4_31_12  decimal(19,2)
SET @SP_A_BII_bII4_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e','B) II 4)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_BII_bII4e_31_12 decimal(19,2)
SET @SP_A_BII_bII4e_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 4)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII5_31_12  decimal(19,2)
SET @SP_A_BII_bII5_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e','B) II 5)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII5e_31_12 decimal(19,2)
SET @SP_A_BII_bII5e_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 5)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII6_31_12  decimal(19,2)
SET @SP_A_BII_bII6_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e','B) II 6)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII6e_31_12  decimal(19,2)
SET @SP_A_BII_bII6e_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 6)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII7_31_12  decimal(19,2)
SET @SP_A_BII_bII7_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e','B) II 7)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII7e_31_12 decimal(19,2)
SET @SP_A_BII_bII7e_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 7)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII8_31_12  decimal(19,2)
SET @SP_A_BII_bII8_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e','B) II 8)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII8e_31_12 decimal(19,2)
SET @SP_A_BII_bII8e_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 8)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII9_31_12  decimal(19,2)
SET @SP_A_BII_bII9_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e','B) II 9)o')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BII_bII9e_31_12 decimal(19,2)
SET @SP_A_BII_bII9e_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('B) II 9)e')
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear )
,0)

DECLARE @SP_A_BII decimal(19,2)
SET @SP_A_BII = 
(@SP_A_BII_bII1_31_12 + @SP_A_BII_bII2_31_12  + @SP_A_BII_bII3_31_12  + @SP_A_BII_bII4_31_12  + 
 @SP_A_BII_bII5_31_12 + @SP_A_BII_bII6_31_12  + @SP_A_BII_bII7_31_12  + @SP_A_BII_bII8_31_12  + 
 @SP_A_BII_bII9_31_12) 
 -
 (@SP_A_BII_bII1_01_01 + @SP_A_BII_bII2_01_01 + @SP_A_BII_bII3_01_01 + @SP_A_BII_bII4_01_01  + 
 @SP_A_BII_bII5_01_01 + @SP_A_BII_bII6_01_01 + @SP_A_BII_bII7_01_01  + @SP_A_BII_bII8_01_01  + 
 @SP_A_BII_bII9_01_01) 

--DECLARE @SP_A_BIIe decimal(19,2)
--SET @SP_A_BIIe = @SP_A_BII_bII1e + @SP_A_BII_bII2e  + @SP_A_BII_bII3e  + @SP_A_BII_bII4e  + @SP_A_BII_bII5e  + @SP_A_BII_bII6e  + @SP_A_BII_bII7e  + @SP_A_BII_bII8e  + @SP_A_BII_bII9e 

-- N.B: l'aumento dei crediti va in negativo. La diminuzione in positivo
SET @AUMENTO_DIMINUZIONE_CREDITI = - @SP_A_BII 
 
-----------------------------------------------------------------------
------------- (AUMENTO)/DIMINUZIONE DELLE RIMANENZE ----------------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- Totale rimanenze al 31/12 - Totale rimanenze al 01/01
-- B) I Rimanenze (ATTIVO)

DECLARE @AUMENTO_DIMINUZIONE_RIMANENZE  decimal(19,2)
DECLARE @SP_A_B_I_01_01 decimal(19,2)
SET @SP_A_B_I_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_B_I_31_12 decimal(19,2)
SET @SP_A_B_I_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) I'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_B_I DECIMAL(19,2) 
SET @SP_A_B_I = @SP_A_B_I_31_12 -@SP_A_B_I_01_01

--N.B: l'aumento delle rimanenze va in negativo. La diminuzione in positivo
SET @AUMENTO_DIMINUZIONE_RIMANENZE =  - @SP_A_B_I

-----------------------------------------------------------------------
------------- (AUMENTO)/DIMINUZIONE DEI DEBITI ----------------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- Totale debiti al 31/12 - Totale debiti al 01/01
-- D) Debiti (PASSIVO)
DECLARE @AUMENTO_DIMINUZIONE_DEBITI decimal(19,2)
 

DECLARE @SP_P_D_d2_01_01 decimal(19,2)
SET @SP_P_D_d2_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)e','D) 2)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d2o_01_01 decimal(19,2)
SET @SP_P_D_d2o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d3_01_01 decimal(19,2)
SET @SP_P_D_d3_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)e','D) 3)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_D_d3o_01_01 decimal(19,2)
SET @SP_P_D_d3o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d4_01_01 decimal(19,2)
SET @SP_P_D_d4_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)e','D) 4)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d4o_01_01 decimal(19,2)
SET @SP_P_D_d4o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d5_01_01 decimal(19,2)
SET @SP_P_D_d5_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)e','D) 5)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d5o_01_01 decimal(19,2)
SET @SP_P_D_d5o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d6_01_01 decimal(19,2)
SET @SP_P_D_d6_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)e','D) 6)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d6o_01_01 decimal(19,2)
SET @SP_P_D_d6o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d7_01_01 decimal(19,2)
SET @SP_P_D_d7_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)e','D) 7)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_D_d7o_01_01 decimal(19,2)
SET @SP_P_D_d7o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d8_01_01 decimal(19,2)
SET @SP_P_D_d8_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)e','D) 8)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d8o_01_01 decimal(19,2)
SET @SP_P_D_d8o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d9_01_01 decimal(19,2)
SET @SP_P_D_d9_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)e','D) 9)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d9o_01_01 decimal(19,2)
SET @SP_P_D_d9o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d10_01_01 decimal(19,2)
SET @SP_P_D_d10_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)e','D) 10)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d10o_01_01 decimal(19,2)
SET @SP_P_D_d10o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d11_01_01 decimal(19,2)
SET @SP_P_D_d11_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)e','D) 11)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d11o_01_01 decimal(19,2)
SET @SP_P_D_d11o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d12_01_01 decimal(19,2)
SET @SP_P_D_d12_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)e','D) 12)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d12o_01_01 decimal(19,2)
SET @SP_P_D_d12o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

 
DECLARE @SP_P_D_d1e_01_01 decimal(19,2)
SET @SP_P_D_d1e_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d1o_01_01 decimal(19,2)
SET @SP_P_D_d1o_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d1e_31_12 decimal(19,2)
SET @SP_P_D_d1e_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)



DECLARE @SP_P_D_d1o_31_12 decimal(19,2)
SET @SP_P_D_d1o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d2_31_12 decimal(19,2)
SET @SP_P_D_d2_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)e','D) 2)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d2o_31_12 decimal(19,2)
SET @SP_P_D_d2o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 2)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d3_31_12 decimal(19,2)
SET @SP_P_D_d3_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)e','D) 3)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_D_d3o_31_12 decimal(19,2)
SET @SP_P_D_d3o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 3)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d4_31_12 decimal(19,2)
SET @SP_P_D_d4_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)e','D) 4)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d4o_31_12 decimal(19,2)
SET @SP_P_D_d4o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 4)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d5_31_12 decimal(19,2)
SET @SP_P_D_d5_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)e','D) 5)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d5o_31_12 decimal(19,2)
SET @SP_P_D_d5o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 5)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d6_31_12 decimal(19,2)
SET @SP_P_D_d6_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)e','D) 6)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d6o_31_12 decimal(19,2)
SET @SP_P_D_d6o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 6)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d7_31_12 decimal(19,2)
SET @SP_P_D_d7_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)e','D) 7)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_D_d7o_31_12 decimal(19,2)
SET @SP_P_D_d7o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 7)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d8_31_12 decimal(19,2)
SET @SP_P_D_d8_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)e','D) 8)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d8o_31_12 decimal(19,2)
SET @SP_P_D_d8o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 8)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d9_31_12 decimal(19,2)
SET @SP_P_D_d9_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)e','D) 9)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d9o_31_12 decimal(19,2)
SET @SP_P_D_d9o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 9)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d10_31_12 decimal(19,2)
SET @SP_P_D_d10_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)e','D) 10)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d10o_31_12 decimal(19,2)
SET @SP_P_D_d10o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 10)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d11_31_12 decimal(19,2)
SET @SP_P_D_d11_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)e','D) 11)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d11o_31_12 decimal(19,2)
SET @SP_P_D_d11o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 11)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d12_31_12 decimal(19,2)
SET @SP_P_D_d12_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)e','D) 12)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_D_d12o_31_12 decimal(19,2)
SET @SP_P_D_d12o_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony  in ('D) 12)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


-- task 11243 non valorizzare nessun importo perchè quella è un'intestazione nella colonna
-- l'importo che al momento viene valorizzato lì, va inglobato nella voce (Aumento)/Diminuzione dei debiti. 
-- Questa voce al momento esclude tutta la voce D1) dello Stato Patrimoniale. Invece deve escludere solo D1) o (OLTRE l'esercizio)

DECLARE @ATTIVITA_DI_FINANZIAMENTO decimal(19,2)
SET @ATTIVITA_DI_FINANZIAMENTO = 0 --@SP_P_D_d1e_31_12 - @SP_P_D_d1e_01_01

--Se il risultato è positivo è una fonte e va con segno POSITIVO altrimenti in NEGATIVO
DECLARE @VARIAZIONE_NETTA_DEI_FINANZIAMENTI_A_MEDIO_LUNGO_TERMINE decimal(19,2)
SET @VARIAZIONE_NETTA_DEI_FINANZIAMENTI_A_MEDIO_LUNGO_TERMINE= @SP_P_D_d1o_31_12 -@SP_P_D_d1o_01_01


DECLARE @SP_P_D decimal(19,2)
SET @SP_P_D = 
(@SP_P_D_d2_31_12 + @SP_P_D_d3_31_12 + @SP_P_D_d4_31_12 + 
 @SP_P_D_d5_31_12 + @SP_P_D_d6_31_12 + @SP_P_D_d7_31_12 + 
 @SP_P_D_d8_31_12 + @SP_P_D_d9_31_12 + @SP_P_D_d10_31_12 + @SP_P_D_d11_31_12 + @SP_P_D_d12_31_12 ) -

(@SP_P_D_d2_01_01 + @SP_P_D_d3_01_01 + @SP_P_D_d4_01_01 + @SP_P_D_d5_01_01+ 
 @SP_P_D_d6_01_01 + @SP_P_D_d7_01_01 + 
 @SP_P_D_d8_01_01 + @SP_P_D_d9_01_01 + @SP_P_D_d10_01_01 + @SP_P_D_d11_01_01 + @SP_P_D_d12_01_01 ) 
+
 (@SP_P_D_d1e_31_12 - @SP_P_D_d1e_01_01)  -- -questa voce prima andava in  ATTIVITA' DI FINANZIAMENTO

--N.B: l'aumento dei debiti va in POSITIVO. La diminuzione in NEGATIVO
SET @AUMENTO_DIMINUZIONE_DEBITI = @SP_P_D
--DECLARE @SP_P_Do decimal(19,2)
--SET @SP_P_Do = @SP_P_D_d1o + @SP_P_D_d2o + @SP_P_D_d3o + @SP_P_D_d4o + @SP_P_D_d5o + @SP_P_D_d6o + @SP_P_D_d7o + @SP_P_D_d8o + @SP_P_D_d9o + @SP_P_D_d10o + @SP_P_D_d11o + @SP_P_D_d12o

-----------------------------------------------------------------------
--------- VARIAZIONE DI ALTRE VOCI DEL CAPITALE CIRCOLANTE ------------ 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- Totale Attività finanziarie al 31/12 - Totale Attività finanziarie al 01/01
-- B) III Attività finanziarie (ATTIVO)
DECLARE @VARIAZIONE_ALTRE_VOCI_CAPITALE_CIRCOLANTE DECIMAL(19,2)
DECLARE @SP_A_BIII_01_01 decimal(19,2)
SET @SP_A_BIII_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) III'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BIII_31_12 decimal(19,2)
SET @SP_A_BIII_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) III'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
--N.B: l'aumento delle attiv.fin. va in negativo. La diminuzione in positivo
DECLARE @SP_A_BIII DECIMAL(19,2)
SET @SP_A_BIII = - ( @SP_A_BIII_31_12 - @SP_A_BIII_01_01 )

-- C) Ratei e risconti attivi (ATTIVO)
DECLARE @SP_A_C1_01_01 decimal(19,2)  
SET @SP_A_C1_01_01 =  
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'C) c1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
 

DECLARE @SP_A_C1_31_12 decimal(19,2)  
SET @SP_A_C1_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'C) c1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_C2_01_01 decimal(19,2)
SET @SP_A_C2_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'C) c2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_C2_31_12 decimal(19,2)
SET @SP_A_C2_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'C) c2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

--  C) Ratei e risconti attivi (ATTIVO):
-- N.B: l'aumento dei ratei e risconti attivi va in negativo. La diminuzione in positivo

DECLARE @SP_A_C decimal(19,2)
--SET @SP_A_C = @SP_A_C1_31_12 - @SP_A_C1_01_01 + @SP_A_C2_31_12 - @SP_A_C2_01_01 
SET @SP_A_C = - ( @SP_A_C1_31_12 + @SP_A_C2_31_12 - (@SP_A_C1_01_01  + @SP_A_C2_01_01)) 

---------------------------------------	D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO	--------------------------------------------------------------------
-- D) Ratei attivi per progetti e ricerche in corso
-- 'd 1)' Ratei attivi per progetti e ricerche finanziate e co-finanziate in corso(ATTIVO)
DECLARE @SP_A_D1_01_01 decimal(19,2)  
SET @SP_A_D1_01_01 =  
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'd 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
  PRINT '@SP_A_D1_01_01'
 PRINT @SP_A_D1_01_01
DECLARE @SP_A_D1_31_12 decimal(19,2)  
SET @SP_A_D1_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE  entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'd 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
  PRINT '@SP_A_D1_31_12'
 PRINT @SP_A_D1_31_12

--  D) Ratei attivi per progetti e ricerche in corso (ATTIVO):
-- N.B: l'aumento dei ratei e risconti attivi va in negativo. La diminuzione in positivo

DECLARE @SP_A_D decimal(19,2)
SET @SP_A_D = - ( @SP_A_D1_31_12 - @SP_A_D1_01_01)  
PRINT '@SP_A_D'
PRINT @SP_A_D
--E) Ratei e risconti passivi e contributi agli investimenti (PASSIVO)

DECLARE @SP_P_E1_01_01 decimal(19,2)
SET @SP_P_E1_01_01 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_E1_31_12 decimal(19,2)
SET @SP_P_E1_31_12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_E2_01_01 decimal(19,2)
SET @SP_P_E2_01_01 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate  BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_E2_31_12 decimal(19,2)
SET @SP_P_E2_31_12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)



DECLARE @SP_P_E3_01_01 decimal(19,2)
SET @SP_P_E3_01_01 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday 
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_E3_31_12 decimal(19,2)
SET @SP_P_E3_31_12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'E) e3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

--N.B: l'aumento delle attiv.fin. va in negativo. La diminuzione in positivo
--N.B: l'aumento dei ratei e risconti attivi va in negativo. La diminuzione in positivo
--N.B: l'aumento dei ratei e risconti passivi va in positivo. La diminuzione in negativo
DECLARE @SP_P_E decimal(19,2)
SET @SP_P_E =(@SP_P_E1_31_12 + @SP_P_E2_31_12 + @SP_P_E3_31_12 )- ( @SP_P_E1_01_01 + @SP_P_E2_01_01 + @SP_P_E3_01_01 )

-- 'F)	RISCONTI PASSIVI PER PROGETTI E RICERCHE IN CORSO'
-- 'f1) Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso'
 

DECLARE @SP_P_F1_01_01 decimal(19,2)
SET @SP_P_F1_01_01 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'f 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

PRINT '@SP_P_F1_01_01'
PRINT @SP_P_F1_01_01


DECLARE @SP_P_F1_31_12 decimal(19,2)
SET @SP_P_F1_31_12 =
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'f 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

 PRINT '@SP_P_F1_31_12'
PRINT @SP_P_F1_31_12

--N.B: l'aumento dei ratei e risconti passivi va in positivo. La diminuzione in negativo
DECLARE @SP_P_F decimal(19,2)
SET @SP_P_F =  @SP_P_F1_31_12- @SP_P_F1_01_01
PRINT '@SP_P_F'
PRINT @SP_P_F
SET @VARIAZIONE_ALTRE_VOCI_CAPITALE_CIRCOLANTE =  + @SP_A_BIII + @SP_A_C + @SP_A_D +  @SP_P_E + @SP_P_F

-----------------------------------------------------------------------
--------- A) FLUSSO DI CASSA (CASH FLOW) OPERATIVO -------------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- Somma algebrica delle voci finora elencate  
DECLARE @FLUSSO_DI_CASSA_CASH_FLOW_OPERATIVO DECIMAL(19,2)
SET @FLUSSO_DI_CASSA_CASH_FLOW_OPERATIVO  = 
	isnull(@RISULTATO_NETTO,0) +
	isnull(@AMMORTAMENTI_E_SVALUTAZIONI,0) +
	isnull(@VARIAZIONE_NETTA_FONDI_RISCHI_ED_ONERI,0) +
	isnull(@VARIAZIONE_NETTA_TFR,0) + 
	isnull(@AUMENTO_DIMINUZIONE_CREDITI,0) + 
	isnull(@AUMENTO_DIMINUZIONE_RIMANENZE,0) + 
	isnull(@AUMENTO_DIMINUZIONE_DEBITI,0) +
	isnull(@VARIAZIONE_ALTRE_VOCI_CAPITALE_CIRCOLANTE,0)
	
-----------------------------------------------------------------------
---------INVESTIMENTI IN IMMOBILIZZAZIONI: MATERIALI ------------------ 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- INVESTIMENTI IN IMMOBILIZZAZIONI: MATERIALI
-- Totale IMM.MAT. al 31/12 - Totale IMM.MAT.  al 01/01,
-- NB: Le immobilizzazioni devono essere valorizzate al LORDO degli ammortamenti!
-- A) II Materiali (ATTIVO)

--- NOTA BENE: 
-- Emilia propone sue soluzioni alternative
-- [09:57:14] Maria Smaldino: bisogna scegliere
-- [09:58:00] Maria Smaldino: 1) Escludere le scritture con tipo conto "Fondo Ammortamento" 
-- dalle formule però il tipo conto è configurabile, dovremmo nel caso uniformarli a tutti i clienti
-- [09:59:07] Maria Smaldino: 2) Siccome i conti di tipo "Fondo Ammortamento" hanno pure 
-- la caratteristica di avere segno negativo sullo stato patrimoniale, usiamo questo segno 
-- per filtrare le scritture di ammortamento escludendole dal totale



DECLARE @INVESTIMENTI_IN_IMMOBILIZZAZIONI_MATERIALI DECIMAL(19,2)

DECLARE @SP_A_AII_aII1_01_01 decimal(19,2)
SET @SP_A_AII_aII1_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII2_01_01 decimal(19,2)
SET @SP_A_AII_aII2_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII3_01_01 decimal(19,2)
SET @SP_A_AII_aII3_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII4_01_01 decimal(19,2)
SET @SP_A_AII_aII4_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 4)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII5_01_01 decimal(19,2)
SET @SP_A_AII_aII5_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 5)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_AII_aII6_01_01 decimal(19,2)
SET @SP_A_AII_aII6_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 6)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII7_01_01 decimal(19,2)
SET @SP_A_AII_aII7_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 7)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

--------------------------------------
---------------- 31 12 ---------------
--------------------------------------

DECLARE @SP_A_AII_aII1_31_12 decimal(19,2)
SET @SP_A_AII_aII1_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII2_31_12  decimal(19,2)
SET @SP_A_AII_aII2_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII3_31_12  decimal(19,2)
SET @SP_A_AII_aII3_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII4_31_12  decimal(19,2)
SET @SP_A_AII_aII4_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 4)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII5_31_12  decimal(19,2)
SET @SP_A_AII_aII5_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 5)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_A_AII_aII6_31_12  decimal(19,2)
SET @SP_A_AII_aII6_31_12  = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 6)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AII_aII7_31_12  decimal(19,2)
SET @SP_A_AII_aII7_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 7)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)



DECLARE @Ammortamenti_Materiali  decimal(19,2)
SET @Ammortamenti_Materiali = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 2)'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)

DECLARE @SP_A_AII decimal(19,2)
SET @SP_A_AII = 
	(@SP_A_AII_aII1_31_12 + @SP_A_AII_aII2_31_12 + @SP_A_AII_aII3_31_12 + @SP_A_AII_aII4_31_12 +  @SP_A_AII_aII5_31_12 + @SP_A_AII_aII6_31_12 + @SP_A_AII_aII7_31_12) 
	+ @Ammortamenti_Materiali
	- (@SP_A_AII_aII1_01_01 + @SP_A_AII_aII2_01_01 + @SP_A_AII_aII3_01_01 + @SP_A_AII_aII4_01_01 +  @SP_A_AII_aII5_01_01 + @SP_A_AII_aII6_01_01 + @SP_A_AII_aII7_01_01 ) 

-- Questo totale in base al segno del risultato va a finire in un campo o nell'altro ANALOGO
-- dei disinvestimenti
DECLARE @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_MATERIALI DECIMAL(19,2)
IF (@SP_A_AII > 0)
	SET @INVESTIMENTI_IN_IMMOBILIZZAZIONI_MATERIALI  = -@SP_A_AII
ELSE
	SET @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_MATERIALI  = -@SP_A_AII
	


-----------------------------------------------------------------------
---------INVESTIMENTI IN IMMOBILIZZAZIONI: IMMATERIALI ---------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- INVESTIMENTI IN IMMOBILIZZAZIONI: IMMATERIALI
-- Totale IMM.IMM. al 31/12 - Totale IMM.IMM.  al 01/01, 
-- NB: Le immobilizzazioni devono essere valorizzate al LORDO degli ammortamenti!
-- A) I Immateriali (ATTIVO)
DECLARE @Ammortamenti_IMMateriali  decimal(19,2)
SET @Ammortamenti_IMMateriali = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop 
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.codeplaccount = 'B) X 1)'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND placcount.ayear = @ayear)
,0)

DECLARE @INVESTIMENTI_IN_IMMOBILIZZAZIONI_IMMATERIALI decimal(19,2)
DECLARE @SP_A_AI_aI1_01_01 decimal(19,2)
SET @SP_A_AI_aI1_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI2_01_01 decimal(19,2)
SET @SP_A_AI_aI2_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI3_01_01 decimal(19,2)
SET @SP_A_AI_aI3_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 3)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI4_01_01 decimal(19,2)
SET @SP_A_AI_aI4_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 4)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI5_01_01 decimal(19,2)
SET @SP_A_AI_aI5_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 5)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------------------------
--------------------- 31 12 -----------------
---------------------------------------------
DECLARE @SP_A_AI_aI1_31_12 decimal(19,2)
SET @SP_A_AI_aI1_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI2_31_12 decimal(19,2)
SET @SP_A_AI_aI2_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI3_31_12 decimal(19,2)
SET @SP_A_AI_aI3_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 3)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI4_31_12 decimal(19,2)
SET @SP_A_AI_aI4_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 4)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI_aI5_31_12 decimal(19,2)
SET @SP_A_AI_aI5_31_12= 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I 5)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_AI DECIMAL(19,2)
SET @SP_A_AI = 
	(@SP_A_AI_aI1_31_12 + @SP_A_AI_aI2_31_12 + @SP_A_AI_aI3_31_12 + @SP_A_AI_aI4_31_12 + @SP_A_AI_aI5_31_12) 
	+ @Ammortamenti_IMMateriali
	-  (@SP_A_AI_aI1_01_01 + @SP_A_AI_aI2_01_01  + @SP_A_AI_aI3_01_01  + @SP_A_AI_aI4_01_01  + @SP_A_AI_aI5_01_01 )

DECLARE @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_IMMATERIALI DECIMAL(19,2)

IF (@SP_A_AI > 0)
	SET @INVESTIMENTI_IN_IMMOBILIZZAZIONI_IMMATERIALI = -@SP_A_AI
ELSE
	SET @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_IMMATERIALI =- @SP_A_AI
	
-----------------------------------------------------------------------
---------INVESTIMENTI IN IMMOBILIZZAZIONI: FINANZIARIE ---------------- 
-----------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- INVESTIMENTI IN IMMOBILIZZAZIONI: FINANZIARIE
-- Totale IMM.FIN. al 31/12 - Totale IMM.FIN.  al 01/01	
--NB: Le immobilizzazioni devono essere valorizzate al LORDO degli ammortamenti!
-- A) III Finanziarie (ATTIVO)
DECLARE @INVESTIMENTI_IN_IMMOBILIZZAZIONI_FINANZIARIE decimal(19,2)
DECLARE @SP_A_AIII_01_01 decimal(19,2)
SET @SP_A_AIII_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear) 
,0)

DECLARE @SP_A_AIII_31_12 decimal(19,2)
SET @SP_A_AIII_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear) 
,0)

DECLARE @SP_AIII DECIMAL(19,2)
DECLARE @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_FINANZIARIE DECIMAL(19,2)

SET @SP_AIII = @SP_A_AIII_31_12 - @SP_A_AIII_01_01
IF (@SP_AIII > 0)
	SET @INVESTIMENTI_IN_IMMOBILIZZAZIONI_FINANZIARIE = - @SP_AIII
ELSE
	SET @DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_FINANZIARIE = - @SP_AIII




----------------------------------------------------------------------------------
-- B) FLUSSO MONETARIO (CASH FLOW) DA ATTIVITA’ DI INVESTIMENTO/DISINVESTIMENTO --
----------------------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- Somma algebrica colonna C
DECLARE @FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_INVESTIMENTO_DISINVESTIMENTO DECIMAL(19,2)
-- Somma delle immobilizzazioni:investimenti e disinvestimenti
SET @FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_INVESTIMENTO_DISINVESTIMENTO =
		isnull(@INVESTIMENTI_IN_IMMOBILIZZAZIONI_MATERIALI,0) +
		isnull(@INVESTIMENTI_IN_IMMOBILIZZAZIONI_IMMATERIALI ,0) +
		isnull(@INVESTIMENTI_IN_IMMOBILIZZAZIONI_FINANZIARIE ,0) +
		isnull(@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_MATERIALI ,0) +
		isnull(@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_IMMATERIALI ,0) + 
		isnull(@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_FINANZIARIE,0)
--------------------------------------------------------------------------------------------------------------------
------------------------- 	AUMENTO DI CAPITALE (Variazioni del Patrimonio Netto)) --------------------------------- 
--------------------------------------------------------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- A) I Fondo di dotazione dell'Ateneo (PASSIVO)
-- Totale Fondo di dotazione dell'Ateneo al 31/12 - Totale Fondo di dotazione dell'Ateneo  al 01/01

DECLARE @AUMENTO_DI_CAPITALE DECIMAL(19,2)
DECLARE @SP_P_AI_01_01 decimal(19,2)
SET @SP_P_AI_01_01  =  
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------
DECLARE @SP_P_AI_31_12 decimal(19,2)
SET @SP_P_AI_31_12  = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) I'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
 


DECLARE @SP_P_AII_aII1_01_01 decimal(19,2)
SET @SP_P_AII_aII1_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN  @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------
DECLARE @SP_P_AII_aII1_31_12 decimal(19,2)
SET @SP_P_AII_aII1_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_P_AII_aII2_01_01 decimal(19,2)
SET @SP_P_AII_aII2_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------

DECLARE @SP_P_AII_aII2_31_11 decimal(19,2)
SET @SP_P_AII_aII2_31_11 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_AII_aII3_01_01 decimal(19,2)
SET @SP_P_AII_aII3_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------

DECLARE @SP_P_AII_aII3_31_12 decimal(19,2)
SET @SP_P_AII_aII3_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) II 3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


-- AUMENTO DI CAPITALE (Variazioni del Patrimonio Netto)=	Totale Patrimonio Netto( tranne Risultato esercizio al 31/12) - Totale Patrimonio Netto al 01/01

 --Tutte le voci di Stato Patrimoniale che stanno sotto A) Patrimonio Netto TRANNE il codice A III 1 per il quale va considerato solo il valore all'01/01 con il segno meno.

DECLARE @SP_P_AIII_aIII1_01_01 decimal(19,2)
SET @SP_P_AIII_aIII1_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------

/*DECLARE @SP_P_AIII_aIII1_31_12 decimal(19,2)
SET @SP_P_AIII_aIII1_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 1)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
*/

DECLARE @SP_P_AIII_aIII2_01_01 decimal(19,2)
SET @SP_P_AIII_aIII2_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------

DECLARE @SP_P_AIII_aIII2_31_12 decimal(19,2)
SET @SP_P_AIII_aIII2_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 2)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


DECLARE @SP_P_AIII_aIII3_01_01 decimal(19,2)
SET @SP_P_AIII_aIII3_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

---------------------------
---------- 31 12 ----------
---------------------------

DECLARE @SP_P_AIII_aIII3_31_12 decimal(19,2)
SET @SP_P_AIII_aIII3_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'A) III 3)'
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
 
 
-- AUMENTO DI CAPITALE (Variazioni del Patrimonio Netto)
-- Totale Patrimonio Netto tranne Risultato esercizio al 31/12 - Totale Patrimonio Netto al 01/01	
-- Tutte le voci di Stato Patrimoniale che stanno sotto A) Patrimonio Netto TRANNE il codice A III 1 per il quale va considerato solo il valore all'01/01 con il segno meno.		
-- Se il risultato è positivo è una fonte e va con segno POSITIVO altrimenti in NEGATIVO

DECLARE @SP_P_AI decimal(19,2)
DECLARE @SP_P_AII decimal(19,2)
DECLARE @SP_P_AIII decimal(19,2)

SET @SP_P_AI   = @SP_P_AI_31_12 - @SP_P_AI_01_01  
SET @SP_P_AII  = (@SP_P_AII_aII1_31_12 +@SP_P_AII_aII2_31_11 + @SP_P_AII_aII3_31_12 ) - (@SP_P_AII_aII1_01_01 +@SP_P_AII_aII2_01_01 + @SP_P_AII_aII3_01_01)
SET @SP_P_AIII = (/*@SP_P_AIII_aIII1_31_12 + */@SP_P_AIII_aIII2_31_12 + @SP_P_AIII_aIII3_31_12) - (@SP_P_AIII_aIII1_01_01 + @SP_P_AIII_aIII2_01_01 + @SP_P_AIII_aIII3_01_01) -->  @SP_P_AIII_aIII1_01_01 è stato letto col segno -
SET @AUMENTO_DI_CAPITALE = @SP_P_AI + @SP_P_AII + @SP_P_AIII  /*	- (@SP_P_AIII_aIII1_31_12 - @SP_P_AIII_aIII1_01_01)	*/

----------------------------------------------------------------------------------
---- VARIAZIONE NETTA DEI FINANZIAMENTI A MEDIO-LUNGO TERMINE --------------------
----------------------------------------------------------------------------------
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
-- D) 1 Mutui e debiti verso banche (PASSIVO)
-- Totale Mutui e debiti  verso Banche al 31/12 - Totale Mutui e debiti  verso Banche al 01/01
 
 
DECLARE @SP_P_D_d1_01_01 decimal(19,2)
SET @SP_P_D_d1_01_01 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e','D) 1)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)


-----------------------------------------
------------------- 31 12 ---------------
-----------------------------------------
DECLARE @SP_P_D_d1_31_12 DECIMAL(19,2)

SET @SP_P_D_d1_31_12 = 
ISNULL(
	(SELECT SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony in ('D) 1)e','D) 1)o')
	and patrimony.patpart ='P'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear )
,0)


DECLARE @SP_P_D_d1 DECIMAL(19,2)
SET @SP_P_D_d1 = @SP_P_D_d1_31_12 - @SP_P_D_d1_01_01 

 

----------------------------------------------------------------------------------
-------- C) FLUSSO MONETARIO (CASH FLOW) DA ATTIVITA’ DI FINANZIAMENTO------------ 
----------------------------------------------------------------------------------
-- Somma algebrica colonna C
DECLARE @FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_FINANZIAMENTO DECIMAL(19,2)
--QUA
SET @FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_FINANZIAMENTO = 
			@ATTIVITA_DI_FINANZIAMENTO
			+ @AUMENTO_DI_CAPITALE
			+ @VARIAZIONE_NETTA_DEI_FINANZIAMENTI_A_MEDIO_LUNGO_TERMINE   
			
----------------------------------------------------------------------------------
-------- D) FLUSSO MONETARIO (CASH FLOW) DELL’ESERCIZIO (A+B+C)------------------- 
----------------------------------------------------------------------------------
--Somma algebrica A+B+C
DECLARE @FLUSSO_MONETARI0_CASH_FLOW_ESERCIZIO_A_B_C DECIMAL(19,2)
SET @FLUSSO_MONETARI0_CASH_FLOW_ESERCIZIO_A_B_C = 
		isnull(@FLUSSO_DI_CASSA_CASH_FLOW_OPERATIVO,0) +  -- (A)
		isnull(@FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_INVESTIMENTO_DISINVESTIMENTO,0)  + -- (B)
		isnull(@FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_FINANZIAMENTO,0) -- (C)
		
----------------------------------------------------------------------------------
-------- DISPONIBILITA’ MONETARIA NETTA INIZIALE --------------------------------- 
----------------------------------------------------------------------------------
--Disponibilità liquide  al 01/01
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
--B) IV Disponibilità liquide  (ATTIVO)
DECLARE @DISPONIBILITA_MONETARIA_NETTA_INIZIALE DECIMAL(19,2)
DECLARE @SP_A_BIV_bIV1_01_01 decimal(19,2)
SET @SP_A_BIV_bIV1_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday  AND @firstday 
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BIV_bIV2_01_01 decimal(19,2)
SET @SP_A_BIV_bIV2_01_01 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE --entry.adate BETWEEN @firstday AND @firstday 
	(entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind =7
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)
DECLARE @SP_A_BIV_01_01 decimal(19,2)
SET @SP_A_BIV_01_01 = @SP_A_BIV_bIV1_01_01 + @SP_A_BIV_bIV2_01_01
SET @DISPONIBILITA_MONETARIA_NETTA_INIZIALE = @SP_A_BIV_01_01
----------------------------------------------------------------------------------
-------- DISPONIBILITA’ MONETARIA NETTA FINALE ----------------------------------- 
----------------------------------------------------------------------------------
--Disponibilità liquide al 31/12
-- Stato Patrimoniale VOCE SCHEMA  Stato Patrimoniale RIFERIMENTO
--B) IV Disponibilità liquide  (ATTIVO)
DECLARE @DISPONIBILITA_MONETARIA_NETTA_FINALE DECIMAL(19,2)
DECLARE @SP_A_BIV_bIV1_31_12 decimal(19,2)
SET @SP_A_BIV_bIV1_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 1)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BIV_bIV2_31_12 decimal(19,2)
SET @SP_A_BIV_bIV2_31_12 = 
ISNULL(
	(SELECT -SUM(amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	JOIN patrimony
	ON patrimony.idpatrimony = account.idpatrimony
		WHERE entry.adate BETWEEN @start  AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.codepatrimony = 'B) IV 2)'
	and patrimony.patpart ='A'
	AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
	AND patrimony.ayear = @ayear)
,0)

DECLARE @SP_A_BIV_31_12 decimal(19,2)
SET @SP_A_BIV_31_12 = @SP_A_BIV_bIV1_31_12 + @SP_A_BIV_bIV2_31_12
SET @DISPONIBILITA_MONETARIA_NETTA_FINALE = @SP_A_BIV_31_12
----------------------------------------------------------------------------------
-------- FLUSSO MONETARIO (CASH FLOW) DELL’ESERCIZIO -----------------------------
----------------------------------------------------------------------------------
 DECLARE @FLUSSO_MONETARIO_CASH_FLOW_ESERCIZIO decimal(19,2)

 SET @FLUSSO_MONETARIO_CASH_FLOW_ESERCIZIO = 
	 @DISPONIBILITA_MONETARIA_NETTA_FINALE -
	 @DISPONIBILITA_MONETARIA_NETTA_INIZIALE
		
DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal


SELECT
	@ayear			AS ayear      ,
	@idupboriginal	as   idupb          ,
	@codeupb	    as	 codeupb	    ,
	@title		    as	 upb		    ,
	@RISULTATO_NETTO 
		AS 'RISULTATO_NETTO',
	@AMMORTAMENTI_E_SVALUTAZIONI 
		AS 'AMMORTAMENTI_E_SVALUTAZIONI',
	@VARIAZIONE_NETTA_FONDI_RISCHI_ED_ONERI 
		AS 'VARIAZIONE_NETTA_FONDI_RISCHI_ED_ONERI',
	@VARIAZIONE_NETTA_TFR 
		AS 'VARIAZIONE_NETTA_TFR',
	@AUMENTO_DIMINUZIONE_CREDITI 
		AS 'AUMENTO_DIMINUZIONE_CREDITI',
	@AUMENTO_DIMINUZIONE_RIMANENZE 
		AS 'AUMENTO_DIMINUZIONE_RIMANENZE',
	@AUMENTO_DIMINUZIONE_DEBITI 
		AS 'AUMENTO_DIMINUZIONE_DEBITI',
	@VARIAZIONE_ALTRE_VOCI_CAPITALE_CIRCOLANTE 
		AS 'VARIAZIONE_ALTRE_VOCI_CAPITALE_CIRCOLANTE',
	@FLUSSO_DI_CASSA_CASH_FLOW_OPERATIVO 
		AS 'FLUSSO_DI_CASSA_CASH_FLOW_OPERATIVO',
	@INVESTIMENTI_IN_IMMOBILIZZAZIONI_MATERIALI 
		AS 'INVESTIMENTI_IN_IMMOBILIZZAZIONI_MATERIALI',
	@INVESTIMENTI_IN_IMMOBILIZZAZIONI_IMMATERIALI 
		AS 'INVESTIMENTI_IN_IMMOBILIZZAZIONI_IMMATERIALI',
	@INVESTIMENTI_IN_IMMOBILIZZAZIONI_FINANZIARIE 
		AS 'INVESTIMENTI_IN_IMMOBILIZZAZIONI_FINANZIARIE',
	@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_MATERIALI 
		AS 'DISINVESTIMENTI_DA_IMMOBILIZZAZIONI_MATERIALI',
	@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_IMMATERIALI 
		AS 'DISINVESTIMENTI_DA_IMMOBILIZZAZIONI_IMMATERIALI',
	@DISINVESTIMENTI_DI_IMMOBILIZZAZIONI_FINANZIARIE 
		AS 'DISINVESTIMENTI_DA_IMMOBILIZZAZIONI_FINANZIARIE',
	@FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_INVESTIMENTO_DISINVESTIMENTO
		AS 'FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_INVESTIMENTO_DISINVESTIMENTO',
	@ATTIVITA_DI_FINANZIAMENTO
		AS 'ATTIVITA'' DI FINANZIAMENTO',
	@AUMENTO_DI_CAPITALE 
		AS 'AUMENTO_DI_CAPITALE (VARIAZIONI DEL PATRIMONIO NETTO)',

	@VARIAZIONE_NETTA_DEI_FINANZIAMENTI_A_MEDIO_LUNGO_TERMINE 
		AS 'VARIAZIONE_NETTA_FINAZIAMENTI_MEDIO_LUNGO_TERMINE',
	@FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_FINANZIAMENTO
		AS 'FLUSSO_MONETARI0_CASH_FLOW_ATTIVITA_FINANZIAMENTO',
	@FLUSSO_MONETARI0_CASH_FLOW_ESERCIZIO_A_B_C 
		AS 'FLUSSO_MONETARI0_CASH_FLOW_ESERCIZIO_A_B_C',
	@DISPONIBILITA_MONETARIA_NETTA_INIZIALE
		AS 'DISPONIBILITA_MONETARIA_NETTA_INIZIALE',
	@DISPONIBILITA_MONETARIA_NETTA_FINALE
		AS 'DISPONIBILITA_MONETARIA_NETTA_FINALE',
	@FLUSSO_MONETARIO_CASH_FLOW_ESERCIZIO
		AS 'FLUSSO_MONETARIO_CASH_FLOW_ESERCIZIO'
	

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
  


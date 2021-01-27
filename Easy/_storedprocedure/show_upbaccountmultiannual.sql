
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbaccountmultiannual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbaccountmultiannual]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- [show_upbaccountmultiannual] {ts '2017-09-12 00:00:00'},'0001000100030001'

CREATE     PROCEDURE [show_upbaccountmultiannual]
	@date datetime,
	@idupb varchar(36)
AS BEGIN


	DECLARE @ayear int
	SET @ayear = YEAR(@date)

	CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

	DECLARE @prevision_to_currentyear_exp_costi decimal(19,2)
	DECLARE @prevision2_exp_costi		decimal(19,2)
	DECLARE @prevision3_exp_costi		decimal(19,2)
	DECLARE @prevision4_exp_costi		decimal(19,2)
	DECLARE @prevision5_exp_costi		decimal(19,2)

	DECLARE @prevision_to_currentyear_exp_investimenti decimal(19,2)
	DECLARE @prevision2_exp_investimenti		decimal(19,2)
	DECLARE @prevision3_exp_investimenti		decimal(19,2)
	DECLARE @prevision4_exp_investimenti		decimal(19,2)
	DECLARE @prevision5_exp_investimenti		decimal(19,2)	
	
	DECLARE @prevision_to_currentyear_acc decimal(19,2)
	DECLARE @prevision2_acc		decimal(19,2)
	DECLARE @prevision3_acc		decimal(19,2)
	DECLARE @prevision4_acc		decimal(19,2)
	DECLARE @prevision5_acc		decimal(19,2)

  	SELECT @prevision_to_currentyear_exp_costi = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear <= @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
		AND isnull(A.flagaccountusage,0)&64<>0 -- costi

  	SELECT @prevision_to_currentyear_exp_investimenti = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear <= @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
		AND isnull(A.flagaccountusage,0)&256<>0 -- investimenti

  	SELECT @prevision_to_currentyear_acc = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear <= @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
		AND isnull(A.flagaccountusage,0)&128<>0
	
	SELECT  
  	@prevision2_exp_costi = ISNULL(SUM(prevision2),0),
  	@prevision3_exp_costi = ISNULL(SUM(prevision3),0),
  	@prevision4_exp_costi = ISNULL(SUM(prevision4),0),
  	@prevision5_exp_costi = ISNULL(SUM(prevision5),0)
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
			AND isnull(A.flagaccountusage,0)&64<>0

	SELECT  
  	@prevision2_exp_investimenti = ISNULL(SUM(prevision2),0),
  	@prevision3_exp_investimenti = ISNULL(SUM(prevision3),0),
  	@prevision4_exp_investimenti = ISNULL(SUM(prevision4),0),
  	@prevision5_exp_investimenti = ISNULL(SUM(prevision5),0)
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
			AND isnull(A.flagaccountusage,0)&256<>0


SELECT  
  	@prevision2_acc = ISNULL(SUM(prevision2),0),
  	@prevision3_acc = ISNULL(SUM(prevision3),0),
  	@prevision4_acc = ISNULL(SUM(prevision4),0),
  	@prevision5_acc = ISNULL(SUM(prevision5),0)
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and flagusable = 'S')
			AND isnull(A.flagaccountusage,0)&128<>0


	DECLARE @previsionvar_to_currentyear_exp_costi decimal(19,2)
	DECLARE @previsionvar2_exp_costi				 decimal(19,2)
	DECLARE @previsionvar3_exp_costi				 decimal(19,2)
	DECLARE @previsionvar4_exp_costi				 decimal(19,2)
	DECLARE @previsionvar5_exp_costi				 decimal(19,2)
  	
	DECLARE @previsionvar_to_currentyear_exp_investimenti decimal(19,2)
	DECLARE @previsionvar2_exp_investimenti				 decimal(19,2)
	DECLARE @previsionvar3_exp_investimenti				 decimal(19,2)
	DECLARE @previsionvar4_exp_investimenti				 decimal(19,2)
	DECLARE @previsionvar5_exp_investimenti				 decimal(19,2)

	DECLARE @previsionvar_to_currentyear_acc decimal(19,2)
	DECLARE @previsionvar2_acc				 decimal(19,2)
	DECLARE @previsionvar3_acc				 decimal(19,2)
	DECLARE @previsionvar4_acc				 decimal(19,2)
	DECLARE @previsionvar5_acc				 decimal(19,2)
  	

  	SELECT @previsionvar_to_currentyear_exp_costi = ISNULL(SUM(d.amount),0) 
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar <= @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&64<>0

			SELECT @previsionvar_to_currentyear_exp_investimenti = ISNULL(SUM(d.amount),0) 
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar <= @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&256<>0

SELECT @previsionvar_to_currentyear_acc = ISNULL(SUM(d.amount),0) 
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar <= @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&128<>0
		
	SELECT  
  	@previsionvar2_exp_costi = ISNULL(SUM(d.amount2),0),
  	@previsionvar3_exp_costi = ISNULL(SUM(d.amount3),0),
  	@previsionvar4_exp_costi = ISNULL(SUM(d.amount4),0),
  	@previsionvar5_exp_costi = ISNULL(SUM(d.amount5),0)
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar = @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&64<>0

	SELECT  
  	@previsionvar2_exp_investimenti = ISNULL(SUM(d.amount2),0),
  	@previsionvar3_exp_investimenti = ISNULL(SUM(d.amount3),0),
  	@previsionvar4_exp_investimenti = ISNULL(SUM(d.amount4),0),
  	@previsionvar5_exp_investimenti = ISNULL(SUM(d.amount5),0)
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar = @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&256<>0

SELECT  
  	@previsionvar2_acc = ISNULL(SUM(d.amount2),0),
  	@previsionvar3_acc = ISNULL(SUM(d.amount3),0),
  	@previsionvar4_acc = ISNULL(SUM(d.amount4),0),
  	@previsionvar5_acc = ISNULL(SUM(d.amount5),0)
	FROM accountvar v
	JOIN accountvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN account c
		ON c.idacc = d.idacc 
	WHERE d.idupb = @idupb
		AND v.yvar = @ayear
		AND v.adate <= @date
		AND v.variationkind <> 5 
		AND v.idaccountvarstatus = 5
		AND isnull(C.flagaccountusage,0)&128<>0
		
	CREATE TABLE #totepexp_to_currentyear_costi (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepexp_to_currentyear_costi
		SELECT epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount else -epexpyear.amount end)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear <= @ayear
			AND epexp.yepexp <=@ayear
			AND epexp.adate <= @date
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
		GROUP BY epexp.nphase
 
	CREATE TABLE #totepexp_to_currentyear_investimenti (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepexp_to_currentyear_investimenti
		SELECT epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount else -epexpyear.amount end)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear <= @ayear
			AND epexp.yepexp <=@ayear
			AND epexp.adate <= @date
		AND (isnull(account.flagaccountusage,0)&128)<>0 -- investimenti
		GROUP BY epexp.nphase
 
	CREATE TABLE #totepacc_to_currentyear (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepacc_to_currentyear
		SELECT epacc.nphase, 
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccyear.amount else -epaccyear.amount end)
		FROM epaccyear
		JOIN epacc
			ON epacc.idepacc = epaccyear.idepacc
		WHERE epaccyear.idupb = @idupb
			AND epaccyear.ayear <= @ayear
			AND epacc.yepacc <=@ayear
			AND epacc.adate <= @date
		GROUP BY epacc.nphase
 
 
 	CREATE TABLE #totepexp_costi (nphase varchar(20) NULL, tot2 decimal(19,2) NULL, 
									 tot3 decimal(19,2) NULL,tot4 decimal(19,2) NULL,tot5 decimal(19,2) NULL)
	INSERT INTO #totepexp_costi
		SELECT epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount2 else -epexpyear.amount2 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount3 else -epexpyear.amount3 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount4 else -epexpyear.amount4 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount5 else -epexpyear.amount5 end)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
		GROUP BY epexp.nphase
 
 
  	CREATE TABLE #totepexp_investimenti (nphase varchar(20) NULL, tot2 decimal(19,2) NULL, 
									 tot3 decimal(19,2) NULL,tot4 decimal(19,2) NULL,tot5 decimal(19,2) NULL)
	INSERT INTO #totepexp_investimenti
		SELECT epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount2 else -epexpyear.amount2 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount3 else -epexpyear.amount3 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount4 else -epexpyear.amount4 end),
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpyear.amount5 else -epexpyear.amount5 end)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
		AND (isnull(account.flagaccountusage,0)&128)<>0 -- investimenti
		GROUP BY epexp.nphase
 
 	CREATE TABLE #totepacc (nphase varchar(20) NULL, tot2 decimal(19,2) NULL, 
									 tot3 decimal(19,2) NULL,tot4 decimal(19,2) NULL,tot5 decimal(19,2) NULL)
	INSERT INTO #totepacc
		SELECT epacc.nphase, 
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccyear.amount2 else -epaccyear.amount2 end),
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccyear.amount3 else -epaccyear.amount3 end),
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccyear.amount4 else -epaccyear.amount4 end),
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccyear.amount5 else -epaccyear.amount5 end)
		FROM epaccyear
		JOIN epacc
			ON epacc.idepacc = epaccyear.idepacc
		WHERE epaccyear.idupb = @idupb
			AND epaccyear.ayear = @ayear
			AND epacc.adate <= @date
		GROUP BY epacc.nphase
	
	-- Variazione Movimenti di spesa esercizio corrente
	CREATE TABLE #totepexpvar_to_currentyear_costi(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepexpvar_to_currentyear_costi
	SELECT 
		epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount else -epexpvar.amount end)
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
			on  epexpyear.idacc=account.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexp.yepexp <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear <= @ayear
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
	GROUP BY epexp.nphase

	CREATE TABLE #totepexpvar_to_currentyear_investimenti(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepexpvar_to_currentyear_investimenti
	SELECT 
		epexp.nphase, 
			SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount else -epexpvar.amount end)
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
			on  epexpyear.idacc=account.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexp.yepexp <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear <= @ayear
		AND (isnull(account.flagaccountusage,0)&128)<>0 -- investimenti
	GROUP BY epexp.nphase

	CREATE TABLE #totepaccvar_to_currentyear(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepaccvar_to_currentyear
	SELECT 
		epacc.nphase, 
			SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccvar.amount else -epaccvar.amount end)
	FROM epaccvar
	JOIN epacc
		ON epacc.idepacc = epaccvar.idepacc
	JOIN epaccyear
		ON epaccyear.idepacc = epaccvar.idepacc
	WHERE epaccvar.adate <= @date
		AND epaccvar.yvar <= @ayear
		AND epacc.yepacc <= @ayear
		AND epaccyear.idupb = @idupb
		AND epaccyear.ayear <= @ayear
	GROUP BY epacc.nphase


	
	-- Variazione Movimenti di spesa esercizio corrente
	CREATE TABLE #totepexpvar_costi(nphase tinyint, tot2 decimal(19,2),tot3 decimal(19,2),tot4 decimal(19,2),tot5 decimal(19,2) )
	INSERT INTO #totepexpvar_costi 
	SELECT 
		epexp.nphase, 
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount2 else -epexpvar.amount2 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount3 else -epexpvar.amount3 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount4 else -epexpvar.amount4 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount5 else -epexpvar.amount5 end)
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
			on  epexpyear.idacc=account.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar = @ayear
		AND epexp.yepexp = @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
	GROUP BY epexp.nphase

	CREATE TABLE #totepexpvar_investimenti(nphase tinyint, tot2 decimal(19,2),tot3 decimal(19,2),tot4 decimal(19,2),tot5 decimal(19,2) )
	INSERT INTO #totepexpvar_investimenti
	SELECT 
		epexp.nphase, 
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount2 else -epexpvar.amount2 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount3 else -epexpvar.amount3 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount4 else -epexpvar.amount4 end),
		SUM(case when isnull(epexp.flagvariation,'N')='N' then epexpvar.amount5 else -epexpvar.amount5 end)
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
			on  epexpyear.idacc=account.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar = @ayear
		AND epexp.yepexp = @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		AND (isnull(account.flagaccountusage,0)&128)<>0 -- investimenti
	GROUP BY epexp.nphase

	CREATE TABLE #totepaccvar(nphase tinyint, tot2 decimal(19,2),tot3 decimal(19,2),tot4 decimal(19,2),tot5 decimal(19,2) )
	INSERT INTO #totepaccvar 
	SELECT 
		epacc.nphase, 
		SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccvar.amount2 else -epaccvar.amount2 end),
		SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccvar.amount3 else -epaccvar.amount3 end),
		SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccvar.amount4 else -epaccvar.amount4 end),
		SUM(case when isnull(epacc.flagvariation,'N')='N' then epaccvar.amount5 else -epaccvar.amount5 end)
	FROM epaccvar
	JOIN epacc
		ON epacc.idepacc = epaccvar.idepacc
	JOIN epaccyear
		ON epaccyear.idepacc = epaccvar.idepacc
	WHERE epaccvar.adate <= @date
		AND epaccvar.yvar = @ayear
		AND epacc.yepacc = @ayear
		AND epaccyear.idupb = @idupb
		AND epaccyear.ayear = @ayear
	GROUP BY epacc.nphase


	DECLARE @departmentname varchar(150)
	SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

	INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
	DECLARE @codeupb varchar(50)
	DECLARE @descupb varchar(150)
	SELECT @codeupb = codeupb, @descupb = title FROM upb WHERE idupb = @idupb
	
	INSERT INTO #situation VALUES ('U.P.B. ' + @codeupb + ' - ' + @descupb, NULL, 'H')
	INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	DECLARE @requested decimal(19,2)
	DECLARE @granted decimal(19,2)
	SELECT @requested = requested, @granted = granted FROM upb WHERE idupb = @idupb
	
	DECLARE @requested_distributed decimal(19,2)
	SELECT @requested_distributed = ISNULL(SUM(requested),0) FROM upb 
					WHERE paridupb = @idupb
	DECLARE @granted_distributed decimal(19,2)
	SELECT @granted_distributed = ISNULL(SUM(granted),0) FROM upb 
					WHERE paridupb = @idupb
					
	DECLARE @showgranted char(1)
	IF (@requested IS NOT NULL) OR (@granted IS NOT NULL)
	BEGIN
		SET @showgranted = 'S'
	END
	ELSE
	BEGIN
		SET @showgranted = 'N'
	END
	
	INSERT INTO #situation VALUES ('', NULL, 'N')

	INSERT INTO #situation VALUES ('B U D G E T', NULL, 'N')
	
	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE --------------------------------
	---------------------------------------------------------------------
 	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision_to_currentyear_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Costi', @previsionvar_to_currentyear_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', ISNULL(@prevision_to_currentyear_exp_costi, 0) + 	ISNULL(@previsionvar_to_currentyear_exp_costi, 0), 'S')
	
	DECLARE @nphase tinyint
	DECLARE @phasedesc varchar(50)
	DECLARE @totbudget_epexp_costi decimal(19,2)
	DECLARE @budget_epexpvar_costi decimal(19,2)
	DECLARE @totbudget_epexp_investimenti decimal(19,2)
	DECLARE @budget_epexpvar_investimenti decimal(19,2)
	DECLARE @totbudget_epacc decimal(19,2)
	DECLARE @budget_epaccvar decimal(19,2)



DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_costi = 0
		SET @budget_epexpvar_costi = 0

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot),0) 	FROM #totepexp_to_currentyear_costi	 WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot),0)	FROM #totepexpvar_to_currentyear_costi WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')
		DECLARE @labelavail varchar(150)
		DECLARE @labelgranted varchar(150)
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision_to_currentyear_exp_costi, 0) + 
		ISNULL(@previsionvar_to_currentyear_exp_costi, 0) - 
		ISNULL(@totbudget_epexp_costi, 0) -
		ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_costi, 0) -
			ISNULL(@budget_epexpvar_costi, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

	INSERT INTO #situation VALUES ('', NULL, 'N')
-------------------investimenti ---------------
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision_to_currentyear_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Investimenti', @previsionvar_to_currentyear_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', ISNULL(@prevision_to_currentyear_exp_investimenti, 0) + 	ISNULL(@previsionvar_to_currentyear_exp_investimenti, 0), 'S')
	
DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_investimenti = 0
		SET @budget_epexpvar_investimenti = 0

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot),0) 	FROM #totepexp_to_currentyear_investimenti	 WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot),0)	FROM #totepexpvar_to_currentyear_investimenti WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')
		---DECLARE @labelavail varchar(150)
		
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision_to_currentyear_exp_investimenti, 0) + 
		ISNULL(@previsionvar_to_currentyear_exp_investimenti, 0) - 
		ISNULL(@totbudget_epexp_investimenti, 0) -
		ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_investimenti, 0) -
			ISNULL(@budget_epexpvar_investimenti, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

----------------------
		INSERT INTO #situation VALUES ('', NULL, 'N')

	INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision_to_currentyear_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Ricavi', @previsionvar_to_currentyear_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', ISNULL(@prevision_to_currentyear_acc, 0) + 	ISNULL(@previsionvar_to_currentyear_acc, 0), 'S')


DECLARE phase_crs_acc INSENSITIVE CURSOR FOR
WITH epaccphase (nphase, description)
AS 
(
    SELECT  1, 'Preaccertamento'
    UNION
    SELECT  2, 'Accertamento'
)
SELECT nphase, description  from epaccphase 
	FOR READ ONLY
	OPEN phase_crs_acc
	FETCH NEXT FROM phase_crs_acc INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epacc = 0
		SET @budget_epaccvar = 0

		SELECT @totbudget_epacc = ISNULL(SUM(tot),0) 	FROM #totepacc_to_currentyear	 WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot),0)	FROM #totepaccvar_to_currentyear WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')
		DECLARE @labelavail_acc varchar(150)
		SET @labelavail_acc = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelavail_acc = @labelavail + ')'
	
		INSERT INTO #situation VALUES(@labelavail_acc, 
		ISNULL(@prevision_to_currentyear_acc, 0) + 
		ISNULL(@previsionvar_to_currentyear_acc, 0) - 
		ISNULL(@totbudget_epacc, 0) -
		ISNULL(@budget_epaccvar, 0) , 'S')
	
		FETCH NEXT FROM phase_crs_acc INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs_acc

		INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 1 --------------COSTI -------------
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear +1), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision2_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Costi', @previsionvar2_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', ISNULL(@prevision2_exp_costi, 0) + ISNULL(@previsionvar2_exp_costi, 0), 'S')
	
DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_costi = 0
		SET @budget_epexpvar_costi = 0

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot2),0) 		FROM #totepexp_costi	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot2),0)	FROM #totepexpvar_costi		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision2_exp_costi, 0) + 
		ISNULL(@previsionvar2_exp_costi, 0) - 
		ISNULL(@totbudget_epexp_costi, 0) -

		ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_costi, 0) -
			ISNULL(@budget_epexpvar_costi, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

		INSERT INTO #situation VALUES ('', NULL, 'N')

		---------------
			---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 1 --------------investimenti -------------
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear +1), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision2_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Investimenti', @previsionvar2_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', ISNULL(@prevision2_exp_investimenti, 0) + ISNULL(@previsionvar2_exp_investimenti, 0), 'S')
	
DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_investimenti = 0
		SET @budget_epexpvar_investimenti = 0

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot2),0) 		FROM #totepexp_investimenti	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot2),0)	FROM #totepexpvar_investimenti		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision2_exp_investimenti, 0) + 
		ISNULL(@previsionvar2_exp_investimenti, 0) - 
		ISNULL(@totbudget_epexp_investimenti, 0) -

		ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_investimenti, 0) -
			ISNULL(@budget_epexpvar_investimenti, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

		INSERT INTO #situation VALUES ('', NULL, 'N')
		--------------
	INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision2_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Ricavi', @previsionvar2_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', ISNULL(@prevision2_acc, 0) + ISNULL(@previsionvar2_acc, 0), 'S')

DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epaccphase (nphase, description)
AS 
(
    SELECT  1, 'Preaccertamento'
    UNION
    SELECT  2, 'Accertamento'
)
SELECT nphase, description  from epaccphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epacc = 0
		SET @budget_epaccvar = 0

		SELECT @totbudget_epacc = ISNULL(SUM(tot2),0) 		FROM #totepacc	WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot2),0)	FROM #totepaccvar		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'		
		SET @labelavail = @labelavail + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision2_acc, 0) + 
		ISNULL(@previsionvar2_acc, 0) - 
		ISNULL(@totbudget_epacc, 0) -
		ISNULL(@budget_epaccvar, 0) , 'S')
	
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

		INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 2 ---------------------------costi ---------
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear + 2), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision3_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Costi', @previsionvar3_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', ISNULL(@prevision3_exp_costi, 0) + ISNULL(@previsionvar3_exp_costi, 0), 'S')


DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_costi = 0
		SET @budget_epexpvar_costi = 0

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot3),0) 		FROM #totepexp_costi	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot3),0)	FROM #totepexpvar_costi		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')


		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision3_exp_costi, 0) + 
		ISNULL(@previsionvar3_exp_costi, 0) - 
		ISNULL(@totbudget_epexp_costi, 0) -

		ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_costi, 0) -
			ISNULL(@budget_epexpvar_costi, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
	
		---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 2 ---------------------------
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear + 2), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision3_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Investimenti', @previsionvar3_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', ISNULL(@prevision3_exp_investimenti, 0) + ISNULL(@previsionvar3_exp_investimenti, 0), 'S')


DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_investimenti = 0
		SET @budget_epexpvar_investimenti = 0

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot3),0) 		FROM #totepexp_investimenti	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot3),0)	FROM #totepexpvar_investimenti		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')


		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision3_exp_investimenti, 0) + 
		ISNULL(@previsionvar3_exp_investimenti, 0) - 
		ISNULL(@totbudget_epexp_investimenti, 0) -

		ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_investimenti, 0) -
			ISNULL(@budget_epexpvar_investimenti, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
	
	------------------------------
		INSERT INTO #situation VALUES ('', NULL, 'N')
		INSERT INTO #situation VALUES ('', NULL, 'N')

	INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision3_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Ricavi', @previsionvar3_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', ISNULL(@prevision3_acc, 0) + ISNULL(@previsionvar3_acc, 0), 'S')

	DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epaccphase (nphase, description)
AS 
(
    SELECT  1, 'Preaccertamento'
    UNION
    SELECT  2, 'Accertamento'
)
SELECT nphase, description  from epaccphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epacc = 0
		SET @budget_epaccvar = 0

		SELECT @totbudget_epacc = ISNULL(SUM(tot3),0) 		FROM #totepacc	WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot3),0)	FROM #totepaccvar		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')


		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelavail = @labelavail + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision3_acc, 0) + 
		ISNULL(@previsionvar3_acc, 0) - 
		ISNULL(@totbudget_epacc, 0) -

		ISNULL(@budget_epaccvar, 0) , 'S')
			
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
	


		INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 3 ---------------------------COSTI
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear +3), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision4_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Costi', @previsionvar4_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', ISNULL(@prevision4_exp_costi, 0) + ISNULL(@previsionvar4_exp_costi, 0), 'S')
	

DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_costi = 0
		SET @budget_epexpvar_costi = 0

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot4),0) 	FROM #totepexp_costi	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot4),0)	FROM #totepexpvar_costi		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
			
				
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
		
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision4_exp_costi, 0) + 
		ISNULL(@previsionvar4_exp_costi, 0) - 
		ISNULL(@totbudget_epexp_costi, 0) -

		ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_costi, 0) -
			ISNULL(@budget_epexpvar_costi, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
		INSERT INTO #situation VALUES ('', NULL, 'N')

	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 3 ---------------------------Investimenti
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear +3), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision4_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Investimenti', @previsionvar4_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', ISNULL(@prevision4_exp_investimenti, 0) + ISNULL(@previsionvar4_exp_investimenti, 0), 'S')
	

DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_investimenti = 0
		SET @budget_epexpvar_investimenti = 0

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot4),0) 	FROM #totepexp_investimenti	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot4),0)	FROM #totepexpvar_investimenti		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
			
				
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
		
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision4_exp_investimenti, 0) + 
		ISNULL(@previsionvar4_exp_investimenti, 0) - 
		ISNULL(@totbudget_epexp_investimenti, 0) -

		ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_investimenti, 0) -
			ISNULL(@budget_epexpvar_investimenti, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
		INSERT INTO #situation VALUES ('', NULL, 'N')
		----------------------------------------
	

	INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision4_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Ricavi', @previsionvar4_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', ISNULL(@prevision4_acc, 0) + ISNULL(@previsionvar4_acc, 0), 'S')

DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epaccphase (nphase, description)
AS 
(
    SELECT  1, 'Preaccertamento'
    UNION
    SELECT  2, 'Accertamento'
)
SELECT nphase, description  from epaccphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epacc = 0
		SET @budget_epaccvar = 0

		SELECT @totbudget_epacc = ISNULL(SUM(tot4),0) 	FROM #totepacc	WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot4),0)	FROM #totepaccvar		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelavail = @labelavail + ')'
		
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision4_acc, 0) + 
		ISNULL(@previsionvar4_acc, 0) - 
		ISNULL(@totbudget_epacc, 0) -

		ISNULL(@budget_epaccvar, 0) , 'S')
	
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

		INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')

	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 4 ---------------------------COSTI
	---------------------------------------------------------------------
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear + 4), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision5_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Costi', @previsionvar5_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', ISNULL(@prevision5_exp_costi, 0) + ISNULL(@previsionvar5_exp_costi, 0), 'S')


DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_costi = 0
		SET @budget_epexpvar_costi = 0

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot5),0) 		FROM #totepexp_costi	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot5),0)	FROM #totepexpvar_costi		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision5_exp_costi, 0) + 
		ISNULL(@previsionvar5_exp_costi, 0) - 
		ISNULL(@totbudget_epexp_costi, 0) -

		ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_costi, 0) -
			ISNULL(@budget_epexpvar_costi, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
	---------------------------------------------------------------------
	----------------- ESERCIZIO CORRENTE  + 4 ---------------------------investimenti
	---------------------------------------------------------------------
INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear + 4), NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision5_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Investimenti', @previsionvar5_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', ISNULL(@prevision5_exp_investimenti, 0) + ISNULL(@previsionvar5_exp_investimenti, 0), 'S')


DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epexpphase (nphase, description)
AS 
(
    SELECT  1, 'Preimpegno'
    UNION
    SELECT  2, 'Impegno'
)
SELECT nphase, description  from epexpphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epexp_investimenti = 0
		SET @budget_epexpvar_investimenti = 0

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot5),0) 		FROM #totepexp_investimenti	WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot5),0)	FROM #totepexpvar_investimenti		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision5_exp_investimenti, 0) + 
		ISNULL(@previsionvar5_exp_investimenti, 0) - 
		ISNULL(@totbudget_epexp_investimenti, 0) -

		ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epexp_investimenti, 0) -
			ISNULL(@budget_epexpvar_investimenti, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs
		
		INSERT INTO #situation VALUES ('', NULL, 'N')

		INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision5_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Ricavi', @previsionvar5_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', ISNULL(@prevision5_acc, 0) + ISNULL(@previsionvar5_acc, 0), 'S')

	
DECLARE phase_crs INSENSITIVE CURSOR FOR
WITH epaccphase (nphase, description)
AS 
(
    SELECT  1, 'Preaccertamento'
    UNION
    SELECT  2, 'Accertamento'
)
SELECT nphase, description  from epaccphase 
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @totbudget_epacc = 0
		SET @budget_epaccvar = 0

		SELECT @totbudget_epacc = ISNULL(SUM(tot5),0) 		FROM #totepacc	WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot5),0)	FROM #totepaccvar		WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')

		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, 
		ISNULL(@prevision5_acc, 0) + 
		ISNULL(@previsionvar5_acc, 0) - 
		ISNULL(@totbudget_epacc, 0) -

		ISNULL(@budget_epaccvar, 0) , 'S')
	
		IF (@showgranted = 'S')
		BEGIN
			INSERT INTO #situation VALUES(@labelgranted,
			ISNULL(@granted, 0) - 
			ISNULL(@totbudget_epacc, 0) -
			ISNULL(@budget_epaccvar, 0) ,'S')
		END
		FETCH NEXT FROM phase_crs INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs

	SELECT value, amount, kind FROM #situation
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


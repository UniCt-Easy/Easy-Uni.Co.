
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbaccountannual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbaccountannual]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [show_upbaccountannual]
	@date datetime,
	@idupb varchar(36)
AS BEGIN

-- [show_upbaccountannual] {ts '2017-09-12 00:00:00'},'0001000100030001'
	DECLARE @ayear int
	SET @ayear = YEAR(@date)

	CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

	DECLARE @prevision_currentyear_exp_costi decimal(19,2)
	DECLARE @prevision_currentyear_exp_investimenti decimal(19,2)
	DECLARE @prevision_currentyear_acc decimal(19,2)
 

  	SELECT @prevision_currentyear_exp_costi = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and accountlevel.flagusable = 'S')
		AND (isnull(A.flagaccountusage,0)&64)<>0

  	SELECT @prevision_currentyear_exp_investimenti = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and accountlevel.flagusable = 'S')
		AND (isnull(A.flagaccountusage,0)&256)<>0

  	SELECT @prevision_currentyear_acc = ISNULL(SUM(prevision),0) 
	FROM accountyearview
	join account A on A.idacc=accountyearview.idacc
	WHERE idupb = @idupb
		AND accountyearview.ayear = @ayear
		AND A.nlevel = (SELECT MIN(accountlevel.nlevel) FROM accountlevel 
			WHERE ayear = accountyearview.ayear and accountlevel.flagusable = 'S')
			AND (isnull(A.flagaccountusage,0)&128)<>0

			
	DECLARE @previsionvar_currentyear_exp_costi decimal(19,2)
	DECLARE @previsionvar_currentyear_exp_investimenti decimal(19,2)
	DECLARE @previsionvar_currentyear_acc decimal(19,2)

  	SELECT @previsionvar_currentyear_exp_costi = ISNULL(SUM(d.amount),0) 
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
		AND (isnull(c.flagaccountusage,0)&64)<>0 -- costi

  	SELECT @previsionvar_currentyear_exp_investimenti = ISNULL(SUM(d.amount),0) 
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
		AND (isnull(c.flagaccountusage,0)&256)<>0 -- investimenti

	SELECT @previsionvar_currentyear_acc = ISNULL(SUM(d.amount),0) 
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
		AND (isnull(c.flagaccountusage,0)&128)<>0


	CREATE TABLE #totepexp_currentyear_costi (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepexp_currentyear_costi
		SELECT epexp.nphase, 
			SUM(epexpyear.amount)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
			and epexp.flagvariation='N'
			AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
		GROUP BY epexp.nphase
	

	INSERT INTO  #totepexp_currentyear_costi
		SELECT epexp.nphase, 
			-SUM(epexpyear.amount)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
			and epexp.flagvariation='S'
			AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
		GROUP BY epexp.nphase

	CREATE TABLE #totepexp_currentyear_investimenti (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepexp_currentyear_investimenti
		SELECT epexp.nphase, 
			SUM(epexpyear.amount)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
			and epexp.flagvariation='N'
			AND (isnull(account.flagaccountusage,0)&256)<>0 -- investimenti
		GROUP BY epexp.nphase
	
	
	INSERT INTO  #totepexp_currentyear_investimenti
		SELECT epexp.nphase, 
			-SUM(epexpyear.amount)
		FROM epexpyear
		JOIN epexp
			ON epexp.idepexp = epexpyear.idepexp
		join account 
			on  epexpyear.idacc=account.idacc
		WHERE epexpyear.idupb = @idupb
			AND epexpyear.ayear = @ayear
			AND epexp.adate <= @date
			and epexp.flagvariation='S'
			AND (isnull(account.flagaccountusage,0)&256)<>0 -- investimenti
		GROUP BY epexp.nphase

	CREATE TABLE #totepacc_currentyear (nphase varchar(20) NULL,tot decimal(19,2) NULL)
	INSERT INTO  #totepacc_currentyear
		SELECT epacc.nphase, 
			SUM(epaccyear.amount)
		FROM epaccyear
		JOIN epacc
			ON epacc.idepacc = epaccyear.idepacc
		WHERE epaccyear.idupb = @idupb
			AND epaccyear.ayear = @ayear
			AND epacc.adate <= @date
			and epacc.flagvariation='N'
		GROUP BY epacc.nphase
	
	INSERT INTO  #totepacc_currentyear
		SELECT epacc.nphase, 
			-SUM(epaccyear.amount)
		FROM epaccyear
		JOIN epacc
			ON epacc.idepacc = epaccyear.idepacc
		WHERE epaccyear.idupb = @idupb
			AND epaccyear.ayear = @ayear
			AND epacc.adate <= @date
			and epacc.flagvariation='A'
		GROUP BY epacc.nphase
	


	-- Variazione Movimenti di spesa esercizio corrente
	CREATE TABLE #totepexpvar_currentyear_costi(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepexpvar_currentyear_costi
	SELECT 
		epexp.nphase, 
		ISNULL(SUM(epexpvar.amount),0)  
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
		on account.idacc = epexpyear.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		and epexp.flagvariation='N'
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
	GROUP BY epexp.nphase
	
	INSERT INTO #totepexpvar_currentyear_costi
	SELECT 
		epexp.nphase, 
		-ISNULL(SUM(epexpvar.amount),0)  
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
		on account.idacc = epexpyear.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		and epexp.flagvariation='S'
		AND (isnull(account.flagaccountusage,0)&64)<>0 -- costi
	GROUP BY epexp.nphase

	CREATE TABLE #totepexpvar_currentyear_investimenti(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepexpvar_currentyear_investimenti
	SELECT 
		epexp.nphase, 
		ISNULL(SUM(epexpvar.amount),0)  
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
		on account.idacc = epexpyear.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		and epexp.flagvariation='N'
		AND (isnull(account.flagaccountusage,0)&256)<>0 -- investimenti
	GROUP BY epexp.nphase
	
	INSERT INTO #totepexpvar_currentyear_investimenti
	SELECT 
		epexp.nphase, 
		-ISNULL(SUM(epexpvar.amount),0)  
	FROM epexpvar
	JOIN epexp
		ON epexp.idepexp = epexpvar.idepexp
	JOIN epexpyear
		ON epexpyear.idepexp = epexpvar.idepexp
	join account 
		on account.idacc = epexpyear.idacc
	WHERE epexpvar.adate <= @date
		AND epexpvar.yvar <= @ayear
		AND epexpyear.idupb = @idupb
		AND epexpyear.ayear = @ayear
		and epexp.flagvariation='S'
		AND (isnull(account.flagaccountusage,0)&256)<>0 -- investimenti
	GROUP BY epexp.nphase

	CREATE TABLE #totepaccvar_currentyear(nphase tinyint, tot decimal(19,2))
	INSERT INTO #totepaccvar_currentyear
	SELECT 
		epacc.nphase, 
		ISNULL(SUM(epaccvar.amount),0)  
	FROM epaccvar
	JOIN epacc
		ON epacc.idepacc = epaccvar.idepacc
	JOIN epaccyear
		ON epaccyear.idepacc = epaccvar.idepacc
	WHERE epaccvar.adate <= @date
		AND epaccvar.yvar <= @ayear
		AND epaccyear.idupb = @idupb
		AND epaccyear.ayear = @ayear
		and epacc.flagvariation='N'
	GROUP BY epacc.nphase



	DECLARE @departmentname varchar(150)
	SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'Manca Cfg. Parametri Tutte le stampe')

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
	-- sezione COSTI
 	INSERT INTO #situation VALUES ('ESERCIZIO ' + CONVERT(VARCHAR(4),@ayear), NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Costi', @prevision_currentyear_exp_costi, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Costi', @previsionvar_currentyear_exp_costi, '')
	INSERT INTO #situation VALUES ('Budget Attuale Costi', 	ISNULL(@prevision_currentyear_exp_costi, 0) + 	ISNULL(@previsionvar_currentyear_exp_costi, 0), 'S')
	
	DECLARE @nphase tinyint
	DECLARE @phasedesc varchar(50)
	DECLARE @totbudget_epexp_costi decimal(19,2)
	DECLARE @budget_epexpvar_costi decimal(19,2)

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

		SELECT @totbudget_epexp_costi = ISNULL(SUM(tot),0) 	FROM #totepexp_currentyear_costi	 WHERE nphase = @nphase 
		SELECT @budget_epexpvar_costi = ISNULL(SUM(tot),0)	FROM #totepexpvar_currentyear_costi WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_costi, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_costi, '')
		DECLARE @labelavail varchar(150)
		DECLARE @labelgranted varchar(150)
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, ISNULL(@prevision_currentyear_exp_costi, 0) + ISNULL(@previsionvar_currentyear_exp_costi, 0) - 
								ISNULL(@totbudget_epexp_costi, 0) -	ISNULL(@budget_epexpvar_costi, 0) , 'S')
	
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

---- sezione INVESTIMENTI
 	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Investimenti', @prevision_currentyear_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Investimenti', @previsionvar_currentyear_exp_investimenti, '')
	INSERT INTO #situation VALUES ('Budget Attuale Investimenti', 	ISNULL(@prevision_currentyear_exp_investimenti, 0) + ISNULL(@previsionvar_currentyear_exp_investimenti, 0), 'S')
	

	DECLARE @totbudget_epexp_investimenti decimal(19,2)
	DECLARE @budget_epexpvar_investimenti decimal(19,2)


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

		SELECT @totbudget_epexp_investimenti = ISNULL(SUM(tot),0) 	FROM #totepexp_currentyear_investimenti	 WHERE nphase = @nphase 
		SELECT @budget_epexpvar_investimenti = ISNULL(SUM(tot),0)	FROM #totepexpvar_currentyear_investimenti WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('1.Totale movimenti (' + @phasedesc+ ')', @totbudget_epexp_investimenti, '')
		INSERT INTO #situation VALUES('2.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epexpvar_investimenti, '')
		--DECLARE @labelavail varchar(150)
		SET @labelavail = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 1 - 2'
		SET @labelgranted = 'Finanziamento concesso disponibile (' + @phasedesc + ') (Fin. Acc. - 1 -2'
		
		SET @labelavail = @labelavail + ')'
		SET @labelgranted = @labelgranted + ')'
	
		INSERT INTO #situation VALUES(@labelavail, ISNULL(@prevision_currentyear_exp_investimenti, 0) + ISNULL(@previsionvar_currentyear_exp_investimenti, 0) - 
								ISNULL(@totbudget_epexp_investimenti, 0) -	ISNULL(@budget_epexpvar_investimenti, 0) , 'S')
	
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
----------------------------------------------	
	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES ('Budget Iniziale Ricavi', @prevision_currentyear_acc, '')
	INSERT INTO #situation VALUES ('Variazioni Budget Ricavi', @previsionvar_currentyear_acc, '')
	INSERT INTO #situation VALUES ('Budget Attuale Ricavi', 	ISNULL(@prevision_currentyear_acc, 0) + 	ISNULL(@previsionvar_currentyear_acc, 0), 'S')


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

		SELECT @totbudget_epacc = ISNULL(SUM(tot),0) 	FROM #totepacc_currentyear	 WHERE nphase = @nphase 
		SELECT @budget_epaccvar = ISNULL(SUM(tot),0)	FROM #totepaccvar_currentyear WHERE nphase = @nphase
			
		INSERT INTO #situation VALUES('3.Totale movimenti (' + @phasedesc+ ')', @totbudget_epacc, '')
		INSERT INTO #situation VALUES('4.Totale variazioni movimenti (' + @phasedesc + ')', @budget_epaccvar, '')
		DECLARE @labelavail_acc varchar(150)		
		SET @labelavail_acc = 'Budget disponibile (' + @phasedesc + ') (Budget Att. - 3 - 4'
		
		SET @labelavail_acc = @labelavail_acc + ')'
	
		INSERT INTO #situation VALUES(@labelavail_acc, 
		ISNULL(@prevision_currentyear_acc, 0) + ISNULL(@previsionvar_currentyear_acc, 0) - ISNULL(@totbudget_epacc, 0) -ISNULL(@budget_epaccvar, 0) , 'S')
	
		FETCH NEXT FROM phase_crs_acc INTO @nphase, @phasedesc
	END
	DEALLOCATE phase_crs_acc
	
	SELECT value, amount, kind FROM #situation
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




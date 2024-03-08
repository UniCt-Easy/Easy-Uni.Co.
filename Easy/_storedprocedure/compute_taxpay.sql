
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_taxpay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_taxpay]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [compute_taxpay]
(	
	@ayear int,
	@taxcode int,
	@stop datetime
)
AS BEGIN


DECLARE @ayear_start int
set @ayear_start =year(@stop)			--anno inizio = anno data stop

DECLARE @start datetime
SET @start = CONVERT(datetime, '01-01-' + CONVERT(varchar(4), @ayear_start), 105)	--data inizio = 1/1/anno inizio

--setuser 'amministrazione'
-- compute_taxpay 2021, 17,'31-12-2021'
/* Versione 1.0.2 del 18/11/2008 ultima modifica: SARA */
CREATE TABLE #automov
(
	movkind varchar(128),
	idreg int,
	idfin int,
	idupb varchar(36),
	idman int,
	amount decimal(19,2),
	competencydate datetime,
	idexp int,
	payee_title varchar(100),
	location varchar(200),
	idcity int,
	idfiscaltaxregion varchar(20),
	sourcekind char(1),
	fiscaltaxcode varchar(20),
	ayear int,
	refmonth int,
	idser int
)

CREATE TABLE #percentage_rip
(
	idreg int,
	quota float
)

DECLARE @mainupb varchar(36)
SET @mainupb = '0001'

DECLARE @mainidman int	
SELECT @mainidman = idman FROM upb WHERE idupb = @mainupb

DECLARE @tax varchar(50)
DECLARE @taxref varchar(20)
SELECT @tax = description, @taxref = taxref
FROM tax WHERE taxcode = @taxcode

DECLARE @employtaxkind char(1)
DECLARE @admintaxkind char(1)
SELECT 
@admintaxkind = 
CASE
	WHEN (automanagekind & 1) <> 0 THEN '0'
	WHEN (automanagekind & 2) <> 0 THEN '1'
	WHEN (automanagekind & 4) <> 0 THEN '2'
	WHEN (automanagekind & 8) <> 0 THEN '3'
END,
@employtaxkind = 
CASE
	WHEN (automanagekind & 256) <> 0 THEN '0'
	WHEN (automanagekind & 512) <> 0 THEN '0'
	WHEN (automanagekind & 1024) <> 0 THEN '0'
END
FROM config WHERE ayear = @ayear

DECLARE @flag tinyint
DECLARE @idfinexpensecontra int
DECLARE @idfinexpensecontraemploy int

DECLARE @idfinadmintax int

SELECT
@flag = taxsetup.flag
FROM taxsetup 
WHERE taxsetup.taxcode = @taxcode	AND taxsetup.ayear = @ayear


DECLARE @payee_title varchar(50)
DECLARE @idexp int
DECLARE @idreg int
DECLARE @idser int
DECLARE @idreg_cursor int
DECLARE @idfinexpense int
DECLARE @idupbexpense varchar(31)
DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)
DECLARE @idregion int
DECLARE @idcountry int
DECLARE @flagforeign char(1)
DECLARE @location varchar(200)
DECLARE @tmp_idfin_employ int
DECLARE @tmp_idfin_admin int
DECLARE @tmp_idupb_employ varchar(36)
DECLARE @tmp_idupb_admin varchar(36)
DECLARE @tmp_idman_employ int
DECLARE @tmp_idman_admin int
DECLARE @idmanexpense int
DECLARE @competencydate datetime

DECLARE @idcity int
DECLARE @idfiscaltaxregion varchar(5)

DECLARE @sourcekind char(1)
DECLARE @fiscaltaxcode varchar(20)
DECLARE @fiscalyear int
DECLARE @refmonth int

DECLARE #tax_crs INSENSITIVE CURSOR FOR
SELECT
	expensetaxview.datetaxpay AS datetaxpay, registry.title AS title, expensetaxview.idexp AS idexp, 
	CASE 
		WHEN @ayear = expenseyear.ayear THEN expenseyear.idfin
		WHEN @ayear = expenseyear.ayear + 1 THEN finlookup.newidfin
		ELSE expenseyear.idfin
	END, expenseyear.idupb, expense.idman,
	ISNULL(SUM(expensetaxview.employtax), 0) AS employtax,
	ISNULL(SUM(expensetaxview.admintax), 0) AS admintax,
	expense.idreg, expenselast.idser,
	expensetaxview.idcity, expensetaxview.idfiscaltaxregion, 'R' AS sourcekind,
	tax.fiscaltaxcode, expensetaxview.ayear,
	--CASE
	--	WHEN expensetaxview.ayear < @ayear THEN 12 ELSE
	MONTH(paymenttransmission.transmissiondate)
	--END
	AS refmonth
FROM expensetaxview
JOIN expense				ON expense.idexp = expensetaxview.idexp
JOIN expenseyear			ON expenseyear.idexp = expense.idexp
LEFT OUTER JOIN finlookup ON expenseyear.idfin = finlookup.oldidfin
JOIN expenselast			ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment		ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry				ON expense.idreg = registry.idreg
LEFT OUTER JOIN tax						ON tax.taxcode = expensetaxview.taxcode
WHERE expenseyear.ayear = @ayear_start 
	AND ISNULL(tax.maintaxcode,tax.taxcode) = @taxcode
	AND expensetaxview.ytaxpay IS NULL
	AND expensetaxview.datetaxpay BETWEEN @start AND @stop
	AND
	(
		(
			(expensetaxview.idinc IS NULL)
			AND (ISNULL(expensetaxview.admintax,0) + 
			ISNULL(expensetaxview.employtax,0)) < 0
		)
		OR (ISNULL(expensetaxview.admintax,0) + 
		ISNULL(expensetaxview.employtax,0)) > 0
	)
		 
GROUP BY
	expensetaxview.competencydate, registry.title, expensetaxview.ayear,expenseyear.ayear,
	expensetaxview.idexp,expenseyear.idfin,finlookup.newidfin,expenseyear.idupb, expense.idman, expensetaxview.datetaxpay,
	expense.idreg, expenselast.idser, expensetaxview.idcity, expensetaxview.idfiscaltaxregion, tax.fiscaltaxcode,
	paymenttransmission.transmissiondate
UNION ALL
SELECT
	expensetaxcorrige.adate AS datetaxpay,
	registry.title AS title,
	expensetaxcorrige.idexp AS idexp, 
	CASE 
		WHEN @ayear = expenseyear.ayear THEN expenseyear.idfin
		WHEN @ayear = expenseyear.ayear + 1 THEN finlookup.newidfin
		ELSE expenseyear.idfin
	END, expenseyear.idupb, expense.idman,
	ISNULL(SUM(expensetaxcorrige.employamount), 0) AS employtax,
	ISNULL(SUM(expensetaxcorrige.adminamount), 0) AS admintax,
	expense.idreg, expenselast.idser,
	expensetaxcorrige.idcity, expensetaxcorrige.idfiscaltaxregion, 'C' AS sourcekind,
	tax.fiscaltaxcode, expensetaxcorrige.ayear,
	--CASE
	--	WHEN expensetaxcorrige.ayear < @ayear THEN 12 ELSE
	MONTH(expensetaxcorrige.adate)
	--END 
	AS refmonth
FROM expensetaxcorrige
JOIN expense					ON expense.idexp = expensetaxcorrige.idexp
JOIN expenseyear				ON expenseyear.idexp = expense.idexp
LEFT OUTER JOIN finlookup ON expenseyear.idfin = finlookup.oldidfin
JOIN expenselast				ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment			ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry				ON expense.idreg = registry.idreg
LEFT OUTER JOIN tax						ON tax.taxcode = expensetaxcorrige.taxcode
WHERE --expenseyear.ayear = @ayear_start AND[16412]
	ISNULL(tax.maintaxcode,tax.taxcode) = @taxcode
	AND expensetaxcorrige.ytaxpay IS NULL
	AND expensetaxcorrige.adate IS NOT NULL
	--AND expensetaxcorrige.ayear = @ayear
	AND expensetaxcorrige.adate BETWEEN @start AND @stop
	AND (
		(
			(expensetaxcorrige.linkedidinc IS NULL)
			AND (ISNULL(expensetaxcorrige.adminamount,0) + 
			ISNULL(expensetaxcorrige.employamount,0)) < 0
		)
		OR
		(
			ISNULL(expensetaxcorrige.adminamount,0) + 
			ISNULL(expensetaxcorrige.employamount,0) > 0
		)
	)

GROUP BY
	expensetaxcorrige.adate, registry.title, expensetaxcorrige.ayear,expenseyear.ayear,
	expensetaxcorrige.idexp,expenseyear.idfin,finlookup.newidfin, expenseyear.idupb, expense.idman, 
	expense.idreg, expenselast.idser,expensetaxcorrige.idcity, expensetaxcorrige.idfiscaltaxregion, tax.fiscaltaxcode,
	paymenttransmission.transmissiondate
ORDER BY idexp
FOR READ ONLY

OPEN #tax_crs

FETCH NEXT FROM #tax_crs 
INTO @competencydate, @payee_title, @idexp, @idfinexpense, @idupbexpense, @idmanexpense,
	@employtax, @admintax, @idreg_cursor, @idser, @idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
	@fiscalyear, @refmonth
WHILE (@@FETCH_STATUS = 0)
BEGIN


	SELECT
	@idfinexpensecontra = isnull(F1.idfin,taxsetup.idfinexpensecontra),
	@idfinexpensecontraemploy = isnull(F2.idfin,taxsetup.idfinexpenseemploy),
	@idfinadmintax =  isnull(F3.idfin,taxsetup.idfinadmintax)
	FROM taxsetup 
		left outer join taxfinmotive on taxfinmotive.taxcode=taxsetup.taxcode and taxfinmotive.idser = @idser
		left outer join finmotivedetail F1 on F1.idfinmotive = taxfinmotive.idmotexpensecontra and F1.ayear=@ayear
		left outer join finmotivedetail F2 on F2.idfinmotive = taxfinmotive.idmotexpenseemploy and F2.ayear=@ayear
		left outer join finmotivedetail F3 on F3.idfinmotive = taxfinmotive.idmotadmintax and F3.ayear=@ayear	
	WHERE taxsetup.taxcode = @taxcode	AND taxsetup.ayear = @ayear


	SET @location = NULL
	IF  ((@flag&1) <> 0)
	BEGIN
	SELECT 
		@idreg = taxsetup.paymentagency
		FROM taxsetup
		WHERE taxsetup.taxcode = @taxcode AND taxsetup.ayear = @ayear
	END
		
	IF ((@flag&2) <> 0)
	BEGIN
		SELECT @idregion = 
		CASE
			WHEN idcountry IS NOT NULL THEN
			(SELECT idregion FROM geo_country WHERE geo_country.idcountry = fiscaltaxregion.idcountry)
			ELSE idregion
		END
		FROM fiscaltaxregion
		WHERE idfiscaltaxregion = @idfiscaltaxregion

		SELECT @idcountry = idcountry
		FROM geo_city
		WHERE idcity = @idcity

		SELECT
			@idreg = taxregionsetupview.regionalagency,
			@location = taxregionsetupview.place
		FROM taxregionsetupview
		WHERE taxregionsetupview.taxcode = @taxcode
			AND taxregionsetupview.ayear = @ayear
			AND 
			(((taxregionsetupview.idplace = @idregion) AND (taxregionsetupview.kind ='R')) 
			OR
			((taxregionsetupview.idplace = @idcountry) AND (taxregionsetupview.kind ='P')))
	END
		
	IF  ((@flag&4) <> 0)
	BEGIN
		DELETE FROM #percentage_rip
	
		INSERT INTO #percentage_rip (idreg,quota)
		SELECT idreg, percentage FROM taxpaymentpartsetup
		WHERE taxcode = @taxcode AND ayear = @ayear
	END
		
	--calcola il capitolo di per il versamento della parte DIPENDENTE
	IF @employtaxkind = '2' 
	BEGIN
		--CREA UN MOVIMENTO DIRETTAMENTE ALL'ENTE
		--LE RITENUTE SONO VERSATE  SUL CAPITOLO DEL MOVIMENTO DI SPESA
		SET @tmp_idfin_employ = @idfinexpense
		SET @tmp_idupb_employ = @idupbexpense
		SET @tmp_idman_employ = @idmanexpense
	END
	ELSE
	BEGIN
		--ALTRIMENTI					
		--LE RITENUTE SONO VERSATE SUL CAPITOLO DELLA PARTITA DI GIRO PER I VERSAMENTI RITENUTE
		SET @tmp_idfin_employ = @idfinexpensecontraemploy
		SET @tmp_idupb_employ = @mainupb
		SET @tmp_idman_employ = @mainidman
	END

	--calcola il capitolo per il versamento della parte AMMINISTRAZIONE
	IF @admintaxkind = '3' --OR @employtaxkind = '2'
	BEGIN
		--CREA UN MOVIMENTO DIRETTAMENTE ALL'ENTE
		--SE NON SPECIFICO IL BILANCIO PER I CONTRIBUTI E' USATO IL CAPITOLO DEL MOV. DI SPESA
		SET @tmp_idfin_admin = ISNULL(@idfinadmintax, @idfinexpense)
		IF @idfinadmintax IS NULL
		BEGIN	--SE NON SPECIFICO IL BILANCIO PER I CONTRIBUTI E' USATO IL CAPITOLO DEL MOV. DI SPESA
			SET @tmp_idupb_admin = @idupbexpense
			SET @tmp_idman_admin = @idmanexpense
		END
		ELSE
		BEGIN  --ALTRIMENTI E' USATO IL BILANCIO PER I CONTRIBUTI
			SET @tmp_idupb_admin = @mainupb
			SET @tmp_idman_admin = @mainidman
		END
	END
	ELSE
	BEGIN
		--I CONTRIBUTI SONO VERSATI SUL CAPITOLO DELLA PARTITA DI GIRO PER I VERSAMENTI RITENUTE
		SET @tmp_idfin_admin = @idfinexpensecontra
		SET @tmp_idupb_admin = @mainupb
		SET @tmp_idman_admin = @mainidman
	END
	IF @admintax <> 0
	BEGIN
		--print 'Admin Tax'
		--print @admintax
		IF (((@flag&1) <> 0) OR  ((@flag&2) <> 0))
		BEGIN
			INSERT INTO #automov
			(
				movkind, idreg, idfin, idupb, idman,
				amount, competencydate, idexp, payee_title,
				location, idcity, idfiscaltaxregion, sourcekind, fiscaltaxcode,
				ayear, refmonth,idser
			)
			VALUES
			(
				'Spesa', @idreg, @tmp_idfin_admin, @tmp_idupb_admin, @tmp_idman_admin,
				@admintax, @competencydate, @idexp, @payee_title,
				@location, @idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
				@fiscalyear, @refmonth,@idser
			)
		END
		ELSE
		BEGIN
			INSERT INTO #automov
			(
				movkind, idreg, idfin, idupb, idman,
				amount,
				competencydate, idexp, payee_title,
				location, idcity, idfiscaltaxregion, sourcekind, fiscaltaxcode,
				ayear, refmonth,idser
			)
			SELECT
				'Spesa', #percentage_rip.idreg, @tmp_idfin_admin, @tmp_idupb_admin, @tmp_idman_admin,
				ROUND(@admintax * #percentage_rip.quota, 2),
				@competencydate, @idexp, @payee_title,
				@location, @idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
				@fiscalyear, @refmonth,@idser
			FROM #percentage_rip
		END
	END --IF @admintax <> 0
	IF @employtax <> 0
	BEGIN
		IF (((@flag&1) <> 0) OR  ((@flag&2) <> 0))
		BEGIN
			INSERT INTO #automov
			(
				movkind, idreg, idfin, idupb, idman,
				amount, competencydate, idexp, payee_title,
				location, idcity, idfiscaltaxregion, sourcekind, fiscaltaxcode,
				ayear, refmonth,idser
			)
			VALUES
			(
				'Spesa', @idreg, @tmp_idfin_employ, @tmp_idupb_employ, @tmp_idman_employ,
				@employtax, @competencydate, @idexp, @payee_title, 
				@location, @idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
				@fiscalyear, @refmonth,@idser
			)
		END
		ELSE
		BEGIN
			INSERT INTO #automov
			(
				movkind, idreg, idfin, idupb, idman,
				amount,
				competencydate, idexp, payee_title,
				location, idcity, idfiscaltaxregion, sourcekind, fiscaltaxcode,
				ayear, refmonth,idser
			)
			SELECT
				'Spesa', #percentage_rip.idreg, @tmp_idfin_employ, @tmp_idupb_employ, @tmp_idman_employ,
				ROUND(@employtax * #percentage_rip.quota, 2),
				@competencydate, @idexp, @payee_title,
				@location, @idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
				@fiscalyear, @refmonth,@idser
			FROM #percentage_rip
		END
	END --IF @employtax <> 0
	FETCH NEXT FROM #tax_crs INTO @competencydate,@payee_title,@idexp, @idfinexpense, @idupbexpense, @idmanexpense,
		@employtax, @admintax,@idreg_cursor, @idser,@idcity, @idfiscaltaxregion, @sourcekind, @fiscaltaxcode,
		@fiscalyear, @refmonth
END --WHILE
CLOSE #tax_crs
DEALLOCATE #tax_crs

DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT  paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento'  
				and  (start is null or start <= @stop) 
				and (stop is null or stop >= @stop)				
				),'Manca Cfg. Parametri Tutte le stampe')



SELECT
        @departmentname as departmentname,
			isnull(treasurer.header,treasurer.description) as department,

	E.ymov, E.nmov,
	movkind, #automov.amount,
	#automov.idreg, 
	registry.title AS registry,
	#automov.idfin, competencydate, 
	fin.codefin, 
	#automov.idupb,
	upb.codeupb,
	#automov.idman,
	manager.title as manager,
	#automov.idexp, payee_title, 
	#automov.location,
	#automov.idcity,
	geo_city.title AS city,
	#automov.idfiscaltaxregion,
	fiscaltaxregion.title AS fiscaltaxregion,
	#automov.sourcekind,
	#automov.fiscaltaxcode,
	@taxcode as taxcode,
        @tax as tax,
        @taxref as taxref,
	#automov.ayear,
	#automov.refmonth,
	payment.idtreasurer,
	#automov.idser, 
	service.codeser,
	service.description as service
FROM #automov 
JOIN registry					ON registry.idreg = #automov.idreg
JOIN fin						ON fin.idfin = #automov.idfin
JOIN upb						ON upb.idupb = #automov.idupb
LEFT OUTER JOIN manager			ON manager.idman = #automov.idman
LEFT OUTER JOIN expense E		ON E.idexp = #automov.idexp
LEFT OUTER JOIN geo_city		ON geo_city.idcity = #automov.idcity
LEFT OUTER JOIN fiscaltaxregion	ON fiscaltaxregion.idfiscaltaxregion = #automov.idfiscaltaxregion
LEFT OUTER JOIN	expenselast		on expenselast.idexp=E.idexp
LEFT OUTER JOIN	payment			on expenselast.kpay=payment.kpay
LEFT OUTER JOIN treasurer		on payment.idtreasurer= treasurer.idtreasurer
LEFT OUTER JOIN service		on #automov.idser= service.idser
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


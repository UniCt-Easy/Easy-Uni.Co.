
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_currentfloatfund]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_currentfloatfund]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_currentfloatfund 2007
--setuser 'amm'

CREATE    PROCEDURE [exp_currentfloatfund]
(
	@ayear int = NULL
)
AS BEGIN

DECLARE @startfloatfund decimal(19,2)
DECLARE @proceedstransmission decimal(19,2)
DECLARE @payment decimal(19,2)
DECLARE @fin_kind tinyint


DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

CREATE TABLE #currentfloatfund(description varchar(100), import decimal(19,2))


IF (@ayear IS NOT NULL)
BEGIN
	SELECT @fin_kind = fin_kind
	FROM config
	WHERE ayear = @ayear

	
	IF ((SELECT COUNT(*) FROM fin WHERE ayear = @ayear AND (flag & 16 <>0))>0)
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			SELECT @startfloatfund = ISNULL(SUM(finyear.secondaryprev),0) --previsione
			FROM finyear 
			join fin F on finyear.idfin=F.idfin
			WHERE (F.flag & 16 <>0) and finyear.ayear=@ayear

			SELECT @startfloatfund = 
			@startfloatfund +
			ISNULL(
				(SELECT SUM(d.amount) 
				FROM finvardetail d
				join FIN F on F.idfin=d.idfin
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				WHERE v.flagsecondaryprev = 'S' AND (F.flag & 16 <>0) AND (V.yvar=@ayear) 
					AND v.idfinvarstatus = 5)
			,0)
		END

		IF (@fin_kind = 2)
		BEGIN
			SELECT @startfloatfund = ISNULL(SUM(finyear.prevision),0)  --- previsione
			FROM finyear
			join fin F on finyear.idfin=F.idfin 
			WHERE (F.flag & 16 <>0) and finyear.ayear=@ayear
	
			SELECT @startfloatfund = 
			@startfloatfund +
			ISNULL(
				(SELECT SUM(d.amount) 
				FROM finvardetail d
				join FIN F on F.idfin=d.idfin
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				WHERE v.flagprevision = 'S' AND V.variationkind <> 5 AND  (F.flag & 16 <>0) AND (V.yvar=@ayear)
				AND v.idfinvarstatus = 5)
			,0)
		END
	END

	IF (SELECT COUNT(*) FROM fin WHERE ayear = @ayear AND (flag & 16 <>0)) = 0
		OR (@fin_kind = 1)
	BEGIN
		-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
		SELECT @startfloatfund = ISNULL(startfloatfund,0) 
		FROM surplus WHERE ayear = @ayear 
	END
	
	INSERT INTO #currentfloatfund values
	('FONDO CASSA INIZIALE',@startfloatfund)

	
	SET @proceedstransmission =
		
		ISNULL(
			(SELECT SUM(ISNULL(i.curramount,0))
			FROM incometotal i 
			JOIN income e
				ON e.idinc=i.idinc
			JOIN incomelast IL
				ON IL.idinc = e.idinc
			JOIN proceeds p
				ON  p.kpro=IL.kpro
			JOIN proceedstransmission pt
				ON p.kproceedstransmission=pt.kproceedstransmission 
			WHERE i.ayear = @ayear)
		,0)


	INSERT INTO #currentfloatfund values
	('Reversali Trasmesse',@proceedstransmission)


	SET @payment = 
	ISNULL(
		(SELECT ISNULL(SUM(i.curramount), 0)
		FROM expense s
		JOIN expensetotal i
			ON s.idexp = i.idexp
			AND s.ymov = i.ayear
		JOIN expenselast EL
			ON EL.idexp = s.idexp
		WHERE i.ayear = @ayear)
	,0)
	--WHERE ayear = @ayear

	declare @ultima_fase varchar(50)
	select  @ultima_fase=description  from expensephase where nphase=(select max(nphase) from expensephase) 

	INSERT INTO #currentfloatfund values
	(@ultima_fase,@payment)
	
	INSERT INTO #currentfloatfund values
	('Residuo disponibile per ' +@ultima_fase+' (Regola MOVIM021)',@startfloatfund+@proceedstransmission-@payment)

	INSERT INTO #currentfloatfund values
	('',null)

	INSERT INTO #currentfloatfund values
	('Dettaglio Entrata:',null)

--- calcoli entrata

	INSERT INTO #currentfloatfund 
	select 'Reversali Trasmesse',sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	join incometotal ET 
		ON EL.idinc=ET.idinc 
	JOIN proceeds P	
		ON P.kpro=EL.kpro
	where 
	ET.ayear=@ayear
	AND EL.kpro is not null
	AND P.kproceedstransmission is not null

	INSERT INTO #currentfloatfund 
	SELECT 'Reversali non Trasmesse', sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	JOIN incometotal ET 
		ON EL.idinc=ET.idinc 
	JOIN proceeds P	
		ON P.kpro=EL.kpro
	where 
	ET.ayear=@ayear 
	AND EL.kpro is not null
	AND P.kproceedstransmission is null


	INSERT INTO #currentfloatfund 
	select 'Incassi non inseriri in reversali',sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	JOIN incometotal ET 
		ON EL.idinc=ET.idinc 
	AND NOT EXISTS (select * from proceeds P where P.kpro=EL.kpro)
	WHERE 
	ET.ayear=@ayear 

	INSERT INTO #currentfloatfund values
	('',null)

	INSERT INTO #currentfloatfund values
	('Dettaglio Spesa:',null)

--calcoli spesa

	INSERT INTO #currentfloatfund 
	select 'Mandati Trasmessi',sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	join expensetotal ET 
		ON EL.idexp=ET.idexp 
	JOIN payment P	
		ON P.kpay=EL.kpay
	where 
	ET.ayear=@ayear 
	AND EL.kpay is not null
	AND P.kpaymenttransmission is not null

	INSERT INTO #currentfloatfund 
	SELECT 'Mandati non Trasmessi', sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	JOIN expensetotal ET 
		ON EL.idexp=ET.idexp 
	JOIN payment P	
		ON P.kpay=EL.kpay
	where 
	ET.ayear=@ayear
	AND EL.kpay is not null
	AND P.kpaymenttransmission is null


	INSERT INTO #currentfloatfund 
	select @ultima_fase+' non inserite in mandati',sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	JOIN expensetotal ET 
		ON EL.idexp=ET.idexp 
	AND NOT EXISTS (select * from payment P where P.kpay=EL.kpay)
	WHERE 
	ET.ayear=@ayear 
--impegnato da liquidare
	declare @expensephase int
	set @expensephase = (select expensephase from config where ayear=@ayear)

	
	INSERT INTO #currentfloatfund 
	SELECT 'Impegnato da Liquidare',sum(available) FROM expense E 
	JOIN expensetotal ET 
		ON E.idexp=ET.idexp
	WHERE e.nphase=@expensephase
	AND E.ymov=@ayear

END
ELSE 	
	INSERT INTO #currentfloatfund values
	('Inserire Esercizio',null)

	SELECT description as 'Descrizione', import as 'Importo' from  #currentfloatfund
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


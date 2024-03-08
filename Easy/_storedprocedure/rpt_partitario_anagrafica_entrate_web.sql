
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_anagrafica_entrate_web]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_anagrafica_entrate_web]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_partitario_anagrafica_entrate_web]
	@ayear int,
	@codelevel tinyint,
	@codefin varchar(50),
	@start datetime,
	@stop datetime,
	@idreg int
AS


BEGIN


DECLARE @idfin int
IF (@codefin IS NULL OR @codefin = '' OR @codefin = '%')
	BEGIN
		SET @idfin = null	
	END
Else
	BEGIN
	   	SET @idfin = (select idfin 
				from fin 
				where codefin = @codefin 
				and ayear=@ayear 
				and (fin.flag&1)=0) -- Entrata
	END

/* Versione 1.0.2 del 14/12/2007 ultima modifica: PIERO */
DECLARE @level_input tinyint
SELECT @level_input = ISNULL(nlevel, @codelevel) from fin where idfin = @idfin
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
BEGIN
	SET  @codelevel = @level_input
END


DECLARE @nfinphase tinyint

SELECT @nfinphase = incomeregphase
FROM uniconfig

DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase)
FROM    incomephase 

IF @start is null
BEGIN
	SET @start = {d '1900-01-01'}
END

	
CREATE TABLE #income
(
	idfin int,
	nphase tinyint,
	flagarrear char(1),	
	ayear int,
	adate datetime,
	description varchar(300),
	title varchar(100),
	available decimal(19,2),
	rowkind int,
	npro int,
	nassessment int,
	ymovassessment int,
	nmovassessment int,
	assessment_amount decimal(19,2),
	origin_assessment_amount decimal(19,2),
	nproceed int,
	ymovproceed int,
	nmovproceed int,
	proceed_amount decimal(19,2)
)

INSERT INTO #income
(
	idfin,
	nphase, 
	rowkind,
	adate, 
	description, 
	title,
	nassessment, 
	ymovassessment,
	nmovassessment,
	assessment_amount,
	origin_assessment_amount,
	nproceed, 
	ymovproceed,
	nmovproceed,
	proceed_amount,
	npro,
	flagarrear,
	available
)
SELECT 
	ISNULL(FL.idparent, incomeyear.idfin),
	income.nphase,	
	income.nphase,
	income.adate,
	CASE  WHEN (isnull(income.doc,'') = '')
	      THEN income.description 
	      WHEN (isnull(income.doc,'')<> '' AND income.docdate is null) 
	      THEN  income.description + ' (Doc. ' + isnull(Convert (varchar(20),income.doc),'')  +')'
	      ELSE  income.description + ' (Doc. ' + isnull(Convert (varchar(20),income.doc),'')  + ' del '+ 
		Convert (varchar(2),datepart(dd,income.docdate))+'/'+Convert (varchar(2),datepart(mm,income.docdate))+
		'/'+Convert (varchar(4),datepart(yy,income.docdate))+')'
	end,
	registry.title,
	I2.idinc, --Accertamento
	I2.ymov,
	I2.nmov,  
	CASE 
		WHEN income.nphase = @nfinphase THEN incomeyear.amount
		ELSE 0
	END ,
	CASE 
		WHEN income.nphase = @nfinphase THEN incomeyear_starting.amount
		ELSE 0
	END ,
	I3.idinc, --Incasso
	I3.ymov,
	I3.nmov,
	CASE 
		WHEN income.nphase = @maxincomephase THEN incomeyear.amount
		ELSE 0
	END ,
	proceeds.npro,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	CASE 
		WHEN income.nphase = @nfinphase THEN IT2.available
		ELSE 0
	END 
FROM incomeyear
JOIN income
	ON incomeyear.idinc = income.idinc 
JOIN registry 
	ON income.idreg = registry.idreg
JOIN upb 
	ON upb.idupb=incomeyear.idupb
JOIN fin 
	ON incomeyear.idfin = fin.idfin 
JOIN incometotal
	ON  incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear	
JOIN incomelink IL2
	ON IL2.idchild = income.idinc  
	AND IL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = incomeyear.idfin AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = incomeyear.idfin AND FL1.nlevel = @level_input
LEFT  OUTER JOIN incomelast
	ON incomelast.idinc = income.idinc
LEFT OUTER 
	JOIN proceeds
	ON incomelast.kpro=proceeds.kpro
LEFT OUTER JOIN income I2
	ON I2.idinc = IL2.idparent
JOIN incometotal IT2
	ON IT2.idinc=I2.idinc
	AND IT2.ayear = incomeyear.ayear
LEFT OUTER JOIN income I3
	 ON I3.idinc = incomelast.idinc 
LEFT OUTER JOIN incometotal incometotal_firstyear
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
WHERE ((fin.flag&1)=0) -- Entrata
	AND (@idfin IS NULL OR isnull(FL1.idparent, fin.idfin) = @idfin)
	AND incomeyear.ayear = @ayear
	AND income.adate BETWEEN @start AND @stop
	AND ((income.nphase IN (@nfinphase,@maxincomephase )))
	AND (@idreg IS NULL OR income.idreg = @idreg)

UPDATE #income
	SET
	assessment_amount = assessment_amount + 
				(SELECT ISNULL(SUM(amount),0.0) 
				   FROM incomevar
				  WHERE incomevar.idinc = #income.nassessment
				    AND incomevar.adate <= @stop
				    AND incomevar.yvar = @ayear
				    AND #income.nphase = @nfinphase),
	proceed_amount = proceed_amount + 
				(SELECT ISNULL(SUM(amount),0.0) 
				   FROM incomevar
				  WHERE incomevar.idinc = #income.nproceed
				    AND incomevar.adate <= @stop
				    AND incomevar.yvar = @ayear
				    AND #income.nphase = @maxincomephase
				)

DELETE FROM #income
WHERE nphase = @maxincomephase AND npro IS NULL

	SELECT  
		#income.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		nphase,
		rowkind,
		adate,
		description,
		#income.title as registry,
		nassessment,
		ymovassessment,
		nmovassessment,	
		(isnull(assessment_amount,0.0)) as assessment_amount,
		(isnull(origin_assessment_amount,0.0)) as origin_assessment_amount,
		nproceed,
		ymovproceed,
		nmovproceed,	
		(isnull(proceed_amount,0.0)) as proceed_amount,
		sum(isnull(available,0)) as available,
		npro,
		flagarrear,
		@ayear as ayear
	FROM  #income
	JOIN fin F
		ON #income.idfin = F.idfin
	GROUP BY
		F.printingorder,
		#income.idfin,F.codefin,F.title,
		nphase,
		rowkind	,adate,description,#income.title,nassessment,nproceed,npro,flagarrear,
		#income.ayear,
		assessment_amount,origin_assessment_amount,proceed_amount,available,
		ymovassessment, nmovassessment,	ymovproceed, nmovproceed
	ORDER BY 
		F.printingorder, rowkind, adate
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_anagrafica_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_anagrafica_spese]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- rpt_partitario_anagrafica_spese 2009,3,null,{d '2009-12-01'},{d '2009-12-31'},0

CREATE    PROCEDURE [rpt_partitario_anagrafica_spese]
	@ayear int,
	@codelevel tinyint,
	@codefin varchar(50),
	@start datetime,
	@stop datetime,
	@idreg int

AS
BEGIN
/* Versione 1.0.2 del 14/12/2007 ultima modifica: PIERO */


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
				and (fin.flag&1)=1) -- = Spesa
	END

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@codelevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@codelevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @codelevel = @level_input
	END

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel)
	FROM finlevel
	WHERE (flag&2)<>0  AND ayear = @ayear
IF @levelusable < @codelevel
BEGIN	
	SET @levelusable = @codelevel
END

-- considerare bene cosa succede quando voglio la stampa per articolo e specifico un capitolo in input
-- devo prendere i figli del capitolo specificato, aventi livello @codelevel

DECLARE @nfinphase tinyint

SELECT @nfinphase = expenseregphase
FROM uniconfig

-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchÃ¨ questÃ  Ã¨ la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase)
FROM    expensephase 
-- ATTENZIONE L'ipotesi di funzionamento di questa sp � che faseimpegno = fasepagamento - 1.
-- ALTRIMENTI SBALLA LE RIGHE DEL PAGAMENTO SUL REPORT (o meglio con un p� di tempo si deve fare un controllo per eliminare tutte le fasi 
-- che non sono fase del pagamento e fase dell' impegno, anzi lo faccio subito inserendo alla fine una DELETE WHERE nphase <> fase del pagamento  AND nphase <> fase dell'impegno)



CREATE TABLE #expense
(
	idfin int ,
	nphase tinyint,
	rowkind int,
	adate datetime,
	description varchar(300),     
	title varchar(100),	
	nappropriation int,
	ymovappropriation int,
	nmovappropriation int,
	appropriation_amount decimal(19,2),
	available decimal(19,2),
	npayment int,
	ymovpayment int,
	nmovpayment int,
	payment_amount decimal(19,2),
	npay int,
	flagarrear char(1),	
	yoperation int,
	noperation int,
	operation_amount decimal(19,2),
	yrestore int,
	nrestore int,
	ayear int,
	pettycash char(1)
)

INSERT INTO #expense
(
	idfin,
	nphase,
	rowkind, 
	adate, 
	description, 
	title,		
	nappropriation, 
	ymovappropriation,
	nmovappropriation,
	appropriation_amount,
	npayment, 
	ymovpayment,
	nmovpayment,
	payment_amount,
	npay,
	flagarrear,
	available,
	pettycash
)	
SELECT 
	ISNULL(FL.idparent, expenseyear.idfin),
	expense.nphase,
	expense.nphase,
	expense.adate,
	CASE  WHEN (isnull(expense.doc,'') = '')
	      THEN expense.description 
	      WHEN (isnull(expense.doc,'')<> '' AND expense.docdate is null) 
	      THEN  expense.description + ' (Doc. ' + isnull(Convert (varchar(20),expense.doc),'')  +')'
	      ELSE  expense.description + ' (Doc. ' + isnull(Convert (varchar(20),expense.doc),'')  + ' del '+ 
		Convert (varchar(2),datepart(dd,expense.docdate))+'/'+Convert (varchar(2),datepart(mm,expense.docdate))+
		'/'+Convert (varchar(4),datepart(yy,expense.docdate))+')'
	end,
	registry.title,	
	E2.idexp, --Impegno
	E2.ymov,
	E2.nmov,  
	CASE 
		WHEN expense.nphase = @nfinphase THEN expenseyear.amount
		ELSE 0
	END ,
	E3.idexp, --Pagamento
	E3.ymov,
	E3.nmov, 
	CASE 
		WHEN expense.nphase = @maxexpensephase THEN expenseyear.amount
		ELSE 0
	END,
	payment.npay,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	CASE 
		WHEN expense.nphase = @nfinphase THEN ET2.available 
		ELSE 0
	END ,
	'N'
FROM expenseyear
JOIN expense
	ON expenseyear.idexp = expense.idexp 
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
JOIN fin
	ON expenseyear.idfin = fin.idfin 
	AND expenseyear.ayear = fin.ayear
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear		
JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = @nfinphase
LEFT  OUTER JOIN finlink FL
	ON FL.idchild = expenseyear.idfin  AND FL.nlevel = @codelevel
LEFT  OUTER JOIN finlink FL1
	ON FL1.idchild = expenseyear.idfin  AND FL1.nlevel = @level_input
LEFT  OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment
	ON expenselast.kpay = payment.kpay
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = @maxexpensephase
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
JOIN expensetotal ET2
	ON ET2.idexp=E2.idexp
	AND ET2.ayear = expenseyear.ayear
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
JOIN registry 
	ON registry.idreg = expense.idreg
WHERE ((fin.flag&1)=1) -- Spesa
	AND expenseyear.ayear = @ayear
	AND (@idfin IS NULL OR  isnull(FL1.idparent, expenseyear.idfin) = @idfin)		
	AND expense.adate <= @stop
	AND ((expense.nphase IN (@nfinphase,@maxexpensephase )))
	AND ( expense.idreg = @idreg OR @idreg = 0 )
	--escludiamo i movimenti di spesa associati a reintegri di fondo economale
	AND NOT EXISTS (SELECT PE.idexp FROM pettycashexpense PE
			JOIN pettycashoperation OP
			ON  PE.idpettycash = OP.idpettycash
			AND PE.yoperation  = OP.yoperation 
			AND PE.noperation  = OP.noperation
			AND PE.idexp 	   = expense.idexp
			AND ((OP.flag& 2)<>0)  -- Reintegro  
			)

------------------------------------------
-- piccole spese reintegrate che 	--
-- contabilizzano contratti occasionali --
------------------------------------------

INSERT INTO #expense
(
	idfin,
	adate,
	description,     
	title,	
	yoperation,
	noperation,
	operation_amount,
	yrestore,
	nrestore,
	ayear,
	pettycash
)	
SELECT
	-- bilancio del reintegro
	EY.idfin,
	-- data contabile operazione fondo economale
	OP.adate,
	-- descrizione della contabilizzazione effettuata
	-- (con riferimento al documento e numero operazione del fondo economale)
	CASE  WHEN (isnull(OP.doc,'') = '')
		      THEN OP.description  + ' ' + OP.pettycash 
		      WHEN (isnull(OP.doc,'')<> '' AND OP.docdate is null) 
		      THEN  OP.description + OP.pettycash +  ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  +')'
		      ELSE  OP.description + OP.pettycash + ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  + ' del '+ 
			Convert (varchar(2),datepart(dd,OP.docdate))+'/'+Convert (varchar(2),datepart(mm,OP.docdate))+
			'/'+Convert (varchar(4),datepart(yy,OP.docdate))+')'
	END,
	-- creditore dell'operazione
	OP.registry,
	-- informazioni relative all'operazione
	OP.yoperation,
	OP.noperation,
	OP.amount,
	-- informazioni relative al reintegro
	OP.yrestore,
	OP.nrestore,
	@ayear,
	'S'
FROM pettycashoperationview OP
JOIN pettycashoperationcasualcontract CON
			ON  OP.idpettycash = CON.idpettycash
			AND OP.yoperation  = CON.yoperation
			AND OP.noperation  = CON.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry 
	ON registry.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
JOIN pettycashexpense PE
	ON  PE.idpettycash = OPR.idpettycash
	AND PE.yoperation  = OPR.yoperation 
	AND PE.noperation  = OPR.noperation
JOIN expense  E   
	ON  PE.idexp  = E.idexp 
	AND E.nphase  = @nfinphase
JOIN expenseyear  EY 
	ON EY.idexp   = PE.idexp
	AND EY.ayear  = @ayear
WHERE  (@idfin IS NULL OR EY.idfin = @idfin)	
	AND ( OP.idreg = @idreg OR @idreg = 0 )
	AND OP.adate <= @stop
	
--------------------------------------------
-- piccole spese reintegrate che 	  --
-- contabilizzano contratti professionali --
--------------------------------------------
INSERT INTO #expense
(
	idfin,
	adate,
	description,     
	title,	
	yoperation,
	noperation,
	operation_amount,
	yrestore,
	nrestore,
	ayear,
	pettycash
)	
	SELECT
	-- bilancio del reintegro
	EY.idfin,
	-- data contabile operazione fondo economale
	OP.adate,
	-- descrizione della contabilizzazione effettuata
	-- (con riferimento al documento e numero operazione del fondo economale)
	CASE  WHEN (isnull(OP.doc,'') = '')
		      THEN OP.description  + ' ' + OP.pettycash 
		      WHEN (isnull(OP.doc,'')<> '' AND OP.docdate is null) 
		      THEN  OP.description + OP.pettycash +  ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  +')'
		      ELSE  OP.description + OP.pettycash + ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  + ' del '+ 
			Convert (varchar(2),datepart(dd,OP.docdate))+'/'+Convert (varchar(2),datepart(mm,OP.docdate))+
			'/'+Convert (varchar(4),datepart(yy,OP.docdate))+')'
	END,
	-- creditore dell'operazione
	OP.registry,
	-- informazioni relative all'operazione
	OP.yoperation,
	OP.noperation,
	OP.amount,
	-- informazioni relative al reintegro
	OP.yrestore,
	OP.nrestore,
	@ayear,
	'S'
FROM pettycashoperationview OP
JOIN pettycashoperationprofservice CON
			ON OP.idpettycash = CON.idpettycash
			AND OP.yoperation = CON.yoperation
			AND OP.noperation = CON.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry 
	ON registry.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
JOIN pettycashexpense PE
	ON  PE.idpettycash = OPR.idpettycash
	AND PE.yoperation  = OPR.yoperation 
	AND PE.noperation  = OPR.noperation
JOIN expense  E   
	ON  PE.idexp  = E.idexp 
	AND E.nphase  = @nfinphase
JOIN expenseyear  EY 
	ON EY.idexp = PE.idexp
	AND EY.ayear = @ayear
WHERE  (@idfin IS NULL OR EY.idfin = @idfin)	
AND ( OP.idreg = @idreg OR @idreg = 0 )
AND OP.adate <= @stop
	

------------------------------------------
-- piccole spese reintegrate che 	--
-- contabilizzano anticipi missioni     --
------------------------------------------
INSERT INTO #expense
(
	idfin,
	adate,
	description,     
	title,	
	yoperation,
	noperation,
	operation_amount,
	yrestore,
	nrestore,
	ayear,
	pettycash
)	
SELECT
	-- bilancio del reintegro
	EY.idfin,
	-- data contabile operazione fondo economale
	OP.adate,
	-- descrizione della contabilizzazione effettuata
	-- (con riferimento al documento e numero operazione del fondo economale)
	CASE  WHEN (isnull(OP.doc,'') = '')
		      THEN OP.description  + ' ' + OP.pettycash 
		      WHEN (isnull(OP.doc,'')<> '' AND OP.docdate is null) 
		      THEN  OP.description + OP.pettycash +  ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  +')'
		      ELSE  OP.description + OP.pettycash + ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  + ' del '+ 
			Convert (varchar(2),datepart(dd,OP.docdate))+'/'+Convert (varchar(2),datepart(mm,OP.docdate))+
			'/'+Convert (varchar(4),datepart(yy,OP.docdate))+')'
	END,
	-- creditore dell'operazione
	OP.registry,
	-- informazioni relative all'operazione
	OP.yoperation,
	OP.noperation,
	OP.amount,
	-- informazioni relative al reintegro
	OP.yrestore,
	OP.nrestore,
	@ayear,
	'S'
FROM pettycashoperationview OP
JOIN pettycashoperationitineration MIS
			ON OP.idpettycash = MIS.idpettycash
			AND OP.yoperation = MIS.yoperation
			AND OP.noperation = MIS.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry 
	ON registry.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
JOIN pettycashexpense PE
	ON  PE.idpettycash = OPR.idpettycash
	AND PE.yoperation  = OPR.yoperation 
	AND PE.noperation  = OPR.noperation
JOIN expense  E   
	ON  PE.idexp  = E.idexp 
	AND E.nphase  = @nfinphase
JOIN expenseyear  EY 
	ON EY.idexp = PE.idexp
	AND EY.ayear = @ayear
WHERE  (@idfin IS NULL OR EY.idfin = @idfin)	
AND ( OP.idreg = @idreg OR @idreg = 0 )
AND OP.adate <= @stop
-----------------------------------
-- piccole spese reintegrate che --
-- contabilizzano fatture ---------	
-----------------------------------
INSERT INTO #expense
(
	idfin,
	adate,
	description,     
	title,	
	yoperation,
	noperation,
	operation_amount,
	yrestore,
	nrestore,
	ayear,
	pettycash
)	
SELECT
	-- bilancio del reintegro
	EY.idfin,
	-- data contabile operazione fondo economale
	OP.adate,
	-- descrizione della contabilizzazione effettuata
	-- (con riferimento al documento e numero operazione del fondo economale)
	CASE  WHEN (isnull(OP.doc,'') = '')
		      THEN OP.description  + ' ' + OP.pettycash 
		      WHEN (isnull(OP.doc,'')<> '' AND OP.docdate is null) 
		      THEN  OP.description + OP.pettycash +  ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  +')'
		      ELSE  OP.description + OP.pettycash + ' (Doc. ' + isnull(Convert (varchar(20),OP.doc),'')  + ' del '+ 
			Convert (varchar(2),datepart(dd,OP.docdate))+'/'+Convert (varchar(2),datepart(mm,OP.docdate))+
			'/'+Convert (varchar(4),datepart(yy,OP.docdate))+')'
	END,
	-- creditore dell'operazione
	OP.registry,
	-- informazioni relative all'operazione
	OP.yoperation,
	OP.noperation,
	OP.amount,
	-- informazioni relative al reintegro
	OP.yrestore,
	OP.nrestore,
	@ayear,
	'S'
FROM pettycashoperationview OP
JOIN pettycashoperationinvoice INV
			ON  OP.idpettycash = INV.idpettycash
			AND OP.yoperation  = INV.yoperation
			AND OP.noperation  = INV.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry 
	ON registry.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
JOIN pettycashexpense PE
	ON  PE.idpettycash = OPR.idpettycash
	AND PE.yoperation  = OPR.yoperation 
	AND PE.noperation  = OPR.noperation
JOIN expense  E   
	ON  PE.idexp  = E.idexp 
	AND E.nphase  = @nfinphase
JOIN expenseyear  EY 
	ON EY.idexp = PE.idexp
	AND EY.ayear = @ayear
WHERE  (@idfin IS NULL OR EY.idfin = @idfin)	
AND ( OP.idreg = @idreg OR @idreg = 0 )
AND OP.adate <= @stop

----------------------------------------------
----------------------------------------------
----------------------------------------------
	
	DELETE FROM #expense
	WHERE nphase = @maxexpensephase AND npay IS NULL
	
	UPDATE #expense
	SET
	appropriation_amount = appropriation_amount + 
		(SELECT ISNULL(SUM(amount),0) 
		FROM expensevar
		WHERE expensevar.idexp = #expense.nappropriation
		AND expensevar.adate <= @stop
		AND expensevar.yvar = @ayear
		AND #expense.nphase  = @nfinphase 
		)

	UPDATE #expense
	SET
	payment_amount = payment_amount + 
		(SELECT ISNULL(SUM(amount),0) FROM expensevar
		WHERE expensevar.idexp = #expense.npayment
		and expensevar.adate <= @stop
		and expensevar.yvar = @ayear
		and #expense.nphase  = @maxexpensephase
		)

	SELECT 
		#expense.idfin,
		F.codefin,
		F.title as fintitle,
		F.printingorder as finprintingorder,
		nphase,
		rowkind,
		adate,
		description,
		#expense.title as registry,
		nappropriation,
		ymovappropriation,
		nmovappropriation,	
		sum(isnull(appropriation_amount,0)) as appropriation_amount,
		npayment,
		ymovpayment,
		nmovpayment,
		sum(isnull(payment_amount,0)) as  payment_amount,
		sum(isnull(available,0)) as available,
		npay,
		flagarrear,
		#expense.yoperation,
		#expense.noperation,
		#expense.operation_amount,
		#expense.yrestore,
		#expense.nrestore,
		@ayear as ayear,
		#expense.pettycash
	FROM #expense
	JOIN fin F
		ON #expense.idfin = F.idfin
	GROUP BY  	
		#expense.idfin,F.codefin,F.title,
		F.printingorder,#expense.nphase,
		rowkind,adate,description,#expense.title,nappropriation,npayment,
		npay,flagarrear,#expense.ayear,#expense.yoperation,
		#expense.noperation,
		#expense.operation_amount,
		#expense.yrestore,
		#expense.nrestore,
		ymovappropriation,nmovappropriation,ymovpayment,nmovpayment,
		#expense.pettycash	
	ORDER BY F.printingorder, adate,rowkind, #expense.pettycash 

END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anagrafica_partitario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anagrafica_partitario]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE        PROCEDURE [rpt_anagrafica_partitario]
	@ayear int,
	@title varchar(100), 
	@start datetime,
	@stop datetime
AS
BEGIN
CREATE TABLE #partitario
(
	idreg int,
	title varchar(100),
	cf varchar(16),  
	p_iva varchar(15),
	rowkind int,
	competencydate datetime,
	operationkind varchar(55),
	ymov int,
	nmov int,
	nvar int,
	npro_npay int,
	description varchar(150),
 	doc varchar(35),
	docdate datetime,
	proceeds float,
	payment	float		 
)
-- ovvero prendo la massima fase tra quelle che contengono o il codice di bilancio o il creditore perchÃ¨ questÃ  Ã¨ la vera fase di impegno giuridico
DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase)
FROM    expensephase 

-- INSERISCO I PAGAMENTI
INSERT INTO #partitario
SELECT 
	HPV.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	3,
	HPV.competencydate,
	'Pagamento',
	HPV.ymov,
	HPV.nmov,
	null,
	HPV.npay,
	HPV.description,
	HPV.doc,
	HPV.docdate,
	null,	
	HPV.amount
FROM historypaymentview HPV
JOIN registry REG
	ON REG.idreg = HPV.idreg
WHERE HPV.ymov = @ayear
	AND REG.title LIKE @title
	AND HPV.competencydate > = @start 
	AND HPV.competencydate < = @stop
--escludiamo i movimenti di spesa associati a reintegri di fondo economale
	AND NOT EXISTS (SELECT PE.idexp FROM pettycashexpense PE
			JOIN pettycashoperation OP
			ON  PE.idpettycash = OP.idpettycash
			AND PE.yoperation  = OP.yoperation 
			AND PE.noperation  = OP.noperation
			AND PE.idexp 	   = HPV.idexp
			AND ((OP.flag& 2)<>0)  -- reintegro  
			) 

-- INSERISCO LE CONTABILIZZAZIONI EFFETTUATE -
-- TRAMITE FONDO ECONOMALE -------------------
-- SOLO SE REINTEGRATE -----------------------

----------------------------------------------
---------- CONTRATTI OCCASIONALI -------------
----------------------------------------------
INSERT INTO #partitario
SELECT 
	OP.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	5,
	OP.adate,
	'Op. Fondo Econ.',
	OP.yoperation,
	OP.noperation,
	null,
	OP.nrestore,
	OP.description + ' ' + OP.pettycash ,
	OP.doc,
	OP.docdate,
	null,	
	OP.amount
FROM pettycashoperationview OP
JOIN pettycashoperationcasualcontract CON
			ON  OP.idpettycash = CON.idpettycash
			AND OP.yoperation  = CON.yoperation
			AND OP.noperation  = CON.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry  REG
	ON REG.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
WHERE OP.yoperation = @ayear
	AND OP.registry LIKE @title
	AND OP.adate > = @start 
	AND OP.adate < = @stop

----------------------------------------------
---------- CONTRATTI PROFESSIONALI -------------
----------------------------------------------
INSERT INTO #partitario
SELECT 
	OP.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	5,
	OP.adate,
	'Op. Fondo Econ.',
	OP.yoperation,
	OP.noperation,
	null,
	OP.nrestore,
	OP.description + ' ' + OP.pettycash ,
	OP.doc,
	OP.docdate,
	null,	
	OP.amount
FROM pettycashoperationview OP
JOIN pettycashoperationprofservice CON
			ON  OP.idpettycash = CON.idpettycash
			AND OP.yoperation  = CON.yoperation
			AND OP.noperation  = CON.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry  REG
	ON REG.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
WHERE OP.yoperation = @ayear
	AND OP.registry LIKE @title
	AND OP.adate > = @start 
	AND OP.adate < = @stop

----------------------------------------------
---------- MISSIONI --------------------------
----------------------------------------------
INSERT INTO #partitario
SELECT 
	OP.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	5,
	OP.adate,
	'Op. Fondo Econ.',
	OP.yoperation,
	OP.noperation,
	null,
	OP.nrestore,
	OP.description + ' ' + OP.pettycash ,
	OP.doc,
	OP.docdate,
	null,	
	OP.amount
FROM pettycashoperationview OP
JOIN pettycashoperationitineration MIS
			ON  OP.idpettycash = MIS.idpettycash
			AND OP.yoperation  = MIS.yoperation
			AND OP.noperation  = MIS.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry  REG
	ON REG.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
WHERE OP.yoperation = @ayear
	AND OP.registry LIKE @title
	AND OP.adate > = @start 
	AND OP.adate < = @stop


----------------------------------------------
---------- DOCUMENTI IVA ---------------------
----------------------------------------------
INSERT INTO #partitario
SELECT 
	OP.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	5,
	OP.adate,
	'Op. Fondo Econ.',
	OP.yoperation,
	OP.noperation,
	null,
	OP.nrestore,
	OP.description + ' ' + OP.pettycash ,
	OP.doc,
	OP.docdate,
	null,	
	OP.amount
FROM pettycashoperationview OP
JOIN pettycashoperationinvoice INV
			ON  OP.idpettycash = INV.idpettycash
			AND OP.yoperation  = INV.yoperation
			AND OP.noperation  = INV.noperation
			AND ((OP.flag& 8)<>0)  -- spesa  
JOIN registry  REG
	ON REG.idreg = OP.idreg
JOIN pettycashoperation OPR --reintegro
	ON  OP.idpettycash = OPR.idpettycash
	AND OP.yrestore  = OPR.yoperation
	AND OP.nrestore  = OPR.noperation
	AND ((OPR.flag& 2)<>0)  -- reintegro  
WHERE OP.yoperation = @ayear
	AND OP.registry LIKE @title
	AND OP.adate > = @start 
	AND OP.adate < = @stop


-- INSERISCO LE ENTRATE
INSERT INTO #partitario
SELECT 
	HPV.idreg,
	REG.title,
	REG.cf,
	REG.p_iva,
	1,
	HPV.competencydate,
	'Incassi',
	HPV.ymov,
	HPV.nmov,
	null,
	HPV.npro,
	HPV.description,
	HPV.doc,
	HPV.docdate,
	HPV.amount,
	null		
FROM historyproceedsview HPV 
JOIN registry REG
	ON REG.idreg = HPV.idreg
WHERE HPV.ymov = @ayear
	AND REG.title LIKE @title
	AND HPV.competencydate > = @start 
	AND HPV.competencydate < = @stop
	
DECLARE @proceedsphase varchar(20)
SELECT @proceedsphase = MAX(nphase) FROM incomephase
INSERT INTO #partitario
(
	idreg,
	title,
	cf,  
	p_iva,
	rowkind,
	competencydate,
	operationkind,
	ymov,
	nmov,
	nvar,
	npro_npay,
	description,
	doc,
	docdate,
	proceeds
)
SELECT
	income.idreg,
	registry.title,
	registry.cf,
	registry.p_iva,
	2,
	incomevar.adate,
	'Var. incasso',
	income.ymov,
	income.nmov,
	incomevar.nvar,
	incomelast.kpro,
	incomevar.description,
	incomevar.doc,
	incomevar.docdate,
	incomevar.amount
FROM incomevar
JOIN income
	ON income.idinc = incomevar.idinc
JOIN registry
	ON registry.idreg = income.idreg
LEFT OUTER JOIN incomelast
	ON income.idinc = incomelast.idinc
WHERE income.ymov = @ayear
	AND incomevar.yvar = @ayear
	AND registry.title LIKE @title
	AND incomevar.adate BETWEEN @start AND @stop
	AND isnull(incomevar.autokind,'') <>'22' 
	AND income.nphase = @proceedsphase

DECLARE @paymentphase varchar(20)
SELECT @paymentphase = MAX(nphase)FROM expensephase
INSERT INTO #partitario
(
	idreg,
	title,
	cf,  
	p_iva,
	rowkind,
	competencydate,
	operationkind,
	ymov,
	nmov,
	nvar,
	npro_npay,
	description,
	doc,
	docdate,
	payment
)
SELECT
	expense.idreg,
	registry.title,
	registry.cf,
	registry.p_iva,
	4,
	expensevar.adate,
	'Var. pagamento',
	expense.ymov,
	expense.nmov,
	expensevar.nvar,
	expenselast.kpay,
	expensevar.description,
	expensevar.doc,
	expensevar.docdate,
	expensevar.amount
FROM expensevar
JOIN expense
	ON expense.idexp = expensevar.idexp
JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
WHERE expense.ymov = @ayear
	AND expensevar.yvar = @ayear
	AND registry.title LIKE @title
	AND expensevar.adate BETWEEN @start AND @stop
	AND isnull(expensevar.autokind,'') <>'22' 
	AND expense.nphase = @paymentphase
AND NOT EXISTS (SELECT PE.idexp FROM pettycashexpense PE
			JOIN pettycashoperation OP
			ON  PE.idpettycash = OP.idpettycash
			AND PE.yoperation  = OP.yoperation 
			AND PE.noperation  = OP.noperation
			AND PE.idexp 	   = expense.idexp
			AND ((OP.flag& 2)<>0)  -- reintegro  
			) 

DECLARE @departmentname varchar(500)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @start) 
				and (stop is null or stop >= @start)
				),'Manca Cfg. Parametri Tutte le stampe')



SELECT
        @departmentname as departmentname,
		idreg,
		title,
		cf, 
		p_iva,
		rowkind,
		competencydate,
		operationkind ,
		ymov ,
		nmov ,
		nvar ,
		npro_npay ,
		description,
		doc,
		docdate,
		proceeds,
		payment	
FROM #partitario 
ORDER BY title ASC, 
	competencydate ASC, 
	rowkind ASC,
	ymov ASC,
	nmov ASC,
	nvar ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


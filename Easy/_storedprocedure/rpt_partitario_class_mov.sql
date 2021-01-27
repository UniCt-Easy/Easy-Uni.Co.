
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_class_mov]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_class_mov]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [rpt_partitario_class_mov]
	@ayear smallint,
	@idsorkind int,
	@incomeorexpense  char(1),
	@start smalldatetime,
	@stop  smalldatetime,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1)
AS
BEGIN
	DECLARE @idupboriginal 	varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S') set @idupb=@idupb+'%' 
	
	CREATE TABLE #sortedmov
	(
		idsorkind  varchar(20),
		descriptionsortingkind varchar(50),
		sortcode varchar(50),
		sortingdescription varchar(200),
		adate smalldatetime,
		phasedescription varchar(50),
		ymov smallint,
		nmov int,
		registry varchar(100),
		codefin	varchar(50),
		idupb varchar(36),
		codeupb varchar(50),
		upb varchar(150),
		description varchar(300),  
		curramount decimal(19,2),
		sortedamount decimal(19,2)
	)
	
	DECLARE @descriptionsortingkind	varchar(50)
	SELECT @descriptionsortingkind = description
		FROM sortingkind
		WHERE idsorkind = @idsorkind

	DECLARE @nphasemovimento  tinyint
	IF (@incomeorexpense  = 'E')
	BEGIN
		SELECT @nphasemovimento = nphaseincome
			FROM sortingkind
			WHERE idsorkind = @idsorkind

		INSERT INTO #sortedmov
			(
				idsorkind,
				descriptionsortingkind,
				sortcode,
				sortingdescription,
				adate,
				phasedescription,
				ymov,
				nmov,
				registry,
				codefin,
				idupb,
				codeupb,
				upb, 
				description,
				curramount,
				sortedamount
			)
			SELECT
				@idsorkind,
				@descriptionsortingkind,
			  	sorting.sortcode,
				sorting.description,
				income.adate,
				incomephase.description,
				income.ymov,
				income.nmov,
				registry.title,
				fin.codefin,
				upb.idupb,
				upb.codeupb,
				upb.title, 
				--income.description,
				case 
				when isnull(income.doc,'')='' then income.description 
				when isnull(income.doc,'') <> '' and isnull(income.docdate,'')='' 
					then	income.description + 
						' (Doc. ' 
						+ isnull(Convert (varchar(35),ISNULL(income.doc,'')),'') + ')'
				else  income.description + 
					' (Doc. ' 
					+ isnull(Convert (varchar(35),ISNULL(income.doc,'')),'') + ' del '
					+ iSNULL(Convert (varchar(2),datepart(dd,income.docdate))+'/'+Convert (varchar(2),datepart(mm,income.docdate))+'/'+Convert (varchar(4),datepart(yy,income.docdate)),'')
					+')'	
				end,
				incometotal.curramount,
				incomesorted.amount
			FROM income
			JOIN incometotal
				ON incometotal.idinc = income.idinc
			JOIN incomeyear
				ON incomeyear.idinc = income.idinc
			JOIN incomesorted
				ON incomesorted.idinc = income.idinc
			JOIN sorting
				ON sorting.idsor = incomesorted.idsor
			JOIN incomephase
				ON incomephase.nphase = income.nphase
			LEFT OUTER JOIN registry
				ON registry.idreg = income.idreg
			LEFT OUTER JOIN fin
				ON fin.idfin = incomeyear.idfin
			LEFT OUTER JOIN upb 		
				on upb.idupb = incomeyear.idupb
			WHERE income.adate BETWEEN @start AND @stop
				AND incometotal.ayear = @ayear
				AND incomeyear.ayear = @ayear
				AND incomesorted.ayear=@ayear
				AND sorting.idsorkind = @idsorkind
				AND (  (incomeyear.idupb is null and @idupb='%') or (incomeyear.idupb like @idupb))		
		END
	IF (@incomeorexpense  = 'S')
	BEGIN
		SELECT 	@nphasemovimento = nphaseexpense
			FROM sortingkind
			WHERE idsorkind = @idsorkind

		INSERT INTO #sortedmov
			(
				idsorkind,
				descriptionsortingkind,
				sortcode,
				sortingdescription,
				adate,
				phasedescription,
				ymov,
				nmov,
				registry,
				codefin,
				idupb,
				codeupb,
				upb, 
				description,
				curramount,
				sortedamount
			)
			SELECT
				@idsorkind,
				@descriptionsortingkind,
				sorting.sortcode,
				sorting.description,
				expense.adate,
				expensephase.description,
				expense.ymov,
				expense.nmov,
				registry.title,
				fin.codefin,
				upb.idupb,
				upb.codeupb,
				upb.title, 
				case 
				when isnull(expense.doc,'')='' then expense.description 
				when isnull(expense.doc,'') <> '' and isnull(expense.docdate,'')='' 
					then	expense.description + 
						' (Doc. ' 
						+ isnull(Convert (varchar(35),ISNULL(expense.doc,'')),'') + ')'
				else  expense.description + 
					' (Doc. ' 
					+ isnull(Convert (varchar(35),ISNULL(expense.doc,'')),'') + ' del '
					+ iSNULL(Convert (varchar(2),datepart(dd,expense.docdate))+'/'+Convert (varchar(2),datepart(mm,expense.docdate))+'/'+Convert (varchar(4),datepart(yy,expense.docdate)),'')
					+')'	
				end,
				expensetotal.curramount,
				expensesorted.amount
			FROM expense
			JOIN expensetotal
			ON expensetotal.idexp = expense.idexp
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp
			JOIN expensesorted
				ON expensesorted.idexp = expense.idexp
			JOIN sorting
				ON sorting.idsor = expensesorted.idsor
			JOIN expensephase
				ON expensephase.nphase = expense.nphase
			LEFT OUTER JOIN registry
				ON registry.idreg = expense.idreg
			LEFT OUTER JOIN fin
				ON fin.idfin = expenseyear.idfin
			LEFT OUTER JOIN upb 		
				ON upb.idupb = expenseyear.idupb
			WHERE expense.adate BETWEEN isnull(@start, {d '1900-01-01'}) AND isnull(@stop, {d '2079-06-06'})
				AND expensetotal.ayear = @ayear
				AND expenseyear.ayear = @ayear
				AND sorting.idsorkind = @idsorkind
				AND expensesorted.ayear = @ayear
				AND (  (expenseyear.idupb is null and @idupb='%') or (expenseyear.idupb like @idupb))	
		END
	
/* nelle altre stampe viene preso il top 1 dalla tabella temporanea non dalla tabella upb. Questo è possibile perchè
	le altre stampe fanno un cross join per riempire la tab temporanea, mentre qui esegue solo una SELECT dei movimenti classificati.
*/
 	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
			UPDATE #sortedmov SET  
				upb = (SELECT TOP 1 title
					FROM upb
					WHERE idupb = @idupboriginal),
				idupb = @idupboriginal,
				codeupb =(SELECT TOP 1 codeupb
					FROM upb
					WHERE idupb = @idupboriginal)

/*	Questo segmento di codice è stato commentato perchè non serve porre a null
	il valore dell'UPB per annullare il raggruppamento nel report inquanto nel report non c'è un 
	raggruppamento ma solo una visualizzazione dell'UPB
	IF (@showupb <>'S') and (@idupboriginal = '%') 
				UPDATE #sortedmov SET  
				upb =  null,
				idupb = null,
				codeupb = null*/
	SELECT * FROM	 #sortedmov 
		ORDER BY idsorkind ASC, 
		sortcode ASC, 
		adate ASC,
		ymov ASC,
		nmov ASC
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

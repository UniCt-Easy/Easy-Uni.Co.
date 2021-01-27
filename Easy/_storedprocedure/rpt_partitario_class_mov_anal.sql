
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_class_mov_anal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_class_mov_anal]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE [rpt_partitario_class_mov_anal]
	@ayear smallint,
	@idsorkind int,
	@codefin varchar(30),
	@start smalldatetime,
	@stop smalldatetime,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@idman int

AS
BEGIN
--exec rpt_partitario_class_mov_anal 2006, 'MIUR', '',{ts '2006-01-01 00:00:00'}, {ts '2006-12-07 00:00:00'},'S','%','S',null

/* Versione 1.0.12 del 17/09/2007 ultima modifica: SARA */

DECLARE @maxphase tinyint
SET  @maxphase = (SELECT MAX(nphase) FROM expensephase)

DECLARE @movphase tinyint
SET  @movphase = (SELECT nphaseexpense
	FROM sortingkind 
	WHERE idsorkind = @idsorkind)


DECLARE @descfasemovimento varchar(30)
SET @descfasemovimento =  (SELECT  description
	FROM expensephase 
	WHERE nphase = @maxphase) 
	
DECLARE @flagvaliditadoc 	char(1)   	

SET @flagvaliditadoc = (SELECT cashvaliditykind
	FROM config
	WHERE ayear = @ayear)

DECLARE @desctipoclass varchar(35)
SET  @desctipoclass = (SELECT  description
	FROM sortingkind
	WHERE idsorkind = @idsorkind)

IF ISNULL(@codefin,'') = '' SET  @codefin = '%'

	
DECLARE @idupboriginal 	varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb+'%' 

CREATE TABLE #sorted
(
	sortcode varchar(50), 
	idsor varchar(39),
	sorting varchar(200), 
	idexp int,
	adate smalldatetime,
	phasedescription varchar(35),
	ymov smallint,
	nmov integer,
	idreg integer,
	fintitle varchar(150),
	codefin varchar(50), 
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	idman int,
	description varchar(250),  
	curramount decimal(19,2),
	sortedamount decimal(19,2),
	nphase tinyint,
	nphaseclass tinyint,
	tothierarchy varchar (50)
)
		
	INSERT INTO #sorted
	(
		sortcode,
		idsor,
		sorting,
		idexp,
		adate,
		phasedescription,
		nphase,
		ymov,
		nmov,
		idreg,
		codefin,
		fintitle,
		idupb,
		codeupb,
		upb, 
		idman,
		description,
		curramount,
		sortedamount
	)
	SELECT
		sorting.sortcode,
		sorting.idsor,
		sorting.description,
		expense.idexp,
		expense.adate,
		expensephase.description,
		expense.nphase,
		expense.ymov,
		expense.nmov,
		expense.idreg,
		fin.codefin,
		fin.title,
		upb.idupb,
		upb.codeupb,
		upb.title, 
		finlast.idman,
		expense.description,
		expensetotal.curramount,
		SUM(expensesorted.amount)
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
	LEFT OUTER JOIN upb 		
		ON upb.idupb = expenseyear.idupb
	LEFT OUTER JOIN fin
		ON fin.idfin = expenseyear.idfin
	LEFT OUTER JOIN finlast
		ON finlast.idfin = expenseyear.idfin
	WHERE expense.adate BETWEEN isnull(@start, {d '1900-01-01'}) AND isnull(@stop, {d '2079-06-06'})
		AND fin.codefin like @codefin AND (( fin.flag & 1)=1) 
		AND expensetotal.curramount <> 0
		AND (  (@idman is null) or (finlast.idman = @idman))	
		AND expensetotal.ayear = @ayear
		AND expenseyear.ayear = @ayear
		AND expense.nphase = @movphase
		AND sorting.idsorkind = @idsorkind
		AND expensesorted.ayear = @ayear
		AND ((expenseyear.idupb is null and @idupb='%') or (expenseyear.idupb like @idupb))	
	GROUP BY sorting.idsor,sorting.sortcode,sorting.description,
		expense.idexp,	expense.adate,	expensephase.description,
		expense.nphase,	expense.ymov,expense.nmov,expense.idreg,
		fin.codefin,fin.title,upb.idupb,
		upb.codeupb,upb.title, finlast.idman,expense.description,expensetotal.curramount
		

	IF @maxphase > @movphase
	BEGIN	
		INSERT INTO #sorted
		(
			sortcode,
			idsor,
			sorting,
			idexp,
			adate,
			phasedescription,
			nphase,
			ymov,
			nmov,
			idreg,
			codefin,
			fintitle,
			idupb,
			codeupb,
			upb, 
			idman,
			description,
			curramount,
			sortedamount
		)				
		SELECT 
			DISTINCT 
			#sorted.sortcode,
			#sorted.idsor,
			#sorted.sorting,
			expense.idexp,
			expense.adate,
			@descfasemovimento,
			expense.nphase,
			expense.ymov,
			expense.nmov,
			expense.idreg,
			#sorted.codefin,
			#sorted.fintitle,
			#sorted.idupb,
			#sorted.codeupb,
			#sorted.upb, 
			#sorted.idman,
			expense.description,
			expensetotal.curramount,
			expensetotal.curramount*#sorted.sortedamount/#sorted.curramount
		FROM #sorted
		JOIN expenselink
			ON #sorted.idexp = expenselink.idparent and expenselink.nlevel = @movphase
		JOIN expense
			ON expense.idexp = expenselink.idchild
		JOIN expensetotal
			ON expensetotal.idexp = expense.idexp
		WHERE expensetotal.ayear = @ayear
			AND expense.adate  BETWEEN isnull(@start, {d '1900-01-01'}) AND isnull(@stop, {d '2079-06-06'})
			AND expense.nphase = @maxphase
	END
			
	UPDATE #sorted
		SET description = description +  ISNULL(' - Mandato di pagamento n. '+CONVERT(varchar(6),
			(SELECT i.npay FROM  historypaymentview I
			WHERE i.idexp = #sorted.idexp)),'') + 
				ISNULL(' del '+CONVERT(varchar(10),
					(SELECT i.competencydate FROM  historypaymentview I
						WHERE i.idexp = #sorted.idexp),105),'')

	UPDATE #sorted SET nphaseclass = @movphase

UPDATE #sorted
SET sorting = 'NON CLASSIFICATO',
    sortcode = 'NON-C'
WHERE idsor IS NULL


IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #sorted SET  
			upb = (SELECT TOP 1 upb
				FROM #sorted
				WHERE idupb = @idupboriginal),
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #sorted	
				WHERE idupb = @idupboriginal)
IF (@showupb <>'S') and (@idupboriginal = '%') 
			UPDATE #sorted SET  
			upb =  null,
			idupb = null,
			codeupb = null

-- costruisce la gerarchia del movimento per creare l'ordinamento 
UPDATE #sorted 
SET 
	tothierarchy = 
        Replicate(0,4-len(convert(varchar(4),isnull(E1.ymov,0))))+ convert(varchar(4),isnull(E1.ymov,0))+ '/' + 
        Replicate(0,6-len(convert(varchar(6),isnull(E1.nmov,0))))+ convert(varchar(6),isnull(E1.nmov,0))+ ' '+

        Replicate(0,4-len(convert(varchar(4),isnull(E2.ymov,0))))+ convert(varchar(4),isnull(E2.ymov,0))+ '/' + 
        Replicate(0,6-len(convert(varchar(6),isnull(E2.nmov,0))))+ convert(varchar(6),isnull(E2.nmov,0))+ ' '+

        Replicate(0,4-len(convert(varchar(4),isnull(E3.ymov,0))))+ convert(varchar(4),isnull(E3.ymov,0))+ '/' + 
        Replicate(0,6-len(convert(varchar(6),isnull(E3.nmov,0))))+ convert(varchar(6),isnull(E3.nmov,0))+ ' '+

        Replicate(0,4-len(convert(varchar(4),isnull(E4.ymov,0))))+ convert(varchar(4),isnull(E4.ymov,0))+ '/' + 
        Replicate(0,6-len(convert(varchar(6),isnull(E4.nmov,0))))+ convert(varchar(6),isnull(E4.nmov,0))

FROM expense
JOIN expenselink EL1
	ON EL1.idchild = expense.idexp  AND EL1.nlevel = 1
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = expense.idexp  AND EL2.nlevel = 2
LEFT OUTER JOIN expenselink EL3
	ON EL3.idchild = expense.idexp  AND EL3.nlevel = 3
LEFT OUTER JOIN expenselink EL4
	ON EL4.idchild = expense.idexp  AND EL4.nlevel = 4
LEFT OUTER JOIN expense E1
	ON E1.idexp = EL1.idparent
LEFT OUTER JOIN expense E2
	ON E2.idexp = EL2.idparent
LEFT OUTER JOIN expense E4
	ON E4.idexp = EL4.idparent
LEFT OUTER JOIN expense E3
	ON E3.idexp = EL3.idparent
WHERE  EL1.idchild = #sorted.idexp

	SELECT 
		@idsorkind as 'idsorkind', 
      	       	@desctipoclass as 'descriptionsortingkind', 
       	       	#sorted.sortcode,
	       	#sorted.idsor,
	       	#sorted.sorting,
	      	#sorted.idexp,
		#sorted.adate,
		#sorted.phasedescription,
		#sorted.ymov,
		#sorted.nmov,
	       	registry.title as 'registry',
	      	#sorted.codefin,
	       	#sorted.fintitle,
		#sorted.idupb,
		#sorted.codeupb,
		#sorted.upb,
		manager.title as 'manager',
		#sorted.description,  
		#sorted.curramount,
		#sorted.sortedamount,
		#sorted.nphase,
		#sorted.nphaseclass
	FROM #sorted
	JOIN expenseyear
		ON expenseyear.idexp = #sorted.idexp
	LEFT OUTER JOIN registry
		ON registry.idreg = #sorted.idreg
	LEFT OUTER JOIN manager
		ON manager.idman = #sorted.idman
	WHERE expenseyear.ayear = @ayear
	ORDER BY codefin ASC, 
	#sorted.sortcode ASC, 
	#sorted.tothierarchy ASC,
	#sorted.adate ASC,
	#sorted.ymov ASC,
	#sorted.nmov ASC

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

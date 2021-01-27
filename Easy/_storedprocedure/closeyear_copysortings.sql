
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_copysortings]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_copysortings]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [closeyear_copysortings]
(
	@ysource int,
	@movementkind char(1),  -- I/E Income / Expense
	@overwrite char(1)   --S/N
)
AS BEGIN
DECLARE @ydest int
SET @ydest = @ysource + 1
-- [closeyear_copysortings] 2012, 'S', 'S'
DECLARE @maxincomephase tinyint
DECLARE @maxexpensephase tinyint
SELECT @maxincomephase = max(nphase) from incomephase
SELECT @maxexpensephase = max(nphase) from expensephase

IF (@overwrite='S')
BEGIN
	IF (@movementkind='E')
	BEGIN
		DELETE FROM expensesorted WHERE (ayear = @ydest)
		AND EXISTS
			(SELECT * FROM expensesorted I
			JOIN sorting S
				ON S.idsor = I.idsor
			JOIN sorting S_EXT
				ON S_EXT.idsor = expensesorted.idsor
			WHERE (I.idexp = expensesorted.idexp)
				AND (I.ayear = @ysource)
				AND (S.idsorkind = S_EXT.idsorkind))
	END
	ELSE
	BEGIN
		DELETE FROM incomesorted WHERE (ayear = @ydest)
		AND EXISTS
			(SELECT * FROM incomesorted I
			JOIN sorting S
				ON S.idsor = I.idsor
			JOIN sorting S_EXT
				ON S_EXT.idsor = incomesorted.idsor
			WHERE (I.idinc = incomesorted.idinc)
				AND (I.ayear = @ysource)
				AND (S.idsorkind = S_EXT.idsorkind))
	END
END

PRINT 'Inizio: '
PRINT @ysource

-- tabella temporanea per i residui attivi/passivi multiclassificati
CREATE TABLE #movfinsorted
	(
		original_idsor   	int,
		original_idsorkind	int,
		lastphase_idsorkind	int,
		idexp_or_idinc		int,
		idsubclass		int,
		class_amount		decimal(19,2),
		startyear_amount		decimal(19,2),
		newyear_amount		decimal(19,2),
		lastphase_amount	decimal(19,2)
	)

IF (@movementkind='I')
BEGIN      
	IF EXISTS
		(SELECT * FROM incomesorted A1 
		JOIN incomeyear A2 
			ON A1.idinc = A2.idinc 
		WHERE (A1.ayear = @ysource)
			AND (A2.ayear = @ydest)
			AND
				(SELECT COUNT(*)
				FROM incomesorted II2
				WHERE (II2.idinc = A1.idinc)
					AND (II2.idsor=A1.idsor)
					AND (II2.ayear= @ydest)) = 0)
	BEGIN

DECLARE @idsorkindInc int
DECLARE @nphaseincome tinyint
DECLARE @siopeI_kind int

DECLARE crskindInc  cursor LOCAL STATIC FOR 
SELECT idsorkind,isnull(nphaseincome,0) FROM sortingkind  FOR READ ONLY

OPEN crskindInc

FETCH NEXT FROM crskindInc INTO @idsorkindInc, @nphaseincome
WHILE @@fetch_status=0 begin

			IF ( 
			EXISTS (select * from sortingkind where idparentkind = @idsorkindInc)
			AND ( (select ISNULL(nphaseincome,0) from sortingkind where idparentkind = @idsorkindInc) = @maxincomephase )
			)
			BEGIN
				SELECT @siopeI_kind = idsorkind from sortingkind where idparentkind = @idsorkindInc

				--Inserisce i dettagli delle classificazioni sull'accertamento, 
				--raggruppati sullo stesso codice, e le classificazioni 
				--degli incassi, raggruppati sullo stesso codice Siope
				DELETE FROM #movfinsorted
				INSERT INTO #movfinsorted
					(
						original_idsor   	,
						original_idsorkind	,
						lastphase_idsorkind	,
						idexp_or_idinc		,
						class_amount		,
						startyear_amount, 
						newyear_amount,
						lastphase_amount	,
						idsubclass
					)
				SELECT
						I.idsor,
						@idsorkindInc,
						@siopeI_kind,	
						I.idinc,
						--ISNULL(SUM(I.amount),0),
						SUM(I.amount),I0.amount,I1.curramount,			 
						(SELECT ISNULL(SUM(ES.amount),0)
						FROM incomesorted ES
						JOIN sorting S
							ON ES.idsor = S.idsor and S.idsorkind = @siopeI_kind --@SIOPE
						JOIN incomelast E
							ON E.idinc = ES.idinc 
						JOIN incomelink EL
							ON E.idinc=EL.idchild
							AND EL.nlevel = @nphaseincome --@nphase_eMIUR
						JOIN income EPADRE
							ON EPADRE.idinc=EL.idparent
						JOIN sorting MIUR
							ON  S.sortcode = MIUR.sortcode
						WHERE ES.ayear = @ysource 
							AND MIUR.idsor = I.idsor 
							AND MIUR.idsorkind = @idsorkindInc --@MIUR 
							AND EPADRE.idinc = I.idinc),
						(SELECT MAX(idsubclass) 
							FROM  incomesorted 
							WHERE incomesorted.idsor = I.idsor 
							AND   incomesorted.idinc = I.idinc 
						)
					FROM incomesorted I 
					JOIN incomeyear I0
						ON I0.idinc=I.idinc
					JOIN incometotal I1
						ON I1.idinc=I.idinc
					JOIN sorting
						ON sorting.idsor = I.idsor 
					WHERE
						sorting.idsorkind=@idsorkindInc 
					--prende la classificazione dell'esercizio N-mo
						AND (I.ayear=@ysource)
					--esiste l'imputazione nell'anno sorgente
						AND (I0.ayear=@ysource+1)
					--esiste l'imputazione nell'anno successivo
						AND (I1.ayear=@ysource+1)  
					--non esiste l'imputazione di quella classificazione nell'esercizio successivo
						AND (SELECT COUNT(*) FROM incomesorted I2
							WHERE (I2.idinc= I.idinc)
								AND (I2.idsor=I.idsor)	
								AND (I2.ayear= @ydest))=0
						 GROUP BY I.idsor,I.idinc,I0.amount,I1.curramount	

					
					-- SOTTRAE all'importo dell'accertamento la class.siope dell'Incasso
					INSERT INTO incomesorted 
					(
						idsor,idinc,idsubclass,ct,cu,stop,start,
						description,flagnodate,tobecontinued,amount,
						lt,lu,txt,rtf,
						paridsor,paridsubclass,valuen1,valuen2,valuen3,valuen4,valuen5,
						values1,values2,values3,values4,values5,
						valuev1,valuev2,valuev3,valuev4,valuev5,
						ayear
					)
 					SELECT
						original_idsor,idexp_or_idinc,idsubclass +1,GetDate(),'SortingsCopy2',null,null,
						null,null,null, (isnull(class_amount,0) - isnull(lastphase_amount,0))*newyear_amount/startyear_amount,
						GetDate(),'SortingsCopy2',null,null,
						null,null,null,null,null, null,null,
						null,null,null, null,null,
						null,null,null, null,null,
						@ydest
					FROM #movfinsorted
					WHERE isnull(class_amount,0) - isnull(lastphase_amount,0) <>0 and startyear_amount<>0
					
					

				END
			ELSE
			BEGIN
			-- LAVORA COME PRIMA
				
				INSERT INTO incomesorted 
				(
					idsor,idinc,idsubclass,ct,cu,stop,start,
					description,flagnodate,tobecontinued,amount,lt,lu,txt,rtf,
					paridsor,paridsubclass,valuen1,valuen2,valuen3,valuen4,valuen5,
					values1,values2,values3,values4,values5,valuev1,valuev2,valuev3,valuev4,valuev5,ayear
				)
     				SELECT I.idsor,I.idinc,
					ISNULL(
						(SELECT I1.idsubclass FROM incomesorted I1
						WHERE (I1.idsubclass=I.idsubclass)
							AND (I1.idsor=I.idsor)
							AND (I1.idinc=I.idinc))
					,0)
					- ISNULL(
						(SELECT MIN(I1.idsubclass) FROM incomesorted I1
						WHERE (I1.idsor=I.idsor)
							AND (I1.idinc=I.idinc)
							AND (I1.ayear = @ysource))
					,0)
					+ ISNULL(
						(SELECT MAX(IA.idsubclass) FROM incomesorted IA
						WHERE (IA.idsor=I.idsor)
							AND (IA.idinc=I.idinc))
					,0)
					+1,
					I.ct,I.cu,I.stop,I.start,
					I.description,I.flagnodate,I.tobecontinued,
					CASE
						WHEN I1.curramount=I0.curramount THEN I.amount 
						ELSE I.amount*(CONVERT(float,I1.curramount)/CONVERT(float,I0.curramount))
					END,
					I.lt,I.lu,I.txt,I.rtf,
					I.paridsor,I.paridsubclass,I.valuen1,I.valuen2,I.valuen3,I.valuen4,I.valuen5,
					I.values1,I.values2,I.values3,I.values4,I.values5,I.valuev1,I.valuev2,I.valuev3,I.valuev4,I.valuev5,
					@ydest
				FROM incomesorted I 
				JOIN incometotal I0
					ON I0.idinc=I.idinc
				JOIN incometotal I1
					ON I1.idinc=I.idinc
				JOIN sorting
					ON sorting.idsor = I.idsor 
				WHERE
					sorting.idsorkind=@idsorkindInc 
				--prende la classificazione dell'esercizio N-mo
					AND (I.ayear=@ysource)
				--esiste l'imputazione nell'anno sorgente
					AND (I0.ayear=@ysource)
				--esiste l'imputazione nell'anno successivo
					AND (I1.ayear=@ysource+1)
				--non esiste l'imputazione di quella classificazione nell'esercizio successivo
					AND (SELECT COUNT(*) from incomesorted I2
						WHERE (I2.idinc= I.idinc)
							AND (I2.idsor=I.idsor)
							AND (I2.ayear= @ydest))=0
			END

	FETCH NEXT FROM crskindInc INTO @idsorkindInc,@nphaseincome
	end

	deallocate crskindInc

END
END

ELSE
BEGIN
	IF EXISTS(SELECT * FROM expensesorted A1 
		JOIN expenseyear A2
			ON A1.idexp=A2.idexp 
		WHERE (A1.ayear=@ysource)
			AND (A2.ayear=@ydest)
			AND
				(SELECT COUNT(*)
				from expensesorted II2
				where (II2.idexp= A1.idexp)
					AND (II2.idsor=A1.idsor)
					AND (II2.ayear= @ydest))=0)
	BEGIN
	print 'ramo A'
declare @idsorkindExp int
declare @nphaseexpense tinyint
declare @siopeE_kind int

declare @counter int

DECLARE crskindExp  cursor LOCAL STATIC FOR 
SELECT idsorkind,isnull(nphaseexpense,0) FROM sortingkind  FOR READ ONLY

OPEN crskindExp

FETCH NEXT FROM crskindExp INTO @idsorkindExp, @nphaseexpense
WHILE @@fetch_status=0 begin
			print '@idsorkindExp:'
			print @idsorkindExp
			IF ( 
				EXISTS (select * from sortingkind where idparentkind = @idsorkindExp)
			AND 
				( (select ISNULL(nphaseexpense,0) from sortingkind where idparentkind = @idsorkindExp) = @maxexpensephase )
				)
			BEGIN
				SELECT @siopeE_kind = idsorkind from sortingkind where idparentkind = @idsorkindExp
				print 'ramo a1'
			--Inserisce i dettagli delle classificazioni sull'impegno, 
			--raggruppati sullo stesso codice, e le classificazioni 
			--dei pagamenti, raggruppati sullo stesso codice Siope
				DELETE FROM #movfinsorted
				INSERT INTO #movfinsorted
					(
						original_idsor   	,
						original_idsorkind	,
						lastphase_idsorkind	,
						idexp_or_idinc		,
						class_amount,startyear_amount, newyear_amount,
						lastphase_amount	,
						idsubclass		
					)
				SELECT
						I.idsor,
						@idsorkindExp,
						@siopeE_kind,
						I.idexp,
						SUM(I.amount),I0.amount,I1.curramount,	
						(SELECT ISNULL(SUM(ES.amount),0)
						FROM expensesorted ES
						JOIN sorting S
							ON ES.idsor = S.idsor and S.idsorkind = @siopeE_kind--@SIOPE
						JOIN expenselast E
							ON E.idexp = ES.idexp 
						JOIN expenselink EL
							ON E.idexp=EL.idchild
							AND EL.nlevel = @nphaseexpense--@nphase_eMIUR
						JOIN expense EPADRE
							ON EPADRE.idexp=EL.idparent
						JOIN sorting MIUR
							ON  S.sortcode = MIUR.sortcode
						WHERE ES.ayear = @ysource 
							AND MIUR.idsor = I.idsor 
							AND MIUR.idsorkind = @idsorkindExp--@MIUR 
							AND EPADRE.idexp = I.idexp),
						(SELECT MAX(idsubclass) 
							FROM  expensesorted 
							WHERE expensesorted.idsor = I.idsor 
							AND   expensesorted.idexp = I.idexp 
						)
				FROM expensesorted I 
				JOIN expenseyear I0
					ON I0.idexp=I.idexp
				JOIN expensetotal I1
					ON I1.idexp=I.idexp
				JOIN sorting
					ON sorting.idsor = I.idsor 
				WHERE
				sorting.idsorkind=@idsorkindExp 
				--prende la classificazione dell'esercizio N-mo
				AND (I.ayear=@ysource)
				--esiste l'imputazione nell'anno sorgente
					AND (I0.ayear=@ysource+1)
				--esiste l'imputazione nell'anno successivo
					AND (I1.ayear=@ysource+1)
				--non esiste l'imputazione di quella classificazione nell'esercizio successivo
					AND (SELECT COUNT(*) FROM expensesorted I2
						WHERE (I2.idexp= I.idexp)
							AND (I2.idsor=I.idsor)	
							AND (I2.ayear= @ydest))=0
				GROUP BY I.idsor,I.idexp,I0.amount,I1.curramount

				
				select * from #movfinsorted order by idexp_or_idinc
				-- SOTTRAE all'importo dell'impegno la class.siope del pagamento
				INSERT INTO expensesorted 
					(
						idsor,idexp,idsubclass,ct,cu,stop,start,
						description,flagnodate,tobecontinued,amount,lt,lu,txt,rtf,
						paridsor,paridsubclass,valuen1,valuen2,valuen3,valuen4,valuen5,
						values1,values2,values3,values4,values5,valuev1,valuev2,valuev3,valuev4,valuev5,ayear
					)
				SELECT 
					original_idsor,idexp_or_idinc,idsubclass +1,GetDate(),'SortingsCopy2',null,null,
					null,null,null,   (isnull(class_amount,0) - isnull(lastphase_amount,0))*newyear_amount/startyear_amount,
					GetDate(),'SortingsCopy2',null,null,
					null,null,null,null,null, null,null,
					null,null,null, null,null,
					null,null,null, null,null,
					@ydest
				FROM #movfinsorted
				WHERE isnull(class_amount,0) - isnull(lastphase_amount,0) <> 0 and startyear_amount<>0

				
			END
			ELSE
			BEGIN
			print 'ramo B'
			-- LAVORA COME PRIMA
					INSERT INTO expensesorted 
					(
						idsor,idexp,idsubclass,ct,cu,stop,start,
						description,flagnodate,tobecontinued,amount,lt,lu,txt,rtf,
						paridsor,paridsubclass,valuen1,valuen2,valuen3,valuen4,valuen5,
						values1,values2,values3,values4,values5,valuev1,valuev2,valuev3,valuev4,valuev5,ayear
					)
 					SELECT
						I.idsor,I.idexp,
						ISNULL(
							(SELECT I1.idsubclass FROM expensesorted I1
							WHERE (I1.idsubclass=I.idsubclass)
								AND (I1.idsor=I.idsor)
								AND (I1.idexp=I.idexp))
						,0)
						- ISNULL(
							(SELECT MIN(I1.idsubclass) FROM expensesorted I1
							WHERE (I1.idsor=I.idsor)
								AND (I1.idexp=I.idexp)
								AND (I1.ayear = @ysource))
						,0)
						+ ISNULL(
							(SELECT MAX(IA.idsubclass) FROM expensesorted IA
							WHERE (IA.idsor=I.idsor)
								AND (IA.idexp=I.idexp))
						,0)
						+1,
						getdate(),'SortingsCopy2',I.stop,I.start,
						I.description,I.flagnodate,I.tobecontinued,
						CASE
							WHEN I1.curramount=I0.curramount THEN I.amount 
							ELSE I.amount*(CONVERT(float,I1.curramount)/CONVERT(float,I0.curramount))
						END,
						I.lt,I.lu,I.txt,I.rtf,
						I.paridsor,I.paridsubclass,I.valuen1,I.valuen2,I.valuen3,I.valuen4,I.valuen5,
						I.values1,I.values2,I.values3,I.values4,I.values5,I.valuev1,I.valuev2,I.valuev3,I.valuev4,I.valuev5,
						@ydest
					FROM expensesorted I 
					JOIN expensetotal I0
						ON I0.idexp=I.idexp
					JOIN expensetotal I1
						ON I1.idexp=I.idexp
					JOIN sorting
						ON sorting.idsor = I.idsor 
					WHERE
					sorting.idsorkind=@idsorkindExp 
					--prende la classificazione dell'esercizio N-mo
					AND (I.ayear=@ysource)
					--esiste l'imputazione nell'anno sorgente
						AND (I0.ayear=@ysource)
					--esiste l'imputazione nell'anno successivo
						AND (I1.ayear=@ysource+1)
					--non esiste l'imputazione di quella classificazione nell'esercizio successivo
						AND (SELECT COUNT(*) FROM expensesorted I2
							WHERE (I2.idexp= I.idexp)
								AND (I2.idsor=I.idsor)	--
								AND (I2.ayear= @ydest))=0

			END
	
	FETCH NEXT FROM crskindExp INTO @idsorkindExp,@nphaseexpense
end

deallocate crskindExp


	END
END

PRINT 'Finisco: '
PRINT @ysource
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



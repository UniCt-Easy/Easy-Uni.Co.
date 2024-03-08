
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_operazione_fondo_economale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_operazione_fondo_economale]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE           PROCEDURE [rpt_operazione_fondo_economale]
	@ayear int,
	@codicefondo int,
	@startnop int,
	@stopnop int,
	@idsorkind int
AS						      
BEGIN		
/*
 
 exec rpt_operazione_fondo_economale 2008, 21, 1, 50, 23 -- SIOPE
 exec rpt_operazione_fondo_economale 2008, 21, 1, 50, 19 -- MIUR
*/
DECLARE @nphase INT
SELECT  @nphase = expenseregphase FROM uniconfig

DECLARE @sorting_phase tinyint		
SELECT @sorting_phase = nphaseexpense FROM sortingkind WHERE idsorkind=@idsorkind

DECLARE @codesorkind varchar(20)
DECLARE @sorkind varchar(50)
SELECT @codesorkind = codesorkind ,
        @sorkind = description
FROM sortingkind where idsorkind=@idsorkind


CREATE TABLE #piccola_spesa(
	rowkind int, 
	yoperation int, 
	noperation int, 
	yrestore int, 
	nrestore int, 
	adate datetime, 
	amount decimal(19,2), 
	description varchar(500),
	doc varchar(100), docdate datetime, 
	pettycash varchar(500), 
	idupb varchar(100), codeupb varchar(100),
	title varchar(500), idfin int, codefin varchar(100), 
	ymov int, nmov int,idexpIx int,
	txt text, nphase int, 
	class_operation varchar(500),code_class_operation varchar(100),
	payment varchar(200),
	bursarship varchar(100),
	organizational_unit varchar(100)
	)

INSERT INTO #piccola_spesa (rowkind, yoperation, noperation, 
	yrestore, nrestore, adate, amount, description, doc, docdate, pettycash,
	idupb, codeupb, title, idfin, codefin, ymov, nmov, idexpIx, txt, nphase, class_operation, code_class_operation,
	bursarship,organizational_unit)

------------------------------------------------------------------------------------------------
-- Caricamento tabella nel caso in cui esista il collegamento fra l'operazione piccola spesa  --
-- ed un movimento di spesa per il reintegro ---------------------------------------------------
------------------------------------------------------------------------------------------------

-- 1)operazioni classificate direttamente con SIOPE: imputazione fatta
-- con il  movimento di spesa da associare al reintegro
SELECT 
        1,
        pco.yoperation,
        pco.noperation,
        pco.yrestore,
        pco.nrestore,
        pco.adate,
        pco.amount,
        pco.description, 
        pco.doc,
        pco.docdate,
        pc.description,
        u.idupb,
        u.codeupb,
        u.title,
        f.idfin,
        f.codefin,
        E2.ymov,--ISNULL(e1.ymov,e2.ymov),
        E2.nmov,--ISNULL(e1.nmov,e2.nmov),
		E2.idexp,
        pco.txt,
        E2.nphase,--ISNULL(e1.nphase,e2.nphase),
        spos.description,
        spos.sortcode,
        pc.bursarship,
        pc.organizational_unit 
FROM pettycashoperation pco
JOIN pettycash pc
	ON pco.idpettycash=pc.idpettycash
JOIN pettycashoperationsorted pos
	ON pos.yoperation = pco.yoperation
	AND pos.noperation = pco.noperation
	AND pos.idpettycash=pco.idpettycash
JOIN sorting spos
	ON pos.idsor=spos.idsor
JOIN sortingkind skpos
	ON skpos.idsorkind = spos.idsorkind
	and skpos.codesorkind = @codesorkind
JOIN expense e   -- movimento di spesa da associare al reintegro
	ON pco.idexp = e.idexp 
LEFT OUTER JOIN expenseyear ey
	ON e.idexp = ey.idexp
-- individuo la fase impegno tra le fasi del movimento di spesa del reintegro --
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = E.idexp  AND EL2.nlevel = @nphase
LEFT OUTER JOIN expense E2
    ON E2.idexp = isnull(EL2.idparent, pco.idexp)
LEFT OUTER JOIN fin f
	ON f.idfin = ey.idfin
LEFT OUTER JOIN upb u
	ON u.idupb = ey.idupb
WHERE pc.idpettycash = @codicefondo
		AND ey.ayear= @ayear
        AND   pco.yoperation = @ayear
        AND   pco.noperation BETWEEN @startnop AND @stopnop
        AND   (pco.flag & 8) != 0 

--2) operazioni non classificate direttamente con SIOPE: imputazione con il  movimento di spesa da associare al reintegro

INSERT INTO #piccola_spesa (rowkind, yoperation, noperation, yrestore, nrestore, adate, amount, description, doc, docdate, pettycash,
idupb, codeupb, title, idfin, codefin, ymov, nmov, idexpIx, txt, nphase, class_operation, code_class_operation,
bursarship,organizational_unit)

SELECT 
        2,
        pco.yoperation,
        pco.noperation,
        pco.yrestore,
        pco.nrestore,
        pco.adate,
        pco.amount,
        pco.description, 
        pco.doc,
        pco.docdate,
        pc.description,
        u.idupb,
        u.codeupb,
        u.title,
        f.idfin,
        f.codefin,
        E2.ymov,
        E2.nmov,
		E2.idexp,
        pco.txt,
        E2.nphase,
        S.description,--null
		S.sortcode, -- null
        pc.bursarship,
        pc.organizational_unit
FROM pettycashoperation pco
JOIN pettycash pc
	ON pco.idpettycash=pc.idpettycash
JOIN expense E
	on pco.idexp = E.idexp 
JOIN expenseyear ey
	on e.idexp = ey.idexp
-- individuo la fase impegno tra le fasi del movimento di spesa del reintegro --
LEFT OUTER JOIN expenselink EL2
	ON EL2.idchild = E.idexp  AND EL2.nlevel = @nphase
LEFT OUTER JOIN expense E2
	ON E2.idexp = isnull(EL2.idparent, pco.idexp)
LEFT OUTER JOIN expensesorted E2S
	ON E2.idexp = E2S.idexp -- AND E2.nphase = @sorting_phase-- la classificazione della fase nexpensephase di sorkind
LEFT JOIN sorting S
	ON E2S.idsor = S.idsor and S.idsorkind  = @idsorkind
LEFT OUTER JOIN fin f
	ON f.idfin = ey.idfin
LEFT OUTER JOIN upb u
	ON u.idupb=ey.idupb
WHERE pc.idpettycash = @codicefondo
		AND ey.ayear= @ayear
        AND   pco.yoperation = @ayear
        AND   pco.noperation BETWEEN @startnop AND @stopnop
        AND   (pco.flag & 8) != 0 
        AND  NOT EXISTS 
	(SELECT * FROM pettycashoperationsorted pos
		  JOIN sorting spos
		    ON pos.idsor=spos.idsor
		  JOIN sortingkind skpos
		    ON skpos.idsorkind = spos.idsorkind
		   AND skpos.codesorkind =@codesorkind
		WHERE  pos.yoperation = pco.yoperation
		  AND  pos.noperation = pco.noperation
		  AND  pos.idpettycash= pco.idpettycash
	)

--- 3) Operazioni in cui l'imputazione è stata fatta direttamente
--  e  direttamente classificate 
INSERT INTO #piccola_spesa (rowkind, yoperation, noperation, yrestore, nrestore, adate, amount, description, doc, docdate, pettycash,
idupb, codeupb, title, idfin, codefin, ymov, nmov,idexpIx, txt, nphase, class_operation, code_class_operation,
bursarship,organizational_unit )
SELECT 
        3,
        pco.yoperation,
        pco.noperation,
        pco.yrestore,
        pco.nrestore,
        pco.adate,
        pco.amount,
        pco.description,
        pco.doc,
        pco.docdate,
        pc.description,
        u.idupb,
        u.codeupb,
        u.title,
        f.idfin,
        f.codefin,
        null, --e.ymov,
        null, --e.nmov,
		null,
        pco.txt,
        NULL,--e.nphase,
        spos.description,
        spos.sortcode ,
        pc.bursarship,
        pc.organizational_unit 
FROM pettycashoperation pco
JOIN pettycash pc
	ON pco.idpettycash=pc.idpettycash
--------------------------------------------------
-- imputazione operazione eseguita direttamente --
--------------------------------------------------
JOIN fin f
	ON f.idfin = pco.idfin
	AND f.ayear=@ayear
JOIN upb u
	ON u.idupb=pco.idupb
JOIN pettycashoperationsorted pos
	ON pos.yoperation   = pco.yoperation
	AND pos.noperation  = pco.noperation
	AND pos.idpettycash = pco.idpettycash
JOIN sorting spos
	ON pos.idsor=spos.idsor
WHERE pc.idpettycash = @codicefondo
		and spos.idsorkind  = @idsorkind
        AND   pco.yoperation = @ayear
        AND   pco.noperation BETWEEN @startnop AND @stopnop
        AND   (pco.flag & 8) != 0 

--- 4) Operazioni in cui l'imputazione è stata fatta direttamente
--  e  non direttamente classificate 
INSERT INTO #piccola_spesa (rowkind, yoperation, noperation, yrestore, nrestore, adate, amount, description, doc, docdate, pettycash,
idupb, codeupb, title, idfin, codefin, ymov, nmov,idexpIx, txt, nphase, class_operation, code_class_operation,
bursarship,organizational_unit )
SELECT 
        4,
        pco.yoperation,
        pco.noperation,
        pco.yrestore,
        pco.nrestore,
        pco.adate,
        pco.amount,
        pco.description,
        pco.doc,
        pco.docdate,
        pc.description,
        u.idupb,
        u.codeupb,
        u.title,
        f.idfin,
        f.codefin,
        null, --e.ymov,
        null, --e.nmov,
		null,
        pco.txt,
        NULL,--e.nphase,
        null,
        null, 
        pc.bursarship,
        pc.organizational_unit 
FROM pettycashoperation pco
JOIN pettycash pc
	ON pco.idpettycash=pc.idpettycash
JOIN fin f
	ON f.idfin = pco.idfin
	AND f.ayear=@ayear
JOIN upb u
	ON u.idupb=pco.idupb
WHERE pc.idpettycash = @codicefondo
        AND   pco.yoperation = @ayear
        AND   pco.noperation BETWEEN @startnop AND @stopnop
        AND   (pco.flag & 8) != 0 
        AND  NOT EXISTS 
        	(SELECT * FROM pettycashoperationsorted pos
        		  JOIN sorting spos
        		    ON pos.idsor=spos.idsor
        		  JOIN sortingkind skpos
        		    ON skpos.idsorkind = spos.idsorkind
        		   AND skpos.codesorkind =@codesorkind
        		WHERE  pos.yoperation = pco.yoperation
        		  AND  pos.noperation = pco.noperation
        		  AND  pos.idpettycash= pco.idpettycash
        	)


CREATE TABLE #sorting_reintegro
	(
	 	rowkind int, 
	 	yoperation int, 
	 	noperation int, 
		idexp_maxphase int, 
		class_imp varchar(500), 
		sortcode varchar(200)
	)

-- leggo le classificazioni SIOPE eventualmente associate all'ultima fase del reintegro
-- se le singole operazioni non sono state classificate direttamente
INSERT INTO #sorting_reintegro
(
	rowkind , 
 	yoperation , 
 	noperation , 
	idexp_maxphase , 
	class_imp , 
	sortcode 
)
SELECT 
	po.rowkind , 
	po.yoperation , 
	po.noperation ,
	e.idexp,
	s.description,
	s.sortcode
FROM #piccola_spesa po
JOIN pettycashexpense pce
	ON  po.yrestore 	= pce.yoperation
	AND po.nrestore 	= pce.noperation
	AND @codicefondo  	= pce.idpettycash
JOIN expense e
	ON  e.idexp = pce.idexp
	AND e.nphase = @sorting_phase
JOIN expenseyear ey
	ON   ey.idexp    = e.idexp
	AND  ey.ayear    = @ayear
	AND  ey.idfin    = po.idfin
	AND  ey.idupb    = po.idupb
JOIN expensesorted es
	ON e.idexp  = es.idexp
JOIN sorting s
	ON es.idsor=s.idsor
JOIN sortingkind sk
	ON sk.idsorkind = s.idsorkind
	AND sk.codesorkind =@codesorkind 
WHERE po.rowkind IN (2,4)
        AND po.nrestore IS NOT NULL
--        AND class_imp IS NULL


UPDATE #piccola_spesa
SET  #piccola_spesa.ymov = e.ymov,
     #piccola_spesa.nmov = e.nmov,
	 #piccola_spesa.idexpIx	= e.idexp
FROM #piccola_spesa po
	JOIN pettycashexpense pce
		ON  po.yrestore 	= pce.yoperation
		AND po.nrestore 	= pce.noperation
		AND @codicefondo  	= pce.idpettycash
	JOIN expense e
		ON  e.idexp = pce.idexp
		AND e.nphase = @nphase
    JOIN expenseyear EY
        ON EY.idexp = E.idexp
WHERE po.rowkind IN (3,4)
        AND EY.idfin = po.idfin AND EY.idupb = po.idupb
        AND EY.ayear = @ayear
        AND po.nrestore IS NOT NULL

-- Valorizza il numero del mandato
UPDATE #piccola_spesa SET payment = 'Mandato '
DECLARE @npay int
DECLARE @idexpIx int
declare @noperation int

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT distinct payment.npay, #piccola_spesa.idexpIx, noperation  
	FROM payment
	JOIN expenselast
		ON payment.kpay = expenselast.kpay
	JOIN expenselink 
		ON expenselast.idexp = expenselink.idchild and expenselink.nlevel = @nphase
	JOIN #piccola_spesa
		ON expenselink.idparent = #piccola_spesa.idexpIx
	
	OPEN cursore
	FETCH NEXT FROM cursore INTO @npay, @idexpIx,@noperation
 
	WHILE (@@fetch_status=0) 
	BEGIN
	
		UPDATE #piccola_spesa SET payment = isnull(payment,'') + ' n° '+isnull(convert(varchar(10),@npay),'') + '; '
		WHERE #piccola_spesa.idexpIx = @idexpIx and #piccola_spesa.noperation  = @noperation 
		
	FETCH NEXT FROM cursore INTO @npay, @idexpIx, @noperation
	END
	
CLOSE cursore
DEALLOCATE cursore



SELECT 
        @sorkind  as sorkind,
        #piccola_spesa.yoperation,
        #piccola_spesa.noperation,
        adate,
        amount, 
        #piccola_spesa.description as 'descriz_operazione',
        doc,
        docdate,
        pettycash  as 'descriz_fondo',
        idupb ,
        codeupb,
        title,
        codefin,
        ymov,
        nmov,
		payment,
        #sorting_reintegro.class_imp  as 'descriz_class_imp',
        #sorting_reintegro.sortcode as 'code_class_imp',
        txt,
        #piccola_spesa.nphase,
		expensephase.description as expensephase,
        class_operation  'descriz_class_op',
        code_class_operation as 'code_class_op',
        #piccola_spesa.bursarship,
        #piccola_spesa.organizational_unit 
FROM #piccola_spesa
LEFT OUTER JOIN #sorting_reintegro
	ON #piccola_spesa.rowkind = #sorting_reintegro.rowkind
	AND #piccola_spesa.yoperation = #sorting_reintegro.yoperation
	AND #piccola_spesa.noperation = #sorting_reintegro.noperation
left outer join expensephase
	on expensephase.nphase = #piccola_spesa.nphase
ORDER BY #piccola_spesa.noperation

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_operazione_fondo_economale 2015, 5, 1, 111, 21


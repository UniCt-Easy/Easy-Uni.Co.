
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


--Aggiorno tutte le contabilizzazioni generiche di expensemandate, con esercizio uguale oppure
--precedente al 2006, su ordini attivi, singole e totali
DECLARE @ayear int
SET @ayear = 1 + ISNULL((SELECT MAX(ayear) FROM accountingyear WHERE flag>=5),0)

-- Caso 1. contratto passivo contabilizzato totalmente da un singolo impegno
-- Contabilizzazione TOTALE del contratto passivo (ORDIN)
UPDATE mandatedetail 
SET idexp_taxable = M.idexp,
    idexp_iva     = M.idexp
FROM expensemandate M
WHERE (SELECT COUNT(*) FROM expensemandate
	WHERE idmankind = mandatedetail.idmankind
		AND yman = mandatedetail.yman 
		AND nman = mandatedetail.nman) = 1
	AND M.idmankind = mandatedetail.idmankind
	AND M.yman = mandatedetail.yman 
	AND M.nman = mandatedetail.nman
	AND M.movkind = 1
	AND (SELECT ISNULL(active,'S') 
		FROM  mandate 
		WHERE idmankind = mandatedetail.idmankind
			AND yman = mandatedetail.yman 
			AND nman = mandatedetail.nman) = 'S'
	AND NOT EXISTS
		(SELECT * FROM mandatedetail MD
		WHERE MD.idexp_taxable = M.idexp
		   OR MD.idexp_iva = M.idexp)
	AND ISNULL(
		(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
		FROM totmandateview
		WHERE idmankind  = M.idmankind
			AND yman = M.yman 
			AND nman = M.nman)
	,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(ey_starting.amount,0)
			FROM expense
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
	          WHERE expense.idexp = M.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = M.idexp),0)
	,0)


-- Contabilizzazione TOTALE dell'imponibile del contratto passivo (IMPON)
UPDATE mandatedetail
SET    idexp_taxable = M.idexp
FROM   expensemandate M
WHERE (
	(SELECT COUNT(*) FROM expensemandate
	WHERE idmankind = mandatedetail.idmankind
        	AND yman = mandatedetail.yman 
        	AND nman = mandatedetail.nman) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expensemandate
		WHERE idmankind = mandatedetail.idmankind
        		AND yman = mandatedetail.yman 
	        	AND nman = mandatedetail.nman
			AND expensemandate.movkind = 3) = 1
	)
	-- Fine Parte Aggiunta
	AND M.idmankind = mandatedetail.idmankind
	AND M.yman      = mandatedetail.yman 
	AND M.nman      = mandatedetail.nman
	AND M.movkind   = 3
	AND (SELECT ISNULL(active,'S') 
		FROM  mandate 
		WHERE idmankind = mandatedetail.idmankind
			AND yman = mandatedetail.yman 
			AND nman = mandatedetail.nman) = 'S'
	AND NOT EXISTS
		(SELECT * FROM mandatedetail MD
		WHERE MD.idexp_taxable = M.idexp
		OR    MD.idexp_iva = M.idexp)
	AND ISNULL(
		(SELECT ISNULL(taxabletotal,0) FROM totmandateview
		WHERE idmankind  = M.idmankind
			AND yman = M.yman 
			AND nman = M.nman)
	,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(ey_starting.amount,0)
			FROM expense
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
		          WHERE expense.idexp = M.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = M.idexp),0)
	,0)


-- Contabilizzazione TOTALE dell'imposta del contratto passivo (IMPOS)
UPDATE mandatedetail 
SET idexp_iva = M.idexp
FROM expensemandate  M
WHERE (
	(SELECT COUNT(*) FROM expensemandate
	WHERE idmankind = mandatedetail.idmankind
		AND yman = mandatedetail.yman 
		AND nman = mandatedetail.nman) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expensemandate
		WHERE idmankind = mandatedetail.idmankind
        		AND yman = mandatedetail.yman 
	        	AND nman = mandatedetail.nman
			AND expensemandate.movkind = 2) = 1
	)
	-- Fine Parte Aggiunta
	AND M.idmankind = mandatedetail.idmankind
	AND M.yman = mandatedetail.yman 
	AND M.nman = mandatedetail.nman
	AND M.movkind = 2
	AND (SELECT ISNULL(active,'S') 
		FROM mandate 
		WHERE idmankind = mandatedetail.idmankind
		AND yman = mandatedetail.yman 
		AND nman = mandatedetail.nman) = 'S'
	AND NOT EXISTS
		(SELECT * FROM mandatedetail MD
		WHERE MD.idexp_taxable = M.idexp
		OR    MD.idexp_iva = M.idexp)
	AND ISNULL(
		(SELECT ISNULL(ivatotal,0) FROM totmandateview
		  WHERE idmankind = M.idmankind
		    AND yman = M.yman 
	            AND nman = M.nman)
		,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(ey_starting.amount,0)
			FROM expense
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
	          WHERE expense.idexp = M.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = M.idexp),0)
	,0)


-- I contratti passivi che non rientrano in questi casi particolari, 
-- con esercizio precedente al 2006,
-- vengono resi non attivi
UPDATE  mandate 
SET     mandate.active = 'N' 
WHERE   ISNULL(mandate.active,'S') = 'S' 
  AND   mandate.yman < @ayear 
AND EXISTS 
	 (SELECT * 
	 FROM  expensemandate EM 
	 WHERE mandate.idmankind = EM.idmankind 
	 AND   mandate.yman = EM.yman 
	 AND   mandate.nman = EM.nman) 
AND     
( 
	(SELECT
		ISNULL(
			ISNULL((SELECT  ISNULL(SUM(ey_starting.amount),0)
			FROM expensemandate EM1
			JOIN expense 
				ON expense.idexp = EM1.idexp
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
			WHERE   EM1.idmankind = mandate.idmankind 
				AND EM1.yman = mandate.yman 
				AND EM1.nman = mandate.nman
			),0) 
			+
			ISNULL((SELECT   SUM(ISNULL(expensevar.amount, 0.0))
			  FROM    expensemandate EM2
			  JOIN    expensevar ON EM2.idexp = expensevar.idexp
			 WHERE    EM2.idexp = expensevar.idexp 
			   AND    EM2.idmankind = mandate.idmankind 
			   AND    EM2.yman      = mandate.yman 
			   AND    EM2.nman      = mandate.nman 
			),0)
		,0)
	)
	<> (SELECT (ISNULL(linkedimpon,0) + ISNULL(linkedimpos,0) + ISNULL(linkedordin,0)) 
	    FROM   mandateresidual 
	    WHERE  mandateresidual.idmankind = mandate.idmankind 
	    AND    mandateresidual.yman      = mandate.yman 
	    AND    mandateresidual.nman      = mandate.nman) 
)

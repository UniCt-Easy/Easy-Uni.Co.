
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


--Aggiorno tutte le contabilizzazioni generiche di expenseinvoice, con esercizio uguale oppure
--precedente al 2006, su ordini attivi, singole e totali
DECLARE @ayear int
SET @ayear = 1 + ISNULL((SELECT MAX(ayear) FROM accountingyear WHERE flag>=5 ),0)
-- Parte 1.1. Fatture di Acquisto
-- Contabilizzazione TOTALE della fattura di acquisto (DOCUM)
UPDATE invoicedetail 
SET    idexp_taxable = I.idexp,
       idexp_iva = I.idexp
FROM expenseinvoice I
WHERE (SELECT COUNT(*) FROM expenseinvoice
	WHERE idinvkind  = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 1
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idexp_taxable = I.idexp
		   OR DI.idexp_iva     = I.idexp)
	AND ISNULL(
		(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
		FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
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
		          WHERE expense.idexp = I.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = I.idexp),0)
	,0)


-- Contabilizzazione TOTALE dell3ibile del contratto passivo (IMPON)
UPDATE invoicedetail 
SET    idexp_taxable = I.idexp
FROM   expenseinvoice I
WHERE (
	(SELECT COUNT(*) FROM expenseinvoice
	WHERE idinvkind  = invoicedetail.idinvkind
        	AND yinv = invoicedetail.yinv 
        	AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expenseinvoice
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND expenseinvoice.movkind = 3) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 3 
	AND (SELECT ISNULL(active,'S') 
		FROM  invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE   DI.idexp_taxable = I.idexp
			OR idexp_iva = I.idexp)
	
	AND ISNULL(
		(SELECT ISNULL(taxabletotal,0) FROM totinvoiceview
		WHERE  idinvkind = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
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
	          	WHERE expense.idexp = I.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = I.idexp),0)
	,0)


-- Contabilizzazione TOTALE dell'imposta del contratto passivo (IMPOS)
UPDATE invoicedetail 
SET idexp_iva = I.idexp
FROM expenseinvoice  I
WHERE (
	(SELECT COUNT(*) FROM expenseinvoice
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expenseinvoice
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND expenseinvoice.movkind = 2) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 2
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		  WHERE DI.idexp_taxable = I.idexp
		     OR DI.idexp_iva = I.idexp)
	AND ISNULL(
		(SELECT ISNULL(ivatotal,0) FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
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
	          	WHERE expense.idexp = I.idexp),0) 
		+
		ISNULL((SELECT SUM(ISNULL(expensevar.amount, 0.0))
		   FROM expensevar
	          WHERE expensevar.idexp = I.idexp),0)
	,0)



-- Parte 1.2. Fatture di Vendita
-- Contabilizzazione TOTALE della fattura di acquisto (DOCUM)
UPDATE invoicedetail 
SET    idinc_taxable = I.idinc,
       idinc_iva = I.idinc
FROM   incomeinvoice I
WHERE  (SELECT COUNT(*) FROM incomeinvoice
	 WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 1
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind  = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable = I.idinc
		   OR DI.idinc_iva = I.idinc)
	AND ISNULL(
		(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
		FROM totinvoiceview
		WHERE  idinvkind = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(iy_starting.amount,0)
			FROM income
			JOIN incometotal it_firstyear
			  	ON it_firstyear.idinc = income.idinc
			  	AND ((it_firstyear.flag & 2) <> 0 )
			JOIN incomeyear iy_starting
				ON iy_starting.idinc = it_firstyear.idinc
			  	AND iy_starting.ayear = it_firstyear.ayear
	          WHERE income.idinc = I.idinc),0) 
		+
		ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0.0))
		   FROM incomevar
	          WHERE incomevar.idinc = I.idinc),0)
	,0)


-- Contabilizzazione TOTALE dell3ibile della fattura di vendita (IMPON)
UPDATE invoicedetail
SET idinc_taxable = I.idinc
FROM incomeinvoice I 
WHERE (
	(SELECT COUNT(*) FROM incomeinvoice
	WHERE idinvkind = invoicedetail.idinvkind
        	AND yinv = invoicedetail.yinv 
        	AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM incomeinvoice
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND incomeinvoice.movkind = 3) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 3 
	AND (SELECT ISNULL(active,'S') 
		FROM  invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable = I.idinc
			OR DI.idinc_iva = I.idinc)
	AND ISNULL(
		(SELECT ISNULL(taxabletotal,0) FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(iy_starting.amount,0)
			FROM income
			JOIN incometotal it_firstyear
			  	ON it_firstyear.idinc = income.idinc
			  	AND ((it_firstyear.flag & 2) <> 0 )
			JOIN incomeyear iy_starting
				ON iy_starting.idinc = it_firstyear.idinc
			  	AND iy_starting.ayear = it_firstyear.ayear
	          WHERE income.idinc = I.idinc),0) 
		+
		ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0.0))
		   FROM incomevar
	          WHERE incomevar.idinc = I.idinc),0)
	,0)

-- Contabilizzazione TOTALE dell'imposta della fattura di vendita (IMPOS)
UPDATE invoicedetail 
SET idinc_iva = I.idinc
FROM incomeinvoice  I
WHERE (
	(SELECT COUNT(*) FROM incomeinvoice
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM incomeinvoice
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND incomeinvoice.movkind = 2) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 2
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable = I.idinc
		   OR DI.idinc_iva = I.idinc)
	AND ISNULL(
		(SELECT ISNULL(ivatotal,0) FROM totinvoiceview
			WHERE idinvkind = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
	       ISNULL((SELECT ISNULL(iy_starting.amount,0)
			FROM income
			JOIN incometotal it_firstyear
			  	ON it_firstyear.idinc = income.idinc
			  	AND ((it_firstyear.flag & 2) <> 0 )
			JOIN incomeyear iy_starting
				ON iy_starting.idinc = it_firstyear.idinc
			  	AND iy_starting.ayear = it_firstyear.ayear
	          WHERE income.idinc = I.idinc),0) 
		+
		ISNULL((SELECT SUM(ISNULL(incomevar.amount, 0.0))
		   FROM incomevar
	          WHERE incomevar.idinc = I.idinc),0)
	,0)

-- Parte 1.3. Note di Credito
-- Contabilizzazione TOTALE della nota di credito (DOCUM)
UPDATE invoicedetail 
SET    idexp_taxable = I.idexp,
       idexp_iva     = I.idexp
FROM expensevar  I
WHERE (SELECT COUNT(*) FROM expensevar
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 1
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idexp_taxable = I.idexp
		   OR DI.idexp_iva     = I.idexp)
	AND ISNULL(
		(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
		FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(expensevar.amount,0)
		FROM expensevar
	        WHERE expensevar.idexp = I.idexp
			AND expensevar.nvar = I.nvar
		        AND expensevar.yvar = I.yinv)
	,0)

-- Contabilizzazione TOTALE dell3ibile della nota di credito (IMPON)
UPDATE invoicedetail
SET idexp_taxable = I.idexp
FROM expensevar I
WHERE (
	(SELECT COUNT(*) FROM expensevar
	WHERE idinvkind = invoicedetail.idinvkind
        	AND yinv = invoicedetail.yinv 
        	AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expensevar
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND expensevar.movkind = 3) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 3 
	AND (SELECT ISNULL(active,'S') 
		FROM  invoice 
		WHERE idinvkind  = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS 
		(SELECT * FROM invoicedetail DI
		WHERE DI.idexp_taxable = I.idexp
		   OR DI.idexp_iva = I.idexp)
	AND ISNULL(
		(SELECT ISNULL(taxabletotal,0) FROM totinvoiceview
		WHERE idinvkind = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(expensevar.amount,0)
		FROM expensevar
	        WHERE expensevar.idexp = I.idexp
			AND expensevar.nvar = I.nvar
		        AND expensevar.yvar = I.yinv)
	,0)

-- Contabilizzazione TOTALE dell'imposta della nota di credito (IMPOS)
UPDATE invoicedetail 
SET idexp_iva = I.idexp
FROM expensevar  I
WHERE (
	(SELECT COUNT(*) FROM expensevar
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM expensevar
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND expensevar.movkind = 2) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 2
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idexp_taxable = I.idexp
			OR DI.idexp_iva = I.idexp)
	AND ISNULL(
		(SELECT ISNULL(ivatotal,0) FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(expensevar.amount,0)
		FROM expensevar
	        WHERE expensevar.idexp = I.idexp
			AND expensevar.nvar = I.nvar
		        AND expensevar.yvar = I.yinv)
	,0)

-- Parte 1.4. Note di Debito
-- Contabilizzazione TOTALE della nota di debito (DOCUM)
UPDATE invoicedetail 
SET idinc_taxable = I.idinc,
idinc_iva = I.idinc
FROM incomevar I
WHERE (SELECT COUNT(*) FROM incomevar
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 1
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable = I.idinc
		   OR DI.idinc_iva = I.idinc)
	
	AND ISNULL(
		(SELECT SUM(ISNULL(taxabletotal,0) + ISNULL(ivatotal,0))
		FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(incomevar.amount,0)
		FROM incomevar
	        WHERE incomevar.idinc = I.idinc
			AND incomevar.nvar = I.nvar
		        AND incomevar.yvar = I.yinv)
	,0)

-- Contabilizzazione TOTALE della nota di debito (IMPON)
UPDATE invoicedetail
SET idinc_taxable = I.idinc
FROM incomevar I
WHERE (
	(SELECT COUNT(*) FROM incomevar
	WHERE idinvkind = invoicedetail.idinvkind
        	AND yinv = invoicedetail.yinv 
        	AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM incomevar
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND incomevar.movkind = 3) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 3 
	AND (SELECT ISNULL(active,'S') 
		FROM  invoice 
		WHERE idinvkind = invoicedetail.idinvkind
			AND yinv = invoicedetail.yinv 
			AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable  = I.idinc
			OR DI.idinc_iva = I.idinc)
	AND ISNULL(
		(SELECT ISNULL(taxabletotal,0) FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(incomevar.amount,0)
		FROM incomevar
	        WHERE incomevar.idinc      = I.idinc
			AND incomevar.nvar = I.nvar
		        AND incomevar.yvar = I.yinv)
	,0)

-- Contabilizzazione TOTALE dell'imposta della nota di debito (IMPOS)
UPDATE invoicedetail 
SET idinc_iva = I.idinc
FROM incomevar I
WHERE (
	(SELECT COUNT(*) FROM incomevar
	WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 1
	-- Inizio Parte Aggiunta
	OR (SELECT COUNT(*) FROM incomevar
		WHERE idinvkind = invoicedetail.idinvkind
        		AND yinv = invoicedetail.yinv 
	        	AND ninv = invoicedetail.ninv
			AND incomevar.movkind = 2) = 1
	)
	-- Fine Parte Aggiunta
	AND I.idinvkind = invoicedetail.idinvkind
	AND I.yinv = invoicedetail.yinv 
	AND I.ninv = invoicedetail.ninv
	AND I.movkind = 2
	AND (SELECT ISNULL(active,'S') 
		FROM invoice 
		WHERE idinvkind = invoicedetail.idinvkind
		AND yinv = invoicedetail.yinv 
		AND ninv = invoicedetail.ninv) = 'S'
	AND NOT EXISTS
		(SELECT * FROM invoicedetail DI
		WHERE DI.idinc_taxable = I.idinc
			OR DI.idinc_iva = I.idinc)
	AND ISNULL(
		(SELECT ISNULL(ivatotal,0) FROM totinvoiceview
		WHERE idinvkind  = I.idinvkind
			AND yinv = I.yinv 
			AND ninv = I.ninv)
	,0) =
	ISNULL(
		(SELECT -ISNULL(incomevar.amount,0)
		FROM incomevar
	        WHERE incomevar.idinc = I.idinc
			AND incomevar.nvar = I.nvar
		        AND incomevar.yvar = I.yinv)
	,0)

-- Le fatture che non rientrano in questi casi particolari, con esercizio precedente al 2006,
-- vengono rese non attive

-- Parte 2.1. Fatture di acquisto
UPDATE invoice SET invoice.active = 'N'
WHERE  ISNULL(active,'S') = 'S'
       AND invoice.yinv < @ayear
       AND EXISTS
		(
		SELECT * 
		FROM   expenseinvoice EI
		WHERE  invoice.idinvkind = EI.idinvkind
		   AND invoice.yinv = EI.yinv 
		   AND invoice.ninv = EI.ninv)
       AND
	( 
	(SELECT
		ISNULL(
			ISNULL((SELECT ISNULL(SUM(ey_starting.amount),0)
			FROM expenseinvoice EI1
			JOIN expense 
				ON expense.idexp = EI1.idexp
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
			  WHERE EI1.idinvkind = invoice.idinvkind 
				AND EI1.yinv      = invoice.yinv 
			    	AND EI1.ninv      = invoice.ninv
			),0) 
			+
			ISNULL((SELECT   SUM(ISNULL(expensevar.amount, 0.0))
			  FROM    expenseinvoice EI2
			  JOIN    expensevar ON EI2.idexp = expensevar.idexp
			 WHERE    EI2.idexp = expensevar.idexp 
			   AND    EI2.idinvkind = invoice.idinvkind 
			   AND    EI2.yinv      = invoice.yinv 
			   AND    EI2.ninv      = invoice.ninv 
			),0)
		,0)
	)
	<> (SELECT (ISNULL(linkedimpon,0) + ISNULL(linkedimpos,0) + ISNULL(linkeddocum,0)) 
	    FROM   invoiceresidual 
	    WHERE  invoiceresidual.idinvkind = invoice.idinvkind 
	    AND    invoiceresidual.yinv      = invoice.yinv 
	    AND    invoiceresidual.ninv      = invoice.ninv) 
	)	


-- Parte 2.2. Fatture di vendita

UPDATE invoice SET invoice.active = 'N'
WHERE  ISNULL(active,'S') = 'S'
       AND invoice.yinv < @ayear
       AND EXISTS
		(
		SELECT * 
		FROM   incomeinvoice EI
		WHERE  invoice.idinvkind = EI.idinvkind
		   AND invoice.yinv = EI.yinv 
		   AND invoice.ninv = EI.ninv)
       AND
	( 
	(SELECT
		ISNULL(
			ISNULL((SELECT ISNULL(SUM(iy_starting.amount),0)
			FROM   incomeinvoice EI1
			JOIN   income 
				ON   income.idinc = EI1.idinc
			JOIN incometotal it_firstyear
			  	ON it_firstyear.idinc = income.idinc
			  	AND ((it_firstyear.flag & 2) <> 0 )
			JOIN incomeyear iy_starting
				ON iy_starting.idinc = it_firstyear.idinc
			  	AND iy_starting.ayear = it_firstyear.ayear
			  WHERE   EI1.idinvkind = invoice.idinvkind 
			    AND   EI1.yinv      = invoice.yinv 
			    AND   EI1.ninv      = invoice.ninv
			),0) 
			+
			ISNULL((SELECT   SUM(ISNULL(incomevar.amount, 0.0))
			  FROM    incomeinvoice EI2
			  JOIN    incomevar ON EI2.idinc = incomevar.idinc
			 WHERE    EI2.idinc = incomevar.idinc 
			   AND    EI2.idinvkind = invoice.idinvkind 
			   AND    EI2.yinv      = invoice.yinv 
			   AND    EI2.ninv      = invoice.ninv 
			),0)
		,0)
	)
	<> (SELECT (ISNULL(linkedimpon,0) + ISNULL(linkedimpos,0) + ISNULL(linkeddocum,0)) 
	    FROM   invoiceresidual 
	    WHERE  invoiceresidual.idinvkind = invoice.idinvkind 
	    AND    invoiceresidual.yinv      = invoice.yinv 
	    AND    invoiceresidual.ninv      = invoice.ninv) 
	)	


-- Parte 2.3. Note di Credito -ISNULL(expensevar.amount,0) FROM expensevar
UPDATE invoice SET invoice.active = 'N'
WHERE  ISNULL(active,'S') = 'S'
       AND invoice.yinv < @ayear
       AND EXISTS
		(
		SELECT * 
		FROM   expensevar EI
		WHERE  invoice.idinvkind = EI.idinvkind
		   AND invoice.yinv = EI.yinv 
		   AND invoice.ninv = EI.ninv)
       AND
	( 
		(SELECT
			SUM(-ISNULL(EI2.amount, 0.0))
			  FROM    expensevar  EI2
			 WHERE    EI2.idinvkind = invoice.idinvkind 
			   AND    EI2.yinv      = invoice.yinv 
			   AND    EI2.ninv      = invoice.ninv 
		)
		<> (SELECT (ISNULL(linkedimpon,0) + ISNULL(linkedimpos,0) + ISNULL(linkeddocum,0)) 
		    FROM   invoiceresidual 
		    WHERE  invoiceresidual.idinvkind = invoice.idinvkind 
		    AND    invoiceresidual.yinv      = invoice.yinv 
		    AND    invoiceresidual.ninv      = invoice.ninv) 
	)	

-- Parte 2.4. Note di Debito
UPDATE invoice SET invoice.active = 'N'
WHERE  ISNULL(active,'S') = 'S'
       AND invoice.yinv < @ayear
       AND EXISTS
		(
		SELECT * 
		FROM   incomevar EI
		WHERE  invoice.idinvkind = EI.idinvkind
		   AND invoice.yinv = EI.yinv 
		   AND invoice.ninv = EI.ninv)
       AND
	( 
		(SELECT
			SUM(-ISNULL(EI2.amount, 0.0))
			  FROM    incomevar EI2
			 WHERE    EI2.idinvkind = invoice.idinvkind 
			   AND    EI2.yinv      = invoice.yinv 
			   AND    EI2.ninv      = invoice.ninv 
		)
		<> (SELECT (ISNULL(linkedimpon,0) + ISNULL(linkedimpos,0) + ISNULL(linkeddocum,0)) 
		    FROM   invoiceresidual 
		    WHERE  invoiceresidual.idinvkind = invoice.idinvkind 
		    AND    invoiceresidual.yinv      = invoice.yinv 
		    AND    invoiceresidual.ninv      = invoice.ninv) 
	)	

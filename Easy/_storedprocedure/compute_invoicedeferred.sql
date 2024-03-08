
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_invoicedeferred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_invoicedeferred]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE compute_invoicedeferred
AS BEGIN
CREATE TABLE #invoicedeferred
(
	yivapay int,
	nivapay int,
	idinvkind int,
	yinv int,
	ninv int,
	ivatotalpayed decimal(19,2),
	totalpayed decimal(19,2),
	movkind smallint
)

-- Inserimento Fatture con IVA Immediata
INSERT INTO #invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	ivatotalpayed
)
SELECT
	IP.yivapay,
	IP.nivapay,
	I.idinvkind,
	I.yinv,
	I.ninv,
	T.ivatotal
FROM invoice I
JOIN totinvoiceview T
	ON I.idinvkind = T.idinvkind
	AND I.yinv = T.yinv
	AND I.ninv = T.ninv
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN ivapay IP
	ON I.adate BETWEEN IP.start AND IP.stop
WHERE I.flagdeferred = 'N'
	AND IP.paymentkind = 'C'
	AND IRK.registerclass IN ('A','V')

-- Inserimento Fatture con IVA Differita
-- Fatture di Acquisto
INSERT INTO #invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	movkind,
	ivatotalpayed,
	totalpayed
)
SELECT
	IP.yivapay,
	IP.nivapay,
	I.idinvkind,
	I.yinv,
	I.ninv,
	EI.movkind,
	CASE
		WHEN EI.movkind = 2
		THEN SUM(PC.amount)
		ELSE NULL
	END,
	CASE
		WHEN EI.movkind = 1
		THEN SUM(PC.amount)
		ELSE NULL
	END
FROM invoice I
JOIN expenseinvoice EI
	ON EI.idinvkind = I.idinvkind
	AND EI.yinv = I.yinv
	AND EI.ninv = I.ninv
JOIN paymentcommunicated PC
	ON PC.idexp = EI.idexp
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind 
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN totinvoiceview T
	ON T.idinvkind = I.idinvkind
	AND T.yinv = I.yinv
	AND T.ninv = I.ninv
JOIN ivapay IP
	ON PC.competencydate BETWEEN IP.start AND IP.stop
WHERE EI.movkind IN (1, 2)
	AND IRK.registerclass = 'A'
	AND I.flagdeferred = 'S'
	AND IP.paymentkind = 'C'
GROUP BY IP.yivapay, IP.nivapay, I.idinvkind, I.yinv, I.ninv, EI.movkind

-- Note di Credito
INSERT INTO #invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	movkind,
	ivatotalpayed,
	totalpayed
)
SELECT
	IP.yivapay,
	IP.nivapay,
	I.idinvkind,
	I.yinv,
	I.ninv,
	EI.movkind,
	CASE
		WHEN EI.movkind = 2
		THEN -(SUM(PC.amount))
		ELSE NULL
	END,
	CASE
		WHEN EI.movkind = 1
		THEN -(SUM(PC.amount))
		ELSE NULL
	END
FROM invoice I
JOIN expensevar EI
	ON EI.idinvkind = I.idinvkind
	AND EI.yinv = I.yinv
	AND EI.ninv = I.ninv
JOIN paymentcommunicated PC
	ON PC.idexp = EI.idexp
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind 
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN totinvoiceview T
	ON T.idinvkind = I.idinvkind
	AND T.yinv = I.yinv
	AND T.ninv = I.ninv
JOIN ivapay IP
	ON PC.competencydate BETWEEN IP.start AND IP.stop
WHERE EI.movkind IN (1, 2)
	AND IRK.registerclass = 'A'
	AND I.flagdeferred = 'S'
	AND IP.paymentkind = 'C'
GROUP BY IP.yivapay, IP.nivapay, I.idinvkind, I.yinv, I.ninv, EI.movkind

-- Fatture di Vendita
INSERT INTO #invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	movkind,
	ivatotalpayed,
	totalpayed
)
SELECT
	IP.yivapay,
	IP.nivapay,
	I.idinvkind,
	I.yinv,
	I.ninv,
	II.movkind,
	CASE
		WHEN II.movkind = 2
		THEN SUM(PE.amount)
		ELSE NULL
	END,
	CASE
		WHEN II.movkind = 1
		THEN SUM(PE.amount)
		ELSE NULL
	END
FROM invoice I
JOIN incomeinvoice II
	ON II.idinvkind = I.idinvkind
	AND II.yinv = I.yinv
	AND II.ninv = I.ninv
JOIN proceedsemitted PE
	ON PE.idinc = II.idinc
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind 
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN totinvoiceview T
	ON T.idinvkind = I.idinvkind
	AND T.yinv = I.yinv
	AND T.ninv = I.ninv
JOIN ivapay IP
	ON PE.competencydate BETWEEN IP.start AND IP.stop
WHERE II.movkind IN (1, 2)
	AND IRK.registerclass = 'V'
	AND I.flagdeferred = 'S'
	AND IP.paymentkind = 'C'
GROUP BY IP.yivapay, IP.nivapay, I.idinvkind, I.yinv, I.ninv, II.movkind

-- Note di Credito emesse
INSERT INTO #invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	movkind,
	ivatotalpayed,
	totalpayed
)
SELECT
	IP.yivapay,
	IP.nivapay,
	I.idinvkind,
	I.yinv,
	I.ninv,
	II.movkind,
	CASE
		WHEN II.movkind = 2
		THEN -(SUM(PE.amount))
		ELSE NULL
	END,
	CASE
		WHEN II.movkind = 1
		THEN -(SUM(PE.amount))
		ELSE NULL
	END
FROM invoice I
JOIN incomevar II
	ON II.idinvkind = I.idinvkind
	AND II.yinv = I.yinv
	AND II.ninv = I.ninv
JOIN proceedsemitted PE
	ON PE.idinc = II.idinc
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind 
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN totinvoiceview T
	ON T.idinvkind = I.idinvkind
	AND T.yinv = I.yinv
	AND T.ninv = I.ninv
JOIN ivapay IP
	ON PE.competencydate BETWEEN IP.start AND IP.stop
WHERE II.movkind IN (1, 2)
	AND IRK.registerclass = 'V'
	AND I.flagdeferred = 'S'
	AND IP.paymentkind = 'C'
GROUP BY IP.yivapay, IP.nivapay, I.idinvkind, I.yinv, I.ninv, II.movkind

-- Assegno l'importo dell'IVA liquidata per tutti i documenti contabilizzati per intero
UPDATE #invoicedeferred
SET ivatotalpayed = T.ivatotal
FROM totinvoiceview T
WHERE T.idinvkind = #invoicedeferred.idinvkind
	AND T.yinv = #invoicedeferred.yinv
	AND T.ninv = #invoicedeferred.ninv
	AND #invoicedeferred.movkind = 1
	AND #invoicedeferred.totalpayed = (ISNULL(T.taxabletotal,0) + ISNULL(T.ivatotal,0))

-- Assegno l'importo dell'IVA liquidata per tutti i documenti contabilizzati parzialmente (metodo della proporzione)
UPDATE #invoicedeferred
SET ivatotalpayed = 
	#invoicedeferred.totalpayed * 
	ISNULL(T.ivatotal,0) / (ISNULL(T.ivatotal,0) + ISNULL(T.taxabletotal,0))
FROM totinvoiceview T
WHERE T.idinvkind = #invoicedeferred.idinvkind
	AND T.yinv = #invoicedeferred.yinv
	AND T.ninv = #invoicedeferred.ninv
	AND #invoicedeferred.ivatotalpayed IS NULL
	AND
		(SELECT SUM(i2.totalpayed)
		FROM #invoicedeferred i2
		WHERE i2.idinvkind = #invoicedeferred.idinvkind
			AND i2.yinv = #invoicedeferred.yinv
			AND i2.ninv = #invoicedeferred.ninv
			AND (i2.yivapay < #invoicedeferred.yivapay
				OR
				(i2.yivapay = #invoicedeferred.yivapay
					AND i2.nivapay <= #invoicedeferred.nivapay)
			)
		) < (ISNULL(T.ivatotal,0) + ISNULL(T.taxabletotal,0))
	AND #invoicedeferred.movkind = 1

-- Assegno l'importo dell'IVA liquidata per tutti i documenti contabilizzati parzialmente (metodo per differenza)
UPDATE #invoicedeferred
SET ivatotalpayed = 
	ISNULL(T.ivatotal,0) - 
	ISNULL(
		(SELECT SUM(ivatotalpayed)
		FROM #invoicedeferred I
		WHERE I.idinvkind = #invoicedeferred.idinvkind
			AND I.yinv = #invoicedeferred.yinv
			AND I.ninv = #invoicedeferred.ninv)
	,0)
FROM totinvoiceview T
WHERE T.idinvkind = #invoicedeferred.idinvkind
	AND T.yinv = #invoicedeferred.yinv
	AND T.ninv = #invoicedeferred.ninv
	AND #invoicedeferred.ivatotalpayed IS NULL
	AND
		(SELECT SUM(i2.totalpayed)
		FROM #invoicedeferred i2
		WHERE i2.idinvkind = #invoicedeferred.idinvkind
			AND i2.yinv = #invoicedeferred.yinv
			AND i2.ninv = #invoicedeferred.ninv
			AND (i2.yivapay < #invoicedeferred.yivapay
				OR
				(i2.yivapay = #invoicedeferred.yivapay
					AND i2.nivapay <= #invoicedeferred.nivapay)
			)
		) = (ISNULL(T.ivatotal,0) + ISNULL(T.taxabletotal,0))
	AND #invoicedeferred.movkind = 1

DELETE FROM invoicedeferred

INSERT INTO invoicedeferred
(
	yivapay,
	nivapay,
	idinvkind, 
	yinv,
	ninv,
	ivatotalpayed,
	totalpayed,
	ct,
	cu,
	lt,
	lu
)
SELECT
	yivapay,
	nivapay,
	idinvkind,
	yinv,
	ninv,
	ivatotalpayed,
	totalpayed,
	GETDATE() AS ct,
	'SP' AS cu,
	GETDATE() AS lt,
	'''SP''' AS lu
FROM #invoicedeferred
ORDER BY yivapay, nivapay, idinvkind, yinv, ninv

SELECT TOP 1 * FROM invoicedeferred
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


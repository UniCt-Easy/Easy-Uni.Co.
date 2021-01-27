
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_riepilogoiva_old]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_riepilogoiva_old]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE rpt_riepilogoiva_old
(
	@idivaregisterkind INT,
	@year int,
	@startmonth int,
	@stopmonth int,
	@official char(1)
)
AS BEGIN
	IF @startmonth IS NULL OR @startmonth < 1
	BEGIN
		SET @startmonth = 1
	END
	IF @startmonth > 12
	BEGIN
		SET @startmonth = 12
	END
	IF @stopmonth IS NULL OR @stopmonth < 1
	BEGIN
		SET @stopmonth = 1
	END
	IF @stopmonth > 12
	BEGIN
		SET @stopmonth = 12
	END

	-- Tabella che contiene le fatture/note di credito suddivise per tipo IVA
	CREATE TABLE #invoice
	(
		idinvkind int,
		codeinvkind varchar(20),
		yinv int,
		ninv int,
		taxabletotal decimal(19,2),
		ivatotal decimal(19,2),
		ivaunabatable decimal(19,2),
		ivaabatable decimal(19,2),
		flagvariation char(1),
		registrationdate datetime,
		flagdeferred char(1),
		flagmixed char(1),
		idivakind int,
		period char(1)
	)

	-- Tabella finale, dove sono presenti i vari tipi IVA con gli importi calcolati
	CREATE TABLE #ivakind
	(
		idivakind int,
		taxabletotal_period decimal(19,2),
		ivatotal_period decimal(19,2),
		ivaunabatable_period decimal(19,2),
		ivaabatable_period decimal(19,2),
		flagdeferred char(1)
	)

	-- Elenco delle fatture / note di credito associate ai movimenti finanziari
	CREATE TABLE #invoice_finmov
	(
		idinvkind int,
		yinv int,
		ninv int,
		idivaregisterkind int,
		flagmixed char(1),
		flagdeferred char(1),
		ivatotal decimal(19,2),
		flagvariation char(1),
-- inizio campi nuovi
		ivagross decimal(19,2),
		ivaabatable decimal(19,2),
		ivaunabatable decimal(19,2),
-- fine campi nuovi
		totivaunabatable decimal(19,2),
		currivaunabatable decimal(19,2),
		taxabletotal decimal(19,2),
		previvatotalpayed decimal(19,2),
		prevtotalpayed decimal(19,2),
		currivagrosspayed decimal(19,2),
		currivapayed decimal(19,2),
		currtotalpayed decimal(19,2),
		amountlinked decimal(19,2),
		movkind varchar(10),
		rapporto_corrente decimal(19,6),
		rapporto_precedente decimal(19,6),
		period char(1)
	)

	CREATE TABLE #invoice_old
	(
		idinvkind int,
		yinv int,
		ninv int,
		amountlinked decimal(19,2),
		movkind varchar(10)
	)

	-- Sezione 1. Dichiarazione e valorizzazione delle variabili di configurazione
	DECLARE @proratarate decimal(19,6)
	DECLARE @mixedrate decimal(19,6)
	
	SELECT @proratarate = ISNULL(prorata,0) FROM iva_prorata WHERE ayear = @year
	
	SELECT @mixedrate = ISNULL(mixed,0) FROM iva_mixed WHERE ayear = @year
	
	DECLARE @registerclass char(1)
	DECLARE @registername varchar(35)
	SELECT @registerclass = registerclass,
	@registername = description
	FROM ivaregisterkind
	WHERE idivaregisterkind = @idivaregisterkind

	DECLARE @lastday datetime
	
	SET @lastday = '01-' + CONVERT(varchar(2),SUBSTRING('00',1,2 - LEN(CONVERT(varchar(2),(@startmonth+1))))) +
	CONVERT(varchar(2),@startmonth) + '-' + CONVERT(varchar(4),@year)
	SET @lastday = DATEADD(DAY,-1,@lastday)
	
	-- Sezione 2. Gestione dell'IVA immediata (Visualizzazione di tutti i documenti con IVA immediata)	
	-- Sezione 2.1. Totale documenti IVA da inizio anno all'ultimo giorno del mese precedente
	INSERT INTO #invoice
	(codeinvkind, yinv, ninv, idivakind, period,
	taxabletotal,
	ivatotal,
	ivaabatable,
	registrationdate, flagdeferred, flagvariation)
	SELECT 'MESIPREC',@year,0, invoicedetail.idivakind, 'P',
	CONVERT(decimal(19,2),
		SUM(
		    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
			  CONVERT(decimal(19,6),invoice.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
			 )
		   )
		),
		CONVERT(decimal(19,2),
		SUM(ROUND(
			CONVERT(decimal(19,6),ISNULL(invoicedetail.tax, 0.0))
			
		,2))),
	CASE
		WHEN @registerclass = 'A'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
			* ISNULL(@proratarate,0) *
			CASE 
				WHEN ((invoicekind.flag&2)<>0) THEN @mixedrate
				ELSE 1
			END
		WHEN @registerclass = 'V'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
	END,
	@lastday, 'N', 
	CASE
		when (( invoicekind.flag & 4)<>0) then 'S'
		else 'N'

	End
	FROM invoice
	JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.ninv = invoicedetail.ninv
	JOIN invoicekind
	ON invoice.idinvkind = invoicekind.idinvkind
	JOIN invoicekindregisterkind
	ON invoicekind.idinvkind = invoicekindregisterkind.idinvkind
	JOIN ivaregister
	ON ivaregister.idivaregisterkind = invoicekindregisterkind.idivaregisterkind
	AND ivaregister.idinvkind = invoice.idinvkind
	AND ivaregister.yinv = invoice.yinv
	AND ivaregister.ninv = invoice.ninv
	WHERE flagdeferred = 'N'
	AND invoice.yinv = @year
	AND YEAR(invoice.adate) = @year
	AND MONTH(invoice.adate) < @startmonth
	AND ivaregister.idivaregisterkind = @idivaregisterkind
	GROUP BY (invoicekind.flag&2),(invoicekind.flag&4), invoicedetail.idivakind

	-- Sezione 2.2. Documenti IVA registrati nel periodo in considerazione
	INSERT INTO #invoice
	(idinvkind, yinv, ninv, invoicedetail.idivakind, period,
	taxabletotal,
	ivatotal,
	ivaabatable,
	flagvariation, registrationdate, flagdeferred)
	SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, invoicedetail.idivakind, 'C',
	CONVERT(decimal(19,2),
		SUM(
		    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
			  CONVERT(decimal(19,6),invoice.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
			 )
		   )
		),
	CONVERT(decimal(19,2),
	SUM(ROUND(
		CONVERT(decimal(19,6),ISNULL(invoicedetail.tax, 0.0)) 
	,2))),

	CASE
		WHEN @registerclass = 'A'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
			* ISNULL(@proratarate,0) *
			CASE 
				WHEN ((invoicekind.flag&2)<>0) THEN @mixedrate
				ELSE 1
			END
		WHEN @registerclass = 'V'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
	END,
	(invoicekind.flag&4), invoice.adate, 'N'
	FROM invoice
	JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.ninv = invoicedetail.ninv
	JOIN invoicekind
	ON invoice.idinvkind = invoicekind.idinvkind
	JOIN invoicekindregisterkind
	ON invoicekind.idinvkind = invoicekindregisterkind.idinvkind
	JOIN ivaregister
	ON ivaregister.idivaregisterkind = invoicekindregisterkind.idivaregisterkind
	AND ivaregister.idinvkind = invoice.idinvkind
	AND ivaregister.yinv = invoice.yinv
	AND ivaregister.ninv = invoice.ninv
	WHERE flagdeferred = 'N'
	AND invoice.yinv = @year
	AND YEAR(invoice.adate) = @year
	AND MONTH(invoice.adate) BETWEEN @startmonth AND @stopmonth
	AND ivaregister.idivaregisterkind = @idivaregisterkind
	GROUP BY invoice.idinvkind, invoice.yinv, invoice.ninv, (invoicekind.flag&2), (invoicekind.flag&4),
	invoice.adate, invoicedetail.idivakind

	-- Sezione 3. Gestione dei documenti IVA con IVA differita
	IF (@registerclass = 'A')
	BEGIN
		-- Calcolo sulle Fatture
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(paymentcommunicated.amount), 'P', 'N'
		FROM expenseinvoice
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expenseinvoice.idexp
		JOIN invoice
		ON expenseinvoice.idinvkind = invoice.idinvkind
		AND expenseinvoice.yinv = invoice.yinv
		AND expenseinvoice.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE expenseinvoice.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(paymentcommunicated.competencydate) = @year
		AND MONTH(paymentcommunicated.competencydate) < @startmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(expensevar.amount), 'P', 'S'
		FROM expensevar
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expensevar.idexp
		JOIN invoice
		ON expensevar.idinvkind = invoice.idinvkind
		AND expensevar.yinv = invoice.yinv
		AND expensevar.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE expensevar.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(paymentcommunicated.competencydate) = @year
		AND MONTH(paymentcommunicated.competencydate) < @startmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		-- Calcolo sulle Fatture
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(paymentcommunicated.amount), 'C', 'N'
		FROM expenseinvoice
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expenseinvoice.idexp
		JOIN invoice
		ON expenseinvoice.idinvkind = invoice.idinvkind
		AND expenseinvoice.yinv = invoice.yinv
		AND expenseinvoice.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE expenseinvoice.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(paymentcommunicated.competencydate) = @year
		AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(expensevar.amount), 'C', 'S'
		FROM expensevar
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expensevar.idexp
		JOIN invoice
		ON expensevar.idinvkind = invoice.idinvkind
		AND expensevar.yinv = invoice.yinv
		AND expensevar.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE expensevar.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(paymentcommunicated.competencydate) = @year
		AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)
	
		INSERT INTO #invoice_old (idinvkind, yinv, ninv, movkind, amountlinked)
		SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, expenseinvoice.movkind, 
		SUM(paymentcommunicated.amount)
		FROM invoice
		JOIN expenseinvoice
		ON invoice.idinvkind = expenseinvoice.idinvkind
		AND invoice.yinv = expenseinvoice.yinv
		AND invoice.ninv = expenseinvoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expenseinvoice.idexp
		WHERE invoice.flagdeferred = 'S'
		AND ivaregister.idivaregisterkind = @idivaregisterkind
		AND YEAR(paymentcommunicated.competencydate) < @year 
		AND expenseinvoice.movkind IN (1,2)
		AND (SELECT COUNT(*) FROM #invoice_finmov
			WHERE #invoice_finmov.idinvkind = invoice.idinvkind
			AND #invoice_finmov.yinv = invoice.yinv
			AND #invoice_finmov.ninv = invoice.ninv)>0
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind, 
		paymentcommunicated.competencydate

		INSERT INTO #invoice_old (idinvkind, yinv, ninv, movkind, amountlinked)
		SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, expensevar.movkind, 
		SUM(paymentcommunicated.amount)
		FROM invoice
		JOIN expensevar
		ON invoice.idinvkind = expensevar.idinvkind
		AND invoice.yinv = expensevar.yinv
		AND invoice.ninv = expensevar.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN paymentcommunicated
		ON paymentcommunicated.idexp = expensevar.idexp
		WHERE invoice.flagdeferred = 'S'
		AND ivaregister.idivaregisterkind = @idivaregisterkind
		AND YEAR(paymentcommunicated.competencydate) < @year 
		AND expensevar.movkind IN (1,2)
		AND (SELECT COUNT(*) FROM #invoice_finmov
			WHERE #invoice_finmov.idinvkind = invoice.idinvkind
			AND #invoice_finmov.yinv = invoice.yinv
			AND #invoice_finmov.ninv = invoice.ninv)>0
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 
		paymentcommunicated.competencydate
	END

	IF (@registerclass = 'V')
	BEGIN
		-- Calcolo sulle Fatture
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(proceedsemitted.amount), 'P', 'N'
		FROM incomeinvoice
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomeinvoice.idinc
		JOIN invoice
		ON incomeinvoice.idinvkind = invoice.idinvkind
		AND incomeinvoice.yinv = invoice.yinv
		AND incomeinvoice.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE incomeinvoice.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(proceedsemitted.competencydate) = @year
		AND MONTH(proceedsemitted.competencydate) < @startmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(incomevar.amount), 'P', 'S'
		FROM incomevar
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomevar.idinc
		JOIN invoice
		ON incomevar.idinvkind = invoice.idinvkind
		AND incomevar.yinv = invoice.yinv
		AND incomevar.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE incomevar.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(proceedsemitted.competencydate) = @year
		AND MONTH(proceedsemitted.competencydate) < @startmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(proceedsemitted.amount), 'C', 'N'
		FROM incomeinvoice
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomeinvoice.idinc
		JOIN invoice
		ON incomeinvoice.idinvkind = invoice.idinvkind
		AND incomeinvoice.yinv = invoice.yinv
		AND incomeinvoice.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE incomeinvoice.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(proceedsemitted.competencydate) = @year
		AND MONTH(proceedsemitted.competencydate) BETWEEN @startmonth AND @stopmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind, 
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagdeferred, flagmixed, idivaregisterkind,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, period, flagvariation)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind, 'S',
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		SUM(incomevar.amount), 'C', 'S'
		FROM incomevar
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomevar.idinc
		JOIN invoice
		ON incomevar.idinvkind = invoice.idinvkind
		AND incomevar.yinv = invoice.yinv
		AND incomevar.ninv = invoice.ninv
		JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
		JOIN totinvoiceview
		ON totinvoiceview.idinvkind = invoice.idinvkind
		AND totinvoiceview.yinv = invoice.yinv
		AND totinvoiceview.ninv = invoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
		WHERE incomevar.movkind IN (1,2)
		AND ivaregisterkind.registerclass = @registerclass
		AND YEAR(proceedsemitted.competencydate) = @year
		AND MONTH(proceedsemitted.competencydate) BETWEEN @startmonth AND @stopmonth
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND invoice.flagdeferred = 'S'
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind,
		(invoicekind.flag&2), ivaregisterkind.idivaregisterkind,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal)

		INSERT INTO #invoice_old (idinvkind, yinv, ninv, movkind, amountlinked)
		SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, incomeinvoice.movkind, 
		SUM(proceedsemitted.amount)
		FROM invoice
		JOIN incomeinvoice
		ON invoice.idinvkind = incomeinvoice.idinvkind
		AND invoice.yinv = incomeinvoice.yinv
		AND invoice.ninv = incomeinvoice.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomeinvoice.idinc
		WHERE invoice.flagdeferred = 'S'
		AND ivaregister.idivaregisterkind = @idivaregisterkind
		AND YEAR(proceedsemitted.competencydate) < @year 
		AND incomeinvoice.movkind IN (1,2)
		AND (SELECT COUNT(*) FROM #invoice_finmov
			WHERE #invoice_finmov.idinvkind = invoice.idinvkind
			AND #invoice_finmov.yinv = invoice.yinv
			AND #invoice_finmov.ninv = invoice.ninv)>0
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind, 
		proceedsemitted.competencydate

		INSERT INTO #invoice_old (idinvkind, yinv, ninv, movkind, amountlinked)
		SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, incomevar.movkind, 
		SUM(proceedsemitted.amount)
		FROM invoice
		JOIN incomevar
		ON invoice.idinvkind = incomevar.idinvkind
		AND invoice.yinv = incomevar.yinv
		AND invoice.ninv = incomevar.ninv
		JOIN ivaregister
		ON ivaregister.idinvkind = invoice.idinvkind 
		AND ivaregister.yinv = invoice.yinv
		AND ivaregister.ninv = invoice.ninv
		JOIN proceedsemitted
		ON proceedsemitted.idinc = incomevar.idinc
		WHERE invoice.flagdeferred = 'S'
		AND ivaregister.idivaregisterkind = @idivaregisterkind
		AND YEAR(proceedsemitted.competencydate) < @year 
		AND incomevar.movkind IN (1,2)
		AND (SELECT COUNT(*) FROM #invoice_finmov
			WHERE #invoice_finmov.idinvkind = invoice.idinvkind
			AND #invoice_finmov.yinv = invoice.yinv
			AND #invoice_finmov.ninv = invoice.ninv)>0
		GROUP BY invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind, 
		proceedsemitted.competencydate
	END

	-- Calcolo del rapporto per i documenti contabilizzati in periodo pregresso e per quelli contabilizzati nel periodo corrente
	UPDATE #invoice_finmov
	SET #invoice_finmov.rapporto_corrente = 
	CASE
		WHEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) < #invoice_finmov.ivatotal
		THEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) / #invoice_finmov.ivatotal
		ELSE NULL
	END,
	#invoice_finmov.rapporto_precedente =
	CASE
		WHEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) = #invoice_finmov.ivatotal
		THEN
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) / #invoice_finmov.ivatotal
		ELSE NULL
	END
	WHERE movkind = 2
	AND period = 'P'

	UPDATE #invoice_finmov
	SET #invoice_finmov.rapporto_corrente = 
	CASE
		WHEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) < #invoice_finmov.ivatotal
		THEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) / #invoice_finmov.ivatotal
		ELSE NULL
	END,
	#invoice_finmov.rapporto_precedente =
	CASE
		WHEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) = #invoice_finmov.ivatotal
		THEN
			(ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = 'P')
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0)) / #invoice_finmov.ivatotal
		ELSE NULL
	END
	WHERE movkind = 2
	AND period = 'C'
	

	UPDATE #invoice_finmov
	SET #invoice_finmov.rapporto_corrente = 
	CASE
		WHEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) < (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		THEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) / (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		ELSE NULL
	END,
	#invoice_finmov.rapporto_precedente =
	CASE
		WHEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) = (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		THEN
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) / (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		ELSE NULL
	END
	WHERE movkind = 1
	AND period = 'P'


	UPDATE #invoice_finmov
	SET #invoice_finmov.rapporto_corrente = 
	CASE
		WHEN 
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) < (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		THEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked))
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = #invoice_finmov.period)
			,0) / (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		ELSE NULL
	END,
	#invoice_finmov.rapporto_precedente =
	CASE
		WHEN
			ISNULL(
				(SELECT ABS(SUM(amountlinked)) 
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv)
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0) = (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		THEN
			(ISNULL(
				(SELECT ABS(SUM(amountlinked)) 
				FROM #invoice_finmov i2
				WHERE i2.idinvkind = #invoice_finmov.idinvkind
				AND i2.yinv = #invoice_finmov.yinv
				AND i2.ninv = #invoice_finmov.ninv
				AND i2.period = 'P')
			,0) +
			ISNULL(
				(SELECT ABS(amountlinked)
				FROM #invoice_old
				WHERE #invoice_old.idinvkind = #invoice_finmov.idinvkind
				AND #invoice_old.yinv = #invoice_finmov.yinv
				AND #invoice_old.ninv = #invoice_finmov.ninv)
			,0)) / (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0))
		ELSE NULL
	END
	WHERE movkind = 1
	AND period = 'C'

	INSERT INTO #invoice
	(idinvkind, yinv, ninv, idivakind, flagdeferred, period,
	taxabletotal,
	ivatotal,
	ivaabatable,
	flagvariation
	)
	SELECT
	#invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, invoicedetail.idivakind,
	'S', #invoice_finmov.period,
	CONVERT(decimal(19,2),
		SUM(
		    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
			  CONVERT(decimal(19,6),invoice.exchangerate) * 
			  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount,0)))
			* rapporto_corrente
			,2)
		   )
		),
	CONVERT(decimal(19,2),
	SUM(ROUND(
		CONVERT(decimal(19,6),ISNULL(invoicedetail.tax, 0.0)) *   
		rapporto_corrente
	,2))),
	CASE
		WHEN @registerclass = 'A'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable)* rapporto_corrente, 2)), 0)
			* ISNULL(@proratarate,0) *
			CASE 
				WHEN #invoice_finmov.flagmixed = 'S' THEN @mixedrate
				ELSE 1
			END
		WHEN @registerclass = 'V'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable)* rapporto_corrente, 2)), 0)
	END,
	#invoice_finmov.flagvariation
	FROM #invoice_finmov
	JOIN invoice
	ON #invoice_finmov.idinvkind = invoice.idinvkind
	AND #invoice_finmov.yinv = invoice.yinv
	AND #invoice_finmov.ninv = invoice.ninv
	JOIN invoicedetail
	ON #invoice_finmov.idinvkind = invoicedetail.idinvkind
	AND #invoice_finmov.yinv = invoicedetail.yinv
	AND #invoice_finmov.ninv = invoicedetail.ninv
	WHERE #invoice_finmov.rapporto_corrente IS NOT NULL
	GROUP BY #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv,#invoice_finmov.rapporto_corrente, invoicedetail.idivakind,
	#invoice_finmov.period, #invoice_finmov.flagmixed, #invoice_finmov.flagvariation

	INSERT INTO #invoice
	(idinvkind, yinv, ninv, idivakind, flagdeferred, period,
	taxabletotal,
	ivatotal,
	ivaabatable,
	flagvariation
	)
	SELECT
	#invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, invoicedetail.idivakind,
	'S', #invoice_finmov.period,
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
			    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				  CONVERT(decimal(19,6),invoice.exchangerate) * 
				  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount,0)))
				,2)
			   )
			)
	,0) - 
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
			    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
				  CONVERT(decimal(19,6),invoice.exchangerate) * 
				  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount,0)))
				* rapporto_precedente
				,2)
			   )
			)
	,0),
	ISNULL(
		CONVERT(decimal(19,2),
		SUM(ROUND(
			CONVERT(decimal(19,6),ISNULL(invoicedetail.tax, 0.0)) 
		,2)))
	,0) - 
	ISNULL(
		CONVERT(decimal(19,2),
		SUM(ROUND(
			CONVERT(decimal(19,6),ISNULL(invoicedetail.tax, 0.0)) *   
			 rapporto_precedente
		,2)))
	,0),
	CASE
		WHEN @registerclass = 'A'
		THEN
		ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
		* ISNULL(@proratarate,0) *
		CASE 
			WHEN #invoice_finmov.flagmixed = 'S' THEN @mixedrate
			ELSE 1
		END -
		ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable) * rapporto_precedente, 2)), 0)
		* ISNULL(@proratarate,0) *
		CASE 
			WHEN #invoice_finmov.flagmixed = 'S' THEN @mixedrate
			ELSE 1
		END
		WHEN @registerclass = 'V'
		THEN
		ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable), 2)), 0)
		-
		ISNULL(SUM(ROUND((invoicedetail.tax - invoicedetail.unabatable)* rapporto_precedente, 2)), 0)
	END,
	#invoice_finmov.flagvariation
	FROM #invoice_finmov
	JOIN invoice
	ON #invoice_finmov.idinvkind = invoice.idinvkind
	AND #invoice_finmov.yinv = invoice.yinv
	AND #invoice_finmov.ninv = invoice.ninv
	JOIN invoicedetail
	ON #invoice_finmov.idinvkind = invoicedetail.idinvkind
	AND #invoice_finmov.yinv = invoicedetail.yinv
	AND #invoice_finmov.ninv = invoicedetail.ninv
	WHERE #invoice_finmov.rapporto_precedente IS NOT NULL
	GROUP BY #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv,#invoice_finmov.rapporto_corrente, invoicedetail.idivakind,
	#invoice_finmov.period, #invoice_finmov.flagmixed, #invoice_finmov.flagvariation

	UPDATE #invoice SET ivaunabatable = ISNULL(ivatotal,0) - ISNULL(ivaabatable,0)

	UPDATE #invoice SET
	taxabletotal = -taxabletotal, ivatotal = -ivatotal,
	ivaabatable = -ivaabatable, ivaunabatable = -ivaunabatable
	WHERE flagvariation = 'S'
	
	INSERT INTO #ivakind
	(
		idivakind,
		flagdeferred
	)
	SELECT idivakind,
	flagdeferred
	FROM #invoice
	GROUP BY idivakind, flagdeferred
	
	UPDATE #ivakind
	SET
	taxabletotal_period =
	ISNULL(
		(SELECT SUM(taxabletotal)
		FROM #invoice
		WHERE #ivakind.idivakind = #invoice.idivakind
		AND #ivakind.flagdeferred = #invoice.flagdeferred
		AND #invoice.period = 'C')
	,0),
	ivatotal_period =
	ISNULL(
		(SELECT SUM(ivatotal)
		FROM #invoice
		WHERE #ivakind.idivakind = #invoice.idivakind
		AND #ivakind.flagdeferred = #invoice.flagdeferred
		AND #invoice.period = 'C')
	,0),
	ivaunabatable_period =
	ISNULL(
		(SELECT SUM(ivaunabatable)
		FROM #invoice
		WHERE #ivakind.idivakind = #invoice.idivakind
		AND #ivakind.flagdeferred = #invoice.flagdeferred
		AND #invoice.period = 'C')
	,0),
	ivaabatable_period =
	ISNULL(
		(SELECT SUM(ivaabatable)
		FROM #invoice
		WHERE #ivakind.idivakind = #invoice.idivakind
		AND #ivakind.flagdeferred = #invoice.flagdeferred
		AND #invoice.period = 'C')
	,0)
	
	CREATE TABLE #invoicedeferred
	(
		idivakind varchar(10),
		idinvkind varchar(10),
		yinv int,
		ninv int,
		taxabletotal decimal(19,2),
		ivaunabatable decimal(19,2),
		ivaabatable decimal(19,2),
		flagvariation char(1)
	)

	-- Sezione 2bis. Gestione dei documenti IVA con IVA differita
	INSERT INTO #invoicedeferred (idinvkind, yinv, ninv, idivakind, taxabletotal, ivaunabatable, ivaabatable, flagvariation)
	SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, invoicedetail.idivakind,
	CONVERT(decimal(19,2),
	SUM(
	    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
		  CONVERT(decimal(19,6),invoice.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
		 )
	   )
	),
	CONVERT(decimal(19,2),
		SUM(
			ROUND(ISNULL(invoicedetail.tax, 0.0),2)
		)
	) -
	CASE
		WHEN @registerclass = 'A'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - ISNULL(invoicedetail.unabatable,0)), 2)), 0)
			* ISNULL(@proratarate,0) *
			CASE 
				WHEN ((invoicekind.flag&2)<>0) THEN @mixedrate
				ELSE 1
			END
		WHEN @registerclass = 'V'
		THEN ISNULL(SUM(ROUND((invoicedetail.tax - ISNULL(invoicedetail.unabatable,0)), 2)), 0)
	END,
	CASE
		WHEN @registerclass = 'A'
		THEN
			ISNULL(SUM(ROUND((invoicedetail.tax - ISNULL(invoicedetail.unabatable,0)), 2)), 0)
			* ISNULL(@proratarate,0) *
			CASE 
				WHEN ((invoicekind.flag&2)<>0) THEN @mixedrate
				ELSE 1
			END
		WHEN @registerclass = 'V'
		THEN ISNULL(SUM(ROUND((invoicedetail.tax - ISNULL(invoicedetail.unabatable,0)), 2)), 0)
	END,
	CASE
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		ELSE 'N'
	END
	FROM invoice
	JOIN invoicedetail
	ON invoice.idinvkind = invoicedetail.idinvkind
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.ninv = invoicedetail.ninv
	JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregister
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
	JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	JOIN invoicekindregisterkind
	ON invoicekindregisterkind.idinvkind = invoice.idinvkind
	AND invoicekindregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	WHERE invoice.flagdeferred = 'S'
	AND YEAR(invoice.adate) = @year
	AND MONTH(invoice.adate) BETWEEN @startmonth AND @stopmonth
	AND ivaregisterkind.registerclass = @registerclass
	AND ivaregister.idivaregisterkind = @idivaregisterkind
	GROUP BY invoice.idinvkind, invoice.yinv, invoice.ninv, idivakind, (invoicekind.flag&2), (invoicekind.flag&4)


	UPDATE #invoicedeferred SET
	taxabletotal = -taxabletotal,
	ivaabatable = -ivaabatable, ivaunabatable = -ivaunabatable
	WHERE flagvariation = 'S'

	DECLARE @monthname varchar(30)
	SELECT @monthname = title
	FROM monthname
	WHERE code = @startmonth

	IF (@startmonth <> @stopmonth)
	BEGIN
			SET @monthname = @monthname + ' - ' +
			(SELECT title FROM monthname WHERE code = @stopmonth)
	END
	
	CREATE TABLE #outtable
	(
		idivakind int,
		taxabletotal_imm decimal(19,2),
		ivaunabatable_imm decimal(19,2),
		ivaabatable_imm decimal(19,2),
		taxabletotal_dif decimal(19,2),
		ivaunabatable_dif decimal(19,2),
		ivaabatable_dif decimal(19,2),
		taxabletotal_totdif decimal(19,2), -- Imponibile (dei documenti differiti)
		ivaunabatable_totdif decimal(19,2), -- IVA Indetraibile (dei documenti differiti)
		ivaabatable_totdif decimal(19,2) -- IVA Detraibile (dei documenti differiti)
	)

	INSERT INTO #outtable
	(
		idivakind,
		taxabletotal_imm,
		ivaunabatable_imm,
		ivaabatable_imm,
		taxabletotal_dif,
		ivaunabatable_dif,
		ivaabatable_dif,
		taxabletotal_totdif,
		ivaunabatable_totdif,
		ivaabatable_totdif
	)
	SELECT idivakind,
		(SELECT SUM(taxabletotal_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'N'),
		(SELECT SUM(ivaunabatable_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'N'),
		(SELECT SUM(ivaabatable_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'N'),
		(SELECT SUM(taxabletotal_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'S'),
		(SELECT SUM(ivaunabatable_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'S'),
		(SELECT SUM(ivaabatable_period)
		FROM #ivakind i2
		WHERE i2.idivakind = #ivakind.idivakind
		AND i2.flagdeferred = 'S'),
		(SELECT SUM(taxabletotal)
		FROM #invoicedeferred
		WHERE #invoicedeferred.idivakind = #ivakind.idivakind),
		(SELECT SUM(ivaunabatable)
		FROM #invoicedeferred
		WHERE #invoicedeferred.idivakind = #ivakind.idivakind),
		(SELECT SUM(ivaabatable)
		FROM #invoicedeferred
		WHERE #invoicedeferred.idivakind = #ivakind.idivakind)
	FROM #ivakind
	GROUP BY idivakind

	INSERT INTO #outtable 
	(
		idivakind,
		taxabletotal_totdif,
		ivaunabatable_totdif,
		ivaabatable_totdif
	)
	SELECT idivakind, SUM(taxabletotal), SUM(ivaunabatable), SUM(ivaabatable)
	FROM #invoicedeferred
	WHERE NOT EXISTS(SELECT * FROM #invoice WHERE #invoice.idivakind = #invoicedeferred.idivakind)
	GROUP BY idivakind

	SELECT
	@monthname AS currmonth,
	@year AS curryear,
	@registername AS registername,
	ivakind.codeivakind as  idivakind,--#outtable.idivakind,
	ivakind.description AS ivakinddescr,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	ISNULL(taxabletotal_imm,0) AS taxabletotal_imm, -- Imponibile (dei documenti immediati)
	ISNULL(ivaunabatable_imm,0) AS ivaunabatable_imm, -- IVA Indetraibile (dei documenti immediati)
	ISNULL(ivaabatable_imm,0) AS ivaabatable_imm, -- IVA Detraibile (dei documenti immediati)
	ISNULL(taxabletotal_dif,0) AS taxabletotal_dif, -- Imponibile (dei documenti differiti divenuti immediati)
	ISNULL(ivaunabatable_dif,0) AS ivaunabatable_dif, -- IVA Indetrabile (dei documenti differiti divenuti immediati)
	ISNULL(ivaabatable_dif,0) AS ivaabatable_dif, -- IVA Detraibile (dei documenti differiti divenuti immediati)
	ISNULL(taxabletotal_totdif,0) AS taxabletotal_totdif, -- Imponibile (dei documenti differiti)
	ISNULL(ivaunabatable_totdif,0) AS ivaunabatable_totdif, -- IVA Indetraibile (dei documenti differiti)
	ISNULL(ivaabatable_totdif,0) AS ivaabatable_totdif -- IVA Detraibile (dei documenti differiti)
	FROM #outtable
	JOIN ivakind
	ON ivakind.idivakind = #outtable.idivakind
	WHERE ISNULL(taxabletotal_imm,0) <> 0
	OR ISNULL(ivaunabatable_imm,0) <> 0
	OR ISNULL(ivaabatable_imm,0) <> 0
	OR ISNULL(taxabletotal_dif,0) <> 0
	OR ISNULL(ivaunabatable_dif,0) <> 0
	OR ISNULL(ivaabatable_dif,0) <> 0
	OR ISNULL(taxabletotal_totdif,0) <> 0
	OR ISNULL(ivaunabatable_totdif,0) <> 0
	OR ISNULL(ivaabatable_totdif,0) <> 0
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- Script che esegue le SP per lo split delle fatture

-- Se non esistono fatture => esci
IF ((SELECT COUNT(*) FROM invoice) = 0) RETURN
 
DECLARE @fatt_v_c int
DECLARE @fatt_a_c int
DECLARE @ncred_c int
DECLARE @ndeb_c int
SET @fatt_v_c = (SELECT COUNT(*) FROM incomeinvoice)
SET @fatt_a_c = (SELECT COUNT(*) FROM expenseinvoice)
SET @ndeb_c = (SELECT COUNT(*) FROM incomevar where idinvkind is not null and yinv is not null and ninv is not null)
SET @ncred_c = (SELECT COUNT(*) FROM expensevar where idinvkind is not null and yinv is not null and ninv is not null)

-- Se esistono fatture ma non sono state contabilizzate => esci
IF ((@fatt_v_c + @fatt_a_c + @ndeb_c + @ncred_c) = 0) RETURN

DECLARE @ayear int
SET @ayear = 1 + ISNULL((SELECT MAX(ayear) FROM accountingyear WHERE flag>=5),0)

-- Se esistono fatture contabilizzate e non esistono liquidazioni IVA => imposta le fatture da non contabilizzare, esci
IF ((SELECT COUNT(*) FROM ivapay) = 0)
BEGIN
	IF (@fatt_v_c > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM incomeinvoice
			WHERE incomeinvoice.idinvkind = invoice.idinvkind
				AND incomeinvoice.yinv = invoice.yinv
				AND incomeinvoice.ninv = invoice.ninv)
		AND invoice.yinv < @ayear

		UPDATE invoice SET active = 'N'
		WHERE 
		ISNULL(
			(SELECT ISNULL(taxabletotal,0) + ISNULL(ivatotal,0) FROM totinvoiceview
			WHERE totinvoiceview.idinvkind = invoice.idinvkind
			AND totinvoiceview.yinv = invoice.yinv
			AND totinvoiceview.ninv = invoice.ninv)
		,0) = 
		ISNULL(
			(SELECT ISNULL(SUM(iy_starting.amount),0)
			FROM income
			JOIN incomeinvoice
				ON income.idinc = incomeinvoice.idinc
			JOIN incometotal it_firstyear
			  	ON it_firstyear.idinc = income.idinc
			  	AND ((it_firstyear.flag & 2) <> 0 )
			JOIN incomeyear iy_starting
				ON iy_starting.idinc = it_firstyear.idinc
			  	AND iy_starting.ayear = it_firstyear.ayear
			WHERE incomeinvoice.idinvkind = invoice.idinvkind
				AND incomeinvoice.yinv = invoice.yinv
				AND incomeinvoice.ninv = invoice.ninv)
		,0)
		AND invoice.yinv = @ayear
	END

	IF (@fatt_a_c > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM expenseinvoice
			WHERE expenseinvoice.idinvkind = invoice.idinvkind
				AND expenseinvoice.yinv = invoice.yinv
				AND expenseinvoice.ninv = invoice.ninv)
		AND invoice.yinv < @ayear

		UPDATE invoice SET active = 'N'
		WHERE 
		ISNULL(
			(SELECT ISNULL(taxabletotal,0) + ISNULL(ivatotal,0) FROM totinvoiceview
			WHERE totinvoiceview.idinvkind = invoice.idinvkind
			AND totinvoiceview.yinv = invoice.yinv
			AND totinvoiceview.ninv = invoice.ninv)
		,0) = 
		ISNULL(
			(SELECT ISNULL(SUM(ey_starting.amount),0)
			FROM expense
			JOIN expenseinvoice
				ON expense.idexp = expenseinvoice.idexp
			JOIN expensetotal et_firstyear
			  	ON et_firstyear.idexp = expense.idexp
			  	AND ((et_firstyear.flag & 2) <> 0 )
			JOIN expenseyear ey_starting
				ON ey_starting.idexp = et_firstyear.idexp
			  	AND ey_starting.ayear = et_firstyear.ayear
			WHERE expenseinvoice.idinvkind = invoice.idinvkind
				AND expenseinvoice.yinv = invoice.yinv
				AND expenseinvoice.ninv = invoice.ninv)
		,0)
		AND invoice.yinv = @ayear
	END

	IF (@ndeb_c > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM incomevar
			WHERE incomevar.idinvkind = invoice.idinvkind
				AND incomevar.yinv = invoice.yinv
				AND incomevar.ninv = invoice.ninv)
		AND invoice.yinv < @ayear

		UPDATE invoice SET active = 'N'
		WHERE 
		ISNULL(
			(SELECT ISNULL(taxabletotal,0) + ISNULL(ivatotal,0) FROM totinvoiceview
			WHERE totinvoiceview.idinvkind = invoice.idinvkind
			AND totinvoiceview.yinv = invoice.yinv
			AND totinvoiceview.ninv = invoice.ninv)
		,0) = 
		ISNULL(
			(SELECT -SUM(amount)
			FROM incomevar
			WHERE incomevar.idinvkind = invoice.idinvkind
				AND incomevar.yinv = invoice.yinv
				AND incomevar.ninv = invoice.ninv)
		,0)
		AND invoice.yinv = @ayear
	END

	IF (@ncred_c > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM expensevar
			WHERE expensevar.idinvkind = invoice.idinvkind
				AND expensevar.yinv = invoice.yinv
				AND expensevar.ninv = invoice.ninv)
		AND invoice.yinv < @ayear

		UPDATE invoice SET active = 'N'
		WHERE 
		ISNULL(
			(SELECT ISNULL(taxabletotal,0) + ISNULL(ivatotal,0) FROM totinvoiceview
			WHERE totinvoiceview.idinvkind = invoice.idinvkind
			AND totinvoiceview.yinv = invoice.yinv
			AND totinvoiceview.ninv = invoice.ninv)
		,0) = 
		ISNULL(
			(SELECT -SUM(amount)
			FROM expensevar
			WHERE expensevar.idinvkind = invoice.idinvkind
				AND expensevar.yinv = invoice.yinv
				AND expensevar.ninv = invoice.ninv)
		,0)
		AND invoice.yinv = @ayear
	END
END
ELSE
BEGIN
	IF ((SELECT COUNT(*) FROM incomeinvoice WHERE yinv < @ayear) > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM incomeinvoice
			WHERE incomeinvoice.idinvkind = invoice.idinvkind
				AND incomeinvoice.yinv = invoice.yinv
				AND incomeinvoice.ninv = invoice.ninv)
		AND invoice.yinv < @ayear
	END

	IF ((SELECT COUNT(*) FROM expenseinvoice WHERE yinv < @ayear) > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM expenseinvoice
			WHERE expenseinvoice.idinvkind = invoice.idinvkind
				AND expenseinvoice.yinv = invoice.yinv
				AND expenseinvoice.ninv = invoice.ninv)
		AND invoice.yinv < @ayear
	END

	IF ((SELECT COUNT(*) FROM incomevar WHERE yinv < @ayear) > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM incomevar
			WHERE incomevar.idinvkind = invoice.idinvkind
				AND incomevar.yinv = invoice.yinv
				AND incomevar.ninv = invoice.ninv)
		AND invoice.yinv < @ayear
	END

	IF ((SELECT COUNT(*) FROM expensevar WHERE yinv < @ayear) > 0)
	BEGIN
		UPDATE invoice SET active = 'N'
		WHERE EXISTS
			(SELECT * FROM expensevar
			WHERE expensevar.idinvkind = invoice.idinvkind
				AND expensevar.yinv = invoice.yinv
				AND expensevar.ninv = invoice.ninv)
		AND invoice.yinv < @ayear
	END
END
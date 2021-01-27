
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registroiva_sub_old]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registroiva_sub_old]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_registroiva_sub_old]
	@idivaregisterkind int,
	@year int,
	@month int
AS BEGIN
	
	CREATE TABLE #invoice_finmov
	(
		idinvkind int,		
		yinv int,
		ninv int,
		flagmixed char(1),
		ivatotal decimal(19,2),
		ivagross decimal(19,2),
		ivaabatable decimal(19,2),
		ivaunabatable decimal(19,2),
		totivaunabatable decimal(19,2),
		currivaunabatable decimal(19,2),
		taxabletotal decimal(19,2),
		previvatotalpayed decimal(19,2),
		prevtotalpayed decimal(19,2),
		currivagrosspayed decimal(19,2),
		currivapayed decimal(19,2),
		currtotalpayed decimal(19,2),
		amountlinked decimal(19,2),
		movkind varchar(20),
		rapporto decimal(19,6),
		idmov int,
		nvar int,
		adate smalldatetime,
		movdescription varchar(50),
		movdate datetime
	)

	DECLARE @registerclass char(1)
	SELECT @registerclass = registerclass
	FROM ivaregisterkind
	WHERE idivaregisterkind = @idivaregisterkind

	IF @month IS NULL OR @month < 1
	BEGIN
		SET @month = 1
	END
	IF @month > 12
	BEGIN
		SET @month = 12
	END

	DECLARE @proratarate decimal(19,6)
	SELECT @proratarate = prorata
	FROM iva_prorata
	WHERE ayear = @year
	
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed
	FROM iva_mixed
	WHERE ayear = @year

	-- Gestione IVA differita
	DECLARE @deferredexpensephase char(1)
	DECLARE @deferredincomephase char(1)
	SELECT  @deferredexpensephase = deferredexpensephase, 
		@deferredincomephase = deferredincomephase
	FROM config WHERE ayear = @year
	
	CREATE TABLE #invoice
	(
		idinvkind  int,		
		yinv int,
		ninv int,
		flagmixed char(1),
		ivatotal decimal(19,2),
		ivagross decimal(19,2),
		ivaabatable decimal(19,2),
		ivaunabatable decimal(19,2),
		totivaunabatable decimal(19,2),
		currivaunabatable decimal(19,2),
		prorataamount decimal(19,2),
		mixedamount decimal(19,2),
		taxabletotal decimal(19,2),
		amountlinked decimal(19,2),
		movkind varchar(20),
		idivakind  int,		
		adate smalldatetime,
		movdescription varchar(50),
		movdate datetime
	)

	IF (@registerclass = 'A')
	BEGIN
		-- Sezione 2.2. IVA Differita
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagmixed, adate,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, idmov, movdescription, movdate)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expenseinvoice.movkind, 
	   	CASE
			WHEN ivaregisterkind.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,	
		invoice.adate,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		paymentcommunicated.amount, expenseinvoice.idexp,
		'Mov. n. ' + CONVERT(varchar(6),paymentcommunicated.nmov) + '/' + CONVERT(varchar(4),paymentcommunicated.ymov),
		paymentcommunicated.competencydate
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
			AND MONTH(paymentcommunicated.competencydate) = @month
			AND invoice.flagdeferred = 'S'
			AND ivaregisterkind.idivaregisterkind = @idivaregisterkind)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagmixed, adate,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, idmov, nvar, movdescription, movdate)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,expensevar.movkind, 
	   	CASE
			WHEN ivaregisterkind.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,	
		invoice.adate,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		expensevar.amount, expensevar.idexp, expensevar.nvar,
		'Var. n. ' + CONVERT(varchar(6),expensevar.nvar) + '/' + CONVERT(varchar(4),expensevar.yvar),
		paymentcommunicated.competencydate
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
		AND MONTH(paymentcommunicated.competencydate) = @month
		AND invoice.flagdeferred = 'S'
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind)
	END	
	
	IF (@registerclass = 'V')
	BEGIN
		-- Sezione 2.2. IVA Differita
		-- Calcolo sulle Fatture
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagmixed, adate,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, idmov, movdescription, movdate)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomeinvoice.movkind,
	   	CASE
			WHEN ivaregisterkind.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,	
		invoice.adate,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		proceedsemitted.amount, incomeinvoice.idinc,
		'Mov. n. ' + CONVERT(varchar(6),proceedsemitted.nmov) + '/' + CONVERT(varchar(4),proceedsemitted.ymov),
		proceedsemitted.competencydate
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
		AND MONTH(proceedsemitted.competencydate) = @month
		AND invoice.flagdeferred = 'S'
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind)

		-- Calcolo sulle Note di Credito
		INSERT INTO #invoice_finmov (idinvkind, yinv, ninv, movkind, flagmixed, adate,
		ivatotal, taxabletotal, totivaunabatable, amountlinked, idmov, nvar, movdescription, movdate)
		(SELECT invoice.idinvkind,invoice.yinv,invoice.ninv,incomevar.movkind, 
	   	CASE
			WHEN ivaregisterkind.flagactivity = 3  THEN 'S'
			ELSE 'N'
		END,	
		invoice.adate,
		totinvoiceview.ivatotal, totinvoiceview.taxabletotal, totinvoiceview.unabatabletotal, 
		incomevar.amount, incomevar.idinc, incomevar.nvar,
		'Var. n. ' + CONVERT(varchar(6),incomevar.nvar) + '/' + CONVERT(varchar(4),incomevar.yvar),
		proceedsemitted.competencydate
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
		AND MONTH(proceedsemitted.competencydate) = @month
		AND invoice.flagdeferred = 'S'
		AND ivaregisterkind.idivaregisterkind = @idivaregisterkind)
	END
	
	DECLARE @datebegin datetime
	DECLARE @dateend datetime
	DECLARE @monthstr varchar(2)
	SET @monthstr = SUBSTRING('00',1,2 - LEN(CONVERT(varchar(2),@month))) + CONVERT(varchar(2),@month)
	SET @datebegin = '01-' + @monthstr + '-' + CONVERT(varchar(4),@year)
	SET @dateend = DATEADD(DAY,-1,DATEADD(MONTH,1,@datebegin))
	
	UPDATE #invoice_finmov
	SET previvatotalpayed =
	ISNULL(
		(SELECT SUM(ivatotalpayed)
		FROM invoicedeferred
		JOIN ivapay
		ON ivapay.yivapay = invoicedeferred.yivapay
		AND ivapay.nivapay = invoicedeferred.nivapay
		WHERE #invoice_finmov.idinvkind = invoicedeferred.idinvkind
		AND #invoice_finmov.yinv = invoicedeferred.yinv
		AND #invoice_finmov.ninv = invoicedeferred.ninv
		AND ivapay.stop < @datebegin)
	,0)
	UPDATE #invoice_finmov
	SET prevtotalpayed =
	ISNULL(
		(SELECT SUM(totalpayed)
		FROM invoicedeferred
		JOIN ivapay
		ON ivapay.yivapay = invoicedeferred.yivapay
		AND ivapay.nivapay = invoicedeferred.nivapay
		WHERE #invoice_finmov.idinvkind = invoicedeferred.idinvkind
		AND #invoice_finmov.yinv = invoicedeferred.yinv
		AND #invoice_finmov.ninv = invoicedeferred.ninv
		AND ivapay.stop < @datebegin)
	,0)
	WHERE #invoice_finmov.movkind = 1
	UPDATE #invoice_finmov
	SET rapporto = 
	CASE
		WHEN ABS(#invoice_finmov.amountlinked) +
		ISNULL(
			(SELECT ABS(SUM(amountlinked))
			FROM #invoice_finmov i2
			WHERE i2.idinvkind = #invoice_finmov.idinvkind
			AND i2.yinv = #invoice_finmov.yinv
			AND i2.ninv = #invoice_finmov.ninv
			AND i2.idmov + CONVERT(varchar(6),ISNULL(i2.nvar,0)) <
			#invoice_finmov.idmov + CONVERT(varchar(6),ISNULL(#invoice_finmov.nvar,0)))
		,0) <> (ISNULL(#invoice_finmov.ivatotal,0) - ISNULL(#invoice_finmov.previvatotalpayed,0))
		THEN ABS(#invoice_finmov.amountlinked) / ISNULL(#invoice_finmov.ivatotal,0)
		ELSE 1
	END
	WHERE movkind = 2
	
	UPDATE #invoice_finmov
	SET rapporto = 
	CASE
		WHEN ABS(#invoice_finmov.amountlinked) +
		ISNULL(
			(SELECT ABS(SUM(amountlinked))
			FROM #invoice_finmov i2
			WHERE i2.idinvkind = #invoice_finmov.idinvkind
			AND i2.yinv = #invoice_finmov.yinv
			AND i2.ninv = #invoice_finmov.ninv
			AND i2.idmov + CONVERT(varchar(6),ISNULL(i2.nvar,0)) <
			#invoice_finmov.idmov + CONVERT(varchar(6),ISNULL(#invoice_finmov.nvar,0)))
		,0) <> (ISNULL(#invoice_finmov.ivatotal,0) + ISNULL(#invoice_finmov.taxabletotal,0) - ISNULL(#invoice_finmov.prevtotalpayed,0)) 
		THEN ABS(#invoice_finmov.amountlinked) / (ISNULL(#invoice_finmov.taxabletotal,0) + ISNULL(#invoice_finmov.ivatotal,0))
		ELSE 1
	END
	WHERE movkind = 1
	
	-- Contabilizzazione IMPOS
	INSERT INTO #invoice (idinvkind,yinv, ninv, taxabletotal, ivagross, ivaabatable, idivakind, adate, movdescription, movdate)
	SELECT #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, 
	CASE
		WHEN #invoice_finmov.rapporto <> 1
		THEN
		CONVERT(decimal(19,2),
			SUM(
				ROUND(
					invoicedetail.taxable * invoicedetail.npackage * 
					CONVERT(decimal(19,6),invoice.exchangerate) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0)))
					* rapporto
				,2)
			)
		)
		ELSE
		CONVERT(decimal(19,2),
			SUM(
				ROUND(
					invoicedetail.taxable * invoicedetail.npackage * 
					CONVERT(decimal(19,6),invoice.exchangerate) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0)))
				,2)
			)
		)
		-
		(
			CONVERT(decimal(19,2),
				SUM(
			    	ROUND(
						invoicedetail.taxable * invoicedetail.npackage * 
						CONVERT(decimal(19,6),invoice.exchangerate) *
						(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0)))
						*
						(#invoice_finmov.previvatotalpayed / #invoice_finmov.ivatotal)
					,2)
				)
			)
		)
		-
		ISNULL(
			(SELECT 
				CONVERT(decimal(19,2),
					SUM(
						ROUND(
							id2.taxable * id2.npackage * 
							CONVERT(decimal(19,6),i2.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(id2.discount, 0)))
							* ifm2.rapporto
						,2)
					)
				)
			FROM invoice i2
			JOIN invoicedetail id2
			ON i2.idinvkind = id2.idinvkind
			AND i2.yinv = id2.yinv
			AND i2.ninv = id2.ninv
			JOIN #invoice_finmov ifm2
			ON ifm2.idinvkind = i2.idinvkind
			AND ifm2.yinv = i2.yinv
			AND ifm2.ninv = i2.ninv
			WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
			AND ifm2.idinvkind = #invoice_finmov.idinvkind
			AND ifm2.yinv = #invoice_finmov.yinv
			AND ifm2.ninv = #invoice_finmov.ninv
			AND id2.idivakind = invoicedetail.idivakind)
		,0)
	END,
	CASE
		WHEN #invoice_finmov.rapporto <> 1
		THEN ISNULL(SUM(ROUND(invoicedetail.tax, 2)),0) * rapporto
		ELSE
			ISNULL(
				SUM(
					ROUND(invoicedetail.tax, 2)
				)
			,0)
			-
			(
				ISNULL(
					SUM(
						ROUND(
							invoicedetail.tax
							 * (#invoice_finmov.previvatotalpayed / #invoice_finmov.ivatotal)
						,2)
					)
				,0)
			)
			-
			ISNULL(
				(SELECT 
					CONVERT(decimal(19,2),
						SUM(ROUND(id2.tax * ifm2.rapporto,2))
					)
				FROM invoice i2
				JOIN invoicedetail id2
				ON i2.idinvkind = id2.idinvkind
				AND i2.yinv = id2.yinv
				AND i2.ninv = id2.ninv
				JOIN #invoice_finmov ifm2
				ON ifm2.idinvkind = i2.idinvkind
				AND ifm2.yinv = i2.yinv
				AND ifm2.ninv = i2.ninv
				WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
				AND ifm2.idinvkind = #invoice_finmov.idinvkind
				AND ifm2.yinv = #invoice_finmov.yinv
				AND ifm2.ninv = #invoice_finmov.ninv
				AND id2.idivakind = invoicedetail.idivakind)
			,0)
	END,
	CASE
		WHEN @registerclass = 'A' THEN
		CASE 
			WHEN #invoice_finmov.rapporto <> 1
			THEN 
			ISNULL(
				SUM(
					ROUND(
						(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
						* ISNULL(@proratarate,0) *
						CASE
							WHEN (#invoice_finmov.flagmixed ='S')  THEN ISNULL(@mixedrate, 0)
							ELSE 1
						END * rapporto
					, 2) 
				)
			, 0)
			ELSE
			ISNULL(
				SUM(
					ROUND(
						(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
						*ISNULL(@proratarate,0) * 
						CASE
							WHEN ( #invoice_finmov.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
							ELSE 1
						END
					,2)
				)
			, 0)
			-
			ISNULL(
				SUM(
					ROUND(
						(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
						* ISNULL(@proratarate,0) * 
						CASE
							WHEN ( #invoice_finmov.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
							ELSE 1
						END
						* (#invoice_finmov.previvatotalpayed / #invoice_finmov.ivatotal)
					,2)
				)
			, 0)
			-
			ISNULL(
				(SELECT 
				ISNULL(
					SUM(
						ROUND(
							(ISNULL(id2.tax,0) - ISNULL(id2.unabatable,0))
							* ifm2.rapporto * ISNULL(@proratarate,0) *
							CASE
								WHEN ( ifm2.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
								ELSE 1
							END
						,2) 
					)
				, 0)
				FROM invoice i2
				JOIN invoicedetail id2
				ON i2.idinvkind = id2.idinvkind
				AND i2.yinv = id2.yinv
				AND i2.ninv = id2.ninv
				JOIN #invoice_finmov ifm2
				ON ifm2.idinvkind = i2.idinvkind
				AND ifm2.yinv = i2.yinv
				AND ifm2.ninv = i2.ninv
				WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
				AND id2.idivakind = invoicedetail.idivakind
				AND ifm2.idinvkind = #invoice_finmov.idinvkind
				AND ifm2.yinv = #invoice_finmov.yinv
				AND ifm2.ninv = #invoice_finmov.ninv
				GROUP BY ifm2.flagmixed)
			,0)
		END
		ELSE 
		CASE
			WHEN #invoice_finmov.rapporto <> 1
			THEN ISNULL(SUM(ROUND(invoicedetail.tax * rapporto, 2)),0) 
			ELSE
				ISNULL(
					SUM(
						ROUND(invoicedetail.tax, 2)
					)
				,0)
				-
				(
					ISNULL(
						SUM(
							ROUND(
								invoicedetail.tax
								* (#invoice_finmov.previvatotalpayed / #invoice_finmov.ivatotal)
							,2)
						)
					,0)
				)
			-
			ISNULL(
				(SELECT 
					CONVERT(decimal(19,2),
						SUM(ROUND(id2.tax,2)* ifm2.rapporto)
					)
				FROM invoice i2
				JOIN invoicedetail id2
				ON i2.idinvkind = id2.idinvkind
				AND i2.yinv = id2.yinv
				AND i2.ninv = id2.ninv
				JOIN #invoice_finmov ifm2
				ON ifm2.idinvkind = i2.idinvkind
				AND ifm2.yinv = i2.yinv
				AND ifm2.ninv = i2.ninv
				WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
				AND ifm2.idinvkind = #invoice_finmov.idinvkind
				AND ifm2.yinv = #invoice_finmov.yinv
				AND ifm2.ninv = #invoice_finmov.ninv
				AND id2.idivakind = invoicedetail.idivakind)
			,0)
		END
	END,
	invoicedetail.idivakind, #invoice_finmov.adate, #invoice_finmov.movdescription, #invoice_finmov.movdate
	FROM #invoice_finmov
	JOIN invoicedetail
	ON #invoice_finmov.idinvkind = invoicedetail.idinvkind
	AND #invoice_finmov.yinv = invoicedetail.yinv
	AND #invoice_finmov.ninv = invoicedetail.ninv
	JOIN invoice
	ON #invoice_finmov.idinvkind = invoice.idinvkind
	AND #invoice_finmov.yinv = invoice.yinv
	AND #invoice_finmov.ninv = invoice.ninv
	WHERE #invoice_finmov.movkind = 2
	GROUP BY invoicedetail.idivakind, #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, #invoice_finmov.rapporto,
	#invoice_finmov.previvatotalpayed, #invoice_finmov.ivatotal, #invoice_finmov.adate, #invoice_finmov.flagmixed, 
	#invoice_finmov.movdescription, #invoice_finmov.movdate, #invoice_finmov.idmov, #invoice_finmov.nvar

	
	-- Contabilizzazione DOCUM
	INSERT INTO #invoice (idinvkind,yinv, ninv, taxabletotal, ivagross, ivaabatable, idivakind, adate, movdescription, movdate)
	SELECT #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, 
	CASE
		WHEN #invoice_finmov.rapporto <> 1
		THEN
		CONVERT(decimal(19,2),
			SUM(
				ROUND(
					invoicedetail.taxable * invoicedetail.npackage * 
					CONVERT(decimal(19,6),invoice.exchangerate) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))) * rapporto
				,2)
			)
		)
		ELSE
		CONVERT(decimal(19,2),
			SUM(
				ROUND(
					invoicedetail.taxable * invoicedetail.npackage * 
					CONVERT(decimal(19,6),invoice.exchangerate) *
					(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0)))
				,2)
			)
		)
		-
		(
			CONVERT(decimal(19,2),
				SUM(
					ROUND(
						invoicedetail.taxable * invoicedetail.npackage * 
						CONVERT(decimal(19,6),invoice.exchangerate) *
						(1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0)))
						 *
						(#invoice_finmov.prevtotalpayed / (#invoice_finmov.ivatotal + #invoice_finmov.taxabletotal))
					,2)
				)
			)
		)
		-
		ISNULL(
			(SELECT 
				CONVERT(decimal(19,2),
					SUM(
						ROUND(
							id2.taxable * id2.npackage * 
							CONVERT(decimal(19,6),i2.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(id2.discount, 0)))
						* ifm2.rapporto
						,2)
					)
				)
			FROM invoice i2
			JOIN invoicedetail id2
			ON i2.idinvkind = id2.idinvkind
			AND i2.yinv = id2.yinv
			AND i2.ninv = id2.ninv
			JOIN #invoice_finmov ifm2
			ON ifm2.idinvkind = i2.idinvkind
			AND ifm2.yinv = i2.yinv
			AND ifm2.ninv = i2.ninv
			WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
			AND ifm2.idinvkind = #invoice_finmov.idinvkind
			AND ifm2.yinv = #invoice_finmov.yinv
			AND ifm2.ninv = #invoice_finmov.ninv
			AND id2.idivakind = invoicedetail.idivakind)
		,0)
	END,
	CASE
		WHEN #invoice_finmov.rapporto <> 1
		THEN ISNULL(SUM(ROUND(invoicedetail.tax * rapporto, 2)),0) 
		ELSE
			ISNULL(
				SUM(
					ROUND(invoicedetail.tax, 2)
				)
			,0)
			- (
				ISNULL(
					SUM(
						ROUND(
							invoicedetail.tax
							* (#invoice_finmov.prevtotalpayed / (#invoice_finmov.ivatotal + #invoice_finmov.taxabletotal))
						, 2)
					)
				,0)
			)
			-
			ISNULL(
				(SELECT 
					CONVERT(decimal(19,2),
						SUM(ROUND(id2.tax * ifm2.rapporto,2))
					)
				FROM invoice i2
				JOIN invoicedetail id2
				ON i2.idinvkind = id2.idinvkind
				AND i2.yinv = id2.yinv
				AND i2.ninv = id2.ninv
				JOIN #invoice_finmov ifm2
				ON ifm2.idinvkind = i2.idinvkind
				AND ifm2.yinv = i2.yinv
				AND ifm2.ninv = i2.ninv
				WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
				AND ifm2.idinvkind = #invoice_finmov.idinvkind
				AND ifm2.yinv = #invoice_finmov.yinv
				AND ifm2.ninv = #invoice_finmov.ninv
				AND id2.idivakind = invoicedetail.idivakind)
			,0)
	END,
	CASE
		WHEN @registerclass = 'A' THEN
		CASE 
			WHEN #invoice_finmov.rapporto <> 1
			THEN 
				ISNULL(
					SUM(
						ROUND(
							(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
							* ISNULL(@proratarate,0) * 
							CASE
								WHEN ( #invoice_finmov.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
								ELSE 1
							END * rapporto
						,2)
					)
				,0)
			ELSE
				ISNULL(
					SUM(
						ROUND(
							(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
							* ISNULL(@proratarate,0) * 
							CASE
								WHEN ( #invoice_finmov.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
								ELSE 1
							END
						,2)
					)
				,0)
				 -
				ISNULL(
					SUM(
						ROUND(
							(ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0))
							* ISNULL(@proratarate,0) * 
							CASE
								WHEN ( #invoice_finmov.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
								ELSE 1
							END
							* (#invoice_finmov.prevtotalpayed / (#invoice_finmov.ivatotal + #invoice_finmov.taxabletotal))
						,2)
					)
				,0)
				-
				ISNULL(
					(SELECT 
					ISNULL(
						SUM(
							ROUND(
								(ISNULL(id2.tax,0) - ISNULL(id2.unabatable,0))
								 * ifm2.rapporto * ISNULL(@proratarate,0) * 
								CASE
									WHEN  ( ifm2.flagmixed ='S') THEN ISNULL(@mixedrate, 0)
									ELSE 1
								END
							,2)
						)
					,0)
					FROM invoice i2
					JOIN invoicedetail id2
					ON i2.idinvkind = id2.idinvkind
					AND i2.yinv = id2.yinv
					AND i2.ninv = id2.ninv
					JOIN #invoice_finmov ifm2
					ON ifm2.idinvkind = i2.idinvkind
					AND ifm2.yinv = i2.yinv
					AND ifm2.ninv = i2.ninv
					WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
					AND id2.idivakind = invoicedetail.idivakind
					AND ifm2.idinvkind = #invoice_finmov.idinvkind
					AND ifm2.yinv = #invoice_finmov.yinv
					AND ifm2.ninv = #invoice_finmov.ninv
					GROUP BY ifm2.flagmixed)
				,0)
		END
		ELSE
		CASE
			WHEN #invoice_finmov.rapporto <> 1
			THEN ISNULL(SUM(ROUND(invoicedetail.tax * rapporto, 2)),0) 
			ELSE
				ISNULL(
					SUM(
						ROUND(invoicedetail.tax, 2)
					)
				,0)
				-
				(
					ISNULL(
						SUM(
							ROUND(invoicedetail.tax
							* (#invoice_finmov.prevtotalpayed / (#invoice_finmov.ivatotal + #invoice_finmov.taxabletotal))
							, 2)
						)
					,0)
				)
				-
				ISNULL(
					(SELECT 
					CONVERT(decimal(19,2),
						SUM(ROUND(id2.tax,2)* ifm2.rapporto)
						)
					FROM invoice i2
					JOIN invoicedetail id2
					ON i2.idinvkind = id2.idinvkind
					AND i2.yinv = id2.yinv
					AND i2.ninv = id2.ninv
					JOIN #invoice_finmov ifm2
					ON ifm2.idinvkind = i2.idinvkind
					AND ifm2.yinv = i2.yinv
					AND ifm2.ninv = i2.ninv
					WHERE ifm2.idmov + ISNULL(CONVERT(varchar(6),ifm2.nvar),'')< #invoice_finmov.idmov + ISNULL(CONVERT(varchar(6),#invoice_finmov.nvar),'')
					AND ifm2.idinvkind = #invoice_finmov.idinvkind
					AND ifm2.yinv = #invoice_finmov.yinv
					AND ifm2.ninv = #invoice_finmov.ninv
					AND id2.idivakind = invoicedetail.idivakind)
				,0)
		END
	END,
	invoicedetail.idivakind, #invoice_finmov.adate, #invoice_finmov.movdescription, #invoice_finmov.movdate
	FROM #invoice_finmov
	JOIN invoicedetail
	ON #invoice_finmov.idinvkind = invoicedetail.idinvkind
	AND #invoice_finmov.yinv = invoicedetail.yinv
	AND #invoice_finmov.ninv = invoicedetail.ninv
	JOIN invoice
	ON #invoice_finmov.idinvkind = invoice.idinvkind
	AND #invoice_finmov.yinv = invoice.yinv
	AND #invoice_finmov.ninv = invoice.ninv
	WHERE #invoice_finmov.movkind = 1
	GROUP BY invoicedetail.idivakind, #invoice_finmov.idinvkind, #invoice_finmov.yinv, #invoice_finmov.ninv, #invoice_finmov.rapporto,
	#invoice_finmov.ivatotal, #invoice_finmov.taxabletotal, #invoice_finmov.prevtotalpayed, #invoice_finmov.adate,
	#invoice_finmov.flagmixed, #invoice_finmov.movdescription, #invoice_finmov.movdate, #invoice_finmov.idmov, #invoice_finmov.nvar
	
	-- Inverto i valori delle note di credito con IVA differita
	UPDATE #invoice SET taxabletotal = -taxabletotal, ivagross = -ivagross, ivaabatable = -ivaabatable
	WHERE (SELECT (flag&4) FROM invoicekind
		WHERE idinvkind = #invoice.idinvkind) <> 0 -- Spesa

	UPDATE #invoice SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)
	
	SELECT
	ivaregister.nivaregister,
	#invoice.adate,
	ISNULL(invoicekind.description,'')  AS idinvkinddescr,
	#invoice.movdescription,
	#invoice.movdate,
	invoice.doc,
	invoice.docdate,
	currency.codecurrency as idcurrency,
	invoice.exchangerate,
	#invoice.taxabletotal,
	#invoice.ivagross,
	#invoice.ivaabatable,
	#invoice.ivaunabatable,
	ivakind.description AS idivakind
	FROM #invoice
	JOIN invoice
		ON invoice.idinvkind = #invoice.idinvkind
		AND invoice.yinv = #invoice.yinv
		AND invoice.ninv = #invoice.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN ivaregisterkind
		ON ivaregister.idivaregisterkind = ivaregisterkind.idivaregisterkind
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivakind
		ON ivakind.idivakind = #invoice.idivakind
	LEFT OUTER JOIN currency
		ON currency.idcurrency = invoice.idcurrency
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
	ORDER BY nivaregister
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

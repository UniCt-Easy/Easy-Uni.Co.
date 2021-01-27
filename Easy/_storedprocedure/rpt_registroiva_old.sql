
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registroiva_old]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registroiva_old]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [rpt_registroiva_old]
	@idivaregisterkind int,
	@year int,
	@month int,
	@official char(1)
AS BEGIN
	IF @month IS NULL OR @month < 1
	BEGIN
		SET @month = 1
	END
	IF @month > 12
	BEGIN
		SET @month = 12
	END
	
	DECLARE @registerclass char(1)
	SELECT @registerclass = registerclass
	FROM ivaregisterkind
	WHERE idivaregisterkind = @idivaregisterkind
	DECLARE @monthname varchar(20)
	SELECT @monthname = title
	FROM monthname
	WHERE code = @month
	DECLARE @proratarate decimal(19,6)
	SELECT @proratarate = prorata
	FROM iva_prorata
	WHERE ayear = @year
	DECLARE @mixedrate decimal(19,6)	
	SELECT @mixedrate = mixed
	FROM iva_mixed
	WHERE ayear = @year
	CREATE TABLE #invoice
	(
		idinvkind int,		
		yinv int,
		ninv int,
		idivaregisterkind int,	
		flagmixed char(1),
		flagdeferred char(1),
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
		idivakind int		
	)

	-- Gestione IVA Immediata
	-- Calcolo sulle Fatture
	INSERT INTO #invoice (idinvkind, yinv, ninv, flagdeferred, idivaregisterkind,
	taxabletotal, ivagross, ivaabatable, idivakind)
	(SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.flagdeferred, ivaregisterkind.idivaregisterkind,
	CONVERT(decimal(19,2),
	SUM(
	    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
		  CONVERT(decimal(19,6),invoice.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
		 )
	   )
	),
	ISNULL(SUM(ROUND(invoicedetail.tax, 2)),0), 
	CASE
		WHEN @registerclass = 'A' THEN
		ISNULL(SUM(ROUND((ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0)) * invoice.exchangerate, 2)), 0)
		* ISNULL(@proratarate,0) * 
			CASE
				WHEN (invoicekind.flag&2)<>0 THEN ISNULL(@mixedrate, 0)
				ELSE 1
			END
		ELSE ISNULL(SUM(ROUND(invoicedetail.tax, 2)),0)
	END,
	ivakind.idivakind
	FROM ivaregister
	JOIN invoice
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
	JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	JOIN invoicekind
	ON invoicekind.idinvkind = ivaregister.idinvkind
	JOIN invoicedetail
	ON invoicedetail.idinvkind = ivaregister.idinvkind
	AND invoicedetail.yinv = ivaregister.yinv
	AND invoicedetail.ninv = ivaregister.ninv
	JOIN ivakind
	ON invoicedetail.idivakind = ivakind.idivakind
	WHERE ivaregisterkind.registerclass = @registerclass
	AND (invoicekind.flag&4)=0 
	AND YEAR(invoice.adate) = @year
	AND MONTH(invoice.adate) = @month
	AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
	GROUP BY invoice.idinvkind, invoice.yinv, invoice.ninv, ivaregisterkind.idivaregisterkind, ivakind.idivakind,
	(invoicekind.flag&2), invoice.flagdeferred)
	
	-- Calcolo sulle Note di Credito
	INSERT INTO #invoice (idinvkind, yinv, ninv, flagdeferred, idivaregisterkind,
	taxabletotal, ivagross, ivaabatable, idivakind)
	(SELECT invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.flagdeferred, ivaregisterkind.idivaregisterkind,
	- CONVERT(decimal(19,2),
	SUM(
	    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
		  CONVERT(decimal(19,6),invoice.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
		 )
	   )
	),
	- ISNULL(SUM(ROUND(invoicedetail.tax * invoice.exchangerate, 2)),0), 
	CASE
		WHEN @registerclass = 'A' THEN
		- ISNULL(SUM(ROUND((ISNULL(invoicedetail.tax,0) - ISNULL(invoicedetail.unabatable,0)) * invoice.exchangerate, 2)), 0)
		* ISNULL(@proratarate,0) * 
			CASE
				WHEN (invoicekind.flag&2)<>0 THEN ISNULL(@mixedrate, 0)
				ELSE 1
			END
		ELSE - ISNULL(SUM(ROUND(invoicedetail.tax, 2)),0)
	END,
	ivakind.idivakind
	FROM ivaregister
	JOIN invoice
	ON invoice.idinvkind = ivaregister.idinvkind
	AND invoice.yinv = ivaregister.yinv
	AND invoice.ninv = ivaregister.ninv
	JOIN ivaregisterkind
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	JOIN invoicekind
	ON invoicekind.idinvkind = ivaregister.idinvkind
	JOIN invoicedetail
	ON invoicedetail.idinvkind = ivaregister.idinvkind
	AND invoicedetail.yinv = ivaregister.yinv
	AND invoicedetail.ninv = ivaregister.ninv
	JOIN ivakind
	ON ivakind.idivakind = invoicedetail.idivakind
	WHERE ivaregisterkind.registerclass = @registerclass
	AND (invoicekind.flag&4)<>0--variation = 'S'
	AND YEAR(invoice.adate) = @year
	AND MONTH(invoice.adate) = @month
	AND ivaregisterkind.idivaregisterkind = @idivaregisterkind
	GROUP BY invoice.idinvkind, invoice.yinv, invoice.ninv, ivaregisterkind.idivaregisterkind, ivakind.idivakind,
	(invoicekind.flag&2), invoice.flagdeferred)
	UPDATE #invoice SET ivaunabatable = ISNULL(ivagross,0) - ISNULL(ivaabatable,0)
	
	SELECT
		ivaregisterkind.description AS ivaregisterdescr,
		@monthname AS monthname,
		@year AS ayear,
		ivaregister.nivaregister,
		#invoice.flagdeferred,
		invoice.adate AS registrationdate,
		invoicekind.description AS idinvkinddescr,
		invoice.doc,
		invoice.docdate,
		registry.title AS registry,
		currency.codecurrency as idcurrency,
		invoice.exchangerate,
		ISNULL(
			(SELECT ISNULL(SUM(i2.taxabletotal),0) + ISNULL(SUM(i2.ivagross),0)
			FROM #invoice i2
			WHERE #invoice.idinvkind = i2.idinvkind
			AND #invoice.yinv = i2.yinv
			AND #invoice.ninv = i2.ninv)
		,0) AS total,
		#invoice.taxabletotal,
		#invoice.ivagross,
		#invoice.ivaabatable,
		#invoice.ivaunabatable,
		ivakind.description AS idivakind,
		unifiedivaregisterkind.description as unifiedivaregisterkind,
		unifiedivaregister.unifiedninv
		FROM #invoice
		JOIN ivaregisterkind
			ON #invoice.idivaregisterkind = ivaregisterkind.idivaregisterkind
		JOIN ivaregister
			ON #invoice.idivaregisterkind = ivaregister.idivaregisterkind
			AND #invoice.idinvkind = ivaregister.idinvkind
			AND #invoice.yinv = ivaregister.yinv
			AND #invoice.ninv = ivaregister.ninv
		JOIN invoice
			ON invoice.idinvkind = #invoice.idinvkind
			AND invoice.yinv = #invoice.yinv
			AND invoice.ninv = #invoice.ninv
		JOIN registry
			ON registry.idreg = invoice.idreg
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = #invoice.idivakind
		left outer join unifiedivaregister
			ON unifiedivaregister.idinvkind = #invoice.idinvkind
			AND unifiedivaregister.yinv = #invoice.yinv
			AND unifiedivaregister.ninv = #invoice.ninv
		left outer join unifiedivaregisterkind
			ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
		LEFT OUTER JOIN currency
			ON currency.idcurrency = invoice.idcurrency
		WHERE ivaregisterkind.registerclass = @registerclass
		ORDER BY nivaregister
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


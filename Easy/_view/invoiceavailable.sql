-- CREAZIONE VISTA invoiceavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceavailable]
GO

--setuser 'amm' , select * from invoiceavailable

CREATE    VIEW [invoiceavailable]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	doc,
	docdate,
	ycon,
	ncon,
	adate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	cu, 
	ct, 
	lu, 
	lt,
	taxabletotal,
	ivatotal,
	linkedamount,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flag_enable_split_payment,
	flag_auto_split_payment
)
AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.doc,
	invoice.docdate,
	null,
	null,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	invoice.officiallyprinted,
	invoice.cu, 
	invoice.ct, 
	invoice.lu, 
	invoice.lt,
	totinvoiceview.taxabletotal,
	totinvoiceview.ivatotal,
	CONVERT(decimal(23,5),
	CASE 
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)  AND (invoice.flag_enable_split_payment='N') THEN  
		ISNULL(
			(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)  AND (invoice.flag_enable_split_payment='S') THEN  
		ISNULL(
			(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
		+ totinvoiceview.ivatotal
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0) AND (invoice.flag_enable_split_payment='N') THEN
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e 
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0) AND (invoice.flag_enable_split_payment='S') THEN
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e 
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)
		+ totinvoiceview.ivatotal

	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN 
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.idinvkind = invoice.idinvkind
			AND mov.yinv = invoice.yinv
			AND mov.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
		ISNULL(
			(SELECT ABS(SUM(s.amount)) 
			FROM expensevar s
			WHERE s.idinvkind = invoice.idinvkind
			AND s.yinv = invoice.yinv
			AND s.ninv = invoice.ninv)
		,0)
	END),

	--residuo = totaleimponibile + totaleiva - totale movimenti
	ISNULL(totinvoiceview.taxabletotal, 0.0) +
	ISNULL(totinvoiceview.ivatotal, 0.0) - 
	
	CONVERT(decimal(19,5),
	CASE 
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)  AND (invoice.flag_enable_split_payment='N')THEN 
		ISNULL(
			(SELECT SUM(incomeyear_starting.amount)
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
	
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)  AND (invoice.flag_enable_split_payment='S') THEN 
		ISNULL(
			(SELECT SUM(incomeyear_starting.amount)
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
		+ totinvoiceview.ivatotal

	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0)  AND (invoice.flag_enable_split_payment='N') THEN 
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)

	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0)  AND (invoice.flag_enable_split_payment='S') THEN 
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)
		+ totinvoiceview.ivatotal
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.idinvkind = invoice.idinvkind
			AND mov.yinv = invoice.yinv
			AND mov.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
		ISNULL(
			(SELECT ABS(SUM(s.amount)) 
			FROM expensevar s (NOLOCK)
			WHERE s.idinvkind = invoice.idinvkind
			AND s.yinv = invoice.yinv
			AND s.ninv = invoice.ninv)
		,0)
	END),
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
	invoice.flag_enable_split_payment,
	invoice.flag_auto_split_payment
FROM invoice (NOLOCK)
JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv






 
GO


 
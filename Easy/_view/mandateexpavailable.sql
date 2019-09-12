-- CREAZIONE VISTA mandateexpavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[mandateexpavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandateexpavailable]
GO


--select * from mandateexpavailable
-- Rusciano G. 01.12.2005
CREATE      VIEW [mandateexpavailable]
(
	idmankind,
	yman,
	nman,
	mankind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	flagintracom,
	idman,
	manager,
	idmandatestatus,
	mandatestatus,
	isrequest,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	subappropriation,
	finsubappropriation,
	adatesubappropriation
)
AS SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description,
	registry.title,
	mandate.description,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	totmandateview.taxabletotal, -- totale imponibile su tutto l'ordine
	totmandateview.ivatotal,--totale iva su tutto l'ordine
	totmandatedetailview.taxabletotal,--totale imponibile dei dettagli associati a movimenti di spesa
	totmandatedetailview.ivatotal,--totale iva dei dettagli associati a movimenti di spesa
	--totale movimenti = somma (importo) del join di ordinegenericomovspesa con  spesa + 
        --somma (importo) del join di ordinegenericomovspesa con variazionespesa
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0)
	FROM expensemandate mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
	ON expensetotal_firstyear.idexp = s.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	JOIN expensevar v (NOLOCK)
	ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati o annullati
		(SELECT CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
				CASE 
				WHEN (md.idexp_taxable IS  NULL) AND ( md.idexp_iva IS  NOT NULL)
				THEN
					 ROUND((ISNULL(md.taxable,0) * ISNULL(md.npackage, md.number))  ,2)

			WHEN (( md.idexp_iva IS NULL) AND (md.idexp_taxable IS  NOT NULL) and ( m.flagintracom <>'N'))
			THEN
					 0
				WHEN (( md.idexp_iva IS NULL) AND (md.idexp_taxable IS  NOT NULL) and (m.flagintracom ='N'))
				THEN
					 ROUND( ISNULL(md.tax,0)  ,2)

				WHEN ( md.idexp_iva IS  NULL) AND (md.idexp_taxable IS  NULL)
				THEN
					 ROUND((ISNULL(md.taxable,0) * ISNULL(md.npackage, md.number) 
					 + ISNULL(md.tax,0))  ,2)
				ELSE   0
				END
			   ),0)
			)		
		FROM mandatedetail md
		join mandate m
			 on md.idmankind = m.idmankind AND  md.yman = m.yman AND  md.nman = m.nman
		WHERE md.idmankind = mandate.idmankind
		AND  md.yman = mandate.yman
		AND  md.nman = mandate.nman
		AND md.stop is null),
	mandate.active,
	mandate.flagintracom,
	mandate.idman,
	manager.title,
	mandate.idmandatestatus,
	mandatestatus.description ,
	mandatekind.isrequest,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05),
	mandate.subappropriation,
	mandate.finsubappropriation,
	mandate.adatesubappropriation
	FROM mandate (NOLOCK)
	JOIN mandatekind
	ON mandatekind.idmankind = mandate.idmankind
	JOIN totmandateview (NOLOCK)
	ON totmandateview.idmankind = mandate.idmankind
	AND totmandateview.yman = mandate.yman
	AND totmandateview.nman = mandate.nman
	LEFT OUTER JOIN totmandatedetailview (NOLOCK)
	ON totmandatedetailview.idmankind = mandate.idmankind
	AND totmandatedetailview.yman = mandate.yman
	AND totmandatedetailview.nman = mandate.nman
	LEFT OUTER JOIN registry (NOLOCK)	
	ON registry.idreg = mandate.idreg
	LEFT OUTER JOIN manager (NOLOCK)	
	ON manager.idman = mandate.idman
	LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
	

GO

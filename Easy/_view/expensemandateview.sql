
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


-- CREAZIONE VISTA expensemandateview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensemandateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensemandateview]
GO

CREATE  VIEW expensemandateview 
(
	idmankind,
	yman,
	nman,
	movkind,
	idexp,
	mankind,
	nphase,
	phase,
	ymov,
	nmov,
	--ycreation,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	totdetail,
	deltavalue, 
	deltapercent, 
	limitvalue,
	limitpercent,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
	AS SELECT
	expensemandate.idmankind,
	expensemandate.yman,
	expensemandate.nman,
	expensemandate.movkind,
	expensemandate.idexp,
	mandatekind.description,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	
	--totdetail
	isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and 
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0),

	-- deltavalue
	ISNULL(
		(SELECT Y.amount
		FROM expenseyear Y
		JOIN expensetotal T
			ON Y.idexp = T.idexp
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idexp = expensemandate.idexp)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM expensevar V
		WHERE V.idexp = expensemandate.idexp
			AND V.yvar <= expenseyear.ayear)
	,0)
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)),

/* -- J.T.R. Commentata questa gestione perché con i residui dava problemi!
	isnull(expensetotal.curramount,0) 
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)),
*/
	-- deltapercentage
	case
	when  
	      (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) = 0 AND 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
			from mandatedetailview_compact
			where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)) = 0
	      )
	then  0
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) <> 0 AND 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)) = 0
	      )
	then  1000
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)) <> 0
	      )
	then
	((
	(ISNULL(
		(SELECT Y.amount
		FROM expenseyear Y
		JOIN expensetotal T
			ON Y.idexp = T.idexp
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idexp = expensemandate.idexp)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM expensevar V
		WHERE V.idexp = expensemandate.idexp
			AND V.yvar <= expenseyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)))
	/
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)))
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            

		),0)) <> 0
	      )
	then - 1
	end,
	mandatekind.deltaamount,
	mandatekind.deltapercentage,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expensemandate.cu,
	expensemandate.ct,
	expensemandate.lu,
	expensemandate.lt,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05
	FROM expensemandate (nolock)
	JOIN expense (nolock)		ON expense.idexp = expensemandate.idexp
	JOIN expensephase (nolock) 	ON expensephase.nphase = expense.nphase
	JOIN expenseyear (nolock)	ON expenseyear.idexp = expense.idexp
	JOIN expensetotal (nolock)	ON expensetotal.idexp = expenseyear.idexp
								AND expensetotal.ayear = expenseyear.ayear
	JOIN mandatekind (nolock)	ON mandatekind.idmankind = expensemandate.idmankind
	JOIN mandate	 (nolock)	ON mandate.idmankind = expensemandate.idmankind AND mandate.nman = expensemandate.nman AND mandate.yman = expensemandate.yman 
	LEFT OUTER JOIN expense parentexpense (nolock)		ON expense.parentidexp = parentexpense.idexp
	LEFT OUTER JOIN expense former	 (nolock)			ON expense.idformerexpense = former.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear (nolock)		ON expensetotal_firstyear.idexp = expense.idexp
									AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting (nolock)	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
							AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	LEFT OUTER JOIN expenselast	 (nolock)		ON expenselast.idexp = expense.idexp
	LEFT OUTER JOIN service	 (nolock)			ON service.idser = expenselast.idser
	LEFT OUTER JOIN fin		 (nolock)			ON fin.idfin = expenseyear.idfin
	LEFT OUTER JOIN upb	 (nolock)				ON upb.idupb = expenseyear.idupb
	LEFT OUTER JOIN registry (nolock)			ON registry.idreg = expense.idreg
	LEFT OUTER JOIN manager	(nolock)	 		ON manager.idman = expense.idman
	LEFT OUTER JOIN payment	(nolock)			ON payment.kpay = expenselast.kpay


GO

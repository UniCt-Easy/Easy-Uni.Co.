
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


-- CREAZIONE VISTA incomeestimateview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomeestimateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomeestimateview]
GO







CREATE   VIEW incomeestimateview 
(
	idestimkind,
	yestim,
	nestim,
	movkind,
	idinc,
	estimkind,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
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
	incomelastflag,
	flag, 
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	incomeestimate.idestimkind,
	incomeestimate.yestim,
	incomeestimate.nestim,
	incomeestimate.movkind,
	incomeestimate.idinc,
	estimatekind.description,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0),
	-- deltaamount
	(
	(ISNULL(
		(SELECT Y.amount
		FROM incomeyear Y
		JOIN incometotal T
			ON Y.idinc = T.idinc
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idinc = incomeestimate.idinc)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM incomevar V
		WHERE V.idinc = incomeestimate.idinc
			AND V.yvar <= incomeyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)  
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) )),
	-- deltapercentage
	case
	when  
	      (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) ) = 0
	      )
	then  0
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
			from estimatedetailview
			where idinc_taxable = incomeestimate.idinc and 
        		( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
			( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
			),0)  
			+
			isnull((select sum(iva_euro)
			from estimatedetailview
			where idinc_iva = incomeestimate.idinc and 
        		( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
			( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
			),0) ) = 0
	      )
	then  1000
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0)  
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0) ) <> 0
	      )
	then
	((
	(ISNULL(
		(SELECT Y.amount
		FROM incomeyear Y
		JOIN incometotal T
			ON Y.idinc = T.idinc
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idinc = incomeestimate.idinc)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM incomevar V
		WHERE V.idinc = incomeestimate.idinc
			AND V.yvar <= incomeyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva= incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) ))
	/
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)  
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)))
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0)  
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0) ) <> 0
	      )
	then - 1
	end,
	isnull(estimatekind.deltaamount,0),
	isnull(estimatekind.deltapercentage,0),
	incomelast.flag,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	incomeestimate.cu,
	incomeestimate.ct,
	incomeestimate.lu,
	incomeestimate.lt
	FROM incomeestimate (NOLOCK)
	JOIN income (NOLOCK)					ON income.idinc = incomeestimate.idinc
	JOIN incomephase (NOLOCK)				ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)				ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)				ON incometotal.idinc = incomeyear.idinc
												AND incometotal.ayear = incomeyear.ayear
	JOIN estimatekind						ON estimatekind.idestimkind = incomeestimate.idestimkind
	LEFT OUTER JOIN income parentincome (NOLOCK)		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc and incometotal_firstyear.ayear=income.ymov		
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN incomelast  (NOLOCK)	ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)			ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)			ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)		ON manager.idman = income.idman









GO

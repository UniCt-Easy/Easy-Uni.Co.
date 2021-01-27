
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


-- CREAZIONE VISTA mandateavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[mandateavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandateavailable]
GO


--setuser 'amm'
--select * from mandateavailable
CREATE VIEW [mandateavailable]
(
	idmankind,
	yman,
	nman,
	mankind,
	registry,
	idupb,
	description,
	doc,
	docdate,
	adate,
	idman,
	manager,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	active,
	isrequest,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatekind.description,
	registry.title,
	mandatedetail.idupb,
	mandate.description,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	mandate.idman,
	manager.title,
	isnull(totmandateview.taxabletotal,0),
	isnull(totmandateview.ivatotal,0),
	
	--totale movimenti = somma (amount) del join di expensemandate con  expense + 
             --                             somma (amount) del join di expensemandate con expensevar
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s 
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expenseyear expenseyear_starting		ON expenseyear_starting.idexp =  mov.idexp
  										AND expenseyear_starting.ayear =  s.ymov 		
	WHERE mov.idmankind = mandate.idmankind 	AND mov.yman = mandate.yman			AND mov.nman = mandate.nman)
	 +

	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s			ON s.idexp = mov.idexp
	JOIN expensevar v		ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind	AND mov.yman = mandate.yman	AND mov.nman = mandate.nman)
	,2)),

	--residuo = totaleimponibile + totaleiva - totale movimenti
	CONVERT(decimal(19,2),ROUND(
	ISNULL(totmandateview.taxabletotal, 0.0) +	ISNULL(totmandateview.ivatotal, 0.0) -
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
				FROM expensemandate mov 
			JOIN expense s 	ON s.idexp = mov.idexp
			LEFT OUTER JOIN expenseyear expenseyear_starting	ON expenseyear_starting.idexp =  mov.idexp
  													AND expenseyear_starting.ayear = s.ymov		
	WHERE mov.idmankind = mandate.idmankind	AND mov.yman = mandate.yman	AND mov.nman = mandate.nman) -
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s		ON s.idexp = mov.idexp
	JOIN expensevar v	ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind	AND mov.yman = mandate.yman	AND mov.nman = mandate.nman)
	,2)),
	mandate.active,
	mandatekind.isrequest,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05
	FROM mandatedetail with (nolock)
	JOIN mandate  with (nolock)	  	ON mandatedetail.idmankind = mandate.idmankind	AND mandatedetail.yman = mandate.yman	
										AND mandatedetail.nman = mandate.nman
	JOIN mandatekind with (nolock)		ON mandate.idmankind = mandatekind.idmankind
	LEFT OUTER JOIN totmandateview  with (nolock)	ON totmandateview.idmankind = mandate.idmankind
										AND totmandateview.yman = mandate.yman
										AND totmandateview.nman = mandate.nman
LEFT OUTER JOIN manager  with (nolock)	ON manager.idman = mandate.idman
JOIN registry (NOLOCK) ON registry.idreg = mandatedetail.idreg
	--where (ordinegenerico.flagutilizzabile is null) or (ordinegenerico.flagutilizzabile='S')
GROUP BY mandatedetail.idmankind,mandate.idmankind, 
	mandatedetail.yman,mandate.yman,
	mandate.nman,mandatedetail.nman,
	mandatedetail.idreg,
	mandatedetail.idupb,
	mandatekind.description,mandate.description,
	mandate.doc,mandate.docdate,mandate.adate,mandate.active,
	mandate.idman,manager.title,
	taxabletotal,ivatotal,
	mandatekind.isrequest,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05,registry.title

GO

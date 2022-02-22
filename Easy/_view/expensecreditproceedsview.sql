
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


-- CREAZIONE VISTA accountprevisionview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensecreditproceedsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensecreditproceedsview]
GO

--setuser 'amministrazione'
--select * from expensecreditproceedsview


CREATE        VIEW expensecreditproceedsview
(
	ayear,
	idexp,	ymov,	nmov, description,curramount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	idunderwriting,
	codeunderwriting,
	underwriting,
	appropriation,
	payments, 
	topay,
	paymentsavailable,
	proceedsavailable
)
AS
SELECT 
	i1.ayear,
	s1.idexp,s1.ymov,s1.nmov, s1.description,	
	i0.amount+ isnull( (select sum(amount) from expensevar EV  where EV.idexp=S1.idexp and EV.yvar<=i1.ayear),0)	,
	i1.idfin, f.codefin,f.title,
	i1.idupb, u.codeupb, u.title,
	UW.idunderwriting, UW.codeunderwriting, UW.title,
	--appropriation
	isnull(UA.amount,0) + isnull( (select sum(amount) from expensevar EV where EV.idexp=S1.idexp and EV.idunderwriting=UW.idunderwriting),0),
	--payments
	isnull( (select sum(amount) from underwritingpayment UP  join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= UP.idexp 
												and UP.idunderwriting= UW.idunderwriting							
							),0)+
	isnull ( (select sum(amount) from expensevar PV  
							join expenselast ELA on PV.idexp=ELA.idexp
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= PV.idexp
									and PV.idunderwriting= UW.idunderwriting
							),0),
	--topay = appropriation-payments
	isnull(UA.amount,0) + isnull( (select sum(amount) from expensevar EV 
							where EV.idexp=S1.idexp and EV.idunderwriting=UW.idunderwriting),0)
	- isnull( (select sum(amount) from underwritingpayment UP  
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= UP.idexp 
												and UP.idunderwriting= UW.idunderwriting
							),0)
	- isnull ( (select sum(amount) from expensevar PV  
							join expenselast ELA on PV.idexp=ELA.idexp
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= PV.idexp
									and PV.idunderwriting= UW.idunderwriting
							),0),

	--paymentpreavailable = prev.secondaria - pagamenti	
	ISNULL(UWT.currentprev,0) + ISNULL(UWT.previsionvariation,0) 	- (ISNULL(UET.totalcompetency,0) + ISNULL(UET.totalarrears,0)),

	--proceedsavailable = tot proceeds - pagamenti
	isnull( UWT.totproceedspart,0)	- isnull( UET.totalcompetency ,0)- isnull(UET.totalarrears,0)

	
	
FROM expense s1
INNER JOIN expenseyear i0		  ON s1.idexp = i0.idexp  and i0.ayear=s1.ymov
INNER JOIN expenseyear i1		  ON s1.idexp = i1.idexp  
INNER JOIN fin f				  ON F.idfin= i1.idfin
INNER JOIN upb U			      ON U.idupb= i1.idupb
INNER JOIN  underwriting UW					  ON UW.idunderwriting 
	in ((select idunderwriting from underwritingappropriation where idexp=s1.idexp )
		union 
		 (select idunderwriting from expensevar where idexp=s1.idexp )
		)
LEFT OUTER JOIN underwritingappropriation UA on UW.idunderwriting=UA.idunderwriting and UA.idexp=i0.idexp
LEFT OUTER JOIN upbunderwritingtotal UWT	  on UWT.idfin=i1.idfin and UWT.idupb=i1.idupb and UWT.idunderwriting=UW.idunderwriting
LEFT OUTER JOIN underwritingexpensetotal UET 	ON UET.idunderwriting = UW.idunderwriting
							AND UET.idupb = i1.idupb	AND UET.idfin = i1.idfin	AND UET.nphase = (select max(nphase) from expensephase)
where s1.nphase=1

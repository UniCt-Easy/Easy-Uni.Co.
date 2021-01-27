
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


-- CREAZIONE VISTA billview
IF EXISTS(select * from sysobjects where id = object_id(N'[billview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [billview]
GO



CREATE   VIEW [billview]
(
	ybill,
	nbill,
	billkind,
	active,
	adate,
	registry,
	motive,
	total, 
	reduction,
	covered,
	regularized,
	toregularize,
	regularizationnote,
	idtreasurer,
	treasurer,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	bill.ybill,
	bill.nbill,
	bill.billkind,
	bill.active,
	bill.adate,
	bill.registry,
	bill.motive,
	bill.total, 
	bill.reduction,
	CASE billkind
		WHEN 'D' THEN
			isnull((SELECT SUM(expensetotal.curramount)
			FROM expenselast		 (NOLOCK)		
			    JOIN expensetotal (NOLOCK)
  				ON expensetotal.idexp = expenselast.idexp				
			WHERE  expenselast.nbill = bill.nbill
					and expensetotal.ayear= bill.ybill
		),0)
				+
			isnull((SELECT SUM(operation.amount)
			FROM pettycashoperation operation (NOLOCK)
			WHERE operation.yoperation = bill.ybill
				AND operation.nbill = bill.nbill
				AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = operation.yrestore
					AND restoreop.noperation = operation.nrestore
					AND restoreop.idpettycash = operation.idpettycash)),0)
				+ 
		   isnull((SELECT SUM(amount) from expensebill where expensebill.ybill=bill.ybill 
							AND expensebill.nbill=bill.nbill ),0)
		WHEN 'C' THEN
			isnull((SELECT SUM(incometotal.curramount)
			FROM incomelast (NOLOCK)
				 JOIN incometotal (NOLOCK)
  				ON incometotal.idinc = incomelast.idinc				
			WHERE incomelast.nbill = bill.nbill 
					and incometotal.ayear= bill.ybill),0)
			+
		   isnull((SELECT SUM(amount) from incomebill where incomebill.ybill=bill.ybill 
							AND incomebill.nbill=bill.nbill ),0)
	END,
	CASE ISNULL(bill.active,'S')
	WHEN 'S' THEN 
	isnull((SELECT SUM(billtransaction.amount)
			FROM billtransaction (NOLOCK)			
			WHERE billtransaction.nbill = bill.nbill 
					and billtransaction.ybilltran= bill.ybill
					and billtransaction.kind = bill.billkind),0) 
	ELSE
	isnull(bill.total,0) -  
	isnull(bill.reduction,0) 
	END
	,
	CASE ISNULL(bill.active,'S')
	WHEN 'S' THEN 
	isnull(bill.total,0) -  
	isnull(bill.reduction,0) -	
	isnull((SELECT SUM(billtransaction.amount)
		FROM billtransaction (NOLOCK)			
		WHERE billtransaction.nbill = bill.nbill 
				and billtransaction.ybilltran= bill.ybill
				and billtransaction.kind = bill.billkind),0) 
			ELSE 0
	END,				
	bill.regularizationnote,
	bill.idtreasurer,
	treasurer.description,
	treasurer.idsor01,treasurer.idsor02,treasurer.idsor03,treasurer.idsor04,treasurer.idsor05,
	bill.cu,
	bill.ct,
	bill.lu,
	bill.lt
FROM bill
LEFT OUTER JOIN treasurer
	ON bill.idtreasurer = treasurer.idtreasurer

GO

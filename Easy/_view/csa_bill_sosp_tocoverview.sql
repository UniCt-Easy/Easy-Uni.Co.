
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


-- CREAZIONE VISTA csa_bill_sosp_tocoverview
-- setuser 'amministrazione'

IF EXISTS(select * from sysobjects where id = object_id(N'[csa_bill_sosp_tocoverview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_bill_sosp_tocoverview]
GO



CREATE VIEW [csa_bill_sosp_tocoverview]
(
	ybill,
	nbill,
	billkind, 
	tocover

)
AS SELECT
	bill.ybill,
	bill.nbill,
	bill.billkind,
	bill.total
	-
	(
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
		END
	)
	- -- sottraiamo i totali per le entry di csa_bill immesse precedentemente ma che non hanno ancora generato movimenti

	ISNULL((
		SELECT SUM(csa_bill.amount)
		FROM csa_bill
		JOIN csa_import 
			ON csa_bill.idcsa_import = csa_import.idcsa_import
		WHERE csa_import.yimport = bill.ybill AND csa_bill.nbill = bill.nbill
		AND NOT EXISTS (
			SELECT *
			FROM csa_import_expense
			JOIN (
				SELECT expense.idexp, expense.ymov, expenselast.nbill
				FROM (expense JOIN expenselast ON expense.idexp = expenselast.idexp)
			) AS expensefull
				ON csa_import_expense.idexp = expensefull.idexp
			WHERE
				csa_bill.idcsa_import = csa_import_expense.idcsa_import
				AND bill.ybill = expensefull.ymov
				AND bill.nbill = expensefull.nbill
				AND bill.billkind = 'D'
		)
	),0)

	FROM bill
	WHERE bill.billkind = 'D'

GO

/*
sp_help bill
sp_help csa_bill
sp_help csa_import
sp_help csa_import_expense
sp_help expenselast
*/

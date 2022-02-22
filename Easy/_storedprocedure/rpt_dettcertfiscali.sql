
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_dettcertfiscali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_dettcertfiscali]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [rpt_dettcertfiscali]
	@ayear 			int,
	@start 			datetime,
	@stop 			datetime,
	@idreg 			int,
	@certificationkind 	char(1)
AS
BEGIN
	DECLARE @phase_accounting int
	SELECT  @phase_accounting = expensephase 
	FROM 	config 
	WHERE 	ayear = @ayear
	
	CREATE TABLE #certificazioni_fiscali
	(
		npayment	int		,
		datepayment	datetime	,
		idexp		varchar(40)	,
		desc_expense	varchar(200)	,
		servicekind	varchar(50)	,
		curramount	decimal(19,2)	,
		taxable		decimal(19,2)	,
		fiscalretention	decimal(19,2)	,
		otherretentions	decimal(19,2)	,
		employtaxamount	decimal(19,2)	
	)
	INSERT INTO #certificazioni_fiscali
	(
		idexp,
		npayment,
		datepayment,
		desc_expense,
		servicekind,
		curramount
	)
	SELECT DISTINCT
		expense.idexp,
		expense.npay,
		payment.adate,
		expense.description,
		service.description,
		ISNULL(expense.amount,0.0)
	FROM expense
	JOIN payment
		ON  payment.ypay = expense.ypay
		AND payment.npay = expense.npay
	JOIN paymenttransmission
		ON  paymenttransmission.ypaymenttransmission  = payment.ypaymenttransmission
		AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission
	JOIN service 
		ON service.idser = expense.idser
	WHERE 
		expense.idreg = @idreg and 
		((service.flagalwaysinfiscalmodels='S') OR
 		(exists (SELECT * 
		  	from expensetax D 
          		JOIN tax t
	  			ON t.taxcode= D.taxcode 
	  		WHERE t.taxkind='F' and D.idexp = expense.idexp)
			)) AND 
		service.certificatekind=@certificationkind AND 
		paymenttransmission.transmissiondate BETWEEN @start AND @stop AND 
		(service.certificatekind in ('A','B','C') 
		OR
		(service.certificatekind = 'D' AND 
		(SUBSTRING(expense.idexp,1,8*@phase_accounting) NOT IN 
		(SELECT idexp FROM expenseitineration)
		OR SUBSTRING(expense.idexp,1,8*@phase_accounting) IN 
		(SELECT m1.idexp FROM expenseitineration m1
		 WHERE m1.movkind = 'SALDO' OR (m1.movkind = 'ANPAG' AND 
			EXISTS (SELECT * FROM expenseitineration m2
			JOIN expenseyear
				ON expenseyear.idexp = m2.idexp
				AND expenseyear.ayear = @ayear
			WHERE m2.movkind = 'SALDO'
				AND m1.yitineration = m2.yitineration
				AND m1.nitineration = m2.nitineration))))
			)
			)

	UPDATE #certificazioni_fiscali
	SET employtaxamount =
		(SELECT ISNULL(SUM(ISNULL(expensetax.employtax,0)),0)
		FROM    expensetax
		JOIN    expense 	
			ON expense.idexp = expensetax.idexp
		WHERE 
			(expensetax.idexp = #certificazioni_fiscali.idexp) AND
			(EXISTS (SELECT * 
		  	         FROM expensetax D 
          		         JOIN tax t
	  			   ON t.taxcode= D.taxcode 
	  		        WHERE t.taxkind='F' and D.idexp = expense.idexp)
			))
	UPDATE #certificazioni_fiscali
	SET curramount = curramount -
	ISNULL((SELECT SUM(amount) 
		FROM expensevar 
		WHERE idexp = #certificazioni_fiscali.idexp 
		AND   autokind <>'RITEN'), 0.0)
	
	UPDATE #certificazioni_fiscali
	SET curramount = curramount +
	ISNULL((SELECT  SUM(PO.amount)
		  FROM  pettycashoperation PO
		  JOIN  pettycashoperationcasualcontract PCC
		    ON  PO.idpettycash = PCC.idpettycash
		   AND  PO.yoperation  = PCC.yoperation
		   AND  PO.noperation  = PCC.noperation
		 WHERE EXISTS ( SELECT * FROM
		     expensecasualcontract EP
		    WHERE  EP.ycon = PCC.ycon
		   AND  EP.ncon = PCC.ncon 
		   AND  #certificazioni_fiscali.idexp like  EP.idexp + '%')
		   AND  PO.adate BETWEEN @start AND @stop
		), 0.0)
	
	UPDATE #certificazioni_fiscali
	SET curramount = curramount +
	ISNULL((SELECT SUM(PO.amount) 
		FROM   pettycashoperation PO
		JOIN   pettycashoperationprofservice PPS
		  ON   PO.idpettycash = PPS.idpettycash
		 AND   PO.yoperation  = PPS.yoperation
		 AND   PO.noperation  = PPS.noperation
		 WHERE EXISTS ( SELECT * FROM
		     expenseprofservice EP
		   WHERE  EP.ycon = PPS.ycon
		   AND  EP.ncon = PPS.ncon 
		   AND  #certificazioni_fiscali.idexp like  EP.idexp + '%')
		   AND  PO.adate BETWEEN @start AND @stop
		), 0.0)
	
	UPDATE #certificazioni_fiscali
	SET curramount = curramount +
	ISNULL((SELECT SUM(PO.amount) 
		FROM   pettycashoperation PO
		JOIN pettycashoperationitineration PIT
			ON  PO.idpettycash = PIT.idpettycash
			AND PO.yoperation  = PIT.yoperation
			AND PO.noperation  = PIT.noperation
		WHERE  EXISTS (SELECT * 
				 FROM expenseitineration EI
				WHERE EI.yitineration  = PIT.yitineration
				  AND EI.nitineration  = PIT.nitineration
				  AND #certificazioni_fiscali.idexp like  EI.idexp  + '%')
		AND    PO.adate BETWEEN @start AND @stop
		AND 	(PIT.movkind IN ('ANPAG'))), 0.0)

	UPDATE #certificazioni_fiscali
	SET curramount = curramount -
	ISNULL((SELECT SUM(amount) 
		FROM expensevar 
		WHERE idexp = #certificazioni_fiscali.idexp 
		AND   autokind <>'RITEN'), 0.0)

	UPDATE #certificazioni_fiscali
	SET curramount = curramount -
	ISNULL((SELECT SUM(amount) 
		FROM expensevar 
		WHERE idexp = #certificazioni_fiscali.idexp 
		AND   autokind <>'RITEN'), 0.0)

	UPDATE #certificazioni_fiscali
	SET curramount = curramount -
	ISNULL((SELECT SUM(amount) 
		FROM expensevar 
		WHERE idexp = #certificazioni_fiscali.idexp 
		AND   autokind <>'RITEN'), 0.0)

	UPDATE #certificazioni_fiscali
	SET taxable = 
		(SELECT  ISNULL(MAX(expensetax.taxablegross),0)
		FROM expensetax
		JOIN tax 
			ON tax.taxcode = expensetax.taxcode
		JOIN expense 	
			ON expense.idexp = expensetax.idexp
		JOIN payment  
			ON payment.ypay = expense.ypay
			AND payment.npay = expense.npay
		JOIN paymenttransmission 
			ON paymenttransmission.ypaymenttransmission = payment.ypaymenttransmission
			AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission
		JOIN service 
			ON service.idser=expense.idser
		WHERE 
				(service.certificatekind = @certificationkind)AND
				(tax.taxkind='F') AND
				(expensetax.idexp=#certificazioni_fiscali.idexp) AND
				(paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	)
	UPDATE #certificazioni_fiscali
	SET fiscalretention = 
		(SELECT  ISNULL(SUM(expensetax.employtax),0)
		FROM expensetax
		JOIN tax 
			ON tax.taxcode = expensetax.taxcode
		JOIN expense 	
			ON expense.idexp = expensetax.idexp
		JOIN service 
			ON service.idser=expense.idser
		JOIN payment  
			ON payment.ypay = expense.ypay
			AND payment.npay = expense.npay
		JOIN paymenttransmission 
			ON paymenttransmission.ypaymenttransmission = payment.ypaymenttransmission
			AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission
		WHERE 
		(service.certificatekind = @certificationkind) AND
		(tax.taxkind='F') AND
		(expensetax.idexp=#certificazioni_fiscali.idexp) AND
		(paymenttransmission.transmissiondate BETWEEN @start AND @stop)
	)
	UPDATE #certificazioni_fiscali    SET otherretentions = employtaxamount - isnull(fiscalretention,0)
	
	SELECT
		idexp,
		npayment,
		datepayment,
		desc_expense 	as 'description',
		servicekind,
		curramount,
		taxable,
		fiscalretention,
		otherretentions,
		employtaxamount
		FROM #certificazioni_fiscali
		ORDER BY 
		datepayment, 
		npayment,
		idexp
	END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


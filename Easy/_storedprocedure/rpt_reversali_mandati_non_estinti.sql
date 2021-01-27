
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


if OBJECTPROPERTY(object_id('rpt_reversali_mandati_non_estinti'), 'IsProcedure') = 1
	drop procedure rpt_reversali_mandati_non_estinti
go



CREATE                                       PROCEDURE [rpt_reversali_mandati_non_estinti]
	@ayear					smallint,
	@movkind			char(1),
	@start         smalldatetime,
	@stop           smalldatetime 
AS
	BEGIN
		IF @movkind = 'C'
			BEGIN
				SELECT
					 income.ypro as 'ydoc',
					 income.npro as 'ndoc',
					 banktransaction.yban,
					 banktransaction.nban,
					 proceeds.adate,
					 proceeds.printdate,
					'ytransmission' = proceedstransmission.yproceedstransmission,
					'ntransmission' = proceedstransmission.nproceedstransmission,
					 proceedstransmission.transmissiondate,
					 registry.title,
					 incometotal .curramount,
					 banktransaction.amount,
					'notperformedamount' = ISNULL(incometotal .curramount, 0.0) 
								- ISNULL(banktransaction.amount, 0.0)
					FROM proceeds join proceedstransmission 
					ON proceedstransmission.yproceedstransmission = proceeds.yproceedstransmission
					AND proceedstransmission.nproceedstransmission = proceeds.nproceedstransmission
					JOIN registry on  registry.idreg = proceeds.idreg
					JOIN income 
					ON income.ypro=proceeds.ypro and income.npro=proceeds.npro
					JOIN incometotal  
					ON incometotal.idinc=income.idinc and incometotal.ayear=@ayear
					LEFT OUTER JOIN banktransaction on banktransaction.ypro=income.ypro AND banktransaction.npro=income.npro
					WHERE EXISTS (SELECT * FROM banktransaction x 
							WHERE x.ypro= income.ypro AND x.npro= income.npro AND x.kind = 'C'
							GROUP BY npro,ypro 
							HAVING isnull(sum(x.amount),0) <incometotal.curramount )
					OR NOT EXISTS (SELECT * FROM banktransaction y 
							WHERE  y.ypro= income.ypro AND y.npro= income.npro AND y.kind = 'C')
					AND proceedstransmission.transmissiondate  BETWEEN @start AND @stop


				END
		ELSE
			BEGIN
				SELECT
					 expense.ypay as 'ydoc',
					 expense.npay as 'ndoc',
					 banktransaction.yban,
					 banktransaction.nban,
					 payment.adate,
					 payment.printdate,
					'ytransmission' = paymenttransmission.ypaymenttransmission,
					'ntransmission' = paymenttransmission.npaymenttransmission,
					 paymenttransmission.transmissiondate,
					 registry.title,
					 expensetotal .curramount,
					 banktransaction.amount,
					'notperformedamount' = ISNULL(expensetotal .curramount, 0.0) 
								- ISNULL(banktransaction.amount, 0.0)
					FROM payment join paymenttransmission 
					ON paymenttransmission.ypaymenttransmission = payment.ypaymenttransmission
					AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission
					JOIN registry on  registry.idreg = payment.idreg
					JOIN expense 
					ON expense.ypay=payment.ypay and expense.npay=payment.npay
					JOIN expensetotal  
					ON expensetotal.idexp=expense.idexp and expensetotal.ayear=@ayear
					LEFT OUTER JOIN banktransaction on banktransaction.ypay=expense.ypay AND banktransaction.npay=expense.npay
					WHERE EXISTS (SELECT * FROM banktransaction x 
							WHERE x.ypay= expense.ypay AND x.npay= expense.npay AND x.kind = 'C'
							GROUP BY npay,ypay 
							HAVING isnull(sum(x.amount),0) <expensetotal.curramount )
					OR NOT EXISTS (SELECT * FROM banktransaction y 
							WHERE  y.ypay= expense.ypay AND y.npay= expense.npay AND y.kind = 'C')
							AND paymenttransmission.transmissiondate  BETWEEN @start AND @stop

			END
	END




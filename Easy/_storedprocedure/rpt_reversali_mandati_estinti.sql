
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


if OBJECTPROPERTY(object_id('rpt_reversali_mandati_estinti'), 'IsProcedure') = 1
	drop procedure rpt_reversali_mandati_estinti
go



CREATE  PROCEDURE [rpt_reversali_mandati_estinti]
	@ayear					smallint,
	@movkind			char(1),
  	@start         smalldatetime,
  	@stop           smalldatetime 
AS
	BEGIN
		IF @movkind = 'C'
			BEGIN
				SELECT
					banktransaction.ypro as 'ydoc',
					banktransaction.npro as 'ndoc',
					banktransaction.yban,
					banktransaction.nban,
					proceeds.adate,
					proceeds.printdate,
					'ytransmission' = proceedstransmission.yproceedstransmission,
					'ntransmission' = proceedstransmission.nproceedstransmission,
					proceedstransmission.transmissiondate,
					registry.title,
					banktransaction.amount
					FROM banktransaction
					JOIN proceeds
					ON proceeds.ypro = banktransaction.ypro
					AND proceeds.npro = banktransaction.npro
					JOIN proceedstransmission
					ON proceedstransmission.yproceedstransmission = proceeds.yproceedstransmission
					AND proceedstransmission.nproceedstransmission = proceeds.nproceedstransmission
					join income 
					on income.ypro=proceeds.ypro and income.npro=proceeds.npro
					join incometotal  
					on incometotal.idinc=income.idinc 
					left outer JOIN registry
					ON registry.idreg = proceeds.idreg
					WHERE banktransaction.kind = 'C'
					and incometotal.ayear=@ayear
					AND banktransaction.amount = --incometotal.curramount
									( select sum(curramount) from incometotal t
									join income i on t.idinc=i.idinc
									where t.ayear = @ayear
									and i.ypro=proceeds.ypro and i.npro=proceeds.npro
									)
				        AND banktransaction.transactiondate  BETWEEN @start AND @stop
					group by banktransaction.ypro,banktransaction.npro,banktransaction.yban,banktransaction.nban,
					proceeds.adate,proceeds.printdate,proceedstransmission.yproceedstransmission,
					proceedstransmission.nproceedstransmission,proceedstransmission.transmissiondate,
					registry.title,	banktransaction.amount
					ORDER BY banktransaction.ypro, 
					banktransaction.npro
				END
		ELSE
			BEGIN
				SELECT
					banktransaction.ypay as 'ydoc',
					banktransaction.npay as 'ndoc',
					banktransaction.yban,
					banktransaction.nban,
					payment.adate,
					payment.printdate,
					'ytransmission' = paymenttransmission.ypaymenttransmission,
					'ntransmission' = paymenttransmission.npaymenttransmission,
					paymenttransmission.transmissiondate,
					registry.title,
					banktransaction.amount
					FROM banktransaction
					JOIN payment
					ON payment.ypay = banktransaction.ypay
					AND payment.npay = banktransaction.npay
					JOIN paymenttransmission
					ON paymenttransmission.ypaymenttransmission = payment.ypaymenttransmission
					AND paymenttransmission.npaymenttransmission = payment.npaymenttransmission
					join expense 
					on expense.ypay=payment.ypay and expense.npay=payment.npay
					join expensetotal  
					on expensetotal.idexp=expense.idexp 
					left outer JOIN registry
					ON payment.idreg = registry.idreg  
					WHERE banktransaction.kind = 'D'
					and expensetotal.ayear=@ayear
					AND banktransaction.amount =-- expensetotal.curramount
								( select sum(curramount) from expensetotal t
									join expense e on t.idexp=e.idexp
									where t.ayear = @ayear
									and e.ypay=payment.ypay and e.npay=payment.npay
									)
	          			AND banktransaction.transactiondate BETWEEN @start AND @stop
					group by banktransaction.ypay ,	banktransaction.npay ,
					banktransaction.yban,banktransaction.nban,
					payment.adate,payment.printdate,paymenttransmission.ypaymenttransmission,
					paymenttransmission.npaymenttransmission,
					paymenttransmission.transmissiondate,registry.title,banktransaction.amount
					ORDER BY banktransaction.ypay, 
					banktransaction.npay
			END
	END



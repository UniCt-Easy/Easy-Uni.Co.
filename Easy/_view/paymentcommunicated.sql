
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


-- CREAZIONE VISTA paymentcommunicated
IF EXISTS(select * from sysobjects where id = object_id(N'[paymentcommunicated]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paymentcommunicated]
GO
 
CREATE   VIEW [paymentcommunicated]
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	kpaymenttransmission,
	ypaymenttransmission,
	npaymenttransmission,
	doc,
	docdate,
	description,
	amount,
	curramount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	refexternaldoc,
	paymentdescr,
	biccode,
    extracode,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	idchargehandling,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	printdate,
	competencydate,
	cu,
	ct,
	lu,
	lt,idfin,idupb
)
AS
SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
	paymenttransmission.npaymenttransmission,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expensetotal.curramount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.biccode,
	expenselast.extracode,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expenselast.idchargehandling,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	payment.printdate,
	paymenttransmission.transmissiondate,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expenseyear.idfin,expenseyear.idupb
FROM expense 
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment 
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expense.ymov = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idexp

	

GO


 


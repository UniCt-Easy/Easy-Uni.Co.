
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


-- CREAZIONE VISTA paymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[paymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [paymentview]
GO
--setuser 'amministrazione'
--clear_table_info 'paymentview'
-- Inserire la ALTER  VIEW qui--
CREATE                              VIEW [paymentview]
	(
	kpay,
	ypay,
	npay,
	npay_treasurer,
	idstamphandling,
	stamphandling,
	idtreasurer,
	codetreasurer,
	flag,
	kind,
	idreg,
	registry,
	idfin,
	codefin,
	finance,
	idman,
	manager,
	kpaymenttransmission,
  	ypaymenttransmission,
  	npaymenttransmission,
  	transmissiondate,
	adate,
	printdate,
	annulmentdate,
	cu,
	ct,
	lu,
	lt,
	total,
	net,
	performed,
	notperformed,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	external_reference,
	streamdate
	)
	AS SELECT
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.npay_treasurer,
	payment.idstamphandling,
	stamphandling.description,
	payment.idtreasurer,
	treasurer.codetreasurer,
	payment.flag,
	CASE
		WHEN ((payment.flag&1)<> 0) THEN 'C'
		WHEN ((payment.flag&2)<> 0) THEN 'R'
		WHEN ((payment.flag&4)<> 0) THEN 'M'
	END, 
	payment.idreg,
	registry.title,
	payment.idfin,
	fin.codefin,
	fin.title,
	payment.idman,
	manager.title,
	payment.kpaymenttransmission,
  	paymenttransmission.ypaymenttransmission,
  	paymenttransmission.npaymenttransmission,
  	paymenttransmission.transmissiondate,
	payment.adate,
	payment.printdate,
	payment.annulmentdate,
	payment.cu,
	payment.ct,
	payment.lu,
	payment.lt,
	(SELECT SUM(curramount) from expenselast EL
			join expensetotal I ON EL.idexp = I.idexp 
			--join expense S  	on I.idexp=S.idexp AND      I.ayear = payment.ypay			
	 WHERE  EL.kpay=payment.kpay ),
	(SELECT SUM(curramount) from expensetotal I with (nolock)
				--join expense S with (nolock) on I.idexp=S.idexp 
		JOIN expenselast EL with (nolock) ON EL.idexp = I.idexp
	 WHERE  EL.kpay=payment.kpay AND 
	        I.ayear = payment.ypay)-
	isnull( (SELECT sum(IIT.curramount) from expenselast EL with (nolock)
				join expense E with (nolock) on E.idexp =  EL.idexp				
				join income II with (nolock) on EL.idexp=II.idpayment and 
						((II.autokind=4 and II.idreg = E.idreg ) or II.autokind in (6,7,14,20,21,30,31)) 
				join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=payment.ypay	
				join incomelast IL with (nolock) on IL.idinc=II.idinc 
		WHERE EL.kpay  = payment.kpay 
		  
         ),0),
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.kpay=payment.kpay),0),
	(SELECT SUM(curramount) from expensetotal I join expense S on I.idexp=S.idexp 
		JOIN expenselast EL ON EL.idexp = S.idexp
	  WHERE EL.kpay=payment.kpay AND I.ayear = payment.ypay)
	  -ISNULL( (SELECT SUM(amount) from banktransaction P where
		P.kpay=payment.kpay),0),
	COALESCE(payment.idsor01,treasurer.idsor01) ,COALESCE(payment.idsor02,treasurer.idsor02),COALESCE(payment.idsor03,treasurer.idsor03),
	COALESCE(payment.idsor04,treasurer.idsor04),COALESCE(payment.idsor05,treasurer.idsor05),
	payment.external_reference,
	paymenttransmission.streamdate
	FROM payment  with (nolock)			
	LEFT OUTER JOIN registry  with (nolock)	ON registry.idreg = payment.idreg	
	LEFT OUTER JOIN fin  with (nolock)	ON fin.idfin = payment.idfin  		
	LEFT OUTER JOIN manager with (nolock)	ON manager.idman = payment.idman	
	LEFT OUTER JOIN stamphandling with (nolock)	ON stamphandling.idstamphandling = payment.idstamphandling	
	LEFT OUTER JOIN paymenttransmission with (nolock)	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission	
	LEFT OUTER JOIN treasurer with (nolock)	ON treasurer.idtreasurer = payment.idtreasurer

GO

 

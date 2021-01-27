
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_paymentperformed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_paymentperformed]
GO

CREATE    PROCEDURE [exp_paymentperformed]
	@ydoc		int,
	@idfin		int,	
	@idupb		varchar(36),
	@start      smalldatetime,
  	@stop       smalldatetime ,
	@tipo_data  char(1)

AS
/* Gianni 17-11-2014 per UNISOB */
BEGIN


CREATE TABLE #performed
(
	ydoc int, 	--Anno mandato
	ndoc int,	-- N. mandato
	stamphandling varchar(50),
	registry varchar(100),
	codefin	varchar(50),
	fin varchar(150),
	manager varchar(150),
	ytransmission int, 	
	ntransmission int,	
	transmissiondate smalldatetime,	
	adate smalldatetime,	
	printdate smalldatetime, 	
	annulmentdate smalldatetime,	
	transactiondate smalldatetime, 
	total decimal(19,2),
	performed decimal(19,2),
	notperformed decimal(19,2),
	yban int,
	nban int,
	banktransaction decimal(19,2),
	communicatedperformed decimal(19,2),
	communicatednotperformed decimal(19,2),
	notcommunicated decimal(19,2),
	idfin		int,	
	idupb		varchar(36)
)

if @tipo_data = 'T'
BEGIN 
 INSERT INTO #performed
	(
		yban,
		nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,
		banktransaction,
		idfin,	
		idupb
	)
	
		SELECT
			banktransaction.yban,
			banktransaction.nban,
			payment.ypay, 
			payment.npay,
			stamphandling.description ,
			registry.title , 
			fin.codefin,
			fin.title,
			manager.title,
			paymenttransmission.ypaymenttransmission, 
			paymenttransmission.npaymenttransmission,
			paymenttransmission.transmissiondate,
			payment.adate,
			payment.printdate, 
			payment.annulmentdate,
			banktransaction.transactiondate,
			banktransaction.amount,
			expenseyear.idfin,
			expenseyear.idupb
		FROM payment 
		LEFT OUTER JOIN registry 
			ON registry.idreg = payment.idreg
		LEFT OUTER JOIN fin 
			ON fin.idfin = payment.idfin 
		LEFT OUTER JOIN manager 
			ON manager.idman = payment.idman
		LEFT OUTER JOIN stamphandling 
			ON stamphandling.idstamphandling = payment.idstamphandling
		LEFT OUTER JOIN paymenttransmission
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		LEFT OUTER JOIN banktransaction
			ON banktransaction.kpay = payment.kpay		
		LEFT OUTER JOIN expenselast on 
		banktransaction.kpay= expenselast.kpay
		LEFT OUTER JOIN expenseyear on
		expenseyear.idexp = expenselast.idexp
		WHERE payment.ypay = @ydoc and transmissiondate BETWEEN @start AND @stop
		AND banktransaction.transactiondate is not null
		AND (@idupb is null OR expenseyear.idupb=@idupb)
		AND (@idfin is null OR expenseyear.idfin=@idfin)
		ORDER BY payment.ypay,payment.npay, banktransaction.idpay
 END
 ELSE
 BEGIN
	INSERT INTO #performed
	(
		yban,
		nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,
		banktransaction,
		idfin,	
		idupb
	)
	SELECT
			banktransaction.yban,
			banktransaction.nban,
			payment.ypay, 
			payment.npay,
			stamphandling.description ,
			registry.title , 
			fin.codefin,
			fin.title,
			manager.title,
			paymenttransmission.ypaymenttransmission, 
			paymenttransmission.npaymenttransmission,
			paymenttransmission.transmissiondate,
			payment.adate,
			payment.printdate, 
			payment.annulmentdate,
			banktransaction.transactiondate,
			banktransaction.amount,
			expenseyear.idfin,
			expenseyear.idupb
		FROM payment 
		LEFT OUTER JOIN registry 
			ON registry.idreg = payment.idreg
		LEFT OUTER JOIN fin 
			ON fin.idfin = payment.idfin 
		LEFT OUTER JOIN manager 
			ON manager.idman = payment.idman
		LEFT OUTER JOIN stamphandling 
			ON stamphandling.idstamphandling = payment.idstamphandling
		LEFT OUTER JOIN paymenttransmission
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		LEFT OUTER JOIN banktransaction
			ON banktransaction.kpay = payment.kpay		
		LEFT OUTER JOIN expenselast on 
		banktransaction.kpay= expenselast.kpay
		LEFT OUTER JOIN expenseyear on
		expenseyear.idexp = expenselast.idexp
		WHERE payment.ypay = @ydoc --and transmissiondate <= @stop
		AND banktransaction.transactiondate BETWEEN @start AND @stop
		AND (@idupb is null OR expenseyear.idupb=@idupb)
		AND (@idfin is null OR expenseyear.idfin=@idfin)
		ORDER BY payment.ypay,payment.npay, banktransaction.idpay
	END

SELECT 
		ydoc [Es. Mandato],	
		ndoc [N. Mandato],
		registry [Anagrafica],
		printdate [Data di stampa],
		ntransmission [Distinta],
		transmissiondate [Data Trasmissione],
		transactiondate [Data di esitazione],
		ISNULL(banktransaction,0) 		[Esitato] --'banktransaction',
FROM #performed
	

END



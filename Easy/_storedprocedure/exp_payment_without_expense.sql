
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_without_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_without_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [exp_payment_without_expense]
@ayear smallint,
@date smalldatetime

AS BEGIN
--	mov. bancari a debito non collegati a mandati o collegati a mandati  trasmessi dopo la data
SELECT  			
	PD.yban as 'Esercizio Transazione', 
	PD.nban as 'Numero Transazione' ,
	P.ypay as 'Esercizio del Mandato' ,       
	P.npay as 'Numero Mandato',                
	isnull( ET.curramount,0) as 'Importo',
	isnull(PD.amount,0) as 'Importo Esitato',
	PD.transactiondate as 'Data Operazione' 
FROM    banktransaction PD 
JOIN    payment P
	ON P.kpay = PD.kpay
JOIN expensetotal ET 
	ON ET.idexp = PD.idexp 
WHERE PD.transactiondate <= @date 
	AND ET.ayear=@ayear 
	AND kind = 'D'
	AND (pd.kpay is null 
		OR NOT EXISTS
			(SELECT *	--PT.transmissiondate 
			FROM paymenttransmission PT  
				
			WHERE PD.kpay = P.kpay 
			AND PT.kpaymenttransmission = P.kpaymenttransmission 
			AND PT.transmissiondate <=@date
			)
		)
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


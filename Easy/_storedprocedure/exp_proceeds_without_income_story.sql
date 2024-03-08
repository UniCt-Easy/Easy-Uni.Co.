
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_without_income_story]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_without_income_story]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [exp_proceeds_without_income_story]
@ayear smallint,
@date smalldatetime

AS BEGIN
--	mov. bancari a credito non collegati a reversali o collegati a reversali trasmesse dopo la data
SELECT 		
	PD.yban as 'Esercizio Transazione' ,
	PD.nban as 'Numero Transazione',
	P.ypro as 'Esercizio Reversale',       
	P.npro as 'Numero Reversale',                
	isnull( IY.amount,0) + 
		isnull((select sum(amount) from incomevar iv where iv.idinc = IY.idinc and iv.yvar = @ayear and iv.adate <=@date),0)
	as 'Importo',
	isnull(PD.amount,0) as 'Importo Esitato',
	PD.transactiondate as 'Data Operazione' 
FROM  banktransaction PD 
JOIN  proceeds P
	ON P.kpro = PD.kpro
JOIN incomeyear IY 
	ON IY.idinc = PD.idinc 
WHERE PD.transactiondate <= @date 
	AND IY.ayear=@ayear
	--AND ISNULL(PD.amount,0) = ISNULL( IT.curramount,0) 
	AND kind = 'C'
	AND (PD.kpro is null 
		OR NOT EXISTS
			(SELECT *	--PT.transmissiondate 
			FROM proceedstransmission PT  
			WHERE PD.kpro = P.kpro
			AND PT.kproceedstransmission = P.kproceedstransmission 
				AND PT.transmissiondate <=@date
			)
		)

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


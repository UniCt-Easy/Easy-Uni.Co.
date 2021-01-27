
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prev_performed_proceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prev_performed_proceeds]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                          PROCEDURE [exp_prev_performed_proceeds]
@date datetime,
@ayear int 
AS 
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
DECLARE @DEC_31_ayearprevious datetime
SET @DEC_31_ayearprevious = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),(@ayear-1)), 105)
	
SELECT 
	P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	P.adate AS 'Data Reversale',
	SUM(IT.curramount) AS 'Importo totale',
	ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpro = IL.kpro
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) AS 'Importo esitato nell''esercizio corrente, alla data'
FROM incometotal IT 
JOIN income I 
	on IT.idinc = I.idinc
JOIN incomelast IL 
	on IL.idinc = I.idinc
JOIN proceeds P 	
	on P.kpro = IL.kpro
JOIN proceedstransmission PT
	ON PT.kproceedstransmission = P.kproceedstransmission
WHERE PT.transmissiondate <= @date
	AND P.ypro = (@ayear - 1)
GROUP BY P.ypro,P.npro,P.adate, IL.kpro 
HAVING ISNULL(SUM(IT.curramount),0)>0
	AND ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpro = IL.kpro
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) >0
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


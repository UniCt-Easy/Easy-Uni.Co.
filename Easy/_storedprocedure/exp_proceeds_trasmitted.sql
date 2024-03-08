
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_trasmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_trasmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_proceeds_trasmitted {ts '2023-12-19 00:00:00'},2023


CREATE  PROCEDURE [exp_proceeds_trasmitted]
@date smalldatetime,
@ayear smallint
AS BEGIN

/* Versione 1.0.0 del 14/09/2007 ultima modifica: PIERO */

SELECT
	P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	p.adate AS 'Data Reversale',
	SUM(it.curramount) AS 'Importo Totale',
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction b
		WHERE b.kpro = il.kpro
			AND b.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(it.curramount) - 
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction b
		WHERE b.kpro = il.kpro
			AND b.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato',
	t.description as 'Cassiere'
	FROM incometotal it 
	JOIN income i 
		ON it.idinc=i.idinc
	JOIN incomelast il 
		ON il.idinc = i.idinc
	JOIN proceeds p 
		ON p.kpro = il.kpro
	JOIN proceedstransmission pt
		ON pt.kproceedstransmission = p.kproceedstransmission
	left join treasurer t on t.idtreasurer = p.idtreasurer
	WHERE p.ypro = @ayear
		AND pt.transmissiondate <= @date
	group by P.ypro, P.npro, p.adate, il.kpro, t.description
	HAVING ISNULL(SUM(it.curramount),0)>0 
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


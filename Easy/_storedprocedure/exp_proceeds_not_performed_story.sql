/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_not_performed_story]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_not_performed_story]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_proceeds_not_performed_story {d '2022-09-30'},2022


CREATE PROCEDURE [exp_proceeds_not_performed_story]
@date datetime,
@ayear int
AS 
BEGIN
SELECT  P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	P.adate AS 'Data Reversale',
	I.nmov AS 'Num.Movimento',
	I.description AS Descrizione,
	r.title AS Versante,
	(SUM(iy.amount) 
	+ isnull((select sum(iv2.amount) from incomevar iv2 
			JOIN incomelast il2
				ON il2.idinc = iv2.idinc
			join income i2 on il2.idinc = i2.idinc
			where iv2.idinc = il2.idinc 
					and il2.kpro = il.kpro
					and i2.nmov = i.nmov
					and iv2.yvar = @ayear and iv2.adate <=@date),0)
	- 
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction b
		WHERE b.kpro = il.kpro
			AND b.transactiondate <= @date)
	,0)) AS Importo,
	t.description as 'Conto Corrente'
FROM incomeyear iy 
JOIN income i 
		ON iy.idinc=i.idinc
JOIN incomelast il 
		ON il.idinc = i.idinc
JOIN proceeds P
	ON il.kpro = P.kpro
JOIN proceedstransmission pt
	ON pt.kproceedstransmission = p.kproceedstransmission
left join treasurer t on t.idtreasurer = P.idtreasurer
LEFT JOIN registry r ON r.idreg = i.idreg
WHERE (iy.ayear IS NULL OR p.ypro=@ayear)
	AND pt.transmissiondate <= @date
	AND
		ISNULL((SELECT SUM(amount)from banktransaction PD
		where PD.kpro=P.kpro and 
		PD.transactiondate <= @date),0) =0
group by P.ypro, P.npro, p.adate, il.kpro, i.nmov, i.description, r.title, t.description
ORDER BY P.ypro,P.npro,I.nmov
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


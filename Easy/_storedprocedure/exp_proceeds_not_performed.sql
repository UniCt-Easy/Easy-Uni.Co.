
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_not_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_not_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_proceeds_not_performed {ts '2023-12-19 00:00:00'},2023


CREATE                               PROCEDURE [exp_proceeds_not_performed]
@date datetime,
@ayear int
AS 
BEGIN
SELECT  P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	P.adate AS 'Data Reversale',
	I.nmov AS 'Num.Movimento',
	I.description AS Descrizione,
	I.registry AS Versante,
	I.curramount AS Importo,
	t.description as 'Cassiere'
FROM incomeview I
JOIN proceeds P
	ON I.ypro = P.ypro
	AND I.npro = P.npro
JOIN proceedstransmission pt
	ON pt.kproceedstransmission = p.kproceedstransmission
left join treasurer t on t.idtreasurer = P.idtreasurer
WHERE (I.ayear IS NULL OR p.ypro=@ayear)
	AND pt.transmissiondate <= @date
	AND
		ISNULL((SELECT SUM(amount)from banktransaction PD
		where PD.kpro=P.kpro and 
		PD.transactiondate <= @date),0) =0
ORDER BY P.ypro,P.npro,I.nmov
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


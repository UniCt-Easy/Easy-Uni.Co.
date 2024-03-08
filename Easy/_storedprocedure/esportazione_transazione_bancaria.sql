
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esportazione_transazione_bancaria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esportazione_transazione_bancaria]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--esportazione_transazione_bancaria 2007 ,'D'

CREATE        PROCEDURE [esportazione_transazione_bancaria]
@year smallint,
@kind char


AS BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
IF @kind='C'  --Movimenti a credito


SELECT  a.nban as 'Progressivo' ,
	a.transactiondate as 'Data transazione',
	a.valuedate as 'Data Valuta',
	p.npro as 'Numero Reversale',
	p.ypro as 'Esercizio Reversale',
	--r.title 'Creditore',
	a.amount 'Importo Esitato'
FROM banktransaction a           
JOIN proceeds p
	on a.kpro = p.kpro
LEFT OUTER JOIN incomelast b
	on a.idpro = b.idpro 
	and b.kpro = p.kpro
LEFT OUTER JOIN income i 
	on a.idinc = i.idinc 
left outer join registry r
	on i.idreg = r.idreg
WHERE a.kind = @kind and p.ypro=@year
ELSE   --Movimenti a debito
SELECT  a.nban as 'Progressivo' ,
	a.transactiondate as 'Data transazione' ,
	a.valuedate as 'Data Valuta',
	p.npay as 'Numero Mandato' ,
	p.ypay as 'Esercizio Mandato' ,
	c.title 'Creditore', 	
	a.amount 'Importo Esitato'
FROM banktransaction a 
JOIN payment p
	on a.kpay = p.kpay
LEFT OUTER JOIN expenselast b 
	on a.idpay =b.idpay 
	and b.kpay = p.kpay
LEFT OUTER JOIN expense e
	on  e.idexp = b.idexp
LEFT OUTER join registry c 
	on e.idreg= c.idreg
WHERE a.kind=@kind and p.ypay=@year
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


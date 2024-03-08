
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contrattopassivo_non_pagato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contrattopassivo_non_pagato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
-- exp_contrattopassivo_non_pagato 2022
CREATE                PROCEDURE [exp_contrattopassivo_non_pagato]
(
	@ayear int,
	@idmankind varchar(20)=null
)

AS BEGIN

DECLARE @expenselevel INT
DECLARE @maxlevel INT

SELECT @expenselevel = expenseregphase FROM uniconfig
SELECT @maxlevel = MAX(nphase) FROM expensephase

DECLARE @yman int
DECLARE @nman int
--DECLARE @number decimal(19,2)
DECLARE @rownum int
DECLARE @ypay int
DECLARE @npay int


CREATE TABLE #mandate_detail 
( yman int, nman int, adate datetime, manager varchar (150), registry varchar(100), detaildescription varchar(150), npackage decimal(19,2), imponibile decimal(19,2), 
 taxrate decimal(19,2), discount varchar(11), total decimal(19,2) , ypay int, npay varchar(100), idmankind varchar(50), rownum int, idexp_pay int, 
ymov int, nmov int, yepexp int, nepexp int )


INSERT INTO #mandate_detail (idmankind, nman, yman, rownum, adate, detaildescription,manager, registry,npackage, imponibile, taxrate,
				discount,total,ymov,nmov, yepexp, nepexp )
SELECT distinct MD.idmankind, MD.nman, MD.yman,MD.rownum, M.adate,  MD.detaildescription, MG.title, RG.title, MD.npackage,
	MD.taxable,
	isnull(MD.taxrate * 100 , 0), 
	convert(varchar(10),isnull( MD.discount * 100, 0))+ '%', 
	ROUND(MD.taxable * MD.npackage * 
		  CONVERT(DECIMAL(19,6),M.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(MD.discount, 0.0))),2
		)+
	ROUND(MD.tax,2),
	EX.ymov,
	EX.nmov,
	EP.yepexp,
	EP.nepexp
	FROM mandatedetail MD
	JOIN mandate M					ON MD.idmankind= M.idmankind AND MD.nman = M.nman AND MD.yman = M.yman
	LEFT OUTER JOIN manager MG		ON M.idman = MG.idman
	LEFT OUTER JOIN  registry RG	ON ISNULL(M.idreg,MD.idreg) = RG.idreg 	
	LEFT OUTER JOIN expense EX			ON MD.idexp_taxable=EX.idexp
	LEFT OUTER JOIN epexp EP			ON MD.idepexp = EP.idepexp
WHERE MD.yman = @ayear	AND ( MD.idmankind=@idmankind or @idmankind is null)
AND MD.stop IS NULL  AND
		(  MD.idexp_taxable is null OR
			 NOT EXISTS (SELECT * FROM expenselink EL
						JOIN expenselast elast on elast.idexp=el.idchild 
						WHERE EL.idparent =  MD.idexp_taxable)
		)
	


SELECT mandatekind.description AS 'Tipo Contratto', yman AS 'Esercizio', nman AS 'N.ordine', rownum AS 'N.dettaglio', adate AS 'Data contabile',
	 manager AS 'Nome responsabile', registry AS 'Nome fornitore',detaildescription AS 'Descrizione detaglio', npackage AS 'Quantità', 
	imponibile AS 'Imponibile', taxrate AS 'Iva %', discount AS 'Sconto',total AS 'Totale', ymov AS 'Eserc. Impegno', nmov AS 'Num. Impegno',
	yepexp AS 'Eserc. Impegno di Budget', nepexp AS 'Num. Impegno di Budget'
FROM #mandate_detail 
JOIN mandatekind
	ON #mandate_detail.idmankind = mandatekind.idmankind

ORDER BY #mandate_detail.idmankind, #mandate_detail.yman, #mandate_detail.nman, #mandate_detail.rownum

END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



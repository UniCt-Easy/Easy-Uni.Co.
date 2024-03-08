
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contrattoattivo_non_incassato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contrattoattivo_non_incassato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser 'amministrazione'
-- exp_contrattoattivo_non_incassato 2022
CREATE                PROCEDURE [exp_contrattoattivo_non_incassato]
(
	@ayear int,
	@idestimkind varchar(20)=null
)

AS BEGIN


CREATE TABLE #estimate_detail 
( yestim int, nestim int, adate datetime, manager varchar (150), registry varchar(100), detaildescription varchar(150), number decimal(19,2), imponibile decimal(19,2), 
 taxrate decimal(19,2), discount varchar(11), total decimal(19,2) , ypay int, npay varchar(100), idestimkind varchar(50), rownum int, 
ymov int, nmov int, yepacc int, nepacc int)


INSERT INTO #estimate_detail (idestimkind, nestim, yestim, rownum, adate, detaildescription,manager, registry,number, imponibile, taxrate,
				discount,total,ymov,nmov, yepacc, nepacc)
SELECT distinct ED.idestimkind, ED.nestim, ED.yestim, ED.rownum, E.adate, ED.detaildescription, MG.title, RG.title, ED.number,
	ED.taxable,
	isnull(ED.taxrate * 100, 0),
	convert(varchar(10),isnull(ED.discount * 100, 0))+ '%',
	ROUND(ED.taxable * ED.number * 
		  CONVERT(DECIMAL(19,6),E.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(ED.discount, 0.0))),2
		)+
	ROUND(ED.tax,2),
	I.ymov,
	I.nmov,
	EP.yepacc,
	EP.nepacc
	FROM estimatedetail ED
	JOIN estimate E					ON ED.idestimkind = E.idestimkind AND ED.nestim = E.nestim AND ED.yestim = E.yestim
	LEFT OUTER JOIN manager MG		ON E.idman = MG.idman
	LEFT OUTER JOIN	registry RG		ON ISNULL(E.idreg, ED.idreg) = RG.idreg
	LEFT OUTER JOIN income I		ON ED.idinc_taxable = I.idinc
	LEFT OUTER JOIN epacc EP		ON ED.idepacc = EP.idepacc
WHERE ED.yestim = @ayear AND (ED.idestimkind = @idestimkind or @idestimkind is null)
AND ED.stop IS NULL AND
		(ED.idinc_taxable is null OR
			NOT EXISTS (SELECT * FROM incomelink IL
						JOIN incomelast ilast on ilast.idinc = IL.idchild
						WHERE IL.idparent = ED.idinc_taxable)
		)


SELECT estimatekind.description AS 'Tipo Contratto', yestim AS 'Esercizio', nestim AS 'N. Contratto', rownum AS 'N.dettaglio', adate AS 'Data contabile',
	 manager AS 'Nome responsabile', registry AS 'Nome Cliente',detaildescription AS 'Descrizione dettaglio', number AS 'Quantità', 
	imponibile AS 'Imponibile', taxrate AS 'Iva %', discount AS 'Sconto',total AS 'Totale', ymov AS 'Eserc. Accertamento', nmov AS 'Num. Accertamento',
	yepacc AS 'Eserc. Accertamento di Budget', nepacc AS 'Num. Accertamento di Budget'
FROM #estimate_detail 
JOIN estimatekind
	ON #estimate_detail.idestimkind = estimatekind.idestimkind

ORDER BY #estimate_detail.idestimkind, #estimate_detail.yestim, #estimate_detail.nestim, #estimate_detail.rownum

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

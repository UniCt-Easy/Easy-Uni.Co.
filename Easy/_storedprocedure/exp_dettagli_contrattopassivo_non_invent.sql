
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_dettagli_contrattopassivo_non_invent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_dettagli_contrattopassivo_non_invent]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [exp_dettagli_contrattopassivo_non_invent]
(
	@ayear int,
	@idmankind varchar(20)
)

AS BEGIN
-- [exp_dettagli_contrattopassivo_non_invent] 2017, null
DECLARE @expenselevel INT
DECLARE @maxlevel INT

SELECT @expenselevel = expenseregphase FROM uniconfig
SELECT @maxlevel = MAX(nphase) FROM expensephase

DECLARE @idmankind_detail varchar(50)
DECLARE @yman int
DECLARE @nman int
DECLARE @npackage decimal(19,2)
DECLARE @idgroup int
DECLARE @idexp_taxable int
DECLARE @ypay int
DECLARE @npay int

--sp_help mandatedetailview

CREATE TABLE #mandate_detail 
( idmankind varchar(50), mandatekind varchar(150), yman int, nman int, adate datetime, manager varchar (150), registry varchar(100),
  detaildescription varchar(150), npackage decimal(19,2), imponibile decimal(19,2), 
  taxrate decimal(19,2), discount varchar(20), total decimal(19,2) , ypay int, npay varchar(1000), idgroup int, idexp_taxable int , assetkind char(1))

	INSERT INTO #mandate_detail (idmankind, mandatekind,yman, nman, adate, manager, registry, detaildescription, npackage, imponibile, 
					taxrate, discount, total,  idgroup,idexp_taxable,assetkind)
	SELECT   MK.idmankind, MK.description, MD.yman, MD.nman, M.adate, MG.title, RG.title, MD.detaildescription, MD.npackage, SUM(MD.taxable),
		isnull(MD.taxrate * 100 , 0), convert(varchar(10),isnull( MD.discount * 100, 0))+ '%', 
		sum(MD.taxable  * MD.npackage + MD.tax - (MD.taxable * MD.npackage * isnull(MD.discount,0))),
		MD.idgroup, MD.idexp_taxable, MD.assetkind
	FROM mandatedetail MD
	JOIN mandate M
		ON MD.idmankind= M.idmankind 
		AND MD.nman = M.nman
		AND MD.yman = M.yman
	JOIN mandatekind MK
		ON MK.idmankind = M.idmankind
	LEFT OUTER JOIN manager MG
		ON M.idman = MG.idman
	JOIN  registry RG
		ON MD.idreg = RG.idreg  

	WHERE MD.assetkind NOT IN ('A', 'P') --- INVENTARIABILE O AUMENTO DI VALORE 
	AND M.yman = @ayear AND ( M.idmankind = @idmankind OR @idmankind IS NULL)
	GROUP BY MK.idmankind, MK.description,MD.yman, MD.nman, MD.assetkind, MD.idgroup, MD.idreg, MD.npackage, 
	M.adate, MG.title, RG.title, MD.detaildescription, MD.taxrate, 
		MD.discount,idexp_taxable, MD.assetkind
 

DECLARE cursore CURSOR FORWARD_ONLY for 
SELECT #mandate_detail.idmankind, #mandate_detail.yman,#mandate_detail.nman, #mandate_detail.npackage, #mandate_detail.idgroup,#mandate_detail.idexp_taxable, P1.ypay, P1.npay
FROM #mandate_detail 
	JOIN mandatedetail MD 
		ON #mandate_detail.idmankind = MD.idmankind
		AND  #mandate_detail.yman = MD.yman
		AND #mandate_detail.nman = MD.nman
		AND #mandate_detail.idgroup = MD.idgroup
		AND #mandate_detail.idexp_taxable = MD.idexp_taxable
	LEFT OUTER JOIN expenselink ELK1
		ON ELK1.idparent = MD.idexp_taxable
	LEFT OUTER JOIN expenselink ELK2
		ON ELK2.idparent = ELK1.idchild
		AND ELK2.idchild = ELK2.idchild
		AND ELK2.nlevel=@maxlevel
	LEFT OUTER JOIN expenselast EL1
		ON ELK2.idparent = EL1.idexp
	LEFT OUTER JOIN payment P1
		ON EL1.kpay = P1.kpay
WHERE ELK1.nlevel = @expenselevel
AND ELK2.idchild is not null
GROUP BY #mandate_detail.idmankind,#mandate_detail.yman,#mandate_detail.nman, #mandate_detail.npackage, #mandate_detail.idgroup,#mandate_detail.idexp_taxable, P1.ypay, P1.npay

OPEN cursore
FETCH NEXT FROM cursore 
INTO 	@idmankind_detail, @yman,@nman, @npackage, @idgroup,@idexp_taxable, @ypay, @npay

WHILE (@@fetch_status=0) 
BEGIN
	UPDATE #mandate_detail SET
	npay = ISNULL(npay, '') + CONVERT (varchar(4),@ypay) + '/' + convert (varchar(10),@npay) + ', '
	WHERE #mandate_detail.idmankind = @idmankind_detail
	AND  #mandate_detail.yman = @yman
	AND #mandate_detail.nman = @nman
	AND #mandate_detail.idgroup = @idgroup
	AND #mandate_detail.idexp_taxable = @idexp_taxable 
	FETCH NEXT FROM cursore 
	INTO @idmankind_detail,@yman,@nman, @npackage, @idgroup,@idexp_taxable, @ypay, @npay
END
CLOSE cursore
DEALLOCATE cursore

-- Toglie la virgola finale

UPDATE #mandate_detail SET 
npay = substring (npay,1, len(npay)-1) 
WHERE npay IS NOT NULL


SELECT mandatekind as 'Tipo Contratto',yman AS 'Esercizio', nman AS 'N.ordine', idgroup as '#Dettaglio',case assetkind 
		when 'A' then 'Inventariabile'
		when 'P' then 'Aumento di valore'
		when 'S' then 'Servizi'
		when 'M' then 'Magazzino'
		else 'Altro'
	end 'Tipo bene', adate AS 'Data contabile', manager AS 'Nome responsabile', 
	registry AS 'Nome fornitore',detaildescription AS 'Descrizione dettaglio', npackage AS 'Quantità', 
	imponibile AS 'Imponibile', taxrate AS 'Iva %', discount AS 'Sconto',total AS 'Totale', npay AS 'Mandato' 
	
FROM #mandate_detail order by mandatekind, yman, nman

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


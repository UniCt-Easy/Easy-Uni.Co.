if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contrattopassivo_pagato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contrattopassivo_pagato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                PROCEDURE [exp_contrattopassivo_pagato]
(
	@ayear int,
	@idmankind varchar(20)
)

AS BEGIN
-- exec exp_contrattopassivo_pagato 2018, null
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
 taxrate decimal(19,2), discount varchar(11), total decimal(19,2) , ypay int, npay varchar(100), idmankind varchar(50), rownum int, idexp_pay int )



	INSERT INTO #mandate_detail (idmankind, nman, yman, rownum, adate, detaildescription,manager, registry,npackage, imponibile, taxrate,
					discount, total )
	SELECT distinct MD.idmankind, MD.nman, MD.yman,MD.rownum, M.adate,  MD.detaildescription, MG.title, RG.title, MD.npackage,
			MD.taxable,
		isnull(MD.taxrate * 100 , 0), 
		convert(varchar(10),isnull( MD.discount * 100, 0))+ '%', 
			ROUND(MD.taxable * MD.npackage * 
				CONVERT(DECIMAL(19,6),M.exchangerate) *
				(1 - CONVERT(DECIMAL(19,6),ISNULL(MD.discount, 0.0))),2
			)+
		ROUND(MD.tax,2)
		FROM mandatedetail MD
		JOIN mandate M
			ON MD.idmankind= M.idmankind 
			AND MD.nman = M.nman
			AND MD.yman = M.yman
		JOIN expensemandate EM
			ON MD.idmankind=EM.idmankind
			AND MD.nman=EM.nman
			AND MD.yman=EM.yman
			AND MD.idexp_taxable=EM.idexp
		LEFT OUTER JOIN manager MG
			ON M.idman = MG.idman
		LEFT OUTER JOIN  registry RG
			ON ISNULL(M.idreg,MD.idreg) = RG.idreg 
	WHERE MD.yman = @ayear
	AND ( EM.idmankind=@idmankind or @idmankind is null)
	AND MD.stop IS NULL





DECLARE cursore CURSOR FORWARD_ONLY for 
SELECT MD.idmankind, MD.nman, MD.yman,MD.rownum, P.ypay , P.npay 
	FROM mandatedetail MD
	JOIN expensemandate EM
		ON MD.idmankind=EM.idmankind
		AND MD.nman=EM.nman
		AND MD.yman=EM.yman
		AND MD.idexp_taxable=EM.idexp
	JOIN expenselink EL
		ON EL.idparent = EM.idexp
		AND nlevel = @expenselevel
	JOIN expenselink EL2
		ON EL2.idparent = EL.idchild
		AND EL2.nlevel = @maxlevel
	JOIN expenselast ET
		ON ET.idexp = EL.idchild
	JOIN payment P
		ON ET.kpay = P.kpay
WHERE MD.yman = @ayear
AND EM.idmankind=@idmankind
AND MD.stop IS NULL

OPEN cursore
FETCH NEXT FROM cursore 
INTO 	@idmankind, @nman, @yman,@rownum, @ypay , @npay 

WHILE (@@fetch_status=0) 
BEGIN
	UPDATE #mandate_detail SET
	npay = ISNULL(npay, '') + CONVERT (varchar(4),@ypay) + '/' + convert (varchar(10),@npay) + ', '
	WHERE #mandate_detail.idmankind = @idmankind
	AND  #mandate_detail.yman = @yman
	AND #mandate_detail.nman = @nman
	AND #mandate_detail.rownum = @rownum
	--AND #mandate_detail.idexp_taxable = @idexp_taxable 
	FETCH NEXT FROM cursore 
	INTO @idmankind, @nman, @yman,@rownum, @ypay , @npay 
END
CLOSE cursore
DEALLOCATE cursore

-- Toglie la virgola finale

UPDATE #mandate_detail SET 
npay = substring (npay,1, len(npay)-1) 
WHERE npay IS NOT NULL

SELECT mandatekind.description AS 'Tipo Contratto', yman AS 'Esercizio', nman AS 'N.ordine', rownum AS 'N.dettaglio', adate AS 'Data contabile',
	 manager AS 'Nome responsabile', registry AS 'Nome fornitore',detaildescription AS 'Descrizione detaglio', npackage AS 'Quantità', 
	imponibile AS 'Imponibile', taxrate AS 'Iva %', discount AS 'Sconto',total AS 'Totale', npay AS 'Mandato'
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
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_transazioni_sospesi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_transazioni_sospesi]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE 	PROCEDURE [rpt_transazioni_sospesi]
	@ybill int,
	@nbill int,
	@kind    char(1),
	@filterop char(1)    -- C --> Movimenti finanziari a copertura,  -- R --> Regolarizzazioni
AS

BEGIN
 
-- exec [rpt_transazioni_sospesi] 2014, 1, 'C', 'R'/'C'
-- sp_help expensephase

CREATE TABLE #partitependenti(
    ymov int,
    nmov int,
    description varchar(150),
    ydoc int,
    ndoc int,
    kpay int,
    idpay int,
    curramount decimal(19,2),
    docamount decimal(19,2),
    covered decimal(19,2),						-- Importo associato
    esitato_partite_pendenti decimal(19,2) 		-- Importo regolarizzato
)    

INSERT INTO #partitependenti
(
    ymov,
    nmov,
    description,
    ydoc,
    ndoc,
    kpay,
    idpay,
    curramount,
    docamount,
    covered,						-- Importo associato
    esitato_partite_pendenti		-- Importo regolarizzato 
)
SELECT
	expense.ymov,
	expense.nmov,
	expense.description,
	payment.ypay,
	payment.npay,
	payment.kpay,
    expenselast.idpay,
	expensetotal.curramount,
	null
FROM expenselast  (NOLOCK)		
JOIN expensetotal (NOLOCK)
  ON expensetotal.idexp = expenselast.idexp		 
JOIN expense (NOLOCK)
  ON expense.idexp = expenselast.idexp	
LEFT OUTER JOIN  payment
  ON payment.kpay = expenselast.idexp	
WHERE expenselast.nbill = @nbill
 AND  expensetotal.ayear= @ybill
 
INSERT INTO #partitependenti
(
    ymov,
    nmov,
    description,
    ydoc,
    ndoc,
    kpay,
    idpay,
    curramount,
    docamount,
    covered,						-- Importo associato
    esitato_partite_pendenti		-- Importo regolarizzato 
)
SELECT
	expense.ymov,
	expense.nmov,
	expense.description,
	payment.ypay,
	payment.npay,
	payment.kpay,
    expenselast.idpay,
	expensetotal.curramount
	null
FROM expenselast  (NOLOCK)		
JOIN expensetotal (NOLOCK)
  ON expensetotal.idexp = expenselast.idexp		 
JOIN expense (NOLOCK)
  ON expense.idexp = expenselast.idexp	
LEFT OUTER payment
  ON payment.kpay = expenselast.idexp	
WHERE expenselast.nbill = @nbill
 AND  expensetotal.ayear= @ybill
 
 
 INSERT INTO #partitependenti
(
    ymov,
    nmov,
    description,
    ydoc,
    ndoc,
    kpay,
    idpay,
    curramount,
    docamount,
    covered,						-- Importo associato
    esitato_partite_pendenti		-- Importo regolarizzato 
)
SELECT
	expense.ymov,
	expense.nmov,
	expense.description,
	payment.ypay,
	payment.npay,
	payment.kpay,
    expenselast.idpay,
	expensetotal.curramount
	null
 SELECT SUM(operation.amount)
			FROM pettycashoperation operation (NOLOCK)
			WHERE operation.yoperation = bill.ybill
				AND operation.nbill = bill.nbill
				AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = operation.yrestore
					AND restoreop.noperation = operation.nrestore
					AND restoreop.idpettycash = operation.idpettycash
					 
SELECT
    ymov,
    nmov,
    ydoc,
    ndoc,
    curramount,
    docamount,
    covered,						-- Importo associato
    esitato_partite_pendenti		-- Importo regolarizzato 
FROM #partitependenti

ORDER BY ymov,nmov

END

GO

SET QUOTED_IDENTIFIER OFF

GO

SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




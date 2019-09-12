if exists (select * from dbo.sysobjects where id = object_id(N'[exp_partitependenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_partitependenti]

 GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO

CREATE PROCEDURE [exp_partitependenti]

@ayear int,

@date datetime,

@kind    char(1),

@idtreasurer INT,

@historicizebillop char(1)

 AS

BEGIN

/* Modifica apportata da Gianni per aggiungere la colonna del Tesoriere  15-10-2014 */
--exec exp_partitependenti 2014, {d '2014-06-30'}, 'D', null, 'S'


CREATE TABLE #partitependenti(

    ybill smallint,

    nbill int,

    billkind varchar(10),
	motive		varchar(150),
	registry	varchar(150),

	tesoriere varchar(150),						-- Descrizione del Tesoriere associato alla partita pendente

    tot_partite_pendenti decimal(19,2),			-- Importo totale delle partite pendenti attive
    apertura_partite_pendenti decimal(19,2),    -- Importo apertura delle partite pendenti attive
    reduction_partite_pendenti decimal(19,2),   -- Importo riduzioni delle partite pendenti attive

    esitato_partite_pendenti decimal(19,2),		-- Importo regolarizzato

    partite_pendenti decimal(19,2)				-- Importo scoperto (da regolarizzare) => Importo totale visualizzato nella stampa

	
)    

-- PARTITE PENDENTI ATTIVE (importo non regolarizzato delle partite pendenti aperte per chi usa tale gestione)

-- = Importo TOTALE delle partite pendenti attive

-- - calcolo l'importo REGOLARIZZATO delle partite pendenti attive

IF (ISNULL(@historicizebillop,'N') = 'N')
	BEGIN

		INSERT INTO #partitependenti(ybill,nbill,billkind, motive,registry, tesoriere, tot_partite_pendenti)

		SELECT ybill,nbill,billkind, motive,registry, treasurer.description, isnull(total,0) - isnull(reduction,0) 

		FROM bill
		LEFT OUTER JOIN treasurer on bill.idtreasurer = treasurer.idtreasurer
		WHERE   bill.active = 'S' AND ybill = @ayear AND billkind = @kind AND adate <= @date
		AND (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
	END
 ELSE
 BEGIN
		INSERT INTO #partitependenti(ybill,nbill,billkind, motive,registry, tesoriere, tot_partite_pendenti)
		SELECT  bill.ybill,bill.nbill,bill.billkind, bill.motive, bill.registry, treasurer.description , bankimportbill.amount
		FROM    bill 
		LEFT OUTER JOIN  bankimportbill on bill.ybill=bankimportbill.ybill and 
					 bill.nbill=bankimportbill.nbill and 
					 bill.billkind=bankimportbill.billkind and
					 bankimportbill.ybill = bill.ybill  and
					 (bankimportbill.adate <= @date OR bankimportbill.adate is null)  
		LEFT OUTER JOIN  treasurer on bill.idtreasurer = treasurer.idtreasurer
		WHERE 
		bill.ybill = @ayear and bill.billkind = @kind 
		and bill.active='S'
		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
END
	


UPDATE #partitependenti SET apertura_partite_pendenti =

ISNULL((SELECT isnull(total,0) 

FROM bill

WHERE bill.ybill = @ayear

AND bill.billkind = @kind

AND active = 'S'

AND bill.adate <= @date

and bill.nbill = #partitependenti.nbill

AND (idtreasurer = @idtreasurer or @idtreasurer is null)    )

,0)


UPDATE #partitependenti SET reduction_partite_pendenti =

ISNULL((SELECT isnull(reduction,0) 

FROM bill

WHERE bill.ybill = @ayear

AND bill.billkind = @kind

AND active = 'S'

AND bill.adate <= @date

and bill.nbill = #partitependenti.nbill

AND (idtreasurer = @idtreasurer or @idtreasurer is null)    )

,0)

UPDATE #partitependenti SET esitato_partite_pendenti =

ISNULL((SELECT SUM(bt.amount)

FROM billtransaction bt

JOIN bill on bill.ybill=bt.ybilltran and

     bill.nbill=bt.nbill and

     bill.billkind=bt.kind

WHERE bt.ybilltran = @ayear
 AND  #partitependenti.billkind = bill.billkind
AND  #partitependenti.nbill =  bill.nbill 
AND  bill.billkind = @kind
AND  bt.adate <= @date OR bt.adate is null
AND active = 'S'
)

,0)
------------------------------------
--select * from #partitependenti
-------------------------------------
UPDATE #partitependenti SET partite_pendenti = isnull(tot_partite_pendenti,0) - isnull(esitato_partite_pendenti,0)

-- Rimuovo quelle bollette per cui l'importo stato tutto regolarizzato.

DELETE FROM #partitependenti WHERE partite_pendenti = 0

-- Inserisco la riga dei totali, per poter fare un confronto immediato ocn la stampa della concordanza.

INSERT INTO #partitependenti(

billkind ,

tot_partite_pendenti,    

esitato_partite_pendenti,    

partite_pendenti )

SELECT

'TOTALE',

SUM(tot_partite_pendenti) ,    

SUM(esitato_partite_pendenti) ,    

 SUM(partite_pendenti)

FROM #partitependenti

SELECT

billkind as 'Tipo',

ybill as 'Esercizio',

nbill as 'Numero',

motive as 'Descrizione',

registry as 'Anagrafica',

tesoriere as 'Tesoriere' ,

tot_partite_pendenti as 'Importo totale',

esitato_partite_pendenti as 'Importo regolarizzato',

partite_pendenti as 'Importo da regolarizzare'

   

FROM #partitependenti

ORDER BY billkind,nbill

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



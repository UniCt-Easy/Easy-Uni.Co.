
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sospesi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sospesi]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE 	PROCEDURE [rpt_sospesi]
	@ayear int,
	@date datetime,
	@kind    char(1),
	@idtreasurer INT,
	@historicizebillop char(1),
	@filterbill char(1)  -- R --> Da Regolarizzare, N --> Non Regolarizzate, 
						 -- P --> Parzialmente Regolarizzate, C --> Includi regolarizzate 
AS

BEGIN

--exec [rpt_sospesi] 2007, {d '2007-09-30'}, 'C', null, 'N','T'
 
CREATE TABLE #partitependenti(
    ybill smallint,
    nbill int,
    billkind varchar(10),
    adate datetime, 
    registry varchar(150),
    motive varchar(150),
    covered decimal(19,2),
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

		INSERT INTO #partitependenti(ybill,nbill,billkind, tot_partite_pendenti)

		SELECT ybill,nbill,billkind, isnull(total,0) - isnull(reduction,0)

		FROM bill

		WHERE   active = 'S' AND ybill = @ayear AND (billkind = @kind) AND adate <= @date
		AND (idtreasurer = @idtreasurer or @idtreasurer is null)
	END
 ELSE
 BEGIN
		INSERT INTO #partitependenti(ybill,nbill,billkind, tot_partite_pendenti)
		SELECT  bill.ybill,bill.nbill,bill.billkind, bankimportbill.amount
		FROM    bill 
		LEFT OUTER JOIN  bankimportbill on bill.ybill=bankimportbill.ybill and 
					 bill.nbill=bankimportbill.nbill and 
					 bill.billkind=bankimportbill.billkind and
					 bankimportbill.ybill = bill.ybill  and
					 (bankimportbill.adate <= @date OR bankimportbill.adate is null)  
		WHERE bill.ybill = @ayear AND (bill.billkind = @kind)
		and  bill.active = 'S' 
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

UPDATE #partitependenti SET covered = ISNULL ((SELECT isnull(covered,0) 

FROM billview

WHERE billview.ybill = @ayear

AND billview.billkind = @kind

AND active = 'S'

AND billview.adate <= @date

and billview.nbill = #partitependenti.nbill

AND (idtreasurer = @idtreasurer or @idtreasurer is null))
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

IF (@filterbill <> 'C')
BEGIN
	DELETE FROM #partitependenti WHERE partite_pendenti = 0
END


SELECT

billkind as 'Tipo',

ybill as 'Esercizio',

nbill as 'Numero',

covered as 'Importo movimenti finanziari associati al sospeso',

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




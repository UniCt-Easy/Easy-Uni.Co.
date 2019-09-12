if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilancio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE exp_bilancio 
AS BEGIN
  --		  tracciato_bilancio = new string[] {
  --          "nliv;Numero Livello Bilancio;Intero;1",
  --          "descrliv;Descrizione Livello Bilancio;Stringa;50",
  --          "codicebil;Codice Bilancio;Stringa;50",
  --          "ordinestampa;Ordine di stampa;Stringa;50",
  --          "partebil;Parte Bilancio (E/S);Codificato;1;E|S",
  --          "anno;Anno;intero;4",
  --          "codiceparentbil;Codice bilancio del nodo PARENT di questo;Stringa;50",
  --          "descrbil;Descrizione voce bilancio;Stringa;150",
  --          "resp;Responsabile;Stringa;150",
  --          "datascad;Data scadenza;Data;8"
  --      };
-- exp_bilancio        
-- usa la tabella lookup_bilancio

--create table lookup_bilancio
--(
--	cia_codefin varchar(50),
--	easy_codefin  varchar(50),
--	finpart char(1)
--)
--select * from conto_f_bilancio
-- exec exp_cia_bilancio
CREATE TABLE #tracciato_bilancio
(
 nliv			 int,			-- ;Numero Livello Bilancio;Intero;1",
 descrliv		 varchar(50),	-- ;Descrizione Livello Bilancio;Stringa;50",
 codicebil		 varchar(50),	-- ;Codice Bilancio;Stringa;50",
 ordinestampa	 varchar(50),	-- ;Ordine di stampa;Stringa;50",
 partebil		 char(1),		-- ;Parte Bilancio (E/S);Codificato;1;E|S",
 anno			 int,			-- ;Anno;intero;4",
 codiceparentbil varchar(50),	-- ;Codice bilancio del nodo PARENT di questo;Stringa;50",
 descrbil		 varchar(150),	-- ;Descrizione voce bilancio;Stringa;150",
 resp			 varchar(150),	-- ;Responsabile;Stringa;150",
 datascad		 datetime		-- ;Data scadenza;Data;8"
)


INSERT INTO #tracciato_bilancio
(
 nliv			 ,	-- ;Numero Livello Bilancio;Intero;1",
 descrliv	     ,	-- ;Descrizione Livello Bilancio;Stringa;50",
 codicebil		 ,	-- ;Codice Bilancio;Stringa;50",
 ordinestampa	 ,	-- ;Ordine di stampa;Stringa;50",
 partebil	     ,	-- ;Parte Bilancio (E/S);Codificato;1;E|S",
 anno			 ,	-- ;Anno;intero;4",
 codiceparentbil ,	-- ;Codice bilancio del nodo PARENT di questo;Stringa;50",
 descrbil		 ,	-- ;Descrizione voce bilancio;Stringa;150",
 resp			  	-- ;Responsabile;Stringa;150",
)
select
NUMERO_LIVELLO - 1, 
CASE
	WHEN NUMERO_LIVELLO - 1 = 1 THEN 'Titolo'
	WHEN NUMERO_LIVELLO - 1 = 2 THEN 'Categoria'
	WHEN NUMERO_LIVELLO - 1 = 3 THEN 'Capitolo'
	WHEN NUMERO_LIVELLO - 1 = 4 THEN 'Articolo'
	else ''
END,
lookup_bilancio.codefin,
lookup_bilancio.codefin,
lookup_bilancio.finpart,
conto_f.ESERCIZIO,
lookup_bilancio_padre.codefin as padre,
conto_f.NOME_CONTO,
null
from  CONTO_F  
LEFT OUTER JOIN   lookup_bilancio
ON  lookup_bilancio.CHIAVE_COMPLETA = CONTO_F.CHIAVE_COMPLETA
LEFT OUTER JOIN lookup_bilancio lookup_bilancio_padre 
ON  lookup_bilancio_padre.CHIAVE_COMPLETA = CONTO_F.CHIAVE_PADRE
order by ESERCIZIO, lookup_bilancio.CHIAVE_COMPLETA


INSERT INTO #tracciato_bilancio
(
 nliv			 ,	-- ;Numero Livello Bilancio;Intero;1",
 descrliv	     ,	-- ;Descrizione Livello Bilancio;Stringa;50",
 codicebil		 ,	-- ;Codice Bilancio;Stringa;50",
 ordinestampa	 ,	-- ;Ordine di stampa;Stringa;50",
 partebil	     ,	-- ;Parte Bilancio (E/S);Codificato;1;E|S",
 anno			 ,	-- ;Anno;intero;4",
 codiceparentbil ,	-- ;Codice bilancio del nodo PARENT di questo;Stringa;50",
 descrbil		 ,	-- ;Descrizione voce bilancio;Stringa;150",
 resp			  	-- ;Responsabile;Stringa;150",
)
SELECT
2,
'Categoria',
substring(codicebil,1,3),
substring(codicebil,1,3),
partebil,
anno,
substring(codicebil,1,1),
descrbil,
null
FROM 
#tracciato_bilancio 
WHERE  LEN(codicebil) > 1
AND nliv = 1


INSERT INTO #tracciato_bilancio
(
 nliv			 ,	-- ;Numero Livello Bilancio;Intero;1",
 descrliv	     ,	-- ;Descrizione Livello Bilancio;Stringa;50",
 codicebil		 ,	-- ;Codice Bilancio;Stringa;50",
 ordinestampa	 ,	-- ;Ordine di stampa;Stringa;50",
 partebil	     ,	-- ;Parte Bilancio (E/S);Codificato;1;E|S",
 anno			 ,	-- ;Anno;intero;4",
 codiceparentbil ,	-- ;Codice bilancio del nodo PARENT di questo;Stringa;50",
 descrbil		 ,	-- ;Descrizione voce bilancio;Stringa;150",
 resp			  	-- ;Responsabile;Stringa;150",
)
SELECT
3,
'Capitolo',
substring(codicebil,1,5),
substring(codicebil,1,5),
partebil,
anno,
substring(codicebil,1,3),
descrbil,
null
FROM 
#tracciato_bilancio 
WHERE  LEN(codicebil)  = 5
AND nliv IN (1,2)
 

--INSERT INTO #tracciato_bilancio
--(
-- nliv			 ,	-- ;Numero Livello Bilancio;Intero;1",
-- descrliv	     ,	-- ;Descrizione Livello Bilancio;Stringa;50",
-- codicebil		 ,	-- ;Codice Bilancio;Stringa;50",
-- ordinestampa	 ,	-- ;Ordine di stampa;Stringa;50",
-- partebil	     ,	-- ;Parte Bilancio (E/S);Codificato;1;E|S",
-- anno			 ,	-- ;Anno;intero;4",
-- codiceparentbil ,	-- ;Codice bilancio del nodo PARENT di questo;Stringa;50",
-- descrbil		 ,	-- ;Descrizione voce bilancio;Stringa;150",
-- resp			  	-- ;Responsabile;Stringa;150",
--)
--SELECT
--3,
--'Capitolo',
--substring(codicebil,1,5),
--substring(codicebil,1,5),
--partebil,
--anno,
--substring(codicebil,1,3),
--descrbil,
--null
--FROM 
--#tracciato_bilancio 
--WHERE  LEN(codicebil) > 3
--AND nliv = 2

update #tracciato_bilancio set codicebil = substring(codicebil,1,1) , ordinestampa= substring(codicebil,1,1) 
WHERE  nliv = 1

update #tracciato_bilancio set codicebil = substring(codicebil,1,3) , ordinestampa= substring(codicebil,1,3) 
WHERE  nliv = 2

select * from #tracciato_bilancio where nliv <> 0
order by nliv, partebil, codicebil,anno

--select  * from #tracciato_bilancio where descrliv = 'categoria'
drop table #tracciato_bilancio

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



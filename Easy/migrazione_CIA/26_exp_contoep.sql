
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contoep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contoep]
GO

--Modificata da Gianni il 11-01-2016

CREATE PROCEDURE [dbo].[exp_contoep]
AS BEGIN
       --string[] tracciato_pianoconti = new string[] {
       --     "nliv;Numero Livello Conto;Intero;1",
       --     "descrliv;Descrizione Livello Conto;Stringa;50",
       --     "codiceconto;Codice Conto;Stringa;50",
       --     "ordinestampa;Ordine di stampa;Stringa;50",
       --     "anno;Anno;intero;4",
       --     "codiceparentconto;Codice conto del nodo PARENT di questo;Stringa;50",
       --     "title;Descrizione conto;Stringa;150",
       --     "competenza;Flag competenza;Codificato;1;S|N",
       --     "contoordine;Flag conto d'ordine;Codificato;1;S|N",
       --     "idaccountkind;chiave tipo conto (di tabella accountkind);Stringa;20",
       --     "flagcliente;Flag registra cliente;Codificato;1;S|N",
       --     "flagupb;Flag registra UPB;Codificato;1;S|N",
       --     "flagutile;Flag utile;Codificato;1;S|N",
       --     "flagperdita;Flag perdita;Codificato;1;S|N",
       --     "flagignoracliente;Ignora cliente in epilogo;Codificato;1;S|N",
       --     "flagignoraupb;Ignora upb in epilogo;Codificato;1;S|N",
       --     "codicecontoeconomico;Codice conto economico associato;Stringa;50",
       --     "flagsegnopositivocontoeconomico;Segno positivo conto economico;Codificato;1;S|N",
       --     "codicestatopatrimoniale;Codice stato patrimoniale;Stringa;50",
       --     "flagsegnopositivostatopatrimoniale;Segno positivo stato patrimoniale;Codificato;1;S|N",
       --     "flagenablebudgetprev;Abilita Previsione di Budget;Codificato;1;S|N"
  --      };
-- exp_contoep       
-- usa la tabella lookup_contoep

--CREATE TABLE lookup_contoep
--(
--	chiave_completa varchar(50),
--	codeacc  varchar(50)
--	CONSTRAINT xpklookup_contoep PRIMARY KEY (chiave_completa)
--)
 
 
CREATE TABLE #tracciato_contoep
(
            nliv				int, --;Numero Livello Conto;Intero;1",
            descrliv			varchar(50),--;Descrizione Livello Conto;Stringa;50",
            codiceconto			varchar(50),--;Codice Conto;Stringa;50",
            ordinestampa		varchar(50),--;Ordine di stampa;Stringa;50",
            anno				int,--;Anno;intero;4",
            codiceparentconto	varchar(50),--;Codice conto del nodo PARENT di questo;Stringa;50",
            title				varchar(150),--;Descrizione conto;Stringa;150",
            competenza			char(1),--;Flag competenza;Codificato;1;S|N",
            contoordine			char(1),--;Flag conto d'ordine;Codificato;1;S|N",
            idaccountkind		varchar(20),--;chiave tipo conto (di tabella accountkind);Stringa;20",
            flagcliente			char(1),--;Flag registra cliente;Codificato;1;S|N",
            flagupb				char(1),--;Flag registra UPB;Codificato;1;S|N",
            flagutile			char(1),---;Flag utile;Codificato;1;S|N",
            flagperdita			char(1),---;Flag perdita;Codificato;1;S|N",
            flagignoracliente	char(1),---;Ignora cliente in epilogo;Codificato;1;S|N",
            flagignoraupb		char(1),---;Ignora upb in epilogo;Codificato;1;S|N",
            codicecontoeconomico			varchar(50),--;Codice conto economico associato;Stringa;50",
            flagsegnopositivocontoeconomico  varchar(50),--;Segno positivo conto economico;Codificato;1;S|N",
            codicestatopatrimoniale			varchar(50),--;Codice stato patrimoniale;Stringa;50",
            flagsegnopositivostatopatrimoniale char(1),   --;Segno positivo stato patrimoniale;Codificato;1;S|N"
            flagenablebudgetprev char(1) --Abilita Previsione di Budget
)


INSERT INTO #tracciato_contoep
(
            nliv				,--;Numero Livello Conto;Intero;1",
            descrliv			,--;Descrizione Livello Conto;Stringa;50",
            codiceconto			,--;Codice Conto;Stringa;50",
            ordinestampa		,--;Ordine di stampa;Stringa;50",
            anno				,--;Anno;intero;4",
            codiceparentconto	,--;Codice conto del nodo PARENT di questo;Stringa;50",
            title				,--;Descrizione conto;Stringa;150",
            competenza			,--;Flag competenza;Codificato;1;S|N",
            contoordine			,--;Flag conto d'ordine;Codificato;1;S|N",
            idaccountkind		,--;chiave tipo conto (di tabella accountkind);Stringa;20",
            flagcliente			,--;Flag registra cliente;Codificato;1;S|N",
            flagupb				,--;Flag registra UPB;Codificato;1;S|N",
            flagutile			,---;Flag utile;Codificato;1;S|N",
            flagperdita			,---;Flag perdita;Codificato;1;S|N",
            flagignoracliente	,---;Ignora cliente in epilogo;Codificato;1;S|N",
            flagignoraupb		,---;Ignora upb in epilogo;Codificato;1;S|N",
            codicecontoeconomico				,--;Codice conto economico associato;Stringa;50",
            flagsegnopositivocontoeconomico		,--;Segno positivo conto economico;Codificato;1;S|N",
            codicestatopatrimoniale				,--;Codice stato patrimoniale;Stringa;50",
            flagsegnopositivostatopatrimoniale,	 --;Segno positivo stato patrimoniale;Codificato;1;S|N"
            flagenablebudgetprev  --Abilita Previsione di Budget
)
select
NUMERO_LIVELLO, 
'Liv.'+convert(varchar(10),NUMERO_LIVELLO),
lookup_contoep.codeacc,
lookup_contoep.codeacc,
conto_ep.ESERCIZIO,
lookup_contoep_padre.codeacc as padre,
conto_ep.NOME_CONTO,
'S',
CASE 
	WHEN NATURA_CONTO = 'CDO' THEN 'S'
	ELSE 'N'
END,
--NATURA_CONTO 
--NUA  -- la maggior parte sono CREDITI        
--EPR  --  Fondo ammortamento e svalutazione 
--EEC  -- Costi      
--NUP  -- Debiti anche se con le dovute eccezioni così come i crditi       
--CDO  -- CONTI D'ORDINE        
--EER  -- Ricavi        
--EPC  -- immobilizzazioni anche se con le dovute eccezioni  

-- MAPPATURA CON LA NOSTRA TABELLA ACCOUNTKIND
-- Gianni
--DEBITI			0003
--RICAVI			0016
--IMMOB				0005
--CONTIDORD			0010 Non avendo una voce affine nella nostra accountkind mettiamo 'Conti transitori di debito'
--FONDOAMMSVAL		0008
--CREDITI			0002
--COSTI				0001

CASE NATURA_CONTO
	WHEN 'NUA' THEN '0002'	--'CREDITI'	   -- con le dovute eccezioni
	WHEN 'EPR' THEN '0008'	--'FONDOAMMSVAL' -- fondo ammortamento
	WHEN 'EEC' THEN '0001'	--'COSTI'		   -- costi 
	WHEN 'NUP' THEN '0003'	--'DEBITI'	   -- debiti con le dovute eccezioni
	WHEN 'CDO' THEN '0010'	--'CONTIDORD'    -- da eliminare poi
	WHEN 'EER' THEN '0016'	--'RICAVI'		
	WHEN 'EPC' THEN '0005'	--'IMMOB'  --- anche se con le dovute eccezioni	
	ELSE			NULL	
END,
'S',
'S',
'S',    --flagutile		Flag utile;Codificato;1;S|N",
'N',    --flagperdita	Flag perdita;Codificato;1;S|N",
'S',    --flagignoracliente	 Ignora cliente in epilogo;Codificato;1;S|N",
'S',    --flagignoraupb		Ignora upb in epilogo;Codificato;1;S|N",
null,	--codicecontoeconomico	 Codice conto economico associato;Stringa;50",
null,   --flagsegnopositivocontoeconomico	 Segno positivo conto economico;Codificato;1;S|N",
null,   --codicestatopatrimoniale		 Codice stato patrimoniale;Stringa;50",
null,    --flagsegnopositivostatopatrimoniale,
'S' --flagenablebudgetprev
from  CONTO_EP  
LEFT OUTER JOIN   lookup_contoep
ON  lookup_contoep.CHIAVE_COMPLETA = CONTO_EP.CHIAVE_COMPLETA
LEFT OUTER JOIN lookup_contoep lookup_contoep_padre 
ON  lookup_contoep_padre.CHIAVE_COMPLETA = CONTO_EP.CHIAVE_PADRE
--WHERE NUMERO_LIVELLO > 1
order by ESERCIZIO, lookup_contoep.CHIAVE_COMPLETA


select * from #tracciato_contoep  
order by nliv, codiceconto,anno

drop table #tracciato_contoep

END



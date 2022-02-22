
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modpagamento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modpagamento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_modpagamento]

AS BEGIN


--string[] tracciato_modpag =
--    new string[]{ "codice;Codice anagrafica;Intero;10",
--                //modalità di pagamento
--                "tipomodpag;tipo modalità di pagamento "+
--                    "1-Assegno circolare  (non ammette delegato o coordinate bancarie) "+
--                    "3-Bonifico presso altre banche (non ammette delegato, coord.bancarie obbligatorie) "+
--                    "4-Bonifico presso istituto cassiere (non ammette delegato, coord.bancarie obbligatorie) "+
--                    "5-Conto corrente postale (ammette solo il cc) "+
--                    "6-Esclusiva cassiere (non ammette delegato o coord.bancarie) "+
--                    "7-Sportello (ammette delegato e  non ammette coord.bancarie);"+
--                    "Codificato;1;1|3|4|5|6|7",
--                        "nomemod;Nome modalità;Stringa;50",
--                        "descrmod;Nome modalità;Stringa;150",

--                "abi;ABI;Stringa;10",
--                "cab;CAB;Stringa;10",
--                "cin;CIN;Stringa;5",
--                "cc;Conto corrente;Stringa;30",
--                "bic;Conto BIC/SWIFT;Stringa;20",
--                "delegato;Codice delegato (di anagrafica);Intero;10",
--                "valuta;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
--                "tiposcadenza;Tipo scadenza "+
--                    "1-data contabile,2-data documento,"+
--                    "3-fine mese data contabile,4-fine mese data documento,"+
--                    "5-Pagamento immediato;Codificato;1;1|2|3|4|5",
--                "ggscadenza;Giorni dalla scadenza;intero;2",
--                "iban;IBAN;Stringa;50",     
--                "extracode;Conto in banca d'Italia;Stringa;10",
--                "refexternaldoc;Riferimento doc.esterno;Stringa;5",
--                "txt;Note;Stringa;1000",
--                "attivo;Attivo;Codificato;1;S|N",
--                    "flagstandard;Modalità predefinita;Codificato;1;S|N"
--    };



SELECT 
	LKA.idreg as 'codice',
	P.idpaymethod as 'tipomodpag',
	substring(RP.DESCRIZIONE,1,50) as 'nomemod',
	B.ABI as 'abi',
	B.CAB as 'cab',
	B.CIN as 'cin',
	B.NUMEROCONTO as 'cc', 
	B.BIC as 'bic',
	null as 'delegato',
	'Eur'as 'valuta',
	-- la tabella "rif_termini_pagamento" e "termini_pagamento" sono vuote
	null as 'tiposcadenza',
	null as 'ggscadenza',
	B.IBAN as 'iban', 
	null as 'extracode',
	null as 'refexternaldoc',
	B.intestazione as 'descrmod',
	'S' as 'attivo',
	'N' as 'flagstandard'
FROM ANAGRAFICO A 
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
JOIN MODALITA_PAGAMENTO MP
  ON A.CODICE = MP.CODICE
JOIN RIF_MODALITA_PAGAMENTO RP
  ON  MP.CODICE_RIF = RP.CODICE
JOIN BANCA B
  ON A.CODICE = B.CODICE
JOIN lookup_modalita_pagamento P
	ON P.codice = RP.codice
WHERE LKA.tipo ='A' 
	AND (B.TIPO IS NULL OR RP.TIPO_PAGAMENTO IS NULL OR RP.TIPO_PAGAMENTO = B.TIPO) 
	AND P.idpaymethod IS NOT NULL
	
UNION  
SELECT 
	LKA.idreg as 'codice',
	P.idpaymethod as 'tipomodpag',
	substring(RP.DESCRIZIONE,1,50) as 'nomemod',
	B.ABI as 'abi',
	B.CAB as 'cab',
	B.CIN as 'cin',
	B.NUMEROCONTO as 'cc', 
	B.BIC as 'bic',
	null as 'delegato',
	'Eur'as 'valuta',
	-- la tabella "rif_termini_pagamento" e "termini_pagamento" sono vuote
	null as 'tiposcadenza',
	null as 'ggscadenza',
	B.IBAN as 'iban', 
	null as 'extracode',
	null as 'refexternaldoc',
	B.intestazione as 'descrmod',
	'S' as 'attivo',
	'N' as 'flagstandard'
FROM ANAGRAFICO A 
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
JOIN MODALITA_PAGAMENTO MP
  ON A.CODICE = MP.CODICE
JOIN RIF_MODALITA_PAGAMENTO RP
  ON  MP.CODICE_RIF = RP.CODICE
JOIN BANCA B
  ON A.CODICE = B.CODICE
JOIN lookup_modalita_pagamento P
	ON P.codice = RP.codice
WHERE LKA.tipo ='A' 
	AND RP.TIPO_PAGAMENTO <> B.TIPO 
	AND P.idpaymethod IS NOT NULL
	AND NOT EXISTS (SELECT 1 FROM ANAGRAFICO A2
				JOIN  MODALITA_PAGAMENTO MP2
					on A2.CODICE = MP2.CODICE
				JOIN RIF_MODALITA_PAGAMENTO RP2
					ON  MP2.CODICE_RIF = RP2.CODICE
				JOIN BANCA B2 
					ON A2.CODICE = B2.CODICE
				WHERE A2.CODICE = A.CODICE  AND (B2.TIPO IS NULL OR RP2.TIPO_PAGAMENTO IS NULL OR RP2.TIPO_PAGAMENTO = B2.TIPO)
				) 
UNION 

SELECT
	LKA.idreg as 'codice',
	P.idpaymethod as 'tipomodpag',
	substring(B.DESCRIZIONE,1,50) as 'nomemod',
	B.ABI as 'abi',
	B.CAB as 'cab',
	B.CIN as 'cin',
	B.NUMEROCONTO as 'cc', 
	B.BIC as 'bic',
	null as 'delegato',
	'Eur'as 'valuta',
	-- la tabella "rif_termini_pagamento" e "termini_pagamento" sono vuote
	null as 'tiposcadenza',
	null as 'ggscadenza',
	B.IBAN as 'iban', 
	null as 'extracode',
	null as 'refexternaldoc',
	B.intestazione as 'descrmod',
	'S' as 'attivo',
	'N' as'flagstandard' 
FROM banca_dip B
JOIN dipendenti D
    ON D.codice = B.codice 
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.codice
join modalita_pagamento_dip M
    on D.codice = M.codice
join rif_modalita_pagamento R
    on R.codice = M.codice_rif 
JOIN lookup_modalita_pagamento P
	ON P.codice = R.codice
WHERE LKA.tipo ='D' 
	AND P.idpaymethod IS NOT NULL
	AND  (B.TIPO IS NULL OR R.TIPO_PAGAMENTO IS NULL OR R.TIPO_PAGAMENTO = B.TIPO) 
UNION 

SELECT
	LKA.idreg as 'codice',
	P.idpaymethod as 'tipomodpag',
	substring(B.DESCRIZIONE,1,50) as 'nomemod',
	B.ABI as 'abi',
	B.CAB as 'cab',
	B.CIN as 'cin',
	B.NUMEROCONTO as 'cc', 
	B.BIC as 'bic',
	null as 'delegato',
	'Eur'as 'valuta',
	-- la tabella "rif_termini_pagamento" e "termini_pagamento" sono vuote
	null as 'tiposcadenza',
	null as 'ggscadenza',
	B.IBAN as 'iban', 
	null as 'extracode',
	null as 'refexternaldoc',
	B.intestazione as 'descrmod',
	'S' as 'attivo',
	'N' as 'flagstandard'
FROM banca_dip B
JOIN dipendenti D
    ON D.codice = B.codice 
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.codice
join modalita_pagamento_dip M
    on D.codice = M.codice
join rif_modalita_pagamento R
    on R.codice = M.codice_rif 
JOIN lookup_modalita_pagamento P
	ON P.codice = R.codice
WHERE   LKA.tipo ='D' 
	AND P.idpaymethod IS NOT NULL
	AND (B.TIPO <> R.TIPO_PAGAMENTO ) and 
		not exists( SELECT 1 FROM banca_dip B2
					JOIN dipendenti D2
						ON D2.codice = B2.codice 
					JOIN lookup_anagrafica LKA2
						ON LKA2.codice = D2.codice
					join modalita_pagamento_dip M2
						on D2.codice = M2.codice
					join rif_modalita_pagamento R2
						on R2.codice = M2.codice_rif 
				   WHERE LKA2.tipo ='A' 
						AND D2.CODICE = D.CODICE  
					AND (B2.TIPO IS NULL OR R2.TIPO_PAGAMENTO IS NULL OR R2.TIPO_PAGAMENTO = B2.TIPO)       
			)
UNION


SELECT distinct
	LKA.idreg as 'codice',
	P.idpaymethod as 'tipomodpag',
	substring(D.MODALITA_PAGAMENTO,1,50) as 'nomemod',
	D.ABI_CLIENTE_FORNITORE as 'abi',
	D.CAB_CLIENTE_FORNITORE as 'cab',
	D.CIN as 'cin',
	D.NUMERO_CONTO_CLIENTE_FORNITORE as 'cc', 
	D.BIC as 'bic',
	null as 'delegato',
	'Eur'as 'valuta',
	null as 'tiposcadenza',
	null as 'ggscadenza',
	D.IBAN as 'iban', 
	null as 'extracode',
	null as 'refexternaldoc',
	D.DESCRIZIONE_BANCA_CLI_FOR as 'descrmod',
	'S' as 'attivo',
	'N' as'flagstandard' 
from CURR_DOCUMENTO_CONTABILE D 
join RIF_MODALITA_PAGAMENTO RPAG
	on D.MODALITA_PAGAMENTO = RPAG.descrizione
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.CODICE_ANAG
JOIN lookup_modalita_pagamento P
	ON P.codice = RPAG.codice
WHERE LKA.tipo ='U' 


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

-- EXEC exp_modpagamento
/*
update registrypaymethod set flagstandard ='S'
where not exists (select * from registrypaymethod R2
				where registrypaymethod.idreg = R2.idreg		
				and registrypaymethod.idregistrypaymethod <> R2.idregistrypaymethod )

*/

------------------------------------------------------------------------------------------------------------------------------------------------------------

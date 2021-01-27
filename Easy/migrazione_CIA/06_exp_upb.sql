
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_upb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_upb]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE exp_upb

( @bilancio varchar(50) , @extroot varchar(50)=null
)
AS BEGIN
	-- -exp_upb   'A.AMMCE'    

      -- "codiceupb;Codice UPB;Stringa;50",
      --      "ordinestampa;Ordine di stampa;Stringa;50",
      --      "codiceparentupb;Codice UPB del nodo PARENT di questo;Stringa;50",
      --      "descrupb;Descrizione UPB;Stringa;150",
      --      "resp;Responsabile;Stringa;150",
      --      "accertamentipregr;Accertamenti pregressi;Numero;22",
      --      "impegnipregr;Impegni pregressi;Numero;22",
      --      "finrich;Finanziamento Richiesto;Numero;22",
      --      "finacc;Finanziamento Accordato;Numero;22",
      --      "fincerto;Finanziamento Certo (Fondo) (S/N);Codificato;1;S|N",
      --      "attivo;Attivo (S/N);Codificato;1;S|N",
      --      "codcup; Codice Unico di Progetto;Stringa;15",
      --      "codtipoclass01;Codice Tipo class. 01;Stringa;20",
	  --	  "codclass01;Codice class. 01;Stringa;50",
	  --	  "codtipoclass02;Codice Tipo class. 02;Stringa;20",
      --      "codclass02;Codice class. 02;Stringa;50",
      --      "codtipoclass03;Codice tipo class. 03;Stringa;20",
      --      "codclass03;Codice class. 03;Stringa;50",
      --      "codtipoclass04;Codice Tipo class. 04;Stringa;20",
      --      "codclass04;Codice class. 04;Stringa;50",
      --      "codtipoclass05;Codice Tipo class. 05;Stringa;20",
      --      "codclass05;Codice class. 05;Stringa;50",
      --      "flagattivita;Flag Attività;Codificato;1;Q|I|C",
      --      "flagdidattica;Didattica (S/N);Codificato;1;S|N",
      --      "flagricerca;Ricerca;Codificato;1;S|N",
      --      "codicecass;Codice Cassiere;Stringa;20",
      --      "descrcass;Descrizione Cassiere;Stringa;150",
      --      "note;Note;Stringa;400"
      --  };
    
DECLARE @taxrate decimal(19,2)
SET @taxrate = 1936.27
declare @skiplen int
set @skiplen= len(@bilancio)+2

declare @codice_root varchar(20)
declare @codice_altri varchar(20)

set @codice_root = 'libero'
if @extroot is not null set @codice_root=@extroot

set @codice_altri = 'tuttiprogetti'
-- usa la tabella lookup_progetti
declare @maxeserc int
select @maxeserc  =max(esercizio) from UNITA_ORGANIZZATIVA where IDENTIFICATIVO_BILANCIO = @bilancio

SELECT
	U.NUMERO_LIVELLO - 1 as nlevel,
	1 as 'kind',
	case when  U.NUMERO_LIVELLO=2 then @codice_root
		else substring(U.CHIAVE_COMPLETA, @skiplen,len(U.chiave_completa)) 
	end 
	AS codiceupb, 
	case when  U.NUMERO_LIVELLO=2  then @codice_root
		else substring(U.CHIAVE_COMPLETA, @skiplen,len(U.chiave_completa)) 
	end 	
	AS ordinestampa,
	case when  U.NUMERO_LIVELLO=2 then null
		 when  U.NUMERO_LIVELLO=3 then @codice_root
		else substring(U.CHIAVE_COMPLETA_PADRE, @skiplen,len(U.chiave_completa_padre))
	end 	

	 AS codiceparentupb,
	ISNULL(U.DESCRIZIONE,U.NOME_UNITA) AS descrupb,
	rtrim(U.RESPONSABILE) AS resp,
	CASE 
		WHEN UPPER (P.CODICE_VALUTA) = 'EUR'  THEN P.importo_complessivo 
		ELSE convert(decimal(19,2),ROUND (P.importo_complessivo/@taxrate,2) )
	END AS finrich				, --Finanziamento Richiesto
	CASE 
		WHEN UPPER (P.CODICE_VALUTA) = 'EUR'  THEN P.importo_complessivo 
		ELSE convert(decimal(19,2),ROUND((P.importo_complessivo/@taxrate),2)  )
	END AS finacc				, --Finanziamento Accordato
	'N' AS fincerto,
	CASE 
		WHEN  P.DATA_SCADENZA IS NULL AND U.esercizio = @maxeserc THEN 'S'
		WHEN YEAR (P.DATA_SCADENZA) >= YEAR(GETDATE()) AND U.esercizio = @maxeserc THEN 'S'
		ELSE 'N'
	END AS attivo,
	/*   	substring(substring(UBILANCIO.CHIAVE_COMPLETA, @skiplen,len(UBILANCIO.CHIAVE_COMPLETA)),1,20) AS codicecass,
    ISNULL(UBILANCIO.DESCRIZIONE,UBILANCIO.NOME_UNITA) AS descrcass,*/
	lookup_dipartimento.codeupb as codicecass,
	lookup_dipartimento.descrizione as descrcass,
    P.ENTE_FINANZIATORE AS finanziatore,
    P.DATA_SCADENZA AS datafine,
      CASE
		WHEN P.CODICE_PROGETTO IS NOT NULL THEN P.NOTE
		ELSE NULL
    END as note
FROM  UNITA_ORGANIZZATIVA  U
	LEFT OUTER JOIN  UNITA_ORGANIZZATIVA UBILANCIO		ON U.IDENTIFICATIVO_BILANCIO = UBILANCIO.CHIAVE_COMPLETA
LEFT OUTER JOIN  PROGETTO  P -- -bilancio e codice progetto	
	ON U.IDENTIFICATIVO_BILANCIO = P.BILANCIO	AND U.chiave = P.CODICE_PROGETTO
LEFT OUTER JOIN   lookup_dipartimento
	ON lookup_dipartimento.chiave_completa = U.IDENTIFICATIVO_BILANCIO
WHERE
	U.IDENTIFICATIVO_BILANCIO = @bilancio AND
	U.numero_livello>1 AND
NOT EXISTS (SELECT * FROM   UNITA_ORGANIZZATIVA U1 WHERE 
					U1.CHIAVE_COMPLETA = U.CHIAVE_COMPLETA AND
						((U1.ESERCIZIO > U.ESERCIZIO) 
						OR
						((U1.ESERCIZIO = U.ESERCIZIO) AND 
							CONVERT(INT, U1.VERSIONE) > CONVERT(INT, U.VERSIONE))))
AND NOT EXISTS (SELECT * FROM   UNITA_ORGANIZZATIVA UBILANCIO1 WHERE 
						 UBILANCIO1.CHIAVE_COMPLETA = UBILANCIO.CHIAVE_COMPLETA AND
						((UBILANCIO1.ESERCIZIO > UBILANCIO.ESERCIZIO )
						OR 
						( (UBILANCIO1.ESERCIZIO = UBILANCIO.ESERCIZIO) AND
							 CONVERT(INT, UBILANCIO1.VERSIONE) > CONVERT(INT, UBILANCIO.VERSIONE))))


UNION ALL

SELECT
	2 as nlevel,
    2 as 'kind',
 	@codice_altri AS codiceupb, 
	@codice_altri  AS ordinestampa,
	@codice_root  AS codiceparentupb,
	'Tutti i progetti'  AS descrupb,
	null AS resp,
	null AS finrich				, --Finanziamento Richiesto
	null AS finacc				, --Finanziamento Accordato
	'N' AS fincerto,
	'S' AS 'attivo',
/*   	substring(substring(UBILANCIO.CHIAVE_COMPLETA, @skiplen,len(UBILANCIO.CHIAVE_COMPLETA)),1,20) AS codicecass,
    ISNULL(UBILANCIO.DESCRIZIONE,UBILANCIO.NOME_UNITA) AS descrcass,*/
	lookup_dipartimento.codeupb as codicecass,
	lookup_dipartimento.descrizione as descrcass,
    null AS finanziatore,
    null AS datafine,
    null  as note
	from  lookup_dipartimento
			where lookup_dipartimento.chiave_completa = @bilancio


UNION ALL

SELECT
	UBILANCIO.NUMERO_LIVELLO+1  as nlevel,
	3 as 'kind',
 	P.codice_progetto AS codiceupb, 
	P.codice_progetto  AS ordinestampa,
	@codice_altri  AS codiceparentupb,
	P.DESCRIZIONE AS descrupb,
	P.RESPONSABILE AS resp,
	CASE 
		WHEN UPPER (P.CODICE_VALUTA) = 'EUR'  THEN P.importo_complessivo 
		ELSE convert(decimal(19,2),ROUND (P.importo_complessivo/@taxrate,2)  )
	END AS finrich				, --Finanziamento Richiesto
	CASE 
		WHEN UPPER (P.CODICE_VALUTA) = 'EUR'  THEN P.importo_complessivo 
		ELSE convert(decimal(19,2), ROUND((P.importo_complessivo/@taxrate),2)  )
	END AS finacc				, --Finanziamento Accordato
	'N' AS fincerto,
	CASE 
		WHEN  P.DATA_SCADENZA IS NULL AND UBILANCIO.esercizio = @maxeserc THEN 'S'
		WHEN YEAR (P.DATA_SCADENZA) >= YEAR(GETDATE()) AND UBILANCIO.esercizio = @maxeserc THEN 'S'
		ELSE 'N'
	END AS 'attivo',
/*   	substring(substring(UBILANCIO.CHIAVE_COMPLETA, @skiplen,len(UBILANCIO.CHIAVE_COMPLETA)),1,20) AS codicecass,
    ISNULL(UBILANCIO.DESCRIZIONE,UBILANCIO.NOME_UNITA) AS descrcass,*/
	lookup_dipartimento.codeupb as codicecass,
	lookup_dipartimento.descrizione as descrcass,
    P.ENTE_FINANZIATORE AS finanziatore,
    P.DATA_SCADENZA AS datafine,
    P.CODICE_PROGETTO  as note
FROM  PROGETTO P
JOIN  UNITA_ORGANIZZATIVA UBILANCIO
	ON P.BILANCIO = UBILANCIO.CHIAVE_COMPLETA
LEFT OUTER JOIN   lookup_dipartimento
	ON lookup_dipartimento.chiave_completa = UBILANCIO.IDENTIFICATIVO_BILANCIO
WHERE 
	UBILANCIO.IDENTIFICATIVO_BILANCIO = @bilancio AND
	UBILANCIO.numero_livello>1 AND
	NOT EXISTS	
		(SELECT * FROM  UNITA_ORGANIZZATIVA U  WHERE  U.IDENTIFICATIVO_BILANCIO = P.bilancio 
			and U.chiave = P.codice_progetto)
	AND NOT EXISTS (SELECT * FROM   UNITA_ORGANIZZATIVA UBILANCIO1 WHERE 
			UBILANCIO1.CHIAVE_COMPLETA = UBILANCIO.CHIAVE_COMPLETA AND
					((UBILANCIO1.ESERCIZIO > UBILANCIO.ESERCIZIO )
					OR 
				( (UBILANCIO1.ESERCIZIO = UBILANCIO.ESERCIZIO) AND 
				CONVERT(INT, UBILANCIO1.VERSIONE) > CONVERT(INT, UBILANCIO.VERSIONE))))


ORDER BY 1,2,3


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


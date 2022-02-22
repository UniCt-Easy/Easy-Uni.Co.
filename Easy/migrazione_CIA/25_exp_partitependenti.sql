
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_partitependenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_partitependenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- exp_partitependenti 'A.ammce'
--amministrazione;34;exec [GIOVE2-PC\SQL2008,1435].[TEST].[DBO].exp_partitependenti 'A.AMMCE'
CREATE PROCEDURE exp_partitependenti
( @bilancio varchar(50)  
)
AS
BEGIN
/*			"anno;Anno;Intero;4",
            "num;Numero parita pendete;Intero;6",
            "tipo;Tipo partita pendete(Credito/Debito);Codificato;1;C|D",
			"anagrafica;Denominazione anagrafica;Stringa;150",
			"importocoperto;Importo Coperto;Numero;22", -- covered 
			"importoapertura;Importo Apertura;Numero;22", --total 
            "data;Data contabile;Data;8", -- adate
			"attiva;Da regolarizzare;Codificato;1;S|N", --	active  
            "causale;Causale;Stringa;150", -- motive 
			"codicecass;Codice Cassiere;Stringa;20",  --idtreasurer
            "descrcass;Descrizione Cassiere;Stringa;150",
			"note;Note per la regolarizzazione;Stringa;400", -- regularizationnote
			"importochiusura;Importo Chiusura;Numero;22", -- reduction
*/            

select 
S.ESERCIZIO as 'anno',
S.NUMERO_SOSPESO as 'num',
case when S.TIPO_SOSPESO = 'E' then 'C'else 'D' end as 'tipo',
null as 'anagrafica',
null as 'importocoperto',
CONVERT(decimal(19,2),CASE 
	WHEN S.esercizio >= 2002 THEN S.IMPORTO
	ELSE   ROUND(S.IMPORTO/1936.27,2)  
 END) as 'importoapertura',
isnull(S.DATA_VALUTA_ENTE, S.DATA_REGISTRAZIONE) as 'data',
'S' as 'attiva',
substring(S.DESCRIZIONE,1,150) as 'causale',
null as 'codicecass',
null as 'descrcass',
null as 'note',
case when S.esercizio>=2002 then
	(select sum(AMMONTARE_RELAZIONE)  from REL_SOSPESO_DOCUMENTO R
	where R.ESERCIZIO_DOCUMENTO = S.ESERCIZIO
		and R.NUMERO_SOSPESO = S.NUMERO_SOSPESO
		and R.TIPO_SOSPESO = S.TIPO_SOSPESO
  )
else 
 (select sum(CONVERT(decimal(19,2), ROUND(AMMONTARE_RELAZIONE/1936.27,2) )) from REL_SOSPESO_DOCUMENTO R
	where R.ESERCIZIO_DOCUMENTO = S.ESERCIZIO
		and R.NUMERO_SOSPESO = S.NUMERO_SOSPESO
		and R.TIPO_SOSPESO = S.TIPO_SOSPESO
)
 end
  as  'importochiusura'
FROM sospeso S
WHERE S.BILANCIO = @bilancio
order by S.tipo_sospeso,S.esercizio,S.numero_sospeso					
END




GO

-- exp_partitependenti 'A.AMMCE'
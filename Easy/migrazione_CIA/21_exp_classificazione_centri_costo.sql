
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_classificazioni_centri_costo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_classificazioni_centri_costo]
GO
/****** Object:  StoredProcedure [dbo].[exp_classificazioni_centri_costo]    Script Date: 27/11/2013 10.05.13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- [dbo].[exp_classificazioni_centri_costo] null
CREATE PROCEDURE [dbo].[exp_classificazioni_centri_costo]
(@bilancio varchar(120) = null )
AS BEGIN
        --string[] tracciato_classificazioni = new string[]{
        --    "codesorkind;Codice tipo classificazione;Stringa;20",
        --    "descrsorkind;Descrizione tipo classificazione;Stringa;50",
        --    "startsorkind;anno inizio tipo classificazione;Intero;4",
        --    "stopsorkind;anno fine tipo classificazione;Intero;4",
        --    "nphaseincome;Livello associazione alle entrate del tipo classificazione;Intero;1",
        --    "nphaseexpense;Livello associazione alle spese del tipo classificazione;Intero;1",
        --    "sortcode;Codice classificazione;Stringa;50",
        --    "parentsortcode;Codice classificazione del nodo parent;Stringa;50",
        --    "printingorder;Ordine di stampa;Stringa;50",
        --    "nlevel;N. Livello classificazione;Intero;2",
        --    "usable;Livello operativo (S/N);Codificato;1;S|N",
        --    "descrlevel;Descrizione livello classificazione;Stringa;50",
        --    "description;Descrizione voce classificazione;Stringa;200",
        --    "startsorting;anno inizio voce classificazione;Intero;4",
        --    "stopsorting;anno fine voce classificazione;Intero;4"

DECLARE @startsorkind int
DECLARE @stopsorkind int

SELECT @startsorkind = MIN(convert(int,ESERCIZIO)),
	   @stopsorkind = MAX(convert(int,ESERCIZIO)) 
  FROM CENTRO_COSTO



  --sp_help centro_costo
SELECT
	'centricosto' as codesorkind, 
	'Centri di Costo' as descrsorkind,
	@startsorkind as startsorkind ,
	NULL as stopsorkind,
	null as nphaseincome,
	null as nphaseexpense,
	C.CHIAVE_COMPLETA,
	SUBSTRING(C.CHIAVE_COMPLETA,3, LEN(C.CHIAVE_COMPLETA) -2)   as sortcode,
	CASE
		WHEN   (PATINDEX('%.%', REVERSE(C.CHIAVE_COMPLETA))  = LEN (C.CHIAVE_COMPLETA) -1) THEN 
			   SUBSTRING(C.CHIAVE_COMPLETA,3, LEN(C.CHIAVE_COMPLETA) - PATINDEX('%.%', REVERSE(C.CHIAVE_COMPLETA)) - 1 )
		ELSE   SUBSTRING(C.CHIAVE_COMPLETA,3, LEN(C.CHIAVE_COMPLETA) - PATINDEX('%.%', REVERSE(C.CHIAVE_COMPLETA)) - 2 )
	END 
	as parentsortcode,
	SUBSTRING(C.CHIAVE_COMPLETA,3, LEN(C.CHIAVE_COMPLETA) -2)   as printingorder,
    LEN(C.CHIAVE_COMPLETA) - LEN(REPLACE(C.CHIAVE_COMPLETA,'.',''))   AS nlevel,
	'S' as usable,
	'Livello' + CONVERT(Varchar(10), (LEN(C.CHIAVE_COMPLETA) - LEN(REPLACE(C.CHIAVE_COMPLETA,'.','')) ) ) AS descrlevel,
	C.NOME as description,
	C.ESERCIZIO AS  startsorting,
	NULL  AS stopsorting
FROM  CENTRO_COSTO C
WHERE ((@bilancio IS NULL) OR (C.BILANCIO = @bilancio))
AND NOT EXISTS (SELECT * FROM   CENTRO_COSTO C1 WHERE 
C1.CHIAVE_COMPLETA = C.CHIAVE_COMPLETA AND
C1.ESERCIZIO > C.ESERCIZIO )
AND C.CHIAVE_COMPLETA <> 'C'
order by LEN(C.CHIAVE_COMPLETA)
END


GO


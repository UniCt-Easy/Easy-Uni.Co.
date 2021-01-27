
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_ubicazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_ubicazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
                          nliv: Pos.    0 lunghezza    1 Tipo:          Intero Descrizione: Numero Livello ubicazione
                      descrliv: Pos.    1 lunghezza   30 Tipo:         Stringa Descrizione: Descrizione Livello ubicazione
                    codiceubic: Pos.   31 lunghezza   50 Tipo:         Stringa Descrizione: Codice ubicazione
              codiceparentubic: Pos.   81 lunghezza   50 Tipo:         Stringa Descrizione: Codice ubicazione del nodo PARENT di questo
                     descrubic: Pos.  131 lunghezza  150 Tipo:         Stringa Descrizione: Descrizione voce classificazione
                          resp: Pos.  281 lunghezza  150 Tipo:         Stringa Descrizione: Responsabile
                          note: Pos.  431 lunghezza  100 Tipo:         Stringa Descrizione: Note
*/

CREATE      PROCEDURE [exp_ubicazioni]
( 
@bilancio varchar(50)  = null  
)
AS BEGIN

SELECT 
	isnull(U.sequenza,'1') as 'nliv',
	case
		when isnull(U.sequenza,'1') = '1' then 'Struttura'
		when U.sequenza = '2' then 'Area'
		when U.sequenza = '3' then 'Ufficio'
	end as 'descrliv',
	rtrim(ltrim(U.chiave_ubicazione)) as 'codiceubic',
	case when  isnull(U.sequenza,'1') = '1' then null
		else U.chiave_padre 
	end as 'codiceparentubic',
	rtrim(ltrim(U.descrizione)) as 'descrubic',
	(select top 1 responsabile from  REL_UBICAZIONE_RESPONSABILE 
			where REL_UBICAZIONE_RESPONSABILE.chiave_ubicazione = U.CHIAVE_UBICAZIONE 
			and REL_UBICAZIONE_RESPONSABILE.DATA_CANCELLAZIONE is null
		) as 'resp',
	null as 'note'
FROM UBICAZIONE U
--JOIN REL_UO_UBICAZIONE R	ON U.chiave_ubicazione = R.chiave_ubicazione
--JOIN lookup_upb LK	ON LK.chiave_completa = R.chiave_unita_organizzativa
--WHERE LK.bilancio = @bilancio

GROUP BY U.sequenza, U.chiave_ubicazione, U.chiave_padre,U.descrizione
ORDER BY U.SEQUENZA, U.chiave_ubicazione

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

EXEC exp_ubicazioni  null--'A.DIPSU'

------------------------------------------------------------------------------------------------------------------------------------------------------------
--select * from UBICAZIONE U
--JOIN REL_UO_UBICAZIONE R		ON U.chiave_ubicazione = R.chiave_ubicazione
--JOIN lookup_upb LK 	ON LK.chiave_completa = R.chiave_unita_organizzativa

--where U.chiave_ubicazione = '03_04C'

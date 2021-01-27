
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_classificazioneinventariale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_classificazioneinventariale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
                          nliv: Pos.    0 lunghezza    1 Tipo:          Intero Descrizione: Numero Livello classificazione
                      descrliv: Pos.    1 lunghezza   30 Tipo:         Stringa Descrizione: Descrizione Livello classificazione
                   codiceclass: Pos.   31 lunghezza   20 Tipo:         Stringa Descrizione: Codice classificazione inventariale
             codiceparentclass: Pos.   51 lunghezza   20 Tipo:         Stringa Descrizione: Codice classificazione inventariale del nodo PARENT di questo
                    descrclass: Pos.   71 lunghezza  150 Tipo:         Stringa Descrizione: Descrizione voce classificazione
*/

CREATE      PROCEDURE [exp_classificazioneinventariale]
( @bilancio varchar(50)  = null  -->inutilizzato
)
AS BEGIN


select 
	sequenza as 'nliv',
	case
		when sequenza = '1' then 'Categoria'
		when sequenza = '2' then 'Gruppo'
		when sequenza = '3' then 'Sottogruppo'
	end as 'descrliv',
	chiave_completa as 'codiceclass',
	case when  sequenza = '1' then null
		else chiave_padre 
	end as 'codiceparentclass',
	descrizione as 'descrclass'
from INVENTARIO_CATEGORIA_GRUPPI
order by sequenza

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

EXEC exp_classificazioneinventariale

------------------------------------------------------------------------------------------------------------------------------------------------------------

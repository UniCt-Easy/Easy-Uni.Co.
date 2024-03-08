
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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



if exists (select * from dbo.sysobjects where id = object_id(N'[check_inquadramento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_inquadramento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 
CREATE    PROCEDURE [check_inquadramento]

AS BEGIN
        
CREATE TABLE #logerror(
	errore varchar(1000)
)

 	-- 1 -- Inquadramenti senza qualifica
	INSERT INTO #logerror(errore)
	select 'Anagrafica con Inquadramento senza Qualifica. Codice ' + convert(varchar(10), r.idreg) + ' Denominazione '+r.title  + ' Data decorrenza: '+ CONVERT(varchar(19),CONVERT(smalldatetime, incomeclassvalidity, 105),105) 
	from registrylegalstatus rls 
	join registry r 
		on rls.idreg = r.idreg
	where rls.idposition is null and rls.active ='S'
	
	
	-- 2 -- Estraggo le righe che dovrebbero avere valorizzato i livello, invece è null
	INSERT INTO #logerror(errore)
	select 'Anagrafica con Inquadramento senza Livello per la qualifica "'+ p.title + '" Codice' + convert(varchar(10), r.idreg) + ' Denominazione '+r.title   
	from registrylegalstatus rls 
	join registry r 		on rls.idreg = r.idreg
	join position p			on p.idposition = rls.idposition
	where rls.livello is null and p.codeposition in ('PTA_EP','PTA_B','PTA_C','PTA_D')
	and rls.active ='S'


SELECT 
	errore
FROM #logerror
ORDER BY errore

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


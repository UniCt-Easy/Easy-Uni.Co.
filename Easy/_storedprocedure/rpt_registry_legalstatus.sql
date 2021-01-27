
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



/* Versione 1.0.0 del 10/09/2007 ultima modifica: PIERO */

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_registry_legalstatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_registry_legalstatus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE     PROCEDURE [rpt_registry_legalstatus]
(
		@idreg int
)
AS BEGIN


SELECT 
	
-- pos giuridica 
	registrylegalstatus.idreg,
	registrylegalstatus.start, -- data delibera
	
	position.description as position,
	registrylegalstatus.incomeclass, -- classe stipendiale
	registrylegalstatus.incomeclassvalidity, -- data decorrenza
	registrylegalstatus.idregistrylegalstatus
FROM registry
-- posizione giuridica
LEFT OUTER JOIN registrylegalstatus 
	ON registrylegalstatus.idreg = registry.idreg AND isnull(registrylegalstatus.active,'N')='S'
JOIN position 
	ON registrylegalstatus.idposition = position.idposition 

WHERE (registry.idreg = @idreg OR @idreg is null)
	
	

END







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


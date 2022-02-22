
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registry_doublereference]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registry_doublereference]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [exp_registry_doublereference]
AS
BEGIN



SELECT 
	idreg AS 'Codice Anagrafica', 
	title AS 'Denominazione' FROM registry
WHERE (SELECT COUNT(*) FROM registryreference
			WHERE registry.idreg = registryreference.idreg
			AND registryreference.flagdefault = 'S') > 1

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


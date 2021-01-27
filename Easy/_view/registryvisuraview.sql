
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


-- CREAZIONE VISTA registryvisuraview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryvisuraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryvisuraview]
GO





--select * from registryvisuraview


CREATE    VIEW [dbo].[registryvisuraview] 
(
	idreg,
	registry,
	idregistryvisura,
	start,
	stop,
	visuracertification,
	cu, 
	ct, 
	lu,
	lt
)
AS 
SELECT
	registryvisura.idreg, 
	registry.title, 
	registryvisura.idregistryvisura,
	registryvisura.start,
	registryvisura.stop,
	registryvisura.visuracertification,
	registryvisura.cu, 
	registryvisura.ct, 
	registryvisura.lu, 
	registryvisura.lt
FROM registryvisura (NOLOCK)
JOIN registry (NOLOCK)
	ON registryvisura.idreg = registry.idreg



GO

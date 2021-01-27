
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


-- CREAZIONE VISTA registryspecialcategory770view
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryspecialcategory770view]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryspecialcategory770view]
GO



CREATE    VIEW [dbo].[registryspecialcategory770view] 
AS 
SELECT
	registryspecialcategory770.ayear,
	registryspecialcategory770.idregistryspecialcategory770,
	registryspecialcategory770.idspecialcategory770,
	specialcategory770.description as specialcategory770,
	registryspecialcategory770.idreg, 
	registry.title as registry, 
	registryspecialcategory770.cu, 
	registryspecialcategory770.ct, 
	registryspecialcategory770.lu, 
	registryspecialcategory770.lt
FROM registryspecialcategory770 (NOLOCK)
JOIN specialcategory770
	ON registryspecialcategory770.idspecialcategory770 = specialcategory770.idspecialcategory770
	and registryspecialcategory770.ayear = specialcategory770.ayear
JOIN registry (NOLOCK)
	ON registryspecialcategory770.idreg = registry.idreg



GO

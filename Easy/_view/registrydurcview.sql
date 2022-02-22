
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


-- CREAZIONE VISTA registrydurcview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydurcview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydurcview]
GO








CREATE    VIEW [dbo].[registrydurcview] 
(
	idreg,
	registry,
	idregistrydurc,
	iddurckind,
	durckinddescr,
	start,
	stop,
	adate,
	selfcertification,
	durccertification,
	doc,
	docdate,
	inpscode,
	inailcode,
	buildingcode,
	otherinsurancecode,
	flagirregular,
	cu, 
	ct, 
	lu,
	lt
)
AS 
SELECT
	registrydurc.idreg, 
	registry.title, 
	registrydurc.idregistrydurc,
	registrydurc.iddurckind,
	durckind.description,
	registrydurc.start,
	registrydurc.stop,
	registrydurc.adate,
	registrydurc.selfcertification,
	registrydurc.durccertification,
	registrydurc.doc,
	registrydurc.docdate,
	registrydurc.inpscode,
	registrydurc.inailcode,
	registrydurc.buildingcode,
	registrydurc.otherinsurancecode,
	registrydurc.flagirregular,
	registrydurc.cu, 
	registrydurc.ct, 
	registrydurc.lu, 
	registrydurc.lt
FROM registrydurc (NOLOCK)
JOIN durckind
	ON registrydurc.iddurckind = durckind.iddurckind
JOIN registry (NOLOCK)
	ON registrydurc.idreg = registry.idreg



GO

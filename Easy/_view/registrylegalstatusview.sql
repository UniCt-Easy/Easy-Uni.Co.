
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


-- CREAZIONE VISTA registrylegalstatusview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrylegalstatusview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrylegalstatusview]
GO


CREATE  VIEW [DBO].registrylegalstatusview 
(
	idreg,
	title, 
	start,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt,
	idregistrylegalstatus,
	stop,
	csa_compartment,csa_role, csa_class,
	iddaliaposition,codedaliaposition,daliaposition
)
	AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.codeposition,
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt,
	registrylegalstatus.idregistrylegalstatus,
 	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class,
	registrylegalstatus.iddaliaposition,
	dalia_position.codedaliaposition,
	dalia_position.description
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
JOIN position 
	ON registrylegalstatus.idposition = position.idposition 
LEFT OUTER JOIN dalia_position 
	ON registrylegalstatus.iddaliaposition = dalia_position.iddaliaposition 





GO

 

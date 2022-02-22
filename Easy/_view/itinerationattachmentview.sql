
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


-- CREAZIONE VISTA itinerationattachmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationattachmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationattachmentview]
GO


--drop view [itinerationattachmentview] 
--setuser 'amministrazione'
-- select * from [itinerationattachmentview]
CREATE VIEW [itinerationattachmentview] 
	(
	kpay,
	idexp,
	iditineration,
	idattachment
	)
	AS SELECT
	EL.kpay,
	E.idexp,
	EI.iditineration,
	IA.idattachment
	FROM expense E (NOLOCK)
	JOIN expenselast EL (NOLOCK) ON EL.idexp = E.idexp
	JOIN expenselink ELK (NOLOCK) ON ELK.idchild = EL.idexp
	JOIN expenseitineration EI (NOLOCK) ON EI.idexp = ELK.idparent
	JOIN itineration I (NOLOCK) ON  I.iditineration = EI.iditineration
	JOIN (select iditineration, idattachment from itinerationattachment) IA ON IA.iditineration = I.iditineration
	

GO



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


-- CREAZIONE VISTA itinerationlapview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationlapview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationlapview]
GO


CREATE  VIEW itinerationlapview 
(
	iditineration,
	yitineration,
	nitineration,
	lapnumber,
	idforeigncountry,
	codeforeigncountry,
	location,
	flagitalian,
	description,
	starttime,
	stoptime,
	days,
	hours,
	idreduction,
	reduction,
	allowance,
	advancepercentage,
	ancereductionpercentage,
	cu, ct, lu, lt
)
AS SELECT
	itinerationlap.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationlap.lapnumber,
	itinerationlap.idforeigncountry,
	foreigncountry.codeforeigncountry,
	foreigncountry.description,
	itinerationlap.flagitalian,
	itinerationlap.description,
	itinerationlap.starttime,
	itinerationlap.stoptime,
	itinerationlap.days,
	itinerationlap.hours,
	itinerationlap.idreduction,
	reduction.description,
	itinerationlap.allowance, 
	itinerationlap.advancepercentage, 
	itinerationlap.reductionpercentage,
	itinerationlap.cu, itinerationlap.ct, itinerationlap.lu, itinerationlap.lt
FROM itinerationlap
JOIN itineration
ON itineration.iditineration = itinerationlap.iditineration
LEFT OUTER JOIN foreigncountry
ON foreigncountry.idforeigncountry = itinerationlap.idforeigncountry
LEFT OUTER JOIN reduction
ON reduction.idreduction = itinerationlap.idreduction


GO



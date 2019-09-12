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



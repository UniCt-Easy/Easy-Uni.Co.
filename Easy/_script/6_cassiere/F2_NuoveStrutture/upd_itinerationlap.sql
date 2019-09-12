UPDATE itinerationlap SET flagitalian = 
CASE
	WHEN flagitalian = 'I' THEN 'S'
	ELSE 'N'
END
if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_authagency]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_authagency]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
-- rpt_missione_authagency 2018,194
CREATE  PROCEDURE [rpt_missione_authagency]
	@yitineration smallint, 
	@nitineration int
AS BEGIN
SELECT 
	authagency.title AS authagency_title,
	authagency.description AS authagency_desc,
	itinerationauthagency.lt AS authagency_date,
	authagency.priority,
	CASE WHEN itinerationauthagency.flagstatus = 'S' THEN 'Approvata'
		 WHEN itinerationauthagency.flagstatus = 'N' THEN 'Non Approvata'
		 WHEN itinerationauthagency.flagstatus = 'D' THEN 'Da Esaminare'
	END AS 'status'
FROM itineration
	JOIN itinerationauthagency 		ON itineration.iditineration = itinerationauthagency.iditineration
	JOIN authagency					ON itinerationauthagency.idauthagency = authagency.idauthagency
WHERE itineration.yitineration = @yitineration
		AND itineration.nitineration = @nitineration
		AND itineration.iditineration_ref is null
ORDER BY authagency.priority
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

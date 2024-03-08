
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_missione_calcolo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_missione_calcolo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
-- rpt_missione_calcolo 2018,194
CREATE  PROCEDURE [rpt_missione_calcolo]
	@yitineration smallint, 
	@nitineration int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN
DECLARE @iditineration int
SELECT  @iditineration=iditineration
	FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration


create table #indennita
(
	lapnumber int,
	grossfactor float,
	indennitatot decimal (19,2),
	quotaesente decimal (19,2),
	imponibiletappa decimal (19,2),
	exemption decimal (19,6),
	percquotaesentegg decimal (19,8),
	days float,
	hours float,
	flagitalian char	
)

insert into #indennita
(
	lapnumber ,
	grossfactor,
	indennitatot ,
	exemption ,
	percquotaesentegg ,
	days ,
	hours,
	flagitalian
)
select 
	lapnumber,
	isnull(grossfactor,0),
	ISNULL(
	Round(
		(1-isnull(convert(real,reductionpercentage),0))*isnull(convert(real,allowance),0)*
		  ( convert(real, itinerationlap.days)  +
		    convert(real, itinerationlap.hours)/24
	          )
	,2)
	,0),

	case 
		WHEN (itinerationlap.flagitalian='S') then (select top 1 isnull(italianexemption,0) 
					from itinerationparameter where start<=itinerationlap.starttime
					order by start desc)
		ELSE (select top 1 isnull(foreignexemption,0) 
					from itinerationparameter where start<=itinerationlap.starttime
					order by start desc)
	end,
	case 
		when (isnull(reductionpercentage,0)>1) then '1'
		ELSE isnull(reductionpercentage,0)
	end,
	itinerationlap.days,
	itinerationlap.hours,
	itinerationlap.flagitalian	
from itineration 
join itinerationlap on itineration.iditineration = itinerationlap.iditineration
where ( (itineration.yitineration = @yitineration and itineration.nitineration = @nitineration) 
		or (iditineration_ref = @iditineration) )
	AND (@idsor01 IS NULL OR itineration.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR itineration.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR itineration.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR itineration.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR itineration.idsor05 = @idsor05)



update #indennita
set quotaesente = ISNULL(
			CASE 
			WHEN  ROUND((1- convert(real,percquotaesentegg))*convert(real,exemption)*(convert(real,days)+convert(real,hours)/24),2)
				> indennitatot
				then (indennitatot) 
				else ROUND((1- convert(real,percquotaesentegg))*convert(real,exemption)*(convert(real,days)+convert(real,hours)/24),2)
			end
		,0)

update #indennita
set imponibiletappa = ROUND(ISNULL(
			CASE
			when (indennitatot - quotaesente)>0
				then ( convert(real,(indennitatot - quotaesente)) * convert(real,grossfactor) )
				else 0
			End
		,0),2)

SELECT
	ISNULL(
		(SELECT SUM(amount)
		FROM itinerationrefund
		join itineration m on m.iditineration = itinerationrefund.iditineration
		WHERE itinerationrefund.flagadvancebalance = 'S'
			AND ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
			--AND m.yitineration = @yitineration	AND m.nitineration = @nitineration
			
			)
	,0) AS totalrefund,
	ISNULL(
		(SELECT SUM(extraallowance)
		FROM itinerationrefund
		join itineration m on m.iditineration = itinerationrefund.iditineration
		WHERE itinerationrefund.flagadvancebalance = 'S'
					AND ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--AND m.yitineration = @yitineration	AND m.nitineration = @nitineration
			)
	,0) AS extraallowance,
	/*ISNULL(
		(SELECT SUM(allowance)
		FROM itinerationlap
		WHERE yitineration = @yitineration
			AND nitineration = @nitineration
			AND flagitalian = 'S')
	,0) AS italiangrossallowance,*/
	ISNULL(
		(SELECT SUM(
		    CASE 
			WHEN ((indennitatot - quotaesente)>0)
			THEN    (imponibiletappa + quotaesente)
			ELSE   indennitatot
		    END
		   )
		from #indennita
		where  flagitalian='S') --yitineration = @yitineration	AND nitineration = @nitineration and
	,0) as italiangrossallowance,

	/*ISNULL(
		(SELECT SUM(allowance)
		FROM itinerationlap
		WHERE yitineration = @yitineration
			AND nitineration = @nitineration
			AND flagitalian = 'N')
	,0) AS foreigngrossallowance,*/
	ISNULL(
		(SELECT SUM(
		    CASE 
			WHEN ((indennitatot - quotaesente)>0)
			THEN    (imponibiletappa + quotaesente)
			ELSE   indennitatot
		    END
		   )
		from #indennita
		where flagitalian='N'   --yitineration = @yitineration AND nitineration = @nitineration and 
		)
	,0) as foreigngrossallowance,

	min(grossfactor) as grossfactor,
	/*ROUND(ISNULL(admincarkmcost,0) * ISNULL(admincarkm,0),2) +
	ROUND(ISNULL(owncarkmcost,0) * ISNULL(owncarkm,0),2) +
	ROUND(ISNULL(footkmcost,0) * ISNULL(footkm,0),2) AS kmrefund,*/
	ISNULL((select 	SUM((ISNULL(admincarkmcost,0) * ISNULL(admincarkm,0)) +
		(ISNULL(owncarkmcost,0) * ISNULL(owncarkm,0)) +
		(ISNULL(footkmcost,0) * ISNULL(footkm,0)))
		from itineration i2
		where ISNULL(i2.iditineration_ref, i2.iditineration)= @iditineration
		),0)
		 AS kmrefund,
		 
	ISNULL(
		(SELECT SUM(i.admintax) 
		FROM itinerationtax i
		join itineration m on m.iditineration = i.iditineration
		JOIN tax t				ON i.taxcode = t.taxcode
		WHERE		ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--m.yitineration = @yitineration	AND m.nitineration = @nitineration
			AND t.taxkind = 2)
	,0) AS admintaxass,
	ISNULL(
		(SELECT SUM(i.admintax) 
		FROM itinerationtax i
		join itineration m on m.iditineration = i.iditineration
		JOIN tax t 			ON i.taxcode = t.taxcode
		WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--m.yitineration = @yitineration	AND m.nitineration = @nitineration
			AND t.taxkind = 3)
	,0) AS admintaxprev,
	ISNULL(
		(SELECT SUM(i.employtax) 
		FROM itinerationtax i
		join itineration m on m.iditineration = i.iditineration
		JOIN tax t		ON i.taxcode = t.taxcode
		WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--m.yitineration = @yitineration	AND m.nitineration = @nitineration
			AND t.taxkind = 2)
	,0) AS employtaxass,
	ISNULL(
		(SELECT SUM(i.employtax) 
		FROM itinerationtax i
		join itineration m on m.iditineration = i.iditineration
		JOIN tax t  			ON i.taxcode = t.taxcode
		WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--m.yitineration = @yitineration	AND m.nitineration = @nitineration
			AND t.taxkind = 3)
	,0) AS employtaxprev,
	ISNULL(
		(SELECT SUM(i.employtax) 
		FROM itinerationtax i
		join itineration m on m.iditineration = i.iditineration
		JOIN tax t			ON i.taxcode = t.taxcode
		WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
					--m.yitineration = @yitineration	AND m.nitineration = @nitineration
			AND t.taxkind = 1)
	,0) AS employtaxfisc,
	ISNULL(
		(SELECT SUM((ISNULL(linkedangir,0) + ISNULL(linkedanpag,0)))
		FROM itinerationresidual
		join itineration m on m.iditineration = itinerationresidual.iditineration
		WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration
		)
	,0) AS linkedadvance,
		ISNULL(
		(SELECT sum(m.totadvance) from 
			itineration m 
			WHERE ISNULL(m.iditineration_ref,m.iditineration) = @iditineration			
			)
		,0) AS totadvance
FROM itineration
WHERE yitineration = @yitineration
	AND nitineration = @nitineration
	AND (@idsor01 IS NULL OR itineration.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR itineration.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR itineration.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR itineration.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR itineration.idsor05 = @idsor05)
	AND itineration.iditineration_ref is null
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[get_itinerationrefundrule]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_itinerationrefundrule]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [get_itinerationrefundrule]
(
	@iditineration int,
	@nrefund int,
	@fieldname varchar(255),
	@returnvalue decimal(19,8) output
)

as 
CREATE TABLE #temp
(
	iditinerationrefundrule int,
	iddetail int,
	advancepercentage decimal(19,6),
	nhour_min int,
	nhour_max int,
	limit decimal(19,2)
)
BEGIN
-- first get idreg, idposition and incomeclass
DECLARE @idreg int
DECLARE @idposition int
DECLARE @incomeclass int
DECLARE @flag_geo char
DECLARE @starttime smalldatetime
DECLARE @iditinerationrefundkindgroup int
declare @nhour int

SELECT 	@idreg=itineration.idreg,
	@idposition=registrylegalstatus.idposition,
	@incomeclass=registrylegalstatus.incomeclass 
 	from itineration 
		join 	registry 
			on itineration.idreg=registry.idreg 
		join registrylegalstatus 
			on itineration.idreg=registrylegalstatus.idreg
			and itineration.idregistrylegalstatus=registrylegalstatus.idregistrylegalstatus
	where itineration.iditineration=@iditineration
		

-- get flag,starttime from itinerationrefund
SELECT  @flag_geo=flag_geo, @starttime = itinerationrefund.starttime,
	@iditinerationrefundkindgroup=itinerationrefundkind.iditinerationrefundkindgroup , 
	@nhour = datediff(hour, itinerationrefund.starttime,itinerationrefund.stoptime) 
	from itinerationrefund 
	join itinerationrefundkind on itinerationrefund.iditinerationrefundkind=
	itinerationrefundkind.iditinerationrefundkind
	where itinerationrefund.iditineration=@iditineration and itinerationrefund.nrefund=@nrefund 

-- Insert rule into temptable

	insert into #temp 
	select  top 1
		itinerationrefundruledetail.iditinerationrefundrule,
	 	itinerationrefundruledetail.iddetail,
		itinerationrefundruledetail.advancepercentage,
		itinerationrefundruledetail.nhour_min,
		itinerationrefundruledetail.nhour_max,
		itinerationrefundruledetail.limit 
	from itinerationrefundruledetail 
	inner join itinerationrefundrule on 
		itinerationrefundrule.iditinerationrefundrule = itinerationrefundruledetail.iditinerationrefundrule 
	where itinerationrefundruledetail.idposition=@idposition and isnull(@incomeclass,0) 
	between itinerationrefundruledetail.minincomeclass and itinerationrefundruledetail.maxincomeclass and 
	(
		(@flag_geo='I' and isnull(flag_italy,'')='S') or 
		(@flag_geo='U' and isnull(flag_eu,'')='S') or 
		(@flag_geo='E' and isnull(flag_extraeu,'')='S')
	)
	and itinerationrefundrule.start<=@starttime
	and itinerationrefundruledetail.iditinerationrefundkindgroup=@iditinerationrefundkindgroup
	and (itinerationrefundruledetail.nhour_min is null or itinerationrefundruledetail.nhour_min <= @nhour)
	and (itinerationrefundruledetail.nhour_max is null or itinerationrefundruledetail.nhour_max >= @nhour)
	order by itinerationrefundrule.start desc

if (select count(*) from #temp)=0 set @returnvalue=null

if @fieldname='iditinerationrefundrule' set @returnvalue=(select iditinerationrefundrule from #temp)
if @fieldname='iddetail' set @returnvalue=(select iddetail from #temp)
if @fieldname='advancepercentage' set @returnvalue=(select advancepercentage from #temp)
if @fieldname='nhour_min' set @returnvalue=(select nhour_min from #temp)
if @fieldname='nhour_max' set @returnvalue=(select nhour_max from #temp)
if @fieldname='limit' set @returnvalue=(select limit from #temp)


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


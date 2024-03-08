
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


if exists (select * from dbo.sysobjects where id = object_id(N'[AL_rpt_riepprevisione_UPB]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [AL_rpt_riepprevisione_UPB]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







-- AL_rpt_riepprevisione_UPB 2008, 'S', '5', 'AMMNE'
-- setuser 'accademia'
-- euro2005.dbo.sp_rpt_riepprevisione_UPB 2008, 'E', '5', ''
-- sp_rpt_riepprevisione_UPB 2008, 'E', '5', ''

CREATE   PROCEDURE AL_rpt_riepprevisione_UPB
	@ayear smallint,
	@finpart char(1),
	@levelusable tinyint,
 	@upb varchar(36)
AS
BEGIN
CREATE TABLE #rptrieppreventivo	
(
upb							varchar(10)  NULL,
decoupb							varchar(150)  NULL,
code1											varchar(30)		 NULL,
desc1												varchar(100)	 NULL,
order1											varchar(30)		 NULL,
initialprevision							float					NULL,
previousprevision							float					NULL,
secondaryprevision				float					NULL,
previoussecondaryprev				float					NULL,
variazioneanumento						float					NULL,
previousarrears						float					NULL,

-- disponibile
currentarrears						float					NULL,
variazionediminuzione				float					NULL,
varsecaumento								float					NULL,
varsecdiminuzione						float					NULL,
varripaumento								float					NULL,
varripdiminuzione						float					NULL,
fondocassapres							float					NULL,
avanzoamminpres							float					NULL,
fondocassapresprec					float					NULL,
avanzoamminpresprec					float					NULL
--previoussecondaryprev
,tit1totprevsecesprec float NULL
--previousarrears
,tit1previousarrears float NULL
,tit1totprevcorr float					NULL
,tit1totprevprec float					NULL
,tit1totprevseccorr float					NULL
,tit1totvaraum float					NULL

--previoussecondaryprev
,tit2totprevsecesprec float NULL
--previousarrears
,tit2previousarrears float NULL
,tit2totprevcorr float					NULL
,tit2totprevprec float					NULL
,tit2totprevseccorr float					NULL
,tit2totvaraum float					NULL

--previoussecondaryprev
,tit3totprevsecesprec float NULL
--previousarrears
,tit3previousarrears float NULL
,tit3totprevcorr float					NULL
,tit3totprevprec float					NULL
,tit3totprevseccorr float					NULL
,tit3totvaraum float					NULL

--previoussecondaryprev
,tit4totprevsecesprec float NULL
--previousarrears
,tit4previousarrears float NULL
,tit4totprevcorr float					NULL
,tit4totprevprec float					NULL
,tit4totprevseccorr float					NULL

,tit4totvaraum float					NULL
,esercizio smallint NULL
)
insert into #rptrieppreventivo (upb, decoupb, code1, desc1, order1,
[initialprevision], [previousprevision], [secondaryprevision], 
 [previoussecondaryprev], [currentarrears], [previousarrears], variazioneanumento,
 [fondocassapres], [avanzoamminpres], [fondocassapresprec], [avanzoamminpresprec], 
-- [prevdefcassa] 
esercizio)
select distinct 
			upb						
,			decode_upb					
,			code1						
,			desc1						
,			order1						
,previsionecorr = SUM(ISNULL(initialprevision, 0.0))							
,previsioneprec = SUM(ISNULL(previousprevision	, 0.0))			
,prevseceserciziocorr = SUM(ISNULL(secondaryprevision, 0.0))			
,prevsecesercizioprec = SUM(isnull(previoussecondaryprev, 0.0))

,ripartizionecorr = SUM(ISNULL(currentarrears, 0.0))
,ripartizioneprec = SUM(ISNULL(previousarrears, 0.0))

,variazioneaumento = SUM(ISNULL(currentarrears, 0.0))
,fondocassapres = SUM(ISNULL(fondocassapres, 0.0))							
,avanzoamminpres = SUM(ISNULL(avanzoamminpres	, 0.0))						
,fondocassapresprec = SUM(ISNULL(fondocassapresprec	, 0.0))				
,avanzoamminpresprec = SUM(ISNULL(avanzoamminpresprec	, 0.0))				
, @ayear
from [riep_preventivo] 
group by upb, decode_upb,code1,desc1,order1						


update  #rptrieppreventivo	
set tit1totprevcorr = (select sum(isnull(initialprevision	,0.0))	
FROM [riep_preventivo]where code1='1') 
--SELECT [upb], [decode_upb], [code1], [desc1], [descliv1], [order1], [code2], 
-- [desc2], [descliv2], [order2], [code3], [desc3], [descliv3], [order3], 
-- [initialprevision], [previousprevision], [secondaryprevision], 
-- [previoussecondaryprev], [currentarrears], [previousarrears], 
-- [fondocassapres], [avanzoamminpres], [fondocassapresprec], [avanzoamminpresprec], 
-- [prevdefcassa] 
-- FROM [riep_preventivo]
-- where upb = @upb
		
update  #rptrieppreventivo	
set tit2totprevcorr = (select sum(isnull(initialprevision	,0.0))	
from riep_preventivo	where code1='2') 

update  #rptrieppreventivo	
set tit3totprevcorr = (select sum(isnull(initialprevision	,0.0))	
from riep_preventivo	where code1='3') 

update  #rptrieppreventivo	
set tit4totprevcorr = (select sum(isnull(initialprevision	,0.0))	
from riep_preventivo	where code1='4') 

---------------
update  #rptrieppreventivo	
set tit1totprevprec = (select sum(isnull(previousprevision	,0.0))	
from riep_preventivo where code1='1') 
		
update  #rptrieppreventivo	
set tit2totprevprec = (select sum(isnull(previousprevision	,0.0))	
from riep_preventivo where code1='2') 

update  #rptrieppreventivo	
set tit3totprevprec = (select sum(isnull(previousprevision	,0.0))	
from riep_preventivo where code1='3') 

update  #rptrieppreventivo	
set tit4totprevprec = (select sum(isnull(previousprevision	,0.0))	
from riep_preventivo where code1='4') 
--------------------
-- secondaryprevision secondaryprevision
update  #rptrieppreventivo	
set tit1totprevseccorr = (select sum(isnull(secondaryprevision	,0.0))	
from riep_preventivo where code1='1') 
		
update  #rptrieppreventivo	
set tit2totprevseccorr = (select sum(isnull(secondaryprevision	,0.0))	
from riep_preventivo where code1='2') 

update  #rptrieppreventivo	
set tit3totprevseccorr = (select sum(isnull(secondaryprevision	,0.0))	
from riep_preventivo where code1='3') 

update  #rptrieppreventivo	
set tit4totprevseccorr = (select sum(isnull(secondaryprevision	,0.0))	
from riep_preventivo where code1='4') 
--------------------
-- currentarrears currentarrears
update  #rptrieppreventivo	
set tit1totvaraum = (select sum(isnull(currentarrears	,0.0))	
from riep_preventivo where code1='1') 
		
update  #rptrieppreventivo	
set tit2totvaraum = (select sum(isnull(currentarrears	,0.0))	
from riep_preventivo where code1='2') 

update  #rptrieppreventivo	
set tit3totvaraum = (select sum(isnull(currentarrears	,0.0))	
from riep_preventivo where code1='3') 

update  #rptrieppreventivo	
set tit4totvaraum = (select sum(isnull(currentarrears	,0.0))	
from riep_preventivo where code1='4') 

--------------------
-- previoussecondaryprev previoussecondaryprev

update  #rptrieppreventivo	
set tit1totprevsecesprec = (select sum(isnull(previoussecondaryprev	,0.0))	
from riep_preventivo where code1='1') 

update  #rptrieppreventivo	
set tit2totprevsecesprec = (select sum(isnull(previoussecondaryprev,0.0))	
from riep_preventivo where code1='2') 

update  #rptrieppreventivo	
set tit3totprevsecesprec = (select sum(isnull(previoussecondaryprev,0.0))	
from riep_preventivo where code1='3') 


update  #rptrieppreventivo	
set tit4totprevsecesprec = (select sum(isnull(previoussecondaryprev,0.0))	
from riep_preventivo where code1='4') 

--------------------

update  #rptrieppreventivo	
set tit1previousarrears = (select sum(isnull(previousarrears,0.0))	
from riep_preventivo where code1='1') 

update  #rptrieppreventivo	
set tit2previousarrears = (select sum(isnull(previousarrears,0.0))	
from riep_preventivo where code1='2') 

update  #rptrieppreventivo	
set tit3previousarrears = (select sum(isnull(previousarrears,0.0))	
from riep_preventivo where code1='3') 

update  #rptrieppreventivo	
set tit4previousarrears = (select sum(isnull(previousarrears,0.0))	
from riep_preventivo where code1='4') 

--------------------

select 
			upb						
,			decoupb					
,			code1						
,			desc1						
,			order1						
,			initialprevision					
,			previousprevision					
,			secondaryprevision				
,			previoussecondaryprev				
,			currentarrears												
,			previousarrears						
,			currentarrears						
,			variazionediminuzione				
,			varsecaumento						
,			varsecdiminuzione					
,			varripaumento						
,			varripdiminuzione					
,			fondocassapres						
,			avanzoamminpres					
,			fondocassapresprec					
,			avanzoamminpresprec					

,tit1totprevsecesprec 
,tit1previousarrears 
,tit1totprevcorr 
,tit1totprevprec 
,tit1totprevseccorr 
,tit1totvaraum 
,tit2totprevsecesprec 
,tit2previousarrears 
,tit2totprevcorr 
,tit2totprevprec 
,tit2totprevseccorr 
,tit2totvaraum 

,tit3totprevsecesprec 
,tit3previousarrears 
,tit3totprevcorr 
,tit3totprevprec 
,tit3totprevseccorr 
,tit3totvaraum 

,tit4totprevsecesprec 
,tit4previousarrears 
,tit4totprevcorr 
,tit4totprevprec 
,tit4totprevseccorr 
,tit4totvaraum 

FROM #rptrieppreventivo	
order by code1

-- select sum(previoussecondaryprev) from #rptrieppreventivo	
END




















GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


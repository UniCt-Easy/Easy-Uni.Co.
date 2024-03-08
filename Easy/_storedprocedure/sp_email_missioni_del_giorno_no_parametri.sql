
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



if exists (select * from dbo.sysobjects where id = object_id(N'[sp_email_missioni_del_giorno_no_parametri]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_email_missioni_del_giorno_no_parametri]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [sp_email_missioni_del_giorno_no_parametri]
AS

BEGIN

-- execute [amministrazione].[sp_email_missioni_del_giorno_no_parametri]
-- FORMAT (getdate(), 'dd-MM-yyyy')
----------------------------------------------------------------------
-- create conditions for html tables in top and mid sections of email.
 
declare @xml_missioni NVARCHAR(MAX)
declare @body_missioni NVARCHAR(MAX)
declare @message_subject  NVARCHAR(MAX)

set @message_subject = 'Resoconto delle missioni inserite nella giornata: ' + convert(varchar,format(convert(date,getdate()),'dd-MM-yyyy') )

create table #missioni
(
[Eserc. miss.]			varchar(max),
[Num. miss.]			varchar(max),
[Descrizione]			varchar(max),
[Località]				varchar(max),
[Responsabile]			varchar(max),
[Stato]					varchar(max),
[Denom. Percipiente]	varchar(max),
[Matricola]				varchar(max),
[Posizione Giuridica]	varchar(max),
[Data inizio]			varchar(max),
[Data fine]				varchar(max),
[Data contabile]		varchar(max),
[Costo Totale]			varchar(max),
[Anticipo]				varchar(max),
[Anticipo Erogato]		varchar(max),
[Totale Erogato]		varchar(max),
[Residuo da erogare]	varchar(max),
[Data Doc. Definitiva]	varchar(max),
[Codice UPB]			varchar(max),
[Modello Autorizzativo]	varchar(max),
[Dati della macchina]	varchar(max),
[Motivazione macchina]	varchar(max)
)

insert into #missioni
select 
yitineration		as [Eserc. miss.],
nitineration		as [Num. miss.],
description			as [Descrizione],
location			as [Località],
manager				as [Responsabile],
itinerationstatus	as [Stato],
registry			as [Denom. Percipiente],
extmatricula		as [Matricola],
position			as [Posizione Giuridica],
format(start,	'dd-MM-yyyy')			as [Data inizio],
format(stop,	'dd-MM-yyyy')			as [Data fine],
format(adate,	'dd-MM-yyyy')			as [Data contabile],
total				as [Costo Totale],
totadvance			as [Anticipo],
advancelinked		as [Anticipo Erogato],
totlinked			as [Totale Erogato],
totresidual			as [Residuo da erogare],
datecompleted		as [Data Doc. Definitiva],
codeupb				as [Codice UPB],
authmodtitle		as [Modello Autorizzativo],
vehicle_info		as [Dati della macchina],
vehicle_motive		as [Motivazione uso della macchina]
from itinerationview 
where --(adate >= getdate()-100 and adate <= getdate()) AND -- da correggere prendere solo quelle del giorno
iditinerationstatus=6 AND flagweb='S' AND totadvance > 0 AND  totresidual > 0
order by 1 desc ,2 asc




----------------------------------------------------------------------
-- set xml top table td's
-- create html table object for: #agent_job_step_error_report
set @xml_missioni=
 cast(
 (select
isnull([Eserc. miss.]			,'') as 'td' , '',
isnull([Num. miss.]				,'') as 'td' , '',
isnull([Descrizione]			,'') as 'td' , '',						
isnull([Località]				,'') as 'td' , '',			
isnull([Responsabile]			,'') as 'td' , '',			
isnull([Stato]					,'') as 'td' , '',					
isnull([Denom. Percipiente]		,'') as 'td' , '',	
isnull([Matricola]				,'') as 'td' , '',				
isnull([Posizione Giuridica]	,'') as 'td' , '',	
isnull([Data inizio]			,'') as 'td' , '',			
isnull([Data fine]				,'') as 'td' , '',				
isnull([Data contabile]			,'') as 'td' , '',		
isnull([Costo Totale]			,'') as 'td' , '',			
isnull([Anticipo]				,'') as 'td' , '',			
isnull([Anticipo Erogato]		,'') as 'td' , '',	
isnull([Totale Erogato]			,'') as 'td' , '',	
isnull([Residuo da erogare]		,'') as 'td' , '',	
isnull([Codice UPB]				,'') as 'td' , '',		
isnull([Modello Autorizzativo]	,'') as 'td' , ''	
 from #missioni
 for xml path('tr')
 , elements)
 as NVARCHAR(MAX)
 )
 

----------------------------------------------------------------------
 
set @body_missioni =
 '<html>
 <head>
 <style>
 h1{
 font-family: sans-serif;
 font-size: 110%;
 }
 h3{
 font-family: sans-serif;
 color: red;
 }
 
 table, td, tr, th {
 font-family: sans-serif;
 font-size: 90%;
 border: 1px solid black;
 border-collapse: collapse;
 }
 th {
 text-align: left;
 background-color: gray;
 color: white;
 padding: 5px;
 }
 
 td {
 padding: 5px;
 font-size: 90%;
 }
 </style>
 </head>
 <body>
 <H3>' + @message_subject + '</H3>
 <h1>Controllo eseguito in data: '  + convert(varchar,format(convert(date,getdate()),'dd-MM-yyyy')) + '
 <table border = 1>
 <tr>
<th> Eserc. miss.			</th>
<th> Num. miss.				</th>
<th> Descrizione			</th>
<th> Località				</th>
<th> Responsabile			</th>
<th> Stato					</th>
<th> Denom. Percipiente		</th>
<th> Matricola				</th>
<th> Posizione Giuridica	</th>
<th> Data inizio			</th>
<th> Data fine				</th>
<th> Data contabile			</th>
<th> Costo Totale			</th>
<th> Anticipo				</th>
<th> Anticipo Erogato		</th>
<th> Totale Erogato			</th>
<th> Residuo da erogare		</th>
<th> Codice UPB				</th>
<th> Modello Autorizzativo	</th>
 </tr>'

 
select  @body_missioni = @body_missioni + isnull(@xml_missioni,'Non ho trovato nuove missioni')

-- amministrazione.[sp_alert_email_conto_terzi]
---------------------------------------------------------------------
-- send email.
 
EXEC msdb.dbo.sp_send_dbmail
 @profile_name = 'notifiche.easy@unict.it'
, @recipients = 'giannismal@yahoo.it'
, @subject = @message_subject
, @body = @body_missioni
, @body_format = 'HTML';
 
drop table #missioni

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


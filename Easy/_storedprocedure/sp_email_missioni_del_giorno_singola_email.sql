
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



if exists (select * from dbo.sysobjects where id = object_id(N'[sp_email_missioni_del_giorno_singola_email]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_email_missioni_del_giorno_singola_email]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [sp_email_missioni_del_giorno_singola_email]
(
  @idcustomuser VARCHAR(50)
, @title VARCHAR(150)
, @email VARCHAR(50)
, @idsor01 INT
, @idsor02 INT
, @idsor03 INT
, @idsor04 INT
, @idsor05 INT
, @all_sorkind01 VARCHAR(1)
, @all_sorkind02 VARCHAR(1)
, @all_sorkind03 VARCHAR(1)
, @all_sorkind04 VARCHAR(1)
, @all_sorkind05 VARCHAR(1) 
)

AS

BEGIN

-- [amministrazione].[sp_email_missioni_del_giorno]
-- FORMAT (getdate(), 'dd-MM-yyyy')
----------------------------------------------------------------------
-- create conditions for html tables in top and mid sections of email.
 
declare @xml_missioni NVARCHAR(MAX)
declare @body_missioni NVARCHAR(MAX)
declare @message_subject  NVARCHAR(MAX)

set @message_subject = 'Resoconto missioni da elaborare. Data: ' + convert(varchar,format(convert(date,getdate()),'dd-MM-yyyy') ) + ' - Utente: ' + @idcustomuser + ' - Ruolo: ' + @title

create table #missioni
(
[Eserc. miss.]				varchar(max),
[Num. miss.]				varchar(max),
[Descrizione]				varchar(max),
[Località]					varchar(max),
[Responsabile]				varchar(max),
[Stato]						varchar(max),
[Denom. Percipiente]		varchar(max),
[Matricola]					varchar(max),
[Posizione Giuridica]		varchar(max),
[Data inizio]				varchar(max),
[Data fine]					varchar(max),
[Data contabile]			varchar(max),
[Costo Totale]				varchar(max),
[Anticipo]					varchar(max),
[Anticipo Erogato]			varchar(max),
[Totale Erogato]			varchar(max),
[Residuo da erogare]		varchar(max),
[Data Doc. Definitiva]		varchar(max),
[Codice UPB]				varchar(max),
[Modello Autorizzativo]		varchar(max),
[Dati della macchina]		varchar(max),
[Motivazione macchina]		varchar(max),
[Appunti per il pagamento]	varchar(max),
[Appunti inseriti su Easy]	varchar(max)
)

insert into #missioni
SELECT
itineration.yitineration							as [Eserc. miss.],
itineration.nitineration							as [Num. miss.],
itineration.description								as [Descrizione],
itineration.location								as [Località],
manager.title										as [Responsabile],
itinerationstatus.description						as [Stato],
registry.title										as [Denom. Percipiente],
registry.extmatricula								as [Matricola],
position.description								as [Posizione Giuridica],
format(itineration.start,	'dd-MM-yyyy')			as [Data inizio],
format(itineration.stop,	'dd-MM-yyyy')			as [Data fine],
format(itineration.adate,	'dd-MM-yyyy')			as [Data contabile],
itineration.total									as [Costo Totale],
itineration.totadvance								as [Anticipo],
IR.linkedangir+IR.linkedanpag						as [Anticipo Erogato],
(case when linkedsaldo>0 
	then IR.linkedsaldo+IR.linkedanpag 
	else IR.linkedanpag+IR.linkedangir
end) 												as [Totale Erogato],
IR.totalgross-
(case when linkedsaldo>0 
	then IR.linkedsaldo+IR.linkedanpag 
	else IR.linkedanpag+IR.linkedangir 
end)												as [Residuo da erogare],
itineration.datecompleted							as [Data Doc. Definitiva],
upb.codeupb											as [Codice UPB],
authmodel.title										as [Modello Autorizzativo],
itineration.vehicle_info							as [Dati della macchina],
itineration.vehicle_motive							as [Motivazione uso della macchina],
itineration.applierannotations						as [Appunti per il pagamento],
convert(varchar(max),itineration.txt)				as [Appunti inseriti da Easy]
FROM itineration						with (nolock)	
JOIN registry							with (nolock)	ON registry.idreg = itineration.idreg
LEFT OUTER JOIN legalstatuscontract L1	with (nolock)	ON L1.idreg = itineration.idreg AND L1.idregistrylegalstatus = itineration.idregistrylegalstatus 
LEFT OUTER JOIN position				with (nolock)	ON position.idposition=L1.idposition
LEFT OUTER JOIN itinerationstatus		with (nolock)	ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus
LEFT OUTER JOIN manager					with (nolock)	ON manager.idman = itineration.idman
LEFT OUTER JOIN authmodel				with (nolock)	ON authmodel.idauthmodel = itineration.idauthmodel
LEFT OUTER JOIN upb						with (nolock)	ON upb.idupb = itineration.idupb
join itinerationresidual  IR			with (nolock)	on IR.iditineration= itineration.iditineration
where 

itineration.iditinerationstatus	=  6  -- sono nello stato di approvata  iditinerationstatus=6
AND itineration.flagweb			= 'S' -- sono state inserite tramite web   flagweb='S'
AND itineration.active			= 'S' -- sono utilizzabili per le contabilizzazione  active = 'S'
AND itineration.flagoutside		<>'S' -- le missioni su fondi esterni non vanno trasmesse
--AND itineration.iditineration not in (select iditineration from itinerationsorting)

/*
AND (
		(IR.totalgross-(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end) > 0 )	-- 1. hanno un residuo da erogare derivante dall'anticipo o dal rendiconto totresidual > 0
		OR 
		( 
		 (IR.totalgross-(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end)) = 0 -- 2. non hanno un residuo da erogare derivante dall'anticipo
			 AND  (convert(varchar(max),itineration.txt) is null) --  e hanno il campo “Appunti per il pagamento” vuoto (in questo campo l’ufficio contabile aggiungerà manualmente il numero dell’impegno di riferimento)
		 AND itineration.iditineration not in (select iditineration from itinerationsorting)
		) 
	)
*/

AND (
			-- Una missione è da trattare se:

			--se c’è un anticipo da erogare
			((IR.totadvance > IR.linkedangir+IR.linkedanpag) and (IR.residual > 0)) 
			
			OR
			--se è stata approvata e non ancora impegnata ( NB non contabilizzata )
			(
			(itineration.iditinerationstatus	=  6 )
			AND
			(convert(varchar(max),itineration.txt) is null) --  e hanno il campo “Appunti per il pagamento” vuoto (in questo campo l’ufficio contabile aggiungerà manualmente il numero dell’impegno di riferimento)
			AND 
			(itineration.iditineration not in (select iditineration from itinerationsorting))
			)

			OR
			--se è stato inserito un rendiconto e non è stata ancora pagata.
			((IR.totadvance = IR.linkedangir+IR.linkedanpag) and (IR.residual > 0) and itineration.completed ='S') 
		
	)

	

AND ((isnull(itineration.idsor01,UPB.idsor01)=@idsor01 ) OR (@idsor01 is NULL) OR (@all_sorkind01 ='S'))
AND	((isnull(itineration.idsor02,UPB.idsor02)=@idsor02 ) OR (@idsor02 is NULL) OR (@all_sorkind02 ='S'))
AND ((isnull(itineration.idsor03,UPB.idsor03)=@idsor03 ) OR (@idsor03 is NULL) OR (@all_sorkind03 ='S'))
AND	((isnull(itineration.idsor04,UPB.idsor04)=@idsor04 ) OR (@idsor04 is NULL) OR (@all_sorkind04 ='S'))
AND	((isnull(itineration.idsor05,UPB.idsor05)=@idsor05 ) OR (@idsor05 is NULL) OR (@all_sorkind05 ='S'))
order by 1 desc ,2 asc






-- ESCE SE NON CI SONO MISSIONI DA VISUALIZZARE
if (select count(*) from #missioni )= 0 RETURN


----------------------------------------------------------------------
-- set xml top table td's
-- create html table object for: #agent_job_step_error_report
set @xml_missioni=
 cast(
 (select
isnull([Eserc. miss.]				,'') as 'td' , '',
isnull([Num. miss.]					,'') as 'td' , '',
isnull([Descrizione]				,'') as 'td' , '',						
isnull([Località]					,'') as 'td' , '',			
isnull([Responsabile]				,'') as 'td' , '',			
isnull([Stato]						,'') as 'td' , '',					
isnull([Denom. Percipiente]			,'') as 'td' , '',	
isnull([Matricola]					,'') as 'td' , '',				
isnull([Posizione Giuridica]		,'') as 'td' , '',	
isnull([Data inizio]				,'') as 'td' , '',			
isnull([Data fine]					,'') as 'td' , '',				
isnull([Data contabile]				,'') as 'td' , '',		
isnull([Costo Totale]				,'') as 'td' , '',			
isnull([Anticipo]					,'') as 'td' , '',			
isnull([Anticipo Erogato]			,'') as 'td' , '',	
isnull([Totale Erogato]				,'') as 'td' , '',	
isnull([Residuo da erogare]			,'') as 'td' , '',	
isnull([Codice UPB]					,'') as 'td' , '',		
isnull([Modello Autorizzativo]		,'') as 'td' , '',	
isnull([Appunti per il pagamento]	,'') as 'td' , '',	
isnull([Appunti inseriti su Easy]	,'') as 'td' , ''
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
 <h1>Controllo eseguito in data: '  + convert(varchar,format(convert(date,getdate()),'dd-MM-yyyy')) + '  Utente: ' + @idcustomuser + ' Ruolo: ' + @title + '
 <table border = 1>
 <tr>
<th> Eserc. miss.				</th>
<th> Num. miss.					</th>
<th> Descrizione				</th>
<th> Località					</th>
<th> Responsabile				</th>
<th> Stato						</th>
<th> Denom. Percipiente			</th>
<th> Matricola					</th>
<th> Posizione Giuridica		</th>
<th> Data inizio				</th>
<th> Data fine					</th>
<th> Data contabile				</th>
<th> Costo Totale				</th>
<th> Anticipo					</th>
<th> Anticipo Erogato			</th>
<th> Totale Erogato				</th>
<th> Residuo da erogare			</th>
<th> Codice UPB					</th>
<th> Modello Autorizzativo		</th>
<th> Appunti per il pagamento	</th>
<th> Appunti inseriti su Easy	</th>
 </tr>'

 
select  @body_missioni = @body_missioni + isnull(@xml_missioni,'Non ho trovato nuove missioni')

-- amministrazione.[sp_alert_email_conto_terzi]
---------------------------------------------------------------------
-- send email.
 
EXEC msdb.dbo.sp_send_dbmail
  @profile_name = 'notifiche.easy@unict.it'
, @recipients = @email
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


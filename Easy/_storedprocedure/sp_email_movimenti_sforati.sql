/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

IF  exists (SELECT * FROM  dbo.sysobjects WHERE id = object_id(N'[sp_email_movimenti_sforati]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_email_movimenti_sforati]
GO

--setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE   PROCEDURE  [sp_email_movimenti_sforati]
(
	@email varchar(100) = 'your-email@example.com'
)
AS

BEGIN

--setuser setuser 'amministrazione'


declare @ayear int
	set @ayear = (select year(getdate()))

declare @adate datetime
	set @adate = (select getdate())

---------------------------------------------------------------------
-- create conditions for html tables in top and mid sections of email.
 
declare @xml_contratti NVARCHAR(MAX)
--declare @xml_mid NVARCHAR(MAX)
declare @body_contratti NVARCHAR(MAX)
--declare @body_mid NVARCHAR(MAX)
declare @message_subject  NVARCHAR(MAX)

declare @currdb_name varchar(70)
declare @currserver_name varchar(70)
SELECT @currdb_name = DB_NAME(), @currserver_name = @@SERVERNAME 

set @message_subject = 'Situazione Movimenti con importo incoerente tra esercizi calcolato in data: ' + convert(varchar,convert(datetime,GETDATE())) + '( DB: ' + @currdb_name + ' - Server : '+ @currserver_name +')'
print @message_subject
 
DECLARE @StringSql nvarchar(max)
SET @StringSql = 
'select   E1.idepexp, '+
  'E.nphase, E.yepexp, E.nepexp, '+
  'E1.ayear ''Anno1'', '+
  'E2.ayear ''Anno2'', '+
  'case when E.nphase = 2 then isnull(E1.curramount, 0)+ isnull(E1.curramount2, 0)+ isnull(E1.curramount3, 0)+ isnull(E1.curramount4, 0)+ isnull(E1.curramount5, 0)- ('+
  '  case when E.flagvariation = ''N'' then ISNULL(E1.cost, 0) else - ISNULL(E1.cost, 0) end'+
  ') ELSE isnull(E1.available, 0)+ isnull(E1.available2, 0)+ isnull(E1.available3, 0)+ isnull(E1.available4, 0)+ isnull(E1.available5, 0) END as ''Disponibile Anno1'', '+
  'case when E.nphase = 2 then isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) else isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) '+
  'end as ''Importo Anno2'', '+
  'case when E.nphase = 2 then isnull(E1.curramount, 0)+ isnull(E1.curramount2, 0)+ isnull(E1.curramount3, 0)+ isnull(E1.curramount4, 0)+ isnull(E1.curramount5, 0)- ('+
  '  case when E.flagvariation = ''N'' then ISNULL(E1.cost, 0) else - ISNULL(E1.cost, 0) end'+
  ') ELSE isnull(E1.available, 0)+ isnull(E1.available2, 0)+ isnull(E1.available3, 0)+ isnull(E1.available4, 0)+ isnull(E1.available5, 0) END - case when E.nphase = 2 then isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) else isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) '+
  'end as ''Errore'' '+
'from '+
  'epexptotal E1 with (nolock) '+
  'JOIN epexp E ON E1.idepexp = E.idepexp '+
  'left JOIN epexpyear E2 with (nolock) ON E1.idepexp = E2.idepexp '+
  'and E1.ayear + 1 = E2.ayear '+
  'LEFT JOIN epexptotal E2T with (nolock) ON E1.idepexp = E2T.idepexp '+
  'and E1.ayear + 1 = E2T.ayear '+
'WHERE '+
  'E1.ayear < YEAR( GETDATE()) '+
  'and e1.ayear > YEAR(GETDATE())-2 '+
  'AND ('+
  '  case when E.nphase = 2 then isnull(E1.curramount, 0)+ isnull(E1.curramount2, 0)+ isnull(E1.curramount3, 0)+ isnull(E1.curramount4, 0)+ isnull(E1.curramount5, 0)- ('+
  '    case when E.flagvariation = ''N'' then ISNULL(E1.cost, 0) else - ISNULL(E1.cost, 0) end'+
  '  ) ELSE isnull(E1.available, 0)+ isnull(E1.available2, 0)+ isnull(E1.available3, 0)+ isnull(E1.available4, 0)+ isnull(E1.available5, 0) END'+
  ') - ('+
  '  case when E.nphase = 2 then isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) else isnull(E2.amount, 0)+ isnull(E2.amount2, 0)+ isnull(E2.amount3, 0)+ isnull(E2.amount4, 0)+ isnull(E2.amount5, 0) '+
  '  end'+
  ') > 0 '+
 -- 'and E1.curramount > 0 '+
'order by nphase, yepexp, nepexp, anno1'

print @StringSql

create table ##situazione
(
[idepexp]	varchar(max),
[nphase]			varchar(max),
[yepexp]	varchar(max),
[nepexp]	varchar(max),
[Anno1]			varchar(max),
[Anno2]		varchar(max),
[Disponibile Anno1]	varchar(max),
[Importo Anno2]	varchar(max),
[Errore]		varchar(max)
)


	
		
		insert  into ##situazione  
		EXEC sp_executesql 
		@stmt = @StringSql



set @xml_contratti =
 cast(
 (select
isnull([idepexp],'') as 'td' , ''
,isnull([nphase],'') as 'td' , ''
,isnull([yepexp],'') as 'td' , ''
,isnull([nepexp],'') as 'td' , ''
,isnull([Anno1],'') as 'td' , ''
,isnull([Anno2],'') as 'td' , ''
,isnull(	replace([Disponibile Anno1],'.',',')				,'') as 'td' , ''
,isnull(	replace([Importo Anno2],'.',',')		,'') as 'td' , ''
,isnull(	replace([Errore],'.',',')			,'') as 'td' , ''

 from ##situazione

 for xml path('tr')
 , elements)
 as NVARCHAR(MAX)
 )
 

set @body_contratti =
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
 background-color: ROYALBLUE;
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
 <table border = 1>
 <tr>
<th> idepexp	</th>
<th> nphase	</th>
<th> yepexp	</th>
<th> nepexp  	</th>
<th> Anno1	</th>
<th> Anno2 </th>
<th> Disponibile Anno1 </th>
<th> Importo Anno2 </th>
<th> Errore </th>
 </tr>'
 
select  @body_contratti = @body_contratti + isnull(@xml_contratti,'Non sono riuscito a generare la stampa')

DECLARE @Column1Name VARCHAR(255)
--SET @Column1Name = '[sep=;' + CHAR(13) + CHAR(10) + 'Codice Conto]'
SET @Column1Name = '[Codice Conto]'
DECLARE @query_to_csv varchar(max)

set @query_to_csv = 'set nocount on;
	select
	isnull([idepexp],'''')  AS '+ @Column1Name + '
	,isnull([nphase],'''') AS [nphase]
	,isnull([yepexp],'''') AS [yepexp]
	,isnull([nepexp],'''') AS [nepexp]
	,isnull([Anno1],'''') AS [Anno1]
	,isnull([Anno1],'''') AS [Anno1]
	,''"'' + replace(replace(replace(replace(isnull([Disponibile Anno1],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile Anno1]
	,''"'' + replace(replace(replace(replace(isnull([Importo Anno2],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''		AS [Importo Anno2]
	,''"'' + replace(replace(replace(replace(isnull([Errore],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Errore]
	 from ##situazione;
	 set nocount off;'

declare @separatore char(1)
set @separatore = char(9)
declare @c int
select @c = (Select count(*) from ##situazione)
print @c
select @message_subject = CONVERT(varchar(10), @c)+' Errori - '+@message_subject

IF (@c) > 0
EXEC msdb.dbo.sp_send_dbmail
 @profile_name = 'your-email@example.com'
, @recipients = @email --'your-email@example.com'--; your-email@example.com; your-email@example.com; your-email@example.com'
, @subject = @message_subject
, @body = @body_contratti
, @body_format = 'HTML'
, @query = @query_to_csv
, @attach_query_result_as_file = 1
, @query_result_separator = @separatore
, @query_result_no_padding = 1
, @query_attachment_filename = 'situazione.csv';
 

drop table ##situazione

END


GO



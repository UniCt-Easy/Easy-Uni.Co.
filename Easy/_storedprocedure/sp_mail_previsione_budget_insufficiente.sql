
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sp_mail_previsione_budget_insufficiente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_mail_previsione_budget_insufficiente]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [sp_mail_previsione_budget_insufficiente](
	
	@email varchar(100)
)
AS

declare @ayear int
set @ayear = year(getdate())


BEGIN
----------------------------------------------------------------------
-- create conditions for html tables in top and mid sections of email.
 
declare @xml_contratti NVARCHAR(MAX)
declare @body_contratti NVARCHAR(MAX)
declare @message_subject  NVARCHAR(MAX)
declare @currdb_name varchar(70)
declare @currserver_name varchar(70)
SELECT @currdb_name = DB_NAME(), @currserver_name = @@SERVERNAME 

set @message_subject = 'Monitoraggio Previsione budget insufficiente in data: ' + convert(varchar, getdate(), 105) + '( DB: ' + @currdb_name + ' - Server : '+ @currserver_name +')'

/* PORZIONE DI CODICE PRESA DALLA STORED PROCEDURE exp_situazioneupbaccount_SUN */

CREATE TABLE ##previsioni(
		tipo_mov_budget varchar(100),
		idupb varchar(36), 
		codeupb varchar(50), 
		upb varchar(150), 
		idacc varchar(38), 
		codeacc varchar(50),
		account  varchar(150), 
		prevcorrente decimal(19,2),
		totalefasereale decimal(19,2),
		totalefaseTotalizzatore decimal(19,2),
		prevdisponibilesufaseReale decimal(19,2), 
		prevdisponibilesufaseTotalizzatore decimal(19,2), 
		fase int
)


-- DB che usano gli impegni di budget
	INSERT INTO ##previsioni(
		tipo_mov_budget,
		idupb, 
		codeupb, 
		upb , 
		idacc, 
		codeacc,
		account,
		prevcorrente,
		totalefasereale,
		totalefaseTotalizzatore,
		prevdisponibilesufaseReale, 
		prevdisponibilesufaseTotalizzatore, 
		fase 
		 )
	exec exp_previsione_budget_insufficiente @ayear , 'N',null, null


if ((select count(*) from ##previsioni) =0)
Begin
	drop table ##previsioni

	RETURN --  se non ci sono dati, non invia la mail.
End

declare @message_toolong  NVARCHAR(MAX)
set @message_toolong = ""

if ((select count(*) from ##previsioni) >800)
Begin
	set @message_toolong = char(13)+"Le dimensioni del file allegato o dei risultati sono superiori al valore consentito, per cui non verranno visualizzate tutte le righe. "+
				"Eseguire l'esportazione da programma per visualizzare tutti i risultati."
End

DECLARE @StringSelect nvarchar(4000)


	SET @StringSelect = 
	' SELECT top 800' +
'		tipo_mov_budget , '+
'		idupb  , '+
'		codeupb  , '+
'		upb   , '+
'		idacc  , '+
'		codeacc  , '+
'		account  , '+
'		prevcorrente  , '+
'		totalefasereale , '+
'		totalefaseTotalizzatore , '+
'		prevdisponibilesufaseReale , '+ 
'		prevdisponibilesufaseTotalizzatore , '+
'		fase  '
 
 
DECLARE @StringFrom nvarchar(2000)
SET @StringFrom = 
' FROM ##previsioni  ' 
/*GENERAZIONE DEL TABELLA PER LA EMAIL */

DECLARE @Column1Name VARCHAR(255)
SET @Column1Name = '[idupb]'
DECLARE @query_to_csv varchar(max)

create table ##situazione(
	[tipo_mov_budget] varchar(max),  
	[idupb] varchar(max),   
	[codeupb] varchar(max),   
	[upb] varchar(max),   
	[idacc] varchar(max),   
	[codeacc] varchar(max),  
	[account] varchar(max),  
	[prevcorrente] varchar(max),  
	[totalefasereale] varchar(max),  
	[totalefaseTotalizzatore] varchar(max),  
	[prevdisponibilesufaseReale] varchar(max),   
	[prevdisponibilesufaseTotalizzatore] varchar(max),   
	[fase]	varchar(max)		 
)


PRINT   @StringSelect
PRINT   @StringFrom

DECLARE @StringSql NVARCHAR(4000) 
SET @StringSql =@StringSelect + @StringFrom

	insert  into ##situazione	
	EXEC sp_executesql	
	@stmt = @StringSql

-- set xml top table td's
-- create html table object for: #agent_job_step_error_report

		set @xml_contratti =
		 cast(
		 (select top 800
			isnull([tipo_mov_budget],'') as 'td' , ''
			,isnull([idupb],'') as 'td' , ''
			,isnull([Codeupb],'') as 'td' , ''
			,isnull([upb],'') as 'td' , ''
			,isnull([idacc],'') as 'td' , ''
			,isnull([Codeacc],'') as 'td' , ''
			,isnull([account],'') as 'td' , ''

			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[prevcorrente]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[totalefasereale]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''

			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[totalefaseTotalizzatore]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[prevdisponibilesufaseReale]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''

			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[prevdisponibilesufaseTotalizzatore]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([fase],'') as 'td' , ''
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
		 <H3>' + @message_subject +  '</H3>
		 <h5>' + @message_toolong+ '</h5>
		 <table border = 1>
		 <tr>
		<th>Tipo mov.Budget </th>  
		<th>idupb </th>   
		<th>Cod.UPB </th>   
		<th>UPB  </th>   
		<th>idacc </th>   
		<th>Cod.Conto </th>  
		<th>Conto </th>  
		<th>Prev.Corrente </th>  
		<th>Totale Fase Reale </th>  
		<th>Totale Fase Totalizzatore </th>  
		<th>Prev. disponibile su fase Reale </th>   
		<th>Prev. disponibile su fase Totalizzatore </th>   
		<th>Fase </th>   
		 </tr>'
  
		select  @body_contratti = @body_contratti + isnull(@xml_contratti,'Non sono riuscito a generare la stampa')


		set @query_to_csv = 'set nocount on;
			select
			isnull([tipo_mov_budget],'''') AS [Tipo Mov.budget]
			,isnull([idupb],'''')  AS '+ @Column1Name + '
			,isnull([CodeUPB],'''') AS [Codice UPB]
			,isnull([UPB],'''') AS [UPB]
			,isnull([idacc],'''') AS [idacc]
			,isnull([codeacc],'''') AS [Cod.Acc]
			,isnull([account],'''') AS [Conto]

			,''"'' + replace(replace(replace(replace(isnull([prevcorrente],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Prev.Corrente ]
			,''"'' + replace(replace(replace(replace(isnull([totalefasereale],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Totale Fase Reale ]

			,''"'' + replace(replace(replace(replace(isnull([totalefaseTotalizzatore],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Totale Fase Totalizzatore ]
			,''"'' + replace(replace(replace(replace(isnull([prevdisponibilesufaseReale],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Prev. Disponibile su fase Reale ]
			,''"'' + replace(replace(replace(replace(isnull([prevdisponibilesufaseTotalizzatore],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Prevdisponibile su fase Totalizzatore ]
			,isnull([fase],'''') AS [Fase]

			 from ##situazione;
			 set nocount off;'




	 print '@query_to_csv:'
	 print @query_to_csv
declare @separatore char(1)
set @separatore = char(9)
declare @mittente varchar(100)
set @mittente = 'notifiche@temposrl.com'
IF EXISTS (select * from license where cf ='02044190615' )
Begin
	 set @mittente ='notifiche'
End
 
EXEC msdb.dbo.sp_send_dbmail
 @profile_name = @mittente
, @recipients = @email -- 'assistenzasw@temposrl.com'--'saradeca@inwind.it'--; carmela.luise@unicampania.it; Giovanni.RUSSO@unicampania.it; francesco.capruzzi@temposrl.com'
, @subject = @message_subject
, @body = @body_contratti
, @body_format = 'HTML'
, @query = @query_to_csv
, @attach_query_result_as_file = 1
, @query_result_separator = @separatore
, @query_result_no_padding = 1
, @query_attachment_filename = 'situazione.csv';
 
drop table ##previsioni
drop table ##situazione


END



go

	  --exec sp_mail_previsione_budget_insufficiente 'assistenzasw@temposrl.com'

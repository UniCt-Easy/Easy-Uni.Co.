
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sp_mail_limitidispesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_mail_limitidispesa]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [sp_mail_limitidispesa](
	
	@idupb varchar(36)='%',
	@email varchar(100)
)
AS

BEGIN
----------------------------------------------------------------------
-- create conditions for html tables in top and mid sections of email.
 
declare @xml_contratti NVARCHAR(MAX)
--declare @xml_mid NVARCHAR(MAX)
declare @body_contratti NVARCHAR(MAX)
--declare @body_mid NVARCHAR(MAX)
declare @message_subject  NVARCHAR(MAX)

set @message_subject = 'Monitoraggio limiti di costo in data: ' + convert(varchar, getdate(), 101)

/* PORZIONE DI CODICE PRESA DALLA STORED PROCEDURE exp_situazioneupbaccount_SUN */

CREATE TABLE ##situazione_limiti(
	idupbP varchar(36), codeupbP varchar(50), limit_amountP decimal(19,2), epexpamountP  decimal(19,2), 
	disp_epexpamountP decimal(19,2),
	entryamountP decimal(19,2), disp_entryamountP decimal(19,2),
	amount_reserveP decimal(19,2),
	perc_impegnatoP NVARCHAR(MAX),  perc_costiP NVARCHAR(MAX),
	idupbF varchar(36), codeupbF varchar(50), limit_amountF decimal(19,2), epexpamountF  decimal(19,2), 
	disp_epexpamountF decimal(19,2),
	entryamountF decimal(19,2), disp_entryamountF decimal(19,2),
	amount_reserveF decimal(19,2),
	perc_impegnatoF NVARCHAR(MAX),  perc_costiF NVARCHAR(MAX),
)
declare @flagepexp char(1)
select @flagepexp = flagepexp from config where ayear =  year(getdate())
if(@flagepexp='S')
Begin
-- DB che usano gli impegni di budget
	INSERT INTO ##situazione_limiti(
		idupbP, codeupbP, limit_amountP, epexpamountP , perc_impegnatoP, disp_epexpamountP, 
		entryamountP , perc_costiP, disp_entryamountP,
		amount_reserveP ,
		  
		idupbF, codeupbF, limit_amountF, epexpamountF , perc_impegnatoF, disp_epexpamountF,
		entryamountF , perc_costiF, disp_entryamountF,
		amount_reserveF
		   )
	exec exp_upbmonthlycap
End
if(@flagepexp='N')
Begin
-- ai DB che NON usano gli impegni di budget nascondiamo le colonne Impegni e disp. a impegnare per evitare confusione
	INSERT INTO ##situazione_limiti(
		idupbP, codeupbP, limit_amountP, 
		entryamountP , perc_costiP, disp_entryamountP,
		amount_reserveP ,
		  
		idupbF, codeupbF, limit_amountF, 
		entryamountF , perc_costiF, disp_entryamountF,
		amount_reserveF)
	exec exp_upbmonthlycap
End

if ((select count(*) from ##situazione_limiti) =0)
Begin
	drop table ##situazione_limiti

	RETURN --  se non ci sono dati, non invia la mail.
End

DECLARE @StringSelect nvarchar(4000)

IF (@flagepexp = 'S') 
BEGIN
	SET @StringSelect = 
	' SELECT ' +
		' idupbP as ''Idupb'',		'+
		' codeupbP as ''Codice UPB'', '+
		' limit_amountP as ''Limite impostato (alla data)'','+
		' epexpamountP as ''Impegnato'', '+
		' perc_impegnatoP as ''perc_impegnatoP'', '+
		' case when idupbP is not null then  isnull(limit_amountP,0)-isnull(epexpamountP,0) '+
		' else null end as ''Disponibile ad impegnare'' ,'+
		' entryamountP as ''Costi'', '+
		' perc_costiP as ''perc_costiP'', '+
		' case when idupbP is not null then  isnull(limit_amountP,0)-isnull(entryamountP,0) '+
			' else null end as ''Disponibile per Costi'' ,'+
		' amount_reserveP as ''Riserva'','+

		' idupbF  as ''Idupb(figlia)'',	'+	
		' codeupbF  as ''Codice UPB figlia'', '+
		' limit_amountF  as ''Limite impostato (alla data)'',  epexpamountF  as ''Impegnato'', 	'+
		' perc_impegnatoF as ''perc_impegnatoF'', '+
		' case when idupbF is not null then  isnull(limit_amountF,0)-isnull(epexpamountF,0)  '+
			' else null end as ''Disponibile ad impegnare'' ,'+
		' entryamountF  as ''Costi'', 	 '+
		' perc_costiF as ''perc_costiF'', '+
		' case when idupbF is not null then isnull(limit_amountF,0)-isnull(entryamountF,0) '+
			' else null end as ''Disponibile per Costi'' ,'+
		' amount_reserveF  as ''Riserva'' '
END 
ELSE
BEGIN
	SET @StringSelect = 
		' select idupbP as ''Idupb'',		 '+
		' codeupbP as ''Codice UPB'',  '+
		' limit_amountP as ''Limite impostato (alla data)'',  '+
		' entryamountP as ''Costi'',  '+
		' perc_costiP as ''perc_costiP'', '+
		' case when idupbP is not null then  isnull(limit_amountP,0)-isnull(entryamountP,0)  '+
			' else null end as ''Disponibile per Costi'' , '+
		' amount_reserveP as ''Riserva'', '+

		' idupbF  as ''Idupb(figlia)'',		 '+
		' codeupbF  as ''Codice UPB figlia'',  '+
		' limit_amountF  as ''Limite impostato (alla data)'',   '+
		' entryamountF  as ''Costi'', 	  '+
		' perc_costiF as ''perc_costiF'', '+
		' case when idupbF is not null then isnull(limit_amountF,0)-isnull(entryamountF,0)  '+
			' else null end as ''Disponibile per Costi'' , '+
		' amount_reserveF  as ''Riserva'' '
	
END
 
 
DECLARE @StringFrom nvarchar(2000)
SET @StringFrom = 
' FROM ##situazione_limiti  ' 
/*GENERAZIONE DEL TABELLA PER LA EMAIL */

DECLARE @Column1Name VARCHAR(255)
SET @Column1Name = '[idupb]'
DECLARE @query_to_csv varchar(max)

create table ##situazione
(
[idupb]	varchar(max),		
[Codice UPB]			varchar(max),
[Limite impostato (alla data)]	varchar(max),	
[Impegnato]	varchar(max),		
[perc_impegnatoP]	varchar(max),		
[Disponibile ad impegnare]			varchar(max)	,		
[Costi]	varchar(max),	
[perc_costiP]	varchar(max),	
[Disponibile per Costi]		varchar(max),	
[Riserva]		varchar(max), 

[Idupb(figlia)]	varchar(max),
[Codice UPB figlia]			varchar(max),
[Limite impostato (alla data) UPB figlia]	varchar(max),
[Impegnato UPB figlia]	varchar(max),	
[perc_impegnatoF]	varchar(max),		
[Disponibile ad impegnare UPB figlia]			varchar(max)	,		
[Costi UPB figlia]	varchar(max),	
[perc_costiF]	varchar(max),	
[Disponibile per Costi UPB figlia]		varchar(max),	
[Riserva UPB figlia]		varchar(max), 
)
create table ##situazione_nobudget
(
[idupb]	varchar(max),		
[Codice UPB]			varchar(max),
[Limite impostato (alla data)]	varchar(max),	
[Costi]	varchar(max),	
[perc_costiP]	varchar(max),	
[Disponibile per Costi]		varchar(max),	
[Riserva]		varchar(max), 

[Idupb(figlia)]	varchar(max),
[Codice UPB figlia]			varchar(max),
[Limite impostato (alla data) UPB figlia]	varchar(max),
[Costi UPB figlia]	varchar(max),	
[perc_costiF]	varchar(max),	
[Disponibile per Costi UPB figlia]		varchar(max),	
[Riserva UPB figlia]		varchar(max), 
)

PRINT   @StringSelect
PRINT   @StringFrom

DECLARE @StringSql NVARCHAR(4000) 
SET @StringSql =@StringSelect + @StringFrom
		
if(@flagepexp='S')
Begin
	insert  into ##situazione	
	EXEC sp_executesql	
	@stmt = @StringSql
End
else
Begin
print @StringSql
	insert  into ##situazione_nobudget
	EXEC sp_executesql	
	@stmt = @StringSql
End


-- set xml top table td's
-- create html table object for: #agent_job_step_error_report
if(@flagepexp='S')
Begin
		set @xml_contratti =
		 cast(
		 (select
			isnull([idupb],'') as 'td' , ''
			,isnull([Codice UPB],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Limite impostato (alla data)]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Impegnato]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_impegnatoP],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile ad impegnare]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Costi]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_costiP],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile per Costi]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Riserva]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([Idupb(figlia)],'') as 'td' , ''
			,isnull([Codice UPB figlia],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Limite impostato (alla data) UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Impegnato UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_impegnatoF],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile ad impegnare UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Costi UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_costiF],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile per Costi UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Riserva UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
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
		<th> idupb </th>
		<th> Codice UPB </th>
		<th> Limite impostato (alla data) </th>
		<th> Impegnato </th>
		<th> % Impegnato </th>
		<th> Disponibile ad impegnare </th>
		<th> Costi </th>
		<th> % Costi </th>
		<th> Disponibile per Costi </th>
		<th> Riserva </th>

		<th> Idupb(figlia) </th>
		<th> Codice UPB figlia </th>
		<th> Limite impostato (alla data) UPB figlia </th>
		<th> Impegnato UPB figlia </th>
		<th> % Impegnato UPB figlia </th>
		<th> Disponibile ad impegnare UPB figlia </th>
		<th> Costi UPB figlia </th>
		<th> % Costi UPB figlia </th>
		<th> Disponibile per Costi UPB figlia </th>
		<th> Riserva UPB figlia </th>
		 </tr>'
  
		select  @body_contratti = @body_contratti + isnull(@xml_contratti,'Non sono riuscito a generare la stampa')


		set @query_to_csv = 'set nocount on;
			select
			isnull([idupb],'''')  AS '+ @Column1Name + '
			,isnull([Codice UPB],'''') AS [Codice UPB]
			,''"'' + replace(replace(replace(replace(isnull([Limite impostato (alla data)],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Limite impostato (alla data) ]
			,''"'' + replace(replace(replace(replace(isnull([Impegnato],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Impegnato ]
			,''"'' + replace(replace(replace(replace(isnull([perc_impegnatoP],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% impegnato ]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile ad impegnare],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile ad impegnare ]
			,''"'' + replace(replace(replace(replace(isnull([Costi],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Costi ]
			,''"'' + replace(replace(replace(replace(isnull([perc_costiP],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% Costi ]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile per Costi],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile per Costi ]
			,''"'' + replace(replace(replace(replace(isnull([Riserva],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Riserva ]

			,isnull([Idupb(figlia)],'''')  AS [Idupb(figlia)] 
			,isnull([Codice UPB figlia],'''') AS [Codice UPB figlia]
			,''"'' + replace(replace(replace(replace(isnull([Limite impostato (alla data) UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Limite impostato (alla data) UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Impegnato UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Impegnato UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([perc_impegnatoF],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% impegnato UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile ad impegnare UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile ad impegnare UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Costi UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Costi UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([perc_costiF],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% Costi UPB figlia]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile per Costi UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile per Costi UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Riserva UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Riserva UPB figlia ]

			 from ##situazione;
			 set nocount off;'
End
Else
Begin
		set @xml_contratti =
		 cast(
		 (select
			isnull([idupb],'') as 'td' , ''
			,isnull([Codice UPB],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Limite impostato (alla data)]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Costi]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_costiP],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile per Costi]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Riserva]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([Idupb(figlia)],'') as 'td' , ''
			,isnull([Codice UPB figlia],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Limite impostato (alla data) UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Costi UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,isnull([perc_costiF],'') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Disponibile per Costi UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
			,replace(replace(replace(CONVERT(varchar(15), CONVERT(money, isnull(convert(decimal(19,2),[Riserva UPB figlia]),0.0)), 1),'.','v'),',','.'),'v',',') as 'td' , ''
		 from ##situazione_nobudget
		 for xml path('tr')
		 , elements)
		 as NVARCHAR(MAX)
		 )
   --print @xml_contratti --- TEST
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
		<th> idupb </th>
		<th> Codice UPB </th>
		<th> Limite impostato (alla data) </th>
		<th> Costi </th>
		<th> % Costi </th>
		<th> Disponibile per Costi </th>
		<th> Riserva </th>

		<th> Idupb(figlia) </th>
		<th> Codice UPB figlia </th>
		<th> Limite impostato (alla data) UPB figlia </th>
		<th> Costi UPB figlia </th>
		<th> % Costi UPB figlia </th>
		<th> Disponibile per Costi UPB figlia </th>
		<th> Riserva UPB figlia </th>
		 </tr>'
  
		select  @body_contratti = @body_contratti + isnull(@xml_contratti,'Non sono riuscito a generare la stampa')


		set @query_to_csv = 'set nocount on;
			select
			isnull([idupb],'''')  AS '+ @Column1Name + '
			,isnull([Codice UPB],'''') AS [Codice UPB]
			,''"'' + replace(replace(replace(replace(isnull([Limite impostato (alla data)],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Limite impostato (alla data) ]
			,''"'' + replace(replace(replace(replace(isnull([Costi],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Costi ]
			,''"'' + replace(replace(replace(replace(isnull([perc_costiP],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% Costi ]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile per Costi],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile per Costi ]
			,''"'' + replace(replace(replace(replace(isnull([Riserva],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Riserva ]

			,isnull([Idupb(figlia)],'''')  AS [Idupb(figlia)] 
			,isnull([Codice UPB figlia],'''') AS [Codice UPB figlia]
			,''"'' + replace(replace(replace(replace(isnull([Limite impostato (alla data) UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Limite impostato (alla data) UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Costi UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Costi UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([perc_costiF],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [% Costi UPB figlia]
			,''"'' + replace(replace(replace(replace(isnull([Disponibile per Costi UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Disponibile per Costi UPB figlia ]
			,''"'' + replace(replace(replace(replace(isnull([Riserva UPB figlia],0.00),''.'','',''),char(10), ''''),char(13), ''''),char(9), '''') + ''"''			AS [Riserva UPB figlia ]

			 from ##situazione_nobudget;
			 set nocount off;'
End

	 print '@query_to_csv:'
	 print @query_to_csv
declare @separatore char(1)
set @separatore = char(9)
 
EXEC msdb.dbo.sp_send_dbmail
 @profile_name = 'Notifiche'
, @recipients = @email -- 'assistenzasw@temposrl.com'--'saradeca@inwind.it'--; carmela.luise@unicampania.it; Giovanni.RUSSO@unicampania.it; francesco.capruzzi@temposrl.com'
, @subject = @message_subject
, @body = @body_contratti
, @body_format = 'HTML'
, @query = @query_to_csv
, @attach_query_result_as_file = 1
, @query_result_separator = @separatore
, @query_result_no_padding = 1
, @query_attachment_filename = 'situazione.csv';
 
drop table ##situazione_limiti
drop table ##situazione
drop table ##situazione_nobudget

END



go

	-- exec sp_mail_limitidispesa '%','assistenzasw@temposrl.com'

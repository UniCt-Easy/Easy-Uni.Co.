
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[count_contract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_contract]
GO



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--input @kind= C occasionale  o P professionale
CREATE  PROCEDURE [count_contract](
	@ayear 		smallint,
	@kind 		char(1),
	@idreg		int,
	@res int out
) as 
begin

create table #mytable (nrows int)
declare @iddbdepartment varchar(50)
declare @currstmt nvarchar(1000)

declare @num int

declare @cursore cursor
set @cursore = cursor for select distinct iddbdepartment from dbaccess
open @cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
--	print @iddbdepartment
	if (@kind='C')
		SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.casualcontract' +
					' where ycon = '+convert(varchar(20),@ayear)+' and idreg= '+convert(varchar(20),@idreg)
	else
		SET @currstmt= 'SELECT  COUNT(*) FROM '+ @iddbdepartment + '.profservice' +
					' where ycon = '+convert(varchar(20),@ayear)+' and idreg= '+convert(varchar(20),@idreg)

	insert into #mytable exec sp_executesql @currstmt
	if (select max(nrows) from #mytable)>0 break
	delete from #mytable 
	fetch next from @cursore into @iddbdepartment	
end

SET @res= ISNULL((SELECT max(nrows) from #mytable), 0)
drop table #mytable
--print @res
end
go



-- GENERAZIONE DATI PER audit --
IF exists(SELECT * FROM [audit] WHERE idaudit = 'OCCAS015')
UPDATE [audit] SET consequence = null,flagsystem = 'N',lt = {ts '2008-10-01 12:42:43.487'},lu = 'SA',severity = 'W',title = 'OCCAS015- Pagamento di un professionista con una prestazione occasionale' WHERE idaudit = 'OCCAS015'
ELSE
INSERT INTO [audit] (idaudit,consequence,flagsystem,lt,lu,severity,title) VALUES ('OCCAS015',null,'N',{ts '2008-10-01 12:42:43.487'},'SA','W','OCCAS015- Pagamento di un professionista con una prestazione occasionale')
GO

IF exists(SELECT * FROM [audit] WHERE idaudit = 'PROFE005')
UPDATE [audit] SET consequence = null,flagsystem = 'N',lt = {ts '2008-10-01 12:41:51.893'},lu = 'SA',severity = 'W',title = 'PROFE005 - Pagamento di un professionista che ha svolto anche prestazioni occasionali nell''anno' WHERE idaudit = 'PROFE005'
ELSE
INSERT INTO [audit] (idaudit,consequence,flagsystem,lt,lu,severity,title) VALUES ('PROFE005',null,'N',{ts '2008-10-01 12:41:51.893'},'SA','W','PROFE005 - Pagamento di un professionista che ha svolto anche prestazioni occasionali nell''anno')
GO

-- FINE GENERAZIONE SCRIPT --



-- GENERAZIONE DATI PER auditcheck --
IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'OCCAS015' AND idcheck = '1' AND opkind = 'I' AND tablename = 'casualcontract')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2008-10-01 12:27:54.253'},lu = 'SA',message = 'Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione professionale. Probabilmente non si sta usando il modulo corretto per l''inserimento di questa prestazione.',precheck = 'S',sqlcmd = '[execute count_contract %<sys_esercizio>%,
	''P'',  
	%<casualcontract.idreg>% ,
	@outvar output]{I}=0' WHERE idaudit = 'OCCAS015' AND idcheck = '1' AND opkind = 'I' AND tablename = 'casualcontract'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('OCCAS015','1','I','casualcontract','S','S','S','N','N',{ts '2008-10-01 12:27:54.253'},'SA','Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione professionale. Probabilmente non si sta usando il modulo corretto per l''inserimento di questa prestazione.','S','[execute count_contract %<sys_esercizio>%,
	''P'',  
	%<casualcontract.idreg>% ,
	@outvar output]{I}=0')
GO

IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'OCCAS015' AND idcheck = '2' AND opkind = 'I' AND tablename = 'casualcontract')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2008-10-01 12:23:28.190'},lu = 'SA',message = 'Il prestatore d''opera ha una partita iva quindi è un professionista. Verificare che la prestazione non debba quindi essere inquadrata come prestazione professionale.',precheck = 'S',sqlcmd = '[select isnull(p_iva,'''') from registry where idreg= %<casualcontract.idreg>%]{C} =''''' WHERE idaudit = 'OCCAS015' AND idcheck = '2' AND opkind = 'I' AND tablename = 'casualcontract'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('OCCAS015','2','I','casualcontract','S','S','S','N','N',{ts '2008-10-01 12:23:28.190'},'SA','Il prestatore d''opera ha una partita iva quindi è un professionista. Verificare che la prestazione non debba quindi essere inquadrata come prestazione professionale.','S','[select isnull(p_iva,'''') from registry where idreg= %<casualcontract.idreg>%]{C} =''''')
GO

IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'OCCAS015' AND idcheck = '1' AND opkind = 'U' AND tablename = 'casualcontract')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2008-10-01 12:47:01.783'},lu = 'SA',message = 'Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione professionale. Probabilmente non si sta usando il modulo corretto per l''inserimento di questa prestazione.',precheck = 'S',sqlcmd = '[execute count_contract %<sys_esercizio>%,
	''P'',  
	%<casualcontract.idreg>% ,
	@outvar output]{I}=0

or

%<casualcontract.idreg>% =&<casualcontract.idreg>&' WHERE idaudit = 'OCCAS015' AND idcheck = '1' AND opkind = 'U' AND tablename = 'casualcontract'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('OCCAS015','1','U','casualcontract','S','S','S','N','N',{ts '2008-10-01 12:47:01.783'},'SA','Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione professionale. Probabilmente non si sta usando il modulo corretto per l''inserimento di questa prestazione.','S','[execute count_contract %<sys_esercizio>%,
	''P'',  
	%<casualcontract.idreg>% ,
	@outvar output]{I}=0

or

%<casualcontract.idreg>% =&<casualcontract.idreg>&')
GO

IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'PROFE005' AND idcheck = '1' AND opkind = 'I' AND tablename = 'profservice')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2008-10-01 12:47:47.610'},lu = 'SA',message = 'Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione occasionale. E'' possibile che non si stia usando il modulo corretto per l''effettuazione di questa prestazione.',precheck = 'S',sqlcmd = '[execute count_contract %<sys_esercizio>%,
	''C'',  
	%<profservice.idreg>% ,
	@outvar output]{I}=0
' WHERE idaudit = 'PROFE005' AND idcheck = '1' AND opkind = 'I' AND tablename = 'profservice'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('PROFE005','1','I','profservice','S','S','S','N','N',{ts '2008-10-01 12:47:47.610'},'SA','Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione occasionale. E'' possibile che non si stia usando il modulo corretto per l''effettuazione di questa prestazione.','S','[execute count_contract %<sys_esercizio>%,
	''C'',  
	%<profservice.idreg>% ,
	@outvar output]{I}=0
')
GO

IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'PROFE005' AND idcheck = '1' AND opkind = 'U' AND tablename = 'profservice')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2008-10-01 12:47:42.393'},lu = 'SA',message = 'Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione occasionale. E'' possibile che non si stia usando il modulo corretto per l''effettuazione di questa prestazione.',precheck = 'S',sqlcmd = '[execute count_contract %<sys_esercizio>%,
	''C'',  
	%<profservice.idreg>% ,
	@outvar output]{I}=0

or

%<profservice.idreg>% =&<profservice.idreg>&' WHERE idaudit = 'PROFE005' AND idcheck = '1' AND opkind = 'U' AND tablename = 'profservice'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('PROFE005','1','U','profservice','S','S','S','N','N',{ts '2008-10-01 12:47:42.393'},'SA','Il prestatore d''opera ha già svolto nell''anno, assunto dall''ateneo, una prestazione occasionale. E'' possibile che non si stia usando il modulo corretto per l''effettuazione di questa prestazione.','S','[execute count_contract %<sys_esercizio>%,
	''C'',  
	%<profservice.idreg>% ,
	@outvar output]{I}=0

or

%<profservice.idreg>% =&<profservice.idreg>&')
GO

-- FINE GENERAZIONE SCRIPT --


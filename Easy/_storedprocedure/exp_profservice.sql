
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_profservice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_profservice]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [exp_profservice]
	@adate datetime,
	@idreg int
AS BEGIN

-- exp_profservice 2011, 39563	
	

CREATE TABLE #profservice
(
	iddbdepartment varchar(50),
	--ayear int,
	ycon  int,
	ncon  int,
	start datetime,
	stop  datetime,
	ndays int,
	adate datetime,
	registry varchar(100),
	cf varchar(40),
	upb varchar(150),
	feegross decimal(19,2),
	service varchar(50),
	description varchar(150),
	ivakind varchar(50),
	yservreg int, 
	nservreg int,
	authneeded char(1)
)	   	

--DECLARE @ayearstr varchar(4)
--SET @ayearstr = CONVERT(varchar(4), @ayear)

DECLARE @adatestr varchar(25)
SET @adatestr = '{d ' + '''' + CONVERT(VARCHAR(4),datepart(yy,@adate)) + '-' + 
CONVERT(VARCHAR(2),replicate ('0', 2 - len(datepart(mm,@adate)))) + CONVERT (VARCHAR(2),datepart(mm,@adate)) + '-' + 
CONVERT(VARCHAR(2),replicate ('0', 2 - len(datepart(dd,@adate)))) + CONVERT (VARCHAR(2),datepart(dd,@adate)) + '''' + '}'

DECLARE @idregstr varchar(20)
IF @idreg IS NULL 
	SET @idregstr = ''
ELSE 
	SET @idregstr = 'and P.idreg = ' + CONVERT(varchar(10), @idreg)
	


declare @iddbdepartment varchar(50)
declare @currstmt nvarchar(2000)



declare @cursore cursor
set @cursore = cursor for select  iddbdepartment from dbdepartment
			   where (start is null or start <= year(@adate)) AND ( stop is null or stop >= year(@adate))
open @cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
 --print @iddbdepartment
 
SET @currstmt= 'SELECT  ' +  '''' + @iddbdepartment+ ''''  + ', ' +
               ' P.ycon  ,  P.ncon  ,  P.start ,  P.stop  ,  P.ndays , P.adate , ' +
               ' P.registry ,  ISNULL (R.cf,R.foreigncf), U.title, P.feegross, ' +
               ' P.service, P.description, P.ivakind, ' + 
				' P.authneeded, ' +
				' ( select yservreg from '+ @iddbdepartment + '.serviceregistry S '+
				' where S.idrelated = ''profservice§'' + convert(varchar(4),P.ycon) + ''§''  + convert(varchar(4),P.ncon) ), '+
				' ( select nservreg from '+ @iddbdepartment + '.serviceregistry S ' +
				' where S.idrelated = ''profservice§'' + convert(varchar(4),P.ycon) + ''§''  + convert(varchar(4),P.ncon) ) '+
 			   ' FROM '+ @iddbdepartment + '.profserviceview P' +
               ' JOIN registry R on R.idreg = P.idreg 
				 LEFT OUTER JOIN upb U on U.idupb = P.idupb ' + 
               ' WHERE P.start >= ' + @adatestr + @idregstr +
	           ' ORDER BY ' + ' P.ycon, P.ncon '



 --select @currstmt
 insert into #profservice 
 (iddbdepartment,
 -- ayear ,
  ycon  ,
  ncon  ,
  start ,
  stop  ,
  ndays ,
  adate , 
  registry ,
  cf,
  upb,
  feegross,
  service,
  description,
  ivakind,
  authneeded,
  yservreg,
  nservreg )
 exec sp_executesql @currstmt
 fetch next from @cursore into @iddbdepartment 
end

SELECT 
	iddbdepartment as 'Dipartimento',
	-- ayear as 'Eserc. Fiscale' ,
	ycon  as 'Eserc. Contratto',
	ncon  as 'Num. Contratto',
	start as 'Inizio',
	stop  as 'Fine',
	ndays as 'Giorni',
	adate as 'Data Cont.', 
	registry as 'Percipiente' ,
	cf as 'CF',
	description as 'Descrizione',
	feegross as 'Comp. Lordo',
	ivakind as 'Tipologia Iva',
	service as 'Prestazione',
	upb as 'UPB',
	yservreg as 'Eserc.Banca dati incarico',
	nservreg  as 'Num.Banca dati incarico',
	case when authneeded='X' then 'Autorizzazione non applicabile' 
	when authneeded ='S' then 'Autorizzazione'
	when authneeded ='N' then 'Non necessita autorizzazione'
end as 'Autorizzazione del soggetto per il compenso'
 FROM #profservice
DROP TABLE #profservice
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_casualcontract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_casualcontract]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE [exp_casualcontract]
	@ayear int,
	@adate datetime,
	@idreg int
AS BEGIN

-- exp_casualcontract 2014, {d '2014-12-31'}, 6398

CREATE TABLE #casualcontract
(
	iddbdepartment varchar(50),
	ayear int,
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
	taxableotheragency decimal(19,2),
	service varchar(50),
	description varchar(150),
	yservreg int, 
	nservreg int,
	authneeded char(1)
)	   	

DECLARE @ayearstr varchar(4)
SET @ayearstr = CONVERT(varchar(4), @ayear)

DECLARE @adatestr varchar(25)
SET @adatestr = '{d ' + '''' + CONVERT(VARCHAR(4),datepart(yy,@adate)) + '-' + 
CONVERT(VARCHAR(2),replicate ('0', 2 - len(datepart(mm,@adate)))) + CONVERT (VARCHAR(2),datepart(mm,@adate)) + '-' + 
CONVERT(VARCHAR(2),replicate ('0', 2 - len(datepart(dd,@adate)))) + CONVERT (VARCHAR(2),datepart(dd,@adate)) + '''' + '}'

DECLARE @idregstr varchar(20)
IF @idreg IS NULL 
	SET @idregstr = ''
ELSE 
	SET @idregstr = 'and C.idreg = ' + CONVERT(varchar(10), @idreg)

declare @iddbdepartment varchar(50)
declare @currstmt nvarchar(2000)


DECLARE @datestr VARCHAR(30)
IF @adate IS NOT NULL
	SET @datestr = 'C.start >= ' + @adatestr
ELSE
	SET @datestr = 'C.ayear =  ' + @ayearstr

	


declare @cursore cursor
set @cursore = cursor for select  iddbdepartment from dbdepartment
			    where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
open @cursore
fetch next from @cursore into @iddbdepartment

while @@fetch_status=0 begin
 --print @iddbdepartment
 
SET @currstmt=	'SELECT  ' +  '''' + @iddbdepartment+ ''''  + ', ' +
				' C.ayear , C.ycon  ,  C.ncon  ,  C.start ,  C.stop  ,  C.ndays , C.adate , ' +
				' C.registry ,  ISNULL (R.cf,R.foreigncf), C.upb, C.feegross, ' +
				' C.taxableotheragency, C.service, C.description, ' + 
				' C.authneeded, ' +
				' ( select yservreg from '+ @iddbdepartment + '.serviceregistry S '+
				' where S.idrelated = ''cascon§'' + convert(varchar(4),C.ycon) + ''§''  + convert(varchar(4),C.ncon) ), '+
				' ( select nservreg from '+ @iddbdepartment + '.serviceregistry S ' +
				' where S.idrelated = ''cascon§'' + convert(varchar(4),C.ycon) + ''§''  + convert(varchar(4),C.ncon) ) '+
 				'  FROM '+ @iddbdepartment + '.casualcontractview C' +
               ' JOIN registry R on R.idreg = C.idreg ' + 
               ' WHERE ' + @datestr  + @idregstr +
			   ' AND C.ayear = (SELECT MAX(C2.ayear) FROM  ' + @iddbdepartment + '.casualcontractview C2
								WHERE C2.ycon = C.ycon
								AND C2.ncon = C.ncon)' +
		       ' ORDER BY ' + ' C.ycon, C.ncon '
		   
		   

 print @currstmt
 insert into #casualcontract 
 (iddbdepartment,
  ayear ,
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
  taxableotheragency,
  service,
  description,
  authneeded,
  yservreg,
  nservreg )
 exec sp_executesql @currstmt
 fetch next from @cursore into @iddbdepartment 
end

SELECT 
	iddbdepartment as 'Dipartimento',
	ayear as 'Eserc. Fiscale' ,
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
	taxableotheragency as 'Impon. Altri Enti',
	service as 'Prestazione',
	upb as 'UPB',
    yservreg as 'Eserc.Banca dati incarico',
	nservreg  as 'Num.Banca dati incarico',
	case when authneeded='X' then 'Autorizzazione non applicabile' 
		when authneeded ='S' then 'Autorizzazione'
		when authneeded ='N' then 'Non necessita autorizzazione'
end as 'Autorizzazione del soggetto per il compenso'	
 FROM #casualcontract
DROP TABLE #casualcontract
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



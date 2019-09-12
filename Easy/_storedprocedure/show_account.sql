if exists (select * from dbo.sysobjects where id = object_id(N'[show_account]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_account]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'

CREATE PROCEDURE [show_account]
(
	@adate datetime,
	@idacc varchar(38)
)
AS
BEGIN
	--	show_account '31-12-2016','%'
	CREATE TABLE #situazione (value varchar(250), amount decimal(19,2), kind char(1))

	insert into #situazione values ('Sede', null, 'H')
	insert into #situazione values ('Situazione al '+convert(varchar(10),@adate,105), null, 'H')

	if len(@idacc)>2
	begin
		insert into #situazione
			select accountlevel.description+' '+account.codeacc, null, 'H' 
			from account
			join accountlevel on accountlevel.nlevel=account.nlevel and accountlevel.ayear=account.ayear
			where account.idacc=@idacc

		insert into #situazione 
			select title, null, 'H'
			from account where idacc=@idacc

		insert into #situazione 
			select 'Esercizio '+cast(ayear as varchar(4)), null, 'H'
			from account
			where idacc=@idacc
	end else begin
		insert into #situazione values('Esercizio 20'+@idacc, null, 'H')
	end

	declare @identrykind int
	set @identrykind = 7

	declare @entrykind varchar(100)

	while @identrykind<>0
	begin
		if exists (select *
			from entry
			join entrydetail 
				on entrydetail.yentry=entry.yentry 
				and entrydetail.nentry=entry.nentry
			where entrydetail.idacc like @idacc+'%'
				and entry.identrykind=@identrykind
				and entry.adate<=@adate
				and entrydetail.amount<>0
				AND entry.yentry = year(@adate)
				)
		begin
			insert into #situazione values (null, null, 'N')
	
			insert into #situazione
				select 'Scritture '+case @identrykind when 1 then 'Normali' else 'di '+description end,
					null, 'N'
				from entrykind where identrykind=@identrykind
		
			insert into #situazione 
				select 'Dare',
					sum(-entrydetail.amount), ''
				from entry
				join entrydetail 
					on entrydetail.yentry=entry.yentry 
					and entrydetail.nentry=entry.nentry
				where entrydetail.idacc like @idacc+'%' 
					and entry.identrykind=@identrykind 
					and entrydetail.amount<0
					and entry.adate<=@adate
					AND entry.yentry = year(@adate)
		
			insert into #situazione 
				select 'Avere',	sum(entrydetail.amount), ''
				from entry
				join entrydetail 
					on entrydetail.yentry=entry.yentry 
					and entrydetail.nentry=entry.nentry
				where entrydetail.idacc like @idacc+'%'
					and entry.identrykind=@identrykind 
					and entrydetail.amount>0
					and entry.adate<=@adate
					AND entry.yentry = year(@adate)
		
			insert into #situazione 
				select 'Saldo', sum(entrydetail.amount), ''
				from entry
				join entrydetail 
					on entrydetail.yentry=entry.yentry 
					and entrydetail.nentry=entry.nentry
				where entrydetail.idacc like @idacc+'%'
					and entry.identrykind=@identrykind
					and entry.adate<=@adate
					AND entry.yentry = year(@adate)
		end
	
		set @identrykind = case @identrykind 
			when 7 then 1 
			when 6 then 0 
			else @identrykind+1 
		end
	end

--TIPO SCRITTURA NON SPECIFICATO
	if exists (select *
		from entry
		join entrydetail 
			on entrydetail.yentry=entry.yentry 
			and entrydetail.nentry=entry.nentry
		where entrydetail.idacc like @idacc+'%'
			and entry.identrykind is null
			and entry.adate<=@adate
			and entrydetail.amount<>0
			AND entry.yentry = year(@adate)
			)
	begin
		insert into #situazione values (null, null, 'N')

		insert into #situazione values('Scritture di tipo non specificato', null, 'N')
	
		insert into #situazione 
			select 'Dare',
				sum(-entrydetail.amount), ''
			from entry
			join entrydetail 
				on entrydetail.yentry=entry.yentry 
				and entrydetail.nentry=entry.nentry
			where entrydetail.idacc like @idacc+'%' 
				and entry.identrykind is null
				and entrydetail.amount<0
				and entry.adate<=@adate
				AND entry.yentry = year(@adate)
	
		insert into #situazione 
			select 'Avere',	sum(entrydetail.amount), ''
			from entry
			join entrydetail 
				on entrydetail.yentry=entry.yentry 
				and entrydetail.nentry=entry.nentry
			where entrydetail.idacc like @idacc+'%'
				and entry.identrykind is null
				and entrydetail.amount>0
				and entry.adate<=@adate
				AND entry.yentry = year(@adate)
	
		insert into #situazione 
			select 'Saldo', sum(entrydetail.amount), ''
			from entry
			join entrydetail 
				on entrydetail.yentry=entry.yentry 
				and entrydetail.nentry=entry.nentry
			where entrydetail.idacc like @idacc+'%'
				and entry.identrykind is null
				and entry.adate<=@adate
				AND entry.yentry = year(@adate)
	end
--TOTALI
	insert into #situazione values (null, null, 'N')
	insert into #situazione values ('TOTALE SCRITTURE', null, 'N')

	insert into #situazione 
		select 'DARE',
			sum(-entrydetail.amount), 'S'
		from entry
		join entrydetail 
			on entrydetail.yentry=entry.yentry 
			and entrydetail.nentry=entry.nentry
		where entrydetail.idacc like @idacc+'%'
			and entrydetail.amount<0
			and entry.adate<=@adate
			AND entry.yentry = year(@adate)

	insert into #situazione 
		select 'AVERE',
			sum(entrydetail.amount), 'S'
		from entry
		join entrydetail 
			on entrydetail.yentry=entry.yentry 
			and entrydetail.nentry=entry.nentry
		where entrydetail.idacc like @idacc+'%'
			and entrydetail.amount>0
			and entry.adate<=@adate
			AND entry.yentry = year(@adate)

	insert into #situazione 
		select 'SALDO',
			sum(entrydetail.amount), 'S'
		from entry
		join entrydetail 
			on entrydetail.yentry=entry.yentry 
			and entrydetail.nentry=entry.nentry
		where entrydetail.idacc like @idacc+'%'
			and entry.adate<=@adate
			AND entry.yentry = year(@adate)

	select * from #situazione
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


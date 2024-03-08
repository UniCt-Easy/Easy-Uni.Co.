
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_epilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_epilogo]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'

CREATE    procedure [compute_epilogo](
	@ayear int,
	@kind char(1),-- E: epilogo conto Economico, P: epilogo conti patrimoniali, R:Rilevazione risultato economico
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null 
)
as begin 

	declare @idaccPL varchar(38)-- Conto che pareggia l'epilogo dei conti economici 
	select @idaccPL = idacc_pl from config where ayear = @ayear

	declare @idaccPAT varchar(38)-- Conto che pareggia l'epilogo dei conti patrimoniali
	select @idaccPAT = idacc_patrimony from config where ayear = @ayear 

	declare @idacc_risultatoesercizio varchar(38) -- Conto di risultato esercizio
	select @idacc_risultatoesercizio = idacc_economic_result from config where ayear = @ayear

	declare @idaccToUse varchar(38)

	DECLARE @MyTable table(amount decimal(19,2), idacc varchar(38), idaccmotive varchar(36), idepexp int, idepacc int, idupb varchar(36), idreg int,idrelated varchar(100))
	-- Epilogo dei conti economici
	-- Nel caso dell'Epilogo del Risultato Economico, non dobbiamo valorizzare idaccmotive, idepexp nei dettagli scritture. Idem per R = Rilevazione risultato economico
	if(@kind='E')
	Begin
		set @idaccToUse= @idaccPL		
		insert into @MyTable(amount , idacc , idaccmotive , idepexp , idepacc ,
		idupb , idreg) --,idrelated
		SELECT -SUM(ED.amount), ED.idacc, null, null ,  null,
			case when flag&2 =0 then ED.idupb else null end,  
			case when flag&1 =0  then ED.idreg else null end --,
			--case when flag&32<>0 then ED.idrelated else null end
		FROM entrydetail ED 
		JOIN account ACC 			ON ED.idacc = ACC.idacc
		 WHERE ED.yentry = @ayear 			and ACC.ayear = @ayear			and ACC.idplaccount is not null
		 GROUP BY ED.idacc,  
			(case when flag&2 =0 then ED.idupb else null end),
			 (case when flag&1 =0  then ED.idreg else null end)--,
			 --(case when flag&32<>0 then ED.idrelated else null end)
			 having SUM(ED.amount)<>0 
	End

	-- Epilogo conti patrimoniali
	-- Nell'epilogo dei conti patrimoniali dobbiamo valorizzare idaccmotive(solo se idepexp è valorizzato) e idepexp dai dettagli scritture
	if(@kind='P')
	Begin
		set @idaccToUse= @idaccPAT
		insert into @MyTable(amount, idacc, /*idaccmotive,*/ idepexp, idepacc, idupb, idreg, idrelated) --,idrelated
		SELECT -SUM(ED.amount), ED.idacc, 
		/*case WHEN (flag&8 =0 and (ED.idepexp is not null or ED.idepacc is not null) ) then ED.idaccmotive ELSE null END,  */
		case when (flag&8 =0) then ED.idepexp else null end ,    
		case when (flag&8 =0) then ED.idepacc else null end ,   
		case when flag&2 =0	  then ED.idupb else null end ,  
		case when (flag&1 =0) then ED.idreg else null end ,
		case when (flag&32<>0) then ED.idrelated else null end 
		 FROM entrydetail ED 
		 JOIN account ACC 			ON  ED.idacc = ACC.idacc
		 WHERE  ED.yentry = @ayear					and ACC.ayear = @ayear 			and ACC.idpatrimony is not null
		 GROUP BY ED.idacc, /* (CASE WHEN (flag&8 =0  and (ED.idepexp is not null or ED.idepacc is not null))  THEN ED.idaccmotive ELSE null END), */
		 (case when (flag&2 =0) then ED.idupb else null end),
		 (case when (flag&1 =0) then ED.idreg else null end),    
		 (case when (flag&8 =0) then ED.idepexp else null end) ,    
		 (case when (flag&8 =0) then ED.idepacc else null end),
		 (case when (flag&32<>0) then ED.idrelated else null end)         
		 having SUM(ED.amount)<>0 
	End
	if(@kind='R')
	Begin
		set @idaccToUse= @idacc_risultatoesercizio
		insert into @MyTable(amount, idacc,  idupb, idreg)
		SELECT -SUM(ED.amount) AS amount, ED.idacc, 
             case when ACC.flag&2 =0 then U.idupb else null end as idupb , 
             case when ACC.flag&1 =0 then ED.idreg else null end as idreg 			 
             FROM entrydetail ED 
             JOIN account ACC               ON ED.idacc = ACC.idacc
			 left outer join UPB UPB_associati on ED.idupb = UPB_associati.idupb 
             left outer join UPB U on U.idupb  = ISNULL(UPB_associati.idupb_capofila,UPB_associati.idupb) 
             WHERE ED.yentry = @ayear		and ACC.ayear = @ayear		and ED.idacc = @idaccPL
             GROUP BY ED.idacc, 
							(case when ACC.flag&2 =0  then U.idupb else null end), 
							 ( case when ACC.flag&1 =0 then ED.idreg else null end)
             having SUM(ED.amount)<>0 
	End

	DECLARE @max_nentry int
	SELECT @max_nentry = MAX(nentry) FROM entry	WHERE yentry = @ayear
	IF (@max_nentry IS NULL) SET @max_nentry = 0

	DECLARE @31dicembre smalldatetime
	SET @31dicembre= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)

	declare @identrykind int
	declare @description_entry varchar(150)
	declare @use_idreg char(1)
	declare @use_idupb char(1)
	set @use_idreg = 'S'
	set @use_idupb = 'S'

	if ( isnull((select flag&1 from account where idacc=@idaccToUse),0)<>0 ) set @use_idreg='N'
	if ( isnull((select flag&2 from account where idacc=@idaccToUse),0)<>0 ) set @use_idupb='N'

	--set @use_idreg = isnull( (select flagregistry from account where idacc = @idaccToUse),'N')
	--set @use_idupb = isnull((select flagupb from account where idacc = @idaccToUse),'N')


	if(@kind='E') 
		Begin 
			set @identrykind = 11
			set @description_entry = 'Scrittura di epilogo esercizio ' + convert(varchar(4),@ayear) + ' (conto economico)'
		
		end

	if(@kind='P') 
		Begin
			set @identrykind = 12
			set @description_entry = 'Scrittura di epilogo esercizio ' + convert(varchar(4),@ayear) + ' (stato patrimoniale)'
		End
	
	if(@kind='R') 
		Begin
			set @identrykind = 10
			set @description_entry = 'Scrittura di epilogo esercizio ' + convert(varchar(4),@ayear) + '	(rilevazione risultato economico)'
		End
	
	if( (select count(*) from @MyTable) = 0) 		RETURN;

	INSERT into entry(nentry, yentry, adate, identrykind, description, locked, idsor01, idsor02, idsor03, idsor04, idsor05, official, ct, cu, lt, lu)
	select @max_nentry+1, @ayear, @31dicembre, @identrykind, @description_entry,
		'N', @idsor01, @idsor02, @idsor03, @idsor04, @idsor05,'S',
		getdate(), 'compute_epilogo',getdate(), 'compute_epilogo'
	
	/* Se la query restituisce , @description_entryrighe, crea una scrittura
	 di tipo 11 per Epilogo Conti Economici, descrizione = Scrittura di epilogo esercizio @ayear (conto economico)
	 di tipo 12 per Epilogo Conti Patrimoniali, , descrizione = Scrittura di epilogo esercizio @ayear (stato patrimoniale)
	*/

	-- Legge il conto @idaccPAT e @idaccPL e controlloo se nella scrittura debba scrivere anche l'idreg e l'upb, ossia flagregistry e flagupb

	-- Nell'Epilogo dei conti economici non dobbiamo valorizzare causale e impegno di budget
	-- Quindi per ogni idacc della query, con idacc diverso da   @idaccPAT o @idaccPL, a seconda dell'epilogo, crea i dettagli scrittura positivi e negativi

	DECLARE @MyEntrydetail table(
		nentry int,
		yentry int,
		ndetail int identity(1,1), 
		amount decimal(19,2),
		idacc varchar(38),
		idreg int,
		idupb varchar(36),
		idaccmotive varchar(36),
		description varchar(400),
		idepexp int ,
		idepacc int,
		idrelated varchar(100)
		 )

		insert into @MyEntrydetail (nentry, yentry, amount, idacc,	idreg ,	idupb,	idaccmotive,  idepexp,idepacc,idrelated)
		select @max_nentry+1, @ayear, T.amount, T.idacc, T.idreg, T.idupb,
			null, ---case when @kind='P' then T.idaccmotive else null end,
			case when @kind='P' then T.idepexp else null end,
			case when @kind='P' then T.idepacc else null end,
			T.idrelated
		from @MyTable T
		where (@kind='E' and T.idacc <> @idaccPL )
			OR (@kind ='P' and T.idacc <>@idaccPAT)
			OR (@kind ='R')

		insert into @MyEntrydetail (nentry, yentry, amount, idacc,	idreg ,	idupb,	idaccmotive,  idepexp,idepacc)
		select @max_nentry+1, @ayear, sum(-T.amount), 
			@idaccToUse,
			case when @use_idreg = 'S' then T.idreg else null end, 
			case when @use_idupb = 'S' then T.idupb else null end,
			null, --case when @kind='P' then T.idaccmotive else null end,
			case when @kind='P' then T.idepexp else null end,
			case when @kind='P' then T.idepacc else null end
			
		from @MyTable T
		group by
			 case when @use_idreg = 'S' then T.idreg else null end,
			 case when @use_idupb = 'S' then T.idupb else null end,
			 case when @kind='P' then T.idepexp else null end ,
			 case when @kind='P' then T.idepacc else null end
		
		insert into entrydetail(nentry, yentry, ndetail, amount, idacc,	idreg ,	idupb,	idaccmotive,  idepexp,idepacc, ct, cu, lt, lu,idrelated)
		select nentry, yentry, ndetail, amount, idacc,	idreg ,	idupb,	idaccmotive,  idepexp,idepacc, getdate(), 'compute_epilogo', getdate(),'compute_epilogo',idrelated
		from @MyEntrydetail
		where isnull(amount,0)<>0
End

GO

 

 


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- select * from entry where cu='compute_epilogo'
-- select * from entrydetail where cu='compute_epilogo'

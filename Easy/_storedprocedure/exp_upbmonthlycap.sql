
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


--setuser 'amministrazione'

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_upbmonthlycap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_upbmonthlycap]
GO

CREATE PROCEDURE [exp_upbmonthlycap]
	@ayear int = null,
	@adate datetime = null,
	@idupb varchar(36)='%',
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS BEGIN
	if (@ayear is null )
		set @ayear = year(getdate())  --- ANNO CORRENTE,  SE NON SPECIFICHIAMO UN ESERCIZIO IN INPUT
	if (@adate is null)	 set @adate = getdate()  --- L'ESPORTAZIONE   DEVE MOSTRARE LA SITUAZIONE AD OGGI, SE NON SPECIFICHIAMO UNA DATA IN INPUT
	declare @mesidaconteggiare int  
	set @mesidaconteggiare = month(@adate)
	--- LEGGO LA TABELLA ANNUALE DI CONFIGURAZIONE DEI LIMITI DI COSTO PER UPB. IL LIMITE MOSTRATO NELL'ESPORTAZIONE DEVE ESSERE CUMULATIVO, OVVERO 
	--- DEVE ESSERE CALCOLATO COME SOMMA DEI LIMITI DI TUTTI I MESI A PARTIRE DA GENNAIO FINO AL MESE CORRENTE
	--- IMPORTANTE: GLI UPB SU CUI E' IMPOSTATO UN LIMITE NON SONO NECESSARIAMENTE ESSI STESSI SOGGETTI AL LIMITE,
	--- MA VIENE ESPLICITAMENTE IMPOSTATO SU DI ESSI (AD ESEMPIO,  SOLO SUGLI UPB DIPARTIMENTO) 
	--- PER CONTROLLARE I COSTI DELLE UPB FIGLIE CHE DEVONO ESSERE SOGGETTE A LIMITE, CONTRASSEGNATE DA UN FLAG.
	create table #Tupb (idupb varchar(36), codeupb varchar(50), limit_amount decimal(19,2), amount_reserve decimal(19,2) )
	insert into #Tupb(idupb, codeupb, limit_amount, amount_reserve)
	select 
		M.idupb, U.codeupb,
		case when @mesidaconteggiare<=1 then isnull(M.amount_1,0) 
			 when @mesidaconteggiare<=2 then (isnull(M.amount_1,0) + isnull(M.amount_2,0))
			 when @mesidaconteggiare<=3 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0))
			 when @mesidaconteggiare<=4 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0))
			 when @mesidaconteggiare<=5 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0))
			 when @mesidaconteggiare<=6 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0))
			 when @mesidaconteggiare<=7 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0))
			 when @mesidaconteggiare<=8 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0)+ isnull(M.amount_8,0))
			 when @mesidaconteggiare<=9 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0)+ isnull(M.amount_8,0)+ isnull(M.amount_9,0))
			 when @mesidaconteggiare<=10 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0)+ isnull(M.amount_8,0)+ isnull(M.amount_9,0)+ isnull(M.amount_10,0))
			 when @mesidaconteggiare<=11 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0)+ isnull(M.amount_8,0)+ isnull(M.amount_9,0)+ isnull(M.amount_10,0)+ isnull(M.amount_11,0))
			 when @mesidaconteggiare<=12 then (isnull(M.amount_1,0) + isnull(M.amount_2,0) + isnull(M.amount_3,0) + isnull(M.amount_4,0)+ isnull(M.amount_5,0)+ isnull(M.amount_6,0)+ isnull(M.amount_7,0)+ isnull(M.amount_8,0)+ isnull(M.amount_9,0)+ isnull(M.amount_10,0)+ isnull(M.amount_11,0)+ isnull(M.amount_12,0))
		end,
		M.amount_reserve
	from upbmonthlycap M
	join upb U on M.idupb = U.idupb
	where M.ayear = @ayear
	and (@idsor01 = U.idsor01 or @idsor01 is null or U.idsor01 is null)
	and (@idsor02 = U.idsor02 or @idsor02 is null or U.idsor02 is null)
	and (@idsor03 = U.idsor03 or @idsor03 is null or U.idsor03 is null)
	and (@idsor04 = U.idsor04 or @idsor04 is null or U.idsor04 is null)
	and (@idsor05 = U.idsor05 or @idsor05 is null or U.idsor05 is null)


	-- TABELLA IMPEGNATO DI BUDGET DELLE UPB SOGGETTE A LIMITE, CONTRASSEGNATE DA UN FLAG
	-- I SOLI CONTI DI COSTO O IMMOBILIZZAZIONE DA CONSIDERARE SONO CONTRASSEGNATI DA FLAG
	create table #Tepexp (idupb varchar(36), epexpamount decimal(19,2))
	insert into #Tepexp(idupb, epexpamount)
	select EY.idupb, sum(ET.curramount)
	from  epexptotal ET
	join epexpyear EY on ET.idepexp = EY.idepexp and ET.ayear = @ayear
	join account A on A.idacc = EY.idacc
	join upb U on EY.idupb = U.idupb
	join upbyear UY on U.idupb = UY.idupb and UY.ayear = @ayear
	join epexp E on E.idepexp = EY.idepexp and E.nphase = 1
	where EY.ayear = @ayear 
		and EY.idupb like @idupb+'%' 
		and ((A.flag &64)<>0) /*CONTI SOGGETTI A LIMITE*/
		and (( A.flagaccountusage & 320) <> 0) -- 64 costi e 256 immobilizzazioni
		and  (UY.locked &4<>0) /*UPB SOGGETTI A LIMITE*/  and E.adate <=@adate
		and E.yepexp = @ayear
		and (@idsor01 = U.idsor01 or @idsor01 is null or U.idsor01 is null)
		and (@idsor02 = U.idsor02 or @idsor02 is null or U.idsor02 is null)
		and (@idsor03 = U.idsor03 or @idsor03 is null or U.idsor03 is null)
		and (@idsor04 = U.idsor04 or @idsor04 is null or U.idsor04 is null)
		and (@idsor05 = U.idsor05 or @idsor05 is null or U.idsor05 is null)
	group by  EY.idupb
	

	-- TABELLA COSTI (SOMMA DETTAGLI SCRITTURE DELL'ANNO CORRENTE) DELLE UPB SOGGETTE A LIMITE, CONTRASSEGNATE DA UN FLAG
	-- I SOLI CONTI DI COSTO O IMMOBILIZZAZIONE DA CONSIDERARE SONO CONTRASSEGNATI DA FLAG
	create table #Tentrydetail (idupb varchar(36), entryamount decimal(19,2))
	insert into #Tentrydetail(idupb, entryamount)
	select D.idupb, sum(D.amount)
	from entry E
	join entrydetail D on E.yentry = D.yentry and E.nentry = D.nentry
	join account A on A.idacc = D.idacc
	join upb  U on U.idupb = D.idupb
	join upbyear UY on U.idupb = UY.idupb and UY.ayear = @ayear
	where E.yentry = @ayear  
		and D.idupb like @idupb+'%'
		and ((A.flag &64)<>0) /*CONTI SOGGETTI A LIMITE*/
		and (( A.flagaccountusage & 320) <> 0) -- 64 costi e 256 immobilizzazioni
		and (UY.locked &4<>0) /*UPB SOGGETTI A LIMITE*/ 
		and E.adate <=@adate
		and (@idsor01 = U.idsor01 or @idsor01 is null or U.idsor01 is null)
		and (@idsor02 = U.idsor02 or @idsor02 is null or U.idsor02 is null)
		and (@idsor03 = U.idsor03 or @idsor03 is null or U.idsor03 is null)
		and (@idsor04 = U.idsor04 or @idsor04 is null or U.idsor04 is null)
		and (@idsor05 = U.idsor05 or @idsor05 is null or U.idsor05 is null)
	group by  D.idupb

	-- COSTRUIAMO LA TABELLA DEI SOLI PADRI A PARTIRE DALLA TABELLA MENSILE DI CONFIGURAZIONE. 
	-- SARANNO MOSTRATI SULLA PARTE SINISTRA DELL'ESPORTAZIONE, SOLO GLI UPB CONFIGURATI, DI MINIMO LIVELLO PER OGNI RAMO.
	-- POICHE' NELLA GERARCHIA DEGLI UPB NON ABBIAMO IL CONCETTO DI NUMERO DI LIVELLO, IL "PADRE" DI UN RAMO DI UPB CONFIGURATI
	-- VA CALCOLATO CON UN CICLO SULLA LUNGHEZZA DEL CODICE (MINIMO 4 CIFRE, AUMENTATO DI QUATTRO IN QUATTRO).
	-- SOLO SE NESSUN UPB GERARCHICAMENTE PRECEDENTE SIA GIA' STATO INSERITO COME "PADRE" IN UN PASSO PRECEDENTE,  
	-- NEL CICLO CORRENTE POSSIAMO ASSUMERE UPB CON CODICE  DELLA LUNGHEZZA CORRENTE COME "PADRE"
	create table #padri (idupbpadre varchar(36))
	declare @currlen int
	declare @minlen int 
	declare @maxlen int 
	select	@minlen= min(len(idupb)) from upbmonthlycap where ayear = @ayear
	select	@maxlen= max(len(idupb)) from upbmonthlycap where ayear = @ayear
	set		@currlen= @minlen
	while (@currlen<=@maxlen)
	Begin
			insert into #padri(idupbpadre)
			select  U.idupb  -- prende solo un padre di n figli
			from upbmonthlycap U
			where U.ayear = @ayear  and len(U.idupb ) = @currlen
			and not exists (select * from #padri where  U.idupb  like idupbpadre +'%' ) 
			and (@idupb+'%' like U.idupb+'%'  or @idupb ='%')
			set @currlen= @currlen+4
	end
 
 	--SELECT * FROM #padri
	-- TABELLA DEGLI IMPORTI TOTALIZZATI. SOLO  PER UPB "FIGLI" CON LIMITE ESPLICITAMENTE CONFIGURATO NELLA TABELLA MENSILE DI CONFIGURAZIONE 
	-- (CHE RAPPRESENTA UN "DI CUI" RISPETTO AL LIMITE DI UN UPB GERARCHICAMENTE SUPERIORE). 
	-- L'ESPORTAZIONE DEVE TOTALIZZARE GLI IMPORTI DELL'IMPEGNATO DI BUDGET E DELLE SCRITTURE DI COSTO NEL PERIODO,
	-- DI TUTTI I NODI SOTTOSTANTI, AVENTI FLAG "SOGGETTO A LIMITE", E MOSTRARE GLI IMPORTI TOTALI PER UN RAFFRONTO CON IL LIMITE CONFIGURATO. 
	-- LI INSERIAMO  IN UNA TABELLA TEMPORANEA A PARTE PERCHE' VANNO MOSTRATI IN COLONNE A DESTRA,
	-- SEPARATE QUINDI DA QUELLE DEI "PADRI"
	create table #FigliaAmount(idupbpadre varchar(36),idupb varchar(36), codeupb varchar(50), limit_amount decimal(19,2), epexpamount  decimal(19,2), entryamount decimal(19,2), amount_reserve decimal(19,2), capofila char(1))
	insert into #FigliaAmount(idupbpadre,  idupb, codeupb, limit_amount, epexpamount , entryamount, amount_reserve, capofila)
		select 
			(select idupbpadre from #padri P where Uc.idupb like P.idupbpadre+'%'),
			Uc.idupb,
			Uc.codeupb , 
			Uc.limit_amount , 
			(SELECT SUM(EP.epexpamount) FROM #Tepexp EP WHERE EP.idupb like Uc.idupb + '%') , 
			(SELECT SUM(ED.entryamount) FROM  #Tentrydetail ED WHERE ED.idupb like Uc.idupb + '%'),
			Uc.amount_reserve,
			'N'
	from #Tupb Uc
	where Uc.idupb not in (select idupbpadre from #padri)
	
	-- IMPOSTO UN ORDINAMENTO CON UPB "CAPOFILA" TRA I FIGLI, PERCHè NEL FILE EXCEL SOLO SU UN UPB DEVE ESSERE COMPILATO ANCHE CON I DATI IL PADRE, OVVERO IL PRIMO,
	-- NELLE RIGHE FIGLIE SUCCESSIVE LE INFORMAZIONI DEL PADRE NON DEVONO ESSERE RIPETUTE
	UPDATE #FigliaAmount 		SET capofila = 'S'	where idupb=(select top 1 idupb  from #FigliaAmount F where #FigliaAmount.idupbpadre = F.idupbpadre order by F.idupb )
	

	
	-- TABELLA DEGLI IMPORTI TOTALIZZATI. SOLO  PER UPB "PADRI" CON LIMITE ESPLICITAMENTE CONFIGURATO NELLA TABELLA MENSILE DI CONFIGURAZIONE. 
	-- L'ESPORTAZIONE DEVE TOTALIZZARE GLI IMPORTI DELL'IMPEGNATO DI BUDGET E DELLE SCRITTURE DI COSTO NEL PERIODO,
	-- DI TUTTI I NODI SOTTOSTANTI, AVENTI FLAG "SOGGETTO A LIMITE", E MOSTRARE GLI IMPORTI TOTALI PER UN RAFFRONTO CON IL LIMITE CONFIGURATO.
	-- LI INSERIAMO  IN UNA TABELLA TEMPORANEA A PARTE PERCHE' VANNO MOSTRATI IN COLONNE A SINISTRA,
	-- SEPARATE QUINDI DA QUELLE DEI "FIGLI"
	create table #PadreAmount(idupb varchar(36), codeupb varchar(50), limit_amount decimal(19,2), epexpamount  decimal(19,2), entryamount decimal(19,2), amount_reserve decimal(19,2))
	insert into #PadreAmount(idupb, codeupb, limit_amount, epexpamount , entryamount, amount_reserve)
		select 
			Up.idupb,
			Up.codeupb , 
			Up.limit_amount , 
			(SELECT SUM(EP.epexpamount) FROM #Tepexp EP WHERE EP.idupb like Up.idupb + '%') , 
			(SELECT SUM(ED.entryamount) FROM #Tentrydetail ED WHERE ED.idupb like Up.idupb + '%'),
			Up.amount_reserve
	from #Tupb Up 
	join #padri P on Up.idupb = P.idupbpadre
	--SELECT * FROM #FigliaAmount
	--SELECT * FROM #PadreAmount
	-- CREO QUESTA TABELLA PER RISPETTARE LO SCHEMA RICHIESTO IN OUTPUT, OVVERO SULLE COLONNE DI SINISTRA I "PADRI", MENTRE SULLE COLONNE DI DESTRA I "FIGLI" SOTTOSTANTI,
	-- IL CUI LIMITE RAPPRESENTA UN "DI CUI" DI QUELLO DEL "PADRE"

	create table #AllAmount(idupbP varchar(36), codeupbP varchar(50), limit_amountP decimal(19,2), epexpamountP  decimal(19,2), entryamountP decimal(19,2), amount_reserveP decimal(19,2),
							perc_impegnatoP decimal(19,6), perc_costiP decimal(19,6),
							idupbF varchar(36), codeupbF varchar(50), limit_amountF decimal(19,2), epexpamountF  decimal(19,2), entryamountF decimal(19,2), amount_reserveF decimal(19,2),
							perc_impegnatoF decimal(19,6), perc_costiF decimal(19,6))
	-- INSERISCO LE UPB CHE SONO SOLO PADRE, NON HANNO FIGLI, QUINDI DOBBIAMO COMPILARE SOLO LE PRIME COLONNE
	insert into #AllAmount(idupbP , codeupbP , limit_amountP, epexpamountP  , entryamountP, amount_reserveP, perc_impegnatoP,  perc_costiP)
	select idupb, codeupb, limit_amount, epexpamount , entryamount, amount_reserve,
			case when (limit_amount<>0) 
			then  convert(decimal(19,6), ( epexpamount	/limit_amount ) ) 
			else 0
		end, -- % impegnato del padre sul limite
		case when (limit_amount<>0) 
			then  convert(decimal(19,6), ( entryamount	/limit_amount ) ) 
			else 0
		end -- % Costi del padre sul limite
	from #PadreAmount
	where not exists (select * from #FigliaAmount F where F.idupb like #PadreAmount.idupb+'%' )
	
	-- INSERISCO UPB PADRI E UPB FIGLIE, SE UNA UPB HA PIU' FIGLI, I DATI DEL PADRE SARANNO SCRITTI SOLO SUL PRIMO FIGLIO
	insert into #AllAmount(idupbP , codeupbP , limit_amountP , epexpamountP  , entryamountP , amount_reserveP ,  perc_impegnatoP,  perc_costiP,
							idupbF , codeupbF , limit_amountF , epexpamountF  , entryamountF , amount_reserveF ,  perc_impegnatoF,  perc_costiF)
	select 
			case when F.capofila='S' then P.idupb else null end, 
			case when F.capofila='S' then P.codeupb else null end, 
			case when F.capofila='S' then P.limit_amount  else null end, 
			case when F.capofila='S' then P.epexpamount  else null end,  
			case when F.capofila='S' then P.entryamount else null end,  
			case when F.capofila='S' then P.amount_reserve else null end, 

			case when F.capofila='S' and (P.limit_amount<>0) then   convert(decimal(19,6), ( P.epexpamount/P.limit_amount ) )  else null end,  -- % impeganto padre
			case when F.capofila='S' and (P.limit_amount<>0)  then convert(decimal(19,6), ( P.entryamount/P.limit_amount ) )  else null end,  -- % costi padre

			F.idupb, 
			F.codeupb,	
			F.limit_amount, F.epexpamount , F.entryamount,F.amount_reserve,
			case when (F.limit_amount<>0) 
			then  convert(decimal(19,6), ( F.epexpamount/F.limit_amount ) ) 
			else 0
			end, -- % impegnato figlia
			case when (F.limit_amount<>0) 
			then  convert(decimal(19,6), ( F.entryamount/F.limit_amount ) ) 
			else 0
			end --- % costi figlia
	from #FigliaAmount F
	join #PadreAmount P on F.idupbpadre = P.idupb

	update #AllAmount set entryamountP=-entryamountP, entryamountF = -entryamountF,  
						perc_costiP = -perc_costiP,    perc_costiF=-perc_costiF
declare @flagepexp char(1)
select @flagepexp = flagepexp from config where ayear =  @ayear
 
--VISUALIZZO TUTTO
if (@flagepexp='S')
Begin
	select idupbP as 'Idupb',		
		codeupbP as 'Codice UPB', 
		limit_amountP as 'Limite impostato (alla data)', 
		epexpamountP as 'Impegnato', 
		format(perc_impegnatoP,'P2') as '% Impegnato', -- % impegnato del padre sul limite,
		case when idupbP is not null then  isnull(limit_amountP,0)-isnull(epexpamountP,0) 
			else null end as 'Disponibile ad impegnare' ,
		entryamountP as 'Costi', 
		format(perc_costiP,'P2') as '% Costi', -- % Costi del padre sul limite,
		case when idupbP is not null then  isnull(limit_amountP,0)-isnull(entryamountP,0) 
			else null 
		end as 'Disponibile per Costi' ,
		amount_reserveP as 'Riserva',

		idupbF  as 'Idupb(figlia)',		
		codeupbF  as 'Codice UPB figlia', 
		limit_amountF  as 'Limite impostato (alla data) UPB figlia',  
		epexpamountF  as 'Impegnato UPB figlia', 	

		format(perc_impegnatoF,'P2') as '% Impegnato UPB figlia', -- % Impegnato della figlia sul limite,

		case when idupbF is not null then  isnull(limit_amountF,0)-isnull(epexpamountF,0)  
			else null 
		end as 'Disponibile ad impegnare UPB figlia' ,
		entryamountF  as 'Costi UPB figlia', 
		format(perc_costiF,'P2') as '% Costi UPB figlia', -- % Costi della figlia sul limite,
		case when idupbF is not null then isnull(limit_amountF,0)-isnull(entryamountF,0) 
			else null end as 'Disponibile per Costi UPB figlia' ,
		amount_reserveF  as 'Riserva UPB figlia'
	from #AllAmount
End
if (@flagepexp='N')
Begin
	select idupbP as 'Idupb',		
		codeupbP as 'Codice UPB', 
		limit_amountP as 'Limite impostato (alla data)', 
		entryamountP as 'Costi',
		format(perc_costiP,'P2') as '% Costi', -- % Costi del padre sul limite,	
		case when idupbP is not null then  isnull(limit_amountP,0)-isnull(entryamountP,0) 
			else null end as 'Disponibile per Costi' ,
		amount_reserveP as 'Riserva',

		idupbF  as 'Idupb(figlia)',		
		codeupbF  as 'Codice UPB figlia', 
		limit_amountF  as 'Limite impostato (alla data) UPB figlia',  
		entryamountF  as 'Costi UPB figlia', 	
		format(perc_costiF,'P2') as '% Costi UPB figlia', -- % Costi della figlia sul limite,
		case when idupbF is not null then isnull(limit_amountF,0)-isnull(entryamountF,0) 
			else null end as 'Disponibile per Costi UPB figlia' ,
		amount_reserveF  as 'Riserva UPB figlia'
	from #AllAmount
End

	drop table #Tupb
	drop table #Tepexp
	drop table #Tentrydetail
	drop table #AllAmount
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 	 --EXEC exp_upbmonthlycap null, null, '%'
	--EXEC exp_upbmonthlycap null, null, '0001000300020005'
 --EXEC [sp_mail_limitidispesa] '%', 'mariasmal@tiscali.it'

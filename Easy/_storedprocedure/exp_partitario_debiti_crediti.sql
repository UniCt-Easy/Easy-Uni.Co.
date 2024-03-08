
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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



--@lista_id dbo.idrelated_list  READONLY 

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_partitario_debiti_crediti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_partitario_debiti_crediti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exp_partitario_debiti_crediti '2021', {d '2021-01-01'}, {d '2021-06-16'}, '6', null, 'E', null, '%', 'N', 'N', null, 'T','S'
CREATE PROCEDURE [exp_partitario_debiti_crediti]
(
	@ayear			int,
	@start			datetime,
	@stop			datetime,
	@nlevel 		varchar(1),
	@filterpatrimony 		varchar(50),
	@patpart char(1),
	@filteraccount varchar(50),
	@idupb		varchar(36),
	@showupb	char(1),
	@showchildupb	char(1),
	@idreg     int,
	@dockind varchar(1), -- T --> Tutti, P-->Professionali, D--> Altri compensi , M-->Missione, C->Cedolino, F --> Fattura, O--Occasionali, E-->Fondo economale, S-->Stipendi. L--Liquidazione iva
	-- B --> Contratti passivi, A--> Contratti attivi,
	@suppressifblank varchar(1) = 'N',
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
	AS
	--print @idupb
--	Esportazione dato patrimoniale dettagliato

--mostra anagrafica ma non raggruppa per anagrafica, raggruppa per idrelated
--mostra upb S ddeve stare il parametro 
--nascondi voci del piano dei conti non movimentate S fisso 

--escludi scritture epilogo S si
--solo scritture apertura N
--escludi scritture assestamento progetti pluriennali N
--raggruppa idrelated S
--non vogliamo vedere le cooordinate analitiche

-- aggiungere tipo documento, esercizio documento, numero documento, numero dettaglio, data documento, data apertura debito e credito
-- datascrittura date, importo iniziale debito (AVERE)decimal(19,2), residuo decimal(19,2)  (DARE MENO AVERE?? somma algebrica dettagli scritture)
-- (select sum(ed2.amount) from entrydetail ed2 
		--			join account A on ed2.idacc=A.idacc
		--			where ed2.idrelated=ed.idrelated and ed2.idacc=ed.idacc and (A.flagaccountusage & 16)<>0),
-- UPB non interessa. 
	BEGIN
	DECLARE @lista_id dbo.idrelated_list -- READONLY 
	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	-- Calcola la lunghezza del filtro in base ad nlevel		
SET @filteraccount = RTRIM(@filteraccount) --print @filteraccount
IF  @filteraccount = ''
BEGIN
	SELECT @filteraccount = NULL
END

DECLARE @lenfilteracc int
SET @lenfilteracc = DATALENGTH(RTRIM(ISNULL(@filteraccount,''))) --print @lenfilteracc

	CREATE TABLE #bilanciostatopatrimoniale(
		yoriginal int,
		adate datetime,
		idpatrimony	 	varchar(38), 
		idupb varchar(36),
		dare decimal(19,2),
		avere decimal(19,2),
		idacc varchar(38),
		codeacc varchar(50),
		account varchar(150), 
		nlevel char(1),
		idreg int,
		idsor1 int,idsor2 int,idsor3 int,
		idrelated varchar(100)
	)

	
-- Calcola la lunghezza del filtro in base ad nlevel		
	SET @filterpatrimony = RTRIM(@filterpatrimony) --print @filterpatrimony
	IF @filterpatrimony = ''
		SELECT @filterpatrimony = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filterpatrimony,''))) 
	--print @lenfilter
	
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+2  --print @newnlevel

	 
 


	INSERT INTO #bilanciostatopatrimoniale(
		adate,
		idpatrimony,
		idupb,
		dare,avere,
		idacc,
		nlevel,
		idreg,
		idrelated
		)
		SELECT 
		case when    entrydetail.idrelated is null then entry.adate else null end,
			patrimony.idpatrimony,		
			entrydetail.idupb,
			case when isnull(entrydetail.amount,0)<0 then entrydetail.amount else null end,
			case when isnull(entrydetail.amount,0)>0 then entrydetail.amount else null end,
			SUBSTRING(account.idacc, 1, @newnlevel),  	
			patrimony.nlevel,
			entrydetail.idreg,
			entrydetail.idrelated
		 --   CASE  --identrykind = 7 APERTURA
			--	WHEN (identrykind <> 7) THEN entrydetail.idrelated -- per le scritture non di APERTURA prendo idrelated scrittura stessa
			--	WHEN ((identrykind = 7) AND (entrydetail.idepexp IS NOT NULL) AND (entrydetail.idepacc IS NULL)) 
			--	THEN (SELECT idrelated FROM epexp where epexp.idepexp = entrydetail.idepexp ) --- per le aperture prendo idrelated impegno di budget OPPURE
			--	WHEN ((identrykind = 7) AND (entrydetail.idepacc IS NOT NULL) AND (entrydetail.idepexp IS NULL)) -- per le aperture prendo idrelated accertamento di budget
			--	THEN (SELECT idrelated FROM epacc where epacc.idepacc = entrydetail.idepacc ) --in tutti gli altri casi non metto niente (ad esempio se stanno valorizzati erroneamente impegno e accertamento di budget)
			--	ELSE NULL
			--END
		FROM entry
		JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc
		JOIN patrimony				ON patrimony.idpatrimony = account.idpatrimony
		JOIN upb					ON entrydetail.idupb = upb.idupb
		WHERE entry.yentry = @ayear				
			AND (entry.adate BETWEEN @start AND @stop)
			AND (entrydetail.idupb like @idupb  OR @idupb = '%' )
			AND (entrydetail.idreg like @idreg  OR @idreg is null )
			and (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			and (@patpart = 'E' or patrimony.patpart = @patpart)
			AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilteracc) = @filteraccount)
			AND (entry.identrykind not in (6,11,12) ) --DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			AND (((account.flagaccountusage & 16) <> 0)  --DEBITO
			OR ((account.flagaccountusage & 32) <> 0))  --CREDITO
			AND (@idsor01 IS NULL OR COALESCE (entry.idsor01, upb.idsor01)=@idsor01)  
			AND (@idsor01 IS NULL OR COALESCE (entry.idsor02, upb.idsor02)=@idsor02) 
			AND (@idsor01 IS NULL OR COALESCE (entry.idsor03, upb.idsor03)=@idsor03) 
			AND (@idsor01 IS NULL OR COALESCE (entry.idsor04, upb.idsor04)=@idsor04)  
			AND (@idsor01 IS NULL OR COALESCE (entry.idsor05, upb.idsor05)=@idsor05) 
			--AND entry.identrykind  = 7 -- da togliere, solo per test delle scritture di apertura
			--AND (entrydetail.idepacc IS NOT NULL) AND (entrydetail.idepexp IS NULL)
			--AND (entrydetail.idepexp IS not  NULL) AND (entrydetail.idepacc IS not NULL)
			----AND (entrydetail.idrelated like 'cascon%'  
			--  or entrydetail.idrelated like 'profservice%' 
			--  or entrydetail.idrelated like 'wageadd%' 
			--  or entrydetail.idrelated like 'itineration%'
			--  or entrydetail.idrelated like 'payroll%'
			--  or entrydetail.idrelated like 'inv%'
			--  or entrydetail.idrelated like 'man%'
			--  or entrydetail.idrelated like 'estim%'
			--  or entrydetail.idrelated like 'csaimport%' 
			--  or entrydetail.idrelated like 'ivapay%'
			--  or entrydetail.idrelated like 'foeco%' 
--)

--select * from #bilanciostatopatrimoniale where adate is not null
DECLARE	@delimiter_character CHAR(1) = 'ß'
INSERT INTO @lista_id  select distinct idrelated from #bilanciostatopatrimoniale   where idrelated IS NOT NULL   --AND idrelated   like 'csaimportß%'  AND idrelated NOT like '%csaimport%' --  like '%estim%'  OR  idrelated   like '%man%'  OR  idrelated   like '%inv%' OR  idrelated   like '%payroll%' OR  idrelated   like '%cascon%'
 
--Inserisce le voci non associate a Conti EP
INSERT INTO #bilanciostatopatrimoniale(
		idpatrimony,
		nlevel
		)
		SELECT 
			patrimony.idpatrimony ,
			patrimony.nlevel
		FROM patrimony
		WHERE (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			and patrimony.ayear = @ayear
			and (@patpart = 'E' or patrimony.patpart = @patpart)
			and (select count(*)  from patrimony P2
					where P2.paridpatrimony = patrimony.idpatrimony)=0
			and (select count(*)  from #bilanciostatopatrimoniale P
					where P.idpatrimony = patrimony.idpatrimony)=0
--select * from #bilanciostatopatrimoniale

--4) Se si usa il "Mostra UPB", nell'esportazione si chiede di visualizzare le seguenti ulteriori colonne:
--- il flagactivity dell'upb con la dicitura "Tipo attivit√† dell'UPB" e i valori Qualsiasi\Non specificata, Istituzionale o Commerciale
--- il codice tipo UPB con la dicitura "Tipo UPB"
--- il flagkind con la dicitura "Funzione dell'UPB" e i valori Didattica o Ricerca
--- la Data inizio
--- la Data fine
 --select *  from #bilanciostatopatrimoniale  where idrelated is not null ORDER BY idrelated
 -- select *  from #bilanciostatopatrimoniale  where idrelated is   null 
 --SELECT * FROM @lista_id
CREATE  TABLE #Tdrel (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
kind varchar(max), rifdoc varchar(max), docdate datetime, daterif datetime )
--select * from [fn_decode_idrelated_tab] (@lista_id) 
--select distinct  from @lista_id  where idrelated is null 
--select *  from @lista_id  where  
insert into #Tdrel
select * from [fn_decode_idrelated_tab] (@lista_id) 
IF (@showupb ='N')
BEGIN
	SELECT  
		registry.title as 'Anagrafica',
		registry.idreg as 'Cod.Anagrafica',
		account.codeacc as 'Codice conto',
		account.title	as 'Conto',
		#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.kind ELSE 'Imputazione generica' END as 'Tipo documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN	#Tdrel.rifdoc ELSE 'Imputazione generica'END  as 'Documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.docdate ELSE #bilanciostatopatrimoniale.adate  END as 'Data Documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.daterif ELSE #bilanciostatopatrimoniale.adate  END as 'Data apertura Debito e Credito',
		patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
		patrimony.patpart   as 'Parte schema ufficiale',
		patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
		sum(#bilanciostatopatrimoniale.dare) as 'Dare',
		sum(#bilanciostatopatrimoniale.avere) as 'Avere',
		sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo'
		FROM patrimony 
		join #bilanciostatopatrimoniale		on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
		join account						on #bilanciostatopatrimoniale.idacc = account.idacc
		left outer join registry			on #bilanciostatopatrimoniale.idreg = registry.idreg
		left outer join #Tdrel on #bilanciostatopatrimoniale.idrelated = #Tdrel.idrelated 
		WHERE patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
		GROUP BY registry.title, registry.idreg, account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title,
				#bilanciostatopatrimoniale.idrelated, #Tdrel.kind, #Tdrel.rifdoc,#Tdrel.daterif ,#Tdrel.docdate,#bilanciostatopatrimoniale.adate
		HAVING (sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0) AND
		(@suppressifblank = 'N'  OR (sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0))  <> 0))
		ORDER BY  registry.title, account.codeacc, #bilanciostatopatrimoniale.idrelated
END
IF (@showupb ='S')
BEGIN
	SELECT  
		registry.title as 'Anagrafica',
		registry.idreg as 'Cod.Anagrafica',
		account.codeacc as 'Codice conto',
		account.title	as 'Conto',
		#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.kind ELSE 'Imputazione generica' END as 'Tipo documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN	#Tdrel.rifdoc ELSE 'Imputazione generica' END  as 'Documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.docdate ELSE #bilanciostatopatrimoniale.adate   END as 'Data Documento',
		CASE WHEN (	#bilanciostatopatrimoniale.idrelated IS NOT NULL) THEN  #Tdrel.daterif ELSE #bilanciostatopatrimoniale.adate  END as 'Data apertura Debito e Credito',
		upb.codeupb	    as 'Codice UPB',
		upb.title		as 'UPB',
		CASE upb.flagactivity
					when 4 then 'Qualsiasi/Non specificata'
					when 1 then 'Istituzionale'
					when 2 then 'Commerciale'
		END  as 'Tipo attivit‡',
		epupbkind.description as 'Tipo UPB ai fini dell''Economico Patrimoniale',
		CASE upb.flagkind
				when 0 then 'Didattica'
				when 1 then 'Ricerca'
		END  as 'Funzione',
		upb.start as 'Data inizio',
		upb.stop  as 'Data fine', 
		patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
			patrimony.patpart   as 'Parte schema ufficiale',
		patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
		sum(#bilanciostatopatrimoniale.dare) as 'Dare',
		sum(#bilanciostatopatrimoniale.avere) as 'Avere',
		sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo'
		FROM patrimony 
		join #bilanciostatopatrimoniale 
			on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
		join account on #bilanciostatopatrimoniale.idacc = account.idacc
		left  outer join registry			on #bilanciostatopatrimoniale.idreg = registry.idreg
		left outer join upb					on #bilanciostatopatrimoniale.idupb = upb.idupb
		left outer join epupbkind 			on epupbkind.idepupbkind = upb.idepupbkind
		left outer join #Tdrel on #bilanciostatopatrimoniale.idrelated  = #Tdrel.idrelated  
		where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
		GROUP BY registry.title, registry.idreg, account.codeacc, account.title, patrimony.codepatrimony,patrimony.patpart, patrimony.title, 
		upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description, #bilanciostatopatrimoniale.idrelated,
		#Tdrel.kind, #Tdrel.rifdoc, #Tdrel.daterif   ,#Tdrel.docdate,#bilanciostatopatrimoniale.adate
		HAVING (sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0) AND
		(@suppressifblank = 'N'  OR (sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0))  <> 0) )
		ORDER BY  registry.title, account.codeacc
END
 

End -- fine sp
 
 
 

 






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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_debiti_crediti_anagrafica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_debiti_crediti_anagrafica]
GO
--select * from account
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exp_debiti_crediti_anagrafica '2023', {d '2023-10-27'}, '5', null, NULL, 'P', NULL,'A','T','S'
 
CREATE PROCEDURE [exp_debiti_crediti_anagrafica]
(
	@ayear					int,
	@stop					datetime,
	@nlevel 				varchar(1),
	@filterpatrimony 		varchar(50),
	@filteraccount			varchar(50),
	@patpart				char(1),
	@idreg					int,
	@kind					char(1), --'A' -- > Aggregata   'D' -- > Dettagliata
	@dockind varchar(1), -- T --> Tutti, P-->Professionali, D--> Altri compensi , M-->Missione, C->Cedolino, F --> Fattura, O--Occasionali, E-->Fondo economale, S-->Stipendi. L--Liquidazione iva
	-- B --> Contratti passivi, A--> Contratti attivi,
	@suppressifblank varchar(1) = 'N' 
)
	AS
	BEGIN
	DECLARE @lista_id dbo.idrelated_list   
	--print @idupb
-- Esportazione dato patrimoniale dettagliato
-- nascondi voci del piano dei conti non movimentate S/N, default N

-- escludi scritture epilogo S si
-- ESCLUDO I CONTI D'ORDINE
-- solo scritture apertura N
-- escludi scritture assestamento progetti pluriennali N
-- raggruppa idrelated S
-- non vogliamo vedere le cooordinate analitiche

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
		dare,avere,
		idacc,
		nlevel,
		idreg,
		idrelated
		)
		SELECT --TOP 200
		case when    entrydetail.idrelated is null then entry.adate else null end,
			patrimony.idpatrimony,		
			case when isnull(entrydetail.amount,0)<0 then entrydetail.amount else null end,
			case when isnull(entrydetail.amount,0)>0 then entrydetail.amount else null end,
			SUBSTRING(account.idacc, 1, @newnlevel),  	
			patrimony.nlevel,
			entrydetail.idreg,
			--isnull(entrydetail.idrelated, convert(varchar,entry.yentry) + '/' + convert(varchar,entry.nentry) + ' '+ entry.description )
		    CASE  --identrykind = 7 APERTURA
				WHEN (identrykind <> 7) THEN entrydetail.idrelated -- per le scritture non di APERTURA prendo idrelated scrittura stessa
				WHEN ((identrykind = 7) AND (entrydetail.idepexp IS NOT NULL) AND (entrydetail.idepacc IS NULL)) 
				THEN (SELECT idrelated FROM epexp where epexp.idepexp = entrydetail.idepexp ) --- per le aperture prendo idrelated impegno di budget OPPURE
				WHEN ((identrykind = 7) AND (entrydetail.idepacc IS NOT NULL) AND (entrydetail.idepexp IS NULL)) -- per le aperture prendo idrelated accertamento di budget
				THEN (SELECT idrelated FROM epacc where epacc.idepacc = entrydetail.idepacc ) --in tutti gli altri casi non metto niente (ad esempio se stanno valorizzati erroneamente impegno e accertamento di budget)
				ELSE NULL
			END
		FROM entry
		JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc
		JOIN patrimony				ON patrimony.idpatrimony = account.idpatrimony
		WHERE entry.yentry = @ayear				
			AND (entry.adate <= @stop)
			AND (entrydetail.idreg like @idreg  OR @idreg is null )
			and (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			and (@patpart = 'T' or patrimony.patpart = @patpart)
			AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilteracc) = @filteraccount)
			AND (entry.identrykind not in (6,11,12) ) --DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			AND (((account.flagaccountusage & 16) <> 0)  --DEBITO
			OR ((account.flagaccountusage & 32) <> 0))  --CREDITO
			--AND entry.identrykind  <> 7 -- da togliere, solo per test delle scritture di apertura
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
--
 
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
			and (@patpart = 'T' or patrimony.patpart = @patpart)
			and (select count(*)  from patrimony P2
					where P2.paridpatrimony = patrimony.idpatrimony)=0
			and (select count(*)  from #bilanciostatopatrimoniale P
					where P.idpatrimony = patrimony.idpatrimony)=0

--select * from #bilanciostatopatrimoniale

 --SELECT * FROM @lista_id

 IF (@kind = 'D')
 BEGIN
		DECLARE	@delimiter_character CHAR(1) = '§'
		INSERT INTO @lista_id  select distinct idrelated from #bilanciostatopatrimoniale   where idrelated IS NOT NULL   --AND idrelated   like 'csaimport§%'  AND idrelated NOT like '%csaimport%' --  like '%estim%'  OR  idrelated   like '%man%'  OR  idrelated   like '%inv%' OR  idrelated   like '%payroll%' OR  idrelated   like '%cascon%'

		CREATE  TABLE #Tdrel (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
		kind varchar(max), rifdoc varchar(max), docdate datetime, daterif datetime )
		--select * from [fn_decode_idrelated_tab] (@lista_id) 
		--select distinct  from @lista_id  where idrelated is null 
		--select *  from @lista_id  where  
		insert into #Tdrel
		select * from [fn_decode_idrelated_tab] (@lista_id) 

		--SELECT * FROM #Tdrel
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
			WHERE patrimony.ayear = @ayear and (@patpart = 'T' or patrimony.patpart = @patpart)
			GROUP BY registry.title, registry.idreg, account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title,
					#bilanciostatopatrimoniale.idrelated, #Tdrel.kind, #Tdrel.rifdoc,#Tdrel.daterif ,#Tdrel.docdate,#bilanciostatopatrimoniale.adate
			HAVING (sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0) AND
			(@suppressifblank = 'N'  OR (sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0))  <> 0))
			ORDER BY  registry.title, account.codeacc, #bilanciostatopatrimoniale.idrelated
 END

 ELSE
 BEGIN
 SELECT  
			registry.title as 'Anagrafica',
			registry.idreg as 'Cod.Anagrafica',
			account.codeacc as 'Codice conto',
			account.title	as 'Conto',
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
			WHERE patrimony.ayear = @ayear and (@patpart = 'T' or patrimony.patpart = @patpart)
			GROUP BY registry.title, registry.idreg, account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title
			HAVING (sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0) AND
			(@suppressifblank = 'N'  OR (sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0))  <> 0))
			ORDER BY  registry.title, account.codeacc  
 END
End -- fine sp
 
 
 

 






/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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



if OBJECTPROPERTY(object_id('exp_statopatrimoniale_dm2012_dett'), 'IsProcedure') = 1
	drop procedure exp_statopatrimoniale_dm2012_dett
go
-- setuser 'amministrazione' 
-- setuser 'amm'
CREATE  PROCEDURE [exp_statopatrimoniale_dm2012_dett]

	@ayear			int,
	@start			datetime,
	@stop			datetime,
	@nlevel 		varchar(1),
	@filterpatrimony 		varchar(50),
	@patpart char(1),
	@filteraccount varchar(50),
	@showidsor123	char(1),
	@idsor1 int,
	@showidsor1child char(1), 
	@idsor2 int,
	@idsor3 int,
	@suppressifblank 	char(1) ,
	@idupb		varchar(36),
	@showupb	char(1),
	@showchildupb	char(1),
	@showregistry	char(1),
	@flag_soloapertura char(1)='N',
	@flag_noepilogo char(1)='S',
	@flag_noassestamentoprogp char(1)='S',  -- no assestamento progetti pluriennali,
	@flag_idrelated char(1) = 'S'
	AS

-- exp_statopatrimoniale_dm2012_dett 2018, {d '2018-01-01'}, {d '2018-11-08'}, '3', null, 'E', null, 'N', null, null, null,null,'S', '%', 'N', 'S', 'S', 'N', 'S'

	BEGIN

	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	-- Calcola la lunghezza del filtro in base ad nlevel		
SET @filteraccount = RTRIM(@filteraccount) PRINT @filteraccount
IF  @filteraccount = ''
BEGIN
	SELECT @filteraccount = NULL
END

DECLARE @lenfilteracc int
SET @lenfilteracc = DATALENGTH(RTRIM(ISNULL(@filteraccount,''))) PRINT @lenfilteracc

	CREATE TABLE #bilanciostatopatrimoniale(
		idpatrimony	 	varchar(38), 
		idupb varchar(38),
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
	SET @filterpatrimony = RTRIM(@filterpatrimony) PRINT @filterpatrimony
	IF @filterpatrimony = ''
		SELECT @filterpatrimony = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filterpatrimony,''))) 
	PRINT @lenfilter
	
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+2  PRINT @newnlevel

	declare @sortcode1 varchar(50)
	set @sortcode1 = null
	if(@idsor1 is not null and @showidsor1child='S'	) 
	Begin
		set @sortcode1 = ( select sortcode from sorting where idsor = @idsor1 )
	End

	CREATE TABLE #sortinglink1
	(
		idchild int 
	)

	-- Valuta se considerare i figli o meno dell'idsor
	IF (@showidsor1child = 'S')
	BEGIN
		INSERT INTO #sortinglink1
		SELECT idchild from sortinglink 
		WHERE  idparent = @idsor1
	END


	INSERT INTO #bilanciostatopatrimoniale(
		idpatrimony,
		idupb,
		dare,avere,
		idacc,
		nlevel,
		idreg,
		idsor1,idsor2,idsor3,
		idrelated
		)
		SELECT 
			patrimony.idpatrimony,		
			entrydetail.idupb,
			case when isnull(entrydetail.amount,0)<0 then entrydetail.amount else null end,
			case when isnull(entrydetail.amount,0)>0 then entrydetail.amount else null end,
			SUBSTRING(account.idacc, 1, @newnlevel),  	
			patrimony.nlevel,
			entrydetail.idreg,
			entrydetail.idsor1,entrydetail.idsor2,entrydetail.idsor3,
			case when @flag_idrelated='S' then entrydetail.idrelated else null end			 
		FROM entry
		JOIN entrydetail			ON entry.yentry  = entrydetail.yentry 	AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc
		JOIN patrimony				ON patrimony.idpatrimony = account.idpatrimony
		WHERE entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
			and (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL) 
			AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2) 
			AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
			AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilteracc) = @filteraccount)
			AND (@flag_noepilogo='N' or entry.identrykind not in (6,11,12) ) -- se @flag_noepilogo='S' allora DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND (@flag_soloapertura='N' or entry.identrykind =7 ) -- se @flag_soloapertura='S' allora solo scritture apertura
			AND  ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			AND (@flag_noassestamentoprogp='N' or entry.identrykind NOT IN (8,13) ) -- s  no assestamento progetti pluriennali

 
			 
if (@suppressifblank = 'N')
BEGIN
	INSERT INTO #bilanciostatopatrimoniale(
			idpatrimony,
			nlevel,
			dare, avere,
			idacc
			)
			SELECT 
				patrimony.idpatrimony,
				patrimony.nlevel,
				0,0,
				SUBSTRING(account.idacc, 1, @newnlevel)
			FROM patrimony
			JOIN account				ON patrimony.idpatrimony = account.idpatrimony
			WHERE (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
				and patrimony.ayear = @ayear
				and (select count(*)  from #bilanciostatopatrimoniale P
						where P.idpatrimony = patrimony.idpatrimony
						and P.idacc = account.idacc)=0
END


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
			and (select count(*)  from patrimony P2
					where P2.paridpatrimony = patrimony.idpatrimony)=0
			and (select count(*)  from #bilanciostatopatrimoniale P
					where P.idpatrimony = patrimony.idpatrimony)=0


--4) Se si usa il "Mostra UPB", nell'esportazione si chiede di visualizzare le seguenti ulteriori colonne:
--- il flagactivity dell'upb con la dicitura "Tipo attivitÃ  dell'UPB" e i valori Qualsiasi\Non specificata, Istituzionale o Commerciale
--- il codice tipo UPB con la dicitura "Tipo UPB"
--- il flagkind con la dicitura "Funzione dell'UPB" e i valori Didattica o Ricerca
--- la Data inizio
--- la Data fine
IF (@showidsor123 ='N') 
Begin
		if(@showregistry='N')
		Begin
				IF (@showupb ='N')
					BEGIN
						SELECT  
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
							patrimony.patpart   as 'Parte schema ufficiale',
							patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciostatopatrimoniale.dare) as 'Dare',
							sum(#bilanciostatopatrimoniale.avere) as 'Avere',
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo'
							FROM patrimony 
							join #bilanciostatopatrimoniale on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account on #bilanciostatopatrimoniale.idacc = account.idacc
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title, 
									#bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY account.codeacc,#bilanciostatopatrimoniale.idrelated
					END
				IF (@showupb ='S')
					BEGIN
						SELECT  
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							CASE upb.flagactivity
									 when 4 then 'Qualsiasi/Non specificata'
									 when 1 then 'Istituzionale'
									 when 2 then 'Commerciale'
							END  as 'Tipo attività',
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
							join #bilanciostatopatrimoniale 			on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account								on #bilanciostatopatrimoniale.idacc = account.idacc
							left outer join upb 						on #bilanciostatopatrimoniale.idupb = upb.idupb
							left outer join epupbkind 					on epupbkind.idepupbkind = upb.idepupbkind
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY account.codeacc, account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title, 
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description, 
								#bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY account.codeacc,#bilanciostatopatrimoniale.idrelated
					END
		End

		if(@showregistry='S')
		Begin
				IF (@showupb ='N')
					BEGIN
						SELECT  
							registry.title as 'Anagrafica',
							registry.idreg as 'Cod.Anagrafica',
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
							patrimony.patpart   as 'Parte schema ufficiale',
							patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciostatopatrimoniale.dare) as 'Dare',
							sum(#bilanciostatopatrimoniale.avere) as 'Avere',
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo'
							FROM patrimony 
							join #bilanciostatopatrimoniale		on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account						on #bilanciostatopatrimoniale.idacc = account.idacc
							left  outer join registry			on #bilanciostatopatrimoniale.idreg = registry.idreg
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY registry.title, registry.idreg, account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title,
								 #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
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
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							CASE upb.flagactivity
									 when 4 then 'Qualsiasi/Non specificata'
									 when 1 then 'Istituzionale'
									 when 2 then 'Commerciale'
							END  as 'Tipo attività',
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
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY registry.title, registry.idreg, account.codeacc, account.title, patrimony.codepatrimony,patrimony.patpart, patrimony.title, 
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description, #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY  registry.title, account.codeacc
					END
		End
END

IF (@showidsor123 ='S') 
Begin
		if(@showregistry='N')
		Begin
				IF (@showupb ='N')
					BEGIN
						SELECT  
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
							patrimony.patpart   as 'Parte schema ufficiale',
							patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciostatopatrimoniale.dare) as 'Dare',
							sum(#bilanciostatopatrimoniale.avere) as 'Avere',
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo',
							S1.sortcode as 'Coord.Anal.1',
							S2.sortcode as 'Coord.Anal.2',
							S3.sortcode as 'Coord.Anal.3'
							FROM patrimony 
							join #bilanciostatopatrimoniale 
								on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account on #bilanciostatopatrimoniale.idacc = account.idacc
							LEFT OUTER JOIN sorting S1 ON #bilanciostatopatrimoniale.idsor1 = S1.idsor
							LEFT OUTER JOIN sorting S2 ON #bilanciostatopatrimoniale.idsor2 = S2.idsor
							LEFT OUTER JOIN sorting S3 ON #bilanciostatopatrimoniale.idsor3 = S3.idsor
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title, S1.sortcode,S2.sortcode,S3.sortcode
							, #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY account.codeacc, #bilanciostatopatrimoniale.idrelated
					END
				IF (@showupb ='S')
					BEGIN
						SELECT  
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							CASE upb.flagactivity
									 when 4 then 'Qualsiasi/Non specificata'
									 when 1 then 'Istituzionale'
									 when 2 then 'Commerciale'
							END  as 'Tipo attività',
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
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo',
							S1.sortcode as 'Coord.Anal.1',
							S2.sortcode as 'Coord.Anal.2',
							S3.sortcode as 'Coord.Anal.3'
							FROM patrimony 
							join #bilanciostatopatrimoniale 			on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account								on #bilanciostatopatrimoniale.idacc = account.idacc
							left outer join upb 						on #bilanciostatopatrimoniale.idupb = upb.idupb
							left outer join epupbkind 					on epupbkind.idepupbkind = upb.idepupbkind
							LEFT OUTER JOIN sorting S1 ON #bilanciostatopatrimoniale.idsor1 = S1.idsor
							LEFT OUTER JOIN sorting S2 ON #bilanciostatopatrimoniale.idsor2 = S2.idsor
							LEFT OUTER JOIN sorting S3 ON #bilanciostatopatrimoniale.idsor3 = S3.idsor
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY account.codeacc, account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title, 
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
							S1.sortcode,S2.sortcode,S3.sortcode, #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY account.codeacc, #bilanciostatopatrimoniale.idrelated
					END
		End

		if(@showregistry='S')
		Begin
				IF (@showupb ='N')
					BEGIN
						SELECT  
							registry.title as 'Anagrafica',
							registry.idreg as 'Cod.Anagrafica',
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							#bilanciostatopatrimoniale.idrelated as 'Chiave EP dettaglio',
							patrimony.codepatrimony   as 'Codice voce schema ufficiale associata al conto',
							patrimony.patpart   as 'Parte schema ufficiale',
							patrimony.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciostatopatrimoniale.dare) as 'Dare',
							sum(#bilanciostatopatrimoniale.avere) as 'Avere',
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo',
							S1.sortcode as 'Coord.Anal.1',
							S2.sortcode as 'Coord.Anal.2',
							S3.sortcode as 'Coord.Anal.3'
							FROM patrimony 
							join #bilanciostatopatrimoniale		on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account						on #bilanciostatopatrimoniale.idacc = account.idacc
							left  outer join registry			on #bilanciostatopatrimoniale.idreg = registry.idreg
							LEFT OUTER JOIN sorting S1 ON #bilanciostatopatrimoniale.idsor1 = S1.idsor
							LEFT OUTER JOIN sorting S2 ON #bilanciostatopatrimoniale.idsor2 = S2.idsor
							LEFT OUTER JOIN sorting S3 ON #bilanciostatopatrimoniale.idsor3 = S3.idsor
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY registry.title, registry.idreg, account.codeacc,account.title, patrimony.codepatrimony, patrimony.patpart,patrimony.title,
							S1.sortcode,S2.sortcode,S3.sortcode, #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
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
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							CASE upb.flagactivity
									 when 4 then 'Qualsiasi/Non specificata'
									 when 1 then 'Istituzionale'
									 when 2 then 'Commerciale'
							END  as 'Tipo attività',
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
							sum(isnull(#bilanciostatopatrimoniale.dare,0) + isnull(#bilanciostatopatrimoniale.avere,0)) as 'Saldo',
							S1.sortcode as 'Coord.Anal.1',
							S2.sortcode as 'Coord.Anal.2',
							S3.sortcode as 'Coord.Anal.3'
							FROM patrimony 
							join #bilanciostatopatrimoniale 
								on #bilanciostatopatrimoniale.idpatrimony = patrimony.idpatrimony
							join account on #bilanciostatopatrimoniale.idacc = account.idacc
							left  outer join registry			on #bilanciostatopatrimoniale.idreg = registry.idreg
							left outer join upb					on #bilanciostatopatrimoniale.idupb = upb.idupb
							left outer join epupbkind 			on epupbkind.idepupbkind = upb.idepupbkind
							LEFT OUTER JOIN sorting S1 ON #bilanciostatopatrimoniale.idsor1 = S1.idsor
							LEFT OUTER JOIN sorting S2 ON #bilanciostatopatrimoniale.idsor2 = S2.idsor
							LEFT OUTER JOIN sorting S3 ON #bilanciostatopatrimoniale.idsor3 = S3.idsor
							where patrimony.ayear = @ayear and (@patpart = 'E' or patrimony.patpart = @patpart)
							GROUP BY registry.title, registry.idreg, account.codeacc, account.title, patrimony.codepatrimony,patrimony.patpart, patrimony.title, 
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
							S1.sortcode,S2.sortcode,S3.sortcode, #bilanciostatopatrimoniale.idrelated
							HAVING (@suppressifblank='N' OR sum(#bilanciostatopatrimoniale.dare)<>0 or sum(#bilanciostatopatrimoniale.avere) <>0)
							ORDER BY  registry.title, account.codeacc, #bilanciostatopatrimoniale.idrelated
					END
		End
END


End -- fine sp
 
 
 

 

 --EXEC exp_statopatrimoniale_dm2012_dett 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, 1, NULL, null, null, null ,'S','%','S','S','S'

 





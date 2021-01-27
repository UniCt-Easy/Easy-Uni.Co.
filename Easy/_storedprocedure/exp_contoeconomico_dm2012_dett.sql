
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contoeconomico_dm2012_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contoeconomico_dm2012_dett]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm'
 -- exec exp_contoeconomico_dm2012_dett '2018', {d '2018-01-01'}, {d '2018-10-19'}, '1', null, 'S','7115', 'S', null, null, 'S', '%', 'N', 'N','S'
-- exp_contoeconomico_dm2012_dett '2018', {d '2018-01-01'}, {d '2018-10-19'}, '3', null, 'N',2999, 'S', null, null, 'S', '%', 'N', 'S','N'
--setuser 'amministrazione' 
CREATE  PROCEDURE [exp_contoeconomico_dm2012_dett]

	@ayear			int,
	@start			datetime,
	@stop			datetime,
	@nlevel 		varchar(1),
	@filterplaccount 		varchar(50),
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
	@flag_noassestamentoprogp char(1)='S'  -- no assestamento progetti pluriennali
	AS

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
	CREATE TABLE #bilanciocontoeconomico(
		idplaccount	 	varchar(38), 
		idupb varchar(38),
		dare decimal(19,2),
		avere decimal(19,2),
		idacc varchar(38),
		codeacc varchar(50),
		account varchar(150), 
		nlevel char(1),
		idreg int,
		idsor1 int,idsor2 int,idsor3 int
	)
 
	
-- Calcola la lunghezza del filtro in base ad nlevel		
	SET @filterplaccount = RTRIM(@filterplaccount) PRINT @filterplaccount
	IF @filterplaccount = ''
		SELECT @filterplaccount = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filterplaccount,''))) PRINT @lenfilter
	
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

	INSERT INTO #bilanciocontoeconomico(
		idplaccount,
		idupb,
		dare,avere,
		idacc,
		nlevel,
		idreg,
		idsor1,idsor2,idsor3 
		)
	SELECT  
			placcount.idplaccount,  	
			entrydetail.idupb ,		
			case when isnull(entrydetail.amount,0)<0 then -entrydetail.amount else null end,
			case when isnull(entrydetail.amount,0)>0 then entrydetail.amount else null end,
			SUBSTRING(account.idacc, 1, @newnlevel), 
			placcount.nlevel,
			entrydetail.idreg,
			entrydetail.idsor1,entrydetail.idsor2,entrydetail.idsor3 
		FROM entry
		JOIN entrydetail
			ON entry.yentry  = entrydetail.yentry 
			AND entry.nentry = entrydetail.nentry 
		JOIN account
			ON account.idacc = entrydetail.idacc
		JOIN placcount
			ON placcount.idplaccount = account.idplaccount
		LEFT OUTER JOIN sorting S1 ON entrydetail.idsor1 = S1.idsor
		WHERE entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
			and (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilteracc) = @filteraccount)
			AND (entrydetail.idsor1 IN (SELECT idchild FROM #sortinglink1) OR entrydetail.idsor1 = @idsor1 OR @idsor1 IS NULL) 
			AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)
			AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
			AND entry.identrykind not in  (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			AND (@flag_noassestamentoprogp='N' or entry.identrykind NOT IN (8,13) ) -- s  no assestamento progetti pluriennali

if (@suppressifblank = 'N')
BEGIN
INSERT INTO #bilanciocontoeconomico(
		idplaccount,
		nlevel,
		dare, avere,
		idacc
		)
		SELECT 
			placcount.idplaccount,
			placcount.nlevel,
			0, 0,
			SUBSTRING(account.idacc, 1, @newnlevel) 
		FROM placcount
		JOIN account
			ON placcount.idplaccount = account.idplaccount
		WHERE (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			and placcount.ayear = @ayear
			-- coppie C.E.- Piano dei Conti non precedentemente estratte
			and (select count(*)  from #bilanciocontoeconomico P
					where P.idplaccount = placcount.idplaccount
					and P.idacc = account.idacc)=0
END
 
--Inserisce le voci non associate a scritture
INSERT INTO #bilanciocontoeconomico(
		idplaccount,
		nlevel
		)
		SELECT 
			placcount.idplaccount,
			placcount.nlevel
		FROM placcount
		WHERE (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			and placcount.ayear = @ayear
			and (select count(*)  from placcount P2
					where P2.paridplaccount = placcount.idplaccount)=0
			and (select count(*)  from #bilanciocontoeconomico P
					where P.idplaccount = placcount.idplaccount)=0

 

--4) Se si usa il "Mostra UPB", nell'esportazione si chiede di visualizzare le seguenti ulteriori colonne:
--- il flagactivity dell'upb con la dicitura "Tipo attività dell'UPB" e i valori Qualsiasi\Non specificata, Istituzionale o Commerciale
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
							placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
							placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciocontoeconomico.dare) as 'Dare',
							sum(#bilanciocontoeconomico.avere) as 'Avere',
							sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo'
							FROM placcount 
							join #bilanciocontoeconomico 
								on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
								join account on #bilanciocontoeconomico.idacc = account.idacc
							where placcount.ayear = @ayear
							GROUP BY account.codeacc,account.title,  placcount.codeplaccount,placcount.title
							HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
							ORDER BY account.codeacc
					End
					IF (@showupb ='S')
					Begin
							SELECT    
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
							placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciocontoeconomico.dare) as 'Dare',
							sum(#bilanciocontoeconomico.avere) as 'Avere',
							sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
							case when upb.flagactivity=  1 then 'Istituzionale'
								 when upb.flagactivity = 2 then 'Commerciale'
								 when upb.flagactivity = 4 then 'Qualsiasi\Non specificata'
								 else null
							end as 'Attività',

							epupbkind.title as 'Tipo UPB',
							case when upb.flagkind&3=  1 then 'Didattica'
								 when upb.flagkind&3 = 2 then 'Ricerca'
								 when upb.flagkind&3 = 3 then 'Didattica+Ricerca'
								 else null
							end as 'Funzione dell''UPB',
							upb.start as 'Data Inizio',
							upb.stop as 'Data Fine'
							FROM placcount 
							join #bilanciocontoeconomico 			on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
							join account							on #bilanciocontoeconomico.idacc = account.idacc
							left outer join upb						on #bilanciocontoeconomico.idupb = upb.idupb
							left outer join epupbkind				on epupbkind.idepupbkind = upb.idepupbkind
							where placcount.ayear = @ayear
							GROUP BY account.codeacc, account.title,  placcount.codeplaccount,placcount.title,
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
							upb.flagkind,epupbkind.title,upb.flagactivity
							HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
							ORDER BY account.codeacc

					End
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
							placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
							placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciocontoeconomico.dare) as 'Dare',
							sum(#bilanciocontoeconomico.avere) as 'Avere',
							sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo'
							FROM placcount 
							join #bilanciocontoeconomico 
								on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
								join account on #bilanciocontoeconomico.idacc = account.idacc
							left  outer join registry			on #bilanciocontoeconomico.idreg = registry.idreg
							where placcount.ayear = @ayear
							GROUP BY registry.title, registry.idreg, account.codeacc,account.title,  placcount.codeplaccount,placcount.title
							HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
							ORDER BY  registry.title, account.codeacc
					End
					IF (@showupb ='S')
					Begin
							SELECT    
							registry.title as 'Anagrafica',
							registry.idreg as 'Cod.Anagrafica',
							account.codeacc as 'Codice conto',
							account.title	as 'Conto',
							upb.codeupb	    as 'Codice UPB',
							upb.title		as 'UPB',
							placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
							placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
							sum(#bilanciocontoeconomico.dare) as 'Dare',
							sum(#bilanciocontoeconomico.avere) as 'Avere',
							sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
							case when upb.flagactivity=  1 then 'Istituzionale'
								 when upb.flagactivity = 2 then 'Commerciale'
								 when upb.flagactivity = 4 then 'Qualsiasi\Non specificata'
								 else null
							end as 'Attività',

							epupbkind.title as 'Tipo UPB',
							case when upb.flagkind&3=  1 then 'Didattica'
								 when upb.flagkind&3 = 2 then 'Ricerca'
								 when upb.flagkind&3 = 3 then 'Didattica+Ricerca'
								 else null
							end as 'Funzione dell''UPB',
							upb.start as 'Data Inizio',
							upb.stop as 'Data Fine'
							FROM placcount 
							join #bilanciocontoeconomico 			on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
							join account							on #bilanciocontoeconomico.idacc = account.idacc
							left  outer join registry			on #bilanciocontoeconomico.idreg = registry.idreg
							left outer join upb						on #bilanciocontoeconomico.idupb = upb.idupb
							left outer join epupbkind				on epupbkind.idepupbkind = upb.idepupbkind
							where placcount.ayear = @ayear
							GROUP BY registry.title, registry.idreg, account.codeacc, account.title,  placcount.codeplaccount,placcount.title,
							upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
							upb.flagkind,epupbkind.title,upb.flagactivity
							HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
							ORDER BY  registry.title, account.codeacc

					End
			End
End

IF (@showidsor123 ='S') 
Begin
	if(@showregistry='N')
		Begin
				IF (@showupb ='N')
					BEGIN
						SELECT  
						account.codeacc as 'Codice conto',
						account.title	as 'Conto',
						placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
						placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
						sum(#bilanciocontoeconomico.dare) as 'Dare',
						sum(#bilanciocontoeconomico.avere) as 'Avere',
						sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
						S1.sortcode as 'Coord.Anal.1',
						S2.sortcode as 'Coord.Anal.2',
						S3.sortcode as 'Coord.Anal.3'
						FROM placcount 
						join #bilanciocontoeconomico 
							on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
							join account on #bilanciocontoeconomico.idacc = account.idacc
						LEFT OUTER JOIN sorting S1 ON #bilanciocontoeconomico.idsor1 = S1.idsor
						LEFT OUTER JOIN sorting S2 ON #bilanciocontoeconomico.idsor2 = S2.idsor
						LEFT OUTER JOIN sorting S3 ON #bilanciocontoeconomico.idsor3 = S3.idsor
						where placcount.ayear = @ayear
						GROUP BY account.codeacc,account.title,  placcount.codeplaccount,placcount.title,
						S1.sortcode,S2.sortcode,S3.sortcode
						HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
						ORDER BY account.codeacc
				End
				IF (@showupb ='S')
				Begin

						SELECT    
						account.codeacc as 'Codice conto',
						account.title	as 'Conto',
						upb.codeupb	    as 'Codice UPB',
						upb.title		as 'UPB',
						placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
						placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
						sum(#bilanciocontoeconomico.dare) as 'Dare',
						sum(#bilanciocontoeconomico.avere) as 'Avere',
						sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
						case when upb.flagactivity=  1 then 'Istituzionale'
							 when upb.flagactivity = 2 then 'Commerciale'
							 when upb.flagactivity = 4 then 'Qualsiasi\Non specificata'
							 else null
						end as 'Attività',

						epupbkind.title as 'Tipo UPB',
						case when upb.flagkind&3=  1 then 'Didattica'
							 when upb.flagkind&3 = 2 then 'Ricerca'
							 when upb.flagkind&3 = 3 then 'Didattica+Ricerca'
							 else null
						end as 'Funzione dell''UPB',
						upb.start as 'Data Inizio',
						upb.stop as 'Data Fine',
						S1.sortcode as 'Coord.Anal.1',
						S2.sortcode as 'Coord.Anal.2',
						S3.sortcode as 'Coord.Anal.3'
						FROM placcount 
						join #bilanciocontoeconomico 			on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
						join account							on #bilanciocontoeconomico.idacc = account.idacc
						left outer join upb						on #bilanciocontoeconomico.idupb = upb.idupb
						left outer join epupbkind				on epupbkind.idepupbkind = upb.idepupbkind
						LEFT OUTER JOIN sorting S1 ON #bilanciocontoeconomico.idsor1 = S1.idsor
						LEFT OUTER JOIN sorting S2 ON #bilanciocontoeconomico.idsor2 = S2.idsor
						LEFT OUTER JOIN sorting S3 ON #bilanciocontoeconomico.idsor3 = S3.idsor
						where placcount.ayear = @ayear
						GROUP BY account.codeacc, account.title,  placcount.codeplaccount,placcount.title,
						upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
						upb.flagkind,epupbkind.title,upb.flagactivity,
						S1.sortcode,S2.sortcode,S3.sortcode
						HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
						ORDER BY account.codeacc
				End
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
						placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
						placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
						sum(#bilanciocontoeconomico.dare) as 'Dare',
						sum(#bilanciocontoeconomico.avere) as 'Avere',
						sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
						S1.sortcode as 'Coord.Anal.1',
						S2.sortcode as 'Coord.Anal.2',
						S3.sortcode as 'Coord.Anal.3'
						FROM placcount 
						join #bilanciocontoeconomico 
							on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
						join account on #bilanciocontoeconomico.idacc = account.idacc
						left  outer join registry			on #bilanciocontoeconomico.idreg = registry.idreg
						LEFT OUTER JOIN sorting S1 ON #bilanciocontoeconomico.idsor1 = S1.idsor
						LEFT OUTER JOIN sorting S2 ON #bilanciocontoeconomico.idsor2 = S2.idsor
						LEFT OUTER JOIN sorting S3 ON #bilanciocontoeconomico.idsor3 = S3.idsor
						where placcount.ayear = @ayear
						GROUP BY registry.title, registry.idreg,account.codeacc,account.title,  placcount.codeplaccount,placcount.title,
						S1.sortcode,S2.sortcode,S3.sortcode
						HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
						ORDER BY  registry.title, account.codeacc
				End
				IF (@showupb ='S')
				Begin

						SELECT    
						registry.title as 'Anagrafica',
						registry.idreg as 'Cod.Anagrafica',
						account.codeacc as 'Codice conto',
						account.title	as 'Conto',
						upb.codeupb	    as 'Codice UPB',
						upb.title		as 'UPB',
						placcount.codeplaccount   as 'Codice voce schema ufficiale associata al conto',
						placcount.title  as 'Descrizione voce schema ufficiale associata al conto',
						sum(#bilanciocontoeconomico.dare) as 'Dare',
						sum(#bilanciocontoeconomico.avere) as 'Avere',
						sum(-isnull(#bilanciocontoeconomico.dare,0) + isnull(#bilanciocontoeconomico.avere,0)) as 'Saldo',
						case when upb.flagactivity=  1 then 'Istituzionale'
							 when upb.flagactivity = 2 then 'Commerciale'
							 when upb.flagactivity = 4 then 'Qualsiasi\Non specificata'
							 else null
						end as 'Attività',

						epupbkind.title as 'Tipo UPB',
						case when upb.flagkind&3=  1 then 'Didattica'
							 when upb.flagkind&3 = 2 then 'Ricerca'
							 when upb.flagkind&3 = 3 then 'Didattica+Ricerca'
							 else null
						end as 'Funzione dell''UPB',
						upb.start as 'Data Inizio',
						upb.stop as 'Data Fine',
						S1.sortcode as 'Coord.Anal.1',
						S2.sortcode as 'Coord.Anal.2',
						S3.sortcode as 'Coord.Anal.3'
						FROM placcount 
						join #bilanciocontoeconomico 			on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
						join account							on #bilanciocontoeconomico.idacc = account.idacc
						left  outer join registry			on #bilanciocontoeconomico.idreg = registry.idreg
						left outer join upb						on #bilanciocontoeconomico.idupb = upb.idupb
						left outer join epupbkind				on epupbkind.idepupbkind = upb.idepupbkind
						LEFT OUTER JOIN sorting S1 ON #bilanciocontoeconomico.idsor1 = S1.idsor
						LEFT OUTER JOIN sorting S2 ON #bilanciocontoeconomico.idsor2 = S2.idsor
						LEFT OUTER JOIN sorting S3 ON #bilanciocontoeconomico.idsor3 = S3.idsor
						where placcount.ayear = @ayear
						GROUP BY registry.title, registry.idreg, account.codeacc, account.title,  placcount.codeplaccount,placcount.title,
						upb.codeupb, upb.title,upb.idepupbkind, upb.flagactivity, upb.flagkind, upb.start, upb.stop,epupbkind.description,
						upb.flagkind,epupbkind.title,upb.flagactivity,
						S1.sortcode,S2.sortcode,S3.sortcode
						HAVING (@suppressifblank='N' OR sum(#bilanciocontoeconomico.dare)<>0 or sum(#bilanciocontoeconomico.avere) <>0)
						ORDER BY  registry.title, account.codeacc
				End
		End		
End

END-- fine sp


 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

 
 --exec exp_contoeconomico_dm2012_dett '2018', {d '2018-01-01'}, {d '2018-10-19'}, '1', null, '7115', 'S', null, null, 'S', '%', 'N', 'N'
 

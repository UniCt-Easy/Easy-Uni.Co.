
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unifiedf24ep_dati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unifiedf24ep_dati]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 --setuser 'amm'
 -- [exp_unifiedf24ep_dati] 1
CREATE procedure [exp_unifiedf24ep_dati](@idunifiedf24ep int) as
begin

	create table #tributi (
		tiporiga char(1),
		codicetributo varchar(4),
		descrtributo  varchar(400),
		tipoente varchar(4),
		rifA varchar(7),
		rifB  varchar(6)
	)

	--exec exp_unifiedf24ep_dati 1
	
	insert into #tributi values ('S','384E','Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo','CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ('S','385E','Addizionale comunale Irpef trattenuta dai sostituti d’imposta- acconto','CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta- acconto 
	insert into #tributi values ('S','891E','Sanzioni per ravvedimento su Addizionale comunale Irpef trattenuta dai sostituti d’imposta','CCCC',  null,'AAAA') -- Sanzioni per ravvedimento su Addizionale comunale Irpef trattenuta dai sostituti d’imposta 
	--insert into #tributi values ('382E',  'EE','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta  su emolumenti corrisposti nell’anno solare 2007–saldo  	
	--insert into #tributi values ('383E',  'EE','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta su emolumenti corrisposti nell’anno solare 2007- acconto    
	
	insert into #tributi values ('R','380E', 'IRAP', 'RR','00MM','AAAA') -- IRAP  	
	insert into #tributi values ('R','381E', 'Addizionale regionale Irpef trattenuta dai sostituti d’imposta', 'RR','00MM','AAAA') -- Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ('R','892E', 'Sanzioni per ravvedimento su IRAP', 'RR',  null,'AAAA') -- Sanzioni per ravvedimento su IRAP 
	insert into #tributi values ('R','893E', 'Sanzioni per ravvedimento Addizionale regionale Irpef trattenuta dai sostituti d’imposta', 'RR',  null,'AAAA') -- Sanzioni per ravvedimento Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	
	insert into #tributi values ('F','100E', 'Ritenute sui redditi da lavoro dipendente ed assimilati',  null,'00MM','AAAA') -- Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ('F','104E', 'Ritenute sui redditi da lavoro autonomo', null,'00MM','AAAA') -- Ritenute sui redditi da lavoro autonomo  
	insert into #tributi values ('F','105E', 'Ritenute sulle indennità di esproprio, occupazione , etc. - articolo 11, legge 413/91', null,'00MM','AAAA') -- Ritenute sulle indennità di esproprio, occupazione , etc. - articolo 11, legge 413/91  
	insert into #tributi values ('F','106E', 'Ritenute sui contributi corrisposti alle imprese - articolo 28 D.P.R. 600/73', null,'00MM','AAAA') -- Ritenute sui contributi corrisposti alle imprese - articolo 28 D.P.R. 600/73 
	insert into #tributi values ('F','107E', 'Altre ritenute alla fonte', null,'00MM','AAAA') -- Altre ritenute alla fonte  
	insert into #tributi values ('F','890E', 'Sanzioni per ravvedimento su ritenute erariali', null,  null,'AAAA') -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('F','112E', 'Ritenuta alla fonte su somme pignorate', null,'00MM','AAAA') -- Ritenuta alla fonte su somme pignorate 

	insert into #tributi values ('I','C10', 'Contributi dovuti per soggetti non titolari di pensione (diretta o indiretta), e non titolari di ulteriori contemporanei rapporti assicurativi. ',  null,  'MMAAAA',null) -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('I','CXX', 'Contributi dovuti per soggetti titolari di pensione (diretta o indiretta) e/o di ulteriori contemporanei rapporti assicurativi. ', null,  'MMAAAA',null) -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('Q','P101', 'CASSA C.P.T.S. - CONTRIBUTI OBBLIGATORI',  null,  'MMAAAA','MMAAAA') -- CASSA C.P.T.S. - CONTRIBUTI OBBLIGATORI
	insert into #tributi values ('Q','P909', 'CASSA UNICA DEL CREDITO - CREDITO', null,  'MMAAAA','MMAAAA') -- P909CASSA UNICA DEL CREDITO - CREDITO
	insert into #tributi values ('F','150E', 'SOMME A TITOLO DI IMPOSTE ERARIALI 
											  RIMBORSATE DAL SOSTITUTO D''IMPOSTA 
											  A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)', null,  null,'AAAA') --SOMME A TITOLO DI IMPOSTE ERARIALI RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)
	insert into #tributi values ('F','134E', 'IRPEF A SALDO TRATTENUTA DAL
											 SOSTITUTO D''IMPOSTA',  null, '00MM','AAAA') --IRPEF A SALDO TRATTENUTA DAL SOSTITUTO D''IMPOSTA
	insert into #tributi values ('R','126E', 'ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA 
											 DAL SOSTITUTO D''IMPOSTA A SEGUITO
											 DI ASSISTENZA FISCALE',  'RR', null,'AAAA') --ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE
	insert into #tributi values ('R','153E', 'SOMME A TITOLO DI ADDIZIONALE REGIONALE
											 ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA
											 A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,
											 LETT.A)D.LGS. N. 175/2014',  'RR', null, 'AAAA') --SOMME A TITOLO DI ADDIZIONALE REGIONALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('S','127E', 'ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA 
											 DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO – ',  'CCCC','00MM','AAAA') --ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO –
	insert into #tributi values ('S','154E', 'SOMME A TITOLO DI ADDIZIONALE 
											  COMUNALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO 
											  D''IMPOSTA A SEGUITO DI ASSISTENZA 
											  FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014',  'CCCC', null,'AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('F','133E', 'IRPEF IN ACCONTO TRATTENUTA
											  DAL SOSTITUTO D''IMPOSTA', null , '00MM','AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014

	-- inserire qui i codici tributo a credito

		
	insert into #tributi values ( 'S','161E', 'Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo', 'CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ( 'R','160E', 'Addizionale regionale Irpef trattenuta dai sostituti d’imposta',  'RR','00MM','AAAA') -- Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ( 'F','156E', 'Ritenute sui redditi da lavoro autonomo', null,'00MM','AAAA') -- Ritenute sui redditi da lavoro autonomo  	
	insert into #tributi values ( 'F','155E', 'Ritenute sui redditi da lavoro dipendente ed assimilati', null,'00MM','AAAA') -- Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ( 'F','165E', 'Bonus fiscale', null,'00MM','AAAA') -- Bonus fiscale 

	insert into #tributi values ('F','601E','VERSAMENTO IVA MENSILE GENNAIO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE GENNAIO"
	insert into #tributi values ('F','602E','VERSAMENTO IVA MENSILE FEBBRAIO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE FEBBRAIO"
	insert into #tributi values ('F','603E','VERSAMENTO IVA MENSILE MARZO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE MARZO"
	insert into #tributi values ('F','604E','VERSAMENTO IVA MENSILE APRILE', null, null,'AAA')--	"VERSAMENTO IVA MENSILE APRILE"
	insert into #tributi values ('F','605E','VERSAMENTO IVA MENSILE MAGGIO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE MAGGIO"
	insert into #tributi values ('F','606E','VERSAMENTO IVA MENSILE GIUGNO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE GIUGNO"
	insert into #tributi values ('F','607E','VERSAMENTO IVA MENSILE LUGLIO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE LUGLIO"
	insert into #tributi values ('F','608E','VERSAMENTO IVA MENSILE AGOSTO', null, null,'AAA')--	"VERSAMENTO IVA MENSILE AGOSTO"
	insert into #tributi values ('F','609E','VERSAMENTO IVA MENSILE SETTEMBRE', null, null,'AAA')--	"VERSAMENTO IVA MENSILE SETTEMBRE"
	insert into #tributi values ('F','610E','VERSAMENTO IVA MENSILE OTTOBRE', null, null,'AAA')--	"VERSAMENTO IVA MENSILE OTTOBRE"
	insert into #tributi values ('F','611E','VERSAMENTO IVA MENSILE NOVEMBRE', null, null,'AAA')--	"VERSAMENTO IVA MENSILE NOVEMBRE"
	insert into #tributi values ('F','612E','VERSAMENTO IVA MENSILE DICEMBRE', null, null,'AAA')--	"VERSAMENTO IVA MENSILE DICEMBRE"

	insert into #tributi values ('F','613E','VERSAMENTO ACCONTO PER IVA MENSILE', null, null,'AAAA')--	VERSAMENTO IVA MENSILE DICEMBRE
	insert into #tributi values ('F','614E','VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE
	insert into #tributi values ('F','615E','VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE
	insert into #tributi values ('F','616E','VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE', null,null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE
	insert into #tributi values ('F','617E','VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE ',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE 
	insert into #tributi values ('F','618E','VERSAMENTO IVA ACCONTO ',null,null,'AAAA')--	VERSAMENTO IVA ACCONTO  
	insert into #tributi values ('F','619E','VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE', null,null,'AAAA')--	VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE
	insert into #tributi values ('F','620E','SPLIT ISTITUZIONALE', null,'00MM','AAAA')--	SPLIT ISTITUZIONALE
	insert into #tributi values ('F','621E','SPLIT COMMERCIALE', null,'00MM','AAAA')--	SPLIT COMMERCIALE
	insert into #tributi values ('F','622E','INTRA 12','00MM', null,'AAAA')--	INTRA 12	
	insert into #tributi values ('F','801E','SANZIONE PECUNIARIA IVA',null,'00MM','AAAA')--	SANZIONE PECUNIARIA IVA
	insert into #tributi values ('F','901E','REGOLARIZZAZIONE OPERAZIONI IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.',null, '00MM','AAAA')--	REGOLARIZZAZIONE OPERAZIONI IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.




	--declare @annodichiarazione int
	--set @annodichiarazione = 2008
	
	--select * from #tributi

	create table #f24 (
		tiporecord char(1), -- M o V
		tiporiga char(1),
		codicetributo varchar(4),
		codice  varchar(10), -- ex codiceEnte
		descrente varchar(200),
		estremi varchar(17),
		riferimentoA varchar(10),
		riferimentoB varchar(10),
		importoADebito decimal(19,2),
		importoacredito decimal(19,2),
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16) -- codice fiscale debitore per intervento sostitutivo
	)
         


	create table #errori (
		taxcode int,
		idexp int,
		iddbdepartment varchar(50),
		ymov int, 
		nmov int,
		message varchar(200)
	)

	--sp_help unifiedtax

insert into #errori (taxcode, idexp, iddbdepartment, ymov, nmov, message)
		select  distinct unifiedtax.taxcode, null, iddbdepartment, null,null,
		'Il tributo '+isnull(tax.taxref,'')+' ha il codice '+
		isnull(tax.fiscaltaxcode,'')+
		' che non è gestito dalla procedura di generazione del modello f24ep'
		from unifiedtax 
		join tax on tax.taxcode = unifiedtax.taxcode
		where idunifiedf24ep = @idunifiedf24ep
		and not exists (select * from #tributi where #tributi.codicetributo = tax.fiscaltaxcode OR #tributi.codicetributo = tax.fiscaltaxcodecredit )


	if (select count(*) from #errori) > 0
	begin
		select 
		'Dipartimento' = #errori.iddbdepartment,
		'Ritenuta' = tax.taxref,
		'Eserc.movim.' = #errori.ymov,
		'Num.movim.' = #errori.nmov,
		'Problema riscontrato' = #errori.message
		from #errori
		join tax on tax.taxcode = #errori.taxcode

		return
	end

	declare @codiceTributo varchar(4)
	declare @importoADebito decimal(19,2)
	declare @importoACredito decimal(19,2)
	declare @tiporiga char(1)
	declare @codice  varchar(4) --ex codiceEnte
	declare @descrente varchar(200)
	declare @estremi varchar(17)
	declare @riferimentoA varchar(6)
	declare @riferimentoB varchar(6)

	declare @rifA varchar(7)
	declare @rifB varchar(6)
	
	declare @iddbdepartment varchar(50)
	declare @taxcode int
	declare @idexp int
	declare @ymov int
	declare @nmov int
	declare @idunifiedtax int
	declare @idcity int
	declare @idfiscaltaxregion varchar(5)
	declare @idcountry int
	declare @geoappliance char(1)
	declare @tipoEnte varchar(4)
	declare @sanctioncode varchar(4)
	declare @cafcode varchar(4)
	declare @ayearsanction smallint
	declare @idreg int
	declare @fiscalyear int
	declare @iniziocompetenza datetime
	declare @finecompetenza datetime
	declare @mese int
	declare @anno smallint
	declare @mycity varchar(100)
	declare @mycap	varchar(5)
	declare @cf_agency varchar(20)  
	declare @agency   varchar(100)
	declare @iban_f24  varchar(50)
	declare @email_f24  varchar(50)
	declare @paymentdate  datetime --   'Data di addebito',
	declare @ayear int -- anno
	declare @nmonth  int -- 'Mese dichiarazione',
 
	--declare @12gen08 datetime
	--select  @12gen08 = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

	--sp_help unifiedtax
						
	--declare @idf24ep int
	--set @idf24ep = 1
	create table #versamenti (
		kind char(1),
		taxcode int,
		fiscaltaxcode varchar(10),
		geoappliance char(1),
		idcity  int,
		idfiscaltaxregion varchar(5),
		iddbdepartment varchar(50),
		idexp int,
		ymov int,
		nmov int,
		idreg int,
		idunifiedtax int,
		sanctioncode varchar(4),
		cafcode varchar(4),
		ayearsanction smallint,
		importoadebito decimal(19,2),
		importoacredito decimal(19,2),
		anno smallint,
		meseriferimento int,
		iniziocompetenza datetime,--da expenselast
		finecompetenza datetime --da expenselast
		)
	
	--inserisce tutte le imposte da unifiedtax di questo f24ep 
	INSERT INTO  #versamenti
	(taxcode, idcity, idfiscaltaxregion, geoappliance, iddbdepartment, idexp, 
	ymov, nmov, idreg,importoadebito, importoacredito, meseriferimento,iniziocompetenza,finecompetenza, anno)
	select  unifiedtax.taxcode, unifiedtax.idcity,
		unifiedtax.idfiscaltaxregion, tax.geoappliance, 
		unifiedtax.iddbdepartment,
		unifiedtax.idexp, unifiedtax.ymov, unifiedtax.nmov, 
		unifiedtax.idreg,
		CASE WHEN isnull(unifiedtax.admintax,0)+isnull(unifiedtax.employtax,0) > 0  THEN isnull(unifiedtax.admintax,0)+isnull(unifiedtax.employtax,0)  ELSE 0 END,
		CASE WHEN isnull(unifiedtax.admintax,0)+isnull(unifiedtax.employtax,0) < 0  THEN -(isnull(unifiedtax.admintax,0)+isnull(unifiedtax.employtax,0))  ELSE 0 END,
		unifiedtax.nmonth,
		unifiedtax.servicestart,
		unifiedtax.servicestop,
		unifiedtax.ayear
	from unifiedtax join tax on unifiedtax.taxcode = tax.taxcode
	where unifiedtax.idunifiedf24ep = @idunifiedf24ep
	

	--select 1,* from #versamenti
	--inserisce tutte le imposte da unifiedtaxcorrige di questo f24ep 
	INSERT INTO  #versamenti
	 (taxcode,  idcity, idfiscaltaxregion, geoappliance,iddbdepartment, idexp, 
	ymov, nmov, idreg,importoadebito, importoacredito, meseriferimento,iniziocompetenza,finecompetenza, anno)
	select  unifiedtaxcorrige.taxcode, unifiedtaxcorrige.idcity,
		unifiedtaxcorrige.idfiscaltaxregion, tax.geoappliance, unifiedtaxcorrige.iddbdepartment,
		unifiedtaxcorrige.idexp,unifiedtaxcorrige.ymov,unifiedtaxcorrige.nmov, 
		unifiedtaxcorrige.idreg, 
		CASE WHEN isnull(unifiedtaxcorrige.adminamount,0)+isnull(unifiedtaxcorrige.employamount,0) > 0  THEN isnull(unifiedtaxcorrige.adminamount,0)+isnull(unifiedtaxcorrige.employamount,0)  ELSE 0 END,
		CASE WHEN isnull(unifiedtaxcorrige.adminamount,0)+isnull(unifiedtaxcorrige.employamount,0) < 0  THEN -(isnull(unifiedtaxcorrige.adminamount,0)+isnull(unifiedtaxcorrige.employamount,0))  ELSE 0 END,
		unifiedtaxcorrige.nmonth,
		unifiedtaxcorrige.servicestart,
		unifiedtaxcorrige.servicestop,
		unifiedtaxcorrige.ayear
		from unifiedtaxcorrige join tax on unifiedtaxcorrige.taxcode = tax.taxcode
		where unifiedtaxcorrige.idunifiedf24ep = @idunifiedf24ep
		
	-- select 2,* from #versamenti
	--inserisce tutte le imposte da unifiedf24epsanction di questo f24ep 
	-- Sanzioni per Ravvedimento Operoso
	INSERT INTO  #versamenti
		(sanctioncode,idcity,idfiscaltaxregion,importoadebito, importoacredito, ayearsanction)
	SELECT  fiscaltaxcode,
		idcity,
		idfiscaltaxregion,
		importoadebito = isnull(amount,0),
		importoacredito = 0,
		unifiedf24epsanction.ayear
		FROM   unifiedf24epsanction 
		JOIN   f24epsanctionkind  
		ON unifiedf24epsanction.idsanction = f24epsanctionkind.idsanction
		WHERE  unifiedf24epsanction.idunifiedf24ep = @idunifiedf24ep
	
	UPDATE #versamenti  SET fiscaltaxcode = 
	CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecredit IS NOT NULL ) THEN tax.fiscaltaxcodecredit ELSE tax.fiscaltaxcode END,
	kind =  CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecredit IS NOT NULL ) THEN 'C' ELSE 'D' END
	FROM tax WHERE  tax.taxcode = #versamenti.taxcode AND #versamenti.fiscaltaxcode is null

	UPDATE #versamenti SET importoadebito = importoadebito - importoacredito, importoacredito = 0 WHERE kind = 'D'
	UPDATE #versamenti SET importoacredito = importoacredito - importoadebito, importoadebito = 0 WHERE kind = 'C'  --- bonus fiscale ha solo un codice a credito

	--select * from #versamenti
	-- where importoadebito = 0
	--drop table #versamenti
	declare  @myfiscalregion varchar(2)
	declare  @myidcity int
	select   @myidcity=max(idcity) from	license
	select	 @mycity = title from geo_city where idcity= @myidcity
	select	 @mycap= max(cap) from license
	select   @myfiscalregion= idfiscaltaxregion from geo_cityfiscalview where idcity=@myidcity

	select @paymentdate  = paymentdate,   -- 'Data di addebito'
		   @ayear = ayear, -- esercizio
	       @nmonth		 = nmonth	 -- 'Mese dichiarazione' 
	from unifiedf24ep where idunifiedf24ep = @idunifiedf24ep
	
	select @cf_agency  = license.cf from license
	select @agency  = license.agency from license
	select @iban_f24 = config.iban_f24 from config where ayear = @ayear
	select @email_f24 = config.email_f24 from config where ayear = @ayear
	--select V.iddbdepartment, V.taxcode, V.idexp, V.ymov,V.nmov, 
	--	V.idreg, V.idcity,V.idfiscaltaxregion,
	--	V.importoadebito, V.importoacredito, V.meseriferimento, V.anno,
	--	V.sanctioncode, V.ayearsanction, V.iniziocompetenza, V.finecompetenza,
	--	ISNULL(V.cafcode,T.fiscaltaxcode), TT.tiporiga, TT.tipoente, TT.rifA,  TT.rifB,  
	--	ISNULL( T.geoappliance, CASE TT.tipoente WHEN 'CCCC' THEN 'C' WHEN 'RR' THEN 'R' ELSE NULL END )
	--	from #versamenti V
	--		left outer join tax T on V.taxcode=T.taxcode
	--		left outer join #tributi TT on TT.codicetributo = isnull(V.cafcode,T.fiscaltaxcode)
	--	--WHERE ISNULL(V.cafcode,T.fiscaltaxcode) IN ('150E', '134E','126E','153E','127E','154E','133E')
 
	declare @cursore cursor

	set @cursore = cursor for 
		select V.iddbdepartment,  V.fiscaltaxcode,  V.idexp, V.ymov,V.nmov, 
		V.idreg, V.idcity,V.idfiscaltaxregion,V.geoappliance,
		V.importoadebito, V.importoacredito, V.meseriferimento, V.anno,
		V.sanctioncode, V.ayearsanction, V.iniziocompetenza, V.finecompetenza
		from #versamenti V

	open @cursore
	fetch next from @cursore into @iddbdepartment,@codicetributo, @idexp, @ymov, @nmov,
			@idreg, @idcity,
			@idfiscaltaxregion, @geoappliance,
			@importoADebito, @importoACredito,
			@mese, @anno,
			@sanctioncode, @ayearsanction, @iniziocompetenza, @finecompetenza
	while @@fetch_status = 0
	begin
		set @codice = null --ex @codiceEnte
		set @riferimentoA=null
		set @riferimentoB=null
		set @estremi=null
		set @tipoente=null
		set @tiporiga=null
		set @rifA =null
		set @rifB =null
 
	
		SELECT  
				@tiporiga = #tributi.tiporiga,
				@tipoente = #tributi.tipoente, 
				@rifA = #tributi.rifA,
				@rifB = #tributi.rifB
		FROM    #tributi WHERE #tributi.codicetributo = @codiceTributo

	--SANZIONI PER RAVVEDIMENTO OPEROSO
		IF      @sanctioncode IS NOT NULL
		BEGIN
			SELECT @codiceTributo = @sanctioncode,
			@tiporiga = #tributi.tiporiga,
			@tipoente = #tributi.tipoente, 
			@rifA = #tributi.rifA,
			@rifB = #tributi.rifB,
			@anno = @ayearsanction
			FROM #tributi 
			WHERE #tributi.codicetributo = @sanctioncode
		END


		IF      @cafcode IS NOT NULL
		BEGIN
			SELECT @codiceTributo = @cafcode,
			@tiporiga = #tributi.tiporiga,
			@tipoente = #tributi.tipoente, 
			@rifA = #tributi.rifA,
			@rifB = #tributi.rifB,

			@anno = @ayear
			FROM #tributi 
			WHERE #tributi.codicetributo = @cafcode
		END

		--Per l'irap (380e) facciamo un calcolo a parte 
		if (@codiceTributo='380E' )			
		begin
			set @idcity= @myidcity
			set @idfiscaltaxregion=@myfiscalregion
			print @myfiscalregion
			print @idcity
		end

		if (@codiceTributo='CXX' OR @codiceTributo='C10')			
		begin
			set @estremi= @mycap+substring(@mycity,1,12)
			select  @codice = idinpscenter from config where ayear=@anno
		end
		

		if (@codiceTributo='P101' OR @codiceTributo='P909')			
		begin
			select @codice = max(country) from license
		end


		if (@geoappliance ='C' and @idcity is null)
		begin 
		insert into #errori (iddbdepartment, taxcode, idexp, ymov, nmov, message)
			values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
			'Per il tributo con codice ' + isnull(@codiceTributo, '')
			+ ' non è stato valorizzato il comune di riferimento');
		end


		if (@geoappliance ='R' and @idfiscaltaxregion is null )
		begin 
		insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov,  message)
			values (@iddbdepartment, @taxcode, @idexp,@ymov,@nmov, 
			'Per il tributo con codice ' + isnull(@codiceTributo, '')
			+ ' non è stato valorizzata la regione di riferimento');
		end

		if (@rifA = '00MM')
		begin
			if (@mese>9) set @riferimentoA= '00'+convert(varchar(2),@mese)
			if (@mese<=9) set @riferimentoA= '000'+convert(varchar(2),@mese)
		end

		if (@rifA = 'MMAAAA' and @rifB is null)
		begin
			if (@mese>9) set @riferimentoA= convert(varchar(2),@mese)+convert(varchar(4),@anno)
			if (@mese<=9) set @riferimentoA= '0'+convert(varchar(2),@mese)+convert(varchar(4),@anno)
		end
		
		if (@rifA = 'MM/AAAA' and @rifB is null)
		begin
			if (@mese>9) set @riferimentoA= convert(varchar(2),@mese)+ '/' + convert(varchar(4),@anno)
			if (@mese<=9) set @riferimentoA= '0'+convert(varchar(2),@mese)+ '/' + convert(varchar(4),@anno)
		end
		print @rifA
		print @riferimentoA
		if (@rifA = 'MMAAAA' and @rifB is not null)
		begin
			if (month(@iniziocompetenza)>9) set @riferimentoA= 
				convert(varchar(2),month(@iniziocompetenza))+convert(varchar(4),year(@iniziocompetenza))
			if (month(@iniziocompetenza)<=9) set @riferimentoA= '0'+
				convert(varchar(2),month(@iniziocompetenza))+convert(varchar(4),year(@iniziocompetenza))
		end

		if (@rifA='00MM' and @riferimentoA is null)
			insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare il mese di riferimento');


		if (@rifA='MMAAAA' and @riferimentoA is null and @rifB is null)
			insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di pagamento');

		if (@rifA='MMAAAA' and @riferimentoA is null and @rifB is not null)
			insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di inizio competenza');

		if (@rifB = 'MMAAAA' )
		begin
			if (month(@finecompetenza)>9) set @riferimentoB= 
				convert(varchar(2),month(@finecompetenza))+convert(varchar(4),year(@finecompetenza))
			if (month(@finecompetenza)<=9) set @riferimentoB= '0'+
				convert(varchar(2),month(@finecompetenza))+convert(varchar(4),year(@finecompetenza))
		end

		if (@rifB = 'AAAA' )
		begin
			set @riferimentoB=convert(varchar(4),@anno)
		end


		if (@rifB='AAAA' and @riferimentoB is null)
			insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare l''anno di riferimento');

		if (@rifB='MMAAAA' and @riferimentoB is null)
			insert into #errori (iddbdepartment, taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp, @ymov, @nmov, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di fine competenza');


--sezione: ENTI LOCALI
		if @tipoente in ('CCCC','EE')
		begin
					
			select @fiscalyear = @anno  			
			
			-- CODICE ENTE LOCALE TAB T1 (EE)  
			-- SOLO 
			if @tipoEnte = 'EE'
			begin
				select @codice = case 
						when geo_country.idcountry = 21 then '03'--Bolzano
						when geo_country.idregion = 6 then '07'--Friuli Venezia Giulia
						when geo_country.idcountry = 22 then '18'--Trento
						when geo_country.idregion = 2 then '20'--Valle d'Aosta
						else '99' 
					end
					from geo_country
					join geo_city 
						on geo_city.idcountry = geo_country.idcountry
					where geo_city.idcity = @idcity
				
				select @descrente =  CASE @codice
									WHEN '03' THEN 'Bolzano'
									WHEN '07' THEN 'Friuli Venezia Giulia'
									WHEN '18' THEN 'Trento'
									WHEN '20' THEN 'Valle d''Aosta'
									ELSE NULL
							 END 
							 
				if @codice is null
					begin 
					insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov,  message)
						values (@iddbdepartment,@taxcode, @idexp, @ymov,@nmov,
						'Per il tributo con codice ' + isnull(@codiceTributo, '')
						+ ' la procedura non è stata in grado di ricavare il codice dell''ente 
						(provincia autonoma/regione)');
					end
			end
			
			
		end
		
				
		-- CODICE CATASTALE COMUNE (CCCC)  
		if @tipoEnte = 'CCCC'
		begin
			select @codice = geo_city_agency.value
				from geo_city_agency
				where geo_city_agency.idcity = @idcity
				and geo_city_agency.idagency = 1
				and geo_city_agency.idcode = 1
			
				select @descrente =  title from geo_city
				where idcity = @idcity
				
			if @codice is null
				begin 
				insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov, message)
					values (@iddbdepartment, @taxcode, @idexp,@ymov,@nmov,
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare il codice dell''ente 
					(comune)');
				end
		end
			
		--sezione: REGIONI  
		if @tipoente = 'RR'
		begin
			select  @codice = @idfiscaltaxregion
			
			select @descrente =  title from fiscaltaxregion
			where idfiscaltaxregion = @idfiscaltaxregion

	
			if @codice is null
			begin 
				insert into #errori (iddbdepartment,taxcode, idexp, ymov, nmov,  message)
					values (@iddbdepartment,@taxcode, @idexp,@ymov,@nmov,
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare il codice dell''ente (regione)');
			end
		end

	
		if ((isnull(@importoADebito,0) <> 0) or (isnull(@importoACredito,0) <> 0))
		begin
			insert into #f24 (tiporecord,tiporiga,codicetributo, codice, descrente, estremi, riferimentoA, riferimentoB, importoADebito, importoacredito)
				values ('V',@tiporiga, @codiceTributo, @codice,@descrente, @estremi, @riferimentoA, @riferimentoB, @importoADebito, @importoACredito)
		end
		
		SET @codice = null
		SET @descrente = null
		SET @estremi = null
		SET @riferimentoA = null
		SET @riferimentoB = null

		SET @codiceTributo =null
		SET @tipoente=null
		SET @tiporiga=null
		SET @rifA =null
		SET @rifB =null

		FETCH NEXT FROM @cursore INTO  @iddbdepartment,@codicetributo, @idexp, @ymov, @nmov,
			@idreg, @idcity,
			@idfiscaltaxregion, @geoappliance,
			@importoADebito, @importoACredito,
			@mese, @anno,
			@sanctioncode, @ayearsanction, @iniziocompetenza, @finecompetenza
	END
	
	if (EXISTS (SELECT * FROM #f24 WHERE tiporecord = 'V' AND isnull(declaration_on_behalf_of,'N')  = 'N')) 
	begin
		insert into #f24 (tiporecord)
		values ('M')
	end

	-- altri dettagli interventi sostitutivi
	CREATE TABLE #others_details
	(
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16),
		fiscaltaxcode varchar(4),		  -- codice tributo per intervento sostitutivo
		importoadebito decimal(19,2),
		importoacredito decimal(19,2),
		identifying_marks varchar(20),
		rifa_month int,
		rifa_year int,
		rifa varchar(10),
		rifb_month int, 
		rifb_year int,
		code varchar(10),
		tiporiga char(1)
	)
	
	
	-- Applicazione intervento sostitutivo per conto di
	INSERT INTO  #others_details
		(declaration_on_behalf_of,cf_contributor,fiscaltaxcode, importoadebito,importoacredito,
		 identifying_marks, rifa_month, rifa_year, rifa, rifb_month, rifb_year, code,tiporiga)
	SELECT  
		'S',
		registry.cf,
		Upper(fiscaltaxcode),
		importoadebito = IsNull(amount,0),
		importoacredito = 0,
		Upper(identifying_marks),
		rifa_month,
		rifa_year,
		Ltrim(Rtrim(Upper(rifa))),
		rifb_month,
		rifb_year,
		Ltrim(Rtrim(Upper(code))),
		Upper(tiporiga)
		FROM   unifiedclawback 
		JOIN   registry 
		  ON   registry.idreg = unifiedclawback.idreg  -- 
	   WHERE   unifiedclawback.idunifiedf24ep = @idunifiedf24ep


	declare @declaration_on_behalf_of char(1)
	declare @cf_contributor varchar(16)

	declare @identifying_marks varchar(20)
	declare @rifa_month int
	declare @rifa_year int
	declare @rif_a varchar(10)
	declare @rifb_month int
	declare @rifb_year int
	
	set @riferimentoA  = null
	set @riferimentoB  = null
	set @codiceTributo = null
	
	declare @cursore1 cursor
	
	set @cursore1 = cursor for 
		select declaration_on_behalf_of,cf_contributor,tiporiga, fiscaltaxcode, importoadebito,importoacredito,
			   code, identifying_marks, rifa_month, rifa_year, rifa, rifb_month, rifb_year
		from   #others_details
	
	open @cursore1
	fetch next from @cursore1 into  @declaration_on_behalf_of, @cf_contributor,
			@tiporiga, @codicetributo, @importoadebito,  @importoacredito,
			@codice, @identifying_marks, @rifa_month, @rifa_year, @rif_a,
			@rifb_month, @rifb_year
		
	while @@fetch_status = 0
	begin

		IF (@rif_a is not null) --  AAAA
				set @riferimentoA = @rif_a
				
		IF (@rifa_month is not null and @rifa_year is null) --  00MM
		begin
				if (@rifa_month>9) set @riferimentoA= '00'+convert(varchar(2),@rifa_month)
				if (@rifa_month<=9) set @riferimentoA= '000'+convert(varchar(2),@rifa_month)
		end
			
		IF (@rifa_month is null and @rifa_year is not null) --  AAAA
				set @riferimentoA =convert(varchar(4),@rifa_year)
				
		IF (@rifa_month is not null and @rifa_year is not null)  --MMAAAA
		begin
				if (@rifa_month>9) set @riferimentoA= convert(varchar(2),@rifa_month)+convert(varchar(4),@rifa_year)
				if (@rifa_month<=9) set @riferimentoA= '0'+convert(varchar(2),@rifa_month)+convert(varchar(4),@rifa_year)
		end
		
		IF (@rifb_month is not null and @rifb_year is null) --  00MM
		begin
				if (@rifb_month>9) set @riferimentoB= '00'+convert(varchar(2),@rifb_month)
				if (@rifb_month<=9) set @riferimentoB= '000'+convert(varchar(2),@rifb_month)
		end
		
		IF (@rifb_month is null and @rifb_year is not null) --  AAAA
			set @riferimentoB =convert(varchar(4),@rifb_year)
			
		IF (@rifb_month is not null and @rifb_year is not null)  --MMAAAA
		begin
				 if (@rifb_month>9) set @riferimentoB= convert(varchar(2),@rifb_month)+convert(varchar(4),@rifb_year)
				 if (@rifb_month<=9) set @riferimentoB= '0'+convert(varchar(2),@rifb_month)+convert(varchar(4),@rifb_year)
		end
		
		INSERT INTO #f24 (tiporecord, declaration_on_behalf_of,cf_contributor, tiporiga,codicetributo, 
						  codice, estremi, riferimentoA, riferimentoB, importoADebito, importoacredito)
		SELECT  'V', @declaration_on_behalf_of, @cf_contributor,
				@tiporiga, @codiceTributo,  
				@codice, @identifying_marks, @riferimentoA,  @riferimentoB,@importoadebito,@importoACredito
				
					set @riferimentoA  = null
					set @riferimentoB  = null
	

	fetch next from @cursore1 into @declaration_on_behalf_of, @cf_contributor,
			@tiporiga, @codicetributo, @importoadebito, @importoacredito, 
			@codice, @identifying_marks, @rifa_month, @rifa_year, @rif_a,
			@rifb_month, @rifb_year
	end
	
  --select  * from #f24 order by codicetributo
  --insert into #f24 (tiporecord, declaration_on_behalf_of, cf_contributor)
	 --SELECT DISTINCT 'M',declaration_on_behalf_of, cf_contributor 
	 --FROM #f24 WHERE cf_contributor IS NOT NULL
	 
	
	if (select count(*) from #errori) > 0
	begin
		select 
			'Dipartimento' = #errori.iddbdepartment,
			--'Ritenuta' = tax.taxref,
			'Eserc.movim.' = #errori.ymov,
			'Num.movim.' = #errori.nmov,
			'Problema riscontrato' = #errori.message
			from #errori
			left outer join tax on tax.taxcode = #errori.taxcode
			order by #errori.iddbdepartment,tax.taxref
	end else begin
			select 
		 @cf_agency as 'CF Ente', 
		 @agency as 'Ente dichiarante',  
		 @email_f24 as 'Email',    
		 @iban_f24 as 'Iban di addebito',  
		 @idunifiedf24ep as 'Numero', 
		 @anno  as  'Esercizio',
		 @paymentdate as  'Data di addebito',
		 @nmonth  as 'Mese dichiarazione', 
		declaration_on_behalf_of as 'Intervento Sostitutivo', 
		cf_contributor as 'Per conto di', 
		CASE #f24.tiporiga 
			WHEN 'F' THEN 'ERARIO'
			WHEN 'N' THEN 'ERARIO'
			WHEN 'S' THEN 'ENTI LOCALI'
			WHEN 'R' THEN 'REGIONI'
			WHEN 'I' THEN 'INPS'
			WHEN 'Q' THEN 'INPDAP'
		END  as 'Tipo Tributo',
		#f24.codicetributo as 'Cod. Tributo o Sanzione', 
		#tributi.descrtributo as 'Tributo',
		codice as 'Codice Ente di riferimento', 
		descrente as 'Ente di riferimento', 
		estremi as 'Estremi',
		riferimentoA as 'Riferimento A (MM/AAAA)',
		riferimentoB as 'Riferimento B (MM/AAAA)',
		sum(importoADebito) as 'Importo a debito',
		sum(importoACredito) as 'Importo a credito'
		from #f24 
		left outer join #tributi on  #f24.codicetributo = #tributi.codicetributo
		--WHERE tiporecord = 'V' AND #f24.codicetributo  IN ('150E', '134E','126E','153E','127E','154E','133E')
 
		group by tiporecord, declaration_on_behalf_of, cf_contributor,#f24.tiporiga,#f24.codicetributo,
		#tributi.descrtributo, codice, descrente, estremi,riferimentoA,riferimentoB
		order by cf_contributor, #f24.tiporiga, #f24.codicetributo,estremi,riferimentoA,riferimentoB
			
		
	end
	
end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

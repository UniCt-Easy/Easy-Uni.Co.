
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_f24ordinario_dati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_f24ordinario_dati]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione'
--setuser 'amm'
--EXEC exp_f24ordinario_dati 8
CREATE procedure exp_f24ordinario_dati(@idf24ordinario int) as
begin

	create table #tributi (
	 
		tiporiga char(1),
		codicetributo varchar(10),
		descrtributo varchar(400),
		tipoente varchar(4),
		rifA varchar(10),
		rifB  varchar(10)
	)
 
	--exec exp_f24ordinario_dati 42
	declare @ayear int
	declare @taxpay_start datetime
	declare @taxpay_stop  datetime
	declare @nmonth  int
	declare @paymentdate  datetime

	select @paymentdate  = paymentdate,  
		   @ayear = ayear,
		   @nmonth = nmonth,
		   @taxpay_start = taxpay_start,
		   @taxpay_stop = taxpay_stop
	from   f24ordinario where idf24ordinario = @idf24ordinario

	/*
	F: ERARIO n.6
	I: INPS n.4
	R: REGIONI n.4
	S: ENTI LOCALI n.4
	N: INAIL n.3
	Q: INPDAP nell'F24 ordinario non sono previsti
	*/
	insert into #tributi values ('S','3848', 'Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo',
								'CCCC','00MM','AAAA') -- 384E Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ('S','3847','Addizionale comunale Irpef trattenuta dai sostituti d’imposta- acconto',
							'CCCC','00MM','AAAA') -- 385E Addizionale comunale Irpef trattenuta dai sostituti d’imposta- acconto 
	insert into #tributi values ('S','8926','Sanzioni per ravvedimento su Addizionale comunale Irpef trattenuta dai sostituti d’imposta ',
							'CCCC',  null,'AAAA') -- 891E Sanzioni per ravvedimento su Addizionale comunale Irpef trattenuta dai sostituti d’imposta 
	
	insert into #tributi values ('R','3858', 'IRAP', 'RR','00MM','AAAA') -- 380E IRAP  	
	insert into #tributi values ('R','3802', 'Addizionale regionale Irpef trattenuta dai sostituti d’imposta  ', 'RR','00MM','AAAA') -- 381E Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ('R','8907', 'Sanzioni per ravvedimento su IRAP ', 'RR',  null,'AAAA') -- 892E Sanzioni per ravvedimento su IRAP 
	insert into #tributi values ('R','8902',  'Sanzioni per ravvedimento Addizionale regionale Irpef trattenuta dai sostituti d’imposta  ','RR',  null,'AAAA') -- 893E Sanzioni per ravvedimento Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	
	insert into #tributi values ('F','1001', 'Ritenute sui redditi da lavoro dipendente ed assimilati  ', null,'00MM','AAAA') -- 100E Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ('F','1040',  'Ritenute sui redditi da lavoro autonomo  ',null,'00MM','AAAA') -- 104E Ritenute sui redditi da lavoro autonomo  
	insert into #tributi values ('F','1052', 'Ritenute sulle indennità di esproprio, occupazione , etc. - articolo 11, legge 413/91', null,'00MM','AAAA') -- 105E Ritenute sulle indennità di esproprio, occupazione , etc. - articolo 11, legge 413/91  
	insert into #tributi values ('F','1045', 'Ritenute sui contributi corrisposti alle imprese - articolo 28 D.P.R. 600/73 ', null,'00MM','AAAA') -- 106E Ritenute sui contributi corrisposti alle imprese - articolo 28 D.P.R. 600/73 
/**/insert into #tributi values ('F','_107', 'Altre ritenute alla fonte  ', null,'00MM','AAAA') -- 107E Altre ritenute alla fonte  
/**/insert into #tributi values ('F','_890', 'Sanzioni per ravvedimento su ritenute erariali ',null,  null,'AAAA') -- 890E Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('F','1049', 'Ritenuta alla fonte su somme pignorate ', null,'00MM','AAAA') -- 112E Ritenuta alla fonte su somme pignorate 

/**/insert into #tributi values ('I','_C10',  'Contributi dovuti per soggetti non titolari di pensione (diretta o indiretta), e non titolari di ulteriori contemporanei rapporti assicurativi. ',null,  'MMAAAA',null)		-- C10 Sanzioni per ravvedimento su ritenute erariali 
/**/insert into #tributi values ('I','_CXX','Contributi dovuti per soggetti titolari di pensione (diretta o indiretta) e/o di ulteriori contemporanei rapporti assicurativi. ',   null,  'MMAAAA',null)		-- CXX Sanzioni per ravvedimento su ritenute erariali 
/**/insert into #tributi values ('Q','_101','CASSA C.P.T.S. - CONTRIBUTI OBBLIGATORI', null,  'MMAAAA','MMAAAA')	-- P101 Sanzioni per ravvedimento su ritenute erariali 
/**/insert into #tributi values ('Q','_909', 'CASSA UNICA DEL CREDITO - CREDITO',null,  'MMAAAA','MMAAAA')	-- P909 Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('F','1631', 'SOMME A TITOLO DI IMPOSTE ERARIALI RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)',  null,  null,'AAAA')		-- 150E SOMME A TITOLO DI IMPOSTE ERARIALI RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)
	insert into #tributi values ('F','4731', 'IRPEF A SALDO TRATTENUTA DAL SOSTITUTO D''IMPOSTA',null, '00MM','AAAA')		-- 134E IRPEF A SALDO TRATTENUTA DAL SOSTITUTO D''IMPOSTA
	insert into #tributi values ('F','3803', 'ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE',  'RR', null,'AAAA')			-- 126E ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE
	insert into #tributi values ('R','3796', 'SOMME A TITOLO DI ADDIZIONALE REGIONALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1, LETT.A)D.LGS. N. 175/2014','RR', null, 'AAAA')		-- 153E SOMME A TITOLO DI ADDIZIONALE REGIONALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('S','3845', 'ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO – ',  'CCCC','00MM','AAAA')		-- 127E ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO –
	insert into #tributi values ('S','3846', 'ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730 -',  'CCCC','00MM','AAAA')		-- 128E ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- 
	insert into #tributi values ('S','3797', 'SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014','CCCC', null,'AAAA')		-- 154E SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('F','4730', 'IRPEF IN ACCONTO TRATTENUTA DAL SOSTITUTO D''IMPOSTA',null , '00MM','AAAA')		-- 133E SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014

	-- inserire qui i codici tributo a credito
	
	--insert into #tributi values ('S','1669','CCCC','00MM','AAAA') -- 161E Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	  insert into #tributi values ('S','1669','Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo','RR',null,'AAAA') -- 161E Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	
	insert into #tributi values ('R','1671',  'Addizionale regionale Irpef trattenuta dai sostituti d’imposta',  'RR',null,'AAAA') -- 160E Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ('F','1628', 'Ritenute sui redditi da lavoro autonomo', null, null,'AAAA') -- 156E Ritenute sui redditi da lavoro autonomo  	
	insert into #tributi values ('F','1627',  'Ritenute sui redditi da lavoro dipendente ed assimilati', null, null,'AAAA') -- 155E Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ('F','1701',   'Bonus fiscale',null,'00MM','AAAA') -- 165E Bonus fiscale 
	
	insert into #tributi values ('F','6001','VERSAMENTO IVA MENSILE GENNAIO', null, null,'AAA')--	601E "VERSAMENTO IVA MENSILE GENNAIO"
	insert into #tributi values ('F','6002','VERSAMENTO IVA MENSILE FEBBRAIO', null, null,'AAA')--	602E "VERSAMENTO IVA MENSILE FEBBRAIO"
	insert into #tributi values ('F','6003','VERSAMENTO IVA MENSILE MARZO', null, null,'AAA')--	603E "VERSAMENTO IVA MENSILE MARZO"
	insert into #tributi values ('F','6004','VERSAMENTO IVA MENSILE APRILE', null, null,'AAA')--	604E "VERSAMENTO IVA MENSILE APRILE"
	insert into #tributi values ('F','6005','VERSAMENTO IVA MENSILE MAGGIO', null, null,'AAA')--	605E "VERSAMENTO IVA MENSILE MAGGIO"
	insert into #tributi values ('F','6006','VERSAMENTO IVA MENSILE GIUGNO', null, null,'AAA')--	606E "VERSAMENTO IVA MENSILE GIUGNO"
	insert into #tributi values ('F','6007','VERSAMENTO IVA MENSILE LUGLIO', null, null,'AAA')--	607E "VERSAMENTO IVA MENSILE LUGLIO"
	insert into #tributi values ('F','6008','VERSAMENTO IVA MENSILE AGOSTO', null, null,'AAA')--	608E "VERSAMENTO IVA MENSILE AGOSTO"
	insert into #tributi values ('F','6009','VERSAMENTO IVA MENSILE SETTEMBRE', null, null,'AAA')--	609E "VERSAMENTO IVA MENSILE SETTEMBRE"
	insert into #tributi values ('F','6010','VERSAMENTO IVA MENSILE OTTOBRE', null, null,'AAA')--	610E "VERSAMENTO IVA MENSILE OTTOBRE"
	insert into #tributi values ('F','6011','VERSAMENTO IVA MENSILE NOVEMBRE', null, null,'AAA')--	611E "VERSAMENTO IVA MENSILE NOVEMBRE"
	insert into #tributi values ('F','6012','VERSAMENTO IVA MENSILE DICEMBRE', null, null,'AAA')--	612E "VERSAMENTO IVA MENSILE DICEMBRE"

	insert into #tributi values ('F','6013','VERSAMENTO ACCONTO PER IVA MENSILE',null, null,'AAAA')-- 613E	VERSAMENTO ACCONTO PER IVA MENSILE
	insert into #tributi values ('F','6031','VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE',null, null,'AAAA')-- 614E	VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE
	insert into #tributi values ('F','6032','VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE',null, null,'AAAA')-- 615E	VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE
	insert into #tributi values ('F','6033','VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE',null, null,'AAAA')-- 616E	VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE
	insert into #tributi values ('F','6034','VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE',null, null,'AAAA')-- 617E	VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE 
	insert into #tributi values ('F','6035','VERSAMENTO IVA ACCONTO ',null, null,'AAAA')-- 618E	VERSAMENTO IVA ACCONTO  
	insert into #tributi values ('F','6099','VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE',null, null,'AAAA')-- 619E	VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE
	insert into #tributi values ('F','6040','SPLIT ISTITUZIONALE',null,'00MM','AAAA')-- 620E	SPLIT ISTITUZIONALE
	insert into #tributi values ('F','6041','SPLIT COMMERCIALE',null,'00MM','AAAA')-- 621E	SPLIT COMMERCIALE
	insert into #tributi values ('F','6043','INTRA 12',null,'00MM','AAAA')-- 622E	INTRA 12
	insert into #tributi values ('F','8904','SANZIONE PECUNIARIA IVA',null, null,'AAAA')-- 801E	SANZIONE PECUNIARIA IVA
	insert into #tributi values ('F','9399','REGOLARIZZAZIONE OPERAZIONI IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.',null,null,'AAAA')-- 901E	REGOLARIZZAZIONE OPERAZIONI SOGGETTE AD IVA IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.

	--declare @annodichiarazione int
	--set @annodichiarazione = 2008
	
	--select * from #tributi

	create table #f24 (
		tiporecord char(1), -- M o V; M = dati anagrafici, V = dati contabili
		tiporiga char(1),
		codicetributo varchar(10),
		codice  varchar(10), -- ex codice ente
		descrente varchar(200),
		estremi varchar(17),
		riferimentoA varchar(10),
		riferimentoB varchar(10),
		importoADebito decimal(19,2),
		importoACredito decimal(19,2),
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16), -- codice fiscale debitore per intervento sostitutivo
		--- f24 ordinariodetail
		codiceufficio	varchar(10),			--Codice ufficio finanziario - Sezione ERARIO. 
		codiceatto	varchar(20),				--Codice Atto - Sezione ERARIO
		ravvedimentooperoso	char(1),			--Ravvedimento Operoso(S/N) - SEZIONE IMU E ALTRI TRIBUTI LOCALI 
		immobilivariati	char(1),				--Immobili variati(S/N) - SEZIONE IMU E ALTRI TRIBUTI LOCALI
		accontosaldo	char(1),				--Acconto/Saldo -  SEZIONE IMU E ALTRI TRIBUTI LOCALI 
		numeroimmobili	int	,					--Ravvedimento Operoso(S/N) - SEZIONE IMU E ALTRI TRIBUTI LOCALI 
		idfiscaltaxregion	varchar(5),			--Codice Regione( tabella fiscaltaxregion) : Sezione REGIONI
		detrazioneabitazione	decimal	(19,2),	--Importo Detrazione abitazione principale  - Sezione IMU ed Altri Tributi Locali
		idaltrienti	varchar(10),				--Codice altri enti Previdenziali ed Assicurativi   (Tabella f24altrientiprevidenzialiassicurativi ) - SEZIONE Altri Enti previdenziali ed assicurativi
		idcodicesedealtrienti varchar(10),		--Codice Sede - Sezione Altri Enti previdenziali ed assicurativi. Campo libero.
		codiceposizione	varchar(10),			--Codice posizione - Sezione Altri Enti previdenziali ed assicurativi. Campo libero.
	
		identificativooperazione	varchar(20),-- Identificativo Operazione - Sezione IMU ed Altri Tributi Locali
		--identelocale	int	,					-- Codice ente/prov/Comune [4]: Codice ente [2]
		--idprovincia	varchar(10),			-- Codice ente/prov/Comune [4]: codice regione [2]
		--catastalecomune	varchar(10),		-- Codice ente/prov/Comune [4]: codice catastale [4]
		codiceente_provincia_comune varchar(4),
		codiceditta	varchar(8),					--Codice ditta - Sezione INAIL
		cc_codiceditta	varchar(2),				--Codice controllo (c.c.) del Codice Ditta - Sezione INAIL
		numerodiriferimento	varchar(6),			--Numero di riferimento - Sezione INAIL
		causaleinail	char(1),						--Causale - Sezione INAIL
		codicesedeinail	varchar	(10)			--ID Codice Sede INAIL (tabella f24sediinail) - Sezione INAIL
	)

	declare @matricolaInpsF24 varchar(50)
	select @matricolaInpsF24 = matricolainpsf24 from config where ayear = @ayear
	declare @codicesedeINPS varchar(4)
	declare @sedeINPS varchar(100)
	select  @codicesedeINPS = inpscenter.othercentercode,
			@sedeINPS = inpscenter.title
			from inpscenter 
			join config 
				on inpscenter.idinpscenter = config.idinpscenter
			where config.ayear=@ayear

	declare @sedeInail varchar(100)
	select @sedeInail = nomesede from f24sediinail where codicesede = @codicesedeINPS

	insert into #f24(
		tiporecord,
		codicetributo,
		tiporiga ,
		importoADebito,	importoACredito,
		riferimentoA,	riferimentoB,

		codiceufficio,
		codiceatto	,
		ravvedimentooperoso,
		immobilivariati	,
		accontosaldo	,
		numeroimmobili	,
		idfiscaltaxregion,
		detrazioneabitazione,
		idaltrienti,
		idcodicesedealtrienti,
		codiceposizione	,
	
		identificativooperazione,
		codiceente_provincia_comune ,
	
		codiceditta	,
		cc_codiceditta,
		numerodiriferimento	,
		causaleinail,
		codicesedeinail
		)
	SELECT 
		'V',
		codicetributo,
		idf24sezione,
		sum(importoadebito),	sum(importoacredito),
		riferimentoa,	riferimentob,

		codiceufficio,
		codiceatto	,
		ravvedimentooperoso,
		immobilivariati	,
		accontosaldo	,
		numeroimmobili	,
		idfiscaltaxregion,
	
		sum(detrazioneabitazione),
		idaltrienti,
		idcodicesedealtrienti,
		codiceposizione	,
	
		identificativooperazione,
		--codiceente_provincia_comune ,
		coalesce(convert(varchar(4),identelocale), convert(varchar(4),idprovincia),catastalecomune),
		codiceditta	,
		cc_codiceditta,
		numerodiriferimento	,
		causaleinail	,
		codicesedeinail
	FROM f24ordinariodetail O
	WHERE O.idf24ordinario= @idf24ordinario
	group by 	codicetributo,
		riferimentoa,	riferimentob,

		codiceufficio,	codiceatto	,	ravvedimentooperoso,
		immobilivariati	,	accontosaldo	,	numeroimmobili	,
		idaltrienti	,
		idfiscaltaxregion,
	
		idaltrienti,
		idcodicesedealtrienti,
		codiceposizione	,
	
		identificativooperazione,
		--codiceente_provincia_comune ,
		coalesce(convert(varchar(4),identelocale), convert(varchar(4),idprovincia),catastalecomune),
		idf24sezione,
		codiceditta	,
		cc_codiceditta,
		numerodiriferimento	,
		causaleinail	,
		codicesedeinail

	declare @NomeAltriEnti varchar(100)
	select @NomeAltriEnti = a.descrizione
		from f24altrientiprevidenzialiassicurativi a
		join #f24 f on f.idaltrienti = a.idaltrienti

	declare @SedeAltriEnti varchar(100)
	select @SedeAltriEnti = a.descrizione
		from f24sedialtrienti a
		join #f24 f on f.idaltrienti = a.idaltrienti

	create table #errori (
		taxcode int,
		idexp int,
		ytaxpay smallint,
		ntaxpay int,
		message varchar(200)
	)

	insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
		select taxpay.taxcode, null, taxpay.ytaxpay, taxpay.ntaxpay,
		'Il tributo '+isnull(tax.taxref,'')+' ha il codice '+
		isnull(tax.fiscaltaxcodef24ord,'')+
		' che non è gestito dalla procedura di generazione del modello f24ep'
		from taxpay 
		join tax on tax.taxcode = taxpay.taxcode
		where idf24ordinario= @idf24ordinario
		and not exists (select * from #tributi where #tributi.codicetributo = tax.fiscaltaxcodef24ord OR #tributi.codicetributo = tax.fiscaltaxcodecreditf24ord)

	if (select count(*) from #errori) > 0
	begin
		select * from #errori
		return
	end

	declare @codiceTributo varchar(10)
	declare @importoADebito decimal(19,2)
	declare @importoACredito decimal(19,2)
	declare @tiporiga char(1)
	declare @codice  varchar(10) --ex codiceEnte
	declare @descrente varchar(200)
	declare @estremi varchar(17)
	declare @riferimentoA varchar(10)
	declare @riferimentoB varchar(10)

	declare @rifA varchar(10)
	declare @rifB varchar(10)


	declare @taxcode int
	declare @idexp int
	declare @transmissiondate datetime
	declare @ytaxpay smallint
	declare @ntaxpay int
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
	declare @annotrasmissione smallint
	declare @iniziocompetenza datetime
	declare @finecompetenza datetime
	declare @mese int
	declare @anno smallint
	declare @mycity varchar(100)
	declare @mycap	varchar(5)
	declare @importo decimal(19,2) 

	declare @cf_agency varchar(20)  
	declare @agency   varchar(100)
	declare @iban_f24  varchar(50)
	declare @email_f24  varchar(50)
	select @cf_agency  = license.cf from license
	select @agency  = license.agency from license
	--select @iban_f24 = config.iban_f24 from config where ayear = @ayear
	select @email_f24 = config.email_f24 from config where ayear = @ayear		

	create table #versamenti (
		kind char(1),
		geoappliance char(1),
		fiscaltaxcode24ord varchar(10),
		maintaxcode int,
		taxcode int,
		idcity  int,
		idfiscaltaxregion varchar(5),
		idexp int,
		idreg int,
		ytaxpay smallint,
		ntaxpay int,
		sanctioncode varchar(4),
		cafcode varchar(4),
		ayearsanction smallint,
		importoadebito decimal(19,2),
		importoacredito decimal(19,2),
		datatrasmissione datetime,
		annotrasmissione smallint,
		iniziocompetenza datetime,--da expenselast
		finecompetenza datetime, --da expenselast
		anno smallint,
		meseriferimento int
		)
	
	-- dettagli ritenute con i loro importi originali e i codici tributi relativi alle ritenute originali, anche se aggregate nella liquidazione, 
	-- in caso di correzioni ritenute   
	INSERT INTO  #versamenti
	(maintaxcode, taxcode,idcity, geoappliance,idfiscaltaxregion, idexp,idreg, ytaxpay, ntaxpay, 
	importoadebito, importoacredito, datatrasmissione, annotrasmissione, meseriferimento,iniziocompetenza,finecompetenza, anno)
	select maintaxcode = taxpay.taxcode, tax.taxcode, expensetax.idcity,tax.geoappliance,
		expensetax.idfiscaltaxregion, 
		expensetax.idexp, expense.idreg, taxpay.ytaxpay, taxpay.ntaxpay,
		CASE WHEN isnull(admintax,0)+isnull(employtax,0) > 0  THEN isnull(admintax,0)+isnull(employtax,0)  ELSE 0 END,
		CASE WHEN isnull(admintax,0)+isnull(employtax,0) < 0  THEN -(isnull(admintax,0)+isnull(employtax,0))  ELSE 0 END,
		paymenttransmission.transmissiondate, 
		year(paymenttransmission.transmissiondate),
		month(paymenttransmission.transmissiondate),
		expenselast.servicestart,expenselast.servicestop,
		isnull(expensetax.ayear,year(paymenttransmission.transmissiondate))
		--expensetax.ayear
		from taxpay 
		join expensetax 
			on expensetax.ytaxpay = taxpay.ytaxpay
			and expensetax.ntaxpay = taxpay.ntaxpay
		join tax on  tax.taxcode = expensetax.taxcode
		join expense
			on expense.idexp = expensetax.idexp
		join expenselast 
			on expenselast.idexp = expense.idexp
		join payment 
			on payment.kpay = expenselast.kpay
		join paymenttransmission 
			on paymenttransmission.kpaymenttransmission = 
			payment.kpaymenttransmission
		where taxpay.idf24ordinario = @idf24ordinario

	
	-- correzioni di dettagli ritenute con i loro importi relativi alle ritenute originali,
	-- anche se aggregate ad altre ritenute nella liquidazione
	 
	INSERT INTO  #versamenti
	(maintaxcode, taxcode,idcity, idfiscaltaxregion,geoappliance, idexp, idreg, ytaxpay, ntaxpay, importoadebito,importoacredito,
	 datatrasmissione, annotrasmissione, meseriferimento,iniziocompetenza,finecompetenza, anno)
	 SELECT   maintaxcode = taxpay.taxcode, tax.taxcode,expensetaxcorrige.idcity, tax.geoappliance,
	 expensetaxcorrige.idfiscaltaxregion,
	 expensetaxcorrige.idexp,expense.idreg, taxpay.ytaxpay, taxpay.ntaxpay,
	 CASE WHEN isnull(adminamount,0)+isnull(employamount,0) > 0  THEN isnull(adminamount,0)+isnull(employamount,0)  ELSE 0 END,
	 CASE WHEN isnull(adminamount,0)+isnull(employamount,0) < 0 THEN -(isnull(adminamount,0)+isnull(employamount,0))  ELSE 0 END,
	 paymenttransmission.transmissiondate, 
	 year(paymenttransmission.transmissiondate),
	 month(paymenttransmission.transmissiondate),
	 expenselast.servicestart,expenselast.servicestop,
	 isnull(expensetaxcorrige.ayear,year(paymenttransmission.transmissiondate))
	 --expensetax.ayear
	 FROM taxpay 
	 JOIN expensetaxcorrige 
		ON expensetaxcorrige.ytaxpay = taxpay.ytaxpay
		AND expensetaxcorrige.ntaxpay = taxpay.ntaxpay
	 JOIN tax 
		ON expensetaxcorrige.taxcode = tax.taxcode
	 JOIN expense
		ON expense.idexp = expensetaxcorrige.idexp
	 JOIN expenselast 
		ON expenselast.idexp = expense.idexp
	 JOIN payment 
		ON payment.kpay = expenselast.kpay
	 JOIN paymenttransmission 
		ON paymenttransmission.kpaymenttransmission = 
		payment.kpaymenttransmission
	 WHERE taxpay.idf24ordinario = @idf24ordinario
 
	 update #versamenti set meseriferimento=12 where anno<year(datatrasmissione)
	 update #versamenti set anno=year(datatrasmissione)-1 where anno<year(datatrasmissione)
	 --select taxcode, meseriferimento, sum(importoadebito), sum(importoacredito) from #versamenti group by taxcode, meseriferimento
			--select * from #versamenti where taxcode = 7
	--select * from #versamenti
	-- Sanzioni per Ravvedimento Operoso
	--INSERT INTO  #versamenti
	--	(sanctioncode,idcity,idfiscaltaxregion,importoadebito, importoacredito, ayearsanction)
	--SELECT fiscaltaxcode24ord,
	--	ISNULL(idcity,0),
	--	idfiscaltaxregion,
	--	importoadebito = isnull(amount,0),
	--	importoacredito = 0,
	--	f24epsanction.ayear
	--	FROM   f24epsanction 
	--	JOIN   f24epsanctionkind  
	--	ON f24epsanction.idsanction = f24epsanctionkind.idsanction
	--	WHERE  f24epsanction.idf24ordinario = @idf24ordinario

	
		UPDATE #versamenti  SET fiscaltaxcode24ord = 
		CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecreditf24ord IS NOT NULL ) THEN tax.fiscaltaxcodecreditf24ord ELSE tax.fiscaltaxcodef24ord END,
		kind =  CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecreditf24ord IS NOT NULL ) THEN 'C' ELSE 'D' END
		FROM tax WHERE  tax.taxcode = #versamenti.taxcode  

 
		UPDATE #versamenti SET importoadebito = importoadebito - importoacredito, importoacredito = 0 WHERE kind = 'D'
		UPDATE #versamenti SET importoacredito = importoacredito - importoadebito, importoadebito = 0 WHERE kind = 'C'  --- bonus fiscale ha solo un codice a credito

		--select * from #versamenti
--- aggrego i dati estratti per codice ritenuta, segno importo e flag "compensa"
--select * from #versamenti
	CREATE	TABLE #tot_versamenti (
		taxcode int,
		fiscaltaxcode24ord varchar(10),
		geoappliance char(1),
		idcity  int,
		idfiscaltaxregion varchar(5),
		idexp int,
		idreg int,
		ytaxpay int,
		ntaxpay int,
		sanctioncode varchar(4),
		cafcode varchar(4),
		ayearsanction smallint,
		importoadebito decimal(19,2),
		importoacredito decimal(19,2),
		datatrasmissione datetime,
		annotrasmissione smallint,
		iniziocompetenza datetime,--da expenselast
		finecompetenza datetime, --da expenselast
		anno smallint,
		meseriferimento int
		)

		INSERT INTO #tot_versamenti
		(	
			fiscaltaxcode24ord,
			idcity,
			idfiscaltaxregion,
			geoappliance,
			idexp,
			idreg ,
			ytaxpay ,
			ntaxpay ,
			sanctioncode ,
			ayearsanction ,
			importoadebito ,
			importoacredito ,
			datatrasmissione ,
			annotrasmissione ,
			iniziocompetenza ,--da expenselast
			finecompetenza , --da expenselast
			anno ,
			meseriferimento 
		)
		SELECT	
			fiscaltaxcode24ord,
			idcity,
			idfiscaltaxregion,
			geoappliance,
			idexp,
			idreg,
			ytaxpay,
			ntaxpay,
			sanctioncode,
			ayearsanction,
			SUM(importoadebito),
			SUM(importoacredito),
			datatrasmissione,
			annotrasmissione,
			iniziocompetenza,--da expenselast
			finecompetenza, --da expenselast
			anno,
			meseriferimento 
	FROM    #versamenti
	GROUP BY fiscaltaxcode24ord,taxcode,idcity,idfiscaltaxregion,geoappliance,idexp,idreg ,ytaxpay ,ntaxpay ,
		     sanctioncode,ayearsanction, datatrasmissione , annotrasmissione ,
			 iniziocompetenza,/*da expenselast*/ finecompetenza, /*da expenselast*/ anno, meseriferimento 

--SELECT * FROM #tot_versamenti
--  altri dettagli inseriti manualmente
	CREATE TABLE #others_details
	(
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16),
		fiscaltaxcode24ord varchar(10),		  -- codice tributo per intervento sostitutivo
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
	--INSERT INTO  #others_details
	--	(declaration_on_behalf_of,cf_contributor,fiscaltaxcode24ord, importoadebito,importoacredito,
	--	 identifying_marks, rifa_month, rifa_year, rifa, rifb_month, rifb_year, code,tiporiga)
	--SELECT  
	--	'S',
	--	registry.cf,
	--	Upper(fiscaltaxcode24ord),
	--	importoadebito = IsNull(amount,0),
	--	importoacredito = 0,
	--	Upper(identifying_marks),
	--	rifa_month,
	--	rifa_year,
	--	Ltrim(Rtrim(Upper(rifa))),
	--	rifb_month,
	--	rifb_year,
	--	Ltrim(Rtrim(Upper(code))),
	--	Upper(tiporiga)
	--	FROM   expenseclawback 
	--	JOIN   expense 
	--	  ON   expenseclawback.idexp = expense.idexp 
	--	JOIN   registry 
	--	  ON   registry.idreg = expense.idreg  -- 
	--   WHERE   expenseclawback.idf24ordinario = @idf24ordinario
		--select  * from registry where cf ='80166370587'
-- Liquidazione IVA
	CREATE TABLE #ivapay(
		rif_month int,
		rif_year int,
		totaliva_comm_aDebito  decimal(19,2),--601E	602E	603E	604E	605E	606E	607E	608E	609E	610E	611E	612E
		totaliva_comm_aCredito  decimal(19,2),
		totaliva_splitcomm  decimal(19,2),	--621E
		totalsplitist_aDebito decimal(19,2),	--620E
		totalintra12_aCredito decimal(19,2),	--622E
		totalintra12_aDebito decimal(19,2),	--622E
		totaliva_comm_aDebito_acc  decimal(19,2),	totaliva_comm_aCredito_acc  decimal(19,2), -- 618E
		fiscaltaxcode24ord varchar(10)
	)
	


	INSERT INTO  #ivapay(
		rif_month,
		rif_year,
		totaliva_comm_aDebito,	totaliva_comm_aCredito,
		totalsplitist_aDebito,
		totalintra12_aDebito, totalintra12_aCredito
		)
	select 
		month(ivapay.start),
		ivapay.yivapay,
		isnull(totaldebit,0), isnull(totalcredit,0),
		isnull(totaldebitsplit,0),
		isnull(totaldebit12,0) ,	isnull(totalcredit12,0)
		from ivapay 
		where ivapay.idf24ordinario = @idf24ordinario and paymentkind='C'

	INSERT INTO  #ivapay(
		rif_month,
		rif_year,
		totaliva_splitcomm 
		)
	select 
		month(ivapay.start),
		ivapay.yivapay,
		--Reg. Acquisti: iva totale - iva a credito
		isnull(ivapaydetailview.ivatotal,0) - (isnull(ivanet,0) + isnull(ivanetdeferred,0) )
		from ivapay 
		join ivapaydetailview
			on ivapay.yivapay = ivapaydetailview.yivapay and ivapay.nivapay = ivapaydetailview.nivapay
		where ivapay.idf24ordinario = @idf24ordinario
		and ivapaydetailview.registerclass ='A'
		and paymentkind='C'
		and isnull(ivapaydetailview.ivatotal,0) - (isnull(ivanet,0) + isnull(ivanetdeferred,0) ) >0

	update #ivapay set totaliva_comm_aCredito = isnull(totaliva_comm_aCredito,0) - isnull(totaliva_splitcomm,0)
	-- Inserisce l'Acconto
		INSERT INTO  #ivapay(
		rif_month,
		rif_year,
		totaliva_comm_aDebito_acc,	totaliva_comm_aCredito_acc
	)
	select 
		month(ivapay.start),
		ivapay.yivapay,
		isnull(totaldebit,0), isnull(totalcredit,0)
		from ivapay 
		where ivapay.idf24ordinario = @idf24ordinario and paymentkind='A'

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, riferimentoA,*/ riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		case rif_month	
				when 1 then '6001'	when 2 then '6002' when 3 then '6003' when 4	then '6004' when 5 then '6005' when 6 then '6006' 
				when 7 then '6007'	when 8 then '6008' when 9 then '6009' when 10	then '6010' when 11 then '6011' when 12 then '6012' 
		end,
		convert(varchar(4),rif_year),
		totaliva_comm_aDebito,	totaliva_comm_aCredito
	from #ivapay

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'6040',
		case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totalsplitist_aDebito,	null
	from #ivapay
	where isnull(totalsplitist_aDebito,0) >0

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'6041',
			case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totaliva_splitcomm,null
	from #ivapay
	where isnull(totaliva_splitcomm,0)>0

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'6043',
				case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totalintra12_aDebito, totalintra12_aCredito
	from #ivapay
	where isnull(totalintra12_aDebito,0)>0 or isnull(totalintra12_aDebito,0)>0

	
	
	
	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, riferimentoA,*/ riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'6035',
		convert(varchar(4),rif_year),
		isnull(totaliva_comm_aDebito_acc,0),	isnull(totaliva_comm_aCredito_acc,0)
	from #ivapay
	where isnull(totaliva_comm_aDebito_acc,0) > 0 or isnull(totaliva_comm_aCredito_acc,0)>0

	

	--select 2,* from #versamenti
	--select * from #versamenti
	--drop table #versamenti
	declare  @myfiscalregion varchar(4)
	declare	 @myidcity int
	select	 @myidcity=max(idcity) from	license
	select	 @mycity = title from geo_city where idcity= @myidcity
	select   @mycap= max(cap) from license
	select   @myfiscalregion= idfiscaltaxregion from geo_cityfiscalview where idcity=@myidcity

	declare @cursore cursor


	set @cursore = cursor for 
		select fiscaltaxcode24ord, idexp, idreg, idcity,idfiscaltaxregion,geoappliance, ytaxpay, ntaxpay, 
		importoadebito,importoacredito, datatrasmissione, annotrasmissione, meseriferimento, anno,
		sanctioncode, ayearsanction, iniziocompetenza,finecompetenza
		from #tot_versamenti
	
	open @cursore
	fetch next from @cursore into @codicetributo, @idexp, @idreg, @idcity,
			@idfiscaltaxregion,@geoappliance, @ytaxpay, @ntaxpay, 
			@importoADebito,@importoacredito, @transmissiondate, @annotrasmissione, 
			@mese, @anno,
			@sanctioncode, @ayearsanction, @iniziocompetenza, @finecompetenza
	while @@fetch_status = 0
	begin
		set @codice = null --ex @codiceEnte
		set @descrente = null
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

		--COMUNICAZIONI DA CAF
		IF      @cafcode IS NOT NULL
		BEGIN
			SELECT @codiceTributo = @cafcode,
			@tiporiga = #tributi.tiporiga,
			@tipoente = #tributi.tipoente, 
			@rifA = #tributi.rifA,
			@rifB = #tributi.rifB
			FROM #tributi 
			WHERE #tributi.codicetributo = @cafcode
		END

		--Per l'irap (380e) facciamo un calcolo a parte per determinare la città e regione
		if (@codiceTributo='3858' )			
		begin
			set @idcity= @myidcity
			set @idfiscaltaxregion=@myfiscalregion
		end
		
	
		if (@codiceTributo='_CXX' OR @codiceTributo='_C10')			
		begin
			set @estremi= @mycap+substring(@mycity,1,12)
			--select  @codice = idinpscenter from config where ayear=@anno. Task 6329 
			select  @codice = inpscenter.othercentercode
			from inpscenter 
			join config 
				on inpscenter.idinpscenter = config.idinpscenter
			where config.ayear=@anno
		end
		

		if (@codiceTributo='_101' OR @codiceTributo='_909')			
		begin
			select @codice = max(country) from license
		end

		
		if (@geoappliance ='C' and @idcity is null)
		begin 
		insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
			values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
			'Per il tributo con codice ' + isnull(@codiceTributo, '')
			+ ' non è stato valorizzato il comune di riferimento');
		end


		if (@geoappliance ='R' and @idfiscaltaxregion is null )
		begin 
		insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
			values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
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

		if (@rifA = 'MMAAAA' and @rifB is not null)
		begin
		if (@codiceTributo='_101' OR @codiceTributo='_909')			
			begin
			-- solo per P101 e P909 va considerata la data trasmissione. Task 6329 
			if (month(@transmissiondate)>9) set @riferimentoA= 
				convert(varchar(2),month(@transmissiondate))+convert(varchar(4),year(@transmissiondate))
			if (month(@transmissiondate)<=9) set @riferimentoA= '0'+
				convert(varchar(2),month(@transmissiondate))+convert(varchar(4),year(@transmissiondate))
			end
		else
		begin
			if (month(@iniziocompetenza)>9) set @riferimentoA= 
				convert(varchar(2),month(@iniziocompetenza))+convert(varchar(4),year(@iniziocompetenza))
			if (month(@iniziocompetenza)<=9) set @riferimentoA= '0'+
				convert(varchar(2),month(@iniziocompetenza))+convert(varchar(4),year(@iniziocompetenza))
		end
		end

		if (@rifA='00MM' and @riferimentoA is null)
			insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare il mese di riferimento');

		if (@rifA='MMAAAA' and @riferimentoA is null and @rifB is null)
			insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di pagamento');

		if (@rifA='MMAAAA' and @riferimentoA is null and @rifB is not null)
			insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di inizio competenza');



		if (@rifB = 'MMAAAA' )
		Begin
			if (@codiceTributo='_101' OR @codiceTributo='_909')			
				begin
				-- solo per P101 e P909 va considerata la data trasmissione. Task 6329 
					if (month(@transmissiondate)>9) set @riferimentoB= 
						convert(varchar(2),month(@transmissiondate))+convert(varchar(4),year(@transmissiondate))
					if (month(@transmissiondate)<=9) set @riferimentoB= '0'+
						convert(varchar(2),month(@transmissiondate))+convert(varchar(4),year(@transmissiondate))
				end
			Else
			Begin
				if (month(@finecompetenza)>9) set @riferimentoB= 
					convert(varchar(2),month(@finecompetenza))+convert(varchar(4),year(@finecompetenza))
				if (month(@finecompetenza)<=9) set @riferimentoB= '0'+
					convert(varchar(2),month(@finecompetenza))+convert(varchar(4),year(@finecompetenza))
			End
		End

		if (@rifB = 'AAAA' )
		begin
			set @riferimentoB=convert(varchar(4),@anno)
		end


		if (@rifB='AAAA' and @riferimentoB is null)
			insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare l''anno di riferimento');

		if (@rifB='MMAAAA' and @riferimentoB is null)
			insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare la data di fine competenza');


				
		
--sezione: ENTI LOCALI
		if @tipoente in ('CCCC','EE')
		begin
			
			select @fiscalyear = @anno  -- anno fiscale letto da expensetax e non da payroll o dal contratto
			
			
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
					insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
						values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
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
				insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
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
				insert into #errori (taxcode, idexp, ytaxpay, ntaxpay, message)
					values (@taxcode, @idexp, @ytaxpay, @ntaxpay, 
					'Per il tributo con codice ' + isnull(@codiceTributo, '')
					+ ' la procedura non è stata in grado di ricavare il codice dell''ente (regione)');
			end
		end
						

		insert into #f24 (tiporecord, tiporiga,codicetributo, codice, estremi, riferimentoA, riferimentoB, importoADebito,importoACredito)
			values ('V',@tiporiga, @codiceTributo, @codice, @estremi, @riferimentoA, @riferimentoB, @importoADebito,@importoACredito)

		fetch next from  @cursore into  @codicetributo, @idexp, @idreg, @idcity,
			@idfiscaltaxregion, @geoappliance, @ytaxpay, @ntaxpay, 
			@importoADebito, @importoacredito, @transmissiondate, @annotrasmissione, @mese, @anno,
			@sanctioncode, @ayearsanction, @iniziocompetenza, @finecompetenza
	end
	if (	 EXISTS (SELECT * FROM #f24 WHERE tiporecord = 'V' AND isnull(declaration_on_behalf_of,'N')  = 'N')) 
	begin
	insert into #f24 (tiporecord)
	values ('M')
	end

	
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
		select declaration_on_behalf_of,cf_contributor,tiporiga, fiscaltaxcode24ord, importoadebito,importoacredito,
			   code, identifying_marks, rifa_month, rifa_year, rifa, rifb_month, rifb_year
		from   #others_details
	
	open @cursore1
	fetch next from @cursore1 into  @declaration_on_behalf_of, @cf_contributor,
			@tiporiga, @codicetributo, @importoadebito,@importoacredito,
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
						  codice, estremi, riferimentoA, riferimentoB, importoADebito,importoacredito)
		SELECT  'V', @declaration_on_behalf_of, @cf_contributor,
				@tiporiga, @codiceTributo,  
				@codice, @identifying_marks, @riferimentoA,  @riferimentoB,@importoadebito, @importoacredito
				
					set @riferimentoA  = null
					set @riferimentoB  = null
	

	fetch next from @cursore1 into @declaration_on_behalf_of, @cf_contributor,
			@tiporiga, @codicetributo, @importoadebito, @importoacredito,
			@codice, @identifying_marks, @rifa_month, @rifa_year, @rif_a,
			@rifb_month, @rifb_year
	end
	
  --select  * from #f24 order by codicetributo
  insert into #f24 (tiporecord, declaration_on_behalf_of, cf_contributor)
	 SELECT DISTINCT 'M', isnull(declaration_on_behalf_of, 'S') as declaration_on_behalf_of, cf_contributor 
	 FROM #f24 WHERE cf_contributor IS NOT NULL

	if (select count(*) from #errori) > 0
	begin
		select 
			'Ritenuta' = tax.taxref,
			'Eserc.liquidaz.' = #errori.ytaxpay,
			'Num.liquidaz.' = #errori.ntaxpay,
			'Fase spesa' = expensephase.description,
			'Eserc.movim.' = expense.ymov,
			'Num.movim.' = expense.nmov,
			'Problema riscontrato' = #errori.message
			from #errori
			join expense on expense.idexp = #errori.idexp
			join expensephase on expensephase.nphase = expense.nphase
			LEFT OUTER join tax on tax.taxcode = #errori.taxcode
	end
	else
	 begin

		select 
		 @cf_agency as 'CF Ente', 
		 @agency as 'Ente dichiarante',  
		 @email_f24 as 'Email',    
		 --@iban_f24 as 'Iban di addebito',  
		 @idf24ordinario as 'Numero', 
		 @anno  as  'Esercizio',
		 @paymentdate as  'Data di addebito',
		 @nmonth  as 'Mese dichiarazione',
		 @taxpay_start as 'Data prima liquidazione',
		 @taxpay_stop as 'Data ultima liquidazione',

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
		case when #f24.tiporiga='I' /* INPS, len = 6*/
				then SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(ISNULL(riferimentoA,'')))+ ISNULL(riferimentoA,'')
			 when #f24.tiporiga in ('R','S') /* REGIONI,IMU e altri tributi locali ==> len = 4*/
				then SUBSTRING(REPLICATE('0',4),1,4 - DATALENGTH(ISNULL(riferimentoA,'')))+ ISNULL(riferimentoA,'')
		else null
		end	as 'Riferimento A',
		case when #f24.tiporiga='I' /* INPS, len ==> 6*/
				then SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(ISNULL(riferimentoB,'')))+ ISNULL(riferimentoB,'')
			 when #f24.tiporiga in ('R','S') /* REGIONI,IMU e altri tributi locali ==> len = 4*/
				then SUBSTRING(REPLICATE('0',4),1,4 - DATALENGTH(ISNULL(riferimentoB,'')))+ ISNULL(riferimentoB,'')
		else null
		end	as 	'Riferimento B',
		sum(importoADebito) as 'Importo a debito',
		sum(importoACredito) as 'Importo a credito',
		
		codiceufficio as 'Codice Ufficio',
		codiceatto	as 'Codice Atto',
		--> Sezione INPS(I)
		case when #f24.tiporiga='I' then @codicesedeINPS else null end as 'Codice Sede INPS',
		case when #f24.tiporiga='I' then @sedeINPS else null end as 'Sede INPS',
		case when #f24.tiporiga='I' then @matricolaInpsF24 else null end as 'Matricola INPS F24',

		--> Sezione Regioni(R)
		idfiscaltaxregion as 'Codice Regione',

		--> Sezione IMU ed Altri Tributi Locali(S)
		identificativooperazione as 'Identificativo Operazione',
		codiceente_provincia_comune as 'Codice Ente/Provincia/Comune',
		isnull(ravvedimentooperoso,0) as 'Revvedimento Operoso',
		isnull(immobilivariati,0) as 'Immobili Variati'	,
		case when accontosaldo ='A' then 1 else	0 end as 'Acconto',
		case when accontosaldo ='S' then 1 else	0 end as 'Saldo',
		SUBSTRING(REPLICATE('0',3),1,3 - DATALENGTH(convert(varchar(3), isnull(numeroimmobili, 0))))+ convert(varchar(3), isnull(numeroimmobili, 0)) as 'Numero Immobili',
		isnull(detrazioneabitazione,0) as 'Detrazione Abitazione',

		--> Sezione INAIL(N)
		isnull(codicesedeinail,replicate('0',5)) as 'Codice Sede Inail',
		isnull(@sedeInail, '') as 'Sede Inail',
		isnull(codiceditta,replicate('0',8)) as 	'Codice Ditta',
		isnull(cc_codiceditta,replicate('0',2)) as 'C.C. Codice Ditta',
		ISNULL(numerodiriferimento,replicate('0',6)) as 'Numero di Riferimento',
		'X' as 'causaleinail',
		
		-->Sezione Altri Enti previdenziali ed assicurativi(A)
		isnull(idaltrienti,REPLICATE('0',4)) as 'Codice Altri Enti' ,
		isnull(@NomeAltriEnti, '') as 'Nome Ente',
		idcodicesedealtrienti as 'Codice Sede Altri Enti',
		@SedeAltriEnti as 'Sede Ente',
		isnull(codiceposizione,	REPLICATE('0',9)) as 'Codice Posizione'
		from #f24 
		left outer join #tributi on  #f24.codicetributo = #tributi.codicetributo
		WHERE tiporecord = 'V'
		group by tiporecord, declaration_on_behalf_of, cf_contributor,#f24.tiporiga,#f24.codicetributo,
		#tributi.descrtributo, codice, descrente, 
		estremi,riferimentoA,riferimentoB, codiceufficio,	codiceatto	,
		ravvedimentooperoso,	immobilivariati	,	accontosaldo	,
		numeroimmobili	,	idfiscaltaxregion,	detrazioneabitazione,
		idaltrienti,	idcodicesedealtrienti,	codiceposizione	,
		identificativooperazione,	codiceente_provincia_comune ,
		codiceditta	,	cc_codiceditta,	numerodiriferimento	,	causaleinail	,	codicesedeinail
order by cf_contributor

	end
	
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

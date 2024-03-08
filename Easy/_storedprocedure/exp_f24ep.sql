
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


--  exec exp_f24ep 117
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_f24ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_f24ep]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser'amministrazione'
--setuser'amm'
CREATE procedure exp_f24ep(@idf24ep int) as
begin

	create table #tributi (
	 
		tiporiga char(1),
		codicetributo varchar(10),
		tipoente varchar(4),
		rifA varchar(10),
		rifB  varchar(10)
	)
 
	--exec exp_f24ep 42
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
	from   f24ep where idf24ep = @idf24ep

	
	insert into #tributi values ('S','384E','CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ('S','385E','CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta- acconto 
	insert into #tributi values ('S','891E','CCCC',  null,'AAAA') -- Sanzioni per ravvedimento su Addizionale comunale Irpef trattenuta dai sostituti d’imposta 
	--insert into #tributi values ('382E',  'EE','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta  su emolumenti corrisposti nell’anno solare 2007–saldo  	
	--insert into #tributi values ('383E',  'EE','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta su emolumenti corrisposti nell’anno solare 2007- acconto    
	
	insert into #tributi values ('R','380E',  'RR','00MM','AAAA') -- IRAP  	
	insert into #tributi values ('R','381E',  'RR','00MM','AAAA') -- Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ('R','892E',  'RR',  null,'AAAA') -- Sanzioni per ravvedimento su IRAP 
	insert into #tributi values ('R','893E',  'RR',  null,'AAAA') -- Sanzioni per ravvedimento Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	
	insert into #tributi values ('F','100E',  null,'00MM','AAAA') -- Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ('F','104E',  null,'00MM','AAAA') -- Ritenute sui redditi da lavoro autonomo  
	insert into #tributi values ('F','105E',  null,'00MM','AAAA') -- Ritenute sulle indennità di esproprio, occupazione , etc. - articolo 11, legge 413/91  
	insert into #tributi values ('F','106E',  null,'00MM','AAAA') -- Ritenute sui contributi corrisposti alle imprese - articolo 28 D.P.R. 600/73 
	insert into #tributi values ('F','107E',  null,'00MM','AAAA') -- Altre ritenute alla fonte  
	insert into #tributi values ('F','890E',  null,  null,'AAAA') -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('F','112E',  null,'00MM','AAAA') -- Ritenuta alla fonte su somme pignorate 

	insert into #tributi values ('I','C10',  null,  'MMAAAA',null) -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('I','CXX',  null,  'MMAAAA',null) -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('Q','P101', null,  'MMAAAA','MMAAAA') -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('Q','P909', null,  'MMAAAA','MMAAAA') -- Sanzioni per ravvedimento su ritenute erariali 
	insert into #tributi values ('F','150E', null,  null,'AAAA') --SOMME A TITOLO DI IMPOSTE ERARIALI RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)
	insert into #tributi values ('F','134E', null, '00MM','AAAA') --IRPEF A SALDO TRATTENUTA DAL SOSTITUTO D''IMPOSTA
	insert into #tributi values ('F','126E', 'RR', null,'AAAA') --ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE
	insert into #tributi values ('R','153E', 'RR', null, 'AAAA') --SOMME A TITOLO DI ADDIZIONALE REGIONALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('S','127E', 'CCCC','00MM','AAAA') --ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO –
	insert into #tributi values ('S','128E', 'CCCC','00MM','AAAA') --ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- 
	insert into #tributi values ('S','154E', 'CCCC', null,'AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('F','133E', null , '00MM','AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014

	-- inserire qui i codici tributo a credito
	
	insert into #tributi values ('S','161E','CCCC','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ('R','160E',  'RR','00MM','AAAA') -- Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ('F','156E',  null,'00MM','AAAA') -- Ritenute sui redditi da lavoro autonomo  	
	insert into #tributi values ('F','155E',  null,'00MM','AAAA') -- Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ('F','165E',  null,'00MM','AAAA') -- Bonus fiscale 
	
	insert into #tributi values ('F','601E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE GENNAIO"
	insert into #tributi values ('F','602E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE FEBBRAIO"
	insert into #tributi values ('F','603E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE MARZO"
	insert into #tributi values ('F','604E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE APRILE"
	insert into #tributi values ('F','605E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE MAGGIO"
	insert into #tributi values ('F','606E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE GIUGNO"
	insert into #tributi values ('F','607E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE LUGLIO"
	insert into #tributi values ('F','608E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE AGOSTO"
	insert into #tributi values ('F','609E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE SETTEMBRE"
	insert into #tributi values ('F','610E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE OTTOBRE"
	insert into #tributi values ('F','611E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE NOVEMBRE"
	insert into #tributi values ('F','612E',null, null,'AAA')--	"VERSAMENTO IVA MENSILE DICEMBRE"

	insert into #tributi values ('F','613E',null, null,'AAAA')--	VERSAMENTO ACCONTO PER IVA MENSILE
	insert into #tributi values ('F','614E',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 1 TRIMESTRE
	insert into #tributi values ('F','615E',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 2 TRIMESTRE
	insert into #tributi values ('F','616E',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 3 TRIMESTRE
	insert into #tributi values ('F','617E',null, null,'AAAA')--	VERSAMENTO IVA TRIMESTRALE 4 TRIMESTRE 
	insert into #tributi values ('F','618E',null, null,'AAAA')--	VERSAMENTO IVA ACCONTO  
	insert into #tributi values ('F','619E',null, null,'AAAA')--	VERSAMENTO IVA SULLA BASE DELLA DICHIARAZIONE ANNUALE
	insert into #tributi values ('F','620E',null,'00MM','AAAA')--	SPLIT ISTITUZIONALE
	insert into #tributi values ('F','621E',null,'00MM','AAAA')--	SPLIT COMMERCIALE
	insert into #tributi values ('F','622E',null,'00MM','AAAA')--	INTRA 12
	insert into #tributi values ('F','801E',null,'00MM','AAAA')--	SANZIONE PECUNIARIA IVA
	insert into #tributi values ('F','901E',null,'00MM','AAAA')--	REGOLARIZZAZIONE OPERAZIONI SOGGETTE AD IVA IN CASO DI MANCATA/ IRREGOLARE FATTURAZ.

	--declare @annodichiarazione int
	--set @annodichiarazione = 2008
	
	--select * from #tributi

	create table #f24 (
		tiporecord char(1), -- M o V
		tiporiga char(1),
		codicetributo varchar(10),
		codice  varchar(10), -- ex codice ente
		estremi varchar(17),
		riferimentoA varchar(10),
		riferimentoB varchar(10),
		importoADebito decimal(19,2),
		importoACredito decimal(19,2),
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16) -- codice fiscale debitore per intervento sostitutivo
	)
          

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
		isnull(tax.fiscaltaxcode,'')+
		' che non è gestito dalla procedura di generazione del modello f24ep'
		from taxpay 
		join tax on tax.taxcode = taxpay.taxcode
		where idf24ep = @idf24ep
		and not exists (select * from #tributi where #tributi.codicetributo = tax.fiscaltaxcode OR #tributi.codicetributo = tax.fiscaltaxcodecredit)

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
	--declare @12gen08 datetime
	--select  @12gen08 = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})
						
	--declare @idf24ep int
	--set @idf24ep = 1
	create table #versamenti (
		kind char(1),
		geoappliance char(1),
		fiscaltaxcode varchar(10),
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
		where taxpay.idf24ep = @idf24ep
		--group by expensetax.taxcode, taxpay.taxcode, tax.taxcode, expensetax.idcity,
		--expensetax.idfiscaltaxregion,expensetax.idexp, taxpay.ytaxpay, taxpay.ntaxpay,
		--paymenttransmission.transmissiondate, year(paymenttransmission.transmissiondate), 
		--month(paymenttransmission.transmissiondate), expenselast.servicestart,expenselast.servicestop,
		--isnull(expensetax.ayear,year(paymenttransmission.transmissiondate)), expense.idreg

	--select 1,* from #versamenti
	--insert da expensetaxcorrige
	
	-- correzioni di dettagli ritenute con i loro importi relativi alle ritenute originali,
	-- anche se aggregate ad altre ritenute nella liquidazione
	 
	 INSERT INTO  #versamenti
	(maintaxcode, taxcode,idcity, geoappliance,idfiscaltaxregion, idexp, idreg, ytaxpay, ntaxpay, importoadebito,importoacredito,
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
	 WHERE taxpay.idf24ep = @idf24ep
	 --group by expensetaxcorrige.taxcode, taxpay.taxcode,tax.taxcode, expensetaxcorrige.idcity,
	 --expensetaxcorrige.idfiscaltaxregion,expensetaxcorrige.idexp, taxpay.ytaxpay, taxpay.ntaxpay,
	 --paymenttransmission.transmissiondate, year(paymenttransmission.transmissiondate), 
	 --month(paymenttransmission.transmissiondate),expenselast.servicestart,expenselast.servicestop,
	 --isnull(expensetaxcorrige.ayear,year(paymenttransmission.transmissiondate)),expense.idreg
	--select * from #versamenti where importoacredito <> 0
	 update #versamenti set meseriferimento=12 where anno<year(datatrasmissione)
	 update #versamenti set anno=year(datatrasmissione)-1 where anno<year(datatrasmissione)
	 --select taxcode, meseriferimento, sum(importoadebito), sum(importoacredito) from #versamenti group by taxcode, meseriferimento
			--select * from #versamenti where taxcode = 7
	--select * from #versamenti
	-- Sanzioni per Ravvedimento Operoso
	INSERT INTO  #versamenti
		(sanctioncode,idcity,idfiscaltaxregion,importoadebito, importoacredito, ayearsanction)
	SELECT fiscaltaxcode,
		ISNULL(idcity,0),
		idfiscaltaxregion,
		importoadebito = isnull(amount,0),
		importoacredito = 0,
		f24epsanction.ayear
		FROM   f24epsanction 
		JOIN   f24epsanctionkind  
		ON f24epsanction.idsanction = f24epsanctionkind.idsanction
		WHERE  f24epsanction.idf24ep = @idf24ep


		UPDATE #versamenti  SET fiscaltaxcode = 
		CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecredit IS NOT NULL ) THEN tax.fiscaltaxcodecredit ELSE tax.fiscaltaxcode END,
		kind =  CASE WHEN (importoacredito <> 0 AND tax.fiscaltaxcodecredit IS NOT NULL ) THEN 'C' ELSE 'D' END
		FROM tax WHERE  tax.taxcode = #versamenti.taxcode  
		--select * from #versamenti 
 
		UPDATE #versamenti SET importoadebito = importoadebito - importoacredito, importoacredito = 0 WHERE kind = 'D'
		UPDATE #versamenti SET importoacredito = importoacredito - importoadebito, importoadebito = 0 WHERE kind = 'C'  --- bonus fiscale ha solo un codice a credito
		--select * from #versamenti  where fiscaltaxcode = '380E'
		--select * from #versamenti 
--- aggrego i dati estratti per codice ritenuta, segno importo e flag "compensa"
--select * from #versamenti
	CREATE	TABLE #tot_versamenti (
		taxcode int,
		fiscaltaxcode varchar(10),
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
			fiscaltaxcode,
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
			fiscaltaxcode,
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
	GROUP BY fiscaltaxcode,taxcode,idcity,idfiscaltaxregion,geoappliance,idexp,idreg ,ytaxpay ,ntaxpay ,
		     sanctioncode,ayearsanction, datatrasmissione , annotrasmissione ,
			 iniziocompetenza,/*da expenselast*/ finecompetenza, /*da expenselast*/ anno, meseriferimento 

--SELECT * FROM #tot_versamenti
--  altri dettagli inseriti manualmente
	CREATE TABLE #others_details
	(
		declaration_on_behalf_of char(1), -- intervento sostitutivo per conto di altro soggetto
		cf_contributor varchar(16),
		fiscaltaxcode varchar(10),		  -- codice tributo per intervento sostitutivo
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
		FROM   expenseclawback 
		JOIN   expense 
		  ON   expenseclawback.idexp = expense.idexp 
		JOIN   registry 
		  ON   registry.idreg = expense.idreg  -- 
	   WHERE   expenseclawback.idf24ep = @idf24ep
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
		fiscaltaxcode varchar(10)
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
		where ivapay.idf24ep = @idf24ep and paymentkind='C'

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
		where ivapay.idf24ep = @idf24ep
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
		where ivapay.idf24ep = @idf24ep and paymentkind='A'

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, riferimentoA,*/ riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		case rif_month	
				when 1 then '601E'	when 2 then '602E' when 3 then '603E' when 4	then '604E' when 5 then '605E' when 6 then '606E' 
				when 7 then '607E'	when 8 then '608E' when 9 then '609E' when 10	then '610E' when 11 then '611E' when 12 then '612E' 
		end,
		convert(varchar(4),rif_year),
		totaliva_comm_aDebito,	totaliva_comm_aCredito
	from #ivapay

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'620E',
		case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totalsplitist_aDebito,	null
	from #ivapay
	where isnull(totalsplitist_aDebito,0) >0

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'621E',
			case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totaliva_splitcomm,null
	from #ivapay
	where isnull(totaliva_splitcomm,0)>0

	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, */riferimentoA, riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'622E',
				case when (rif_month>9) then '00'+convert(varchar(2),rif_month)
			when  (rif_month<=9) then  '000'+convert(varchar(2),rif_month)
		end,
		convert(varchar(4),rif_year),
		totalintra12_aDebito, totalintra12_aCredito
	from #ivapay
	where isnull(totalintra12_aDebito,0)>0 or isnull(totalintra12_aDebito,0)>0

	
	
	
	insert into #f24 (tiporecord, tiporiga,codicetributo,/* codice, estremi, riferimentoA,*/ riferimentoB, importoADebito,importoACredito)
	select 'V', 'F',  
		'618E',
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
		select fiscaltaxcode, idexp, idreg, idcity,idfiscaltaxregion,geoappliance, ytaxpay, ntaxpay, 
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
		if (@codiceTributo='380E' )			
		begin
			set @idcity= @myidcity
			set @idfiscaltaxregion=@myfiscalregion
		end
		
	
		if (@codiceTributo='CXX' OR @codiceTributo='C10')			
		begin
			set @estremi= @mycap+substring(@mycity,1,12)
			--select  @codice = idinpscenter from config where ayear=@anno. Task 6329 
			select  @codice = inpscenter.othercentercode
			from inpscenter 
			join config 
				on inpscenter.idinpscenter = config.idinpscenter
			where config.ayear=@anno
		end
		

		if (@codiceTributo='P101' OR @codiceTributo='P909')			
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
		if (@codiceTributo='P101' OR @codiceTributo='P909')			
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
			if (@codiceTributo='P101' OR @codiceTributo='P909')			
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
		select declaration_on_behalf_of,cf_contributor,tiporiga, fiscaltaxcode, importoadebito,importoacredito,
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

		select tiporecord, isnull(declaration_on_behalf_of, 'S') as declaration_on_behalf_of, cf_contributor, tiporiga,codicetributo, codice, estremi,riferimentoA,riferimentoB,
		importoadebito = isnull(sum(importoADebito),0),
		importoacredito =  isnull(sum(importoACredito),0) 
		from #f24 
		group by tiporecord, declaration_on_behalf_of, cf_contributor,tiporiga,codicetributo, codice,  estremi,riferimentoA,riferimentoB
order by cf_contributor
	

	end
	
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--exec exp_f24ep 117
--V	S	NULL	R	380E	05	NULL	0009	2023	23739.62	0.00
--V	S	NULL	R	380E	05	NULL	0009	2023	23876.72	137.10

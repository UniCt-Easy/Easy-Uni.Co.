
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emens_datiPosContributiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emens_datiPosContributiva]
GO 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 
CREATE        PROCEDURE [emens_datiPosContributiva]
(
	@ycommunication int,
	@startmonth int,
	@stopmonth int,
	@parentsp char(1),  --'E' chiamata dalla procedura del calcolo dell'EMENS, 'X' chiamata dalla procedura di esportazione Excel
    @adate datetime,
	@estrai char(1)
)
AS BEGIN

-- setuser 'amm'
-- exec emens_datiPosContributiva 2016, 1, 6,'E',{ts '2016-12-31 00:00:00'} ,'E'
-- Per tutte le descrizioni dei campi vedi tracciato allegato al task 7581

CREATE TABLE #employ
(
	idreg int,
	cf_employ varchar(16),
	surname varchar(50)  COLLATE SQL_Latin1_General_CP1_CI_AS ,
	firstname varchar(50)   COLLATE SQL_Latin1_General_CP1_CI_AS,
	start smalldatetime,
	stop smalldatetime,
	citycode varchar(20),
	RegimePost95 char(1),
	taxcode int,
	idexp int,
	ycommunication int,
	mcommunication int,
	-- DatiRetributivi
	tipolavoratore char(2),
	imponibile decimal(19,2),
	contributo decimal(19,6),
	ImponibileCtrAgg decimal(19,6),
	ContribAggCorrente decimal(19,6),
	ImpEccMassSpet  decimal(19,6),
	ContrEccMassSpet decimal(19,6),
	GiorniContribuiti int,
	TipoRapportoLav varchar(20)
) 

if @estrai = 'N'
BEGIN
select * from  #employ
return
END
declare @agencynumber varchar(10)
select @agencynumber = substring(agencynumber,1,10) from config where ayear = @ycommunication

-- Dati rilevati dal modulo OCCASIONALE
INSERT INTO #employ(
	idreg,
	cf_employ,
	surname,
	firstname,
	imponibile,
	contributo,
	start,
	stop,
	RegimePost95,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	tipolavoratore,
	ImponibileCtrAgg,
	ContribAggCorrente,
	ImpEccMassSpet,
	ContrEccMassSpet,
	GiorniContribuiti,
	TipoRapportoLav
)
--select taxref from tax where taxref like '%enpals%'
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	expensetaxofficial.taxablenet,
	case when (tax.taxref= '16_ENPALS_POST95_1') then 	isnull(expensetaxofficial.employtax,0)
		 when (tax.taxref= '16_ENPALS_POST95_2') then 	isnull(expensetaxofficial.employtax,0) - ROUND(expensetaxofficial.taxablenet*0.01,2)
		 when (tax.taxref= '16_ENPALS_POST95_2') then 	0
	END,
	casualcontractview.start,
	casualcontractview.stop,
	case when tax.taxref like '%ENPALS_PRE95%' then 'N' else 'S' end,
	expensetaxofficial.taxcode,
	expensetaxofficial.idexp,
	casualcontractview.ayear,
	MONTH(casualcontractview.stop),
	--tipolavoratore
	case when tax.taxref like '%ENPALS_PRE95%' then 'SY' else 'SC' end,
	case when (tax.taxref in('16_ENPALS_POST95_2','16_ENPALS_PRE95_2')) then expensetaxofficial.taxablenet else  0 end,
	case when (tax.taxref in('16_ENPALS_POST95_2','16_ENPALS_PRE95_2')) then ROUND(expensetaxofficial.taxablenet*0.01,2) else  0 end, -- Calcola l'1%
	case when (tax.taxref in('16_ENPALS_PRE95_3','16_ENPALS_POST95_3')) then expensetaxofficial.taxablenet else  0 end, --ImpEccMassSpet
	case when (tax.taxref in('16_ENPALS_PRE95_3','16_ENPALS_POST95_3')) then expensetaxofficial.employtax else  0 end,  --ContrEccMassSpet>
	datediff(day,casualcontractview.start,casualcontractview.stop),
	casualcontractview.idemenscontractkind
FROM registry
JOIN casualcontractview 	ON registry.idreg = casualcontractview.idreg
JOIN expensecasualcontract 	ON casualcontractview.ycon = expensecasualcontract.ycon
							AND casualcontractview.ncon = expensecasualcontract.ncon
JOIN expenselink			ON expensecasualcontract.idexp = expenselink.idparent
JOIN expensetaxofficial		ON expensetaxofficial.idexp = expenselink.idchild
JOIN tax					ON expensetaxofficial.taxcode = tax.taxcode
WHERE YEAR(casualcontractview.ayear) = @ycommunication
	AND MONTH(casualcontractview.stop) BETWEEN @startmonth AND @stopmonth
	AND tax.taxkind = 3 AND tax.taxref LIKE '%ENPALS%' 
	AND casualcontractview.ayear = @ycommunication
	AND expensetaxofficial.taxablenet > 0
	AND (     
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                (@adate IS NOT NULL 
-- il dettaglio deve avere DataFine > della data in oggetto.        
                AND isnull(expensetaxofficial.stop,{ts '2079-01-01 00:00:00'}) > @adate
-- il dettaglio deve avere DataInzio = alla MAX(datainzio) dei dettagli validi alla data in oggetto
                AND ISNULL(expensetaxofficial.start,{ts '1900-01-01 00:00:00'}) 
                        = (SELECT ISNULL(MAX(ETO.start),{ts '1900-01-01 00:00:00'})
                		FROM expensetaxofficial ETO
                		WHERE ETO.idexp = expensetaxofficial.idexp
                                        AND ETO.taxcode = expensetaxofficial.taxcode
                                        AND ETO.nbracket = expensetaxofficial.nbracket
                			AND isnull(ETO.stop,{ts '2079-01-01 00:00:00'}) > @adate
                                        AND ETO.start<=@adate
                                        )
                )
	)

-- Dati rilevati dal modulo PROFESSIONALE
INSERT INTO #employ(
	idreg,
	cf_employ,
	surname,
	firstname,
	imponibile,
	contributo,
	start,
	stop,
	RegimePost95,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	tipolavoratore,
	ImponibileCtrAgg,
	ContribAggCorrente,
	ImpEccMassSpet,
	ContrEccMassSpet,
	GiorniContribuiti,
	TipoRapportoLav
)
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	expensetaxofficial.taxablenet,
	case when (tax.taxref= '16_ENPALS_POST95_1') then 	isnull(expensetaxofficial.employtax,0)
		 when (tax.taxref= '16_ENPALS_POST95_2') then 	isnull(expensetaxofficial.employtax,0) - ROUND(expensetaxofficial.taxablenet*0.01,2)
		 when (tax.taxref= '16_ENPALS_POST95_2') then 	0
	END,
	profservice.start,
	profservice.stop,
	case when tax.taxref like '%ENPALS_PRE95%' then 'N' else 'S' end,
	expensetaxofficial.taxcode,
	expensetaxofficial.idexp,
	profservice.ycon,
	MONTH(profservice.stop),
	--tipolavoratore
	case when tax.taxref like '%ENPALS_PRE95%' then 'SY' else 'SC' end,
	case when (tax.taxref in('16_ENPALS_POST95_2','16_ENPALS_PRE95_2')) then expensetaxofficial.taxablenet else  0 end,
	case when (tax.taxref in('16_ENPALS_POST95_2','16_ENPALS_PRE95_2')) then ROUND(expensetaxofficial.taxablenet*0.01,2) else  0 end, -- Calcola l'1%
	case when (tax.taxref in('16_ENPALS_PRE95_3','16_ENPALS_POST95_3')) then expensetaxofficial.taxablenet else  0 end, --ImpEccMassSpet
	case when (tax.taxref in('16_ENPALS_PRE95_3','16_ENPALS_POST95_3')) then expensetaxofficial.employtax else  0 end,  --ContrEccMassSpet>
	datediff(day,profservice.start,profservice.stop),
	'LA'
FROM registry
JOIN profservice			ON registry.idreg = profservice.idreg
--JOIN expenseprofservice		ON profservice.ycon = expenseprofservice.yconAND profservice.ncon = expenseprofservice.ncon
--JOIN expenselink			ON expenseprofservice.idexp = expenselink.idparent
join expenseinvoice			on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
JOIN expensetaxofficial		ON expensetaxofficial.idexp =  expenseinvoice.idexp -- expenselink.idchild
JOIN tax					ON expensetaxofficial.taxcode = tax.taxcode
WHERE profservice.ycon = @ycommunication
	AND MONTH(profservice.stop) BETWEEN @startmonth AND @stopmonth
	AND tax.taxkind = 3 AND tax.taxref LIKE '%ENPALS%' 
	AND expensetaxofficial.taxablenet > 0
	AND (     
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                (@adate IS NOT NULL 
-- il dettaglio deve avere DataFine > della data in oggetto.        
                AND isnull(expensetaxofficial.stop,{ts '2079-01-01 00:00:00'}) > @adate
-- il dettaglio deve avere DataInzio = alla MAX(datainzio) dei dettagli validi alla data in oggetto
                AND ISNULL(expensetaxofficial.start,{ts '1900-01-01 00:00:00'}) 
                        = (SELECT ISNULL(MAX(ETO.start),{ts '1900-01-01 00:00:00'})
                		FROM expensetaxofficial ETO
                		WHERE ETO.idexp = expensetaxofficial.idexp
                                        AND ETO.taxcode = expensetaxofficial.taxcode
                                        AND ETO.nbracket = expensetaxofficial.nbracket
                			AND isnull(ETO.stop,{ts '2079-01-01 00:00:00'}) > @adate
                                        AND ETO.start<=@adate
                                        )
                )
	)


-- Impostazione del CodiceComune
DECLARE @idagency int
DECLARE @idcode int
SET @idagency = 1
SET @idcode = 1
UPDATE #employ SET citycode = (SELECT value FROM geo_city_agency WHERE idagency = @idagency AND idcode = @idcode 
                                AND idcity = ( SELECT idcity from license))

DECLARE @maxlensurname int
DECLARE @maxlenfirstname int
SET @maxlensurname = 30
SET @maxlenfirstname = 20
UPDATE #employ SET surname =
	SUBSTRING(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	surname,
	'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'$',' '),
	'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
	':',' '),';',' '),'<',' '),'=',' '),'>',' '),'?',' '),']',' '),'_',' '),'`',' '),'{',' '),'}',' '),'~',' '),
	'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),
	'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),'õ','o'),'ý','y'),
	'é','e'''),'à','a'''),'è','e'''),'ì','i'''),'ò','o'''),'ù','u'''),'á','a'''),'í','i'''),'ó','o'''),'É','e'''),
	'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),'Ù','u'''),
	1,@maxlensurname),
	firstname = 
	SUBSTRING(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	firstname,
	'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'$',' '),
	'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
	':',' '),';',' '),'<',' '),'=',' '),'>',' '),'?',' '),']',' '),'_',' '),'`',' '),'{',' '),'}',' '),'~',' '),
	'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),
	'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),'õ','o'),'ý','y'),
	'é','e'''),'à','a'''),'è','e'''),'ì','i'''),'ò','o'''),'ù','u'''),'á','a'''),'í','i'''),'ó','o'''),'É','e'''),
	'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),'Ù','u'''),
	1,@maxlenfirstname)

IF @parentsp = 'E'
BEGIN
	SELECT 
		cf_employ as 'CFLavoratore',
		surname as 'Cognome',
		firstname as 'Nome',
		'S' as Qualifica1,
		'F' as Qualifica2,
		'D' as Qualifica3,
		RegimePost95 ,
		'000' as 'Cittadinanza',
		citycode as 'CodiceComune',
		'CD' as codicecontratto,
		'G' as tipopaga,
		tipolavoratore,
		SUM(imponibile) as imponibile,
		sum(contributo) as contributo,
		start ,
		stop ,
		sum(ImponibileCtrAgg) as 'ImponibileCtrAgg',
		sum(ContribAggCorrente) as 'ContribAggCorrente',
		sum(ImpEccMassSpet) as 'ImpEccMassSpet',
		sum(ContrEccMassSpet) as 'ContrEccMassSpet',
		0 as 'ContrSolidarietaSpet',
		0 as 'RetribTeorica',
		--isnull(@agencynumber, space(10)) as agencynumber
		'S'as 'TrattQuotaLav',
		(select count(distinct cf_employ) from #employ) as 'NumLavoratori',
		'1' as 'ForzaAziendale',
		(select count(*) from #employ) as 'NumDenIndiv',
		(select sum(contributo) from #employ) as 'TotaleADebito',
		0 as 'TotaleACredito',
		sum(GiorniContribuiti) as 'GiorniContribuiti',
		TipoRapportoLav 
	FROM #employ
	GROUP BY 
	cf_employ,surname,firstname,RegimePost95,tipolavoratore, citycode, TipoRapportoLav,start,stop

END
 
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

  --exec emens_datiPosContributiva 2016, 3, 3,'E',{ts '2016-03-31 00:00:00'}
  --exec emens_datiPosContributiva 2015, 1, 12,'E',{ts '2015-12-31 00:00:00'}


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


--setuser 'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_caf_document]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_caf_document]
GO
 
--exec [exp_certificazioneunica_caf_document]   2009
CREATE PROCEDURE [exp_certificazioneunica_caf_document]
(
	@annodichiarazione int
)
-- estraggo l'elenco dei percipienti, assimilati dipendenti, che hanno eseguito prestazioni mappate con il Record G
-- con l'indicazione del coniuge su ciascun contratto
 
AS BEGIN
	--declare @annodichiarazione int
	--set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #prestazioni_trasmesse
	(
		idcon  varchar(8),
		padre  varchar(8),
		capofila char(1),
		ycon  int,
		ncon int,
		duty varchar(400),
		feegross decimal(19,2),
		idreg int,
		idser int,
		motive770 varchar(10)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #prestazioni_trasmesse
		(
			idcon,
			ycon,
			ncon,
			duty,
			feegross,
			idreg, 
			idser
		)
	SELECT   co.idcon, co.ycon, co.ncon, co.duty, ce.feegross, co.idreg,  co.idser      
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		JOIN registry ON registry.idreg = co.idreg
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
		AND ce.disbursementdate is not null
		AND (registry.cf IS  NOT NULL) 
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		
	UPDATE #prestazioni_trasmesse
	SET padre = exhibitedcud.idcon
	FROM exhibitedcud
	WHERE exhibitedcud.idlinkedcon = #prestazioni_trasmesse.idcon
		AND exhibitedcud.fiscalyear = @annoredditi
	
	
	UPDATE #prestazioni_trasmesse
	SET capofila = 'S'
	WHERE idcon = (SELECT TOP 1 idcon FROM #prestazioni_trasmesse A WHERE padre IS NULL AND A.idreg = #prestazioni_trasmesse.idreg)

	select cafdocument.ayear as 'Es. Contratto', 
	parasubcontract.ncon as 'Num. contratto',
	cafdocument.idcafdocument as 'Num. comunicazione', 
	cafdocument.docdate as 'Data Doc',
	registry.title as 'Anagrafica',
	registry.cf as 'Codice Fiscale',
	CASE cafdocument.cafdocumentkind
	 WHEN 'O' THEN 'Ordinaria'
	 WHEN 'I' THEN 'Integrativa'
	 WHEN 'R' THEN 'Rettificativa'
	END as 'Tipo Comunicazione',
	cafdocument.irpeftoretain as 'Irpef da Trattenere', cafdocument.irpeftorefund as 'Irpef da Rimborsare',
	cafdocument.idfiscaltaxregion as 'Regione per Addizionale Regionale',
	cafdocument.regionaltaxtoretain as 'Addizionale Regionale da Trattenere', cafdocument.regionaltaxtorefund as 'Addizionale Regionale da Rimborsare',
	cafdocument.regionaltaxtoretainhusband as 'Addizionale Regionale Coniuge da Trattenere', cafdocument.regionaltaxtorefundhusband as 'Addizionale Regionale Coniuge da Rimborsare',
	geo_city_agencyview.value as 'Codice Comune', 
	geo_city_agencyview.title as 'Comune', 
	geo_city_agencyview.provincecode as 'Provincia',
	cafdocument.citytaxtoretain as 'Addizionale Comunale da Trattenere', cafdocument.citytaxtorefund as 'Addizionale Comunale da Rimborsare',
	cafdocument.citytaxtoretainhusband as 'Addizionale Comunale Coniuge da Trattenere', cafdocument.citytaxtorefundhusband as 'Addizionale Comunale Coniuge da Rimborsare',
	cafdocument.citytaxaccount as 'Acconto Addizionale Comunale da Trattenere', cafdocument.citytaxaccounthusband as 'Acconto Addizionale Comunale Coniuge da Trattenere',
	cafdocument.separatedincome as 'Acconto 20% Redditi Tassazione Separata', cafdocument.separatedincomehusband as 'Acconto 20% Redditi Tassazione Separata Coniuge',
	cafdocument.ratequantity as 'N.ro Rate', cafdocument.startmonth as 'Mese Inizio',
	cafdocument.firstrateadvance as 'Prima Rata Acconto Irpef', cafdocument.nquotafirstinstalment as 'N.ro Rate',
	cafdocument.monthfirstinstalment as 'Mese Inizio', cafdocument.secondrateadvance as 'Seconda Rata Acconto Irpef',
	cafdocument.nquotasecondinstalment as 'N.ro Rate', cafdocument.monthsecondinstalment as 'Mese Inizio'
	from  cafdocument 
	join parasubcontract on cafdocument.idcon = parasubcontract.idcon
	join registry on parasubcontract.idreg = registry.idreg
	join geo_city_agencyview on geo_city_agencyview.idcity = cafdocument.idcity 
	AND geo_city_agencyview.idagency = 1
	AND geo_city_agencyview.idcode = 1
	AND geo_city_agencyview.version = 1
	join #prestazioni_trasmesse on cafdocument.idcon = #prestazioni_trasmesse.idcon
	where cafdocument.ayear = @annoredditi and #prestazioni_trasmesse.capofila = 'S'
	order by cafdocument.ayear, cast(parasubcontract.ncon as int)

DROP TABLE #prestazioni_trasmesse
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

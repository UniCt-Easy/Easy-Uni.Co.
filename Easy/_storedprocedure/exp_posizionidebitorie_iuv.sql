
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


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[exp_posizionidebitorie_iuv]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [exp_posizionidebitorie_iuv]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================
-- Prepara gli avvisi di pagamento da caricare sul WS della Banca di Sondrio
-- =========================================================================
-- exp_posizionidebitorie_iuv '000000000014592'
--setuser 'amm'
CREATE PROCEDURE exp_posizionidebitorie_iuv
	@iuv varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @len_email int
	SET @len_email = 70
	CREATE TABLE #advice
	(
		idflusso int,
		iddetail int,
		idreg int,
		importo decimal(19,2),
		scadenza datetime,
		--iniziovalidita datetime,
		--finevalidita datetime,
		causale varchar(800),
		iddisposizione char(35),
		nform varchar(20),
		iduniqueformcode varchar(100),
		barcodevalue  varchar(60),
		qrcodevalue  varchar(60),
		codiceavviso varchar(100)
	)

	INSERT INTO #advice
	(
		idflusso,
		iddetail,
		idreg,
		importo,
		scadenza,
		--iniziovalidita,
		--finevalidita,
		nform,
		iduniqueformcode,
		barcodevalue, qrcodevalue , codiceavviso
	)
	SELECT
		idflusso, 
		null, --iddetail, 
		idreg, 
		isnull(sum(importoversamento),0)+isnull(sum(tax),0),
		(select max(expirationdate) from flussocreditidetail F2 where F2.iuv = @iuv and F2.idflusso = F1.idflusso), 
		--(select max(competencystart) from flussocreditidetail F2 where F2.iuv = @iuv and F2.idflusso = F1.idflusso), 
		--(select min(competencystop) from flussocreditidetail F2 where F2.iuv = @iuv and F2.idflusso = F1.idflusso), 
		-- description,
		-- 		
		nform, --> num. bollettino
		iduniqueformcode,
		barcodevalue,
		qrcodevalue ,
		codiceavviso
	FROM flussocreditidetail F1
	WHERE iuv = @iuv
	group by idflusso, idreg, 
		--competencystart, 
		--competencystop, 
		--description,
		nform,
		iduniqueformcode,barcodevalue,	qrcodevalue ,codiceavviso
		
	CREATE TABLE #address
	(
		idaddresskind int,
		idreg int,
		indirizzo varchar(100),
		citta varchar(120),
		cap varchar(20),
		provincia varchar(2),
		nazione varchar(65)
	)
	declare @ayear int
	set @ayear = YEAR(getdate())
	
	DECLARE @addressdate datetime
	SET @addressdate = CONVERT(datetime, '31-12-' + CONVERT(varchar(4), @ayear), 105)

	DECLARE @codenostand varchar(20)
	SET @codenostand = '07_SW_AVV'

	DECLARE @codestand varchar(20)
	SET @codestand = '07_SW_DEF'

	DECLARE @STAND int
	SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

	DECLARE @NOSTAND int
	SET @NOSTAND = isnull((select idaddress FROM address WHERE codeaddress = @codenostand),0)

	INSERT INTO #address
	(
		idaddresskind,
		idreg,
		indirizzo,
		citta,
		cap,
		provincia,
		nazione
	)
	SELECT
		idaddresskind,
		idreg, 
		address,
		ISNULL(geo_city.title,'')+' '+ISNULL(registryaddress.location,''),
		registryaddress.cap,
		geo_country.province,
		CASE
			WHEN flagforeign = 'N' then 'Italia'
			ELSE geo_nation.title
		END
	FROM registryaddress
	LEFT OUTER JOIN geo_city 		ON geo_city.idcity = registryaddress.idcity
	LEFT OUTER JOIN geo_country		ON geo_city.idcountry = geo_country.idcountry
	LEFT OUTER JOIN geo_nation		ON geo_nation.idnation = registryaddress.idnation
	WHERE registryaddress.active <>'N' 
		AND registryaddress.start = (
			SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind 
			AND cdi.active <> 'N' 
			AND cdi.start <= @addressdate
			and cdi.idreg = registryaddress.idreg
		)
		and (idreg in (select idreg from #advice))

	DELETE #address
		WHERE #address.idaddresskind <> @nostand
		AND EXISTS (
			SELECT * FROM #address r2 
			WHERE #address.idreg=r2.idreg
			and r2.idaddresskind = @nostand
		)

	DELETE #address
		WHERE #address.idaddresskind not in (@nostand, @stand)
		AND EXISTS (
			SELECT * FROM #address r2 
			WHERE #address.idreg=r2.idreg
			AND r2.idaddresskind = @stand
		)

	DELETE #address
		WHERE (
			select count(*) from #address r2 
			WHERE #address.idreg=r2.idreg
		)>1;

with descr_crediti (descr,idflusso,idreg,iduniqueformcode) as (
			select distinct coalesce(
			invoicekind.description+' n.'+convert(varchar(10),flussocreditidetail.ninv)+'/'+convert(varchar(4),flussocreditidetail.yinv),
			estimatekind.description+' n.'+convert(varchar(10),flussocreditidetail.nestim)+'/'+convert(varchar(4),flussocreditidetail.yestim),
			'bollettino n.'+isnull(flussocreditidetail.nform,flussocreditidetail.iduniqueformcode)
						, flussocreditidetail.description 
			),
			flussocreditidetail.idflusso,
			flussocreditidetail.idreg,
			flussocreditidetail.iduniqueformcode
			from flussocreditidetail 
			left outer join invoicekind on flussocreditidetail.idinvkind  = invoicekind.idinvkind
			left outer join estimatekind on flussocreditidetail.idestimkind  = estimatekind.idestimkind
			WHERE flussocreditidetail.iuv =@iuv
				and flussocreditidetail.annulment is null
			)	

	SELECT
		-- Informazioni pagamento
		ADV.idflusso, ADV.iddetail, ADV.importo, ADV.scadenza, --ADV.iniziovalidita, ADV.finevalidita, 
		SUBSTRING(
					(SELECT distinct ', ' + st1.descr AS [text()]
						FROM descr_crediti st1
						WHERE st1.iduniqueformcode=ADV.iduniqueformcode
										and st1.idreg=ADV.idreg
						FOR XML PATH ('')
					)
					 , 3, 150) as causale ,
					 
		'Oggetto del pagamento: '+
		REPLACE(SUBSTRING(
        (SELECT  distinct isnull(substring(description,1,80),'') AS [text()]
            FROM flussocreditidetail st1
            WHERE st1.idflusso = ADV.idflusso   and st1.iduniqueformcode=ADV.iduniqueformcode and st1.idreg=ADV.idreg
            FOR XML PATH ('')        )
		,1,4000)
		,'&#x0D;',char(13))
		as note,
		ADV.iddisposizione,
		-- Informazioni debitore
		REG.idreg, 
		CASE
			WHEN REG.p_iva is not null then 'G'
			ELSE 'F' 
		END AS tipo,
		CASE
			WHEN REG.p_iva is not null then REG.p_iva
			ELSE REG.cf
		END AS codice,
		REG.forename, REG.surname,
		REG.title AS anagrafica, ADDR.indirizzo, ADDR.cap, ADDR.citta, ADDR.provincia, ADDR.nazione,  SUBSTRING(REF.email,1,@len_email) as email, NULL as pec,
		nform,
		ADV.iduniqueformcode,
		barcodevalue,
		qrcodevalue ,codiceavviso
	FROM	#advice AS ADV
		--join descr_crediti on ADV.iduniqueformcode=descr_crediti.iduniqueformcode 
	LEFT OUTER JOIN		registry AS REG ON ADV.idreg = REG.idreg
	LEFT OUTER JOIN		#address AS ADDR ON ADDR.idreg = REG.idreg
	LEFT OUTER JOIN		registryreference AS REF ON REF.idreg = REG.idreg AND flagdefault = 'S'
	
END
GO

 --exp_posizionidebitorie_iuv '000000000013481'

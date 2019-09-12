IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[exp_posizionidebitoriebsondrio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [exp_posizionidebitoriebsondrio]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amm'
-- =========================================================================
-- Prepara gli avvisi di pagamento da caricare sul WS della Banca di Sondrio
-- =========================================================================
-- exp_posizionidebitoriebsondrio 1,2017

CREATE PROCEDURE exp_posizionidebitoriebsondrio
	@idflusso INT,
	@ayear INT
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE #advice
	(
		idflusso int,
		idreg int,
		importo decimal(19,2),
		scadenza datetime,
		iniziovalidita datetime,
		finevalidita datetime,
		causale varchar(150),
		iddisposizione bigint,
		iduniqueformcode varchar(100)
		--codiceavviso varchar(100)
	);
	
	
	INSERT INTO #advice
	(
		idflusso,
		idreg,
		importo,
		scadenza,
		iduniqueformcode,
		--barcodevalue, qrcodevalue ,codiceavviso,
		iddisposizione
	)	
				
		SELECT
				f1.idflusso, 
				f1.idreg,
				sum(isnull(f1.importoversamento,0)+isnull(f1.tax,0)),	min(f1.expirationdate), --min(f1.competencystart), min(f1.competencystop), 				
				f1.iduniqueformcode,
		-- barcodevalue, qrcodevalue, codiceavviso,
			min(f1.idunivoco) 
			FROM flussocreditidetail F1
			WHERE  f1.annulment is null and f1.idflusso=@idflusso AND (f1.iuv IS NULL OR ((f1.flag & 2)<>0)) --  and
		group by f1.idflusso, f1.iduniqueformcode,f1.idreg
		
	--select * from #advice


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
		idaddresskind,	idreg,	indirizzo,	citta,	cap,	provincia,	nazione
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
	LEFT OUTER JOIN geo_city		ON geo_city.idcity = registryaddress.idcity
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
			invoicekind.description+' n.'+convert(varchar(10),f2.ninv)+'/'+convert(varchar(4),f2.yinv),
			estimatekind.description+' n.'+convert(varchar(10),f2.nestim)+'/'+convert(varchar(4),f2.yestim),
			'bollettino n.'+isnull(f2.nform,f2.iduniqueformcode)
						, f2.description 
			),
			f2.idflusso,
			f2.idreg,
			f2.iduniqueformcode
			from flussocreditidetail  f2
			left outer join invoicekind on f2.idinvkind  = invoicekind.idinvkind
			left outer join estimatekind on f2.idestimkind  = estimatekind.idestimkind
			WHERE f2.idflusso=@idflusso 
				
			)	
	SELECT
		-- Informazioni pagamento
		ADV.idflusso, ADV.importo, ADV.scadenza, --ADV.iniziovalidita, ADV.finevalidita, 
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
		REG.forename,REG.surname,
		REG.title AS anagrafica, ADDR.indirizzo, ADDR.cap, ADDR.citta, ADDR.provincia, ADDR.nazione, REF.email, NULL as pec,
		ADV.iduniqueformcode, 		
		SUBSTRING(
					(SELECT distinct ', ' + st1.descr AS [text()]
						FROM descr_crediti st1
						WHERE st1.iduniqueformcode=ADV.iduniqueformcode
										and st1.idreg=ADV.idreg
						FOR XML PATH ('')
					)
					 , 3, 150) as causale ,
		'Oggetto del pagamento:'+
		REPLACE(SUBSTRING(
        (SELECT  distinct isnull(char(13)+substring(description,1,80),'') AS [text()]
            FROM flussocreditidetail st1
            WHERE st1.idflusso = ADV.idflusso   and st1.iduniqueformcode=ADV.iduniqueformcode and st1.idreg=ADV.idreg
            FOR XML PATH ('')
        )
		,1,4000)
		,'&#x0D;',char(13)) 
		as note
		--barcodevalue, qrcodevalue ,codiceavviso
	FROM #advice AS ADV	
	LEFT OUTER JOIN			registry AS REG ON ADV.idreg = REG.idreg
	LEFT OUTER JOIN			#address AS ADDR ON ADDR.idreg = REG.idreg
	LEFT OUTER JOIN			registryreference AS REF ON REF.idreg = REG.idreg AND flagdefault = 'S'	
END

GO

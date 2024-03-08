
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


	if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoice_estere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoice_estere]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
-- La sp viene chiamata dal form della fattura, per creare la riga in sdi_acquisto_estere e quindi il file xml
CREATE procedure exp_electronicinvoice_estere(
	@yinv int,
	@ninv int,
	@idinvkind int
) as
begin
declare @idreg_fornitore int
select @idreg_fornitore = idreg from invoice where yinv = @yinv and ninv = @ninv and idinvkind = @idinvkind

declare @cf varchar(11)
declare @p_iva varchar(11)
select @cf = case when upper(substring(cf,1,2)) ='IT' then substring(cf,3,(len(cf)-2))
			else cf
			end, 
	@p_iva = case when upper(substring(p_iva,1,2)) ='IT' then substring(p_iva,3,(len(p_iva)-2))
			else p_iva
			end
	from license

	DECLARE @phonenumber varchar(30)	-- license.phonenumber = 30
	DECLARE @comune varchar(65)			-- geo_city.title = 65, license.location = 50
	DECLARE @provincia varchar(2)		-- license.country = 2
	DECLARE @indirizzo varchar(100)		-- license.address1 = 50 + license.address2 = 50
	DECLARE @cap varchar(5)				-- license.cap = 5
	SELECT
		@phonenumber = substring(ltrim(rtrim(license.phonenumber)),1,12),
		@comune = SUBSTRING(isnull(geo_city.title, license.location), 1, 60),
		@provincia = license.country,
		@indirizzo = isnull(license.address1,'') + isnull(license.address2,''),
		@cap = license.cap
	FROM license
	left outer join geo_city 
		on geo_city.idcity = license.idcity

----------------- Calcola la Sede del Fornitore ------------------------------------------
DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@yinv), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @codestabileorg varchar(20)
SET @codestabileorg = '18_FE_STABILE_ORG'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand


DECLARE @stabileorg int
SELECT @stabileorg = idaddress FROM address WHERE codeaddress = @codestabileorg

CREATE TABLE #SedeFornitore
(
	idaddresskind int,
    idreg int,
	address varchar(100),	-- registryaddress.address = 100
	location varchar(65),	-- geo_city.title = 65, registryaddress.location = 50
	cap varchar(20),		-- registryaddress.cap = 20		
	province varchar(2),
	nation varchar(2)
)
/*
--1.4.4   <RappresentanteFiscale>       Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia
--1.4.4.1   <IdFiscaleIVA>				
--    1.4.4.1.1   <IdPaese>			
--    1.4.4.1.2   <IdCodice>        (campo assente nella scheda indirizzi dell'anagrafica)			
--1.4.4.2   <Denominazione>			(campo assente nella scheda indirizzi dell'anagrafica)				
--1.4.4.3   <Nome>					(campo assente nella scheda indirizzi dell'anagrafica)			
--1.4.4.4   <Cognome>				(campo assente nella scheda indirizzi dell'anagrafica)			
*/

CREATE TABLE #StabileOrganizzazioneFornitore
(
	idaddresskind int,
    idreg int,
	address varchar(100),	-- registryaddress.address = 100
	location varchar(65),	-- geo_city.title = 65, registryaddress.location = 50
	cap varchar(20),		-- registryaddress.cap = 20
	province varchar(2),
	nation varchar(2)
)

INSERT INTO #StabileOrganizzazioneFornitore(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT 
	idaddresskind,
	idreg, 
	address,
	isnull(geo_city.title, registryaddress.location),
	case when geo_city.idcity is null then '00000' else registryaddress.cap end,
	geo_country.province,
	ISNULL(geo_nation_agency.value,'IT')
FROM registryaddress
LEFT OUTER JOIN geo_city 	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation_agency
	 ON geo_nation_agency.idnation = registryaddress.idnation 
	 AND geo_nation_agency.idagency = 6 -- ente ISO   
	 AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
	 AND geo_nation_agency.version = 1
	 AND geo_nation_agency.stop IS NULL
WHERE registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			AND cdi.idreg = registryaddress.idreg)
	AND idreg = @idreg_fornitore AND registryaddress.idaddresskind = @stabileorg


INSERT INTO #SedeFornitore(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT 
	idaddresskind,
	idreg, 
	address,
	isnull(geo_city.title, registryaddress.location),
	case when geo_city.idcity is null then '00000' else ltrim(rtrim(registryaddress.cap)) end,
	case when geo_nation_agency.value is null then geo_country.province else 'EE' end,
	ISNULL(geo_nation_agency.value,'IT')
FROM registryaddress
LEFT OUTER JOIN geo_city			ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country			ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation_agency
	 ON geo_nation_agency.idnation = registryaddress.idnation 
	 AND geo_nation_agency.idagency = 6 -- ente ISO   
	 AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
	 AND geo_nation_agency.version = 1
	 AND geo_nation_agency.stop IS NULL
WHERE registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			AND cdi.idreg = registryaddress.idreg)
	AND idreg = @idreg_fornitore

DELETE #SedeFornitore
	WHERE #SedeFornitore.idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM #SedeFornitore r2 
		WHERE #SedeFornitore.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #SedeFornitore
	WHERE #SedeFornitore.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #SedeFornitore r2 
		WHERE #SedeFornitore.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #SedeFornitore
	WHERE (
		SELECT COUNT(*) FROM #SedeFornitore r2 
		WHERE #SedeFornitore.idreg = r2.idreg
	)>1

-------------------- Fine calcolo della Sede del Fornitore -------------------------------------------------

select 
	/*ROW_NUMBER() OVER(PARTITION BY  I.ipa_ven_cliente, I.rifamm_ven_cliente,  I.email_ven_cliente, I.pec_ven_cliente
      ORDER BY   I.ipa_ven_cliente, I.rifamm_ven_cliente,  I.email_ven_cliente, I.pec_ven_cliente) */
	  1 as 'position',
	  
	CASE
		WHEN ((IK.flag&4)=0) THEN 'F'--fattura
		WHEN ((IK.flag&4)<>0) THEN 'V'-- nota di credito
	END as 'tipofattura',
	I.idinvkind, I.yinv, I.ninv,
--	<CessionarioCommittente> è l' Università
	@cf as 'IdTrasmittenteCodice',
	-- n 1 del 2014 => 1400000001
	substring(convert(varchar(4),@yinv),3,2)
	+ replicate('0',4-len(convert(varchar(4),@ninv ))) + convert(varchar(4),@ninv )
	+ replicate('0',4-len(convert(varchar(4),@idinvkind))) + convert(varchar(4),@idinvkind)
	as 'ProgressivoInvio',
	--replicate('0',5-len(convert(varchar(5),@ninv ))) + convert(varchar(5),@ninv )
	substring(convert(varchar(4),@yinv),3,2)
	+ replicate('0',4-len(convert(varchar(4),@ninv ))) + convert(varchar(4),@ninv )
	+ replicate('0',4-len(convert(varchar(4),@idinvkind))) + convert(varchar(4),@idinvkind)
	as 'ProgressivoFile',
	-- 1.1.4   <CodiceDestinatario> 
	I.ipa_ven_emittente as 'CodiceDestinatario',-- E' l'IPA del destinatario, che in questo caso è l'ateneo/dipartimento
	
--<CedentePrestatore>  è il fornitore inserito in fattura		
	case when RR.coderesidence = 'I' then 'IT' 
		 when RR.coderesidence = 'J' then #SedeFornitore.nation
		 --se i primi due caratteri sono stringa dovrebbero essere la sigla della Nazione e quindi mettiamo quella,
		 -- diversamente leggiamo la sigla della nazione da #SedeFornitore.nation. 
		 when (RR.coderesidence = 'X' and  substring(R.foreigncf,1,2) LIKE '[a-zA-Z][a-zA-Z]%')  then substring(R.foreigncf,1,2) 
		 when (RR.coderesidence = 'X' and  substring(R.foreigncf,1,2) not LIKE '[a-zA-Z][a-zA-Z]%')  then #SedeFornitore.nation
		 else null
		 end
	as 'IdFiscaleIvaPaeseFornitore'	,
	case when RR.coderesidence = 'I' then R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 -- se i primi due caratteri sono stringa dovrebbero essere la sigla della Nazione quindi non non lieggiamo,
		 -- diversamente leggiamo tutta il campo 'foreigncf'
		 when (RR.coderesidence = 'X' and  substring(R.foreigncf,1,2) LIKE '[a-zA-Z][a-zA-Z]%') then substring(R.foreigncf,3,28)
		 when (RR.coderesidence = 'X' and  substring(R.foreigncf,1,2) not LIKE '[a-zA-Z][a-zA-Z]%') then substring(R.foreigncf,1,28)
		 else null
		 end
	as 'IdFiscaleIvaCodiceFornitore'	,
	R.cf as 'CFFornitore',
	isnull(RC.flaghuman,'N') as 'flaghuman',
	case when isnull(RC.flaghuman,'N') = 'N' then substring(ltrim(rtrim(title)),1,60)	else null	end as 'DenominazioneFornitore',
	case when isnull(RC.flaghuman,'N') = 'S' then ltrim(rtrim(forename))	else null end as 'nomeFornitore',
	case when isnull(RC.flaghuman,'N') = 'S' then ltrim(rtrim(surname))else null end as 'cognomeFornitore',
	
	#SedeFornitore.address as 'indirizzoFornitore', 
	#SedeFornitore.location as 'comuneFornitore', 
	#SedeFornitore.cap as 'capFornitore',
	#SedeFornitore.province as 'provinciaFornitore',  
	#SedeFornitore.nation as 'nazioneFornitore', 
	/*
	1.4.3	  <StabileOrganizzazione>					
	1.4.3.1   <Indirizzo>				
	1.4.3.2   <NumeroCivico>				
	1.4.3.3   <CAP>				
	1.4.3.4   <Comune>				
	1.4.3.5   <Provincia>				
	1.4.3.6   <Nazione>		
	*/		
	#StabileOrganizzazioneFornitore.address as 'indirizzoStabileOrg', 
	#StabileOrganizzazioneFornitore.location as 'comuneStabileOrg', 
	#StabileOrganizzazioneFornitore.cap as 'capStabileOrg',
	#StabileOrganizzazioneFornitore.province as 'provinciaStabileOrg',  
	#StabileOrganizzazioneFornitore.nation as 'nazioneStabileOrg', 
	--- 1.2.6   <RiferimentoAmministrazione> Codice identificativo del cedente / prestatore / fornitore ai fini amministrativo-contabili. Non obbligatorio.
	-- 1.3   <RappresentanteFiscale> :Blocco da valorizzare nei casi in cui il Cedente Prestatore Fornitore si avvalga di un rappresentante fiscale in Italia.
	CASE WHEN (I.idreg_sostituto IS NOT NULL) THEN 'IT' ELSE NULL END  as 'IdPaeseRappresentante', 
	CASE WHEN (I.idreg_sostituto IS NOT NULL) THEN I.p_iva_sostituto ELSE NULL END as 'IdCodiceRappresentante',
	CASE WHEN I.flaghuman_sostituto ='N' THEN I.registry_sostituto  ELSE NULL END as 'DenominazioneRappresentante',  
	CASE WHEN I.flaghuman_sostituto ='S' THEN I.forename_sostituto  ELSE NULL END as 'NomeRappresentante',  
	CASE WHEN I.flaghuman_sostituto ='S' THEN I.surname_sostituto   ELSE NULL END as 'CognomeRappresentante',   
	-- </RappresentanteFiscale> 
	-- </CedentePrestatore>

	-- 1.4   <CessionarioCommittente>: Cessionario Committente Cliente = Ateneo
	--I.rifamm_ven_cliente as 'RiferimentoAmministrazione',
	I.ipa_ven_emittente,
	I.rifamm_ven_emittente,
	--I.email_ven_cliente, 
	--I.pec_ven_cliente, 
	'IT' as IdFiscaleIvaPaeseDip,
	@p_iva as 'IdFiscaleIvaCodiceDip',
	T.departmentname_fe as 'DenominazioneDip',
	case when isnull(I.flagdeferred,'N')='S' then 'RF16'else 'RF01' end as 'RegimeFiscale',
	@indirizzo as 'indirizzoDip',
	@cap as 'capDip',
	@comune as 'comuneDip',
	@provincia as 'provinciaDip',
	'IT' as 'nazioneDip',
	
-- Se I-Italia, leggiamo la piva
-- Se J-UE, leggiamo la p.iva, che sarà valorizzata con la p.iva estera
-- Se X-Extra UE, leggiamo foreigncf, che sarà valorizzato con il codice identificativo estero

-- <DATI GENERALI>
	FEkind.codefedocumentkind	as 'Tipodocumento',
	'EUR' as 'divisa',
	I.protocoldate	as'data',
	--I.doc as 'numero',20
	replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 15) as 'numero',
	I.docdate as 'datadocumento',
	-- Sulla fattura, sull'intera fattura non sul dettaglio, è previsto o uno sconto o una maggiorazione. Per questo potremmo fare un altro check, che verifichi non vi siano sia sconti che maggiorazioni 
	-- nella stessa fattura, perchè non possiamo trasmettere nello stesso file un dettaglio scontato e un dettaglio maggiorato.Anche se il concetto di maggiorazione credo non venga usato proprio...
	--> Imponibile totale -  Imponibile totale scontato = importo sconto
	 ROUND((  select 
		  SUM( CONVERT(decimal(19,8), (/*imponibile totale euro scontato diviso quantità*/ID2.taxable_euro/ISNULL(ID2.npackage, ID2.number)
		  -
		  /*sottraggo imponibile unitario non scontato convertito in euro*/ ID2.taxable * CONVERT(DECIMAL(19,10),ID2.exchangerate) ))*ISNULL(ID2.npackage, ID2.number))		   
		 from invoicedetailview ID2		
		 where ID2.ninv = I.ninv AND ID2.yinv = I.yinv AND ID2.idinvkind = I.idinvkind and ID2.taxable_euro <>0 and ISNULL(ID2.npackage, ID2.number)<>0
	   ),2)

	 --   CONVERT(decimal(19,2),
		--ROUND((SELECT SUM(
		--			ID2.taxable * 
		--			ISNULL(ID2.npackage,ID2.number) * 
		--			CONVERT(DECIMAL(19,10),I.exchangerate) *
		--			(CONVERT(DECIMAL(19,6),ISNULL(ID2.discount, 0.0))
		--			)
		--  )
		--  from invoicedetailview ID2		
		--  where ID2.ninv = I.ninv AND ID2.yinv = I.yinv AND ID2.idinvkind = I.idinvkind and ID2.taxable_euro <>0 and ISNULL(ID2.npackage, ID2.number)<>0)
		-- ,2 ))  
		 
		 as 'sconto',
	case 
		when (select sum(discount) from invoicedetail id2 where id2.ninv = I.ninv AND id2.yinv = I.yinv AND id2.idinvkind = I.idinvkind)>0 then 'SC'
		when (select sum(discount) from invoicedetail id2 where id2.ninv = I.ninv AND id2.yinv = I.yinv AND id2.idinvkind = I.idinvkind)<0 then 'MG'
		else null
	end as 'tipoScontoMaggiorazione',
	I.total as 'ImportoTotaleDocumento',
	I.description as 'Causale',
--	<DatiFattureCollegate>	
	null as 'RiferimentoNumeroLinea',-- linea di dettaglio della fattura a cui si fa riferimento (se il riferimento è all'intera fattura, non viene valorizzato) 
									-- Non lo valorizziamo perchè noi nel dettaglio spefichiamo la fattura madre, e non anche la riga di dettaglio
	(select TOP 1 substring(M.doc,1,20) from invoice M 
			join invoicedetail id2
				on M.idinvkind = id2.idinvkind_main and M.yinv = id2.yinv_main and M.ninv = id2.ninv_main
		where id2.idinvkind = I.idinvkind and id2.yinv = I.yinv and id2.ninv = I.ninv) as 'IdDocumentoFatturaMadre',
	(select TOP 1 M.adate from invoice M 
			join invoicedetail id2
				on M.idinvkind = id2.idinvkind_main and M.yinv = id2.yinv_main and M.ninv = id2.ninv_main
		where id2.idinvkind = I.idinvkind and id2.yinv = I.yinv and id2.ninv = I.ninv) as 'DataFatturaMadre',
--	ivakind.rate as 'AliquotaIVA',
	--I.idfepaymethodcondition as 'CondizioniPagamento',
	--I.idfepaymethod as 'ModalitaPagamento',
	-- Data Scadenza Pagamento
/* Lasciamolo calcolare al form, perchè è più semplice calcolare le date
	case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when I.idexpirationkind = 1 and I.paymentexpiring is not null then I.adate + paymentexpiring
		-- Data documento = Numero gg  D.F.
		when I.idexpirationkind = 2 then I.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when I.idexpirationkind = 3 then ultimo giorno(I.docdate)
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when I.idexpirationkind = 4 then ultimo giorno(I.adate)
		--	Pagamento Immediato  = data registrazione
		when I.idexpirationkind = 5 then I.adate
	else null
	end as 'DataScadenzaPagamento'*/
	 I.idexpirationkind ,
	 I.paymentexpiring,
	 case	when isnull(I.flag_enable_split_payment,'N') = 'S' then  I.taxable 
			else I.total 
	 end  as 'ImportoPagamento',
	 case --when (R.flagbankitaliaproceeds='S' AND I.idfepaymethod in ('MP05','MP15')) then (select iban_f24 from config where ayear = @yinv)
		when (R.flagbankitaliaproceeds='S' AND I.idfepaymethod in ('MP05','MP15')) then null
		  when (I.idtreasurer is not null  AND I.idfepaymethod in ('MP05','MP15')) then (select iban from treasurer where treasurer.idtreasurer = I.idtreasurer)
		  when  (I.idfepaymethod in ('MP05','MP15')) then (select iban from treasurer where flagdefault='S')
		  else null
	end as 'iban',
	I.idstampkind,
	case when (R.flagbankitaliaproceeds='S' AND I.idfepaymethod in ('MP05','MP15')) 
		then 'CODICE DI TESORERIA PER IL GIROCONTO: '+(select substring(iban_f24,len(iban_f24)-6,7 ) from config where ayear = @yinv)
		else null
	end as 'CodicePagamento'
from invoiceview I 
join fedocumentkind FEkind on FEkind.idfedocumentkind = I.idfedocumentkind
join invoicekind IK				ON IK.idinvkind = I.idinvkind
join registry R					on I.idreg = R.idreg
join residence RR				on RR.idresidence = R.residence
join registryclass RC			on RC.idregistryclass = R.idregistryclass
JOIN #SedeFornitore				ON #SedeFornitore.idreg = I.idreg
JOIN treasurer T on I.idtreasurer_acq_estere = T.idtreasurer
LEFT OUTER JOIN #StabileOrganizzazioneFornitore				ON #StabileOrganizzazioneFornitore.idreg = I.idreg
where I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind
and ((I.idreg_sostituto is not null and I.p_iva_sostituto is not null) or I.idreg_sostituto is null)
end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 


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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicecomunicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicecomunicate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_invoicecomunicate(
	@esercizio int,		-- anno solare
	@semestre int,		-- vale 1 o 2
	@kind char(1)		-- Acquisto o Vendita
	) as
begin

-- exec exp_invoicecomunicate 2017,1,'V'
--  exec exp_invoicecomunicatedetail  2017,1,'V'

DECLARE @meseinizio int
DECLARE @mesefine int
 
	SELECT 
		@meseinizio= case	
			when @semestre = 1 then 1
			when @semestre = 2 then 7
			End,
		@mesefine = case
			when @semestre = 1 then 6
			when @semestre = 2 then 12
			End


declare @cf varchar(11)
declare @p_iva varchar(11)
select @cf = case when upper(substring(cf,1,2)) ='IT' then substring(cf,3,(len(cf)-2))
			else cf
			end, 
	@p_iva = case when upper(substring(p_iva,1,2)) ='IT' then substring(p_iva,3,(len(p_iva)-2))
			else p_iva
			end
	from license

	DECLARE @phonenumber varchar(12)
	DECLARE @comune varchar(60)
	DECLARE @provincia varchar(2)
	DECLARE @indirizzo varchar(60)
	DECLARE @cap varchar(5)
	DECLARE @agencyname varchar(80)
	
	SELECT
		@phonenumber = substring(ltrim(rtrim(license.phonenumber)),1,12),
		@comune = SUBSTRING(isnull(geo_city.title, license.location), 1, 60),
		@provincia = license.country,
		@indirizzo = isnull(license.address1,'') + SUBSTRING(isnull(license.address2,''), 1, 10),
		@cap = license.cap,
		@agencyname = substring(ltrim(rtrim(license.agencyname)),1,80)
	FROM license
	left outer join geo_city 
		on geo_city.idcity = license.idcity

----------------- Calcola la Sede dell' Anagrafica ------------------------------------------
DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@esercizio), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

CREATE TABLE #SedeAnagrafica
(
	idaddresskind int,
    idreg int,
	address varchar(60),	
	location varchar(60),
	cap varchar(5),		
	province varchar(2),
	nation varchar(2)
)

INSERT INTO #SedeAnagrafica(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT distinct 
	registryaddress.idaddresskind,
	I.idreg, 
	substring(registryaddress.address,1,60),
	SUBSTRING(isnull(geo_city.title, registryaddress.location), 1, 60),
	registryaddress.cap,
	geo_country.province,
	ISNULL(geo_nation_agency.value,'IT')
FROM invoice I
join invoicekind 
	on I.idinvkind = invoicekind.idinvkind
JOIN registryaddress
	on I.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
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
	AND month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
	AND (
		 @kind = 'V' AND ((invoicekind.flag&1)<>0)  /* Vendita	*/AND I.idsdi_vendita is null /* Esclude le F.E.*/
		OR
		@kind = 'A' AND ((invoicekind.flag&1)=0)  /* Acquisto*/	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
		)
	and (isnull(I.flagbit,0)&8)=0
DELETE #SedeAnagrafica
	WHERE #SedeAnagrafica.idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM #SedeAnagrafica r2 
		WHERE #SedeAnagrafica.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #SedeAnagrafica
	WHERE #SedeAnagrafica.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #SedeAnagrafica r2 
		WHERE #SedeAnagrafica.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #SedeAnagrafica
	WHERE (
		SELECT COUNT(*) FROM #SedeAnagrafica r2 
		WHERE #SedeAnagrafica.idreg = r2.idreg
	)>1


-------------------- Fine calcolo della Sede del Anagrafica -------------------------------------------------

select 
	I.invoicekind,
	I.idinvkind, I.yinv, I.ninv,
ROW_NUMBER() OVER(PARTITION BY I.yinv-- I.idinvkind, I.yinv, I.ninv
      ORDER BY   I.idinvkind, I.yinv, I.ninv) as 'position',

	CASE
		WHEN ((IK.flag&4)=0) THEN 'F'--fattura
		WHEN ((IK.flag&4)<>0) THEN 'V'-- nota di credito
	END as 'tipofattura',
--	<CEDENTE PRESTATORE> è l' Università
	@cf as 'IdTrasmittenteCodice',
	-- n 1 del 2014 => 1400000001
	substring(convert(varchar(4),@esercizio),3,2)+ @kind+replicate('0',6-len(convert(varchar(6),@semestre ))) + convert(varchar(6),@semestre )
	as 'ProgressivoInvio',
	replicate('',5) as 'IdSistema',
	replicate('0',5-len(convert(varchar(5),@semestre ))) + convert(varchar(5),@semestre )
	as 'ProgressivoFile',
	
	@p_iva as 'IdFiscaleIvaCodiceDip',
	substring(@agencyname,1,80) as 'DenominazioneDip',
	--case when isnull(I.flagdeferred,'N')='S' then 'RF16'else 'RF01' end as 'RegimeFiscale',
	@indirizzo as 'indirizzoDip',
	@cap as 'capDip',
	@comune as 'comuneDip',
	@provincia as 'provinciaDip',
	'IT' as 'nazioneDip',
	
-- Se I-Italia, leggiamo la piva
-- Se J-UE, leggiamo la p.iva, che sarà valorizzata con la p.iva estera
-- Se X-Extra UE, leggiamo foreigncf, che sarà valorizzato con il codice identificativo estero

--<CESSIONARIO COMMITTENTE>  è l' Anagrafica inserito in fattura		-- FARE UN CHECK PER CONTROLLARE CHE questa select dia l'info del paese
	case when RR.coderesidence = 'I' then 'IT' 
		 when RR.coderesidence = 'J' then isnull(substring(R.p_iva,1,2), #SedeAnagrafica.nation)--task 11360
		 when RR.coderesidence = 'X' then isnull(#SedeAnagrafica.nation,substring(R.foreigncf,1,2))
		 else null
		 end
	as 'IdFiscaleIvaPaeseAnagrafica'	,
	case when RR.coderesidence = 'I' then R.p_iva
		 when RR.coderesidence = 'J' then isnull(R.p_iva, isnull(substring(R.foreigncf,1,28), replicate(0,28)))--task 11360
		 when RR.coderesidence = 'X' then isnull(substring(R.foreigncf,1,28), replicate(0,28))
		 else null
		 end
	as 'IdFiscaleIvaCodiceAnagrafica'	,
	R.cf as 'CFAnagrafica',
	isnull(RC.flaghuman,'N') as 'flaghuman',
	case when isnull(RC.flaghuman,'N') = 'N' then substring(ltrim(rtrim(title)),1,80)	else null	end as 'DenominazioneAnagrafica',
	case when isnull(RC.flaghuman,'N') = 'S' then substring( ltrim(rtrim(surname)),1,60) else null end as 'cognomeAnagrafica',
	case when isnull(RC.flaghuman,'N') = 'S' then substring( ltrim(rtrim(forename)),1,60) else null end as 'nomeAnagrafica',
	
	#SedeAnagrafica.address as 'indirizzoAnagrafica', 
	#SedeAnagrafica.location as 'comuneAnagrafica', 
	#SedeAnagrafica.cap as 'capAnagrafica',
	#SedeAnagrafica.province as 'provinciaAnagrafica',  
	#SedeAnagrafica.nation as 'nazioneAnagrafica', 

-- <DATI GENERALI>
/*
Acquisto Intracom S UE
se dettaglio = beni => TD10
se dettaglio = servizi =>TD11

Acquisto Intracom X Extra UE: 
se autofatture => TD11 Diventa: se Acquisto  Extra UE e NON bolla doganale => TD11
se bolla doganale => TD10

TD10 fattura di acquisto intracomunitario beni									
TD11 fattura di acquisto intracomunitario servizi									

*/
	CASE
		WHEN (@kind='V' and (IK.flag&4)=0) THEN 'TD01'--fattura
		WHEN ((IK.flag&4)<>0) THEN 'TD04'-- nota di credito
		WHEN (@kind='A' and I.flagintracom='N' and (IK.flag&4)=0) THEN 'TD01'--fattura
		when @kind='A'and I.flagintracom='S' and 
			isnull((select sum(rowtotal) from invoicedetailview ID where I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(ID.intrastatoperationkind,'') = 'B'),0)
			>
			isnull((select sum(rowtotal) from invoicedetailview ID where I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(ID.intrastatoperationkind,'') = 'S'),0)
			then 'TD10'
		when @kind='A'and I.flagintracom='S' and 
			isnull((select sum(rowtotal) from invoicedetailview ID where I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(ID.intrastatoperationkind,'') = 'B'),0)
			<
			isnull((select sum(rowtotal) from invoicedetailview ID where I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(ID.intrastatoperationkind,'') = 'S'),0)
			then 'TD11'
		when @kind='A'and I.flagintracom='X' and ((flagbit & 1)= 0)	 then 'TD11'
		when @kind='A'and I.flagintracom='X' and ((flagbit & 1)<>0)			then 'TD10'

	END as 'Tipodocumento',
	I.docdate as 'datadocumento',
	I.adate	as'dataregistrazione',
	-- la lunghezza è 20
	substring(ltrim(rtrim(I.doc)),1, 20-len(isnull(ik.printingcode,''))-1)+ '/'+isnull(ik.printingcode,'') as 'numero',
	RR.coderesidence
from invoiceview I 
join invoicekind IK				ON IK.idinvkind = I.idinvkind
join registry R					on I.idreg = R.idreg
join residence RR				on RR.idresidence = R.residence
join registryclass RC			on RC.idregistryclass = R.idregistryclass
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
LEFT OUTER JOIN #SedeAnagrafica				ON #SedeAnagrafica.idreg = I.idreg
where month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
	AND IRK.flagactivity = 2-- Commerciale 
	AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
	AND IRK.registerclass = @kind
	AND (
		 @kind = 'V' and (IK.flag & 1)<>0 /* Vendita	*/AND I.idsdi_vendita is null /* Esclude le F.E.*/
		OR
		@kind = 'A'and (IK.flag & 1)=0  /*  Acquisto*/	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
		)
	and (select count(*) from invoicedetailview ID where  I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(taxable_euro,0) <>0 )>0
	and (isnull(I.flagbit,0)&8)=0
order by I.invoicekind, I.yinv, I.ninv

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

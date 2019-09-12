if exists (select * from dbo.sysobjects where id = object_id(N'[exp_esterometro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_esterometro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
CREATE procedure exp_esterometro(
	@esercizio int,		-- anno solare
	@trimestre int,		-- vale 1 o 2 o 3 o 4
	@mese int,			-- vale da 1 1 12
	@kind char(1)		-- Acquisto o Vendita
	) as
begin
--setuser'amm'
-- exec exp_esterometro 2015,2,null,'A'
 

DECLARE @meseinizio int
DECLARE @mesefine int
 
IF (@mese is not null)
BEGIN
	SELECT @meseinizio = @mese
	SELECT @mesefine = @mese
END 
ELSE
BEGIN
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9
			when @trimestre = 4 then 12
	END
END

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
SELECT * FROM f_get_esterometrosede(	@esercizio, @trimestre, @mese, @kind   )
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
	CASE  
		WHEN @trimestre IS NOT NULL THEN	substring(convert(varchar(4),@esercizio),3,2)+ @kind+replicate('0',6-len(convert(varchar(6),@trimestre ))) + convert(varchar(6),@trimestre )
		ELSE substring(convert(varchar(4),@esercizio),3,2)+ @kind+replicate('0',6-len(convert(varchar(6),@mese ))) + convert(varchar(6),@mese )
	END
	as 'ProgressivoInvio',
	replicate('',5) as 'IdSistema',
	CASE  
		WHEN @trimestre IS NOT NULL THEN	replicate('0',5-len(convert(varchar(5),@trimestre ))) + convert(varchar(5),@trimestre )
		ELSE replicate('0',5-len(convert(varchar(5),@mese ))) + convert(varchar(5),@mese )
	END
	
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
JOIN #SedeAnagrafica				ON #SedeAnagrafica.idreg = I.idreg
where month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
	AND IRK.flagactivity = 2-- Commerciale 
	AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
	AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
	AND IRK.registerclass = @kind
	AND (
		 @kind = 'V' and (IK.flag & 1)<>0 /* Vendita	*/AND I.idsdi_vendita is null /* Esclude le F.E.*/
		OR
		@kind = 'A'and (IK.flag & 1)=0  /*  Acquisto*/	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
		)
	and (select count(*) from invoicedetailview ID where  I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind and isnull(taxable_euro,0) <>0 )>0
	and (isnull(I.flagbit,0)&8)=0   --- non escludere da invio dati fatture
	and (isnull(I.flagbit,0)&1)=0   --- no bolletta doganale

order by I.invoicekind, I.yinv, I.ninv

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

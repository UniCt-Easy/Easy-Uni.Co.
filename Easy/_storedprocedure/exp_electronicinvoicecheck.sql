
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoicecheck]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoicecheck]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'

CREATE procedure exp_electronicinvoicecheck(@yelectronicinvoice smallint, @nelectronicinvoice int) as
begin
-- exec exp_electronicinvoicecheck 2015, 1
CREATE TABLE #error (message varchar(4000))

INSERT INTO #error(message)
select 'Inserire il Codice Fiscale di ' +agencyname +' in Informazioni Ente'
from license
where cf is null


INSERT INTO #error(message)
select 'Inserire la Partita IVA di ' +agencyname +' in Informazioni Ente'
from license
where p_iva is null

INSERT INTO #error(message)
select 'Anagrafica senza IPA o pec o mail f.e. specificati :' + R.title
from electronicinvoice E 
join registry R
	on E.idreg = R.idreg
where E.nelectronicinvoice = @nelectronicinvoice and E.yelectronicinvoice = @yelectronicinvoice
	and R.ipa_fe is null and R.email_fe is null and R.pec_fe is null

-- Se l'aliquota è 0, va trasmessa la natura dell'operazione se non rientra tra quelle imponibili (il campo 2.2.1.12 deve essere valorizzato a zero)
INSERT INTO #error(message)
select 'Specificare la Natura dell''aliquota: '+  convert(varchar(50), ivakind.description)+', utilizzata nel dettaglio fattura ' +
	 convert(varchar(50), ID.invoicekind) + convert(varchar(10),ID.yinv)
		+ ' N.'+convert(varchar(10),ID.ninv)+' dett.'+convert(varchar(10),ID.rownum) +'.'
from invoice I 
join invoicedetailview ID		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind					on ivakind.idivakind = ID.idivakind
where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
and isnull(ID.rate,0) = 0 and ivakind.idfenature is null



-- Se l'aliquota è 0, va trasmesso anche il Riferimento normativo
INSERT INTO #error(message)
select 'Specificare il Riferimento Normativo nel dettaglio fattura ' + convert(varchar(50), ID.invoicekind) + convert(varchar(10),ID.yinv)
		+ ' N.'+convert(varchar(10),ID.ninv)+' dett.'+convert(varchar(10),ID.rownum) +'.'
from invoice I 
join invoicedetailview ID
	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
and isnull(ID.rate,0) = 0 and ID.fereferencerule is null


INSERT INTO #error(message)
select 'Specificare le Condizioni di Pagamento nella fattura: ' + convert(varchar(50), I.invoicekind) + convert(varchar(10),I.yinv)
		+ ' N.'+convert(varchar(10),I.ninv)+ '.'
from invoiceview I 
where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
and I.flagvariation = 'N'
and I.idfepaymethodcondition is null

INSERT INTO #error(message)
select 'Specificare la Modalita Pagamento nella fattura: ' + convert(varchar(50), I.invoicekind) + convert(varchar(10),I.yinv)
		+ ' N.'+convert(varchar(10),I.ninv)+ '.'
from invoiceview I 
where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
and I.flagvariation = 'N'
and I.idfepaymethod is null


---- Se collegato a c.attivo, il c.attivo deve avere il riferimento (registryreference)
--INSERT INTO #error(message)
--select 'Inserire il riferimento nel contratto attivo ' + convert(varchar(200), ID.idestimkind) + convert(varchar(10),ID.yestim)
--		+ ' N.'+convert(varchar(10),ID.nestim)+'.'
--from invoice I 
--join invoicedetailview ID 	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
--join estimate E on ID.idestimkind=E.idestimkind and ID.yestim = E.yestim and ID.nestim=E.nestim 
--where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
--and E.registryreference is null



-- Se collegato a c.attivo, il c.attivo deve avere il documento (doc)
INSERT INTO #error(message)
select 'Inserire il documento collegato nel contratto attivo ' + convert(varchar(200), ID.idestimkind) + convert(varchar(10),ID.yestim)
		+ ' N.'+convert(varchar(10),ID.nestim)+'.'
from invoice I 
join invoicedetailview ID 	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join estimate E on ID.idestimkind=E.idestimkind and ID.yestim = E.yestim and ID.nestim=E.nestim 
where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
and E.doc is null and ID.cigcode is not null


--INSERT INTO #error(message)
--select 'Inserire la data documento collegato nel contratto attivo ' + convert(varchar(200), ID.idestimkind) + convert(varchar(10),ID.yestim)
--		+ ' N.'+convert(varchar(10),ID.nestim)+'.'
--from invoice I 
--join invoicedetailview ID 	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
--join estimate E on ID.idestimkind=E.idestimkind and ID.yestim = E.yestim and ID.nestim=E.nestim 
--where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
--and E.docdate is null


---- Se collegato a c.attivo, il c.attivo deve avere il cig (cigcode)
--INSERT INTO #error(message)
--select 'Inserire il cig nel contratto attivo ' + convert(varchar(200), ID.idestimkind) + convert(varchar(10),ID.yestim)
--		+ ' N.'+convert(varchar(10),ID.nestim)+' dett.'+convert(varchar(10),ID.estimrownum) +'.'
--from invoice I 
--join invoicedetailview ID 	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
--join estimatedetail ED on ID.idestimkind=ED.idestimkind and ID.yestim = ED.yestim and ID.nestim=ED.nestim and ID.estimrownum=ED.rownum
--join estimatedetail E on ID.idestimkind=E.idestimkind and ID.yestim = E.yestim and ID.nestim=E.nestim 
--where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
--and isnull(E.cigcode,ED.cigcode) is null






INSERT INTO #error(message)
select 'Per l''anagrafica: '+ R.title+' Il primo carattere della Partita IVA è numerico. I primi due caratteri dovrebbero rappresentano il paese ( IT, DE, ES …..) ed i restanti (fino ad un massimo di 28) il codice vero e proprio.'
from electronicinvoice E 
join registry R		on E.idreg = R.idreg
join residence RR	on RR.idresidence = R.residence
where E.nelectronicinvoice = @nelectronicinvoice and E.yelectronicinvoice = @yelectronicinvoice
	and RR.coderesidence = 'J' and ASCII(SUBSTRING(R.p_iva,1,1)) BETWEEN 48 AND 57 -- 0..9
	
INSERT INTO #error(message)
select 'Per l''anagrafica: '+ R.title+' Il primo carattere del CF estero/Passaporto è numerico. I primi due caratteri dovrebbero rappresentano il paese ( IT, DE, ES …..) ed i restanti (fino ad un massimo di 28) il codice vero e proprio.'
from electronicinvoice E 
join registry R		on E.idreg = R.idreg
join residence RR	on RR.idresidence = R.residence
where E.nelectronicinvoice = @nelectronicinvoice and E.yelectronicinvoice = @yelectronicinvoice
	and  RR.coderesidence = 'X' and ASCII(SUBSTRING(R.foreigncf,1,1)) BETWEEN 48 AND 57 -- 0..9


INSERT INTO #error(message)
select 'Per l''anagrafica: '+ R.title+' non è stato specificato nè Codice Fiscale nè Partita IVA.'
from electronicinvoice E 
join registry R		on E.idreg = R.idreg
join residence RR	on RR.idresidence = R.residence
where E.nelectronicinvoice = @nelectronicinvoice and E.yelectronicinvoice = @yelectronicinvoice
	and R.p_iva is null
	and R.cf is null
	and R.foreigncf is null
----------------- Calcola la Sede del Cliente ------------------------------------------
declare @idreg int
select @idreg = idreg from electronicinvoice where yelectronicinvoice = @yelectronicinvoice and nelectronicinvoice = @nelectronicinvoice
declare @registry varchar(100)
select @registry = title from registry where idreg = @idreg

DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@yelectronicinvoice), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

CREATE TABLE #SedeCliente
(
	idaddresskind int,
    idreg int,
	address varchar(60),	
	location varchar(60),
	cap varchar(15),		
	province varchar(2),
	nation varchar(2)
	)

INSERT INTO #SedeCliente(idaddresskind, idreg, address,	location, cap, province, nation)
SELECT 
	idaddresskind,
	idreg, 
	substring(address,1,60),
	SUBSTRING(isnull(geo_city.title, registryaddress.location), 1, 60),
	case when geo_city.idcity is null then '00000' else registryaddress.cap end,
	case when geo_nation_agency.value is null then geo_country.province else 'EE' end,
	ISNULL(geo_nation_agency.value,'IT')
FROM registryaddress
LEFT OUTER JOIN geo_city				ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country				ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation_agency		 ON geo_nation_agency.idnation = registryaddress.idnation 
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
	AND idreg = @idreg

DELETE #SedeCliente
	WHERE #SedeCliente.idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM #SedeCliente r2 
		WHERE #SedeCliente.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #SedeCliente
	WHERE #SedeCliente.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #SedeCliente r2 
		WHERE #SedeCliente.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #SedeCliente
	WHERE (
		SELECT COUNT(*) FROM #SedeCliente r2 
		WHERE #SedeCliente.idreg = r2.idreg
	)>1

-------------------- Fine calcolo della Sede del Cliente -------------------------------------------------
if(select count(*) from #SedeCliente where address is null)>0
Begin
	INSERT INTO #error(message)
	select 'Per l''anagrafica: '+ @registry +' non è stato specificato un Indirizzo valido.'
End

if(select count(*) from #SedeCliente where location is null)>0
Begin
	INSERT INTO #error(message)
	select 'Per l''anagrafica: '+ @registry +' non è stato specificato un Comune valido.'
End

if(select count(*) from #SedeCliente where cap is null and province is null)>0
Begin
	INSERT INTO #error(message)
	select 'Per l''anagrafica: '+ @registry +' non è stato specificato un CAP valido.'
End

if(select count(*) from #SedeCliente where nation is null)>0
Begin
	INSERT INTO #error(message)
	select 'Per l''anagrafica: '+ @registry +' non è stata specificata una Nazione valida.'
End

if(select count(*) from #SedeCliente)=0
Begin
	INSERT INTO #error(message)
	select 'Per l''anagrafica: '+ @registry +' non è stato indicato alcun Indirizzo.'
End

select * from #error

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

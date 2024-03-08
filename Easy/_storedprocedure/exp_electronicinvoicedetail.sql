
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoicedetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoicedetail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 
CREATE procedure exp_electronicinvoicedetail(@yelectronicinvoice smallint=null, @nelectronicinvoice int=null, @yinv int=null,	@ninv int=null,	@idinvkind int=null) as
begin
-- exec exp_electronicinvoicedetail 2021, 278
-- exec exp_electronicinvoicedetail null, null, 2023, 3, 120

-- Il codice prenderà solo le righe con IdDocumento not null

CREATE TABLE #campiaggiuntivi(
	idinvkind	int,
	yinv	smallint,
	ninv	int,
	_2_1_2_1_RiferimentoNumeroLinea int,
	_2_1_2_2_IdDocumento varchar(20),
	_2_1_2_3_Data date, 
	_2_1_2_4_NumItem varchar(20),
	_2_1_2_5_CodiceCommessaConvenzione  varchar(100)
)
insert into #campiaggiuntivi(
	idinvkind	,yinv	,ninv	,
	_2_1_2_1_RiferimentoNumeroLinea,
	_2_1_2_2_IdDocumento,
	_2_1_2_3_Data , 
	_2_1_2_4_NumItem,
	_2_1_2_5_CodiceCommessaConvenzione )
select 
	idinvkind	,yinv	,ninv	,
	case when labelfield1int = '2_1_2_1_RiferimentoNumeroLinea' then valuefield1int else null end,
	case when labelfield1str = '2_1_2_2_IdDocumento' then valuefield1str else null end,
	case when labelfield1date = '2_1_2_3_Data' then valuefield1date else null end,
	case when labelfield2str = '2_1_2_4_NumItem' then valuefield2str else null end,
	case when labelfield3str = '2_1_2_5_CodiceCommessaConvenzione' then valuefield3str else null end
from invoiceadditionalfields
where  yinv = @yinv and ninv = @ninv and idinvkind = @idinvkind 

select distinct
	'DatiOrdineAcquisto' as recordkind,
	ID.idinvkind, ID.yinv, ID.ninv,
	isnull(_2_1_2_1_RiferimentoNumeroLinea, ID.idgroup) as 'NumeroLinea',
	null as 'Descrizione',
	null as 'quantita',
	null as 'TipoCessionePrestazione',
	null as 'PrezzoUnitario',
	null as 'tipoScontoMaggiorazioneDettaglio',
	null as 'scontoDettaglio',	
	null as 'PrezzoTotale',
	null as 'AliquotaIVA',
	null as 'Natura',
	--<DatiBeniServizi><DatiRiepilogo>
	-- calcoliamo nel form
	--<DatiOrdineAcquisto>
	isnull(_2_1_2_1_RiferimentoNumeroLinea, ID.idgroup) as 'RiferimentoNumeroLinea',
	null as 'CodiceTipo',
	null as 'CodiceValore',
	case 
		when CA._2_1_2_2_IdDocumento is not null then CA._2_1_2_2_IdDocumento
		when (ID.cupcode is not null or ID.cigcode is not null)
		then 
			substring(convert(varchar(4),I.yinv),3,2)
			+'/'	+ ISNULL(REPLICATE('0', 5-DATALENGTH(CONVERT(varchar(7),I.ninv))) + CONVERT(varchar(5), I.ninv),REPLICATE('0',5))
			+':'	+ substring(convert(varchar(10),I.idinvkind),1,11)
		else null
	end as 'IdDocumento',--> viene valorizzato solo se è stato indicato il cig o il cup nel dettaglio fattura.
	case 
		when CA._2_1_2_3_Data is not null then CA._2_1_2_3_Data
		else null
	end as 'DataDocumentoCollegato', --> segue la valorizzazione di IdDocumento
	isnull(CA._2_1_2_4_NumItem,  ID.idgroup  ) as 'NumItem', 
	CASE  
		when CA._2_1_2_5_CodiceCommessaConvenzione is not null then CA._2_1_2_5_CodiceCommessaConvenzione
		ELSE NULL 
	END AS 'CodiceCommessaConvenzione'
	,
	ID.cupcode as 'CodiceCUP',
	ID.cigcode as 'CodiceCIG'
from invoice I 
join invoicedetailview ID		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind					on ivakind.idivakind = ID.idivakind
join registry R on I.idreg = R.idreg
join #campiaggiuntivi CA on I.ninv = CA.ninv and I.yinv = CA.yinv and I.idinvkind = CA.idinvkind
left outer join electronicinvoiceview E	on I.nelectronicinvoice = E.nelectronicinvoice and I.yelectronicinvoice = E.yelectronicinvoice
where (I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
		or
		 I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind )
		and isnull((select count(*) from #campiaggiuntivi),0) >0				-------------------------------------- >>>>>>>>>>>>>>>>> LEGGE DA CAMPI AGGIUNTIVI
UNION
select distinct
	'DatiOrdineAcquisto' as recordkind,
	ID.idinvkind, ID.yinv, ID.ninv,
	ID.idgroup as 'NumeroLinea',
	null as 'Descrizione',
	null as 'quantita',
	null as 'TipoCessionePrestazione',
	null as 'PrezzoUnitario',
	null as 'tipoScontoMaggiorazioneDettaglio',
	null as 'scontoDettaglio',	
	null as 'PrezzoTotale',
	null as 'AliquotaIVA',
	null as 'Natura',
	--<DatiBeniServizi><DatiRiepilogo>
	-- calcoliamo nel form
	--<DatiOrdineAcquisto>
	ID.idgroup as 'RiferimentoNumeroLinea',
	null as 'CodiceTipo',
	null as 'CodiceValore',
	case 
		when ID.idestimkind is not null
			then (select top 1 substring(isnull(doc,description),1,20) from estimate where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim  )
		when (ID.cupcode is not null or ID.cigcode is not null)
			then 
				substring(convert(varchar(4),I.yinv),3,2)
				+'/'	+ ISNULL(REPLICATE('0', 5-DATALENGTH(CONVERT(varchar(7),I.ninv))) + CONVERT(varchar(5), I.ninv),REPLICATE('0',5))
				+':'	+ substring(convert(varchar(10),I.idinvkind),1,11)
		else null
	end as 'IdDocumento',--> viene valorizzato solo se è stato indicato il cig o il cup nel dettaglio fattura.
	case 
		when ID.idestimkind is not null --and (ID.cupcode is not null or ID.cigcode is not null)
			then (select top 1 docdate from estimate where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim)
		else null
	end as 'DataDocumentoCollegato', --> segue la valorizzazione di IdDocumento
	ID.idgroup as 'NumItem', 
	CASE  
		WHEN (select nso_vendita.order_idemittente from nso_vendita
			join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
			where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim) IS NOT NULL 
				then   '#'+ (select nso_vendita.order_idemittente from nso_vendita
							join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
							where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim)
						+'#'
		ELSE NULL 
	END AS 'CodiceCommessaConvenzione'
	,
	ID.cupcode as 'CodiceCUP',
	ID.cigcode as 'CodiceCIG'
from invoice I 
join invoicedetailview ID		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind					on ivakind.idivakind = ID.idivakind
join registry R on I.idreg = R.idreg
left outer join electronicinvoiceview E	on I.nelectronicinvoice = E.nelectronicinvoice and I.yelectronicinvoice = E.yelectronicinvoice
where (I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
		or
		 I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind )
		 and isnull((select count(*) from #campiaggiuntivi),0)=0			-------------------------------------- >>>>>>>>>>>>>>>>> LEGGE SOLO DA DETTAGLI FATTURA 
UNION
select 
	'DatiBeniServizi'  as recordkind, 
	ID.idinvkind, ID.yinv, ID.ninv,
	ID.idgroup as 'NumeroLinea',
	ID.detaildescription as 'Descrizione',
	ISNULL(ID.npackage, ID.number) as 'quantita',
	ID.idfetransfer as 'TipoCessionePrestazione',
	case when (ivakind.flag & 512 = 0 ) then sum(ID.taxable)
		 when  (ivakind.flag & 512 <> 0 ) then sum( isnull(ID.taxable,0) + isnull(ID.tax,0) )
	end	as 'PrezzoUnitario',
	case  
		when ID.discount>0 then 'SC'
		when ID.discount<0 then 'MG'
		else null
	end as 'tipoScontoMaggiorazioneDettaglio',
	CONVERT(decimal(19,2), 100*ID.discount) as 'scontoDettaglio',	
	
	
	case when (ivakind.flag & 512 = 0 ) then sum(ID.taxable_euro)
		when (ivakind.flag & 512 <> 0 ) then sum(ID.taxable_euro) + isnull(sum(ID.tax),0) 
	end	as 'PrezzoTotale',
	case when (ivakind.flag & 512 = 0 ) then CONVERT(decimal(19,2),ivakind.rate*100)
		when (ivakind.flag & 512 <> 0 ) then 0
	end as 'AliquotaIVA',
	case when SUM(isnull(ID.tax,0)) = 0 then ivakind.idfenature else null end as 'Natura',
	--<DatiBeniServizi><DatiRiepilogo>
	-- calcoliamo nel form
	--<DatiOrdineAcquisto>
	ID.idgroup as 'RiferimentoNumeroLinea',
	ID.codicetipo as 'CodiceTipo',
	ID.codicevalore as 'CodiceValore',
	case 
		when ID.idestimkind is not null
			then (select top 1 substring(isnull(doc,description),1,20) from estimate where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim  )
		when (ID.cupcode is not null or ID.cigcode is not null)
		then 
			substring(convert(varchar(4),I.yinv),3,2)
			+'/'	+ ISNULL(REPLICATE('0', 5-DATALENGTH(CONVERT(varchar(7),I.ninv))) + CONVERT(varchar(5), I.ninv),REPLICATE('0',5))
			+':'	+ substring(convert(varchar(10),I.idinvkind),1,11)
		else null
	end as 'IdDocumento',--> viene valorizzato solo se è stato indicato il cig o il cup nel dettaglio fattura.
	case 
		when ID.idestimkind is not null --and (ID.cupcode is not null or ID.cigcode is not null)
			then (select top 1 docdate from estimate where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim)
		else null
	end as 'DataDocumentoCollegato', --> segue la valorizzazione di IdDocumento
	ID.idgroup  as 'NumItem', 
	CASE  
		WHEN (select nso_vendita.order_idemittente from nso_vendita
			join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
			where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim) IS NOT NULL 
				then   '#'+ (select nso_vendita.order_idemittente from nso_vendita
							join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
							where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim)
						+'#'
		ELSE NULL 
	END AS 'CodiceCommessaConvenzione'
	,
	ID.cupcode as 'CodiceCUP',
	ID.cigcode as 'CodiceCIG'
from invoice I 
join invoicedetailview ID		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind					on ivakind.idivakind = ID.idivakind
join registry R on I.idreg = R.idreg
left outer join electronicinvoiceview E	on I.nelectronicinvoice = E.nelectronicinvoice and I.yelectronicinvoice = E.yelectronicinvoice
where (I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
		or
		 I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind )
group by ID.idinvkind,ID.yinv, ID.ninv, R.ipa_fe, ID.idgroup,ISNULL(ID.npackage, ID.number),	ID.detaildescription,
		ID.idfetransfer,ID.discount,ivakind.rate,
		ivakind.idfenature, ivakind.flag, ID.codicetipo,ID.codicevalore,
		ID.idestimkind,ID.yestim,ID.nestim, --ID.estimrownum,
		ID.cupcode,ID.cigcode,
		I.ninv,I.yinv,I.idinvkind


end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

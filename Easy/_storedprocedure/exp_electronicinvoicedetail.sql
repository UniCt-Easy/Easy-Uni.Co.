if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoicedetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoicedetail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
CREATE procedure exp_electronicinvoicedetail(@yelectronicinvoice smallint, @nelectronicinvoice int) as
begin
-- exec exp_electronicinvoicedetail 2015, 120
select 
	ID.idinvkind, ID.yinv, ID.ninv,
	ID.rownum as 'NumeroLinea',
	substring(ID.detaildescription,1,100) as 'Descrizione',
	ISNULL(ID.npackage, ID.number) as 'quantita',
	ID.idfetransfer as 'TipoCessionePrestazione',
	ID.taxable as 'PrezzoUnitario',
	case 
		when ID.discount>0 then 'SC'
		when ID.discount<0 then 'MG'
		else null
	end as 'tipoScontoMaggiorazioneDettaglio',
	CONVERT(decimal(19,2), 100*ID.discount) as 'scontoDettaglio',
	
	ID.taxable_euro as 'PrezzoTotale',
	CONVERT(decimal(19,2),ivakind.rate*100) as 'AliquotaIVA',
	case when isnull(ID.tax,0) = 0 then ivakind.idfenature else null end as 'Natura',
	--<DatiBeniServizi><DatiRiepilogo>
	-- calcoliamo nel form
	--<DatiOrdineAcquisto>
	ID.rownum as 'RiferimentoNumeroLinea',
	ID.codicetipo as 'CodiceTipo',
	ID.codicevalore as 'CodiceValore',
	case 
		when ID.idestimkind is not null --and (ID.cupcode is not null or ID.cigcode is not null)
			then (select top 1 substring(doc,1,20) from estimate where idestimkind = ID.idestimkind and yestim=ID.yestim and nestim = ID.nestim)
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
	ID.estimrownum  as 'NumItem', 
	ID.cupcode as 'CodiceCUP',
	ID.cigcode as 'CodiceCIG'
from invoice I 
join invoicedetailview ID
	on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind
	on ivakind.idivakind = ID.idivakind
join electronicinvoiceview E
	on I.nelectronicinvoice = E.nelectronicinvoice and I.yelectronicinvoice = E.yelectronicinvoice
where E.nelectronicinvoice = @nelectronicinvoice and E.yelectronicinvoice = @yelectronicinvoice

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


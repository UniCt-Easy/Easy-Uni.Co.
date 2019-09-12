if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoiceriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoiceriepilogo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_electronicinvoiceriepilogo(@yelectronicinvoice smallint, @nelectronicinvoice int) as
begin
-- exec exp_electronicinvoiceriepilogo 2018, 566
-- Importi raggruppati per Aliquota, o Natua, se l'operazione non rientra tra quelle imponibili (ossia aliquota = 0)
	select 
		I.idinvkind, I.yinv, I.ninv,
		CONVERT(decimal(19,2),ivakind.rate*100) as 'AliquotaIVA',
		null as 'Natura',
		sum(ID.taxable_euro) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA',
		 replace (replace(ID.fereferencerule,char(13),''),char(10),'') as 'RiferimentoNormativo'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join registry R
		on R.idreg = I.idreg
	join ivakind
		on ivakind.idivakind = ID.idivakind
	where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
	and isnull(ivakind.rate ,0) >0
	group by I.idinvkind, I.yinv, I.ninv,ivakind.rate,I.flagdeferred,I.flag_enable_split_payment,    replace (replace(ID.fereferencerule,char(13),''),char(10),'')

	union 

	select 
		I.idinvkind, I.yinv, I.ninv,
		0 as 'AliquotaIVA',
		ivakind.idfenature as 'Natura',
		sum(ID.taxable_euro) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA',
		 replace (replace(ID.fereferencerule,char(13),''),char(10),'') as 'RiferimentoNormativo'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join ivakind
		on ivakind.idivakind = ID.idivakind
	join registry R
		on R.idreg = I.idreg
	where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
	and isnull(ivakind.rate ,0) =0
	group by I.idinvkind, I.yinv, I.ninv,ivakind.idfenature,I.flagdeferred,   replace (replace(ID.fereferencerule,char(13),''),char(10),''),I.flag_enable_split_payment

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
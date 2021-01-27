
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoiceriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoiceriepilogo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_electronicinvoiceriepilogo(@yelectronicinvoice smallint, @nelectronicinvoice int) as
begin
-- exec exp_electronicinvoiceriepilogo 2019, 127
-- Importi raggruppati per Aliquota, o Natua, se l'operazione non rientra tra quelle imponibili (ossia aliquota = 0)
	select 
		I.idinvkind, I.yinv, I.ninv,
		case when (ivakind.flag & 512 = 0 ) then CONVERT(decimal(19,2),ivakind.rate*100)
		when (ivakind.flag & 512 <> 0 ) then 0
		end	 as 'AliquotaIVA',
		null as 'Natura',
		case when (ivakind.flag & 512 = 0 ) then sum(ID.taxable_euro) 
			when (ivakind.flag & 512 <> 0 ) then sum(ID.taxable_euro) + isnull(sum(ID.iva_euro),0) 
		end	 as 'ImponibileImporto',
		case when (ivakind.flag & 512 = 0 ) then sum(ID.iva_euro) 
			when (ivakind.flag & 512 <> 0 ) then 0
		end	 as 'Imposta',
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
	group by I.idinvkind, I.yinv, I.ninv,ivakind.rate, ivakind.flag, I.flagdeferred,I.flag_enable_split_payment,    replace (replace(ID.fereferencerule,char(13),''),char(10),'')

	union 

	select 
		I.idinvkind, I.yinv, I.ninv,
		0 as 'AliquotaIVA',
		ivakind.idfenature as 'Natura',
		case when (ivakind.flag & 512 = 0 ) then sum(ID.taxable_euro) 
			when (ivakind.flag & 512 <> 0 ) then sum(ID.taxable_euro) + isnull(sum(ID.iva_euro),0) 
		end	 as 'ImponibileImporto',
		case when (ivakind.flag & 512 = 0 ) then sum(ID.iva_euro) 
			when (ivakind.flag & 512 <> 0 ) then 0
		end	 as 'Imposta',
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
	group by I.idinvkind, I.yinv, I.ninv,ivakind.idfenature, ivakind.flag, I.flagdeferred,   replace (replace(ID.fereferencerule,char(13),''),char(10),''),I.flag_enable_split_payment

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

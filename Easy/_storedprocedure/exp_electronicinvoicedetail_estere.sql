
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoicedetail_estere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoicedetail_estere]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
CREATE procedure exp_electronicinvoicedetail_estere(
	@yinv int,
	@ninv int,
	@idinvkind int) as
begin
-- exec exp_electronicinvoicedetail_estere1 2021, 5, 2 

select 
	ID.idinvkind, ID.yinv, ID.ninv,
	ID.idgroup as 'NumeroLinea',
	ID.detaildescription as 'Descrizione',
	ISNULL(ID.npackage, ID.number) as 'quantita',
	ID.idfetransfer as 'TipoCessionePrestazione',
	/* prezzo unitario in euro  = imponibile unitario scontato euro esclusa IVA*/
	SUM(CONVERT(decimal(19,2),
		ROUND(ID.taxable * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)) 
		  )
		 ,2
		))
		) 
		as 'PrezzoUnitario',
	case  
		when ID.discount>0 then 'SC'
		when ID.discount<0 then 'MG'
		else null
	end as 'tipoScontoMaggiorazioneDettaglio',
	CONVERT(decimal(19,2), 100*ID.discount) as 'scontoDettaglio',	
	SUM(ID.taxable_euro) as 'PrezzoTotale',
    CONVERT(decimal(19,2),ivakind.rate*100) as 'AliquotaIVA',
	case when SUM(isnull(ID.tax,0)) = 0 then ivakind.idfenature else null end as 'Natura',
	--<DatiBeniServizi><DatiRiepilogo>
	-- calcoliamo nel form
	--<DatiOrdineAcquisto>
	ID.idgroup as 'RiferimentoNumeroLinea',
	ID.codicetipo as 'CodiceTipo',
	ID.codicevalore as 'CodiceValore',
	case 
		when ID.idmankind is not null --and (ID.cupcode is not null or ID.cigcode is not null)
			then (select top 1 substring(isnull(doc,description),1,20) from mandate where idmankind = ID.idmankind and yman=ID.yman and nman = ID.nman  )
		when (ID.cupcode is not null or ID.cigcode is not null)
		then 
			substring(convert(varchar(4),I.yinv),3,2)
			+'/'	+ ISNULL(REPLICATE('0', 5-DATALENGTH(CONVERT(varchar(7),I.ninv))) + CONVERT(varchar(5), I.ninv),REPLICATE('0',5))
			+':'	+ substring(convert(varchar(10),I.idinvkind),1,11)
		else null
	end as 'IdDocumento',--> viene valorizzato solo se � stato indicato il cig o il cup nel dettaglio fattura.
	case 
		when ID.idmankind is not null --and (ID.cupcode is not null or ID.cigcode is not null)
			then (select top 1 docdate from mandate where idmankind = ID.idmankind and yman=ID.yman and nman = ID.nman)
		else null
	end as 'DataDocumentoCollegato', --> segue la valorizzazione di IdDocumento
	ID.idgroup  as 'NumItem', 
	ID.cupcode as 'CodiceCUP',
	ID.cigcode as 'CodiceCIG'
from invoice I 
join invoicedetailview ID		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind					on ivakind.idivakind = ID.idivakind
where I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind
group by ID.idinvkind,ID.yinv, ID.ninv,ID.idgroup,ISNULL(ID.npackage, ID.number),	ID.detaildescription,
		ID.idfetransfer,ID.discount,ivakind.rate,
		ivakind.idfenature, ivakind.flag, ID.codicetipo,ID.codicevalore,
		ID.idmankind,ID.yman,ID.nman, --ID.estimrownum,
		ID.cupcode,ID.cigcode,I.ninv,I.yinv,I.idinvkind



end

GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


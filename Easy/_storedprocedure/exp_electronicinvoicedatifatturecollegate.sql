
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoicedatifatturecollegate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoicedatifatturecollegate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
CREATE procedure exp_electronicinvoicedatifatturecollegate(@yelectronicinvoice smallint=null, @nelectronicinvoice int=null, @yinv int=null,	@ninv int=null,	@idinvkind int=null) as
begin
-- exec exp_electronicinvoicedatifatturecollegate 2021, 1
-- select * from electronicinvoiceview
select 
	NC.idinvkind, NC.yinv, NC.ninv,
	NC.rownum_main as 'RiferimentoNumeroLinea',/*riga fatturaa a cui ci si riferisce*/
	substring(convert(varchar(4), MAIN.yinv),3,2)
	+'/'	+ ISNULL(REPLICATE('0', 5-DATALENGTH(CONVERT(varchar(7),MAIN.ninv))) + CONVERT(varchar(5), MAIN.ninv),REPLICATE('0',5))
	+':'	+ substring(convert(varchar(10), MAIN.idinvkind),1,11)
		'IdDocumento',--> viene valorizzato solo se è stato indicato il cig o il cup nel dettaglio fattura.
	M.docdate as 'DataDocumentoCollegato', --> segue la valorizzazione di IdDocumento
	NC.rownum  as 'NumItem', /*riga del documento corrente*/
	CASE  
		WHEN (select nso_vendita.order_idemittente from nso_vendita
			join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
			where idestimkind = MAIN.idestimkind and yestim=MAIN.yestim and nestim = MAIN.nestim) IS NOT NULL 
				then   '#'+ (select nso_vendita.order_idemittente from nso_vendita
							join estimate on nso_vendita.idnso_vendita = estimate.idnso_vendita
							where idestimkind = MAIN.idestimkind and yestim=MAIN.yestim and nestim = MAIN.nestim)
						+'#'
		ELSE NULL 
	END AS 'CodiceCommessaConvenzione',
	MAIN.cupcode as 'CodiceCUP',
	MAIN.cigcode as 'CodiceCIG'
from invoice I 
join  invoicedetailview NC on I.ninv = NC.ninv and I.yinv = NC.yinv and I.idinvkind = NC.idinvkind
join invoicedetailview MAIN		on MAIN.idinvkind = NC.idinvkind_main and MAIN.yinv = NC.yinv_main and MAIN.ninv = NC.ninv_main --and MAIN.rownum = NC.rownum_main
join invoice M on  M.ninv = MAIN.ninv and M.yinv = MAIN.yinv and M.idinvkind = MAIN.idinvkind
join ivakind					on ivakind.idivakind = NC.idivakind
join registry R on NC.idreg = R.idreg
left outer join electronicinvoiceview E	on I.nelectronicinvoice = E.nelectronicinvoice and I.yelectronicinvoice = E.yelectronicinvoice
where (I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
		or
		 I.yinv = @yinv and I.ninv = @ninv and I.idinvkind = @idinvkind )
group by NC.idinvkind,NC.yinv, NC.ninv, NC.rownum,NC.rownum_main,
		I.idinvkind,I.yinv, I.ninv,
		MAIN.idinvkind, MAIN.yinv, MAIN.ninv,
		M.docdate,
		NC.codicetipo,NC.codicevalore,
		MAIN.idestimkind, MAIN.yestim, MAIN.nestim,
		MAIN.cupcode,MAIN.cigcode



end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


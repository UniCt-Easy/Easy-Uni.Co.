
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicecomunicateriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicecomunicateriepilogo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_invoicecomunicateriepilogo(
	@esercizio int,		-- anno solare
	@semestre int,		-- vale 1 o 2
	@kind char(1) 
	) as
begin
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
-- exec exp_invoicecomunicateriepilogo 2017,1,'A'
-- Importi raggruppati per Aliquota, o Natua, se l'operazione non rientra tra quelle imponibili (ossia aliquota = 0)
	select 
		ID.invoicekind,
		I.idinvkind, I.yinv, I.ninv,
		CONVERT(decimal(19,2),ivakind.rate*100) as 'AliquotaIVA',
		null as 'Natura',
		isnull(sum(ID.taxable_euro),0) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		0 as 'Detraibile', -- è un campo facoltativo, per cui lo escludiamo
		'' as 'Deducibile', -- è un campo facoltativo, per cui lo escludiamo
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join registry R
		on R.idreg = I.idreg
	join ivakind
		on ivakind.idivakind = ID.idivakind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	where  month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
			AND IRK.flagactivity = 2-- Commerciale 
			AND IRK.registerclass = @kind
			AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
			AND (
				 @kind = 'V' AND (flagbuysell  ='V')  AND I.idsdi_vendita is null /* Esclude le F.E.*/
				OR
				@kind = 'A' AND (flagbuysell  ='A')   	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
			)
			AND isnull(ivakind.rate ,0) >0
			AND isnull(taxable_euro,0) <>0 
			and (isnull(I.flagbit,0)&8)=0
	group by I.idinvkind,ID.invoicekind, I.yinv, I.ninv,ivakind.rate,I.flagdeferred,I.flag_enable_split_payment, ID.fereferencerule

	union 

	select 
		ID.invoicekind,
		I.idinvkind, I.yinv, I.ninv,
		0 as 'AliquotaIVA',
		ivakind.idfenature as 'Natura',
		sum(ID.taxable_euro) as 'ImponibileImporto',
		isnull(sum(ID.iva_euro),0) as 'Imposta',
		0 as 'Detraibile', -- è un campo facoltativo, per cui lo escludiamo
		'' as 'Deducibile', -- è un campo facoltativo, per cui lo escludiamo
		case 
			when isnull(I.flag_enable_split_payment,'N')='S' then 'S' --> Scissione dei pagamenti
			when isnull(I.flagdeferred,'N')='S' then 'D'
			else 'I' 
		end as 'EsigibilitaIVA'
	from invoice I 
	join invoicedetailview ID
		on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
	join ivakind
		on ivakind.idivakind = ID.idivakind
	join registry R
		on R.idreg = I.idreg
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	where  month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
		AND (
			@kind = 'V' AND (flagbuysell  ='V')  AND I.idsdi_vendita is null /* Esclude le F.E.*/
			OR
			@kind = 'A' AND (flagbuysell  ='A')   AND I.idsdi_acquisto is null /* Esclude le F.E.*/
			)
		AND IRK.flagactivity = 2-- Commerciale 
		AND IRK.registerclass = @kind
		AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
		and isnull(ivakind.rate ,0) =0
		AND isnull(taxable_euro,0) <>0 
		and (isnull(I.flagbit,0)&8)=0
	group by I.idinvkind,ID.invoicekind, I.yinv, I.ninv,ivakind.idfenature,I.flagdeferred,ID.fereferencerule,I.flag_enable_split_payment
	order by ID.invoicekind, I.yinv, I.ninv
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
  

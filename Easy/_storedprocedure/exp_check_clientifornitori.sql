
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_clientifornitori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_clientifornitori]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   procedure exp_check_clientifornitori(@declarationyear int) as
begin
declare @ayear int
set @ayear = @declarationyear-1

select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'AVVISO: Un dettaglio sarà ignorato perchè non è specificato il tipo di imposizione dell''aliquota '+ivakind.description
	from invoice 
	join invoicekind on invoice.idinvkind=invoicekind.idinvkind
	join invoicedetail
		on invoicedetail.idinvkind=invoice.idinvkind
		and invoicedetail.yinv=invoice.yinv
		and invoicedetail.ninv=invoice.ninv
	join ivakind on ivakind.idivakind=invoicedetail.idivakind
	where ivakind.idivataxablekind is null and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and invoicedetail.yinv_main=@ayear))
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Nel dettaglio della nota di variazione manca l''anno della fattura di riferimento'
	from invoice 
	join invoicekind on invoice.idinvkind=invoicekind.idinvkind
	join invoicedetail on invoicedetail.idinvkind=invoice.idinvkind
		and invoicedetail.yinv=invoice.yinv
		and invoicedetail.ninv=invoice.ninv
	where ((invoicekind.flag&4)<>0) and invoicedetail.yinv_main is null
		and ((invoicekind.flag&2)=0)
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Manca il Tipo di attività del registro "'+isnull(ivaregisterkind.description,'')+'"'
	from invoice 
	join invoicekind on invoicekind.idinvkind=invoice.idinvkind
	join invoicekindregisterkind on invoicekindregisterkind.idinvkind=invoicekind.idinvkind
	join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
	where ivaregisterkind.flagactivity is null and ivaregisterkind.registerclass in ('A','V')
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and invoicedetail.yinv_main=@ayear))
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Nella fattura non è specificata la data del documento'
	from invoice 
	join invoicekind on invoice.idinvkind=invoicekind.idinvkind
	where ((invoicekind.flag&4)=0) and invoice.docdate is null
	and ((invoicekind.flag&2)=0)
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'AVVISO: La fattura sarà ignorata perchè manca la partita iva di "'+registry.title+'"'
	from invoice 
	join invoicekind on invoice.idinvkind=invoicekind.idinvkind
	join registry on invoice.idreg=registry.idreg
	where isnumeric(registry.p_iva)=0
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)<2008 and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and year(invoicedetail.yinv_main)<2008 and invoicedetail.yinv_main=@ayear))
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'AVVISO: La fattura sarà ignorata perchè manca il codice fiscale di "'+registry.title+'"'
	from invoice 
	join invoicekind on invoice.idinvkind=invoicekind.idinvkind
	join registry on invoice.idreg=registry.idreg
	where registry.cf is null
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)>=2008 and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and year(invoicedetail.yinv_main)>=2008 and invoicedetail.yinv_main=@ayear))
	and exists (select *
		from invoicekindregisterkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where isnull(ivaregisterkind.flagactivity,2)=2 and ivaregisterkind.registerclass in ('A','V')
		and invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Non esiste un collegamento tra tipo di documento e registro iva con protocollo vendita'
	from invoice 
	join invoicekind on invoicekind.idinvkind=invoice.idinvkind
	where not exists (select *
		from invoicekindregisterkind 
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where invoicekindregisterkind.idinvkind=invoicekind.idinvkind)
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and invoicedetail.yinv_main=@ayear))
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Esiste più di un collegamento tra tipo di documento e registro iva con protocollo vendita'
	from invoice 
	join invoicekind on invoicekind.idinvkind=invoice.idinvkind
	where (select count(*)
		from invoicekindregisterkind 
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where invoicekindregisterkind.idinvkind=invoicekind.idinvkind and ivaregisterkind.registerclass='V')>1
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and invoicedetail.yinv_main=@ayear))
union
select invoicekind.description, invoice.yinv, invoice.ninv, invoice.docdate, 
	'Esiste più di un collegamento tra tipo di documento e registro iva con protocollo acquisto'
	from invoice 
	join invoicekind on invoicekind.idinvkind=invoice.idinvkind
	where (select count(*)
		from invoicekindregisterkind 
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		where invoicekindregisterkind.idinvkind=invoicekind.idinvkind and ivaregisterkind.registerclass='A')>1
	and ((invoicekind.flag&2)=0)
	and (((invoicekind.flag&4)=0) and year(invoice.docdate)=@ayear 
		or ((invoicekind.flag&4)<>0) and 
		exists (select * from invoicedetail
			where invoicedetail.idinvkind=invoice.idinvkind
			and invoicedetail.yinv=invoice.yinv
			and invoicedetail.ninv=invoice.ninv
			and invoicedetail.yinv_main=@ayear))
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


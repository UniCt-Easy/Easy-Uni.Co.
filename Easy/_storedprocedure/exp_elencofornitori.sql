
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elencofornitori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elencofornitori]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--exp_elencofornitori 2016
CREATE   procedure exp_elencofornitori(@declarationyear int) as 
begin
	declare @ayear int
	set @ayear = @declarationyear-1

	select  chiave=case when @ayear<2008 then registry.p_iva else registry.cf end,
		ivakind.idivataxablekind,
		taxable_euro=sum(case (invoicekind.flag&4) when 0 then taxable_euro else -taxable_euro end), 
		iva_euro=sum(case (invoicekind.flag&4) when 0 then iva_euro else -iva_euro end)
		into #dati
		from invoice 
		join invoicekind on invoicekind.idinvkind=invoice.idinvkind
		join invoicedetailview on invoicedetailview.idinvkind=invoice.idinvkind
			and invoicedetailview.yinv=invoice.yinv
			and invoicedetailview.ninv=invoice.ninv
		join ivakind on ivakind.idivakind=invoicedetailview.idivakind
		join invoicekindregisterkind on invoicekindregisterkind.idinvkind=invoicekind.idinvkind
		join ivaregisterkind on ivaregisterkind.idivaregisterkind=invoicekindregisterkind.idivaregisterkind
		join registry on invoice.idreg=registry.idreg
			and (@ayear<2008 and isnumeric(registry.p_iva)=1 or @ayear>=2008 and registry.cf is not null)
		join ivataxablekind on ivataxablekind.idivataxablekind = ivakind.idivataxablekind
		where ivaregisterkind.flagactivity=2 
			and ivaregisterkind.registerclass='A' 
			and ((invoicekind.flag&2)=0)
			and (
				(	((invoicekind.flag&4)=0)  AND year(invoice.docdate)=@ayear	)
				OR
				(	((invoicekind.flag&4)<>0) AND  invoicedetailview.yinv_main=@ayear	)
			    )	
		group by case when @ayear<2008 then registry.p_iva else registry.cf end, ivakind.idivataxablekind

	create table #fornitori (
		FR001001 int, 
		FR002001 varchar(16), 
		FR003001 varchar(15), 
		FR004001 int, 
		FR004002 int, 
		FR005001 int, 
		FR006001 int, 
		FR007001 int, 
		FR008001 int, 
		FR009001 int, 
		FR009002 int, 
		FR010001 int, 
		FR011001 int,
		FR012001 int,
		FR013001 int)

	declare @FR004001 int
	declare @FR004002 int
	declare @FR005001 int
	declare @FR006001 int
	declare @FR007001 int
	declare @FR008001 int

	declare @chiave varchar(100)
	declare @progressivo int
	set @progressivo = 1

	declare @cursore cursor 
	set @cursore = cursor for select distinct chiave from #dati

	open @cursore
	fetch next from @cursore into @chiave
	
	
	while @@fetch_status=0
	begin
		set @FR004001=0
		set @FR004002=0
		set @FR005001=0
		set @FR006001=0
		set @FR007001=0
		set @FR008001=0
	
		select @FR004001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=1
		select @FR004002 = round(iva_euro, 0) from #dati where chiave=@chiave and idivataxablekind=1
		select @FR006001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=2
		select @FR007001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=3
		select @FR008001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=4
		
		declare @cf varchar(100)
		declare @p_iva varchar(100)
		set @cf = null
		set @p_iva = null
		
		if @ayear<2008 begin
			set @p_iva = @chiave
			select @cf = cf from registry where p_iva = @chiave
		end else begin
			set @cf = @chiave
			select @p_iva = p_iva from registry where cf = @chiave
		end

		insert into #fornitori
			values(@progressivo, @cf, @p_iva, @FR004001, @FR004002, @FR005001, @FR006001, @FR007001, @FR008001, null, null, null, null, null, null)

		set @progressivo = @progressivo + 1
		fetch next from @cursore into @chiave
	end
	select * from #fornitori
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


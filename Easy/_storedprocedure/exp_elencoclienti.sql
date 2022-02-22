
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elencoclienti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elencoclienti]
GO

--setuser 'amm'
-- exp_elencoclienti 2015
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   procedure exp_elencoclienti(@declarationyear int) as 
begin
	declare @ayear int
	set @ayear = @declarationyear-1

	select chiave=case when @ayear<2008 then registry.p_iva else registry.cf end,
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
		join ivataxablekind on ivataxablekind.idivataxablekind = ivakind.idivataxablekind
		where ivaregisterkind.flagactivity=2 
			and ivaregisterkind.registerclass='V' --and invoicekind.flagbuysell='V'
			and ((invoicekind.flag&2)=0)
			and (
				(	((invoicekind.flag&4)=0)  AND year(invoice.docdate)=@ayear	)
				OR
				(	((invoicekind.flag&4)<>0) AND  invoicedetailview.yinv_main=@ayear	)
			    )	
			and (@ayear<2008 and isnumeric(registry.p_iva)=1 or @ayear>=2008 and registry.cf is not null)
		group by case when @ayear<2008 then registry.p_iva else registry.cf end, ivakind.idivataxablekind

	create table #clienti (
		CL001001 int, 
		CL002001 varchar(16), 
		CL003001 varchar(15), 
		CL004001 int, 
		CL004002 int, 
		CL005001 int, 
		CL006001 int, 
		CL007001 int, 
		CL008001 int, 
		CL008002 int, 
		CL009001 int, 
		CL010001 int, 
		CL011001 int)

	declare @CL004001 int
	declare @CL004002 int
	declare @CL005001 int
	declare @CL006001 int
	declare @CL007001 int

	declare @chiave varchar(100)
	declare @progressivo int
	set @progressivo = 1

	declare @cursore cursor 
	set @cursore = cursor for select distinct chiave from #dati

	open @cursore
	fetch next from @cursore into @chiave
	
	while @@fetch_status=0
	begin
		set @CL004001=0
		set @CL004002=0
		set @CL005001=0
		set @CL006001=0
		set @CL007001=0
	
		select @CL004001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=1
		select @CL004002 = round(iva_euro, 0) from #dati where chiave=@chiave and idivataxablekind=1
		select @CL005001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=2
		select @CL006001 = round(taxable_euro, 0) from #dati where chiave=@chiave and idivataxablekind=3

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

		insert into #clienti 
			values (@progressivo, @cf, @p_iva, @CL004001, @CL004002, @CL005001, @CL006001, @CL007001, null, null, null, null, null)

		set @progressivo = @progressivo + 1
		fetch next from @cursore into @chiave
	end
	select * from #clienti
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


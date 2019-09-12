if exists (select * from dbo.sysobjects where id = object_id(N'[exp_electronicinvoiceallegati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_electronicinvoiceallegati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_electronicinvoiceallegati(@yelectronicinvoice smallint, @nelectronicinvoice int) as
begin
--exec exp_electronicinvoiceallegati 2014,4
select 
		I.idinvkind, I.yinv, I.ninv,
		isnull(IA.filename,'.') as 'filename',
		IA.attachment
	from invoice I 
	join invoiceattachment IA
		on I.ninv = IA.ninv and I.yinv = IA.yinv and I.idinvkind = IA.idinvkind
	where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 




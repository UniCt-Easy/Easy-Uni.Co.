
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
	join invoiceattachmentkind IAK
		on IA.idattachmentkind = IAK.idattachmentkind
	where I.nelectronicinvoice = @nelectronicinvoice and I.yelectronicinvoice = @yelectronicinvoice
		and IAK.attachment_fe = 'S'

end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 




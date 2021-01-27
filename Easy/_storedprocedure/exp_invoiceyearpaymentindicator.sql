
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoiceyearpaymentindicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoiceyearpaymentindicator]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [exp_invoiceyearpaymentindicator](
	@year int
) 

AS BEGIN

--setuser 'amministrazione'
--exec exp_invoiceyearpaymentindicator 2016

select
d.invoicekind [Tipo Documento],
d.yinv [Anno Fattura],
transmissiondate,
d.ninv [Num. Fattura],
d.rownum [Num. riga fattura],
i.docdate [Data emissione Fornitore],
d.registry [Fornitore],
CASE WHEN ik.flag&4 <> 0 THEN -d.taxable_euro --solo anagrafiche con IPA
 ELSE d.taxable_euro  
END [Imponibile],
CASE WHEN ik.flag&4 <> 0 THEN -d.iva_euro 
 ELSE d.iva_euro  
END
 [IVA],
CASE WHEN ik.flag&4 <> 0 THEN -d.rowtotal 
 ELSE d.rowtotal  
END
 [Totale Riga],
DENSE_RANK() OVER (ORDER BY  d.registry) as [Numero impresa creditrice]
from invoicedetailview d
left join invoice i on  i.yinv = d.yinv and i.ninv = d.ninv and i.idinvkind = d.idinvkind
left join invoicekind ik on i.idinvkind = ik.idinvkind
left join expensevar ev on d.idexp_taxable = ev.idexp
left join paymenttransmission p on ev.kpaymenttransmission = p.kpaymenttransmission
where YEAR(i.docdate) <= @year
and d.idpccdebitstatus = 'LIQ'
and flagbuysell = 'A'
and d.yinv = @year
and (transmissiondate IS NULL OR YEAR(transmissiondate)>@year)

order by [Numero impresa creditrice]

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

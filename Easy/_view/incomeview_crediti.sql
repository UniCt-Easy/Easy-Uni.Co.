
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


SET QUOTED_IDENTIFIER ON
GO
-- CREAZIONE VISTA incomeview_crediti
IF EXISTS(select * from sysobjects where id = object_id(N'[incomeview_crediti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomeview_crediti]
GO
--setuser 'amministrazione' 
--setuser 'amm'
 
CREATE  VIEW [incomeview_crediti]
(
	idinc,nphase,
	iduniqueformcode,	
	iuv,
	idflusso
)
AS SELECT
	income.idinc,income.nphase,
	fcd.iduniqueformcode,	
	fcd.iuv,	
	fcd.idflusso
	FROM income (NOLOCK)
	join invoicedetail id on (id.idinc_taxable=income.idinc or (id.idinc_iva=income.idinc ))
	join flussocreditidetail fcd on  fcd.iduniqueformcode= id.iduniqueformcode 
UNION
SELECT
	income.idinc,income.nphase,
	fcd.iduniqueformcode,	
	fcd.iuv,	
	fcd.idflusso
	FROM income (NOLOCK)
	join estimatedetail ed on (ed.idinc_taxable = income.idinc  or  (ed.idinc_iva=income.idinc ))
	join flussocreditidetail fcd on  fcd.iduniqueformcode= ed.iduniqueformcode 


GO



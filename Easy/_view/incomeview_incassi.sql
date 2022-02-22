
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
-- CREAZIONE VISTA incomeview_incassi
IF EXISTS(select * from sysobjects where id = object_id(N'[incomeview_incassi]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomeview_incassi]
GO

--setuser 'amministrazione' 
--setuser 'amm'
 
CREATE  VIEW [incomeview_incassi]
(
	idinc,nphase,
	iduniqueformcode,	iuv,idflusso
)
AS SELECT
	income.idinc,income.nphase,
	id.iduniqueformcode ,	fci.iuv,	fci.idflusso 
	FROM income (NOLOCK)
	join invoicedetail id on ( id.idinc_taxable=income.idinc  or id.idinc_iva=income.idinc) 
	join flussocreditidetail fcd on  fcd.iduniqueformcode=id.iduniqueformcode and fcd.idinvkind is not null
	join flussoincassidetail fci on  fci.iduniqueformcode=fcd.iduniqueformcode or fcd.iuv=fci.iuv

UNION 

SELECT
	income.idinc,income.nphase,
	ed.iduniqueformcode ,	fci.iuv,	fci.idflusso 
	FROM income (NOLOCK)
	join incomelink IL on IL.idchild = income.idinc and IL.idchild <> IL.idparent
	join incomelast L on IL.idchild = L.idinc 
	join estimatedetail ed on (ed.idinc_taxable = IL.idparent OR ed.idinc_iva = IL.idparent  )  
	join flussocreditidetail fcd on  fcd.iduniqueformcode= ed.iduniqueformcode and fcd.idestimkind is not null
	join flussoincassidetail fci on  fci.iduniqueformcode=fcd.iduniqueformcode or fcd.iuv=fci.iuv
GO



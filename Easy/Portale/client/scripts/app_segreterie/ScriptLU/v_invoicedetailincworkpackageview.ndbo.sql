
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


--setuser 'amministrazione'
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailincworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailincworkpackageview]
GO

-- Per invoicedetail è sufficiente che progettoricavo vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [invoicedetailincworkpackageview]
as
select 
	I.idinvkind, I.yinv, I.ninv,
		CASE
			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
		END as flagbuysell, 
		CASE
			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		END as flagvariation ,
	I.description as descriptioninvoice,
	substring('Doc.IVA:' + I.doc,1,35) as doc,
	I.docdate,
	Idet.rownum,
	Idet.idupb,
	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto,
	IDET.idinc_taxable,
	IDET.idinc_iva,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
			 as iva_euro,
-- Calcola l'incassato
		case 
			when IDET.idinc_taxable IS NULL and  IDET.idinc_iva IS  NULL then 0
			when IDET.idinc_taxable IS not NULL and  IDET.idinc_iva IS  not NULL 
					then CONVERT(decimal(19,2),
						ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
						CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2)) 
						+ CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idinc_taxable IS NULL and  IDET.idinc_iva IS not NULL then CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idinc_taxable IS not NULL and  IDET.idinc_iva IS  NULL then CONVERT(decimal(19,2),
							ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
							CONVERT(DECIMAL(19,10),I.exchangerate) *	 (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
		end AS proceedamount,
	PC.idprogettoricavo
from invoice I 
JOIN invoicekind 		
	ON invoicekind.idinvkind = I.idinvkind
join invoicedetail IDET 
	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
join progettotiporicavoaccmotive PM 	
	on PM.idaccmotive = Idet.idaccmotive 
join progettotipocosto PTC		/*Tipo voce RICAVO*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

left outer join progettoricavo PC
	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated

 go
 

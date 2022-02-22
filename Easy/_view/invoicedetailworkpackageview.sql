
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


---- Non più in uso, è stata sostituita da "invoicedetailexpworkpackageview" in previsione della gestione delle entrate, ove useremo "invoicedetailincworkpackageview".
--IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
--DROP VIEW [invoicedetailworkpackageview]
--GO

---- Per invoicedetail è sufficiente che progettocosto vada in join con idrelated, perchè l'idrelated ha il rownum


--CREATE        VIEW [invoicedetailworkpackageview]
--as
--select 
--	I.idinvkind, I.yinv, I.ninv,
--		CASE
--			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
--			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
--		END as flagbuysell, 
--		CASE
--			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
--			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
--		END as flagvariation ,
--	I.description as descriptioninvoice,
--	I.doc,
--	I.docdate,
--	Idet.rownum,
--	Idet.idupb,
--	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
--	WP.idworkpackage,
--	WP.title as titleworkpackage,
--	WP.description as descriptionworkpackage,
--	P.idprogetto,
--	P.title as progetto,
--	P.idprogettokind,
--	PM.idprogettotipocosto as idprogettotipocosto,
--	IDET.idexp_taxable,
--	IDET.idexp_iva,
--	-- Indica che la fattura è stata pagata col fondo economale.
--	NULL AS idpettycash, NULL as yoperation, NULL as noperation,--PCI.idpettycash , PCI.yoperation, PCI.noperation,
--	-- IMPONIBILE 
--		CONVERT(decimal(19,2),
--		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
--		  CONVERT(DECIMAL(19,10),I.exchangerate) *
--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
--		 ,2
--		)) as taxable_euro,
--	-- IVA
--	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
--			 as iva_euro,
---- Calcola il pagato
--		case 
--			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS  NULL then 0
--			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  not NULL 
--					then CONVERT(decimal(19,2),
--						ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
--						CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2)) 
--						+ CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
--			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS not NULL then CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
--			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  NULL then CONVERT(decimal(19,2),
--							ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
--							CONVERT(DECIMAL(19,10),I.exchangerate) *	 (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
--		end AS payedamount,
--	PC.idprogettocosto
--from invoice I 
--JOIN invoicekind 		
--	ON invoicekind.idinvkind = I.idinvkind
--join invoicedetail IDET 
--	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
--join progettotipocostoaccmotive PM 	
--	on PM.idaccmotive = Idet.idaccmotive 
--join progettotipocosto PTC		/*Tipo voce costo*/
--	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
--join progetto P 
--	on PM.idprogetto = P.idprogetto
--join workpackageupb WPU 
--	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
--join workpackage WP 
--	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

--left outer join progettocosto PC
--	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
--UNION 
--select 
--	I.idinvkind, I.yinv, I.ninv,
--		CASE
--			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
--			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
--		END as flagbuysell, 
--		CASE
--			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
--			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
--		END as flagvariation ,
--	I.description as descriptioninvoice,
--	I.doc,
--	I.docdate,
--	Idet.rownum,
--	Idet.idupb,
--	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
--	WP.idworkpackage,
--	WP.title as titleworkpackage,
--	WP.description as descriptionworkpackage,
--	P.idprogetto,
--	P.title as progetto,
--	P.idprogettokind,
--	PM.idprogettotipocosto as idprogettotipocosto,
--	NULL,--IDET.idexp_taxable,
--	NULL,--IDET.idexp_iva,
--	-- Indica che la fattura è stata pagata col fondo economale.
--	PCI.idpettycash , PCI.yoperation, PCI.noperation,
--	-- IMPONIBILE 
--		CONVERT(decimal(19,2),
--		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
--		  CONVERT(DECIMAL(19,10),I.exchangerate) *
--		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
--		 ,2
--		)) as taxable_euro,
--	-- IVA
--	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
--			 as iva_euro,
---- Calcola il pagato
--			CONVERT(decimal(19,2),
--				ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
--					CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
--				+
--				CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
--		AS payedamount,
--	PC.idprogettocosto
--from invoice I 
--JOIN invoicekind 		
--	ON invoicekind.idinvkind = I.idinvkind
--join invoicedetail IDET 
--	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
--join progettotipocostoaccmotive PM 	
--	on PM.idaccmotive = Idet.idaccmotive 
--join progettotipocosto PTC		/*Tipo voce costo*/
--	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
--join progetto P 
--	on PM.idprogetto = P.idprogetto
--join workpackageupb WPU 
--	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
--join workpackage WP 
--	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--join pettycashoperationinvoice PCI
--	on  PCI.idinvkind = I.idinvkind and PCI.yinv = I.yinv and PCI.ninv = I.ninv
--left outer join progettocosto PC
--	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
--	and PCI.idpettycash = PC.idpettycash AND PCI.yoperation = PC.yoperation AND PCI.noperation = PC.noperation    	 


-- go
 

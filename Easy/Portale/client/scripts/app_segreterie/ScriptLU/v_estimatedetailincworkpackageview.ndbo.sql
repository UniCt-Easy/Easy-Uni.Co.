
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
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetailincworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetailincworkpackageview]
GO

-- Per estimatedetail è sufficiente che progettoricavo vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [estimatedetailincworkpackageview]
as
select 
	I.idestimkind, I.yestim, I.nestim,
	I.description as descriptionestimate,
	substring('Doc.CA:' + I.doc,1,35) as doc,
	I.docdate,
	DET.rownum,
	DET.idupb,
	'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto,
	v.idinc as idincproceed,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(DET.taxable * DET.number * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(DET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(DET.tax,2))
			 as iva_euro,
-- Calcola il pagato
	ISNULL(v.amount, 0) AS proceedamount,
	PC.idprogettoricavo
from estimate I 
JOIN estimatekind 		
	ON estimatekind.idestimkind = I.idestimkind
join estimatedetail DET 
	ON I.idestimkind = DET.idestimkind  and I.yestim = DET.yestim and I.nestim = DET.nestim
join progettotiporicavoaccmotive PM 	
	on PM.idaccmotive = DET.idaccmotive 
join progettotipocosto PTC		/*Tipo voce ricavo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = DET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join incomelastestimatedetail v 
				on	v.idestimkind = DET.idestimkind AND	 v.yestim = DET.yestim AND	 v.nestim = DET.nestim AND		 v.rownum = DET.rownum
left outer join progettoricavo PC
	on 'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) = PC.idrelated
WHERE estimatekind.linktoinvoice = 'N'
 go
 
 --select * from estimatedetailincworkpackageview


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


-- CREAZIONE VISTA invoicekindyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicekindyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicekindyearview]
GO


--setuser 'amm'
--setuser 'amministrazione'
/* 
	select distinct flagbuysell,flagvariation,realsign,
	(select count(*) from invoicekindregisterkind IKRK 
					join ivaregisterkind rk on ikrk.idivaregisterkind=rk.idivaregisterkind
					where rk.registerclass='A' and IKRK.idinvkind=invoicekindyearview.idinvkind) as n_acquisti
	 from invoicekindyearview

*/
CREATE                              VIEW [invoicekindyearview]
(
	ayear,
	idinvkind,	codeinvkind,	description,
	flag,
	flagbuysell,
	flagmixed,
	flagvariation,
	idacc,	idacc_deferred,	idacc_discount,	idacc_unabatable,
	proratarate,	mixedrate,	abatablerate,
	cu,	ct,	lu,	lt,
	idsor01,	idsor02,	idsor03,	idsor04,	idsor05,
	realsign
)
AS SELECT  
	IPR.ayear,	--IKY.ayear,
	IK.idinvkind,	IK.codeinvkind,	IK.description,	IK.flag,
	CASE
		WHEN ((IK.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((IK.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((IK.flag&2)=0) THEN 'N'--flagmixed
		WHEN ((IK.flag&2)<>0) THEN 'S'
	END, 
	CASE
		WHEN ((IK.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((IK.flag&4)<>0) THEN 'S'
	END, 
	
	IKY.idacc,	IKY.idacc_deferred,	IKY.idacc_discount,	IKY.idacc_unabatable,
	IPR.prorata,
	IM.mixed,
		CASE
		WHEN ((IK.flag&2)<>0) THEN IPR.prorata * IM.mixed
		ELSE IPR.prorata
	END,
	IK.cu,	IK.ct,	IK.lu,	IK.lt,
	IK.idsor01,	IK.idsor02,	IK.idsor03,	IK.idsor04,	IK.idsor05,
	(case when ((IK.flag&4)=0) then 1 else -1 end)* --
	(case when ((IK.flag&1)=0) then -1 else 1 end)* -- ((IK.flag&1)=0) THEN 'ACQUISTO'   1 se contabilizzato in entrata -1 in spesa
	(case when (select count(*) from invoicekindregisterkind IKRK 
					join ivaregisterkind rk on ikrk.idivaregisterkind=rk.idivaregisterkind
					where rk.registerclass='A' and IKRK.idinvkind=IK.idinvkind)>0 
					then -1 else 1	end)

FROM invoicekind IK WITH (NOLOCK)
CROSS JOIN iva_prorata IPR WITH (NOLOCK)		--ON IPR.ayear = IKY.ayear
LEFT OUTER JOIN iva_mixed IM WITH (NOLOCK)			ON IM.ayear = IPR.ayear
LEFT OUTER JOIN invoicekindyear IKY WITH (NOLOCK)	ON IK.idinvkind = IKY.idinvkind	AND IKY.ayear = IM.ayear
GO

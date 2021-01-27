
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


-- CREAZIONE VISTA provisionview
IF EXISTS(select * from sysobjects where id = object_id(N'[provisionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [provisionview]
GO
 
 
-- select * from provisionview
CREATE  VIEW provisionview
(
	idprovision,
	description,
	adate,
	idreg,
	registry,
	idepexp,
	yepexp,
	nepexp,
	nphase,
	phase,
	flagvariation,
	epexpdescription,
	title,
	idupb,
	codeupb,
	upb,
	doc,
	docdate,
	idaccmotive,
	codemotive,
	accmotive,
	idaccmotive_patrim,
	codemotive_patrim,
	accmotive_patrim,
	available,
	payed,
	topay,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	provision.idprovision,
	provision.description,
	provision.adate,
	provision.idreg,
	registry.title,
	epexp.idepexp,
	epexp.yepexp,
	epexp.nepexp,
	epexp.nphase,
	case when epexp.nphase = 1 then 'Preimpegno'
		else 'Impegno'
	end,
	epexp.flagvariation,
	epexp.description,
	provision.title,
	provision.idupb,
	upb.codeupb,
	upb.title,
	provision.doc,
	provision.docdate,
	provision.idaccmotive,
	accmotive.codemotive,
	accmotive.title,
	provision.idaccmotive_patrim,
	accmotive_patrim.codemotive,
	accmotive_patrim.title,
	--- AVAILABLE:  somma algebrica delle scritture associate ai conti di accantonamento (bit 12 di flagaccountusage)
	ISNULL((
						select SUM(entrydetail.amount)
						from entrydetail 
						join account on account.idacc = entrydetail.idacc
						where entrydetail.idepexp = epexp.idepexp 
						and ( account.flagaccountusage & 4096)<> 0    
						),0),
	--- "PAYED" come somma dei conti di debito movimentati in avere  
	ISNULL((
				select SUM(entrydetail.amount)
				from entrydetail 
				join account on account.idacc = entrydetail.idacc
				where entrydetail.idepexp = epexp.idepexp 
				and ( account.flagaccountusage & 16)<> 0    
				and entrydetail.amount > 0
				),0),
	--- "TOPAY" come somma dei conti di debito in avere - quelli in dare, considero per semplicità la somma algebrica dei dettagli scritture
	ISNULL((
				select SUM(entrydetail.amount)
				from entrydetail 
				join account on account.idacc = entrydetail.idacc
				where entrydetail.idepexp = epexp.idepexp 
				and ( account.flagaccountusage & 16)<> 0    
				),0),
	provision.idsor01,
	provision.idsor02,
	provision.idsor03,
	provision.idsor04,
	provision.idsor05,
	provision.ct,
	provision.cu,
	provision.lt,
	provision.lu
FROM   provision  
LEFT OUTER JOIN registry
	ON provision.idreg = registry.idreg
LEFT OUTER JOIN epexp 
	ON provision.idepexp = epexp.idepexp
LEFT OUTER JOIN accmotive 
	ON provision.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN accmotive accmotive_patrim 
	ON provision.idaccmotive_patrim = accmotive_patrim.idaccmotive
LEFT OUTER JOIN upb
	ON provision.idupb= upb.idupb
GO


 

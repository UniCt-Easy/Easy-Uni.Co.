
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


-- CREAZIONE VISTA flussocreditidetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[flussocreditidetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flussocreditidetailview]
GO


-- select * from flussocreditidetailview
-- clear_table_info'flussocreditidetailview'
-- setuser 'amministrazione'
-- setuser 'amm'

CREATE    VIEW flussocreditidetailview
 AS
	select 
	D.idflusso,
	C.idsor01,C.idsor02,C.idsor03,C.idsor04,C.idsor05,
	C.istransmitted,
	C.docdate,
	C.idestimkind as idestimkind_main,
	EK.description as estimkind_det,
	D.idestimkind,D.yestim,D.nestim,D.rownum,
	IK.description as invoicekind,
	D.idinvkind,D.yinv, D.ninv, D.invrownum,
	D.description,
	D.iddetail, D.importoversamento, 
	D.idupb, U.title as upb,
	D.idupb_iva, Uiva.title as upb_iva,
	D.iduniqueformcode,
	D.idreg,R.title as registry,
	D.nform,
	D.cf,
	D.iuv,
	D.annulment,
	D.stop,D.flag,
	C.datacreazioneflusso,
	A1.idaccmotive as idaccmotivecredit,
	A2.idaccmotive as idaccmotiveundotax,
	A3.idaccmotive as idaccmotiveundotaxpost,
	A4.idaccmotive as idaccmotiverevenue,
	A1.codemotive as causalecredito,
	A2.codemotive as casualeentroanno ,
	A3.codemotive as casualepostanno,
	A4.codemotive as casualericavo,
	FM.idfinmotive,
	FM.codemotive,
	FM.title as causalebilentrata,
	D.idfinmotive_iva,
	D.competencystart,
	D.competencystop,
	D.codiceavviso, D.idunivoco, D.expirationdate,  D.p_iva,
	D.codicetassonomia,
	D.idsor1,
	D.idsor2,
	D.idsor3,
	sorting1.sortcode as sortcode1,
	sorting2.sortcode as sortcode2,
	sorting3.sortcode as sortcode3,
	D.idlist,
	list.intcode,
	C.cu,
	C.ct,
	C.lu,
	C.lt,
	C.filename,
	D.tax
 from flussocrediti C
	join flussocreditidetail D						on C.idflusso=D.idflusso
	left outer join registry R						on R.idreg= D.idreg
	left outer join estimatekind EK					on D.idestimkind = EK.idestimkind
	left outer join upb U							on U.idupb = D.idupb
	left outer join upb Uiva						on Uiva.idupb = D.idupb_iva
	left outer join invoicekind IK					on D.idinvkind = IK.idinvkind
	left outer join accmotive A1					on A1.idaccmotive = D.idaccmotivecredit
	left outer join accmotive A2					on A2.idaccmotive = D.idaccmotiveundotax
	left outer join accmotive A3					on A3.idaccmotive = D.idaccmotiveundotaxpost
	left outer join accmotive A4					on A4.idaccmotive = D.idaccmotiverevenue
	left outer join finmotive FM					on D.idfinmotive = FM.idfinmotive
	left outer join sorting sorting1 WITH (NOLOCK)	on sorting1.idsor = D.idsor1
	left outer join sorting sorting2 WITH (NOLOCK)	on sorting2.idsor = D.idsor2
	left outer join sorting sorting3 WITH (NOLOCK)	on sorting3.idsor = D.idsor3
	left outer join list on D.idlist=list.idlist



GO

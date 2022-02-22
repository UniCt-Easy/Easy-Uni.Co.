
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


IF EXISTS(select * from sysobjects where id = object_id(N'[import_flowview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [import_flowview]
GO

--setuser 'amm'
--select * from [import_flowview]

CREATE      VIEW [import_flowview]
as
select I.*,
	F.idfin,F.title as fin_title,
	U.idupb,U.title as upb_title,
	accyear.idinc as acc_idinc,
	impyear.idexp as imp_idexp,
	finacc.idfin as acc_idfin,
	finacc.codefin as acc_codefin,
	upbacc.idupb as acc_idupb,
	upbacc.codeupb as acc_codeupb,
	finimp.idfin as imp_idfin,
	finimp.codefin as imp_codefin,
	upbimp.idupb as imp_idupb,
	upbimp.codeupb as imp_codeupb,
	case when I.E_S='E' then sk1.nphaseincome else sk1.nphaseexpense end as nphase1,
	sor1.idsor as idsor1,
	case when I.E_S='E' then sk2.nphaseincome else sk2.nphaseexpense end as nphase2,
	sor2.idsor as idsor2,
	case when I.E_S='E' then sk3.nphaseincome else sk3.nphaseexpense end as nphase3,
	sor3.idsor as idsor3,
	case when I.E_S='E' then sk4.nphaseincome else sk4.nphaseexpense end as nphase4,
	sor4.idsor as idsor4,
	case when I.E_S='E' then sk5.nphaseincome else sk5.nphaseexpense end as nphase5,
	sor5.idsor as idsor5,
	reg.title as registry,
	man.title as manager,
	rpm.idpaymethod,rpm.iban,rpm.cin,rpm.idbank,rpm.idcab,rpm.cc,rpm.iddeputy,rpm.refexternaldoc,
			rpm.paymentdescr, rpm.biccode,rpm.extracode,--rpm.idpaymethod,
	case when I.E_S='S' then accd.idacc else accc.idacc end as idacc,
	case when I.E_S='S' then pay.ymov else pro.ymov end as anno_liqinc,
	case when I.E_S='S' then pay.nmov else pro.nmov end as numero_liqinc,
	case when I.E_S='S' then payment.ypay else proceeds.ypro end as anno_manrev,
	case when I.E_S='S' then payment.npay else proceeds.npro end as numero_manrev,
	case when I_linked.E_S='S' then I_linked.id_liq else I_linked.id_inc   end as linked_id,
	coalesce(F.idfin,accyear.idfin,impyear.idfin) as sel_idfin,
	coalesce(U.idupb,accyear.idupb,impyear.idupb) as sel_idupb,
	coalesce(I.idman,acc.idman,imp.idman,U.idman,upbacc.idman,upbimp.idman) as sel_idman,
	coalesce(I.idreg,acc.idreg,imp.idreg) as sel_idreg,
	I.nfase_accimp as parent_phase,
	t.idtreasurer,
	stamphandling.idstamphandling	


from import_flow I
left outer join fin F on I.codefin = F.codefin and I.esercizio=F.ayear and F.flag&1 = case when I.E_S='E' then 0 else 1 end
left outer join upb U on U.codeupb = I.codeupb
left outer join income acc on I.E_S='E' and acc.ymov = I.anno_accimp and acc.nmov= I.numero_accimp and acc.nphase=isnull(I.nfase_accimp,1)
left outer join incomeyear accyear on I.E_S='E' and acc.idinc = accyear.idinc and accyear.ayear=I.esercizio
left outer join expense imp on I.E_S='S' and imp.ymov = I.anno_accimp and imp.nmov=I.numero_accimp and imp.nphase=isnull(I.nfase_accimp,1)
left outer join expenseyear impyear on I.E_S='S' and impyear.idexp= imp.idexp and impyear.ayear=I.esercizio
left outer join fin finacc on accyear.idfin = finacc.idfin
left outer join fin finimp on impyear.idfin= finimp.idfin
left outer join upb upbacc on accyear.idupb = upbacc.idupb
left outer join upb upbimp on impyear.idupb = upbimp.idupb
left outer join sortingkind sk1 on sk1.codesorkind= I.codtipoclass1
left outer join sorting sor1 on sor1.idsorkind = sk1.idsorkind and sor1.sortcode=I.sortcode1
left outer join sortingkind sk2 on sk2.codesorkind= I.codtipoclass2
left outer join sorting sor2 on sor2.idsorkind = sk2.idsorkind and sor2.sortcode=I.sortcode2
left outer join sortingkind sk3 on sk3.codesorkind= I.codtipoclass3
left outer join sorting sor3 on sor3.idsorkind = sk3.idsorkind and sor3.sortcode=I.sortcode3
left outer join sortingkind sk4 on sk4.codesorkind= I.codtipoclass4
left outer join sorting sor4 on sor4.idsorkind = sk4.idsorkind and sor4.sortcode=I.sortcode4
left outer join sortingkind sk5 on sk5.codesorkind= I.codtipoclass5
left outer join sorting sor5 on sor5.idsorkind = sk5.idsorkind and sor5.sortcode=I.sortcode5
left outer join registry reg on reg.idreg = I.idreg
left outer join manager man on man.idman = I.idman
left outer join registrypaymethod rpm on rpm.idreg=I.idreg and rpm.idregistrypaymethod = I.idregistrypaymethod
left outer join accmotivedetail accd on reg.idaccmotivedebit=accd.idaccmotive and accd.ayear=I.esercizio
left outer join accmotivedetail accc on reg.idaccmotivecredit=accc.idaccmotive and accc.ayear=I.esercizio
left outer join expense pay on I.E_S='S' and I.id_liq = pay.idexp 
left outer join expenselast elast on I.E_S='S' and I.id_liq = elast.idexp
left outer join payment on I.E_S='S' and elast.kpay=payment.kpay
left outer join income pro on I.E_S='E' and I.id_inc = pro.idinc 
left outer join incomelast ilast on I.E_S='E' and I.id_inc = ilast.idinc
left outer join proceeds on I.E_S='E' and ilast.kpro=proceeds.kpro
left outer join import_flow I_linked on I_linked.idimportflow = I.idimportflow_parent
left outer join treasurer t on t.codetreasurer=I.cod_cassiere
left outer join stamphandling on stamphandling.handlingbankcode = I.handlingbankcode

GO


--clear_table_info 'import_flow_view,import_flow'


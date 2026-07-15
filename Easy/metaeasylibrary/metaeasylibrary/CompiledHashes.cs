/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using q= metadatalibrary.MetaExpression;

public class initIndexes {
	private static bool inited = false;

	public initIndexes() {
		if (!inited) {
			inited = true;
			startIndexes();
		}

	}

	static void startIndexes() {

		HashCreatorBuilder.registerHashCreator("HashCreator_idman", new HashCreator_idman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_idsor", new HashCreator_idfin_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idautosort_idfin",
			new HashCreator_ayear_idautosort_idfin());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsorkind", new HashCreator_idsorkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_nvar_rownum_yvar", new HashCreator_nvar_rownum_yvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc", new HashCreator_idacc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotive", new HashCreator_idaccmotive());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridfin", new HashCreator_paridfin());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_nlevel", new HashCreator_ayear_nlevel());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor", new HashCreator_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin", new HashCreator_idfin());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_idupb", new HashCreator_idfin_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear", new HashCreator_ayear());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind_nman_yman",
			new HashCreator_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexpirationkind", new HashCreator_idexpirationkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind_nman_rownum_yman",
			new HashCreator_idmankind_nman_rownum_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcurrency", new HashCreator_idcurrency());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind_idsor_nman_yman",
			new HashCreator_idmankind_idsor_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind", new HashCreator_idmankind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_ninv_rownum_yinv",
			new HashCreator_idinvkind_ninv_rownum_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg", new HashCreator_idreg());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_nvar", new HashCreator_idexp_nvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idupb", new HashCreator_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idsor_idsubclass",
			new HashCreator_idexp_idsor_idsubclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmandatestatus", new HashCreator_idmandatestatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idstore", new HashCreator_idstore());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_idmankind_nman_yman",
			new HashCreator_idattachment_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idivakind", new HashCreator_idivakind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmaritalstatus", new HashCreator_idmaritalstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistryreference",
			new HashCreator_idreg_idregistryreference());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcategory", new HashCreator_idcategory());
		HashCreatorBuilder.registerHashCreator("HashCreator_idposition", new HashCreator_idposition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrylegalstatus",
			new HashCreator_idreg_idregistrylegalstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcentralizedcategory",
			new HashCreator_idcentralizedcategory());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idsor", new HashCreator_idreg_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idregistrykind", new HashCreator_idregistrykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idtitle", new HashCreator_idtitle());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrypaymethod",
			new HashCreator_idreg_idregistrypaymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_start", new HashCreator_idreg_start());
		HashCreatorBuilder.registerHashCreator("HashCreator_idresidence", new HashCreator_idresidence());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaddress", new HashCreator_idaddress());
		HashCreatorBuilder.registerHashCreator("HashCreator_idregistryclass", new HashCreator_idregistryclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcity", new HashCreator_idcity());
		HashCreatorBuilder.registerHashCreator("HashCreator_idagency_idcity_idcode_version",
			new HashCreator_idagency_idcity_idcode_version());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaddresskind_idreg_start",
			new HashCreator_idaddresskind_idreg_start());
		HashCreatorBuilder.registerHashCreator("HashCreator_idnation", new HashCreator_idnation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotivecredit", new HashCreator_idaccmotivecredit());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotivedebit", new HashCreator_idaccmotivedebit());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddaliaposition", new HashCreator_iddaliaposition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaddresskind", new HashCreator_idaddresskind());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddurckind", new HashCreator_iddurckind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idspecialcategory770",
			new HashCreator_ayear_idspecialcategory770());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrycf", new HashCreator_idreg_idregistrycf());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrypiva",
			new HashCreator_idreg_idregistrypiva());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrydurc",
			new HashCreator_idreg_idregistrydurc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistrycvattachment",
			new HashCreator_idreg_idregistrycvattachment());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistryspecialcategory770",
			new HashCreator_idreg_idregistryspecialcategory770());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_idregistryvisura",
			new HashCreator_idreg_idregistryvisura());
		HashCreatorBuilder.registerHashCreator("HashCreator_idregion", new HashCreator_idregion());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcountry", new HashCreator_idcountry());
		HashCreatorBuilder.registerHashCreator("HashCreator_idbank", new HashCreator_idbank());
		HashCreatorBuilder.registerHashCreator("HashCreator_idbank_idcab", new HashCreator_idbank_idcab());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpaymethod", new HashCreator_idpaymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_idchargehandling", new HashCreator_idchargehandling());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddeputy", new HashCreator_iddeputy());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepexp_nvar", new HashCreator_idepexp_nvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind_iduniqueregister_nman_yman",
			new HashCreator_idmankind_iduniqueregister_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_cigcode_idmankind_nman_yman",
			new HashCreator_cigcode_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachmentkind", new HashCreator_idattachmentkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_cigcode_idavcp_idmankind_nman_yman",
			new HashCreator_cigcode_idavcp_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idavcp_idmankind_nman_yman",
			new HashCreator_idavcp_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlist", new HashCreator_idlist());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinv", new HashCreator_idinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idconsipcategory", new HashCreator_idconsipcategory());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepexp_rownum", new HashCreator_idepexp_rownum());
		HashCreatorBuilder.registerHashCreator("HashCreator_idconsipkind", new HashCreator_idconsipkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp", new HashCreator_idexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_idclawback", new HashCreator_idclawback());
		HashCreatorBuilder.registerHashCreator("HashCreator_idclawback_idexp", new HashCreator_idclawback_idexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idexp", new HashCreator_ayear_idexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_nphase", new HashCreator_nphase());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_nbracket_taxcode",
			new HashCreator_idexp_nbracket_taxcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_taxcode", new HashCreator_taxcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idmankind_nman_yman",
			new HashCreator_idexp_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_iditineration",
			new HashCreator_idexp_iditineration());
		HashCreatorBuilder.registerHashCreator("HashCreator_idestimkind_nestim_yestim",
			new HashCreator_idestimkind_nestim_yestim());
		HashCreatorBuilder.registerHashCreator("HashCreator_idunderwriting", new HashCreator_idunderwriting());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_idsor_idsubclass",
			new HashCreator_idinc_idsor_idsubclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_idestimkind_nestim_rownum_yestim",
			new HashCreator_idestimkind_nestim_rownum_yestim());
		HashCreatorBuilder.registerHashCreator("HashCreator_idestimkind", new HashCreator_idestimkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_idestimkind_nestim_yestim",
			new HashCreator_idattachment_idestimkind_nestim_yestim());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_nvar", new HashCreator_idinc_nvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idestimkind_idsor_nestim_yestim",
			new HashCreator_idestimkind_idsor_nestim_yestim());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_ninv_yinv",
			new HashCreator_idinvkind_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idivaregisterkind", new HashCreator_idivaregisterkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idivaregisterkind_nivaregister_yivaregister",
			new HashCreator_idivaregisterkind_nivaregister_yivaregister());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccountkind", new HashCreator_idaccountkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_idsor_ninv_yinv",
			new HashCreator_idinvkind_idsor_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idinvkind", new HashCreator_ayear_idinvkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind", new HashCreator_idinvkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_ninv_nivapay_yinv_yivapay",
			new HashCreator_idinvkind_ninv_nivapay_yinv_yivapay());
		HashCreatorBuilder.registerHashCreator("HashCreator_idtreasurer", new HashCreator_idtreasurer());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_idivaregisterkind",
			new HashCreator_idinvkind_idivaregisterkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpcc", new HashCreator_idpcc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfepaymethod", new HashCreator_idfepaymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_iduniqueregister_ninv_yinv",
			new HashCreator_idinvkind_iduniqueregister_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_idinvkind_ninv_yinv",
			new HashCreator_idattachment_idinvkind_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsdi_acquisto", new HashCreator_idsdi_acquisto());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatnation", new HashCreator_idintrastatnation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsdi_status", new HashCreator_idsdi_status());
		HashCreatorBuilder.registerHashCreator("HashCreator_ncon_ycon", new HashCreator_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_idstock", new HashCreator_idstock());
		HashCreatorBuilder.registerHashCreator("HashCreator_idblacklist", new HashCreator_idblacklist());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfepaymethodcondition",
			new HashCreator_idfepaymethodcondition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatkind", new HashCreator_idintrastatkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatpaymethod",
			new HashCreator_idintrastatpaymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsdi_vendita", new HashCreator_idsdi_vendita());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsdi_deliverystatus",
			new HashCreator_idsdi_deliverystatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_ipa_fe", new HashCreator_ipa_fe());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsdi_rifamm", new HashCreator_idsdi_rifamm());
		HashCreatorBuilder.registerHashCreator("HashCreator_nassetacquire", new HashCreator_nassetacquire());
		HashCreatorBuilder.registerHashCreator("HashCreator_idnocigmotive", new HashCreator_idnocigmotive());
		HashCreatorBuilder.registerHashCreator("HashCreator_idser", new HashCreator_idser());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration", new HashCreator_iditineration());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_nrefund",
			new HashCreator_iditineration_nrefund());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_lapnumber",
			new HashCreator_iditineration_lapnumber());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_taxcode",
			new HashCreator_iditineration_taxcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_start", new HashCreator_start());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditinerationrefundkind",
			new HashCreator_iditinerationrefundkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_groupnumber_idreduction_start",
			new HashCreator_groupnumber_idreduction_start());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_idsor",
			new HashCreator_iditineration_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idforeigncountry", new HashCreator_idforeigncountry());
		HashCreatorBuilder.registerHashCreator("HashCreator_idflights_iditineration",
			new HashCreator_idflights_iditineration());
		HashCreatorBuilder.registerHashCreator("HashCreator_idauthagency_iditineration",
			new HashCreator_idauthagency_iditineration());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_iditineration",
			new HashCreator_idattachment_iditineration());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddalia_dipartimento",
			new HashCreator_iddalia_dipartimento());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddalia_funzionale", new HashCreator_iddalia_funzionale());
		HashCreatorBuilder.registerHashCreator("HashCreator_idauthagency", new HashCreator_idauthagency());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddaliarecruitmentmotive",
			new HashCreator_iddaliarecruitmentmotive());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditinerationstatus",
			new HashCreator_iditinerationstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idauthmodel", new HashCreator_idauthmodel());
		HashCreatorBuilder.registerHashCreator("HashCreator_kpaymenttransmission",
			new HashCreator_kpaymenttransmission());
		HashCreatorBuilder.registerHashCreator("HashCreator_kpay", new HashCreator_kpay());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpettycash", new HashCreator_idpettycash());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpettycash_ncon_noperation_ycon_yoperation",
			new HashCreator_idpettycash_ncon_noperation_ycon_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpettycash_idunderwriting_noperation_yoperation",
			new HashCreator_idpettycash_idunderwriting_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idpettycash", new HashCreator_ayear_idpettycash());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idclawback", new HashCreator_ayear_idclawback());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpettycash_noperation_yoperation",
			new HashCreator_idpettycash_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpettycash_idsor_idsubclass_noperation_yoperation",
			new HashCreator_idpettycash_idsor_idsubclass_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_billkind_nbill_ybill",
			new HashCreator_billkind_nbill_ybill());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_idpettycash_noperation_yoperation",
			new HashCreator_iditineration_idpettycash_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_idpettycash_ninv_noperation_yinv_yoperation",
			new HashCreator_idinvkind_idpettycash_ninv_noperation_yinv_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idtipo", new HashCreator_idtipo());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_idpettycash_noperation_yoperation",
			new HashCreator_idinc_idpettycash_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idpettycash_noperation_yoperation",
			new HashCreator_idexp_idpettycash_noperation_yoperation());
		HashCreatorBuilder.registerHashCreator("HashCreator_kproceedstransmission",
			new HashCreator_kproceedstransmission());
		HashCreatorBuilder.registerHashCreator("HashCreator_kpro", new HashCreator_kpro());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idposition", new HashCreator_ayear_idposition());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_ncon_ycon", new HashCreator_ayear_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_ncon_ycon", new HashCreator_idsor_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcontractlength",
			new HashCreator_ayear_idcontractlength());
		HashCreatorBuilder.registerHashCreator("HashCreator_ncon_taxcode_ycon", new HashCreator_ncon_taxcode_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idworkingtime",
			new HashCreator_ayear_idworkingtime());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idinvkind_ninv_yinv",
			new HashCreator_idexp_idinvkind_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idunderwriting",
			new HashCreator_idexp_idunderwriting());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_ncon_ycon", new HashCreator_idexp_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpayroll_idpayrolltax",
			new HashCreator_idpayroll_idpayrolltax());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_nbill_ybill", new HashCreator_idexp_nbill_ybill());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idpayroll", new HashCreator_idexp_idpayroll());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idexpensetaxcorrige",
			new HashCreator_idexp_idexpensetaxcorrige());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfiscaltaxregion", new HashCreator_idfiscaltaxregion());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_idexpensetaxofficial",
			new HashCreator_idexp_idexpensetaxofficial());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpayroll", new HashCreator_idpayroll());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc", new HashCreator_idinc());
		HashCreatorBuilder.registerHashCreator("HashCreator_tiporiga", new HashCreator_tiporiga());
		HashCreatorBuilder.registerHashCreator("HashCreator_code", new HashCreator_code());
		HashCreatorBuilder.registerHashCreator("HashCreator_rifa_month", new HashCreator_rifa_month());
		HashCreatorBuilder.registerHashCreator("HashCreator_rifb_month", new HashCreator_rifb_month());
		HashCreatorBuilder.registerHashCreator("HashCreator_idformerexpense", new HashCreator_idformerexpense());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetload", new HashCreator_idassetload());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset", new HashCreator_idasset());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetusagekind_nassetacquire",
			new HashCreator_idassetusagekind_nassetacquire());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetusagekind", new HashCreator_idassetusagekind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_idassetmanager",
			new HashCreator_idasset_idassetmanager());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinv_idmultifieldkind",
			new HashCreator_idinv_idmultifieldkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetloadkind", new HashCreator_idassetloadkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_idassetlocation",
			new HashCreator_idasset_idassetlocation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_idassetsubmanager",
			new HashCreator_idasset_idassetsubmanager());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_idpiece", new HashCreator_idasset_idpiece());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlocation", new HashCreator_idlocation());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmot", new HashCreator_idmot());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmultifieldkind", new HashCreator_idmultifieldkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinventory", new HashCreator_idinventory());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor2", new HashCreator_idsor2());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor1", new HashCreator_idsor1());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor3", new HashCreator_idsor3());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetunload", new HashCreator_idassetunload());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetunload_idinc",
			new HashCreator_idassetunload_idinc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetunloadkind", new HashCreator_idassetunloadkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_namortization", new HashCreator_namortization());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetload_idexp", new HashCreator_idassetload_idexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_idenactment", new HashCreator_idenactment());
		HashCreatorBuilder.registerHashCreator("HashCreator_nvar_yvar", new HashCreator_nvar_yvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor04", new HashCreator_idsor04());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor05", new HashCreator_idsor05());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor02", new HashCreator_idsor02());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor03", new HashCreator_idsor03());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor01", new HashCreator_idsor01());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepacc", new HashCreator_idepacc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepacc_rownum", new HashCreator_idepacc_rownum());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idepacc", new HashCreator_ayear_idepacc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepacc_nvar", new HashCreator_idepacc_nvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridepacc", new HashCreator_paridepacc());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idepexp", new HashCreator_ayear_idepexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepexp", new HashCreator_idepexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridepexp", new HashCreator_paridepexp());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotivecredit_crg",
			new HashCreator_idaccmotivecredit_crg());
		HashCreatorBuilder.registerHashCreator("HashCreator_idivakind_forced", new HashCreator_idivakind_forced());
		HashCreatorBuilder.registerHashCreator("HashCreator_movkind", new HashCreator_movkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_ncreditpart", new HashCreator_idinc_ncreditpart());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_nproceedspart",
			new HashCreator_idinc_nproceedspart());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idinc", new HashCreator_ayear_idinc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope", new HashCreator_idsor_siope());
		HashCreatorBuilder.registerHashCreator("HashCreator_iso_payment", new HashCreator_iso_payment());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcountry_origin", new HashCreator_idcountry_origin());
		HashCreatorBuilder.registerHashCreator("HashCreator_iso_destination", new HashCreator_iso_destination());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcountry_destination",
			new HashCreator_idcountry_destination());
		HashCreatorBuilder.registerHashCreator("HashCreator_iso_provenance", new HashCreator_iso_provenance());
		HashCreatorBuilder.registerHashCreator("HashCreator_iso_origin", new HashCreator_iso_origin());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotivedebit_crg",
			new HashCreator_idaccmotivedebit_crg());
		HashCreatorBuilder.registerHashCreator("HashCreator_rifamm_ven_emittente",
			new HashCreator_rifamm_ven_emittente());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_sostituto", new HashCreator_idreg_sostituto());
		HashCreatorBuilder.registerHashCreator("HashCreator_ipa_ven_emittente", new HashCreator_ipa_ven_emittente());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_forwarder_ninv_forwarder_yinv_forwarder",
			new HashCreator_idinvkind_forwarder_ninv_forwarder_yinv_forwarder());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_invrownum_ninv_yinv",
			new HashCreator_idinvkind_invrownum_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_idgroup_ninv_yinv",
			new HashCreator_idinvkind_idgroup_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinvkind_inv_idgroup_ninv_yinv",
			new HashCreator_idinvkind_inv_idgroup_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmain_avcp_idmankind_nman_yman",
			new HashCreator_idmain_avcp_idmankind_nman_yman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_rupanac", new HashCreator_idreg_rupanac());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmankind_idsor", new HashCreator_idmankind_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachmentkind_idmankind",
			new HashCreator_idattachmentkind_idmankind());
		HashCreatorBuilder.registerHashCreator("HashCreator_nservreg_yservreg", new HashCreator_nservreg_yservreg());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idapregistrykind",
			new HashCreator_ayear_idapregistrykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idapmanager", new HashCreator_ayear_idapmanager());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idfinancialactivity",
			new HashCreator_ayear_idfinancialactivity());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idapcontractkind",
			new HashCreator_ayear_idapcontractkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idapactivitykind",
			new HashCreator_ayear_idapactivitykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idconsultingkind",
			new HashCreator_ayear_idconsultingkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idacquirekind",
			new HashCreator_ayear_idacquirekind());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddepartment", new HashCreator_iddepartment());
		HashCreatorBuilder.registerHashCreator("HashCreator_nservreg_semesterpay_ypay_yservreg",
			new HashCreator_nservreg_semesterpay_ypay_yservreg());
		HashCreatorBuilder.registerHashCreator("HashCreator_pa_code", new HashCreator_pa_code());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreferencerule", new HashCreator_idreferencerule());
		HashCreatorBuilder.registerHashCreator("HashCreator_idapfinancialactivity",
			new HashCreator_idapfinancialactivity());
		HashCreatorBuilder.registerHashCreator("HashCreator_idserviceregistrykind",
			new HashCreator_idserviceregistrykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_yservreg_idacquirekind",
			new HashCreator_yservreg_idacquirekind());
		HashCreatorBuilder.registerHashCreator("HashCreator_yservreg_idfinancialactivity",
			new HashCreator_yservreg_idfinancialactivity());
		HashCreatorBuilder.registerHashCreator("HashCreator_idconferring", new HashCreator_idconferring());
		HashCreatorBuilder.registerHashCreator("HashCreator_conferring_idcity", new HashCreator_conferring_idcity());
		HashCreatorBuilder.registerHashCreator("HashCreator_yservreg_idapcontractkind",
			new HashCreator_yservreg_idapcontractkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_discount", new HashCreator_idacc_discount());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_unabatable", new HashCreator_idacc_unabatable());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_deferred", new HashCreator_idacc_deferred());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_split", new HashCreator_idacc_split());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_deferred_split",
			new HashCreator_idacc_deferred_split());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_deferred_intra",
			new HashCreator_idacc_deferred_intra());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_unabatable_split",
			new HashCreator_idacc_unabatable_split());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_intra", new HashCreator_idacc_intra());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_unabatable_intra",
			new HashCreator_idacc_unabatable_intra());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatmeasure", new HashCreator_idintrastatmeasure());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatsupplymethod",
			new HashCreator_idintrastatsupplymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatcode", new HashCreator_idintrastatcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcostpartition", new HashCreator_idcostpartition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpccdebitmotive", new HashCreator_idpccdebitmotive());
		HashCreatorBuilder.registerHashCreator("HashCreator_idunit", new HashCreator_idunit());
		HashCreatorBuilder.registerHashCreator(
			"HashCreator_idinvkind_idivaregisterkind_ninv_nivapay_rownum_yinv_yivapay",
			new HashCreator_idinvkind_idivaregisterkind_ninv_nivapay_rownum_yinv_yivapay());
		HashCreatorBuilder.registerHashCreator("HashCreator_idintrastatservice", new HashCreator_idintrastatservice());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpccdebitstatus", new HashCreator_idpccdebitstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlistclass", new HashCreator_idlistclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpackage", new HashCreator_idpackage());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfinmotive", new HashCreator_idfinmotive());
		HashCreatorBuilder.registerHashCreator("HashCreator_idunderwriter", new HashCreator_idunderwriter());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_idupb", new HashCreator_idsor_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_idupb", new HashCreator_idattachment_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_idupb", new HashCreator_idacc_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idepupbkind", new HashCreator_idepupbkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idautosort_idupb",
			new HashCreator_ayear_idautosort_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idupb_idupb_dest", new HashCreator_idupb_idupb_dest());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idupb", new HashCreator_ayear_idupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridupb", new HashCreator_paridupb());
		HashCreatorBuilder.registerHashCreator("HashCreator_idupb_dest", new HashCreator_idupb_dest());
		HashCreatorBuilder.registerHashCreator("HashCreator_idupb_iva", new HashCreator_idupb_iva());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotiveannulment",
			new HashCreator_idaccmotiveannulment());
		HashCreatorBuilder.registerHashCreator("HashCreator_idrevenuepartition", new HashCreator_idrevenuepartition());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idunderwriting",
			new HashCreator_ayear_idunderwriting());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_iva", new HashCreator_idexp_iva());
		HashCreatorBuilder.registerHashCreator("HashCreator_idexp_taxable", new HashCreator_idexp_taxable());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_linked", new HashCreator_idinc_linked());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_idinvkind_ninv_yinv",
			new HashCreator_idinc_idinvkind_ninv_yinv());
		HashCreatorBuilder.registerHashCreator("HashCreator_idestimkind_idinc_nestim_yestim",
			new HashCreator_idestimkind_idinc_nestim_yestim());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_nbill_ybill", new HashCreator_idinc_nbill_ybill());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_iva", new HashCreator_idinc_iva());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinc_taxable", new HashCreator_idinc_taxable());
		HashCreatorBuilder.registerHashCreator("HashCreator_nphaseincome", new HashCreator_nphaseincome());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinventoryamortization",
			new HashCreator_idinventoryamortization());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_idgrant_idpiece",
			new HashCreator_idasset_idgrant_idpiece());
		HashCreatorBuilder.registerHashCreator("HashCreator_idasset_iddetail_idgrant_idpiece",
			new HashCreator_idasset_iddetail_idgrant_idpiece());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmanager", new HashCreator_idmanager());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcurrman", new HashCreator_idcurrman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcurrsubman", new HashCreator_idcurrsubman());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinventoryagency", new HashCreator_idinventoryagency());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetvar_idassetvardetail",
			new HashCreator_idassetvar_idassetvardetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idassetvar", new HashCreator_idassetvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idreg_distrained", new HashCreator_idreg_distrained());
		HashCreatorBuilder.registerHashCreator("HashCreator_iditineration_ref", new HashCreator_iditineration_ref());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcon", new HashCreator_idcon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idotherinsurance",
			new HashCreator_ayear_idotherinsurance());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpayrollkind", new HashCreator_idpayrollkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddeduction", new HashCreator_iddeduction());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idabatement_idcon",
			new HashCreator_ayear_idabatement_idcon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcon_iddeduction",
			new HashCreator_ayear_idcon_iddeduction());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcon_idexhibitedcud",
			new HashCreator_idcon_idexhibitedcud());
		HashCreatorBuilder.registerHashCreator("HashCreator_idabatement", new HashCreator_idabatement());
		HashCreatorBuilder.registerHashCreator("HashCreator_idabatement_idcon_idexhibitedcud",
			new HashCreator_idabatement_idcon_idexhibitedcud());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddeduction_idpayroll",
			new HashCreator_iddeduction_idpayroll());
		HashCreatorBuilder.registerHashCreator("HashCreator_idabatement_idpayroll",
			new HashCreator_idabatement_idpayroll());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpayroll_idpayrolltax_nbracket",
			new HashCreator_idpayroll_idpayrolltax_nbracket());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcon_idfamily",
			new HashCreator_ayear_idcon_idfamily());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idabatement", new HashCreator_ayear_idabatement());
		HashCreatorBuilder.registerHashCreator("HashCreator_activitycode_ayear", new HashCreator_activitycode_ayear());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcon_idotherinail", new HashCreator_idcon_idotherinail());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_iddeduction", new HashCreator_ayear_iddeduction());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcon_iddeduction_idexhibitedcud",
			new HashCreator_idcon_iddeduction_idexhibitedcud());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpat", new HashCreator_idpat());
		HashCreatorBuilder.registerHashCreator("HashCreator_idmatriculabook", new HashCreator_idmatriculabook());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcon", new HashCreator_ayear_idcon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idemenscontractkind",
			new HashCreator_ayear_idemenscontractkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcon_idsor", new HashCreator_idcon_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcafdocument_idcon",
			new HashCreator_idcafdocument_idcon());
		HashCreatorBuilder.registerHashCreator("HashCreator_codice", new HashCreator_codice());
		HashCreatorBuilder.registerHashCreator("HashCreator_idtaxratestart_nbracket_taxcode",
			new HashCreator_idtaxratestart_nbracket_taxcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpayroll_idpayrolltaxcorrige",
			new HashCreator_idpayroll_idpayrolltaxcorrige());
		HashCreatorBuilder.registerHashCreator("HashCreator_cafdocumentkind", new HashCreator_cafdocumentkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlinkedrefund", new HashCreator_idlinkedrefund());
		HashCreatorBuilder.registerHashCreator("HashCreator_cigcode_idavcp_ncon_ycon",
			new HashCreator_cigcode_idavcp_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_cigcode_ncon_ycon", new HashCreator_cigcode_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_ncon_nrefund_ycon", new HashCreator_ncon_nrefund_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_idavcp_ncon_ycon", new HashCreator_idavcp_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_nbracket_ncon_taxcode_ycon",
			new HashCreator_nbracket_ncon_taxcode_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddeduction_ncon_ycon",
			new HashCreator_iddeduction_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_startvalidity", new HashCreator_startvalidity());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idser", new HashCreator_ayear_idser());
		HashCreatorBuilder.registerHashCreator("HashCreator_iduniqueregister_ncon_ycon",
			new HashCreator_iduniqueregister_ncon_ycon());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlist_idsor", new HashCreator_idlist_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idlistclass", new HashCreator_ayear_idlistclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridlistclass", new HashCreator_paridlistclass());
		HashCreatorBuilder.registerHashCreator("HashCreator_nentry_yentry", new HashCreator_nentry_yentry());
		HashCreatorBuilder.registerHashCreator("HashCreator_identrykind", new HashCreator_identrykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccrual_ndetail_nentry_yentry",
			new HashCreator_idaccrual_ndetail_nentry_yentry());
		HashCreatorBuilder.registerHashCreator("HashCreator_ndetail_nentry_yentry",
			new HashCreator_ndetail_nentry_yentry());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfinvarstatus", new HashCreator_idfinvarstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfinvarkind", new HashCreator_idfinvarkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idvariationkind", new HashCreator_idvariationkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idlcardvar", new HashCreator_idlcardvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idattachment_nvar_yvar",
			new HashCreator_idattachment_nvar_yvar());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccountvarstatus", new HashCreator_idaccountvarstatus());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpatrimony", new HashCreator_idpatrimony());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_idsor", new HashCreator_idacc_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idplaccount", new HashCreator_idplaccount());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridacc", new HashCreator_paridacc());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_investmentbudget",
			new HashCreator_idsor_investmentbudget());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_economicbudget",
			new HashCreator_idsor_economicbudget());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridpatrimony", new HashCreator_paridpatrimony());
		HashCreatorBuilder.registerHashCreator("HashCreator_paridplaccount", new HashCreator_paridplaccount());
		HashCreatorBuilder.registerHashCreator("HashCreator_idstamphandling", new HashCreator_idstamphandling());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddetail_idpaydisposition",
			new HashCreator_iddetail_idpaydisposition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpaydisposition", new HashCreator_idpaydisposition());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpay_kpay", new HashCreator_idpay_kpay());
		HashCreatorBuilder.registerHashCreator("HashCreator_kpay_nban_yban", new HashCreator_kpay_nban_yban());
		HashCreatorBuilder.registerHashCreator("HashCreator_kpro_nban_yban", new HashCreator_kpro_nban_yban());
		HashCreatorBuilder.registerHashCreator("HashCreator_idpro_kpro", new HashCreator_idpro_kpro());
		HashCreatorBuilder.registerHashCreator("HashCreator_iddivision", new HashCreator_iddivision());
		HashCreatorBuilder.registerHashCreator("HashCreator_idman_idsor", new HashCreator_idman_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotive_debit", new HashCreator_idaccmotive_debit());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotive_cost", new HashCreator_idaccmotive_cost());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotive_payment",
			new HashCreator_idaccmotive_payment());
		HashCreatorBuilder.registerHashCreator("HashCreator_idbankcbi", new HashCreator_idbankcbi());
		HashCreatorBuilder.registerHashCreator("HashCreator_idbankcbi_idcabcbi", new HashCreator_idbankcbi_idcabcbi());
		HashCreatorBuilder.registerHashCreator("HashCreator_idaccmotive_proceeds",
			new HashCreator_idaccmotive_proceeds());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinventorykind", new HashCreator_idinventorykind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idinv_idinv_lev1", new HashCreator_idinv_idinv_lev1());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcertificationmodel",
			new HashCreator_idcertificationmodel());
		HashCreatorBuilder.registerHashCreator("HashCreator_idser_taxcode", new HashCreator_idser_taxcode());
		HashCreatorBuilder.registerHashCreator("HashCreator_idser_idsor", new HashCreator_idser_idsor());
		HashCreatorBuilder.registerHashCreator("HashCreator_voce", new HashCreator_voce());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idmot", new HashCreator_ayear_idmot());


		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import", new HashCreator_idcsa_import());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contract",
			new HashCreator_ayear_idcsa_contract());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_contractkind", new HashCreator_idcsa_contractkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idriep",
			new HashCreator_idcsa_import_idriep());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idriep_ndetail",
			new HashCreator_idcsa_import_idriep_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contractkind",
			new HashCreator_ayear_idcsa_contractkind());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contract_idcsa_contracttax",
			new HashCreator_ayear_idcsa_contract_idcsa_contracttax());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idver", new HashCreator_idcsa_import_idver());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contractkind_idcsa_contractkinddata",
			new HashCreator_ayear_idcsa_contractkind_idcsa_contractkinddata());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_agency", new HashCreator_idcsa_agency());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_incomesetup",
			new HashCreator_ayear_idcsa_incomesetup());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_agency_idcsa_agencypaymethod",
			new HashCreator_idcsa_agency_idcsa_agencypaymethod());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contract_idcsa_contracttax_ndetail",
			new HashCreator_ayear_idcsa_contract_idcsa_contracttax_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idver_ndetail",
			new HashCreator_idcsa_import_idver_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idexp_idver_ndetail",
			new HashCreator_idcsa_import_idexp_idver_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idinc_idver_ndetail",
			new HashCreator_idcsa_import_idinc_idver_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope_expense",
			new HashCreator_idsor_siope_expense());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope_income", new HashCreator_idsor_siope_income());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_expense", new HashCreator_idfin_expense());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_income", new HashCreator_idfin_income());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope_cost", new HashCreator_idsor_siope_cost());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_cost", new HashCreator_idacc_cost());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcustomdirectrel", new HashCreator_idcustomdirectrel());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcustomindirectrel",
			new HashCreator_idcustomindirectrel());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope_incomeclawback",
			new HashCreator_idsor_siope_incomeclawback());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_incomeclawback",
			new HashCreator_idfin_incomeclawback());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_cost", new HashCreator_idfin_cost());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_debit", new HashCreator_idacc_debit());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_internalcredit",
			new HashCreator_idacc_internalcredit());
		HashCreatorBuilder.registerHashCreator("HashCreator_modulename", new HashCreator_modulename());
		HashCreatorBuilder.registerHashCreator("HashCreator_paramname_procedurename",
			new HashCreator_paramname_procedurename());
		HashCreatorBuilder.registerHashCreator("HashCreator_procedurename", new HashCreator_procedurename());
		HashCreatorBuilder.registerHashCreator("HashCreator_fileformat", new HashCreator_fileformat());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idexp_idriep_ndetail",
			new HashCreator_idcsa_import_idexp_idriep_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcustomdirectrel", new HashCreator_idcustomdirectrel());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_bill_idcsa_import",
			new HashCreator_idcsa_bill_idcsa_import());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contract_ndetail",
			new HashCreator_ayear_idcsa_contract_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idcsa_import_idinc_idriep_ndetail",
			new HashCreator_idcsa_import_idinc_idriep_ndetail());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_revenue", new HashCreator_idacc_revenue());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contractkind_idcsa_rule",
			new HashCreator_ayear_idcsa_contractkind_idcsa_rule());
		HashCreatorBuilder.registerHashCreator("HashCreator_ayear_idcsa_contract_idcsa_registry",
			new HashCreator_ayear_idcsa_contract_idcsa_registry());
		HashCreatorBuilder.registerHashCreator("HashCreator_idsor_siope_main", new HashCreator_idsor_siope_main());
		HashCreatorBuilder.registerHashCreator("HashCreator_idfin_main", new HashCreator_idfin_main());
		HashCreatorBuilder.registerHashCreator("HashCreator_idacc_main", new HashCreator_idacc_main());
		HashCreatorBuilder.registerHashCreator("HashCreator_idwebpayment", new HashCreator_idwebpayment());
		HashCreatorBuilder.registerHashCreator("HashCreator_idflusso", new HashCreator_idflusso());
		

	}
}





public class HashCreator_idwebpayment : IHashCreator { 
	public string[] k   ={"idwebpayment"};
	public string []keys {get {return k;}}
	public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
		if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
		return r["idwebpayment",v].ToString();
	}
	public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
		if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
		return proposedValue.ToString();
	}
	public string getFromObject(object o) {
		return q.getField("idwebpayment",o).ToString();
	}
	public string getFromDictionary(Dictionary<string,object>o) {
		return (o["idwebpayment"]??"").ToString();
	}
	public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
		return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
	}
	public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
		return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
	}
} 


 public class HashCreator_idflusso : IHashCreator { 
public string[] k   ={"idflusso"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idflusso",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idflusso",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idflusso"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
  


public class HashCreator_idman : IHashCreator { 
public string[] k   ={"idman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idman",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idman",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idman"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_idsor : IHashCreator { 
public string[] k   ={"idfin","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idfin",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idfin")?proposedValue.ToString():r["idfin",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idfin",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idfin"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idfin"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idfin"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_ayear_idautosort_idfin : IHashCreator { 
public string[] k   ={"ayear","idautosort","idfin"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idautosort",v].ToString(),r["idfin",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idautosort")?proposedValue.ToString():r["idautosort",v].ToString());
s += "§"+ ((field=="idfin")?proposedValue.ToString():r["idfin",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idautosort",o).ToString(),q.getField("idfin",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idautosort"]??"").ToString(),(o["idfin"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idautosort"].ToString(),childVal["idfin"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idautosort"].ToString(),parentVal["idfin"].ToString());
}
 } 
public class HashCreator_idsorkind : IHashCreator { 
public string[] k   ={"idsorkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsorkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsorkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsorkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nvar_rownum_yvar : IHashCreator { 
public string[] k   ={"nvar","rownum","yvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nvar",v].ToString(),r["rownum",v].ToString(),r["yvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nvar")?proposedValue.ToString():r["nvar",v].ToString();
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
s += "§"+ ((field=="yvar")?proposedValue.ToString():r["yvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nvar",o).ToString(),q.getField("rownum",o).ToString(),q.getField("yvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nvar"]??"").ToString(),(o["rownum"]??"").ToString(),(o["yvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nvar"].ToString(),childVal["rownum"].ToString(),childVal["yvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nvar"].ToString(),parentVal["rownum"].ToString(),parentVal["yvar"].ToString());
}
 } 
public class HashCreator_idacc : IHashCreator { 
public string[] k   ={"idacc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotive : IHashCreator { 
public string[] k   ={"idaccmotive"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotive",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotive",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotive"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paridfin : IHashCreator { 
public string[] k   ={"paridfin"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridfin",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridfin",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridfin"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_nlevel : IHashCreator { 
public string[] k   ={"ayear","nlevel"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["nlevel",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="nlevel")?proposedValue.ToString():r["nlevel",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("nlevel",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["nlevel"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["nlevel"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["nlevel"].ToString());
}
 } 
public class HashCreator_idsor : IHashCreator { 
public string[] k   ={"idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin : IHashCreator { 
public string[] k   ={"idfin"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_idupb : IHashCreator { 
public string[] k   ={"idfin","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idfin",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idfin")?proposedValue.ToString():r["idfin",v].ToString();
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idfin",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idfin"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idfin"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idfin"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_ayear : IHashCreator { 
public string[] k   ={"ayear"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["ayear",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("ayear",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["ayear"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString();
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idexpirationkind : IHashCreator { 
public string[] k   ={"idexpirationkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idexpirationkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idexpirationkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idexpirationkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmankind_nman_rownum_yman : IHashCreator { 
public string[] k   ={"idmankind","nman","rownum","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmankind",v].ToString(),r["nman",v].ToString(),r["rownum",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString();
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("rownum",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["rownum"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["rownum"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["rownum"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idcurrency : IHashCreator { 
public string[] k   ={"idcurrency"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcurrency",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcurrency",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcurrency"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmankind_idsor_nman_yman : IHashCreator { 
public string[] k   ={"idmankind","idsor","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmankind",v].ToString(),r["idsor",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmankind",o).ToString(),q.getField("idsor",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmankind"]??"").ToString(),(o["idsor"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmankind"].ToString(),childVal["idsor"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmankind"].ToString(),parentVal["idsor"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idmankind : IHashCreator { 
public string[] k   ={"idmankind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmankind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmankind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmankind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_ninv_rownum_yinv : IHashCreator { 
public string[] k   ={"idinvkind","ninv","rownum","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["rownum",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("rownum",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["rownum"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["rownum"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["rownum"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idreg : IHashCreator { 
public string[] k   ={"idreg"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idreg",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idreg",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idreg"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_nvar : IHashCreator { 
public string[] k   ={"idexp","nvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["nvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="nvar")?proposedValue.ToString():r["nvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("nvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["nvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["nvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["nvar"].ToString());
}
 } 
public class HashCreator_idupb : IHashCreator { 
public string[] k   ={"idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idupb",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idupb",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idupb"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_idsor_idsubclass : IHashCreator { 
public string[] k   ={"idexp","idsor","idsubclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idsor",v].ToString(),r["idsubclass",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="idsubclass")?proposedValue.ToString():r["idsubclass",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idsor",o).ToString(),q.getField("idsubclass",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idsor"]??"").ToString(),(o["idsubclass"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idsor"].ToString(),childVal["idsubclass"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idsor"].ToString(),parentVal["idsubclass"].ToString());
}
 } 
public class HashCreator_idmandatestatus : IHashCreator { 
public string[] k   ={"idmandatestatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmandatestatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmandatestatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmandatestatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idstore : IHashCreator { 
public string[] k   ={"idstore"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idstore",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idstore",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idstore"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idattachment_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"idattachment","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idivakind : IHashCreator { 
public string[] k   ={"idivakind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idivakind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idivakind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idivakind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmaritalstatus : IHashCreator { 
public string[] k   ={"idmaritalstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmaritalstatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmaritalstatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmaritalstatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_idregistryreference : IHashCreator { 
public string[] k   ={"idreg","idregistryreference"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistryreference",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistryreference")?proposedValue.ToString():r["idregistryreference",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistryreference",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistryreference"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistryreference"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistryreference"].ToString());
}
 } 
public class HashCreator_idcategory : IHashCreator { 
public string[] k   ={"idcategory"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcategory",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcategory",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcategory"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idposition : IHashCreator { 
public string[] k   ={"idposition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idposition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idposition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idposition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_idregistrylegalstatus : IHashCreator { 
public string[] k   ={"idreg","idregistrylegalstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrylegalstatus",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrylegalstatus")?proposedValue.ToString():r["idregistrylegalstatus",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrylegalstatus",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrylegalstatus"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrylegalstatus"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrylegalstatus"].ToString());
}
 } 
public class HashCreator_idcentralizedcategory : IHashCreator { 
public string[] k   ={"idcentralizedcategory"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcentralizedcategory",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcentralizedcategory",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcentralizedcategory"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_idsor : IHashCreator { 
public string[] k   ={"idreg","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idregistrykind : IHashCreator { 
public string[] k   ={"idregistrykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idregistrykind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idregistrykind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idregistrykind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idtitle : IHashCreator { 
public string[] k   ={"idtitle"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idtitle",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idtitle",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idtitle"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_idregistrypaymethod : IHashCreator { 
public string[] k   ={"idreg","idregistrypaymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrypaymethod",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrypaymethod")?proposedValue.ToString():r["idregistrypaymethod",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrypaymethod",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrypaymethod"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrypaymethod"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrypaymethod"].ToString());
}
 } 
public class HashCreator_idreg_start : IHashCreator { 
public string[] k   ={"idreg","start"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["start",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="start")?proposedValue.ToString():r["start",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("start",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["start"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["start"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["start"].ToString());
}
 } 
public class HashCreator_idresidence : IHashCreator { 
public string[] k   ={"idresidence"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idresidence",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idresidence",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idresidence"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaddress : IHashCreator { 
public string[] k   ={"idaddress"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaddress",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaddress",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaddress"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idregistryclass : IHashCreator { 
public string[] k   ={"idregistryclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idregistryclass",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idregistryclass",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idregistryclass"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcity : IHashCreator { 
public string[] k   ={"idcity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcity",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcity",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcity"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idagency_idcity_idcode_version : IHashCreator { 
public string[] k   ={"idagency","idcity","idcode","version"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idagency",v].ToString(),r["idcity",v].ToString(),r["idcode",v].ToString(),r["version",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idagency")?proposedValue.ToString():r["idagency",v].ToString();
s += "§"+ ((field=="idcity")?proposedValue.ToString():r["idcity",v].ToString());
s += "§"+ ((field=="idcode")?proposedValue.ToString():r["idcode",v].ToString());
s += "§"+ ((field=="version")?proposedValue.ToString():r["version",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idagency",o).ToString(),q.getField("idcity",o).ToString(),q.getField("idcode",o).ToString(),q.getField("version",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idagency"]??"").ToString(),(o["idcity"]??"").ToString(),(o["idcode"]??"").ToString(),(o["version"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idagency"].ToString(),childVal["idcity"].ToString(),childVal["idcode"].ToString(),childVal["version"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idagency"].ToString(),parentVal["idcity"].ToString(),parentVal["idcode"].ToString(),parentVal["version"].ToString());
}
 } 
public class HashCreator_idaddresskind_idreg_start : IHashCreator { 
public string[] k   ={"idaddresskind","idreg","start"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idaddresskind",v].ToString(),r["idreg",v].ToString(),r["start",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idaddresskind")?proposedValue.ToString():r["idaddresskind",v].ToString();
s += "§"+ ((field=="idreg")?proposedValue.ToString():r["idreg",v].ToString());
s += "§"+ ((field=="start")?proposedValue.ToString():r["start",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idaddresskind",o).ToString(),q.getField("idreg",o).ToString(),q.getField("start",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idaddresskind"]??"").ToString(),(o["idreg"]??"").ToString(),(o["start"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idaddresskind"].ToString(),childVal["idreg"].ToString(),childVal["start"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idaddresskind"].ToString(),parentVal["idreg"].ToString(),parentVal["start"].ToString());
}
 } 
public class HashCreator_idnation : IHashCreator { 
public string[] k   ={"idnation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idnation",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idnation",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idnation"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotivecredit : IHashCreator { 
public string[] k   ={"idaccmotivecredit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotivecredit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotivecredit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotivecredit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotivedebit : IHashCreator { 
public string[] k   ={"idaccmotivedebit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotivedebit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotivedebit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotivedebit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddaliaposition : IHashCreator { 
public string[] k   ={"iddaliaposition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddaliaposition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddaliaposition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddaliaposition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaddresskind : IHashCreator { 
public string[] k   ={"idaddresskind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaddresskind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaddresskind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaddresskind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddurckind : IHashCreator { 
public string[] k   ={"iddurckind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddurckind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddurckind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddurckind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idspecialcategory770 : IHashCreator { 
public string[] k   ={"ayear","idspecialcategory770"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idspecialcategory770",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idspecialcategory770")?proposedValue.ToString():r["idspecialcategory770",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idspecialcategory770",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idspecialcategory770"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idspecialcategory770"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idspecialcategory770"].ToString());
}
 } 
public class HashCreator_idreg_idregistrycf : IHashCreator { 
public string[] k   ={"idreg","idregistrycf"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrycf",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrycf")?proposedValue.ToString():r["idregistrycf",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrycf",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrycf"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrycf"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrycf"].ToString());
}
 } 
public class HashCreator_idreg_idregistrypiva : IHashCreator { 
public string[] k   ={"idreg","idregistrypiva"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrypiva",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrypiva")?proposedValue.ToString():r["idregistrypiva",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrypiva",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrypiva"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrypiva"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrypiva"].ToString());
}
 } 
public class HashCreator_idreg_idregistrydurc : IHashCreator { 
public string[] k   ={"idreg","idregistrydurc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrydurc",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrydurc")?proposedValue.ToString():r["idregistrydurc",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrydurc",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrydurc"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrydurc"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrydurc"].ToString());
}
 } 
public class HashCreator_idreg_idregistrycvattachment : IHashCreator { 
public string[] k   ={"idreg","idregistrycvattachment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistrycvattachment",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistrycvattachment")?proposedValue.ToString():r["idregistrycvattachment",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistrycvattachment",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistrycvattachment"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistrycvattachment"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistrycvattachment"].ToString());
}
 } 
public class HashCreator_idreg_idregistryspecialcategory770 : IHashCreator { 
public string[] k   ={"idreg","idregistryspecialcategory770"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistryspecialcategory770",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistryspecialcategory770")?proposedValue.ToString():r["idregistryspecialcategory770",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistryspecialcategory770",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistryspecialcategory770"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistryspecialcategory770"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistryspecialcategory770"].ToString());
}
 } 
public class HashCreator_idreg_idregistryvisura : IHashCreator { 
public string[] k   ={"idreg","idregistryvisura"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idreg",v].ToString(),r["idregistryvisura",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idreg")?proposedValue.ToString():r["idreg",v].ToString();
s += "§"+ ((field=="idregistryvisura")?proposedValue.ToString():r["idregistryvisura",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idreg",o).ToString(),q.getField("idregistryvisura",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idreg"]??"").ToString(),(o["idregistryvisura"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idreg"].ToString(),childVal["idregistryvisura"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idreg"].ToString(),parentVal["idregistryvisura"].ToString());
}
 } 
public class HashCreator_idregion : IHashCreator { 
public string[] k   ={"idregion"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idregion",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idregion",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idregion"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcountry : IHashCreator { 
public string[] k   ={"idcountry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcountry",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcountry",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcountry"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idbank : IHashCreator { 
public string[] k   ={"idbank"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idbank",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idbank",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idbank"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idbank_idcab : IHashCreator { 
public string[] k   ={"idbank","idcab"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idbank",v].ToString(),r["idcab",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idbank")?proposedValue.ToString():r["idbank",v].ToString();
s += "§"+ ((field=="idcab")?proposedValue.ToString():r["idcab",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idbank",o).ToString(),q.getField("idcab",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idbank"]??"").ToString(),(o["idcab"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idbank"].ToString(),childVal["idcab"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idbank"].ToString(),parentVal["idcab"].ToString());
}
 } 
public class HashCreator_idpaymethod : IHashCreator { 
public string[] k   ={"idpaymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpaymethod",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpaymethod",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpaymethod"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idchargehandling : IHashCreator { 
public string[] k   ={"idchargehandling"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idchargehandling",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idchargehandling",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idchargehandling"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddeputy : IHashCreator { 
public string[] k   ={"iddeputy"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddeputy",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddeputy",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddeputy"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idepexp_nvar : IHashCreator { 
public string[] k   ={"idepexp","nvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idepexp",v].ToString(),r["nvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idepexp")?proposedValue.ToString():r["idepexp",v].ToString();
s += "§"+ ((field=="nvar")?proposedValue.ToString():r["nvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idepexp",o).ToString(),q.getField("nvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idepexp"]??"").ToString(),(o["nvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idepexp"].ToString(),childVal["nvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idepexp"].ToString(),parentVal["nvar"].ToString());
}
 } 
public class HashCreator_idmankind_iduniqueregister_nman_yman : IHashCreator { 
public string[] k   ={"idmankind","iduniqueregister","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmankind",v].ToString(),r["iduniqueregister",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString();
s += "§"+ ((field=="iduniqueregister")?proposedValue.ToString():r["iduniqueregister",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmankind",o).ToString(),q.getField("iduniqueregister",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmankind"]??"").ToString(),(o["iduniqueregister"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmankind"].ToString(),childVal["iduniqueregister"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmankind"].ToString(),parentVal["iduniqueregister"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_cigcode_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"cigcode","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["cigcode",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="cigcode")?proposedValue.ToString():r["cigcode",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("cigcode",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["cigcode"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["cigcode"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["cigcode"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idattachmentkind : IHashCreator { 
public string[] k   ={"idattachmentkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idattachmentkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idattachmentkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idattachmentkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_cigcode_idavcp_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"cigcode","idavcp","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["cigcode",v].ToString(),r["idavcp",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="cigcode")?proposedValue.ToString():r["cigcode",v].ToString();
s += "§"+ ((field=="idavcp")?proposedValue.ToString():r["idavcp",v].ToString());
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("cigcode",o).ToString(),q.getField("idavcp",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["cigcode"]??"").ToString(),(o["idavcp"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["cigcode"].ToString(),childVal["idavcp"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["cigcode"].ToString(),parentVal["idavcp"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idavcp_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"idavcp","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idavcp",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idavcp")?proposedValue.ToString():r["idavcp",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idavcp",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idavcp"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idavcp"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idavcp"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idlist : IHashCreator { 
public string[] k   ={"idlist"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idlist",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idlist",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idlist"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinv : IHashCreator { 
public string[] k   ={"idinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinv",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinv",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinv"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idconsipcategory : IHashCreator { 
public string[] k   ={"idconsipcategory"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idconsipcategory",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idconsipcategory",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idconsipcategory"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idepexp_rownum : IHashCreator { 
public string[] k   ={"idepexp","rownum"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idepexp",v].ToString(),r["rownum",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idepexp")?proposedValue.ToString():r["idepexp",v].ToString();
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idepexp",o).ToString(),q.getField("rownum",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idepexp"]??"").ToString(),(o["rownum"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idepexp"].ToString(),childVal["rownum"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idepexp"].ToString(),parentVal["rownum"].ToString());
}
 } 
public class HashCreator_idconsipkind : IHashCreator { 
public string[] k   ={"idconsipkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idconsipkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idconsipkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idconsipkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp : IHashCreator { 
public string[] k   ={"idexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idexp",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idexp",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idexp"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idclawback : IHashCreator { 
public string[] k   ={"idclawback"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idclawback",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idclawback",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idclawback"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idclawback_idexp : IHashCreator { 
public string[] k   ={"idclawback","idexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idclawback",v].ToString(),r["idexp",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idclawback")?proposedValue.ToString():r["idclawback",v].ToString();
s += "§"+ ((field=="idexp")?proposedValue.ToString():r["idexp",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idclawback",o).ToString(),q.getField("idexp",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idclawback"]??"").ToString(),(o["idexp"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idclawback"].ToString(),childVal["idexp"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idclawback"].ToString(),parentVal["idexp"].ToString());
}
 } 
public class HashCreator_ayear_idexp : IHashCreator { 
public string[] k   ={"ayear","idexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idexp",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idexp")?proposedValue.ToString():r["idexp",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idexp",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idexp"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idexp"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idexp"].ToString());
}
 } 
public class HashCreator_nphase : IHashCreator { 
public string[] k   ={"nphase"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["nphase",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("nphase",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["nphase"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_nbracket_taxcode : IHashCreator { 
public string[] k   ={"idexp","nbracket","taxcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["nbracket",v].ToString(),r["taxcode",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="nbracket")?proposedValue.ToString():r["nbracket",v].ToString());
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("nbracket",o).ToString(),q.getField("taxcode",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["nbracket"]??"").ToString(),(o["taxcode"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["nbracket"].ToString(),childVal["taxcode"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["nbracket"].ToString(),parentVal["taxcode"].ToString());
}
 } 
public class HashCreator_taxcode : IHashCreator { 
public string[] k   ={"taxcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["taxcode",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("taxcode",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["taxcode"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"idexp","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idexp_iditineration : IHashCreator { 
public string[] k   ={"idexp","iditineration"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["iditineration",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("iditineration",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["iditineration"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["iditineration"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["iditineration"].ToString());
}
 } 
public class HashCreator_idestimkind_nestim_yestim : IHashCreator { 
public string[] k   ={"idestimkind","nestim","yestim"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idestimkind",v].ToString(),r["nestim",v].ToString(),r["yestim",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idestimkind")?proposedValue.ToString():r["idestimkind",v].ToString();
s += "§"+ ((field=="nestim")?proposedValue.ToString():r["nestim",v].ToString());
s += "§"+ ((field=="yestim")?proposedValue.ToString():r["yestim",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idestimkind",o).ToString(),q.getField("nestim",o).ToString(),q.getField("yestim",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idestimkind"]??"").ToString(),(o["nestim"]??"").ToString(),(o["yestim"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idestimkind"].ToString(),childVal["nestim"].ToString(),childVal["yestim"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idestimkind"].ToString(),parentVal["nestim"].ToString(),parentVal["yestim"].ToString());
}
 } 
public class HashCreator_idunderwriting : IHashCreator { 
public string[] k   ={"idunderwriting"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idunderwriting",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idunderwriting",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idunderwriting"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_idsor_idsubclass : IHashCreator { 
public string[] k   ={"idinc","idsor","idsubclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["idsor",v].ToString(),r["idsubclass",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="idsubclass")?proposedValue.ToString():r["idsubclass",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("idsor",o).ToString(),q.getField("idsubclass",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["idsor"]??"").ToString(),(o["idsubclass"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["idsor"].ToString(),childVal["idsubclass"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["idsor"].ToString(),parentVal["idsubclass"].ToString());
}
 } 
public class HashCreator_idestimkind_nestim_rownum_yestim : IHashCreator { 
public string[] k   ={"idestimkind","nestim","rownum","yestim"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idestimkind",v].ToString(),r["nestim",v].ToString(),r["rownum",v].ToString(),r["yestim",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idestimkind")?proposedValue.ToString():r["idestimkind",v].ToString();
s += "§"+ ((field=="nestim")?proposedValue.ToString():r["nestim",v].ToString());
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
s += "§"+ ((field=="yestim")?proposedValue.ToString():r["yestim",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idestimkind",o).ToString(),q.getField("nestim",o).ToString(),q.getField("rownum",o).ToString(),q.getField("yestim",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idestimkind"]??"").ToString(),(o["nestim"]??"").ToString(),(o["rownum"]??"").ToString(),(o["yestim"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idestimkind"].ToString(),childVal["nestim"].ToString(),childVal["rownum"].ToString(),childVal["yestim"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idestimkind"].ToString(),parentVal["nestim"].ToString(),parentVal["rownum"].ToString(),parentVal["yestim"].ToString());
}
 } 
public class HashCreator_idestimkind : IHashCreator { 
public string[] k   ={"idestimkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idestimkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idestimkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idestimkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idattachment_idestimkind_nestim_yestim : IHashCreator { 
public string[] k   ={"idattachment","idestimkind","nestim","yestim"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["idestimkind",v].ToString(),r["nestim",v].ToString(),r["yestim",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="idestimkind")?proposedValue.ToString():r["idestimkind",v].ToString());
s += "§"+ ((field=="nestim")?proposedValue.ToString():r["nestim",v].ToString());
s += "§"+ ((field=="yestim")?proposedValue.ToString():r["yestim",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("idestimkind",o).ToString(),q.getField("nestim",o).ToString(),q.getField("yestim",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["idestimkind"]??"").ToString(),(o["nestim"]??"").ToString(),(o["yestim"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["idestimkind"].ToString(),childVal["nestim"].ToString(),childVal["yestim"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["idestimkind"].ToString(),parentVal["nestim"].ToString(),parentVal["yestim"].ToString());
}
 } 
public class HashCreator_idinc_nvar : IHashCreator { 
public string[] k   ={"idinc","nvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["nvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="nvar")?proposedValue.ToString():r["nvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("nvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["nvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["nvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["nvar"].ToString());
}
 } 
public class HashCreator_idestimkind_idsor_nestim_yestim : IHashCreator { 
public string[] k   ={"idestimkind","idsor","nestim","yestim"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idestimkind",v].ToString(),r["idsor",v].ToString(),r["nestim",v].ToString(),r["yestim",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idestimkind")?proposedValue.ToString():r["idestimkind",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="nestim")?proposedValue.ToString():r["nestim",v].ToString());
s += "§"+ ((field=="yestim")?proposedValue.ToString():r["yestim",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idestimkind",o).ToString(),q.getField("idsor",o).ToString(),q.getField("nestim",o).ToString(),q.getField("yestim",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idestimkind"]??"").ToString(),(o["idsor"]??"").ToString(),(o["nestim"]??"").ToString(),(o["yestim"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idestimkind"].ToString(),childVal["idsor"].ToString(),childVal["nestim"].ToString(),childVal["yestim"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idestimkind"].ToString(),parentVal["idsor"].ToString(),parentVal["nestim"].ToString(),parentVal["yestim"].ToString());
}
 } 
public class HashCreator_idinvkind_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idivaregisterkind : IHashCreator { 
public string[] k   ={"idivaregisterkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idivaregisterkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idivaregisterkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idivaregisterkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idivaregisterkind_nivaregister_yivaregister : IHashCreator { 
public string[] k   ={"idivaregisterkind","nivaregister","yivaregister"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idivaregisterkind",v].ToString(),r["nivaregister",v].ToString(),r["yivaregister",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idivaregisterkind")?proposedValue.ToString():r["idivaregisterkind",v].ToString();
s += "§"+ ((field=="nivaregister")?proposedValue.ToString():r["nivaregister",v].ToString());
s += "§"+ ((field=="yivaregister")?proposedValue.ToString():r["yivaregister",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idivaregisterkind",o).ToString(),q.getField("nivaregister",o).ToString(),q.getField("yivaregister",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idivaregisterkind"]??"").ToString(),(o["nivaregister"]??"").ToString(),(o["yivaregister"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idivaregisterkind"].ToString(),childVal["nivaregister"].ToString(),childVal["yivaregister"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idivaregisterkind"].ToString(),parentVal["nivaregister"].ToString(),parentVal["yivaregister"].ToString());
}
 } 
public class HashCreator_idaccountkind : IHashCreator { 
public string[] k   ={"idaccountkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccountkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccountkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccountkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_idsor_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","idsor","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["idsor",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("idsor",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["idsor"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["idsor"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["idsor"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_ayear_idinvkind : IHashCreator { 
public string[] k   ={"ayear","idinvkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idinvkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idinvkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idinvkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idinvkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idinvkind"].ToString());
}
 } 
public class HashCreator_idinvkind : IHashCreator { 
public string[] k   ={"idinvkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinvkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinvkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinvkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_ninv_nivapay_yinv_yivapay : IHashCreator { 
public string[] k   ={"idinvkind","ninv","nivapay","yinv","yivapay"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["nivapay",v].ToString(),r["yinv",v].ToString(),r["yivapay",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="nivapay")?proposedValue.ToString():r["nivapay",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
s += "§"+ ((field=="yivapay")?proposedValue.ToString():r["yivapay",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("nivapay",o).ToString(),q.getField("yinv",o).ToString(),q.getField("yivapay",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["nivapay"]??"").ToString(),(o["yinv"]??"").ToString(),(o["yivapay"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["nivapay"].ToString(),childVal["yinv"].ToString(),childVal["yivapay"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["nivapay"].ToString(),parentVal["yinv"].ToString(),parentVal["yivapay"].ToString());
}
 } 
public class HashCreator_idtreasurer : IHashCreator { 
public string[] k   ={"idtreasurer"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idtreasurer",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idtreasurer",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idtreasurer"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_idivaregisterkind : IHashCreator { 
public string[] k   ={"idinvkind","idivaregisterkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["idivaregisterkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="idivaregisterkind")?proposedValue.ToString():r["idivaregisterkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("idivaregisterkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["idivaregisterkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["idivaregisterkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["idivaregisterkind"].ToString());
}
 } 
public class HashCreator_idpcc : IHashCreator { 
public string[] k   ={"idpcc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpcc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpcc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpcc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfepaymethod : IHashCreator { 
public string[] k   ={"idfepaymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfepaymethod",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfepaymethod",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfepaymethod"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_iduniqueregister_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","iduniqueregister","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["iduniqueregister",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="iduniqueregister")?proposedValue.ToString():r["iduniqueregister",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("iduniqueregister",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["iduniqueregister"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["iduniqueregister"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["iduniqueregister"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idattachment_idinvkind_ninv_yinv : IHashCreator { 
public string[] k   ={"idattachment","idinvkind","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idsdi_acquisto : IHashCreator { 
public string[] k   ={"idsdi_acquisto"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsdi_acquisto",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsdi_acquisto",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsdi_acquisto"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatnation : IHashCreator { 
public string[] k   ={"idintrastatnation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatnation",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatnation",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatnation"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsdi_status : IHashCreator { 
public string[] k   ={"idsdi_status"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsdi_status",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsdi_status",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsdi_status"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ncon_ycon : IHashCreator { 
public string[] k   ={"ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ncon")?proposedValue.ToString():r["ncon",v].ToString();
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_idstock : IHashCreator { 
public string[] k   ={"idstock"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idstock",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idstock",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idstock"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idblacklist : IHashCreator { 
public string[] k   ={"idblacklist"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idblacklist",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idblacklist",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idblacklist"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfepaymethodcondition : IHashCreator { 
public string[] k   ={"idfepaymethodcondition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfepaymethodcondition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfepaymethodcondition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfepaymethodcondition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatkind : IHashCreator { 
public string[] k   ={"idintrastatkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatpaymethod : IHashCreator { 
public string[] k   ={"idintrastatpaymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatpaymethod",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatpaymethod",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatpaymethod"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsdi_vendita : IHashCreator { 
public string[] k   ={"idsdi_vendita"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsdi_vendita",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsdi_vendita",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsdi_vendita"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsdi_deliverystatus : IHashCreator { 
public string[] k   ={"idsdi_deliverystatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsdi_deliverystatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsdi_deliverystatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsdi_deliverystatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ipa_fe : IHashCreator { 
public string[] k   ={"ipa_fe"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["ipa_fe",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("ipa_fe",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["ipa_fe"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsdi_rifamm : IHashCreator { 
public string[] k   ={"idsdi_rifamm"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsdi_rifamm",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsdi_rifamm",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsdi_rifamm"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nassetacquire : IHashCreator { 
public string[] k   ={"nassetacquire"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["nassetacquire",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("nassetacquire",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["nassetacquire"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idnocigmotive : IHashCreator { 
public string[] k   ={"idnocigmotive"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idnocigmotive",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idnocigmotive",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idnocigmotive"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idser : IHashCreator { 
public string[] k   ={"idser"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idser",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idser",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idser"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iditineration : IHashCreator { 
public string[] k   ={"iditineration"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iditineration",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iditineration",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iditineration"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iditineration_nrefund : IHashCreator { 
public string[] k   ={"iditineration","nrefund"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iditineration",v].ToString(),r["nrefund",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString();
s += "§"+ ((field=="nrefund")?proposedValue.ToString():r["nrefund",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iditineration",o).ToString(),q.getField("nrefund",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iditineration"]??"").ToString(),(o["nrefund"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iditineration"].ToString(),childVal["nrefund"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iditineration"].ToString(),parentVal["nrefund"].ToString());
}
 } 
public class HashCreator_iditineration_lapnumber : IHashCreator { 
public string[] k   ={"iditineration","lapnumber"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iditineration",v].ToString(),r["lapnumber",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString();
s += "§"+ ((field=="lapnumber")?proposedValue.ToString():r["lapnumber",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iditineration",o).ToString(),q.getField("lapnumber",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iditineration"]??"").ToString(),(o["lapnumber"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iditineration"].ToString(),childVal["lapnumber"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iditineration"].ToString(),parentVal["lapnumber"].ToString());
}
 } 
public class HashCreator_iditineration_taxcode : IHashCreator { 
public string[] k   ={"iditineration","taxcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iditineration",v].ToString(),r["taxcode",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString();
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iditineration",o).ToString(),q.getField("taxcode",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iditineration"]??"").ToString(),(o["taxcode"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iditineration"].ToString(),childVal["taxcode"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iditineration"].ToString(),parentVal["taxcode"].ToString());
}
 } 
public class HashCreator_start : IHashCreator { 
public string[] k   ={"start"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["start",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("start",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["start"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iditinerationrefundkind : IHashCreator { 
public string[] k   ={"iditinerationrefundkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iditinerationrefundkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iditinerationrefundkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iditinerationrefundkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_groupnumber_idreduction_start : IHashCreator { 
public string[] k   ={"groupnumber","idreduction","start"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["groupnumber",v].ToString(),r["idreduction",v].ToString(),r["start",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="groupnumber")?proposedValue.ToString():r["groupnumber",v].ToString();
s += "§"+ ((field=="idreduction")?proposedValue.ToString():r["idreduction",v].ToString());
s += "§"+ ((field=="start")?proposedValue.ToString():r["start",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("groupnumber",o).ToString(),q.getField("idreduction",o).ToString(),q.getField("start",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["groupnumber"]??"").ToString(),(o["idreduction"]??"").ToString(),(o["start"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["groupnumber"].ToString(),childVal["idreduction"].ToString(),childVal["start"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["groupnumber"].ToString(),parentVal["idreduction"].ToString(),parentVal["start"].ToString());
}
 } 
public class HashCreator_iditineration_idsor : IHashCreator { 
public string[] k   ={"iditineration","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iditineration",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iditineration",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iditineration"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iditineration"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iditineration"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idforeigncountry : IHashCreator { 
public string[] k   ={"idforeigncountry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idforeigncountry",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idforeigncountry",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idforeigncountry"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idflights_iditineration : IHashCreator { 
public string[] k   ={"idflights","iditineration"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idflights",v].ToString(),r["iditineration",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idflights")?proposedValue.ToString():r["idflights",v].ToString();
s += "§"+ ((field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idflights",o).ToString(),q.getField("iditineration",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idflights"]??"").ToString(),(o["iditineration"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idflights"].ToString(),childVal["iditineration"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idflights"].ToString(),parentVal["iditineration"].ToString());
}
 } 
public class HashCreator_idauthagency_iditineration : IHashCreator { 
public string[] k   ={"idauthagency","iditineration"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idauthagency",v].ToString(),r["iditineration",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idauthagency")?proposedValue.ToString():r["idauthagency",v].ToString();
s += "§"+ ((field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idauthagency",o).ToString(),q.getField("iditineration",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idauthagency"]??"").ToString(),(o["iditineration"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idauthagency"].ToString(),childVal["iditineration"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idauthagency"].ToString(),parentVal["iditineration"].ToString());
}
 } 
public class HashCreator_idattachment_iditineration : IHashCreator { 
public string[] k   ={"idattachment","iditineration"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["iditineration",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("iditineration",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["iditineration"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["iditineration"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["iditineration"].ToString());
}
 } 
public class HashCreator_iddalia_dipartimento : IHashCreator { 
public string[] k   ={"iddalia_dipartimento"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddalia_dipartimento",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddalia_dipartimento",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddalia_dipartimento"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddalia_funzionale : IHashCreator { 
public string[] k   ={"iddalia_funzionale"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddalia_funzionale",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddalia_funzionale",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddalia_funzionale"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idauthagency : IHashCreator { 
public string[] k   ={"idauthagency"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idauthagency",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idauthagency",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idauthagency"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddaliarecruitmentmotive : IHashCreator { 
public string[] k   ={"iddaliarecruitmentmotive"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddaliarecruitmentmotive",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddaliarecruitmentmotive",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddaliarecruitmentmotive"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iditinerationstatus : IHashCreator { 
public string[] k   ={"iditinerationstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iditinerationstatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iditinerationstatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iditinerationstatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idauthmodel : IHashCreator { 
public string[] k   ={"idauthmodel"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idauthmodel",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idauthmodel",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idauthmodel"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_kpaymenttransmission : IHashCreator { 
public string[] k   ={"kpaymenttransmission"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["kpaymenttransmission",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("kpaymenttransmission",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["kpaymenttransmission"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_kpay : IHashCreator { 
public string[] k   ={"kpay"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["kpay",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("kpay",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["kpay"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpettycash : IHashCreator { 
public string[] k   ={"idpettycash"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpettycash",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpettycash",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpettycash"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpettycash_ncon_noperation_ycon_yoperation : IHashCreator { 
public string[] k   ={"idpettycash","ncon","noperation","ycon","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpettycash",v].ToString(),r["ncon",v].ToString(),r["noperation",v].ToString(),r["ycon",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpettycash",o).ToString(),q.getField("ncon",o).ToString(),q.getField("noperation",o).ToString(),q.getField("ycon",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpettycash"]??"").ToString(),(o["ncon"]??"").ToString(),(o["noperation"]??"").ToString(),(o["ycon"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpettycash"].ToString(),childVal["ncon"].ToString(),childVal["noperation"].ToString(),childVal["ycon"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpettycash"].ToString(),parentVal["ncon"].ToString(),parentVal["noperation"].ToString(),parentVal["ycon"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_idpettycash_idunderwriting_noperation_yoperation : IHashCreator { 
public string[] k   ={"idpettycash","idunderwriting","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpettycash",v].ToString(),r["idunderwriting",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString();
s += "§"+ ((field=="idunderwriting")?proposedValue.ToString():r["idunderwriting",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpettycash",o).ToString(),q.getField("idunderwriting",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpettycash"]??"").ToString(),(o["idunderwriting"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpettycash"].ToString(),childVal["idunderwriting"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpettycash"].ToString(),parentVal["idunderwriting"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_ayear_idpettycash : IHashCreator { 
public string[] k   ={"ayear","idpettycash"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idpettycash",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idpettycash",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idpettycash"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idpettycash"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idpettycash"].ToString());
}
 } 
public class HashCreator_ayear_idclawback : IHashCreator { 
public string[] k   ={"ayear","idclawback"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idclawback",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idclawback")?proposedValue.ToString():r["idclawback",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idclawback",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idclawback"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idclawback"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idclawback"].ToString());
}
 } 
public class HashCreator_idpettycash_noperation_yoperation : IHashCreator { 
public string[] k   ={"idpettycash","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpettycash",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString();
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpettycash",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpettycash"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpettycash"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpettycash"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_idpettycash_idsor_idsubclass_noperation_yoperation : IHashCreator { 
public string[] k   ={"idpettycash","idsor","idsubclass","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpettycash",v].ToString(),r["idsor",v].ToString(),r["idsubclass",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
s += "§"+ ((field=="idsubclass")?proposedValue.ToString():r["idsubclass",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpettycash",o).ToString(),q.getField("idsor",o).ToString(),q.getField("idsubclass",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpettycash"]??"").ToString(),(o["idsor"]??"").ToString(),(o["idsubclass"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpettycash"].ToString(),childVal["idsor"].ToString(),childVal["idsubclass"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpettycash"].ToString(),parentVal["idsor"].ToString(),parentVal["idsubclass"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_billkind_nbill_ybill : IHashCreator { 
public string[] k   ={"billkind","nbill","ybill"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["billkind",v].ToString(),r["nbill",v].ToString(),r["ybill",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="billkind")?proposedValue.ToString():r["billkind",v].ToString();
s += "§"+ ((field=="nbill")?proposedValue.ToString():r["nbill",v].ToString());
s += "§"+ ((field=="ybill")?proposedValue.ToString():r["ybill",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("billkind",o).ToString(),q.getField("nbill",o).ToString(),q.getField("ybill",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["billkind"]??"").ToString(),(o["nbill"]??"").ToString(),(o["ybill"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["billkind"].ToString(),childVal["nbill"].ToString(),childVal["ybill"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["billkind"].ToString(),parentVal["nbill"].ToString(),parentVal["ybill"].ToString());
}
 } 
public class HashCreator_iditineration_idpettycash_noperation_yoperation : IHashCreator { 
public string[] k   ={"iditineration","idpettycash","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iditineration",v].ToString(),r["idpettycash",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iditineration")?proposedValue.ToString():r["iditineration",v].ToString();
s += "§"+ ((field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iditineration",o).ToString(),q.getField("idpettycash",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iditineration"]??"").ToString(),(o["idpettycash"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iditineration"].ToString(),childVal["idpettycash"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iditineration"].ToString(),parentVal["idpettycash"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_idinvkind_idpettycash_ninv_noperation_yinv_yoperation : IHashCreator { 
public string[] k   ={"idinvkind","idpettycash","ninv","noperation","yinv","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["idpettycash",v].ToString(),r["ninv",v].ToString(),r["noperation",v].ToString(),r["yinv",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("idpettycash",o).ToString(),q.getField("ninv",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yinv",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["idpettycash"]??"").ToString(),(o["ninv"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yinv"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["idpettycash"].ToString(),childVal["ninv"].ToString(),childVal["noperation"].ToString(),childVal["yinv"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["idpettycash"].ToString(),parentVal["ninv"].ToString(),parentVal["noperation"].ToString(),parentVal["yinv"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_idtipo : IHashCreator { 
public string[] k   ={"idtipo"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idtipo",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idtipo",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idtipo"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_idpettycash_noperation_yoperation : IHashCreator { 
public string[] k   ={"idinc","idpettycash","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["idpettycash",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("idpettycash",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["idpettycash"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["idpettycash"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["idpettycash"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_idexp_idpettycash_noperation_yoperation : IHashCreator { 
public string[] k   ={"idexp","idpettycash","noperation","yoperation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idpettycash",v].ToString(),r["noperation",v].ToString(),r["yoperation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idpettycash")?proposedValue.ToString():r["idpettycash",v].ToString());
s += "§"+ ((field=="noperation")?proposedValue.ToString():r["noperation",v].ToString());
s += "§"+ ((field=="yoperation")?proposedValue.ToString():r["yoperation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idpettycash",o).ToString(),q.getField("noperation",o).ToString(),q.getField("yoperation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idpettycash"]??"").ToString(),(o["noperation"]??"").ToString(),(o["yoperation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idpettycash"].ToString(),childVal["noperation"].ToString(),childVal["yoperation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idpettycash"].ToString(),parentVal["noperation"].ToString(),parentVal["yoperation"].ToString());
}
 } 
public class HashCreator_kproceedstransmission : IHashCreator { 
public string[] k   ={"kproceedstransmission"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["kproceedstransmission",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("kproceedstransmission",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["kproceedstransmission"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_kpro : IHashCreator { 
public string[] k   ={"kpro"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["kpro",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("kpro",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["kpro"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idposition : IHashCreator { 
public string[] k   ={"ayear","idposition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idposition",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idposition")?proposedValue.ToString():r["idposition",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idposition",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idposition"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idposition"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idposition"].ToString());
}
 } 
public class HashCreator_ayear_ncon_ycon : IHashCreator { 
public string[] k   ={"ayear","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_idsor_ncon_ycon : IHashCreator { 
public string[] k   ={"idsor","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idsor",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idsor")?proposedValue.ToString():r["idsor",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idsor",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idsor"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idsor"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idsor"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_ayear_idcontractlength : IHashCreator { 
public string[] k   ={"ayear","idcontractlength"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcontractlength",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcontractlength")?proposedValue.ToString():r["idcontractlength",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcontractlength",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcontractlength"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcontractlength"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcontractlength"].ToString());
}
 } 
public class HashCreator_ncon_taxcode_ycon : IHashCreator { 
public string[] k   ={"ncon","taxcode","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ncon",v].ToString(),r["taxcode",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ncon")?proposedValue.ToString():r["ncon",v].ToString();
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ncon",o).ToString(),q.getField("taxcode",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ncon"]??"").ToString(),(o["taxcode"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ncon"].ToString(),childVal["taxcode"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ncon"].ToString(),parentVal["taxcode"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_ayear_idworkingtime : IHashCreator { 
public string[] k   ={"ayear","idworkingtime"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idworkingtime",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idworkingtime")?proposedValue.ToString():r["idworkingtime",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idworkingtime",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idworkingtime"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idworkingtime"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idworkingtime"].ToString());
}
 } 
public class HashCreator_idexp_idinvkind_ninv_yinv : IHashCreator { 
public string[] k   ={"idexp","idinvkind","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idexp_idunderwriting : IHashCreator { 
public string[] k   ={"idexp","idunderwriting"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idunderwriting",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idunderwriting")?proposedValue.ToString():r["idunderwriting",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idunderwriting",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idunderwriting"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idunderwriting"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idunderwriting"].ToString());
}
 } 
public class HashCreator_idexp_ncon_ycon : IHashCreator { 
public string[] k   ={"idexp","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_idpayroll_idpayrolltax : IHashCreator { 
public string[] k   ={"idpayroll","idpayrolltax"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpayroll",v].ToString(),r["idpayrolltax",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString();
s += "§"+ ((field=="idpayrolltax")?proposedValue.ToString():r["idpayrolltax",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpayroll",o).ToString(),q.getField("idpayrolltax",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpayroll"]??"").ToString(),(o["idpayrolltax"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpayroll"].ToString(),childVal["idpayrolltax"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpayroll"].ToString(),parentVal["idpayrolltax"].ToString());
}
 } 
public class HashCreator_idexp_nbill_ybill : IHashCreator { 
public string[] k   ={"idexp","nbill","ybill"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["nbill",v].ToString(),r["ybill",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="nbill")?proposedValue.ToString():r["nbill",v].ToString());
s += "§"+ ((field=="ybill")?proposedValue.ToString():r["ybill",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("nbill",o).ToString(),q.getField("ybill",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["nbill"]??"").ToString(),(o["ybill"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["nbill"].ToString(),childVal["ybill"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["nbill"].ToString(),parentVal["ybill"].ToString());
}
 } 
public class HashCreator_idexp_idpayroll : IHashCreator { 
public string[] k   ={"idexp","idpayroll"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idpayroll",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idpayroll",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idpayroll"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idpayroll"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idpayroll"].ToString());
}
 } 
public class HashCreator_idexp_idexpensetaxcorrige : IHashCreator { 
public string[] k   ={"idexp","idexpensetaxcorrige"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idexpensetaxcorrige",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idexpensetaxcorrige")?proposedValue.ToString():r["idexpensetaxcorrige",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idexpensetaxcorrige",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idexpensetaxcorrige"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idexpensetaxcorrige"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idexpensetaxcorrige"].ToString());
}
 } 
public class HashCreator_idfiscaltaxregion : IHashCreator { 
public string[] k   ={"idfiscaltaxregion"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfiscaltaxregion",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfiscaltaxregion",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfiscaltaxregion"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_idexpensetaxofficial : IHashCreator { 
public string[] k   ={"idexp","idexpensetaxofficial"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idexp",v].ToString(),r["idexpensetaxofficial",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idexp")?proposedValue.ToString():r["idexp",v].ToString();
s += "§"+ ((field=="idexpensetaxofficial")?proposedValue.ToString():r["idexpensetaxofficial",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idexp",o).ToString(),q.getField("idexpensetaxofficial",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idexp"]??"").ToString(),(o["idexpensetaxofficial"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idexp"].ToString(),childVal["idexpensetaxofficial"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idexp"].ToString(),parentVal["idexpensetaxofficial"].ToString());
}
 } 
public class HashCreator_idpayroll : IHashCreator { 
public string[] k   ={"idpayroll"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpayroll",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpayroll",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpayroll"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc : IHashCreator { 
public string[] k   ={"idinc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_tiporiga : IHashCreator { 
public string[] k   ={"tiporiga"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["tiporiga",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("tiporiga",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["tiporiga"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_code : IHashCreator { 
public string[] k   ={"code"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["code",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("code",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["code"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_rifa_month : IHashCreator { 
public string[] k   ={"rifa_month"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["rifa_month",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("rifa_month",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["rifa_month"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_rifb_month : IHashCreator { 
public string[] k   ={"rifb_month"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["rifb_month",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("rifb_month",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["rifb_month"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idformerexpense : IHashCreator { 
public string[] k   ={"idformerexpense"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idformerexpense",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idformerexpense",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idformerexpense"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetload : IHashCreator { 
public string[] k   ={"idassetload"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetload",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetload",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetload"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idasset : IHashCreator { 
public string[] k   ={"idasset"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idasset",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idasset",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idasset"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetusagekind_nassetacquire : IHashCreator { 
public string[] k   ={"idassetusagekind","nassetacquire"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idassetusagekind",v].ToString(),r["nassetacquire",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idassetusagekind")?proposedValue.ToString():r["idassetusagekind",v].ToString();
s += "§"+ ((field=="nassetacquire")?proposedValue.ToString():r["nassetacquire",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idassetusagekind",o).ToString(),q.getField("nassetacquire",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idassetusagekind"]??"").ToString(),(o["nassetacquire"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idassetusagekind"].ToString(),childVal["nassetacquire"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idassetusagekind"].ToString(),parentVal["nassetacquire"].ToString());
}
 } 
public class HashCreator_idassetusagekind : IHashCreator { 
public string[] k   ={"idassetusagekind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetusagekind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetusagekind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetusagekind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idasset_idassetmanager : IHashCreator { 
public string[] k   ={"idasset","idassetmanager"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["idassetmanager",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="idassetmanager")?proposedValue.ToString():r["idassetmanager",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("idassetmanager",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["idassetmanager"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["idassetmanager"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["idassetmanager"].ToString());
}
 } 
public class HashCreator_idinv_idmultifieldkind : IHashCreator { 
public string[] k   ={"idinv","idmultifieldkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinv",v].ToString(),r["idmultifieldkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinv")?proposedValue.ToString():r["idinv",v].ToString();
s += "§"+ ((field=="idmultifieldkind")?proposedValue.ToString():r["idmultifieldkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinv",o).ToString(),q.getField("idmultifieldkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinv"]??"").ToString(),(o["idmultifieldkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinv"].ToString(),childVal["idmultifieldkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinv"].ToString(),parentVal["idmultifieldkind"].ToString());
}
 } 
public class HashCreator_idassetloadkind : IHashCreator { 
public string[] k   ={"idassetloadkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetloadkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetloadkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetloadkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idasset_idassetlocation : IHashCreator { 
public string[] k   ={"idasset","idassetlocation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["idassetlocation",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="idassetlocation")?proposedValue.ToString():r["idassetlocation",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("idassetlocation",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["idassetlocation"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["idassetlocation"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["idassetlocation"].ToString());
}
 } 
public class HashCreator_idasset_idassetsubmanager : IHashCreator { 
public string[] k   ={"idasset","idassetsubmanager"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["idassetsubmanager",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="idassetsubmanager")?proposedValue.ToString():r["idassetsubmanager",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("idassetsubmanager",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["idassetsubmanager"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["idassetsubmanager"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["idassetsubmanager"].ToString());
}
 } 
public class HashCreator_idasset_idpiece : IHashCreator { 
public string[] k   ={"idasset","idpiece"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["idpiece",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="idpiece")?proposedValue.ToString():r["idpiece",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("idpiece",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["idpiece"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["idpiece"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["idpiece"].ToString());
}
 } 
public class HashCreator_idlocation : IHashCreator { 
public string[] k   ={"idlocation"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idlocation",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idlocation",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idlocation"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmot : IHashCreator { 
public string[] k   ={"idmot"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmot",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmot",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmot"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmultifieldkind : IHashCreator { 
public string[] k   ={"idmultifieldkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmultifieldkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmultifieldkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmultifieldkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinventory : IHashCreator { 
public string[] k   ={"idinventory"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinventory",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinventory",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinventory"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor2 : IHashCreator { 
public string[] k   ={"idsor2"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor2",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor2",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor2"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor1 : IHashCreator { 
public string[] k   ={"idsor1"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor1",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor1",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor1"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor3 : IHashCreator { 
public string[] k   ={"idsor3"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor3",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor3",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor3"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetunload : IHashCreator { 
public string[] k   ={"idassetunload"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetunload",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetunload",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetunload"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetunload_idinc : IHashCreator { 
public string[] k   ={"idassetunload","idinc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idassetunload",v].ToString(),r["idinc",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idassetunload")?proposedValue.ToString():r["idassetunload",v].ToString();
s += "§"+ ((field=="idinc")?proposedValue.ToString():r["idinc",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idassetunload",o).ToString(),q.getField("idinc",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idassetunload"]??"").ToString(),(o["idinc"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idassetunload"].ToString(),childVal["idinc"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idassetunload"].ToString(),parentVal["idinc"].ToString());
}
 } 
public class HashCreator_idassetunloadkind : IHashCreator { 
public string[] k   ={"idassetunloadkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetunloadkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetunloadkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetunloadkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_namortization : IHashCreator { 
public string[] k   ={"namortization"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["namortization",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("namortization",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["namortization"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetload_idexp : IHashCreator { 
public string[] k   ={"idassetload","idexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idassetload",v].ToString(),r["idexp",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idassetload")?proposedValue.ToString():r["idassetload",v].ToString();
s += "§"+ ((field=="idexp")?proposedValue.ToString():r["idexp",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idassetload",o).ToString(),q.getField("idexp",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idassetload"]??"").ToString(),(o["idexp"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idassetload"].ToString(),childVal["idexp"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idassetload"].ToString(),parentVal["idexp"].ToString());
}
 } 
public class HashCreator_idenactment : IHashCreator { 
public string[] k   ={"idenactment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idenactment",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idenactment",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idenactment"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nvar_yvar : IHashCreator { 
public string[] k   ={"nvar","yvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nvar",v].ToString(),r["yvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nvar")?proposedValue.ToString():r["nvar",v].ToString();
s += "§"+ ((field=="yvar")?proposedValue.ToString():r["yvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nvar",o).ToString(),q.getField("yvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nvar"]??"").ToString(),(o["yvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nvar"].ToString(),childVal["yvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nvar"].ToString(),parentVal["yvar"].ToString());
}
 } 
public class HashCreator_idsor04 : IHashCreator { 
public string[] k   ={"idsor04"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor04",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor04",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor04"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor05 : IHashCreator { 
public string[] k   ={"idsor05"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor05",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor05",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor05"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor02 : IHashCreator { 
public string[] k   ={"idsor02"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor02",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor02",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor02"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor03 : IHashCreator { 
public string[] k   ={"idsor03"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor03",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor03",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor03"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor01 : IHashCreator { 
public string[] k   ={"idsor01"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor01",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor01",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor01"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idepacc : IHashCreator { 
public string[] k   ={"idepacc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idepacc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idepacc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idepacc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idepacc_rownum : IHashCreator { 
public string[] k   ={"idepacc","rownum"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idepacc",v].ToString(),r["rownum",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idepacc")?proposedValue.ToString():r["idepacc",v].ToString();
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idepacc",o).ToString(),q.getField("rownum",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idepacc"]??"").ToString(),(o["rownum"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idepacc"].ToString(),childVal["rownum"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idepacc"].ToString(),parentVal["rownum"].ToString());
}
 } 
public class HashCreator_ayear_idepacc : IHashCreator { 
public string[] k   ={"ayear","idepacc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idepacc",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idepacc")?proposedValue.ToString():r["idepacc",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idepacc",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idepacc"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idepacc"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idepacc"].ToString());
}
 } 
public class HashCreator_idepacc_nvar : IHashCreator { 
public string[] k   ={"idepacc","nvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idepacc",v].ToString(),r["nvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idepacc")?proposedValue.ToString():r["idepacc",v].ToString();
s += "§"+ ((field=="nvar")?proposedValue.ToString():r["nvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idepacc",o).ToString(),q.getField("nvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idepacc"]??"").ToString(),(o["nvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idepacc"].ToString(),childVal["nvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idepacc"].ToString(),parentVal["nvar"].ToString());
}
 } 
public class HashCreator_paridepacc : IHashCreator { 
public string[] k   ={"paridepacc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridepacc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridepacc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridepacc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idepexp : IHashCreator { 
public string[] k   ={"ayear","idepexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idepexp",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idepexp")?proposedValue.ToString():r["idepexp",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idepexp",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idepexp"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idepexp"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idepexp"].ToString());
}
 } 
public class HashCreator_idepexp : IHashCreator { 
public string[] k   ={"idepexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idepexp",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idepexp",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idepexp"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paridepexp : IHashCreator { 
public string[] k   ={"paridepexp"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridepexp",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridepexp",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridepexp"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotivecredit_crg : IHashCreator { 
public string[] k   ={"idaccmotivecredit_crg"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotivecredit_crg",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotivecredit_crg",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotivecredit_crg"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idivakind_forced : IHashCreator { 
public string[] k   ={"idivakind_forced"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idivakind_forced",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idivakind_forced",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idivakind_forced"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_movkind : IHashCreator { 
public string[] k   ={"movkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["movkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("movkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["movkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_ncreditpart : IHashCreator { 
public string[] k   ={"idinc","ncreditpart"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["ncreditpart",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="ncreditpart")?proposedValue.ToString():r["ncreditpart",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("ncreditpart",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["ncreditpart"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["ncreditpart"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["ncreditpart"].ToString());
}
 } 
public class HashCreator_idinc_nproceedspart : IHashCreator { 
public string[] k   ={"idinc","nproceedspart"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["nproceedspart",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="nproceedspart")?proposedValue.ToString():r["nproceedspart",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("nproceedspart",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["nproceedspart"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["nproceedspart"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["nproceedspart"].ToString());
}
 } 
public class HashCreator_ayear_idinc : IHashCreator { 
public string[] k   ={"ayear","idinc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idinc",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idinc")?proposedValue.ToString():r["idinc",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idinc",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idinc"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idinc"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idinc"].ToString());
}
 } 
public class HashCreator_idsor_siope : IHashCreator { 
public string[] k   ={"idsor_siope"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iso_payment : IHashCreator { 
public string[] k   ={"iso_payment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iso_payment",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iso_payment",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iso_payment"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcountry_origin : IHashCreator { 
public string[] k   ={"idcountry_origin"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcountry_origin",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcountry_origin",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcountry_origin"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iso_destination : IHashCreator { 
public string[] k   ={"iso_destination"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iso_destination",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iso_destination",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iso_destination"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcountry_destination : IHashCreator { 
public string[] k   ={"idcountry_destination"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcountry_destination",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcountry_destination",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcountry_destination"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iso_provenance : IHashCreator { 
public string[] k   ={"iso_provenance"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iso_provenance",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iso_provenance",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iso_provenance"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iso_origin : IHashCreator { 
public string[] k   ={"iso_origin"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iso_origin",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iso_origin",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iso_origin"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotivedebit_crg : IHashCreator { 
public string[] k   ={"idaccmotivedebit_crg"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotivedebit_crg",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotivedebit_crg",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotivedebit_crg"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_rifamm_ven_emittente : IHashCreator { 
public string[] k   ={"rifamm_ven_emittente"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["rifamm_ven_emittente",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("rifamm_ven_emittente",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["rifamm_ven_emittente"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_sostituto : IHashCreator { 
public string[] k   ={"idreg_sostituto"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idreg_sostituto",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idreg_sostituto",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idreg_sostituto"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ipa_ven_emittente : IHashCreator { 
public string[] k   ={"ipa_ven_emittente"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["ipa_ven_emittente",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("ipa_ven_emittente",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["ipa_ven_emittente"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_forwarder_ninv_forwarder_yinv_forwarder : IHashCreator { 
public string[] k   ={"idinvkind_forwarder","ninv_forwarder","yinv_forwarder"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind_forwarder",v].ToString(),r["ninv_forwarder",v].ToString(),r["yinv_forwarder",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind_forwarder")?proposedValue.ToString():r["idinvkind_forwarder",v].ToString();
s += "§"+ ((field=="ninv_forwarder")?proposedValue.ToString():r["ninv_forwarder",v].ToString());
s += "§"+ ((field=="yinv_forwarder")?proposedValue.ToString():r["yinv_forwarder",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind_forwarder",o).ToString(),q.getField("ninv_forwarder",o).ToString(),q.getField("yinv_forwarder",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind_forwarder"]??"").ToString(),(o["ninv_forwarder"]??"").ToString(),(o["yinv_forwarder"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind_forwarder"].ToString(),childVal["ninv_forwarder"].ToString(),childVal["yinv_forwarder"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind_forwarder"].ToString(),parentVal["ninv_forwarder"].ToString(),parentVal["yinv_forwarder"].ToString());
}
 } 
public class HashCreator_idinvkind_invrownum_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","invrownum","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["invrownum",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="invrownum")?proposedValue.ToString():r["invrownum",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("invrownum",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["invrownum"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["invrownum"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["invrownum"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idinvkind_idgroup_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","idgroup","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["idgroup",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="idgroup")?proposedValue.ToString():r["idgroup",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("idgroup",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["idgroup"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["idgroup"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["idgroup"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idinvkind_inv_idgroup_ninv_yinv : IHashCreator { 
public string[] k   ={"idinvkind","inv_idgroup","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["inv_idgroup",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="inv_idgroup")?proposedValue.ToString():r["inv_idgroup",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("inv_idgroup",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["inv_idgroup"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["inv_idgroup"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["inv_idgroup"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idmain_avcp_idmankind_nman_yman : IHashCreator { 
public string[] k   ={"idmain_avcp","idmankind","nman","yman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmain_avcp",v].ToString(),r["idmankind",v].ToString(),r["nman",v].ToString(),r["yman",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmain_avcp")?proposedValue.ToString():r["idmain_avcp",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
s += "§"+ ((field=="nman")?proposedValue.ToString():r["nman",v].ToString());
s += "§"+ ((field=="yman")?proposedValue.ToString():r["yman",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmain_avcp",o).ToString(),q.getField("idmankind",o).ToString(),q.getField("nman",o).ToString(),q.getField("yman",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmain_avcp"]??"").ToString(),(o["idmankind"]??"").ToString(),(o["nman"]??"").ToString(),(o["yman"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmain_avcp"].ToString(),childVal["idmankind"].ToString(),childVal["nman"].ToString(),childVal["yman"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmain_avcp"].ToString(),parentVal["idmankind"].ToString(),parentVal["nman"].ToString(),parentVal["yman"].ToString());
}
 } 
public class HashCreator_idreg_rupanac : IHashCreator { 
public string[] k   ={"idreg_rupanac"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idreg_rupanac",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idreg_rupanac",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idreg_rupanac"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmankind_idsor : IHashCreator { 
public string[] k   ={"idmankind","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idmankind",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idmankind",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idmankind"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idmankind"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idmankind"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idattachmentkind_idmankind : IHashCreator { 
public string[] k   ={"idattachmentkind","idmankind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachmentkind",v].ToString(),r["idmankind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachmentkind")?proposedValue.ToString():r["idattachmentkind",v].ToString();
s += "§"+ ((field=="idmankind")?proposedValue.ToString():r["idmankind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachmentkind",o).ToString(),q.getField("idmankind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachmentkind"]??"").ToString(),(o["idmankind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachmentkind"].ToString(),childVal["idmankind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachmentkind"].ToString(),parentVal["idmankind"].ToString());
}
 } 
public class HashCreator_nservreg_yservreg : IHashCreator { 
public string[] k   ={"nservreg","yservreg"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nservreg",v].ToString(),r["yservreg",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nservreg")?proposedValue.ToString():r["nservreg",v].ToString();
s += "§"+ ((field=="yservreg")?proposedValue.ToString():r["yservreg",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nservreg",o).ToString(),q.getField("yservreg",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nservreg"]??"").ToString(),(o["yservreg"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nservreg"].ToString(),childVal["yservreg"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nservreg"].ToString(),parentVal["yservreg"].ToString());
}
 } 
public class HashCreator_ayear_idapregistrykind : IHashCreator { 
public string[] k   ={"ayear","idapregistrykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idapregistrykind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idapregistrykind")?proposedValue.ToString():r["idapregistrykind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idapregistrykind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idapregistrykind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idapregistrykind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idapregistrykind"].ToString());
}
 } 
public class HashCreator_ayear_idapmanager : IHashCreator { 
public string[] k   ={"ayear","idapmanager"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idapmanager",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idapmanager")?proposedValue.ToString():r["idapmanager",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idapmanager",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idapmanager"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idapmanager"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idapmanager"].ToString());
}
 } 
public class HashCreator_ayear_idfinancialactivity : IHashCreator { 
public string[] k   ={"ayear","idfinancialactivity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idfinancialactivity",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idfinancialactivity")?proposedValue.ToString():r["idfinancialactivity",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idfinancialactivity",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idfinancialactivity"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idfinancialactivity"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idfinancialactivity"].ToString());
}
 } 
public class HashCreator_ayear_idapcontractkind : IHashCreator { 
public string[] k   ={"ayear","idapcontractkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idapcontractkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idapcontractkind")?proposedValue.ToString():r["idapcontractkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idapcontractkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idapcontractkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idapcontractkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idapcontractkind"].ToString());
}
 } 
public class HashCreator_ayear_idapactivitykind : IHashCreator { 
public string[] k   ={"ayear","idapactivitykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idapactivitykind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idapactivitykind")?proposedValue.ToString():r["idapactivitykind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idapactivitykind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idapactivitykind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idapactivitykind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idapactivitykind"].ToString());
}
 } 
public class HashCreator_ayear_idconsultingkind : IHashCreator { 
public string[] k   ={"ayear","idconsultingkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idconsultingkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idconsultingkind")?proposedValue.ToString():r["idconsultingkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idconsultingkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idconsultingkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idconsultingkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idconsultingkind"].ToString());
}
 } 
public class HashCreator_ayear_idacquirekind : IHashCreator { 
public string[] k   ={"ayear","idacquirekind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idacquirekind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idacquirekind")?proposedValue.ToString():r["idacquirekind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idacquirekind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idacquirekind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idacquirekind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idacquirekind"].ToString());
}
 } 
public class HashCreator_iddepartment : IHashCreator { 
public string[] k   ={"iddepartment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddepartment",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddepartment",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddepartment"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nservreg_semesterpay_ypay_yservreg : IHashCreator { 
public string[] k   ={"nservreg","semesterpay","ypay","yservreg"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nservreg",v].ToString(),r["semesterpay",v].ToString(),r["ypay",v].ToString(),r["yservreg",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nservreg")?proposedValue.ToString():r["nservreg",v].ToString();
s += "§"+ ((field=="semesterpay")?proposedValue.ToString():r["semesterpay",v].ToString());
s += "§"+ ((field=="ypay")?proposedValue.ToString():r["ypay",v].ToString());
s += "§"+ ((field=="yservreg")?proposedValue.ToString():r["yservreg",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nservreg",o).ToString(),q.getField("semesterpay",o).ToString(),q.getField("ypay",o).ToString(),q.getField("yservreg",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nservreg"]??"").ToString(),(o["semesterpay"]??"").ToString(),(o["ypay"]??"").ToString(),(o["yservreg"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nservreg"].ToString(),childVal["semesterpay"].ToString(),childVal["ypay"].ToString(),childVal["yservreg"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nservreg"].ToString(),parentVal["semesterpay"].ToString(),parentVal["ypay"].ToString(),parentVal["yservreg"].ToString());
}
 } 
public class HashCreator_pa_code : IHashCreator { 
public string[] k   ={"pa_code"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["pa_code",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("pa_code",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["pa_code"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreferencerule : IHashCreator { 
public string[] k   ={"idreferencerule"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idreferencerule",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idreferencerule",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idreferencerule"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idapfinancialactivity : IHashCreator { 
public string[] k   ={"idapfinancialactivity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idapfinancialactivity",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idapfinancialactivity",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idapfinancialactivity"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idserviceregistrykind : IHashCreator { 
public string[] k   ={"idserviceregistrykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idserviceregistrykind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idserviceregistrykind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idserviceregistrykind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_yservreg_idacquirekind : IHashCreator { 
public string[] k   ={"yservreg","idacquirekind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["yservreg",v].ToString(),r["idacquirekind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="yservreg")?proposedValue.ToString():r["yservreg",v].ToString();
s += "§"+ ((field=="idacquirekind")?proposedValue.ToString():r["idacquirekind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("yservreg",o).ToString(),q.getField("idacquirekind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["yservreg"]??"").ToString(),(o["idacquirekind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["yservreg"].ToString(),childVal["idacquirekind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["yservreg"].ToString(),parentVal["idacquirekind"].ToString());
}
 } 
public class HashCreator_yservreg_idfinancialactivity : IHashCreator { 
public string[] k   ={"yservreg","idfinancialactivity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["yservreg",v].ToString(),r["idfinancialactivity",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="yservreg")?proposedValue.ToString():r["yservreg",v].ToString();
s += "§"+ ((field=="idfinancialactivity")?proposedValue.ToString():r["idfinancialactivity",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("yservreg",o).ToString(),q.getField("idfinancialactivity",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["yservreg"]??"").ToString(),(o["idfinancialactivity"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["yservreg"].ToString(),childVal["idfinancialactivity"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["yservreg"].ToString(),parentVal["idfinancialactivity"].ToString());
}
 } 
public class HashCreator_idconferring : IHashCreator { 
public string[] k   ={"idconferring"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idconferring",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idconferring",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idconferring"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_conferring_idcity : IHashCreator { 
public string[] k   ={"conferring_idcity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["conferring_idcity",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("conferring_idcity",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["conferring_idcity"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_yservreg_idapcontractkind : IHashCreator { 
public string[] k   ={"yservreg","idapcontractkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["yservreg",v].ToString(),r["idapcontractkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="yservreg")?proposedValue.ToString():r["yservreg",v].ToString();
s += "§"+ ((field=="idapcontractkind")?proposedValue.ToString():r["idapcontractkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("yservreg",o).ToString(),q.getField("idapcontractkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["yservreg"]??"").ToString(),(o["idapcontractkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["yservreg"].ToString(),childVal["idapcontractkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["yservreg"].ToString(),parentVal["idapcontractkind"].ToString());
}
 } 
public class HashCreator_idacc_discount : IHashCreator { 
public string[] k   ={"idacc_discount"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_discount",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_discount",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_discount"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_unabatable : IHashCreator { 
public string[] k   ={"idacc_unabatable"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_unabatable",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_unabatable",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_unabatable"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_deferred : IHashCreator { 
public string[] k   ={"idacc_deferred"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_deferred",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_deferred",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_deferred"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_split : IHashCreator { 
public string[] k   ={"idacc_split"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_split",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_split",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_split"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_deferred_split : IHashCreator { 
public string[] k   ={"idacc_deferred_split"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_deferred_split",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_deferred_split",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_deferred_split"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_deferred_intra : IHashCreator { 
public string[] k   ={"idacc_deferred_intra"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_deferred_intra",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_deferred_intra",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_deferred_intra"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_unabatable_split : IHashCreator { 
public string[] k   ={"idacc_unabatable_split"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_unabatable_split",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_unabatable_split",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_unabatable_split"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_intra : IHashCreator { 
public string[] k   ={"idacc_intra"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_intra",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_intra",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_intra"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_unabatable_intra : IHashCreator { 
public string[] k   ={"idacc_unabatable_intra"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_unabatable_intra",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_unabatable_intra",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_unabatable_intra"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatmeasure : IHashCreator { 
public string[] k   ={"idintrastatmeasure"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatmeasure",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatmeasure",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatmeasure"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatsupplymethod : IHashCreator { 
public string[] k   ={"idintrastatsupplymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatsupplymethod",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatsupplymethod",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatsupplymethod"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idintrastatcode : IHashCreator { 
public string[] k   ={"idintrastatcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatcode",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatcode",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatcode"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcostpartition : IHashCreator { 
public string[] k   ={"idcostpartition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcostpartition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcostpartition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcostpartition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpccdebitmotive : IHashCreator { 
public string[] k   ={"idpccdebitmotive"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpccdebitmotive",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpccdebitmotive",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpccdebitmotive"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idunit : IHashCreator { 
public string[] k   ={"idunit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idunit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idunit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idunit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinvkind_idivaregisterkind_ninv_nivapay_rownum_yinv_yivapay : IHashCreator { 
public string[] k   ={"idinvkind","idivaregisterkind","ninv","nivapay","rownum","yinv","yivapay"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinvkind",v].ToString(),r["idivaregisterkind",v].ToString(),r["ninv",v].ToString(),r["nivapay",v].ToString(),r["rownum",v].ToString(),r["yinv",v].ToString(),r["yivapay",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString();
s += "§"+ ((field=="idivaregisterkind")?proposedValue.ToString():r["idivaregisterkind",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="nivapay")?proposedValue.ToString():r["nivapay",v].ToString());
s += "§"+ ((field=="rownum")?proposedValue.ToString():r["rownum",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
s += "§"+ ((field=="yivapay")?proposedValue.ToString():r["yivapay",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinvkind",o).ToString(),q.getField("idivaregisterkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("nivapay",o).ToString(),q.getField("rownum",o).ToString(),q.getField("yinv",o).ToString(),q.getField("yivapay",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinvkind"]??"").ToString(),(o["idivaregisterkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["nivapay"]??"").ToString(),(o["rownum"]??"").ToString(),(o["yinv"]??"").ToString(),(o["yivapay"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinvkind"].ToString(),childVal["idivaregisterkind"].ToString(),childVal["ninv"].ToString(),childVal["nivapay"].ToString(),childVal["rownum"].ToString(),childVal["yinv"].ToString(),childVal["yivapay"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinvkind"].ToString(),parentVal["idivaregisterkind"].ToString(),parentVal["ninv"].ToString(),parentVal["nivapay"].ToString(),parentVal["rownum"].ToString(),parentVal["yinv"].ToString(),parentVal["yivapay"].ToString());
}
 } 
public class HashCreator_idintrastatservice : IHashCreator { 
public string[] k   ={"idintrastatservice"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idintrastatservice",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idintrastatservice",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idintrastatservice"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpccdebitstatus : IHashCreator { 
public string[] k   ={"idpccdebitstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpccdebitstatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpccdebitstatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpccdebitstatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idlistclass : IHashCreator { 
public string[] k   ={"idlistclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idlistclass",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idlistclass",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idlistclass"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpackage : IHashCreator { 
public string[] k   ={"idpackage"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpackage",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpackage",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpackage"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfinmotive : IHashCreator { 
public string[] k   ={"idfinmotive"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfinmotive",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfinmotive",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfinmotive"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idunderwriter : IHashCreator { 
public string[] k   ={"idunderwriter"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idunderwriter",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idunderwriter",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idunderwriter"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor_idupb : IHashCreator { 
public string[] k   ={"idsor","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idsor",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idsor")?proposedValue.ToString():r["idsor",v].ToString();
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idsor",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idsor"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idsor"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idsor"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_idattachment_idupb : IHashCreator { 
public string[] k   ={"idattachment","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_idacc_idupb : IHashCreator { 
public string[] k   ={"idacc","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idacc",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idacc")?proposedValue.ToString():r["idacc",v].ToString();
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idacc",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idacc"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idacc"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idacc"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_idepupbkind : IHashCreator { 
public string[] k   ={"idepupbkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idepupbkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idepupbkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idepupbkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idautosort_idupb : IHashCreator { 
public string[] k   ={"ayear","idautosort","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idautosort",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idautosort")?proposedValue.ToString():r["idautosort",v].ToString());
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idautosort",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idautosort"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idautosort"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idautosort"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_idupb_idupb_dest : IHashCreator { 
public string[] k   ={"idupb","idupb_dest"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idupb",v].ToString(),r["idupb_dest",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idupb")?proposedValue.ToString():r["idupb",v].ToString();
s += "§"+ ((field=="idupb_dest")?proposedValue.ToString():r["idupb_dest",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idupb",o).ToString(),q.getField("idupb_dest",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idupb"]??"").ToString(),(o["idupb_dest"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idupb"].ToString(),childVal["idupb_dest"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idupb"].ToString(),parentVal["idupb_dest"].ToString());
}
 } 
public class HashCreator_ayear_idupb : IHashCreator { 
public string[] k   ={"ayear","idupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idupb",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idupb")?proposedValue.ToString():r["idupb",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idupb",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idupb"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idupb"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idupb"].ToString());
}
 } 
public class HashCreator_paridupb : IHashCreator { 
public string[] k   ={"paridupb"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridupb",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridupb",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridupb"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idupb_dest : IHashCreator { 
public string[] k   ={"idupb_dest"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idupb_dest",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idupb_dest",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idupb_dest"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idupb_iva : IHashCreator { 
public string[] k   ={"idupb_iva"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idupb_iva",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idupb_iva",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idupb_iva"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotiveannulment : IHashCreator { 
public string[] k   ={"idaccmotiveannulment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotiveannulment",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotiveannulment",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotiveannulment"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idrevenuepartition : IHashCreator { 
public string[] k   ={"idrevenuepartition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idrevenuepartition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idrevenuepartition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idrevenuepartition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idunderwriting : IHashCreator { 
public string[] k   ={"ayear","idunderwriting"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idunderwriting",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idunderwriting")?proposedValue.ToString():r["idunderwriting",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idunderwriting",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idunderwriting"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idunderwriting"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idunderwriting"].ToString());
}
 } 
public class HashCreator_idexp_iva : IHashCreator { 
public string[] k   ={"idexp_iva"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idexp_iva",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idexp_iva",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idexp_iva"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idexp_taxable : IHashCreator { 
public string[] k   ={"idexp_taxable"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idexp_taxable",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idexp_taxable",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idexp_taxable"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_linked : IHashCreator { 
public string[] k   ={"idinc_linked"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinc_linked",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinc_linked",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinc_linked"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_idinvkind_ninv_yinv : IHashCreator { 
public string[] k   ={"idinc","idinvkind","ninv","yinv"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["idinvkind",v].ToString(),r["ninv",v].ToString(),r["yinv",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="idinvkind")?proposedValue.ToString():r["idinvkind",v].ToString());
s += "§"+ ((field=="ninv")?proposedValue.ToString():r["ninv",v].ToString());
s += "§"+ ((field=="yinv")?proposedValue.ToString():r["yinv",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("idinvkind",o).ToString(),q.getField("ninv",o).ToString(),q.getField("yinv",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["idinvkind"]??"").ToString(),(o["ninv"]??"").ToString(),(o["yinv"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["idinvkind"].ToString(),childVal["ninv"].ToString(),childVal["yinv"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["idinvkind"].ToString(),parentVal["ninv"].ToString(),parentVal["yinv"].ToString());
}
 } 
public class HashCreator_idestimkind_idinc_nestim_yestim : IHashCreator { 
public string[] k   ={"idestimkind","idinc","nestim","yestim"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idestimkind",v].ToString(),r["idinc",v].ToString(),r["nestim",v].ToString(),r["yestim",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idestimkind")?proposedValue.ToString():r["idestimkind",v].ToString();
s += "§"+ ((field=="idinc")?proposedValue.ToString():r["idinc",v].ToString());
s += "§"+ ((field=="nestim")?proposedValue.ToString():r["nestim",v].ToString());
s += "§"+ ((field=="yestim")?proposedValue.ToString():r["yestim",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idestimkind",o).ToString(),q.getField("idinc",o).ToString(),q.getField("nestim",o).ToString(),q.getField("yestim",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idestimkind"]??"").ToString(),(o["idinc"]??"").ToString(),(o["nestim"]??"").ToString(),(o["yestim"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idestimkind"].ToString(),childVal["idinc"].ToString(),childVal["nestim"].ToString(),childVal["yestim"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idestimkind"].ToString(),parentVal["idinc"].ToString(),parentVal["nestim"].ToString(),parentVal["yestim"].ToString());
}
 } 
public class HashCreator_idinc_nbill_ybill : IHashCreator { 
public string[] k   ={"idinc","nbill","ybill"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinc",v].ToString(),r["nbill",v].ToString(),r["ybill",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinc")?proposedValue.ToString():r["idinc",v].ToString();
s += "§"+ ((field=="nbill")?proposedValue.ToString():r["nbill",v].ToString());
s += "§"+ ((field=="ybill")?proposedValue.ToString():r["ybill",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinc",o).ToString(),q.getField("nbill",o).ToString(),q.getField("ybill",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinc"]??"").ToString(),(o["nbill"]??"").ToString(),(o["ybill"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinc"].ToString(),childVal["nbill"].ToString(),childVal["ybill"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinc"].ToString(),parentVal["nbill"].ToString(),parentVal["ybill"].ToString());
}
 } 
public class HashCreator_idinc_iva : IHashCreator { 
public string[] k   ={"idinc_iva"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinc_iva",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinc_iva",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinc_iva"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinc_taxable : IHashCreator { 
public string[] k   ={"idinc_taxable"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinc_taxable",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinc_taxable",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinc_taxable"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nphaseincome : IHashCreator { 
public string[] k   ={"nphaseincome"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["nphaseincome",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("nphaseincome",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["nphaseincome"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinventoryamortization : IHashCreator { 
public string[] k   ={"idinventoryamortization"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinventoryamortization",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinventoryamortization",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinventoryamortization"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idasset_idgrant_idpiece : IHashCreator { 
public string[] k   ={"idasset","idgrant","idpiece"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["idgrant",v].ToString(),r["idpiece",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="idgrant")?proposedValue.ToString():r["idgrant",v].ToString());
s += "§"+ ((field=="idpiece")?proposedValue.ToString():r["idpiece",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("idgrant",o).ToString(),q.getField("idpiece",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["idgrant"]??"").ToString(),(o["idpiece"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["idgrant"].ToString(),childVal["idpiece"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["idgrant"].ToString(),parentVal["idpiece"].ToString());
}
 } 
public class HashCreator_idasset_iddetail_idgrant_idpiece : IHashCreator { 
public string[] k   ={"idasset","iddetail","idgrant","idpiece"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idasset",v].ToString(),r["iddetail",v].ToString(),r["idgrant",v].ToString(),r["idpiece",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idasset")?proposedValue.ToString():r["idasset",v].ToString();
s += "§"+ ((field=="iddetail")?proposedValue.ToString():r["iddetail",v].ToString());
s += "§"+ ((field=="idgrant")?proposedValue.ToString():r["idgrant",v].ToString());
s += "§"+ ((field=="idpiece")?proposedValue.ToString():r["idpiece",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idasset",o).ToString(),q.getField("iddetail",o).ToString(),q.getField("idgrant",o).ToString(),q.getField("idpiece",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idasset"]??"").ToString(),(o["iddetail"]??"").ToString(),(o["idgrant"]??"").ToString(),(o["idpiece"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idasset"].ToString(),childVal["iddetail"].ToString(),childVal["idgrant"].ToString(),childVal["idpiece"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idasset"].ToString(),parentVal["iddetail"].ToString(),parentVal["idgrant"].ToString(),parentVal["idpiece"].ToString());
}
 } 
public class HashCreator_idmanager : IHashCreator { 
public string[] k   ={"idmanager"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmanager",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmanager",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmanager"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcurrman : IHashCreator { 
public string[] k   ={"idcurrman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcurrman",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcurrman",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcurrman"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcurrsubman : IHashCreator { 
public string[] k   ={"idcurrsubman"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcurrsubman",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcurrsubman",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcurrsubman"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinventoryagency : IHashCreator { 
public string[] k   ={"idinventoryagency"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinventoryagency",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinventoryagency",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinventoryagency"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idassetvar_idassetvardetail : IHashCreator { 
public string[] k   ={"idassetvar","idassetvardetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idassetvar",v].ToString(),r["idassetvardetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idassetvar")?proposedValue.ToString():r["idassetvar",v].ToString();
s += "§"+ ((field=="idassetvardetail")?proposedValue.ToString():r["idassetvardetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idassetvar",o).ToString(),q.getField("idassetvardetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idassetvar"]??"").ToString(),(o["idassetvardetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idassetvar"].ToString(),childVal["idassetvardetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idassetvar"].ToString(),parentVal["idassetvardetail"].ToString());
}
 } 
public class HashCreator_idassetvar : IHashCreator { 
public string[] k   ={"idassetvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idassetvar",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idassetvar",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idassetvar"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idreg_distrained : IHashCreator { 
public string[] k   ={"idreg_distrained"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idreg_distrained",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idreg_distrained",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idreg_distrained"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iditineration_ref : IHashCreator { 
public string[] k   ={"iditineration_ref"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iditineration_ref",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iditineration_ref",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iditineration_ref"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcon : IHashCreator { 
public string[] k   ={"idcon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcon",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcon",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcon"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idotherinsurance : IHashCreator { 
public string[] k   ={"ayear","idotherinsurance"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idotherinsurance",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idotherinsurance")?proposedValue.ToString():r["idotherinsurance",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idotherinsurance",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idotherinsurance"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idotherinsurance"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idotherinsurance"].ToString());
}
 } 
public class HashCreator_idpayrollkind : IHashCreator { 
public string[] k   ={"idpayrollkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpayrollkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpayrollkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpayrollkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddeduction : IHashCreator { 
public string[] k   ={"iddeduction"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddeduction",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddeduction",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddeduction"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idabatement_idcon : IHashCreator { 
public string[] k   ={"ayear","idabatement","idcon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idabatement",v].ToString(),r["idcon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idabatement")?proposedValue.ToString():r["idabatement",v].ToString());
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idabatement",o).ToString(),q.getField("idcon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idabatement"]??"").ToString(),(o["idcon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idabatement"].ToString(),childVal["idcon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idabatement"].ToString(),parentVal["idcon"].ToString());
}
 } 
public class HashCreator_ayear_idcon_iddeduction : IHashCreator { 
public string[] k   ={"ayear","idcon","iddeduction"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcon",v].ToString(),r["iddeduction",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
s += "§"+ ((field=="iddeduction")?proposedValue.ToString():r["iddeduction",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcon",o).ToString(),q.getField("iddeduction",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcon"]??"").ToString(),(o["iddeduction"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcon"].ToString(),childVal["iddeduction"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcon"].ToString(),parentVal["iddeduction"].ToString());
}
 } 
public class HashCreator_idcon_idexhibitedcud : IHashCreator { 
public string[] k   ={"idcon","idexhibitedcud"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcon",v].ToString(),r["idexhibitedcud",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcon")?proposedValue.ToString():r["idcon",v].ToString();
s += "§"+ ((field=="idexhibitedcud")?proposedValue.ToString():r["idexhibitedcud",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcon",o).ToString(),q.getField("idexhibitedcud",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcon"]??"").ToString(),(o["idexhibitedcud"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcon"].ToString(),childVal["idexhibitedcud"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcon"].ToString(),parentVal["idexhibitedcud"].ToString());
}
 } 
public class HashCreator_idabatement : IHashCreator { 
public string[] k   ={"idabatement"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idabatement",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idabatement",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idabatement"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idabatement_idcon_idexhibitedcud : IHashCreator { 
public string[] k   ={"idabatement","idcon","idexhibitedcud"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idabatement",v].ToString(),r["idcon",v].ToString(),r["idexhibitedcud",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idabatement")?proposedValue.ToString():r["idabatement",v].ToString();
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
s += "§"+ ((field=="idexhibitedcud")?proposedValue.ToString():r["idexhibitedcud",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idabatement",o).ToString(),q.getField("idcon",o).ToString(),q.getField("idexhibitedcud",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idabatement"]??"").ToString(),(o["idcon"]??"").ToString(),(o["idexhibitedcud"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idabatement"].ToString(),childVal["idcon"].ToString(),childVal["idexhibitedcud"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idabatement"].ToString(),parentVal["idcon"].ToString(),parentVal["idexhibitedcud"].ToString());
}
 } 
public class HashCreator_iddeduction_idpayroll : IHashCreator { 
public string[] k   ={"iddeduction","idpayroll"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iddeduction",v].ToString(),r["idpayroll",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iddeduction")?proposedValue.ToString():r["iddeduction",v].ToString();
s += "§"+ ((field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iddeduction",o).ToString(),q.getField("idpayroll",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iddeduction"]??"").ToString(),(o["idpayroll"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iddeduction"].ToString(),childVal["idpayroll"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iddeduction"].ToString(),parentVal["idpayroll"].ToString());
}
 } 
public class HashCreator_idabatement_idpayroll : IHashCreator { 
public string[] k   ={"idabatement","idpayroll"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idabatement",v].ToString(),r["idpayroll",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idabatement")?proposedValue.ToString():r["idabatement",v].ToString();
s += "§"+ ((field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idabatement",o).ToString(),q.getField("idpayroll",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idabatement"]??"").ToString(),(o["idpayroll"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idabatement"].ToString(),childVal["idpayroll"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idabatement"].ToString(),parentVal["idpayroll"].ToString());
}
 } 
public class HashCreator_idpayroll_idpayrolltax_nbracket : IHashCreator { 
public string[] k   ={"idpayroll","idpayrolltax","nbracket"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpayroll",v].ToString(),r["idpayrolltax",v].ToString(),r["nbracket",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString();
s += "§"+ ((field=="idpayrolltax")?proposedValue.ToString():r["idpayrolltax",v].ToString());
s += "§"+ ((field=="nbracket")?proposedValue.ToString():r["nbracket",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpayroll",o).ToString(),q.getField("idpayrolltax",o).ToString(),q.getField("nbracket",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpayroll"]??"").ToString(),(o["idpayrolltax"]??"").ToString(),(o["nbracket"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpayroll"].ToString(),childVal["idpayrolltax"].ToString(),childVal["nbracket"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpayroll"].ToString(),parentVal["idpayrolltax"].ToString(),parentVal["nbracket"].ToString());
}
 } 
public class HashCreator_ayear_idcon_idfamily : IHashCreator { 
public string[] k   ={"ayear","idcon","idfamily"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcon",v].ToString(),r["idfamily",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
s += "§"+ ((field=="idfamily")?proposedValue.ToString():r["idfamily",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcon",o).ToString(),q.getField("idfamily",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcon"]??"").ToString(),(o["idfamily"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcon"].ToString(),childVal["idfamily"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcon"].ToString(),parentVal["idfamily"].ToString());
}
 } 
public class HashCreator_ayear_idabatement : IHashCreator { 
public string[] k   ={"ayear","idabatement"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idabatement",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idabatement")?proposedValue.ToString():r["idabatement",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idabatement",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idabatement"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idabatement"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idabatement"].ToString());
}
 } 
public class HashCreator_activitycode_ayear : IHashCreator { 
public string[] k   ={"activitycode","ayear"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["activitycode",v].ToString(),r["ayear",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="activitycode")?proposedValue.ToString():r["activitycode",v].ToString();
s += "§"+ ((field=="ayear")?proposedValue.ToString():r["ayear",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("activitycode",o).ToString(),q.getField("ayear",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["activitycode"]??"").ToString(),(o["ayear"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["activitycode"].ToString(),childVal["ayear"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["activitycode"].ToString(),parentVal["ayear"].ToString());
}
 } 
public class HashCreator_idcon_idotherinail : IHashCreator { 
public string[] k   ={"idcon","idotherinail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcon",v].ToString(),r["idotherinail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcon")?proposedValue.ToString():r["idcon",v].ToString();
s += "§"+ ((field=="idotherinail")?proposedValue.ToString():r["idotherinail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcon",o).ToString(),q.getField("idotherinail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcon"]??"").ToString(),(o["idotherinail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcon"].ToString(),childVal["idotherinail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcon"].ToString(),parentVal["idotherinail"].ToString());
}
 } 
public class HashCreator_ayear_iddeduction : IHashCreator { 
public string[] k   ={"ayear","iddeduction"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["iddeduction",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="iddeduction")?proposedValue.ToString():r["iddeduction",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("iddeduction",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["iddeduction"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["iddeduction"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["iddeduction"].ToString());
}
 } 
public class HashCreator_idcon_iddeduction_idexhibitedcud : IHashCreator { 
public string[] k   ={"idcon","iddeduction","idexhibitedcud"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcon",v].ToString(),r["iddeduction",v].ToString(),r["idexhibitedcud",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcon")?proposedValue.ToString():r["idcon",v].ToString();
s += "§"+ ((field=="iddeduction")?proposedValue.ToString():r["iddeduction",v].ToString());
s += "§"+ ((field=="idexhibitedcud")?proposedValue.ToString():r["idexhibitedcud",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcon",o).ToString(),q.getField("iddeduction",o).ToString(),q.getField("idexhibitedcud",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcon"]??"").ToString(),(o["iddeduction"]??"").ToString(),(o["idexhibitedcud"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcon"].ToString(),childVal["iddeduction"].ToString(),childVal["idexhibitedcud"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcon"].ToString(),parentVal["iddeduction"].ToString(),parentVal["idexhibitedcud"].ToString());
}
 } 
public class HashCreator_idpat : IHashCreator { 
public string[] k   ={"idpat"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpat",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpat",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpat"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idmatriculabook : IHashCreator { 
public string[] k   ={"idmatriculabook"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idmatriculabook",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idmatriculabook",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idmatriculabook"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idcon : IHashCreator { 
public string[] k   ={"ayear","idcon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcon"].ToString());
}
 } 
public class HashCreator_ayear_idemenscontractkind : IHashCreator { 
public string[] k   ={"ayear","idemenscontractkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idemenscontractkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idemenscontractkind")?proposedValue.ToString():r["idemenscontractkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idemenscontractkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idemenscontractkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idemenscontractkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idemenscontractkind"].ToString());
}
 } 
public class HashCreator_idcon_idsor : IHashCreator { 
public string[] k   ={"idcon","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcon",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcon")?proposedValue.ToString():r["idcon",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcon",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcon"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcon"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcon"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idcafdocument_idcon : IHashCreator { 
public string[] k   ={"idcafdocument","idcon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcafdocument",v].ToString(),r["idcon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcafdocument")?proposedValue.ToString():r["idcafdocument",v].ToString();
s += "§"+ ((field=="idcon")?proposedValue.ToString():r["idcon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcafdocument",o).ToString(),q.getField("idcon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcafdocument"]??"").ToString(),(o["idcon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcafdocument"].ToString(),childVal["idcon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcafdocument"].ToString(),parentVal["idcon"].ToString());
}
 } 
public class HashCreator_codice : IHashCreator { 
public string[] k   ={"codice"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["codice",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("codice",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["codice"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idtaxratestart_nbracket_taxcode : IHashCreator { 
public string[] k   ={"idtaxratestart","nbracket","taxcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idtaxratestart",v].ToString(),r["nbracket",v].ToString(),r["taxcode",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idtaxratestart")?proposedValue.ToString():r["idtaxratestart",v].ToString();
s += "§"+ ((field=="nbracket")?proposedValue.ToString():r["nbracket",v].ToString());
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idtaxratestart",o).ToString(),q.getField("nbracket",o).ToString(),q.getField("taxcode",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idtaxratestart"]??"").ToString(),(o["nbracket"]??"").ToString(),(o["taxcode"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idtaxratestart"].ToString(),childVal["nbracket"].ToString(),childVal["taxcode"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idtaxratestart"].ToString(),parentVal["nbracket"].ToString(),parentVal["taxcode"].ToString());
}
 } 
public class HashCreator_idpayroll_idpayrolltaxcorrige : IHashCreator { 
public string[] k   ={"idpayroll","idpayrolltaxcorrige"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpayroll",v].ToString(),r["idpayrolltaxcorrige",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpayroll")?proposedValue.ToString():r["idpayroll",v].ToString();
s += "§"+ ((field=="idpayrolltaxcorrige")?proposedValue.ToString():r["idpayrolltaxcorrige",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpayroll",o).ToString(),q.getField("idpayrolltaxcorrige",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpayroll"]??"").ToString(),(o["idpayrolltaxcorrige"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpayroll"].ToString(),childVal["idpayrolltaxcorrige"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpayroll"].ToString(),parentVal["idpayrolltaxcorrige"].ToString());
}
 } 
public class HashCreator_cafdocumentkind : IHashCreator { 
public string[] k   ={"cafdocumentkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["cafdocumentkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("cafdocumentkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["cafdocumentkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idlinkedrefund : IHashCreator { 
public string[] k   ={"idlinkedrefund"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idlinkedrefund",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idlinkedrefund",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idlinkedrefund"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_cigcode_idavcp_ncon_ycon : IHashCreator { 
public string[] k   ={"cigcode","idavcp","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["cigcode",v].ToString(),r["idavcp",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="cigcode")?proposedValue.ToString():r["cigcode",v].ToString();
s += "§"+ ((field=="idavcp")?proposedValue.ToString():r["idavcp",v].ToString());
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("cigcode",o).ToString(),q.getField("idavcp",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["cigcode"]??"").ToString(),(o["idavcp"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["cigcode"].ToString(),childVal["idavcp"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["cigcode"].ToString(),parentVal["idavcp"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_cigcode_ncon_ycon : IHashCreator { 
public string[] k   ={"cigcode","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["cigcode",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="cigcode")?proposedValue.ToString():r["cigcode",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("cigcode",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["cigcode"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["cigcode"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["cigcode"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_ncon_nrefund_ycon : IHashCreator { 
public string[] k   ={"ncon","nrefund","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ncon",v].ToString(),r["nrefund",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ncon")?proposedValue.ToString():r["ncon",v].ToString();
s += "§"+ ((field=="nrefund")?proposedValue.ToString():r["nrefund",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ncon",o).ToString(),q.getField("nrefund",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ncon"]??"").ToString(),(o["nrefund"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ncon"].ToString(),childVal["nrefund"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ncon"].ToString(),parentVal["nrefund"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_idavcp_ncon_ycon : IHashCreator { 
public string[] k   ={"idavcp","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idavcp",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idavcp")?proposedValue.ToString():r["idavcp",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idavcp",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idavcp"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idavcp"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idavcp"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_nbracket_ncon_taxcode_ycon : IHashCreator { 
public string[] k   ={"nbracket","ncon","taxcode","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nbracket",v].ToString(),r["ncon",v].ToString(),r["taxcode",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nbracket")?proposedValue.ToString():r["nbracket",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nbracket",o).ToString(),q.getField("ncon",o).ToString(),q.getField("taxcode",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nbracket"]??"").ToString(),(o["ncon"]??"").ToString(),(o["taxcode"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nbracket"].ToString(),childVal["ncon"].ToString(),childVal["taxcode"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nbracket"].ToString(),parentVal["ncon"].ToString(),parentVal["taxcode"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_iddeduction_ncon_ycon : IHashCreator { 
public string[] k   ={"iddeduction","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iddeduction",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iddeduction")?proposedValue.ToString():r["iddeduction",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iddeduction",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iddeduction"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iddeduction"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iddeduction"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_startvalidity : IHashCreator { 
public string[] k   ={"startvalidity"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["startvalidity",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("startvalidity",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["startvalidity"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idser : IHashCreator { 
public string[] k   ={"ayear","idser"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idser",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idser")?proposedValue.ToString():r["idser",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idser",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idser"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idser"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idser"].ToString());
}
 } 
public class HashCreator_iduniqueregister_ncon_ycon : IHashCreator { 
public string[] k   ={"iduniqueregister","ncon","ycon"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iduniqueregister",v].ToString(),r["ncon",v].ToString(),r["ycon",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iduniqueregister")?proposedValue.ToString():r["iduniqueregister",v].ToString();
s += "§"+ ((field=="ncon")?proposedValue.ToString():r["ncon",v].ToString());
s += "§"+ ((field=="ycon")?proposedValue.ToString():r["ycon",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iduniqueregister",o).ToString(),q.getField("ncon",o).ToString(),q.getField("ycon",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iduniqueregister"]??"").ToString(),(o["ncon"]??"").ToString(),(o["ycon"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iduniqueregister"].ToString(),childVal["ncon"].ToString(),childVal["ycon"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iduniqueregister"].ToString(),parentVal["ncon"].ToString(),parentVal["ycon"].ToString());
}
 } 
public class HashCreator_idlist_idsor : IHashCreator { 
public string[] k   ={"idlist","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idlist",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idlist")?proposedValue.ToString():r["idlist",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idlist",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idlist"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idlist"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idlist"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_ayear_idlistclass : IHashCreator { 
public string[] k   ={"ayear","idlistclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idlistclass",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idlistclass")?proposedValue.ToString():r["idlistclass",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idlistclass",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idlistclass"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idlistclass"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idlistclass"].ToString());
}
 } 
public class HashCreator_paridlistclass : IHashCreator { 
public string[] k   ={"paridlistclass"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridlistclass",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridlistclass",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridlistclass"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_nentry_yentry : IHashCreator { 
public string[] k   ={"nentry","yentry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["nentry",v].ToString(),r["yentry",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="nentry")?proposedValue.ToString():r["nentry",v].ToString();
s += "§"+ ((field=="yentry")?proposedValue.ToString():r["yentry",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("nentry",o).ToString(),q.getField("yentry",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["nentry"]??"").ToString(),(o["yentry"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["nentry"].ToString(),childVal["yentry"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["nentry"].ToString(),parentVal["yentry"].ToString());
}
 } 
public class HashCreator_identrykind : IHashCreator { 
public string[] k   ={"identrykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["identrykind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("identrykind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["identrykind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccrual_ndetail_nentry_yentry : IHashCreator { 
public string[] k   ={"idaccrual","ndetail","nentry","yentry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idaccrual",v].ToString(),r["ndetail",v].ToString(),r["nentry",v].ToString(),r["yentry",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idaccrual")?proposedValue.ToString():r["idaccrual",v].ToString();
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
s += "§"+ ((field=="nentry")?proposedValue.ToString():r["nentry",v].ToString());
s += "§"+ ((field=="yentry")?proposedValue.ToString():r["yentry",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idaccrual",o).ToString(),q.getField("ndetail",o).ToString(),q.getField("nentry",o).ToString(),q.getField("yentry",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idaccrual"]??"").ToString(),(o["ndetail"]??"").ToString(),(o["nentry"]??"").ToString(),(o["yentry"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idaccrual"].ToString(),childVal["ndetail"].ToString(),childVal["nentry"].ToString(),childVal["yentry"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idaccrual"].ToString(),parentVal["ndetail"].ToString(),parentVal["nentry"].ToString(),parentVal["yentry"].ToString());
}
 } 
public class HashCreator_ndetail_nentry_yentry : IHashCreator { 
public string[] k   ={"ndetail","nentry","yentry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ndetail",v].ToString(),r["nentry",v].ToString(),r["yentry",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString();
s += "§"+ ((field=="nentry")?proposedValue.ToString():r["nentry",v].ToString());
s += "§"+ ((field=="yentry")?proposedValue.ToString():r["yentry",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ndetail",o).ToString(),q.getField("nentry",o).ToString(),q.getField("yentry",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ndetail"]??"").ToString(),(o["nentry"]??"").ToString(),(o["yentry"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ndetail"].ToString(),childVal["nentry"].ToString(),childVal["yentry"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ndetail"].ToString(),parentVal["nentry"].ToString(),parentVal["yentry"].ToString());
}
 } 
public class HashCreator_idfinvarstatus : IHashCreator { 
public string[] k   ={"idfinvarstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfinvarstatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfinvarstatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfinvarstatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfinvarkind : IHashCreator { 
public string[] k   ={"idfinvarkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfinvarkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfinvarkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfinvarkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idvariationkind : IHashCreator { 
public string[] k   ={"idvariationkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idvariationkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idvariationkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idvariationkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idlcardvar : IHashCreator { 
public string[] k   ={"idlcardvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idlcardvar",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idlcardvar",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idlcardvar"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idattachment_nvar_yvar : IHashCreator { 
public string[] k   ={"idattachment","nvar","yvar"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idattachment",v].ToString(),r["nvar",v].ToString(),r["yvar",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idattachment")?proposedValue.ToString():r["idattachment",v].ToString();
s += "§"+ ((field=="nvar")?proposedValue.ToString():r["nvar",v].ToString());
s += "§"+ ((field=="yvar")?proposedValue.ToString():r["yvar",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idattachment",o).ToString(),q.getField("nvar",o).ToString(),q.getField("yvar",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idattachment"]??"").ToString(),(o["nvar"]??"").ToString(),(o["yvar"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idattachment"].ToString(),childVal["nvar"].ToString(),childVal["yvar"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idattachment"].ToString(),parentVal["nvar"].ToString(),parentVal["yvar"].ToString());
}
 } 
public class HashCreator_idaccountvarstatus : IHashCreator { 
public string[] k   ={"idaccountvarstatus"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccountvarstatus",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccountvarstatus",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccountvarstatus"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpatrimony : IHashCreator { 
public string[] k   ={"idpatrimony"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpatrimony",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpatrimony",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpatrimony"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_idsor : IHashCreator { 
public string[] k   ={"idacc","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idacc",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idacc")?proposedValue.ToString():r["idacc",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idacc",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idacc"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idacc"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idacc"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idplaccount : IHashCreator { 
public string[] k   ={"idplaccount"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idplaccount",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idplaccount",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idplaccount"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paridacc : IHashCreator { 
public string[] k   ={"paridacc"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridacc",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridacc",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridacc"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor_investmentbudget : IHashCreator { 
public string[] k   ={"idsor_investmentbudget"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_investmentbudget",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_investmentbudget",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_investmentbudget"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor_economicbudget : IHashCreator { 
public string[] k   ={"idsor_economicbudget"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_economicbudget",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_economicbudget",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_economicbudget"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paridpatrimony : IHashCreator { 
public string[] k   ={"paridpatrimony"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridpatrimony",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridpatrimony",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridpatrimony"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paridplaccount : IHashCreator { 
public string[] k   ={"paridplaccount"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["paridplaccount",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("paridplaccount",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["paridplaccount"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idstamphandling : IHashCreator { 
public string[] k   ={"idstamphandling"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idstamphandling",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idstamphandling",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idstamphandling"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_iddetail_idpaydisposition : IHashCreator { 
public string[] k   ={"iddetail","idpaydisposition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["iddetail",v].ToString(),r["idpaydisposition",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="iddetail")?proposedValue.ToString():r["iddetail",v].ToString();
s += "§"+ ((field=="idpaydisposition")?proposedValue.ToString():r["idpaydisposition",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("iddetail",o).ToString(),q.getField("idpaydisposition",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["iddetail"]??"").ToString(),(o["idpaydisposition"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["iddetail"].ToString(),childVal["idpaydisposition"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["iddetail"].ToString(),parentVal["idpaydisposition"].ToString());
}
 } 
public class HashCreator_idpaydisposition : IHashCreator { 
public string[] k   ={"idpaydisposition"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idpaydisposition",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idpaydisposition",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idpaydisposition"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idpay_kpay : IHashCreator { 
public string[] k   ={"idpay","kpay"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpay",v].ToString(),r["kpay",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpay")?proposedValue.ToString():r["idpay",v].ToString();
s += "§"+ ((field=="kpay")?proposedValue.ToString():r["kpay",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpay",o).ToString(),q.getField("kpay",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpay"]??"").ToString(),(o["kpay"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpay"].ToString(),childVal["kpay"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpay"].ToString(),parentVal["kpay"].ToString());
}
 } 
public class HashCreator_kpay_nban_yban : IHashCreator { 
public string[] k   ={"kpay","nban","yban"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["kpay",v].ToString(),r["nban",v].ToString(),r["yban",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="kpay")?proposedValue.ToString():r["kpay",v].ToString();
s += "§"+ ((field=="nban")?proposedValue.ToString():r["nban",v].ToString());
s += "§"+ ((field=="yban")?proposedValue.ToString():r["yban",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("kpay",o).ToString(),q.getField("nban",o).ToString(),q.getField("yban",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["kpay"]??"").ToString(),(o["nban"]??"").ToString(),(o["yban"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["kpay"].ToString(),childVal["nban"].ToString(),childVal["yban"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["kpay"].ToString(),parentVal["nban"].ToString(),parentVal["yban"].ToString());
}
 } 
public class HashCreator_kpro_nban_yban : IHashCreator { 
public string[] k   ={"kpro","nban","yban"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["kpro",v].ToString(),r["nban",v].ToString(),r["yban",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="kpro")?proposedValue.ToString():r["kpro",v].ToString();
s += "§"+ ((field=="nban")?proposedValue.ToString():r["nban",v].ToString());
s += "§"+ ((field=="yban")?proposedValue.ToString():r["yban",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("kpro",o).ToString(),q.getField("nban",o).ToString(),q.getField("yban",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["kpro"]??"").ToString(),(o["nban"]??"").ToString(),(o["yban"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["kpro"].ToString(),childVal["nban"].ToString(),childVal["yban"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["kpro"].ToString(),parentVal["nban"].ToString(),parentVal["yban"].ToString());
}
 } 
public class HashCreator_idpro_kpro : IHashCreator { 
public string[] k   ={"idpro","kpro"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idpro",v].ToString(),r["kpro",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idpro")?proposedValue.ToString():r["idpro",v].ToString();
s += "§"+ ((field=="kpro")?proposedValue.ToString():r["kpro",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idpro",o).ToString(),q.getField("kpro",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idpro"]??"").ToString(),(o["kpro"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idpro"].ToString(),childVal["kpro"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idpro"].ToString(),parentVal["kpro"].ToString());
}
 } 
public class HashCreator_iddivision : IHashCreator { 
public string[] k   ={"iddivision"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["iddivision",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("iddivision",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["iddivision"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idman_idsor : IHashCreator { 
public string[] k   ={"idman","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idman",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idman")?proposedValue.ToString():r["idman",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idman",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idman"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idman"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idman"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_idaccmotive_debit : IHashCreator { 
public string[] k   ={"idaccmotive_debit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotive_debit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotive_debit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotive_debit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotive_cost : IHashCreator { 
public string[] k   ={"idaccmotive_cost"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotive_cost",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotive_cost",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotive_cost"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idaccmotive_payment : IHashCreator { 
public string[] k   ={"idaccmotive_payment"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotive_payment",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotive_payment",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotive_payment"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idbankcbi : IHashCreator { 
public string[] k   ={"idbankcbi"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idbankcbi",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idbankcbi",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idbankcbi"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idbankcbi_idcabcbi : IHashCreator { 
public string[] k   ={"idbankcbi","idcabcbi"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idbankcbi",v].ToString(),r["idcabcbi",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idbankcbi")?proposedValue.ToString():r["idbankcbi",v].ToString();
s += "§"+ ((field=="idcabcbi")?proposedValue.ToString():r["idcabcbi",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idbankcbi",o).ToString(),q.getField("idcabcbi",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idbankcbi"]??"").ToString(),(o["idcabcbi"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idbankcbi"].ToString(),childVal["idcabcbi"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idbankcbi"].ToString(),parentVal["idcabcbi"].ToString());
}
 } 
public class HashCreator_idaccmotive_proceeds : IHashCreator { 
public string[] k   ={"idaccmotive_proceeds"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idaccmotive_proceeds",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idaccmotive_proceeds",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idaccmotive_proceeds"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinventorykind : IHashCreator { 
public string[] k   ={"idinventorykind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idinventorykind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idinventorykind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idinventorykind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idinv_idinv_lev1 : IHashCreator { 
public string[] k   ={"idinv","idinv_lev1"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idinv",v].ToString(),r["idinv_lev1",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idinv")?proposedValue.ToString():r["idinv",v].ToString();
s += "§"+ ((field=="idinv_lev1")?proposedValue.ToString():r["idinv_lev1",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idinv",o).ToString(),q.getField("idinv_lev1",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idinv"]??"").ToString(),(o["idinv_lev1"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idinv"].ToString(),childVal["idinv_lev1"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idinv"].ToString(),parentVal["idinv_lev1"].ToString());
}
 } 
public class HashCreator_idcertificationmodel : IHashCreator { 
public string[] k   ={"idcertificationmodel"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcertificationmodel",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcertificationmodel",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcertificationmodel"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idser_taxcode : IHashCreator { 
public string[] k   ={"idser","taxcode"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idser",v].ToString(),r["taxcode",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idser")?proposedValue.ToString():r["idser",v].ToString();
s += "§"+ ((field=="taxcode")?proposedValue.ToString():r["taxcode",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idser",o).ToString(),q.getField("taxcode",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idser"]??"").ToString(),(o["taxcode"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idser"].ToString(),childVal["taxcode"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idser"].ToString(),parentVal["taxcode"].ToString());
}
 } 
public class HashCreator_idser_idsor : IHashCreator { 
public string[] k   ={"idser","idsor"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idser",v].ToString(),r["idsor",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idser")?proposedValue.ToString():r["idser",v].ToString();
s += "§"+ ((field=="idsor")?proposedValue.ToString():r["idsor",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idser",o).ToString(),q.getField("idsor",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idser"]??"").ToString(),(o["idsor"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idser"].ToString(),childVal["idsor"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idser"].ToString(),parentVal["idsor"].ToString());
}
 } 
public class HashCreator_voce : IHashCreator { 
public string[] k   ={"voce"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["voce",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("voce",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["voce"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idmot : IHashCreator { 
public string[] k   ={"ayear","idmot"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idmot",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idmot")?proposedValue.ToString():r["idmot",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idmot",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idmot"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idmot"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idmot"].ToString());
}
 } 


public class HashCreator_idsor_siope_expense : IHashCreator { 
public string[] k   ={"idsor_siope_expense"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope_expense",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope_expense",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope_expense"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor_siope_income : IHashCreator { 
public string[] k   ={"idsor_siope_income"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope_income",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope_income",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope_income"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_expense : IHashCreator { 
public string[] k   ={"idfin_expense"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin_expense",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin_expense",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin_expense"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_income : IHashCreator { 
public string[] k   ={"idfin_income"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin_income",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin_income",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin_income"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 

public class HashCreator_idacc_debit : IHashCreator { 
public string[] k   ={"idacc_debit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_debit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_debit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_debit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_modulename : IHashCreator { 
public string[] k   ={"modulename"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["modulename",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("modulename",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["modulename"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_paramname_procedurename : IHashCreator { 
public string[] k   ={"paramname","procedurename"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["paramname",v].ToString(),r["procedurename",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="paramname")?proposedValue.ToString():r["paramname",v].ToString();
s += "§"+ ((field=="procedurename")?proposedValue.ToString():r["procedurename",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("paramname",o).ToString(),q.getField("procedurename",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["paramname"]??"").ToString(),(o["procedurename"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["paramname"].ToString(),childVal["procedurename"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["paramname"].ToString(),parentVal["procedurename"].ToString());
}
 } 
public class HashCreator_procedurename : IHashCreator { 
public string[] k   ={"procedurename"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["procedurename",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("procedurename",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["procedurename"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_fileformat : IHashCreator { 
public string[] k   ={"fileformat"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["fileformat",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("fileformat",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["fileformat"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcsa_import_idexp_idriep_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idexp","idriep","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idexp",v].ToString(),r["idriep",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idexp")?proposedValue.ToString():r["idexp",v].ToString());
s += "§"+ ((field=="idriep")?proposedValue.ToString():r["idriep",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idexp",o).ToString(),q.getField("idriep",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idexp"]??"").ToString(),(o["idriep"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idexp"].ToString(),childVal["idriep"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idexp"].ToString(),parentVal["idriep"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_import_idriep : IHashCreator { 
public string[] k   ={"idcsa_import","idriep"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idriep",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idriep")?proposedValue.ToString():r["idriep",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idriep",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idriep"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idriep"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idriep"].ToString());
}
 } 
public class HashCreator_idcsa_contractkind : IHashCreator { 
public string[] k   ={"idcsa_contractkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcsa_contractkind",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcsa_contractkind",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcsa_contractkind"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idcsa_contract : IHashCreator { 
public string[] k   ={"ayear","idcsa_contract"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contract",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contract")?proposedValue.ToString():r["idcsa_contract",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contract",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contract"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contract"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contract"].ToString());
}
 } 
public class HashCreator_idcsa_import : IHashCreator { 
public string[] k   ={"idcsa_import"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcsa_import",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcsa_import",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcsa_import"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcustomdirectrel : IHashCreator { 
public string[] k   ={"idcustomdirectrel"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcustomdirectrel",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcustomdirectrel",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcustomdirectrel"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idcsa_import_idver : IHashCreator { 
public string[] k   ={"idcsa_import","idver"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idver",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idver")?proposedValue.ToString():r["idver",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idver",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idver"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idver"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idver"].ToString());
}
 } 
public class HashCreator_idcsa_import_idriep_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idriep","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idriep",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idriep")?proposedValue.ToString():r["idriep",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idriep",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idriep"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idriep"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idriep"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_import_idver_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idver","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idver",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idver")?proposedValue.ToString():r["idver",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idver",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idver"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idver"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idver"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_bill_idcsa_import : IHashCreator { 
public string[] k   ={"idcsa_bill","idcsa_import"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_bill",v].ToString(),r["idcsa_import",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_bill")?proposedValue.ToString():r["idcsa_bill",v].ToString();
s += "§"+ ((field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_bill",o).ToString(),q.getField("idcsa_import",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_bill"]??"").ToString(),(o["idcsa_import"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_bill"].ToString(),childVal["idcsa_import"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_bill"].ToString(),parentVal["idcsa_import"].ToString());
}
 } 
public class HashCreator_ayear_idcsa_contractkind : IHashCreator { 
public string[] k   ={"ayear","idcsa_contractkind"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contractkind",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contractkind")?proposedValue.ToString():r["idcsa_contractkind",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contractkind",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contractkind"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contractkind"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contractkind"].ToString());
}
 } 
public class HashCreator_ayear_idcsa_contract_ndetail : IHashCreator { 
public string[] k   ={"ayear","idcsa_contract","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contract",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contract")?proposedValue.ToString():r["idcsa_contract",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contract",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contract"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contract"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contract"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_import_idinc_idriep_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idinc","idriep","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idinc",v].ToString(),r["idriep",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idinc")?proposedValue.ToString():r["idinc",v].ToString());
s += "§"+ ((field=="idriep")?proposedValue.ToString():r["idriep",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idinc",o).ToString(),q.getField("idriep",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idinc"]??"").ToString(),(o["idriep"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idinc"].ToString(),childVal["idriep"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idinc"].ToString(),parentVal["idriep"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcustomindirectrel : IHashCreator { 
public string[] k   ={"idcustomindirectrel"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcustomindirectrel",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcustomindirectrel",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcustomindirectrel"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idcsa_contract_idcsa_contracttax : IHashCreator { 
public string[] k   ={"ayear","idcsa_contract","idcsa_contracttax"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contract",v].ToString(),r["idcsa_contracttax",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contract")?proposedValue.ToString():r["idcsa_contract",v].ToString());
s += "§"+ ((field=="idcsa_contracttax")?proposedValue.ToString():r["idcsa_contracttax",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contract",o).ToString(),q.getField("idcsa_contracttax",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contract"]??"").ToString(),(o["idcsa_contracttax"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contract"].ToString(),childVal["idcsa_contracttax"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contract"].ToString(),parentVal["idcsa_contracttax"].ToString());
}
 } 
public class HashCreator_idcsa_agency_idcsa_agencypaymethod : IHashCreator { 
public string[] k   ={"idcsa_agency","idcsa_agencypaymethod"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_agency",v].ToString(),r["idcsa_agencypaymethod",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_agency")?proposedValue.ToString():r["idcsa_agency",v].ToString();
s += "§"+ ((field=="idcsa_agencypaymethod")?proposedValue.ToString():r["idcsa_agencypaymethod",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_agency",o).ToString(),q.getField("idcsa_agencypaymethod",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_agency"]??"").ToString(),(o["idcsa_agencypaymethod"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_agency"].ToString(),childVal["idcsa_agencypaymethod"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_agency"].ToString(),parentVal["idcsa_agencypaymethod"].ToString());
}
 } 
public class HashCreator_ayear_idcsa_incomesetup : IHashCreator { 
public string[] k   ={"ayear","idcsa_incomesetup"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_incomesetup",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_incomesetup")?proposedValue.ToString():r["idcsa_incomesetup",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_incomesetup",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_incomesetup"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_incomesetup"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_incomesetup"].ToString());
}
 } 
public class HashCreator_ayear_idcsa_contractkind_idcsa_contractkinddata : IHashCreator { 
public string[] k   ={"ayear","idcsa_contractkind","idcsa_contractkinddata"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contractkind",v].ToString(),r["idcsa_contractkinddata",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contractkind")?proposedValue.ToString():r["idcsa_contractkind",v].ToString());
s += "§"+ ((field=="idcsa_contractkinddata")?proposedValue.ToString():r["idcsa_contractkinddata",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contractkind",o).ToString(),q.getField("idcsa_contractkinddata",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contractkind"]??"").ToString(),(o["idcsa_contractkinddata"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contractkind"].ToString(),childVal["idcsa_contractkinddata"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contractkind"].ToString(),parentVal["idcsa_contractkinddata"].ToString());
}
 } 
public class HashCreator_idcsa_agency : IHashCreator { 
public string[] k   ={"idcsa_agency"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idcsa_agency",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idcsa_agency",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idcsa_agency"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idcsa_contract_idcsa_contracttax_ndetail : IHashCreator { 
public string[] k   ={"ayear","idcsa_contract","idcsa_contracttax","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contract",v].ToString(),r["idcsa_contracttax",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contract")?proposedValue.ToString():r["idcsa_contract",v].ToString());
s += "§"+ ((field=="idcsa_contracttax")?proposedValue.ToString():r["idcsa_contracttax",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contract",o).ToString(),q.getField("idcsa_contracttax",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contract"]??"").ToString(),(o["idcsa_contracttax"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contract"].ToString(),childVal["idcsa_contracttax"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contract"].ToString(),parentVal["idcsa_contracttax"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_import_idinc_idver_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idinc","idver","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idinc",v].ToString(),r["idver",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idinc")?proposedValue.ToString():r["idinc",v].ToString());
s += "§"+ ((field=="idver")?proposedValue.ToString():r["idver",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idinc",o).ToString(),q.getField("idver",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idinc"]??"").ToString(),(o["idver"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idinc"].ToString(),childVal["idver"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idinc"].ToString(),parentVal["idver"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idcsa_import_idexp_idver_ndetail : IHashCreator { 
public string[] k   ={"idcsa_import","idexp","idver","ndetail"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["idcsa_import",v].ToString(),r["idexp",v].ToString(),r["idver",v].ToString(),r["ndetail",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="idcsa_import")?proposedValue.ToString():r["idcsa_import",v].ToString();
s += "§"+ ((field=="idexp")?proposedValue.ToString():r["idexp",v].ToString());
s += "§"+ ((field=="idver")?proposedValue.ToString():r["idver",v].ToString());
s += "§"+ ((field=="ndetail")?proposedValue.ToString():r["ndetail",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("idcsa_import",o).ToString(),q.getField("idexp",o).ToString(),q.getField("idver",o).ToString(),q.getField("ndetail",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["idcsa_import"]??"").ToString(),(o["idexp"]??"").ToString(),(o["idver"]??"").ToString(),(o["ndetail"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["idcsa_import"].ToString(),childVal["idexp"].ToString(),childVal["idver"].ToString(),childVal["ndetail"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["idcsa_import"].ToString(),parentVal["idexp"].ToString(),parentVal["idver"].ToString(),parentVal["ndetail"].ToString());
}
 } 
public class HashCreator_idsor_siope_cost : IHashCreator { 
public string[] k   ={"idsor_siope_cost"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope_cost",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope_cost",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope_cost"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_cost : IHashCreator { 
public string[] k   ={"idacc_cost"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_cost",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_cost",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_cost"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_cost : IHashCreator { 
public string[] k   ={"idfin_cost"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin_cost",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin_cost",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin_cost"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idsor_siope_incomeclawback : IHashCreator { 
public string[] k   ={"idsor_siope_incomeclawback"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope_incomeclawback",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope_incomeclawback",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope_incomeclawback"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_revenue : IHashCreator { 
public string[] k   ={"idacc_revenue"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_revenue",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_revenue",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_revenue"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_incomeclawback : IHashCreator { 
public string[] k   ={"idfin_incomeclawback"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin_incomeclawback",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin_incomeclawback",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin_incomeclawback"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_internalcredit : IHashCreator { 
public string[] k   ={"idacc_internalcredit"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_internalcredit",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_internalcredit",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_internalcredit"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_ayear_idcsa_contractkind_idcsa_rule : IHashCreator { 
public string[] k   ={"ayear","idcsa_contractkind","idcsa_rule"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contractkind",v].ToString(),r["idcsa_rule",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contractkind")?proposedValue.ToString():r["idcsa_contractkind",v].ToString());
s += "§"+ ((field=="idcsa_rule")?proposedValue.ToString():r["idcsa_rule",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contractkind",o).ToString(),q.getField("idcsa_rule",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contractkind"]??"").ToString(),(o["idcsa_rule"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contractkind"].ToString(),childVal["idcsa_rule"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contractkind"].ToString(),parentVal["idcsa_rule"].ToString());
}
 } 
public class HashCreator_ayear_idcsa_contract_idcsa_registry : IHashCreator { 
public string[] k   ={"ayear","idcsa_contract","idcsa_registry"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return string.Join("§",r["ayear",v].ToString(),r["idcsa_contract",v].ToString(),r["idcsa_registry",v].ToString());
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
string s = (field=="ayear")?proposedValue.ToString():r["ayear",v].ToString();
s += "§"+ ((field=="idcsa_contract")?proposedValue.ToString():r["idcsa_contract",v].ToString());
s += "§"+ ((field=="idcsa_registry")?proposedValue.ToString():r["idcsa_registry",v].ToString());
return s;
}
public string getFromObject(object o) {
return string.Join("§",q.getField("ayear",o).ToString(),q.getField("idcsa_contract",o).ToString(),q.getField("idcsa_registry",o).ToString());
}
public string getFromDictionary(Dictionary<string,object>o) {
return string.Join("§",(o["ayear"]??"").ToString(),(o["idcsa_contract"]??"").ToString(),(o["idcsa_registry"]??"").ToString());
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var childVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ParentColumns.Length; i++) {
  childVal[rel.ChildColumns[i].ColumnName] = rParent[rel.ParentColumns[i].ColumnName,ver];
}
return string.Join("§",childVal["ayear"].ToString(),childVal["idcsa_contract"].ToString(),childVal["idcsa_registry"].ToString());
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
 var parentVal= new Dictionary<string, object>();
for (int i = 0; i < rel.ChildColumns.Length; i++) {
   parentVal[rel.ParentColumns[i].ColumnName] = rChild[rel.ChildColumns[i].ColumnName,ver];
}
return string.Join("§",parentVal["ayear"].ToString(),parentVal["idcsa_contract"].ToString(),parentVal["idcsa_registry"].ToString());
}
 } 
public class HashCreator_idsor_siope_main : IHashCreator { 
public string[] k   ={"idsor_siope_main"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idsor_siope_main",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idsor_siope_main",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idsor_siope_main"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idfin_main : IHashCreator { 
public string[] k   ={"idfin_main"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idfin_main",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idfin_main",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idfin_main"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 
public class HashCreator_idacc_main : IHashCreator { 
public string[] k   ={"idacc_main"};
public string []keys {get {return k;}}
public string get(DataRow r,DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return r["idacc_main",v].ToString();
}
public string get(DataRow r,string field, object proposedValue, DataRowVersion v=DataRowVersion.Default) {
  if (r.RowState == DataRowState.Deleted) v = DataRowVersion.Original;
return proposedValue.ToString();
}
public string getFromObject(object o) {
return q.getField("idacc_main",o).ToString();
}
public string getFromDictionary(Dictionary<string,object>o) {
return (o["idacc_main"]??"").ToString();
}
public string getChild(DataRow rParent,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rParent[rel.ParentColumns[0].ColumnName,ver].ToString();
}
public string getParent(DataRow rChild,DataRelation rel,DataRowVersion ver=DataRowVersion.Default) {
return rChild[rel.ChildColumns[0].ColumnName,ver].ToString();
}
 } 

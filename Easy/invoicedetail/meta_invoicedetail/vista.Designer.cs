
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_invoicedetail {
public class invoicedetailRow: MetaRow  {
	public invoicedetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 ninv{ 
		get {return  (Int32)this["ninv"];}
		set {this["ninv"]= value;}
	}
	public object ninvValue { 
		get{ return this["ninv"];}
		set {this["ninv"]= value;}
	}
	public Int32 ninvOriginal { 
		get {return  (Int32)this["ninv",DataRowVersion.Original];}
	}
	public Int32 rownum{ 
		get {return  (Int32)this["rownum"];}
		set {this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {this["rownum"]= value;}
	}
	public Int32 rownumOriginal { 
		get {return  (Int32)this["rownum",DataRowVersion.Original];}
	}
	public Int16 yinv{ 
		get {return  (Int16)this["yinv"];}
		set {this["yinv"]= value;}
	}
	public object yinvValue { 
		get{ return this["yinv"];}
		set {this["yinv"]= value;}
	}
	public Int16 yinvOriginal { 
		get {return  (Int16)this["yinv",DataRowVersion.Original];}
	}
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	public DateTime? competencystart{ 
		get {if (this["competencystart"]==DBNull.Value)return null; return  (DateTime?)this["competencystart"];}
		set {if (value==null) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public object competencystartValue { 
		get{ return this["competencystart"];}
		set {if (value==null|| value==DBNull.Value) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public DateTime? competencystartOriginal { 
		get {if (this["competencystart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystart",DataRowVersion.Original];}
	}
	public DateTime? paymentcompetency{ 
		get {if (this["paymentcompetency"]==DBNull.Value)return null; return  (DateTime?)this["paymentcompetency"];}
		set {if (value==null) this["paymentcompetency"]= DBNull.Value; else this["paymentcompetency"]= value;}
	}
	public object paymentcompetencyValue { 
		get{ return this["paymentcompetency"];}
		set {if (value==null|| value==DBNull.Value) this["paymentcompetency"]= DBNull.Value; else this["paymentcompetency"]= value;}
	}
	public DateTime? paymentcompetencyOriginal { 
		get {if (this["paymentcompetency",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["paymentcompetency",DataRowVersion.Original];}
	}
	public DateTime? competencystop{ 
		get {if (this["competencystop"]==DBNull.Value)return null; return  (DateTime?)this["competencystop"];}
		set {if (value==null) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public object competencystopValue { 
		get{ return this["competencystop"];}
		set {if (value==null|| value==DBNull.Value) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public DateTime? competencystopOriginal { 
		get {if (this["competencystop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystop",DataRowVersion.Original];}
	}
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	public String detaildescription{ 
		get {if (this["detaildescription"]==DBNull.Value)return null; return  (String)this["detaildescription"];}
		set {if (value==null) this["detaildescription"]= DBNull.Value; else this["detaildescription"]= value;}
	}
	public object detaildescriptionValue { 
		get{ return this["detaildescription"];}
		set {if (value==null|| value==DBNull.Value) this["detaildescription"]= DBNull.Value; else this["detaildescription"]= value;}
	}
	public String detaildescriptionOriginal { 
		get {if (this["detaildescription",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["detaildescription",DataRowVersion.Original];}
	}
	public Double? discount{ 
		get {if (this["discount"]==DBNull.Value)return null; return  (Double?)this["discount"];}
		set {if (value==null) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public object discountValue { 
		get{ return this["discount"];}
		set {if (value==null|| value==DBNull.Value) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public Double? discountOriginal { 
		get {if (this["discount",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["discount",DataRowVersion.Original];}
	}
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
	}
	public String idmankind{ 
		get {if (this["idmankind"]==DBNull.Value)return null; return  (String)this["idmankind"];}
		set {if (value==null) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public object idmankindValue { 
		get{ return this["idmankind"];}
		set {if (value==null|| value==DBNull.Value) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public String idmankindOriginal { 
		get {if (this["idmankind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmankind",DataRowVersion.Original];}
	}
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
	}
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	public Int32? manrownum{ 
		get {if (this["manrownum"]==DBNull.Value)return null; return  (Int32?)this["manrownum"];}
		set {if (value==null) this["manrownum"]= DBNull.Value; else this["manrownum"]= value;}
	}
	public object manrownumValue { 
		get{ return this["manrownum"];}
		set {if (value==null|| value==DBNull.Value) this["manrownum"]= DBNull.Value; else this["manrownum"]= value;}
	}
	public Int32? manrownumOriginal { 
		get {if (this["manrownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["manrownum",DataRowVersion.Original];}
	}
	public Int32? nman{ 
		get {if (this["nman"]==DBNull.Value)return null; return  (Int32?)this["nman"];}
		set {if (value==null) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public object nmanValue { 
		get{ return this["nman"];}
		set {if (value==null|| value==DBNull.Value) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public Int32? nmanOriginal { 
		get {if (this["nman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nman",DataRowVersion.Original];}
	}
	public Decimal? number{ 
		get {if (this["number"]==DBNull.Value)return null; return  (Decimal?)this["number"];}
		set {if (value==null) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public object numberValue { 
		get{ return this["number"];}
		set {if (value==null|| value==DBNull.Value) this["number"]= DBNull.Value; else this["number"]= value;}
	}
	public Decimal? numberOriginal { 
		get {if (this["number",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["number",DataRowVersion.Original];}
	}
	public Decimal? tax{ 
		get {if (this["tax"]==DBNull.Value)return null; return  (Decimal?)this["tax"];}
		set {if (value==null) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public object taxValue { 
		get{ return this["tax"];}
		set {if (value==null|| value==DBNull.Value) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public Decimal? taxOriginal { 
		get {if (this["tax",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["tax",DataRowVersion.Original];}
	}
	public Decimal? taxable{ 
		get {if (this["taxable"]==DBNull.Value)return null; return  (Decimal?)this["taxable"];}
		set {if (value==null) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public object taxableValue { 
		get{ return this["taxable"];}
		set {if (value==null|| value==DBNull.Value) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public Decimal? taxableOriginal { 
		get {if (this["taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["taxable",DataRowVersion.Original];}
	}
	public Decimal? unabatable{ 
		get {if (this["unabatable"]==DBNull.Value)return null; return  (Decimal?)this["unabatable"];}
		set {if (value==null) this["unabatable"]= DBNull.Value; else this["unabatable"]= value;}
	}
	public object unabatableValue { 
		get{ return this["unabatable"];}
		set {if (value==null|| value==DBNull.Value) this["unabatable"]= DBNull.Value; else this["unabatable"]= value;}
	}
	public Decimal? unabatableOriginal { 
		get {if (this["unabatable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["unabatable",DataRowVersion.Original];}
	}
	public Int16? yman{ 
		get {if (this["yman"]==DBNull.Value)return null; return  (Int16?)this["yman"];}
		set {if (value==null) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public object ymanValue { 
		get{ return this["yman"];}
		set {if (value==null|| value==DBNull.Value) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public Int16? ymanOriginal { 
		get {if (this["yman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yman",DataRowVersion.Original];}
	}
	public String idestimkind{ 
		get {if (this["idestimkind"]==DBNull.Value)return null; return  (String)this["idestimkind"];}
		set {if (value==null) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public object idestimkindValue { 
		get{ return this["idestimkind"];}
		set {if (value==null|| value==DBNull.Value) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public String idestimkindOriginal { 
		get {if (this["idestimkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idestimkind",DataRowVersion.Original];}
	}
	public Int32? estimrownum{ 
		get {if (this["estimrownum"]==DBNull.Value)return null; return  (Int32?)this["estimrownum"];}
		set {if (value==null) this["estimrownum"]= DBNull.Value; else this["estimrownum"]= value;}
	}
	public object estimrownumValue { 
		get{ return this["estimrownum"];}
		set {if (value==null|| value==DBNull.Value) this["estimrownum"]= DBNull.Value; else this["estimrownum"]= value;}
	}
	public Int32? estimrownumOriginal { 
		get {if (this["estimrownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["estimrownum",DataRowVersion.Original];}
	}
	public Int32? nestim{ 
		get {if (this["nestim"]==DBNull.Value)return null; return  (Int32?)this["nestim"];}
		set {if (value==null) this["nestim"]= DBNull.Value; else this["nestim"]= value;}
	}
	public object nestimValue { 
		get{ return this["nestim"];}
		set {if (value==null|| value==DBNull.Value) this["nestim"]= DBNull.Value; else this["nestim"]= value;}
	}
	public Int32? nestimOriginal { 
		get {if (this["nestim",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nestim",DataRowVersion.Original];}
	}
	public Int16? yestim{ 
		get {if (this["yestim"]==DBNull.Value)return null; return  (Int16?)this["yestim"];}
		set {if (value==null) this["yestim"]= DBNull.Value; else this["yestim"]= value;}
	}
	public object yestimValue { 
		get{ return this["yestim"];}
		set {if (value==null|| value==DBNull.Value) this["yestim"]= DBNull.Value; else this["yestim"]= value;}
	}
	public Int16? yestimOriginal { 
		get {if (this["yestim",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yestim",DataRowVersion.Original];}
	}
	public Int32? idgroup{ 
		get {if (this["idgroup"]==DBNull.Value)return null; return  (Int32?)this["idgroup"];}
		set {if (value==null) this["idgroup"]= DBNull.Value; else this["idgroup"]= value;}
	}
	public object idgroupValue { 
		get{ return this["idgroup"];}
		set {if (value==null|| value==DBNull.Value) this["idgroup"]= DBNull.Value; else this["idgroup"]= value;}
	}
	public Int32? idgroupOriginal { 
		get {if (this["idgroup",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgroup",DataRowVersion.Original];}
	}
	public Int32? idexp_taxable{ 
		get {if (this["idexp_taxable"]==DBNull.Value)return null; return  (Int32?)this["idexp_taxable"];}
		set {if (value==null) this["idexp_taxable"]= DBNull.Value; else this["idexp_taxable"]= value;}
	}
	public object idexp_taxableValue { 
		get{ return this["idexp_taxable"];}
		set {if (value==null|| value==DBNull.Value) this["idexp_taxable"]= DBNull.Value; else this["idexp_taxable"]= value;}
	}
	public Int32? idexp_taxableOriginal { 
		get {if (this["idexp_taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp_taxable",DataRowVersion.Original];}
	}
	public Int32? idexp_iva{ 
		get {if (this["idexp_iva"]==DBNull.Value)return null; return  (Int32?)this["idexp_iva"];}
		set {if (value==null) this["idexp_iva"]= DBNull.Value; else this["idexp_iva"]= value;}
	}
	public object idexp_ivaValue { 
		get{ return this["idexp_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idexp_iva"]= DBNull.Value; else this["idexp_iva"]= value;}
	}
	public Int32? idexp_ivaOriginal { 
		get {if (this["idexp_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp_iva",DataRowVersion.Original];}
	}
	public Int32? idinc_taxable{ 
		get {if (this["idinc_taxable"]==DBNull.Value)return null; return  (Int32?)this["idinc_taxable"];}
		set {if (value==null) this["idinc_taxable"]= DBNull.Value; else this["idinc_taxable"]= value;}
	}
	public object idinc_taxableValue { 
		get{ return this["idinc_taxable"];}
		set {if (value==null|| value==DBNull.Value) this["idinc_taxable"]= DBNull.Value; else this["idinc_taxable"]= value;}
	}
	public Int32? idinc_taxableOriginal { 
		get {if (this["idinc_taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc_taxable",DataRowVersion.Original];}
	}
	public Int32? idinc_iva{ 
		get {if (this["idinc_iva"]==DBNull.Value)return null; return  (Int32?)this["idinc_iva"];}
		set {if (value==null) this["idinc_iva"]= DBNull.Value; else this["idinc_iva"]= value;}
	}
	public object idinc_ivaValue { 
		get{ return this["idinc_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idinc_iva"]= DBNull.Value; else this["idinc_iva"]= value;}
	}
	public Int32? idinc_ivaOriginal { 
		get {if (this["idinc_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc_iva",DataRowVersion.Original];}
	}
	public Int32? ninv_main{ 
		get {if (this["ninv_main"]==DBNull.Value)return null; return  (Int32?)this["ninv_main"];}
		set {if (value==null) this["ninv_main"]= DBNull.Value; else this["ninv_main"]= value;}
	}
	public object ninv_mainValue { 
		get{ return this["ninv_main"];}
		set {if (value==null|| value==DBNull.Value) this["ninv_main"]= DBNull.Value; else this["ninv_main"]= value;}
	}
	public Int32? ninv_mainOriginal { 
		get {if (this["ninv_main",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv_main",DataRowVersion.Original];}
	}
	public Int16? yinv_main{ 
		get {if (this["yinv_main"]==DBNull.Value)return null; return  (Int16?)this["yinv_main"];}
		set {if (value==null) this["yinv_main"]= DBNull.Value; else this["yinv_main"]= value;}
	}
	public object yinv_mainValue { 
		get{ return this["yinv_main"];}
		set {if (value==null|| value==DBNull.Value) this["yinv_main"]= DBNull.Value; else this["yinv_main"]= value;}
	}
	public Int16? yinv_mainOriginal { 
		get {if (this["yinv_main",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv_main",DataRowVersion.Original];}
	}
	public Int32 idivakind{ 
		get {return  (Int32)this["idivakind"];}
		set {this["idivakind"]= value;}
	}
	public object idivakindValue { 
		get{ return this["idivakind"];}
		set {this["idivakind"]= value;}
	}
	public Int32 idivakindOriginal { 
		get {return  (Int32)this["idivakind",DataRowVersion.Original];}
	}
	public Int32 idinvkind{ 
		get {return  (Int32)this["idinvkind"];}
		set {this["idinvkind"]= value;}
	}
	public object idinvkindValue { 
		get{ return this["idinvkind"];}
		set {this["idinvkind"]= value;}
	}
	public Int32 idinvkindOriginal { 
		get {return  (Int32)this["idinvkind",DataRowVersion.Original];}
	}
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
	}
	public Int32? idintrastatcode{ 
		get {if (this["idintrastatcode"]==DBNull.Value)return null; return  (Int32?)this["idintrastatcode"];}
		set {if (value==null) this["idintrastatcode"]= DBNull.Value; else this["idintrastatcode"]= value;}
	}
	public object idintrastatcodeValue { 
		get{ return this["idintrastatcode"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatcode"]= DBNull.Value; else this["idintrastatcode"]= value;}
	}
	public Int32? idintrastatcodeOriginal { 
		get {if (this["idintrastatcode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idintrastatcode",DataRowVersion.Original];}
	}
	public Int32? idintrastatmeasure{ 
		get {if (this["idintrastatmeasure"]==DBNull.Value)return null; return  (Int32?)this["idintrastatmeasure"];}
		set {if (value==null) this["idintrastatmeasure"]= DBNull.Value; else this["idintrastatmeasure"]= value;}
	}
	public object idintrastatmeasureValue { 
		get{ return this["idintrastatmeasure"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatmeasure"]= DBNull.Value; else this["idintrastatmeasure"]= value;}
	}
	public Int32? idintrastatmeasureOriginal { 
		get {if (this["idintrastatmeasure",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idintrastatmeasure",DataRowVersion.Original];}
	}
	public Decimal? weight{ 
		get {if (this["weight"]==DBNull.Value)return null; return  (Decimal?)this["weight"];}
		set {if (value==null) this["weight"]= DBNull.Value; else this["weight"]= value;}
	}
	public object weightValue { 
		get{ return this["weight"];}
		set {if (value==null|| value==DBNull.Value) this["weight"]= DBNull.Value; else this["weight"]= value;}
	}
	public Decimal? weightOriginal { 
		get {if (this["weight",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["weight",DataRowVersion.Original];}
	}
	public String va3type{ 
		get {if (this["va3type"]==DBNull.Value)return null; return  (String)this["va3type"];}
		set {if (value==null) this["va3type"]= DBNull.Value; else this["va3type"]= value;}
	}
	public object va3typeValue { 
		get{ return this["va3type"];}
		set {if (value==null|| value==DBNull.Value) this["va3type"]= DBNull.Value; else this["va3type"]= value;}
	}
	public String va3typeOriginal { 
		get {if (this["va3type",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["va3type",DataRowVersion.Original];}
	}
	public String intrastatoperationkind{ 
		get {if (this["intrastatoperationkind"]==DBNull.Value)return null; return  (String)this["intrastatoperationkind"];}
		set {if (value==null) this["intrastatoperationkind"]= DBNull.Value; else this["intrastatoperationkind"]= value;}
	}
	public object intrastatoperationkindValue { 
		get{ return this["intrastatoperationkind"];}
		set {if (value==null|| value==DBNull.Value) this["intrastatoperationkind"]= DBNull.Value; else this["intrastatoperationkind"]= value;}
	}
	public String intrastatoperationkindOriginal { 
		get {if (this["intrastatoperationkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["intrastatoperationkind",DataRowVersion.Original];}
	}
	public Int32? idintrastatservice{ 
		get {if (this["idintrastatservice"]==DBNull.Value)return null; return  (Int32?)this["idintrastatservice"];}
		set {if (value==null) this["idintrastatservice"]= DBNull.Value; else this["idintrastatservice"]= value;}
	}
	public object idintrastatserviceValue { 
		get{ return this["idintrastatservice"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatservice"]= DBNull.Value; else this["idintrastatservice"]= value;}
	}
	public Int32? idintrastatserviceOriginal { 
		get {if (this["idintrastatservice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idintrastatservice",DataRowVersion.Original];}
	}
	public Int32? idintrastatsupplymethod{ 
		get {if (this["idintrastatsupplymethod"]==DBNull.Value)return null; return  (Int32?)this["idintrastatsupplymethod"];}
		set {if (value==null) this["idintrastatsupplymethod"]= DBNull.Value; else this["idintrastatsupplymethod"]= value;}
	}
	public object idintrastatsupplymethodValue { 
		get{ return this["idintrastatsupplymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idintrastatsupplymethod"]= DBNull.Value; else this["idintrastatsupplymethod"]= value;}
	}
	public Int32? idintrastatsupplymethodOriginal { 
		get {if (this["idintrastatsupplymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idintrastatsupplymethod",DataRowVersion.Original];}
	}
	public Int32? idlist{ 
		get {if (this["idlist"]==DBNull.Value)return null; return  (Int32?)this["idlist"];}
		set {if (value==null) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public object idlistValue { 
		get{ return this["idlist"];}
		set {if (value==null|| value==DBNull.Value) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public Int32? idlistOriginal { 
		get {if (this["idlist",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlist",DataRowVersion.Original];}
	}
	public Int32? idunit{ 
		get {if (this["idunit"]==DBNull.Value)return null; return  (Int32?)this["idunit"];}
		set {if (value==null) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public object idunitValue { 
		get{ return this["idunit"];}
		set {if (value==null|| value==DBNull.Value) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public Int32? idunitOriginal { 
		get {if (this["idunit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunit",DataRowVersion.Original];}
	}
	public Int32? idpackage{ 
		get {if (this["idpackage"]==DBNull.Value)return null; return  (Int32?)this["idpackage"];}
		set {if (value==null) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public object idpackageValue { 
		get{ return this["idpackage"];}
		set {if (value==null|| value==DBNull.Value) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public Int32? idpackageOriginal { 
		get {if (this["idpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpackage",DataRowVersion.Original];}
	}
	public Int32? unitsforpackage{ 
		get {if (this["unitsforpackage"]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage"];}
		set {if (value==null) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public object unitsforpackageValue { 
		get{ return this["unitsforpackage"];}
		set {if (value==null|| value==DBNull.Value) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public Int32? unitsforpackageOriginal { 
		get {if (this["unitsforpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage",DataRowVersion.Original];}
	}
	public Decimal? npackage{ 
		get {if (this["npackage"]==DBNull.Value)return null; return  (Decimal?)this["npackage"];}
		set {if (value==null) this["npackage"]= DBNull.Value; else this["npackage"]= value;}
	}
	public object npackageValue { 
		get{ return this["npackage"];}
		set {if (value==null|| value==DBNull.Value) this["npackage"]= DBNull.Value; else this["npackage"]= value;}
	}
	public Decimal? npackageOriginal { 
		get {if (this["npackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["npackage",DataRowVersion.Original];}
	}
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	public String exception12{ 
		get {if (this["exception12"]==DBNull.Value)return null; return  (String)this["exception12"];}
		set {if (value==null) this["exception12"]= DBNull.Value; else this["exception12"]= value;}
	}
	public object exception12Value { 
		get{ return this["exception12"];}
		set {if (value==null|| value==DBNull.Value) this["exception12"]= DBNull.Value; else this["exception12"]= value;}
	}
	public String exception12Original { 
		get {if (this["exception12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["exception12",DataRowVersion.Original];}
	}
	public String intra12operationkind{ 
		get {if (this["intra12operationkind"]==DBNull.Value)return null; return  (String)this["intra12operationkind"];}
		set {if (value==null) this["intra12operationkind"]= DBNull.Value; else this["intra12operationkind"]= value;}
	}
	public object intra12operationkindValue { 
		get{ return this["intra12operationkind"];}
		set {if (value==null|| value==DBNull.Value) this["intra12operationkind"]= DBNull.Value; else this["intra12operationkind"]= value;}
	}
	public String intra12operationkindOriginal { 
		get {if (this["intra12operationkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["intra12operationkind",DataRowVersion.Original];}
	}
	public String move12{ 
		get {if (this["move12"]==DBNull.Value)return null; return  (String)this["move12"];}
		set {if (value==null) this["move12"]= DBNull.Value; else this["move12"]= value;}
	}
	public object move12Value { 
		get{ return this["move12"];}
		set {if (value==null|| value==DBNull.Value) this["move12"]= DBNull.Value; else this["move12"]= value;}
	}
	public String move12Original { 
		get {if (this["move12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["move12",DataRowVersion.Original];}
	}
	public String idupb_iva{ 
		get {if (this["idupb_iva"]==DBNull.Value)return null; return  (String)this["idupb_iva"];}
		set {if (value==null) this["idupb_iva"]= DBNull.Value; else this["idupb_iva"]= value;}
	}
	public object idupb_ivaValue { 
		get{ return this["idupb_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idupb_iva"]= DBNull.Value; else this["idupb_iva"]= value;}
	}
	public String idupb_ivaOriginal { 
		get {if (this["idupb_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb_iva",DataRowVersion.Original];}
	}
	public Int32? idinvkind_main{ 
		get {if (this["idinvkind_main"]==DBNull.Value)return null; return  (Int32?)this["idinvkind_main"];}
		set {if (value==null) this["idinvkind_main"]= DBNull.Value; else this["idinvkind_main"]= value;}
	}
	public object idinvkind_mainValue { 
		get{ return this["idinvkind_main"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind_main"]= DBNull.Value; else this["idinvkind_main"]= value;}
	}
	public Int32? idinvkind_mainOriginal { 
		get {if (this["idinvkind_main",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind_main",DataRowVersion.Original];}
	}
	public String leasing{ 
		get {if (this["leasing"]==DBNull.Value)return null; return  (String)this["leasing"];}
		set {if (value==null) this["leasing"]= DBNull.Value; else this["leasing"]= value;}
	}
	public object leasingValue { 
		get{ return this["leasing"];}
		set {if (value==null|| value==DBNull.Value) this["leasing"]= DBNull.Value; else this["leasing"]= value;}
	}
	public String leasingOriginal { 
		get {if (this["leasing",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["leasing",DataRowVersion.Original];}
	}
	public String usedmodesospesometro{ 
		get {if (this["usedmodesospesometro"]==DBNull.Value)return null; return  (String)this["usedmodesospesometro"];}
		set {if (value==null) this["usedmodesospesometro"]= DBNull.Value; else this["usedmodesospesometro"]= value;}
	}
	public object usedmodesospesometroValue { 
		get{ return this["usedmodesospesometro"];}
		set {if (value==null|| value==DBNull.Value) this["usedmodesospesometro"]= DBNull.Value; else this["usedmodesospesometro"]= value;}
	}
	public String usedmodesospesometroOriginal { 
		get {if (this["usedmodesospesometro",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["usedmodesospesometro",DataRowVersion.Original];}
	}
	public String resetresidualmandate{ 
		get {if (this["resetresidualmandate"]==DBNull.Value)return null; return  (String)this["resetresidualmandate"];}
		set {if (value==null) this["resetresidualmandate"]= DBNull.Value; else this["resetresidualmandate"]= value;}
	}
	public object resetresidualmandateValue { 
		get{ return this["resetresidualmandate"];}
		set {if (value==null|| value==DBNull.Value) this["resetresidualmandate"]= DBNull.Value; else this["resetresidualmandate"]= value;}
	}
	public String resetresidualmandateOriginal { 
		get {if (this["resetresidualmandate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["resetresidualmandate",DataRowVersion.Original];}
	}
	public String idfetransfer{ 
		get {if (this["idfetransfer"]==DBNull.Value)return null; return  (String)this["idfetransfer"];}
		set {if (value==null) this["idfetransfer"]= DBNull.Value; else this["idfetransfer"]= value;}
	}
	public object idfetransferValue { 
		get{ return this["idfetransfer"];}
		set {if (value==null|| value==DBNull.Value) this["idfetransfer"]= DBNull.Value; else this["idfetransfer"]= value;}
	}
	public String idfetransferOriginal { 
		get {if (this["idfetransfer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfetransfer",DataRowVersion.Original];}
	}
	public String fereferencerule{ 
		get {if (this["fereferencerule"]==DBNull.Value)return null; return  (String)this["fereferencerule"];}
		set {if (value==null) this["fereferencerule"]= DBNull.Value; else this["fereferencerule"]= value;}
	}
	public object fereferenceruleValue { 
		get{ return this["fereferencerule"];}
		set {if (value==null|| value==DBNull.Value) this["fereferencerule"]= DBNull.Value; else this["fereferencerule"]= value;}
	}
	public String fereferenceruleOriginal { 
		get {if (this["fereferencerule",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fereferencerule",DataRowVersion.Original];}
	}
	public String cupcode{ 
		get {if (this["cupcode"]==DBNull.Value)return null; return  (String)this["cupcode"];}
		set {if (value==null) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public object cupcodeValue { 
		get{ return this["cupcode"];}
		set {if (value==null|| value==DBNull.Value) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public String cupcodeOriginal { 
		get {if (this["cupcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cupcode",DataRowVersion.Original];}
	}
	public String cigcode{ 
		get {if (this["cigcode"]==DBNull.Value)return null; return  (String)this["cigcode"];}
		set {if (value==null) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public object cigcodeValue { 
		get{ return this["cigcode"];}
		set {if (value==null|| value==DBNull.Value) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public String cigcodeOriginal { 
		get {if (this["cigcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cigcode",DataRowVersion.Original];}
	}
	public String idpccdebitstatus{ 
		get {if (this["idpccdebitstatus"]==DBNull.Value)return null; return  (String)this["idpccdebitstatus"];}
		set {if (value==null) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public object idpccdebitstatusValue { 
		get{ return this["idpccdebitstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public String idpccdebitstatusOriginal { 
		get {if (this["idpccdebitstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpccdebitstatus",DataRowVersion.Original];}
	}
	public String idpccdebitmotive{ 
		get {if (this["idpccdebitmotive"]==DBNull.Value)return null; return  (String)this["idpccdebitmotive"];}
		set {if (value==null) this["idpccdebitmotive"]= DBNull.Value; else this["idpccdebitmotive"]= value;}
	}
	public object idpccdebitmotiveValue { 
		get{ return this["idpccdebitmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idpccdebitmotive"]= DBNull.Value; else this["idpccdebitmotive"]= value;}
	}
	public String idpccdebitmotiveOriginal { 
		get {if (this["idpccdebitmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpccdebitmotive",DataRowVersion.Original];}
	}
	public Int32? idcostpartition{ 
		get {if (this["idcostpartition"]==DBNull.Value)return null; return  (Int32?)this["idcostpartition"];}
		set {if (value==null) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public object idcostpartitionValue { 
		get{ return this["idcostpartition"];}
		set {if (value==null|| value==DBNull.Value) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public Int32? idcostpartitionOriginal { 
		get {if (this["idcostpartition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcostpartition",DataRowVersion.Original];}
	}
	public String expensekind{ 
		get {if (this["expensekind"]==DBNull.Value)return null; return  (String)this["expensekind"];}
		set {if (value==null) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public object expensekindValue { 
		get{ return this["expensekind"];}
		set {if (value==null|| value==DBNull.Value) this["expensekind"]= DBNull.Value; else this["expensekind"]= value;}
	}
	public String expensekindOriginal { 
		get {if (this["expensekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["expensekind",DataRowVersion.Original];}
	}
	public String rounding{ 
		get {if (this["rounding"]==DBNull.Value)return null; return  (String)this["rounding"];}
		set {if (value==null) this["rounding"]= DBNull.Value; else this["rounding"]= value;}
	}
	public object roundingValue { 
		get{ return this["rounding"];}
		set {if (value==null|| value==DBNull.Value) this["rounding"]= DBNull.Value; else this["rounding"]= value;}
	}
	public String roundingOriginal { 
		get {if (this["rounding",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rounding",DataRowVersion.Original];}
	}
	public Int32? idepexp{ 
		get {if (this["idepexp"]==DBNull.Value)return null; return  (Int32?)this["idepexp"];}
		set {if (value==null) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public object idepexpValue { 
		get{ return this["idepexp"];}
		set {if (value==null|| value==DBNull.Value) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public Int32? idepexpOriginal { 
		get {if (this["idepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepexp",DataRowVersion.Original];}
	}
	public Int32? idepacc{ 
		get {if (this["idepacc"]==DBNull.Value)return null; return  (Int32?)this["idepacc"];}
		set {if (value==null) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public object idepaccValue { 
		get{ return this["idepacc"];}
		set {if (value==null|| value==DBNull.Value) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public Int32? idepaccOriginal { 
		get {if (this["idepacc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepacc",DataRowVersion.Original];}
	}
	public Byte? flagbit{ 
		get {if (this["flagbit"]==DBNull.Value)return null; return  (Byte?)this["flagbit"];}
		set {if (value==null) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public object flagbitValue { 
		get{ return this["flagbit"];}
		set {if (value==null|| value==DBNull.Value) this["flagbit"]= DBNull.Value; else this["flagbit"]= value;}
	}
	public Byte? flagbitOriginal { 
		get {if (this["flagbit",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flagbit",DataRowVersion.Original];}
	}
	public String idfinmotive{ 
		get {if (this["idfinmotive"]==DBNull.Value)return null; return  (String)this["idfinmotive"];}
		set {if (value==null) this["idfinmotive"]= DBNull.Value; else this["idfinmotive"]= value;}
	}
	public object idfinmotiveValue { 
		get{ return this["idfinmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idfinmotive"]= DBNull.Value; else this["idfinmotive"]= value;}
	}
	public String idfinmotiveOriginal { 
		get {if (this["idfinmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfinmotive",DataRowVersion.Original];}
	}
	public String iduniqueformcode{ 
		get {if (this["iduniqueformcode"]==DBNull.Value)return null; return  (String)this["iduniqueformcode"];}
		set {if (value==null) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public object iduniqueformcodeValue { 
		get{ return this["iduniqueformcode"];}
		set {if (value==null|| value==DBNull.Value) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public String iduniqueformcodeOriginal { 
		get {if (this["iduniqueformcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iduniqueformcode",DataRowVersion.Original];}
	}
	public Int32? ycon{ 
		get {if (this["ycon"]==DBNull.Value)return null; return  (Int32?)this["ycon"];}
		set {if (value==null) this["ycon"]= DBNull.Value; else this["ycon"]= value;}
	}
	public object yconValue { 
		get{ return this["ycon"];}
		set {if (value==null|| value==DBNull.Value) this["ycon"]= DBNull.Value; else this["ycon"]= value;}
	}
	public Int32? yconOriginal { 
		get {if (this["ycon",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ycon",DataRowVersion.Original];}
	}
	public Int32? ncon{ 
		get {if (this["ncon"]==DBNull.Value)return null; return  (Int32?)this["ncon"];}
		set {if (value==null) this["ncon"]= DBNull.Value; else this["ncon"]= value;}
	}
	public object nconValue { 
		get{ return this["ncon"];}
		set {if (value==null|| value==DBNull.Value) this["ncon"]= DBNull.Value; else this["ncon"]= value;}
	}
	public Int32? nconOriginal { 
		get {if (this["ncon",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ncon",DataRowVersion.Original];}
	}
	public String codicetipo{ 
		get {if (this["codicetipo"]==DBNull.Value)return null; return  (String)this["codicetipo"];}
		set {if (value==null) this["codicetipo"]= DBNull.Value; else this["codicetipo"]= value;}
	}
	public object codicetipoValue { 
		get{ return this["codicetipo"];}
		set {if (value==null|| value==DBNull.Value) this["codicetipo"]= DBNull.Value; else this["codicetipo"]= value;}
	}
	public String codicetipoOriginal { 
		get {if (this["codicetipo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicetipo",DataRowVersion.Original];}
	}
	public String codicevalore{ 
		get {if (this["codicevalore"]==DBNull.Value)return null; return  (String)this["codicevalore"];}
		set {if (value==null) this["codicevalore"]= DBNull.Value; else this["codicevalore"]= value;}
	}
	public object codicevaloreValue { 
		get{ return this["codicevalore"];}
		set {if (value==null|| value==DBNull.Value) this["codicevalore"]= DBNull.Value; else this["codicevalore"]= value;}
	}
	public String codicevaloreOriginal { 
		get {if (this["codicevalore",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicevalore",DataRowVersion.Original];}
	}
	public Int32? idsor_siope{ 
		get {if (this["idsor_siope"]==DBNull.Value)return null; return  (Int32?)this["idsor_siope"];}
		set {if (value==null) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public object idsor_siopeValue { 
		get{ return this["idsor_siope"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public Int32? idsor_siopeOriginal { 
		get {if (this["idsor_siope",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siope",DataRowVersion.Original];}
	}
	public Int32? idepexp_pre{ 
		get {if (this["idepexp_pre"]==DBNull.Value)return null; return  (Int32?)this["idepexp_pre"];}
		set {if (value==null) this["idepexp_pre"]= DBNull.Value; else this["idepexp_pre"]= value;}
	}
	public object idepexp_preValue { 
		get{ return this["idepexp_pre"];}
		set {if (value==null|| value==DBNull.Value) this["idepexp_pre"]= DBNull.Value; else this["idepexp_pre"]= value;}
	}
	public Int32? idepexp_preOriginal { 
		get {if (this["idepexp_pre",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepexp_pre",DataRowVersion.Original];}
	}
	public Int32? idtassonomia{ 
		get {if (this["idtassonomia"]==DBNull.Value)return null; return  (Int32?)this["idtassonomia"];}
		set {if (value==null) this["idtassonomia"]= DBNull.Value; else this["idtassonomia"]= value;}
	}
	public object idtassonomiaValue { 
		get{ return this["idtassonomia"];}
		set {if (value==null|| value==DBNull.Value) this["idtassonomia"]= DBNull.Value; else this["idtassonomia"]= value;}
	}
	public Int32? idtassonomiaOriginal { 
		get {if (this["idtassonomia",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtassonomia",DataRowVersion.Original];}
	}
	public String idfinmotive_iva{ 
		get {if (this["idfinmotive_iva"]==DBNull.Value)return null; return  (String)this["idfinmotive_iva"];}
		set {if (value==null) this["idfinmotive_iva"]= DBNull.Value; else this["idfinmotive_iva"]= value;}
	}
	public object idfinmotive_ivaValue { 
		get{ return this["idfinmotive_iva"];}
		set {if (value==null|| value==DBNull.Value) this["idfinmotive_iva"]= DBNull.Value; else this["idfinmotive_iva"]= value;}
	}
	public String idfinmotive_ivaOriginal { 
		get {if (this["idfinmotive_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfinmotive_iva",DataRowVersion.Original];}
	}
	public Int32? rownum_main{ 
		get {if (this["rownum_main"]==DBNull.Value)return null; return  (Int32?)this["rownum_main"];}
		set {if (value==null) this["rownum_main"]= DBNull.Value; else this["rownum_main"]= value;}
	}
	public object rownum_mainValue { 
		get{ return this["rownum_main"];}
		set {if (value==null|| value==DBNull.Value) this["rownum_main"]= DBNull.Value; else this["rownum_main"]= value;}
	}
	public Int32? rownum_mainOriginal { 
		get {if (this["rownum_main",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum_main",DataRowVersion.Original];}
	}
	#endregion

}
public class invoicedetailTable : MetaTableBase<invoicedetailRow> {
	public invoicedetailTable() : base("invoicedetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ninv",createColumn("ninv",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),false,false)},
			{"yinv",createColumn("yinv",typeof(short),false,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"paymentcompetency",createColumn("paymentcompetency",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"detaildescription",createColumn("detaildescription",typeof(string),true,false)},
			{"discount",createColumn("discount",typeof(double),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idmankind",createColumn("idmankind",typeof(string),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"manrownum",createColumn("manrownum",typeof(int),true,false)},
			{"nman",createColumn("nman",typeof(int),true,false)},
			{"number",createColumn("number",typeof(decimal),true,false)},
			{"tax",createColumn("tax",typeof(decimal),true,false)},
			{"taxable",createColumn("taxable",typeof(decimal),true,false)},
			{"unabatable",createColumn("unabatable",typeof(decimal),true,false)},
			{"yman",createColumn("yman",typeof(short),true,false)},
			{"idestimkind",createColumn("idestimkind",typeof(string),true,false)},
			{"estimrownum",createColumn("estimrownum",typeof(int),true,false)},
			{"nestim",createColumn("nestim",typeof(int),true,false)},
			{"yestim",createColumn("yestim",typeof(short),true,false)},
			{"idgroup",createColumn("idgroup",typeof(int),true,false)},
			{"idexp_taxable",createColumn("idexp_taxable",typeof(int),true,false)},
			{"idexp_iva",createColumn("idexp_iva",typeof(int),true,false)},
			{"idinc_taxable",createColumn("idinc_taxable",typeof(int),true,false)},
			{"idinc_iva",createColumn("idinc_iva",typeof(int),true,false)},
			{"ninv_main",createColumn("ninv_main",typeof(int),true,false)},
			{"yinv_main",createColumn("yinv_main",typeof(short),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),false,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),false,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idintrastatcode",createColumn("idintrastatcode",typeof(int),true,false)},
			{"idintrastatmeasure",createColumn("idintrastatmeasure",typeof(int),true,false)},
			{"weight",createColumn("weight",typeof(decimal),true,false)},
			{"va3type",createColumn("va3type",typeof(string),true,false)},
			{"intrastatoperationkind",createColumn("intrastatoperationkind",typeof(string),true,false)},
			{"idintrastatservice",createColumn("idintrastatservice",typeof(int),true,false)},
			{"idintrastatsupplymethod",createColumn("idintrastatsupplymethod",typeof(int),true,false)},
			{"idlist",createColumn("idlist",typeof(int),true,false)},
			{"idunit",createColumn("idunit",typeof(int),true,false)},
			{"idpackage",createColumn("idpackage",typeof(int),true,false)},
			{"unitsforpackage",createColumn("unitsforpackage",typeof(int),true,false)},
			{"npackage",createColumn("npackage",typeof(decimal),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"exception12",createColumn("exception12",typeof(string),true,false)},
			{"intra12operationkind",createColumn("intra12operationkind",typeof(string),true,false)},
			{"move12",createColumn("move12",typeof(string),true,false)},
			{"idupb_iva",createColumn("idupb_iva",typeof(string),true,false)},
			{"idinvkind_main",createColumn("idinvkind_main",typeof(int),true,false)},
			{"leasing",createColumn("leasing",typeof(string),true,false)},
			{"usedmodesospesometro",createColumn("usedmodesospesometro",typeof(string),true,false)},
			{"resetresidualmandate",createColumn("resetresidualmandate",typeof(string),true,false)},
			{"idfetransfer",createColumn("idfetransfer",typeof(string),true,false)},
			{"fereferencerule",createColumn("fereferencerule",typeof(string),true,false)},
			{"cupcode",createColumn("cupcode",typeof(string),true,false)},
			{"cigcode",createColumn("cigcode",typeof(string),true,false)},
			{"idpccdebitstatus",createColumn("idpccdebitstatus",typeof(string),true,false)},
			{"idpccdebitmotive",createColumn("idpccdebitmotive",typeof(string),true,false)},
			{"idcostpartition",createColumn("idcostpartition",typeof(int),true,false)},
			{"expensekind",createColumn("expensekind",typeof(string),true,false)},
			{"rounding",createColumn("rounding",typeof(string),true,false)},
			{"idepexp",createColumn("idepexp",typeof(int),true,false)},
			{"idepacc",createColumn("idepacc",typeof(int),true,false)},
			{"flagbit",createColumn("flagbit",typeof(byte),true,false)},
			{"idfinmotive",createColumn("idfinmotive",typeof(string),true,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"ycon",createColumn("ycon",typeof(int),true,false)},
			{"ncon",createColumn("ncon",typeof(int),true,false)},
			{"codicetipo",createColumn("codicetipo",typeof(string),true,false)},
			{"codicevalore",createColumn("codicevalore",typeof(string),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"idepexp_pre",createColumn("idepexp_pre",typeof(int),true,false)},
			{"idtassonomia",createColumn("idtassonomia",typeof(int),true,false)},
			{"idfinmotive_iva",createColumn("idfinmotive_iva",typeof(string),true,false)},
			{"rownum_main",createColumn("rownum_main",typeof(int),true,false)},
		};
	}
}
}

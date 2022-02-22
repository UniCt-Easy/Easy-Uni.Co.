
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


using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_invoicekind {
public class invoicekindRow: MetaRow  {
	public invoicekindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
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
	public String codeinvkind{ 
		get {return  (String)this["codeinvkind"];}
		set {this["codeinvkind"]= value;}
	}
	public object codeinvkindValue { 
		get{ return this["codeinvkind"];}
		set {this["codeinvkind"]= value;}
	}
	public String codeinvkindOriginal { 
		get {return  (String)this["codeinvkind",DataRowVersion.Original];}
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
	public Byte flag{ 
		get {return  (Byte)this["flag"];}
		set {this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {this["flag"]= value;}
	}
	public Byte flagOriginal { 
		get {return  (Byte)this["flag",DataRowVersion.Original];}
	}
	public String flag_autodocnumbering{ 
		get {if (this["flag_autodocnumbering"]==DBNull.Value)return null; return  (String)this["flag_autodocnumbering"];}
		set {if (value==null) this["flag_autodocnumbering"]= DBNull.Value; else this["flag_autodocnumbering"]= value;}
	}
	public object flag_autodocnumberingValue { 
		get{ return this["flag_autodocnumbering"];}
		set {if (value==null|| value==DBNull.Value) this["flag_autodocnumbering"]= DBNull.Value; else this["flag_autodocnumbering"]= value;}
	}
	public String flag_autodocnumberingOriginal { 
		get {if (this["flag_autodocnumbering",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_autodocnumbering",DataRowVersion.Original];}
	}
	public String formatstring{ 
		get {if (this["formatstring"]==DBNull.Value)return null; return  (String)this["formatstring"];}
		set {if (value==null) this["formatstring"]= DBNull.Value; else this["formatstring"]= value;}
	}
	public object formatstringValue { 
		get{ return this["formatstring"];}
		set {if (value==null|| value==DBNull.Value) this["formatstring"]= DBNull.Value; else this["formatstring"]= value;}
	}
	public String formatstringOriginal { 
		get {if (this["formatstring",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["formatstring",DataRowVersion.Original];}
	}
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	public Int32? idinvkind_auto{ 
		get {if (this["idinvkind_auto"]==DBNull.Value)return null; return  (Int32?)this["idinvkind_auto"];}
		set {if (value==null) this["idinvkind_auto"]= DBNull.Value; else this["idinvkind_auto"]= value;}
	}
	public object idinvkind_autoValue { 
		get{ return this["idinvkind_auto"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind_auto"]= DBNull.Value; else this["idinvkind_auto"]= value;}
	}
	public Int32? idinvkind_autoOriginal { 
		get {if (this["idinvkind_auto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind_auto",DataRowVersion.Original];}
	}
	public String printingcode{ 
		get {if (this["printingcode"]==DBNull.Value)return null; return  (String)this["printingcode"];}
		set {if (value==null) this["printingcode"]= DBNull.Value; else this["printingcode"]= value;}
	}
	public object printingcodeValue { 
		get{ return this["printingcode"];}
		set {if (value==null|| value==DBNull.Value) this["printingcode"]= DBNull.Value; else this["printingcode"]= value;}
	}
	public String printingcodeOriginal { 
		get {if (this["printingcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["printingcode",DataRowVersion.Original];}
	}
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	public String address{ 
		get {if (this["address"]==DBNull.Value)return null; return  (String)this["address"];}
		set {if (value==null) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public object addressValue { 
		get{ return this["address"];}
		set {if (value==null|| value==DBNull.Value) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public String addressOriginal { 
		get {if (this["address",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["address",DataRowVersion.Original];}
	}
	public String header{ 
		get {if (this["header"]==DBNull.Value)return null; return  (String)this["header"];}
		set {if (value==null) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public object headerValue { 
		get{ return this["header"];}
		set {if (value==null|| value==DBNull.Value) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public String headerOriginal { 
		get {if (this["header",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["header",DataRowVersion.Original];}
	}
	public String notes1{ 
		get {if (this["notes1"]==DBNull.Value)return null; return  (String)this["notes1"];}
		set {if (value==null) this["notes1"]= DBNull.Value; else this["notes1"]= value;}
	}
	public object notes1Value { 
		get{ return this["notes1"];}
		set {if (value==null|| value==DBNull.Value) this["notes1"]= DBNull.Value; else this["notes1"]= value;}
	}
	public String notes1Original { 
		get {if (this["notes1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notes1",DataRowVersion.Original];}
	}
	public String notes2{ 
		get {if (this["notes2"]==DBNull.Value)return null; return  (String)this["notes2"];}
		set {if (value==null) this["notes2"]= DBNull.Value; else this["notes2"]= value;}
	}
	public object notes2Value { 
		get{ return this["notes2"];}
		set {if (value==null|| value==DBNull.Value) this["notes2"]= DBNull.Value; else this["notes2"]= value;}
	}
	public String notes2Original { 
		get {if (this["notes2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notes2",DataRowVersion.Original];}
	}
	public String notes3{ 
		get {if (this["notes3"]==DBNull.Value)return null; return  (String)this["notes3"];}
		set {if (value==null) this["notes3"]= DBNull.Value; else this["notes3"]= value;}
	}
	public object notes3Value { 
		get{ return this["notes3"];}
		set {if (value==null|| value==DBNull.Value) this["notes3"]= DBNull.Value; else this["notes3"]= value;}
	}
	public String notes3Original { 
		get {if (this["notes3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notes3",DataRowVersion.Original];}
	}
	public String ipa_fe{ 
		get {if (this["ipa_fe"]==DBNull.Value)return null; return  (String)this["ipa_fe"];}
		set {if (value==null) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public object ipa_feValue { 
		get{ return this["ipa_fe"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public String ipa_feOriginal { 
		get {if (this["ipa_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_fe",DataRowVersion.Original];}
	}
	public String riferimento_amministrazione{ 
		get {if (this["riferimento_amministrazione"]==DBNull.Value)return null; return  (String)this["riferimento_amministrazione"];}
		set {if (value==null) this["riferimento_amministrazione"]= DBNull.Value; else this["riferimento_amministrazione"]= value;}
	}
	public object riferimento_amministrazioneValue { 
		get{ return this["riferimento_amministrazione"];}
		set {if (value==null|| value==DBNull.Value) this["riferimento_amministrazione"]= DBNull.Value; else this["riferimento_amministrazione"]= value;}
	}
	public String riferimento_amministrazioneOriginal { 
		get {if (this["riferimento_amministrazione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimento_amministrazione",DataRowVersion.Original];}
	}
	public String enable_fe{ 
		get {if (this["enable_fe"]==DBNull.Value)return null; return  (String)this["enable_fe"];}
		set {if (value==null) this["enable_fe"]= DBNull.Value; else this["enable_fe"]= value;}
	}
	public object enable_feValue { 
		get{ return this["enable_fe"];}
		set {if (value==null|| value==DBNull.Value) this["enable_fe"]= DBNull.Value; else this["enable_fe"]= value;}
	}
	public String enable_feOriginal { 
		get {if (this["enable_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enable_fe",DataRowVersion.Original];}
	}
	public String enable_fe_estera{ 
		get {if (this["enable_fe_estera"]==DBNull.Value)return null; return  (String)this["enable_fe_estera"];}
		set {if (value==null) this["enable_fe_estera"]= DBNull.Value; else this["enable_fe_estera"]= value;}
	}
	public object enable_fe_esteraValue { 
		get{ return this["enable_fe_estera"];}
		set {if (value==null|| value==DBNull.Value) this["enable_fe_estera"]= DBNull.Value; else this["enable_fe_estera"]= value;}
	}
	public String enable_fe_esteraOriginal { 
		get {if (this["enable_fe_estera",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enable_fe_estera",DataRowVersion.Original];}
	}
	#endregion

}
public class invoicekindTable : MetaTableBase<invoicekindRow> {
	public invoicekindTable() : base("invoicekind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"codeinvkind",createColumn("codeinvkind",typeof(string),false,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),false,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"flag_autodocnumbering",createColumn("flag_autodocnumbering",typeof(string),true,false)},
			{"formatstring",createColumn("formatstring",typeof(string),true,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"idinvkind_auto",createColumn("idinvkind_auto",typeof(int),true,false)},
			{"printingcode",createColumn("printingcode",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"address",createColumn("address",typeof(string),true,false)},
			{"header",createColumn("header",typeof(string),true,false)},
			{"notes1",createColumn("notes1",typeof(string),true,false)},
			{"notes2",createColumn("notes2",typeof(string),true,false)},
			{"notes3",createColumn("notes3",typeof(string),true,false)},
			{"ipa_fe",createColumn("ipa_fe",typeof(string),true,false)},
			{"riferimento_amministrazione",createColumn("riferimento_amministrazione",typeof(string),true,false)},
			{"enable_fe",createColumn("enable_fe",typeof(string),true,false)},
			{"enable_fe_estera",createColumn("enable_fe_estera",typeof(string),true,false)},
		};
	}
}
}

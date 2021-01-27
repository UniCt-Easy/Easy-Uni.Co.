
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


using System;
using System.Data;
using System.Collections.Generic;
using metadatalibrary;
namespace meta_invoicekind {
public class invoicekindRow: MetaRow  {
	public invoicekindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///data creazione
	///</summary>
	public DateTime? ct{ 
		get {if (this["ct"]==DBNull.Value)return null; return  (DateTime?)this["ct"];}
		set {if (value==null) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {if (value==null|| value==DBNull.Value) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public DateTime? ctOriginal { 
		get {if (this["ct",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {if (this["cu"]==DBNull.Value)return null; return  (String)this["cu"];}
		set {if (value==null) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {if (value==null|| value==DBNull.Value) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public String cuOriginal { 
		get {if (this["cu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime? lt{ 
		get {if (this["lt"]==DBNull.Value)return null; return  (DateTime?)this["lt"];}
		set {if (value==null) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {if (value==null|| value==DBNull.Value) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public DateTime? ltOriginal { 
		get {if (this["lt",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lt",DataRowVersion.Original];}
	}
	///<summary>
	///nome ultimo utente modifica
	///</summary>
	public String lu{ 
		get {if (this["lu"]==DBNull.Value)return null; return  (String)this["lu"];}
		set {if (value==null) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {if (value==null|| value==DBNull.Value) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public String luOriginal { 
		get {if (this["lu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lu",DataRowVersion.Original];}
	}
	///<summary>
	///Codice tipo documento (tabella ivoicekind)
	///</summary>
	public String codeinvkind{ 
		get {if (this["codeinvkind"]==DBNull.Value)return null; return  (String)this["codeinvkind"];}
		set {if (value==null) this["codeinvkind"]= DBNull.Value; else this["codeinvkind"]= value;}
	}
	public object codeinvkindValue { 
		get{ return this["codeinvkind"];}
		set {if (value==null|| value==DBNull.Value) this["codeinvkind"]= DBNull.Value; else this["codeinvkind"]= value;}
	}
	public String codeinvkindOriginal { 
		get {if (this["codeinvkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeinvkind",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo documento (tabella invoicekind)
	///</summary>
	public Int32? idinvkind{ 
		get {if (this["idinvkind"]==DBNull.Value)return null; return  (Int32?)this["idinvkind"];}
		set {if (value==null) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public object idinvkindValue { 
		get{ return this["idinvkind"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public Int32? idinvkindOriginal { 
		get {if (this["idinvkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///Flag numeraz. automatica
	///	 N: Numerazione manuale
	///	 S: Numeraz. automatica
	///</summary>
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
	///<summary>
	///Formato numerazione automatica per fatture di vendita
	///</summary>
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
	///<summary>
	///attivo
	///</summary>
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
	///<summary>
	///id tipo documento autofattura collegata
	///</summary>
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
	///<summary>
	///Codice per stampa
	///</summary>
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
	///<summary>
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
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
	///<summary>
	///n. operazione
	///</summary>
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
	///<summary>
	///Header
	///</summary>
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
	///<summary>
	///Annotazioni 1 (per stampa fattura)
	///</summary>
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
	///<summary>
	///Annotazioni 2 (per stampa fattura)
	///</summary>
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
	///<summary>
	///Annotazioni  3 (per stampa fattura)
	///</summary>
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
	///<summary>
	///IPA
	///</summary>
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
	///<summary>
	///Riferimento Amministrazione
	///</summary>
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
	///<summary>
	///Utilizzabile nella F.E.
	///</summary>
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
	#endregion

}
///<summary>
///Tipo di documento
///</summary>
public class invoicekindTable : MetaTableBase<invoicekindRow> {
	public invoicekindTable() : base("invoicekind"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("codeinvkind")){ 
			defineColumn("codeinvkind", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idinvkind")){ 
			defineColumn("idinvkind", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("flag_autodocnumbering")){ 
			defineColumn("flag_autodocnumbering", typeof(System.String));
		}
		if (definedColums.ContainsKey("formatstring")){ 
			defineColumn("formatstring", typeof(System.String));
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("idinvkind_auto")){ 
			defineColumn("idinvkind_auto", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("printingcode")){ 
			defineColumn("printingcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("address")){ 
			defineColumn("address", typeof(System.String));
		}
		if (definedColums.ContainsKey("header")){ 
			defineColumn("header", typeof(System.String));
		}
		if (definedColums.ContainsKey("notes1")){ 
			defineColumn("notes1", typeof(System.String));
		}
		if (definedColums.ContainsKey("notes2")){ 
			defineColumn("notes2", typeof(System.String));
		}
		if (definedColums.ContainsKey("notes3")){ 
			defineColumn("notes3", typeof(System.String));
		}
		if (definedColums.ContainsKey("ipa_fe")){ 
			defineColumn("ipa_fe", typeof(System.String));
		}
		if (definedColums.ContainsKey("riferimento_amministrazione")){ 
			defineColumn("riferimento_amministrazione", typeof(System.String));
		}
		if (definedColums.ContainsKey("enable_fe")){ 
			defineColumn("enable_fe", typeof(System.String));
		}
		#endregion

	}
}
}

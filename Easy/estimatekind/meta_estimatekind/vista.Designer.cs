/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_estimatekind {
public class estimatekindRow: MetaRow  {
	public estimatekindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///chiave tipo contratto attivo (tabella estimatekind)
	///</summary>
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
	///id voce upb (tabella upb)
	///</summary>
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
	///allegati
	///</summary>
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
	}
	///<summary>
	///note testuali
	///</summary>
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	///<summary>
	///Email
	///</summary>
	public String email{ 
		get {if (this["email"]==DBNull.Value)return null; return  (String)this["email"];}
		set {if (value==null) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public object emailValue { 
		get{ return this["email"];}
		set {if (value==null|| value==DBNull.Value) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public String emailOriginal { 
		get {if (this["email",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email",DataRowVersion.Original];}
	}
	///<summary>
	///Fax
	///</summary>
	public String faxnumber{ 
		get {if (this["faxnumber"]==DBNull.Value)return null; return  (String)this["faxnumber"];}
		set {if (value==null) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public object faxnumberValue { 
		get{ return this["faxnumber"];}
		set {if (value==null|| value==DBNull.Value) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public String faxnumberOriginal { 
		get {if (this["faxnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["faxnumber",DataRowVersion.Original];}
	}
	///<summary>
	///Ufficio
	///</summary>
	public String office{ 
		get {if (this["office"]==DBNull.Value)return null; return  (String)this["office"];}
		set {if (value==null) this["office"]= DBNull.Value; else this["office"]= value;}
	}
	public object officeValue { 
		get{ return this["office"];}
		set {if (value==null|| value==DBNull.Value) this["office"]= DBNull.Value; else this["office"]= value;}
	}
	public String officeOriginal { 
		get {if (this["office",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["office",DataRowVersion.Original];}
	}
	///<summary>
	///Telefono
	///</summary>
	public String phonenumber{ 
		get {if (this["phonenumber"]==DBNull.Value)return null; return  (String)this["phonenumber"];}
		set {if (value==null) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public object phonenumberValue { 
		get{ return this["phonenumber"];}
		set {if (value==null|| value==DBNull.Value) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public String phonenumberOriginal { 
		get {if (this["phonenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["phonenumber",DataRowVersion.Original];}
	}
	///<summary>
	///flag collegabile a fattura
	///</summary>
	public String linktoinvoice{ 
		get {if (this["linktoinvoice"]==DBNull.Value)return null; return  (String)this["linktoinvoice"];}
		set {if (value==null) this["linktoinvoice"]= DBNull.Value; else this["linktoinvoice"]= value;}
	}
	public object linktoinvoiceValue { 
		get{ return this["linktoinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["linktoinvoice"]= DBNull.Value; else this["linktoinvoice"]= value;}
	}
	public String linktoinvoiceOriginal { 
		get {if (this["linktoinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["linktoinvoice",DataRowVersion.Original];}
	}
	///<summary>
	///flag anagrafica nei dettagli
	///</summary>
	public String multireg{ 
		get {if (this["multireg"]==DBNull.Value)return null; return  (String)this["multireg"];}
		set {if (value==null) this["multireg"]= DBNull.Value; else this["multireg"]= value;}
	}
	public object multiregValue { 
		get{ return this["multireg"];}
		set {if (value==null|| value==DBNull.Value) this["multireg"]= DBNull.Value; else this["multireg"]= value;}
	}
	public String multiregOriginal { 
		get {if (this["multireg",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["multireg",DataRowVersion.Original];}
	}
	///<summary>
	///importo scostamento massimo ammesso in contabilizzazione
	///</summary>
	public Decimal? deltaamount{ 
		get {if (this["deltaamount"]==DBNull.Value)return null; return  (Decimal?)this["deltaamount"];}
		set {if (value==null) this["deltaamount"]= DBNull.Value; else this["deltaamount"]= value;}
	}
	public object deltaamountValue { 
		get{ return this["deltaamount"];}
		set {if (value==null|| value==DBNull.Value) this["deltaamount"]= DBNull.Value; else this["deltaamount"]= value;}
	}
	public Decimal? deltaamountOriginal { 
		get {if (this["deltaamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["deltaamount",DataRowVersion.Original];}
	}
	///<summary>
	///percentuale massima di scostamento in contabilizzazione
	///</summary>
	public Decimal? deltapercentage{ 
		get {if (this["deltapercentage"]==DBNull.Value)return null; return  (Decimal?)this["deltapercentage"];}
		set {if (value==null) this["deltapercentage"]= DBNull.Value; else this["deltapercentage"]= value;}
	}
	public object deltapercentageValue { 
		get{ return this["deltapercentage"];}
		set {if (value==null|| value==DBNull.Value) this["deltapercentage"]= DBNull.Value; else this["deltapercentage"]= value;}
	}
	public Decimal? deltapercentageOriginal { 
		get {if (this["deltapercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["deltapercentage",DataRowVersion.Original];}
	}
	///<summary>
	///Flag numeraz. automatica
	///	 N: Numerazione manuale
	///	 S: Numerazione automatica
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
	///Tipo iva bloccato
	///</summary>
	public Int32? idivakind_forced{ 
		get {if (this["idivakind_forced"]==DBNull.Value)return null; return  (Int32?)this["idivakind_forced"];}
		set {if (value==null) this["idivakind_forced"]= DBNull.Value; else this["idivakind_forced"]= value;}
	}
	public object idivakind_forcedValue { 
		get{ return this["idivakind_forced"];}
		set {if (value==null|| value==DBNull.Value) this["idivakind_forced"]= DBNull.Value; else this["idivakind_forced"]= value;}
	}
	public Int32? idivakind_forcedOriginal { 
		get {if (this["idivakind_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivakind_forced",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
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
	#endregion

}
///<summary>
///Tipo di Contratto attivo
///</summary>
public class estimatekindTable : MetaTableBase<estimatekindRow> {
	public estimatekindTable() : base("estimatekind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idestimkind",createColumn("idestimkind",typeof(string),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"faxnumber",createColumn("faxnumber",typeof(string),true,false)},
			{"office",createColumn("office",typeof(string),true,false)},
			{"phonenumber",createColumn("phonenumber",typeof(string),true,false)},
			{"linktoinvoice",createColumn("linktoinvoice",typeof(string),true,false)},
			{"multireg",createColumn("multireg",typeof(string),true,false)},
			{"deltaamount",createColumn("deltaamount",typeof(decimal),true,false)},
			{"deltapercentage",createColumn("deltapercentage",typeof(decimal),true,false)},
			{"flag_autodocnumbering",createColumn("flag_autodocnumbering",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"address",createColumn("address",typeof(string),true,false)},
			{"header",createColumn("header",typeof(string),true,false)},
			{"idivakind_forced",createColumn("idivakind_forced",typeof(int),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
		};
	}
}
}

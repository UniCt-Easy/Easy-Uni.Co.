
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_mandatekind {
public class mandatekindRow: MetaRow  {
	public mandatekindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id tipo contratto (tabella mandatekind)
	///</summary>
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
	///Ufficio Emittente
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
	///Carico cespite
	///</summary>
	public String linktoasset{ 
		get {if (this["linktoasset"]==DBNull.Value)return null; return  (String)this["linktoasset"];}
		set {if (value==null) this["linktoasset"]= DBNull.Value; else this["linktoasset"]= value;}
	}
	public object linktoassetValue { 
		get{ return this["linktoasset"];}
		set {if (value==null|| value==DBNull.Value) this["linktoasset"]= DBNull.Value; else this["linktoasset"]= value;}
	}
	public String linktoassetOriginal { 
		get {if (this["linktoasset",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["linktoasset",DataRowVersion.Original];}
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
	///Importo Scostamento di tolleranza per contabilizzazioni
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
	///Percentuale di scostamento di tolleranza per contabilizzazioni
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
	///	 N: Numeraz. manuale
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
	///Tipo attivit√†
	///	 1: Istituzionale
	///	 2: Commerciale
	///	 3: Promiscua
	///	 4: Qualsiasi/Non specificata
	///</summary>
	public Int16? flagactivity{ 
		get {if (this["flagactivity"]==DBNull.Value)return null; return  (Int16?)this["flagactivity"];}
		set {if (value==null) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public object flagactivityValue { 
		get{ return this["flagactivity"];}
		set {if (value==null|| value==DBNull.Value) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public Int16? flagactivityOriginal { 
		get {if (this["flagactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["flagactivity",DataRowVersion.Original];}
	}
	///<summary>
	///Nome Firma Centro
	///</summary>
	public String name_c{ 
		get {if (this["name_c"]==DBNull.Value)return null; return  (String)this["name_c"];}
		set {if (value==null) this["name_c"]= DBNull.Value; else this["name_c"]= value;}
	}
	public object name_cValue { 
		get{ return this["name_c"];}
		set {if (value==null|| value==DBNull.Value) this["name_c"]= DBNull.Value; else this["name_c"]= value;}
	}
	public String name_cOriginal { 
		get {if (this["name_c",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["name_c",DataRowVersion.Original];}
	}
	///<summary>
	///Nome Firma Sinistra
	///</summary>
	public String name_l{ 
		get {if (this["name_l"]==DBNull.Value)return null; return  (String)this["name_l"];}
		set {if (value==null) this["name_l"]= DBNull.Value; else this["name_l"]= value;}
	}
	public object name_lValue { 
		get{ return this["name_l"];}
		set {if (value==null|| value==DBNull.Value) this["name_l"]= DBNull.Value; else this["name_l"]= value;}
	}
	public String name_lOriginal { 
		get {if (this["name_l",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["name_l",DataRowVersion.Original];}
	}
	///<summary>
	///Nome Firma Destra
	///</summary>
	public String name_r{ 
		get {if (this["name_r"]==DBNull.Value)return null; return  (String)this["name_r"];}
		set {if (value==null) this["name_r"]= DBNull.Value; else this["name_r"]= value;}
	}
	public object name_rValue { 
		get{ return this["name_r"];}
		set {if (value==null|| value==DBNull.Value) this["name_r"]= DBNull.Value; else this["name_r"]= value;}
	}
	public String name_rOriginal { 
		get {if (this["name_r",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["name_r",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo Firma Centro
	///</summary>
	public String title_c{ 
		get {if (this["title_c"]==DBNull.Value)return null; return  (String)this["title_c"];}
		set {if (value==null) this["title_c"]= DBNull.Value; else this["title_c"]= value;}
	}
	public object title_cValue { 
		get{ return this["title_c"];}
		set {if (value==null|| value==DBNull.Value) this["title_c"]= DBNull.Value; else this["title_c"]= value;}
	}
	public String title_cOriginal { 
		get {if (this["title_c",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_c",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo Firma Sinistra
	///</summary>
	public String title_l{ 
		get {if (this["title_l"]==DBNull.Value)return null; return  (String)this["title_l"];}
		set {if (value==null) this["title_l"]= DBNull.Value; else this["title_l"]= value;}
	}
	public object title_lValue { 
		get{ return this["title_l"];}
		set {if (value==null|| value==DBNull.Value) this["title_l"]= DBNull.Value; else this["title_l"]= value;}
	}
	public String title_lOriginal { 
		get {if (this["title_l",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_l",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo Firma Destra
	///</summary>
	public String title_r{ 
		get {if (this["title_r"]==DBNull.Value)return null; return  (String)this["title_r"];}
		set {if (value==null) this["title_r"]= DBNull.Value; else this["title_r"]= value;}
	}
	public object title_rValue { 
		get{ return this["title_r"];}
		set {if (value==null|| value==DBNull.Value) this["title_r"]= DBNull.Value; else this["title_r"]= value;}
	}
	public String title_rOriginal { 
		get {if (this["title_r",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_r",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni (1)
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
	///Annotazioni (2)
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
	///Annotazioni (3)
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
	///Indirizzo e-mail di notifica dello stato del contratto
	///</summary>
	public String warnmail{ 
		get {if (this["warnmail"]==DBNull.Value)return null; return  (String)this["warnmail"];}
		set {if (value==null) this["warnmail"]= DBNull.Value; else this["warnmail"]= value;}
	}
	public object warnmailValue { 
		get{ return this["warnmail"];}
		set {if (value==null|| value==DBNull.Value) this["warnmail"]= DBNull.Value; else this["warnmail"]= value;}
	}
	public String warnmailOriginal { 
		get {if (this["warnmail",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["warnmail",DataRowVersion.Original];}
	}
	///<summary>
	///Richiesta d'ordine 
	///	 N: Normale ordine
	///	 S: Richiesta d'ordine 
	///</summary>
	public String isrequest{ 
		get {if (this["isrequest"]==DBNull.Value)return null; return  (String)this["isrequest"];}
		set {if (value==null) this["isrequest"]= DBNull.Value; else this["isrequest"]= value;}
	}
	public object isrequestValue { 
		get{ return this["isrequest"];}
		set {if (value==null|| value==DBNull.Value) this["isrequest"]= DBNull.Value; else this["isrequest"]= value;}
	}
	public String isrequestOriginal { 
		get {if (this["isrequest",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isrequest",DataRowVersion.Original];}
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
	///Tipo cespite
	///</summary>
	public Byte? assetkind{ 
		get {if (this["assetkind"]==DBNull.Value)return null; return  (Byte?)this["assetkind"];}
		set {if (value==null) this["assetkind"]= DBNull.Value; else this["assetkind"]= value;}
	}
	public object assetkindValue { 
		get{ return this["assetkind"];}
		set {if (value==null|| value==DBNull.Value) this["assetkind"]= DBNull.Value; else this["assetkind"]= value;}
	}
	public Byte? assetkindOriginal { 
		get {if (this["assetkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["assetkind",DataRowVersion.Original];}
	}
	///<summary>
	///E-mail a cui si intende notificare la richieste di ordine di materiale pericoloso/radioattivo:
	///</summary>
	public String dangermail{ 
		get {if (this["dangermail"]==DBNull.Value)return null; return  (String)this["dangermail"];}
		set {if (value==null) this["dangermail"]= DBNull.Value; else this["dangermail"]= value;}
	}
	public object dangermailValue { 
		get{ return this["dangermail"];}
		set {if (value==null|| value==DBNull.Value) this["dangermail"]= DBNull.Value; else this["dangermail"]= value;}
	}
	public String dangermailOriginal { 
		get {if (this["dangermail",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dangermail",DataRowVersion.Original];}
	}
	///<summary>
	///Indirizzo
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
	///Intestazione report
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
	///<summary>
	///Protocolla nel Registro Unico
	///	 N: Non protocollare nel Registro Unico
	///	 S: Protocolla nel Registro Unico
	///</summary>
	public String touniqueregister{ 
		get {if (this["touniqueregister"]==DBNull.Value)return null; return  (String)this["touniqueregister"];}
		set {if (value==null) this["touniqueregister"]= DBNull.Value; else this["touniqueregister"]= value;}
	}
	public object touniqueregisterValue { 
		get{ return this["touniqueregister"];}
		set {if (value==null|| value==DBNull.Value) this["touniqueregister"]= DBNull.Value; else this["touniqueregister"]= value;}
	}
	public String touniqueregisterOriginal { 
		get {if (this["touniqueregister",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["touniqueregister",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.
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
	///Genera Scritture in partita doppia
	///	 N: Non generare scritture in partita doppia
	///	 S: Genera Scritture in partita doppia
	///</summary>
	public String flagcreatedoubleentry{ 
		get {if (this["flagcreatedoubleentry"]==DBNull.Value)return null; return  (String)this["flagcreatedoubleentry"];}
		set {if (value==null) this["flagcreatedoubleentry"]= DBNull.Value; else this["flagcreatedoubleentry"]= value;}
	}
	public object flagcreatedoubleentryValue { 
		get{ return this["flagcreatedoubleentry"];}
		set {if (value==null|| value==DBNull.Value) this["flagcreatedoubleentry"]= DBNull.Value; else this["flagcreatedoubleentry"]= value;}
	}
	public String flagcreatedoubleentryOriginal { 
		get {if (this["flagcreatedoubleentry",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcreatedoubleentry",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo iva forzato (idivakind di ivakind)
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
	///anagrafica responsabile unico procedimento 
	///</summary>
	public Int32? idreg_rupanac{ 
		get {if (this["idreg_rupanac"]==DBNull.Value)return null; return  (Int32?)this["idreg_rupanac"];}
		set {if (value==null) this["idreg_rupanac"]= DBNull.Value; else this["idreg_rupanac"]= value;}
	}
	public object idreg_rupanacValue { 
		get{ return this["idreg_rupanac"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_rupanac"]= DBNull.Value; else this["idreg_rupanac"]= value;}
	}
	public Int32? idreg_rupanacOriginal { 
		get {if (this["idreg_rupanac",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_rupanac",DataRowVersion.Original];}
	}
	public Int32? requested_doc{ 
		get {if (this["requested_doc"]==DBNull.Value)return null; return  (Int32?)this["requested_doc"];}
		set {if (value==null) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public object requested_docValue { 
		get{ return this["requested_doc"];}
		set {if (value==null|| value==DBNull.Value) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public Int32? requested_docOriginal { 
		get {if (this["requested_doc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["requested_doc",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tipo contratto passivo
///</summary>
public class mandatekindTable : MetaTableBase<mandatekindRow> {
	public mandatekindTable() : base("mandatekind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idmankind",createColumn("idmankind",typeof(String),false,false)},
			{"active",createColumn("active",typeof(String),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"idupb",createColumn("idupb",typeof(String),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"email",createColumn("email",typeof(String),true,false)},
			{"faxnumber",createColumn("faxnumber",typeof(String),true,false)},
			{"office",createColumn("office",typeof(String),true,false)},
			{"phonenumber",createColumn("phonenumber",typeof(String),true,false)},
			{"linktoasset",createColumn("linktoasset",typeof(String),true,false)},
			{"linktoinvoice",createColumn("linktoinvoice",typeof(String),true,false)},
			{"multireg",createColumn("multireg",typeof(String),true,false)},
			{"deltaamount",createColumn("deltaamount",typeof(Decimal),true,false)},
			{"deltapercentage",createColumn("deltapercentage",typeof(Decimal),true,false)},
			{"flag_autodocnumbering",createColumn("flag_autodocnumbering",typeof(String),true,false)},
			{"flagactivity",createColumn("flagactivity",typeof(Int16),true,false)},
			{"name_c",createColumn("name_c",typeof(String),true,false)},
			{"name_l",createColumn("name_l",typeof(String),true,false)},
			{"name_r",createColumn("name_r",typeof(String),true,false)},
			{"title_c",createColumn("title_c",typeof(String),true,false)},
			{"title_l",createColumn("title_l",typeof(String),true,false)},
			{"title_r",createColumn("title_r",typeof(String),true,false)},
			{"notes1",createColumn("notes1",typeof(String),true,false)},
			{"notes2",createColumn("notes2",typeof(String),true,false)},
			{"notes3",createColumn("notes3",typeof(String),true,false)},
			{"warnmail",createColumn("warnmail",typeof(String),true,false)},
			{"isrequest",createColumn("isrequest",typeof(String),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
			{"assetkind",createColumn("assetkind",typeof(Byte),false,false)},
			{"dangermail",createColumn("dangermail",typeof(String),true,false)},
			{"address",createColumn("address",typeof(String),true,false)},
			{"header",createColumn("header",typeof(String),true,false)},
			{"flag",createColumn("flag",typeof(Int32),true,false)},
			{"touniqueregister",createColumn("touniqueregister",typeof(String),true,false)},
			{"ipa_fe",createColumn("ipa_fe",typeof(String),true,false)},
			{"riferimento_amministrazione",createColumn("riferimento_amministrazione",typeof(String),true,false)},
			{"flagcreatedoubleentry",createColumn("flagcreatedoubleentry",typeof(String),true,false)},
			{"idivakind_forced",createColumn("idivakind_forced",typeof(Int32),true,false)},
			{"idreg_rupanac",createColumn("idreg_rupanac",typeof(Int32),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(Int32),true,false)},
		};
	}
}
}

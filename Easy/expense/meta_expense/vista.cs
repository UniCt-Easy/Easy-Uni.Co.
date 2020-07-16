/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_expense {
public class expenseRow: MetaRow  {
	public expenseRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///data contabile
	///</summary>
	public DateTime adate{ 
		get {return  (DateTime)this["adate"];}
		set {this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {this["adate"]= value;}
	}
	public DateTime adateOriginal { 
		get {return  (DateTime)this["adate",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///<summary>
	///Descrizione
	///</summary>
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
	///<summary>
	///documento
	///</summary>
	public String doc{ 
		get {if (this["doc"]==DBNull.Value)return null; return  (String)this["doc"];}
		set {if (value==null) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public object docValue { 
		get{ return this["doc"];}
		set {if (value==null|| value==DBNull.Value) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public String docOriginal { 
		get {if (this["doc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["doc",DataRowVersion.Original];}
	}
	///<summary>
	///data documento
	///</summary>
	public DateTime? docdate{ 
		get {if (this["docdate"]==DBNull.Value)return null; return  (DateTime?)this["docdate"];}
		set {if (value==null) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public object docdateValue { 
		get{ return this["docdate"];}
		set {if (value==null|| value==DBNull.Value) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public DateTime? docdateOriginal { 
		get {if (this["docdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["docdate",DataRowVersion.Original];}
	}
	///<summary>
	///scadenza
	///</summary>
	public DateTime? expiration{ 
		get {if (this["expiration"]==DBNull.Value)return null; return  (DateTime?)this["expiration"];}
		set {if (value==null) this["expiration"]= DBNull.Value; else this["expiration"]= value;}
	}
	public object expirationValue { 
		get{ return this["expiration"];}
		set {if (value==null|| value==DBNull.Value) this["expiration"]= DBNull.Value; else this["expiration"]= value;}
	}
	public DateTime? expirationOriginal { 
		get {if (this["expiration",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["expiration",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///<summary>
	///N.movimento
	///</summary>
	public Int32 nmov{ 
		get {return  (Int32)this["nmov"];}
		set {this["nmov"]= value;}
	}
	public object nmovValue { 
		get{ return this["nmov"];}
		set {this["nmov"]= value;}
	}
	public Int32 nmovOriginal { 
		get {return  (Int32)this["nmov",DataRowVersion.Original];}
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
	///Anno movimento
	///</summary>
	public Int16 ymov{ 
		get {return  (Int16)this["ymov"];}
		set {this["ymov"]= value;}
	}
	public object ymovValue { 
		get{ return this["ymov"];}
		set {this["ymov"]= value;}
	}
	public Int16 ymovOriginal { 
		get {return  (Int16)this["ymov",DataRowVersion.Original];}
	}
	///<summary>
	///Id recupero (tabella recupero)
	///</summary>
	public Int32? idclawback{ 
		get {if (this["idclawback"]==DBNull.Value)return null; return  (Int32?)this["idclawback"];}
		set {if (value==null) this["idclawback"]= DBNull.Value; else this["idclawback"]= value;}
	}
	public object idclawbackValue { 
		get{ return this["idclawback"];}
		set {if (value==null|| value==DBNull.Value) this["idclawback"]= DBNull.Value; else this["idclawback"]= value;}
	}
	public Int32? idclawbackOriginal { 
		get {if (this["idclawback",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idclawback",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. spesa (tabella expense)
	///</summary>
	public Int32 idexp{ 
		get {return  (Int32)this["idexp"];}
		set {this["idexp"]= value;}
	}
	public object idexpValue { 
		get{ return this["idexp"];}
		set {this["idexp"]= value;}
	}
	public Int32 idexpOriginal { 
		get {return  (Int32)this["idexp",DataRowVersion.Original];}
	}
	///<summary>
	///id movimento padre (idexp di tabella expense)
	///</summary>
	public Int32? parentidexp{ 
		get {if (this["parentidexp"]==DBNull.Value)return null; return  (Int32?)this["parentidexp"];}
		set {if (value==null) this["parentidexp"]= DBNull.Value; else this["parentidexp"]= value;}
	}
	public object parentidexpValue { 
		get{ return this["parentidexp"];}
		set {if (value==null|| value==DBNull.Value) this["parentidexp"]= DBNull.Value; else this["parentidexp"]= value;}
	}
	public Int32? parentidexpOriginal { 
		get {if (this["parentidexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["parentidexp",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. spesa collegato (idexp di expense)
	///</summary>
	public Int32? idpayment{ 
		get {if (this["idpayment"]==DBNull.Value)return null; return  (Int32?)this["idpayment"];}
		set {if (value==null) this["idpayment"]= DBNull.Value; else this["idpayment"]= value;}
	}
	public object idpaymentValue { 
		get{ return this["idpayment"];}
		set {if (value==null|| value==DBNull.Value) this["idpayment"]= DBNull.Value; else this["idpayment"]= value;}
	}
	public Int32? idpaymentOriginal { 
		get {if (this["idpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpayment",DataRowVersion.Original];}
	}
	///<summary>
	///id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)
	///</summary>
	public Int32? idformerexpense{ 
		get {if (this["idformerexpense"]==DBNull.Value)return null; return  (Int32?)this["idformerexpense"];}
		set {if (value==null) this["idformerexpense"]= DBNull.Value; else this["idformerexpense"]= value;}
	}
	public object idformerexpenseValue { 
		get{ return this["idformerexpense"];}
		set {if (value==null|| value==DBNull.Value) this["idformerexpense"]= DBNull.Value; else this["idformerexpense"]= value;}
	}
	public Int32? idformerexpenseOriginal { 
		get {if (this["idformerexpense",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idformerexpense",DataRowVersion.Original];}
	}
	///<summary>
	///N.fase
	///</summary>
	public Byte nphase{ 
		get {return  (Byte)this["nphase"];}
		set {this["nphase"]= value;}
	}
	public object nphaseValue { 
		get{ return this["nphase"];}
		set {this["nphase"]= value;}
	}
	public Byte nphaseOriginal { 
		get {return  (Byte)this["nphase",DataRowVersion.Original];}
	}
	///<summary>
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo automatismo, descritto in tabella autokind
	///</summary>
	public Byte? autokind{ 
		get {if (this["autokind"]==DBNull.Value)return null; return  (Byte?)this["autokind"];}
		set {if (value==null) this["autokind"]= DBNull.Value; else this["autokind"]= value;}
	}
	public object autokindValue { 
		get{ return this["autokind"];}
		set {if (value==null|| value==DBNull.Value) this["autokind"]= DBNull.Value; else this["autokind"]= value;}
	}
	public Byte? autokindOriginal { 
		get {if (this["autokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["autokind",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Automatismo
	///</summary>
	public Int32? autocode{ 
		get {if (this["autocode"]==DBNull.Value)return null; return  (Int32?)this["autocode"];}
		set {if (value==null) this["autocode"]= DBNull.Value; else this["autocode"]= value;}
	}
	public object autocodeValue { 
		get{ return this["autocode"];}
		set {if (value==null|| value==DBNull.Value) this["autocode"]= DBNull.Value; else this["autocode"]= value;}
	}
	public Int32? autocodeOriginal { 
		get {if (this["autocode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["autocode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice CUP
	///</summary>
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
	///<summary>
	///Codice CIG
	///</summary>
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
	///<summary>
	///Chiave esterna per db collegati
	///</summary>
	public String external_reference{ 
		get {if (this["external_reference"]==DBNull.Value)return null; return  (String)this["external_reference"];}
		set {if (value==null) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public object external_referenceValue { 
		get{ return this["external_reference"];}
		set {if (value==null|| value==DBNull.Value) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public String external_referenceOriginal { 
		get {if (this["external_reference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["external_reference",DataRowVersion.Original];}
	}
	public Int32? idinc_linked{ 
		get {if (this["idinc_linked"]==DBNull.Value)return null; return  (Int32?)this["idinc_linked"];}
		set {if (value==null) this["idinc_linked"]= DBNull.Value; else this["idinc_linked"]= value;}
	}
	public object idinc_linkedValue { 
		get{ return this["idinc_linked"];}
		set {if (value==null|| value==DBNull.Value) this["idinc_linked"]= DBNull.Value; else this["idinc_linked"]= value;}
	}
	public Int32? idinc_linkedOriginal { 
		get {if (this["idinc_linked",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc_linked",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Movimento di spesa
///</summary>
public class expenseTable : MetaTableBase<expenseRow> {
	public expenseTable() : base("expense"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"expiration",createColumn("expiration",typeof(DateTime),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nmov",createColumn("nmov",typeof(int),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"ymov",createColumn("ymov",typeof(short),false,false)},
			{"idclawback",createColumn("idclawback",typeof(int),true,false)},
			{"idexp",createColumn("idexp",typeof(int),false,false)},
			{"parentidexp",createColumn("parentidexp",typeof(int),true,false)},
			{"idpayment",createColumn("idpayment",typeof(int),true,false)},
			{"idformerexpense",createColumn("idformerexpense",typeof(int),true,false)},
			{"nphase",createColumn("nphase",typeof(byte),false,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"autokind",createColumn("autokind",typeof(byte),true,false)},
			{"autocode",createColumn("autocode",typeof(int),true,false)},
			{"cupcode",createColumn("cupcode",typeof(string),true,false)},
			{"cigcode",createColumn("cigcode",typeof(string),true,false)},
			{"external_reference",createColumn("external_reference",typeof(string),true,false)},
			{"idinc_linked",createColumn("idinc_linked",typeof(int),true,false)},
		};
	}
}
}

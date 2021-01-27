
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
namespace meta_income {
public class incomeRow: MetaRow  {
	public incomeRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///data contabile
	///</summary>
	public DateTime? adate{ 
		get {if (this["adate"]==DBNull.Value)return null; return  (DateTime?)this["adate"];}
		set {if (value==null) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {if (value==null|| value==DBNull.Value) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public DateTime? adateOriginal { 
		get {if (this["adate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adate",DataRowVersion.Original];}
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
	///N.movimento
	///</summary>
	public Int32? nmov{ 
		get {if (this["nmov"]==DBNull.Value)return null; return  (Int32?)this["nmov"];}
		set {if (value==null) this["nmov"]= DBNull.Value; else this["nmov"]= value;}
	}
	public object nmovValue { 
		get{ return this["nmov"];}
		set {if (value==null|| value==DBNull.Value) this["nmov"]= DBNull.Value; else this["nmov"]= value;}
	}
	public Int32? nmovOriginal { 
		get {if (this["nmov",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nmov",DataRowVersion.Original];}
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
	public Int16? ymov{ 
		get {if (this["ymov"]==DBNull.Value)return null; return  (Int16?)this["ymov"];}
		set {if (value==null) this["ymov"]= DBNull.Value; else this["ymov"]= value;}
	}
	public object ymovValue { 
		get{ return this["ymov"];}
		set {if (value==null|| value==DBNull.Value) this["ymov"]= DBNull.Value; else this["ymov"]= value;}
	}
	public Int16? ymovOriginal { 
		get {if (this["ymov",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ymov",DataRowVersion.Original];}
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
	///id mov. entrata (tabella income)
	///</summary>
	public Int32? idinc{ 
		get {if (this["idinc"]==DBNull.Value)return null; return  (Int32?)this["idinc"];}
		set {if (value==null) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public object idincValue { 
		get{ return this["idinc"];}
		set {if (value==null|| value==DBNull.Value) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public Int32? idincOriginal { 
		get {if (this["idinc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc",DataRowVersion.Original];}
	}
	///<summary>
	///Id movimento padre (tabella income)
	///</summary>
	public Int32? parentidinc{ 
		get {if (this["parentidinc"]==DBNull.Value)return null; return  (Int32?)this["parentidinc"];}
		set {if (value==null) this["parentidinc"]= DBNull.Value; else this["parentidinc"]= value;}
	}
	public object parentidincValue { 
		get{ return this["parentidinc"];}
		set {if (value==null|| value==DBNull.Value) this["parentidinc"]= DBNull.Value; else this["parentidinc"]= value;}
	}
	public Int32? parentidincOriginal { 
		get {if (this["parentidinc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["parentidinc",DataRowVersion.Original];}
	}
	///<summary>
	///N.fase
	///</summary>
	public Byte? nphase{ 
		get {if (this["nphase"]==DBNull.Value)return null; return  (Byte?)this["nphase"];}
		set {if (value==null) this["nphase"]= DBNull.Value; else this["nphase"]= value;}
	}
	public object nphaseValue { 
		get{ return this["nphase"];}
		set {if (value==null|| value==DBNull.Value) this["nphase"]= DBNull.Value; else this["nphase"]= value;}
	}
	public Byte? nphaseOriginal { 
		get {if (this["nphase",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["nphase",DataRowVersion.Original];}
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
	///id finanziamento (tabella underwriting)
	///</summary>
	public Int32? idunderwriting{ 
		get {if (this["idunderwriting"]==DBNull.Value)return null; return  (Int32?)this["idunderwriting"];}
		set {if (value==null) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public object idunderwritingValue { 
		get{ return this["idunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public Int32? idunderwritingOriginal { 
		get {if (this["idunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriting",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Movimento di entrata
///</summary>
public class incomeTable : MetaTableBase<incomeRow> {
	public incomeTable() : base("income"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("doc")){ 
			defineColumn("doc", typeof(System.String));
		}
		if (definedColums.ContainsKey("docdate")){ 
			defineColumn("docdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("expiration")){ 
			defineColumn("expiration", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idreg")){ 
			defineColumn("idreg", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nmov")){ 
			defineColumn("nmov", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("ymov")){ 
			defineColumn("ymov", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("idpayment")){ 
			defineColumn("idpayment", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idinc")){ 
			defineColumn("idinc", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("parentidinc")){ 
			defineColumn("parentidinc", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("nphase")){ 
			defineColumn("nphase", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("autokind")){ 
			defineColumn("autokind", typeof(System.Byte));
		}
		if (definedColums.ContainsKey("autocode")){ 
			defineColumn("autocode", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("cupcode")){ 
			defineColumn("cupcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("idunderwriting")){ 
			defineColumn("idunderwriting", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("external_reference")){ 
			defineColumn("external_reference", typeof(System.String));
		}
		#endregion

	}
}
}

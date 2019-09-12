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
using metadatalibrary;
namespace meta_expense {
public class expenseRow: MetaRow  {
	public expenseRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public Int32? idexp{ 
		get {if (this["idexp"]==DBNull.Value)return null; return  (Int32?)this["idexp"];}
		set {if (value==null) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public object idexpValue { 
		get{ return this["idexp"];}
		set {if (value==null|| value==DBNull.Value) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public Int32? idexpOriginal { 
		get {if (this["idexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp",DataRowVersion.Original];}
	}
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
public class expenseTable : MetaTableBase<expenseRow> {
	public expenseTable() : base("expense"){}
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
		if (definedColums.ContainsKey("idclawback")){ 
			defineColumn("idclawback", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idexp")){ 
			defineColumn("idexp", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("parentidexp")){ 
			defineColumn("parentidexp", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idpayment")){ 
			defineColumn("idpayment", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idformerexpense")){ 
			defineColumn("idformerexpense", typeof(System.Int32));
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
		if (definedColums.ContainsKey("cigcode")){ 
			defineColumn("cigcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("external_reference")){ 
			defineColumn("external_reference", typeof(System.String));
		}
		#endregion

	}
}
}

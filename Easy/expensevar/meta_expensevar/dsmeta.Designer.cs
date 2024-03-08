
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
using metadatalibrary;
namespace meta_expensevar {
public class expensevarRow: MetaRow  {
	public expensevarRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. variazione
	///</summary>
	public Int32? nvar{ 
		get {if (this["nvar"]==DBNull.Value)return null; return  (Int32?)this["nvar"];}
		set {if (value==null) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public object nvarValue { 
		get{ return this["nvar"];}
		set {if (value==null|| value==DBNull.Value) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public Int32? nvarOriginal { 
		get {if (this["nvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nvar",DataRowVersion.Original];}
	}
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
	///importo
	///</summary>
	public Decimal? amount{ 
		get {if (this["amount"]==DBNull.Value)return null; return  (Decimal?)this["amount"];}
		set {if (value==null) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {if (value==null|| value==DBNull.Value) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public Decimal? amountOriginal { 
		get {if (this["amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["amount",DataRowVersion.Original];}
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
	///Tipo trasf.
	///</summary>
	public String transferkind{ 
		get {if (this["transferkind"]==DBNull.Value)return null; return  (String)this["transferkind"];}
		set {if (value==null) this["transferkind"]= DBNull.Value; else this["transferkind"]= value;}
	}
	public object transferkindValue { 
		get{ return this["transferkind"];}
		set {if (value==null|| value==DBNull.Value) this["transferkind"]= DBNull.Value; else this["transferkind"]= value;}
	}
	public String transferkindOriginal { 
		get {if (this["transferkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transferkind",DataRowVersion.Original];}
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
	///Anno variazione
	///</summary>
	public Int16? yvar{ 
		get {if (this["yvar"]==DBNull.Value)return null; return  (Int16?)this["yvar"];}
		set {if (value==null) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public object yvarValue { 
		get{ return this["yvar"];}
		set {if (value==null|| value==DBNull.Value) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public Int16? yvarOriginal { 
		get {if (this["yvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yvar",DataRowVersion.Original];}
	}
	///<summary>
	///n.fattura
	///</summary>
	public Int32? ninv{ 
		get {if (this["ninv"]==DBNull.Value)return null; return  (Int32?)this["ninv"];}
		set {if (value==null) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public object ninvValue { 
		get{ return this["ninv"];}
		set {if (value==null|| value==DBNull.Value) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public Int32? ninvOriginal { 
		get {if (this["ninv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv",DataRowVersion.Original];}
	}
	///<summary>
	///anno fattura
	///</summary>
	public Int16? yinv{ 
		get {if (this["yinv"]==DBNull.Value)return null; return  (Int16?)this["yinv"];}
		set {if (value==null) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public object yinvValue { 
		get{ return this["yinv"];}
		set {if (value==null|| value==DBNull.Value) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public Int16? yinvOriginal { 
		get {if (this["yinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. spesa (tabella expense)
	///</summary>
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
	///codice automatismo, significato diverso a secondo di autokind, per es. se autokind ? una ritenuta, autocode ? l'id della ritenuta
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
	///Tipo movimento
	///</summary>
	public Int16? movkind{ 
		get {if (this["movkind"]==DBNull.Value)return null; return  (Int16?)this["movkind"];}
		set {if (value==null) this["movkind"]= DBNull.Value; else this["movkind"]= value;}
	}
	public object movkindValue { 
		get{ return this["movkind"];}
		set {if (value==null|| value==DBNull.Value) this["movkind"]= DBNull.Value; else this["movkind"]= value;}
	}
	public Int16? movkindOriginal { 
		get {if (this["movkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["movkind",DataRowVersion.Original];}
	}
	///<summary>
	///chiave elenco trasmissione in cui ? presente questa variazione ove sia un annullamento
	///</summary>
	public Int32? kpaymenttransmission{ 
		get {if (this["kpaymenttransmission"]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission"];}
		set {if (value==null) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public object kpaymenttransmissionValue { 
		get{ return this["kpaymenttransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public Int32? kpaymenttransmissionOriginal { 
		get {if (this["kpaymenttransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Variazione movimento di spesa
///</summary>
public class expensevarTable : MetaTableBase<expensevarRow> {
	public expensevarTable() : base("expensevar"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("nvar")){ 
			defineColumn("nvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
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
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("transferkind")){ 
			defineColumn("transferkind", typeof(System.String));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("yvar")){ 
			defineColumn("yvar", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("ninv")){ 
			defineColumn("ninv", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("yinv")){ 
			defineColumn("yinv", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("idexp")){ 
			defineColumn("idexp", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idpayment")){ 
			defineColumn("idpayment", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("autokind")){ 
			defineColumn("autokind", typeof(System.Byte));
		}
		if (definedColums.ContainsKey("autocode")){ 
			defineColumn("autocode", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idinvkind")){ 
			defineColumn("idinvkind", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("movkind")){ 
			defineColumn("movkind", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("kpaymenttransmission")){ 
			defineColumn("kpaymenttransmission", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idunderwriting")){ 
			defineColumn("idunderwriting", typeof(System.Int32));
		}
		#endregion

	}
}
}

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
namespace meta_incomevar {
public class incomevarRow: MetaRow  {
	public incomevarRow(DataRowBuilder rb) : base(rb) {} 

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
	///# elenco di trasmissione
	///</summary>
	public Int32? kproceedstransmission{ 
		get {if (this["kproceedstransmission"]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission"];}
		set {if (value==null) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public object kproceedstransmissionValue { 
		get{ return this["kproceedstransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public Int32? kproceedstransmissionOriginal { 
		get {if (this["kproceedstransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Variazione movimento di entrata
///</summary>
public class incomevarTable : MetaTableBase<incomevarRow> {
	public incomevarTable() : base("incomevar"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nvar",createColumn("nvar",typeof(Int32),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"amount",createColumn("amount",typeof(Decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"doc",createColumn("doc",typeof(String),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"transferkind",createColumn("transferkind",typeof(String),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"yvar",createColumn("yvar",typeof(Int16),false,false)},
			{"ninv",createColumn("ninv",typeof(Int32),true,false)},
			{"yinv",createColumn("yinv",typeof(Int16),true,false)},
			{"idinc",createColumn("idinc",typeof(Int32),false,false)},
			{"autokind",createColumn("autokind",typeof(Byte),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(Int32),true,false)},
			{"movkind",createColumn("movkind",typeof(Int16),true,false)},
			{"kproceedstransmission",createColumn("kproceedstransmission",typeof(Int32),true,false)},
		};
	}
}
}

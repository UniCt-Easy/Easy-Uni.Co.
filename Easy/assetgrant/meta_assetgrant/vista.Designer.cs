
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
namespace meta_assetgrant {
public class assetgrantRow: MetaRow  {
	public assetgrantRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Id cespite (tabella asset)
	///</summary>
	public Int32? idasset{ 
		get {if (this["idasset"]==DBNull.Value)return null; return  (Int32?)this["idasset"];}
		set {if (value==null) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public object idassetValue { 
		get{ return this["idasset"];}
		set {if (value==null|| value==DBNull.Value) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public Int32? idassetOriginal { 
		get {if (this["idasset",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idasset",DataRowVersion.Original];}
	}
	///<summary>
	///chiave incrementale
	///</summary>
	public Int32? idgrant{ 
		get {if (this["idgrant"]==DBNull.Value)return null; return  (Int32?)this["idgrant"];}
		set {if (value==null) this["idgrant"]= DBNull.Value; else this["idgrant"]= value;}
	}
	public object idgrantValue { 
		get{ return this["idgrant"];}
		set {if (value==null|| value==DBNull.Value) this["idgrant"]= DBNull.Value; else this["idgrant"]= value;}
	}
	public Int32? idgrantOriginal { 
		get {if (this["idgrant",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgrant",DataRowVersion.Original];}
	}
	///<summary>
	///chiave finanziamento (underwriting)
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
	///Causale di ricavo per il contributo
	///</summary>
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
	///<summary>
	///Importo
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
	///Anno contributo
	///</summary>
	public Int16? ygrant{ 
		get {if (this["ygrant"]==DBNull.Value)return null; return  (Int16?)this["ygrant"];}
		set {if (value==null) this["ygrant"]= DBNull.Value; else this["ygrant"]= value;}
	}
	public object ygrantValue { 
		get{ return this["ygrant"];}
		set {if (value==null|| value==DBNull.Value) this["ygrant"]= DBNull.Value; else this["ygrant"]= value;}
	}
	public Int16? ygrantOriginal { 
		get {if (this["ygrant",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ygrant",DataRowVersion.Original];}
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
	///Documento
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
	///Data documento
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
	///chiave scarico contributo
	///</summary>
	public Int32? idgrantload{ 
		get {if (this["idgrantload"]==DBNull.Value)return null; return  (Int32?)this["idgrantload"];}
		set {if (value==null) this["idgrantload"]= DBNull.Value; else this["idgrantload"]= value;}
	}
	public object idgrantloadValue { 
		get{ return this["idgrantload"];}
		set {if (value==null|| value==DBNull.Value) this["idgrantload"]= DBNull.Value; else this["idgrantload"]= value;}
	}
	public Int32? idgrantloadOriginal { 
		get {if (this["idgrantload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgrantload",DataRowVersion.Original];}
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
	///n. accessorio, 1 se cespite principale
	///</summary>
	public Int32? idpiece{ 
		get {if (this["idpiece"]==DBNull.Value)return null; return  (Int32?)this["idpiece"];}
		set {if (value==null) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public object idpieceValue { 
		get{ return this["idpiece"];}
		set {if (value==null|| value==DBNull.Value) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public Int32? idpieceOriginal { 
		get {if (this["idpiece",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpiece",DataRowVersion.Original];}
	}
	///<summary>
	///ID Accertamento di Budget
	///</summary>
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
	#endregion

}
///<summary>
///Attribuzione di un contributo conto impianti ad un cespite
///</summary>
public class assetgrantTable : MetaTableBase<assetgrantRow> {
	public assetgrantTable() : base("assetgrant"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idasset",createColumn("idasset",typeof(Int32),false,false)},
			{"idgrant",createColumn("idgrant",typeof(Int32),false,false)},
			{"idunderwriting",createColumn("idunderwriting",typeof(Int32),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(String),true,false)},
			{"amount",createColumn("amount",typeof(Decimal),false,false)},
			{"ygrant",createColumn("ygrant",typeof(Int16),true,false)},
			{"description",createColumn("description",typeof(String),true,false)},
			{"doc",createColumn("doc",typeof(String),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"idgrantload",createColumn("idgrantload",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(String),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(String),true,false)},
			{"idpiece",createColumn("idpiece",typeof(Int32),false,false)},
			{"idepacc",createColumn("idepacc",typeof(Int32),true,false)},
		};
	}
}
}

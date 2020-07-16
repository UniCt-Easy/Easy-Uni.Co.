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
namespace meta_assetgrantview {
public class assetgrantviewRow: MetaRow  {
	public assetgrantviewRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public String codemotive{ 
		get {if (this["codemotive"]==DBNull.Value)return null; return  (String)this["codemotive"];}
		set {if (value==null) this["codemotive"]= DBNull.Value; else this["codemotive"]= value;}
	}
	public object codemotiveValue { 
		get{ return this["codemotive"];}
		set {if (value==null|| value==DBNull.Value) this["codemotive"]= DBNull.Value; else this["codemotive"]= value;}
	}
	public String codemotiveOriginal { 
		get {if (this["codemotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codemotive",DataRowVersion.Original];}
	}
	public String motive{ 
		get {if (this["motive"]==DBNull.Value)return null; return  (String)this["motive"];}
		set {if (value==null) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public object motiveValue { 
		get{ return this["motive"];}
		set {if (value==null|| value==DBNull.Value) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public String motiveOriginal { 
		get {if (this["motive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive",DataRowVersion.Original];}
	}
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
	public String codeunderwriting{ 
		get {if (this["codeunderwriting"]==DBNull.Value)return null; return  (String)this["codeunderwriting"];}
		set {if (value==null) this["codeunderwriting"]= DBNull.Value; else this["codeunderwriting"]= value;}
	}
	public object codeunderwritingValue { 
		get{ return this["codeunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["codeunderwriting"]= DBNull.Value; else this["codeunderwriting"]= value;}
	}
	public String codeunderwritingOriginal { 
		get {if (this["codeunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeunderwriting",DataRowVersion.Original];}
	}
	public String underwriting{ 
		get {if (this["underwriting"]==DBNull.Value)return null; return  (String)this["underwriting"];}
		set {if (value==null) this["underwriting"]= DBNull.Value; else this["underwriting"]= value;}
	}
	public object underwritingValue { 
		get{ return this["underwriting"];}
		set {if (value==null|| value==DBNull.Value) this["underwriting"]= DBNull.Value; else this["underwriting"]= value;}
	}
	public String underwritingOriginal { 
		get {if (this["underwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["underwriting",DataRowVersion.Original];}
	}
	public Int32? ninventory{ 
		get {if (this["ninventory"]==DBNull.Value)return null; return  (Int32?)this["ninventory"];}
		set {if (value==null) this["ninventory"]= DBNull.Value; else this["ninventory"]= value;}
	}
	public object ninventoryValue { 
		get{ return this["ninventory"];}
		set {if (value==null|| value==DBNull.Value) this["ninventory"]= DBNull.Value; else this["ninventory"]= value;}
	}
	public Int32? ninventoryOriginal { 
		get {if (this["ninventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninventory",DataRowVersion.Original];}
	}
	public Int32? idinventory{ 
		get {if (this["idinventory"]==DBNull.Value)return null; return  (Int32?)this["idinventory"];}
		set {if (value==null) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {if (value==null|| value==DBNull.Value) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public Int32? idinventoryOriginal { 
		get {if (this["idinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventory",DataRowVersion.Original];}
	}
	public String codeinventory{ 
		get {if (this["codeinventory"]==DBNull.Value)return null; return  (String)this["codeinventory"];}
		set {if (value==null) this["codeinventory"]= DBNull.Value; else this["codeinventory"]= value;}
	}
	public object codeinventoryValue { 
		get{ return this["codeinventory"];}
		set {if (value==null|| value==DBNull.Value) this["codeinventory"]= DBNull.Value; else this["codeinventory"]= value;}
	}
	public String codeinventoryOriginal { 
		get {if (this["codeinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeinventory",DataRowVersion.Original];}
	}
	public String inventory{ 
		get {if (this["inventory"]==DBNull.Value)return null; return  (String)this["inventory"];}
		set {if (value==null) this["inventory"]= DBNull.Value; else this["inventory"]= value;}
	}
	public object inventoryValue { 
		get{ return this["inventory"];}
		set {if (value==null|| value==DBNull.Value) this["inventory"]= DBNull.Value; else this["inventory"]= value;}
	}
	public String inventoryOriginal { 
		get {if (this["inventory",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["inventory",DataRowVersion.Original];}
	}
	public Int32? idinventoryagency{ 
		get {if (this["idinventoryagency"]==DBNull.Value)return null; return  (Int32?)this["idinventoryagency"];}
		set {if (value==null) this["idinventoryagency"]= DBNull.Value; else this["idinventoryagency"]= value;}
	}
	public object idinventoryagencyValue { 
		get{ return this["idinventoryagency"];}
		set {if (value==null|| value==DBNull.Value) this["idinventoryagency"]= DBNull.Value; else this["idinventoryagency"]= value;}
	}
	public Int32? idinventoryagencyOriginal { 
		get {if (this["idinventoryagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventoryagency",DataRowVersion.Original];}
	}
	public String codeinventoryagency{ 
		get {if (this["codeinventoryagency"]==DBNull.Value)return null; return  (String)this["codeinventoryagency"];}
		set {if (value==null) this["codeinventoryagency"]= DBNull.Value; else this["codeinventoryagency"]= value;}
	}
	public object codeinventoryagencyValue { 
		get{ return this["codeinventoryagency"];}
		set {if (value==null|| value==DBNull.Value) this["codeinventoryagency"]= DBNull.Value; else this["codeinventoryagency"]= value;}
	}
	public String codeinventoryagencyOriginal { 
		get {if (this["codeinventoryagency",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeinventoryagency",DataRowVersion.Original];}
	}
	public String inventoryagency{ 
		get {if (this["inventoryagency"]==DBNull.Value)return null; return  (String)this["inventoryagency"];}
		set {if (value==null) this["inventoryagency"]= DBNull.Value; else this["inventoryagency"]= value;}
	}
	public object inventoryagencyValue { 
		get{ return this["inventoryagency"];}
		set {if (value==null|| value==DBNull.Value) this["inventoryagency"]= DBNull.Value; else this["inventoryagency"]= value;}
	}
	public String inventoryagencyOriginal { 
		get {if (this["inventoryagency",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["inventoryagency",DataRowVersion.Original];}
	}
	public Int32? idinv{ 
		get {if (this["idinv"]==DBNull.Value)return null; return  (Int32?)this["idinv"];}
		set {if (value==null) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {if (value==null|| value==DBNull.Value) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public Int32? idinvOriginal { 
		get {if (this["idinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinv",DataRowVersion.Original];}
	}
	public String codeinv{ 
		get {if (this["codeinv"]==DBNull.Value)return null; return  (String)this["codeinv"];}
		set {if (value==null) this["codeinv"]= DBNull.Value; else this["codeinv"]= value;}
	}
	public object codeinvValue { 
		get{ return this["codeinv"];}
		set {if (value==null|| value==DBNull.Value) this["codeinv"]= DBNull.Value; else this["codeinv"]= value;}
	}
	public String codeinvOriginal { 
		get {if (this["codeinv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeinv",DataRowVersion.Original];}
	}
	public String inventorytree{ 
		get {if (this["inventorytree"]==DBNull.Value)return null; return  (String)this["inventorytree"];}
		set {if (value==null) this["inventorytree"]= DBNull.Value; else this["inventorytree"]= value;}
	}
	public object inventorytreeValue { 
		get{ return this["inventorytree"];}
		set {if (value==null|| value==DBNull.Value) this["inventorytree"]= DBNull.Value; else this["inventorytree"]= value;}
	}
	public String inventorytreeOriginal { 
		get {if (this["inventorytree",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["inventorytree",DataRowVersion.Original];}
	}
	public String cost{ 
		get {if (this["cost"]==DBNull.Value)return null; return  (String)this["cost"];}
		set {if (value==null) this["cost"]= DBNull.Value; else this["cost"]= value;}
	}
	public object costValue { 
		get{ return this["cost"];}
		set {if (value==null|| value==DBNull.Value) this["cost"]= DBNull.Value; else this["cost"]= value;}
	}
	public String costOriginal { 
		get {if (this["cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cost",DataRowVersion.Original];}
	}
	public Decimal? assetacquiretotal{ 
		get {if (this["assetacquiretotal"]==DBNull.Value)return null; return  (Decimal?)this["assetacquiretotal"];}
		set {if (value==null) this["assetacquiretotal"]= DBNull.Value; else this["assetacquiretotal"]= value;}
	}
	public object assetacquiretotalValue { 
		get{ return this["assetacquiretotal"];}
		set {if (value==null|| value==DBNull.Value) this["assetacquiretotal"]= DBNull.Value; else this["assetacquiretotal"]= value;}
	}
	public Decimal? assetacquiretotalOriginal { 
		get {if (this["assetacquiretotal",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["assetacquiretotal",DataRowVersion.Original];}
	}
	#endregion

}
public class assetgrantviewTable : MetaTableBase<assetgrantviewRow> {
	public assetgrantviewTable() : base("assetgrantview"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idasset",createColumn("idasset",typeof(int),false,false)},
			{"idpiece",createColumn("idpiece",typeof(int),false,false)},
			{"idgrant",createColumn("idgrant",typeof(int),false,false)},
			{"amount",createColumn("amount",typeof(decimal),false,false)},
			{"ygrant",createColumn("ygrant",typeof(short),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"idgrantload",createColumn("idgrantload",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"codemotive",createColumn("codemotive",typeof(string),true,false)},
			{"motive",createColumn("motive",typeof(string),true,false)},
			{"idunderwriting",createColumn("idunderwriting",typeof(int),true,false)},
			{"codeunderwriting",createColumn("codeunderwriting",typeof(string),true,false)},
			{"underwriting",createColumn("underwriting",typeof(string),true,false)},
			{"ninventory",createColumn("ninventory",typeof(int),true,false)},
			{"idinventory",createColumn("idinventory",typeof(int),false,false)},
			{"codeinventory",createColumn("codeinventory",typeof(string),false,false)},
			{"inventory",createColumn("inventory",typeof(string),false,false)},
			{"idinventoryagency",createColumn("idinventoryagency",typeof(int),false,false)},
			{"codeinventoryagency",createColumn("codeinventoryagency",typeof(string),false,false)},
			{"inventoryagency",createColumn("inventoryagency",typeof(string),false,false)},
			{"idinv",createColumn("idinv",typeof(int),false,false)},
			{"codeinv",createColumn("codeinv",typeof(string),false,false)},
			{"inventorytree",createColumn("inventorytree",typeof(string),false,false)},
			{"cost",createColumn("cost",typeof(string),true,false)},
			{"assetacquiretotal",createColumn("assetacquiretotal",typeof(decimal),true,false)},
		};
	}
}
}

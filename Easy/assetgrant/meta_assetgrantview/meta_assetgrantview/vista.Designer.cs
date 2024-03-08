
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_assetgrantview {
public class assetgrantviewRow: MetaRow  {
	public assetgrantviewRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idasset{ 
		get {return  (Int32)this["idasset"];}
		set {this["idasset"]= value;}
	}
	public object idassetValue { 
		get{ return this["idasset"];}
		set {this["idasset"]= value;}
	}
	public Int32 idassetOriginal { 
		get {return  (Int32)this["idasset",DataRowVersion.Original];}
	}
	public Int32 idpiece{ 
		get {return  (Int32)this["idpiece"];}
		set {this["idpiece"]= value;}
	}
	public object idpieceValue { 
		get{ return this["idpiece"];}
		set {this["idpiece"]= value;}
	}
	public Int32 idpieceOriginal { 
		get {return  (Int32)this["idpiece",DataRowVersion.Original];}
	}
	public Int32 idgrant{ 
		get {return  (Int32)this["idgrant"];}
		set {this["idgrant"]= value;}
	}
	public object idgrantValue { 
		get{ return this["idgrant"];}
		set {this["idgrant"]= value;}
	}
	public Int32 idgrantOriginal { 
		get {return  (Int32)this["idgrant",DataRowVersion.Original];}
	}
	public Decimal amount{ 
		get {return  (Decimal)this["amount"];}
		set {this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {this["amount"]= value;}
	}
	public Decimal amountOriginal { 
		get {return  (Decimal)this["amount",DataRowVersion.Original];}
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
	public Int32 idinventory{ 
		get {return  (Int32)this["idinventory"];}
		set {this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {this["idinventory"]= value;}
	}
	public Int32 idinventoryOriginal { 
		get {return  (Int32)this["idinventory",DataRowVersion.Original];}
	}
	public String codeinventory{ 
		get {return  (String)this["codeinventory"];}
		set {this["codeinventory"]= value;}
	}
	public object codeinventoryValue { 
		get{ return this["codeinventory"];}
		set {this["codeinventory"]= value;}
	}
	public String codeinventoryOriginal { 
		get {return  (String)this["codeinventory",DataRowVersion.Original];}
	}
	public String inventory{ 
		get {return  (String)this["inventory"];}
		set {this["inventory"]= value;}
	}
	public object inventoryValue { 
		get{ return this["inventory"];}
		set {this["inventory"]= value;}
	}
	public String inventoryOriginal { 
		get {return  (String)this["inventory",DataRowVersion.Original];}
	}
	public Int32 idinventoryagency{ 
		get {return  (Int32)this["idinventoryagency"];}
		set {this["idinventoryagency"]= value;}
	}
	public object idinventoryagencyValue { 
		get{ return this["idinventoryagency"];}
		set {this["idinventoryagency"]= value;}
	}
	public Int32 idinventoryagencyOriginal { 
		get {return  (Int32)this["idinventoryagency",DataRowVersion.Original];}
	}
	public String codeinventoryagency{ 
		get {return  (String)this["codeinventoryagency"];}
		set {this["codeinventoryagency"]= value;}
	}
	public object codeinventoryagencyValue { 
		get{ return this["codeinventoryagency"];}
		set {this["codeinventoryagency"]= value;}
	}
	public String codeinventoryagencyOriginal { 
		get {return  (String)this["codeinventoryagency",DataRowVersion.Original];}
	}
	public String inventoryagency{ 
		get {return  (String)this["inventoryagency"];}
		set {this["inventoryagency"]= value;}
	}
	public object inventoryagencyValue { 
		get{ return this["inventoryagency"];}
		set {this["inventoryagency"]= value;}
	}
	public String inventoryagencyOriginal { 
		get {return  (String)this["inventoryagency",DataRowVersion.Original];}
	}
	public Int32 idinv{ 
		get {return  (Int32)this["idinv"];}
		set {this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {this["idinv"]= value;}
	}
	public Int32 idinvOriginal { 
		get {return  (Int32)this["idinv",DataRowVersion.Original];}
	}
	public String codeinv{ 
		get {return  (String)this["codeinv"];}
		set {this["codeinv"]= value;}
	}
	public object codeinvValue { 
		get{ return this["codeinv"];}
		set {this["codeinv"]= value;}
	}
	public String codeinvOriginal { 
		get {return  (String)this["codeinv",DataRowVersion.Original];}
	}
	public String inventorytree{ 
		get {return  (String)this["inventorytree"];}
		set {this["inventorytree"]= value;}
	}
	public object inventorytreeValue { 
		get{ return this["inventorytree"];}
		set {this["inventorytree"]= value;}
	}
	public String inventorytreeOriginal { 
		get {return  (String)this["inventorytree",DataRowVersion.Original];}
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
	public String flag_entryprofitreservedone{ 
		get {if (this["flag_entryprofitreservedone"]==DBNull.Value)return null; return  (String)this["flag_entryprofitreservedone"];}
		set {if (value==null) this["flag_entryprofitreservedone"]= DBNull.Value; else this["flag_entryprofitreservedone"]= value;}
	}
	public object flag_entryprofitreservedoneValue { 
		get{ return this["flag_entryprofitreservedone"];}
		set {if (value==null|| value==DBNull.Value) this["flag_entryprofitreservedone"]= DBNull.Value; else this["flag_entryprofitreservedone"]= value;}
	}
	public String flag_entryprofitreservedoneOriginal { 
		get {if (this["flag_entryprofitreservedone",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_entryprofitreservedone",DataRowVersion.Original];}
	}
	public String flag_financesource{ 
		get {if (this["flag_financesource"]==DBNull.Value)return null; return  (String)this["flag_financesource"];}
		set {if (value==null) this["flag_financesource"]= DBNull.Value; else this["flag_financesource"]= value;}
	}
	public object flag_financesourceValue { 
		get{ return this["flag_financesource"];}
		set {if (value==null|| value==DBNull.Value) this["flag_financesource"]= DBNull.Value; else this["flag_financesource"]= value;}
	}
	public String flag_financesourceOriginal { 
		get {if (this["flag_financesource",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_financesource",DataRowVersion.Original];}
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
			{"flag_entryprofitreservedone",createColumn("flag_entryprofitreservedone",typeof(string),true,false)},
			{"flag_financesource",createColumn("flag_financesource",typeof(string),true,false)},
		};
	}
}
}

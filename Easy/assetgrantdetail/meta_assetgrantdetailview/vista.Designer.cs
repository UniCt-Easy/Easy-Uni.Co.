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
namespace meta_assetgrantdetailview {
public class assetgrantdetailviewRow: MetaRow  {
	public assetgrantdetailviewRow(DataRowBuilder rb) : base(rb) {} 

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
	public String grantdescription{ 
		get {if (this["grantdescription"]==DBNull.Value)return null; return  (String)this["grantdescription"];}
		set {if (value==null) this["grantdescription"]= DBNull.Value; else this["grantdescription"]= value;}
	}
	public object grantdescriptionValue { 
		get{ return this["grantdescription"];}
		set {if (value==null|| value==DBNull.Value) this["grantdescription"]= DBNull.Value; else this["grantdescription"]= value;}
	}
	public String grantdescriptionOriginal { 
		get {if (this["grantdescription",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["grantdescription",DataRowVersion.Original];}
	}
	public Int32? iddetail{ 
		get {if (this["iddetail"]==DBNull.Value)return null; return  (Int32?)this["iddetail"];}
		set {if (value==null) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {if (value==null|| value==DBNull.Value) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public Int32? iddetailOriginal { 
		get {if (this["iddetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddetail",DataRowVersion.Original];}
	}
	public Int16? ydetail{ 
		get {if (this["ydetail"]==DBNull.Value)return null; return  (Int16?)this["ydetail"];}
		set {if (value==null) this["ydetail"]= DBNull.Value; else this["ydetail"]= value;}
	}
	public object ydetailValue { 
		get{ return this["ydetail"];}
		set {if (value==null|| value==DBNull.Value) this["ydetail"]= DBNull.Value; else this["ydetail"]= value;}
	}
	public Int16? ydetailOriginal { 
		get {if (this["ydetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ydetail",DataRowVersion.Original];}
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
	#endregion

}
public class assetgrantdetailviewTable : MetaTableBase<assetgrantdetailviewRow> {
	public assetgrantdetailviewTable() : base("assetgrantdetailview"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idasset")){ 
			defineColumn("idasset", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idpiece")){ 
			defineColumn("idpiece", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ninventory")){ 
			defineColumn("ninventory", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idinventory")){ 
			defineColumn("idinventory", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("inventory")){ 
			defineColumn("inventory", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("codeinventory")){ 
			defineColumn("codeinventory", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idgrant")){ 
			defineColumn("idgrant", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("grantdescription")){ 
			defineColumn("grantdescription", typeof(System.String));
		}
		if (definedColums.ContainsKey("iddetail")){ 
			defineColumn("iddetail", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ydetail")){ 
			defineColumn("ydetail", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
		}
		#endregion

	}
}
}

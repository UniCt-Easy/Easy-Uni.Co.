
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
namespace meta_assetload {
public class assetloadRow: MetaRow  {
	public assetloadRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 nassetload{ 
		get {return  (Int32)this["nassetload"];}
		set {this["nassetload"]= value;}
	}
	public object nassetloadValue { 
		get{ return this["nassetload"];}
		set {this["nassetload"]= value;}
	}
	public Int32 nassetloadOriginal { 
		get {return  (Int32)this["nassetload",DataRowVersion.Original];}
	}
	public Int16 yassetload{ 
		get {return  (Int16)this["yassetload"];}
		set {this["yassetload"]= value;}
	}
	public object yassetloadValue { 
		get{ return this["yassetload"];}
		set {this["yassetload"]= value;}
	}
	public Int16 yassetloadOriginal { 
		get {return  (Int16)this["yassetload",DataRowVersion.Original];}
	}
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
	public String enactment{ 
		get {if (this["enactment"]==DBNull.Value)return null; return  (String)this["enactment"];}
		set {if (value==null) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public object enactmentValue { 
		get{ return this["enactment"];}
		set {if (value==null|| value==DBNull.Value) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public String enactmentOriginal { 
		get {if (this["enactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enactment",DataRowVersion.Original];}
	}
	public DateTime? enactmentdate{ 
		get {if (this["enactmentdate"]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate"];}
		set {if (value==null) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public object enactmentdateValue { 
		get{ return this["enactmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public DateTime? enactmentdateOriginal { 
		get {if (this["enactmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate",DataRowVersion.Original];}
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
	public DateTime? printdate{ 
		get {if (this["printdate"]==DBNull.Value)return null; return  (DateTime?)this["printdate"];}
		set {if (value==null) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public object printdateValue { 
		get{ return this["printdate"];}
		set {if (value==null|| value==DBNull.Value) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public DateTime? printdateOriginal { 
		get {if (this["printdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["printdate",DataRowVersion.Original];}
	}
	public DateTime? ratificationdate{ 
		get {if (this["ratificationdate"]==DBNull.Value)return null; return  (DateTime?)this["ratificationdate"];}
		set {if (value==null) this["ratificationdate"]= DBNull.Value; else this["ratificationdate"]= value;}
	}
	public object ratificationdateValue { 
		get{ return this["ratificationdate"];}
		set {if (value==null|| value==DBNull.Value) this["ratificationdate"]= DBNull.Value; else this["ratificationdate"]= value;}
	}
	public DateTime? ratificationdateOriginal { 
		get {if (this["ratificationdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ratificationdate",DataRowVersion.Original];}
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
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	public Int32? idmot{ 
		get {if (this["idmot"]==DBNull.Value)return null; return  (Int32?)this["idmot"];}
		set {if (value==null) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public object idmotValue { 
		get{ return this["idmot"];}
		set {if (value==null|| value==DBNull.Value) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public Int32? idmotOriginal { 
		get {if (this["idmot",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmot",DataRowVersion.Original];}
	}
	public Int32 idassetloadkind{ 
		get {return  (Int32)this["idassetloadkind"];}
		set {this["idassetloadkind"]= value;}
	}
	public object idassetloadkindValue { 
		get{ return this["idassetloadkind"];}
		set {this["idassetloadkind"]= value;}
	}
	public Int32 idassetloadkindOriginal { 
		get {return  (Int32)this["idassetloadkind",DataRowVersion.Original];}
	}
	public Int32 idassetload{ 
		get {return  (Int32)this["idassetload"];}
		set {this["idassetload"]= value;}
	}
	public object idassetloadValue { 
		get{ return this["idassetload"];}
		set {this["idassetload"]= value;}
	}
	public Int32 idassetloadOriginal { 
		get {return  (Int32)this["idassetload",DataRowVersion.Original];}
	}
	public Int32? idcostpartition{ 
		get {if (this["idcostpartition"]==DBNull.Value)return null; return  (Int32?)this["idcostpartition"];}
		set {if (value==null) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public object idcostpartitionValue { 
		get{ return this["idcostpartition"];}
		set {if (value==null|| value==DBNull.Value) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public Int32? idcostpartitionOriginal { 
		get {if (this["idcostpartition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcostpartition",DataRowVersion.Original];}
	}
	#endregion

}
public class assetloadTable : MetaTableBase<assetloadRow> {
	public assetloadTable() : base("assetload"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nassetload",createColumn("nassetload",typeof(int),false,false)},
			{"yassetload",createColumn("yassetload",typeof(short),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"enactment",createColumn("enactment",typeof(string),true,false)},
			{"enactmentdate",createColumn("enactmentdate",typeof(DateTime),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"printdate",createColumn("printdate",typeof(DateTime),true,false)},
			{"ratificationdate",createColumn("ratificationdate",typeof(DateTime),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"transmitted",createColumn("transmitted",typeof(string),true,false)},
			{"idmot",createColumn("idmot",typeof(int),true,false)},
			{"idassetloadkind",createColumn("idassetloadkind",typeof(int),false,false)},
			{"idassetload",createColumn("idassetload",typeof(int),false,false)},
			{"idcostpartition",createColumn("idcostpartition",typeof(int),true,false)},
		};
	}
}
}

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
using metadatalibrary;
namespace meta_assetgrantdetail {
public class assetgrantdetailRow: MetaRow  {
	public assetgrantdetailRow(DataRowBuilder rb) : base(rb) {} 

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
public class assetgrantdetailTable : MetaTableBase<assetgrantdetailRow> {
	public assetgrantdetailTable() : base("assetgrantdetail"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idasset")){ 
			defineColumn("idasset", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idgrant")){ 
			defineColumn("idgrant", typeof(System.Int32),false);
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
		if (definedColums.ContainsKey("idgrantload")){ 
			defineColumn("idgrantload", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String));
		}
		if (definedColums.ContainsKey("idpiece")){ 
			defineColumn("idpiece", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idepacc")){ 
			defineColumn("idepacc", typeof(System.Int32));
		}
		#endregion

	}
}
}

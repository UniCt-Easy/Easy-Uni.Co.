
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_menuweb {
public class menuwebRow: MetaRow  {
	public menuwebRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idmenuweb{ 
		get {if (this["idmenuweb"]==DBNull.Value)return null; return  (Int32?)this["idmenuweb"];}
		set {if (value==null) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public object idmenuwebValue { 
		get{ return this["idmenuweb"];}
		set {if (value==null|| value==DBNull.Value) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public Int32? idmenuwebOriginal { 
		get {if (this["idmenuweb",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmenuweb",DataRowVersion.Original];}
	}
	public Int32? idmenuwebparent{ 
		get {if (this["idmenuwebparent"]==DBNull.Value)return null; return  (Int32?)this["idmenuwebparent"];}
		set {if (value==null) this["idmenuwebparent"]= DBNull.Value; else this["idmenuwebparent"]= value;}
	}
	public object idmenuwebparentValue { 
		get{ return this["idmenuwebparent"];}
		set {if (value==null|| value==DBNull.Value) this["idmenuwebparent"]= DBNull.Value; else this["idmenuwebparent"]= value;}
	}
	public Int32? idmenuwebparentOriginal { 
		get {if (this["idmenuwebparent",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmenuwebparent",DataRowVersion.Original];}
	}
	public String app{ 
		get {if (this["app"]==DBNull.Value)return null; return  (String)this["app"];}
		set {if (value==null) this["app"]= DBNull.Value; else this["app"]= value;}
	}
	public object appValue { 
		get{ return this["app"];}
		set {if (value==null|| value==DBNull.Value) this["app"]= DBNull.Value; else this["app"]= value;}
	}
	public String appOriginal { 
		get {if (this["app",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["app",DataRowVersion.Original];}
	}
	public String tableName{ 
		get {if (this["tableName"]==DBNull.Value)return null; return  (String)this["tableName"];}
		set {if (value==null) this["tableName"]= DBNull.Value; else this["tableName"]= value;}
	}
	public object tableNameValue { 
		get{ return this["tableName"];}
		set {if (value==null|| value==DBNull.Value) this["tableName"]= DBNull.Value; else this["tableName"]= value;}
	}
	public String tableNameOriginal { 
		get {if (this["tableName",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tableName",DataRowVersion.Original];}
	}
	public String editType{ 
		get {if (this["editType"]==DBNull.Value)return null; return  (String)this["editType"];}
		set {if (value==null) this["editType"]= DBNull.Value; else this["editType"]= value;}
	}
	public object editTypeValue { 
		get{ return this["editType"];}
		set {if (value==null|| value==DBNull.Value) this["editType"]= DBNull.Value; else this["editType"]= value;}
	}
	public String editTypeOriginal { 
		get {if (this["editType",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["editType",DataRowVersion.Original];}
	}
	public String label{ 
		get {if (this["label"]==DBNull.Value)return null; return  (String)this["label"];}
		set {if (value==null) this["label"]= DBNull.Value; else this["label"]= value;}
	}
	public object labelValue { 
		get{ return this["label"];}
		set {if (value==null|| value==DBNull.Value) this["label"]= DBNull.Value; else this["label"]= value;}
	}
	public String labelOriginal { 
		get {if (this["label",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["label",DataRowVersion.Original];}
	}
	public Int32? sort{ 
		get {if (this["sort"]==DBNull.Value)return null; return  (Int32?)this["sort"];}
		set {if (value==null) this["sort"]= DBNull.Value; else this["sort"]= value;}
	}
	public object sortValue { 
		get{ return this["sort"];}
		set {if (value==null|| value==DBNull.Value) this["sort"]= DBNull.Value; else this["sort"]= value;}
	}
	public Int32? sortOriginal { 
		get {if (this["sort",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["sort",DataRowVersion.Original];}
	}
	public String link{ 
		get {if (this["link"]==DBNull.Value)return null; return  (String)this["link"];}
		set {if (value==null) this["link"]= DBNull.Value; else this["link"]= value;}
	}
	public object linkValue { 
		get{ return this["link"];}
		set {if (value==null|| value==DBNull.Value) this["link"]= DBNull.Value; else this["link"]= value;}
	}
	public String linkOriginal { 
		get {if (this["link",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["link",DataRowVersion.Original];}
	}
	#endregion

}
public class menuwebTable : MetaTableBase<menuwebRow> {
	public menuwebTable() : base("menuweb"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idmenuweb",createColumn("idmenuweb",typeof(int),false,false)},
			{"idmenuwebparent",createColumn("idmenuwebparent",typeof(int),true,false)},
			{"app",createColumn("app",typeof(string),true,false)},
			{"tableName",createColumn("tableName",typeof(string),true,false)},
			{"editType",createColumn("editType",typeof(string),true,false)},
			{"label",createColumn("label",typeof(string),false,false)},
			{"sort",createColumn("sort",typeof(int),true,false)},
			{"link",createColumn("link",typeof(string),true,false)},
		};
	}
}
}

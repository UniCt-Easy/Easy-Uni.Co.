
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
namespace meta_emisti_import {
public class emisti_importRow: MetaRow  {
	public emisti_importRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idemisti_import{ 
		get {return  (Int32)this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public object idemisti_importValue { 
		get{ return this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public Int32 idemisti_importOriginal { 
		get {return  (Int32)this["idemisti_import",DataRowVersion.Original];}
	}
	public DateTime adate{ 
		get {return  (DateTime)this["adate"];}
		set {this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {this["adate"]= value;}
	}
	public DateTime adateOriginal { 
		get {return  (DateTime)this["adate",DataRowVersion.Original];}
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
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
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
	public Int32 nimport{ 
		get {return  (Int32)this["nimport"];}
		set {this["nimport"]= value;}
	}
	public object nimportValue { 
		get{ return this["nimport"];}
		set {this["nimport"]= value;}
	}
	public Int32 nimportOriginal { 
		get {return  (Int32)this["nimport",DataRowVersion.Original];}
	}
	public Int16 yimport{ 
		get {return  (Int16)this["yimport"];}
		set {this["yimport"]= value;}
	}
	public object yimportValue { 
		get{ return this["yimport"];}
		set {this["yimport"]= value;}
	}
	public Int16 yimportOriginal { 
		get {return  (Int16)this["yimport",DataRowVersion.Original];}
	}
	public String refexternaldoc{ 
		get {if (this["refexternaldoc"]==DBNull.Value)return null; return  (String)this["refexternaldoc"];}
		set {if (value==null) this["refexternaldoc"]= DBNull.Value; else this["refexternaldoc"]= value;}
	}
	public object refexternaldocValue { 
		get{ return this["refexternaldoc"];}
		set {if (value==null|| value==DBNull.Value) this["refexternaldoc"]= DBNull.Value; else this["refexternaldoc"]= value;}
	}
	public String refexternaldocOriginal { 
		get {if (this["refexternaldoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["refexternaldoc",DataRowVersion.Original];}
	}
	public Int32? idcsa_import{ 
		get {if (this["idcsa_import"]==DBNull.Value)return null; return  (Int32?)this["idcsa_import"];}
		set {if (value==null) this["idcsa_import"]= DBNull.Value; else this["idcsa_import"]= value;}
	}
	public object idcsa_importValue { 
		get{ return this["idcsa_import"];}
		set {if (value==null|| value==DBNull.Value) this["idcsa_import"]= DBNull.Value; else this["idcsa_import"]= value;}
	}
	public Int32? idcsa_importOriginal { 
		get {if (this["idcsa_import",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcsa_import",DataRowVersion.Original];}
	}
	#endregion

}
public class emisti_importTable : MetaTableBase<emisti_importRow> {
	public emisti_importTable() : base("emisti_import"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idemisti_import",createColumn("idemisti_import",typeof(int),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nimport",createColumn("nimport",typeof(int),false,false)},
			{"yimport",createColumn("yimport",typeof(short),false,false)},
			{"refexternaldoc",createColumn("refexternaldoc",typeof(string),true,false)},
			{"idcsa_import",createColumn("idcsa_import",typeof(int),true,false)},
		};
	}
}
}

/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace meta_ivaregisterkind {
public class ivaregisterkindRow: MetaRow  {
	public ivaregisterkindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public String registerclass{ 
		get {return  (String)this["registerclass"];}
		set {this["registerclass"]= value;}
	}
	public object registerclassValue { 
		get{ return this["registerclass"];}
		set {this["registerclass"]= value;}
	}
	public String registerclassOriginal { 
		get {return  (String)this["registerclass",DataRowVersion.Original];}
	}
	public String idivaregisterkindunified{ 
		get {if (this["idivaregisterkindunified"]==DBNull.Value)return null; return  (String)this["idivaregisterkindunified"];}
		set {if (value==null) this["idivaregisterkindunified"]= DBNull.Value; else this["idivaregisterkindunified"]= value;}
	}
	public object idivaregisterkindunifiedValue { 
		get{ return this["idivaregisterkindunified"];}
		set {if (value==null|| value==DBNull.Value) this["idivaregisterkindunified"]= DBNull.Value; else this["idivaregisterkindunified"]= value;}
	}
	public String idivaregisterkindunifiedOriginal { 
		get {if (this["idivaregisterkindunified",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idivaregisterkindunified",DataRowVersion.Original];}
	}
	public Int16? flagactivity{ 
		get {if (this["flagactivity"]==DBNull.Value)return null; return  (Int16?)this["flagactivity"];}
		set {if (value==null) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public object flagactivityValue { 
		get{ return this["flagactivity"];}
		set {if (value==null|| value==DBNull.Value) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public Int16? flagactivityOriginal { 
		get {if (this["flagactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["flagactivity",DataRowVersion.Original];}
	}
	public String codeivaregisterkind{ 
		get {return  (String)this["codeivaregisterkind"];}
		set {this["codeivaregisterkind"]= value;}
	}
	public object codeivaregisterkindValue { 
		get{ return this["codeivaregisterkind"];}
		set {this["codeivaregisterkind"]= value;}
	}
	public String codeivaregisterkindOriginal { 
		get {return  (String)this["codeivaregisterkind",DataRowVersion.Original];}
	}
	public Int32 idivaregisterkind{ 
		get {return  (Int32)this["idivaregisterkind"];}
		set {this["idivaregisterkind"]= value;}
	}
	public object idivaregisterkindValue { 
		get{ return this["idivaregisterkind"];}
		set {this["idivaregisterkind"]= value;}
	}
	public Int32 idivaregisterkindOriginal { 
		get {return  (Int32)this["idivaregisterkind",DataRowVersion.Original];}
	}
	public String compensation{ 
		get {if (this["compensation"]==DBNull.Value)return null; return  (String)this["compensation"];}
		set {if (value==null) this["compensation"]= DBNull.Value; else this["compensation"]= value;}
	}
	public object compensationValue { 
		get{ return this["compensation"];}
		set {if (value==null|| value==DBNull.Value) this["compensation"]= DBNull.Value; else this["compensation"]= value;}
	}
	public String compensationOriginal { 
		get {if (this["compensation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["compensation",DataRowVersion.Original];}
	}
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	public String emails{ 
		get {if (this["emails"]==DBNull.Value)return null; return  (String)this["emails"];}
		set {if (value==null) this["emails"]= DBNull.Value; else this["emails"]= value;}
	}
	public object emailsValue { 
		get{ return this["emails"];}
		set {if (value==null|| value==DBNull.Value) this["emails"]= DBNull.Value; else this["emails"]= value;}
	}
	public String emailsOriginal { 
		get {if (this["emails",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["emails",DataRowVersion.Original];}
	}
	#endregion

}
public class ivaregisterkindTable : MetaTableBase<ivaregisterkindRow> {
	public ivaregisterkindTable() : base("ivaregisterkind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"registerclass",createColumn("registerclass",typeof(string),false,false)},
			{"idivaregisterkindunified",createColumn("idivaregisterkindunified",typeof(string),true,false)},
			{"flagactivity",createColumn("flagactivity",typeof(short),true,false)},
			{"codeivaregisterkind",createColumn("codeivaregisterkind",typeof(string),false,false)},
			{"idivaregisterkind",createColumn("idivaregisterkind",typeof(int),false,false)},
			{"compensation",createColumn("compensation",typeof(string),true,false)},
			{"idtreasurer",createColumn("idtreasurer",typeof(int),true,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"emails",createColumn("emails",typeof(string),true,false)},
		};
	}
}
}

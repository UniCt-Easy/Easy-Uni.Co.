
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
namespace meta_address {
public class addressRow: MetaRow  {
	public addressRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///attivo
	///</summary>
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
	///<summary>
	///Codice
	///</summary>
	public String codeaddress{ 
		get {if (this["codeaddress"]==DBNull.Value)return null; return  (String)this["codeaddress"];}
		set {if (value==null) this["codeaddress"]= DBNull.Value; else this["codeaddress"]= value;}
	}
	public object codeaddressValue { 
		get{ return this["codeaddress"];}
		set {if (value==null|| value==DBNull.Value) this["codeaddress"]= DBNull.Value; else this["codeaddress"]= value;}
	}
	public String codeaddressOriginal { 
		get {if (this["codeaddress",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeaddress",DataRowVersion.Original];}
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
	///#
	///</summary>
	public Int32? idaddress{ 
		get {if (this["idaddress"]==DBNull.Value)return null; return  (Int32?)this["idaddress"];}
		set {if (value==null) this["idaddress"]= DBNull.Value; else this["idaddress"]= value;}
	}
	public object idaddressValue { 
		get{ return this["idaddress"];}
		set {if (value==null|| value==DBNull.Value) this["idaddress"]= DBNull.Value; else this["idaddress"]= value;}
	}
	public Int32? idaddressOriginal { 
		get {if (this["idaddress",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaddress",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Tipo Indirizzo  (anagrafica)
///</summary>
public class addressTable : MetaTableBase<addressRow> {
	public addressTable() : base("address"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"codeaddress",createColumn("codeaddress",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"idaddress",createColumn("idaddress",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
		};
	}
}
}

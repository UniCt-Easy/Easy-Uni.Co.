
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
namespace meta_registry_istitutiesteri {
public class registry_istitutiesteriRow: MetaRow  {
	public registry_istitutiesteriRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String city{ 
		get {if (this["city"]==DBNull.Value)return null; return  (String)this["city"];}
		set {if (value==null) this["city"]= DBNull.Value; else this["city"]= value;}
	}
	public object cityValue { 
		get{ return this["city"];}
		set {if (value==null|| value==DBNull.Value) this["city"]= DBNull.Value; else this["city"]= value;}
	}
	public String cityOriginal { 
		get {if (this["city",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["city",DataRowVersion.Original];}
	}
	public String code{ 
		get {if (this["code"]==DBNull.Value)return null; return  (String)this["code"];}
		set {if (value==null) this["code"]= DBNull.Value; else this["code"]= value;}
	}
	public object codeValue { 
		get{ return this["code"];}
		set {if (value==null|| value==DBNull.Value) this["code"]= DBNull.Value; else this["code"]= value;}
	}
	public String codeOriginal { 
		get {if (this["code",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["code",DataRowVersion.Original];}
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
	///<summary>
	///NACE code
	///</summary>
	public String idnace{ 
		get {if (this["idnace"]==DBNull.Value)return null; return  (String)this["idnace"];}
		set {if (value==null) this["idnace"]= DBNull.Value; else this["idnace"]= value;}
	}
	public object idnaceValue { 
		get{ return this["idnace"];}
		set {if (value==null|| value==DBNull.Value) this["idnace"]= DBNull.Value; else this["idnace"]= value;}
	}
	public String idnaceOriginal { 
		get {if (this["idnace",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idnace",DataRowVersion.Original];}
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
	///<summary>
	///Institutional code
	///</summary>
	public String institutionalcode{ 
		get {if (this["institutionalcode"]==DBNull.Value)return null; return  (String)this["institutionalcode"];}
		set {if (value==null) this["institutionalcode"]= DBNull.Value; else this["institutionalcode"]= value;}
	}
	public object institutionalcodeValue { 
		get{ return this["institutionalcode"];}
		set {if (value==null|| value==DBNull.Value) this["institutionalcode"]= DBNull.Value; else this["institutionalcode"]= value;}
	}
	public String institutionalcodeOriginal { 
		get {if (this["institutionalcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["institutionalcode",DataRowVersion.Original];}
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
	public String name{ 
		get {if (this["name"]==DBNull.Value)return null; return  (String)this["name"];}
		set {if (value==null) this["name"]= DBNull.Value; else this["name"]= value;}
	}
	public object nameValue { 
		get{ return this["name"];}
		set {if (value==null|| value==DBNull.Value) this["name"]= DBNull.Value; else this["name"]= value;}
	}
	public String nameOriginal { 
		get {if (this["name",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["name",DataRowVersion.Original];}
	}
	///<summary>
	///Reference number
	///</summary>
	public String referencenumber{ 
		get {if (this["referencenumber"]==DBNull.Value)return null; return  (String)this["referencenumber"];}
		set {if (value==null) this["referencenumber"]= DBNull.Value; else this["referencenumber"]= value;}
	}
	public object referencenumberValue { 
		get{ return this["referencenumber"];}
		set {if (value==null|| value==DBNull.Value) this["referencenumber"]= DBNull.Value; else this["referencenumber"]= value;}
	}
	public String referencenumberOriginal { 
		get {if (this["referencenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["referencenumber",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.30 Istituti esteri
///</summary>
public class registry_istitutiesteriTable : MetaTableBase<registry_istitutiesteriRow> {
	public registry_istitutiesteriTable() : base("registry_istitutiesteri"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"city",createColumn("city",typeof(string),false,false)},
			{"code",createColumn("code",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idnace",createColumn("idnace",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"institutionalcode",createColumn("institutionalcode",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"name",createColumn("name",typeof(string),false,false)},
			{"referencenumber",createColumn("referencenumber",typeof(string),true,false)},
		};
	}
}
}

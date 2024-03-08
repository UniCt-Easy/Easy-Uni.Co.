
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
namespace meta_virtualuser {
public class virtualuserRow: MetaRow  {
	public virtualuserRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public DateTime? birthdate{ 
		get {if (this["birthdate"]==DBNull.Value)return null; return  (DateTime?)this["birthdate"];}
		set {if (value==null) this["birthdate"]= DBNull.Value; else this["birthdate"]= value;}
	}
	public object birthdateValue { 
		get{ return this["birthdate"];}
		set {if (value==null|| value==DBNull.Value) this["birthdate"]= DBNull.Value; else this["birthdate"]= value;}
	}
	public DateTime? birthdateOriginal { 
		get {if (this["birthdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["birthdate",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale
	///</summary>
	public String cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (String)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public String cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cf",DataRowVersion.Original];}
	}
	public String codicedipartimento{ 
		get {if (this["codicedipartimento"]==DBNull.Value)return null; return  (String)this["codicedipartimento"];}
		set {if (value==null) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public object codicedipartimentoValue { 
		get{ return this["codicedipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public String codicedipartimentoOriginal { 
		get {if (this["codicedipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicedipartimento",DataRowVersion.Original];}
	}
	///<summary>
	///Email
	///</summary>
	public String email{ 
		get {if (this["email"]==DBNull.Value)return null; return  (String)this["email"];}
		set {if (value==null) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public object emailValue { 
		get{ return this["email"];}
		set {if (value==null|| value==DBNull.Value) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public String emailOriginal { 
		get {if (this["email",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email",DataRowVersion.Original];}
	}
	public String forename{ 
		get {if (this["forename"]==DBNull.Value)return null; return  (String)this["forename"];}
		set {if (value==null) this["forename"]= DBNull.Value; else this["forename"]= value;}
	}
	public object forenameValue { 
		get{ return this["forename"];}
		set {if (value==null|| value==DBNull.Value) this["forename"]= DBNull.Value; else this["forename"]= value;}
	}
	public String forenameOriginal { 
		get {if (this["forename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forename",DataRowVersion.Original];}
	}
	///<summary>
	///#
	///</summary>
	public Int32? idvirtualuser{ 
		get {if (this["idvirtualuser"]==DBNull.Value)return null; return  (Int32?)this["idvirtualuser"];}
		set {if (value==null) this["idvirtualuser"]= DBNull.Value; else this["idvirtualuser"]= value;}
	}
	public object idvirtualuserValue { 
		get{ return this["idvirtualuser"];}
		set {if (value==null|| value==DBNull.Value) this["idvirtualuser"]= DBNull.Value; else this["idvirtualuser"]= value;}
	}
	public Int32? idvirtualuserOriginal { 
		get {if (this["idvirtualuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idvirtualuser",DataRowVersion.Original];}
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
	///<summary>
	///Cognome
	///</summary>
	public String surname{ 
		get {if (this["surname"]==DBNull.Value)return null; return  (String)this["surname"];}
		set {if (value==null) this["surname"]= DBNull.Value; else this["surname"]= value;}
	}
	public object surnameValue { 
		get{ return this["surname"];}
		set {if (value==null|| value==DBNull.Value) this["surname"]= DBNull.Value; else this["surname"]= value;}
	}
	public String surnameOriginal { 
		get {if (this["surname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["surname",DataRowVersion.Original];}
	}
	public String sys_user{ 
		get {if (this["sys_user"]==DBNull.Value)return null; return  (String)this["sys_user"];}
		set {if (value==null) this["sys_user"]= DBNull.Value; else this["sys_user"]= value;}
	}
	public object sys_userValue { 
		get{ return this["sys_user"];}
		set {if (value==null|| value==DBNull.Value) this["sys_user"]= DBNull.Value; else this["sys_user"]= value;}
	}
	public String sys_userOriginal { 
		get {if (this["sys_user",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sys_user",DataRowVersion.Original];}
	}
	public Int32? userkind{ 
		get {if (this["userkind"]==DBNull.Value)return null; return  (Int32?)this["userkind"];}
		set {if (value==null) this["userkind"]= DBNull.Value; else this["userkind"]= value;}
	}
	public object userkindValue { 
		get{ return this["userkind"];}
		set {if (value==null|| value==DBNull.Value) this["userkind"]= DBNull.Value; else this["userkind"]= value;}
	}
	public Int32? userkindOriginal { 
		get {if (this["userkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["userkind",DataRowVersion.Original];}
	}
	public String username{ 
		get {if (this["username"]==DBNull.Value)return null; return  (String)this["username"];}
		set {if (value==null) this["username"]= DBNull.Value; else this["username"]= value;}
	}
	public object usernameValue { 
		get{ return this["username"];}
		set {if (value==null|| value==DBNull.Value) this["username"]= DBNull.Value; else this["username"]= value;}
	}
	public String usernameOriginal { 
		get {if (this["username",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["username",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Utente web
///</summary>
public class virtualuserTable : MetaTableBase<virtualuserRow> {
	public virtualuserTable() : base("virtualuser"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"birthdate",createColumn("birthdate",typeof(DateTime),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"codicedipartimento",createColumn("codicedipartimento",typeof(string),false,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),false,false)},
			{"idvirtualuser",createColumn("idvirtualuser",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"surname",createColumn("surname",typeof(string),false,false)},
			{"sys_user",createColumn("sys_user",typeof(string),false,false)},
			{"userkind",createColumn("userkind",typeof(int),false,false)},
			{"username",createColumn("username",typeof(string),false,false)},
		};
	}
}
}

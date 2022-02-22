
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_registryreference {
public class registryreferenceRow: MetaRow  {
	public registryreferenceRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String website{ 
		get {if (this["website"]==DBNull.Value)return null; return  (String)this["website"];}
		set {if (value==null) this["website"]= DBNull.Value; else this["website"]= value;}
	}
	public object websiteValue { 
		get{ return this["website"];}
		set {if (value==null|| value==DBNull.Value) this["website"]= DBNull.Value; else this["website"]= value;}
	}
	public String websiteOriginal { 
		get {if (this["website",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["website",DataRowVersion.Original];}
	}
	public String pec{ 
		get {if (this["pec"]==DBNull.Value)return null; return  (String)this["pec"];}
		set {if (value==null) this["pec"]= DBNull.Value; else this["pec"]= value;}
	}
	public object pecValue { 
		get{ return this["pec"];}
		set {if (value==null|| value==DBNull.Value) this["pec"]= DBNull.Value; else this["pec"]= value;}
	}
	public String pecOriginal { 
		get {if (this["pec",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pec",DataRowVersion.Original];}
	}
	///<summary>
	///accesso web attivato?
	///	 N: Non attivo
	///	 S: Attivo
	///</summary>
	public String activeweb{ 
		get {if (this["activeweb"]==DBNull.Value)return null; return  (String)this["activeweb"];}
		set {if (value==null) this["activeweb"]= DBNull.Value; else this["activeweb"]= value;}
	}
	public object activewebValue { 
		get{ return this["activeweb"];}
		set {if (value==null|| value==DBNull.Value) this["activeweb"]= DBNull.Value; else this["activeweb"]= value;}
	}
	public String activewebOriginal { 
		get {if (this["activeweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["activeweb",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///<summary>
	///Numero fax.
	///</summary>
	public String faxnumber{ 
		get {if (this["faxnumber"]==DBNull.Value)return null; return  (String)this["faxnumber"];}
		set {if (value==null) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public object faxnumberValue { 
		get{ return this["faxnumber"];}
		set {if (value==null|| value==DBNull.Value) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public String faxnumberOriginal { 
		get {if (this["faxnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["faxnumber",DataRowVersion.Original];}
	}
	///<summary>
	///Contatto predefinito
	///	 N: Non Ã¨ contatto predefinito
	///	 S: Contatto predefinito
	///</summary>
	public String flagdefault{ 
		get {if (this["flagdefault"]==DBNull.Value)return null; return  (String)this["flagdefault"];}
		set {if (value==null) this["flagdefault"]= DBNull.Value; else this["flagdefault"]= value;}
	}
	public object flagdefaultValue { 
		get{ return this["flagdefault"];}
		set {if (value==null|| value==DBNull.Value) this["flagdefault"]= DBNull.Value; else this["flagdefault"]= value;}
	}
	public String flagdefaultOriginal { 
		get {if (this["flagdefault",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdefault",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
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
	///#
	///</summary>
	public Int32? idregistryreference{ 
		get {if (this["idregistryreference"]==DBNull.Value)return null; return  (Int32?)this["idregistryreference"];}
		set {if (value==null) this["idregistryreference"]= DBNull.Value; else this["idregistryreference"]= value;}
	}
	public object idregistryreferenceValue { 
		get{ return this["idregistryreference"];}
		set {if (value==null|| value==DBNull.Value) this["idregistryreference"]= DBNull.Value; else this["idregistryreference"]= value;}
	}
	public Int32? idregistryreferenceOriginal { 
		get {if (this["idregistryreference",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistryreference",DataRowVersion.Original];}
	}
	///<summary>
	///iterazioni algoritmo di hashing
	///</summary>
	public Int32? iterweb{ 
		get {if (this["iterweb"]==DBNull.Value)return null; return  (Int32?)this["iterweb"];}
		set {if (value==null) this["iterweb"]= DBNull.Value; else this["iterweb"]= value;}
	}
	public object iterwebValue { 
		get{ return this["iterweb"];}
		set {if (value==null|| value==DBNull.Value) this["iterweb"]= DBNull.Value; else this["iterweb"]= value;}
	}
	public Int32? iterwebOriginal { 
		get {if (this["iterweb",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iterweb",DataRowVersion.Original];}
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
	///Num. cellulare
	///</summary>
	public String mobilenumber{ 
		get {if (this["mobilenumber"]==DBNull.Value)return null; return  (String)this["mobilenumber"];}
		set {if (value==null) this["mobilenumber"]= DBNull.Value; else this["mobilenumber"]= value;}
	}
	public object mobilenumberValue { 
		get{ return this["mobilenumber"];}
		set {if (value==null|| value==DBNull.Value) this["mobilenumber"]= DBNull.Value; else this["mobilenumber"]= value;}
	}
	public String mobilenumberOriginal { 
		get {if (this["mobilenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mobilenumber",DataRowVersion.Original];}
	}
	///<summary>
	///MSN No.
	///</summary>
	public String msnnumber{ 
		get {if (this["msnnumber"]==DBNull.Value)return null; return  (String)this["msnnumber"];}
		set {if (value==null) this["msnnumber"]= DBNull.Value; else this["msnnumber"]= value;}
	}
	public object msnnumberValue { 
		get{ return this["msnnumber"];}
		set {if (value==null|| value==DBNull.Value) this["msnnumber"]= DBNull.Value; else this["msnnumber"]= value;}
	}
	public String msnnumberOriginal { 
		get {if (this["msnnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["msnnumber",DataRowVersion.Original];}
	}
	///<summary>
	///password per accesso web
	///</summary>
	public String passwordweb{ 
		get {if (this["passwordweb"]==DBNull.Value)return null; return  (String)this["passwordweb"];}
		set {if (value==null) this["passwordweb"]= DBNull.Value; else this["passwordweb"]= value;}
	}
	public object passwordwebValue { 
		get{ return this["passwordweb"];}
		set {if (value==null|| value==DBNull.Value) this["passwordweb"]= DBNull.Value; else this["passwordweb"]= value;}
	}
	public String passwordwebOriginal { 
		get {if (this["passwordweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["passwordweb",DataRowVersion.Original];}
	}
	///<summary>
	///Numero tel.
	///</summary>
	public String phonenumber{ 
		get {if (this["phonenumber"]==DBNull.Value)return null; return  (String)this["phonenumber"];}
		set {if (value==null) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public object phonenumberValue { 
		get{ return this["phonenumber"];}
		set {if (value==null|| value==DBNull.Value) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public String phonenumberOriginal { 
		get {if (this["phonenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["phonenumber",DataRowVersion.Original];}
	}
	///<summary>
	///Nome Contatto
	///</summary>
	public String referencename{ 
		get {if (this["referencename"]==DBNull.Value)return null; return  (String)this["referencename"];}
		set {if (value==null) this["referencename"]= DBNull.Value; else this["referencename"]= value;}
	}
	public object referencenameValue { 
		get{ return this["referencename"];}
		set {if (value==null|| value==DBNull.Value) this["referencename"]= DBNull.Value; else this["referencename"]= value;}
	}
	public String referencenameOriginal { 
		get {if (this["referencename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["referencename",DataRowVersion.Original];}
	}
	///<summary>
	///Funzione contatto
	///</summary>
	public String registryreferencerole{ 
		get {if (this["registryreferencerole"]==DBNull.Value)return null; return  (String)this["registryreferencerole"];}
		set {if (value==null) this["registryreferencerole"]= DBNull.Value; else this["registryreferencerole"]= value;}
	}
	public object registryreferenceroleValue { 
		get{ return this["registryreferencerole"];}
		set {if (value==null|| value==DBNull.Value) this["registryreferencerole"]= DBNull.Value; else this["registryreferencerole"]= value;}
	}
	public String registryreferenceroleOriginal { 
		get {if (this["registryreferencerole",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["registryreferencerole",DataRowVersion.Original];}
	}
	///<summary>
	///allegati
	///</summary>
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
	///<summary>
	///sale per la codifica della password
	///</summary>
	public String saltweb{ 
		get {if (this["saltweb"]==DBNull.Value)return null; return  (String)this["saltweb"];}
		set {if (value==null) this["saltweb"]= DBNull.Value; else this["saltweb"]= value;}
	}
	public object saltwebValue { 
		get{ return this["saltweb"];}
		set {if (value==null|| value==DBNull.Value) this["saltweb"]= DBNull.Value; else this["saltweb"]= value;}
	}
	public String saltwebOriginal { 
		get {if (this["saltweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["saltweb",DataRowVersion.Original];}
	}
	///<summary>
	///Skype No.
	///</summary>
	public String skypenumber{ 
		get {if (this["skypenumber"]==DBNull.Value)return null; return  (String)this["skypenumber"];}
		set {if (value==null) this["skypenumber"]= DBNull.Value; else this["skypenumber"]= value;}
	}
	public object skypenumberValue { 
		get{ return this["skypenumber"];}
		set {if (value==null|| value==DBNull.Value) this["skypenumber"]= DBNull.Value; else this["skypenumber"]= value;}
	}
	public String skypenumberOriginal { 
		get {if (this["skypenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["skypenumber",DataRowVersion.Original];}
	}
	///<summary>
	///note testuali
	///</summary>
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
	///<summary>
	///login web
	///</summary>
	public String userweb{ 
		get {if (this["userweb"]==DBNull.Value)return null; return  (String)this["userweb"];}
		set {if (value==null) this["userweb"]= DBNull.Value; else this["userweb"]= value;}
	}
	public object userwebValue { 
		get{ return this["userweb"];}
		set {if (value==null|| value==DBNull.Value) this["userweb"]= DBNull.Value; else this["userweb"]= value;}
	}
	public String userwebOriginal { 
		get {if (this["userweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["userweb",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Contatto
///</summary>
public class registryreferenceTable : MetaTableBase<registryreferenceRow> {
	public registryreferenceTable() : base("registryreference"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"website",createColumn("website",typeof(string),true,false)},
			{"pec",createColumn("pec",typeof(string),true,false)},
			{"activeweb",createColumn("activeweb",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"faxnumber",createColumn("faxnumber",typeof(string),true,false)},
			{"flagdefault",createColumn("flagdefault",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idregistryreference",createColumn("idregistryreference",typeof(int),false,false)},
			{"iterweb",createColumn("iterweb",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"mobilenumber",createColumn("mobilenumber",typeof(string),true,false)},
			{"msnnumber",createColumn("msnnumber",typeof(string),true,false)},
			{"passwordweb",createColumn("passwordweb",typeof(string),true,false)},
			{"phonenumber",createColumn("phonenumber",typeof(string),true,false)},
			{"referencename",createColumn("referencename",typeof(string),false,false)},
			{"registryreferencerole",createColumn("registryreferencerole",typeof(string),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"saltweb",createColumn("saltweb",typeof(string),true,false)},
			{"skypenumber",createColumn("skypenumber",typeof(string),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"userweb",createColumn("userweb",typeof(string),true,false)},
		};
	}
}
}

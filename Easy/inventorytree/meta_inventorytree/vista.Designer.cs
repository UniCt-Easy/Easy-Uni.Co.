
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
namespace meta_inventorytree {
public class inventorytreeRow: MetaRow  {
	public inventorytreeRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///codice class.inventariale (tab. inventorytree)
	///</summary>
	public String codeinv{ 
		get {if (this["codeinv"]==DBNull.Value)return null; return  (String)this["codeinv"];}
		set {if (value==null) this["codeinv"]= DBNull.Value; else this["codeinv"]= value;}
	}
	public object codeinvValue { 
		get{ return this["codeinv"];}
		set {if (value==null|| value==DBNull.Value) this["codeinv"]= DBNull.Value; else this["codeinv"]= value;}
	}
	public String codeinvOriginal { 
		get {if (this["codeinv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeinv",DataRowVersion.Original];}
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
	///causale di scarico
	///</summary>
	public String idaccmotiveunload{ 
		get {if (this["idaccmotiveunload"]==DBNull.Value)return null; return  (String)this["idaccmotiveunload"];}
		set {if (value==null) this["idaccmotiveunload"]= DBNull.Value; else this["idaccmotiveunload"]= value;}
	}
	public object idaccmotiveunloadValue { 
		get{ return this["idaccmotiveunload"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiveunload"]= DBNull.Value; else this["idaccmotiveunload"]= value;}
	}
	public String idaccmotiveunloadOriginal { 
		get {if (this["idaccmotiveunload",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiveunload",DataRowVersion.Original];}
	}
	///<summary>
	///causale di carico
	///</summary>
	public String idaccmotiveload{ 
		get {if (this["idaccmotiveload"]==DBNull.Value)return null; return  (String)this["idaccmotiveload"];}
		set {if (value==null) this["idaccmotiveload"]= DBNull.Value; else this["idaccmotiveload"]= value;}
	}
	public object idaccmotiveloadValue { 
		get{ return this["idaccmotiveload"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotiveload"]= DBNull.Value; else this["idaccmotiveload"]= value;}
	}
	public String idaccmotiveloadOriginal { 
		get {if (this["idaccmotiveload",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotiveload",DataRowVersion.Original];}
	}
	///<summary>
	///N. livello
	///</summary>
	public Byte? nlevel{ 
		get {if (this["nlevel"]==DBNull.Value)return null; return  (Byte?)this["nlevel"];}
		set {if (value==null) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public object nlevelValue { 
		get{ return this["nlevel"];}
		set {if (value==null|| value==DBNull.Value) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public Byte? nlevelOriginal { 
		get {if (this["nlevel",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["nlevel",DataRowVersion.Original];}
	}
	///<summary>
	///ID class. inventariale (tabella inventorytree)
	///</summary>
	public Int32? idinv{ 
		get {if (this["idinv"]==DBNull.Value)return null; return  (Int32?)this["idinv"];}
		set {if (value==null) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {if (value==null|| value==DBNull.Value) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public Int32? idinvOriginal { 
		get {if (this["idinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinv",DataRowVersion.Original];}
	}
	///<summary>
	///id class.parent
	///</summary>
	public Int32? paridinv{ 
		get {if (this["paridinv"]==DBNull.Value)return null; return  (Int32?)this["paridinv"];}
		set {if (value==null) this["paridinv"]= DBNull.Value; else this["paridinv"]= value;}
	}
	public object paridinvValue { 
		get{ return this["paridinv"];}
		set {if (value==null|| value==DBNull.Value) this["paridinv"]= DBNull.Value; else this["paridinv"]= value;}
	}
	public Int32? paridinvOriginal { 
		get {if (this["paridinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridinv",DataRowVersion.Original];}
	}
	///<summary>
	///lookup usato in alcune migrazioni
	///</summary>
	public String lookupcode{ 
		get {if (this["lookupcode"]==DBNull.Value)return null; return  (String)this["lookupcode"];}
		set {if (value==null) this["lookupcode"]= DBNull.Value; else this["lookupcode"]= value;}
	}
	public object lookupcodeValue { 
		get{ return this["lookupcode"];}
		set {if (value==null|| value==DBNull.Value) this["lookupcode"]= DBNull.Value; else this["lookupcode"]= value;}
	}
	public String lookupcodeOriginal { 
		get {if (this["lookupcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lookupcode",DataRowVersion.Original];}
	}
	public String idaccmotivediscount{ 
		get {if (this["idaccmotivediscount"]==DBNull.Value)return null; return  (String)this["idaccmotivediscount"];}
		set {if (value==null) this["idaccmotivediscount"]= DBNull.Value; else this["idaccmotivediscount"]= value;}
	}
	public object idaccmotivediscountValue { 
		get{ return this["idaccmotivediscount"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivediscount"]= DBNull.Value; else this["idaccmotivediscount"]= value;}
	}
	public String idaccmotivediscountOriginal { 
		get {if (this["idaccmotivediscount",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivediscount",DataRowVersion.Original];}
	}
	public String idaccmotivetransfer{ 
		get {if (this["idaccmotivetransfer"]==DBNull.Value)return null; return  (String)this["idaccmotivetransfer"];}
		set {if (value==null) this["idaccmotivetransfer"]= DBNull.Value; else this["idaccmotivetransfer"]= value;}
	}
	public object idaccmotivetransferValue { 
		get{ return this["idaccmotivetransfer"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivetransfer"]= DBNull.Value; else this["idaccmotivetransfer"]= value;}
	}
	public String idaccmotivetransferOriginal { 
		get {if (this["idaccmotivetransfer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivetransfer",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Classificazione inventariale
///</summary>
public class inventorytreeTable : MetaTableBase<inventorytreeRow> {
	public inventorytreeTable() : base("inventorytree"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"codeinv",createColumn("codeinv",typeof(String),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"idaccmotiveunload",createColumn("idaccmotiveunload",typeof(String),true,false)},
			{"idaccmotiveload",createColumn("idaccmotiveload",typeof(String),true,false)},
			{"nlevel",createColumn("nlevel",typeof(Byte),false,false)},
			{"idinv",createColumn("idinv",typeof(Int32),false,false)},
			{"paridinv",createColumn("paridinv",typeof(Int32),true,false)},
			{"lookupcode",createColumn("lookupcode",typeof(String),true,false)},
			{"idaccmotivediscount",createColumn("idaccmotivediscount",typeof(String),true,false)},
			{"idaccmotivetransfer",createColumn("idaccmotivetransfer",typeof(String),true,false)},
		};
	}
}
}

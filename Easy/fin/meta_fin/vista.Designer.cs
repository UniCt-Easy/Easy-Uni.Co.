
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
namespace meta_fin {
public class finRow: MetaRow  {
	public finRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///esercizio
	///</summary>
	public Int16 ayear{ 
		get {return  (Int16)this["ayear"];}
		set {this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {this["ayear"]= value;}
	}
	public Int16 ayearOriginal { 
		get {return  (Int16)this["ayear",DataRowVersion.Original];}
	}
	///<summary>
	///codice bilancio
	///</summary>
	public String codefin{ 
		get {return  (String)this["codefin"];}
		set {this["codefin"]= value;}
	}
	public object codefinValue { 
		get{ return this["codefin"];}
		set {this["codefin"]= value;}
	}
	public String codefinOriginal { 
		get {return  (String)this["codefin",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///<summary>
	///Ordine di stampa
	///</summary>
	public String printingorder{ 
		get {return  (String)this["printingorder"];}
		set {this["printingorder"]= value;}
	}
	public object printingorderValue { 
		get{ return this["printingorder"];}
		set {this["printingorder"]= value;}
	}
	public String printingorderOriginal { 
		get {return  (String)this["printingorder",DataRowVersion.Original];}
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
	///Denominazione
	///</summary>
	public String title{ 
		get {return  (String)this["title"];}
		set {this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {this["title"]= value;}
	}
	public String titleOriginal { 
		get {return  (String)this["title",DataRowVersion.Original];}
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
	///id voce bilancio (tabella fin)
	///</summary>
	public Int32 idfin{ 
		get {return  (Int32)this["idfin"];}
		set {this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {this["idfin"]= value;}
	}
	public Int32 idfinOriginal { 
		get {return  (Int32)this["idfin",DataRowVersion.Original];}
	}
	///<summary>
	///id riga parent (tabella fin)
	///</summary>
	public Int32? paridfin{ 
		get {if (this["paridfin"]==DBNull.Value)return null; return  (Int32?)this["paridfin"];}
		set {if (value==null) this["paridfin"]= DBNull.Value; else this["paridfin"]= value;}
	}
	public object paridfinValue { 
		get{ return this["paridfin"];}
		set {if (value==null|| value==DBNull.Value) this["paridfin"]= DBNull.Value; else this["paridfin"]= value;}
	}
	public Int32? paridfinOriginal { 
		get {if (this["paridfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridfin",DataRowVersion.Original];}
	}
	///<summary>
	///N. livello
	///</summary>
	public Byte nlevel{ 
		get {return  (Byte)this["nlevel"];}
		set {this["nlevel"]= value;}
	}
	public object nlevelValue { 
		get{ return this["nlevel"];}
		set {this["nlevel"]= value;}
	}
	public Byte nlevelOriginal { 
		get {return  (Byte)this["nlevel",DataRowVersion.Original];}
	}
	///<summary>
	///Flag a bit
	///</summary>
	public Byte flag{ 
		get {return  (Byte)this["flag"];}
		set {this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {this["flag"]= value;}
	}
	public Byte flagOriginal { 
		get {return  (Byte)this["flag",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Bilancio
///</summary>
public class finTable : MetaTableBase<finRow> {
	public finTable() : base("fin"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ayear",createColumn("ayear",typeof(short),false,false)},
			{"codefin",createColumn("codefin",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"printingorder",createColumn("printingorder",typeof(string),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idfin",createColumn("idfin",typeof(int),false,false)},
			{"paridfin",createColumn("paridfin",typeof(int),true,false)},
			{"nlevel",createColumn("nlevel",typeof(byte),false,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
		};
	}
}
}

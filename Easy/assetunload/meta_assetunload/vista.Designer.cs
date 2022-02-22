
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
namespace meta_assetunload {
public class assetunloadRow: MetaRow  {
	public assetunloadRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. buono
	///</summary>
	public Int32 nassetunload{ 
		get {return  (Int32)this["nassetunload"];}
		set {this["nassetunload"]= value;}
	}
	public object nassetunloadValue { 
		get{ return this["nassetunload"];}
		set {this["nassetunload"]= value;}
	}
	public Int32 nassetunloadOriginal { 
		get {return  (Int32)this["nassetunload",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. buono
	///</summary>
	public Int16 yassetunload{ 
		get {return  (Int16)this["yassetunload"];}
		set {this["yassetunload"]= value;}
	}
	public object yassetunloadValue { 
		get{ return this["yassetunload"];}
		set {this["yassetunload"]= value;}
	}
	public Int16 yassetunloadOriginal { 
		get {return  (Int16)this["yassetunload",DataRowVersion.Original];}
	}
	///<summary>
	///data contabile, è la data a partire dalla quale il buono è efficace
	///</summary>
	public DateTime? adate{ 
		get {if (this["adate"]==DBNull.Value)return null; return  (DateTime?)this["adate"];}
		set {if (value==null) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {if (value==null|| value==DBNull.Value) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public DateTime? adateOriginal { 
		get {if (this["adate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adate",DataRowVersion.Original];}
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
	///documento
	///</summary>
	public String doc{ 
		get {if (this["doc"]==DBNull.Value)return null; return  (String)this["doc"];}
		set {if (value==null) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public object docValue { 
		get{ return this["doc"];}
		set {if (value==null|| value==DBNull.Value) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public String docOriginal { 
		get {if (this["doc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["doc",DataRowVersion.Original];}
	}
	///<summary>
	///data documento
	///</summary>
	public DateTime? docdate{ 
		get {if (this["docdate"]==DBNull.Value)return null; return  (DateTime?)this["docdate"];}
		set {if (value==null) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public object docdateValue { 
		get{ return this["docdate"];}
		set {if (value==null|| value==DBNull.Value) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public DateTime? docdateOriginal { 
		get {if (this["docdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["docdate",DataRowVersion.Original];}
	}
	///<summary>
	///Provvedimento
	///</summary>
	public String enactment{ 
		get {if (this["enactment"]==DBNull.Value)return null; return  (String)this["enactment"];}
		set {if (value==null) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public object enactmentValue { 
		get{ return this["enactment"];}
		set {if (value==null|| value==DBNull.Value) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public String enactmentOriginal { 
		get {if (this["enactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enactment",DataRowVersion.Original];}
	}
	///<summary>
	///Data provv.
	///</summary>
	public DateTime? enactmentdate{ 
		get {if (this["enactmentdate"]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate"];}
		set {if (value==null) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public object enactmentdateValue { 
		get{ return this["enactmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public DateTime? enactmentdateOriginal { 
		get {if (this["enactmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate",DataRowVersion.Original];}
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
	///Data stampa
	///</summary>
	public DateTime? printdate{ 
		get {if (this["printdate"]==DBNull.Value)return null; return  (DateTime?)this["printdate"];}
		set {if (value==null) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public object printdateValue { 
		get{ return this["printdate"];}
		set {if (value==null|| value==DBNull.Value) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public DateTime? printdateOriginal { 
		get {if (this["printdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["printdate",DataRowVersion.Original];}
	}
	///<summary>
	///Data ratifica
	///</summary>
	public DateTime? ratificationdate{ 
		get {if (this["ratificationdate"]==DBNull.Value)return null; return  (DateTime?)this["ratificationdate"];}
		set {if (value==null) this["ratificationdate"]= DBNull.Value; else this["ratificationdate"]= value;}
	}
	public object ratificationdateValue { 
		get{ return this["ratificationdate"];}
		set {if (value==null|| value==DBNull.Value) this["ratificationdate"]= DBNull.Value; else this["ratificationdate"]= value;}
	}
	public DateTime? ratificationdateOriginal { 
		get {if (this["ratificationdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ratificationdate",DataRowVersion.Original];}
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
	///Trasmesso (non più usato)
	///</summary>
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale (tabella motive)
	///</summary>
	public Int32? idmot{ 
		get {if (this["idmot"]==DBNull.Value)return null; return  (Int32?)this["idmot"];}
		set {if (value==null) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public object idmotValue { 
		get{ return this["idmot"];}
		set {if (value==null|| value==DBNull.Value) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public Int32? idmotOriginal { 
		get {if (this["idmot",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmot",DataRowVersion.Original];}
	}
	///<summary>
	///ID Tipi di buoni di scarico (tabella assetunloadkind)
	///</summary>
	public Int32 idassetunloadkind{ 
		get {return  (Int32)this["idassetunloadkind"];}
		set {this["idassetunloadkind"]= value;}
	}
	public object idassetunloadkindValue { 
		get{ return this["idassetunloadkind"];}
		set {this["idassetunloadkind"]= value;}
	}
	public Int32 idassetunloadkindOriginal { 
		get {return  (Int32)this["idassetunloadkind",DataRowVersion.Original];}
	}
	///<summary>
	///id buono di scarico (tabella assetunload)
	///</summary>
	public Int32 idassetunload{ 
		get {return  (Int32)this["idassetunload"];}
		set {this["idassetunload"]= value;}
	}
	public object idassetunloadValue { 
		get{ return this["idassetunload"];}
		set {this["idassetunload"]= value;}
	}
	public Int32 idassetunloadOriginal { 
		get {return  (Int32)this["idassetunload",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Buono di scarico
///</summary>
public class assetunloadTable : MetaTableBase<assetunloadRow> {
	public assetunloadTable() : base("assetunload"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nassetunload",createColumn("nassetunload",typeof(int),false,false)},
			{"yassetunload",createColumn("yassetunload",typeof(short),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"enactment",createColumn("enactment",typeof(string),true,false)},
			{"enactmentdate",createColumn("enactmentdate",typeof(DateTime),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"printdate",createColumn("printdate",typeof(DateTime),true,false)},
			{"ratificationdate",createColumn("ratificationdate",typeof(DateTime),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"transmitted",createColumn("transmitted",typeof(string),true,false)},
			{"idmot",createColumn("idmot",typeof(int),true,false)},
			{"idassetunloadkind",createColumn("idassetunloadkind",typeof(int),false,false)},
			{"idassetunload",createColumn("idassetunload",typeof(int),false,false)},
		};
	}
}
}

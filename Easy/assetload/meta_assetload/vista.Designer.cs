
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
#pragma warning disable 1591
namespace meta_assetload {
public class assetloadRow: MetaRow  {
	public assetloadRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. buono
	///</summary>
	public Int32? nassetload{ 
		get {if (this["nassetload"]==DBNull.Value)return null; return  (Int32?)this["nassetload"];}
		set {if (value==null) this["nassetload"]= DBNull.Value; else this["nassetload"]= value;}
	}
	public object nassetloadValue { 
		get{ return this["nassetload"];}
		set {if (value==null|| value==DBNull.Value) this["nassetload"]= DBNull.Value; else this["nassetload"]= value;}
	}
	public Int32? nassetloadOriginal { 
		get {if (this["nassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nassetload",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. buono
	///</summary>
	public Int16? yassetload{ 
		get {if (this["yassetload"]==DBNull.Value)return null; return  (Int16?)this["yassetload"];}
		set {if (value==null) this["yassetload"]= DBNull.Value; else this["yassetload"]= value;}
	}
	public object yassetloadValue { 
		get{ return this["yassetload"];}
		set {if (value==null|| value==DBNull.Value) this["yassetload"]= DBNull.Value; else this["yassetload"]= value;}
	}
	public Int16? yassetloadOriginal { 
		get {if (this["yassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yassetload",DataRowVersion.Original];}
	}
	///<summary>
	///data contabile
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
	///Data ratifica, è la data a partire dalla quale il buono è efficace
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
	///ID Tipi di buoni di carico (tabella assetloadkind)
	///</summary>
	public Int32? idassetloadkind{ 
		get {if (this["idassetloadkind"]==DBNull.Value)return null; return  (Int32?)this["idassetloadkind"];}
		set {if (value==null) this["idassetloadkind"]= DBNull.Value; else this["idassetloadkind"]= value;}
	}
	public object idassetloadkindValue { 
		get{ return this["idassetloadkind"];}
		set {if (value==null|| value==DBNull.Value) this["idassetloadkind"]= DBNull.Value; else this["idassetloadkind"]= value;}
	}
	public Int32? idassetloadkindOriginal { 
		get {if (this["idassetloadkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetloadkind",DataRowVersion.Original];}
	}
	///<summary>
	///id buono carico (tabella assetload)
	///</summary>
	public Int32? idassetload{ 
		get {if (this["idassetload"]==DBNull.Value)return null; return  (Int32?)this["idassetload"];}
		set {if (value==null) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public object idassetloadValue { 
		get{ return this["idassetload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public Int32? idassetloadOriginal { 
		get {if (this["idassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetload",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Buono di carico
///</summary>
public class assetloadTable : MetaTableBase<assetloadRow> {
	public assetloadTable() : base("assetload"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nassetload",createColumn("nassetload",typeof(Int32),false,false)},
			{"yassetload",createColumn("yassetload",typeof(Int16),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"description",createColumn("description",typeof(String),true,false)},
			{"doc",createColumn("doc",typeof(String),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"enactment",createColumn("enactment",typeof(String),true,false)},
			{"enactmentdate",createColumn("enactmentdate",typeof(DateTime),true,false)},
			{"idreg",createColumn("idreg",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"printdate",createColumn("printdate",typeof(DateTime),true,false)},
			{"ratificationdate",createColumn("ratificationdate",typeof(DateTime),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"transmitted",createColumn("transmitted",typeof(String),true,false)},
			{"idmot",createColumn("idmot",typeof(Int32),true,false)},
			{"idassetloadkind",createColumn("idassetloadkind",typeof(Int32),false,false)},
			{"idassetload",createColumn("idassetload",typeof(Int32),false,false)},
		};
	}
}
}

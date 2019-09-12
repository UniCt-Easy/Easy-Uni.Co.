/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_proceeds {
public class proceedsRow: MetaRow  {
	public proceedsRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. reversale
	///</summary>
	public Int32? npro{ 
		get {if (this["npro"]==DBNull.Value)return null; return  (Int32?)this["npro"];}
		set {if (value==null) this["npro"]= DBNull.Value; else this["npro"]= value;}
	}
	public object nproValue { 
		get{ return this["npro"];}
		set {if (value==null|| value==DBNull.Value) this["npro"]= DBNull.Value; else this["npro"]= value;}
	}
	public Int32? nproOriginal { 
		get {if (this["npro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npro",DataRowVersion.Original];}
	}
	///<summary>
	///Anno reversale
	///</summary>
	public Int16? ypro{ 
		get {if (this["ypro"]==DBNull.Value)return null; return  (Int16?)this["ypro"];}
		set {if (value==null) this["ypro"]= DBNull.Value; else this["ypro"]= value;}
	}
	public object yproValue { 
		get{ return this["ypro"];}
		set {if (value==null|| value==DBNull.Value) this["ypro"]= DBNull.Value; else this["ypro"]= value;}
	}
	public Int16? yproOriginal { 
		get {if (this["ypro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ypro",DataRowVersion.Original];}
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
	///Data annullamento
	///</summary>
	public DateTime? annulmentdate{ 
		get {if (this["annulmentdate"]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate"];}
		set {if (value==null) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public object annulmentdateValue { 
		get{ return this["annulmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public DateTime? annulmentdateOriginal { 
		get {if (this["annulmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate",DataRowVersion.Original];}
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
	///id voce bilancio (tabella fin)
	///</summary>
	public Int32? idfin{ 
		get {if (this["idfin"]==DBNull.Value)return null; return  (Int32?)this["idfin"];}
		set {if (value==null) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {if (value==null|| value==DBNull.Value) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public Int32? idfinOriginal { 
		get {if (this["idfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin",DataRowVersion.Original];}
	}
	///<summary>
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	///<summary>
	///Id cassiere (tabella treasurer)
	///</summary>
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
	///<summary>
	///Tipo competenza e flag fruttifero
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///chiave reversale (tabella proceeds)
	///</summary>
	public Int32? kpro{ 
		get {if (this["kpro"]==DBNull.Value)return null; return  (Int32?)this["kpro"];}
		set {if (value==null) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public object kproValue { 
		get{ return this["kpro"];}
		set {if (value==null|| value==DBNull.Value) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public Int32? kproOriginal { 
		get {if (this["kpro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpro",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave elenco trasmissione (tabella proceedstransmission)
	///</summary>
	public Int32? kproceedstransmission{ 
		get {if (this["kproceedstransmission"]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission"];}
		set {if (value==null) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public object kproceedstransmissionValue { 
		get{ return this["kproceedstransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public Int32? kproceedstransmissionOriginal { 
		get {if (this["kproceedstransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission",DataRowVersion.Original];}
	}
	///<summary>
	///ID Trattamento del bollo (tabella stamphandling)
	///</summary>
	public Int32? idstamphandling{ 
		get {if (this["idstamphandling"]==DBNull.Value)return null; return  (Int32?)this["idstamphandling"];}
		set {if (value==null) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public object idstamphandlingValue { 
		get{ return this["idstamphandling"];}
		set {if (value==null|| value==DBNull.Value) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public Int32? idstamphandlingOriginal { 
		get {if (this["idstamphandling",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstamphandling",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave esterna per db collegati
	///</summary>
	public String external_reference{ 
		get {if (this["external_reference"]==DBNull.Value)return null; return  (String)this["external_reference"];}
		set {if (value==null) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public object external_referenceValue { 
		get{ return this["external_reference"];}
		set {if (value==null|| value==DBNull.Value) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public String external_referenceOriginal { 
		get {if (this["external_reference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["external_reference",DataRowVersion.Original];}
	}
	///<summary>
	///Num. progressivo Cassiere
	///</summary>
	public Int32? npro_treasurer{ 
		get {if (this["npro_treasurer"]==DBNull.Value)return null; return  (Int32?)this["npro_treasurer"];}
		set {if (value==null) this["npro_treasurer"]= DBNull.Value; else this["npro_treasurer"]= value;}
	}
	public object npro_treasurerValue { 
		get{ return this["npro_treasurer"];}
		set {if (value==null|| value==DBNull.Value) this["npro_treasurer"]= DBNull.Value; else this["npro_treasurer"]= value;}
	}
	public Int32? npro_treasurerOriginal { 
		get {if (this["npro_treasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npro_treasurer",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Documento di incasso
///</summary>
public class proceedsTable : MetaTableBase<proceedsRow> {
	public proceedsTable() : base("proceeds"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("npro")){ 
			defineColumn("npro", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ypro")){ 
			defineColumn("ypro", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("annulmentdate")){ 
			defineColumn("annulmentdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idreg")){ 
			defineColumn("idreg", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("printdate")){ 
			defineColumn("printdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("idfin")){ 
			defineColumn("idfin", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idtreasurer")){ 
			defineColumn("idtreasurer", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("kpro")){ 
			defineColumn("kpro", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("kproceedstransmission")){ 
			defineColumn("kproceedstransmission", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idstamphandling")){ 
			defineColumn("idstamphandling", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("external_reference")){ 
			defineColumn("external_reference", typeof(System.String));
		}
		if (definedColums.ContainsKey("npro_treasurer")){ 
			defineColumn("npro_treasurer", typeof(System.Int32));
		}
		#endregion

	}
}
}


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
namespace meta_flussocrediti {
public class flussocreditiRow: MetaRow  {
	public flussocreditiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num.Flusso
	///</summary>
	public Int32? idflusso{ 
		get {if (this["idflusso"]==DBNull.Value)return null; return  (Int32?)this["idflusso"];}
		set {if (value==null) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {if (value==null|| value==DBNull.Value) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public Int32? idflussoOriginal { 
		get {if (this["idflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idflusso",DataRowVersion.Original];}
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
	///Data creazione flusso
	///</summary>
	public DateTime? datacreazioneflusso{ 
		get {if (this["datacreazioneflusso"]==DBNull.Value)return null; return  (DateTime?)this["datacreazioneflusso"];}
		set {if (value==null) this["datacreazioneflusso"]= DBNull.Value; else this["datacreazioneflusso"]= value;}
	}
	public object datacreazioneflussoValue { 
		get{ return this["datacreazioneflusso"];}
		set {if (value==null|| value==DBNull.Value) this["datacreazioneflusso"]= DBNull.Value; else this["datacreazioneflusso"]= value;}
	}
	public DateTime? datacreazioneflussoOriginal { 
		get {if (this["datacreazioneflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datacreazioneflusso",DataRowVersion.Original];}
	}
	///<summary>
	///Ultimo file generato (stringa)
	///</summary>
	public String flusso{ 
		get {if (this["flusso"]==DBNull.Value)return null; return  (String)this["flusso"];}
		set {if (value==null) this["flusso"]= DBNull.Value; else this["flusso"]= value;}
	}
	public object flussoValue { 
		get{ return this["flusso"];}
		set {if (value==null|| value==DBNull.Value) this["flusso"]= DBNull.Value; else this["flusso"]= value;}
	}
	public String flussoOriginal { 
		get {if (this["flusso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flusso",DataRowVersion.Original];}
	}
	///<summary>
	///trasmesso
	///	 N: Non ancora trasmesso
	///	 S: trasmesso
	///</summary>
	public String istransmitted{ 
		get {if (this["istransmitted"]==DBNull.Value)return null; return  (String)this["istransmitted"];}
		set {if (value==null) this["istransmitted"]= DBNull.Value; else this["istransmitted"]= value;}
	}
	public object istransmittedValue { 
		get{ return this["istransmitted"];}
		set {if (value==null|| value==DBNull.Value) this["istransmitted"]= DBNull.Value; else this["istransmitted"]= value;}
	}
	public String istransmittedOriginal { 
		get {if (this["istransmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["istransmitted",DataRowVersion.Original];}
	}
	///<summary>
	///attributi di sicurezza 1
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
	///attributi di sicurezza 2
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
	///attributi di sicurezza 3
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
	///attributi di sicurezza 4
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
	///attributi di sicurezza 5
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
	///Nome file
	///</summary>
	public String filename{ 
		get {if (this["filename"]==DBNull.Value)return null; return  (String)this["filename"];}
		set {if (value==null) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public object filenameValue { 
		get{ return this["filename"];}
		set {if (value==null|| value==DBNull.Value) this["filename"]= DBNull.Value; else this["filename"]= value;}
	}
	public String filenameOriginal { 
		get {if (this["filename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["filename",DataRowVersion.Original];}
	}
	///<summary>
	///progressivo giornaliero
	///</summary>
	public Int32? progday{ 
		get {if (this["progday"]==DBNull.Value)return null; return  (Int32?)this["progday"];}
		set {if (value==null) this["progday"]= DBNull.Value; else this["progday"]= value;}
	}
	public object progdayValue { 
		get{ return this["progday"];}
		set {if (value==null|| value==DBNull.Value) this["progday"]= DBNull.Value; else this["progday"]= value;}
	}
	public Int32? progdayOriginal { 
		get {if (this["progday",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["progday",DataRowVersion.Original];}
	}
	///<summary>
	///Data documento
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
	///tipo contratto attivo associato, può mancare se è un flusso in estrazione
	///</summary>
	public String idestimkind{ 
		get {if (this["idestimkind"]==DBNull.Value)return null; return  (String)this["idestimkind"];}
		set {if (value==null) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public object idestimkindValue { 
		get{ return this["idestimkind"];}
		set {if (value==null|| value==DBNull.Value) this["idestimkind"]= DBNull.Value; else this["idestimkind"]= value;}
	}
	public String idestimkindOriginal { 
		get {if (this["idestimkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idestimkind",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Crediti da comunicare al nodo pagamenti o simili, anche usata per i crediti che ci vengono comunicati dalle segreterie studenti
///</summary>
public class flussocreditiTable : MetaTableBase<flussocreditiRow> {
	public flussocreditiTable() : base("flussocrediti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(Int32),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"datacreazioneflusso",createColumn("datacreazioneflusso",typeof(DateTime),true,false)},
			{"flusso",createColumn("flusso",typeof(String),true,false)},
			{"istransmitted",createColumn("istransmitted",typeof(String),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
			{"filename",createColumn("filename",typeof(String),true,false)},
			{"progday",createColumn("progday",typeof(Int32),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"idestimkind",createColumn("idestimkind",typeof(String),true,false)},
		};
	}
}
}

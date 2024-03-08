
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
namespace meta_flussocrediti {
public class flussocreditiRow: MetaRow  {
	public flussocreditiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idflusso{ 
		get {return  (Int32)this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public Int32 idflussoOriginal { 
		get {return  (Int32)this["idflusso",DataRowVersion.Original];}
	}
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
public class flussocreditiTable : MetaTableBase<flussocreditiRow> {
	public flussocreditiTable() : base("flussocrediti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"datacreazioneflusso",createColumn("datacreazioneflusso",typeof(DateTime),true,false)},
			{"flusso",createColumn("flusso",typeof(string),true,false)},
			{"istransmitted",createColumn("istransmitted",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"filename",createColumn("filename",typeof(string),true,false)},
			{"progday",createColumn("progday",typeof(int),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"idestimkind",createColumn("idestimkind",typeof(string),true,false)},
		};
	}
}
}
